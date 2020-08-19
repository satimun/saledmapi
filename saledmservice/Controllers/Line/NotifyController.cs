using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using saledmservice.Engine.Line.Notify;

namespace saledmservice.Controllers.Line
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyController : Base
    {
        [HttpPost("PushMessage")]
        public async Task<dynamic> PushMessage([FromBody] dynamic data)
        {
            var res = new PushMessage();
            return await Task.Run(() => ResponeValid(res.Execute(HttpContext, data)));

        }
    }
}
