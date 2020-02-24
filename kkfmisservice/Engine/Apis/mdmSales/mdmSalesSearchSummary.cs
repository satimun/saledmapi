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
    public class mdmSalesSearchSummary : Base<mdmSalesSearchSummaryReq>
    {
        protected override void ExecuteChild(mdmSalesSearchSummaryReq dataReq, ResponseAPI dataRes)
        {
           

            var res = new List<Model.Response.mdmSales.mdmsalesRes>();

/*
            var roles = Ado.Mssql.Table.Currency.GetInstant().Search(dataReq);

            foreach (var x in roles)
            {
                var tmp = new Model.Response.Currency.CurrencyRes();
                tmp.ID = x.ID;
                tmp.Code = x.Code;
                tmp.Description = x.Description;
                tmp.Symbol = x.Symbol;
                tmp.Status = x.status;
                

                res.Add(tmp);

            }
            */

            dataRes.data = res;
            

        }
    }
}
