using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Wall.Models;


namespace Wall.Models
{
    public class WallContext : DbContext
    {
        public WallContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get; set;}
        public DbSet<LoginUser> LoginUsers {get; set;}
        public DbSet<Message> Messages {get; set;}
        public DbSet<Comment> Comments {get; set;}
    }

}