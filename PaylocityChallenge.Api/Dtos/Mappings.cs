using AutoMapper;
using PaylocityChallenge.Api.Dtos.Partial;
using PaylocityChallenge.Api.Dtos.Responses;
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
            CreateMap<Employee, EmployeeResponse>();
            CreateMap<Employee, EmployeeSummaryDto>()
                .ForMember(dest => dest.AnnualBenefitsDiscount, opt => opt.MapFrom(src => src.AnnualPay.BenefitsDiscount))
                .ForMember(dest => dest.AnnualBenefitsPremium, opt => opt.MapFrom(src => src.AnnualPay.BenefitsPremium))
                .ForMember(dest => dest.AnnualBenefitsSubtotal, opt => opt.MapFrom(src => src.AnnualPay.BenefitsSubtotal))
                .ForMember(dest => dest.AnnualTaxableIncome, opt => opt.MapFrom(src => src.AnnualPay.TaxableIncome));
        }  
    }
}
