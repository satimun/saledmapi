using Core.Util;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace Ado.Mssql.View
{
    public class mdmSales : Base
    {
        private static mdmSales instant;

        public static mdmSales GetInstant()
        {
            if (instant == null) instant = new mdmSales();
            return instant;
        }

        private mdmSales()
        {
        }

        //public List<Model.View.Mssql> Search(Model.Request.Country.CountrySearchReq d, SqlTransaction transac = null)
        public List<Model.View.Mssql.mdvSalesSummary> Search(Model.Request.mdmSales.mdmSalesSearchSummaryReq d, SqlTransaction transac = null)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@YRIsNull", d.yr);
            param.Add("@TSaleIsNull", d.tsale);           


            if (d.tsale == "")
            {
                string cmd = "SELECT ROUND(SUM(target_value)/1000000,2) AS target_value "+
                    $" , ROUND(SUM(totsale_value)/1000000,2) AS totsale_value " +
                    $" , ROUND(SUM(totsale_value)/1000000,2) - ROUND(SUM(target_value)/1000000,2) as diff_value " +
                    $" , ROUND(CASE WHEN ROUND(SUM(target_value)/1000000,2) = 0 THEN 0 ELSE "+
                    $" ROUND(SUM(totsale_value)/1000000,2) * 100 / ROUND(SUM(target_value)/1000000,2) END,2) AS percent_diff FROM mdmSales WHERE YR = " + d.yr.ToString();
                
                var res = Query<Model.View.Mssql.mdvSalesSummary>(cmd, param).ToList();

                return res;
            }
            else
            {
                string cmd = "SELECT ROUND(SUM(target_value)/1000000,2) AS target_value " +
                    $" , ROUND(SUM(totsale_value)/1000000,2) AS totsale_value " +
                    $" ,  ROUND(SUM(totsale_value)/1000000,2) - ROUND(SUM(target_value)/1000000,2) as diff_value " +
                    $" , ROUND(CASE WHEN ROUND(SUM(target_value)/1000000,2) = 0 THEN 0 ELSE " +
                    $" ROUND(SUM(totsale_value)/1000000,2) * 100 / ROUND(SUM(target_value)/1000000,2) END,2) AS percent_diff FROM mdmSales WHERE YR = " + d.yr.ToString()+
                    $" AND TSALE = '"+d.tsale+"'";

                var res = Query<Model.View.Mssql.mdvSalesSummary>(cmd, param).ToList();

                return res;
            }

            
            
        }

        
    }
}
