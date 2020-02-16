using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace LoginRegister.Models
{
    public class IndexViewModel
    {
        public User NewRegUser {get; set;}
        public LoginUser NewLogUser {get; set;}
    }
}