using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Response.mdmSales
{
    public class mdmSalesSearchDetailRes
    {
        public string month_code { get; set; }
        public decimal target_value { get; set; }
        public decimal totpi_value { get; set; }
        public decimal totsale_value { get; set; }
        public decimal diff_value { get; set; }
        public decimal percent_diff { get; set; }
        public decimal cum_target_value { get; set; }
        public decimal cum_sale_value { get; set; }
        public decimal cum_diff_value { get; set; }
        public decimal cum_percent_diff { get; set; }
    }
}
