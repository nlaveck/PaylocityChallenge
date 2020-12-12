using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityChallenge.Core.Entities.Abstract
{
    public abstract class FamilyMember : BaseEntity
    {
        public abstract decimal MemberYearlyBenefitsCost { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
