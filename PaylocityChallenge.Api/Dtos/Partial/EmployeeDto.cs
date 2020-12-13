using PaylocityChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityChallenge.Api.Dtos.Partial
{
    public class EmployeeDto : FamilyMemberDto
    {
        public List<DependentDto> Dependents { get; set; }
    }
}
