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
            comm.Parameters.Add("@ID", SqlDbType.Int, m_ID);
            comm.Parameters.Add("@GenRegionID", SqlDbType.SmallInt, m_GenRegionID);
            comm.Parameters.Add("@GenPos_X", SqlDbType.SmallInt, m_GenPos_X);
            comm.Parameters.Add("@GenPos_Y", SqlDbType.SmallInt, m_GenPos_Y);
            comm.Parameters.Add("@GenPos_Z", SqlDbType.SmallInt, m_GenPos_Z);
            comm.Parameters.Add("@GenWorldID", SqlDbType.SmallInt, m_GenWorldID);

        }
    }
}
