using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;

namespace PhoneBook.Data
{
    class PhoneBookContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }


        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=PhoneBook.db");
        }
    }
}