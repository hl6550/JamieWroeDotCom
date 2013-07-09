using System.Data.Entity.ModelConfiguration;
using JamieWroeDotCom.Models;

namespace JamieWroeDotCom.Data.Configuration
{
    internal class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            Property(p => p.Author).IsRequired()
                                   .HasMaxLength(100);

            Property(p => p.Blurb).HasColumnType("TEXT");

            Property(p => p.Content).HasColumnType("LONGTEXT");

            Property(p => p.CreationDate).IsRequired()
                                         .HasColumnName("datetime");

            Property(p => p.Id).IsRequired()
                               .HasColumnOrder(0);

            Property(p => p.Status).IsRequired();

            Property(p => p.Title).IsRequired();
        }
    }
}