using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace saledmservice.Controllers.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardwaitcreatebillController : Base
    {
        [HttpPost("SearchDashboardwaitcreatebill")]

        public async Task<dynamic> Search([FromBody] dynamic data)
        {
            var res = new Engine.Apis.Dashboardwaitcreatebill.Dashboardwaitcreatebill();

            return await Task.Run(() => ResponeValid(res.Execute(HttpContext, data)));

            //return 2;

        }

     



    }



}