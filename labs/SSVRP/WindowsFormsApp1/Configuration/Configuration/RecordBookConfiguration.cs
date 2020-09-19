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
            builder.Property(x => x.NumberOfRecordBook).IsRequired();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Course).IsRequired();
            builder.HasOne(x => x.Group).WithMany(x => x.ListRecordBooks).HasForeignKey(x=>x.GroupId);
        }
    }
}