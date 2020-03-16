using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Table.Mssql
{
    public class mdsUserConfig
    {
        public int? User_ID;
        public bool TwoFactorEnable;
        public int LoginTime;
        public bool EmailLogin;
        public int? UpdateBy;
        public DateTime? Timestamp;
    }
}
