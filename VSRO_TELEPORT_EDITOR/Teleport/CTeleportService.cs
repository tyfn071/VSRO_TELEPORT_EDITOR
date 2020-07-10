using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSRO_TELEPORT_EDITOR
{
    public class CTeleportService:CTeleportBase
    {
        public int m_Service { get; set; }
        public int m_ID { get; set; }
        public short m_GenRegionID { get; set; }
        public short m_GenPos_X { get; set; }
        public short m_GenPos_Y { get; set; }
        public short m_GenPos_Z { get; set; }
        public short m_GenWorldID { get; set; }
    }
}
