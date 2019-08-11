using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.Models
{
    public class TokenObject
    {
        public string Token { get; set; }

        public TokenObject(string token)
        {
            Token = token;
        }
    }
}
