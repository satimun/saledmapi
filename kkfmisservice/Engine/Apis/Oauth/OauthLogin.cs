﻿using Core.Util;

using Model.Request.Oauth;
using Model.Response;
using Model.Response.Oauth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kkfmisservice.Constant;
using Google.Authenticator;

namespace kkfmisservice.Engine.Apis.Oauth
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

            var user = Ado.Mssql.Table.User.GetInstant().Search(new Model.Table.Mssql.mdsUser() { Username = dataReq.username.Trim() }).FirstOrDefault();
            if (user == null) { throw new Exception("Username Not Found."); }
            if (user.Status != "A") { throw new Exception("Username is not Confirm."); }

            var pass = Core.Util.EncryptUtil.Hash(dataReq.password.Trim());

            var config = Ado.Mssql.Table.UserConfig.GetInstant().Search(user.ID);
      

            if (user.Password == Core.Util.EncryptUtil.Hash(pass + user.SoftPassword))
            {

                res.token = pass.NewID();
                res.username = user.Username;

                Ado.Mssql.Table.Token.GetInstant().Insert(new Model.Table.Mssql.mdtToken()
                {
                    User_ID = user.ID.Value,
                    AccessToken_Code = this.AccessToken,
                    Code = res.token,
                    Status = "A",
                    Type = "L",
                    ExpiryTime = DateTime.Now.AddMinutes(config.Select(x => x.LoginTime).FirstOrDefault())
                }, user.ID.Value);

             

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
