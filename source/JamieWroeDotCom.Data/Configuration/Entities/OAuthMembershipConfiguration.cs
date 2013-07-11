using System.Data.Entity.ModelConfiguration;
using JamieWroeDotCom.Models;

namespace JamieWroeDotCom.Data.Configuration.Entities
{
    public class OAuthMembershipConfiguration : EntityTypeConfiguration<OAuthMembership>
    {
        public OAuthMembershipConfiguration()
        {
            ToTable("webpages_OAuthMembership");

            HasKey(k => new { k.Provider, k.ProviderUserId });

            Property(p => p.Provider).HasMaxLength(30)
                                     .IsRequired()
                                     .HasColumnType("nvarchar");

            Property(p => p.ProviderUserId).HasMaxLength(100)
                                           .IsRequired()
                                           .HasColumnType("nvarchar");

            Property(p => p.UserId).IsRequired();
        }
    }
}