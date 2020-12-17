using PaylocityChallenge.Api.Dtos.Partial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaylocityChallenge.Api.Dtos.Responses
{
    public class EmployeeResponse : EmployeeDto
    {
        public int Id { get; set; }
    }
}
