using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Ado.Mssql.Table
{
    public class AccessToken : Base
    {
        private static AccessToken instant;

        public static AccessToken GetInstant()
        {
            if (instant == null) instant = new AccessToken();
            return instant;
        }

        private string conectStr { get; set; }

        private AccessToken()
        {
        }

        public List<Model.Table.Mssql.mdtAccessToken> ListActive()
        {
            string cmd = "SELECT * FROM mdtAccessToken " +
                "WHERE Status='A';";
            var res = Query<Model.Table.Mssql.mdtAccessToken>(cmd, null).ToList();
            return res;
        }

        public List<Model.Table.Mssql.mdtAccessToken> Search(string Code, SqlTransaction transac = null)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Code", Code);

            string cmd = "SELECT * FROM mdtAccessToken " +
                "WHERE Code=@Code;";
            var res = Query<Model.Table.Mssql.mdtAccessToken>(cmd, param).ToList();
            return res;
        }

        public int Update(string Code, SqlTransaction transac = null)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Code", Code);

            string cmd = $"UPDATE mdtAccessToken SET " +
                "CountUse=CountUse+1 " +
                "WHERE Code=@Code;";
            var res = ExecuteNonQuery(transac, cmd, param);
            return res;
        }

        public int Insert(string Code, string IPAddress, string Agent, SqlTransaction transac = null)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Code", Code);
            param.Add("@IPAddress", IPAddress);
            param.Add("@Agent", Agent);

            string cmd = "INSERT INTO mdtAccessToken (Code, IPAddress, Agent, CountUse, Status, UpdateBy, Timestamp) " +
                "VALUES (@Code, @IPAddress, @Agent, 1, 'A', 0, GETDATE());";
            var res = ExecuteNonQuery(transac, cmd, param);
            return res;
        }
    }
}
