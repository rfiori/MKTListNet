using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKTListNet.Domain.Entities;

namespace MKTListNet.Data.EntityConfig
{
    internal class EmailConfig : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.ToTable("Email");

            builder.HasKey(x => x.EmailId);

            builder.Property(x => x.EmailAddress)
                .HasColumnType("vachar")
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(x => x.EmailAddress);
        }
    }
}
