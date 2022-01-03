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
        string mapID          = "";

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

        // Sniff Varibles for sniffs
        public int state_map;
        public int move_time;
        public int move_entry;
        public int move_guid;
        public int move_x;
        public int move_y;
        public int move_z;
        public int move_o;
        public int move_pointx;
        public int move_pointy;
        public int move_pointz;
        public int object_time;
        public int object_entry;
        public int object_guid;
        public int object_pointx;
        public int object_pointy;
        public int object_pointz;
        public string sniff_state;
        public string sniff_move;
        public string sniff_move_1;
        public string sniff_move_2;
        public string sniff_move_3;
        public string sniff_move_4;
        public string sniff_move_5;
        public string sniff_move_6;
        public string sniff_move_7;
        public string sniff_object;
        public string sniff_object_1;
        public string sniff_object_2;
        public string sniff_object_3;
        public string sniff_object_4;

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
            openFileDialog.Title           = "Open File";
            openFileDialog.Filter          = "Parsed Sniff File (*.txt)|*.txt";
            openFileDialog.FileName        = "*.txt";
            openFileDialog.FilterIndex     = 1;
            openFileDialog.ShowReadOnly    = false;
            openFileDialog.Multiselect     = false;
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
            saveFileDialog.Title           = "Save File";
            saveFileDialog.Filter          = "Path Insert SQL (*.sql)|*.sql";
            saveFileDialog.FileName        = "";
            saveFileDialog.FilterIndex     = 1;
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
            if (Properties.Settings.Default.DB)
                createSQL_DB();
            if (Properties.Settings.Default.UDB)
                createSQL_UDB();
            if (Properties.Settings.Default.SAI)
                createSQL_SAI();
            if (Properties.Settings.Default.CPP)
                createCode_cpp();
        }

        private void makegoXyzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = gridWaypoint.SelectedRows[0];
            string go = ".go xyz " + row.Cells[1].Value + " " + row.Cells[2].Value + " " + row.Cells[3].Value;
            Clipboard.SetText(go);
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
                findrange();
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
            findrange();
        }

        public void LoadSniffFileIntoDatatable(string fileName)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            var line = file.ReadLine();
            string filetype = line;
            line = file.ReadLine();
            line = file.ReadLine();
            string sniffversion = line;
            file.Close();

            if (filetype == "# TrinityCore - WowPacketParser")
            {
                // Determine sniff version
                if ((sniffversion.Contains("V4")) || (sniffversion.Contains("V5")))
                    sniff_version_4();
                else if ((sniffversion.Contains("V1")) || (sniffversion.Contains("V2")) || (sniffversion.Contains("V6")) || (sniffversion.Contains("V7")) || (sniffversion.Contains("V9")))
                    sniff_version_6();

                // Process new sniff file
                waypoints.Clear();
                waypoints = GetDataSourceFromSniffFile(fileName);

                if (Properties.Settings.Default.ObjectUpdate == true)
                {
                    this.Text = "Waypoint Creator - Movement data loaded from SMSG_UPDATE_OBJECT";
                }
                else
                {
                    this.Text = "Waypoint Creator - Movement data loaded from SMSG_ON_MONSTER_MOVE";
                }
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
            sniff.o     = "0";
            sniff.time  = "";

            string[] columns = null;

            string col = "entry,guid,x,y,z,o,time,mapID";
            columns = col.Split(new char[] { ',' });
            foreach (var column in columns)
                dt.Columns.Add(column);

            // reading rest of the data
            for (int i = 1; i < lines.Count(); i++)
            {
                if (lines[i].Contains(sniff_state))
                {
                    i++;
                    string[] packetline = lines[i].Split(new char[] { ' ' });
                    mapID = packetline[state_map];
                }

                if (Properties.Settings.Default.ObjectUpdate != true && lines[i].Contains(sniff_move)) // Is this a move packet
                {
                    string[] values = lines[i].Split(new char[] { ' ' });
                    string[] time = values[move_time].Split(new char[] { '.' }); // Get time
                    sniff.time = time[0];

                    do
                    {
                        i++;

                        if (lines[i].Contains(sniff_move_1)) // is this GUID line
                        {
                            if (lines[i].Contains(sniff_move_2) || lines[i].Contains(sniff_move_3)) // Is this a Creature or Vehicle
                            {
                                string[] packetline = lines[i].Split(new char[] { ' ' });
                                sniff.entry = packetline[move_entry]; // Entry count
                                sniff.guid = packetline[move_guid]; // Guid count
                            }
                        }

                        if (lines[i].Contains(sniff_move_4)) // Save Postion for if movement is a turn.
                        {
                            string[] packetline = lines[i].Split(new char[] { ' ' });
                            sniff.x = packetline[move_x];
                            sniff.y = packetline[move_y];
                            sniff.z = packetline[move_z];
                            //sniff.o = "0";
                        }

                        if (lines[i].Contains(sniff_move_5)) // Replace Position with move to location.
                        {
                            string[] packetline = lines[i].Split(new char[] { ' ' });
                            sniff.x = packetline[move_pointx];
                            sniff.y = packetline[move_pointy];
                            sniff.z = packetline[move_pointz];
                            //sniff.o = "0";
                        }

                        if (lines[i].Contains(sniff_move_6)) // moving to player or creature will be ignored
                        {
                            sniff.entry = ""; // Clear entry so movement will be ignored.
                            break;
                        }

                        if (lines[i].Contains(sniff_move_7))
                        {
                            string[] packetline = lines[i].Split(new char[] { ' ' });
                            sniff.o = packetline[move_o];
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
                        dr[7] = mapID;
                        dt.Rows.Add(dr);
                        sniff.entry = "";
                    }
                    sniff.o = "0";
                }

                // Sniff points from createobject "Mostly for flying"
                if (Properties.Settings.Default.ObjectUpdate == true && lines[i].Contains(sniff_object))
                {
                    sniff.entry = "";
                    string[] values = lines[i].Split(new char[] { ' ' });
                    string[] time = values[object_time].Split(new char[] { '.' });
                    sniff.time = time[0];

                    do
                    {
                        i++;

                        if (lines[i].Contains(sniff_object_1))
                        {
                            if (lines[i].Contains(sniff_object_2) || lines[i].Contains(sniff_object_3))
                            {
                                string[] packetline = lines[i].Split(new char[] { ' ' });
                                sniff.entry = packetline[object_entry];
                                sniff.guid = packetline[object_guid];
                            }
                        }

                        // Endpoint: X: doesn't exist in the sniffs I checked. May be 335 and above. 
                        if (lines[i].Contains(sniff_object_4))
                        {

                            string[] packetline = lines[i].Split(new char[] { ' ' });
                            sniff.x = packetline[object_pointx];
                            sniff.y = packetline[object_pointy];
                            sniff.z = packetline[object_pointz];
                            sniff.o = "0";

                            DataRow dr = dt.NewRow();
                            dr[0] = sniff.entry;
                            dr[1] = sniff.guid;
                            dr[2] = sniff.x;
                            dr[3] = sniff.y;
                            dr[4] = sniff.z;
                            dr[5] = sniff.o;
                            dr[6] = sniff.time;
                            dr[7] = mapID;
                            dt.Rows.Add(dr);
                        }

                    } while (lines[i] != "");
                    sniff.entry = "";
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

            findrange();
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

        private void createSQL_DB()
        {
            //Send to SQL
            SQLtext = "-- Pathing for " + creature_name + " Entry: " + creature_entry + "\r\n" + "SET @NPC := XXXXXX;" + "\r\n" + "SET @PATH := @NPC * 10;" + "\r\n";
            SQLtext = SQLtext + "UPDATE `creature` SET `wander_distance`=0,`MovementType`=2,`position_x`=" + Convert.ToString(gridWaypoint[1, 0].Value) + ",`position_y`=" + Convert.ToString(gridWaypoint[2, 0].Value) + ",`position_z`=" + Convert.ToString(gridWaypoint[3, 0].Value) + " WHERE `guid`=@NPC;" + "\r\n";
            SQLtext = SQLtext + "DELETE FROM `creature_addon` WHERE `guid`=@NPC;" + "\r\n";
            SQLtext = SQLtext + "INSERT INTO `creature_addon` (`guid`,`path_id`,`mount`,`bytes1`,`bytes2`,`emote`,`visibilityDistanceType`,`auras`) VALUES (@NPC,@PATH,0,0,1,0,0, '');" + "\r\n";
            SQLtext = SQLtext + "DELETE FROM `waypoint_data` WHERE `id`=@PATH;" + "\r\n";
            SQLtext = SQLtext + "INSERT INTO `waypoint_data` (`id`,`point`,`position_x`,`position_y`,`position_z`,`orientation`,`delay`,`move_type`,`action`,`action_chance`,`wpguid`) VALUES" + "\r\n";

            for (var l = 0; l < gridWaypoint.RowCount; l++)
            {
                string facing = Convert.ToString(gridWaypoint[4, l].Value);
                if (facing == "")
                    facing = "0";

                string time = Convert.ToString(gridWaypoint[5, l].Value);

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
                
            SQLtext = SQLtext + "-- " + (string)listBox.SelectedItem + " .go xyz " + Convert.ToString(gridWaypoint[1, 0].Value) + " " + Convert.ToString(gridWaypoint[2, 0].Value) + " " + Convert.ToString(gridWaypoint[3, 0].Value) + "\r\n";
            txtOutput.Text = txtOutput.Text + SQLtext + "\r\n";
        }

        private void createSQL_UDB()
        {
            //Send to SQL
            SQLtext = "-- Pathing for " + creature_name + " Entry: " + creature_entry + " 'UDB FORMAT' \r\n" + "SET @GUID := XXXXXX;" + "\r\n";
            SQLtext = SQLtext + "UPDATE `creature` SET `wander_distance`=0,`MovementType`=2,`position_x`=" + Convert.ToString(gridWaypoint[1, 0].Value) + ",`position_y`=" + Convert.ToString(gridWaypoint[2, 0].Value) + ",`position_z`=" + Convert.ToString(gridWaypoint[3, 0].Value) + " WHERE `guid`=@GUID;" + "\r\n";
            SQLtext = SQLtext + "DELETE FROM `creature_movement` WHERE `id`=@GUID;" + "\r\n";
            SQLtext = SQLtext + "INSERT INTO `creature_movement` (`id`,`point`,`position_x`,`position_y`,`position_z`,`waittime`,`script_id`,`orientation`) VALUES" + "\r\n";

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
                    SQLtext = SQLtext + waittime + ",0," + facing + ")," + "\r\n";
                }
                else
                {
                    SQLtext = SQLtext + waittime + ",0," + facing + ");" + "\r\n";
                }
            }

            SQLtext = SQLtext + "-- " + (string)listBox.SelectedItem + " .go xyz " + Convert.ToString(gridWaypoint[1, 0].Value) + " " + Convert.ToString(gridWaypoint[2, 0].Value) + " " + Convert.ToString(gridWaypoint[3, 0].Value) + "\r\n";
            txtOutput.Text = txtOutput.Text + SQLtext + "\r\n";
        }

        private void createSQL_SAI()
        {
            string name = creature_name.Replace("'", "''");
            //Send to SQL
            SQLtext = "-- Pathing for " + creature_name + " Entry: " + creature_entry + " 'SAI FORMAT' \r\n" + "SET @NPC := XXXXXX;" + "\r\n";
            SQLtext = SQLtext + "DELETE FROM `waypoints` WHERE `id`=@NPC;" + "\r\n";
            SQLtext = SQLtext + "INSERT INTO `waypoints` (`entry`,`pointid`,`position_x`,`position_y`,`position_z`,`point_comment`) VALUES" + "\r\n";

            for (var l = 0; l < gridWaypoint.RowCount; l++)
            {
                string facing = Convert.ToString(gridWaypoint[4, l].Value);
                if (facing == "")
                    facing = "0";

                string time = Convert.ToString(gridWaypoint[5, l].Value);

                string waittime = Convert.ToString(gridWaypoint[6, l].Value);
                if (waittime == "")
                    waittime = "0";

                SQLtext = SQLtext + "(@NPC," + (l + 1) + ",";

                for (var ll = 1; ll < 4; ll++)
                {
                    SQLtext = SQLtext + gridWaypoint[ll, l].Value + ",";
                }

                if (l < (gridWaypoint.RowCount - 1))
                {
                    SQLtext = SQLtext + "'" + name + "')," + "\r\n";
                }
                else
                {
                    SQLtext = SQLtext + "'" + name + "');" + "\r\n";
                }
            }

            SQLtext = SQLtext + "-- " + (string)listBox.SelectedItem + " .go xyz " + Convert.ToString(gridWaypoint[1, 0].Value) + " " + Convert.ToString(gridWaypoint[2, 0].Value) + " " + Convert.ToString(gridWaypoint[3, 0].Value) + "\r\n";
            txtOutput.Text = txtOutput.Text + SQLtext + "\r\n";
        }

        private void createCode_cpp()
        {
            String Codetext = "// Position Constant for " + creature_name + " Entry: " + creature_entry + " 'C++ FORMAT' \r\n" + "Position const XXXXXX[] =" + "\r\n" + "{" + "\r\n";
            String Codeline = "";

            for (var l = 0; l < gridWaypoint.RowCount; l++)
            {
                Codeline = "    { ";
                for (var ll = 1; ll < 4; ll++)
                {
                    Codeline = Codeline + gridWaypoint[ll, l].Value + "f";
                    if (ll < 3)
                        Codeline = Codeline + ", ";
                    else
                        Codeline = Codeline + " }";
                }
                if (l < gridWaypoint.RowCount - 1)
                    Codeline = Codeline + "," + "\r\n";
                else
                    Codeline = Codeline + "\r\n";

                Codetext = Codetext + Codeline;
            }
            Codetext = Codetext + "};" + "\r\n";
            txtOutput.Text = txtOutput.Text + Codetext + "\r\n";
        }

        private void sniff_version_4()
        {
            state_map = 2;
            move_time = 9;
            move_entry = 6;
            move_guid = 2;
            move_x = 2;
            move_y = 4;
            move_z = 6;
            move_o = 2;
            move_pointx = 3;
            move_pointy = 5;
            move_pointz = 7;
            object_time = 9;
            object_entry = 7;
            object_guid = 3;
            object_pointx = 5;
            object_pointy = 7;
            object_pointz = 9;
            sniff_state = "SMSG_INIT_WORLD_STATES";
            sniff_move = "SMSG_ON_MONSTER_MOVE";
            sniff_move_1 = "GUID: Full:";
            sniff_move_2 = "Creature";
            sniff_move_3 = "Vehicle";
            sniff_move_4 = "Position: X:";
            sniff_move_5 = " Endpoint: X:";
            sniff_move_6 = "Spline Type: 3";
            sniff_move_7 = "Facing Angle:";
            sniff_object = "SMSG_UPDATE_OBJECT";
            sniff_object_1 = "GUID: Full:";
            sniff_object_2 = "Creature";
            sniff_object_3 = "Vehicle";
            sniff_object_4 = "Spline Waypoint: X:";
        }

        private void sniff_version_6()
        {
            state_map = 1;
            move_time = 9;
            move_entry = 8;
            move_guid = 2;
            move_x = 2;
            move_y = 4;
            move_z = 6;
            move_o = 3;
            move_pointx = 5;
            move_pointy = 7;
            move_pointz = 9;
            object_time = 9;
            object_entry = 9;
            object_guid = 3;
            object_pointx = 4;
            object_pointy = 6;
            object_pointz = 8;
            sniff_state = "SMSG_INIT_WORLD_STATES";
            sniff_move = "SMSG_ON_MONSTER_MOVE";
            sniff_move_1 = "MoverGUID: Full:";
            sniff_move_2 = "Creature/0";
            sniff_move_3 = "Vehicle/0";
            sniff_move_4 = "Position: X:";
            sniff_move_5 = " Points: X:";
            sniff_move_6 = "Face: 2";
            sniff_move_7 = "FaceDirection:";
            sniff_object = "SMSG_UPDATE_OBJECT";
            sniff_object_1 = "MoverGUID: Full:";
            sniff_object_2 = "Creature/0";
            sniff_object_3 = "Vehicle/0";
            sniff_object_4 = "Endpoint: X:";
        }

        private void findrange()
        {
            float wanderRange = 0.0f;

            for (var i = 0; i < gridWaypoint.RowCount; i++)
            {
                float x1 = float.Parse(gridWaypoint[1, i].Value.ToString());
                float y1 = float.Parse(gridWaypoint[2, i].Value.ToString());
                float z1 = float.Parse(gridWaypoint[3, i].Value.ToString());

                for (var ii = 0; ii < gridWaypoint.RowCount; ii++)
                {
                    float x2 = float.Parse(gridWaypoint[1, ii].Value.ToString());
                    float y2 = float.Parse(gridWaypoint[2, ii].Value.ToString());
                    float z2 = float.Parse(gridWaypoint[3, ii].Value.ToString());

                    float deltaX = x2 - x1;
                    float deltaY = y2 - y1;
                    float deltaZ = z2 - z1;

                    float distance = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);

                    if (distance > wanderRange)
                        wanderRange = distance;
                }

            }
            toolStripLabelRange.Text = "Wander Range: " + (wanderRange/2).ToString();
        }
    }
}
