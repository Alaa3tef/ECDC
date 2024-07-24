import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IAPIResult } from 'SharedClasses/IAPIResult';
import { IDailyLiftingReport } from 'SharedClasses/IDailyLiftingReport';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AddNewDailyLiftingReportService {

  constructor(private http: HttpClient) { }

  AddDailyLiftingReport(dailyLiftingReport: IDailyLiftingReport): Observable<any> {
    return this.http.post<any>('http://localhost:5000/api/DailyLiftingReport', dailyLiftingReport)
  }

  EditDailyLiftingReport(id:number,DailyLiftingReport:IDailyLiftingReport): Observable<IDailyLiftingReport> {
    return this.http.put<IDailyLiftingReport>(`http://localhost:5000/api/DailyLiftingReport/${id}`,DailyLiftingReport);
  }

  GetDailyLiftingReport(userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/DailyLiftingReport/GetData?UserId=${userId}&UserRole=${userRole}`);
  }

  GetDataByRigAndDateAndName(rigNo:number,date:Date,liftingEngieerName:string,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/DailyLiftingReport/GetDataByRigAndDateAndName${rigNo}?Name=${liftingEngieerName}&UserId=${userId}&UserRole=${userRole}&date=${date}`);
  }

  GetDailyLiftingReportById(id: number,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/DailyLiftingReport/${id}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetDailyLiftingReportDataById(id: number,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/DailyLiftingReport/GetDataById/${id}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetDailyLiftingReportByPage(pageNumber:number,userId:string,userRole:string):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/DailyLiftingReport/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole}`);
  }


  DeleteDailyLiftingReport(DailyLiftingReport:IDailyLiftingReport): Observable<IDailyLiftingReport> {
    return this.http.put<IDailyLiftingReport>(`http://localhost:5000/api/DailyLiftingReport/Delete/${DailyLiftingReport.id}`,DailyLiftingReport);
  }

  GetMobileCrane(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CraneDailyLifting`);
  }

  GetByMobileCrane(MobileCrane: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CraneDailyLifting/MobileCrane?MobileCraneName=${MobileCrane}`);
  }

  GetByForkDailyLifting(ForkDailyLifting: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ForkDailyLifting/Fork?ForkName=${ForkDailyLifting}`);
  }

  GetForkDailyLifting(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ForkDailyLifting`);
  }
}
