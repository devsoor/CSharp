using System;

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SimpleLogin.Models
{
    public class IndexViewModel
    {
        public RegUser NewRegUser {get; set;}
        public LogUser NewLogUser {get; set;}
    }
}