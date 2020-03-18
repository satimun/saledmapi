using Core.Util;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using System.Text;
using Model.Common;
using Model.Table.Mssql;

namespace Ado.Mssql.Table
{
    public class vTEMPLOY : Base
    {
        private static vTEMPLOY instant;

        public static vTEMPLOY GetInstant()
        {
            if (instant == null) instant = new vTEMPLOY();
            return instant;
        }

        private string conectStr { get; set; }

        private vTEMPLOY()
        {
            //conectStr = "Server=191.20.2.3;Uid=sa;PASSWORD=abc123;database=kkf_api;Max Pool Size=10;Connect Timeout=6000;";
            conectStr = "Server=191.20.20.182;Uid=sa;PASSWORD=abc123;database=centraldb;Max Pool Size=10;Connect Timeout=6000;";
        }


 



        public List<Model.Table.Mssql.Employee> Search(Model.Table.Mssql.Employee d, SqlTransaction transac = null)
        {


            DynamicParameters param = new DynamicParameters();
            param.Add("@CODEMPID", d.Code);


            string cmd = "SELECT *,CODEMPID as User_ID,NAMEMPT as  Description FROM vTEMPLOY WHERE (@CODEMPID IS NULL OR CODEMPID = @CODEMPID);";

            var res = Query<Model.Table.Mssql.Employee>(cmd, param, conectStr).ToList();

            return res;
        }



    }
}
