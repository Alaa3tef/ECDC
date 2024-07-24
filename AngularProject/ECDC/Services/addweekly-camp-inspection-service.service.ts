import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IAPIResult } from 'SharedClasses/IAPIResult';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AddweeklyCampInspectionServiceService {

  constructor(private http: HttpClient) {

  }

 AddWeeklyCampInspection(Formdata: FormData): Observable<any> {
   return this.http.post<FormData>(`http://localhost:5000/api/WeeklyCampInspections`, Formdata);
 }

 EditWeeklyCampInspection(WeeklyCampInspection: FormData, id:number): Observable<any> {
   return this.http.put<FormData>(`http://localhost:5000/api/WeeklyCampInspections/${id}`, WeeklyCampInspection);
 }


 GetWeeklyCampInspectionByID(Id: number,userId:string,userRole:string): Observable<IAPIResult> {
   return this.http.get<IAPIResult>(`http://localhost:5000/api/WeeklyCampInspections/GetDataById/${Id}?UserId=${userId}&UserRole=${userRole}`)
 }

 GetWeeklyCampInspectionByIDForPrint(Id: number,userId:string,userRole:string): Observable<IAPIResult> {
   return this.http.get<IAPIResult>(`http://localhost:5000/api/WeeklyCampInspections/Print/${Id}?UserId=${userId}&UserRole=${userRole}`)
 }

 GetWeeklyCampInspectionByRigAndDate(date: string,userId: string, userRole: string,  rigNum: number): Observable<IAPIResult> {
  return this.http.get<IAPIResult>(`http://localhost:5000/api/WeeklyCampInspections/GetAllWithDataByRigNumerAndDate/${userId}?date=${date}&UserRole=${userRole}&RigNumber=${rigNum}`);
}
}
