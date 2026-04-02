using Microsoft.EntityFrameworkCore;

namespace HandsOnEFCodeFirstRelations.Entities
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=TestDb42;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.BookId);
                entity.ToTable("Books");

                // Title Configuration
                entity.Property(b => b.Title)
                    .IsRequired()
                    .HasColumnType("varchar")
                    .HasMaxLength(50);

                // Author
                entity.Property(b => b.Author)
                    .IsRequired()
                    .HasMaxLength(50);

                // Price
                entity.Property(b => b.Price)
                    .HasColumnType("decimal(18,2)")
                    .HasDefaultValue(0);

                // Publish Date
                entity.Property(b => b.PublishDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("GetDate()");

                // Updated Seed Data with 2 records
                entity.HasData(
                    new Book()
                    {
                        BookId = 1,
                        Title = "Asp.net Core MVC",
                        Author = "Microsoft",
                        Price = 1200,
                        PublishDate = new DateTime(2021, 12, 23)
                    },
                    new Book()
                    {
                        BookId = 2,
                        Title = "Angular 20.1",
                        Author = "Google",
                        Price = 2000,
                        PublishDate = new DateTime(2025, 12, 23)
                    }
                );
            });
        }
    }
}