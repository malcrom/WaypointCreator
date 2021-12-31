using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frm_waypoint
{
    public partial class frm_Settings : Form
    {
        public const int boxPoint = 1;
        public const int boxLine  = 2;
        public const int boxBack  = 3;
        public const int boxTitle = 4;

        public frm_Settings()
        {
            InitializeComponent();
        }

        private void Frm_settings_Load(object sender, EventArgs e)
        {
            GetValues();
        }

        private void btnOKClick(object sender, EventArgs e)
        {
            SaveValues();
            this.Close();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            SetDefaults();
        }

        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPointColour_Click(object sender, EventArgs e)
        {
            setColour(boxPoint);
        }

        private void btnLineColour_Click(object sender, EventArgs e)
        {
            setColour(boxLine);
        }

        private void btnBackColour_Click(object sender, EventArgs e)
        {
            setColour(boxBack);
        }

        private void btnTitleColour_Click(object sender, EventArgs e)
        {
            setColour(boxTitle);
        }

        private void setColour(int item)
        {
            ColorDialog colorDlg    = new ColorDialog();
            colorDlg.AllowFullOpen  = true;
            colorDlg.AnyColor       = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color          = Color.Red;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                switch (item)
                {
                    case boxPoint:
                        picBoxPointColour.BackColor = colorDlg.Color;
                        break;
                    case boxLine:
                        picBoxLineColour.BackColor = colorDlg.Color;
                        break;
                    case boxBack:
                        picBoxBackColour.BackColor = colorDlg.Color;
                        break;
                    case boxTitle:
                        picBoxTitleColour.BackColor = colorDlg.Color;
                        break;
                }
            }
        }

        private void GetValues()
        {
            if (Properties.Settings.Default.DB == true)
                chkBoxDB.CheckState = CheckState.Checked;
            else
                chkBoxDB.CheckState = CheckState.Unchecked;

            if (Properties.Settings.Default.UDB == true)
                chkBoxUDB.CheckState = CheckState.Checked;
            else
                chkBoxUDB.CheckState = CheckState.Unchecked;

            if (Properties.Settings.Default.SAI == true)
                chkBoxSAI.CheckState = CheckState.Checked;
            else
                chkBoxSAI.CheckState = CheckState.Unchecked;

            if (Properties.Settings.Default.CPP == true)
                chkBoxCPP.CheckState = CheckState.Checked;
            else
                chkBoxCPP.CheckState = CheckState.Unchecked;

            if (Properties.Settings.Default.Lines == true)
                chkBoxLine.CheckState = CheckState.Checked;
            else
                chkBoxLine.CheckState = CheckState.Unchecked;

            if (Properties.Settings.Default.Splines == true)
                chkBoxSpline.CheckState = CheckState.Checked;
            else
                chkBoxSpline.CheckState = CheckState.Unchecked;

            if (Properties.Settings.Default.ObjectUpdate == true)
                chkBoxObject.CheckState = CheckState.Checked;
            else
                chkBoxObject.CheckState = CheckState.Unchecked;

            picBoxPointColour.BackColor = Properties.Settings.Default.PointColour;
            picBoxLineColour.BackColor = Properties.Settings.Default.LineColour;
            picBoxBackColour.BackColor = Properties.Settings.Default.BackColour;
            picBoxTitleColour.BackColor = Properties.Settings.Default.TitleColour;
        }

        private void SaveValues()
        {
            if (chkBoxDB.CheckState == CheckState.Checked)
                Properties.Settings.Default.DB = true;
            else
                Properties.Settings.Default.DB = false;

            if (chkBoxUDB.CheckState == CheckState.Checked)
                Properties.Settings.Default.UDB = true;
            else
                Properties.Settings.Default.UDB = false;

            if (chkBoxSAI.CheckState == CheckState.Checked)
                Properties.Settings.Default.SAI = true;
            else
                Properties.Settings.Default.SAI = false;

            if (chkBoxCPP.CheckState == CheckState.Checked)
                Properties.Settings.Default.CPP = true;
            else
                Properties.Settings.Default.CPP = false;

            if (chkBoxLine.CheckState == CheckState.Checked)
                Properties.Settings.Default.Lines = true;
            else
                Properties.Settings.Default.Lines = false;

            if (chkBoxSpline.CheckState == CheckState.Checked)
                Properties.Settings.Default.Splines = true;
            else
                Properties.Settings.Default.Splines = false;

            if (chkBoxObject.CheckState == CheckState.Checked)
                Properties.Settings.Default.ObjectUpdate = true;
            else
                Properties.Settings.Default.ObjectUpdate = false;

            Properties.Settings.Default.PointColour = picBoxPointColour.BackColor;
            Properties.Settings.Default.LineColour = picBoxLineColour.BackColor;
            Properties.Settings.Default.BackColour = picBoxBackColour.BackColor;
            Properties.Settings.Default.TitleColour = picBoxTitleColour.BackColor;
            Properties.Settings.Default.Save();
        }

        private void SetDefaults()
        {
            chkBoxDB.CheckState = CheckState.Checked;
            chkBoxUDB.CheckState = CheckState.Unchecked;
            chkBoxSAI.CheckState = CheckState.Unchecked;
            chkBoxCPP.CheckState = CheckState.Unchecked;
            chkBoxLine.CheckState = CheckState.Checked;
            chkBoxSpline.CheckState = CheckState.Unchecked;
            picBoxPointColour.BackColor = Color.Blue;
            picBoxLineColour.BackColor = Color.Aqua;
            picBoxBackColour.BackColor = Color.White;
            picBoxTitleColour.BackColor = Color.Blue;
        }
    }
}
