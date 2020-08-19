using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Request;
using Ado;
using Model;
using Core.Util;
using Model.Request.Dashboardwaitcreatebill;
using Model.Response;

namespace saledmservice.Engine.Apis.Dashboardwaitcreatebill
{
    public class DashboardwaitcreatebillDetail : Base<dashboardwaitcreatebillReq>
    {
        protected override void ExecuteChild(dashboardwaitcreatebillReq dataReq, ResponseAPI dataRes)
        {


            var res = new List<Model.Response.Dashboardwaitcreatebill.dashboardwaitcreatebilldetailRes>();

            var roles = Ado.Mssql.View.dashboardwaitcreatebilldetail.GetInstant().Search(dataReq);


            foreach (var x in roles)
            {
                var tmp = new Model.Response.Dashboardwaitcreatebill.dashboardwaitcreatebilldetailRes();

                tmp.cuscode = x.cuscode;
                tmp.cusname = x.cusname;
                tmp.sendround = x.sendround;
                tmp.invno = x.invno;
                tmp.startpay_time = x.startpay_time;

                tmp.endpay_time = x.endpay_time;
                tmp.hh = x.hh;
                tmp.nn = x.nn;
                tmp.create_time = x.create_time;
                tmp.hh2 = x.hh2;
                tmp.nn2 = x.nn2;
                tmp.time1 = x.time1;
                tmp.time2 = x.time2;

                res.Add(tmp);

            }


            dataRes.data = res;


        }
    }
}
