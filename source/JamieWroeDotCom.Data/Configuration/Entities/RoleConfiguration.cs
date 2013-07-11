using System.Data.Entity.ModelConfiguration;
using JamieWroeDotCom.Models;

namespace JamieWroeDotCom.Data.Configuration.Entities
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            ToTable("webpages_Roles");
            HasKey(p => p.RoleId);
            Property(p => p.RoleName).HasMaxLength(256)
                                     .IsRequired();
        }
    }
}