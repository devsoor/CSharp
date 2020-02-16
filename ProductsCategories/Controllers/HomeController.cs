using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsCategories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace ProductsCategories.Controllers
{
    public class HomeController : Controller
    {
        private ProductsContext dbContext;

        public HomeController(ProductsContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            return RedirectToAction("products");
        }

        [HttpGet("products")]
        public ViewResult Products()
        {
            List<Product> AllProducts = dbContext.Products.ToList();
            ViewBag.allProducts = AllProducts;
            return View();
        }

        public IActionResult CreateProduct(Product newProduct)
        {
            dbContext.Add(newProduct);
            dbContext.SaveChanges();
            return RedirectToAction("Products");
        }

        [HttpGet("/products/{id}")] 
        public ViewResult ProductShow(int id)
        {
            var currrentProduct = dbContext.Products
                .Include(product => product.ProductCats)
                .ThenInclude(category => category.Category)
                .FirstOrDefault(p => p.ProductId == id);

            List<int> catList = new List<int>();
            foreach (var c in currrentProduct.ProductCats)
            {
                catList.Add(c.Category.CategoryId);
            }
            List<Category> allCategories = dbContext.Categories.ToList();

            List<Category> otherCategories = new List<Category>();
            foreach (var cat in allCategories)
            {
                if (!catList.Contains(cat.CategoryId))
                {
                    otherCategories.Add(cat);
                }
            }

            ViewBag.otherCategories = otherCategories;
            return View(currrentProduct);
        }

        [HttpGet("categories")]
        public ViewResult Categories()
        {
            List<Category> AllCategories = dbContext.Categories.ToList();
            ViewBag.allCategories = AllCategories;
            return View();
        }
    
        public IActionResult CreateCategory(Category newCategory)
        {
            dbContext.Add(newCategory);
            dbContext.SaveChanges();
            return RedirectToAction("Categories");
        }

        [HttpPost("/AddCategory/{id}")]
        public IActionResult AddCategory(int id, int category)
        {
            var pc = dbContext.ProductCategory
                .Where(p => p.ProductId == id);
            foreach (var p in pc)
            {
                if (p.CategoryId == category)
                {
                    return RedirectToAction("Products");
                }
            }
        
            var prodCat = new ProdCat
            {
                ProductId = id,
                CategoryId = category
            };
            dbContext.Add(prodCat);
            dbContext.SaveChanges();
            return RedirectToAction("Products");
        }

        [HttpGet("/categories/{id}")] 
        public ViewResult CategoryShow(int id)
        {
            var currrentCategory = dbContext.Categories
                .Include(c => c.ProdCategores)
                .ThenInclude(p => p.Product)
                .FirstOrDefault(c => c.CategoryId == id);

            List<int> prodList = new List<int>();
            foreach (var p in currrentCategory.ProdCategores)
            {
                prodList.Add(p.Product.ProductId);
            }
            List<Product> allProducts = dbContext.Products.ToList();

            List<Product> otherProducts = new List<Product>();
            foreach (var prod in allProducts)
            {
                if (!prodList.Contains(prod.ProductId))
                {
                    otherProducts.Add(prod);
                }
            }

            ViewBag.otherProducts = otherProducts;
            return View(currrentCategory);
        }

        [HttpPost("/AddProduct/{id}")]
        public IActionResult AddCategory(Category category, int id, int product)
        {
            var pc = dbContext.ProductCategory
                .Where(c => c.CategoryId == id);
            foreach (var p in pc)
            {
                if (p.ProductId == product)
                {
                    return RedirectToAction("Products");
                }
            }
        
            var prodCat = new ProdCat
            {
                ProductId = product,
                CategoryId = id
            };
            dbContext.Add(prodCat);
            dbContext.SaveChanges();
            return RedirectToAction("categories");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
