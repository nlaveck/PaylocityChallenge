using PaylocityChallenge.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaylocityChallenge.Core.Entities
{
    public class Employee : FamilyMember
    {
        public const decimal BENEFITS_PACKAGE_COST = 1000M;

        public Employee()
        {
            MemberYearlyBenefitsCost = BENEFITS_PACKAGE_COST;
        }

        public List<Dependent> Dependents { get; set; }
        public override decimal MemberYearlyBenefitsCost { get; }
        public EmployeePay AnnualPay { get; set; }
        public EmployeePay PaycheckPay { get; set; }

        //public void CalculatePay()
        //{
        //    AnnualPay = new EmployeePay(this);
        //    PaycheckPay = new EmployeePay(AnnualPay);
        //}
    }
}
