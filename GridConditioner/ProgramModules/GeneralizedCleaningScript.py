# ---------------------------------------------------------------------------
# GeneralizedCleaningScript
# Created on: Wed March 30 2011 09:10:25 AM
# ---------------------------------------------------------------------------

# Import system modules
import sys, string, os, arcpy, pyodbc as p, time
from arcpy import env
InClassPath = sys.argv[1]
OutClassName = sys.argv[2]
ZoneType = sys.argv[3]
ZoneField = sys.argv[4]
theExtentsLayer = sys.argv[5]
Password = sys.argv[6]
# Set the necessary product code
#gp.SetProduct("ArcInfo")  
arcpy.OverWriteOutput = True

#Local variables
modules = sys.path[0]
GRID_CONDITIONING_GIS_sde = "Database Connections\\GRID_CONDITIONING.GIS.sde"
SERVEROUTCLASSNAME = "Database Connections\\GRID_CONDITIONING.GIS.sde\\GRID_CONDITIONING.GIS." + OutClassName + "_PreDissolve"
SERVEROUTCLASSNAME_FINAL = "Database Connections\\GRID_CONDITIONING.GIS.sde\\GRID_CONDITIONING.GIS." + OutClassName

time.sleep(5)    
#Set up clipping extents
desc = arcpy.Describe(theExtentsLayer)

XMin = desc.extent.XMin
YMin = desc.extent.YMin
XMax = desc.extent.XMax 
YMax = desc.extent.YMax 


extentsMin = str(XMin) + " " + str(YMin)
extentsMax = str(XMax) + " " + str(YMax)
extentsYAxis = str(XMin) + " " + str(YMin + 10)

#Copy local
env.workspace = modules
print modules
print(OutClassName)
try:
    arcpy.Delete_management(OutClassName +".shp", "")
except:
    print(OutClassName + " ready to be created")
#arcpy.FeatureClassToFeatureClass_conversion(InClassPath, modules, OutClassName)
#Clip layer so it doesn't take all day
try:
        arcpy.Clip_analysis(InClassPath, theExtentsLayer, OutClassName, "0.1 Feet")
except:
        print "Created BasicGrid_Clip"


#if we are dealing with the Arterials layer, it needs to be buffered before we can move on    
#Check to see if we are dealing with the Arterials layer:
x = 1
if (InClassPath == "Database Connections\\\\CGIS_Layer.sde\\\\EGH_PUBLIC.ARCMAP_ADMIN.major_arterials_metro"):
    #Have to buffer the layer etc
    try:
        arcpy.Delete_management(OutClassName + "_Buffer.shp", "")
    except:
        print(OutClassName + "_Buffer.shp ready to be created")
    arcpy.Buffer_analysis  (modules + "\\" + OutClassName + ".shp", modules + "\\" + OutClassName + "_Buffer.shp", "30 Feet", "FULL", "ROUND", "NONE", "")
    #Delete the line layer
    arcpy.Delete_management(modules + "\\" + OutClassName + ".shp", "")
    #Rename the new layer
    arcpy.Rename_management(modules + "\\" + OutClassName + "_Buffer.shp", modules + "\\" + OutClassName + ".shp", "")

#if we are dealing with the Streets layer, it needs to be buffered before we can move on    
#Check to see if we are dealing with the Streets layer:
x = 1
if (InClassPath == "Database Connections\\\\CGIS_Layer.sde\\\\EGH_PUBLIC.ARCMAP_ADMIN.streets_pdx"):
    #Have to buffer the layer etc
    try:
        arcpy.Delete_management(OutClassName + "_Buffer.shp", "")
    except:
        print(OutClassName + "_Buffer.shp ready to be created")
    arcpy.Buffer_analysis  (modules + "\\" + OutClassName + ".shp", modules + "\\" + OutClassName + "_Buffer.shp", "15 Feet", "FULL", "ROUND", "NONE", "")
    #Delete the line layer
    arcpy.Delete_management(modules + "\\" + OutClassName + ".shp", "")
    #Rename the new layer
    arcpy.Rename_management(modules + "\\" + OutClassName + "_Buffer.shp", modules + "\\" + OutClassName + ".shp", "")

#Repair geometry
arcpy.RepairGeometry_management(modules + "\\" + OutClassName + ".shp", "DELETE_NULL")

#Single part dissolve
try:
    arcpy.Delete_management(OutClassName + "Dissolve.shp", "")
except:
    print(OutClassName + "Dissolve.shp ready to be created")
if(ZoneField == "NONE"):
    arcpy.Dissolve_management(modules + "\\" + OutClassName + ".shp", modules + "\\" + OutClassName + "Dissolve.shp", "", "", "SINGLE_PART", "DISSOLVE_LINES")
else:
    arcpy.Dissolve_management(modules + "\\" + OutClassName + ".shp", modules + "\\" + OutClassName + "Dissolve.shp", ZoneField, "", "SINGLE_PART", "DISSOLVE_LINES")

#Delete first copy
arcpy.Delete_management(modules + "\\" + OutClassName + ".shp", "")

#Simplify
try:
    arcpy.Delete_management(OutClassName + "Simplify.shp", "")
except:
    print(OutClassName + "Simplify.shp ready to be created")
#arcpy.SimplifyPolygon_cartography(modules + "\\" + OutClassName + "Dissolve.shp", modules + "\\" + OutClassName + "Simplify.shp", "POINT_REMOVE", "1 Feet", "5 SquareFeet", "NO_CHECK", "NO_KEEP")

#Delte old versions and copy to server
try:
    arcpy.Delete_management(SERVEROUTCLASSNAME, "")
except:
    print(OutClassName + "Simplify.shp ready to be created")
arcpy.FeatureClassToFeatureClass_conversion(modules + "\\" + OutClassName + "Dissolve.shp", GRID_CONDITIONING_GIS_sde, OutClassName + "_PreDissolve")

#Delete 2nd copy
arcpy.Delete_management(modules + "\\" + OutClassName + "Dissolve.shp", "")
#arcpy.Delete_management(modules + "\\" + OutClassName + "Simplify.shp", "")
#arcpy.Delete_management(modules + "\\" + OutClassName + "Simplify_Pnt.shp", "")

#Connect to the server
server = 'BESDBDEV1'
database = 'GRID_CONDITIONING'
connStr = (r'DRIVER={SQL Server}; SERVER=' + server + ';DATABASE=' + database + ';' + 'UID=GIS;PWD=' + Password)
conn = p.connect(connStr)

#Add LU_TYPE field
arcpy.AddField_management(SERVEROUTCLASSNAME, "LUType", "TEXT", "", "", "", "", "NULLABLE", "NON_REQUIRED", "")

#Update LU_TYPE field
if(ZoneField == "NONE"):
    theSQL = ("UPDATE [GIS].[" + OutClassName + "_PreDissolve" + "] SET LUType = '" + ZoneType + "'")    
else:
    theSQL = ("UPDATE [GIS].[" + OutClassName + "_PreDissolve" + "] SET LUType = [" + ZoneField + "]")
    
#ZoningMetro and possibly ZoningPDX are special cases
#Problem is that for now, there is no zoning key for zoningpdx, so just don't even think about moving it in
if (InClassPath == "Database Connections\\\\CGIS_Layer.sde\\\\EGH_PUBLIC.ARCMAP_ADMIN.zoning_metro"):
    theSQL = ("UPDATE [GIS].["+ OutClassName + "_PreDissolve" + "] SET LUType = GRID_ZONING FROM [GIS].["+ OutClassName + "_PreDissolve" + "] INNER JOIN [GIS].[METROZONINGROSETTA] ON ZONEGEN_CL = METRO_ZONING")
if (InClassPath == "Database Connections\\\\CGIS_Layer.sde\\\\EGH_PUBLIC.ARCMAP_ADMIN.zoning_pdx"):
    theSQL = ("UPDATE [GIS].["+ OutClassName + "_PreDissolve" + "] SET LUType = GRID_ZONING FROM [GIS].["+ OutClassName + "_PreDissolve" + "] INNER JOIN [GIS].[PDXZONINGROSETTA] ON ZONE = PDX_ZONING")

dbCursor = conn.cursor()
dbCursor.execute(theSQL)
conn.commit()
    
#Delete fields that are not LU_TYPE or Shape.area or OBJECTID or Shape or Shape.len
fields = arcpy.ListFields(SERVEROUTCLASSNAME)
for field in fields:
    if (field.name == 'Shape') | (field.name == 'Shape.area') | (field.name == 'OBJECTID') | (field.name == 'Shape.len') | (field.name == 'LUType'):
        DoSomething = 0#used to be an output function here.
    else:
        arcpy.DeleteField_management(SERVEROUTCLASSNAME, field.name)
        
#Multi-part dissolve based on LU_TYPE
#delete if it already exists
try:
    arcpy.Delete_management(SERVEROUTCLASSNAME_FINAL, "")
except:
    print("")
arcpy.Dissolve_management(SERVEROUTCLASSNAME, SERVEROUTCLASSNAME_FINAL, "LUType", "", "MULTI_PART", "DISSOLVE_LINES")

time.sleep(10)
#Delete the undissolved table
arcpy.Delete_management(SERVEROUTCLASSNAME, "")

