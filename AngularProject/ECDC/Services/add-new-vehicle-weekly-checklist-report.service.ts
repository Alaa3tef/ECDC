import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IAPIResult } from 'SharedClasses/IAPIResult';
import { IVehicleWeeklyChecklist } from 'SharedClasses/IVehicleWeeklyChecklist';

@Injectable({
  providedIn: 'root'
})
export class AddNewVehicleWeeklyChecklistReportService {

 
  constructor(private http: HttpClient) { }

  AddVehicleWeeklyChecklist(VehicleWeeklyChecklist: IVehicleWeeklyChecklist): Observable<IVehicleWeeklyChecklist> {
    return this.http.post<IVehicleWeeklyChecklist>(`http://localhost:5000/api/VehicleWeeklyChecklist`, VehicleWeeklyChecklist);
  }

  EditVehicleWeeklyChecklist(id:number,VehicleWeeklyChecklist:IVehicleWeeklyChecklist): Observable<IVehicleWeeklyChecklist> {
    return this.http.put<IVehicleWeeklyChecklist>(`http://localhost:5000/api/VehicleWeeklyChecklist/${id}`,VehicleWeeklyChecklist);
  }

  GetVehicleWeeklyChecklist(userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/VehicleWeeklyChecklist/GetData?UserId=${userId}&UserRole=${userRole}`);
  }

  GetVehicleWeeklyChecklistByDate(rigNo:number,date:Date,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/VehicleWeeklyChecklist/GetDataForPrint?RigNo=${rigNo}&date=${date}&UserID=${userId}&UserRole=${userRole}`);
  }

  GetVehicleWeeklyChecklistByRig(rigId:number,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/VehicleWeeklyChecklist/GetDataForAnalysis?RigId=${rigId}&UserID=${userId}&UserRole=${userRole}`);
  }

  // GetVehicleWeeklyChecklistById(id: number,userId:string,userRole:string): Observable<IAPIResult> {
  //   return this.http.get<IAPIResult>(`http://localhost:5000/api/VehicleWeeklyChecklist/${id}?UserId=${userId}&UserRole=${userRole}`);
  // }

  GetVehicleWeeklyChecklistDataById(id: number,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/VehicleWeeklyChecklist/GetDataById/${id}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetVehicleWeeklyChecklistByPage(pageNumber:number,userId:string,userRole:string):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/VehicleWeeklyChecklist/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetVehicleWeeklyChecklistForExcel(userId:string,userRole:string):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/VehicleWeeklyChecklist/GetDataForExcel?UserId=${userId}&UserRole=${userRole}`);
  }

  DeleteVehicleWeeklyChecklist(VehicleWeeklyChecklist:IVehicleWeeklyChecklist): Observable<IVehicleWeeklyChecklist> {
    return this.http.put<IVehicleWeeklyChecklist>(`http://localhost:5000/api/VehicleWeeklyChecklist/Delete/${VehicleWeeklyChecklist.id}`,VehicleWeeklyChecklist);
  }
}
