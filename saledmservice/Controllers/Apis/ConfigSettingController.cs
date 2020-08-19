using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using saledmservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using saledmservice.Engine.Apis;

namespace saledmservice.Controllers.Apis
{
    [Produces("application/json")]
    [Route("api/[controller]")]

    [ApiController]
    public class ConfigSettingController : Base
    {
        private IConfiguration Configuration;

        public ConfigSettingController(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        [HttpPost("GetData")]
        public async Task<dynamic> GetData([FromBody] dynamic data)
        {
            var res = new ConfigSettings(Configuration);
            return await Task.Run(() => ResponeValid(res.Execute(HttpContext, data)));

        }
    }
}