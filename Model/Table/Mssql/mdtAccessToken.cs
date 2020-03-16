using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Table.Mssql
{
    public class mdtAccessToken
    {
        public string Code;
        public string IPAddress;
        public string Agent;
        public int CountUse;
        public string Status;
        public int? UpdateBy;
        public DateTime? Timestamp;
    }
}
