using AutoMapper;
using PaylocityChallenge.Api.Dtos.Partial;
using PaylocityChallenge.Core.Entities;

namespace PaylocityChallenge.Api.Dtos
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Dependent, DependentDto>().ReverseMap();
            CreateMap<EmployeePay, EmployeePayDto>().ReverseMap();
            CreateMap<Employee,EmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeWithPayDto>().ReverseMap();
        }  
    }
}
