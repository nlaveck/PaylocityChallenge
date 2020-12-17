import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PreviewEmployeeCostsRequest } from 'src/dtos/requests/preview-employee-costs-request';
import { SaveEmployeeRequest } from 'src/dtos/requests/save-employee-request';
import { EmployeeListingResponse } from 'src/dtos/responses/employee-listing-response';
import { EmployeeResponse } from 'src/dtos/responses/employee-response';
import { PreviewEmployeeCostsResponse } from 'src/dtos/responses/preview-employee-costs-response';
import { environment } from 'src/environments/environment'

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private baseUrl = environment.apiUrl + '/employees/';

  constructor(private httpClient: HttpClient) {

  }

  public previewCosts(request: PreviewEmployeeCostsRequest) : Promise<PreviewEmployeeCostsResponse>{
    return this.httpClient.post<PreviewEmployeeCostsResponse>(this.baseUrl + 'preview', request).toPromise();
  }

  public save(request: SaveEmployeeRequest) : Promise<void> {
    return this.httpClient.post<void>(this.baseUrl + 'create', request).toPromise();
  }

  public update(request: SaveEmployeeRequest, id: number) : Promise<void> {
    return this.httpClient.patch<void>(this.baseUrl + id, request).toPromise();
  }

  public getEmployees(): Promise<EmployeeListingResponse> {
    return this.httpClient.get<EmployeeListingResponse>(this.baseUrl + 'index').toPromise();
  }

  public removeEmpoloyee(id: number): Promise<void> {
    return this.httpClient.delete<void>(this.baseUrl + id).toPromise();
  }

  public getEmployee(id: number): Observable<any> {
    return this.httpClient.get<EmployeeResponse>(this.baseUrl + id);
  }
}
