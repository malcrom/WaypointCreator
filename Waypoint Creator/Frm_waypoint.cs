using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Frm_waypoint
{
    public partial class frm_Waypoint : Form
    {
        static DataTable waypoints = new DataTable();
        static DataTable guids = new DataTable();
        static DataTable movepackets = new DataTable();

        string creature_guid = "";
        string creature_entry = "";
        string creature_name = "";
        string SQLtext = "";

        public frm_Waypoint()
        {
            InitializeComponent();
        }

        private void Frm_waypoint_Load(object sender, EventArgs e)
        {
            chart.BackColor = Properties.Settings.Default.BackColour;
            chart.ChartAreas[0].BackColor = Properties.Settings.Default.BackColour;
        }

        private void Frm_waypoint_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int temp = 0;
                if (toolStripTextBoxEntry.Text == "" || toolStripTextBoxEntry.Text == null )
                {
                    FillListBoxWithGuids(temp);
                }
                else
                {
                    temp = Convert.ToInt32(toolStripTextBoxEntry.Text);
                    FillListBoxWithGuids(temp);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please provide number or leave blank.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void toolStripButtonLoadSniff_Click(object sender, EventArgs e)
        {
            object boolresult = null;
            openFileDialog.Title = "Open Files";
            openFileDialog.Filter = "Monster Move File (*.csv)|*.csv";
            openFileDialog.FileName = "*.csv";
            openFileDialog.FilterIndex = 1;
            openFileDialog.ShowReadOnly = false;
            openFileDialog.Multiselect = false;
            openFileDialog.CheckFileExists = true;
            boolresult = openFileDialog.ShowDialog();
            if (Convert.ToInt16(boolresult) == 2)
            {
                // This code runs if the dialog was cancelled
                return;
            }
            else
            {
                LoadFileIntoDatatable(openFileDialog.FileName);
                toolStripTextBoxEntry.Enabled = true;
                toolStripButtonSearch.Enabled = true;
                toolStripStatusLabel.Text = openFileDialog.FileName + " is selected for parsing.";
            }
        }

        private void listBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            FillGrid();
            GraphPath();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridWaypoint.SelectedRows.Count == gridWaypoint.Rows.Count)
            {
                gridWaypoint.Rows.Clear();
            }
            foreach (DataGridViewRow row in gridWaypoint.SelectedRows)
            {
                gridWaypoint.Rows.Remove(row);
            }
            for (var l = 0; l < gridWaypoint.Rows.Count; l++)
            {
                gridWaypoint[0, l].Value = l + 1;
            }
            GraphPath();
        }

        private void createSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TDB)
                createSQL_TDB();
            if (Properties.Settings.Default.UDB)
                createSQL_UDB();
        }

        private void toolStripButtonSettings_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form Frm_settings = new frm_Settings();
            Frm_settings.ShowDialog();
            GraphPath();
        }

        public DataTable GetDataSourceFromFile(string fileName)
        {
            DataTable dt = new DataTable("Waypoints");
            string[] columns = null;

            string col = "entry,guid,x,y,z,o,time";
            columns = col.Split(new char[] { ',' });
            foreach (var column in columns)
                dt.Columns.Add(column);

            var lines = File.ReadAllLines(fileName);

            // reading rest of the data
            for (int i = 0; i < lines.Count(); i++)
            {
                DataRow dr = dt.NewRow();
                string[] values = lines[i].Split(new char[] { ',' });

                //dr[0] = i;
                for (int j = 0; j < values.Count() && j < columns.Count(); j++)
                    dr[j] = values[j];

                dt.Rows.Add(dr);
            }
            return dt;
        }

        public void LoadFileIntoDatatable(string fileName)
        {
            waypoints.Clear();
            waypoints = GetDataSourceFromFile(fileName);
        }

        public void FillListBoxWithGuids(Int32 entry)
        {
            guids.Clear();
            guids = waypoints.DefaultView.ToTable(true, "guid");

            List<string> lst = new List<string>();
            foreach (DataRow r in guids.Rows)
            {
                lst.Add(r["guid"].ToString());
            }
            //listBox.DataSource.clear();
            if (listBox.DataSource != lst)
                listBox.DataSource = lst;
        }

        public void FillGrid()
        {
            creature_guid = (string)listBox.SelectedItem;
            movepackets = waypoints.Clone();

            foreach (DataRow row in waypoints.Rows)
            {
                if (row.Field<string>(1) == creature_guid)
                    movepackets.ImportRow(row);
            }

            creature_entry = movepackets.Rows[0].Field<string>(0);

            gridWaypoint.Rows.Clear();
            for (var l = 0; l < movepackets.Rows.Count; l++)
            {
                gridWaypoint.Rows.Add();
                gridWaypoint[0, gridWaypoint.RowCount - 1].Value = l + 1;
                for (var ll = 1; ll < 6; ll++)
                gridWaypoint[1, gridWaypoint.RowCount - 1].Value = movepackets.Rows[l].Field<string>(2);
                gridWaypoint[2, gridWaypoint.RowCount - 1].Value = movepackets.Rows[l].Field<string>(3);
                gridWaypoint[3, gridWaypoint.RowCount - 1].Value = movepackets.Rows[l].Field<string>(4);
                gridWaypoint[4, gridWaypoint.RowCount - 1].Value = movepackets.Rows[l].Field<string>(5);
                gridWaypoint[5, gridWaypoint.RowCount - 1].Value = movepackets.Rows[l].Field<string>(6);
                gridWaypoint[6, gridWaypoint.RowCount - 1].Value = "";
            }
        }

        public void GraphPath()
        {
            chart.BackColor = Properties.Settings.Default.BackColour;
            chart.ChartAreas[0].BackColor = Properties.Settings.Default.BackColour;
            chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
            chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
            chart.ChartAreas[0].AxisY.IsReversed = true;

            if (creature_entry == "")
                return;

            DataSet DS = new DataSet();
            string sqltext = "SELECT `name` FROM `creature_template` WHERE `entry`=";
            sqltext = sqltext + creature_entry + ";";
            DS = (DataSet)Module.database_conn(sqltext);

            if (DS.Tables["table1"].Rows.Count > 0)
            {
                creature_name = DS.Tables["table1"].Rows[0][0].ToString();
                chart.Titles.Clear();
                Title title = chart.Titles.Add(creature_name + " Entry: " + creature_entry);
                title.Font = new System.Drawing.Font("Arial", 16, FontStyle.Bold);
                title.ForeColor = Properties.Settings.Default.TitleColour;
            }
            else
            {
                chart.Titles.Clear();
                Title title = chart.Titles.Add("Entry " + creature_entry + " not in database");
                title.Font = new System.Drawing.Font("Arial", 16, FontStyle.Bold);
                title.ForeColor = Properties.Settings.Default.TitleColour;
            }

            chart.Series.Clear();
            chart.Series.Add("Path");
            chart.Series["Path"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;

            if (Properties.Settings.Default.Lines == true)
            {
                chart.Series.Add("Line");

                if (Properties.Settings.Default.Splines == true)
                    chart.Series["Line"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                else
                    chart.Series["Line"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }

            for (var l = 0; l < gridWaypoint.RowCount; l++)
            {
                Double xpos = Convert.ToDouble(gridWaypoint[1, l].Value);
                Double ypos = Convert.ToDouble(gridWaypoint[2, l].Value);

                chart.Series["Path"].Points.AddXY(xpos, ypos);
                chart.Series["Path"].Points[l].Color = Properties.Settings.Default.PointColour;
                chart.Series["Path"].Points[l].Label = Convert.ToString(l + 1);

                if (Properties.Settings.Default.Lines == true)
                {
                    chart.Series["Line"].Points.AddXY(xpos, ypos);;
                    chart.Series["Line"].Points[l].Color = Properties.Settings.Default.LineColour;
                }
            }
        }

        private void createSQL_TDB()
        {
            //Send to SQL
            SQLtext = "-- Pathing for " + creature_name + " Entry: " + creature_entry + " 'TDB FORMAT' \r\n" + "SET @NPC := XXXXXX;" + "\r\n" + "SET @PATH := @NPC * 10;" + "\r\n";
            SQLtext = SQLtext + "UPDATE `creature` SET `spawndist`=0,`MovementType`=2,`position_x`=" + Convert.ToString(gridWaypoint[1, 0].Value) + ",`position_y`=" + Convert.ToString(gridWaypoint[2, 0].Value) + ",`position_z`=" + Convert.ToString(gridWaypoint[3, 0].Value) + " WHERE `guid`=@NPC;" + "\r\n";
            SQLtext = SQLtext + "DELETE FROM `creature_addon` WHERE `guid`=@NPC;" + "\r\n";
            SQLtext = SQLtext + "INSERT INTO `creature_addon` (`guid`,`path_id`,`mount`,`bytes1`,`bytes2`,`emote`,`auras`) VALUES (@NPC,@PATH,0,0,1,0, '');" + "\r\n";
            SQLtext = SQLtext + "DELETE FROM `waypoint_data` WHERE `id`=@PATH;" + "\r\n";
            SQLtext = SQLtext + "INSERT INTO `waypoint_data` (`id`,`point`,`position_x`,`position_y`,`position_z`,`orientation`,`delay`,`move_type`,`action`,`action_chance`,`wpguid`) VALUES" + "\r\n";

            for (var l = 0; l < gridWaypoint.RowCount; l++)
            {
                string facing = Convert.ToString(gridWaypoint[4, l].Value);
                if (facing == "")
                    facing = "0";

                string waittime = Convert.ToString(gridWaypoint[6, l].Value);
                if (waittime == "")
                    waittime = "0";

                SQLtext = SQLtext + "(@PATH," + (l + 1) + ",";

                for (var ll = 1; ll < 4; ll++)
                {
                    SQLtext = SQLtext + gridWaypoint[ll, l].Value + ",";
                }

                if (l < (gridWaypoint.RowCount - 1))
                {
                    SQLtext = SQLtext + facing + "," + waittime + ",0,0,100,0)," + "\r\n";
                }
                else
                {
                    SQLtext = SQLtext + facing + "," + waittime + ",0,0,100,0);" + "\r\n";
                }
            }
                SQLtext = SQLtext + "-- " + (string)listBox.SelectedItem + " .go " + Convert.ToString(gridWaypoint[1, 0].Value) + " " + Convert.ToString(gridWaypoint[2, 0].Value) + " " + Convert.ToString(gridWaypoint[3, 0].Value) + "\r\n";
                txtOutput.Text = txtOutput.Text + SQLtext + "\r\n";
        }

        private void createSQL_UDB()
        {
            //Send to SQL
            SQLtext = "-- Pathing for " + creature_name + " Entry: " + creature_entry + " 'UDB FORMAT' \r\n" + "SET @GUID := XXXXXX;" + "\r\n";
            SQLtext = SQLtext + "UPDATE `creature` SET `position_x`=" + Convert.ToString(gridWaypoint[1, gridWaypoint.RowCount - 1].Value) + ",`position_y`=" + Convert.ToString(gridWaypoint[2, gridWaypoint.RowCount - 1].Value) + ",`position_z`=" + Convert.ToString(gridWaypoint[3, gridWaypoint.RowCount - 1].Value) + " WHERE `guid`=@GUID;" + "\r\n";
            SQLtext = SQLtext + "DELETE FROM `creature_movement` WHERE `id`=@GUID;" + "\r\n";
            SQLtext = SQLtext + "INSERT INTO `creature_movement` (`id`,`point`,`position_x`,`position_y`,`position_z`,`waittime`,`script_id`,`textid1`,`textid2`,`textid3`,`textid4`,`textid5`,`emote`,`spell`,`wpguid`,`orientation`,`model1`,`model2`) VALUES" + "\r\n";

            for (var l = 0; l < gridWaypoint.RowCount; l++)
            {
                string facing = Convert.ToString(gridWaypoint[4, l].Value);
                if (facing == "")
                    facing = "0";

                string waittime = Convert.ToString(gridWaypoint[6, l].Value);
                if (waittime == "")
                    waittime = "0";

                SQLtext = SQLtext + "(@GUID," + (l + 1) + ",";

                for (var ll = 1; ll < 4; ll++)
                {
                    SQLtext = SQLtext + gridWaypoint[ll, l].Value + ",";
                }

                if (l < (gridWaypoint.RowCount - 1))
                {
                    SQLtext = SQLtext + waittime + ",0,0,0,0,0,0,0,0,0," + facing + ",0,0)," + "\r\n";
                }
                else
                {
                    SQLtext = SQLtext + waittime + ",0,0,0,0,0,0,0,0,0," + facing + ",0,0);" + "\r\n";
                }
            }
            SQLtext = SQLtext + "-- " + (string)listBox.SelectedItem + " .go " + Convert.ToString(gridWaypoint[1, 0].Value) + " " + Convert.ToString(gridWaypoint[2, 0].Value) + " " + Convert.ToString(gridWaypoint[3, 0].Value) + "\r\n";
            txtOutput.Text = txtOutput.Text + SQLtext + "\r\n";
        }
   }
}
