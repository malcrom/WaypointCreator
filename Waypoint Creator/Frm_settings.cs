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

        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPointColour_Click(object sender, EventArgs e)
        {
            setColour(1);
        }

        private void btnLineColour_Click(object sender, EventArgs e)
        {
            setColour(2);
        }

        private void btnBackColour_Click(object sender, EventArgs e)
        {
            setColour(3);
        }

        private void btnTitleColour_Click(object sender, EventArgs e)
        {
            setColour(4);
        }

        private void setColour(Int32 item)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.Red;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                switch (item)
                {
                    case 1:
                        picBoxPointColour.BackColor = colorDlg.Color;
                        break;
                    case 2:
                        picBoxLineColour.BackColor = colorDlg.Color;
                        break;
                    case 3:
                        picBoxBackColour.BackColor = colorDlg.Color;
                        break;
                    case 4:
                        picBoxTitleColour.BackColor = colorDlg.Color;
                        break;
                }

                picBoxTitleColour.BackColor = colorDlg.Color;
            }
        }

        private void GetValues()
        {
            if (Properties.Settings.Default.TDB == true)
                chkBoxTDB.CheckState = CheckState.Checked;
            else
                chkBoxTDB.CheckState = CheckState.Unchecked;

            if (Properties.Settings.Default.UDB == true)
                chkBoxUDB.CheckState = CheckState.Checked;
            else
                chkBoxUDB.CheckState = CheckState.Unchecked;

            if (Properties.Settings.Default.Lines == true)
                chkBoxLine.CheckState = CheckState.Checked;
            else
                chkBoxLine.CheckState = CheckState.Unchecked;

            if (Properties.Settings.Default.Splines == true)
                chkBoxSpline.CheckState = CheckState.Checked;
            else
                chkBoxSpline.CheckState = CheckState.Unchecked;

            picBoxPointColour.BackColor = Properties.Settings.Default.PointColour;
            picBoxLineColour.BackColor = Properties.Settings.Default.LineColour;
            picBoxBackColour.BackColor = Properties.Settings.Default.BackColour;
            picBoxTitleColour.BackColor = Properties.Settings.Default.TitleColour;
        }

        private void SaveValues()
        {
            if (chkBoxTDB.CheckState == CheckState.Checked)
                Properties.Settings.Default.TDB = true;
            else
                Properties.Settings.Default.TDB = false;

            if (chkBoxUDB.CheckState == CheckState.Checked)
                Properties.Settings.Default.UDB = true;
            else
                Properties.Settings.Default.UDB = false;

            if (chkBoxLine.CheckState == CheckState.Checked)
                Properties.Settings.Default.Lines = true;
            else
                Properties.Settings.Default.Lines = false;

            if (chkBoxSpline.CheckState == CheckState.Checked)
                Properties.Settings.Default.Splines = true;
            else
                Properties.Settings.Default.Splines = false;

            Properties.Settings.Default.PointColour = picBoxPointColour.BackColor;
            Properties.Settings.Default.LineColour = picBoxLineColour.BackColor;
            Properties.Settings.Default.BackColour = picBoxBackColour.BackColor;
            Properties.Settings.Default.TitleColour = picBoxTitleColour.BackColor;
            Properties.Settings.Default.Save();
        }
    }
}
