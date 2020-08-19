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
    public class Dashboardwaitcreatebill : Base<dashboardwaitcreatebillReq>
    {
        protected override void ExecuteChild(dashboardwaitcreatebillReq dataReq, ResponseAPI dataRes)
        {


            var res = new List<Model.Response.Dashboardwaitcreatebill.dashboardwaitcreatebillRes>();

            var roles = Ado.Mssql.View.dashboardwaitcreatebill.GetInstant().Search(dataReq);


            foreach (var x in roles)
            {
                var tmp = new Model.Response.Dashboardwaitcreatebill.dashboardwaitcreatebillRes();

                tmp.code = x.code;
                tmp.h1 = x.h1;
                tmp.h2 = x.h2;
                tmp.h3 = x.h3;
                tmp.h4 = x.h4;

                tmp.h5 = x.h5;
                tmp.h6 = x.h6;
                tmp.h7 = x.h7;
                tmp.h8 = x.h8;
                tmp.h9 = x.h9;
                tmp.h10 = x.h10;
                tmp.h11 = x.h11;


                res.Add(tmp);

            }


            dataRes.data = res;


        }
    }
}
