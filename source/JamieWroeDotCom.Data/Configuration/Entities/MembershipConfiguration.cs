using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using JamieWroeDotCom.Models;

namespace JamieWroeDotCom.Data.Configuration.Entities
{
    internal class MembershipConfiguration : EntityTypeConfiguration<Membership>
    {
        public MembershipConfiguration()
        {
            ToTable("webpages_Membership");
            HasKey(p => p.UserId);

            Property(p => p.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(p => p.ConfirmationToken).HasMaxLength(128)
                                              .HasColumnType("nvarchar");

            Property(p => p.PasswordFailuresSinceLastSuccess).IsRequired();

            Property(p => p.Password).IsRequired()
                                     .HasMaxLength(128)
                                     .HasColumnType("nvarchar");

            Property(p => p.PasswordSalt).IsRequired()
                                         .HasColumnType("nvarchar")
                                         .HasMaxLength(128);

            Property(p => p.PasswordVerificationToken).HasMaxLength(128)
                                                      .HasColumnType("nvarchar");
        }
    }
}