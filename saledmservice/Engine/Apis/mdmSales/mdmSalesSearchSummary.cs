using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Request;
using Ado;
using Model;
using Core.Util;
using Model.Request.mdmSales;
using Model.Response;

namespace saledmservice.Engine.Apis.mdmSales
{
    public class mdmSalesSearchSummary : Base<mdmSalesSearchSummaryReq>
    {
        protected override void ExecuteChild(mdmSalesSearchSummaryReq dataReq, ResponseAPI dataRes)
        {
           

            var res = new List<Model.Response.mdmSales.mdmsalesRes>();

            var roles = Ado.Mssql.View.mdmSales.GetInstant().Search(dataReq);
            

            foreach (var x in roles)
            {
                var tmp = new Model.Response.mdmSales.mdmsalesRes();

                tmp.target_value = x.target_value;
                tmp.totsale_value = x.totsale_value;
                tmp.diff_value = x.diff_value;
                tmp.percent_diff = x.percent_diff;

               
                res.Add(tmp);

            }
            

            dataRes.data = res;
            

        }
    }
}
