using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        [HttpPost("preview")]
        public PreviewEmployeeCostsResponse PreviewCosts([FromServices] IPayrollService payrollService, [FromBody] PreviewEmployeeCostRequest request)
        {
            var response = new PreviewEmployeeCostsResponse();
            var employee = _mapper.Map<Employee>(request.Employee);
            payrollService.CalculatePay(employee);
            response.AnnualPay = _mapper.Map<EmployeePayDto>(employee.AnnualPay);
            response.PaycheckPay = _mapper.Map<EmployeePayDto>(employee.PaycheckPay);
            return response;
        }

        [HttpPost("create")]
        public async Task<PreviewEmployeeCostsResponse> AddEmployee([FromServices] IPayrollService payrollService, [FromBody] PreviewEmployeeCostRequest request)
        {
            var response = new PreviewEmployeeCostsResponse();
            var employee = _mapper.Map<Employee>(request.Employee);
            payrollService.CalculatePay(employee);
            await _employeeRepository.Add(employee);

            response.AnnualPay = _mapper.Map<EmployeePayDto>(employee.AnnualPay);
            response.PaycheckPay = _mapper.Map<EmployeePayDto>(employee.PaycheckPay);
            return response;
        }

        [HttpGet("index")]
        public async Task<EmployeeListingResponse> GetEmployees()
        {
            var response = new EmployeeListingResponse();
            var employees = await _employeeRepository.GetEmployeeListingAsync();
            response.Employees = _mapper.Map<List<EmployeeWithPayDto>>(employees);
            return response;
        }
    }
}
