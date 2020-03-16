using Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Table.Mssql
{
    public class mdsUser : SetupModel
    {
        public int? ID;
        public string Email;
        public string Username;
        public string Password;
        public string SoftPassword;
        public bool? Type;
    }
}
