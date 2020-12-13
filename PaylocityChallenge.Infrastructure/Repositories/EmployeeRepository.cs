using Microsoft.EntityFrameworkCore;
using PaylocityChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityChallenge.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private DatabaseContext _context;
        public EmployeeRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetEmployeeListingAsync()
        {
            return await _context.Employees.Include(e => e.Pay).ToListAsync();
        }

        public async Task Add(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
        }
    }
}
