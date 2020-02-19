using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using AuctionsBelt.Models;

namespace AuctionsBelt.Models
{
    public class UserAuction
    {
        [Key]
        public int UserAuctionId {get; set;}
        public int UserId {get; set;}
        public int AuctionId {get; set;}
        public User User {get;set;}
        public  Auction  Auction {get;set;}

    }
}