using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class CarRentalContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {  
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CarRental;Trusted_Connection=true");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CarModel(modelBuilder);
            ColorModel(modelBuilder);
            BrandModel(modelBuilder);
            UserModel(modelBuilder);
            CustomerModel(modelBuilder);
            RentalModel(modelBuilder);
        }

        private static void RentalModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>().ToTable("Rentals", "dbo");

            modelBuilder.Entity<Rental>().Property(r => r.RentalId).HasColumnName("RentalId");
            modelBuilder.Entity<Rental>().Property(r => r.CarId).HasColumnName("CarId");
            modelBuilder.Entity<Rental>().Property(r => r.CustomerId).HasColumnName("CustomerId");
            modelBuilder.Entity<Rental>().Property(r => r.RentDate).HasColumnName("RentDate");
            modelBuilder.Entity<Rental>().Property(r => r.ReturnDate).HasColumnName("ReturnDate");
        }

        private static void CustomerModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers", "dbo");

            modelBuilder.Entity<Customer>().Property(c => c.CustomerId).HasColumnName("CustomerId");
            modelBuilder.Entity<Customer>().Property(c => c.CompanyName).HasColumnName("CompanyName");
            modelBuilder.Entity<Customer>().Property(c => c.UserId).HasColumnName("UserId");
        }

        private static void UserModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users", "dbo");

            modelBuilder.Entity<User>().Property(u => u.UserId).HasColumnName("UserId");
            modelBuilder.Entity<User>().Property(u => u.FirstName).HasColumnName("FirstName");
            modelBuilder.Entity<User>().Property(u => u.LastName).HasColumnName("LastName");
            modelBuilder.Entity<User>().Property(u => u.Email).HasColumnName("Email");
            modelBuilder.Entity<User>().Property(u => u.Password).HasColumnName("Password");
        }

        private static void BrandModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().ToTable("Brands", "dbo");

            modelBuilder.Entity<Brand>().Property(b => b.BrandId).HasColumnName("BrandId");
            modelBuilder.Entity<Brand>().Property(b => b.BrandName).HasColumnName("BrandName");
        }

        private static void ColorModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>().ToTable("Colors", "dbo");

            modelBuilder.Entity<Color>().Property(c => c.ColorId).HasColumnName("ColorId");
            modelBuilder.Entity<Color>().Property(c => c.ColorName).HasColumnName("ColorName");
        }

        protected void CarModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Cars", "dbo");

            modelBuilder.Entity<Car>().Property(c => c.CarId).HasColumnName("CarId");
            modelBuilder.Entity<Car>().Property(c => c.BrandId).HasColumnName("BrandId");
            modelBuilder.Entity<Car>().Property(c => c.ColorId).HasColumnName("ColorId");
            modelBuilder.Entity<Car>().Property(c => c.DailyPrice).HasColumnName("DailyPrice");
            modelBuilder.Entity<Car>().Property(c => c.Description).HasColumnName("Description");
            modelBuilder.Entity<Car>().Property(c => c.ModelYear).HasColumnName("ModelYear");
        }

    }
}