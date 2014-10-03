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

        private void button1_Click(object sender, EventArgs e)
        {
            SaveValues();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetValues()
        {
            if (Properties.Settings.Default.TDB == true)
                chkBox_TDB.CheckState = CheckState.Checked;
            else
                chkBox_TDB.CheckState = CheckState.Unchecked;

            if (Properties.Settings.Default.UDB == true)
                chkBox_UDB.CheckState = CheckState.Checked;
            else
                chkBox_UDB.CheckState = CheckState.Unchecked;

            if (Properties.Settings.Default.Lines == true)
                chkBox_Line.CheckState = CheckState.Checked;
            else
                chkBox_Line.CheckState = CheckState.Unchecked;

            if (Properties.Settings.Default.Splines == true)
                chkBox_Spline.CheckState = CheckState.Checked;
            else
                chkBox_Spline.CheckState = CheckState.Unchecked;

            picBox_Point_Colour.BackColor = Properties.Settings.Default.PointColour;
            picBox_Line_Colour.BackColor = Properties.Settings.Default.LineColour;
            picBox_Back_Colour.BackColor = Properties.Settings.Default.BackColour;
            picBox_Title_Colour.BackColor = Properties.Settings.Default.TitleColour;
        }

        private void SaveValues()
        {
            if (chkBox_TDB.CheckState == CheckState.Checked)
                Properties.Settings.Default.TDB = true;
            else
                Properties.Settings.Default.TDB = false;

            if (chkBox_UDB.CheckState == CheckState.Checked)
                Properties.Settings.Default.UDB = true;
            else
                Properties.Settings.Default.UDB = false;

            if (chkBox_Line.CheckState == CheckState.Checked)
                Properties.Settings.Default.Lines = true;
            else
                Properties.Settings.Default.Lines = false;

            if (chkBox_Spline.CheckState == CheckState.Checked)
                Properties.Settings.Default.Splines = true;
            else
                Properties.Settings.Default.Splines = false;

            Properties.Settings.Default.PointColour = picBox_Point_Colour.BackColor;
            Properties.Settings.Default.LineColour = picBox_Line_Colour.BackColor;
            Properties.Settings.Default.BackColour = picBox_Back_Colour.BackColor;
            Properties.Settings.Default.TitleColour = picBox_Title_Colour.BackColor;

            Properties.Settings.Default.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.Red;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                picBox_Point_Colour.BackColor = colorDlg.Color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.Red;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                picBox_Line_Colour.BackColor = colorDlg.Color;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.Red;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                picBox_Back_Colour.BackColor = colorDlg.Color;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.Red;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                picBox_Title_Colour.BackColor = colorDlg.Color;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
