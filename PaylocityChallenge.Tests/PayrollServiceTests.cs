using PaylocityChallenge.Core.Entities;
using PaylocityChallenge.Core.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PaylocityChallenge.Tests
{
    public class PayrollServiceTests
    {
        public PayrollService sut;
        public PayrollServiceTests()
        {
            sut = new PayrollService();
        }
        [Fact]
        public void EmployeeNameStartsWithAGetsDiscount()
        {
            var employee = new Employee()
            {
                FirstName = "apple",
            };
            Assert.Equal(employee.MemberYearlyBenefitsCost * .10M, sut.CalculateMemberDiscount(employee));

            var otherEmployee = new Employee()
            {
                FirstName = "banana"
            };
            Assert.Equal(0, sut.CalculateMemberDiscount(otherEmployee));
        }

        [Fact]
        public void DepnendentStartsWithAGetsDiscount()
        {
            var dependent = new Dependent()
            {
                FirstName = "apple",
            };
            Assert.Equal(dependent.MemberYearlyBenefitsCost * .10M, sut.CalculateMemberDiscount(dependent)); ;

            var otherDependent = new Dependent()
            {
                FirstName = "banana"
            };
            Assert.Equal(0, sut.CalculateMemberDiscount(otherDependent));
        }

        [Fact]
        public void EmployeeYearlyCalculatedCorrectly()
        {
            Employee employee;
            EmployeePay expectedYearlyPay;
            SetupYearlyPay(out employee, out expectedYearlyPay);

            sut.CalculatePay(employee);

            Assert.Equal(expectedYearlyPay.GrossIncome, employee.AnnualPay.GrossIncome);
            Assert.Equal(expectedYearlyPay.BenefitsDiscount, employee.AnnualPay.BenefitsDiscount);
            Assert.Equal(expectedYearlyPay.BenefitsPremium, employee.AnnualPay.BenefitsPremium);
            Assert.Equal(expectedYearlyPay.BenefitsSubtotal, employee.AnnualPay.BenefitsSubtotal);
            Assert.Equal(expectedYearlyPay.TaxableIncome, employee.AnnualPay.TaxableIncome);
        }

        [Fact]
        public void EmployeeCostsCalculatedCorrectly()
        {
            Employee employee;
            EmployeePay expectedYearlyPay;
            SetupYearlyPay(out employee, out expectedYearlyPay);

            sut.CalculatePay(employee);
            var roundMethod = MidpointRounding.AwayFromZero;

            Assert.Equal(expectedYearlyPay.GrossIncome / 26M, employee.PaycheckPay.GrossIncome);
            Assert.Equal(decimal.Round(expectedYearlyPay.BenefitsDiscount / 26M, 2, roundMethod), employee.PaycheckPay.BenefitsDiscount);
            Assert.Equal(decimal.Round(expectedYearlyPay.BenefitsPremium / 26M, 2, roundMethod), employee.PaycheckPay.BenefitsPremium);
            Assert.Equal(employee.PaycheckPay.BenefitsPremium - employee.PaycheckPay.BenefitsDiscount, employee.PaycheckPay.BenefitsSubtotal);
            Assert.Equal(employee.PaycheckPay.GrossIncome - employee.PaycheckPay.BenefitsSubtotal, employee.PaycheckPay.TaxableIncome);
        }


        [Fact]
        public void EmployeeCostsThrowWhenDependentsArentSet()
        {
            var employee = new Employee{ FirstName = "No", LastName = "Dependents" };
            Assert.Throws<NullReferenceException>(() => sut.CalculatePay(employee));
        }

        private void SetupYearlyPay(out Employee employee, out EmployeePay expectedYearlyPay)
        {
            employee = new Employee
            {
                FirstName = "Nathan",
                LastName = "LaVeck",
                Dependents = new List<Dependent>()
                {
                    new Dependent
                    {
                        Relation = DependentRelation.Spouse,
                        FirstName = "Alyssa",
                        LastName = "Cantrell"
                    }
                }
            };
            expectedYearlyPay = new EmployeePay
            {
                GrossIncome = 52000M,
                BenefitsDiscount = sut.CalculateMemberDiscount(employee.Dependents[0]), // Spouse gets a discount
                BenefitsPremium = employee.MemberYearlyBenefitsCost + employee.Dependents[0].MemberYearlyBenefitsCost,
            };
            expectedYearlyPay.BenefitsSubtotal = expectedYearlyPay.BenefitsPremium - expectedYearlyPay.BenefitsDiscount;
            expectedYearlyPay.TaxableIncome = expectedYearlyPay.GrossIncome - expectedYearlyPay.BenefitsSubtotal;
        }
    }
}
