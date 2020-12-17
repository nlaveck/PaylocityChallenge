import { DecimalPipe } from '@angular/common';
import { ViewChild } from '@angular/core';
import { Component, OnInit, ViewChildren } from '@angular/core';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeSummaryDto } from 'src/dtos/partial/employee-summary-dto';

@Component({
  selector: 'app-employee-listing',
  templateUrl: './employee-listing.component.html',
  styleUrls: ['./employee-listing.component.scss']
})


export class EmployeeListingComponent implements OnInit {
  @ViewChild(MatTable) table!: MatTable<EmployeeSummaryDto>;
  tableData: Array<EmployeeSummaryDto> = null;
  displayedColumns = ['lastName', 'firstName', 'annualBenefitsPremium', 'annualBenefitsDiscount', 'annualBenfitsSubtotal', 'annualTaxableIncome', 'options'];

  constructor(private employeeService: EmployeeService) { }

  async ngOnInit(): Promise<void> {
    const response = await this.employeeService.getEmployees();
    this.tableData = response.employees;
  }

  getTotal(columnKey: string) {
    return this.tableData.reduce((acc, val) => acc + val[columnKey], 0);
  }
  async remove(id: number, index: number) {
    try {
      await this.employeeService.removeEmpoloyee(id);
    } catch(ex) {
      console.error("Failed to remove employee!");
      console.error(ex.message);
    }

    this.tableData.splice(index, 1);
    this.table.renderRows();
  }
}
