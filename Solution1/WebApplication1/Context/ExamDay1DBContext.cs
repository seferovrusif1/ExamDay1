using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class ExamDay1DBContext:IdentityDbContext
    {
        public ExamDay1DBContext(DbContextOptions options) : base(options){}

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<News> News { get; set; }
   

    }
}
