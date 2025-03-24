using LibraryApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryApi.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        // DbSet Tanımları (Tablolar)
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Personnel> Personnel { get; set; }
        public DbSet<Lend> Lends { get; set; }
        public DbSet<LendDetail> LendDetails { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockLog> StockLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API ile İlişkiler ve Kurallar
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<Lend>()
                .HasOne(l => l.Personnel)
                .WithMany()
                .HasForeignKey(l => l.PersonnelId);

            modelBuilder.Entity<LendDetail>()
                .HasOne(ld => ld.Book)
                .WithMany()
                .HasForeignKey(ld => ld.BookId);

            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Book)
                .WithOne()
                .HasForeignKey<Stock>(s => s.BookId);

            modelBuilder.Entity<StockLog>()
                .HasOne(sl => sl.Personnel)
                .WithMany()
                .HasForeignKey(sl => sl.PersonnelId);
        }
    }
}