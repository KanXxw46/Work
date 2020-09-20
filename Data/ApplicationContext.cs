using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Data 
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        public ApplicationContext()
        {
            Database.Migrate();
        }

        private readonly string connectionString;
        public ApplicationContext(string connectionString)
        {
            this.connectionString = connectionString;

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database = OnlineShop;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("application_users")
                .HasKey(user => user.Id)
                .HasName("id");

            modelBuilder.Entity<User>()
                .Property(user => user.Email)
                .HasMaxLength(12)
                .IsRequired()
                .HasColumnName("Email");

            modelBuilder.Entity<Profile>()
                .HasOne(user => user.User)
                .WithOne(profile => profile.Profile)
                .HasForeignKey("User");

            User user = new User
            {
                Email = "edumark@mail.ru",
                Phone = "88005553535",
                Password = "2004andrei"
            };

            Profile profile = new Profile
            {
                Address = "//www.http.Lerons"
            };

            var ProfileId = profile.Id;
            var UserId = user.Id;

            modelBuilder.Entity<Profile>()
                .HasData(profile);
            modelBuilder.Entity<User>()
            .HasData(user);
        }
    }
}

