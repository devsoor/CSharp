using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ViewModelFun.Models
{
    public class MyInt
    {
        public string SomeInt {get;set;}
        public MyInt(int i)
        {
            SomeInt = i;
        }
    }
}