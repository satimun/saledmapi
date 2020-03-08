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

namespace kkfmisservice.Engine.Apis.mdmSales
{
    public class mdmSalesSearchDetail : Base<mdmSalesSearchDetailReq>
    {
        protected override void ExecuteChild(mdmSalesSearchDetailReq dataReq, ResponseAPI dataRes)
        {


            var res = new List<Model.Response.mdmSales.mdmSalesSearchDetailRes>();

            var roles = Ado.Mssql.View.mdmSalesSearchDetail.GetInstant().Search(dataReq);


            foreach (var x in roles)
            {
                var tmp = new Model.Response.mdmSales.mdmSalesSearchDetailRes();

                tmp.month_code = x.month_code;
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
