using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductsCategories.Models
{
    public class ProdCat
    {
        public int ProdCatId {get; set;}
        public int ProductId {get; set;}
        public int CategoryId {get; set;}
        public Product Product {get;set;}
        public Category Category {get;set;}

    }
}