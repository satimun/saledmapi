using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using kkfmisservice.Engine.Apis.Oauth;

namespace kkfmisservice.Controllers.Apis
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OauthController : Base
    {

        [HttpGet("Access")]
        public async Task<dynamic> Access()
        {
            var res = new OauthAccessTokenGet();
            return await Task.Run(() => ResponeValid(res.Execute(HttpContext)));
        }

        [HttpPut("Login")]
        public async Task<dynamic> Login([FromBody] dynamic data)
        {
            var res = new OauthLogin();
            return await Task.Run(() => ResponeValid(res.Execute(HttpContext, data)));
        }

        [HttpDelete("Logout")]
        public async Task<dynamic> Logout()
        {
            var res = new OauthLogout();
            return await Task.Run(() => ResponeValid(res.Execute(HttpContext)));
        }

    }
}