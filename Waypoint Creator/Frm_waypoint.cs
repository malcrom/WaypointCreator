using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Frm_waypoint
{
    public partial class frm_Waypoint : Form
    {
        static DataTable waypoints   = new DataTable();
        static DataTable guids       = new DataTable();
        static DataTable movePackets = new DataTable();
        static DataSet copiedRows    = new DataSet();
        static DataSet pasteTable    = new DataSet();

        string creature_guid  = "";
        string creature_entry = "";
        string creature_name  = "";
        string SQLtext        = "";

        struct Packet
        {
            public string time;
            public string x;
            public string y;
            public string z;
            public string o;
            public string entry;
            public string guid;
        };

        public frm_Waypoint()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
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

        private void toolStripButtonLoadSniff_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Open File";
            openFileDialog.Filter = "Parsed Sniff File (*.txt)|*.txt";
            openFileDialog.FileName = "*.txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.ShowReadOnly = false;
            openFileDialog.Multiselect = false;
            openFileDialog.CheckFileExists = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadSniffFileIntoDatatable(openFileDialog.FileName);
                toolStripTextBoxEntry.Enabled = true;
                toolStripButtonSearch.Enabled = true;
                toolStripStatusLabel.Text = openFileDialog.FileName + " is selected for input.";
            }
            else
            {
                // This code runs if the dialog was cancelled
                return;
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "Save File";
            saveFileDialog.Filter = "Path Insert SQL (*.sql)|*.sql";
            saveFileDialog.FileName = "";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.CheckFileExists = false;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (string line in txtOutput.Lines)
                            sw.Write(line + sw.NewLine);

                        sw.Close();
                        MessageBox.Show("SQL Pathing Inserts written to file " + saveFileDialog.FileName, "SQL Written to file", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            else
            {
                // This code runs if the dialog was cancelled
                return;
            }
        }

        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string temp = "0";
                if (toolStripTextBoxEntry.Text == "" || toolStripTextBoxEntry.Text == null )
                {
                    FillListBoxWithGuids(temp);
                }
                else
                {
                    temp = toolStripTextBoxEntry.Text;
                    FillListBoxWithGuids(temp);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please provide number or leave blank.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void toolStripButtonSettings_Click(object sender, EventArgs e)
        {
            // Show Settings dialog
            System.Windows.Forms.Form Frm_settings = new frm_Settings();
            Frm_settings.ShowDialog();
            GraphPath();
        }

        private void listBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // On guid select fill grid and graph.
            if ((string)listBox.SelectedItem != "" && (string)listBox.SelectedItem != null)
            {
                FillGrid();
                GraphPath();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cut selected fields from grid.
            CopyCutFromGrid(true);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Copy selected fields from grid.
            CopyCutFromGrid(false);
        }

        private void pasteAboveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Paste cut or copied data into grid above selected row.
            PasteToGrid(true);
        }

        private void pasteBelowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Paste cut or copied data into grid below selected row.
            PasteToGrid(false);
        }

        private void createSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TDB)
                createSQL_TDB();
            if (Properties.Settings.Default.UDB)
                createSQL_UDB();
        }

        private void CopyCutFromGrid(bool cut)
        {
            // Copy selected fields from grid and cut if cut is true.
            copiedRows.Tables.Clear();
            copiedRows.Tables.Add();
            copiedRows.Tables[0].Columns.AddRange(new DataColumn[6] {new DataColumn("x", typeof(string)), new DataColumn("y", typeof(string)), new DataColumn("z", typeof(string)), new DataColumn("o",typeof(string)), new DataColumn("time",typeof(string)), new DataColumn("delay",typeof(string)) });

            foreach (DataGridViewRow row in gridWaypoint.SelectedRows)
            {
                copiedRows.Tables[0].Rows.Add(row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value, row.Cells[6].Value);
                if (cut)
                    gridWaypoint.Rows.Remove(row);
            }

            if (cut)
            {
                for (var l = 0; l < gridWaypoint.Rows.Count; l++)
                    gridWaypoint[0, l].Value = l + 1;

                GraphPath();
            }
        }

        private void PasteToGrid(bool above)
        {
            // Paste copiedRows into table
            pasteTable.Tables.Clear();
            pasteTable.Tables.Add();
            pasteTable.Tables[0].Columns.AddRange(new DataColumn[6] {new DataColumn("x", typeof(string)), new DataColumn("y", typeof(string)),
                            new DataColumn("z", typeof(string)), new DataColumn("o",typeof(string)), new DataColumn("time",typeof(string)), new DataColumn("delay",typeof(string)) });

            int selected = gridWaypoint.SelectedRows[0].Index;

            // If the selected row is not the first row copy all rows above it to pasteTable
            if (selected > 0)
            {
                for (var l = 0; l < selected; l++)
                {
                    pasteTable.Tables[0].Rows.Add(gridWaypoint[1,l].Value, gridWaypoint[2,l].Value, gridWaypoint[3,l].Value, gridWaypoint[4,l].Value, gridWaypoint[5,l].Value, gridWaypoint[6,l].Value);
                }

            }

            // If pasting below selected row, add selected row to pasteTable before copiedRows
            if (!above)
                pasteTable.Tables[0].Rows.Add(gridWaypoint[1,selected].Value, gridWaypoint[2,selected].Value, gridWaypoint[3,selected].Value, gridWaypoint[4,selected].Value, gridWaypoint[5,selected].Value, gridWaypoint[6,selected].Value);

            // Add copiedRows
            for (var l = copiedRows.Tables[0].Rows.Count - 1; l > -1; l--)
            {
                pasteTable.Tables[0].Rows.Add(copiedRows.Tables[0].Rows[l].Field<string>(0), copiedRows.Tables[0].Rows[l].Field<string>(1), copiedRows.Tables[0].Rows[l].Field<string>(2), copiedRows.Tables[0].Rows[l].Field<string>(3), copiedRows.Tables[0].Rows[l].Field<string>(4), copiedRows.Tables[0].Rows[l].Field<string>(5));
            }

            // If pasting above selected row, add selected row to pasteTable after copiedRows
            if (above)
                pasteTable.Tables[0].Rows.Add(gridWaypoint[1, selected].Value, gridWaypoint[2, selected].Value, gridWaypoint[3, selected].Value, gridWaypoint[4, selected].Value, gridWaypoint[5, selected].Value, gridWaypoint[6, selected].Value);

            // Add all rows below selected row
            if (selected < gridWaypoint.Rows.Count - 1)
            {
                for (var l = selected + 1; l < gridWaypoint.Rows.Count; l++)
                {
                    pasteTable.Tables[0].Rows.Add(gridWaypoint[1, l].Value, gridWaypoint[2, l].Value, gridWaypoint[3, l].Value, gridWaypoint[4, l].Value, gridWaypoint[5, l].Value, gridWaypoint[6, l].Value);
                }

            }

            // All data now in pasteTable. Now to replace grid contents with pasteTable.
            gridWaypoint.Rows.Clear();

            for (var l = 0; l < pasteTable.Tables[0].Rows.Count; l++)
                gridWaypoint.Rows.Add(l + 1, pasteTable.Tables[0].Rows[l].Field<string>(0), pasteTable.Tables[0].Rows[l].Field<string>(1), pasteTable.Tables[0].Rows[l].Field<string>(2), pasteTable.Tables[0].Rows[l].Field<string>(3), pasteTable.Tables[0].Rows[l].Field<string>(4), pasteTable.Tables[0].Rows[l].Field<string>(5));

            GraphPath();
        }

        public void LoadSniffFileIntoDatatable(string fileName)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            var line = file.ReadLine();
            file.Close();

            if (line == "# TrinityCore - WowPacketParser")
            {
                waypoints.Clear();
                waypoints = GetDataSourceFromSniffFile(fileName);
            }
            else
            {
                MessageBox.Show(saveFileDialog.FileName + " is is not a valid TrinityCore parsed sniff file.", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public DataTable GetDataSourceFromSniffFile(string fileName)
        {
            // Clear old sniff displays
            toolStripStatusLabel.Text = "Loading File...";
            listBox.DataSource = null;
            listBox.Refresh();
            gridWaypoint.Rows.Clear();
            chart.Titles.Clear();
            chart.Series.Clear();

            // Set cursor as hourglass
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            var lines = File.ReadAllLines(fileName);

            DataTable dt = new DataTable("Waypoints");

            Packet sniff;

            sniff.entry = "";
            sniff.guid  = "";
            sniff.x     = "";
            sniff.y     = "";
            sniff.z     = "";
            sniff.o     = "";
            sniff.time  = "";

            string[] columns = null;

            string col = "entry,guid,x,y,z,o,time";
            columns = col.Split(new char[] { ',' });
            foreach (var column in columns)
                dt.Columns.Add(column);

            // reading rest of the data
            for (int i = 1; i < lines.Count(); i++)
            {
                if (lines[i].Contains("SMSG_ON_MONSTER_MOVE"))
                {
                    string[] values = lines[i].Split(new char[] { ' ' });
                    string[] time = values[9].Split(new char[] { '.' });
                    sniff.time = time[0];

                    do
                    {
                        i++;

                        if (lines[i].Contains("MoverGUID: Full:"))
                        {
                            if (lines[i].Contains("Creature/0") || lines[i].Contains("Vehicle/0"))
                            {
                                string[] packetline = lines[i].Split(new char[] { ' ' });
                                sniff.entry = packetline[8];
                                sniff.guid = packetline[2];
                            }
                        }

                        if (lines[i].Contains("Position: X:"))
                        {
                            string[] packetline = lines[i].Split(new char[] { ' ' });
                            sniff.x = packetline[2];
                            sniff.y = packetline[4];
                            sniff.z = packetline[6];
                            sniff.o = "0";
                        }

                        if (lines[i].Contains("Points: X:"))
                        {
                            string[] packetline = lines[i].Split(new char[] { ' ' });
                            sniff.x = packetline[5];
                            sniff.y = packetline[7];
                            sniff.z = packetline[9];
                            sniff.o = "0";
                        }

                        if (lines[i].Contains("FaceDirection:"))
                        {
                            string[] packetline = lines[i].Split(new char[] { ' ' });
                            sniff.o = packetline[3];
                        }

                        if (lines[i].Contains("WayPoints: X:"))
                        {
                            string[] packetline = lines[i].Split(new char[] { ' ' });
                            sniff.x = packetline[5];
                            sniff.y = packetline[7];
                            sniff.z = packetline[9];
                            sniff.o = "0";

                            DataRow dr = dt.NewRow();
                            dr[0] = sniff.entry;
                            dr[1] = sniff.guid;
                            dr[2] = sniff.x;
                            dr[3] = sniff.y;
                            dr[4] = sniff.z;
                            dr[5] = sniff.o;
                            dr[6] = sniff.time;
                            dt.Rows.Add(dr);
                            sniff.entry = "";
                        }

                    } while (lines[i] != "");

                    if (sniff.entry != "")
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = sniff.entry;
                        dr[1] = sniff.guid;
                        dr[2] = sniff.x;
                        dr[3] = sniff.y;
                        dr[4] = sniff.z;
                        dr[5] = sniff.o;
                        dr[6] = sniff.time;
                        dt.Rows.Add(dr);
                        sniff.entry = "";
                    }
                }

                if (Properties.Settings.Default.ObjectUpdate == true && lines[i].Contains("SMSG_UPDATE_OBJECT"))
                {
                    sniff.entry = "";
                    string[] values = lines[i].Split(new char[] { ' ' });
                    string[] time = values[9].Split(new char[] { '.' });
                    sniff.time = time[0];

                    do
                    {
                        i++;

                        if (lines[i].Contains("MoverGUID: Full:"))
                        {
                            if (lines[i].Contains("Vehicle/0") || lines[i].Contains("Creature/0"))
                            {
                                string[] packetline = lines[i].Split(new char[] { ' ' });
                                sniff.entry = packetline[9];
                                sniff.guid = packetline[3];
                            }
                        }

                        if (lines[i].Contains("Transport/0"))
                        {
                            if (lines[i].Contains("Transport Position: X:"))
                            {

                                string[] packetline = lines[i].Split(new char[] { ' ' });
                                sniff.x = packetline[4];
                                sniff.y = packetline[6];
                                sniff.z = packetline[8];
                                sniff.o = packetline[10];
                            }
                        }

                        if (lines[i].Contains("Points: X:"))
                        {

                            string[] packetline = lines[i].Split(new char[] { ' ' });
                            sniff.x = packetline[4];
                            sniff.y = packetline[6];
                            sniff.z = packetline[8];
                            sniff.o = "0";

                            DataRow dr = dt.NewRow();
                            dr[0] = sniff.entry;
                            dr[1] = sniff.guid;
                            dr[2] = sniff.x;
                            dr[3] = sniff.y;
                            dr[4] = sniff.z;
                            dr[5] = sniff.o;
                            dr[6] = sniff.time;
                            dt.Rows.Add(dr);
                        }

                    } while (lines[i] != "");
                }
            }

            sniff.entry = "";
            this.Cursor = Cursors.Default;
            return dt;
        }

        public void FillListBoxWithGuids(string entry)
        {
            guids.Clear();
            guids = waypoints.DefaultView.ToTable(true, "guid", "entry");
            List<string> lst = new List<string>();

            foreach (DataRow r in guids.Rows)
            {
                if (entry != "0")
                {
                    if (entry == r["entry"].ToString())
                        lst.Add(r["guid"].ToString());
                }
                else
                {
                    if (r["guid"].ToString() != "")
                        lst.Add(r["guid"].ToString());
                }
            }

            lst.Sort();
            if (listBox.DataSource != lst)
                listBox.DataSource = lst;
            listBox.Refresh();
        }

        public void FillGrid()
        {
                creature_guid = (string)listBox.SelectedItem;
                movePackets = waypoints.Clone();

                foreach (DataRow row in waypoints.Rows)
                {
                    if (row.Field<string>(1) == creature_guid)
                        movePackets.ImportRow(row);
                }

                creature_entry = movePackets.Rows[0].Field<string>(0);

                gridWaypoint.Rows.Clear();

                for (var l = 0; l < movePackets.Rows.Count; l++)
                    gridWaypoint.Rows.Add(l + 1, movePackets.Rows[l].Field<string>(2), movePackets.Rows[l].Field<string>(3), movePackets.Rows[l].Field<string>(4), movePackets.Rows[l].Field<string>(5), movePackets.Rows[l].Field<string>(6), "");
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

            if (Properties.Settings.Default.UsingDB == true)
            {
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
            }
            else
            {
                chart.Titles.Clear();
                Title title = chart.Titles.Add("Entry " + creature_entry + " database not connected");
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
                // TODO Add Label Colour to settings
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
