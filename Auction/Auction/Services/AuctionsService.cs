using Auction.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auction.Services
{
    public class AuctionsService : IAuctionsService
    {
        private readonly IAuctionsRepository _auctionsRepository;
        public AuctionsService(IAuctionsRepository auctionsRepositorie)
        {
            _auctionsRepository = auctionsRepositorie;
        }

        public async Task<dynamic> DeleteAuction(int id)
        {
            return await _auctionsRepository.DeleteAuction(id);
        }

        public async Task<ActionResult<Models.Auction>> Get(int id)
        {
            return await _auctionsRepository.Get(id);
        }

        public async Task<List<Models.Auction>> GetAuctions()
        {
            return await _auctionsRepository.GetAll();
        }

        public async Task<dynamic> PostAuction(Models.Auction auction)
        {
            return await _auctionsRepository.PostAuction(auction);
        }

        public async Task<dynamic> UpdateAuction(Models.Auction auction)
        {
            return await _auctionsRepository.UpdateAuction(auction);
        }
    }
}
