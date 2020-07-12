using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Auction.Data;
using Auction.Models;
using Auction.Services;
using Microsoft.AspNetCore.Authorization;

namespace Auction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly AuctionContext _context;
        private readonly IAuctionsService _auctionsService;

        public AuctionsController(AuctionContext context, IAuctionsService auctionsService)
        {
            _context = context;
            _auctionsService = auctionsService;
        }

        // GET: api/Auctions
        [HttpGet]
        [Authorize()]
        public async Task<ActionResult<IEnumerable<Models.Auction>>> GetAuctions()
        {
            var auction = await _auctionsService.GetAuctions();

            if (auction == null)
            {
                return NotFound();
            }

            return auction;
        }

        // GET: api/Auctions/5
        [HttpGet("{id}")]
        [Authorize()]
        public async Task<ActionResult<Models.Auction>> GetAuction(int id)
        {

            var auction = await _auctionsService.Get(id);

            if (auction == null)
            {
                return NotFound();
            }

            return auction;

        }

        // PUT: api/Auctions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize()]
        public async Task<IActionResult> PutAuction(int id, Models.Auction auction)
        {
            if (id != auction.Id)
            {
                return BadRequest();
            }

            await _auctionsService.UpdateAuction(auction);

            return Ok();
        }

        // POST: api/Auctions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize()]
        public async Task<ActionResult<Models.Auction>> PostAuction(Models.Auction auction)
        {
            await _auctionsService.PostAuction(auction);

            return Ok();
        }

        // DELETE: api/Auctions/5
        [HttpDelete("{id}")]
        [Authorize()]
        public async Task<ActionResult<Models.Auction>> DeleteAuction(int id)
        {
            await _auctionsService.DeleteAuction(id);

            return Ok();
        }

    }
}
