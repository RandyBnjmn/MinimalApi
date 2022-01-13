using Microsoft.EntityFrameworkCore;
using MinimalAPI.Models;

namespace MinimalAPI
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Tasks> Tasks { get; set; }
    }
}
