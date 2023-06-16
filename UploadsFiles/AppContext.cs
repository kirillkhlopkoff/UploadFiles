using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using UploadsFiles.Models;

namespace UploadsFiles
{
    public class AppContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Person> People { get; set; }
        public AppContext(DbContextOptions<AppContext> options, IConfiguration configuration)
            : base(options)
        {
            Database.EnsureCreated();
            _configuration = configuration;
        }
    }
}
