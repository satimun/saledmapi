using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Request.Dashboardwaitcreatebill
{
    public class dashboardwaitcreatebillReq
    {
        public string CODE { get; set; }
        public string stdate { get; set; }
        public string enddate { get; set; }
        public string storeno { get; set; }
        public string docno { get; set; }

        public string cuscod { get; set; }

        public int? showdetail { get; set; }
        public int? showtotal { get; set; }
    }
}
