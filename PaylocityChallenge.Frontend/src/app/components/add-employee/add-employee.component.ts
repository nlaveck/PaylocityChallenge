import {Component, OnInit} from '@angular/core';
import {FormArray, FormBuilder, FormGroup, Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { EmployeeService } from 'src/app/services/employee.service';
import { DependentRelationshipType } from 'src/dtos/partial/dependent-dto';
import { EmployeeDto } from 'src/dtos/partial/employee-dto';
import { PreviewEmployeeCostsRequest } from 'src/dtos/requests/preview-employee-costs-request';
import { SaveEmployeeRequest } from 'src/dtos/requests/save-employee-request';
import { PreviewEmployeeCostsResponse } from 'src/dtos/responses/preview-employee-costs-response';

/**
 * @title Stepper overview
 */
@Component({
  selector: 'app-add-employee',
  templateUrl: 'add-employee.component.html',
  styleUrls: ['add-employee.component.scss'],
})
export class AddEmployeeComponent implements OnInit {
  isLinear = true;
  preview: PreviewEmployeeCostsResponse;
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  dependentRelations = [
    {text: 'Spouse', value: DependentRelationshipType.Spouse},
    {text: 'Child', value: DependentRelationshipType.Child}
  ];
  constructor(private _formBuilder: FormBuilder,
    private employeeService: EmployeeService,
    private router: Router) {}

  ngOnInit() {
    this.firstFormGroup = this._formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required]
    });
    this.secondFormGroup = this._formBuilder.group({
      dependents: this._formBuilder.array([])
    });
  }

  addDependent() {
    let newDependent = this._formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      relation: [null, Validators.required]
    });
    this.getDependentsArray().push(newDependent)
  }

  removeDependent(index: number) {
    this.getDependentsArray().removeAt(index);
  }

  getDependentsArray()  {
    return this.secondFormGroup.get('dependents') as FormArray;
  }

  async previewCosts() {
    if(this.firstFormGroup.valid && this.secondFormGroup.valid) {
      const request = {
        employee: {...this.firstFormGroup.value, ...this.secondFormGroup.value }
      } as PreviewEmployeeCostsRequest;
      try {
        this.preview = await this.employeeService.previewCosts(request);
      } catch (ex) {
        console.error("Failed to get costs preview!");
        console.error(ex.message);
      }
    }
  }

  async saveEmployee(event: MouseEvent) {
    const button = event.target as HTMLButtonElement;
    button.disabled = true;
    if(this.firstFormGroup.valid && this.secondFormGroup.valid) {
      const request = {
        employee: {...this.firstFormGroup.value, ...this.secondFormGroup.value }
      } as SaveEmployeeRequest;
      try {
        await this.employeeService.save(request)
      } catch (ex) {
        console.error("Failed to save employee!");
        console.error(ex.message);
        button.disabled = false;
      }
      this.router.navigate(['..']);
    }
  }
}
