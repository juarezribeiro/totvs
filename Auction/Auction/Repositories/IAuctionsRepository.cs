using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Repositories
{
    public interface IAuctionsRepository
    {
        public Task<List<Models.Auction>> GetAll();
        public Task<Models.Auction> Get(int id);

        public Task<dynamic> UpdateAuction(Models.Auction auction);

        public Task<dynamic> PostAuction(Models.Auction auction);

        public Task<dynamic> DeleteAuction(int id);
    }
}
