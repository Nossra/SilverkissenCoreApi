using Microsoft.Extensions.Configuration;
using silverkissen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.Utilities
{
    public static class ModelFactory
    {
        public static IImage NewImage()
        {
            return new Image();
        }

        public static IUser NewUser(string username, string password)
        {
            return new User(username,password);
        }

        public static ITokenIssuer NewTokenIssuer(IConfiguration Configuration)
        {
            return new TokenIssuer(Configuration);
        }
    }
}
