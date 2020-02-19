using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AuctionsBelt.Models;

namespace AuctionsBelt.Models
{
    public class LoginUser
    {
        [Key]
        public int LoginUserId {get;set;}

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username {get;set;}

        [DataType(DataType.Password)]
        [Required]
        [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
        public string Password {get;set;}
    }  
} 