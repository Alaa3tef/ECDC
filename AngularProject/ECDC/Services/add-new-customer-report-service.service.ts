import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IAPIResult } from 'SharedClasses/IAPIResult';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AddNewCustomerReportServiceService {
  constructor(private http: HttpClient) {

  }

 AddCustomerReport(Formdata: FormData): Observable<any> {
   return this.http.post<FormData>(`http://localhost:5000/api/CustomerReport`, Formdata);
 }

 EditCustomerReport(CustomerReport : FormData, id:number): Observable<any> {
   return this.http.put<FormData>(`http://localhost:5000/api/CustomerReport/${id}`, CustomerReport);
 }  
 GetDataByMonthAndYear(Month:number,Year:number,userId:string,userRole:string,RigNumber:number): Observable<IAPIResult> {
   return this.http.get<IAPIResult>(` http://localhost:5000/api/CustomerReport/GetDataByMonthAndYear/${Month}?Year=${Year}&UserId=${userId}&UserRole=${userRole}&RigNumber=${RigNumber}`);
 }                                                   
 GetCustomerReportByID(Id: number,userId:string,userRole:string): Observable<IAPIResult> {
   return this.http.get<IAPIResult>(`http://localhost:5000/api/CustomerReport/GetDataById/${Id}?UserId=${userId}&UserRole=${userRole}`)
 }
}
