using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Request;
using Ado;
using Model;
using Core.Util;
using Model.Request.SaleSummary;
using Model.Response;

namespace saledmservice.Engine.Apis.SaleSummary
{
    public class SaleSummary : Base<SaleSummaryReq>
    {
        protected override void ExecuteChild(SaleSummaryReq dataReq, ResponseAPI dataRes)
        {


            var res = new List<Model.Response.SaleSummary.SaleSummary>();

            var roles = Ado.Mssql.View.SaleSummary.GetInstant().Search(dataReq);


            foreach (var x in roles)
            {
                var tmp = new Model.Response.SaleSummary.SaleSummary();

                tmp.saledate = x.saledate;
                tmp.po = x.po;
                tmp.pay = x.pay;
                tmp.remain = x.remain;




                res.Add(tmp);

            }


            dataRes.data = res;


        }
    }
}
