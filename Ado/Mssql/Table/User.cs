using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Ado.Mssql.Table
{
    public class User : Base
    {
        private static User instant;

        public static User GetInstant()
        {
            if (instant == null) instant = new User();
            return instant;
        }

        private string conectStr { get; set; }

        private User()
        {
        }

        public List<Model.Table.Mssql.mdsUser> Search(Model.Table.Mssql.mdsUser d, SqlTransaction transac = null)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", d.ID);
            param.Add("@Code", d.Code);
            param.Add("@Description", d.Description);
            param.Add("@Type", d.Type);
            param.Add("@Username", d.Username);
            param.Add("@Email", d.Email);
            param.Add("@Status", d.Status);

            string cmd = "SELECT * FROM mdsUser " +
                "WHERE (@ID IS NULL OR ID=@ID) " +
                "AND (@Code IS NULL OR Code=@Code) " +
                "AND (@Description IS NULL OR Description=@Description) " +
                "AND (@Type IS NULL OR Type=@Type) " +
                "AND (@Username IS NULL OR Username=@Username) " +
                "AND (@Email IS NULL OR Email=@Email) " +
                "AND (@Status IS NULL OR Status=@Status) " +
                ";";
            var res = Query<Model.Table.Mssql.mdsUser>(cmd, param).ToList();
            return res;
        }

        public int Update(Model.Table.Mssql.mdsUser d, int userID = 0, SqlTransaction transac = null)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Code", d.Code);
            param.Add("@Description", d.Description);
            param.Add("@Type", d.Type);
            param.Add("@Username", d.Username);
            param.Add("@Email", d.Email);
            param.Add("@Password", d.Password);
            param.Add("@SoftPassword", d.SoftPassword);
            param.Add("@Status", d.Status);
            param.Add("@UpdateBy", userID);
            param.Add("@ID", d.ID);

            string cmd = $"UPDATE mdsUser SET " +
                "Code=@Code, " +
                "Description=@Description, " +
                "Type=@Type, " +
                "Username=@Username, " +
                "Email=@Email, " +
                "Password=@Password, " +
                "SoftPassword=@SoftPassword, " +
                "Status=@Status, " +
                "UpdateBy=@UpdateBy, " +
                "Timestamp=GETDATE() " +
                "WHERE ID=@ID;";
            var res = ExecuteNonQuery(transac, cmd, param);
            return res;
        }

        public int UpdateStatus(int ID, string status, int userID = 0, SqlTransaction transac = null)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Status", status);
            param.Add("@UpdateBy", userID);
            param.Add("@ID", ID);

            string cmd = $"UPDATE mdsUser SET " +
                "Status=@Status, " +
                "UpdateBy=@UpdateBy, " +
                "Timestamp=GETDATE() " +
                "WHERE ID=@ID;";
            var res = ExecuteNonQuery(transac, cmd, param);
            return res;
        }

        public int Insert(Model.Table.Mssql.mdsUser d, int userID = 0, SqlTransaction transac = null)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", d.ID);
            param.Add("@Code", d.Code);
            param.Add("@Description", d.Description);
            param.Add("@Type", d.Type);  // 1 = staff, 0 = customer
            param.Add("@Username", d.Username);
            param.Add("@Email", d.Email);
            param.Add("@Password", d.Password);
            param.Add("@SoftPassword", d.SoftPassword);
            param.Add("@Status", d.Status);
            param.Add("@UpdateBy", userID);

            string cmd = "INSERT INTO mdsUser (ID, Code, Description, Type, Username, Email, Password, SoftPassword, Status, UpdateBy, Timestamp) " +
                "VALUES (@ID, @Code, @Description, @Type, @Username, @Email, @Password, @SoftPassword, @Status, @UpdateBy, GETDATE());";
            var res = ExecuteNonQuery(transac, cmd, param);
            return res;
        }
    }
}
