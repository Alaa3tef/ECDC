import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IRigCertificates } from 'SharedClasses/IRigCertificates';
import { Observable } from 'rxjs';
import { IAPIResult } from 'SharedClasses/IAPIResult';

@Injectable({
  providedIn: 'root'
})
export class RigCertificatesService {

  
  constructor(private http: HttpClient) { }

  AddRigCertificates(RigCertificates: IRigCertificates): Observable<IRigCertificates> {
    return this.http.post<IRigCertificates>(`http://localhost:5000/api/RigCertificates`, RigCertificates);
  }

  EditRigCertificates(id:number,RigCertificates:IRigCertificates): Observable<IRigCertificates> {
    return this.http.put<IRigCertificates>(`http://localhost:5000/api/RigCertificates/${id}`,RigCertificates);
  }

  GetRigCertificates(userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/RigCertificates/GetData?UserId=${userId}&UserRole=${userRole}`);
  }

  GetRigCertificatesByDate(rigNo:number,date:Date,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/RigCertificates/GetDataForPrint?RigNo=${rigNo}&date=${date}&UserID=${userId}&UserRole=${userRole}`);
  }

  GetRigCertificatesByEngineer(rigNo:number,leavingEngineer:string,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/RigCertificates/GetDataForChart?RigNo=${rigNo}&LeavingEngineer=${leavingEngineer}&UserID=${userId}&UserRole=${userRole}`);
  }

  GetRigCertificatesByRig(rigId:number,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/RigCertificates/GetDataForAnalysis?RigId=${rigId}&UserID=${userId}&UserRole=${userRole}`);
  }

  GetRigCertificatesById(id: number,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/RigCertificates/${id}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetRigCertificatesDataById(id: number,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/RigCertificates/GetDataById/${id}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetRigCertificatesByPage(pageNumber:number,userId:string,userRole:string):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/RigCertificates/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetRigCertificatesForExcel(userId:string,userRole:string):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/RigCertificates/GetDataForExcel?UserId=${userId}&UserRole=${userRole}`);
  }

  DeleteRigCertificates(RigCertificates:IRigCertificates): Observable<IRigCertificates> {
    return this.http.put<IRigCertificates>(`http://localhost:5000/api/RigCertificates/Delete/${RigCertificates.id}`,RigCertificates);
  }
}
