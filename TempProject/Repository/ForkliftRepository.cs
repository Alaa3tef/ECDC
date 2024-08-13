using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Security.Policy;
using TempProject.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TempProject.Repository
{
    public class ForkliftRepository : IForkliftRepository
	{
        Context c;
        public ForkliftRepository(Context c)
        {
            this.c = c;
        }

        public List<Forklift> getall()
        {
			return c.Forklifts
				.Include(a => a.Rig)
				.Include(a => a.user)
				.Where(a => a.IsDeleted == false)
				.Select(a => new Forklift
				{
					Id = a.Id,
					Rig = new Rig { Number = a.Rig.Number, Id = a.Rig.Id },
					RigId=a.RigId,
					Date = a.Date,
					WellName = a.WellName,
					UnitNo = a.UnitNo,
					QHSEEngineer = a.QHSEEngineer,
					//HrsSinceOilChange = a.HrsSinceOilChange,
					CleanAndTidy = a.CleanAndTidy,
					EngineOilLevel = a.EngineOilLevel,
					TransmissionOilLevel = a.TransmissionOilLevel,
					RadiatorWaterLevel = a.RadiatorWaterLevel,
					HydraulicOilLevel = a.HydraulicOilLevel,
					V_beltsTension = a.V_beltsTension,
					DrainWater = a.DrainWater,
					Leaks = a.Leaks,
					BatteryHolder = a.BatteryHolder,
					GaugesForCorrectReadings = a.GaugesForCorrectReadings,
					TirePressure = a.TirePressure,
					TireCondition = a.TireCondition,
					FuelTanksFull = a.FuelTanksFull,
					Lights = a.Lights,
					Alarms = a.Alarms,
					HoistingSystem = a.HoistingSystem,
					AbnormalNoise = a.AbnormalNoise,
					Brakes = a.Brakes,
					LiquidLevel = a.LiquidLevel,
					Instruments = a.Instruments,
					EngineDriveBelts = a.EngineDriveBelts,
					CarriageRollers = a.CarriageRollers,
					SteeringSystem = a.SteeringSystem,
					SeatBelt = a.SeatBelt,
					HoseofCoilCooling = a.HoseofCoilCooling,
					FirstAidBox = a.FirstAidBox,
					CrankShaft = a.CrankShaft,
					DriverSeat = a.DriverSeat,
					EngineV_belts = a.EngineV_belts,
					Wipers = a.Wipers,
					ExistingCorrosion = a.ExistingCorrosion,
					DriverName = a.DriverName,
					CleanAndTidyRemarks = a.CleanAndTidyRemarks,
					EngineOilLevelRemarks = a.EngineOilLevelRemarks,
					TransmissionOilLevelRemarks = a.TransmissionOilLevelRemarks,
					RadiatorWaterLevelRemarks = a.RadiatorWaterLevelRemarks,
					HydraulicOilLevelRemarks = a.HydraulicOilLevelRemarks,
					V_beltsTensionRemarks = a.V_beltsTensionRemarks,
					DrainWaterRemarks = a.DrainWaterRemarks,
					LeaksRemarks = a.LeaksRemarks,
					BatteryHolderRemarks = a.BatteryHolderRemarks,
					GaugesForCorrectReadingsRemarks = a.GaugesForCorrectReadingsRemarks,
					TyrePressureRemarks = a.TyrePressureRemarks,
					TyreConditionRemarks = a.TyreConditionRemarks,
					FuelTanksFullRemarks = a.FuelTanksFullRemarks,
					LightsRemarks = a.LightsRemarks,
					AlarmsRemarks = a.AlarmsRemarks,
					HoistingSystemRemarks = a.HoistingSystemRemarks,
					AbnormalNoiseRemarks = a.AbnormalNoiseRemarks,
					BrakesRemarks = a.BrakesRemarks,
					LiquidLevelRemarks = a.LiquidLevelRemarks,
					InstrumentsRemarks = a.InstrumentsRemarks,
					EngineDriveBeltsRemarks = a.EngineDriveBeltsRemarks,
					CarriageRollersRemarks = a.CarriageRollersRemarks,
					SteeringSystemRemarks = a.SteeringSystemRemarks,
					SeatBeltRemarks = a.SeatBeltRemarks,
					HoseofCoilCoolingRemarks = a.HoseofCoilCoolingRemarks,
					FirstAidBoxRemarks = a.FirstAidBoxRemarks,
					CrankShaftRemarks = a.CrankShaftRemarks,
					DriverSeatRemarks = a.DriverSeatRemarks,
					EngineV_beltsRemarks = a.EngineV_beltsRemarks,
					WipersRemarks = a.WipersRemarks,
					ExistingCorrosionRemarks = a.ExistingCorrosionRemarks,
					userID=a.userID,
					user = new IdentityUser { UserName = a.user.UserName, Id = a.user.Id }
				}).ToList();
        }
    }
}
