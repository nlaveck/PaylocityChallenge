using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaylocityChallenge.Api.Dtos.Partial
{
    public class EmployeeSummaryDto : FamilyMemberDto
    {
        public decimal AnnualBenefitsPremium { get; set; }
        public decimal AnnualBenefitsDiscount { get; set; }
        public decimal AnnualBenefitsSubtotal { get; set; }
        public decimal AnnualTaxableIncome { get; set; }
    }
}
