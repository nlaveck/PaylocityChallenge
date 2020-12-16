import { EmployeePayDto } from "../partial/employee-pay-dto";

export interface PreviewEmployeeCostsResponse {
  annualPay: EmployeePayDto;
  paycheckPay: EmployeePayDto;
}
