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
        public DbSet<City> Cities => Set<City>();

        public DbSet<Country> Countries => Set<Country>();

        public DbSet<State> States => Set<State>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Modelo de Countries
            modelBuilder.Entity<Country>().HasIndex(x=> x.Name).IsUnique();

            //Modelo de Estado
            modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique();

            //Modelo de Ciudad
            modelBuilder.Entity<City>().HasIndex("Name", "StateId").IsUnique();



        }

    }
}

