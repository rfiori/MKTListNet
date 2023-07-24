using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKTListNet.Domain.Entities;

namespace MKTListNet.Infra.EntityConfig
{
    internal class EmailConfig : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.ToTable("Email");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(x => x.EmailAddress)
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(x => x.EmailAddress);


            // ForeignKey
            builder.HasMany(email => email.EmailList)
                .WithMany(emailList => emailList.Email)
                .UsingEntity<EmailEmailList>(
                    j => j.HasOne<EmailList>().WithMany().HasForeignKey(eel => eel.EmailListId),
                    j => j.HasOne<Email>().WithMany().HasForeignKey(eel => eel.EmailId),
                    j =>
                    {
                        j.HasKey(eel => new { eel.EmailId, eel.EmailListId });
                        // j.ToTable("EmailEmailList");
                    });
        }
    }
}
