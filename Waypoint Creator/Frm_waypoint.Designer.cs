namespace Frm_waypoint
{
    partial class frm_Waypoint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Waypoint));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.toolStripSQL = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.tabEditor = new System.Windows.Forms.TabPage();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listBox = new System.Windows.Forms.ListBox();
            this.gridWaypoint = new System.Windows.Forms.DataGridView();
            this.gridColumn_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColumn_x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColumn_y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColumn_z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColumn_o = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColumn_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColumn_delay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteAboveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteBelowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.createSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makegoXyzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripEdit = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBoxEntry = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabelEntry = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLoadSniff = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelRange = new System.Windows.Forms.ToolStripLabel();
            this.tab_Waypoint = new System.Windows.Forms.TabControl();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tabOutput.SuspendLayout();
            this.toolStripSQL.SuspendLayout();
            this.tabEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWaypoint)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.toolStripEdit.SuspendLayout();
            this.tab_Waypoint.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // tabOutput
            // 
            this.tabOutput.Controls.Add(this.txtOutput);
            this.tabOutput.Controls.Add(this.toolStripSQL);
            this.tabOutput.Location = new System.Drawing.Point(8, 39);
            this.tabOutput.Margin = new System.Windows.Forms.Padding(6);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.Padding = new System.Windows.Forms.Padding(6);
            this.tabOutput.Size = new System.Drawing.Size(2808, 1261);
            this.tabOutput.TabIndex = 1;
            this.tabOutput.Text = "SQL Output";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(6, 48);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(6);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(2796, 1207);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.WordWrap = false;
            // 
            // toolStripSQL
            // 
            this.toolStripSQL.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripSQL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave});
            this.toolStripSQL.Location = new System.Drawing.Point(6, 6);
            this.toolStripSQL.Name = "toolStripSQL";
            this.toolStripSQL.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.toolStripSQL.Size = new System.Drawing.Size(2796, 42);
            this.toolStripSQL.TabIndex = 1;
            this.toolStripSQL.Text = "toolStrip1";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(157, 36);
            this.toolStripButtonSave.Text = "Write SQL";
            this.toolStripButtonSave.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.toolStripButtonSave.ToolTipText = "Write textbox to SQL file.";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // tabEditor
            // 
            this.tabEditor.Controls.Add(this.chart);
            this.tabEditor.Controls.Add(this.listBox);
            this.tabEditor.Controls.Add(this.gridWaypoint);
            this.tabEditor.Controls.Add(this.toolStripEdit);
            this.tabEditor.Location = new System.Drawing.Point(8, 39);
            this.tabEditor.Margin = new System.Windows.Forms.Padding(6);
            this.tabEditor.Name = "tabEditor";
            this.tabEditor.Padding = new System.Windows.Forms.Padding(6);
            this.tabEditor.Size = new System.Drawing.Size(2808, 1261);
            this.tabEditor.TabIndex = 0;
            this.tabEditor.Text = "Waypoint Editor";
            this.tabEditor.UseVisualStyleBackColor = true;
            // 
            // chart
            // 
            this.chart.BorderlineWidth = 0;
            this.chart.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart.BorderSkin.BorderColor = System.Drawing.Color.Transparent;
            this.chart.BorderSkin.BorderWidth = 0;
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea1.AxisX.IsReversed = true;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MinorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.None;
            chartArea1.AxisX.ScaleBreakStyle.Enabled = true;
            chartArea1.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.ScrollBar.LineColor = System.Drawing.Color.Black;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX2.MajorGrid.Enabled = false;
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX2.MajorTickMark.Enabled = false;
            chartArea1.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.LabelStyle.Enabled = false;
            chartArea1.AxisY.LabelStyle.IsEndLabelVisible = false;
            chartArea1.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.MinorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.MinorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.None;
            chartArea1.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.ScrollBar.ButtonColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.ScrollBar.LineColor = System.Drawing.Color.Black;
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY2.MajorTickMark.Enabled = false;
            chartArea1.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.CursorX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorX.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            chartArea1.CursorY.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.CursorY.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Enabled = false;
            legend1.ForeColor = System.Drawing.Color.Transparent;
            legend1.HeaderSeparatorColor = System.Drawing.Color.Transparent;
            legend1.ItemColumnSeparatorColor = System.Drawing.Color.Transparent;
            legend1.Name = "Legend1";
            legend1.TitleForeColor = System.Drawing.Color.Transparent;
            legend1.TitleSeparatorColor = System.Drawing.Color.Transparent;
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(6, 48);
            this.chart.Margin = new System.Windows.Forms.Padding(0);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Path";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(1358, 1207);
            this.chart.TabIndex = 25;
            this.chart.Text = "Waypoints";
            title1.DockedToChartArea = "ChartArea1";
            title1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Path";
            title1.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            this.chart.Titles.Add(title1);
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.SystemColors.Menu;
            this.listBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 25;
            this.listBox.Location = new System.Drawing.Point(1364, 48);
            this.listBox.Margin = new System.Windows.Forms.Padding(0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(476, 1207);
            this.listBox.TabIndex = 24;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // gridWaypoint
            // 
            this.gridWaypoint.AllowUserToAddRows = false;
            this.gridWaypoint.AllowUserToDeleteRows = false;
            this.gridWaypoint.AllowUserToResizeColumns = false;
            this.gridWaypoint.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.NullValue = null;
            this.gridWaypoint.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridWaypoint.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridWaypoint.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridWaypoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridWaypoint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridColumn_no,
            this.gridColumn_x,
            this.gridColumn_y,
            this.gridColumn_z,
            this.gridColumn_o,
            this.gridColumn_time,
            this.gridColumn_delay});
            this.gridWaypoint.ContextMenuStrip = this.contextMenuStrip;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridWaypoint.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridWaypoint.Dock = System.Windows.Forms.DockStyle.Right;
            this.gridWaypoint.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridWaypoint.Location = new System.Drawing.Point(1840, 48);
            this.gridWaypoint.Margin = new System.Windows.Forms.Padding(0);
            this.gridWaypoint.Name = "gridWaypoint";
            this.gridWaypoint.RowHeadersWidth = 82;
            this.gridWaypoint.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridWaypoint.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.gridWaypoint.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridWaypoint.Size = new System.Drawing.Size(962, 1207);
            this.gridWaypoint.TabIndex = 20;
            this.gridWaypoint.TabStop = false;
            // 
            // gridColumn_no
            // 
            this.gridColumn_no.HeaderText = "no";
            this.gridColumn_no.MinimumWidth = 10;
            this.gridColumn_no.Name = "gridColumn_no";
            this.gridColumn_no.ReadOnly = true;
            this.gridColumn_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.gridColumn_no.Width = 35;
            // 
            // gridColumn_x
            // 
            dataGridViewCellStyle3.NullValue = null;
            this.gridColumn_x.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridColumn_x.HeaderText = "x";
            this.gridColumn_x.MaxInputLength = 25;
            this.gridColumn_x.MinimumWidth = 10;
            this.gridColumn_x.Name = "gridColumn_x";
            this.gridColumn_x.ReadOnly = true;
            this.gridColumn_x.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridColumn_x.Width = 60;
            // 
            // gridColumn_y
            // 
            dataGridViewCellStyle4.NullValue = null;
            this.gridColumn_y.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridColumn_y.HeaderText = "y";
            this.gridColumn_y.MinimumWidth = 10;
            this.gridColumn_y.Name = "gridColumn_y";
            this.gridColumn_y.ReadOnly = true;
            this.gridColumn_y.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridColumn_y.Width = 60;
            // 
            // gridColumn_z
            // 
            this.gridColumn_z.HeaderText = "z";
            this.gridColumn_z.MinimumWidth = 10;
            this.gridColumn_z.Name = "gridColumn_z";
            this.gridColumn_z.ReadOnly = true;
            this.gridColumn_z.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridColumn_z.Width = 60;
            // 
            // gridColumn_o
            // 
            this.gridColumn_o.HeaderText = "o";
            this.gridColumn_o.MinimumWidth = 10;
            this.gridColumn_o.Name = "gridColumn_o";
            this.gridColumn_o.ReadOnly = true;
            this.gridColumn_o.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridColumn_o.Width = 60;
            // 
            // gridColumn_time
            // 
            this.gridColumn_time.HeaderText = "time";
            this.gridColumn_time.MinimumWidth = 10;
            this.gridColumn_time.Name = "gridColumn_time";
            this.gridColumn_time.ReadOnly = true;
            this.gridColumn_time.Width = 60;
            // 
            // gridColumn_delay
            // 
            this.gridColumn_delay.HeaderText = "delay";
            this.gridColumn_delay.MinimumWidth = 10;
            this.gridColumn_delay.Name = "gridColumn_delay";
            this.gridColumn_delay.Width = 60;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteAboveToolStripMenuItem,
            this.pasteBelowToolStripMenuItem,
            this.toolStripSeparator,
            this.createSQLToolStripMenuItem,
            this.toolStripSeparator2,
            this.makegoXyzToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(231, 244);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteAboveToolStripMenuItem
            // 
            this.pasteAboveToolStripMenuItem.Name = "pasteAboveToolStripMenuItem";
            this.pasteAboveToolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.pasteAboveToolStripMenuItem.Text = "Paste Above";
            this.pasteAboveToolStripMenuItem.Click += new System.EventHandler(this.pasteAboveToolStripMenuItem_Click);
            // 
            // pasteBelowToolStripMenuItem
            // 
            this.pasteBelowToolStripMenuItem.Name = "pasteBelowToolStripMenuItem";
            this.pasteBelowToolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.pasteBelowToolStripMenuItem.Text = "Paste Below";
            this.pasteBelowToolStripMenuItem.Click += new System.EventHandler(this.pasteBelowToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(227, 6);
            // 
            // createSQLToolStripMenuItem
            // 
            this.createSQLToolStripMenuItem.Name = "createSQLToolStripMenuItem";
            this.createSQLToolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.createSQLToolStripMenuItem.Text = "Create SQL";
            this.createSQLToolStripMenuItem.Click += new System.EventHandler(this.createSQLToolStripMenuItem_Click);
            // 
            // makegoXyzToolStripMenuItem
            // 
            this.makegoXyzToolStripMenuItem.Name = "makegoXyzToolStripMenuItem";
            this.makegoXyzToolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.makegoXyzToolStripMenuItem.Text = "Make .go xyz";
            this.makegoXyzToolStripMenuItem.Click += new System.EventHandler(this.makegoXyzToolStripMenuItem_Click);
            // 
            // toolStripEdit
            // 
            this.toolStripEdit.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSearch,
            this.toolStripTextBoxEntry,
            this.toolStripLabelEntry,
            this.toolStripSeparator1,
            this.toolStripButtonSettings,
            this.toolStripButtonLoadSniff,
            this.toolStripLabelRange});
            this.toolStripEdit.Location = new System.Drawing.Point(6, 6);
            this.toolStripEdit.Name = "toolStripEdit";
            this.toolStripEdit.Padding = new System.Windows.Forms.Padding(0);
            this.toolStripEdit.Size = new System.Drawing.Size(2796, 42);
            this.toolStripEdit.Stretch = true;
            this.toolStripEdit.TabIndex = 23;
            this.toolStripEdit.Text = "toolStrip1";
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonSearch.Enabled = false;
            this.toolStripButtonSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSearch.Image")));
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(122, 36);
            this.toolStripButtonSearch.Text = "Search";
            this.toolStripButtonSearch.ToolTipText = "Fill listbox with guids of\r\nselected entry or all entries.";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.toolStripButtonSearch_Click);
            // 
            // toolStripTextBoxEntry
            // 
            this.toolStripTextBoxEntry.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBoxEntry.Enabled = false;
            this.toolStripTextBoxEntry.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxEntry.MaxLength = 6;
            this.toolStripTextBoxEntry.Name = "toolStripTextBoxEntry";
            this.toolStripTextBoxEntry.Size = new System.Drawing.Size(136, 42);
            this.toolStripTextBoxEntry.Tag = "";
            this.toolStripTextBoxEntry.ToolTipText = "Input entry of creature or leave\r\nblank to fill listbox will all in sniff.";
            // 
            // toolStripLabelEntry
            // 
            this.toolStripLabelEntry.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelEntry.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabelEntry.Name = "toolStripLabelEntry";
            this.toolStripLabelEntry.Size = new System.Drawing.Size(70, 36);
            this.toolStripLabelEntry.Text = "Entry:";
            this.toolStripLabelEntry.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // toolStripButtonSettings
            // 
            this.toolStripButtonSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSettings.Image")));
            this.toolStripButtonSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSettings.Name = "toolStripButtonSettings";
            this.toolStripButtonSettings.Size = new System.Drawing.Size(137, 36);
            this.toolStripButtonSettings.Text = "Settings";
            this.toolStripButtonSettings.ToolTipText = "Setup chart and output SQL.";
            this.toolStripButtonSettings.Click += new System.EventHandler(this.toolStripButtonSettings_Click);
            // 
            // toolStripButtonLoadSniff
            // 
            this.toolStripButtonLoadSniff.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoadSniff.Image")));
            this.toolStripButtonLoadSniff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoadSniff.Name = "toolStripButtonLoadSniff";
            this.toolStripButtonLoadSniff.Size = new System.Drawing.Size(178, 36);
            this.toolStripButtonLoadSniff.Text = "Import Sniff";
            this.toolStripButtonLoadSniff.ToolTipText = "Import a parsed wpp sniff file.";
            this.toolStripButtonLoadSniff.Click += new System.EventHandler(this.toolStripButtonLoadSniff_Click);
            // 
            // toolStripLabelRange
            // 
            this.toolStripLabelRange.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelRange.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripLabelRange.Margin = new System.Windows.Forms.Padding(0, 1, 30, 2);
            this.toolStripLabelRange.Name = "toolStripLabelRange";
            this.toolStripLabelRange.Size = new System.Drawing.Size(176, 39);
            this.toolStripLabelRange.Tag = "1/2 max distance between points";
            this.toolStripLabelRange.Text = "Wander Range:";
            // 
            // tab_Waypoint
            // 
            this.tab_Waypoint.Controls.Add(this.tabEditor);
            this.tab_Waypoint.Controls.Add(this.tabOutput);
            this.tab_Waypoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_Waypoint.Location = new System.Drawing.Point(0, 0);
            this.tab_Waypoint.Margin = new System.Windows.Forms.Padding(6);
            this.tab_Waypoint.Name = "tab_Waypoint";
            this.tab_Waypoint.SelectedIndex = 0;
            this.tab_Waypoint.Size = new System.Drawing.Size(2824, 1308);
            this.tab_Waypoint.TabIndex = 20;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 1308);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip.Size = new System.Drawing.Size(2824, 42);
            this.statusStrip.TabIndex = 23;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(176, 32);
            this.toolStripStatusLabel.Text = "No File Loaded";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(227, 6);
            // 
            // frm_Waypoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2824, 1350);
            this.Controls.Add(this.tab_Waypoint);
            this.Controls.Add(this.statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frm_Waypoint";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Waypoint Creator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_waypoint_FormClosing);
            this.Load += new System.EventHandler(this.Frm_waypoint_Load);
            this.tabOutput.ResumeLayout(false);
            this.tabOutput.PerformLayout();
            this.toolStripSQL.ResumeLayout(false);
            this.toolStripSQL.PerformLayout();
            this.tabEditor.ResumeLayout(false);
            this.tabEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWaypoint)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStripEdit.ResumeLayout(false);
            this.toolStripEdit.PerformLayout();
            this.tab_Waypoint.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView gridWaypoint;
        internal System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabPage tabOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TabPage tabEditor;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.ToolStrip toolStripEdit;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxEntry;
        private System.Windows.Forms.TabControl tab_Waypoint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteAboveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteBelowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem createSQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makegoXyzToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonSettings;
        private System.Windows.Forms.ToolStrip toolStripSQL;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridColumn_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridColumn_x;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridColumn_y;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridColumn_z;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridColumn_o;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridColumn_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridColumn_delay;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadSniff;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripLabel toolStripLabelEntry;
        private System.Windows.Forms.ToolStripLabel toolStripLabelRange;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}