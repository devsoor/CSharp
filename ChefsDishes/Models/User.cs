using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
    
namespace ChefsDishes.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}
        [Required]
        [MinLength(2)]
        public string FirstName {get;set;}
        [Required]
        [MinLength(2)]
        public string LastName {get;set;}

        [Required]
        [DataType(DataType.Date)]
        [DOBCheck]
        public DateTime DOB {get;set;} 

        public int Age {get;set;} 

        public List<Dish> CreatedDishes {get;set;} 

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public User()
        {
            CreatedDishes = new List<Dish>();
        }
    }  

    public class DOBCheck : ValidationAttribute
    {
        public string GetErrorMessage() =>
            $"You must be atleast 18 years old.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var chef = (User)validationContext.ObjectInstance;
            DateTime today = DateTime.Now; 
            TimeSpan interval = today - chef.DOB;
            Double totalYears = interval.TotalDays/365;
            if (totalYears < 18.0)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
} 