using Auction.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Repositories
{
    public class AuctionsRepositoriy : IAuctionsRepository
    {
        private readonly AuctionContext _context;

        public AuctionsRepositoriy(AuctionContext context)
        {
            _context = context;
        }

        public async Task<dynamic> DeleteAuction(int id)
        {

            var auction = await _context.Auctions.FindAsync(id);
            if (auction == null)
            {
                throw new System.Exception("An unknow error ocurred.");
            }

            _context.Auctions.Remove(auction);
            return await _context.SaveChangesAsync();
            
        }

        public async Task<Models.Auction> Get(int id)
        {
            return await _context.Auctions
                            .Include(s => s.AuctionList)
                            .ThenInclude(e => e.User)
                            .AsNoTracking()
                            .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Models.Auction>> GetAll()
        {
            return await _context.Auctions
                            .Include(s => s.AuctionList)
                            .ThenInclude(e => e.User)
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task<dynamic> PostAuction(Models.Auction auction)
        {
            _context.Auctions.Add(auction);
            return await _context.SaveChangesAsync();
        }

        public async Task<dynamic> UpdateAuction(Models.Auction auction)
        {
            _context.Entry(auction).State = EntityState.Modified;
            _context.Entry(auction.AuctionList.First()).State = EntityState.Modified;
            
            return await _context.SaveChangesAsync();  
        }
    }
}
