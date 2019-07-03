using Microsoft.EntityFrameworkCore;
using silverkissen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.Servies
{
    public class UserService
    {
        private readonly SilverkissenContext _db;

        public UserService(SilverkissenContext context)
        {
            _db = context;
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
            }
            else
            {
                return true;
            }
        }
    }
}