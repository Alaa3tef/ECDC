import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GetdataByPageService {

  constructor(private http: HttpClient) { }
  GetAccidentByPage(pageNumber: number, userId: string, userRole: string): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/Accident/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole}`);
  }
  GetAccdientCausesByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/AccidentCauses/ByPage/${pageNumber}`);
  }
  GetSubjectListByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/SubjectList/ByPage/${pageNumber}`);
  }
  GetClassificationByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/Classification/ByPage/${pageNumber}`);
  }
  GetClassificationOfAccidentByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/ClassificationOfAccident/ByPage/${pageNumber}`);
  }
  GetComminucationMethodByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/ComminucationMethod/ByPage/${pageNumber}`);
  }
  GetDriverByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/Driver/ByPage/${pageNumber}`);
  }
  GetJMPByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/JMP/ByPage/${pageNumber}`);
  }
  GetPassengerByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/Passenger/ByPage/${pageNumber}`);
  }
  GetPreventionCategoryByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/PreventionCategory/ByPage/${pageNumber}`);
  }
  GetQHSEPositionByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/QHSEPosition/ByPage/${pageNumber}`);
  }
  GetQHSEPositionNameByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/QHSEPositionName/ByPage/${pageNumber}`);
  }
  GetReportedByNameByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/ReportedByName/ByPage/${pageNumber}`);
  }
  GetReportedByPositionByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/ReportedByPosition/ByPage/${pageNumber}`);
  }
  GetRigByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/Rig/ByPage/${pageNumber}`);
  }
  GetRouteNameByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/RouteName/ByPage/${pageNumber}`);
  }
  GetStopCardByPage(pageNumber: number, userId: string, userRole: string): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/StopCardRegister/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole}`);
  }
  GetToolPusherPositionByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/ToolPusherPosition/ByPage/${pageNumber}`);
  }
  GetToolPusherPositionNameByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/ToolPusherPositionName/ByPage/${pageNumber}`);
  }
  GetTypeOfInjuryByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/TypeOfInjury/ByPage/${pageNumber}`);
  }
  GetTypeOfObservationCategoryByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/TypeOfObservationCategory/ByPage/${pageNumber}`);
  }
  GetVehicleByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/Vehicle/ByPage/${pageNumber}`);
  }
  GetViolationCategoryByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/ViolationCategory/ByPage/${pageNumber}`);
  }


  GetRigMovePerformanceByPage(pageNumber: number, userId: string, userRole: string): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/RigMovePerformance/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetEmpCodeByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/EmpCode/ByPage/${pageNumber}`);
  }
  GetPositionByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/Positions/ByPage/${pageNumber}`);
  }
  GetEmployeeCompetencyEvaluationByPage(pageNumber: number, userId: string, userRole: string): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/EmployeeCompetencyEvaluationt/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole} `);
  }
  GetDrillByPage(pageNumber: number, userId: string, userRole: string): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/Drill/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole} `);
  }
  GetCustomerReportByPage(pageNumber: number, userId: string, userRole: string): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/CustomerReport/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole} `);
  }
  GetWeeklyInspectionByPage(pageNumber: number, userId: string, userRole: string): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/WeeklyInspection/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole} `);
  }
  GetWeeklyCampInspectionByPage(pageNumber: number, userId: string, userRole: string): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/WeeklyCampInspections/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole} `);
  }
  GetMedicalReportByPage(pageNumber: number, userId: string, userRole: string): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/MedicalReport/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole} `);
  }
  GetMedicalHistoryReportByPage(pageNumber: number, userId: string, userRole: string): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/MedicalHistoryReport/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole} `);
  }
  GetDrillTypesByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/DrillType/ByPage/${pageNumber}`);
  }
  GetResponsibilityByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/Responsibility/ByPage/${pageNumber}`);
  }
  GetClientByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/Client/ByPage/${pageNumber}`);
  }
  GetCrewByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/Crew/ByPage/${pageNumber}`);
  }
  GetLeadershipVisitByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/LeadershipVisit/ByPage/${pageNumber}`);
  }
  GetDaysSinceNoFatalityByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/DaysSinceNoFatality/ByPage/${pageNumber}`);
  }
  GetDaysDaysSinceNoLTIByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/DaysSinceNoLTI/ByPage/${pageNumber}`);
  }

  //**************** Corrective Action Report ********************** */
  GetRootCauseByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/RootCauses/ByPage/${pageNumber}`);
  }

  GetStandardByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/Standard/ByPage/${pageNumber}`);
  }

  GetCorrectiveResponsabilityByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/CorrectiveResponsability/ByPage/${pageNumber}`);
  }

  GetCorrectiveObservationByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/CorrectiveObservation/ByPage/${pageNumber}`);
  }

  GetCorrectiveByPage(pageNumber: number, userId: string, userRole: string): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/CorrectiveAction/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole}`);
  }

  //*************************** Crane ************************************* */
  GetCraneByPage(pageNumber: number, userId: string, userRole: string): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/Crane/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole}`);
  }

  //*************************** Forklift ************************************* */
  GetForkliftByPage(pageNumber: number, userId: string, userRole: string): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/Forklift/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole}`);
  }

  //*************************** HSEEquipmentList ************************************* */
  GetHSEEquipmentListByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/HSEEquipmentList/ByPage/${pageNumber}`);
  }

  // ****************************  CraneDailyLifting ****************************/
  GetCraneDailyLiftingByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/CraneDailyLifting/ByPage/${pageNumber}`);
  }

  GetForkliftDailyLiftingByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/ForkDailyLifting/ByPage/${pageNumber}`);
  }

  //CertificatesType
  GetCertificatesTypeByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/CertificatesType/ByPage/${pageNumber}`);
  }
}
