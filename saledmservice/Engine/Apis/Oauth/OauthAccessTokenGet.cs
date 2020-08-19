using Model.Request;
using Model.Response;
using Model.Response.Oauth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using saledmservice.Constant;

namespace saledmservice.Engine.Apis.Oauth
{
    public class OauthAccessTokenGet : Base<dynamic>
    {
        public OauthAccessTokenGet()
        {
            AllowAnonymous = true;
            RecaptchaRequire = true;
        }

        protected override void ExecuteChild(dynamic dataReq, ResponseAPI dataRes)
        {

            var res = Ado.Mssql.Table.AccessToken.GetInstant().Search(AccessToken);

            if (res.Count == 1)
            {
                Ado.Mssql.Table.AccessToken.GetInstant().Update(this.AccessToken);
            }
            else
            {
                this.AccessToken = Core.Util.EncryptUtil.NewID(this.IPAddress);
                Ado.Mssql.Table.AccessToken.GetInstant().Insert(this.AccessToken, this.IPAddress, this.UserAgent);
            }

            dataRes.data = new OauthAccessTokenGetRes() { accessToken = this.AccessToken };

            StaticValue.GetInstant().AccessKey();

        }
    }
}
