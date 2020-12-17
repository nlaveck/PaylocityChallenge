import { FamilyMemberDto } from "./family-member-dto";

export interface EmployeeSummaryDto extends FamilyMemberDto {
  id: number;
  annualBenefitsPremium: number;
  annualBenefitsDiscount: number;
  annualBenfitsSubtotal: number;
  annualTaxableIncome: number;
}
