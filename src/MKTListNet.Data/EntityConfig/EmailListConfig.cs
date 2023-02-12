using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKTListNet.Domain.Entities;

namespace MKTListNet.Data.EntityConfig
{
    internal class EmailListConfig : IEntityTypeConfiguration<EmailList>
    {
        public void Configure(EntityTypeBuilder<EmailList> builder)
        {
            builder.ToTable("EmailList");

            builder.HasKey(x => x.ListId);

            builder.Property(x => x.ListName)
                .HasColumnType("vachar")
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
