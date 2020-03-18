using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Request.User
{
    public class UserVerifyReq
    {
        public string email { get; set; }
        public string code { get; set; }
    }
}
