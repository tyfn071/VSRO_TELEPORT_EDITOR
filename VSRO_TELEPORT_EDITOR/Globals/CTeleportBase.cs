using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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

        }
    }
}
