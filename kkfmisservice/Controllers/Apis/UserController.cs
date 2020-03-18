using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using kkfmisservice.Engine.Apis.User;

namespace kkfmisservice.Controllers.Apis
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Base
    {

        [HttpPost("Register")]
        public async Task<dynamic> Register([FromBody] dynamic data)
        {
            var res = new UserRegister();
            return await Task.Run(() => ResponeValid(res.Execute(HttpContext, data)));
        }

        

    }
}