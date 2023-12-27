using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKTListNet.Domain.Entities;

namespace MKTListNet.Infra.EntityConfig
{
    internal class EmailEmailListConfig : IEntityTypeConfiguration<EmailEmailList>
    {
        public void Configure(EntityTypeBuilder<EmailEmailList> builder)
        {
            builder.ToTable("EmailEmailList");

            builder.HasKey(x => new { x.EmailId, x.EmailListId });

            builder.Property(x => x.EmailId)
                .HasColumnType("varchar(50)");
        }
    }
}
