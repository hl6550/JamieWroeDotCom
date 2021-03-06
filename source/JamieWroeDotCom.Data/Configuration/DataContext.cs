﻿using System;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using JamieWroeDotCom.Data.Annotations;
using JamieWroeDotCom.Data.Configuration.Entities;
using JamieWroeDotCom.Models;

namespace JamieWroeDotCom.Data.Configuration
{
    [UsedImplicitly]
    public class DataContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        private static string ConnectionString
        {
            get { return "DefaultConnection"; }
        }

        public DataContext() : base(ConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new MembershipConfiguration());
            modelBuilder.Configurations.Add(new OAuthMembershipConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
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