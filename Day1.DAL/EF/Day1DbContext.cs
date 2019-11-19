using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Day1.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Day1.DAL.EF
{
    public class Day1DbContext : IdentityDbContext<Employee>
    {
        public Day1DbContext()
        {
        }

        public Day1DbContext(DbContextOptions<Day1DbContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
