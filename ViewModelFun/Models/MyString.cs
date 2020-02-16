using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ViewModelFun.Models
{
    public class MyString
    {
        public string SomeString {get;set;}
        public MyString(string str)
        {
            SomeString = str;
        }
    }
}