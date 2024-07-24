import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IAPIResult } from 'SharedClasses/IAPIResult';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AddNewMedicalReportService {

  constructor(private http: HttpClient) {

  }

 AddMedicalReport(Formdata: FormData): Observable<any> {
   return this.http.post<FormData>(`http://localhost:5000/api/MedicalReport`, Formdata);
 }

 EditMedicalReport(MedicalReport : FormData, id:number): Observable<any> {
   return this.http.put<FormData>(`http://localhost:5000/api/MedicalReport/${id}`, MedicalReport);
 }  
 GetDataByRigAndDateAndName(Name:string,userId:string,userRole:string,date:string,rigNum:number,Jop:string): Observable<IAPIResult> {
  return this.http.get<IAPIResult>(`http://localhost:5000/api/MedicalReport/GetDataByRigAndDateAndName${rigNum}?Name=${Name}&UserId=${userId}&UserRole=${userRole}&date=${date}&Jop=${Jop}`);
  }                           

  GetMedicalReportByID(Id: number,userId:string,userRole:string): Observable<IAPIResult> {
   return this.http.get<IAPIResult>(`http://localhost:5000/api/MedicalReport/GetDataById/${Id}?UserId=${userId}&UserRole=${userRole}`)
 }
}
