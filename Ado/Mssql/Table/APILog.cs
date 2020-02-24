using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Ado.Mssql.Table
{
    public class APILog : Base
    {
        private static APILog instant;

        public static APILog GetInstant()
        {
            if (instant == null) instant = new APILog();
            return instant;
        }

        private string conectStr { get; set; }

        private APILog()
        {

        }


        /*
        public List<Model.Table.Mssql.mdlAPILog> Search(Model.Table.Mssql.mdlAPILog d)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", d.ID);
            param.Add("@RefID", d.RefID);
            param.Add("@Token", d.Token);
            param.Add("@Status", d.Status);
            param.Add("@StatusMessage", d.StatusMessage);
            param.Add("@StartDate", d.StartDate);
            param.Add("@EndDate", d.EndDate);
            param.Add("@ServerName", d.ServerName);

            string cmd = "SELECT * FROM sxlAPILog " +
                "WHERE (@ID iS NULL OR ID=@ID) " +
                "OR (@RefID iS NULL OR RefID=@RefID) " +
                "OR (@Token iS NULL OR Token=@Token) " +
                "OR (@Status iS NULL OR Status=@Status) " +
                "OR (@StatusMessage iS NULL OR StatusMessage=@StatusMessage) " +
                "OR (@StartDate iS NULL OR StartDate=@StartDate) " +
                "OR (@EndDate iS NULL OR EndDate=@EndDate) " +
                "OR (@ServerName iS NULL OR ServerName=@ServerName);";
            var res = Query<Model.Table.Mssql.sxlAPILog>(cmd, param).ToList();
            return res;
        }
        


        public int Save(Model.Table.Mssql.sxlAPILog d, SqlTransaction transac = null)
        {
            if (d.ID.HasValue)
            {
                return Update(d, transac);
            }
            else
            {
                return Insert(d, transac);
            }
        }

        public int Update(Model.Table.Mssql.mdlAPILog d, SqlTransaction transac = null)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", d.ID);
            param.Add("@RefID", d.RefID);
            param.Add("@Token", d.Token);
            param.Add("@APIName", d.APIName);
            param.Add("@Status", d.Status);
            param.Add("@StatusMessage", d.StatusMessage);
            param.Add("@StartDate", d.StartDate);
            param.Add("@EndDate", d.EndDate);
            param.Add("@ServerName", d.ServerName);
            param.Add("@Input", d.Input);
            param.Add("@Output", d.Output);

            string cmd = $"UPDATE sxlAPILog SET " +
                "RefID=@RefID, " +
                "Token=@Token, " +
                "APIName=@APIName, " +
                "Status=@Status, " +
                "StatusMessage=@StatusMessage, " +
                "StartDate=@StartDate, " +
                "EndDate=@EndDate, " +
                "ServerName=@ServerName, " +
                "Input=@Input, " +
                "Output=@Output " +
                "WHERE ID=@ID;";
            var res = ExecuteNonQuery(transac, cmd, param);
            return res;
        }

        public int Insert(Model.Table.Mssql.sxlAPILog d, SqlTransaction transac = null)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@RefID", d.RefID);
            param.Add("@Token", d.Token);
            param.Add("@APIName", d.APIName);
            param.Add("@Status", d.Status);
            param.Add("@StatusMessage", d.StatusMessage);
            param.Add("@StartDate", d.StartDate);
            param.Add("@EndDate", d.EndDate);
            param.Add("@ServerName", d.ServerName);
            param.Add("@Input", d.Input);
            param.Add("@Output", d.Output);
            param.Add("@Remark", d.Remark);

            string cmd = "INSERT INTO sxlAPILog (RefID, Token, APIName, Status, StatusMessage, StartDate, EndDate, ServerName, Input, Output, Remark) " +
                "VALUES (@RefID, @Token, @APIName, @Status, @StatusMessage, @StartDate, @EndDate, @ServerName, @Input, @Output, @Remark); " +
                "SELECT SCOPE_IDENTITY();";
            var res = ExecuteScalar<int>(transac, cmd, param);
            return res;
        }
        */
    }
}
