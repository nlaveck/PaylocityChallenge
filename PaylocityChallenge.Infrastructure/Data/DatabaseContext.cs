using Microsoft.EntityFrameworkCore;
using PaylocityChallenge.Core.Entities;
using System;

namespace PaylocityChallenge.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<EmployeePay> EmployeePay { get; set; }
    }
}
