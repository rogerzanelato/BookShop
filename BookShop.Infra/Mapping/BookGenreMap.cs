using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infra.Mapping
{
    public class BookGenreMap : IEntityTypeConfiguration<BookGenre>
    {
        public void Configure(EntityTypeBuilder<BookGenre> builder)
        {
            builder.ToTable("book_genre");

            builder.HasKey(bg => new { bg.GenreId, bg.BookId });

            builder.HasOne<Genre>(ba => ba.Genre)
                .WithMany(g => g.BookGenres)
                .HasForeignKey(bg => bg.GenreId);

            builder.HasOne<Book>(ba => ba.Book)
                .WithMany(a => a.BookGenres)
                .HasForeignKey(ba => ba.BookId);
        }
    }
}
