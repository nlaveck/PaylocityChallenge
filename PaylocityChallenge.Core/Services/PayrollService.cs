using PaylocityChallenge.Core.Entities;
using PaylocityChallenge.Core.Entities.Abstract;
using System.Linq;

namespace PaylocityChallenge.Core.Services
{
    public class PayrollService
    {
        /*
         * Calculates netpay and benefits for the employee
         */
        public void CalculatePay(Employee employee)
        {
            employee.Pay.BenefitsCostAnnual = CalcuteYearlyMemberCosts(employee) + employee.Dependants.Aggregate(0M, (total, dependent) => total + CalcuteYearlyMemberCosts(dependent));
            employee.Pay.BenefitsCostPerPaycheck = employee.Pay.BenefitsCostAnnual  / 26M;
            employee.Pay.NetSalary = employee.Pay.GrossSalary - employee.Pay.BenefitsCostAnnual;
            employee.Pay.NetPerPaycheck = employee.Pay.GrossPerPaycheck - employee.Pay.BenefitsCostPerPaycheck;
        }

        /*
         * Returns the family members cost
         */
        public decimal CalcuteYearlyMemberCosts(FamilyMember member)
        {
            return member.MemberYearlyBenefitsCost * (1M - CalculateMemberDiscount(member));
        }

        /*
         * Family members get a 10% discount on their benefit costs if their name starts with 'A'
         */
        public decimal CalculateMemberDiscount(FamilyMember member)
        {
            if (member.FirstName.StartsWith('A'))
            {
                return .10M;
            } else
            {
                return 0M;
            }
        }

    }
}
