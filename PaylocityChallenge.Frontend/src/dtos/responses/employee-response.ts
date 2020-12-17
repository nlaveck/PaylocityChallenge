import { EmployeeDto } from "../partial/employee-dto";

export interface EmployeeResponse extends EmployeeDto {
  id: number;
}
