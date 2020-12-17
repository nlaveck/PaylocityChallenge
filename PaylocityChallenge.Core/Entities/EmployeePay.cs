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
