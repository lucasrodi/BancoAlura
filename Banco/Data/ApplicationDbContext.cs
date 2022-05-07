using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Banco.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            IdentityUser admin = new IdentityUser
            {
            UserName = "admin@admin.com",
            NormalizedUserName = "ADMIN@ADMIN.COM",
            Email ="admin@admin.com",
            NormalizedEmail="ADMIN@ADMIN.COM",
            EmailConfirmed =true,
            SecurityStamp =Guid.NewGuid().ToString(),
            Id = "99999",
            };
            PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = hasher.HashPassword(admin, "Admin123!");
            builder.Entity<IdentityUser>().HasData(admin);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "99999",Name="admin",NormalizedName="ADMIN"});
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId ="99999",UserId="99999"});

        }
      
    }
}