using Microsoft.EntityFrameworkCore;

namespace LoginRegister.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get; set;}
        public DbSet<LoginUser> LoginUsers {get; set;}
    }
}