using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaylocityChallenge.Api.Dtos.Partial
{
    public class EmployeePayDto
    {
        public decimal GrossSalary { get; set; }
        //public decimal NetSalary { get; set; }
        public decimal GrossPerPaycheck { get; set; }
        //public decimal NetPerPaycheck { get; set; }e
        public decimal BenefitsCostAnnual { get; set; }
        public decimal BenefitsCostPerPaycheck { get; set; }
    }
}
