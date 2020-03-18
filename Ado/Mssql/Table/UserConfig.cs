using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Ado.Mssql.Table
{
    public class UserConfig : Base
    {
        private static UserConfig instant;

        public static UserConfig GetInstant()
        {
            if (instant == null) instant = new UserConfig();
            return instant;
        }

        private string conectStr { get; set; }

        private UserConfig()
        {
        }

        public List<Model.Table.Mssql.mdsUserConfig> Search(int? userID, SqlTransaction transac = null)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@User_ID", userID);

            string cmd = "SELECT * FROM mdsUserConfig " +
                "WHERE (@User_ID IS NULL OR User_ID=@User_ID) " +
                ";";
            var res = Query<Model.Table.Mssql.mdsUserConfig>(cmd, param).ToList();
            return res;
        }

        public int Update(Model.Table.Mssql.mdsUserConfig d, int userID = 0, SqlTransaction transac = null)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@User_ID", d.User_ID);
            param.Add("@TwoFactorEnable", d.TwoFactorEnable);
            param.Add("@EmailLogin", d.EmailLogin);
            param.Add("@LoginTime", d.LoginTime);
            param.Add("@UpdateBy", userID);

            string cmd = $"UPDATE mdsUserConfig SET " +
                "TwoFactorEnable=@TwoFactorEnable, " +
                "EmailLogin=@EmailLogin, " +
                "LoginTime=@LoginTime, " +
                "UpdateBy=@UpdateBy, " +
                "Timestamp=GETDATE() " +
                "WHERE User_ID=@User_ID;";
            var res = ExecuteNonQuery(transac, cmd, param);
            return res;
        }

        public int Insert(Model.Table.Mssql.mdsUserConfig d, int userID, SqlTransaction transac = null)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@User_ID", d.User_ID);
      
            param.Add("@EmailLogin", d.EmailLogin);
            param.Add("@LoginTime", d.LoginTime);
            param.Add("@UpdateBy", userID);

            string cmd = "INSERT INTO mdsUserConfig (User_ID, EmailLogin, LoginTime, UpdateBy, Timestamp) " +
                "VALUES (@User_ID, @EmailLogin, @LoginTime, @UpdateBy, GETDATE());";
            var res = ExecuteScalar<int>(transac, cmd, param);
            return res;
        }
    }
}
