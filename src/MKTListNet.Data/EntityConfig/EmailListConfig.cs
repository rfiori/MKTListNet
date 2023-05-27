using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKTListNet.Domain.Entities;

namespace MKTListNet.Infra.EntityConfig
{
    internal class EmailListConfig : IEntityTypeConfiguration<EmailList>
    {
        public void Configure(EntityTypeBuilder<EmailList> builder)
        {
            builder.ToTable("EmailList");

            builder.HasKey(x => x.ListId);

            builder.Property(x => x.Name)
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Type)
                .HasColumnType("varchar(10)")
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
