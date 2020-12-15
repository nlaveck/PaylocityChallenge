import { DependentDto } from "./dependent-dto";
import { FamilyMemberDto } from "./family-member-dto";

export interface EmployeeDto extends FamilyMemberDto
{
  dependents: Array<DependentDto>
}
