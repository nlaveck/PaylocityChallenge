using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityChallenge.Api.Dtos.Partial
{
    public class DependantDto : FamilyMemberDto
    {
        public RelationType Relation;
    }

    public enum RelationType {
        Spouse = 1,
        Child = 2
    }
}
