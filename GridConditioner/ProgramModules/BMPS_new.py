
import sys, string, os, arcpy
from arcpy import env

# returns 1 if field can be found; returns 0 if field or layer does not exist
def Field_DoesntExist(layer_name, field_name):
	if arcpy.Exists(layer_name):
		if len(arcpy.ListFields(layer_name, field_name)) <> 0:
			return 0 # Field exists
		else:
			return 1 # Field does not exist
	else:
		return 2 # Layer does not exist
		
#Enable overwriting files that already exist
arcpy.OverWriteOutput = True

#set the workspace
arcpy.env.workspace = "Database Connections\\GRID_CONDITIONING.GIS.sde"# (VERSION:DBO.DEFAULT)"
theExtentsLayer = sys.argv[1]

#move the BMP layer from the file to the server
GRID_CONDITIONING_GIS_theOutput = "Database Connections\\GRID_CONDITIONING.GIS.sde\\GRID_CONDITIONING.GIS.BMP_Output"
GRID_CONDITIONING_GIS_sde = "Database Connections\\GRID_CONDITIONING.GIS.sde"
#Delte old versions and copy to server
try:
    arcpy.Delete_management(GRID_CONDITIONING_GIS_theOutput, "")
except:
    print(theExtentsLayer + " BMP ServerTable ready to be created")
arcpy.FeatureClassToFeatureClass_conversion(theExtentsLayer, GRID_CONDITIONING_GIS_sde, "BMP_Output")


    
#==================================
#Get all of the featureclasses in the workspace (database)
fcList = arcpy.ListFeatureClasses()
#==================================


#I don't think this next variable is important
#Boundaries_Select = "theOutput_Dis"

#This is where a dissolve happened in the original zoning process.
#Dissolving here is actually a good idea
#Check to see if the BMP_TYPE field is there
# Process: Dissolve
BMP_Select = "BMP_Output_Dis"

if arcpy.Exists("Database Connections\\GRID_CONDITIONING.GIS.sde\\GRID_CONDITIONING.GIS.BMP_Output_Dis"):
  arcpy.Delete_management("Database Connections\\GRID_CONDITIONING.GIS.sde\\GRID_CONDITIONING.GIS.BMP_Output_Dis", "")
arcpy.Dissolve_management(GRID_CONDITIONING_GIS_theOutput, "Database Connections\\GRID_CONDITIONING.GIS.sde\\GRID_CONDITIONING.GIS.BMP_Output_Dis", "PRF_GEN_TY", "", "MULTI_PART", "DISSOLVE_LINES")

Result = Field_DoesntExist(BMP_Select, "PRF_GEN_TY")
if (Result == 0) :
  
  #BasicGrid_Clip is all the grid cells that we created for this GridModel
  IFI = "BasicGrid_Clip"
  
  #This section just backs up the grid table and the boundaries table
  #============================================
  if arcpy.Exists("theGrid"):
    arcpy.Delete_management("theGrid", "")
  arcpy.Copy_management(IFI, "theGrid")
  
  if arcpy.Exists("BMPBoundaries"):
    arcpy.Delete_management("BMPBoundaries", "")
    arcpy.Copy_management(BMP_Select, "BMPBoundaries")
  
  #============================================
  #This section adds and updates the area fields of the Grid cells
  #This should be done on the BMP and the Grid copy
  #============================================
  #This section adds and updates the area fields of the Grid cells
  #============================================
  arcpy.AddField_management("theGrid", "Area_ft2", "FLOAT", "", "", "", "", "NULLABLE", "NON_REQUIRED", "")
  arcpy.CalculateField_management("theGrid" , "Area_ft2", "float(!shape.area!)", "PYTHON", "#")
  arcpy.AddField_management("theGrid", "SourceObjectID", "LONG", "", "", "", "", "NULLABLE", "NON_REQUIRED", "")
  arcpy.CalculateField_management("theGrid" , "SourceObjectID", "long(!OBJECTID!)", "PYTHON", "#")
  
  
  #We cannot expect the server to be clean of previous runs
  #So we have to remove any 'Y' style tables from the database.
  #========================================================
  fcs = arcpy.ListFeatureClasses()
  for fc in fcs:
    #if the name of the fc starts with an Y, then delete from the server, otherwise, skip
    #arcpy.AddMessage(fc)
    if fc.split('.')[2][0] == "Y":
      arcpy.Delete_management(fc, "")
      print "Deleted " + fc
  #========================================================
  
  #Get the set of variables that will be used:
  #the set of rows, the number of different kinds of land use areas
  Wrows = arcpy.SearchCursor(BMP_Select)
  Wrow = Wrows.next()
  Nfeatures = str(arcpy.GetCount_management(BMP_Select))
  arcpy.AddMessage(Nfeatures + " Records to Process")
  arcpy.ClusterTolerance = 0.1
  
  while  Wrow:
    WFValue = str(Wrow.PRF_GEN_TY)
    print WFValue
    #arcpy.AddMessage("Processing BMP Area " + str(Wrow.BMP_TYPE))
    if WFValue == "IMP":
      variableARG = 1
    else:
      #create a layer that has only the current BMP boundary object in it
      #==================================================================================
      arcpy.MakeFeatureLayer_management(BMP_Select, "thelyr", "\"PRF_GEN_TY\"= '"+str(Wrow.PRF_GEN_TY)+"'")
      #arcpy.Update
      #arcpy.AddMessage("prepping layer " +str(Wrow.OBJECTID))
      #==================================================================================
      
      #cut the grid with the land use layer
      #===================================================================
      arcpy.Clip_analysis("theGrid", "thelyr", "Y" + str(Wrow.PRF_GEN_TY) , "")
      #===================================================================
      
      # Process: Add Fields...
      #=============================================================================
      arcpy.AddField_management("Y" + str(Wrow.PRF_GEN_TY), "area_", "TEXT", "", "", "256", "", "NULLABLE", "NON_REQUIRED", "")
      arcpy.AddField_management("Y" + str(Wrow.PRF_GEN_TY), "theFrac", "DOUBLE", "", "", "", "", "NULLABLE", "NON_REQUIRED", "")
      #=============================================================================
      
      #Calculate the fraction and update the output layer
      #=============================================================================
      arcpy.CalculateField_management("Y" + str(Wrow.PRF_GEN_TY) , "area_", "'" + WFValue + "'", "PYTHON", "#")
      #because the clip_analysis function can AND DOES cause some grid cells to
      #have a larger than 10,000ft^2 area, 'theFrac' needs to be checked
      #again using sql, and those values that are greater than 1.0 should
      #be made apparent to the user.  This is a red herring, but hey,
      #We just split like a million polygons.
      arcpy.CalculateField_management("Y" + str(Wrow.PRF_GEN_TY) , "theFrac", "(float(!shape.area!))/!Area_ft2!", "PYTHON", "#")

      arcpy.Delete_management("thelyr")
    Wrow = Wrows.next()
  #Now that this is done, we need to create a table that can be imported into the 
  # table [GRIDMODEL].[dbo].[GRID_PDX_BMP_GRID] for use in the GRIDMODEL
  
else:
  if (Result == 1) :
    variablex = 1
    #arcpy.AddMessage("Boundaries table does not have an 'LUType' field")
  if (Result == 2) :
    variablez = 1
    #arcpy.AddMessage("Boundaries table does not exist")  
  
  
  
  
  
  
  
  
