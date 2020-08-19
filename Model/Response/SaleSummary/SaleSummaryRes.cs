using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Response.SaleSummary
{
    public class SaleSummary
    {
        public DateTime? saledate { get; set; }
        public float po { get; set; }
        public float pay { get; set; }
        public float remain { get; set; }
      


    }
}
