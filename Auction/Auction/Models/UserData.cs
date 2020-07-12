using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Models
{
    public class UserData
    {
        public int UserDataID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public DateTime ExpiresIn { get; set; }

        public User User { get; set; }
    }
}
