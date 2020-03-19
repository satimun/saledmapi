using Core.Util;
using Model.Request.User;
using Model.Response;
using Model.Response.User;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using kkfmisservice.Constant;

namespace kkfmisservice.Engine.Apis.User
{
    public class UserRegister : Base<UserRegisterReq>
    {
        private bool Issucces = true;
        private string msg = "SUCCESS";

        public UserRegister()
        {
            AllowAnonymous = true;
            RecaptchaRequire = true;
        }

        protected override void ExecuteChild(UserRegisterReq dataReq, ResponseAPI dataRes)
        {
   

            var emp = Ado.Mssql.Table.vTEMPLOY.GetInstant().Search(new Model.Table.Mssql.Employee()
            {
                Code = dataReq.username.Trim()
            }).FirstOrDefault();




            if (emp == null)
            {
                throw new Exception($"Not Found Username : {dataReq.username}.");
            }


            if (dataReq.password.Trim() != dataReq.confpass.Trim()) throw new Exception("Password and Confirm Password not match.");

            if (Ado.Mssql.Table.User.GetInstant().Search(new Model.Table.Mssql.mdsUser()
            {
                Email = dataReq.email.Trim()
            }).Count != 0)
            {
                throw new Exception($"Email '{dataReq.email}' is already in use.");
            }

            if (Ado.Mssql.Table.User.GetInstant().Search(new Model.Table.Mssql.mdsUser()
            {
                Username = dataReq.username.Trim()
            }).Count != 0)
            {
                throw new Exception($"Username '{dataReq.username}' is already in use.");
            }

            var pass = Core.Util.EncryptUtil.Hash(dataReq.password.Trim());
            var softpass = Core.Util.EncryptUtil.NewID(dataReq.username + DateTime.Now.ToString());

            var conn = Ado.Mssql.Base.OpenConnection();
            conn.Open();
            SqlTransaction transac = conn.BeginTransaction();
            try
            {
                var d = new Model.Table.Mssql.mdsUser()
                {
                    ID = emp.User_ID,
                    Code = Core.Util.EncryptUtil.NewID(dataReq.email).MD5(),
                    Email = dataReq.email.Trim(),
                    Username = dataReq.username.Trim(),
                    Password = Core.Util.EncryptUtil.Hash(pass + softpass),      
                    SoftPassword = softpass,
                    Description = emp.Description,
                    Type = true,
                    Status = "N"
                };

                Ado.Mssql.Table.User.GetInstant().Insert(d, UserID, transac);

                Ado.Mssql.Table.UserConfig.GetInstant().Insert(new Model.Table.Mssql.mdsUserConfig()
                {
                    User_ID = emp.User_ID,
                    EmailLogin = true,
                    LoginTime = 480,
                    TwoFactorEnable = false
                }, UserID, transac);



                dataRes.data = new UserRegisterRes() { email = dataReq.email.Trim() };
            }
            catch (Exception ex)
            {
                Issucces = false;
                transac.Rollback();
                msg = ex.Message;
            }
            finally
            {
                if (Issucces) { transac.Commit(); }
                conn.Close();
            }

            if (!Issucces) { throw new Exception(msg); }

            StaticValue.GetInstant().UserData();
        }
    }
}
