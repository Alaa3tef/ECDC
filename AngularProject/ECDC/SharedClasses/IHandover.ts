import { HSEEquipment } from "./HSEEquipment";
import { HSEInventory } from "./HSEInventory";
import { MaterialRequested } from "./MaterialRequested";
import { ShiftDrillTypes } from "./ShiftDrillTypes";
import { Visits } from "./Visits";

export interface IHandover{
  id:number,

  shiftDateFrom:Date,

  shiftDateTo:Date,

  rigId:number,


  wellName:string,

  client:string,

  leavingEmpCode:number,
  leavingEmpName:string,
  comingEmpCode:number,
  comingEmpName:string,

  stopCards:number,

  monthlyStopCards:number,

  openStopCards:number,

  drills:number,

  monthlyDrills:number,

  safetyAlerts:number,

  monthlySafetyAlerts:number,

  weeklyInspection:number,

  internalAudit:number,

  externalAudit:number,

  medicalReport:number,

  trainingMatrix:number,

  rigMove:number,

  incidentReport:number,

  trackingSheetClosedPoints:number,

  potentialHazardReport:number,

  shiftDrillTypes:ShiftDrillTypes[];
  visits:Visits[];
  hseInventory:HSEInventory[];
  hseEquipment:HSEEquipment[];
  materialRequested:MaterialRequested[];

  shiftBrief:string,

  qhseEngineer:string,

  userID:string,
  isDeleted:boolean
}
