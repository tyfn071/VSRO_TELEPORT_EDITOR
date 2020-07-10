using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSRO_TELEPORT_EDITOR
{
    public struct STeleportRestrict
    {
        public STeleportRestrict(RestrictType type)
        {
            m_RestrictType = type;
            m_Data1 = 0;
            m_Data2 = 0;
        }
        public STeleportRestrict(RestrictType type,int data1)
        {
            m_RestrictType = type;
            m_Data1 = data1;
            m_Data2 = 0;
        }
        public STeleportRestrict(RestrictType type, int data1,int data2)
        {
            m_RestrictType = type;
            m_Data1 = data1;
            m_Data2 = data2;
        }

        public enum RestrictType:int
        {
            None = 0,
            LevelLimit = 1,
            BlockEnterWithJobPet = 2,
            NeedItemToEnter = 4,
            DeleteItemAfterEnter = 5,
            BlockEnterWithJobSuit = 6,
            BlockEnterThiefWithPet = 7
        }

        public RestrictType m_RestrictType;
        public int m_Data1;
        public int m_Data2;

    }
    public sealed class CTeleportLink:CTeleportBase
    {
        
        public override void SaveToDatabase()
        {

        }
        public override void SaveToClient()
        {

        }
    }
}
