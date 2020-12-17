import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddEmployeeComponent } from './components/add-employee/add-employee.component';
import { EmployeeListingComponent } from './components/employee-listing/employee-listing.component';

const routes: Routes = [
  { path: 'add-employee', component: AddEmployeeComponent },
  { path: '', component: EmployeeListingComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
