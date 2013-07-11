using System.Data.Entity.ModelConfiguration;
using JamieWroeDotCom.Models;

namespace JamieWroeDotCom.Data.Configuration.Entities
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(p => p.Id).HasColumnOrder(0);

            Property(p => p.UsertName).IsRequired()
                                      .HasMaxLength(200);

            Property(p => p.FirstName).HasMaxLength(100);

            Property(p => p.LastName).HasMaxLength(100);
        }
    }
}