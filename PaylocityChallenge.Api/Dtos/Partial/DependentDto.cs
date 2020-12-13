using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityChallenge.Api.Dtos.Partial
{
    public class DependentDto : FamilyMemberDto
    {
        public RelationType Relation;
    }

    public enum RelationType {
        Spouse = 1,
        Child = 2
    }
}
