﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace saledmservice.Controllers.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardtopvalueController : Base
    {
        [HttpPost("SearchDashboardtopvalue")]

        public async Task<dynamic> Search([FromBody] dynamic data)
        {
            var res = new Engine.Apis.Dashboardtopvalue.Dashboardtopvalue();

            return await Task.Run(() => ResponeValid(res.Execute(HttpContext, data)));

            //return 2;

        }






    }



}