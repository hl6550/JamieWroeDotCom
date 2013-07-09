using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using JamieWroeDotCom.Data.Configuration;

namespace JamieWroeDotCom.Data
{
    using System.Configuration;
    using System.Data.Entity;
    using Models;

    public class DataContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        public static string ConnectionString
        {
            get { return ConfigurationManager.AppSettings["ConnectionStringName"] ?? "DefaultConnection"; }
        }

        public DataContext() : base(ConnectionString)
        {
        }

        static DataContext()
        {
            Database.SetInitializer(new CustomDatabaseInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }

        private void ApplyRules()
        {
            UpdateTimeStamps();
        }

        private void UpdateTimeStamps()
        {
            var changedEntries = ChangeTracker.Entries<IAuditInfo>()
                                              .Where(e => e.State == EntityState.Added ||
                                                          e.State == EntityState.Modified);

            foreach (var entry in changedEntries)
            {
                UpdateTimeStamp(entry);
            }
        }

        private static void UpdateTimeStamp(DbEntityEntry<IAuditInfo> entry)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreationDate = DateTime.Now;
            }

            entry.Entity.LastModified = DateTime.Now;
        }

        public override int SaveChanges()
        {
            ApplyRules();
            return base.SaveChanges();
        }
    }
}