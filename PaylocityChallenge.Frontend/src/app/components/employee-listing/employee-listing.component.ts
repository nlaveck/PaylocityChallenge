import { DecimalPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeSummaryDto } from 'src/dtos/partial/employee-summary-dto';

@Component({
  selector: 'app-employee-listing',
  templateUrl: './employee-listing.component.html',
  styleUrls: ['./employee-listing.component.scss']
})

export class EmployeeListingComponent implements OnInit {

  tableData: Array<EmployeeSummaryDto> = null;
  displayedColumns = ['firstName', 'lastName', 'annualBenefitsPremium', 'annualBenefitsDiscount', 'annualBenfitsSubtotal', 'annualTaxableIncome'];

  constructor(private employeeService: EmployeeService) { }

  async ngOnInit(): Promise<void> {
    const response = await this.employeeService.getEmployees();
    this.tableData = response.employees;
  }

  getTotal(column: string) {
    return this.tableData.reduce((acc, val) => acc + val[column], 0);
  }
}
