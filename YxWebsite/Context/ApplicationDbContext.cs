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

        // Set the database table reference names.
       public DbSet<JapaneseDictionaryModel> DbJapaneseDictionary { get; set; }
       public DbSet<LcModel> DbLanguageCottage { get; set; }
       public DbSet<LcCategoryModel> DbLanguageCottageCategory { get; set; }
       public DbSet<AuditTrailsModel> DbAuditTrails { get; set;}
       public DbSet<LoginModel> DbLogin { get; set; }
    }
}
