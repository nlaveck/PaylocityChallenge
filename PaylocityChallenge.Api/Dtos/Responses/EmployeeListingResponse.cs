using PaylocityChallenge.Api.Dtos.Partial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaylocityChallenge.Api.Dtos.Responses
{
    public class EmployeeListingResponse
    {
        public List<EmployeeSummaryDto> Employees { get; set; }
    }
}
