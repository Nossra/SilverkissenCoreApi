using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using silverkissen.Models;
using silverkissen.Servies;
using silverkissen.Utilities;

namespace silverkissen.Controllers
{
    [Route("api/users")]
    [ApiController] 
    public class UserController : ControllerBase
    {
        private readonly SilverkissenContext _db; 
        public IConfiguration Configuration { get; } 
        public UserController(SilverkissenContext context, IConfiguration config)
        {
            _db = context;
            Configuration = config; 
        }

        [HttpPost]
        public ActionResult<string> Login([FromBody] User suggestedUser)
        {
            bool validUser = CheckCredentials(suggestedUser); 

            if (validUser)
            { 
                ITokenIssuer tokenIssuer = ModelFactory.NewTokenIssuer(Configuration);
                string token = tokenIssuer.GetToken();
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
         
        public bool CheckCredentials(IUser user)
        { 
            var query = from u in _db.Users
                        where u.Username == user.Username
                        && u.Password == user.Password
                        select u;

            var accepted = query.FirstOrDefault();

            if (accepted == null)
            {
                return false;
            } else
            {
                return true;
            }
        }
    }
}