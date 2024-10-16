using Microsoft.EntityFrameworkCore;
using Sdeniz.Entities;

namespace Sdeniz.Data
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        
        public DbSet<Musteri> Musteri { get; set; }
        public DbSet<Post> Rol { get; set; }
        public DbSet<Satici> Satici { get; set; }
        public DbSet<Satis> Satis { get; set; }
        public DbSet<Urun> Urun { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Genel",
                    Image = "default-image.jpg",
                    IsActive = true,
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    IsActive = true,
                    IsAdmin = true,
                    Name = "Admin",
                    Surname = "User",
                    Email = "admin@sarideniz.com",
                    Password = "Lebron234",
                    UserName = "Admin",
                }
            );

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=SdenizDb;User Id=SA;Password=Lebron234gizem;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}