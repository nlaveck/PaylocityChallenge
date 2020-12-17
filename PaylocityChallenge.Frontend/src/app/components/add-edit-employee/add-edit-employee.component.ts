import {Component, OnInit} from '@angular/core';
import {FormArray, FormBuilder, FormGroup, Validators} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from 'src/app/services/employee.service';
import { DependentDto, DependentRelationshipType } from 'src/dtos/partial/dependent-dto';
import { EmployeeDto } from 'src/dtos/partial/employee-dto';
import { PreviewEmployeeCostsRequest } from 'src/dtos/requests/preview-employee-costs-request';
import { SaveEmployeeRequest } from 'src/dtos/requests/save-employee-request';
import { EmployeeResponse } from 'src/dtos/responses/employee-response';
import { PreviewEmployeeCostsResponse } from 'src/dtos/responses/preview-employee-costs-response';

/**
 * @title Stepper overview
 */
@Component({
  selector: 'app-add-employee',
  templateUrl: 'add-edit-employee.component.html',
  styleUrls: ['add-edit-employee.component.scss'],
})
export class AddEditEmployeeComponent implements OnInit {
  employee: EmployeeResponse = {} as EmployeeResponse;
  isEdit: boolean;
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
    private router: Router,
    private activatedRoute: ActivatedRoute) {}

  ngOnInit() {
    this.isEdit =  this.router.url.startsWith('/edit') ? true : false;
    const data = this.activatedRoute.snapshot.data;

    if (data.employee) {
      this.employee = data.employee;
    }
    this.firstFormGroup = this._formBuilder.group({
      firstName: [this.employee.firstName, Validators.required],
      lastName: [this.employee.lastName, Validators.required]
    });
    this.secondFormGroup = this._formBuilder.group({
      dependents: this._formBuilder.array([])
    });
    if(this.employee && this.employee.dependents) {
      this.employee.dependents.forEach(d => this.addDependent(d))
    }
  }

  addDependent(dependent: DependentDto = {} as DependentDto) {
    let newDependent = this._formBuilder.group({
      firstName: [dependent.firstName, Validators.required],
      lastName: [dependent.lastName, Validators.required],
      relation: [dependent.relation, Validators.required]
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
      };
      try {
        if(this.isEdit){
          await this.employeeService.update(request, this.employee.id);
        } else {
          await this.employeeService.save(request);
        }

      } catch (ex) {
        console.error("Failed to save employee!");
        console.error(ex.message);
        button.disabled = false;
      }
      this.router.navigate(['..']);
    }
  }
}
