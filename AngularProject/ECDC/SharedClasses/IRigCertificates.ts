import { AirHoist1 } from "./AirHoist1"
import { AirHoist2 } from "./AirHoist2"
import { Forklift1 } from "./Forklift1"
import { Forklift2 } from "./Forklift2"
import { HSEEquipmentTable } from "./HSEEquipmentTable"
import { HoistingSystem } from "./HoistingSystem"
import { HydraulicWinch1 } from "./HydraulicWinch1"
import { HydraulicWinch2 } from "./HydraulicWinch2"
import { ManRidingWinch } from "./ManRidingWinch"
import { MobileCrane1 } from "./MobileCrane1"
import { MobileCrane2 } from "./MobileCrane2"
import { MudCirculationSystem } from "./MudCirculationSystem"
import { OtherSystem } from "./OtherSystem"
import { PersonnelCerificates } from "./PersonnelCerificates"
import { PowerSystem } from "./PowerSystem"
import { PresssureReliefValve } from "./PresssureReliefValve"
import { RotarySystem } from "./RotarySystem"
import { WellControlSystem } from "./WellControlSystem"

export interface IRigCertificates {
  id: number,
  isDeleted: boolean,
  rigId: number,
  date: Date,
  certificationLiftingGear: Date,
  certificationCATIII: Date,
  certificationCATIV: Date,
  certificationGaugeCalibraion: Date,
  certificationWallThickness: Date,
  dueLiftingGear: Date,
  dueCATIII: Date,
  dueCATIV: Date,
  dueGaugeCalibraion: Date,
  dueWallThickness: Date,

  hseEquipmentTable: HSEEquipmentTable[],
  hoistingSystem: HoistingSystem[],
  rotarySystem: RotarySystem[],
  mudCirculationSystem: MudCirculationSystem[],
  wellControlSystem: WellControlSystem[],
  powerSystem: PowerSystem[],
  otherSystem: OtherSystem[],
  presssureReliefValve: PresssureReliefValve[],
  personnelCerificates: PersonnelCerificates[],

  mobileCrane1: MobileCrane1,
  mobileCrane2: MobileCrane2,
  forklift1: Forklift1,
  forklift2: Forklift2,
  airHoist1: AirHoist1,
  airHoist2: AirHoist2,
  hydraulicWinch1: HydraulicWinch1,
  hydraulicWinch2: HydraulicWinch2,
  manRidingWinch: ManRidingWinch,
  userID: string,
}