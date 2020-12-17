using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaylocityChallenge.Api.Dtos.Partial;
using PaylocityChallenge.Api.Dtos.Requests;
using PaylocityChallenge.Api.Dtos.Responses;
using PaylocityChallenge.Core.Entities;
using PaylocityChallenge.Core.Services;
using PaylocityChallenge.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaylocityChallenge.Api.Controllers
{
    /// <summary>
    /// The employee class
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="employeeRepository"></param>
        public EmployeesController(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }


        /// <summary>
        /// Previews the costs of the employee
        /// </summary>
        /// <param name="request">payload containing name of the employee and the dependents</param>
        /// <returns>200</returns>
        [HttpPost("preview")]
        public ActionResult<PreviewEmployeeCostsResponse> PreviewCosts([FromServices] IPayrollService payrollService, [FromBody] PreviewEmployeeCostRequest request)
        {
            var response = new PreviewEmployeeCostsResponse();
            var employee = _mapper.Map<Employee>(request.Employee);
            payrollService.CalculatePay(employee);
            response.AnnualPay = _mapper.Map<EmployeePayDto>(employee.AnnualPay);
            response.PaycheckPay = _mapper.Map<EmployeePayDto>(employee.PaycheckPay);
            return response;
        }

        /// <summary>
        /// Persists the employee to the database
        /// </summary>
        /// <param name="payrollService"></param>
        /// <param name="request">payload containing name of the employee and the dependents</param>
        /// <returns>204</returns>
        [HttpPost("create")]
        public async Task<IActionResult> Save([FromServices] IPayrollService payrollService, [FromBody] SaveEmployeeRequest request)
        {
            var employee = _mapper.Map<Employee>(request.Employee);
            payrollService.CalculatePay(employee);
            await _employeeRepository.Add(employee);
            return NoContent();
        }


        /// <summary>
        /// Gets a list of all the employees
        /// </summary>
        /// <returns>200</returns>
        [HttpGet("index")]
        public async Task<EmployeeListingResponse> GetEmployees()
        {
            var response = new EmployeeListingResponse();
            var employees = await _employeeRepository.GetEmployeeListingAsync();
            response.Employees = _mapper.Map<List<EmployeeSummaryDto>>(employees);
            return response;
        }


        /// <summary>
        /// Deletes the employee
        /// </summary>
        /// <param name="id">The id of the employee</param>
        /// <returns>204</returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveEmployee(int id)
        {
            await _employeeRepository.Remove(id);
            return NoContent();
        }
    }
}
