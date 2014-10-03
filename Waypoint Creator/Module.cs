using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Frm_waypoint
{
	internal static class Module
	{
		private static MySqlConnection conn;

		public static void database_write(string sqlstring)
		{
			MySqlConnection conn = new MySqlConnection();
			MySqlCommand myCommand = new MySqlCommand();
            conn.ConnectionString = "server=" + Properties.Settings.Default.host + "; port=" + Properties.Settings.Default.port + "; user id=" + Properties.Settings.Default.username + "; password=" + Properties.Settings.Default.password + "; database=" + Properties.Settings.Default.database;
			myCommand.Connection = conn;
			myCommand.CommandText = sqlstring;

			try
			{
				conn.Open();
				myCommand.ExecuteNonQuery();
			}
			catch (MySqlException myerror)
			{
                MessageBox.Show("There was an error updating the database: " + myerror.Message, "Database Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		public static object database_conn(string sqlstring)
		{
			conn = new MySqlConnection();
            conn.ConnectionString = "server=" + Properties.Settings.Default.host + "; port=" + Properties.Settings.Default.port + "; user id=" + Properties.Settings.Default.username + "; password=" + Properties.Settings.Default.password + "; database=" + Properties.Settings.Default.database;
			try
			{
				conn.Open();
				MySqlCommand sql = new MySqlCommand(sqlstring, conn);
				DataSet ds = new DataSet();
				MySqlDataAdapter DataAdapter = new MySqlDataAdapter();
				DataAdapter.SelectCommand = sql;
				DataAdapter.Fill(ds, "table1");
				return ds;
			}
			catch (MySqlException myerror)
			{
				MessageBox.Show("Error Connecting to Database: " + myerror.Message, "Database Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return "";
			}
			finally
			{
                conn.Close();
				conn.Dispose();
			}
		}
	}
}