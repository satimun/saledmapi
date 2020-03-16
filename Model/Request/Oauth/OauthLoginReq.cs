using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Request.Oauth
{
    public class OauthLoginReq
    {
        public string username { get; set; }
        public string password { get; set; }
        public string twofactor { get; set; }
    }
}
