using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Models;


namespace WeddingPlanner.Models
{
    public class WeddingContext : DbContext
    {
        public WeddingContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get; set;}
        public DbSet<LoginUser> LoginUsers {get; set;}
        public DbSet<UserWedding> UserWeddings {get; set;}
        public DbSet<Wedding> Weddings {get; set;}
    }

}