using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ViewModelFun.Models
{
    public class User
    {
        public string Name {get;set;}
        public User(string name)
        {
            Name = name;
        }
    }
}