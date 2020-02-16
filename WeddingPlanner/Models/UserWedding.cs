using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Models
{
    public class UserWedding
    {
        public int UserWeddingId {get; set;}
        public int UserId {get; set;}
        public int WeddingId {get; set;}
        public User User {get;set;}
        public Wedding Wedding {get;set;}

    }
}