using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
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
        internal static async Task<List<CTeleportLink>> GetTeleportLinks()
        {
            List<CTeleportLink> list = new List<CTeleportLink>();
            using(SqlConnection conn =new SqlConnection(Globals.s_SqlConnectionString))
            {
                conn.Open();
                using(SqlCommand command=new SqlCommand("SELECT T.[Service],LTRIM(RTRIM(OT.CodeName128)) as OwnerTeleport,LTRIM(RTRIM(TT.CodeName128)) as TargetTeleport, T.Fee, T.RestrictBindMethod, T.RunTimeTeleportMethod"
                                                        +", T.CheckResult, T.Restrict1, T.Data1_1, T.Data1_2, T.Restrict2, T.Data2_1, T.Data2_2, T.Restrict3, T.Data3_1, T.Data3_2"
                                                        + ",T.Restrict4, T.Data4_1, T.Data4_2, T.Restrict5, T.Data5_1, T.Data5_2 from _RefTeleLink T inner join _RefTeleport OT on OT.ID = T.OwnerTeleport inner join _RefTeleport TT on TT.ID = T.TargetTeleport", conn))
                {
                    using(SqlDataReader reader=await command.ExecuteReaderAsync())
                    {
                        if(reader.HasRows)
                        {
                            while(reader.Read())
                            {
                                CTeleportLink link = new CTeleportLink();
                                link.m_Service = reader.GetInt32(0);
                                link.m_OwnerTeleport = reader.GetString(1);
                                link.m_TargetTeleport = reader.GetString(2);
                                link.m_Fee = reader.GetInt32(3);
                                link.m_RestrictBindMethod = reader.GetByte(4);
                                link.m_RunTimeTeleportMethod = reader.GetByte(5);
                                link.m_ChectResult = reader.GetByte(6);

                                STeleportRestrict restrict1;
                                restrict1.m_RestrictType= (STeleportRestrict.RestrictType)reader.GetInt32(7);
                                restrict1.m_Data1 = reader.GetInt32(8);
                                restrict1.m_Data2 = reader.GetInt32(9);
                                link.Restrict1 = restrict1;

                                STeleportRestrict restrict2;
                                restrict2.m_RestrictType = (STeleportRestrict.RestrictType)reader.GetInt32(10);
                                restrict2.m_Data1 = reader.GetInt32(11);
                                restrict2.m_Data2 = reader.GetInt32(12);
                                link.Restrict2 = restrict2;

                                STeleportRestrict restrict3;
                                restrict3.m_RestrictType = (STeleportRestrict.RestrictType)reader.GetInt32(13);
                                restrict3.m_Data1 = reader.GetInt32(14);
                                restrict3.m_Data2 = reader.GetInt32(15);
                                link.Restrict3 = restrict3;

                                STeleportRestrict restrict4;
                                restrict4.m_RestrictType = (STeleportRestrict.RestrictType)reader.GetInt32(16);
                                restrict4.m_Data1 = reader.GetInt32(17);
                                restrict4.m_Data2 = reader.GetInt32(18);
                                link.Restrict4 = restrict4;

                                STeleportRestrict restrict5;
                                restrict5.m_RestrictType = (STeleportRestrict.RestrictType)reader.GetInt32(19);
                                restrict5.m_Data1 = reader.GetInt32(20);
                                restrict5.m_Data2 = reader.GetInt32(21);
                                link.Restrict5 = restrict5;

                                list.Add(link);
                            }
                        }
                    }
                }
            }
            return list;
        }
        public string m_OwnerTeleport { get; set; }
        public string m_TargetTeleport { get; set; }
        public int m_Fee { get; set; }
        public byte m_RestrictBindMethod { get; set; }
        public byte m_RunTimeTeleportMethod { get; set; }
        public byte m_ChectResult { get; set; }

        public STeleportRestrict Restrict1 { get; set; }
        public STeleportRestrict Restrict2 { get; set; }
        public STeleportRestrict Restrict3 { get; set; }
        public STeleportRestrict Restrict4 { get; set; }
        public STeleportRestrict Restrict5 { get; set; }

        protected override void LoadParameters(SqlCommand comm)
        {
            base.LoadParameters(comm);
            comm.Parameters.AddWithValue("@OwnerTeleport", m_OwnerTeleport);
            comm.Parameters.AddWithValue("@TargetTeleport", m_TargetTeleport);
            comm.Parameters.AddWithValue("@Fee", m_Fee);
            comm.Parameters.AddWithValue("@RestrictBindMethod", m_RestrictBindMethod);
            comm.Parameters.AddWithValue("@RunTimeTeleportMethod", m_RunTimeTeleportMethod);
            comm.Parameters.AddWithValue("@CheckResult", m_ChectResult);

            comm.Parameters.AddWithValue("@Restrict1", (int)Restrict1.m_RestrictType);
            comm.Parameters.AddWithValue("@Data1_1", Restrict1.m_Data1);
            comm.Parameters.AddWithValue("@Data1_2", Restrict1.m_Data2);

            comm.Parameters.AddWithValue("@Restrict2", (int)Restrict2.m_RestrictType);
            comm.Parameters.AddWithValue("@Data2_1", Restrict2.m_Data1);
            comm.Parameters.AddWithValue("@Data2_2", Restrict2.m_Data2);

            comm.Parameters.AddWithValue("@Restrict3", (int)Restrict3.m_RestrictType);
            comm.Parameters.AddWithValue("@Data3_1", Restrict3.m_Data1);
            comm.Parameters.AddWithValue("@Data3_2", Restrict3.m_Data2);

            comm.Parameters.AddWithValue("@Restrict4", (int)Restrict4.m_RestrictType);
            comm.Parameters.AddWithValue("@Data4_1", Restrict4.m_Data1);
            comm.Parameters.AddWithValue("@Data4_2", Restrict4.m_Data2);

            comm.Parameters.AddWithValue("@Restrict5", (int)Restrict5.m_RestrictType);
            comm.Parameters.AddWithValue("@Data5_1", Restrict5.m_Data1);
            comm.Parameters.AddWithValue("@Data5_2", Restrict5.m_Data2);

        }

        protected override string GetInsertQuery()
       => "insert into _RefTeleLink values(@Service, (select ID from _RefTeleport where CodeName128=@OwnerTeleport),(select ID from _RefTeleport where CodeName128=@TargetTeleport),@Fee,@RestrictBindMethod,@RunTimeTeleportMethod,@CheckResult"
                       + ",@Restrict1,@Data1_1,@Data1_2," +
                          ",@Restrict2,@Data2_1,@Data2_2," +
                          ",@Restrict3,@Data3_1,@Data3_2," +
                          ",@Restrict4,@Data4_1,@Data4_2," +
                          ",@Restrict5,@Data5_1,@Data5_2)";
        protected override string GetRemoveQuery()
        => "delete from _RefTeleLink where OwnerTeleport=(select ID from _RefTeleport where CodeName128=@OwnerTeleport) and TargetTeleport=(select ID from _RefTeleport where CodeName128=@TargetTeleport)";
        protected override string GetUpdateQuery()
        => "update _RefTeleLink set Service=@Service," +
                        "Fee=@Fee," +
                        "Restrict1=@Restrict1,Data1_1=@Data1_1,Data1_2=@Data1_2," +
                        "Restrict2=@Restrict2,Data2_1=@Data2_1,Data2_2=@Data2_2," +
                        "Restrict3=@Restrict3,Data3_1=@Data3_1,Data3_2=@Data3_2," +
                        "Restrict4=@Restrict4,Data4_1=@Data4_1,Data4_2=@Data4_2," +
                        "Restrict5=@Restrict5,Data5_1=@Data5_1,Data5_2=@Data5_2 where OwnerTeleport=(select ID from _RefTeleport where CodeName128=@OwnerTeleport) and TargetTeleport=(select ID from _RefTeleport where CodeName128=@TargetTeleport)";



    }
}
