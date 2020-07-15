using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSRO_TELEPORT_EDITOR
{
    public sealed class COptionalTeleport : CTeleportService
    {
        public string m_ObjName128 { get; set; }
        public string m_ZoneName128 { get; set; }
        public int m_RegionIDGroup { get; set; }
        public byte m_MapPoint { get; set; }
        public short m_LevelMin { get; set; }
        public short m_LevelMax { get; set; }

        protected override string GetInsertQuery()
        => "insert into _RefOptionalTeleport ([Service],[ObjName128],[ZoneName128],[RegionID],[Pos_X],[Pos_Y],[Pos_Z],[WorldID],[RegionIDGroup],[MapPoint],[LevelMin],[LevelMax],[Param1],[Param1_Desc_128],[Param2],[Param2_Desc_128],[Param3],[Param3_Desc_128])" +
               " values(@Service,@ObjName128,@ZoneName128,@GenRegionID,@GenPos_X,@GenPos_Y,@GenPos_Z,@GenWorldID,@RegionIDGroup,@MapPoint,@LevelMin,@LevelMax,-1,'xxx',-1,'xxx',-1,'xxx'); select convert(int, SCOPE_IDENTITY())";


        protected override string GetRemoveQuery()
        => "delete from _RefOptionalTeleport where ID=@ID";
        protected override string GetUpdateQuery()
        => "update _RefOptionalTeleport set [Service]=@Service,[ObjName128]=@ObjName128,[ZoneName128]=@ZoneName128,[RegionID]=@GenRegionID,[Pos_X]=@GenPos_X,[Pos_Y]=@GenPos_Y,[Pos_Z]=@GenPos_Z,[WorldID]=@GenWorldID,[RegionIDGroup]=@RegionIDGroup,[MapPoint]=@MapPoint,[LevelMin]=@LevelMin,[LevelMax]=@LevelMax" +
            " where ID=@ID";


    }
}
