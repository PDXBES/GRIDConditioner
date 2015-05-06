namespace GridConditioner
{
    partial class FormGridConditioner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonCreateZoningLayer = new System.Windows.Forms.Button();
            this.listBoxCommonLayers = new System.Windows.Forms.ListBox();
            this.cOMMONLAYERSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gRID_CONDITIONINGDataSet = new GridConditioner.GRID_CONDITIONINGDataSet();
            this.cOMMONLAYERSTableAdapter = new GridConditioner.GRID_CONDITIONINGDataSetTableAdapters.COMMONLAYERSTableAdapter();
            this.labelCommonLayers = new System.Windows.Forms.Label();
            this.labelUserLayers = new System.Windows.Forms.Label();
            this.textBoxPathOfLastSelectedLayer = new System.Windows.Forms.TextBox();
            this.listBoxLayersToProcess = new System.Windows.Forms.ListBox();
            this.processLayerListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gRIDCONDITIONINGDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSERLAYERSTableAdapter = new GridConditioner.GRID_CONDITIONINGDataSetTableAdapters.USERLAYERSTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.oBJECTIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shortNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.landUseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.zONINGTYPESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.landUseColumnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uSERLAYERSBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.zONINGTYPESTableAdapter = new GridConditioner.GRID_CONDITIONINGDataSetTableAdapters.ZONINGTYPESTableAdapter();
            this.buttonAddCommonLayerToProcess = new System.Windows.Forms.Button();
            this.buttonAddUniqueLayerToProcess = new System.Windows.Forms.Button();
            this.buttonRemoveLayerFromProcess = new System.Windows.Forms.Button();
            this.labelPathOfLastSelectedLayer = new System.Windows.Forms.Label();
            this.buttonDeleteUniqueLayer = new System.Windows.Forms.Button();
            this.buttonAddUniqueLayer = new System.Windows.Forms.Button();
            this.labelBoundariesLayerPath = new System.Windows.Forms.Label();
            this.buttonChangeBoundariesLayer = new System.Windows.Forms.Button();
            this.textBoxBoundariesLayerPath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.numericUpDownCellSize = new System.Windows.Forms.NumericUpDown();
            this.labelCellSize = new System.Windows.Forms.Label();
            this.textBoxXMLOutputPath = new System.Windows.Forms.TextBox();
            this.labelXMLOutputPath = new System.Windows.Forms.Label();
            this.ultraPanelSelectionSets = new Infragistics.Win.Misc.UltraPanel();
            this.buttonAddChangeSelectionSetLayer = new Infragistics.Win.Misc.UltraButton();
            this.txtSelectionSetLayer = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabelSelectionSetLayer = new Infragistics.Win.Misc.UltraLabel();
            this.btnCreateSelectionSets = new Infragistics.Win.Misc.UltraButton();
            this.labelUserID = new System.Windows.Forms.Label();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonEnableLinks = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cOMMONLAYERSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gRID_CONDITIONINGDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processLayerListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gRIDCONDITIONINGDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zONINGTYPESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSERLAYERSBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCellSize)).BeginInit();
            this.ultraPanelSelectionSets.ClientArea.SuspendLayout();
            this.ultraPanelSelectionSets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSelectionSetLayer)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCreateZoningLayer
            // 
            this.buttonCreateZoningLayer.Enabled = false;
            this.buttonCreateZoningLayer.Location = new System.Drawing.Point(434, 576);
            this.buttonCreateZoningLayer.Name = "buttonCreateZoningLayer";
            this.buttonCreateZoningLayer.Size = new System.Drawing.Size(128, 23);
            this.buttonCreateZoningLayer.TabIndex = 0;
            this.buttonCreateZoningLayer.Text = "Create zoning layer!";
            this.buttonCreateZoningLayer.UseVisualStyleBackColor = true;
            this.buttonCreateZoningLayer.Visible = false;
            this.buttonCreateZoningLayer.Click += new System.EventHandler(this.buttonCreateZoningLayer_Click);
            // 
            // listBoxCommonLayers
            // 
            this.listBoxCommonLayers.DataSource = this.cOMMONLAYERSBindingSource;
            this.listBoxCommonLayers.DisplayMember = "ShortName";
            this.listBoxCommonLayers.Enabled = false;
            this.listBoxCommonLayers.FormattingEnabled = true;
            this.listBoxCommonLayers.Location = new System.Drawing.Point(26, 117);
            this.listBoxCommonLayers.Name = "listBoxCommonLayers";
            this.listBoxCommonLayers.Size = new System.Drawing.Size(452, 82);
            this.listBoxCommonLayers.TabIndex = 1;
            this.listBoxCommonLayers.ValueMember = "Path";
            this.listBoxCommonLayers.Visible = false;
            // 
            // cOMMONLAYERSBindingSource
            // 
            this.cOMMONLAYERSBindingSource.DataMember = "COMMONLAYERS";
            this.cOMMONLAYERSBindingSource.DataSource = this.gRID_CONDITIONINGDataSet;
            // 
            // gRID_CONDITIONINGDataSet
            // 
            this.gRID_CONDITIONINGDataSet.DataSetName = "GRID_CONDITIONINGDataSet";
            this.gRID_CONDITIONINGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cOMMONLAYERSTableAdapter
            // 
            this.cOMMONLAYERSTableAdapter.ClearBeforeFill = true;
            // 
            // labelCommonLayers
            // 
            this.labelCommonLayers.AutoSize = true;
            this.labelCommonLayers.Enabled = false;
            this.labelCommonLayers.Location = new System.Drawing.Point(23, 101);
            this.labelCommonLayers.Name = "labelCommonLayers";
            this.labelCommonLayers.Size = new System.Drawing.Size(82, 13);
            this.labelCommonLayers.TabIndex = 3;
            this.labelCommonLayers.Text = "Common Layers";
            this.labelCommonLayers.Visible = false;
            // 
            // labelUserLayers
            // 
            this.labelUserLayers.AutoSize = true;
            this.labelUserLayers.Enabled = false;
            this.labelUserLayers.Location = new System.Drawing.Point(23, 206);
            this.labelUserLayers.Name = "labelUserLayers";
            this.labelUserLayers.Size = new System.Drawing.Size(75, 13);
            this.labelUserLayers.TabIndex = 4;
            this.labelUserLayers.Text = "Unique Layers";
            this.labelUserLayers.Visible = false;
            // 
            // textBoxPathOfLastSelectedLayer
            // 
            this.textBoxPathOfLastSelectedLayer.Enabled = false;
            this.textBoxPathOfLastSelectedLayer.Location = new System.Drawing.Point(26, 401);
            this.textBoxPathOfLastSelectedLayer.Name = "textBoxPathOfLastSelectedLayer";
            this.textBoxPathOfLastSelectedLayer.ReadOnly = true;
            this.textBoxPathOfLastSelectedLayer.Size = new System.Drawing.Size(452, 20);
            this.textBoxPathOfLastSelectedLayer.TabIndex = 5;
            this.textBoxPathOfLastSelectedLayer.Visible = false;
            // 
            // listBoxLayersToProcess
            // 
            this.listBoxLayersToProcess.DataSource = this.processLayerListBindingSource;
            this.listBoxLayersToProcess.DisplayMember = "ShortName";
            this.listBoxLayersToProcess.Enabled = false;
            this.listBoxLayersToProcess.FormattingEnabled = true;
            this.listBoxLayersToProcess.Location = new System.Drawing.Point(26, 427);
            this.listBoxLayersToProcess.Name = "listBoxLayersToProcess";
            this.listBoxLayersToProcess.Size = new System.Drawing.Size(452, 95);
            this.listBoxLayersToProcess.TabIndex = 6;
            this.listBoxLayersToProcess.ValueMember = "Path";
            this.listBoxLayersToProcess.Visible = false;
            // 
            // processLayerListBindingSource
            // 
            this.processLayerListBindingSource.DataMember = "ProcessLayerList";
            this.processLayerListBindingSource.DataSource = this.gRID_CONDITIONINGDataSet;
            // 
            // gRIDCONDITIONINGDataSetBindingSource
            // 
            this.gRIDCONDITIONINGDataSetBindingSource.DataSource = this.gRID_CONDITIONINGDataSet;
            this.gRIDCONDITIONINGDataSetBindingSource.Position = 0;
            // 
            // uSERLAYERSTableAdapter
            // 
            this.uSERLAYERSTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.oBJECTIDDataGridViewTextBoxColumn,
            this.shortNameDataGridViewTextBoxColumn,
            this.pathDataGridViewTextBoxColumn,
            this.landUseDataGridViewTextBoxColumn,
            this.landUseColumnDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.uSERLAYERSBindingSource1;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(26, 222);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 21;
            this.dataGridView1.Size = new System.Drawing.Size(452, 130);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.Visible = false;
            // 
            // oBJECTIDDataGridViewTextBoxColumn
            // 
            this.oBJECTIDDataGridViewTextBoxColumn.DataPropertyName = "OBJECTID";
            this.oBJECTIDDataGridViewTextBoxColumn.HeaderText = "OBJECTID";
            this.oBJECTIDDataGridViewTextBoxColumn.Name = "oBJECTIDDataGridViewTextBoxColumn";
            this.oBJECTIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.oBJECTIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // shortNameDataGridViewTextBoxColumn
            // 
            this.shortNameDataGridViewTextBoxColumn.DataPropertyName = "ShortName";
            this.shortNameDataGridViewTextBoxColumn.HeaderText = "ShortName";
            this.shortNameDataGridViewTextBoxColumn.Name = "shortNameDataGridViewTextBoxColumn";
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "Path";
            this.pathDataGridViewTextBoxColumn.HeaderText = "Path";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            // 
            // landUseDataGridViewTextBoxColumn
            // 
            this.landUseDataGridViewTextBoxColumn.DataPropertyName = "LandUse";
            this.landUseDataGridViewTextBoxColumn.DataSource = this.zONINGTYPESBindingSource;
            this.landUseDataGridViewTextBoxColumn.HeaderText = "LandUse";
            this.landUseDataGridViewTextBoxColumn.Name = "landUseDataGridViewTextBoxColumn";
            this.landUseDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.landUseDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.landUseDataGridViewTextBoxColumn.ValueMember = "ZONINGTYPE";
            // 
            // zONINGTYPESBindingSource
            // 
            this.zONINGTYPESBindingSource.DataMember = "ZONINGTYPES";
            this.zONINGTYPESBindingSource.DataSource = this.gRID_CONDITIONINGDataSet;
            // 
            // landUseColumnDataGridViewTextBoxColumn
            // 
            this.landUseColumnDataGridViewTextBoxColumn.DataPropertyName = "LandUseColumn";
            this.landUseColumnDataGridViewTextBoxColumn.HeaderText = "LandUseColumn";
            this.landUseColumnDataGridViewTextBoxColumn.Name = "landUseColumnDataGridViewTextBoxColumn";
            // 
            // uSERLAYERSBindingSource1
            // 
            this.uSERLAYERSBindingSource1.DataMember = "USERLAYERS";
            this.uSERLAYERSBindingSource1.DataSource = this.gRIDCONDITIONINGDataSetBindingSource;
            // 
            // zONINGTYPESTableAdapter
            // 
            this.zONINGTYPESTableAdapter.ClearBeforeFill = true;
            // 
            // buttonAddCommonLayerToProcess
            // 
            this.buttonAddCommonLayerToProcess.Enabled = false;
            this.buttonAddCommonLayerToProcess.Location = new System.Drawing.Point(484, 117);
            this.buttonAddCommonLayerToProcess.Name = "buttonAddCommonLayerToProcess";
            this.buttonAddCommonLayerToProcess.Size = new System.Drawing.Size(78, 82);
            this.buttonAddCommonLayerToProcess.TabIndex = 9;
            this.buttonAddCommonLayerToProcess.Text = "Add selected common layer to process";
            this.buttonAddCommonLayerToProcess.UseVisualStyleBackColor = true;
            this.buttonAddCommonLayerToProcess.Visible = false;
            this.buttonAddCommonLayerToProcess.Click += new System.EventHandler(this.buttonAddCommonLayerToProcess_Click);
            // 
            // buttonAddUniqueLayerToProcess
            // 
            this.buttonAddUniqueLayerToProcess.Enabled = false;
            this.buttonAddUniqueLayerToProcess.Location = new System.Drawing.Point(484, 222);
            this.buttonAddUniqueLayerToProcess.Name = "buttonAddUniqueLayerToProcess";
            this.buttonAddUniqueLayerToProcess.Size = new System.Drawing.Size(78, 130);
            this.buttonAddUniqueLayerToProcess.TabIndex = 10;
            this.buttonAddUniqueLayerToProcess.Text = "Add selected unique layer to process";
            this.buttonAddUniqueLayerToProcess.UseVisualStyleBackColor = true;
            this.buttonAddUniqueLayerToProcess.Visible = false;
            this.buttonAddUniqueLayerToProcess.Click += new System.EventHandler(this.buttonAddUniqueLayerToProcess_Click);
            // 
            // buttonRemoveLayerFromProcess
            // 
            this.buttonRemoveLayerFromProcess.Enabled = false;
            this.buttonRemoveLayerFromProcess.Location = new System.Drawing.Point(484, 427);
            this.buttonRemoveLayerFromProcess.Name = "buttonRemoveLayerFromProcess";
            this.buttonRemoveLayerFromProcess.Size = new System.Drawing.Size(78, 95);
            this.buttonRemoveLayerFromProcess.TabIndex = 11;
            this.buttonRemoveLayerFromProcess.Text = "Remove selected layer from process";
            this.buttonRemoveLayerFromProcess.UseVisualStyleBackColor = true;
            this.buttonRemoveLayerFromProcess.Visible = false;
            this.buttonRemoveLayerFromProcess.Click += new System.EventHandler(this.buttonRemoveLayerFromProcess_Click);
            // 
            // labelPathOfLastSelectedLayer
            // 
            this.labelPathOfLastSelectedLayer.AutoSize = true;
            this.labelPathOfLastSelectedLayer.Enabled = false;
            this.labelPathOfLastSelectedLayer.Location = new System.Drawing.Point(26, 385);
            this.labelPathOfLastSelectedLayer.Name = "labelPathOfLastSelectedLayer";
            this.labelPathOfLastSelectedLayer.Size = new System.Drawing.Size(131, 13);
            this.labelPathOfLastSelectedLayer.TabIndex = 12;
            this.labelPathOfLastSelectedLayer.Text = "Path of last selected layer:";
            this.labelPathOfLastSelectedLayer.Visible = false;
            // 
            // buttonDeleteUniqueLayer
            // 
            this.buttonDeleteUniqueLayer.Enabled = false;
            this.buttonDeleteUniqueLayer.Location = new System.Drawing.Point(153, 358);
            this.buttonDeleteUniqueLayer.Name = "buttonDeleteUniqueLayer";
            this.buttonDeleteUniqueLayer.Size = new System.Drawing.Size(121, 24);
            this.buttonDeleteUniqueLayer.TabIndex = 13;
            this.buttonDeleteUniqueLayer.Text = "Delete Unique Layer";
            this.buttonDeleteUniqueLayer.UseVisualStyleBackColor = true;
            this.buttonDeleteUniqueLayer.Visible = false;
            // 
            // buttonAddUniqueLayer
            // 
            this.buttonAddUniqueLayer.Enabled = false;
            this.buttonAddUniqueLayer.Location = new System.Drawing.Point(26, 358);
            this.buttonAddUniqueLayer.Name = "buttonAddUniqueLayer";
            this.buttonAddUniqueLayer.Size = new System.Drawing.Size(121, 24);
            this.buttonAddUniqueLayer.TabIndex = 14;
            this.buttonAddUniqueLayer.Text = "Add Unique Layer";
            this.buttonAddUniqueLayer.UseVisualStyleBackColor = true;
            this.buttonAddUniqueLayer.Visible = false;
            this.buttonAddUniqueLayer.Click += new System.EventHandler(this.buttonAddUniqueLayer_Click);
            // 
            // labelBoundariesLayerPath
            // 
            this.labelBoundariesLayerPath.AutoSize = true;
            this.labelBoundariesLayerPath.Enabled = false;
            this.labelBoundariesLayerPath.Location = new System.Drawing.Point(26, 62);
            this.labelBoundariesLayerPath.Name = "labelBoundariesLayerPath";
            this.labelBoundariesLayerPath.Size = new System.Drawing.Size(174, 13);
            this.labelBoundariesLayerPath.TabIndex = 16;
            this.labelBoundariesLayerPath.Text = "Path of Boundaries Layer (.shp file):";
            this.labelBoundariesLayerPath.Visible = false;
            // 
            // buttonChangeBoundariesLayer
            // 
            this.buttonChangeBoundariesLayer.Enabled = false;
            this.buttonChangeBoundariesLayer.Location = new System.Drawing.Point(484, 52);
            this.buttonChangeBoundariesLayer.Name = "buttonChangeBoundariesLayer";
            this.buttonChangeBoundariesLayer.Size = new System.Drawing.Size(78, 47);
            this.buttonChangeBoundariesLayer.TabIndex = 17;
            this.buttonChangeBoundariesLayer.Text = "Add/Change boundaries layer";
            this.buttonChangeBoundariesLayer.UseVisualStyleBackColor = true;
            this.buttonChangeBoundariesLayer.Visible = false;
            this.buttonChangeBoundariesLayer.Click += new System.EventHandler(this.buttonChangeBoundariesLayer_Click);
            // 
            // textBoxBoundariesLayerPath
            // 
            this.textBoxBoundariesLayerPath.Enabled = false;
            this.textBoxBoundariesLayerPath.Location = new System.Drawing.Point(26, 78);
            this.textBoxBoundariesLayerPath.Name = "textBoxBoundariesLayerPath";
            this.textBoxBoundariesLayerPath.ReadOnly = true;
            this.textBoxBoundariesLayerPath.Size = new System.Drawing.Size(452, 20);
            this.textBoxBoundariesLayerPath.TabIndex = 15;
            this.textBoxBoundariesLayerPath.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // numericUpDownCellSize
            // 
            this.numericUpDownCellSize.Enabled = false;
            this.numericUpDownCellSize.Location = new System.Drawing.Point(358, 52);
            this.numericUpDownCellSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCellSize.Name = "numericUpDownCellSize";
            this.numericUpDownCellSize.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCellSize.TabIndex = 18;
            this.numericUpDownCellSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownCellSize.Visible = false;
            // 
            // labelCellSize
            // 
            this.labelCellSize.AutoSize = true;
            this.labelCellSize.Enabled = false;
            this.labelCellSize.Location = new System.Drawing.Point(301, 54);
            this.labelCellSize.Name = "labelCellSize";
            this.labelCellSize.Size = new System.Drawing.Size(51, 13);
            this.labelCellSize.TabIndex = 19;
            this.labelCellSize.Text = "Cell size :";
            this.labelCellSize.Visible = false;
            // 
            // textBoxXMLOutputPath
            // 
            this.textBoxXMLOutputPath.Enabled = false;
            this.textBoxXMLOutputPath.Location = new System.Drawing.Point(26, 550);
            this.textBoxXMLOutputPath.Name = "textBoxXMLOutputPath";
            this.textBoxXMLOutputPath.Size = new System.Drawing.Size(452, 20);
            this.textBoxXMLOutputPath.TabIndex = 20;
            this.textBoxXMLOutputPath.Visible = false;
            // 
            // labelXMLOutputPath
            // 
            this.labelXMLOutputPath.AutoSize = true;
            this.labelXMLOutputPath.Enabled = false;
            this.labelXMLOutputPath.Location = new System.Drawing.Point(26, 534);
            this.labelXMLOutputPath.Name = "labelXMLOutputPath";
            this.labelXMLOutputPath.Size = new System.Drawing.Size(89, 13);
            this.labelXMLOutputPath.TabIndex = 21;
            this.labelXMLOutputPath.Text = "XML output path:";
            this.labelXMLOutputPath.Visible = false;
            // 
            // ultraPanelSelectionSets
            // 
            // 
            // ultraPanelSelectionSets.ClientArea
            // 
            this.ultraPanelSelectionSets.ClientArea.Controls.Add(this.buttonAddChangeSelectionSetLayer);
            this.ultraPanelSelectionSets.ClientArea.Controls.Add(this.txtSelectionSetLayer);
            this.ultraPanelSelectionSets.ClientArea.Controls.Add(this.ultraLabelSelectionSetLayer);
            this.ultraPanelSelectionSets.Enabled = false;
            this.ultraPanelSelectionSets.Location = new System.Drawing.Point(23, 605);
            this.ultraPanelSelectionSets.Name = "ultraPanelSelectionSets";
            this.ultraPanelSelectionSets.Size = new System.Drawing.Size(547, 60);
            this.ultraPanelSelectionSets.TabIndex = 22;
            this.ultraPanelSelectionSets.Visible = false;
            // 
            // buttonAddChangeSelectionSetLayer
            // 
            this.buttonAddChangeSelectionSetLayer.Location = new System.Drawing.Point(458, 10);
            this.buttonAddChangeSelectionSetLayer.Name = "buttonAddChangeSelectionSetLayer";
            this.buttonAddChangeSelectionSetLayer.Size = new System.Drawing.Size(81, 47);
            this.buttonAddChangeSelectionSetLayer.TabIndex = 2;
            this.buttonAddChangeSelectionSetLayer.Text = "Add/Change Selection Set Layer";
            this.buttonAddChangeSelectionSetLayer.Click += new System.EventHandler(this.buttonAddChangeSelectionSetLayer_Click);
            // 
            // txtSelectionSetLayer
            // 
            this.txtSelectionSetLayer.Location = new System.Drawing.Point(4, 33);
            this.txtSelectionSetLayer.Name = "txtSelectionSetLayer";
            this.txtSelectionSetLayer.Size = new System.Drawing.Size(442, 21);
            this.txtSelectionSetLayer.TabIndex = 1;
            // 
            // ultraLabelSelectionSetLayer
            // 
            this.ultraLabelSelectionSetLayer.Location = new System.Drawing.Point(4, 17);
            this.ultraLabelSelectionSetLayer.Name = "ultraLabelSelectionSetLayer";
            this.ultraLabelSelectionSetLayer.Size = new System.Drawing.Size(201, 13);
            this.ultraLabelSelectionSetLayer.TabIndex = 0;
            this.ultraLabelSelectionSetLayer.Text = "Path of Selection Set Layer (optional) :";
            // 
            // btnCreateSelectionSets
            // 
            this.btnCreateSelectionSets.Enabled = false;
            this.btnCreateSelectionSets.Location = new System.Drawing.Point(434, 684);
            this.btnCreateSelectionSets.Name = "btnCreateSelectionSets";
            this.btnCreateSelectionSets.Size = new System.Drawing.Size(128, 23);
            this.btnCreateSelectionSets.TabIndex = 23;
            this.btnCreateSelectionSets.Text = "Create selection sets!";
            this.btnCreateSelectionSets.Visible = false;
            this.btnCreateSelectionSets.Click += new System.EventHandler(this.btnCreateSelectionSets_Click);
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Location = new System.Drawing.Point(26, 18);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(46, 13);
            this.labelUserID.TabIndex = 25;
            this.labelUserID.Text = "User ID:";
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Location = new System.Drawing.Point(78, 15);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.ReadOnly = true;
            this.textBoxUserID.Size = new System.Drawing.Size(55, 20);
            this.textBoxUserID.TabIndex = 24;
            this.textBoxUserID.Text = "GIS";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(150, 18);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 27;
            this.labelPassword.Text = "Password:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(212, 15);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(55, 20);
            this.textBoxPassword.TabIndex = 26;
            // 
            // buttonEnableLinks
            // 
            this.buttonEnableLinks.Location = new System.Drawing.Point(274, 15);
            this.buttonEnableLinks.Name = "buttonEnableLinks";
            this.buttonEnableLinks.Size = new System.Drawing.Size(132, 23);
            this.buttonEnableLinks.TabIndex = 28;
            this.buttonEnableLinks.Text = "Enable Links";
            this.buttonEnableLinks.UseVisualStyleBackColor = true;
            this.buttonEnableLinks.Click += new System.EventHandler(this.buttonEnableLinks_Click);
            // 
            // FormGridConditioner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 719);
            this.Controls.Add(this.buttonEnableLinks);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelUserID);
            this.Controls.Add(this.textBoxUserID);
            this.Controls.Add(this.btnCreateSelectionSets);
            this.Controls.Add(this.ultraPanelSelectionSets);
            this.Controls.Add(this.labelXMLOutputPath);
            this.Controls.Add(this.textBoxXMLOutputPath);
            this.Controls.Add(this.labelCellSize);
            this.Controls.Add(this.numericUpDownCellSize);
            this.Controls.Add(this.buttonChangeBoundariesLayer);
            this.Controls.Add(this.labelBoundariesLayerPath);
            this.Controls.Add(this.textBoxBoundariesLayerPath);
            this.Controls.Add(this.buttonAddUniqueLayer);
            this.Controls.Add(this.buttonDeleteUniqueLayer);
            this.Controls.Add(this.labelPathOfLastSelectedLayer);
            this.Controls.Add(this.buttonRemoveLayerFromProcess);
            this.Controls.Add(this.buttonAddUniqueLayerToProcess);
            this.Controls.Add(this.buttonAddCommonLayerToProcess);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.listBoxLayersToProcess);
            this.Controls.Add(this.textBoxPathOfLastSelectedLayer);
            this.Controls.Add(this.labelUserLayers);
            this.Controls.Add(this.labelCommonLayers);
            this.Controls.Add(this.listBoxCommonLayers);
            this.Controls.Add(this.buttonCreateZoningLayer);
            this.Name = "FormGridConditioner";
            this.Text = "Grid Conditioner";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cOMMONLAYERSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gRID_CONDITIONINGDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processLayerListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gRIDCONDITIONINGDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zONINGTYPESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSERLAYERSBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCellSize)).EndInit();
            this.ultraPanelSelectionSets.ClientArea.ResumeLayout(false);
            this.ultraPanelSelectionSets.ClientArea.PerformLayout();
            this.ultraPanelSelectionSets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSelectionSetLayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateZoningLayer;
        private System.Windows.Forms.ListBox listBoxCommonLayers;
        private GRID_CONDITIONINGDataSet gRID_CONDITIONINGDataSet;
        private System.Windows.Forms.BindingSource cOMMONLAYERSBindingSource;
        private GRID_CONDITIONINGDataSetTableAdapters.COMMONLAYERSTableAdapter cOMMONLAYERSTableAdapter;
        private System.Windows.Forms.Label labelCommonLayers;
        private System.Windows.Forms.Label labelUserLayers;
        private System.Windows.Forms.TextBox textBoxPathOfLastSelectedLayer;
        private System.Windows.Forms.ListBox listBoxLayersToProcess;
        private System.Windows.Forms.BindingSource gRIDCONDITIONINGDataSetBindingSource;
        private GRID_CONDITIONINGDataSetTableAdapters.USERLAYERSTableAdapter uSERLAYERSTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource uSERLAYERSBindingSource1;
        private System.Windows.Forms.BindingSource zONINGTYPESBindingSource;
        private GRID_CONDITIONINGDataSetTableAdapters.ZONINGTYPESTableAdapter zONINGTYPESTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button buttonAddCommonLayerToProcess;
        private System.Windows.Forms.Button buttonAddUniqueLayerToProcess;
        private System.Windows.Forms.Button buttonRemoveLayerFromProcess;
        private System.Windows.Forms.BindingSource processLayerListBindingSource;
        private System.Windows.Forms.Label labelPathOfLastSelectedLayer;
        private System.Windows.Forms.Button buttonDeleteUniqueLayer;
        private System.Windows.Forms.Button buttonAddUniqueLayer;
        private System.Windows.Forms.Label labelBoundariesLayerPath;
        private System.Windows.Forms.Button buttonChangeBoundariesLayer;
        private System.Windows.Forms.TextBox textBoxBoundariesLayerPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.NumericUpDown numericUpDownCellSize;
        private System.Windows.Forms.Label labelCellSize;
        private System.Windows.Forms.TextBox textBoxXMLOutputPath;
        private System.Windows.Forms.Label labelXMLOutputPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn oBJECTIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn landUseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn landUseColumnDataGridViewTextBoxColumn;
        private Infragistics.Win.Misc.UltraPanel ultraPanelSelectionSets;
        private Infragistics.Win.Misc.UltraButton buttonAddChangeSelectionSetLayer;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtSelectionSetLayer;
        private Infragistics.Win.Misc.UltraLabel ultraLabelSelectionSetLayer;
        private Infragistics.Win.Misc.UltraButton btnCreateSelectionSets;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.TextBox textBoxUserID;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonEnableLinks;
    }
}

