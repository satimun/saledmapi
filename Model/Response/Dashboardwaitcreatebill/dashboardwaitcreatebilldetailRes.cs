using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Response.Dashboardwaitcreatebill
{
    public class dashboardwaitcreatebilldetailRes
    {

        public string cuscode { get; set; }

        public string cusname { get; set; }

        public string sendround { get; set; }
        public string invno { get; set; }
        public DateTime? startpay_time { get; set; }
        public DateTime? endpay_time { get; set; }

        public int hh { get; set; }
        public int nn { get; set; }


        public DateTime? create_time { get; set; }




        public int hh2 { get; set; }
        public int nn2 { get; set; }

        public float time1 { get; set; }
        public float time2 { get; set; }
    }
}
