using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_MovieShop_.Models;

namespace MVC_MovieShop_.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<RentalHeader> RentalHeaders { get; set; }
        public DbSet<RentalDetail> RentalDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Movie Configuration
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(m => m.MovieId);
                entity.Property(m => m.Title)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(m => m.Genre)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(m => m.Director)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(m => m.Stock)
                    .IsRequired();
            });

            // Customer Configuration
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerId);
                entity.Property(c => c.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(c => c.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(c => c.Email)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(c => c.Phone)
                    .HasMaxLength(50);
                entity.Property(c => c.Address)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(c => c.DateOfBirth)
                    .IsRequired();
            });

            // RentalHeader Configuration
            modelBuilder.Entity<RentalHeader>(entity =>
            {
                entity.HasKey(rh => rh.Id);
                entity.HasOne(rh => rh.CustomerDetails)
                    .WithMany(c => c.RentalHeaders)
                    .HasForeignKey(rh => rh.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.Property(rh => rh.RentalDate)
                    .HasDefaultValueSql("GETDATE()");
            });

            // RentalDetail Configuration
            modelBuilder.Entity<RentalDetail>(entity =>
            {
                entity.HasKey(rd => rd.Id);
                entity.Property(rd => rd.Id)
                    .ValueGeneratedOnAdd();
                entity.Property(rd => rd.RentalFee)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(rd => rd.RentalHeader)
                    .WithMany(rh => rh.RentalDetails)
                    .HasForeignKey(rd => rd.RentalHeaderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(rd => rd.Movie)
                    .WithMany()
                    .HasForeignKey(rd => rd.MovieId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }

}
