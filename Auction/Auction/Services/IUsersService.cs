using Auction.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Services
{
    public interface IUsersService
    {
        public Task<ActionResult<IEnumerable<User>>> GetUsers();
        public UserData Authenticate(string username, string password);
    }
}
