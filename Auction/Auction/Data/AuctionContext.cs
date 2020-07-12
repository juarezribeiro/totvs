using Auction.Models;
using Microsoft.EntityFrameworkCore;

namespace Auction.Data
{
    public class AuctionContext : DbContext
    {
        public AuctionContext(DbContextOptions<AuctionContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserData> UserData { get; set; }
        public DbSet<AuctionList> AuctionLists { get; set; }
        public DbSet<Models.Auction> Auctions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<AuctionList>().ToTable("ActionList");
            modelBuilder.Entity<Models.Auction>().ToTable("Auction");
        }
    }
}
