import { EmployeeSummaryDto } from "../partial/employee-summary-dto";

export interface EmployeeListingResponse {
  employees: Array<EmployeeSummaryDto>
}
