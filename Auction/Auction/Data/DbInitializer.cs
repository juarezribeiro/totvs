using Auction.Data;
using Auction.Models;
using System;
using System.Linq;

namespace Auction.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AuctionContext context)
        {
            context.Database.EnsureCreated();

            if (context.Auctions.Any())
            {
                return;   // DB has been seeded
            }

            var auctions = new Auction.Models.Auction[]
            {
                new Auction.Models.Auction{Title="Auction 1",InitialValue=125,Start=DateTime.Parse("2020-07-07"),End=DateTime.Parse("2020-07-08"),Status=true},
                new Auction.Models.Auction{Title="Auction 2",InitialValue=200,Start=DateTime.Parse("2020-07-08"),End=DateTime.Parse("2020-07-09"),Status=true}
            };
            foreach (Auction.Models.Auction s in auctions)
            {
                context.Auctions.Add(s);
            }
            context.SaveChanges();

            var users = new User[]
            {
                new User{Name="Admin", Status=true},
                new User{Name="Juarez Ribeiro", Status=true},
                new User{Name="Test", Status=false}
            };
            foreach (User c in users)
            {
                context.Users.Add(c);
            }
            context.SaveChanges();

            var usersData = new UserData[]
            {
                new UserData{UserID=1, UserName="admin", Password="A6xnQhbz4Vx2HuGl4lXwZ5U2I8iziLRFnhP5eNfIRvQ="},
                new UserData{UserID=2, UserName="juarez", Password="A6xnQhbz4Vx2HuGl4lXwZ5U2I8iziLRFnhP5eNfIRvQ="},
                new UserData{UserID=3, UserName="test", Password="A6xnQhbz4Vx2HuGl4lXwZ5U2I8iziLRFnhP5eNfIRvQ="},
            };

            foreach (UserData c in usersData)
            {
                context.UserData.Add(c);
            }
            context.SaveChanges();

            var auctionLists = new AuctionList[]
            {
                new AuctionList{AuctionID=1,UserID=1,Condition=Condition.Used},
                new AuctionList{AuctionID=2,UserID=2,Condition=Condition.New}
            };
            foreach (AuctionList e in auctionLists)
            {
                context.AuctionLists.Add(e);
            }
            context.SaveChanges();
        }
    }
}