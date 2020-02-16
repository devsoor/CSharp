using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductsCategories.Models
{
    public class Product
    {
        public int ProductId {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public double Price {get; set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public List<ProdCat> ProductCats {get;set;}
    }
}