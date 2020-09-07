using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Configuration.Configuration
{
    public class RecordBookConfiguration: IEntityTypeConfiguration<RecordBook>
    {
        public void Configure(EntityTypeBuilder<RecordBook> builder)
        {
            builder.ToTable(nameof(RecordBook));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NumberOfRecordBook).HasColumnType("int").IsRequired();
            builder.Property(x => x.FirstName).HasColumnType("nvarchar(30)").IsRequired().HasMaxLength(30);
            builder.Property(x => x.LastName).HasColumnType("nvarchar(30)").IsRequired().HasMaxLength(30);
            builder.Property(x => x.Course).HasColumnType("int").IsRequired();
            builder.HasOne(x => x.Group).WithMany(x => x.ListRecordBooks);
        }
    }
}