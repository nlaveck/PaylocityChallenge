using PaylocityChallenge.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityChallenge.Core.Entities
{
    public class Dependent : FamilyMember
    {
        public const decimal BENEFITS_PACKAGE_COST = 500M;
        public Dependent()
        {
            MemberYearlyBenefitsCost = BENEFITS_PACKAGE_COST;
        }


        public override decimal MemberYearlyBenefitsCost { get; }
        public DependentRelation Relation { get; set; }
    }

    public enum DependentRelation
    {
        None = 0,
        Spouse = 1,
        Child = 2
    }
}
