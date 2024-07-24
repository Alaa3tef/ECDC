import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IAPIResult } from 'SharedClasses/IAPIResult';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AddWeeklyInspectionServiceService {

  constructor(private http: HttpClient) {

  }

 AddWeeklyInspection (Formdata: FormData): Observable<any> {
   return this.http.post<FormData>(`http://localhost:5000/api/WeeklyInspection`, Formdata);
 }

 EditWeeklyInspection(WeeklyInspection: FormData, id:number): Observable<any> {
   return this.http.put<FormData>(`http://localhost:5000/api/WeeklyInspection/${id}`, WeeklyInspection);
 }


 GetWeeklyInspectionByID(Id: number,userId:string,userRole:string): Observable<IAPIResult> {
   return this.http.get<IAPIResult>(`http://localhost:5000/api/WeeklyInspection/GetDataById/${Id}?UserId=${userId}&UserRole=${userRole}`)
 }

 GetWeeklyInspectionByIDForPrint(Id: number,userId:string,userRole:string): Observable<IAPIResult> {
   return this.http.get<IAPIResult>(`http://localhost:5000/api/WeeklyInspection/Print/${Id}?UserId=${userId}&UserRole=${userRole}`)
 }

 GetWeeklyInspectionByRigAndDate(date: string,userId: string, userRole: string,  rigNum: number): Observable<IAPIResult> {
  return this.http.get<IAPIResult>(`http://localhost:5000/api/WeeklyInspection/GetAllWithDataByRigNumerAndDate/${userId}?date=${date}&UserRole=${userRole}&RigNumber=${rigNum}`);
}
}
