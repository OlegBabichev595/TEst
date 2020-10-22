using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configurations
{
    internal sealed class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.ToTable(nameof(BookAuthor));

            builder.HasKey(x => new {x.BookId, x.AuthorId});

            builder.HasOne(x => x.Author).WithMany(x => x.BookAuthor).HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Book).WithMany(x => x.BookAuthor).HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}