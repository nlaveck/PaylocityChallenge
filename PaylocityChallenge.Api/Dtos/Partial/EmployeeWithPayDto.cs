using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaylocityChallenge.Api.Dtos.Partial
{
    public class EmployeeWithPayDto : FamilyMemberDto
    {
        public EmployeePayDto AnnualPay { get; set; }
    }
}
