
import { HeavyTruck } from "./HeavyTruck"
import { LightBus } from "./LightBus"
import { ManPickup } from "./ManPickup"
import { RigPickup } from "./RigPickup"

export interface IVehicleWeeklyChecklist {
  id: number,
  rigId:number,
  date:Date,
  
  cient: string,
  location: string,
  manPickupVehiclePlateNo: number,
  manPickupDriverName: string,
  rigPickupVehiclePlateNo: number,
  rigPickupDriverName: string,
  primeMoverPlateNo: number,
  trailerPlateNo: number,
  heavyTruckDriverName: string,
  lightBusVehiclePlateNo: number,
  lightBusDriverName: string,
  manPickups: ManPickup[],
  rigPickups: RigPickup[],
  lightBus: LightBus[],
  heavyTrucks:HeavyTruck [],
  userID:string,
  isDeleted:boolean,
}
