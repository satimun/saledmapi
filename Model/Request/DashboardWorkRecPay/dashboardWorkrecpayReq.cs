﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Request.DashboardWorkRecPay
{
    public class dashboardWorkrecpayReq
    {

        public string stdate { get; set; }
        public string enddate { get; set; }
        public string storeno { get; set; }
        public string docno { get; set; }

        public int? showdetail { get; set; }
        public int? showtotal { get; set; }

    }
}
