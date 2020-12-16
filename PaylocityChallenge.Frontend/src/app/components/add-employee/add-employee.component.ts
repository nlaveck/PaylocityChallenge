import {Component, OnInit} from '@angular/core';
import {FormArray, FormBuilder, FormGroup, Validators} from '@angular/forms';
import { EmployeeService } from 'src/app/services/employee.service';
import { DependentRelationshipType } from 'src/dtos/partial/dependent-dto';
import { EmployeeDto } from 'src/dtos/partial/employee-dto';
import { PreviewEmployeeCostsRequest } from 'src/dtos/requests/preview-employee-costs-request';
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
  constructor(private _formBuilder: FormBuilder, private employeeService: EmployeeService) {}

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
      var request = {
        employee: {...this.firstFormGroup.value, ...this.secondFormGroup.value }
      } as PreviewEmployeeCostsRequest;
      console.log(request);
      this.preview = await this.employeeService.previewCosts(request);
    }
  }
}
