namespace Frm_waypoint
{
    partial class frm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Login));
            this.lbl_Port = new System.Windows.Forms.Label();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.chkBox_SaveValues = new System.Windows.Forms.CheckBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.lbl_Database = new System.Windows.Forms.Label();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.lbl_Host = new System.Windows.Forms.Label();
            this.txt_Database = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.txt_Host = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_Port
            // 
            this.lbl_Port.AutoSize = true;
            this.lbl_Port.Location = new System.Drawing.Point(12, 175);
            this.lbl_Port.Name = "lbl_Port";
            this.lbl_Port.Size = new System.Drawing.Size(26, 13);
            this.lbl_Port.TabIndex = 25;
            this.lbl_Port.Text = "Port";
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(12, 191);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(100, 20);
            this.txt_Port.TabIndex = 24;
            this.txt_Port.Text = "3306";
            // 
            // chkBox_SaveValues
            // 
            this.chkBox_SaveValues.AutoSize = true;
            this.chkBox_SaveValues.Checked = true;
            this.chkBox_SaveValues.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox_SaveValues.Location = new System.Drawing.Point(122, 198);
            this.chkBox_SaveValues.Name = "chkBox_SaveValues";
            this.chkBox_SaveValues.Size = new System.Drawing.Size(86, 17);
            this.chkBox_SaveValues.TabIndex = 23;
            this.chkBox_SaveValues.Text = "Save Values";
            this.chkBox_SaveValues.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(126, 56);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(82, 23);
            this.btn_Cancel.TabIndex = 22;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(126, 23);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(82, 24);
            this.btn_OK.TabIndex = 21;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.Btn_OK_Click);
            // 
            // lbl_Database
            // 
            this.lbl_Database.AutoSize = true;
            this.lbl_Database.Location = new System.Drawing.Point(12, 136);
            this.lbl_Database.Name = "lbl_Database";
            this.lbl_Database.Size = new System.Drawing.Size(53, 13);
            this.lbl_Database.TabIndex = 20;
            this.lbl_Database.Text = "Database";
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Location = new System.Drawing.Point(12, 93);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(53, 13);
            this.lbl_Password.TabIndex = 19;
            this.lbl_Password.Text = "Password";
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Location = new System.Drawing.Point(12, 50);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(55, 13);
            this.lbl_Username.TabIndex = 18;
            this.lbl_Username.Text = "Username";
            // 
            // lbl_Host
            // 
            this.lbl_Host.AutoSize = true;
            this.lbl_Host.Location = new System.Drawing.Point(12, 7);
            this.lbl_Host.Name = "lbl_Host";
            this.lbl_Host.Size = new System.Drawing.Size(29, 13);
            this.lbl_Host.TabIndex = 17;
            this.lbl_Host.Text = "Host";
            // 
            // txt_Database
            // 
            this.txt_Database.Location = new System.Drawing.Point(12, 152);
            this.txt_Database.Name = "txt_Database";
            this.txt_Database.Size = new System.Drawing.Size(100, 20);
            this.txt_Database.TabIndex = 16;
            this.txt_Database.Text = "world";
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(12, 109);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(100, 20);
            this.txt_Password.TabIndex = 15;
            this.txt_Password.Text = "trinity";
            // 
            // txt_Username
            // 
            this.txt_Username.Location = new System.Drawing.Point(12, 70);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(100, 20);
            this.txt_Username.TabIndex = 14;
            this.txt_Username.Text = "trinity";
            // 
            // txt_Host
            // 
            this.txt_Host.Location = new System.Drawing.Point(12, 23);
            this.txt_Host.Name = "txt_Host";
            this.txt_Host.Size = new System.Drawing.Size(100, 20);
            this.txt_Host.TabIndex = 13;
            this.txt_Host.Text = "localhost";
            // 
            // frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 227);
            this.ControlBox = false;
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.chkBox_SaveValues);
            this.Controls.Add(this.lbl_Host);
            this.Controls.Add(this.lbl_Username);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.lbl_Database);
            this.Controls.Add(this.lbl_Port);
            this.Controls.Add(this.txt_Host);
            this.Controls.Add(this.txt_Username);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_Database);
            this.Controls.Add(this.txt_Port);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MySQL Login for Waypoint Creator";
            this.Load += new System.EventHandler(this.Frm_login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lbl_Port;
        internal System.Windows.Forms.TextBox txt_Port;
        internal System.Windows.Forms.CheckBox chkBox_SaveValues;
        internal System.Windows.Forms.Button btn_Cancel;
        internal System.Windows.Forms.Button btn_OK;
        internal System.Windows.Forms.Label lbl_Database;
        internal System.Windows.Forms.Label lbl_Password;
        internal System.Windows.Forms.Label lbl_Username;
        internal System.Windows.Forms.Label lbl_Host;
        internal System.Windows.Forms.TextBox txt_Database;
        internal System.Windows.Forms.TextBox txt_Password;
        internal System.Windows.Forms.TextBox txt_Username;
        internal System.Windows.Forms.TextBox txt_Host;

    }
}