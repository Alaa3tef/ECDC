using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using TempProject.Models;

namespace TempProject.Repository
{
    public class CraneRepository : ICraneRepository
	{
        Context c;
        public CraneRepository(Context c)
        {
            this.c = c;
        }

        public List<Crane> getall()
        {
            return c.Cranes
                .Include(a => a.Rig)
                .Where(a => a.IsDeleted == false)
				.Select(a => new Crane
                {
                    Id = a.Id,
                    Rig = new Rig { Number = a.Rig.Number,Id= a.Rig.Id },
					RigId = a.RigId,
					Date=a.Date,
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
					LoadComputer = a.LoadComputer,
					GaugesForCcorrectReadings = a.GaugesForCcorrectReadings,
					TirePressure = a.TirePressure,
					FuelTanksFull = a.FuelTanksFull,
					WireRopes = a.WireRopes,
					SwingBrake = a.SwingBrake,
					TestLimitSwitches = a.TestLimitSwitches,
					TestOutriggers = a.TestOutriggers,
					AbnormalNoise = a.AbnormalNoise,
					ServiceBrakes = a.ServiceBrakes,
					Sheaves = a.Sheaves,
					SpoolingOfWire = a.SpoolingOfWire,
					Hookcondition = a.Hookcondition,
					BoomSections = a.BoomSections,
					EngineV_belts = a.EngineV_belts,
					WiringVisually = a.WiringVisually,
					LoadIndicator = a.LoadIndicator,
					AudibleAlarm = a.AudibleAlarm,
					LoadLimiting = a.LoadLimiting,
					BoomAngle = a.BoomAngle,
					LimitSwitch = a.LimitSwitch,
					EmergencyShutDown = a.EmergencyShutDown,
					OperatingReturn = a.OperatingReturn,
					OperatingControls = a.OperatingControls,
					HeadLight = a.HeadLight,
					ReverseAlarm = a.ReverseAlarm,
					ParkingBrake = a.ParkingBrake,
					SafetyBelt = a.SafetyBelt,
					DriverSeat = a.DriverSeat,
					Wipers = a.Wipers,
					ExistingCorrosion = a.ExistingCorrosion,
					TireBolts = a.TireBolts,
					SafeLoadIndicator = a.SafeLoadIndicator,
					ScreenCurtains = a.ScreenCurtains,
					Outrigger = a.Outrigger,
					StrangeSound=a.StrangeSound,
					CleanAndTidyRemarks = a.CleanAndTidyRemarks,
					EngineOilLevelRemarks = a.EngineOilLevelRemarks,
					TransmissionOilLevelRemarks = a.TransmissionOilLevelRemarks,
					RadiatorWaterLevelRemarks = a.RadiatorWaterLevelRemarks,
					HydraulicOilLevelRemarks = a.HydraulicOilLevelRemarks,
					V_beltsTensionRemarks = a.V_beltsTensionRemarks,
					DrainWaterRemarks = a.DrainWaterRemarks,
					LeaksRemarks = a.LeaksRemarks,
					BatteryHolderRemarks = a.BatteryHolderRemarks,
					LoadComputerRemarks = a.LoadComputerRemarks,
					GaugesForCcorrectReadingsRemarks = a.GaugesForCcorrectReadingsRemarks,
					TirePressureRemarks = a.TirePressureRemarks,
					FuelTanksFullRemarks = a.FuelTanksFullRemarks,
					WireRopesRemarks = a.WireRopesRemarks,
					SwingBrakeRemarks = a.SwingBrakeRemarks,
					TestLimitSwitchesRemarks = a.TestLimitSwitchesRemarks,
					TestOutriggersRemarks = a.TestOutriggersRemarks,
					AbnormalNoiseRemarks = a.AbnormalNoiseRemarks,
					ServiceBrakesRemarks = a.ServiceBrakesRemarks,
					SheavesRemarks = a.SheavesRemarks,
					SpoolingOfWireRemarks = a.SpoolingOfWireRemarks,
					HookconditionRemarks = a.HookconditionRemarks,
					BoomSectionsRemarks = a.BoomSectionsRemarks,
					EngineV_beltsRemarks = a.EngineV_beltsRemarks,
					WiringVisuallyRemarks = a.WiringVisuallyRemarks,
					LoadIndicatorRemarks = a.LoadIndicatorRemarks,
					AudibleAlarmRemarks = a.AudibleAlarmRemarks,
					LoadLimitingRemarks = a.LoadLimitingRemarks,
					BoomAngleRemarks = a.BoomAngleRemarks,
					LimitSwitchRemarks = a.LimitSwitchRemarks,
					EmergencyShutDownRemarks = a.EmergencyShutDownRemarks,
					OperatingReturnRemarks = a.OperatingReturnRemarks,
					OperatingControlsRemarks = a.OperatingControlsRemarks,
					HeadLightRemarks = a.HeadLightRemarks,
					ReverseAlarmRemarks = a.ReverseAlarmRemarks,
					ParkingBrakeRemarks = a.ParkingBrakeRemarks,
					SafetyBeltRemarks = a.SafetyBeltRemarks,
					DriverSeatRemarks = a.DriverSeatRemarks,
					WipersRemarks = a.WipersRemarks,
					ExistingCorrosionRemarks = a.ExistingCorrosionRemarks,
					TireBoltsRemarks = a.TireBoltsRemarks,
					SafeLoadIndicatorRemarks = a.SafeLoadIndicatorRemarks,
					ScreenCurtainsRemarks = a.ScreenCurtainsRemarks,
					OutriggerRemarks = a.OutriggerRemarks,
					StrangeSoundRemarks = a.StrangeSoundRemarks,
					DriverName = a.DriverName,
					userID = a.userID,
					user = new IdentityUser { UserName = a.user.UserName,Id=a.user.Id }
                }).ToList();
        }
    }
}
