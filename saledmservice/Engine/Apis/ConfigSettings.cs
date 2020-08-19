using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model.Response;
using Microsoft.Extensions.Configuration;
using Model.Request;



namespace saledmservice.Engine.Apis
{
    public class ConfigSettings : Base<ConfigSetting>
    {
        public ConfigSettings(IConfiguration configuration)
        {
            PermissionKey = "ADMIN";
            Configuration = configuration;

        }

        private IConfiguration Configuration;

        protected override void ExecuteChild(ConfigSetting dataReq, ResponseAPI dataRes)
        {
            var res = new ConfigSetting();
            try
            {
                if (dataReq != null)
                {
                    res.DBMode = dataReq.DBMode;
                    res.Status = true;
                    switch (dataReq.DBMode)
                    {
                        case "1":
                            Ado.Mssql.Base.conString = Configuration["ConnTest"];
                            res.ConnStr = Ado.Mssql.Base.conString;

                            break;

                        case "2":
                            Ado.Mssql.Base.conString = Configuration["ConnLocal"];
                            res.ConnStr = Ado.Mssql.Base.conString;

                            break;
                        default:
                            Ado.Mssql.Base.conString = Configuration["ConnProduction"];
                            res.ConnStr = Ado.Mssql.Base.conString;

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                res.Status = false;
                res.Message = "ไม่สามารถกำหนดค่า Connection String ได้";
            }
            dataRes.data = res;
        }
    }
}
