using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configurations
{
    internal sealed class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable(nameof(Book));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(1024);
            builder.Property(x => x.Description);
            builder.Property(x => x.PublishingDate).HasColumnType("date");
            builder.Property(x => x.Rating).HasColumnType("float");
            builder.Property(x => x.CoverUrl);
            builder.Property(x => x.PublisherId);

            builder.HasOne(x => x.Publisher).WithMany().HasForeignKey(x => x.PublisherId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}