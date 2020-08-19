using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Request;
using Ado;
using Model;
using Core.Util;
using Model.Request.DashboardWorkRecPay;
using Model.Response;

namespace saledmservice.Engine.Apis.DashboardWorkRecPay
{
    public class DashboardWorkRecPaySendround : Base<dashboardWorkrecpayReq>
    {
        protected override void ExecuteChild(dashboardWorkrecpayReq dataReq, ResponseAPI dataRes)
        {


            var res = new List<Model.Response.DashboardWorkRecPay.dashboardWorkRecPaySendroundRes>();

            var roles = Ado.Mssql.View.dashboardWorkrecpaySendround.GetInstant().Search(dataReq);


            foreach (var x in roles)
            {
                var tmp = new Model.Response.DashboardWorkRecPay.dashboardWorkRecPaySendroundRes();

                tmp.SENDROUND = x.SENDROUND;
                tmp.BCSTD_AMT = x.BCSTD_AMT;
                tmp.BCNSTD_AMT = x.BCNSTD_AMT;
                tmp.BC_AMT_08 = x.BC_AMT_08;
                tmp.BC_AMT_09 = x.BC_AMT_09;

                tmp.BC_AMT_10 = x.BC_AMT_10;
                tmp.BC_AMT_11 = x.BC_AMT_11;
                tmp.BC_AMT_12 = x.BC_AMT_12;
                tmp.BC_AMT_13 = x.BC_AMT_13;
                tmp.BC_AMT_14 = x.BC_AMT_14;
                tmp.BC_AMT_15 = x.BC_AMT_15;
                tmp.BC_AMT_16 = x.BC_AMT_16;
                tmp.BC_AMT_17 = x.BC_AMT_17;
                tmp.BC_AMT_18 = x.BC_AMT_18;
                tmp.BC_AMT_19 = x.BC_AMT_19;
                tmp.BC_AMT_20 = x.BC_AMT_20;


                tmp.BC_AMT_22 = x.BC_AMT_22;
                tmp.BC_AMT_23 = x.BC_AMT_23;
                tmp.BC_AMT_24 = x.BC_AMT_24;
                tmp.BC_AMT_25 = x.BC_AMT_25;




                res.Add(tmp);

            }


            dataRes.data = res;


        }
    }
}
