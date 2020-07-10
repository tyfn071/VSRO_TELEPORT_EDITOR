using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public virtual void SaveToDatabase()
        {

        }
        public virtual void SaveToClient()
        {

        }
    }
}
