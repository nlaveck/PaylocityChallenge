import { FamilyMemberDto } from "./family-member-dto";

export interface DependentDto extends FamilyMemberDto {
  relation: DependentRelationshipType;
}

export enum DependentRelationshipType {
  Spouse = 1,
  Child = 2
}
