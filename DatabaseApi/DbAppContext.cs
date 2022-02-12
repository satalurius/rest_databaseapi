using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



#nullable disable

namespace DatabaseApi
{
    public partial class DbAppContext : DbContext
    {
        
        public DbAppContext()
        {
        }

        public DbAppContext(DbContextOptions<DbAppContext> options)
            : base(options)
        {
        }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();

            string connectionString = config.GetConnectionString("DefaultSqliteConnection");

            return connectionString;
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomersAddress> CustomersAddresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = GetConnectionString();

            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlite(connectionString);
            }
        }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CtrNumber);

                entity.ToTable("customers");

                entity.HasIndex(e => e.Email, "IX_customers_email")
                    .IsUnique();

                entity.Property(e => e.CtrNumber)
                    .HasColumnType("INTEGER")
                    .HasColumnName("ctr_number");

                entity.Property(e => e.CurrentBalance)
                    .IsRequired()
                    .HasColumnType("DECIMAL(6, 2)")
                    .HasColumnName("current_balance");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)")
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("VARCHAR(30)")
                    .HasColumnName("last_name");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)")
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<CustomersAddress>(entity =>
            {
                entity.HasKey(e => e.CasId);

                entity.ToTable("customers_addresses");

                entity.Property(e => e.CasId)
                    .HasColumnType("INTEGER")
                    .HasColumnName("cas_id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnType("VARCHAR(15)")
                    .HasColumnName("city");

                entity.Property(e => e.CtrNumber)
                    .IsRequired()
                    .HasColumnType("INTEGER")
                    .HasColumnName("ctr_number");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnType("VARCHAR(7)")
                    .HasColumnName("postal_code");

                entity.HasOne(d => d.CtrNumberNavigation)
                    .WithMany(p => p.CustomersAddresses)
                    .HasForeignKey(d => d.CtrNumber)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
