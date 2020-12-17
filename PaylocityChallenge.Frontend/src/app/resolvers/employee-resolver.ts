import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { EmployeeResponse } from "src/dtos/responses/employee-response";
import { EmployeeService } from "../services/employee.service";

@Injectable({ providedIn: 'root' })
export class EmployeeResolver implements Resolve<EmployeeResponse> {
  constructor(private service: EmployeeService) {}

  resolve(
    route: ActivatedRouteSnapshot,
  ) {
    return this.service.getEmployee(parseInt(route.paramMap.get('id')));
  }
}
