using ClassLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        public DbSet<User> Users { get; set; }

        public DbSet<Branch> Branchs { get; set; }

        public DbSet<Bank> Bank { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<District> Districts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed Data
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(new User() { Id = 1, UserName = "admin", Password = "admin" });
            modelBuilder.Entity<Branch>().HasData(new Branch() { Id = 1, BranchName = "Default Branch", IFSCCode = "BR001", Bank = 1, District = 1, State = 1 });

            modelBuilder.Entity<Bank>().HasData(new Bank() { Id = 1, Code = "Bank1", Name = "Bank 1" });
            modelBuilder.Entity<Bank>().HasData(new Bank() { Id = 2, Code = "Bank2", Name = "Bank 2" });
            modelBuilder.Entity<Bank>().HasData(new Bank() { Id = 3, Code = "Bank3", Name = "Bank 3" });
            modelBuilder.Entity<Bank>().HasData(new Bank() { Id = 4, Code = "Bank4", Name = "Bank 4" });

            modelBuilder.Entity<State>().HasData(new State() { Id = 1, Code = "Punjab", Name = "Punjab" });
            modelBuilder.Entity<State>().HasData(new State() { Id = 2, Code = "MadhyaPradesh", Name = "MadhyaPradesh" });
            modelBuilder.Entity<State>().HasData(new State() { Id = 3, Code = "Maharashtra", Name = "Maharashtra" });

            modelBuilder.Entity<District>().HasData(new District() { Id = 1, Code = "Amritsar", Name = "Amritsar", StateID = 1 });
            modelBuilder.Entity<District>().HasData(new District() { Id = 2, Code = "Pathankot", Name = "Pathankot", StateID = 1 });
            modelBuilder.Entity<District>().HasData(new District() { Id = 3, Code = "Indore", Name = "Indore", StateID = 2 });
            modelBuilder.Entity<District>().HasData(new District() { Id = 4, Code = "Bhopal", Name = "Bhopal", StateID = 2 });
            modelBuilder.Entity<District>().HasData(new District() { Id = 5, Code = "Pune", Name = "Pune", StateID = 3 });
            modelBuilder.Entity<District>().HasData(new District() { Id = 6, Code = "Mumbai", Name = "Mumbai", StateID = 3 });

        }
    }
}
