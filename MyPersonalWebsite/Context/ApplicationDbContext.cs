using MyPersonalWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace MyPersonalWebsite.Context
{
    public class ApplicationDbContext : DbContext // DbContext is inherited from EF Core SQL Server.
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        // Set the database table reference names
       public DbSet<JapaneseDictionary> DbJapaneseDictionary { get; set; }
       public DbSet<LanguageCottage> DbLanguageCottage { get; set; }
    }
}
