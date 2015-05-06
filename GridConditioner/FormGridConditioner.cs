using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;

namespace GridConditioner
{
    public partial class FormGridConditioner : Form
    {
        
        // Get the path that stores the python script.
        string myDocumentsPath;

        public FormGridConditioner()
        {
            //System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //ConnectionStringsSection mySection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            //ConnectionStringSettings conSet = new ConnectionStringSettings("GridConditioner.Properties.Settings.GRID_CONDITIONINGConnectionString", "");
            //mySection.ConnectionStrings.Add(conSet);

            /*foreach (ConnectionStringSettings s in config.ConnectionStrings.ConnectionStrings)
            {
                MessageBox.Show(s.ConnectionString);
            }

            config.ConnectionStrings.ConnectionStrings["GridConditioner.Properties.Settings.GRID_CONDITIONINGConnectionString"].ConnectionString = @"Server=BESDBDEV1;Database=GRID_CONDTITIONER;Trusted_Connection=True;";
            config.Save(ConfigurationSaveMode.Modified); 
            */

            InitializeComponent();
        }

        int CreateXMLOutputFile()
        {
            //this method creates the XML output file.
            //Returns a 0 if the file can be created, Returns a 1 if the file cannot be created.

            //create a file dialog box to get the user's intended path
            SaveFileDialog theDialog = new SaveFileDialog();
            theDialog.Filter = "xml files (.xml)|*.xml";
            DialogResult theResult = theDialog.ShowDialog();

            if (theResult == DialogResult.OK)
            {

                //try to create the file in the intended path
                string filename = theDialog.FileName;

                //try to write to the file in the intended path
                //the dataset here should just be the list of input paths
                //and files.  Maybe I could just create a dataset and fill it up?
                //Sounds like a cheap and easy way to make this work as quickly as possible.

                if (gRID_CONDITIONINGDataSet.ProcessLayerList == null || gRID_CONDITIONINGDataSet.ProcessLayerList.Count == 0) { return 1; }

                try
                {
                    // Create the FileStream to write with.
                    System.IO.FileStream myFileStream = new System.IO.FileStream
                        (filename, System.IO.FileMode.Create);
                    // Create an XmlTextWriter with the fileStream.
                    System.Xml.XmlTextWriter myXmlWriter =
                        new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
                    // Write to the file with the WriteXml method.
                    gRID_CONDITIONINGDataSet.ProcessLayerList.WriteXml(myXmlWriter);
                    myXmlWriter.Close();
                }
                catch (Exception ex)
                {
                    return 1;
                }

                return 0;
            }

            return 1;
        }

        private void buttonCreateZoningLayer_Click(object sender, EventArgs e)
        {
            //Try to create the XML output path, if it is not possible to create an XML output file, 
            //then we must quit.
            if (textBoxBoundariesLayerPath.Text == "")
            {
                MessageBox.Show("Must select a shapefile for boundaries");
                return;
            }

            int results = CreateXMLOutputFile();

            if (results == 0)
            {
                // Get the path that stores the python script.
                string myDocumentsPath = Application.StartupPath;
                bool isFirstUpdateLayer = true;
                MyProcess myProcess = new MyProcess();

                myProcess.ExecuteNamedScript("\"" + textBoxBoundariesLayerPath.Text + "\" " + numericUpDownCellSize.Value.ToString(), "CreateGrid.py", myDocumentsPath);
                //Create a copy of the basic grid for impervious processing.
                myProcess.ExecuteNamedScript("\"Database Connections\\GRID_CONDITIONING.GIS.sde\\GRID_CONDITIONING.GIS.BasicGrid_Clip\" BasicGrid_ClipIMP", "CopyLayers.py", myDocumentsPath);

                foreach (GRID_CONDITIONINGDataSet.ProcessLayerListRow theDataRowView in gRID_CONDITIONINGDataSet.ProcessLayerList.Rows)
                {
                    myProcess.ExecuteNamedScript("\"" + theDataRowView[1] + "\" " +
                        "\"" + theDataRowView[0] + "\" " +
                        "\"" + theDataRowView[2] + "\" " +
                        "\"" + theDataRowView[3] + "\" " +
                        "\"" + textBoxBoundariesLayerPath.Text + "\" " +
                        "\"" + textBoxPassword.Text + "\" ", "GeneralizedCleaningScript.py", myDocumentsPath);
                }
                foreach (GRID_CONDITIONINGDataSet.ProcessLayerListRow theDataRowView in gRID_CONDITIONINGDataSet.ProcessLayerList.Rows)
                {
                    if (isFirstUpdateLayer && string.Compare((string)theDataRowView[2], "IMP") != 0)
                    {
                        myProcess.ExecuteNamedScript("\"Database Connections\\GRID_CONDITIONING.GIS.sde\\GRID_CONDITIONING.GIS." + (string)theDataRowView[0] + "\" theOutput", "CopyLayers.py", myDocumentsPath);
                        isFirstUpdateLayer = false;
                    }
                    else if (string.Compare((string)theDataRowView[2], "IMP") != 0)
                    {
                        myProcess.ExecuteNamedScript("\"" + (string)theDataRowView[0] + "\" theOutput", "UpdateLayers.py", myDocumentsPath);
                    }
                    else
                    {
                        myProcess.ExecuteNamedScript("\"Database Connections\\GRID_CONDITIONING.GIS.sde\\GRID_CONDITIONING.GIS." + (string)theDataRowView[0] + "\" theOutputIMP", "CopyLayers.py", myDocumentsPath);
                    }
                }
                foreach (GRID_CONDITIONINGDataSet.ProcessLayerListRow theDataRowView in gRID_CONDITIONINGDataSet.ProcessLayerList.Rows)
                {
                    myProcess.ExecuteNamedScript("\"" + (string)theDataRowView[0] + "\"", "DeleteLayers.py", myDocumentsPath);
                }

                myProcess.ExecuteNamedScript("", "CutGridByLandUse.py", myDocumentsPath);
                myProcess.ExecuteNamedScript("\"" + numericUpDownCellSize.Value.ToString() + "\" " + 
                                             "\"" + textBoxPassword.Text + "\" ", "UpdateCellCounts.py", myDocumentsPath);

                myProcess.ExecuteNamedScript("", "CutGridByLandUseIMP.py", myDocumentsPath);
                myProcess.ExecuteNamedScript("\"" + numericUpDownCellSize.Value.ToString() + "\" " +
                                             "\"" + textBoxPassword.Text + "\" ", "UpdateCellCountsIMP.py", myDocumentsPath);

                myProcess.ExecuteNamedScript("", "CutIMPByLandUse.py", myDocumentsPath);
                myProcess.ExecuteNamedScript("\"" + numericUpDownCellSize.Value.ToString() + "\" "  +
                                             "\"" + textBoxPassword.Text + "\" ", "UpdateCellCountsSubIMP.py", myDocumentsPath);

                MessageBox.Show("Continue?", "Application", MessageBoxButtons.OKCancel);
            }
            else
            {
                MessageBox.Show("Could not create and/or write to output xml file.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gRID_CONDITIONINGDataSet.ZONINGTYPES' table. You can move, or remove it, as needed.
            this.zONINGTYPESTableAdapter.Fill(this.gRID_CONDITIONINGDataSet.ZONINGTYPES);
            // TODO: This line of code loads data into the 'gRID_CONDITIONINGDataSet.USERLAYERS' table. You can move, or remove it, as needed.
            this.uSERLAYERSTableAdapter.Fill(this.gRID_CONDITIONINGDataSet.USERLAYERS);
            // TODO: This line of code loads data into the 'gRID_CONDITIONINGDataSet.COMMONLAYERS' table. You can move, or remove it, as needed.
            this.cOMMONLAYERSTableAdapter.Fill(this.gRID_CONDITIONINGDataSet.COMMONLAYERS);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.uSERLAYERSBindingSource1.EndEdit();
            this.uSERLAYERSTableAdapter.Update(this.gRID_CONDITIONINGDataSet);
        }

        private void buttonAddCommonLayerToProcess_Click(object sender, EventArgs e)
        {
            //this process should just add the selected common layer to the list of layers to be processed
            //listBoxLayersToProcess.Items.Add(listBoxCommonLayers.SelectedItem);

            gRID_CONDITIONINGDataSet.ProcessLayerList.AddProcessLayerListRow((string)((DataRowView)listBoxCommonLayers.SelectedItem)[1],
                                                                               (string)((DataRowView)listBoxCommonLayers.SelectedItem)[2],
                                                                               (string)((DataRowView)listBoxCommonLayers.SelectedItem)[3],
                                                                               (string)((DataRowView)listBoxCommonLayers.SelectedItem)[4]);
        }

        private void buttonAddUniqueLayerToProcess_Click(object sender, EventArgs e)
        {
            try
            {
                //this process should just add the selected unique layer to the list of layers to be processed
                gRID_CONDITIONINGDataSet.ProcessLayerList.AddProcessLayerListRow((string)(((DataGridViewRow)dataGridView1.CurrentRow).Cells[1].Value),
                                                                                   (string)(((DataGridViewRow)dataGridView1.CurrentRow).Cells[2].Value),
                                                                                   (string)(((DataGridViewRow)dataGridView1.CurrentRow).Cells[3].Value),
                                                                                   (string)(((DataGridViewRow)dataGridView1.CurrentRow).Cells[4].Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Did not select a valid layer!");
            }
        }

        private void buttonRemoveLayerFromProcess_Click(object sender, EventArgs e)
        {
            string theValue = (string)((DataRowView)listBoxLayersToProcess.SelectedItem)[0];
            GRID_CONDITIONINGDataSet.ProcessLayerListRow theRow = (GRID_CONDITIONINGDataSet.ProcessLayerListRow)(gRID_CONDITIONINGDataSet.ProcessLayerList.Select("ShortName = '" + theValue + "'"))[0];

            gRID_CONDITIONINGDataSet.ProcessLayerList.RemoveProcessLayerListRow(theRow);
        }

        private void buttonAddUniqueLayer_Click(object sender, EventArgs e)
        {

        }

        private void buttonChangeBoundariesLayer_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult theBoundaryPathResult = openFileDialog1.ShowDialog();
                if (theBoundaryPathResult == DialogResult.OK)
                {
                    //Should probably check to make sure that this is a polygon
                    //shapefile with valid column names and valid column
                    //data

                    textBoxBoundariesLayerPath.Text = openFileDialog1.FileName;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAddChangeSelectionSetLayer_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult theBoundaryPathResult = openFileDialog1.ShowDialog();
                if (theBoundaryPathResult == DialogResult.OK)
                {
                    txtSelectionSetLayer.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateSelectionSets_Click(object sender, EventArgs e)
        {
            string myDocumentsPath = Application.StartupPath;
            MyProcess myProcess = new MyProcess();

            myProcess.ExecuteNamedScript("\"" + txtSelectionSetLayer.Text + "\" " + numericUpDownCellSize.Value.ToString(), "BMPS_new.py", myDocumentsPath);
            myProcess.ExecuteNamedScript("\"" + textBoxPassword.Text + "\" ", "UpdateBMPCounts.py", myDocumentsPath);
        }

        private void buttonEnableLinks_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();

            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // ConnectionStringsSection mySection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            //config.ConnectionStrings.ConnectionStrings["GridConditioner.Properties.Settings.GRID_CONDITIONINGConnectionString"].ConnectionString = @"Server=BESDBDEV1;Database=GRID_CONDTITIONER;Trusted_Connection=True;";
            //config.ConnectionStrings.ConnectionStrings["GridConditioner.Properties.Settings.GRID_CONDITIONINGConnectionString"].ConnectionString = "Data Source=BESDBDEV1;Initial Catalog=GRID_CONDITIONING;User ID=GIS;Password=" + textBoxPassword.Text  ;
            //config.Save(ConfigurationSaveMode.Modified);

            conn.ConnectionString = "Data Source=BESDBDEV1;Initial Catalog=GRID_CONDITIONING;User ID=GIS;Password=" + textBoxPassword.Text;

            try
            {
                conn.Open();

                foreach (Control cntrl in FormGridConditioner.ActiveForm.Controls)
                {
                    
                    cntrl.Visible = true;
                    cntrl.Enabled = true;
                    cntrl.Refresh();
                }

                textBoxPassword.ReadOnly = true;
            }
            catch (SqlException ex)
            {
                // output the error to see what's going on
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }

    public class MyProcess
    {
        // These are the Win32 error code for file not found or access denied.
        const int ERROR_FILE_NOT_FOUND = 2;
        const int ERROR_ACCESS_DENIED = 5;

        /// <summary>
        /// Executes a python script.
        /// </summary>
        public void ExecuteScript(string commandLineArguments, string outClassName, string myDocumentsPath)
        {
            Process myProcess = new Process();
            try
            {
                //Set the fully qualified script name
                myProcess.StartInfo.FileName = myDocumentsPath + "\\Yall.py";
                //Execute the script:
                myProcess.StartInfo.Arguments = commandLineArguments;
                myProcess.Start();
                // Wait for it to die...
                myProcess.WaitForExit();
            }
            catch (Win32Exception e)
            {
                if (e.NativeErrorCode == ERROR_FILE_NOT_FOUND)
                {
                    Console.WriteLine(e.Message + ". Check the path.");
                }

                else if (e.NativeErrorCode == ERROR_ACCESS_DENIED)
                {
                    // Note that if your word processor might generate exceptions
                    // such as this, which are handled first.
                    Console.WriteLine(e.Message +
                    ". You do not have permission to print this file.");
                }
            }
        }

        /// <summary>
        /// Executes a python script.
        /// </summary>
        public void ExecuteNamedScript(string commandLineArguments, string scriptName, string myDocumentsPath)
        {
            Process myProcess = new Process();

            try
            {
                //Set the fully qualified script name
                myProcess.StartInfo.FileName = myDocumentsPath + "\\ProgramModules\\" + scriptName;
                //Execute the script:
                myProcess.StartInfo.Arguments = commandLineArguments;
                myProcess.Start();
                // Wait for it to die...
                myProcess.WaitForExit();
            }
            catch (Win32Exception e)
            {
                if (e.NativeErrorCode == ERROR_FILE_NOT_FOUND)
                {
                    MessageBox.Show(e.Message + ". Check the path.");
                }

                else if (e.NativeErrorCode == ERROR_ACCESS_DENIED)
                {
                    // Note that if your word processor might generate exceptions
                    // such as this, which are handled first.
                    Console.WriteLine(e.Message +
                    ". You do not have permission to print this file.");
                }
                else
                {
                    MessageBox.Show("You screwed up!");
                }
            }
        }
    }
}
