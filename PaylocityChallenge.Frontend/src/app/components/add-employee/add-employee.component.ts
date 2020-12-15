import {Component, OnInit} from '@angular/core';
import {FormArray, FormBuilder, FormGroup, Validators} from '@angular/forms';
import { DependentRelationshipType } from 'src/dtos/partial/dependent-dto';
import { EmployeeDto } from 'src/dtos/partial/employee-dto';
import { PreviewEmployeeCostsRequest } from 'src/dtos/requests/preview-employee-costs-request';

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
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  dependentRelations = [
    {text: 'Spouse', value: DependentRelationshipType.Spouse},
    {text: 'Child', value: DependentRelationshipType.Child}
  ];
  constructor(private _formBuilder: FormBuilder) {}

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

  previewCosts() {
    if(this.firstFormGroup.valid && this.secondFormGroup.valid) {
      var request = {
        employee: {...this.firstFormGroup.value, ...this.secondFormGroup.value } as EmployeeDto
      } as PreviewEmployeeCostsRequest;
      console.log(request);
    }
  }
}
