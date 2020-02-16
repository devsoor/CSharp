using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        public int WeddingId {get; set;}
        [Required]
        public string WedderOne {get; set;}
        [Required]        
        public string WedderTwo {get; set;}
        public string Name {get; set;}
        [Required]
        [DataType(DataType.Date)]
        [DateCheck]     
        public DateTime Date {get;set;}
        public string DateToDisplay {get;set;}
        [Required]        
        public string Address {get;set;}
        public string Action {get;set;}
        public int UserId {get;set;}
        public User Creator {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public List<UserWedding> AttendedUsers {get;set;}

        public Wedding()
        {
            AttendedUsers = new List<UserWedding>();
            Action = "RSVP";
        }

        public class DateCheck : ValidationAttribute
        {
            public string GetErrorMessage() =>
                $"Date must be in the future.";

            protected override ValidationResult IsValid(object value,
                ValidationContext validationContext)
            {
                var wedding = (Wedding)validationContext.ObjectInstance;
                DateTime today = DateTime.Now; 
                TimeSpan interval = wedding.Date - today;
                if (interval.TotalDays < 0)
                {
                    return new ValidationResult(GetErrorMessage());
                }

                return ValidationResult.Success;
            }
        }
    }
}