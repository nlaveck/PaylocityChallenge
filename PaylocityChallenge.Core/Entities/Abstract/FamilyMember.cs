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

        //public decimal MemberBenefitsDiscount()
        //{
        //    if (FirstName.ToUpper().StartsWith('A'))
        //    {
        //        return MemberYearlyBenefitsCost * .10M;
        //    }
        //    return 0;
        //}
    }
}
