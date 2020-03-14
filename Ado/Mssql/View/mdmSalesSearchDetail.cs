using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Ado.Mssql.View
{
    public class mdmSalesSearchDetail : Base
    {
        private static mdmSalesSearchDetail instant;

        public static mdmSalesSearchDetail GetInstant()
        {
            if (instant == null) instant = new mdmSalesSearchDetail();
            return instant;
        }

        private mdmSalesSearchDetail()
        {
        }
        
        public List<Model.View.Mssql.mdvSalesDetail> Search(Model.Request.mdmSales.mdmSalesSearchDetailReq d, SqlTransaction transac = null)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@YRIsNull", d.yr);
            param.Add("@TSaleIsNull", d.tsale);


            if (d.tsale == "")
            {
                string cmd = "SELECT CAST(MN AS VARCHAR(2))+'/'+CAST(YR AS VARCHAR(4)) AS MONTH_CODE"+
                    $" , ROUND(SUM(target_value)/1000000,2) AS target_value,ROUND(SUM(totpi_value)/1000000,2) as totpi_value, ROUND(SUM(totsale_value)/1000000,2) AS totsale_value " +
                    $" , CASE WHEN SUM(totsale_value) = 0 then 0 else ROUND(SUM(totsale_value)/1000000,2) - ROUND(SUM(target_value)/1000000,2) end  as diff_value " +
                    $" , CASE WHEN SUM(totsale_value) = 0 then 0 else CASE WHEN ROUND(SUM(target_value)/1000000,2) = 0 THEN 0 ELSE " +
                    $" ROUND(ROUND(SUM(totsale_value)/1000000,2) * 100 / ROUND(SUM(target_value)/1000000,2),2) END end AS percent_diff "+
                    $", ROUND((select sum(target_value) from mdmSales b where b.yr = " + d.yr.ToString() + " and b.mn <= mdmsales.mn ) / 1000000,2) as cum_target_value" +
                    $" ,ROUND((select sum(totsale_value) from mdmSales b where b.yr = " + d.yr.ToString() + " and b.mn <= mdmsales.mn) / 1000000,2) as cum_sale_value" +
                    $", ROUND((select sum(totsale_value) from mdmSales b where b.yr = " + d.yr.ToString() + " and b.mn <= mdmsales.mn) / 1000000,2) -  ROUND((select sum(target_value) from mdmSales b where b.yr = " + d.yr.ToString() + " and b.mn <= mdmsales.mn ) / 1000000,2) as cum_diff_value" +
                    $" , ROUND(case when ROUND((select sum(target_value) from mdmSales b where b.yr = " + d.yr.ToString() + " and b.mn <= mdmsales.mn) / 1000000, 2) = 0 then 0 else" + 
                    $" ROUND((select sum(totsale_value) from mdmSales b where b.yr = " + d.yr.ToString() + " and b.mn <= mdmsales.mn) / 1000000,2) *100 /" +
                    $" ROUND((select sum(target_value) from mdmSales b where b.yr = " + d.yr.ToString() +" and b.mn <= mdmsales.mn) / 1000000,2) end,2) as cum_percent_diff "+
                    $" FROM mdmSales WHERE YR = " + d.yr.ToString()+
                    $" GROUP BY YR,MN ORDER BY YR,MN";

                var res = Query<Model.View.Mssql.mdvSalesDetail>(cmd, param).ToList();

                return res;
            }
            else
            {
                string cmd = "SELECT CAST(MN AS VARCHAR(2))+'/'+CAST(YR AS VARCHAR(4)) AS MONTH_CODE" +
                    $" , ROUND(SUM(target_value)/1000000,2) AS target_value,ROUND(SUM(totpi_value)/1000000,2) as totpi_value, ROUND(SUM(totsale_value)/1000000,2) AS totsale_value " +
                    $" , CASE WHEN SUM(totsale_value) = 0 then 0 else ROUND(SUM(totsale_value)/1000000,2) - ROUND(SUM(target_value)/1000000,2)  end as diff_value " +
                    $" , CASE WHEN SUM(totsale_value) = 0 then 0 else CASE WHEN ROUND(SUM(target_value)/1000000,2) = 0 THEN 0 ELSE " +
                    $" ROUND(ROUND(SUM(totsale_value)/1000000,2) * 100 / ROUND(SUM(target_value)/1000000,2),2) END end AS percent_diff " +
                    $", ROUND((select sum(target_value) from mdmSales b where b.yr = " + d.yr.ToString() + " and b.tsale = " + d.tsale + " and b.mn <= mdmsales.mn ) / 1000000,2) as cum_target_value" +
                    $" ,ROUND((select sum(totsale_value) from mdmSales b where b.yr = " + d.yr.ToString() + " and b.tsale = " + d.tsale + " and b.mn <= mdmsales.mn) / 1000000,2) as cum_sale_value" +
                    $", ROUND((select sum(totsale_value) from mdmSales b where b.yr = " + d.yr.ToString() + " and b.tsale = " + d.tsale + " and b.mn <= mdmsales.mn) / 1000000,2) -  ROUND((select sum(target_value) from mdmSales b where b.yr = " + d.yr.ToString() + " and b.tsale = "+d.tsale+" and b.mn <= mdmsales.mn ) / 1000000,2) as cum_diff_value" +
                    $" , ROUND(case when ROUND((select sum(target_value) from mdmSales b where b.yr = " + d.yr.ToString() + " and b.tsale = " + d.tsale + " and b.mn <= mdmsales.mn) / 1000000, 2) = 0 then 0 else" +
                    $" ROUND((select sum(totsale_value) from mdmSales b where b.yr = " + d.yr.ToString() + " and b.tsale = " + d.tsale + " and b.mn <= mdmsales.mn) / 1000000,2) *100 /" +
                    $" ROUND((select sum(target_value) from mdmSales b where b.yr = " + d.yr.ToString() + " and b.tsale = " + d.tsale + " and b.mn <= mdmsales.mn) / 1000000,2) end,2) as cum_percent_diff " +
                    $" FROM mdmSales WHERE YR = " + d.yr.ToString() +
                    $" AND TSALE = '" + d.tsale + "' GROUP BY YR,MN ORDER BY YR,MN";

                var res = Query<Model.View.Mssql.mdvSalesDetail>(cmd, param).ToList();

                return res;
            }



        }
    }
}
