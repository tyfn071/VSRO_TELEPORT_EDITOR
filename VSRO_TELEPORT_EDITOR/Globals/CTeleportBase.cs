using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace VSRO_TELEPORT_EDITOR
{
    public abstract class CTeleportBase:ITeleport
    {

        public CTeleportBase()
        {
            m_Status = EditStatus.Notr;
        }
        public CTeleportBase(EditStatus status)
        {
            m_Status = status;
        }
        public EditStatus m_Status;
        public int m_Service { get; set; }
        protected abstract string GetInsertQuery();
        protected abstract string GetUpdateQuery();
        protected abstract string GetRemoveQuery();
        protected virtual void LoadParameters(SqlCommand comm)
        {
            comm.Parameters.AddWithValue("@Service", m_Service);
        }


        public virtual void SaveToDatabase()
        {
            if(m_Status!=EditStatus.Notr)
            {
                string sqlQuery = string.Empty;

                switch(m_Status)
                {
                    case EditStatus.New:
                        sqlQuery = GetInsertQuery();
                        break;
                    case EditStatus.Edited:
                        sqlQuery = GetUpdateQuery();
                        break;
                    case EditStatus.Removed:
                        sqlQuery = GetRemoveQuery();
                        break;
                }

                using (SqlConnection conn = new SqlConnection(Globals.s_SqlConnectionString))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand(sqlQuery, conn))
                    {
                        LoadParameters(comm);
                        comm.ExecuteNonQuery();
                        m_Status = EditStatus.Notr;
                    }
                }
            }

        }
        public static void SaveToClient(string filename)
        {
            string query = string.Empty;

            switch (filename)
            {
                case "teleportlink.txt":
                    query = "SELECT [Service] ,[OwnerTeleport] ,[TargetTeleport] ,[Fee] ,[RestrictBindMethod] ,[RunTimeTeleportMethod] ,[CheckResult] ,[Restrict1] ,[Data1_1] ,[Data1_2] ,[Restrict2] ,[Data2_1] ,[Data2_2] ,[Restrict3] ,[Data3_1] ,[Data3_2] ,[Restrict4] ,[Data4_1] ,[Data4_2] ,[Restrict5] ,[Data5_1] ,[Data5_2] FROM [dbo].[_RefTeleLink] WHERE Service = 1";
                    break;
                case "teleportdata.txt":
                    query = "SELECT [Service] ,[ID] ,LTRIM(RTRIM([CodeName128])) ,[AssocRefObjID] ,[ZoneName128] ,[GenRegionID] ,[GenPos_X] ,[GenPos_Y] ,[GenPos_Z] ,[GenAreaRadius] ,[CanBeResurrectPos] ,[CanGotoResurrectPos] ,[GenWorldID] FROM [dbo].[_RefTeleport] WHERE Service = 1";
                    break;
                case "refoptionalteleport.txt":
                    query = "select * from _RefOptionalTeleport where Service=1 order by ID";
                    break;
            }

            using (SqlConnection conn = new SqlConnection(Globals.s_SqlConnectionString))
            {
                conn.Open();
                using (SqlDataAdapter comm = new SqlDataAdapter(query, conn))
                {

                    DataTable table = new DataTable();
                    comm.Fill(table);


                    StringBuilder output = new StringBuilder();
                    foreach (DataRow rows in table.Rows)
                    {
                        int i = 0;
                        foreach (DataColumn col in table.Columns)
                        {
                            string linend = (i < table.Columns.Count - 1 ? "\t" : "");
                            if (col.DataType == typeof(float))
                                output.AppendFormat("{0}{1}", ((float)rows[i]).ToString("R"), linend);
                            else
                                output.AppendFormat("{0}{1}", rows[i], linend);
                            i++;
                        }
                        output.AppendLine();
                    }

                    if (!Directory.Exists(Application.StartupPath+@"\Media\server_dep\silkroad\textdata"))
                        Directory.CreateDirectory(Application.StartupPath + @"\Media\server_dep\silkroad\textdata");

                    using (FileStream cltxt = new FileStream(Application.StartupPath + @"\Media\server_dep\silkroad\textdata\" + filename, FileMode.Create))
                    {
                        using (StreamWriter cltxtwriter = new StreamWriter(cltxt, Encoding.Unicode))
                        {
                            cltxtwriter.Write(output.ToString());
                            cltxtwriter.Close();
                            cltxt.Close();
                        }
                    }
                }
            }
        }
    }
}
