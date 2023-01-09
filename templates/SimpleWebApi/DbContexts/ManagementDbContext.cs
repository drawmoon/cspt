﻿using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Models.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebApi.DbContexts
{
    public class ManagementDbContext : DbContext
    {
        public ManagementDbContext(DbContextOptions<ManagementDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>(e =>
            {
                e.ToTable("employee");

                e.Property(p => p.Id)
                    .HasColumnName("id");

                e.Property(p => p.Name)
                    .HasColumnName("name")
                    .HasMaxLength(8);

                e.Property(p => p.Age)
                    .HasColumnName("age")
                    .HasPrecision(2);
            });
        }
    }
}
