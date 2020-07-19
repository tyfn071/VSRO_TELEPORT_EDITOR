using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSRO_TELEPORT_EDITOR
{
    public class CTeleportService:CTeleportBase
    {

        public CTeleportService():base()
        {

        }
        public CTeleportService(EditStatus status):base(status)
        {

        }
        public int m_ID { get; set; }
        public short m_GenRegionID { get; set; }
        public short m_GenPos_X { get; set; }
        public short m_GenPos_Y { get; set; }
        public short m_GenPos_Z { get; set; }
        public short m_GenWorldID { get; set; }

       
        protected override string GetInsertQuery()
        {
            throw new NotImplementedException();
        }
        protected override string GetRemoveQuery()
        {
            throw new NotImplementedException();
        }
        protected override string GetUpdateQuery()
        {
            throw new NotImplementedException();
        }
        protected override void LoadParameters(SqlCommand comm)
        {
            base.LoadParameters(comm);
            comm.Parameters.AddWithValue("@ID", m_ID);
            comm.Parameters.AddWithValue("@GenRegionID",  m_GenRegionID);
            comm.Parameters.AddWithValue("@GenPos_X", m_GenPos_X);
            comm.Parameters.AddWithValue("@GenPos_Y",  m_GenPos_Y);
            comm.Parameters.AddWithValue("@GenPos_Z", m_GenPos_Z);
            comm.Parameters.AddWithValue("@GenWorldID",  m_GenWorldID);

        }
        public override void SaveToDatabase()
        {
            if (m_Status != EditStatus.Notr)
            {
                if (m_Status == EditStatus.New)
                {
                    string sqlQuery = string.Empty;

                    using (SqlConnection conn = new SqlConnection(Globals.s_SqlConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand comm = new SqlCommand(sqlQuery, conn))
                        {
                            LoadParameters(comm);

                            using (SqlDataReader reader = comm.ExecuteReader())
                            {
                                reader.Read();
                                m_ID = reader.GetInt32(0);
                            }

                            m_Status = EditStatus.Notr;
                        }
                    }
                }
                else
                    base.SaveToDatabase();
                
            }
        }
    }
}
