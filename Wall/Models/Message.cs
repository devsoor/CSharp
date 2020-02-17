using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Wall.Models;

namespace Wall.Models
{
    public class Message
    {
        public int MessageId {get;set;}
        public string TheMessage {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public int UserId {get;set;}
        public User User {get;set;}
        public List<Comment> Comments {get;set;}
    }

} 