using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using AuctionsBelt.Models;
    
namespace AuctionsBelt.Models
{
    public class AuctionContext : DbContext
    {
        public AuctionContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get; set;}
        public DbSet<LoginUser> LoginUsers {get; set;}
        public DbSet<UserAuction> UserAuctions {get; set;}
        public DbSet<Auction> Auctions {get; set;}
    }

}