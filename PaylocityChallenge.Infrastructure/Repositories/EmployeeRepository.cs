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
            return await _context.Employees
                .Include(e => e.PaycheckPay)
                .Include(e => e.AnnualPay)
                .ToListAsync();
        }

        public async Task Add(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var employee = new Employee{ Id = id };
            _context.Employees.Attach(employee);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> Get(int id)
        {
            return await _context.Employees.Include(e => e.Dependents).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
