using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaylocityChallenge.Api.Dtos.Partial
{
    public class EmployeePayDto
    {
        public decimal GrossIncome { get; set; }
        public decimal BenefitsPremium { get; set; }
        public decimal BenefitsDiscount { get; set; }
        public decimal BenefitsSubtotal { get; set; }
        public decimal TaxableIncome { get; set; }
    }
}
