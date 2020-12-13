using PaylocityChallenge.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaylocityChallenge.Infrastructure.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeeListingAsync();
        Task Add(Employee employee);
    }
}