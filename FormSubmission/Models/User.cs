using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{
    public class User
    {
        [Required]
        [MinLength(4)]
        public string FirstName {get;set;}

        [Required]
        [MinLength(4)]
        public string LastName {get;set;}
        
        [Required]
        [Range(1,int.MaxValue)]
        public int Age {get;set;}

        [Required]
        [EmailAddress]
        public string Email {get;set;}
        
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password {get;set;}

    }
}