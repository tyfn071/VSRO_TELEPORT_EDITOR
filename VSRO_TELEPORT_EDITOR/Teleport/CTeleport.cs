using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Data.Async;

namespace VSRO_TELEPORT_EDITOR
{
    public sealed class CTeleport : CTeleportService
    {
        internal static async Task<HashSet<string>> GetTeleportCodeNames()
        {
            HashSet<string> codenames = new HashSet<string>();
            using (SqlConnection conn = new SqlConnection(Globals.s_SqlConnectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("select LTRIM(RTRIM(CodeName128)) from _RefTeleport order by ID", conn))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {                            
                            while (reader.Read())
                                codenames.Add(reader.GetString(0));
                        }
                    }
                }               
            }
            return codenames;
        }
        public CTeleport():base()
        {

        }
        public CTeleport(EditStatus status):base(status)
        {

        }
        public CTeleport(string codeName):base()
        {
            using(SqlConnection conn=new SqlConnection(Globals.s_SqlConnectionString))
            {
                conn.Open();
                using(SqlCommand command=new SqlCommand("select * from _RefTeleport where CodeName128=@codename",conn))
                {
                    command.Parameters.AddWithValue("@codename", codeName);
                    using(SqlDataReader reader=command.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            reader.Read();

                            m_Service = reader.GetInt32(0);
                            m_ID = reader.GetInt32(1);
                            m_CodeName128 = reader.GetString(2).Trim();
                            m_AssocRefObjCodeName = reader.GetString(3);
                            m_ZoneName128 = reader.GetString(5);
                            m_GenRegionID = reader.GetInt16(6);
                            m_GenPos_X = reader.GetInt16(7);
                            m_GenPos_Y = reader.GetInt16(8);
                            m_GenPos_Z = reader.GetInt16(9);
                            m_GenAreaRadius = reader.GetInt16(10);                            
                            m_CanBeResurrectPos = reader.GetByte(11) == 1;
                            m_CanBeGotoResurrectPos = reader.GetByte(12) == 1;
                            m_GenWorldID = reader.GetInt16(13);
                            m_BindInteractionMask = reader.GetByte(14);
                            m_FixedService = reader.GetByte(15);
                        }
                    }
                }
            }
        }

        internal static string s_ClientFileName = "teleportdata.txt";
        public string m_CodeName128 { get; set; }
        public string m_AssocRefObjCodeName { get; set; }
        public string m_ZoneName128 { get; set; }
        public short m_GenAreaRadius { get; set; }
        public bool m_CanBeResurrectPos { get; set; }
        public bool m_CanBeGotoResurrectPos { get; set; }
        public byte m_BindInteractionMask { get; set; }
        public byte m_FixedService { get; set; }

        protected override void LoadParameters(SqlCommand comm)
        {
            base.LoadParameters(comm);
            comm.Parameters.AddWithValue("@CodeName128",  m_CodeName128);
            comm.Parameters.AddWithValue("@AssocRefObjCodeName128",  m_AssocRefObjCodeName);
            comm.Parameters.AddWithValue("@ZoneName128", m_ZoneName128);
            comm.Parameters.AddWithValue("@GenAreaRadius", m_GenAreaRadius);
            comm.Parameters.AddWithValue("@CanBeResurrectPos",  m_CanBeResurrectPos ? 1 : 0);
            comm.Parameters.AddWithValue("@CanGotoResurrectPos", m_CanBeGotoResurrectPos ? 1 : 0);
            comm.Parameters.AddWithValue("@BindInteractionMask",  m_BindInteractionMask);
            comm.Parameters.AddWithValue("@FixedService",  m_FixedService);
        }

        protected override string GetInsertQuery()
        => "INSERT INTO _RefTeleport ([Service], [CodeName128], [AssocRefObjCodeName128],[AssocRefObjID],[ZoneName128],[GenRegionID],[GenPos_X],[GenPos_Y],[GenPos_Z],[GenAreaRadius],[CanBeResurrectPos]," +
                "[CanGotoResurrectPos],[GenWorldID],[BindInteractionMask],[FixedService]) values(@Service, @CodeName128, @AssocRefObjCodeName128," +
                "(select case when @AssocRefObjCodeName128='xxx' then 0 else (select ID from _RefObjCommon where CodeName128=@AssocRefObjCodeName128) end)," +
                "@ZoneName128,@GenRegionID,@GenPos_X,@GenPos_Y,@GenPos_Z,@GenAreaRadius,@CanBeResurrectPos,@CanGotoResurrectPos,@GenWorldID,@BindInteractionMask,@FixedService);select convert(int,SCOPE_IDENTITY())";
        protected override string GetUpdateQuery()
        => "UPDATE[dbo].[_RefTeleport] SET[Service] = @Service,[CodeName128] =@CodeName128,[AssocRefObjCodeName128] =@AssocRefObjCodeName128," +
                "[AssocRefObjID] = (select case when @AssocRefObjCodeName128='xxx' then 0 else (select ID from _RefObjCommon where CodeName128=@AssocRefObjCodeName128) end)" +
                ",[ZoneName128] = @ZoneName128,[GenRegionID] = @GenRegionID,[GenPos_X] = @GenPos_X,[GenPos_Y] = @GenPos_Y,[GenPos_Z] = @GenPos_Z,[GenAreaRadius] = @GenAreaRadius" +
                ",[CanBeResurrectPos] = @CanBeResurrectPos,[CanGotoResurrectPos] = @CanGotoResurrectPos,[GenWorldID] = @GenWorldID,[BindInteractionMask] =@BindInteractionMask,[FixedService] =@FixedService where ID=@ID";
        protected override string GetRemoveQuery()
        => "delete from _RefTeleport where ID=@ID";

        internal static bool IsExistsTeleport(string codeName)
        {
            bool s = false;
            using(SqlConnection conn=new SqlConnection(Globals.s_SqlConnectionString))
            {
                conn.Open();
                using(SqlCommand command=new SqlCommand("select ID from _RefTeleport where CodeName128=@codename",conn))
                {
                    command.Parameters.AddWithValue("@codename", codeName);
                    using(SqlDataReader reader=command.ExecuteReader())
                    {
                        s = reader.HasRows;
                    }
                }
            }

            return s;
        }

        public override void SaveToDatabase()
        {
            if(m_Status==EditStatus.Removed)
            {
                using(SqlConnection conn=new SqlConnection(Globals.s_SqlConnectionString))
                {
                    conn.Open();
                    using(SqlCommand command=new SqlCommand("delete from _RefTeleLink where OwnerTeleport=@ID or TargetTeleport=@ID",conn))
                    {
                        command.Parameters.AddWithValue("@ID", m_ID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            base.SaveToDatabase();


        }
    }
}
