using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Request.User
{
    public class UserRegisterReq
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string confpass { get; set; }
    }
}
