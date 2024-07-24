import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IWeeklyClinic } from 'SharedClasses/IWeeklyClinic';
import { Observable } from 'rxjs';
import { IAPIResult } from 'SharedClasses/IAPIResult';

@Injectable({
  providedIn: 'root'
})
export class WeeklyClinicService {

  constructor(private http: HttpClient) { }

  AddWeeklyClinic(WeeklyClinic: IWeeklyClinic): Observable<IWeeklyClinic> {
    return this.http.post<IWeeklyClinic>(`http://localhost:5000/api/WeeklyClinic`, WeeklyClinic);
  }

  EditWeeklyClinic(id:number,WeeklyClinic:IWeeklyClinic): Observable<IWeeklyClinic> {
    return this.http.put<IWeeklyClinic>(`http://localhost:5000/api/WeeklyClinic/${id}`,WeeklyClinic);
  }

  GetWeeklyClinic(userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/WeeklyClinic/GetData?UserId=${userId}&UserRole=${userRole}`);
  }

  GetWeeklyClinicByDate(rigNo:number,date:Date,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/WeeklyClinic/GetDataForPrint?RigNo=${rigNo}&date=${date}&UserID=${userId}&UserRole=${userRole}`);
  }

  GetWeeklyClinicByRig(rigId:number,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/WeeklyClinic/GetDataForAnalysis?RigId=${rigId}&UserID=${userId}&UserRole=${userRole}`);
  }

  GetWeeklyClinicById(id: number,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/WeeklyClinic/${id}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetWeeklyClinicDataById(id: number,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/WeeklyClinic/GetDataById/${id}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetWeeklyClinicByPage(pageNumber:number,userId:string,userRole:string):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/WeeklyClinic/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetWeeklyClinicForExcel(userId:string,userRole:string):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/WeeklyClinic/GetDataForExcel?UserId=${userId}&UserRole=${userRole}`);
  }

  DeleteWeeklyClinic(WeeklyClinic:IWeeklyClinic): Observable<IWeeklyClinic> {
    return this.http.put<IWeeklyClinic>(`http://localhost:5000/api/WeeklyClinic/Delete/${WeeklyClinic.id}`,WeeklyClinic);
  }
}
