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
        protected SqlCommand m_SqlObj;
        protected abstract string GetInsertQuery();
        protected abstract string GetUpdateQuery();
        protected abstract string GetRemoveQuery();
        protected abstract void LoadParameters();


        public virtual void SaveToDatabase()
        {

        }
        public virtual void SaveToClient()
        {

        }
    }
}
