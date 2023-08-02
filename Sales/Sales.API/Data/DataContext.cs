using System;
using Microsoft.EntityFrameworkCore;
using Sales.Shared.Entities;

namespace Sales.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Country> Countries => Set<Country>();



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Modelo de Countries
            modelBuilder.Entity<Country>().HasIndex(x=> x.Name).IsUnique();




        }

    }
}

