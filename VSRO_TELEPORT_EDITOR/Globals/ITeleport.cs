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
        /// <summary>
        /// Save changes to database
        /// </summary>
        void SaveToDatabase();
        /// <summary>
        /// Save changes to Media.pk2 file
        /// </summary>
        void SaveToClient();
    }
}
