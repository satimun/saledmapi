using Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Table.Mssql
{
    public class mdtToken
    {
        public string Code;
        public int User_ID;
        public string AccessToken_Code;
        public DateTime ExpiryTime;
        public string Type;
        public string Status;
        public int? UpdateBy;
        public DateTime? Timestamp;

    }
}
