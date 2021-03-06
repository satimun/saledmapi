﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Response;
using saledmservice.Constant;
using Model.Request;




namespace saledmservice.Engine.Apis.Oauth
{
    public class OauthLogout : Base<dynamic>
    {
        public OauthLogout()
        {
            //AllowAnonymous = true;
        }

        protected override void ExecuteChild(dynamic dataReq, ResponseAPI dataRes)
        {
            Ado.Mssql.Table.Token.GetInstant().Delete(this.Token, UserID);

            StaticValue.GetInstant().TokenKey();
        }
    }
}
