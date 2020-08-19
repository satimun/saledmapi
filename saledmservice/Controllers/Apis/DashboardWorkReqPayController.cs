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
    public class DashboardWorkReqPayController : Base
    {
        [HttpPost("SearchDashboardWorkReqPay")]

        public async Task<dynamic> Search([FromBody] dynamic data)
        {
            var res = new Engine.Apis.DashboardWorkPay.DashboardWorkReqpay();

            return await Task.Run(() => ResponeValid(res.Execute(HttpContext, data)));

            //return 2;

        }






    }



}