using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Request.Dashboardtopvalue
{
    public class DashboardtopvalueReq
    {

        public string stdate { get; set; }
        public string enddate { get; set; }
        public string storeno { get; set; }
        public string docno { get; set; }

        public string worktype { get; set; }

        public string topvalue { get; set; }


    }
}
