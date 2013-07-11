using System.Data.Entity.ModelConfiguration;
using JamieWroeDotCom.Models;

namespace JamieWroeDotCom.Data.Configuration.Entities
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(p => p.Id).HasColumnOrder(0);

            Property(p => p.UserName).IsRequired()
                                     .HasMaxLength(200);

            Property(p => p.FirstName).HasMaxLength(100);

            Property(p => p.LastName).HasMaxLength(100);

            HasMany(a => a.Roles).WithMany(b => b.Users)
                                 .Map(m =>
                                      {
                                          m.MapLeftKey("UserId");
                                          m.MapRightKey("RoleId");
                                          m.ToTable("webpages_UsersInRoles");
                                      });
        }
    }
}