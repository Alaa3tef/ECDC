import { DailyRecordStacticsList } from "./DailyRecordStacticsList";
import { PermitsToWorkList } from "./PermitsToWorkList";
import { SummaryDailyList } from "./SummaryDailyList";
export interface IDailyLiftingReport {
  id: number,
  rigId: number,
  date: Date,
  dailyRecordStacticsListDTOs: DailyRecordStacticsList[],
  summaryDailyListDTOs: SummaryDailyList[],
  permitsToWorkListDTOs: PermitsToWorkList[],
  liftingEngieerCode: number,
  liftingEngieerName: string,
  userID: string,
  isDeleted: boolean,
  mobileCraneName: string
  type: string
  chasisNo: number
  capacity: string
  dateofLastInspection: Date
  dateofNextInspection: Date

  forkName: string,
  forkType: string,
  forkChasisNo: number,
  forkCapacity: string,
  forkDateofLastInspection: Date,
  forkDateofNextInspection: Date,
}
