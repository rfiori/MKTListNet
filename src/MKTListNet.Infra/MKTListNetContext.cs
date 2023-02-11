using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MKTListNet.CrossCutting.Shared;

namespace MKTListNet.Infra
{
    public class MKTListNetContext : IdentityDbContext<MKTListNetUser>
    {
        const string _AdminGuid = "00000001-AAAA-BBBB-CCCC-01A02B03C04D", _AdminName = "admin@admin.com";

        public MKTListNetContext(DbContextOptions<MKTListNetContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //builder.Entity("MKTListNet.Areas.Identity.Data.MKTListNetUser", b =>
            builder.Entity("MKTListNet.Infra.MKTListNetUser", b =>
            {
                b.Property<string>("FullName")
                    .HasColumnType("nvarchar(80)");
            });

            SeedDataIntity(builder);
        }

        private void SeedDataIntity(ModelBuilder builder)
        {
            // Add User.
            builder.Entity<MKTListNetUser>().HasData(
                new MKTListNetUser
                {
                    Id = new Guid(_AdminGuid).ToString(),
                    UserName = _AdminName,
                    NormalizedUserName = _AdminName.ToUpper(),
                    FullName = "Admin",
                    Email = _AdminName,
                    NormalizedEmail = _AdminName.ToUpper(),
                    PasswordHash = new PasswordHasher<MKTListNetUser>().HashPassword(null, "admin"),
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    CreateOn = DateTime.UtcNow
                });

            // Add Claim.
            builder.Entity<IdentityUserClaim<string>>().HasData(
                new IdentityUserClaim<string>
                {
                    Id = 1,
                    UserId = new Guid(_AdminGuid).ToString(),
                    ClaimType = ClaimName.ADMIN,
                    ClaimValue = ClaimPermission.FullAccess
                });
        }
    }
}
