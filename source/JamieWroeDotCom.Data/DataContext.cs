namespace JamieWroeDotCom.Data
{
    using System.Configuration;
    using System.Data.Entity;

    using JamieWroeDotCom.Models;

    public class DataContext : DbContext
    {

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        public static string ConnectionString
        {
            get { return ConfigurationManager.AppSettings["ConnectionStringName"] ?? "DefaultConnection"; }
        }

        public DataContext() : base(ConnectionString) {}

    }
}