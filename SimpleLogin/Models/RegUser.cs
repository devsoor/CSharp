using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SimpleLogin.Models
{
    public class RegUser
    {
        [Required]
        [MinLength(2)]
        public string FirstName {get;set;}

        [Required]
        [MinLength(2)]
        public string LastName {get;set;}

        [Required]
        [EmailAddress]
        public string Email {get;set;}
        
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password {get;set;}

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Compare("Password")]
        public string ConfirmPassword {get;set;}

    }
}