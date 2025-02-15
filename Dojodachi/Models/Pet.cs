using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using System.ComponentModel.DataAnnotations;

namespace Dojodachi.Models
{
    public class Pet
    {
        public int Happiness {get; set;}
        
        public int Fullness {get; set;}

        public int Energy {get; set;}
        

        public int Meals {get; set;}
        public Pet()
        {
            Happiness = 20;
            Fullness = 20;
            Energy = 50;
            Meals = 3;
        }
    }
}