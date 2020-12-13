using PaylocityChallenge.Core.Entities;
using PaylocityChallenge.Core.Entities.Abstract;
using System;
using System.Linq;

namespace PaylocityChallenge.Core.Services
{
    public class PayrollService : IPayrollService
    {
        /*
         * Updates the employee in place to include the benefits cost
         */
        public void CalculatePay(Employee employee)
        {
            employee.Pay = new EmployeePay();
            employee.Pay.BenefitsCostAnnual = CalcuteYearlyMemberCosts(employee) + employee.Dependents.Aggregate(0M, (total, dependent) => total + CalcuteYearlyMemberCosts(dependent));
            var benfitsPaycheckUnrounded = employee.Pay.BenefitsCostAnnual / 26M;
            //Rounding up to ensure benfits are fully covered by employee.  This would require more detail if it should be rounded up or down
            employee.Pay.BenefitsCostPerPaycheck = Math.Round(benfitsPaycheckUnrounded, 2, MidpointRounding.ToPositiveInfinity);
        }

        /*
         * Returns the family members benefits costs after discount
         */
        public decimal CalcuteYearlyMemberCosts(FamilyMember member)
        {
            return member.MemberYearlyBenefitsCost * (1M - CalculateMemberDiscount(member));
        }

        /*
         * Checks the family members name to see if a 10% discount applies to them
         */
        public decimal CalculateMemberDiscount(FamilyMember member)
        {
            if (member.FirstName.ToUpper().StartsWith('A'))
            {
                return .10M;
            }
            else
            {
                return 0M;
            }
        }

    }
}
