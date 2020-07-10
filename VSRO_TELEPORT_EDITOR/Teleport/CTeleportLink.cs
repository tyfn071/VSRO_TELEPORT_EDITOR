using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
            [Display(Name ="None")]
            None = 0,
            [Display(Name = "Level Limit")]
            LevelLimit = 1,
            [Display(Name = "Block Enter With Job Pet")]
            BlockEnterWithJobPet = 2,
            [Display(Name = "Need Item to Enter")]
            NeedItemToEnter = 4,
            [Display(Name = "Delete Item After Enter")]
            DeleteItemAfterEnter = 5,
            [Display(Name = "Block Enter With Job Suit")]
            BlockEnterWithJobSuit = 6,
            [Display(Name = "Block Enter to Thief Trade Pet")]
            BlockEnterThiefWithPet = 7
        }

        public RestrictType m_RestrictType;
        public int m_Data1;
        public int m_Data2;

    }
    public sealed class CTeleportLink:CTeleportBase
    {
        public int m_OwnerTeleport { get; set; }
        public int m_TargetTeleport { get; set; }
        public int m_Fee { get; set; }
        public byte m_RestrictBindMethod { get; set; }
        public byte m_RunTimeTeleportMethod { get; set; }
        public byte m_ChectResult { get; set; }

        public STeleportRestrict Restrict1 { get; set; }
        public STeleportRestrict Restrict2 { get; set; }
        public STeleportRestrict Restrict3 { get; set; }
        public STeleportRestrict Restrict4 { get; set; }
        public STeleportRestrict Restrict5 { get; set; }

        public override void SaveToDatabase()
        {

        }
        public override void SaveToClient()
        {

        }
    }
}
