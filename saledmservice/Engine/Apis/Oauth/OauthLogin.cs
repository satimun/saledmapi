using Core.Util;

using Model.Request.Oauth;
using Model.Response;
using Model.Response.Oauth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using saledmservice.Constant;
using Google.Authenticator;

namespace saledmservice.Engine.Apis.Oauth
{
    public class OauthLogin : Base<OauthLoginReq>
    {
        public OauthLogin()
        {
            AllowAnonymous = true;
            RecaptchaRequire = true;
        }

        protected override void ExecuteChild(OauthLoginReq dataReq, ResponseAPI dataRes)
        {
            var res = new OauthLoginRes();

            var user = Ado.Mssql.Table.User.GetInstant().Search(new Model.Table.Mssql.zUSER() { USER_ID = dataReq.username.Trim() }).FirstOrDefault();
            if (user == null) { throw new Exception("Username Not Found."); }
            if (user.SYSTEMCOD != "") { 


                throw new Exception("User "+ dataReq.username.Trim() + " ถูกระงับการเข้าใช้งานแล้ว !!"+
                                    "("+ user.SYSTEMDESC + ")"); 
            
            
            }

            // var pass = Core.Util.EncryptUtil.Hash(dataReq.PASS_WORD.Trim());





            var pass = dataReq.password.Trim();

            var config = Ado.Mssql.Table.UserConfig.GetInstant().Search(Int32.Parse(user.USER_ID));
      

            if (user.zPASSWORD == pass)
            {

                res.token    = pass.NewID();
                res.USER_ID  = user.USER_ID;

                Ado.Mssql.Table.Token.GetInstant().Insert(new Model.Table.Mssql.mdtToken()
                {
                    User_ID = Int32.Parse(user.USER_ID),
                    AccessToken_Code = this.AccessToken,
                    Code = res.token,
                    Status = "A",
                    Type = "L",
                    ExpiryTime = DateTime.Now.AddMinutes(config.Select(x => x.LoginTime).FirstOrDefault())

                }, Int32.Parse(user.USER_ID));

             

                dataRes.data = res;
                StaticValue.GetInstant().TokenKey();
            }
            else
            {
                throw new Exception("Username or Password was incorrect");
            }

        }
    }
}
