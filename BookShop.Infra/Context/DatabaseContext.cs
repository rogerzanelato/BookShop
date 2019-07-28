using Microsoft.EntityFrameworkCore;
using BookShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using BookShop.Infra.Mapping;

namespace BookShop.Infra.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=bookshop;Integrated Security=true;MultipleActiveResultSets=true");
                // optionsBuilder.UseMySql("server=localhost;port=3306;database=default-db;uid=admin;password=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(new BookMap().Configure);
            modelBuilder.Entity<Genre>(new GenreMap().Configure);
            modelBuilder.Entity<Author>(new AuthorMap().Configure);
            modelBuilder.Entity<BookAuthor>(new BookAuthorMap().Configure);
            modelBuilder.Entity<BookGenre>(new BookGenreMap().Configure);

            base.OnModelCreating(modelBuilder);
        }
    }
}
