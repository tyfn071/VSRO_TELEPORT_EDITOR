using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSRO_TELEPORT_EDITOR
{
    public enum EditStatus:byte
    {
        Notr,
        New,
        Edited,
        Removed
    }
    public interface ITeleport
    {
        void SaveToDatabase();
        void SaveToClient();
    }
}
