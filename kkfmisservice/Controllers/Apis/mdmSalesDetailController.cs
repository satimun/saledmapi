﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kkfmisservice.Controllers.Apis{
    


    [Route("api/[controller]")]
    [ApiController]
    public class mdmSalesDetailController : Base
    {
        [HttpPost("SearchDetail")]

        public async Task<dynamic> Search([FromBody] dynamic data)
        {
            var res = new Engine.Apis.mdmSales.mdmSalesSearchDetail();

            return await Task.Run(() => ResponeValid(res.Execute(HttpContext, data)));

            //return 2;

        }

    /*
     * 
     * [Route("api/[controller]")]
    [ApiController]
    public class mdmSalesController : Base    
    {
        [HttpPost("SearchSummary")]

        public async Task<dynamic> Search([FromBody] dynamic data)
        {
            var res = new Engine.Apis.mdmSales.mdmSalesSearchSummary();

            return await Task.Run(() => ResponeValid(res.Execute(HttpContext, data)));

            //return 2;
        
        }
*/
  




    }
}
 