using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace silverkissen.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //public AuthController(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }

        //[HttpPost("token")]
        //public ActionResult GetToken()
        //{
        //    string secret = Configuration.GetSection("Auth:Secret").Value;
        //    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

        //    var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        //    var token = new JwtSecurityToken(
        //            issuer: "martin",
        //            audience: "readers",
        //            expires: DateTime.Now.AddHours(1),
        //            signingCredentials: signingCredentials 
        //        );

        //    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        //}
    }
}