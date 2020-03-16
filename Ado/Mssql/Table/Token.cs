using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Ado.Mssql.Table
{
    public class Token : Base
    {

        private static Token instant;

        public static Token GetInstant()
        {
            if (instant == null) instant = new Token();
            return instant;
        }

        private string conectStr { get; set; }

        private Token()
        {
        }

        public List<Model.Table.Mssql.mdtToken> ListActive()
        {
            string cmd = "SELECT * FROM mdtToken " +
                "WHERE ExpiryTime > GETDATE() AND Status = 'A';";
            var res = Query<Model.Table.Mssql.mdtToken>(cmd, null).ToList();
            return res;
        }

        public List<Model.Table.Mssql.mdtToken> Search(string Code, SqlTransaction transac = null)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Code", Code);

            string cmd = "SELECT * FROM mdtToken " +
                "WHERE Code=@Code;";
            var res = Query<Model.Table.Mssql.mdtToken>(cmd, param).ToList();
            return res;
        }

        public int Get(string Code, DateTime ExpiryTime, int userID = 0, SqlTransaction transac = null)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Code", Code);
            param.Add("@ExpiryTime", ExpiryTime);
            param.Add("@UpdateBy", userID);

            string cmd = $"UPDATE mdtToken SET " +
                "ExpiryTime=@ExpiryTime, " +
                "UpdateBy=@UpdateBy, " +
                "Timestamp=GETDATE() " +
                "WHERE Code=@Code;";
            var res = ExecuteNonQuery(transac, cmd, param);
            return res;
        }

        public int Delete(string Code, int userID = 0, SqlTransaction transac = null)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Code", Code);
            param.Add("@UpdateBy", userID);

            string cmd = $"UPDATE mdtToken SET " +
                "Status='C', " +
                "UpdateBy=@UpdateBy, " +
                "Timestamp=GETDATE() " +
                "WHERE Code=@Code;";
            var res = ExecuteNonQuery(transac, cmd, param);
            return res;
        }

        public int Insert(Model.Table.Mssql.mdtToken d, int userID = 0, SqlTransaction transac = null)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Code", d.Code);
            param.Add("@User_ID", d.User_ID);
            param.Add("@AccessToken_Code", d.AccessToken_Code);
            param.Add("@ExpiryTime", d.ExpiryTime);
            param.Add("@Type", d.Type);
            param.Add("@UpdateBy", userID);

            string cmd = "INSERT INTO mdtToken (Code, User_ID, AccessToken_Code, ExpiryTime, Type, Status, UpdateBy, Timestamp) " +
                "VALUES (@Code, @User_ID, @AccessToken_Code, @ExpiryTime, @Type, 'A', @UpdateBy, GETDATE());";
            var res = ExecuteNonQuery(transac, cmd, param);
            return res;
        }
    }
}
