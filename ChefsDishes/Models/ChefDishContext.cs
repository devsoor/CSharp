using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace ChefsDishes.Models
{
    public class ChefDishContext : DbContext
    {
        public ChefDishContext(DbContextOptions options) : base(options) { }
        public DbSet<Dish> Dishes {get; set;}
        public DbSet<User> Users {get; set;}
    }
}