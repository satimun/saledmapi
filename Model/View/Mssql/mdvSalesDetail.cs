﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model.View.Mssql
{
    public class mdvSalesDetail
    {
        public int? yr;
        public string tsale;
        public string month_code;
        public decimal target_value;
        public decimal totpi_value;
        public decimal totsale_value;
        public decimal diff_value;
        public decimal percent_diff;
        public decimal cum_target_value;
        public decimal cum_sale_value;
        public decimal cum_diff_value;
        public decimal cum_percent_diff;
    }
}
