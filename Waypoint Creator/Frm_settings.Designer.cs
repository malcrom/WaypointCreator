namespace Frm_waypoint
{
    partial class frm_Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Settings));
            this.groupSQL = new System.Windows.Forms.GroupBox();
            this.chkBox_UDB = new System.Windows.Forms.CheckBox();
            this.chkBox_TDB = new System.Windows.Forms.CheckBox();
            this.groupGraph = new System.Windows.Forms.GroupBox();
            this.chkBox_Spline = new System.Windows.Forms.CheckBox();
            this.chkBox_Line = new System.Windows.Forms.CheckBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupColours = new System.Windows.Forms.GroupBox();
            this.btn_Title_Colour = new System.Windows.Forms.Button();
            this.picBox_Title_Colour = new System.Windows.Forms.PictureBox();
            this.btn_Back_Colour = new System.Windows.Forms.Button();
            this.picBox_Back_Colour = new System.Windows.Forms.PictureBox();
            this.btn_Line_Colour = new System.Windows.Forms.Button();
            this.btn_Point_Colour = new System.Windows.Forms.Button();
            this.picBox_Line_Colour = new System.Windows.Forms.PictureBox();
            this.picBox_Point_Colour = new System.Windows.Forms.PictureBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.btn_Default = new System.Windows.Forms.Button();
            this.groupSQL.SuspendLayout();
            this.groupGraph.SuspendLayout();
            this.groupColours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Title_Colour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Back_Colour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Line_Colour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Point_Colour)).BeginInit();
            this.SuspendLayout();
            // 
            // groupSQL
            // 
            this.groupSQL.Controls.Add(this.chkBox_UDB);
            this.groupSQL.Controls.Add(this.chkBox_TDB);
            this.groupSQL.Location = new System.Drawing.Point(12, 12);
            this.groupSQL.Name = "groupSQL";
            this.groupSQL.Size = new System.Drawing.Size(168, 68);
            this.groupSQL.TabIndex = 5;
            this.groupSQL.TabStop = false;
            this.groupSQL.Text = "SQL Output Format";
            // 
            // chkBox_UDB
            // 
            this.chkBox_UDB.AutoSize = true;
            this.chkBox_UDB.Location = new System.Drawing.Point(6, 42);
            this.chkBox_UDB.Name = "chkBox_UDB";
            this.chkBox_UDB.Size = new System.Drawing.Size(98, 17);
            this.chkBox_UDB.TabIndex = 3;
            this.chkBox_UDB.Text = "UDB Database";
            this.chkBox_UDB.UseVisualStyleBackColor = true;
            // 
            // chkBox_TDB
            // 
            this.chkBox_TDB.AutoSize = true;
            this.chkBox_TDB.Location = new System.Drawing.Point(6, 19);
            this.chkBox_TDB.Name = "chkBox_TDB";
            this.chkBox_TDB.Size = new System.Drawing.Size(97, 17);
            this.chkBox_TDB.TabIndex = 2;
            this.chkBox_TDB.Text = "TDB Database";
            this.chkBox_TDB.UseVisualStyleBackColor = true;
            this.chkBox_TDB.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupGraph
            // 
            this.groupGraph.Controls.Add(this.chkBox_Spline);
            this.groupGraph.Controls.Add(this.chkBox_Line);
            this.groupGraph.Location = new System.Drawing.Point(12, 86);
            this.groupGraph.Name = "groupGraph";
            this.groupGraph.Size = new System.Drawing.Size(168, 68);
            this.groupGraph.TabIndex = 6;
            this.groupGraph.TabStop = false;
            this.groupGraph.Text = "Point Graphing";
            // 
            // chkBox_Spline
            // 
            this.chkBox_Spline.AutoSize = true;
            this.chkBox_Spline.Location = new System.Drawing.Point(6, 42);
            this.chkBox_Spline.Name = "chkBox_Spline";
            this.chkBox_Spline.Size = new System.Drawing.Size(98, 17);
            this.chkBox_Spline.TabIndex = 6;
            this.chkBox_Spline.Text = "Linetype Spline";
            this.chkBox_Spline.UseVisualStyleBackColor = true;
            // 
            // chkBox_Line
            // 
            this.chkBox_Line.AutoSize = true;
            this.chkBox_Line.Location = new System.Drawing.Point(6, 19);
            this.chkBox_Line.Name = "chkBox_Line";
            this.chkBox_Line.Size = new System.Drawing.Size(81, 17);
            this.chkBox_Line.TabIndex = 5;
            this.chkBox_Line.Text = "Show Lines";
            this.chkBox_Line.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(248, 225);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 7;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btn_Cancel.Location = new System.Drawing.Point(248, 254);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupColours
            // 
            this.groupColours.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.groupColours.Controls.Add(this.btn_Point_Colour);
            this.groupColours.Controls.Add(this.btn_Line_Colour);
            this.groupColours.Controls.Add(this.btn_Back_Colour);
            this.groupColours.Controls.Add(this.btn_Title_Colour);
            this.groupColours.Controls.Add(this.picBox_Point_Colour);
            this.groupColours.Controls.Add(this.picBox_Line_Colour);
            this.groupColours.Controls.Add(this.picBox_Back_Colour);
            this.groupColours.Controls.Add(this.picBox_Title_Colour);
            this.groupColours.Location = new System.Drawing.Point(188, 12);
            this.groupColours.Name = "groupColours";
            this.groupColours.Size = new System.Drawing.Size(136, 142);
            this.groupColours.TabIndex = 9;
            this.groupColours.TabStop = false;
            this.groupColours.Text = "Graph Colours";
            // 
            // btn_Title_Colour
            // 
            this.btn_Title_Colour.Location = new System.Drawing.Point(41, 109);
            this.btn_Title_Colour.Name = "btn_Title_Colour";
            this.btn_Title_Colour.Size = new System.Drawing.Size(85, 23);
            this.btn_Title_Colour.TabIndex = 17;
            this.btn_Title_Colour.Text = "Title Colour";
            this.btn_Title_Colour.UseVisualStyleBackColor = true;
            this.btn_Title_Colour.Click += new System.EventHandler(this.button6_Click);
            // 
            // picBox_Title_Colour
            // 
            this.picBox_Title_Colour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox_Title_Colour.Location = new System.Drawing.Point(6, 109);
            this.picBox_Title_Colour.Name = "picBox_Title_Colour";
            this.picBox_Title_Colour.Size = new System.Drawing.Size(23, 23);
            this.picBox_Title_Colour.TabIndex = 16;
            this.picBox_Title_Colour.TabStop = false;
            // 
            // btn_Back_Colour
            // 
            this.btn_Back_Colour.Location = new System.Drawing.Point(41, 80);
            this.btn_Back_Colour.Name = "btn_Back_Colour";
            this.btn_Back_Colour.Size = new System.Drawing.Size(85, 23);
            this.btn_Back_Colour.TabIndex = 15;
            this.btn_Back_Colour.Text = "Back Colour";
            this.btn_Back_Colour.UseVisualStyleBackColor = true;
            this.btn_Back_Colour.Click += new System.EventHandler(this.button5_Click);
            // 
            // picBox_Back_Colour
            // 
            this.picBox_Back_Colour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox_Back_Colour.Location = new System.Drawing.Point(6, 80);
            this.picBox_Back_Colour.Name = "picBox_Back_Colour";
            this.picBox_Back_Colour.Size = new System.Drawing.Size(23, 23);
            this.picBox_Back_Colour.TabIndex = 14;
            this.picBox_Back_Colour.TabStop = false;
            // 
            // btn_Line_Colour
            // 
            this.btn_Line_Colour.Location = new System.Drawing.Point(41, 51);
            this.btn_Line_Colour.Name = "btn_Line_Colour";
            this.btn_Line_Colour.Size = new System.Drawing.Size(85, 23);
            this.btn_Line_Colour.TabIndex = 13;
            this.btn_Line_Colour.Text = "Line Colour";
            this.btn_Line_Colour.UseVisualStyleBackColor = true;
            this.btn_Line_Colour.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_Point_Colour
            // 
            this.btn_Point_Colour.Location = new System.Drawing.Point(41, 22);
            this.btn_Point_Colour.Name = "btn_Point_Colour";
            this.btn_Point_Colour.Size = new System.Drawing.Size(85, 23);
            this.btn_Point_Colour.TabIndex = 12;
            this.btn_Point_Colour.Text = "Point Colour";
            this.btn_Point_Colour.UseVisualStyleBackColor = true;
            this.btn_Point_Colour.Click += new System.EventHandler(this.button3_Click);
            // 
            // picBox_Line_Colour
            // 
            this.picBox_Line_Colour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox_Line_Colour.Location = new System.Drawing.Point(6, 51);
            this.picBox_Line_Colour.Name = "picBox_Line_Colour";
            this.picBox_Line_Colour.Size = new System.Drawing.Size(23, 23);
            this.picBox_Line_Colour.TabIndex = 2;
            this.picBox_Line_Colour.TabStop = false;
            // 
            // picBox_Point_Colour
            // 
            this.picBox_Point_Colour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox_Point_Colour.Location = new System.Drawing.Point(6, 22);
            this.picBox_Point_Colour.Name = "picBox_Point_Colour";
            this.picBox_Point_Colour.Size = new System.Drawing.Size(23, 23);
            this.picBox_Point_Colour.TabIndex = 0;
            this.picBox_Point_Colour.TabStop = false;
            // 
            // btn_Default
            // 
            this.btn_Default.Location = new System.Drawing.Point(248, 161);
            this.btn_Default.Name = "btn_Default";
            this.btn_Default.Size = new System.Drawing.Size(75, 23);
            this.btn_Default.TabIndex = 10;
            this.btn_Default.Text = "Default";
            this.btn_Default.UseVisualStyleBackColor = true;
            // 
            // frm_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 289);
            this.ControlBox = false;
            this.Controls.Add(this.groupSQL);
            this.Controls.Add(this.groupGraph);
            this.Controls.Add(this.groupColours);
            this.Controls.Add(this.btn_Default);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Settings";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Frm_settings_Load);
            this.groupSQL.ResumeLayout(false);
            this.groupSQL.PerformLayout();
            this.groupGraph.ResumeLayout(false);
            this.groupGraph.PerformLayout();
            this.groupColours.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Title_Colour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Back_Colour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Line_Colour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Point_Colour)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupSQL;
        private System.Windows.Forms.CheckBox chkBox_UDB;
        private System.Windows.Forms.CheckBox chkBox_TDB;
        private System.Windows.Forms.GroupBox groupGraph;
        private System.Windows.Forms.CheckBox chkBox_Spline;
        private System.Windows.Forms.CheckBox chkBox_Line;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox groupColours;
        private System.Windows.Forms.PictureBox picBox_Line_Colour;
        private System.Windows.Forms.PictureBox picBox_Point_Colour;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btn_Line_Colour;
        private System.Windows.Forms.Button btn_Point_Colour;
        private System.Windows.Forms.Button btn_Title_Colour;
        private System.Windows.Forms.PictureBox picBox_Title_Colour;
        private System.Windows.Forms.Button btn_Back_Colour;
        private System.Windows.Forms.PictureBox picBox_Back_Colour;
        private System.Windows.Forms.Button btn_Default;
    }
}