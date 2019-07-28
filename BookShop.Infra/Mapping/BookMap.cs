using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infra.Mapping
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("book");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("title");

            builder.Property(c => c.Description)
                .HasColumnName("description");

            builder.Property(c => c.Pages)
                .HasColumnName("pages");

            builder.Property(c => c.Isbn10)
                .HasMaxLength(10)
                .HasColumnName("isbn10");

            builder.Property(c => c.Isbn13)
                .HasMaxLength(13)
                .HasColumnName("isbn13");

            builder.Property(c => c.EditionYear)
                .HasColumnName("editionyear");

            builder.Property(c => c.Stock)
                .IsRequired()
                .HasColumnName("stock");
        }
    }
}
