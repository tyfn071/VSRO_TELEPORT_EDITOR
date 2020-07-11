using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSRO_TELEPORT_EDITOR
{
    public sealed class CTeleport:CTeleportService
    {
        internal static string s_ClientFileName = "teleportdata.txt";
        public string m_CodeName128 { get; set; }
        public string m_AssocRefObjCodeName { get; set; }
        public short m_GenAreaRadius { get; set; }
        public bool m_CanBeResurrectPos { get; set; }
        public bool m_CanBeGotoResurrectPos { get; set; }
        public byte m_BindInteractionMask { get; set; }
        public byte m_FixedService { get; set; }

        protected override string GetInsertQuery()
        => "INSERT INTO _RefTeleport ([Service], [CodeName128], [AssocRefObjCodeName128],[AssocRefObjID],[ZoneName128],[GenRegionID],[GenPos_X],[GenPos_Y],[GenPos_Z],[GenAreaRadius],[CanBeResurrectPos]," +
                "[CanGotoResurrectPos],[GenWorldID],[BindInteractionMask],[FixedService]) values(@Service, @CodeName128, @AssocRefObjCodeName128," +
                "(select case when @AssocRefObjCodeName128='xxx' then 0 else (select ID from _RefObjCommon where CodeName128=@AssocRefObjCodeName128) end)," +
                "@ZoneName128,@GenRegionID,@GenPos_X,@GenPos_Y,@GenPos_Z,@GenAreaRadius,@CanBeResurrectPos,@CanGotoResurrectPos,@GenWorldID,@BindInteractionMask,@FixedService);select convert(int,SCOPE_IDENTITY())";
    }
}
