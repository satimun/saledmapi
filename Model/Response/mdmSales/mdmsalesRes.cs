using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Response.mdmSales
{

    public class mdmsalesRes
    {
        public int? ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Symbol { get; set; }
        public string Status { get; set; }
        public string UpdateBy { get; set; }
        public long? Timestamp { get; set; }
    }
}
