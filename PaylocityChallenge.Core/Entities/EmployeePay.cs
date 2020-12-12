using PaylocityChallenge.Core.Entities.Abstract;

namespace PaylocityChallenge.Core.Entities
{
    public class EmployeePay : BaseEntity
    {
        public decimal GROSS_PAY_AMOUNT = 2000M;
        public EmployeePay()
        {
            GrossPerPaycheck = GROSS_PAY_AMOUNT;
            GrossSalary = GrossPerPaycheck * 26M;
        }
        public decimal GrossSalary { get; set; }
        public decimal NetSalary { get; set; }
        public decimal GrossPerPaycheck { get; set; }
        public decimal NetPerPaycheck { get; set; }
        public decimal BenefitsCostAnnual { get; set; }
        public decimal BenefitsCostPerPaycheck { get; set; }
    }
}
