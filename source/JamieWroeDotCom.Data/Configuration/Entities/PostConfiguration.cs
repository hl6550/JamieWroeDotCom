using System.Data.Entity.ModelConfiguration;
using JamieWroeDotCom.Models;

namespace JamieWroeDotCom.Data.Configuration.Entities
{
    internal class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            Property(p => p.CreationDate).IsRequired()
                                         .HasColumnName("datetime");

            Property(p => p.Id).IsRequired()
                               .HasColumnOrder(0);

            Property(p => p.Title).IsRequired()
                                  .HasMaxLength(200);
        }
    }
}