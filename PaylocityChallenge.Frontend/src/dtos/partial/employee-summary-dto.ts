import { FamilyMemberDto } from "./family-member-dto";

export interface EmployeeSummaryDto extends FamilyMemberDto {
  annualBenefitsPremium: number;
  annualBenefitsDiscount: number;
  annualBenfitsSubtotal: number;
  annualTaxableIncome: number;
}
