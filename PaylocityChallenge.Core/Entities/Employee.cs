using PaylocityChallenge.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityChallenge.Core.Entities
{
    public class Employee : FamilyMember
    {
        public const decimal BENEFITS_PACKAGE_COST = 1000M;

        public Employee()
        {
            MemberYearlyBenefitsCost = BENEFITS_PACKAGE_COST;
            Pay = new EmployeePay();
        }

        public List<Dependent> Dependants { get; set; }
        public override decimal MemberYearlyBenefitsCost { get; }
        public EmployeePay Pay { get; set; }
    }
}
