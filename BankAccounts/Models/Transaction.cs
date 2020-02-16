using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
    
namespace BankAccounts.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId {get;set;}
        public double Amount {get;set;}
        public int UserId { get; set; }
        public User Banker { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }  
} 