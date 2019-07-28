using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infra.Mapping
{
    public class BookAuthorMap : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.ToTable("book_author");

            builder.HasKey(ba => new { ba.AuthorId, ba.BookId });

            builder.HasOne<Author>(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);

            builder.HasOne<Book>(ba => ba.Book)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.BookId);
        }
    }
}
