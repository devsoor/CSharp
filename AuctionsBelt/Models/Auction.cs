using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using AuctionsBelt.Models;
    
namespace AuctionsBelt.Models
{
    public class Auction
    {
        public int AuctionId  {get; set;}
        [Required]
        [MinLength(3)]
        public string ProductName {get;set;}
        [Required]
        [MinLength(10)]
        public string Description {get;set;}
        [Required]
        [Range(0, int.MaxValue)]
        public int StartingBid {get;set;}
        public int TopBid {get;set;}
        public int TimeRemaining {get;set;}
        public int UserId {get;set;}
        public User Seller {get;set;}
        public string FirstName {get;set;}
        public string Action  {get;set;}
        [Required]
        [DataType(DataType.Date)]
        [EndDateCheck]
        public DateTime EndDate {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public List<UserAuction> UserList {get;set;}

    }

    public class EndDateCheck : ValidationAttribute
    {
        public string GetErrorMessage() =>
            $"End Date must be in the future";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var auction = (Auction)validationContext.ObjectInstance;
            DateTime today = DateTime.Now; 
            if (auction.EndDate <= today)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}