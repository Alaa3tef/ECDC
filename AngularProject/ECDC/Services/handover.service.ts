import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IHandover } from 'SharedClasses/IHandover';
import { Observable } from 'rxjs';
import { IAPIResult } from 'SharedClasses/IAPIResult';

@Injectable({
  providedIn: 'root'
})
export class HandoverService {

  constructor(private http: HttpClient) { }

  AddHandover(Handover: IHandover): Observable<IHandover> {
    return this.http.post<IHandover>(`http://localhost:5000/api/Handover`, Handover);
  }

  EditHandover(id:number,Handover:IHandover): Observable<IHandover> {
    return this.http.put<IHandover>(`http://localhost:5000/api/Handover/${id}`,Handover);
  }

  GetHandover(userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Handover/GetData?UserId=${userId}&UserRole=${userRole}`);
  }

  GetHandoverByDate(rigNo:number,date:Date,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Handover/GetDataForPrint?RigNo=${rigNo}&date=${date}&UserID=${userId}&UserRole=${userRole}`);
  }

  GetHandoverByEngineer(rigNo:number,leavingEngineer:string,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Handover/GetDataForChart?RigNo=${rigNo}&LeavingEngineer=${leavingEngineer}&UserID=${userId}&UserRole=${userRole}`);
  }

  GetHandoverByRig(rigId:number,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Handover/GetDataForAnalysis?RigId=${rigId}&UserID=${userId}&UserRole=${userRole}`);
  }

  GetHandoverByRigandEngineer(rigNo:number,engineer:string,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Handover/GetDataForPrint?RigNo=${rigNo}&engineer=${engineer}&UserID=${userId}&UserRole=${userRole}`);
  }

  GetHandoverById(id: number,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Handover/${id}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetHandoverDataById(id: number,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Handover/GetDataById/${id}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetHandoverByPage(pageNumber:number,userId:string,userRole:string):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/Handover/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetHandoverForExcel(userId:string,userRole:string):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/Handover/GetDataForExcel?UserId=${userId}&UserRole=${userRole}`);
  }

  DeleteHandover(Handover:IHandover): Observable<IHandover> {
    return this.http.put<IHandover>(`http://localhost:5000/api/Handover/Delete/${Handover.id}`,Handover);
  }
}
