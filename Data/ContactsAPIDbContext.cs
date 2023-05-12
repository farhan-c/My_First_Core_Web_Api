using Core_Web_Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Core_Web_Api.Data
{
    public class ContactsAPIDbContext : DbContext
    {
        public ContactsAPIDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Contact> Contacts { get; set; }    

    }
}
