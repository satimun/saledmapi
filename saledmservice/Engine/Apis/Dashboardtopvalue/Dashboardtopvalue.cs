using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Request;
using Ado;
using Model;
using Core.Util;
using Model.Request.Dashboardtopvalue;
using Model.Response;

namespace saledmservice.Engine.Apis.Dashboardtopvalue
{
    public class Dashboardtopvalue : Base<DashboardtopvalueReq>
    {
        protected override void ExecuteChild(DashboardtopvalueReq dataReq, ResponseAPI dataRes)
        {


            var res = new List<Model.Response.Dashboardtopvalue.DashboardtopvalueRes>();

            var roles = Ado.Mssql.View.dashboardtopvalue.GetInstant().Search(dataReq);


            foreach (var x in roles)
            {
                var tmp = new Model.Response.Dashboardtopvalue.DashboardtopvalueRes();

                tmp.code = x.code;
                tmp.desc1 = x.desc1;
                tmp.f1 = x.f1;
                tmp.f2 = x.f2;
                tmp.f3 = x.f3;

                res.Add(tmp);

            }


            dataRes.data = res;


        }
    }
}
