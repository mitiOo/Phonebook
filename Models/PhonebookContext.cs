using Microsoft.EntityFrameworkCore;

namespace Phonebook.Models
{
    public class PhonebookContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"(localdb)\MSSQLLocalDB;InitialCatalog=Phonebook;IntegratedSecurity=True");
        }
    }
}
