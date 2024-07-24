import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IAPIResult } from 'SharedClasses/IAPIResult';
import { IAccidentCauses } from 'SharedClasses/IAccidentCauses';
import { IClassification } from 'SharedClasses/IClassification';
import { IClassificationOfAccident } from 'SharedClasses/IClassificationOfAccident';
import { IComminucationMethod } from 'SharedClasses/IComminucationMethod';
import { IDriver } from 'SharedClasses/IDriver';
import { IJMP } from 'SharedClasses/IJMP';
import { IPassenger } from 'SharedClasses/IPassenger';
import { IPreventionCategory } from 'SharedClasses/IPreventionCategory';
import { IQHSEPosition } from 'SharedClasses/IQHSEPosition';
import { IQHSEPositionName } from 'SharedClasses/IQHSEPositionName';
import { IReportedByName } from 'SharedClasses/IReportedByName';
import { IReportedByPosition } from 'SharedClasses/IReportedByPosition';
import { IRig } from 'SharedClasses/IRig';
import { IRigMovePerformanceEvaluation } from 'SharedClasses/IRigMovePerformanceEvaluation';
import { IRouteName } from 'SharedClasses/IRouteName';
import { IToolPusherPosition } from 'SharedClasses/IToolPusherPosition';
import { IToolPusherPositionName } from 'SharedClasses/IToolPusherPositionName';
import { ITypeOfInjury } from 'SharedClasses/ITypeOfInjury';
import { ITypeOfObservationCategory } from 'SharedClasses/ITypeOfObservationCategory';
import { IVehicle } from 'SharedClasses/IVehicle';
import { IViolationCategory } from 'SharedClasses/IViolationCategory';
import { Observable } from 'rxjs';
import { IEmpCode } from 'SharedClasses/IEmpCode';
import { IPosition } from 'SharedClasses/IPosition';
import { ISubjectList } from 'SharedClasses/ISubjectList';
import { IResponsibility } from 'SharedClasses/IResponsibility';
import { IDrillType } from 'SharedClasses/IDrillType';
import { IClient } from 'SharedClasses/IClient';
import { ILeadershipVisits } from 'SharedClasses/ILeadershipVisits';
import { ICrew } from 'SharedClasses/ICrew';
import { IDaysSinceNoFatality } from 'SharedClasses/IDaysSinceNoFatality';
import { IDaysSinceNoLTI } from 'SharedClasses/IDaysSinceNoLTI';
import { IRootCause } from 'SharedClasses/IRootCause';
import { IStandard } from 'SharedClasses/IStandard';
import { ICorrectiveObservation } from 'SharedClasses/ICorrectiveObservation';
import { ICorrectiveAction } from 'SharedClasses/ICorrectiveAction';
import { IForklift } from 'SharedClasses/IForklift';
import { ICrane } from 'SharedClasses/ICrane';
import { ICorrectiveResponsability } from 'SharedClasses/ICorrectiveResponsability';
import { IHSEEquipmentList } from 'SharedClasses/IHSEEquipmentList';
import { ICraneDailyLifting } from 'SharedClasses/ICraneDailyLifting';
import { IForkliftDailyLifting } from 'SharedClasses/IForkliftDailyLifting';
import { ICertificatesType } from 'SharedClasses/ICertificatesType';

@Injectable({
  providedIn: 'root'
})
export class EditDataService {

  constructor(private http: HttpClient) { }

  EditAccidentCauses(AccidentCauses: IAccidentCauses): Observable<IAccidentCauses> {
    return this.http.put<IAccidentCauses>(`http://localhost:5000/api/AccidentCauses/${AccidentCauses.id}`, AccidentCauses);
  }

  EditSubjectList(SubjectList: ISubjectList): Observable<ISubjectList> {
    return this.http.put<ISubjectList>(`http://localhost:5000/api/SubjectList/${SubjectList.id}`, SubjectList);
  }

  EditDrillTypes(id: number, DrillTypes: FormData): Observable<FormData> {
    return this.http.put<FormData>(`http://localhost:5000/api/DrillType/Edit/${id}`, DrillTypes);
  }

  GetAccidentCausesById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/AccidentCauses/${id}`);
  }

  GetSubjectListById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/SubjectList/${id}`);
  }

  GetDrillTypesById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/DrillType/${id}`);
  }
  EditClassification(Classification: IClassification): Observable<IClassification> {
    return this.http.put<IClassification>(`http://localhost:5000/api/Classification/${Classification.id}`, Classification);
  }

  GetClassificationById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Classification/${id}`);
  }

  EditClassificationOfAccident(ClassificationOfAccident: IClassificationOfAccident): Observable<IClassificationOfAccident> {
    return this.http.put<IClassificationOfAccident>(`http://localhost:5000/api/ClassificationOfAccident/${ClassificationOfAccident.id}`, ClassificationOfAccident);
  }

  GetClassificationOfAccidentById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ClassificationOfAccident/${id}`);
  }

  EditComminucationMethod(ComminucationMethod: IComminucationMethod): Observable<IComminucationMethod> {
    return this.http.put<IComminucationMethod>(`http://localhost:5000/api/ComminucationMethod/${ComminucationMethod.id}`, ComminucationMethod);
  }

  GetComminucationMethodById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ComminucationMethod/${id}`);
  }



  EditPassenger(Passenger: IPassenger): Observable<IPassenger> {
    return this.http.put<IPassenger>(`http://localhost:5000/api/Passenger/${Passenger.id}`, Passenger);
  }

  GetPassengerById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Passenger/${id}`);
  }

  EditPreventionCategory(PreventionCategory: IPreventionCategory): Observable<IPreventionCategory> {
    return this.http.put<IPreventionCategory>(`http://localhost:5000/api/PreventionCategory/${PreventionCategory.id}`, PreventionCategory);
  }

  GetPreventionCategoryById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/PreventionCategory/${id}`);
  }

  EditQHSEPosition(QHSEPosition: IQHSEPosition): Observable<IQHSEPosition> {
    return this.http.put<IQHSEPosition>(`http://localhost:5000/api/QHSEPosition/${QHSEPosition.id}`, QHSEPosition);
  }

  GetQHSEPositionById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/QHSEPosition/${id}`);
  }

  EditQHSEPositionName(QHSEPositionName: IQHSEPositionName): Observable<IQHSEPositionName> {
    return this.http.put<IQHSEPositionName>(`http://localhost:5000/api/QHSEPositionName/${QHSEPositionName.id}`, QHSEPositionName);
  }

  GetQHSEPositionNameById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/QHSEPositionName/${id}`);
  }

  EditReportedByName(ReportedByName: IReportedByName): Observable<IReportedByName> {
    return this.http.put<IReportedByName>(`http://localhost:5000/api/ReportedByName/${ReportedByName.id}`, ReportedByName);
  }

  GetReportedByNameById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ReportedByName/${id}`);
  }

  EditReportedByPosition(ReportedByPosition: IReportedByPosition): Observable<IReportedByPosition> {
    return this.http.put<IReportedByPosition>(`http://localhost:5000/api/ReportedByPosition/${ReportedByPosition.id}`, ReportedByPosition);
  }

  GetReportedByPositionById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ReportedByPosition/${id}`);
  }

  EditRig(Rig: IRig): Observable<IRig> {
    return this.http.put<IRig>(`http://localhost:5000/api/Rig/${Rig.id}`, Rig);
  }

  GetRigById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Rig/${id}`);
  }

  EditRouteName(RouteName: IRouteName): Observable<IRouteName> {
    return this.http.put<IRouteName>(`http://localhost:5000/api/RouteName/${RouteName.id}`, RouteName);
  }

  GetRouteNameById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/RouteName/${id}`);
  }

  EditToolPusherPosition(ToolPusherPosition: IToolPusherPosition): Observable<IToolPusherPosition> {
    return this.http.put<IToolPusherPosition>(`http://localhost:5000/api/ToolPusherPosition/${ToolPusherPosition.id}`, ToolPusherPosition);
  }

  GetToolPusherPositionById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ToolPusherPosition/${id}`);
  }

  EditToolPusherPositionName(ToolPusherPositionName: IToolPusherPositionName): Observable<IToolPusherPositionName> {
    return this.http.put<IToolPusherPositionName>(`http://localhost:5000/api/ToolPusherPositionName/${ToolPusherPositionName.id}`, ToolPusherPositionName);
  }

  GetToolPusherPositionNameById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ToolPusherPositionName/${id}`);
  }

  EditTypeOfInjury(TypeOfInjury: ITypeOfInjury): Observable<ITypeOfInjury> {
    return this.http.put<ITypeOfInjury>(`http://localhost:5000/api/TypeOfInjury/${TypeOfInjury.id}`, TypeOfInjury);
  }

  GetTypeOfInjuryById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/TypeOfInjury/${id}`);
  }

  EditTypeOfObservationCategory(TypeOfObservationCategory: ITypeOfObservationCategory): Observable<ITypeOfObservationCategory> {
    return this.http.put<ITypeOfObservationCategory>(`http://localhost:5000/api/TypeOfObservationCategory/${TypeOfObservationCategory.id}`, TypeOfObservationCategory);
  }

  GetTypeOfObservationCategoryById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/TypeOfObservationCategory/${id}`);
  }

  EditVehicle(Vehicle: IVehicle): Observable<IVehicle> {
    return this.http.put<IVehicle>(`http://localhost:5000/api/Vehicle/${Vehicle.id}`, Vehicle);
  }

  GetVehicleById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Vehicle/${id}`);
  }

  EditViolationCategory(ViolationCategory: IViolationCategory): Observable<IViolationCategory> {
    return this.http.put<IViolationCategory>(`http://localhost:5000/api/ViolationCategory/${ViolationCategory.id}`, ViolationCategory);
  }

  GetViolationCategoryById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/ViolationCategory/${id}`);
  }

  GetJMPById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/JMP/ID/${id}`);
  }

  EditJMPForm(id: number, jmp: IJMP): Observable<IJMP> {
    return this.http.put<IJMP>(`http://localhost:5000/api/JMP/${id}`, jmp);
  }

  GetDriverById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Driver/${id}`);
  }

  EditDriverForm(Driver: IDriver): Observable<IDriver> {
    return this.http.put<IDriver>(`http://localhost:5000/api/Driver/${Driver.id}`, Driver);
  }

  EditNotifiyStatus(id: number, notifyStatus: number, jmp: IJMP): Observable<IAPIResult> {
    return this.http.put<IAPIResult>(`http://localhost:5000/api/JMP?id=${id}&notifyStatus=${notifyStatus}`, jmp);
  }

  EditArrivalStatus(id: number, arrivalStatus: boolean, jmp: IJMP): Observable<IAPIResult> {
    return this.http.put<IAPIResult>(`http://localhost:5000/api/JMP/ArrivalStatus?id=${id}&arrivalStatus=${arrivalStatus}`, jmp);
  }

  EditRigMovePerformance(id: number, RigPerformance: IRigMovePerformanceEvaluation): Observable<IRigMovePerformanceEvaluation> {
    return this.http.put<IRigMovePerformanceEvaluation>(`http://localhost:5000/api/RigMovePerformance/${id}`, RigPerformance);
  }
  EditEmpCode(id: number, EmpCode: IEmpCode): Observable<IEmpCode> {
    return this.http.put<IEmpCode>(`http://localhost:5000/api/EmpCode/${id}`, EmpCode);
  }
  EditPositon(id: number, Positon: IPosition): Observable<IPosition> {
    return this.http.put<IPosition>(`http://localhost:5000/api/Positions/${id}`, Positon);
  }
  EditResponsibility(id: number, Responsibility: any): Observable<any> {
    return this.http.put<any>(`http://localhost:5000/api/Responsibility/${id}`, Responsibility);
  }
  EditClient(id: number, Client: FormData): Observable<IClient> {
    return this.http.put<IClient>(`http://localhost:5000/api/Client/${id}`, Client);
  }
  EditLeadershipVisits(id: number, LeadershipVisit: FormData): Observable<ILeadershipVisits> {
    return this.http.put<ILeadershipVisits>(`http://localhost:5000/api/LeadershipVisit/${id}`, LeadershipVisit);
  }
  EditCrew(id: number, Crew: FormData): Observable<ICrew> {
    return this.http.put<ICrew>(`http://localhost:5000/api/Crew/${id}`, Crew);
  }
  EditDaysSinceNoLTI(id: number, DaysSinceNoLTI: FormData): Observable<IDaysSinceNoLTI> {
    return this.http.put<IDaysSinceNoLTI>(`http://localhost:5000/api/DaysSinceNoLTI/${id}`, DaysSinceNoLTI);
  }
  EditDaysSinceNoFatality(id: number, DaysSinceNoFatality: FormData): Observable<IDaysSinceNoFatality> {
    return this.http.put<IDaysSinceNoFatality>(`http://localhost:5000/api/DaysSinceNoFatality/${id}`, DaysSinceNoFatality);
  }

  //****************** Corrective Action Report ****************************** */
  EditRootCause(RootCause: IRootCause): Observable<IRootCause> {
    return this.http.put<IRootCause>(`http://localhost:5000/api/RootCauses/${RootCause.id}`, RootCause);
  }

  GetRootCauseById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/RootCauses/${id}`);
  }

  EditStandard(Standard: IStandard): Observable<IStandard> {
    return this.http.put<IStandard>(`http://localhost:5000/api/Standard/${Standard.id}`, Standard);
  }

  GetStandardById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Standard/${id}`);
  }

  EditCorrectiveResponsability(CorrectiveResponsability: ICorrectiveResponsability): Observable<ICorrectiveResponsability> {
    return this.http.put<ICorrectiveResponsability>(`http://localhost:5000/api/CorrectiveResponsability/${CorrectiveResponsability.id}`, CorrectiveResponsability);
  }

  GetCorrectiveResponsabilityById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CorrectiveResponsability/${id}`);
  }

  EditCorrectiveObservation(CorrectiveObservation: ICorrectiveObservation): Observable<ICorrectiveObservation> {
    return this.http.put<ICorrectiveObservation>(`http://localhost:5000/api/CorrectiveObservation/${CorrectiveObservation.id}`, CorrectiveObservation);
  }

  GetCorrectiveObservationById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CorrectiveObservation/${id}`);
  }

  EditCorrective(id: number, Corrective: FormData): Observable<FormData> {
    return this.http.put<FormData>(`http://localhost:5000/api/CorrectiveAction/${id}`, Corrective);
  }

  GetCorrectiveById(id: number, userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CorrectiveAction/${id}?UserId=${userId}&UserRole=${userRole}`);
  }

  //************************ Crane ****************************** */
  EditCrane(id: number, Crane: ICrane): Observable<ICrane> {
    return this.http.put<ICrane>(`http://localhost:5000/api/Crane/${id}`, Crane);
  }

  GetCraneById(id: number, userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Crane/${id}?UserId=${userId}&UserRole=${userRole}`);
  }


  //*************************** Forklift ********************************** */
  EditForklift(id: number, Forklift: IForklift): Observable<IForklift> {
    return this.http.put<IForklift>(`http://localhost:5000/api/Forklift/${id}`, Forklift);
  }

  GetForkliftById(id: number, userId: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Forklift/${id}?UserId=${userId}&UserRole=${userRole}`);
  }

  //*************************** HSEEquipmentList ********************************** */

  EditHSEEquipmentList(HSEEquipmentList: IHSEEquipmentList): Observable<IHSEEquipmentList> {
    return this.http.put<IHSEEquipmentList>(`http://localhost:5000/api/HSEEquipmentList/${HSEEquipmentList.id}`, HSEEquipmentList);
  }

  GetHSEEquipmentListById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/HSEEquipmentList/${id}`);
  }

  //*************************** CraneDailyLifting ********************************** */
  EditCraneDailyLifting(id: number, CraneDailyLifting: ICraneDailyLifting): Observable<ICraneDailyLifting> {
    return this.http.put<ICraneDailyLifting>(`http://localhost:5000/api/CraneDailyLifting/${id}`, CraneDailyLifting);
  }
  EditForkliftDailyLifting(id: number, ForkliftDailyLifting: IForkliftDailyLifting): Observable<IForkliftDailyLifting> {
    return this.http.put<IForkliftDailyLifting>(`http://localhost:5000/api/ForkDailyLifting/${id}`, ForkliftDailyLifting);
  }

  //CertificatesType
  GetCertificatesTypeById(id: number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/CertificatesType/${id}`);
  }
  EditCertificatesType(CertificatesType: ICertificatesType): Observable<ICertificatesType> {
    return this.http.put<ICertificatesType>(`http://localhost:5000/api/CertificatesType/${CertificatesType.id}`, CertificatesType);
  }
}
