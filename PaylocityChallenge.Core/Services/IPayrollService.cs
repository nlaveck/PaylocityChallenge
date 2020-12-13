using PaylocityChallenge.Core.Entities;
using PaylocityChallenge.Core.Entities.Abstract;

namespace PaylocityChallenge.Core.Services
{
    public interface IPayrollService
    {
        decimal CalculateMemberDiscount(FamilyMember member);
        void CalculatePay(Employee employee);
        decimal CalcuteYearlyMemberCosts(FamilyMember member);
    }
}