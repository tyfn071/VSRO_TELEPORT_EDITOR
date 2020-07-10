using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSRO_TELEPORT_EDITOR
{
    public sealed class CTeleport:CTeleportBase
    {
        public string m_CodeName128 { get; set; }
        public string m_AssocRefObjCodeName { get; set; }
        public short m_GenAreaRadius { get; set; }
        public bool m_CanBeResurrectPos { get; set; }
        public bool m_CanBeGotoResurrectPos { get; set; }
        public byte m_BindInteractionMask { get; set; }
        public byte m_FixedService { get; set; }

        public override void SaveToDatabase()
        {
            throw new NotImplementedException();
        }
        public override void SaveToClient()
        {
            throw new NotImplementedException();
        }
    }
}
