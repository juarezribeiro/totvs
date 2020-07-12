using Auction.Data;
using Auction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AuctionContext _context;

        public UsersRepository(AuctionContext context)
        {
            _context = context;
        }

        public async Task<UserData> Get(string username, string password)
        {
            return await _context.UserData.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserID == id);
        }

        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.Where(y => y.Status == true).Select(u => new User() { UserID = u.UserID, Name = u.Name }).ToListAsync();
        }
    }
}
