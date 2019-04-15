using Microsoft.EntityFrameworkCore;

namespace WeddingPlaner.Models
{
    public class WeddingContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public WeddingContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Wedding> Weddings{get;set;}
        public DbSet<Attendence> Attendences{get;set;}


    }
}