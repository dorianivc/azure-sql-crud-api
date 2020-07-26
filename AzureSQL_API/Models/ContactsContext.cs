using Microsoft.EntityFrameworkCore;
namespace AzureSQL_API.Models
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<Contacts> ContacsSet{get; set;}

    }
}