using PaylocityChallenge.Core.Entities.Abstract;
using System;
using System.Linq;

namespace PaylocityChallenge.Core.Entities
{
   

    public class EmployeePay : BaseEntity
    {
        public const int NUMBER_OF_PAYCHECKS = 26;
        public const int GROSS_PER_PAYCHECK = 2000;

        public EmployeePay()
        {
        }


        /// <summary>
        /// Used to initalize the annual pay of the employee
        /// </summary>
        /// <param name="term"></param>
        /// <param name="employee"></param>
        //public EmployeePay(Employee employee)
        //{
        //    if (employee == null || employee.Dependents == null)
        //    {
        //        throw new Exception("Employee and dependents collection must be initialized before trying to compute pay");
        //    }
        //    Term = Frequency.Annual;
        //    GrossIncome = GROSS_PER_PAYCHECK * NUMBER_OF_PAYCHECKS;
        //    BenefitsPremium = employee.Dependents.Aggregate(employee.MemberYearlyBenefitsCost, (total, dependent) => total + dependent.MemberYearlyBenefitsCost);
        //    BenefitsDiscount = employee.Dependents.Aggregate(employee.MemberBenefitsDiscount(), (total, dependent) => total + dependent.MemberBenefitsDiscount());
        //    BenftisSubtotal = BenefitsPremium - BenefitsDiscount;
        //    TaxableIncome = GrossIncome - BenftisSubtotal;
        //}

        ///// <summary>
        ///// Used to calculate the per paycheck pay from the annual pay.
        ///// NOTE:  This would require clarification on the rounding method that should be used.
        ///// </summary>
        ///// <param name="annualPay">The employees annual pay</param>
        //public EmployeePay(EmployeePay annualPay)
        //{
        //    if (annualPay == null || annualPay.Term != Frequency.Annual)
        //    {
        //        throw new Exception("Constructor is only designed for the use of annual pay");
        //    }
        //    Term = Frequency.Paycheck;
        //    GrossIncome = GROSS_PER_PAYCHECK;
        //    BenefitsPremium = decimal.Round(annualPay.BenefitsPremium / NUMBER_OF_PAYCHECKS, 2, MidpointRounding.AwayFromZero);
        //    BenefitsDiscount = decimal.Round(annualPay.BenefitsDiscount / NUMBER_OF_PAYCHECKS, 2, MidpointRounding.AwayFromZero);
        //    BenftisSubtotal = BenefitsPremium - BenefitsDiscount;
        //    TaxableIncome = GrossIncome - BenftisSubtotal;
        //}

        public decimal GrossIncome { get; set; }
        public decimal BenefitsPremium { get; set; }
        public decimal BenefitsDiscount { get; set; }
        public decimal BenefitsSubtotal { get; set; }
        public decimal TaxableIncome { get; set; }
        public Frequency Term { get; set; }
    }

    public enum Frequency
    {
        Annual = 1,
        Paycheck = 2
    }
}
