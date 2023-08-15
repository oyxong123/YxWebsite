using YxWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace YxWebsite.Context
{
    public class ApplicationDbContext : DbContext // DbContext is inherited from EF Core SQL Server.
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        // Set the database table reference names
       public DbSet<JapaneseDictionaryModel> DbJapaneseDictionary { get; set; }
       public DbSet<LanguageCottageModel> DbLanguageCottage { get; set; }
    }
}
