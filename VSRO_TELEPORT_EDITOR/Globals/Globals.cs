using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSRO_TELEPORT_EDITOR
{
    static class Globals
    {
        internal static string s_SqlConnectionString;
        internal static Dictionary<int, string> GameWorldList;
        internal static Dictionary<string, int> GameWorldIDList;

        internal static void LoadGameWorlds()
        {
            GameWorldList = new Dictionary<int, string>();
            GameWorldIDList = new Dictionary<string, int>();
            using(SqlConnection  conn=new SqlConnection(s_SqlConnectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("select ID,WorldCodeName128 from _RefGame_World order by ID", conn))
                {
                    using(SqlDataReader reader=command.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            while(reader.Read())
                            {
                                GameWorldList.Add(reader.GetInt32(0), reader.GetString(1));
                                GameWorldIDList.Add(reader.GetString(1), reader.GetInt32(0));
                            }
                        }
                    }
                }
            }
        }

        internal static void SetDataGridComboBoxColumn<T>(int idx, List<T> dSource,DataGridView refGridView)
        {
            DataGridViewComboBoxColumn c = (DataGridViewComboBoxColumn)refGridView.Columns[idx];
            c.ValueType = typeof(T);
            c.DataSource = dSource;
        }
    }
}
