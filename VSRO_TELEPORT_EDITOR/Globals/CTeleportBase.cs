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
        public int m_Service { get; set; }
        public int m_ID { get; set; }
        public short m_GenRegionID { get; set; }
        public short m_GenPos_X { get; set; }
        public short m_GenPos_Y { get; set; }
        public short m_GenPos_Z { get; set; }
        public short m_GenWorldID { get; set; }



        public abstract void SaveToDatabase();
        public abstract void SaveToClient();
    }
}
