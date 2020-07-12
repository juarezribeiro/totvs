using Auction.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auction.Repositories
{
    public interface IUsersRepository
    {
        public Task<ActionResult<IEnumerable<User>>> GetUsers();
        public Task<UserData> Get(string username, string password);
        public Task<User> GetUser(int id);
    }
}
