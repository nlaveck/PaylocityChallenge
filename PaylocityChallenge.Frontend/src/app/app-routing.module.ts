import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddEmployeeComponent } from './components/add-employee/add-employee.component';
import { EmployeeListingComponent } from './components/employee-listing/employee-listing.component';
import { EmployeeResolver } from './resolvers/employee-resolver';

const routes: Routes = [
  { path: 'add-employee', component: AddEmployeeComponent },
  {
    path: 'edit-employee/:id',
    component: AddEmployeeComponent,
    resolve: {
      employee: EmployeeResolver
    }
  },
  { path: '', component: EmployeeListingComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
