using PaylocityChallenge.Core.Entities;
using PaylocityChallenge.Core.Entities.Abstract;
using System;
using System.Linq;

namespace PaylocityChallenge.Core.Services
{
    public class PayrollService : IPayrollService
    {
        /*
         * Updates the employee with the calculated pay annually and per paycheck
         */
        public void CalculatePay(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("Missing required arguement employee");
            }
            if (employee.Dependents == null)
            {
                throw new NullReferenceException("Dependents must be populated before calling calculate pay");
            }
            var annualPay = new EmployeePay()
            {
                Term = Frequency.Annual,
                GrossIncome = EmployeePay.GROSS_PER_PAYCHECK * EmployeePay.NUMBER_OF_PAYCHECKS,
                BenefitsPremium = employee.Dependents.Aggregate(employee.MemberYearlyBenefitsCost, (total, dependent) => total + dependent.MemberYearlyBenefitsCost),
                BenefitsDiscount = employee.Dependents.Aggregate(CalculateMemberDiscount(employee), (total, dependent) => total + CalculateMemberDiscount(dependent)),
            };
            annualPay.BenefitsSubtotal = annualPay.BenefitsPremium - annualPay.BenefitsDiscount;
            annualPay.TaxableIncome = annualPay.GrossIncome - annualPay.BenefitsSubtotal;

            var paycheckPay = new EmployeePay()
            {
                Term = Frequency.Paycheck,
                GrossIncome = EmployeePay.GROSS_PER_PAYCHECK,
                BenefitsPremium = decimal.Round(annualPay.BenefitsPremium / EmployeePay.NUMBER_OF_PAYCHECKS, 2, MidpointRounding.AwayFromZero),
                BenefitsDiscount = decimal.Round(annualPay.BenefitsDiscount / EmployeePay.NUMBER_OF_PAYCHECKS, 2, MidpointRounding.AwayFromZero),
            };
            paycheckPay.BenefitsSubtotal = paycheckPay.BenefitsPremium - paycheckPay.BenefitsDiscount;
            paycheckPay.TaxableIncome = paycheckPay.GrossIncome - paycheckPay.BenefitsSubtotal;

            employee.AnnualPay = annualPay;
            employee.PaycheckPay = paycheckPay;
        }


        /*
         * Computes the 10% dicount that is to be subtracted from the benefits
         */
        public decimal CalculateMemberDiscount(FamilyMember member)
        {
            if (member.FirstName.ToUpper().StartsWith('A'))
            {
                return member.MemberYearlyBenefitsCost * .10M;
            }
            else
            {
                return 0M;
            }
        }

    }
}
