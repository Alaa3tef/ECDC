import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IAPIResult } from 'SharedClasses/IAPIResult';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }

  GetAccidents(userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Accident/GetData?UserID=${userId}&UserRole=${userRole}`);
  }

  GetEmployeeCompetencyEvaluationts(userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/EmployeeCompetencyEvaluationt/GetData?UserID=${userId}&UserRole=${userRole}`);
  }

  GetDrills(userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Drill/GetData?UserID=${userId}&UserRole=${userRole}`);
  }
  GetCustomersReport(userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CustomerReport/GetData?UserID=${userId}&UserRole=${userRole}`);
  }
  GetWeeklyInspections(userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/WeeklyInspection/GetData?UserID=${userId}&UserRole=${userRole}`);
  }
  GetWeeklyCampInspections(userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/WeeklyCampInspections/GetData?UserID=${userId}&UserRole=${userRole}`);
  }
  GetMedicalReports(userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/MedicalReport/GetData?UserID=${userId}&UserRole=${userRole}`);
  }
  GetMedicalHistorys(userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/MedicalHistoryReport/GetData?UserID=${userId}&UserRole=${userRole}`);
  }
  GetTypeOfIncidentIdList(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/TypeOfIncident`);
  }
  GetStopCards(userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/StopCardRegister/GetData?UserId=${userId}&UserRole=${userRole}`);
  }

  GetPendingJMP(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/JMP/notifyStatus/${pageNumber}?pagesize=10`);
  }

  GetStopCardsByMonth(month: number,year:number, userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/StopCardRegister/GetDataByMonth/${month}?year=${year}&UserId=${userId}&UserRole=${userRole}`);
  }

  GetJMPs(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/JMP`);
  }

  GetAccidentCauses(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/AccidentCauses`);
  }

  GetSubjectList(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/SubjectList`);
  }

  GetDrillTypeList(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/DrillType`);
  }
  GetRatingList(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Rating`);
  }
  GetDrillByMonth(month1: number, month2: number, userRole: string, UserId: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Drill/GetDrillAnalysisByDrillTypeAndMonth/?Month1=${month1}&Month2=${month2}&UserRole=${userRole}&UserId=${UserId}`);
  }

  GetDrillByYear(year: number, userRole: string, UserId: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Drill/GetDrillAnalysisByDrillTypeAndYear?Year=${year}&UserRole=${userRole}&UserId=${UserId}`);
  }
  GetDrillAnalysisWithCompareByYear(year: number, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Drill/GetDrillAnalysisWithCompareByYear/?Year=${year}&UserRole=${userRole}`);
  }
  GetDrillAnalysisWithCompareByMonth(month1: number, month2: number, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Drill/GetDrillAnalysisWithCompareByMonth/?Month1=${month1}&Month2=${month2}&UserRole=${userRole}`);
  }

  // *************************** Charts For Admin Customer Report **********************
  GetCustomerAnalysisWithCompareByYear(year: number, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CustomerReport/GetCustomerAnalysisWithCompareByYear/?Year=${year}&UserRole=${userRole}`);
  }
  GetCustomerAnalysisWithCompareByMonth(month: number, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CustomerReport/GetCustomerAnalysisWithCompareByMonth/?Month=${month}&UserRole=${userRole}`);
  }
  GetCustomerAnalysisWithCompareTwoRigsByYear(Rig1: number, Rig2: number, Year: number, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CustomerReport/GetCustomerAnalysisWithCompareTwoRigsByYear/?RigID1=${Rig1}&RigID2=${Rig2}&Year=${Year}&UserRole=${userRole}`);
  }
  // *************************** Charts For User Customer Report **********************
  GetCustomerAnalysisByYearForUser(year: number, userRole: string, UserId: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CustomerReport/GetCustomerAnalysisByYearForUser/?year=${year}&userRole=${userRole}&UserId=${UserId}`);
  }
  //*************************** MedicalReportCharts ************************/
  GetMedicalReportAnalysisWithCompareByYear(year: number, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/MedicalReport/GetMedicalReportAnalysisWithCompareByYear/?Year=${year}&UserRole=${userRole}`);
  }
  GetMedicalReportAnalysisWithCompareByMonth(month: number, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/MedicalReport/GetMedicalReportAnalysisWithCompareByMonth/?Month=${month}&UserRole=${userRole}`);
  }

GetMedicalHistoryReportAnalysisWithCompareByYear(rig:number,userRole:string): Observable<IAPIResult> {
  return this.http.get<IAPIResult>(`http://localhost:5000/api/MedicalHistoryReport/GetMedicalHistoryReportAnalysisWithCompareByYear?Rig=${rig}&UserRole=${userRole}`);
}
  GetSubjectById(id:number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/SubjectList/${id}`);
  }


  GetClassification(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Classification`);
  }

  GetClassificationOfAccident(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ClassificationOfAccident`);
  }

  GetPreventionCategory(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/PreventionCategory`);
  }

  GetQHSEPosition(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/QHSEPosition`);
  }

  GetQHSEPositionNameForExcel(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/QHSEPositionName/GetAllForExcel`);
  }

  GetQHSEPositionName(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/QHSEPositionName`);
  }

  GetReportedByNameByEmpCode(empCode: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ReportedByName/Code/${empCode}`);
  }

  GetQHSEPositionNameByEmpCode(empCode: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/QHSEPositionName/Code/${empCode}`);
  }

  GetToolPusherPositionNameByEmpCode(empCode: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ToolPusherPositionName/Code/${empCode}`);
  }

  GetReportedByName(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ReportedByName`);
  }

  GetReportedByNameForExcel(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ReportedByName/GetAllForExcel`);
  }

  GetReportedByPosition(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ReportedByPosition`);
  }

  GetRig(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Rig`);
  }

  GetToolPusherPosition(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ToolPusherPosition`);
  }

  GetToolPusherPositionName(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ToolPusherPositionName`);
  }

  GetToolPusherPositionNameForExcel(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ToolPusherPositionName/GetAllForExcel`);
  }

  GetReportedByNameByID(nameID: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ReportedByName/${nameID}`);
  }

  GetReportedByPositionByID(positionID: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ReportedByPosition/${positionID}`);
  }

  GetToolPusherPositionNameByID(nameID: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ToolPusherPositionName/${nameID}`);
  }

  GetToolPusherPositionByID(positionID: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ToolPusherPosition/${positionID}`);
  }

  GetQHSEPositionNameByID(nameID: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/QHSEPositionName/${nameID}`);
  }

  GetQHSEPositionByID(positionID: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/QHSEPosition/${positionID}`);
  }

  GetTypeOfInjury(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/TypeOfInjury`);
  }

  GetTypeOfObservationCategory(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/TypeOfObservationCategory`);
  }

  GetViolationCategory(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ViolationCategory`);
  }

  GetDriverName(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Driver`);
  }

  GetVehicleName(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Vehicle`);
  }

  GetRoutName(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/RouteName`);
  }

  GetCommuncationMethod(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ComminucationMethod`);
  }

  GetPassengerName(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Passenger`);
  }

  GetPassengerNameForExcel(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Passenger/GetAllForExcel`);
  }

  GetDriverData(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Driver/${id}`);
  }

  GetDriverDataForExcel(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Driver/GetAllForExcel`);
  }

  GetVehicleData(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Vehicle/${id}`);
  }

  GetSJPDataByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/JMP/SJPByPage/${pageNumber}?pagesize=10`);
  }

  GetArrivedSJPDataByPage(pageNumber: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/JMP/ArrivedSJPByPage/${pageNumber}?pagesize=3`);
  }

  GetDataForCharts(filter: string, month: number, userId: string, userRole: string): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/StopCardRegister/GetDataForCharts?query=${filter}&month=${month}&UserId=${userId}&UserRole=${userRole}`);
  }

  GetRigPerformanceData(UserID: string, userRole: string): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/RigMovePerformance/GetAllWithResponseDTO?UserID=${UserID}&UserRole=${userRole}`);
  }

  GetRigPerformanceDataForCharts(RigNo: number, UserID: string, UserRole: string): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/RigMovePerformance/GetAllForAnalysis/${RigNo}?UserID=${UserID}&UserRole=${UserRole}`);
  }

  GetRigPerformanceDataForCompareCharts(RigNo1: number, RigNo2: number, Year: number, UserID: string, userRole: string): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/RigMovePerformance/GetAllForCompareAnalysis?RigID1=${RigNo1}&RigID2=${RigNo2}&Year=${Year}&UserID=${UserID}&UserRole=${userRole}`);
  }

  GetDataForChartsCompare(month1: number, month2: number, Year:number,userId: string, userRole: string): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/StopCardRegister/GetDataByMonthCompare?date1=${month1}&date2=${month2}&year=${Year}&UserId=${userId}&UserRole=${userRole}`);
  }

  GetEmpCode(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/EmpCode`);
  }
  GetEmpCodeDataForExcel(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/EmpCode/GetAllForExcel`);
  }

  GetEmpCodeByID(EmpCodeID: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/EmpCode/${EmpCodeID}`);
  }

  GetEmpCodeByCode(EmpCode: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/EmpCode/Code/${EmpCode}`);
  }

  GetEmpCodeByCodeAndPosition(EmpCode: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/EmpCode/CodeAndPosition/${EmpCode}`);
  }

  GetPositions(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Positions`);
  }

  GetPositionByID(ID: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Positions/${ID}`);
  }
  GetResponsibility(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Responsibility`);
  }

  GetResponsibilityByID(ID: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Responsibility/${ID}`);
  }
  GetClient(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Client`);
  }
  GetClientByID(ID: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Client/${ID}`);
  }
  GetLeadershipVisit(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/LeadershipVisit`);
  }
  GetLeadershipVisitsByID(ID: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/LeadershipVisit/${ID}`);
  }
  GetCrew(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Crew`);
  }
  GetCrewByID(ID: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Crew/${ID}`);
  }
  GetDaysSinceNoLTI(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/DaysSinceNoLTI`);
  }
  GetDaysSinceNoLTITOCheck(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/DaysSinceNoLTI/GetToCheck`);
  }
  GetDaysSinceNoLTIByID(ID: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/DaysSinceNoLTI/${ID}`);
  }
  GetDaysSinceNoFatality(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/DaysSinceNoFatality`);
  }
  GetDaysSinceNoFatalityByID(ID: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/DaysSinceNoFatality/${ID}`);
  }
  GetDaysSinceNoFatalityByRigNumber(RigNumber: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/DaysSinceNoFatality/ByRigNumber/${RigNumber}`);
  }
  GetDaysSinceNoLTIByRigNumber(RigNumber: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/DaysSinceNoLTI/ByRigNumber/${RigNumber}`);
  }

  //********************** Corrective Action Report *********************** */
  GetRootCause(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/RootCauses`);
  }

  GetStandard(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Standard`);
  }

  GetCorrectiveObservation(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CorrectiveObservation`);
  }

  GetCorrectiveDataById(id: number, userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CorrectiveAction/GetDataById/${id}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetCorrectiveDataByDate(date: Date, userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CorrectiveAction/GetDataByDate/${date}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetCorrective(userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CorrectiveAction/GetData?UserId=${userId}&UserRole=${userRole}`);
  }

  GetCorrectiveResponsability(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CorrectiveResponsability`);
  }

  GetCorrectiveForExcel(userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CorrectiveAction/GetDataForExcel?UserId=${userId}&UserRole=${userRole}`);
  }

  GetCorrectiveForAnalysis(RigId: number, userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CorrectiveAction/GetDataForAnalysis?RigId=${RigId}&UserId=${userId}&UserRole=${userRole}`);
  }

  GetCorrectiveByFilter(Responsability: string, Title: string, Date: string, Status: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CorrectiveAction/GetDataByFilter?Responsability=${Responsability}&Title=${Title}&date=${Date}&Status=${Status}`);
  }

  GetCorrectiveByResponsability(Responsability: string, UserId: string, UserRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CorrectiveAction/GetDataByResponsability?Responability=${Responsability}&UserID=${UserId}&UserRole=${UserRole}`);
  }

  GetCorrectiveByDateForAnalysis(UserId: string, UserRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CorrectiveAction/GetDataByDateForAnalysis?UserId=${UserId}&UserRole=${UserRole}`);
  }

  GetCorrectiveByObservation(Observation: string, UserId: string, UserRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CorrectiveAction/GetDataByObservation?Observation=${Observation}&UserID=${UserId}&UserRole=${UserRole}`);
  }

  GetCorrectiveByStandard(Standard: string, UserId: string, UserRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CorrectiveAction/GetDataByStandard?Standard=${Standard}&UserID=${UserId}&UserRole=${UserRole}`);
  }

  //*********************** Crane ********************************** */
  GetCraneForExcel(userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Crane/GetDataForExcel?UserId=${userId}&UserRole=${userRole}`);
  }

  GetCraneDataById(id: number, userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Crane/GetDataById/${id}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetCrane(userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Crane/GetData?UserId=${userId}&UserRole=${userRole}`);
  }


  GetCraneForAnalysis(RigId: number, userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Crane/GetDataForAnalysis?RigId=${RigId}&UserId=${userId}&UserRole=${userRole}`);
  }


  GetCraneDataByDate(date: Date, userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Crane/GetDataByDate/${date}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetCraneDataByDateAndRig(date: Date, rigNo: number, userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Crane/GetDataByDateAndRig/${date}?rigNo=${rigNo}&UserId=${userId}&UserRole=${userRole}`);
  }


  //*********************** Forklift ********************************** */
  GetForkliftForExcel(userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Forklift/GetDataForExcel?UserId=${userId}&UserRole=${userRole}`);
  }

  GetForkliftDataById(id: number, userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Forklift/GetDataById/${id}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetForklift(userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Forklift/GetData?UserId=${userId}&UserRole=${userRole}`);
  }


  GetForkliftForAnalysis(RigId: number, userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Forklift/GetDataForAnalysis?RigId=${RigId}&UserId=${userId}&UserRole=${userRole}`);
  }


  GetForkliftDataByDate(date: Date, userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Forklift/GetDataByDate/${date}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetForkliftDataByDateAndRig(date: Date, rigNo: number, userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Forklift/GetDataByDateAndRig/${date}?rigNo=${rigNo}&UserId=${userId}&UserRole=${userRole}`);
  }

  //*********************** HSEEquipmentList ********************************** */
  GetHSEEquipmentList(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/HSEEquipmentList`);
  }

  // ********************* Daily Lifting Report**********
  GetCraneDailyReport(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CraneDailyLifting`);
  }
  GetCraneDailyLiftingByID(CraneDailyLiftingID: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CraneDailyLifting/${CraneDailyLiftingID}`);
  }

  GetForkliftDailyReport(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ForkDailyLifting`);
  }
  GetForkliftDailyLiftingByID(ForkliftDailyLiftingID: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ForkDailyLifting/${ForkliftDailyLiftingID}`);
  }

  //CertificatesType
  GetCertificatesType(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CertificatesType`);
  }
}
