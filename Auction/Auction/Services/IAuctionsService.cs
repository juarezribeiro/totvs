using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auction.Services
{
    public interface IAuctionsService
    {
        public Task<ActionResult<Models.Auction>> Get(int id);
        public Task<List<Models.Auction>> GetAuctions();
        public Task<dynamic> UpdateAuction(Models.Auction auction);

        public Task<dynamic> PostAuction(Models.Auction auction);

        public Task<dynamic> DeleteAuction(int id);
    }
}
