using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSRO_TELEPORT_EDITOR
{
    public sealed class COptionalTeleport : CTeleportService
    {
        internal static async Task<List<COptionalTeleport>> GetCOptionalTeleports()
        {
            List<COptionalTeleport> list = new List<COptionalTeleport>();
            using(SqlConnection conn=new SqlConnection(Globals.s_SqlConnectionString))
            {
                conn.Open();
                using(SqlCommand comm=new SqlCommand("select [Service],ID,ObjName128,ZoneName128,RegionID,Pos_X,Pos_Y,Pos_Z,WorldID,RegionIDGroup,MapPoint,LevelMin,LevelMax from _RefOptionalTeleport",conn))
                {
                    using(SqlDataReader reader=await comm.ExecuteReaderAsync())
                    {
                        if(reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                COptionalTeleport tp = new COptionalTeleport();
                                tp.m_Service = reader.GetInt32(0);
                                tp.m_ID = reader.GetInt32(1);
                                tp.m_ObjName128 = reader.GetString(2);
                                tp.m_ZoneName128 = reader.GetString(3);
                                tp.m_GenRegionID = reader.GetInt16(4);
                                tp.m_GenPos_X = reader.GetInt16(5);
                                tp.m_GenPos_Y = reader.GetInt16(6);
                                tp.m_GenPos_Z = reader.GetInt16(7);
                                tp.m_GenWorldID = reader.GetInt16(8);
                                tp.m_RegionIDGroup = reader.GetInt32(9);
                                tp.m_MapPoint = reader.GetByte(10);
                                tp.m_LevelMin = reader.GetInt16(11);
                                tp.m_LevelMax = reader.GetInt16(12);

                                list.Add(tp);

                            }
                        }
                    }
                }
            }

            return list;
        }
        public string m_ObjName128 { get; set; }
        public string m_ZoneName128 { get; set; }
        public int m_RegionIDGroup { get; set; }
        public byte m_MapPoint { get; set; }
        public short m_LevelMin { get; set; }
        public short m_LevelMax { get; set; }

        protected override void LoadParameters(SqlCommand comm)
        {
            base.LoadParameters(comm);
            comm.Parameters.AddWithValue("@ObjName128", m_ObjName128);
            comm.Parameters.AddWithValue("@ZoneName128", m_ZoneName128);
            comm.Parameters.AddWithValue("@RegionIDGroup", m_RegionIDGroup);
            comm.Parameters.AddWithValue("@MapPoint", m_MapPoint);
            comm.Parameters.AddWithValue("@LevelMin", m_LevelMin);
            comm.Parameters.AddWithValue("@LevelMax", m_LevelMax);

        }
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
