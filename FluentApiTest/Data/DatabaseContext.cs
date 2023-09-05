using FluentApiTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace FluentApiTest.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) :base (options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasKey(b => b.Id);
            modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired();
            modelBuilder.Entity<Book>().HasOne(a => a.Author).WithMany(b => b.Books).HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Author>().HasKey(a => a.Id);
            modelBuilder.Entity<Author>().HasMany(a => a.Books).WithOne(b => b.Author);

            modelBuilder.Entity<Publisher>().HasKey(p => p.Id);
            modelBuilder.Entity<Publisher>().Property(p => p.Name).IsRequired();

            modelBuilder.Entity<Publisher>()
                .HasMany(p => p.Authors)
                .WithMany(a => a.Publishers)
                .UsingEntity("PublisherAuthors");

            modelBuilder.Entity<Publisher>()
                .HasData(new Publisher
                {
                    Id = 1,
                    Name = "Denmark Publishing",
                });

            modelBuilder.Entity<Author>()
                .HasData(
                new Author 
                { 
                    Id = 1, 
                    Name = "Morten Vestergaard",
                });

            modelBuilder.Entity<Author>()
                .HasData(
                new Author 
                { 
                    Id = 2, 
                    Name = "Asger Jørgensen",
                });

            modelBuilder.Entity<Book>().HasData(new Book { Id = 1, Title = "The Big Evil", AuthorId = 1 });
            modelBuilder.Entity<Book>().HasData(new Book { Id = 2, Title = "Bowl", AuthorId = 1 });
            modelBuilder.Entity<Book>().HasData(new Book { Id = 3, Title = "Redemption at the Valley", AuthorId = 2 });
            modelBuilder.Entity<Book>().HasData(new Book { Id = 4, Title = "At Bay", AuthorId = 2 });

        }
    }
}
