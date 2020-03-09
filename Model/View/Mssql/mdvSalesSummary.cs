using System;
using System.Collections.Generic;
using System.Text;

namespace Model.View.Mssql
{
    public class mdvSalesSummary
    {
        public int? ayr;
        public string atsale;
        public decimal target_value;        
        public decimal totsale_value;
        public decimal diff_value;
        public decimal percent_diff;
    }
}
