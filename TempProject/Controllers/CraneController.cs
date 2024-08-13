using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Drawing.Drawing2D;
using System.Text;
using TempProject.DTO;
using TempProject.DTO.ResponseDTO;
using TempProject.Helper;
using TempProject.Models;
using TempProject.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	//[Authorize]
	public class CraneController : ControllerBase
    {
        public IRepository<Crane> craneRepo { get; set; }
        public ICraneRepository craneRepository { get; set; }

		private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager;

        public CraneController(ICraneRepository _craneRepository,Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager,IRepository<Crane> _craneRepo)
        {
            this.craneRepository = _craneRepository;
            this.craneRepo = _craneRepo;
            this.userManager = _userManager;
        }

		[HttpGet("GetData")]
		public async Task<ResultDTO> GetAllWithData(string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<Crane> temp = craneRepository.getall();
					List<CraneResponseDTO> newTemp = new List<CraneResponseDTO>();
					foreach (Crane crane in temp)
					{
						CraneResponseDTO craneDTO = new CraneResponseDTO();
						craneDTO.Id = crane.Id;
						craneDTO.RigNo = crane.Rig.Number;
						craneDTO.Date = crane.Date;
						craneDTO.WellName = crane.WellName;
						craneDTO.UnitNo = crane.UnitNo;
						craneDTO.QHSEEngineer = crane.QHSEEngineer;
						//craneDTO.HrsSinceOilChange = crane.HrsSinceOilChange;
						craneDTO.CleanAndTidy = crane.CleanAndTidy;
						craneDTO.EngineOilLevel = crane.EngineOilLevel;
						craneDTO.TransmissionOilLevel = crane.TransmissionOilLevel;
						craneDTO.RadiatorWaterLevel = crane.RadiatorWaterLevel;
						craneDTO.HydraulicOilLevel = crane.HydraulicOilLevel;
						craneDTO.V_beltsTension = crane.V_beltsTension;
						craneDTO.DrainWater = crane.DrainWater;
						craneDTO.Leaks = crane.Leaks;
						craneDTO.BatteryHolder = crane.BatteryHolder;
						craneDTO.LoadComputer = crane.LoadComputer;
						craneDTO.GaugesForCcorrectReadings = crane.GaugesForCcorrectReadings;
						craneDTO.TirePressure = crane.TirePressure;
						craneDTO.FuelTanksFull = crane.FuelTanksFull;
						craneDTO.WireRopes = crane.WireRopes;
						craneDTO.SwingBrake = crane.SwingBrake;
						craneDTO.TestLimitSwitches = crane.TestLimitSwitches;
						craneDTO.TestOutriggers = crane.TestOutriggers;
						craneDTO.AbnormalNoise = crane.AbnormalNoise;
						craneDTO.ServiceBrakes = crane.ServiceBrakes;
						craneDTO.Sheaves = crane.Sheaves;
						craneDTO.SpoolingOfWire = crane.SpoolingOfWire;
						craneDTO.Hookcondition = crane.Hookcondition;
						craneDTO.BoomSections = crane.BoomSections;
						craneDTO.EngineV_belts = crane.EngineV_belts;
						craneDTO.WiringVisually = crane.WiringVisually;
						craneDTO.LoadIndicator = crane.LoadIndicator;
						craneDTO.AudibleAlarm = crane.AudibleAlarm;
						craneDTO.LoadLimiting = crane.LoadLimiting;
						craneDTO.BoomAngle = crane.BoomAngle;
						craneDTO.LimitSwitch = crane.LimitSwitch;
						craneDTO.EmergencyShutDown = crane.EmergencyShutDown;
						craneDTO.OperatingReturn = crane.OperatingReturn;
						craneDTO.OperatingControls = crane.OperatingControls;
						craneDTO.HeadLight = crane.HeadLight;
						craneDTO.ReverseAlarm = crane.ReverseAlarm;
						craneDTO.ParkingBrake = crane.ParkingBrake;
						craneDTO.SafetyBelt = crane.SafetyBelt;
						craneDTO.DriverSeat = crane.DriverSeat;
						craneDTO.Wipers = crane.Wipers;
						craneDTO.ExistingCorrosion = crane.ExistingCorrosion;
						craneDTO.TireBolts = crane.TireBolts;
						craneDTO.SafeLoadIndicator = crane.SafeLoadIndicator;
						craneDTO.ScreenCurtains = crane.ScreenCurtains;
						craneDTO.Outrigger = crane.Outrigger;
						craneDTO.StrangeSound = crane.StrangeSound;
						craneDTO.CleanAndTidyRemarks = crane.CleanAndTidyRemarks;
						craneDTO.EngineOilLevelRemarks = crane.EngineOilLevelRemarks;
						craneDTO.TransmissionOilLevelRemarks = crane.TransmissionOilLevelRemarks;
						craneDTO.RadiatorWaterLevelRemarks = crane.RadiatorWaterLevelRemarks;
						craneDTO.HydraulicOilLevelRemarks = crane.HydraulicOilLevelRemarks;
						craneDTO.V_beltsTensionRemarks = crane.V_beltsTensionRemarks;
						craneDTO.DrainWaterRemarks = crane.DrainWaterRemarks;
						craneDTO.LeaksRemarks = crane.LeaksRemarks;
						craneDTO.BatteryHolderRemarks = crane.BatteryHolderRemarks;
						craneDTO.LoadComputerRemarks = crane.LoadComputerRemarks;
						craneDTO.GaugesForCcorrectReadingsRemarks = crane.GaugesForCcorrectReadingsRemarks;
						craneDTO.TirePressureRemarks = crane.TirePressureRemarks;
						craneDTO.FuelTanksFullRemarks = crane.FuelTanksFullRemarks;
						craneDTO.WireRopesRemarks = crane.WireRopesRemarks;
						craneDTO.SwingBrakeRemarks = crane.SwingBrakeRemarks;
						craneDTO.TestLimitSwitchesRemarks = crane.TestLimitSwitchesRemarks;
						craneDTO.TestOutriggersRemarks = crane.TestOutriggersRemarks;
						craneDTO.AbnormalNoiseRemarks = crane.AbnormalNoiseRemarks;
						craneDTO.ServiceBrakesRemarks = crane.ServiceBrakesRemarks;
						craneDTO.SheavesRemarks = crane.SheavesRemarks;
						craneDTO.SpoolingOfWireRemarks = crane.SpoolingOfWireRemarks;
						craneDTO.HookconditionRemarks = crane.HookconditionRemarks;
						craneDTO.BoomSectionsRemarks = crane.BoomSectionsRemarks;
						craneDTO.EngineV_beltsRemarks = crane.EngineV_beltsRemarks;
						craneDTO.WiringVisuallyRemarks = crane.WiringVisuallyRemarks;
						craneDTO.LoadIndicatorRemarks = crane.LoadIndicatorRemarks;
						craneDTO.AudibleAlarmRemarks = crane.AudibleAlarmRemarks;
						craneDTO.LoadLimitingRemarks = crane.LoadLimitingRemarks;
						craneDTO.BoomAngleRemarks = crane.BoomAngleRemarks;
						craneDTO.LimitSwitchRemarks = crane.LimitSwitchRemarks;
						craneDTO.EmergencyShutDownRemarks = crane.EmergencyShutDownRemarks;
						craneDTO.OperatingReturnRemarks = crane.OperatingReturnRemarks;
						craneDTO.OperatingControlsRemarks = crane.OperatingControlsRemarks;
						craneDTO.HeadLightRemarks = crane.HeadLightRemarks;
						craneDTO.ReverseAlarmRemarks = crane.ReverseAlarmRemarks;
						craneDTO.ParkingBrakeRemarks = crane.ParkingBrakeRemarks;
						craneDTO.SafetyBeltRemarks = crane.SafetyBeltRemarks;
						craneDTO.DriverSeatRemarks = crane.DriverSeatRemarks;
						craneDTO.WipersRemarks = crane.WipersRemarks;
						craneDTO.ExistingCorrosionRemarks = crane.ExistingCorrosionRemarks;
						craneDTO.TireBoltsRemarks = crane.TireBoltsRemarks;
						craneDTO.SafeLoadIndicatorRemarks = crane.SafeLoadIndicatorRemarks;
						craneDTO.ScreenCurtainsRemarks = crane.ScreenCurtainsRemarks;
						craneDTO.OutriggerRemarks = crane.OutriggerRemarks;
						craneDTO.StrangeSoundRemarks = crane.StrangeSoundRemarks;
						craneDTO.DriverName = crane.DriverName;
						craneDTO.userName = crane.user.UserName;
						
						newTemp.Add(craneDTO);

					}
					if (newTemp != null)
					{
						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<Crane> temp = craneRepository.getall().Where(a => a.user.Id == UserID).ToList();
					List<CraneResponseDTO> newTemp = new List<CraneResponseDTO>();
					foreach (Crane crane in temp)
					{
						CraneResponseDTO craneDTO = new CraneResponseDTO();
						craneDTO.Id = crane.Id;
						craneDTO.RigNo = crane.Rig.Number;
						craneDTO.Date = crane.Date;
						craneDTO.WellName = crane.WellName;
						craneDTO.UnitNo = crane.UnitNo;
						craneDTO.QHSEEngineer = crane.QHSEEngineer;
						//craneDTO.HrsSinceOilChange = crane.HrsSinceOilChange;
						craneDTO.CleanAndTidy = crane.CleanAndTidy;
						craneDTO.EngineOilLevel = crane.EngineOilLevel;
						craneDTO.TransmissionOilLevel = crane.TransmissionOilLevel;
						craneDTO.RadiatorWaterLevel = crane.RadiatorWaterLevel;
						craneDTO.HydraulicOilLevel = crane.HydraulicOilLevel;
						craneDTO.V_beltsTension = crane.V_beltsTension;
						craneDTO.DrainWater = crane.DrainWater;
						craneDTO.Leaks = crane.Leaks;
						craneDTO.BatteryHolder = crane.BatteryHolder;
						craneDTO.LoadComputer = crane.LoadComputer;
						craneDTO.GaugesForCcorrectReadings = crane.GaugesForCcorrectReadings;
						craneDTO.TirePressure = crane.TirePressure;
						craneDTO.FuelTanksFull = crane.FuelTanksFull;
						craneDTO.WireRopes = crane.WireRopes;
						craneDTO.SwingBrake = crane.SwingBrake;
						craneDTO.TestLimitSwitches = crane.TestLimitSwitches;
						craneDTO.TestOutriggers = crane.TestOutriggers;
						craneDTO.AbnormalNoise = crane.AbnormalNoise;
						craneDTO.ServiceBrakes = crane.ServiceBrakes;
						craneDTO.Sheaves = crane.Sheaves;
						craneDTO.SpoolingOfWire = crane.SpoolingOfWire;
						craneDTO.Hookcondition = crane.Hookcondition;
						craneDTO.BoomSections = crane.BoomSections;
						craneDTO.EngineV_belts = crane.EngineV_belts;
						craneDTO.WiringVisually = crane.WiringVisually;
						craneDTO.LoadIndicator = crane.LoadIndicator;
						craneDTO.AudibleAlarm = crane.AudibleAlarm;
						craneDTO.LoadLimiting = crane.LoadLimiting;
						craneDTO.BoomAngle = crane.BoomAngle;
						craneDTO.LimitSwitch = crane.LimitSwitch;
						craneDTO.EmergencyShutDown = crane.EmergencyShutDown;
						craneDTO.OperatingReturn = crane.OperatingReturn;
						craneDTO.OperatingControls = crane.OperatingControls;
						craneDTO.HeadLight = crane.HeadLight;
						craneDTO.ReverseAlarm = crane.ReverseAlarm;
						craneDTO.ParkingBrake = crane.ParkingBrake;
						craneDTO.SafetyBelt = crane.SafetyBelt;
						craneDTO.DriverSeat = crane.DriverSeat;
						craneDTO.Wipers = crane.Wipers;
						craneDTO.ExistingCorrosion = crane.ExistingCorrosion;
						craneDTO.TireBolts = crane.TireBolts;
						craneDTO.SafeLoadIndicator = crane.SafeLoadIndicator;
						craneDTO.ScreenCurtains = crane.ScreenCurtains;
						craneDTO.Outrigger = crane.Outrigger;
						craneDTO.StrangeSound = crane.StrangeSound;
						craneDTO.CleanAndTidyRemarks = crane.CleanAndTidyRemarks;
						craneDTO.EngineOilLevelRemarks = crane.EngineOilLevelRemarks;
						craneDTO.TransmissionOilLevelRemarks = crane.TransmissionOilLevelRemarks;
						craneDTO.RadiatorWaterLevelRemarks = crane.RadiatorWaterLevelRemarks;
						craneDTO.HydraulicOilLevelRemarks = crane.HydraulicOilLevelRemarks;
						craneDTO.V_beltsTensionRemarks = crane.V_beltsTensionRemarks;
						craneDTO.DrainWaterRemarks = crane.DrainWaterRemarks;
						craneDTO.LeaksRemarks = crane.LeaksRemarks;
						craneDTO.BatteryHolderRemarks = crane.BatteryHolderRemarks;
						craneDTO.LoadComputerRemarks = crane.LoadComputerRemarks;
						craneDTO.GaugesForCcorrectReadingsRemarks = crane.GaugesForCcorrectReadingsRemarks;
						craneDTO.TirePressureRemarks = crane.TirePressureRemarks;
						craneDTO.FuelTanksFullRemarks = crane.FuelTanksFullRemarks;
						craneDTO.WireRopesRemarks = crane.WireRopesRemarks;
						craneDTO.SwingBrakeRemarks = crane.SwingBrakeRemarks;
						craneDTO.TestLimitSwitchesRemarks = crane.TestLimitSwitchesRemarks;
						craneDTO.TestOutriggersRemarks = crane.TestOutriggersRemarks;
						craneDTO.AbnormalNoiseRemarks = crane.AbnormalNoiseRemarks;
						craneDTO.ServiceBrakesRemarks = crane.ServiceBrakesRemarks;
						craneDTO.SheavesRemarks = crane.SheavesRemarks;
						craneDTO.SpoolingOfWireRemarks = crane.SpoolingOfWireRemarks;
						craneDTO.HookconditionRemarks = crane.HookconditionRemarks;
						craneDTO.BoomSectionsRemarks = crane.BoomSectionsRemarks;
						craneDTO.EngineV_beltsRemarks = crane.EngineV_beltsRemarks;
						craneDTO.WiringVisuallyRemarks = crane.WiringVisuallyRemarks;
						craneDTO.LoadIndicatorRemarks = crane.LoadIndicatorRemarks;
						craneDTO.AudibleAlarmRemarks = crane.AudibleAlarmRemarks;
						craneDTO.LoadLimitingRemarks = crane.LoadLimitingRemarks;
						craneDTO.BoomAngleRemarks = crane.BoomAngleRemarks;
						craneDTO.LimitSwitchRemarks = crane.LimitSwitchRemarks;
						craneDTO.EmergencyShutDownRemarks = crane.EmergencyShutDownRemarks;
						craneDTO.OperatingReturnRemarks = crane.OperatingReturnRemarks;
						craneDTO.OperatingControlsRemarks = crane.OperatingControlsRemarks;
						craneDTO.HeadLightRemarks = crane.HeadLightRemarks;
						craneDTO.ReverseAlarmRemarks = crane.ReverseAlarmRemarks;
						craneDTO.ParkingBrakeRemarks = crane.ParkingBrakeRemarks;
						craneDTO.SafetyBeltRemarks = crane.SafetyBeltRemarks;
						craneDTO.DriverSeatRemarks = crane.DriverSeatRemarks;
						craneDTO.WipersRemarks = crane.WipersRemarks;
						craneDTO.ExistingCorrosionRemarks = crane.ExistingCorrosionRemarks;
						craneDTO.TireBoltsRemarks = crane.TireBoltsRemarks;
						craneDTO.SafeLoadIndicatorRemarks = crane.SafeLoadIndicatorRemarks;
						craneDTO.ScreenCurtainsRemarks = crane.ScreenCurtainsRemarks;
						craneDTO.OutriggerRemarks = crane.OutriggerRemarks;
						craneDTO.StrangeSoundRemarks = crane.StrangeSoundRemarks;
						craneDTO.DriverName = crane.DriverName;
						craneDTO.userName = crane.user.UserName;

						newTemp.Add(craneDTO);

					}
					if (newTemp != null)
					{
						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}
				}
			}
			catch (Exception ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}
			return result;
		}

		[HttpGet("GetDataForExcel")]
		public async Task<ResultDTO> GetAllWithDataForExcel(string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<Crane> temp = craneRepository.getall();
					List<CraneExcelDTO> newTemp = new List<CraneExcelDTO>();
					foreach (Crane crane in temp)
					{
						CraneExcelDTO craneDTO = new CraneExcelDTO();
						craneDTO.Id = crane.Id;
						craneDTO.RigNo = crane.Rig.Number;
						craneDTO.Date = crane.Date;
						craneDTO.WellName = crane.WellName;
						craneDTO.UnitNo = crane.UnitNo;
						craneDTO.QHSEEngineer = crane.QHSEEngineer;
						//craneDTO.HrsSinceOilChange = crane.HrsSinceOilChange;
						craneDTO.CleanAndTidy = crane.CleanAndTidy;
						craneDTO.EngineOilLevel = crane.EngineOilLevel;
						craneDTO.TransmissionOilLevel = crane.TransmissionOilLevel;
						craneDTO.RadiatorWaterLevel = crane.RadiatorWaterLevel;
						craneDTO.HydraulicOilLevel = crane.HydraulicOilLevel;
						craneDTO.V_beltsTension = crane.V_beltsTension;
						craneDTO.DrainWater = crane.DrainWater;
						craneDTO.Leaks = crane.Leaks;
						craneDTO.BatteryHolder = crane.BatteryHolder;
						craneDTO.LoadComputer = crane.LoadComputer;
						craneDTO.GaugesForCcorrectReadings = crane.GaugesForCcorrectReadings;
						craneDTO.TirePressure = crane.TirePressure;
						craneDTO.FuelTanksFull = crane.FuelTanksFull;
						craneDTO.WireRopes = crane.WireRopes;
						craneDTO.SwingBrake = crane.SwingBrake;
						craneDTO.TestLimitSwitches = crane.TestLimitSwitches;
						craneDTO.TestOutriggers = crane.TestOutriggers;
						craneDTO.AbnormalNoise = crane.AbnormalNoise;
						craneDTO.ServiceBrakes = crane.ServiceBrakes;
						craneDTO.Sheaves = crane.Sheaves;
						craneDTO.SpoolingOfWire = crane.SpoolingOfWire;
						craneDTO.Hookcondition = crane.Hookcondition;
						craneDTO.BoomSections = crane.BoomSections;
						craneDTO.EngineV_belts = crane.EngineV_belts;
						craneDTO.WiringVisually = crane.WiringVisually;
						craneDTO.LoadIndicator = crane.LoadIndicator;
						craneDTO.AudibleAlarm = crane.AudibleAlarm;
						craneDTO.LoadLimiting = crane.LoadLimiting;
						craneDTO.BoomAngle = crane.BoomAngle;
						craneDTO.LimitSwitch = crane.LimitSwitch;
						craneDTO.EmergencyShutDown = crane.EmergencyShutDown;
						craneDTO.OperatingReturn = crane.OperatingReturn;
						craneDTO.OperatingControls = crane.OperatingControls;
						craneDTO.HeadLight = crane.HeadLight;
						craneDTO.ReverseAlarm = crane.ReverseAlarm;
						craneDTO.ParkingBrake = crane.ParkingBrake;
						craneDTO.SafetyBelt = crane.SafetyBelt;
						craneDTO.DriverSeat = crane.DriverSeat;
						craneDTO.Wipers = crane.Wipers;
						craneDTO.ExistingCorrosion = crane.ExistingCorrosion;
						craneDTO.TireBolts = crane.TireBolts;
						craneDTO.SafeLoadIndicator = crane.SafeLoadIndicator;
						craneDTO.ScreenCurtains = crane.ScreenCurtains;
						craneDTO.Outrigger = crane.Outrigger;
						craneDTO.StrangeSound = crane.StrangeSound;
						craneDTO.CleanAndTidyRemarks = crane.CleanAndTidyRemarks;
						craneDTO.EngineOilLevelRemarks = crane.EngineOilLevelRemarks;
						craneDTO.TransmissionOilLevelRemarks = crane.TransmissionOilLevelRemarks;
						craneDTO.RadiatorWaterLevelRemarks = crane.RadiatorWaterLevelRemarks;
						craneDTO.HydraulicOilLevelRemarks = crane.HydraulicOilLevelRemarks;
						craneDTO.V_beltsTensionRemarks = crane.V_beltsTensionRemarks;
						craneDTO.DrainWaterRemarks = crane.DrainWaterRemarks;
						craneDTO.LeaksRemarks = crane.LeaksRemarks;
						craneDTO.BatteryHolderRemarks = crane.BatteryHolderRemarks;
						craneDTO.LoadComputerRemarks = crane.LoadComputerRemarks;
						craneDTO.GaugesForCcorrectReadingsRemarks = crane.GaugesForCcorrectReadingsRemarks;
						craneDTO.TirePressureRemarks = crane.TirePressureRemarks;
						craneDTO.FuelTanksFullRemarks = crane.FuelTanksFullRemarks;
						craneDTO.WireRopesRemarks = crane.WireRopesRemarks;
						craneDTO.SwingBrakeRemarks = crane.SwingBrakeRemarks;
						craneDTO.TestLimitSwitchesRemarks = crane.TestLimitSwitchesRemarks;
						craneDTO.TestOutriggersRemarks = crane.TestOutriggersRemarks;
						craneDTO.AbnormalNoiseRemarks = crane.AbnormalNoiseRemarks;
						craneDTO.ServiceBrakesRemarks = crane.ServiceBrakesRemarks;
						craneDTO.SheavesRemarks = crane.SheavesRemarks;
						craneDTO.SpoolingOfWireRemarks = crane.SpoolingOfWireRemarks;
						craneDTO.HookconditionRemarks = crane.HookconditionRemarks;
						craneDTO.BoomSectionsRemarks = crane.BoomSectionsRemarks;
						craneDTO.EngineV_beltsRemarks = crane.EngineV_beltsRemarks;
						craneDTO.WiringVisuallyRemarks = crane.WiringVisuallyRemarks;
						craneDTO.LoadIndicatorRemarks = crane.LoadIndicatorRemarks;
						craneDTO.AudibleAlarmRemarks = crane.AudibleAlarmRemarks;
						craneDTO.LoadLimitingRemarks = crane.LoadLimitingRemarks;
						craneDTO.BoomAngleRemarks = crane.BoomAngleRemarks;
						craneDTO.LimitSwitchRemarks = crane.LimitSwitchRemarks;
						craneDTO.EmergencyShutDownRemarks = crane.EmergencyShutDownRemarks;
						craneDTO.OperatingReturnRemarks = crane.OperatingReturnRemarks;
						craneDTO.OperatingControlsRemarks = crane.OperatingControlsRemarks;
						craneDTO.HeadLightRemarks = crane.HeadLightRemarks;
						craneDTO.ReverseAlarmRemarks = crane.ReverseAlarmRemarks;
						craneDTO.ParkingBrakeRemarks = crane.ParkingBrakeRemarks;
						craneDTO.SafetyBeltRemarks = crane.SafetyBeltRemarks;
						craneDTO.DriverSeatRemarks = crane.DriverSeatRemarks;
						craneDTO.WipersRemarks = crane.WipersRemarks;
						craneDTO.ExistingCorrosionRemarks = crane.ExistingCorrosionRemarks;
						craneDTO.TireBoltsRemarks = crane.TireBoltsRemarks;
						craneDTO.SafeLoadIndicatorRemarks = crane.SafeLoadIndicatorRemarks;
						craneDTO.ScreenCurtainsRemarks = crane.ScreenCurtainsRemarks;
						craneDTO.OutriggerRemarks = crane.OutriggerRemarks;
						craneDTO.StrangeSoundRemarks = crane.StrangeSoundRemarks;
						craneDTO.DriverName = crane.DriverName;
						craneDTO.userName = crane.user.UserName;

						newTemp.Add(craneDTO);

					}
					if (newTemp != null)
					{
						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<Crane> temp = craneRepository.getall().Where(a => a.user.Id == UserID).ToList();
					List<CraneExcelDTO> newTemp = new List<CraneExcelDTO>();
					foreach (Crane crane in temp)
					{
						CraneExcelDTO craneDTO = new CraneExcelDTO(); 
						craneDTO.Id = crane.Id;
						craneDTO.RigNo = crane.Rig.Number;
						craneDTO.Date = crane.Date;
						craneDTO.WellName = crane.WellName;
						craneDTO.UnitNo = crane.UnitNo;
						craneDTO.QHSEEngineer = crane.QHSEEngineer;
						//craneDTO.HrsSinceOilChange = crane.HrsSinceOilChange;
						craneDTO.CleanAndTidy = crane.CleanAndTidy;
						craneDTO.EngineOilLevel = crane.EngineOilLevel;
						craneDTO.TransmissionOilLevel = crane.TransmissionOilLevel;
						craneDTO.RadiatorWaterLevel = crane.RadiatorWaterLevel;
						craneDTO.HydraulicOilLevel = crane.HydraulicOilLevel;
						craneDTO.V_beltsTension = crane.V_beltsTension;
						craneDTO.DrainWater = crane.DrainWater;
						craneDTO.Leaks = crane.Leaks;
						craneDTO.BatteryHolder = crane.BatteryHolder;
						craneDTO.LoadComputer = crane.LoadComputer;
						craneDTO.GaugesForCcorrectReadings = crane.GaugesForCcorrectReadings;
						craneDTO.TirePressure = crane.TirePressure;
						craneDTO.FuelTanksFull = crane.FuelTanksFull;
						craneDTO.WireRopes = crane.WireRopes;
						craneDTO.SwingBrake = crane.SwingBrake;
						craneDTO.TestLimitSwitches = crane.TestLimitSwitches;
						craneDTO.TestOutriggers = crane.TestOutriggers;
						craneDTO.AbnormalNoise = crane.AbnormalNoise;
						craneDTO.ServiceBrakes = crane.ServiceBrakes;
						craneDTO.Sheaves = crane.Sheaves;
						craneDTO.SpoolingOfWire = crane.SpoolingOfWire;
						craneDTO.Hookcondition = crane.Hookcondition;
						craneDTO.BoomSections = crane.BoomSections;
						craneDTO.EngineV_belts = crane.EngineV_belts;
						craneDTO.WiringVisually = crane.WiringVisually;
						craneDTO.LoadIndicator = crane.LoadIndicator;
						craneDTO.AudibleAlarm = crane.AudibleAlarm;
						craneDTO.LoadLimiting = crane.LoadLimiting;
						craneDTO.BoomAngle = crane.BoomAngle;
						craneDTO.LimitSwitch = crane.LimitSwitch;
						craneDTO.EmergencyShutDown = crane.EmergencyShutDown;
						craneDTO.OperatingReturn = crane.OperatingReturn;
						craneDTO.OperatingControls = crane.OperatingControls;
						craneDTO.HeadLight = crane.HeadLight;
						craneDTO.ReverseAlarm = crane.ReverseAlarm;
						craneDTO.ParkingBrake = crane.ParkingBrake;
						craneDTO.SafetyBelt = crane.SafetyBelt;
						craneDTO.DriverSeat = crane.DriverSeat;
						craneDTO.Wipers = crane.Wipers;
						craneDTO.ExistingCorrosion = crane.ExistingCorrosion;
						craneDTO.TireBolts = crane.TireBolts;
						craneDTO.SafeLoadIndicator = crane.SafeLoadIndicator;
						craneDTO.ScreenCurtains = crane.ScreenCurtains;
						craneDTO.Outrigger = crane.Outrigger;
						craneDTO.StrangeSound = crane.StrangeSound;
						craneDTO.CleanAndTidyRemarks = crane.CleanAndTidyRemarks;
						craneDTO.EngineOilLevelRemarks = crane.EngineOilLevelRemarks;
						craneDTO.TransmissionOilLevelRemarks = crane.TransmissionOilLevelRemarks;
						craneDTO.RadiatorWaterLevelRemarks = crane.RadiatorWaterLevelRemarks;
						craneDTO.HydraulicOilLevelRemarks = crane.HydraulicOilLevelRemarks;
						craneDTO.V_beltsTensionRemarks = crane.V_beltsTensionRemarks;
						craneDTO.DrainWaterRemarks = crane.DrainWaterRemarks;
						craneDTO.LeaksRemarks = crane.LeaksRemarks;
						craneDTO.BatteryHolderRemarks = crane.BatteryHolderRemarks;
						craneDTO.LoadComputerRemarks = crane.LoadComputerRemarks;
						craneDTO.GaugesForCcorrectReadingsRemarks = crane.GaugesForCcorrectReadingsRemarks;
						craneDTO.TirePressureRemarks = crane.TirePressureRemarks;
						craneDTO.FuelTanksFullRemarks = crane.FuelTanksFullRemarks;
						craneDTO.WireRopesRemarks = crane.WireRopesRemarks;
						craneDTO.SwingBrakeRemarks = crane.SwingBrakeRemarks;
						craneDTO.TestLimitSwitchesRemarks = crane.TestLimitSwitchesRemarks;
						craneDTO.TestOutriggersRemarks = crane.TestOutriggersRemarks;
						craneDTO.AbnormalNoiseRemarks = crane.AbnormalNoiseRemarks;
						craneDTO.ServiceBrakesRemarks = crane.ServiceBrakesRemarks;
						craneDTO.SheavesRemarks = crane.SheavesRemarks;
						craneDTO.SpoolingOfWireRemarks = crane.SpoolingOfWireRemarks;
						craneDTO.HookconditionRemarks = crane.HookconditionRemarks;
						craneDTO.BoomSectionsRemarks = crane.BoomSectionsRemarks;
						craneDTO.EngineV_beltsRemarks = crane.EngineV_beltsRemarks;
						craneDTO.WiringVisuallyRemarks = crane.WiringVisuallyRemarks;
						craneDTO.LoadIndicatorRemarks = crane.LoadIndicatorRemarks;
						craneDTO.AudibleAlarmRemarks = crane.AudibleAlarmRemarks;
						craneDTO.LoadLimitingRemarks = crane.LoadLimitingRemarks;
						craneDTO.BoomAngleRemarks = crane.BoomAngleRemarks;
						craneDTO.LimitSwitchRemarks = crane.LimitSwitchRemarks;
						craneDTO.EmergencyShutDownRemarks = crane.EmergencyShutDownRemarks;
						craneDTO.OperatingReturnRemarks = crane.OperatingReturnRemarks;
						craneDTO.OperatingControlsRemarks = crane.OperatingControlsRemarks;
						craneDTO.HeadLightRemarks = crane.HeadLightRemarks;
						craneDTO.ReverseAlarmRemarks = crane.ReverseAlarmRemarks;
						craneDTO.ParkingBrakeRemarks = crane.ParkingBrakeRemarks;
						craneDTO.SafetyBeltRemarks = crane.SafetyBeltRemarks;
						craneDTO.DriverSeatRemarks = crane.DriverSeatRemarks;
						craneDTO.WipersRemarks = crane.WipersRemarks;
						craneDTO.ExistingCorrosionRemarks = crane.ExistingCorrosionRemarks;
						craneDTO.TireBoltsRemarks = crane.TireBoltsRemarks;
						craneDTO.SafeLoadIndicatorRemarks = crane.SafeLoadIndicatorRemarks;
						craneDTO.ScreenCurtainsRemarks = crane.ScreenCurtainsRemarks;
						craneDTO.OutriggerRemarks = crane.OutriggerRemarks;
						craneDTO.StrangeSoundRemarks = crane.StrangeSoundRemarks;
						craneDTO.DriverName = crane.DriverName;
						craneDTO.userName = crane.user.UserName;

						newTemp.Add(craneDTO);

					}
					if (newTemp != null)
					{
						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}
				}
			}
			catch (Exception ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}
			return result;
		}

		[HttpGet("GetDataForAnalysis")]
		public async Task<ResultDTO> GetAllWithDataForAnalysis(int RigId,string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<Crane> temp = craneRepository.getall().Where(c => c.RigId == RigId).ToList();
					List<CraneExcelDTO> newTemp = new List<CraneExcelDTO>();
					foreach (Crane crane in temp)
					{
						CraneExcelDTO craneDTO = new CraneExcelDTO();
						craneDTO.Id = crane.Id;
						craneDTO.RigNo = crane.Rig.Number;
						craneDTO.Date = crane.Date;
						craneDTO.WellName = crane.WellName;
						craneDTO.UnitNo = crane.UnitNo;
						craneDTO.QHSEEngineer = crane.QHSEEngineer;
						//craneDTO.HrsSinceOilChange = crane.HrsSinceOilChange;
						craneDTO.CleanAndTidy = crane.CleanAndTidy;
						craneDTO.EngineOilLevel = crane.EngineOilLevel;
						craneDTO.TransmissionOilLevel = crane.TransmissionOilLevel;
						craneDTO.RadiatorWaterLevel = crane.RadiatorWaterLevel;
						craneDTO.HydraulicOilLevel = crane.HydraulicOilLevel;
						craneDTO.V_beltsTension = crane.V_beltsTension;
						craneDTO.DrainWater = crane.DrainWater;
						craneDTO.Leaks = crane.Leaks;
						craneDTO.BatteryHolder = crane.BatteryHolder;
						craneDTO.LoadComputer = crane.LoadComputer;
						craneDTO.GaugesForCcorrectReadings = crane.GaugesForCcorrectReadings;
						craneDTO.TirePressure = crane.TirePressure;
						craneDTO.FuelTanksFull = crane.FuelTanksFull;
						craneDTO.WireRopes = crane.WireRopes;
						craneDTO.SwingBrake = crane.SwingBrake;
						craneDTO.TestLimitSwitches = crane.TestLimitSwitches;
						craneDTO.TestOutriggers = crane.TestOutriggers;
						craneDTO.AbnormalNoise = crane.AbnormalNoise;
						craneDTO.ServiceBrakes = crane.ServiceBrakes;
						craneDTO.Sheaves = crane.Sheaves;
						craneDTO.SpoolingOfWire = crane.SpoolingOfWire;
						craneDTO.Hookcondition = crane.Hookcondition;
						craneDTO.BoomSections = crane.BoomSections;
						craneDTO.EngineV_belts = crane.EngineV_belts;
						craneDTO.WiringVisually = crane.WiringVisually;
						craneDTO.LoadIndicator = crane.LoadIndicator;
						craneDTO.AudibleAlarm = crane.AudibleAlarm;
						craneDTO.LoadLimiting = crane.LoadLimiting;
						craneDTO.BoomAngle = crane.BoomAngle;
						craneDTO.LimitSwitch = crane.LimitSwitch;
						craneDTO.EmergencyShutDown = crane.EmergencyShutDown;
						craneDTO.OperatingReturn = crane.OperatingReturn;
						craneDTO.OperatingControls = crane.OperatingControls;
						craneDTO.HeadLight = crane.HeadLight;
						craneDTO.ReverseAlarm = crane.ReverseAlarm;
						craneDTO.ParkingBrake = crane.ParkingBrake;
						craneDTO.SafetyBelt = crane.SafetyBelt;
						craneDTO.DriverSeat = crane.DriverSeat;
						craneDTO.Wipers = crane.Wipers;
						craneDTO.ExistingCorrosion = crane.ExistingCorrosion;
						craneDTO.TireBolts = crane.TireBolts;
						craneDTO.SafeLoadIndicator = crane.SafeLoadIndicator;
						craneDTO.ScreenCurtains = crane.ScreenCurtains;
						craneDTO.Outrigger = crane.Outrigger;
						craneDTO.StrangeSound = crane.StrangeSound;
						craneDTO.CleanAndTidyRemarks = crane.CleanAndTidyRemarks;
						craneDTO.EngineOilLevelRemarks = crane.EngineOilLevelRemarks;
						craneDTO.TransmissionOilLevelRemarks = crane.TransmissionOilLevelRemarks;
						craneDTO.RadiatorWaterLevelRemarks = crane.RadiatorWaterLevelRemarks;
						craneDTO.HydraulicOilLevelRemarks = crane.HydraulicOilLevelRemarks;
						craneDTO.V_beltsTensionRemarks = crane.V_beltsTensionRemarks;
						craneDTO.DrainWaterRemarks = crane.DrainWaterRemarks;
						craneDTO.LeaksRemarks = crane.LeaksRemarks;
						craneDTO.BatteryHolderRemarks = crane.BatteryHolderRemarks;
						craneDTO.LoadComputerRemarks = crane.LoadComputerRemarks;
						craneDTO.GaugesForCcorrectReadingsRemarks = crane.GaugesForCcorrectReadingsRemarks;
						craneDTO.TirePressureRemarks = crane.TirePressureRemarks;
						craneDTO.FuelTanksFullRemarks = crane.FuelTanksFullRemarks;
						craneDTO.WireRopesRemarks = crane.WireRopesRemarks;
						craneDTO.SwingBrakeRemarks = crane.SwingBrakeRemarks;
						craneDTO.TestLimitSwitchesRemarks = crane.TestLimitSwitchesRemarks;
						craneDTO.TestOutriggersRemarks = crane.TestOutriggersRemarks;
						craneDTO.AbnormalNoiseRemarks = crane.AbnormalNoiseRemarks;
						craneDTO.ServiceBrakesRemarks = crane.ServiceBrakesRemarks;
						craneDTO.SheavesRemarks = crane.SheavesRemarks;
						craneDTO.SpoolingOfWireRemarks = crane.SpoolingOfWireRemarks;
						craneDTO.HookconditionRemarks = crane.HookconditionRemarks;
						craneDTO.BoomSectionsRemarks = crane.BoomSectionsRemarks;
						craneDTO.EngineV_beltsRemarks = crane.EngineV_beltsRemarks;
						craneDTO.WiringVisuallyRemarks = crane.WiringVisuallyRemarks;
						craneDTO.LoadIndicatorRemarks = crane.LoadIndicatorRemarks;
						craneDTO.AudibleAlarmRemarks = crane.AudibleAlarmRemarks;
						craneDTO.LoadLimitingRemarks = crane.LoadLimitingRemarks;
						craneDTO.BoomAngleRemarks = crane.BoomAngleRemarks;
						craneDTO.LimitSwitchRemarks = crane.LimitSwitchRemarks;
						craneDTO.EmergencyShutDownRemarks = crane.EmergencyShutDownRemarks;
						craneDTO.OperatingReturnRemarks = crane.OperatingReturnRemarks;
						craneDTO.OperatingControlsRemarks = crane.OperatingControlsRemarks;
						craneDTO.HeadLightRemarks = crane.HeadLightRemarks;
						craneDTO.ReverseAlarmRemarks = crane.ReverseAlarmRemarks;
						craneDTO.ParkingBrakeRemarks = crane.ParkingBrakeRemarks;
						craneDTO.SafetyBeltRemarks = crane.SafetyBeltRemarks;
						craneDTO.DriverSeatRemarks = crane.DriverSeatRemarks;
						craneDTO.WipersRemarks = crane.WipersRemarks;
						craneDTO.ExistingCorrosionRemarks = crane.ExistingCorrosionRemarks;
						craneDTO.TireBoltsRemarks = crane.TireBoltsRemarks;
						craneDTO.SafeLoadIndicatorRemarks = crane.SafeLoadIndicatorRemarks;
						craneDTO.ScreenCurtainsRemarks = crane.ScreenCurtainsRemarks;
						craneDTO.OutriggerRemarks = crane.OutriggerRemarks;
						craneDTO.StrangeSoundRemarks = crane.StrangeSoundRemarks;
						craneDTO.DriverName = crane.DriverName;
						craneDTO.userName = crane.user.UserName;

						newTemp.Add(craneDTO);

					}
					if (newTemp != null)
					{
						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<Crane> temp = craneRepository.getall().Where(a => a.user.Id == UserID && a.RigId == RigId).ToList();
					List<CraneExcelDTO> newTemp = new List<CraneExcelDTO>();
					foreach (Crane crane in temp)
					{
						CraneExcelDTO craneDTO = new CraneExcelDTO();
						craneDTO.Id = crane.Id;
						craneDTO.RigNo = crane.Rig.Number;
						craneDTO.Date = crane.Date;
						craneDTO.WellName = crane.WellName;
						craneDTO.UnitNo = crane.UnitNo;
						craneDTO.QHSEEngineer = crane.QHSEEngineer;
						//craneDTO.HrsSinceOilChange = crane.HrsSinceOilChange;
						craneDTO.CleanAndTidy = crane.CleanAndTidy;
						craneDTO.EngineOilLevel = crane.EngineOilLevel;
						craneDTO.TransmissionOilLevel = crane.TransmissionOilLevel;
						craneDTO.RadiatorWaterLevel = crane.RadiatorWaterLevel;
						craneDTO.HydraulicOilLevel = crane.HydraulicOilLevel;
						craneDTO.V_beltsTension = crane.V_beltsTension;
						craneDTO.DrainWater = crane.DrainWater;
						craneDTO.Leaks = crane.Leaks;
						craneDTO.BatteryHolder = crane.BatteryHolder;
						craneDTO.LoadComputer = crane.LoadComputer;
						craneDTO.GaugesForCcorrectReadings = crane.GaugesForCcorrectReadings;
						craneDTO.TirePressure = crane.TirePressure;
						craneDTO.FuelTanksFull = crane.FuelTanksFull;
						craneDTO.WireRopes = crane.WireRopes;
						craneDTO.SwingBrake = crane.SwingBrake;
						craneDTO.TestLimitSwitches = crane.TestLimitSwitches;
						craneDTO.TestOutriggers = crane.TestOutriggers;
						craneDTO.AbnormalNoise = crane.AbnormalNoise;
						craneDTO.ServiceBrakes = crane.ServiceBrakes;
						craneDTO.Sheaves = crane.Sheaves;
						craneDTO.SpoolingOfWire = crane.SpoolingOfWire;
						craneDTO.Hookcondition = crane.Hookcondition;
						craneDTO.BoomSections = crane.BoomSections;
						craneDTO.EngineV_belts = crane.EngineV_belts;
						craneDTO.WiringVisually = crane.WiringVisually;
						craneDTO.LoadIndicator = crane.LoadIndicator;
						craneDTO.AudibleAlarm = crane.AudibleAlarm;
						craneDTO.LoadLimiting = crane.LoadLimiting;
						craneDTO.BoomAngle = crane.BoomAngle;
						craneDTO.LimitSwitch = crane.LimitSwitch;
						craneDTO.EmergencyShutDown = crane.EmergencyShutDown;
						craneDTO.OperatingReturn = crane.OperatingReturn;
						craneDTO.OperatingControls = crane.OperatingControls;
						craneDTO.HeadLight = crane.HeadLight;
						craneDTO.ReverseAlarm = crane.ReverseAlarm;
						craneDTO.ParkingBrake = crane.ParkingBrake;
						craneDTO.SafetyBelt = crane.SafetyBelt;
						craneDTO.DriverSeat = crane.DriverSeat;
						craneDTO.Wipers = crane.Wipers;
						craneDTO.ExistingCorrosion = crane.ExistingCorrosion;
						craneDTO.TireBolts = crane.TireBolts;
						craneDTO.SafeLoadIndicator = crane.SafeLoadIndicator;
						craneDTO.ScreenCurtains = crane.ScreenCurtains;
						craneDTO.Outrigger = crane.Outrigger;
						craneDTO.StrangeSound = crane.StrangeSound;
						craneDTO.CleanAndTidyRemarks = crane.CleanAndTidyRemarks;
						craneDTO.EngineOilLevelRemarks = crane.EngineOilLevelRemarks;
						craneDTO.TransmissionOilLevelRemarks = crane.TransmissionOilLevelRemarks;
						craneDTO.RadiatorWaterLevelRemarks = crane.RadiatorWaterLevelRemarks;
						craneDTO.HydraulicOilLevelRemarks = crane.HydraulicOilLevelRemarks;
						craneDTO.V_beltsTensionRemarks = crane.V_beltsTensionRemarks;
						craneDTO.DrainWaterRemarks = crane.DrainWaterRemarks;
						craneDTO.LeaksRemarks = crane.LeaksRemarks;
						craneDTO.BatteryHolderRemarks = crane.BatteryHolderRemarks;
						craneDTO.LoadComputerRemarks = crane.LoadComputerRemarks;
						craneDTO.GaugesForCcorrectReadingsRemarks = crane.GaugesForCcorrectReadingsRemarks;
						craneDTO.TirePressureRemarks = crane.TirePressureRemarks;
						craneDTO.FuelTanksFullRemarks = crane.FuelTanksFullRemarks;
						craneDTO.WireRopesRemarks = crane.WireRopesRemarks;
						craneDTO.SwingBrakeRemarks = crane.SwingBrakeRemarks;
						craneDTO.TestLimitSwitchesRemarks = crane.TestLimitSwitchesRemarks;
						craneDTO.TestOutriggersRemarks = crane.TestOutriggersRemarks;
						craneDTO.AbnormalNoiseRemarks = crane.AbnormalNoiseRemarks;
						craneDTO.ServiceBrakesRemarks = crane.ServiceBrakesRemarks;
						craneDTO.SheavesRemarks = crane.SheavesRemarks;
						craneDTO.SpoolingOfWireRemarks = crane.SpoolingOfWireRemarks;
						craneDTO.HookconditionRemarks = crane.HookconditionRemarks;
						craneDTO.BoomSectionsRemarks = crane.BoomSectionsRemarks;
						craneDTO.EngineV_beltsRemarks = crane.EngineV_beltsRemarks;
						craneDTO.WiringVisuallyRemarks = crane.WiringVisuallyRemarks;
						craneDTO.LoadIndicatorRemarks = crane.LoadIndicatorRemarks;
						craneDTO.AudibleAlarmRemarks = crane.AudibleAlarmRemarks;
						craneDTO.LoadLimitingRemarks = crane.LoadLimitingRemarks;
						craneDTO.BoomAngleRemarks = crane.BoomAngleRemarks;
						craneDTO.LimitSwitchRemarks = crane.LimitSwitchRemarks;
						craneDTO.EmergencyShutDownRemarks = crane.EmergencyShutDownRemarks;
						craneDTO.OperatingReturnRemarks = crane.OperatingReturnRemarks;
						craneDTO.OperatingControlsRemarks = crane.OperatingControlsRemarks;
						craneDTO.HeadLightRemarks = crane.HeadLightRemarks;
						craneDTO.ReverseAlarmRemarks = crane.ReverseAlarmRemarks;
						craneDTO.ParkingBrakeRemarks = crane.ParkingBrakeRemarks;
						craneDTO.SafetyBeltRemarks = crane.SafetyBeltRemarks;
						craneDTO.DriverSeatRemarks = crane.DriverSeatRemarks;
						craneDTO.WipersRemarks = crane.WipersRemarks;
						craneDTO.ExistingCorrosionRemarks = crane.ExistingCorrosionRemarks;
						craneDTO.TireBoltsRemarks = crane.TireBoltsRemarks;
						craneDTO.SafeLoadIndicatorRemarks = crane.SafeLoadIndicatorRemarks;
						craneDTO.ScreenCurtainsRemarks = crane.ScreenCurtainsRemarks;
						craneDTO.OutriggerRemarks = crane.OutriggerRemarks;
						craneDTO.StrangeSoundRemarks = crane.StrangeSoundRemarks;
						craneDTO.DriverName = crane.DriverName;
						craneDTO.userName = crane.user.UserName;

						newTemp.Add(craneDTO);

					}
					if (newTemp != null)
					{
						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}
				}
			}
			catch (Exception ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}
			return result;
		}


		[HttpGet("ByPage/{page:int}")]
		public PageResult<CraneResponseDTO> GettAllStoCardsByPage(string UserId, string UserRole, int? page, int pagesize = 10)
		{
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<Crane> temp = craneRepository.getall();
					List<CraneResponseDTO> newTemp = new List<CraneResponseDTO>();
					foreach (Crane crane in temp)
					{
						CraneResponseDTO craneDTO = new CraneResponseDTO();
						craneDTO.Id = crane.Id;
						craneDTO.RigNo = crane.Rig.Number;
						craneDTO.Date = crane.Date;
						craneDTO.WellName = crane.WellName;
						craneDTO.UnitNo = crane.UnitNo;
						craneDTO.QHSEEngineer = crane.QHSEEngineer;
						//craneDTO.HrsSinceOilChange = crane.HrsSinceOilChange;
						craneDTO.CleanAndTidy = crane.CleanAndTidy;
						craneDTO.EngineOilLevel = crane.EngineOilLevel;
						craneDTO.TransmissionOilLevel = crane.TransmissionOilLevel;
						craneDTO.RadiatorWaterLevel = crane.RadiatorWaterLevel;
						craneDTO.HydraulicOilLevel = crane.HydraulicOilLevel;
						craneDTO.V_beltsTension = crane.V_beltsTension;
						craneDTO.DrainWater = crane.DrainWater;
						craneDTO.Leaks = crane.Leaks;
						craneDTO.BatteryHolder = crane.BatteryHolder;
						craneDTO.LoadComputer = crane.LoadComputer;
						craneDTO.GaugesForCcorrectReadings = crane.GaugesForCcorrectReadings;
						craneDTO.TirePressure = crane.TirePressure;
						craneDTO.FuelTanksFull = crane.FuelTanksFull;
						craneDTO.WireRopes = crane.WireRopes;
						craneDTO.SwingBrake = crane.SwingBrake;
						craneDTO.TestLimitSwitches = crane.TestLimitSwitches;
						craneDTO.TestOutriggers = crane.TestOutriggers;
						craneDTO.AbnormalNoise = crane.AbnormalNoise;
						craneDTO.ServiceBrakes = crane.ServiceBrakes;
						craneDTO.Sheaves = crane.Sheaves;
						craneDTO.SpoolingOfWire = crane.SpoolingOfWire;
						craneDTO.Hookcondition = crane.Hookcondition;
						craneDTO.BoomSections = crane.BoomSections;
						craneDTO.EngineV_belts = crane.EngineV_belts;
						craneDTO.WiringVisually = crane.WiringVisually;
						craneDTO.LoadIndicator = crane.LoadIndicator;
						craneDTO.AudibleAlarm = crane.AudibleAlarm;
						craneDTO.LoadLimiting = crane.LoadLimiting;
						craneDTO.BoomAngle = crane.BoomAngle;
						craneDTO.LimitSwitch = crane.LimitSwitch;
						craneDTO.EmergencyShutDown = crane.EmergencyShutDown;
						craneDTO.OperatingReturn = crane.OperatingReturn;
						craneDTO.OperatingControls = crane.OperatingControls;
						craneDTO.HeadLight = crane.HeadLight;
						craneDTO.ReverseAlarm = crane.ReverseAlarm;
						craneDTO.ParkingBrake = crane.ParkingBrake;
						craneDTO.SafetyBelt = crane.SafetyBelt;
						craneDTO.DriverSeat = crane.DriverSeat;
						craneDTO.Wipers = crane.Wipers;
						craneDTO.ExistingCorrosion = crane.ExistingCorrosion;
						craneDTO.TireBolts = crane.TireBolts;
						craneDTO.SafeLoadIndicator = crane.SafeLoadIndicator;
						craneDTO.ScreenCurtains = crane.ScreenCurtains;
						craneDTO.Outrigger = crane.Outrigger;
						craneDTO.StrangeSound = crane.StrangeSound;
						craneDTO.CleanAndTidyRemarks = crane.CleanAndTidyRemarks;
						craneDTO.EngineOilLevelRemarks = crane.EngineOilLevelRemarks;
						craneDTO.TransmissionOilLevelRemarks = crane.TransmissionOilLevelRemarks;
						craneDTO.RadiatorWaterLevelRemarks = crane.RadiatorWaterLevelRemarks;
						craneDTO.HydraulicOilLevelRemarks = crane.HydraulicOilLevelRemarks;
						craneDTO.V_beltsTensionRemarks = crane.V_beltsTensionRemarks;
						craneDTO.DrainWaterRemarks = crane.DrainWaterRemarks;
						craneDTO.LeaksRemarks = crane.LeaksRemarks;
						craneDTO.BatteryHolderRemarks = crane.BatteryHolderRemarks;
						craneDTO.LoadComputerRemarks = crane.LoadComputerRemarks;
						craneDTO.GaugesForCcorrectReadingsRemarks = crane.GaugesForCcorrectReadingsRemarks;
						craneDTO.TirePressureRemarks = crane.TirePressureRemarks;
						craneDTO.FuelTanksFullRemarks = crane.FuelTanksFullRemarks;
						craneDTO.WireRopesRemarks = crane.WireRopesRemarks;
						craneDTO.SwingBrakeRemarks = crane.SwingBrakeRemarks;
						craneDTO.TestLimitSwitchesRemarks = crane.TestLimitSwitchesRemarks;
						craneDTO.TestOutriggersRemarks = crane.TestOutriggersRemarks;
						craneDTO.AbnormalNoiseRemarks = crane.AbnormalNoiseRemarks;
						craneDTO.ServiceBrakesRemarks = crane.ServiceBrakesRemarks;
						craneDTO.SheavesRemarks = crane.SheavesRemarks;
						craneDTO.SpoolingOfWireRemarks = crane.SpoolingOfWireRemarks;
						craneDTO.HookconditionRemarks = crane.HookconditionRemarks;
						craneDTO.BoomSectionsRemarks = crane.BoomSectionsRemarks;
						craneDTO.EngineV_beltsRemarks = crane.EngineV_beltsRemarks;
						craneDTO.WiringVisuallyRemarks = crane.WiringVisuallyRemarks;
						craneDTO.LoadIndicatorRemarks = crane.LoadIndicatorRemarks;
						craneDTO.AudibleAlarmRemarks = crane.AudibleAlarmRemarks;
						craneDTO.LoadLimitingRemarks = crane.LoadLimitingRemarks;
						craneDTO.BoomAngleRemarks = crane.BoomAngleRemarks;
						craneDTO.LimitSwitchRemarks = crane.LimitSwitchRemarks;
						craneDTO.EmergencyShutDownRemarks = crane.EmergencyShutDownRemarks;
						craneDTO.OperatingReturnRemarks = crane.OperatingReturnRemarks;
						craneDTO.OperatingControlsRemarks = crane.OperatingControlsRemarks;
						craneDTO.HeadLightRemarks = crane.HeadLightRemarks;
						craneDTO.ReverseAlarmRemarks = crane.ReverseAlarmRemarks;
						craneDTO.ParkingBrakeRemarks = crane.ParkingBrakeRemarks;
						craneDTO.SafetyBeltRemarks = crane.SafetyBeltRemarks;
						craneDTO.DriverSeatRemarks = crane.DriverSeatRemarks;
						craneDTO.WipersRemarks = crane.WipersRemarks;
						craneDTO.ExistingCorrosionRemarks = crane.ExistingCorrosionRemarks;
						craneDTO.TireBoltsRemarks = crane.TireBoltsRemarks;
						craneDTO.SafeLoadIndicatorRemarks = crane.SafeLoadIndicatorRemarks;
						craneDTO.ScreenCurtainsRemarks = crane.ScreenCurtainsRemarks;
						craneDTO.OutriggerRemarks = crane.OutriggerRemarks;
						craneDTO.StrangeSoundRemarks = crane.StrangeSoundRemarks;
						craneDTO.DriverName = crane.DriverName;
						craneDTO.userName = crane.user.UserName;

						newTemp.Add(craneDTO);
					}

					float countDetails = craneRepository.getall().Count();
					var result = new PageResult<CraneResponseDTO>
					{
						Count = (int)Math.Ceiling(countDetails / pagesize),
						PageIndex = page ?? 1,
						PageSize = pagesize,
						Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
					};

					return result;

				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<Crane> temp = craneRepository.getall().Where(a => a.user.Id == UserId).ToList();
					List<CraneResponseDTO> newTemp = new List<CraneResponseDTO>();
					foreach (Crane crane in temp)
					{
						CraneResponseDTO craneDTO = new CraneResponseDTO();
						craneDTO.Id = crane.Id;
						craneDTO.RigNo = crane.Rig.Number;
						craneDTO.Date = crane.Date;
						craneDTO.WellName = crane.WellName;
						craneDTO.UnitNo = crane.UnitNo;
						craneDTO.QHSEEngineer = crane.QHSEEngineer;
						//craneDTO.HrsSinceOilChange = crane.HrsSinceOilChange;
						craneDTO.CleanAndTidy = crane.CleanAndTidy;
						craneDTO.EngineOilLevel = crane.EngineOilLevel;
						craneDTO.TransmissionOilLevel = crane.TransmissionOilLevel;
						craneDTO.RadiatorWaterLevel = crane.RadiatorWaterLevel;
						craneDTO.HydraulicOilLevel = crane.HydraulicOilLevel;
						craneDTO.V_beltsTension = crane.V_beltsTension;
						craneDTO.DrainWater = crane.DrainWater;
						craneDTO.Leaks = crane.Leaks;
						craneDTO.BatteryHolder = crane.BatteryHolder;
						craneDTO.LoadComputer = crane.LoadComputer;
						craneDTO.GaugesForCcorrectReadings = crane.GaugesForCcorrectReadings;
						craneDTO.TirePressure = crane.TirePressure;
						craneDTO.FuelTanksFull = crane.FuelTanksFull;
						craneDTO.WireRopes = crane.WireRopes;
						craneDTO.SwingBrake = crane.SwingBrake;
						craneDTO.TestLimitSwitches = crane.TestLimitSwitches;
						craneDTO.TestOutriggers = crane.TestOutriggers;
						craneDTO.AbnormalNoise = crane.AbnormalNoise;
						craneDTO.ServiceBrakes = crane.ServiceBrakes;
						craneDTO.Sheaves = crane.Sheaves;
						craneDTO.SpoolingOfWire = crane.SpoolingOfWire;
						craneDTO.Hookcondition = crane.Hookcondition;
						craneDTO.BoomSections = crane.BoomSections;
						craneDTO.EngineV_belts = crane.EngineV_belts;
						craneDTO.WiringVisually = crane.WiringVisually;
						craneDTO.LoadIndicator = crane.LoadIndicator;
						craneDTO.AudibleAlarm = crane.AudibleAlarm;
						craneDTO.LoadLimiting = crane.LoadLimiting;
						craneDTO.BoomAngle = crane.BoomAngle;
						craneDTO.LimitSwitch = crane.LimitSwitch;
						craneDTO.EmergencyShutDown = crane.EmergencyShutDown;
						craneDTO.OperatingReturn = crane.OperatingReturn;
						craneDTO.OperatingControls = crane.OperatingControls;
						craneDTO.HeadLight = crane.HeadLight;
						craneDTO.ReverseAlarm = crane.ReverseAlarm;
						craneDTO.ParkingBrake = crane.ParkingBrake;
						craneDTO.SafetyBelt = crane.SafetyBelt;
						craneDTO.DriverSeat = crane.DriverSeat;
						craneDTO.Wipers = crane.Wipers;
						craneDTO.ExistingCorrosion = crane.ExistingCorrosion;
						craneDTO.TireBolts = crane.TireBolts;
						craneDTO.SafeLoadIndicator = crane.SafeLoadIndicator;
						craneDTO.ScreenCurtains = crane.ScreenCurtains;
						craneDTO.Outrigger = crane.Outrigger;
						craneDTO.StrangeSound = crane.StrangeSound;
						craneDTO.CleanAndTidyRemarks = crane.CleanAndTidyRemarks;
						craneDTO.EngineOilLevelRemarks = crane.EngineOilLevelRemarks;
						craneDTO.TransmissionOilLevelRemarks = crane.TransmissionOilLevelRemarks;
						craneDTO.RadiatorWaterLevelRemarks = crane.RadiatorWaterLevelRemarks;
						craneDTO.HydraulicOilLevelRemarks = crane.HydraulicOilLevelRemarks;
						craneDTO.V_beltsTensionRemarks = crane.V_beltsTensionRemarks;
						craneDTO.DrainWaterRemarks = crane.DrainWaterRemarks;
						craneDTO.LeaksRemarks = crane.LeaksRemarks;
						craneDTO.BatteryHolderRemarks = crane.BatteryHolderRemarks;
						craneDTO.LoadComputerRemarks = crane.LoadComputerRemarks;
						craneDTO.GaugesForCcorrectReadingsRemarks = crane.GaugesForCcorrectReadingsRemarks;
						craneDTO.TirePressureRemarks = crane.TirePressureRemarks;
						craneDTO.FuelTanksFullRemarks = crane.FuelTanksFullRemarks;
						craneDTO.WireRopesRemarks = crane.WireRopesRemarks;
						craneDTO.SwingBrakeRemarks = crane.SwingBrakeRemarks;
						craneDTO.TestLimitSwitchesRemarks = crane.TestLimitSwitchesRemarks;
						craneDTO.TestOutriggersRemarks = crane.TestOutriggersRemarks;
						craneDTO.AbnormalNoiseRemarks = crane.AbnormalNoiseRemarks;
						craneDTO.ServiceBrakesRemarks = crane.ServiceBrakesRemarks;
						craneDTO.SheavesRemarks = crane.SheavesRemarks;
						craneDTO.SpoolingOfWireRemarks = crane.SpoolingOfWireRemarks;
						craneDTO.HookconditionRemarks = crane.HookconditionRemarks;
						craneDTO.BoomSectionsRemarks = crane.BoomSectionsRemarks;
						craneDTO.EngineV_beltsRemarks = crane.EngineV_beltsRemarks;
						craneDTO.WiringVisuallyRemarks = crane.WiringVisuallyRemarks;
						craneDTO.LoadIndicatorRemarks = crane.LoadIndicatorRemarks;
						craneDTO.AudibleAlarmRemarks = crane.AudibleAlarmRemarks;
						craneDTO.LoadLimitingRemarks = crane.LoadLimitingRemarks;
						craneDTO.BoomAngleRemarks = crane.BoomAngleRemarks;
						craneDTO.LimitSwitchRemarks = crane.LimitSwitchRemarks;
						craneDTO.EmergencyShutDownRemarks = crane.EmergencyShutDownRemarks;
						craneDTO.OperatingReturnRemarks = crane.OperatingReturnRemarks;
						craneDTO.OperatingControlsRemarks = crane.OperatingControlsRemarks;
						craneDTO.HeadLightRemarks = crane.HeadLightRemarks;
						craneDTO.ReverseAlarmRemarks = crane.ReverseAlarmRemarks;
						craneDTO.ParkingBrakeRemarks = crane.ParkingBrakeRemarks;
						craneDTO.SafetyBeltRemarks = crane.SafetyBeltRemarks;
						craneDTO.DriverSeatRemarks = crane.DriverSeatRemarks;
						craneDTO.WipersRemarks = crane.WipersRemarks;
						craneDTO.ExistingCorrosionRemarks = crane.ExistingCorrosionRemarks;
						craneDTO.TireBoltsRemarks = crane.TireBoltsRemarks;
						craneDTO.SafeLoadIndicatorRemarks = crane.SafeLoadIndicatorRemarks;
						craneDTO.ScreenCurtainsRemarks = crane.ScreenCurtainsRemarks;
						craneDTO.OutriggerRemarks = crane.OutriggerRemarks;
						craneDTO.StrangeSoundRemarks = crane.StrangeSoundRemarks;
						craneDTO.DriverName = crane.DriverName;
						craneDTO.userName = crane.user.UserName;

						newTemp.Add(craneDTO);
					}

					float countDetails = craneRepository.getall().Where(a => a.user.Id == UserId).Count();
					var result = new PageResult<CraneResponseDTO>
					{
						Count = (int)Math.Ceiling(countDetails / pagesize),
						PageIndex = page ?? 1,
						PageSize = pagesize,
						Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
					};
					return result;
				}
			}
			catch (Exception ex)
			{
				return new PageResult<CraneResponseDTO>();

			}
			return new PageResult<CraneResponseDTO>();
		}


		[HttpGet("GetDataById/{ID:int}")]
		public ActionResult<ResultDTO> GetAllWithDataByID(int ID, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
			{
				Crane crane = craneRepository.getall().FirstOrDefault(a => a.Id == ID);
				if (crane != null)
				{
					CraneResponseDTO craneDTO = new CraneResponseDTO();
					craneDTO.Id = crane.Id;
					craneDTO.RigNo = crane.Rig.Number;
					craneDTO.Date = crane.Date;
					craneDTO.WellName = crane.WellName;
					craneDTO.UnitNo = crane.UnitNo;
					craneDTO.QHSEEngineer = crane.QHSEEngineer;
					//craneDTO.HrsSinceOilChange = crane.HrsSinceOilChange;
					craneDTO.CleanAndTidy = crane.CleanAndTidy;
					craneDTO.EngineOilLevel = crane.EngineOilLevel;
					craneDTO.TransmissionOilLevel = crane.TransmissionOilLevel;
					craneDTO.RadiatorWaterLevel = crane.RadiatorWaterLevel;
					craneDTO.HydraulicOilLevel = crane.HydraulicOilLevel;
					craneDTO.V_beltsTension = crane.V_beltsTension;
					craneDTO.DrainWater = crane.DrainWater;
					craneDTO.Leaks = crane.Leaks;
					craneDTO.BatteryHolder = crane.BatteryHolder;
					craneDTO.LoadComputer = crane.LoadComputer;
					craneDTO.GaugesForCcorrectReadings = crane.GaugesForCcorrectReadings;
					craneDTO.TirePressure = crane.TirePressure;
					craneDTO.FuelTanksFull = crane.FuelTanksFull;
					craneDTO.WireRopes = crane.WireRopes;
					craneDTO.SwingBrake = crane.SwingBrake;
					craneDTO.TestLimitSwitches = crane.TestLimitSwitches;
					craneDTO.TestOutriggers = crane.TestOutriggers;
					craneDTO.AbnormalNoise = crane.AbnormalNoise;
					craneDTO.ServiceBrakes = crane.ServiceBrakes;
					craneDTO.Sheaves = crane.Sheaves;
					craneDTO.SpoolingOfWire = crane.SpoolingOfWire;
					craneDTO.Hookcondition = crane.Hookcondition;
					craneDTO.BoomSections = crane.BoomSections;
					craneDTO.EngineV_belts = crane.EngineV_belts;
					craneDTO.WiringVisually = crane.WiringVisually;
					craneDTO.LoadIndicator = crane.LoadIndicator;
					craneDTO.AudibleAlarm = crane.AudibleAlarm;
					craneDTO.LoadLimiting = crane.LoadLimiting;
					craneDTO.BoomAngle = crane.BoomAngle;
					craneDTO.LimitSwitch = crane.LimitSwitch;
					craneDTO.EmergencyShutDown = crane.EmergencyShutDown;
					craneDTO.OperatingReturn = crane.OperatingReturn;
					craneDTO.OperatingControls = crane.OperatingControls;
					craneDTO.HeadLight = crane.HeadLight;
					craneDTO.ReverseAlarm = crane.ReverseAlarm;
					craneDTO.ParkingBrake = crane.ParkingBrake;
					craneDTO.SafetyBelt = crane.SafetyBelt;
					craneDTO.DriverSeat = crane.DriverSeat;
					craneDTO.Wipers = crane.Wipers;
					craneDTO.ExistingCorrosion = crane.ExistingCorrosion;
					craneDTO.TireBolts = crane.TireBolts;
					craneDTO.SafeLoadIndicator = crane.SafeLoadIndicator;
					craneDTO.ScreenCurtains = crane.ScreenCurtains;
					craneDTO.Outrigger = crane.Outrigger;
					craneDTO.StrangeSound = crane.StrangeSound;
					craneDTO.CleanAndTidyRemarks = crane.CleanAndTidyRemarks;
					craneDTO.EngineOilLevelRemarks = crane.EngineOilLevelRemarks;
					craneDTO.TransmissionOilLevelRemarks = crane.TransmissionOilLevelRemarks;
					craneDTO.RadiatorWaterLevelRemarks = crane.RadiatorWaterLevelRemarks;
					craneDTO.HydraulicOilLevelRemarks = crane.HydraulicOilLevelRemarks;
					craneDTO.V_beltsTensionRemarks = crane.V_beltsTensionRemarks;
					craneDTO.DrainWaterRemarks = crane.DrainWaterRemarks;
					craneDTO.LeaksRemarks = crane.LeaksRemarks;
					craneDTO.BatteryHolderRemarks = crane.BatteryHolderRemarks;
					craneDTO.LoadComputerRemarks = crane.LoadComputerRemarks;
					craneDTO.GaugesForCcorrectReadingsRemarks = crane.GaugesForCcorrectReadingsRemarks;
					craneDTO.TirePressureRemarks = crane.TirePressureRemarks;
					craneDTO.FuelTanksFullRemarks = crane.FuelTanksFullRemarks;
					craneDTO.WireRopesRemarks = crane.WireRopesRemarks;
					craneDTO.SwingBrakeRemarks = crane.SwingBrakeRemarks;
					craneDTO.TestLimitSwitchesRemarks = crane.TestLimitSwitchesRemarks;
					craneDTO.TestOutriggersRemarks = crane.TestOutriggersRemarks;
					craneDTO.AbnormalNoiseRemarks = crane.AbnormalNoiseRemarks;
					craneDTO.ServiceBrakesRemarks = crane.ServiceBrakesRemarks;
					craneDTO.SheavesRemarks = crane.SheavesRemarks;
					craneDTO.SpoolingOfWireRemarks = crane.SpoolingOfWireRemarks;
					craneDTO.HookconditionRemarks = crane.HookconditionRemarks;
					craneDTO.BoomSectionsRemarks = crane.BoomSectionsRemarks;
					craneDTO.EngineV_beltsRemarks = crane.EngineV_beltsRemarks;
					craneDTO.WiringVisuallyRemarks = crane.WiringVisuallyRemarks;
					craneDTO.LoadIndicatorRemarks = crane.LoadIndicatorRemarks;
					craneDTO.AudibleAlarmRemarks = crane.AudibleAlarmRemarks;
					craneDTO.LoadLimitingRemarks = crane.LoadLimitingRemarks;
					craneDTO.BoomAngleRemarks = crane.BoomAngleRemarks;
					craneDTO.LimitSwitchRemarks = crane.LimitSwitchRemarks;
					craneDTO.EmergencyShutDownRemarks = crane.EmergencyShutDownRemarks;
					craneDTO.OperatingReturnRemarks = crane.OperatingReturnRemarks;
					craneDTO.OperatingControlsRemarks = crane.OperatingControlsRemarks;
					craneDTO.HeadLightRemarks = crane.HeadLightRemarks;
					craneDTO.ReverseAlarmRemarks = crane.ReverseAlarmRemarks;
					craneDTO.ParkingBrakeRemarks = crane.ParkingBrakeRemarks;
					craneDTO.SafetyBeltRemarks = crane.SafetyBeltRemarks;
					craneDTO.DriverSeatRemarks = crane.DriverSeatRemarks;
					craneDTO.WipersRemarks = crane.WipersRemarks;
					craneDTO.ExistingCorrosionRemarks = crane.ExistingCorrosionRemarks;
					craneDTO.TireBoltsRemarks = crane.TireBoltsRemarks;
					craneDTO.SafeLoadIndicatorRemarks = crane.SafeLoadIndicatorRemarks;
					craneDTO.ScreenCurtainsRemarks = crane.ScreenCurtainsRemarks;
					craneDTO.OutriggerRemarks = crane.OutriggerRemarks;
					craneDTO.StrangeSoundRemarks = crane.StrangeSoundRemarks;
					craneDTO.DriverName = crane.DriverName;
					craneDTO.userName = crane.user.UserName;
					craneDTO.IsDeleted = crane.IsDeleted;


					if (craneDTO != null)
					{

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = craneDTO;

						return result;
					}
				}

			}
			else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
			{
				Crane crane = craneRepository.getall().FirstOrDefault(a => a.Id == ID && a.user.Id == UserId);
				if (crane != null)
				{
					CraneResponseDTO craneDTO = new CraneResponseDTO();
					craneDTO.Id = crane.Id;
					craneDTO.RigNo = crane.Rig.Number;
					craneDTO.Date = crane.Date;
					craneDTO.WellName = crane.WellName;
					craneDTO.UnitNo = crane.UnitNo;
					craneDTO.QHSEEngineer = crane.QHSEEngineer;
					//craneDTO.HrsSinceOilChange = crane.HrsSinceOilChange;
					craneDTO.CleanAndTidy = crane.CleanAndTidy;
					craneDTO.EngineOilLevel = crane.EngineOilLevel;
					craneDTO.TransmissionOilLevel = crane.TransmissionOilLevel;
					craneDTO.RadiatorWaterLevel = crane.RadiatorWaterLevel;
					craneDTO.HydraulicOilLevel = crane.HydraulicOilLevel;
					craneDTO.V_beltsTension = crane.V_beltsTension;
					craneDTO.DrainWater = crane.DrainWater;
					craneDTO.Leaks = crane.Leaks;
					craneDTO.BatteryHolder = crane.BatteryHolder;
					craneDTO.LoadComputer = crane.LoadComputer;
					craneDTO.GaugesForCcorrectReadings = crane.GaugesForCcorrectReadings;
					craneDTO.TirePressure = crane.TirePressure;
					craneDTO.FuelTanksFull = crane.FuelTanksFull;
					craneDTO.WireRopes = crane.WireRopes;
					craneDTO.SwingBrake = crane.SwingBrake;
					craneDTO.TestLimitSwitches = crane.TestLimitSwitches;
					craneDTO.TestOutriggers = crane.TestOutriggers;
					craneDTO.AbnormalNoise = crane.AbnormalNoise;
					craneDTO.ServiceBrakes = crane.ServiceBrakes;
					craneDTO.Sheaves = crane.Sheaves;
					craneDTO.SpoolingOfWire = crane.SpoolingOfWire;
					craneDTO.Hookcondition = crane.Hookcondition;
					craneDTO.BoomSections = crane.BoomSections;
					craneDTO.EngineV_belts = crane.EngineV_belts;
					craneDTO.WiringVisually = crane.WiringVisually;
					craneDTO.LoadIndicator = crane.LoadIndicator;
					craneDTO.AudibleAlarm = crane.AudibleAlarm;
					craneDTO.LoadLimiting = crane.LoadLimiting;
					craneDTO.BoomAngle = crane.BoomAngle;
					craneDTO.LimitSwitch = crane.LimitSwitch;
					craneDTO.EmergencyShutDown = crane.EmergencyShutDown;
					craneDTO.OperatingReturn = crane.OperatingReturn;
					craneDTO.OperatingControls = crane.OperatingControls;
					craneDTO.HeadLight = crane.HeadLight;
					craneDTO.ReverseAlarm = crane.ReverseAlarm;
					craneDTO.ParkingBrake = crane.ParkingBrake;
					craneDTO.SafetyBelt = crane.SafetyBelt;
					craneDTO.DriverSeat = crane.DriverSeat;
					craneDTO.Wipers = crane.Wipers;
					craneDTO.ExistingCorrosion = crane.ExistingCorrosion;
					craneDTO.TireBolts = crane.TireBolts;
					craneDTO.SafeLoadIndicator = crane.SafeLoadIndicator;
					craneDTO.ScreenCurtains = crane.ScreenCurtains;
					craneDTO.Outrigger = crane.Outrigger;
					craneDTO.StrangeSound = crane.StrangeSound;
					craneDTO.CleanAndTidyRemarks = crane.CleanAndTidyRemarks;
					craneDTO.EngineOilLevelRemarks = crane.EngineOilLevelRemarks;
					craneDTO.TransmissionOilLevelRemarks = crane.TransmissionOilLevelRemarks;
					craneDTO.RadiatorWaterLevelRemarks = crane.RadiatorWaterLevelRemarks;
					craneDTO.HydraulicOilLevelRemarks = crane.HydraulicOilLevelRemarks;
					craneDTO.V_beltsTensionRemarks = crane.V_beltsTensionRemarks;
					craneDTO.DrainWaterRemarks = crane.DrainWaterRemarks;
					craneDTO.LeaksRemarks = crane.LeaksRemarks;
					craneDTO.BatteryHolderRemarks = crane.BatteryHolderRemarks;
					craneDTO.LoadComputerRemarks = crane.LoadComputerRemarks;
					craneDTO.GaugesForCcorrectReadingsRemarks = crane.GaugesForCcorrectReadingsRemarks;
					craneDTO.TirePressureRemarks = crane.TirePressureRemarks;
					craneDTO.FuelTanksFullRemarks = crane.FuelTanksFullRemarks;
					craneDTO.WireRopesRemarks = crane.WireRopesRemarks;
					craneDTO.SwingBrakeRemarks = crane.SwingBrakeRemarks;
					craneDTO.TestLimitSwitchesRemarks = crane.TestLimitSwitchesRemarks;
					craneDTO.TestOutriggersRemarks = crane.TestOutriggersRemarks;
					craneDTO.AbnormalNoiseRemarks = crane.AbnormalNoiseRemarks;
					craneDTO.ServiceBrakesRemarks = crane.ServiceBrakesRemarks;
					craneDTO.SheavesRemarks = crane.SheavesRemarks;
					craneDTO.SpoolingOfWireRemarks = crane.SpoolingOfWireRemarks;
					craneDTO.HookconditionRemarks = crane.HookconditionRemarks;
					craneDTO.BoomSectionsRemarks = crane.BoomSectionsRemarks;
					craneDTO.EngineV_beltsRemarks = crane.EngineV_beltsRemarks;
					craneDTO.WiringVisuallyRemarks = crane.WiringVisuallyRemarks;
					craneDTO.LoadIndicatorRemarks = crane.LoadIndicatorRemarks;
					craneDTO.AudibleAlarmRemarks = crane.AudibleAlarmRemarks;
					craneDTO.LoadLimitingRemarks = crane.LoadLimitingRemarks;
					craneDTO.BoomAngleRemarks = crane.BoomAngleRemarks;
					craneDTO.LimitSwitchRemarks = crane.LimitSwitchRemarks;
					craneDTO.EmergencyShutDownRemarks = crane.EmergencyShutDownRemarks;
					craneDTO.OperatingReturnRemarks = crane.OperatingReturnRemarks;
					craneDTO.OperatingControlsRemarks = crane.OperatingControlsRemarks;
					craneDTO.HeadLightRemarks = crane.HeadLightRemarks;
					craneDTO.ReverseAlarmRemarks = crane.ReverseAlarmRemarks;
					craneDTO.ParkingBrakeRemarks = crane.ParkingBrakeRemarks;
					craneDTO.SafetyBeltRemarks = crane.SafetyBeltRemarks;
					craneDTO.DriverSeatRemarks = crane.DriverSeatRemarks;
					craneDTO.WipersRemarks = crane.WipersRemarks;
					craneDTO.ExistingCorrosionRemarks = crane.ExistingCorrosionRemarks;
					craneDTO.TireBoltsRemarks = crane.TireBoltsRemarks;
					craneDTO.SafeLoadIndicatorRemarks = crane.SafeLoadIndicatorRemarks;
					craneDTO.ScreenCurtainsRemarks = crane.ScreenCurtainsRemarks;
					craneDTO.OutriggerRemarks = crane.OutriggerRemarks;
					craneDTO.StrangeSoundRemarks = crane.StrangeSoundRemarks;
					craneDTO.DriverName = crane.DriverName;
					craneDTO.userName = crane.user.UserName;
					craneDTO.IsDeleted = crane.IsDeleted;


					if (craneDTO != null)
					{

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = craneDTO;

						return result;
					}
				}

			}

			result.Statescode = 404;
			result.Message = "data not found";
			return result;
		}


		[HttpGet("GetDataByDate/{date:DateTime}")]
		public ActionResult<ResultDTO> GetAllWithDataByDate(DateTime date, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<CraneResponseDTO> craneDTOs = new List<CraneResponseDTO>();
					List<Crane> cranes = craneRepository.getall().Where(a => a.Date == date).ToList();
					foreach (Crane crane in cranes)
					{
						CraneResponseDTO craneDTO = new CraneResponseDTO();
						craneDTO.Id = crane.Id;
						craneDTO.RigNo = crane.Rig.Number;
						craneDTO.Date = crane.Date;
						craneDTO.WellName = crane.WellName;
						craneDTO.UnitNo = crane.UnitNo;
						craneDTO.QHSEEngineer = crane.QHSEEngineer;
						//craneDTO.HrsSinceOilChange = crane.HrsSinceOilChange;
						craneDTO.CleanAndTidy = crane.CleanAndTidy;
						craneDTO.EngineOilLevel = crane.EngineOilLevel;
						craneDTO.TransmissionOilLevel = crane.TransmissionOilLevel;
						craneDTO.RadiatorWaterLevel = crane.RadiatorWaterLevel;
						craneDTO.HydraulicOilLevel = crane.HydraulicOilLevel;
						craneDTO.V_beltsTension = crane.V_beltsTension;
						craneDTO.DrainWater = crane.DrainWater;
						craneDTO.Leaks = crane.Leaks;
						craneDTO.BatteryHolder = crane.BatteryHolder;
						craneDTO.LoadComputer = crane.LoadComputer;
						craneDTO.GaugesForCcorrectReadings = crane.GaugesForCcorrectReadings;
						craneDTO.TirePressure = crane.TirePressure;
						craneDTO.FuelTanksFull = crane.FuelTanksFull;
						craneDTO.WireRopes = crane.WireRopes;
						craneDTO.SwingBrake = crane.SwingBrake;
						craneDTO.TestLimitSwitches = crane.TestLimitSwitches;
						craneDTO.TestOutriggers = crane.TestOutriggers;
						craneDTO.AbnormalNoise = crane.AbnormalNoise;
						craneDTO.ServiceBrakes = crane.ServiceBrakes;
						craneDTO.Sheaves = crane.Sheaves;
						craneDTO.SpoolingOfWire = crane.SpoolingOfWire;
						craneDTO.Hookcondition = crane.Hookcondition;
						craneDTO.BoomSections = crane.BoomSections;
						craneDTO.EngineV_belts = crane.EngineV_belts;
						craneDTO.WiringVisually = crane.WiringVisually;
						craneDTO.LoadIndicator = crane.LoadIndicator;
						craneDTO.AudibleAlarm = crane.AudibleAlarm;
						craneDTO.LoadLimiting = crane.LoadLimiting;
						craneDTO.BoomAngle = crane.BoomAngle;
						craneDTO.LimitSwitch = crane.LimitSwitch;
						craneDTO.EmergencyShutDown = crane.EmergencyShutDown;
						craneDTO.OperatingReturn = crane.OperatingReturn;
						craneDTO.OperatingControls = crane.OperatingControls;
						craneDTO.HeadLight = crane.HeadLight;
						craneDTO.ReverseAlarm = crane.ReverseAlarm;
						craneDTO.ParkingBrake = crane.ParkingBrake;
						craneDTO.SafetyBelt = crane.SafetyBelt;
						craneDTO.DriverSeat = crane.DriverSeat;
						craneDTO.Wipers = crane.Wipers;
						craneDTO.ExistingCorrosion = crane.ExistingCorrosion;
						craneDTO.TireBolts = crane.TireBolts;
						craneDTO.SafeLoadIndicator = crane.SafeLoadIndicator;
						craneDTO.ScreenCurtains = crane.ScreenCurtains;
						craneDTO.Outrigger = crane.Outrigger;
						craneDTO.StrangeSound = crane.StrangeSound;
						craneDTO.CleanAndTidyRemarks = crane.CleanAndTidyRemarks;
						craneDTO.EngineOilLevelRemarks = crane.EngineOilLevelRemarks;
						craneDTO.TransmissionOilLevelRemarks = crane.TransmissionOilLevelRemarks;
						craneDTO.RadiatorWaterLevelRemarks = crane.RadiatorWaterLevelRemarks;
						craneDTO.HydraulicOilLevelRemarks = crane.HydraulicOilLevelRemarks;
						craneDTO.V_beltsTensionRemarks = crane.V_beltsTensionRemarks;
						craneDTO.DrainWaterRemarks = crane.DrainWaterRemarks;
						craneDTO.LeaksRemarks = crane.LeaksRemarks;
						craneDTO.BatteryHolderRemarks = crane.BatteryHolderRemarks;
						craneDTO.LoadComputerRemarks = crane.LoadComputerRemarks;
						craneDTO.GaugesForCcorrectReadingsRemarks = crane.GaugesForCcorrectReadingsRemarks;
						craneDTO.TirePressureRemarks = crane.TirePressureRemarks;
						craneDTO.FuelTanksFullRemarks = crane.FuelTanksFullRemarks;
						craneDTO.WireRopesRemarks = crane.WireRopesRemarks;
						craneDTO.SwingBrakeRemarks = crane.SwingBrakeRemarks;
						craneDTO.TestLimitSwitchesRemarks = crane.TestLimitSwitchesRemarks;
						craneDTO.TestOutriggersRemarks = crane.TestOutriggersRemarks;
						craneDTO.AbnormalNoiseRemarks = crane.AbnormalNoiseRemarks;
						craneDTO.ServiceBrakesRemarks = crane.ServiceBrakesRemarks;
						craneDTO.SheavesRemarks = crane.SheavesRemarks;
						craneDTO.SpoolingOfWireRemarks = crane.SpoolingOfWireRemarks;
						craneDTO.HookconditionRemarks = crane.HookconditionRemarks;
						craneDTO.BoomSectionsRemarks = crane.BoomSectionsRemarks;
						craneDTO.EngineV_beltsRemarks = crane.EngineV_beltsRemarks;
						craneDTO.WiringVisuallyRemarks = crane.WiringVisuallyRemarks;
						craneDTO.LoadIndicatorRemarks = crane.LoadIndicatorRemarks;
						craneDTO.AudibleAlarmRemarks = crane.AudibleAlarmRemarks;
						craneDTO.LoadLimitingRemarks = crane.LoadLimitingRemarks;
						craneDTO.BoomAngleRemarks = crane.BoomAngleRemarks;
						craneDTO.LimitSwitchRemarks = crane.LimitSwitchRemarks;
						craneDTO.EmergencyShutDownRemarks = crane.EmergencyShutDownRemarks;
						craneDTO.OperatingReturnRemarks = crane.OperatingReturnRemarks;
						craneDTO.OperatingControlsRemarks = crane.OperatingControlsRemarks;
						craneDTO.HeadLightRemarks = crane.HeadLightRemarks;
						craneDTO.ReverseAlarmRemarks = crane.ReverseAlarmRemarks;
						craneDTO.ParkingBrakeRemarks = crane.ParkingBrakeRemarks;
						craneDTO.SafetyBeltRemarks = crane.SafetyBeltRemarks;
						craneDTO.DriverSeatRemarks = crane.DriverSeatRemarks;
						craneDTO.WipersRemarks = crane.WipersRemarks;
						craneDTO.ExistingCorrosionRemarks = crane.ExistingCorrosionRemarks;
						craneDTO.TireBoltsRemarks = crane.TireBoltsRemarks;
						craneDTO.SafeLoadIndicatorRemarks = crane.SafeLoadIndicatorRemarks;
						craneDTO.ScreenCurtainsRemarks = crane.ScreenCurtainsRemarks;
						craneDTO.OutriggerRemarks = crane.OutriggerRemarks;
						craneDTO.StrangeSoundRemarks = crane.StrangeSoundRemarks;
						craneDTO.DriverName = crane.DriverName;
						craneDTO.userName = crane.user.UserName;
						craneDTOs.Add(craneDTO);

					}
					result.Message = "Success";
					result.Data = craneDTOs;
					result.Statescode = 200;
					return result;
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<CraneResponseDTO> craneDTOs = new List<CraneResponseDTO>();
					List<Crane> cranes = craneRepository.getall().Where(a => a.Date == date && a.user.Id == UserId).ToList();
					foreach (Crane crane in cranes)
					{
						CraneResponseDTO craneDTO = new CraneResponseDTO();
						craneDTO.Id = crane.Id;
						craneDTO.RigNo = crane.Rig.Number;
						craneDTO.Date = crane.Date;
						craneDTO.WellName = crane.WellName;
						craneDTO.UnitNo = crane.UnitNo;
						craneDTO.QHSEEngineer = crane.QHSEEngineer;
						//craneDTO.HrsSinceOilChange = crane.HrsSinceOilChange;
						craneDTO.CleanAndTidy = crane.CleanAndTidy;
						craneDTO.EngineOilLevel = crane.EngineOilLevel;
						craneDTO.TransmissionOilLevel = crane.TransmissionOilLevel;
						craneDTO.RadiatorWaterLevel = crane.RadiatorWaterLevel;
						craneDTO.HydraulicOilLevel = crane.HydraulicOilLevel;
						craneDTO.V_beltsTension = crane.V_beltsTension;
						craneDTO.DrainWater = crane.DrainWater;
						craneDTO.Leaks = crane.Leaks;
						craneDTO.BatteryHolder = crane.BatteryHolder;
						craneDTO.LoadComputer = crane.LoadComputer;
						craneDTO.GaugesForCcorrectReadings = crane.GaugesForCcorrectReadings;
						craneDTO.TirePressure = crane.TirePressure;
						craneDTO.FuelTanksFull = crane.FuelTanksFull;
						craneDTO.WireRopes = crane.WireRopes;
						craneDTO.SwingBrake = crane.SwingBrake;
						craneDTO.TestLimitSwitches = crane.TestLimitSwitches;
						craneDTO.TestOutriggers = crane.TestOutriggers;
						craneDTO.AbnormalNoise = crane.AbnormalNoise;
						craneDTO.ServiceBrakes = crane.ServiceBrakes;
						craneDTO.Sheaves = crane.Sheaves;
						craneDTO.SpoolingOfWire = crane.SpoolingOfWire;
						craneDTO.Hookcondition = crane.Hookcondition;
						craneDTO.BoomSections = crane.BoomSections;
						craneDTO.EngineV_belts = crane.EngineV_belts;
						craneDTO.WiringVisually = crane.WiringVisually;
						craneDTO.LoadIndicator = crane.LoadIndicator;
						craneDTO.AudibleAlarm = crane.AudibleAlarm;
						craneDTO.LoadLimiting = crane.LoadLimiting;
						craneDTO.BoomAngle = crane.BoomAngle;
						craneDTO.LimitSwitch = crane.LimitSwitch;
						craneDTO.EmergencyShutDown = crane.EmergencyShutDown;
						craneDTO.OperatingReturn = crane.OperatingReturn;
						craneDTO.OperatingControls = crane.OperatingControls;
						craneDTO.HeadLight = crane.HeadLight;
						craneDTO.ReverseAlarm = crane.ReverseAlarm;
						craneDTO.ParkingBrake = crane.ParkingBrake;
						craneDTO.SafetyBelt = crane.SafetyBelt;
						craneDTO.DriverSeat = crane.DriverSeat;
						craneDTO.Wipers = crane.Wipers;
						craneDTO.ExistingCorrosion = crane.ExistingCorrosion;
						craneDTO.TireBolts = crane.TireBolts;
						craneDTO.SafeLoadIndicator = crane.SafeLoadIndicator;
						craneDTO.ScreenCurtains = crane.ScreenCurtains;
						craneDTO.Outrigger = crane.Outrigger;
						craneDTO.StrangeSound = crane.StrangeSound;
						craneDTO.CleanAndTidyRemarks = crane.CleanAndTidyRemarks;
						craneDTO.EngineOilLevelRemarks = crane.EngineOilLevelRemarks;
						craneDTO.TransmissionOilLevelRemarks = crane.TransmissionOilLevelRemarks;
						craneDTO.RadiatorWaterLevelRemarks = crane.RadiatorWaterLevelRemarks;
						craneDTO.HydraulicOilLevelRemarks = crane.HydraulicOilLevelRemarks;
						craneDTO.V_beltsTensionRemarks = crane.V_beltsTensionRemarks;
						craneDTO.DrainWaterRemarks = crane.DrainWaterRemarks;
						craneDTO.LeaksRemarks = crane.LeaksRemarks;
						craneDTO.BatteryHolderRemarks = crane.BatteryHolderRemarks;
						craneDTO.LoadComputerRemarks = crane.LoadComputerRemarks;
						craneDTO.GaugesForCcorrectReadingsRemarks = crane.GaugesForCcorrectReadingsRemarks;
						craneDTO.TirePressureRemarks = crane.TirePressureRemarks;
						craneDTO.FuelTanksFullRemarks = crane.FuelTanksFullRemarks;
						craneDTO.WireRopesRemarks = crane.WireRopesRemarks;
						craneDTO.SwingBrakeRemarks = crane.SwingBrakeRemarks;
						craneDTO.TestLimitSwitchesRemarks = crane.TestLimitSwitchesRemarks;
						craneDTO.TestOutriggersRemarks = crane.TestOutriggersRemarks;
						craneDTO.AbnormalNoiseRemarks = crane.AbnormalNoiseRemarks;
						craneDTO.ServiceBrakesRemarks = crane.ServiceBrakesRemarks;
						craneDTO.SheavesRemarks = crane.SheavesRemarks;
						craneDTO.SpoolingOfWireRemarks = crane.SpoolingOfWireRemarks;
						craneDTO.HookconditionRemarks = crane.HookconditionRemarks;
						craneDTO.BoomSectionsRemarks = crane.BoomSectionsRemarks;
						craneDTO.EngineV_beltsRemarks = crane.EngineV_beltsRemarks;
						craneDTO.WiringVisuallyRemarks = crane.WiringVisuallyRemarks;
						craneDTO.LoadIndicatorRemarks = crane.LoadIndicatorRemarks;
						craneDTO.AudibleAlarmRemarks = crane.AudibleAlarmRemarks;
						craneDTO.LoadLimitingRemarks = crane.LoadLimitingRemarks;
						craneDTO.BoomAngleRemarks = crane.BoomAngleRemarks;
						craneDTO.LimitSwitchRemarks = crane.LimitSwitchRemarks;
						craneDTO.EmergencyShutDownRemarks = crane.EmergencyShutDownRemarks;
						craneDTO.OperatingReturnRemarks = crane.OperatingReturnRemarks;
						craneDTO.OperatingControlsRemarks = crane.OperatingControlsRemarks;
						craneDTO.HeadLightRemarks = crane.HeadLightRemarks;
						craneDTO.ReverseAlarmRemarks = crane.ReverseAlarmRemarks;
						craneDTO.ParkingBrakeRemarks = crane.ParkingBrakeRemarks;
						craneDTO.SafetyBeltRemarks = crane.SafetyBeltRemarks;
						craneDTO.DriverSeatRemarks = crane.DriverSeatRemarks;
						craneDTO.WipersRemarks = crane.WipersRemarks;
						craneDTO.ExistingCorrosionRemarks = crane.ExistingCorrosionRemarks;
						craneDTO.TireBoltsRemarks = crane.TireBoltsRemarks;
						craneDTO.SafeLoadIndicatorRemarks = crane.SafeLoadIndicatorRemarks;
						craneDTO.ScreenCurtainsRemarks = crane.ScreenCurtainsRemarks;
						craneDTO.OutriggerRemarks = crane.OutriggerRemarks;
						craneDTO.StrangeSoundRemarks = crane.StrangeSoundRemarks;
						craneDTO.DriverName = crane.DriverName;
						craneDTO.userName = crane.user.UserName;
						craneDTOs.Add(craneDTO);

					}
					result.Message = "Success";
					result.Data = craneDTOs;
					result.Statescode = 200;
					return result;
				}

			}
			catch (Exception ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}

			return result;

		}

		[HttpGet("GetDataByDateAndRig/{date:DateTime}")]
		public ActionResult<ResultDTO> GetDataByDateAndRig(DateTime date, int rigNo, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<CraneResponseDTO> craneDTOs = new List<CraneResponseDTO>();
					List<Crane> cranes = craneRepository.getall().Where(a => a.Date == date && a.Rig.Number == rigNo).ToList();
					foreach (Crane crane in cranes)
					{
						CraneResponseDTO craneDTO = new CraneResponseDTO();
						craneDTO.Id = crane.Id;
						craneDTO.RigNo = crane.Rig.Number;
						craneDTO.Date = crane.Date;
						craneDTO.WellName = crane.WellName;
						craneDTO.UnitNo = crane.UnitNo;
						craneDTO.QHSEEngineer = crane.QHSEEngineer;
						//craneDTO.HrsSinceOilChange = crane.HrsSinceOilChange;
						craneDTO.CleanAndTidy = crane.CleanAndTidy;
						craneDTO.EngineOilLevel = crane.EngineOilLevel;
						craneDTO.TransmissionOilLevel = crane.TransmissionOilLevel;
						craneDTO.RadiatorWaterLevel = crane.RadiatorWaterLevel;
						craneDTO.HydraulicOilLevel = crane.HydraulicOilLevel;
						craneDTO.V_beltsTension = crane.V_beltsTension;
						craneDTO.DrainWater = crane.DrainWater;
						craneDTO.Leaks = crane.Leaks;
						craneDTO.BatteryHolder = crane.BatteryHolder;
						craneDTO.LoadComputer = crane.LoadComputer;
						craneDTO.GaugesForCcorrectReadings = crane.GaugesForCcorrectReadings;
						craneDTO.TirePressure = crane.TirePressure;
						craneDTO.FuelTanksFull = crane.FuelTanksFull;
						craneDTO.WireRopes = crane.WireRopes;
						craneDTO.SwingBrake = crane.SwingBrake;
						craneDTO.TestLimitSwitches = crane.TestLimitSwitches;
						craneDTO.TestOutriggers = crane.TestOutriggers;
						craneDTO.AbnormalNoise = crane.AbnormalNoise;
						craneDTO.ServiceBrakes = crane.ServiceBrakes;
						craneDTO.Sheaves = crane.Sheaves;
						craneDTO.SpoolingOfWire = crane.SpoolingOfWire;
						craneDTO.Hookcondition = crane.Hookcondition;
						craneDTO.BoomSections = crane.BoomSections;
						craneDTO.EngineV_belts = crane.EngineV_belts;
						craneDTO.WiringVisually = crane.WiringVisually;
						craneDTO.LoadIndicator = crane.LoadIndicator;
						craneDTO.AudibleAlarm = crane.AudibleAlarm;
						craneDTO.LoadLimiting = crane.LoadLimiting;
						craneDTO.BoomAngle = crane.BoomAngle;
						craneDTO.LimitSwitch = crane.LimitSwitch;
						craneDTO.EmergencyShutDown = crane.EmergencyShutDown;
						craneDTO.OperatingReturn = crane.OperatingReturn;
						craneDTO.OperatingControls = crane.OperatingControls;
						craneDTO.HeadLight = crane.HeadLight;
						craneDTO.ReverseAlarm = crane.ReverseAlarm;
						craneDTO.ParkingBrake = crane.ParkingBrake;
						craneDTO.SafetyBelt = crane.SafetyBelt;
						craneDTO.DriverSeat = crane.DriverSeat;
						craneDTO.Wipers = crane.Wipers;
						craneDTO.ExistingCorrosion = crane.ExistingCorrosion;
						craneDTO.TireBolts = crane.TireBolts;
						craneDTO.SafeLoadIndicator = crane.SafeLoadIndicator;
						craneDTO.ScreenCurtains = crane.ScreenCurtains;
						craneDTO.Outrigger = crane.Outrigger;
						craneDTO.StrangeSound = crane.StrangeSound;
						craneDTO.CleanAndTidyRemarks = crane.CleanAndTidyRemarks;
						craneDTO.EngineOilLevelRemarks = crane.EngineOilLevelRemarks;
						craneDTO.TransmissionOilLevelRemarks = crane.TransmissionOilLevelRemarks;
						craneDTO.RadiatorWaterLevelRemarks = crane.RadiatorWaterLevelRemarks;
						craneDTO.HydraulicOilLevelRemarks = crane.HydraulicOilLevelRemarks;
						craneDTO.V_beltsTensionRemarks = crane.V_beltsTensionRemarks;
						craneDTO.DrainWaterRemarks = crane.DrainWaterRemarks;
						craneDTO.LeaksRemarks = crane.LeaksRemarks;
						craneDTO.BatteryHolderRemarks = crane.BatteryHolderRemarks;
						craneDTO.LoadComputerRemarks = crane.LoadComputerRemarks;
						craneDTO.GaugesForCcorrectReadingsRemarks = crane.GaugesForCcorrectReadingsRemarks;
						craneDTO.TirePressureRemarks = crane.TirePressureRemarks;
						craneDTO.FuelTanksFullRemarks = crane.FuelTanksFullRemarks;
						craneDTO.WireRopesRemarks = crane.WireRopesRemarks;
						craneDTO.SwingBrakeRemarks = crane.SwingBrakeRemarks;
						craneDTO.TestLimitSwitchesRemarks = crane.TestLimitSwitchesRemarks;
						craneDTO.TestOutriggersRemarks = crane.TestOutriggersRemarks;
						craneDTO.AbnormalNoiseRemarks = crane.AbnormalNoiseRemarks;
						craneDTO.ServiceBrakesRemarks = crane.ServiceBrakesRemarks;
						craneDTO.SheavesRemarks = crane.SheavesRemarks;
						craneDTO.SpoolingOfWireRemarks = crane.SpoolingOfWireRemarks;
						craneDTO.HookconditionRemarks = crane.HookconditionRemarks;
						craneDTO.BoomSectionsRemarks = crane.BoomSectionsRemarks;
						craneDTO.EngineV_beltsRemarks = crane.EngineV_beltsRemarks;
						craneDTO.WiringVisuallyRemarks = crane.WiringVisuallyRemarks;
						craneDTO.LoadIndicatorRemarks = crane.LoadIndicatorRemarks;
						craneDTO.AudibleAlarmRemarks = crane.AudibleAlarmRemarks;
						craneDTO.LoadLimitingRemarks = crane.LoadLimitingRemarks;
						craneDTO.BoomAngleRemarks = crane.BoomAngleRemarks;
						craneDTO.LimitSwitchRemarks = crane.LimitSwitchRemarks;
						craneDTO.EmergencyShutDownRemarks = crane.EmergencyShutDownRemarks;
						craneDTO.OperatingReturnRemarks = crane.OperatingReturnRemarks;
						craneDTO.OperatingControlsRemarks = crane.OperatingControlsRemarks;
						craneDTO.HeadLightRemarks = crane.HeadLightRemarks;
						craneDTO.ReverseAlarmRemarks = crane.ReverseAlarmRemarks;
						craneDTO.ParkingBrakeRemarks = crane.ParkingBrakeRemarks;
						craneDTO.SafetyBeltRemarks = crane.SafetyBeltRemarks;
						craneDTO.DriverSeatRemarks = crane.DriverSeatRemarks;
						craneDTO.WipersRemarks = crane.WipersRemarks;
						craneDTO.ExistingCorrosionRemarks = crane.ExistingCorrosionRemarks;
						craneDTO.TireBoltsRemarks = crane.TireBoltsRemarks;
						craneDTO.SafeLoadIndicatorRemarks = crane.SafeLoadIndicatorRemarks;
						craneDTO.ScreenCurtainsRemarks = crane.ScreenCurtainsRemarks;
						craneDTO.OutriggerRemarks = crane.OutriggerRemarks;
						craneDTO.StrangeSoundRemarks = crane.StrangeSoundRemarks;
						craneDTO.DriverName = crane.DriverName;
						craneDTO.userName = crane.user.UserName;
						craneDTOs.Add(craneDTO);

					}
					result.Message = "Success";
					result.Data = craneDTOs;
					result.Statescode = 200;
					return result;
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<CraneResponseDTO> craneDTOs = new List<CraneResponseDTO>();
					List<Crane> cranes = craneRepository.getall().Where(a => a.Date == date && a.user.Id == UserId && a.Rig.Number == rigNo).ToList();
					foreach (Crane crane in cranes)
					{
						CraneResponseDTO craneDTO = new CraneResponseDTO();
						craneDTO.Id = crane.Id;
						craneDTO.RigNo = crane.Rig.Number;
						craneDTO.Date = crane.Date;
						craneDTO.WellName = crane.WellName;
						craneDTO.UnitNo = crane.UnitNo;
						craneDTO.QHSEEngineer = crane.QHSEEngineer;
						//craneDTO.HrsSinceOilChange = crane.HrsSinceOilChange;
						craneDTO.CleanAndTidy = crane.CleanAndTidy;
						craneDTO.EngineOilLevel = crane.EngineOilLevel;
						craneDTO.TransmissionOilLevel = crane.TransmissionOilLevel;
						craneDTO.RadiatorWaterLevel = crane.RadiatorWaterLevel;
						craneDTO.HydraulicOilLevel = crane.HydraulicOilLevel;
						craneDTO.V_beltsTension = crane.V_beltsTension;
						craneDTO.DrainWater = crane.DrainWater;
						craneDTO.Leaks = crane.Leaks;
						craneDTO.BatteryHolder = crane.BatteryHolder;
						craneDTO.LoadComputer = crane.LoadComputer;
						craneDTO.GaugesForCcorrectReadings = crane.GaugesForCcorrectReadings;
						craneDTO.TirePressure = crane.TirePressure;
						craneDTO.FuelTanksFull = crane.FuelTanksFull;
						craneDTO.WireRopes = crane.WireRopes;
						craneDTO.SwingBrake = crane.SwingBrake;
						craneDTO.TestLimitSwitches = crane.TestLimitSwitches;
						craneDTO.TestOutriggers = crane.TestOutriggers;
						craneDTO.AbnormalNoise = crane.AbnormalNoise;
						craneDTO.ServiceBrakes = crane.ServiceBrakes;
						craneDTO.Sheaves = crane.Sheaves;
						craneDTO.SpoolingOfWire = crane.SpoolingOfWire;
						craneDTO.Hookcondition = crane.Hookcondition;
						craneDTO.BoomSections = crane.BoomSections;
						craneDTO.EngineV_belts = crane.EngineV_belts;
						craneDTO.WiringVisually = crane.WiringVisually;
						craneDTO.LoadIndicator = crane.LoadIndicator;
						craneDTO.AudibleAlarm = crane.AudibleAlarm;
						craneDTO.LoadLimiting = crane.LoadLimiting;
						craneDTO.BoomAngle = crane.BoomAngle;
						craneDTO.LimitSwitch = crane.LimitSwitch;
						craneDTO.EmergencyShutDown = crane.EmergencyShutDown;
						craneDTO.OperatingReturn = crane.OperatingReturn;
						craneDTO.OperatingControls = crane.OperatingControls;
						craneDTO.HeadLight = crane.HeadLight;
						craneDTO.ReverseAlarm = crane.ReverseAlarm;
						craneDTO.ParkingBrake = crane.ParkingBrake;
						craneDTO.SafetyBelt = crane.SafetyBelt;
						craneDTO.DriverSeat = crane.DriverSeat;
						craneDTO.Wipers = crane.Wipers;
						craneDTO.ExistingCorrosion = crane.ExistingCorrosion;
						craneDTO.TireBolts = crane.TireBolts;
						craneDTO.SafeLoadIndicator = crane.SafeLoadIndicator;
						craneDTO.ScreenCurtains = crane.ScreenCurtains;
						craneDTO.Outrigger = crane.Outrigger;
						craneDTO.StrangeSound = crane.StrangeSound;
						craneDTO.CleanAndTidyRemarks = crane.CleanAndTidyRemarks;
						craneDTO.EngineOilLevelRemarks = crane.EngineOilLevelRemarks;
						craneDTO.TransmissionOilLevelRemarks = crane.TransmissionOilLevelRemarks;
						craneDTO.RadiatorWaterLevelRemarks = crane.RadiatorWaterLevelRemarks;
						craneDTO.HydraulicOilLevelRemarks = crane.HydraulicOilLevelRemarks;
						craneDTO.V_beltsTensionRemarks = crane.V_beltsTensionRemarks;
						craneDTO.DrainWaterRemarks = crane.DrainWaterRemarks;
						craneDTO.LeaksRemarks = crane.LeaksRemarks;
						craneDTO.BatteryHolderRemarks = crane.BatteryHolderRemarks;
						craneDTO.LoadComputerRemarks = crane.LoadComputerRemarks;
						craneDTO.GaugesForCcorrectReadingsRemarks = crane.GaugesForCcorrectReadingsRemarks;
						craneDTO.TirePressureRemarks = crane.TirePressureRemarks;
						craneDTO.FuelTanksFullRemarks = crane.FuelTanksFullRemarks;
						craneDTO.WireRopesRemarks = crane.WireRopesRemarks;
						craneDTO.SwingBrakeRemarks = crane.SwingBrakeRemarks;
						craneDTO.TestLimitSwitchesRemarks = crane.TestLimitSwitchesRemarks;
						craneDTO.TestOutriggersRemarks = crane.TestOutriggersRemarks;
						craneDTO.AbnormalNoiseRemarks = crane.AbnormalNoiseRemarks;
						craneDTO.ServiceBrakesRemarks = crane.ServiceBrakesRemarks;
						craneDTO.SheavesRemarks = crane.SheavesRemarks;
						craneDTO.SpoolingOfWireRemarks = crane.SpoolingOfWireRemarks;
						craneDTO.HookconditionRemarks = crane.HookconditionRemarks;
						craneDTO.BoomSectionsRemarks = crane.BoomSectionsRemarks;
						craneDTO.EngineV_beltsRemarks = crane.EngineV_beltsRemarks;
						craneDTO.WiringVisuallyRemarks = crane.WiringVisuallyRemarks;
						craneDTO.LoadIndicatorRemarks = crane.LoadIndicatorRemarks;
						craneDTO.AudibleAlarmRemarks = crane.AudibleAlarmRemarks;
						craneDTO.LoadLimitingRemarks = crane.LoadLimitingRemarks;
						craneDTO.BoomAngleRemarks = crane.BoomAngleRemarks;
						craneDTO.LimitSwitchRemarks = crane.LimitSwitchRemarks;
						craneDTO.EmergencyShutDownRemarks = crane.EmergencyShutDownRemarks;
						craneDTO.OperatingReturnRemarks = crane.OperatingReturnRemarks;
						craneDTO.OperatingControlsRemarks = crane.OperatingControlsRemarks;
						craneDTO.HeadLightRemarks = crane.HeadLightRemarks;
						craneDTO.ReverseAlarmRemarks = crane.ReverseAlarmRemarks;
						craneDTO.ParkingBrakeRemarks = crane.ParkingBrakeRemarks;
						craneDTO.SafetyBeltRemarks = crane.SafetyBeltRemarks;
						craneDTO.DriverSeatRemarks = crane.DriverSeatRemarks;
						craneDTO.WipersRemarks = crane.WipersRemarks;
						craneDTO.ExistingCorrosionRemarks = crane.ExistingCorrosionRemarks;
						craneDTO.TireBoltsRemarks = crane.TireBoltsRemarks;
						craneDTO.SafeLoadIndicatorRemarks = crane.SafeLoadIndicatorRemarks;
						craneDTO.ScreenCurtainsRemarks = crane.ScreenCurtainsRemarks;
						craneDTO.OutriggerRemarks = crane.OutriggerRemarks;
						craneDTO.StrangeSoundRemarks = crane.StrangeSoundRemarks;
						craneDTO.DriverName = crane.DriverName;
						craneDTO.userName = crane.user.UserName;
						craneDTOs.Add(craneDTO);

					}
					result.Message = "Success";
					result.Data = craneDTOs;
					result.Statescode = 200;
					return result;
				}

			}
			catch (Exception ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}

			return result;

		}


		[HttpGet("GetDataByRig/{rigId:int}")]
		public ActionResult<ResultDTO> GetAllWithDataByRig(int rigId, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<CraneResponseDTO> craneDTOs = new List<CraneResponseDTO>();
					List<Crane> cranes = craneRepository.getall().Where(a => a.RigId == rigId).ToList();
					foreach (Crane crane in cranes)
					{
						CraneResponseDTO craneDTO = new CraneResponseDTO();
						craneDTO.Id = crane.Id;
						craneDTO.RigNo = crane.Rig.Number;
						craneDTO.Date = crane.Date;
						craneDTO.WellName = crane.WellName;
						craneDTO.UnitNo = crane.UnitNo;
						craneDTO.QHSEEngineer = crane.QHSEEngineer;
						//craneDTO.HrsSinceOilChange = crane.HrsSinceOilChange;
						craneDTO.CleanAndTidy = crane.CleanAndTidy;
						craneDTO.EngineOilLevel = crane.EngineOilLevel;
						craneDTO.TransmissionOilLevel = crane.TransmissionOilLevel;
						craneDTO.RadiatorWaterLevel = crane.RadiatorWaterLevel;
						craneDTO.HydraulicOilLevel = crane.HydraulicOilLevel;
						craneDTO.V_beltsTension = crane.V_beltsTension;
						craneDTO.DrainWater = crane.DrainWater;
						craneDTO.Leaks = crane.Leaks;
						craneDTO.BatteryHolder = crane.BatteryHolder;
						craneDTO.LoadComputer = crane.LoadComputer;
						craneDTO.GaugesForCcorrectReadings = crane.GaugesForCcorrectReadings;
						craneDTO.TirePressure = crane.TirePressure;
						craneDTO.FuelTanksFull = crane.FuelTanksFull;
						craneDTO.WireRopes = crane.WireRopes;
						craneDTO.SwingBrake = crane.SwingBrake;
						craneDTO.TestLimitSwitches = crane.TestLimitSwitches;
						craneDTO.TestOutriggers = crane.TestOutriggers;
						craneDTO.AbnormalNoise = crane.AbnormalNoise;
						craneDTO.ServiceBrakes = crane.ServiceBrakes;
						craneDTO.Sheaves = crane.Sheaves;
						craneDTO.SpoolingOfWire = crane.SpoolingOfWire;
						craneDTO.Hookcondition = crane.Hookcondition;
						craneDTO.BoomSections = crane.BoomSections;
						craneDTO.EngineV_belts = crane.EngineV_belts;
						craneDTO.WiringVisually = crane.WiringVisually;
						craneDTO.LoadIndicator = crane.LoadIndicator;
						craneDTO.AudibleAlarm = crane.AudibleAlarm;
						craneDTO.LoadLimiting = crane.LoadLimiting;
						craneDTO.BoomAngle = crane.BoomAngle;
						craneDTO.LimitSwitch = crane.LimitSwitch;
						craneDTO.EmergencyShutDown = crane.EmergencyShutDown;
						craneDTO.OperatingReturn = crane.OperatingReturn;
						craneDTO.OperatingControls = crane.OperatingControls;
						craneDTO.HeadLight = crane.HeadLight;
						craneDTO.ReverseAlarm = crane.ReverseAlarm;
						craneDTO.ParkingBrake = crane.ParkingBrake;
						craneDTO.SafetyBelt = crane.SafetyBelt;
						craneDTO.DriverSeat = crane.DriverSeat;
						craneDTO.Wipers = crane.Wipers;
						craneDTO.ExistingCorrosion = crane.ExistingCorrosion;
						craneDTO.TireBolts = crane.TireBolts;
						craneDTO.SafeLoadIndicator = crane.SafeLoadIndicator;
						craneDTO.ScreenCurtains = crane.ScreenCurtains;
						craneDTO.Outrigger = crane.Outrigger;
						craneDTO.StrangeSound = crane.StrangeSound;
						craneDTO.CleanAndTidyRemarks = crane.CleanAndTidyRemarks;
						craneDTO.EngineOilLevelRemarks = crane.EngineOilLevelRemarks;
						craneDTO.TransmissionOilLevelRemarks = crane.TransmissionOilLevelRemarks;
						craneDTO.RadiatorWaterLevelRemarks = crane.RadiatorWaterLevelRemarks;
						craneDTO.HydraulicOilLevelRemarks = crane.HydraulicOilLevelRemarks;
						craneDTO.V_beltsTensionRemarks = crane.V_beltsTensionRemarks;
						craneDTO.DrainWaterRemarks = crane.DrainWaterRemarks;
						craneDTO.LeaksRemarks = crane.LeaksRemarks;
						craneDTO.BatteryHolderRemarks = crane.BatteryHolderRemarks;
						craneDTO.LoadComputerRemarks = crane.LoadComputerRemarks;
						craneDTO.GaugesForCcorrectReadingsRemarks = crane.GaugesForCcorrectReadingsRemarks;
						craneDTO.TirePressureRemarks = crane.TirePressureRemarks;
						craneDTO.FuelTanksFullRemarks = crane.FuelTanksFullRemarks;
						craneDTO.WireRopesRemarks = crane.WireRopesRemarks;
						craneDTO.SwingBrakeRemarks = crane.SwingBrakeRemarks;
						craneDTO.TestLimitSwitchesRemarks = crane.TestLimitSwitchesRemarks;
						craneDTO.TestOutriggersRemarks = crane.TestOutriggersRemarks;
						craneDTO.AbnormalNoiseRemarks = crane.AbnormalNoiseRemarks;
						craneDTO.ServiceBrakesRemarks = crane.ServiceBrakesRemarks;
						craneDTO.SheavesRemarks = crane.SheavesRemarks;
						craneDTO.SpoolingOfWireRemarks = crane.SpoolingOfWireRemarks;
						craneDTO.HookconditionRemarks = crane.HookconditionRemarks;
						craneDTO.BoomSectionsRemarks = crane.BoomSectionsRemarks;
						craneDTO.EngineV_beltsRemarks = crane.EngineV_beltsRemarks;
						craneDTO.WiringVisuallyRemarks = crane.WiringVisuallyRemarks;
						craneDTO.LoadIndicatorRemarks = crane.LoadIndicatorRemarks;
						craneDTO.AudibleAlarmRemarks = crane.AudibleAlarmRemarks;
						craneDTO.LoadLimitingRemarks = crane.LoadLimitingRemarks;
						craneDTO.BoomAngleRemarks = crane.BoomAngleRemarks;
						craneDTO.LimitSwitchRemarks = crane.LimitSwitchRemarks;
						craneDTO.EmergencyShutDownRemarks = crane.EmergencyShutDownRemarks;
						craneDTO.OperatingReturnRemarks = crane.OperatingReturnRemarks;
						craneDTO.OperatingControlsRemarks = crane.OperatingControlsRemarks;
						craneDTO.HeadLightRemarks = crane.HeadLightRemarks;
						craneDTO.ReverseAlarmRemarks = crane.ReverseAlarmRemarks;
						craneDTO.ParkingBrakeRemarks = crane.ParkingBrakeRemarks;
						craneDTO.SafetyBeltRemarks = crane.SafetyBeltRemarks;
						craneDTO.DriverSeatRemarks = crane.DriverSeatRemarks;
						craneDTO.WipersRemarks = crane.WipersRemarks;
						craneDTO.ExistingCorrosionRemarks = crane.ExistingCorrosionRemarks;
						craneDTO.TireBoltsRemarks = crane.TireBoltsRemarks;
						craneDTO.SafeLoadIndicatorRemarks = crane.SafeLoadIndicatorRemarks;
						craneDTO.ScreenCurtainsRemarks = crane.ScreenCurtainsRemarks;
						craneDTO.OutriggerRemarks = crane.OutriggerRemarks;
						craneDTO.StrangeSoundRemarks = crane.StrangeSoundRemarks;
						craneDTO.DriverName = crane.DriverName;
						craneDTO.userName = crane.user.UserName;
						craneDTOs.Add(craneDTO);

					}
					result.Message = "Success";
					result.Data = craneDTOs;
					result.Statescode = 200;
					return result;
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<CraneResponseDTO> craneDTOs = new List<CraneResponseDTO>();
					List<Crane> cranes = craneRepository.getall().Where(a => a.RigId == rigId && a.user.Id == UserId).ToList();
					foreach (Crane crane in cranes)
					{
						CraneResponseDTO craneDTO = new CraneResponseDTO();
						craneDTO.Id = crane.Id;
						craneDTO.RigNo = crane.Rig.Number;
						craneDTO.Date = crane.Date;
						craneDTO.WellName = crane.WellName;
						craneDTO.UnitNo = crane.UnitNo;
						craneDTO.QHSEEngineer = crane.QHSEEngineer;
						//craneDTO.HrsSinceOilChange = crane.HrsSinceOilChange;
						craneDTO.CleanAndTidy = crane.CleanAndTidy;
						craneDTO.EngineOilLevel = crane.EngineOilLevel;
						craneDTO.TransmissionOilLevel = crane.TransmissionOilLevel;
						craneDTO.RadiatorWaterLevel = crane.RadiatorWaterLevel;
						craneDTO.HydraulicOilLevel = crane.HydraulicOilLevel;
						craneDTO.V_beltsTension = crane.V_beltsTension;
						craneDTO.DrainWater = crane.DrainWater;
						craneDTO.Leaks = crane.Leaks;
						craneDTO.BatteryHolder = crane.BatteryHolder;
						craneDTO.LoadComputer = crane.LoadComputer;
						craneDTO.GaugesForCcorrectReadings = crane.GaugesForCcorrectReadings;
						craneDTO.TirePressure = crane.TirePressure;
						craneDTO.FuelTanksFull = crane.FuelTanksFull;
						craneDTO.WireRopes = crane.WireRopes;
						craneDTO.SwingBrake = crane.SwingBrake;
						craneDTO.TestLimitSwitches = crane.TestLimitSwitches;
						craneDTO.TestOutriggers = crane.TestOutriggers;
						craneDTO.AbnormalNoise = crane.AbnormalNoise;
						craneDTO.ServiceBrakes = crane.ServiceBrakes;
						craneDTO.Sheaves = crane.Sheaves;
						craneDTO.SpoolingOfWire = crane.SpoolingOfWire;
						craneDTO.Hookcondition = crane.Hookcondition;
						craneDTO.BoomSections = crane.BoomSections;
						craneDTO.EngineV_belts = crane.EngineV_belts;
						craneDTO.WiringVisually = crane.WiringVisually;
						craneDTO.LoadIndicator = crane.LoadIndicator;
						craneDTO.AudibleAlarm = crane.AudibleAlarm;
						craneDTO.LoadLimiting = crane.LoadLimiting;
						craneDTO.BoomAngle = crane.BoomAngle;
						craneDTO.LimitSwitch = crane.LimitSwitch;
						craneDTO.EmergencyShutDown = crane.EmergencyShutDown;
						craneDTO.OperatingReturn = crane.OperatingReturn;
						craneDTO.OperatingControls = crane.OperatingControls;
						craneDTO.HeadLight = crane.HeadLight;
						craneDTO.ReverseAlarm = crane.ReverseAlarm;
						craneDTO.ParkingBrake = crane.ParkingBrake;
						craneDTO.SafetyBelt = crane.SafetyBelt;
						craneDTO.DriverSeat = crane.DriverSeat;
						craneDTO.Wipers = crane.Wipers;
						craneDTO.ExistingCorrosion = crane.ExistingCorrosion;
						craneDTO.TireBolts = crane.TireBolts;
						craneDTO.SafeLoadIndicator = crane.SafeLoadIndicator;
						craneDTO.ScreenCurtains = crane.ScreenCurtains;
						craneDTO.Outrigger = crane.Outrigger;
						craneDTO.StrangeSound = crane.StrangeSound;
						craneDTO.CleanAndTidyRemarks = crane.CleanAndTidyRemarks;
						craneDTO.EngineOilLevelRemarks = crane.EngineOilLevelRemarks;
						craneDTO.TransmissionOilLevelRemarks = crane.TransmissionOilLevelRemarks;
						craneDTO.RadiatorWaterLevelRemarks = crane.RadiatorWaterLevelRemarks;
						craneDTO.HydraulicOilLevelRemarks = crane.HydraulicOilLevelRemarks;
						craneDTO.V_beltsTensionRemarks = crane.V_beltsTensionRemarks;
						craneDTO.DrainWaterRemarks = crane.DrainWaterRemarks;
						craneDTO.LeaksRemarks = crane.LeaksRemarks;
						craneDTO.BatteryHolderRemarks = crane.BatteryHolderRemarks;
						craneDTO.LoadComputerRemarks = crane.LoadComputerRemarks;
						craneDTO.GaugesForCcorrectReadingsRemarks = crane.GaugesForCcorrectReadingsRemarks;
						craneDTO.TirePressureRemarks = crane.TirePressureRemarks;
						craneDTO.FuelTanksFullRemarks = crane.FuelTanksFullRemarks;
						craneDTO.WireRopesRemarks = crane.WireRopesRemarks;
						craneDTO.SwingBrakeRemarks = crane.SwingBrakeRemarks;
						craneDTO.TestLimitSwitchesRemarks = crane.TestLimitSwitchesRemarks;
						craneDTO.TestOutriggersRemarks = crane.TestOutriggersRemarks;
						craneDTO.AbnormalNoiseRemarks = crane.AbnormalNoiseRemarks;
						craneDTO.ServiceBrakesRemarks = crane.ServiceBrakesRemarks;
						craneDTO.SheavesRemarks = crane.SheavesRemarks;
						craneDTO.SpoolingOfWireRemarks = crane.SpoolingOfWireRemarks;
						craneDTO.HookconditionRemarks = crane.HookconditionRemarks;
						craneDTO.BoomSectionsRemarks = crane.BoomSectionsRemarks;
						craneDTO.EngineV_beltsRemarks = crane.EngineV_beltsRemarks;
						craneDTO.WiringVisuallyRemarks = crane.WiringVisuallyRemarks;
						craneDTO.LoadIndicatorRemarks = crane.LoadIndicatorRemarks;
						craneDTO.AudibleAlarmRemarks = crane.AudibleAlarmRemarks;
						craneDTO.LoadLimitingRemarks = crane.LoadLimitingRemarks;
						craneDTO.BoomAngleRemarks = crane.BoomAngleRemarks;
						craneDTO.LimitSwitchRemarks = crane.LimitSwitchRemarks;
						craneDTO.EmergencyShutDownRemarks = crane.EmergencyShutDownRemarks;
						craneDTO.OperatingReturnRemarks = crane.OperatingReturnRemarks;
						craneDTO.OperatingControlsRemarks = crane.OperatingControlsRemarks;
						craneDTO.HeadLightRemarks = crane.HeadLightRemarks;
						craneDTO.ReverseAlarmRemarks = crane.ReverseAlarmRemarks;
						craneDTO.ParkingBrakeRemarks = crane.ParkingBrakeRemarks;
						craneDTO.SafetyBeltRemarks = crane.SafetyBeltRemarks;
						craneDTO.DriverSeatRemarks = crane.DriverSeatRemarks;
						craneDTO.WipersRemarks = crane.WipersRemarks;
						craneDTO.ExistingCorrosionRemarks = crane.ExistingCorrosionRemarks;
						craneDTO.TireBoltsRemarks = crane.TireBoltsRemarks;
						craneDTO.SafeLoadIndicatorRemarks = crane.SafeLoadIndicatorRemarks;
						craneDTO.ScreenCurtainsRemarks = crane.ScreenCurtainsRemarks;
						craneDTO.OutriggerRemarks = crane.OutriggerRemarks;
						craneDTO.StrangeSoundRemarks = crane.StrangeSoundRemarks;
						craneDTO.DriverName = crane.DriverName;
						craneDTO.userName = crane.user.UserName;
						craneDTOs.Add(craneDTO);

					}
					result.Message = "Success";
					result.Data = craneDTOs;
					result.Statescode = 200;
					return result;
				}

			}
			catch (Exception ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}

			return result;

		}

		[HttpGet("{ID:int}")]
		public ActionResult<ResultDTO> GetByID(int ID, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					Crane crane = craneRepo.getall().FirstOrDefault(a => a.Id == ID);
					CraneDTO craneDTO = new CraneDTO();
					craneDTO.Id = crane.Id;
					craneDTO.RigId = crane.RigId;
					craneDTO.Date = crane.Date;
					craneDTO.WellName = crane.WellName;
					craneDTO.UnitNo = crane.UnitNo;
					craneDTO.QHSEEngineer = crane.QHSEEngineer;
					//craneDTO.HrsSinceOilChange = crane.HrsSinceOilChange;
					craneDTO.CleanAndTidy = crane.CleanAndTidy;
					craneDTO.EngineOilLevel = crane.EngineOilLevel;
					craneDTO.TransmissionOilLevel = crane.TransmissionOilLevel;
					craneDTO.RadiatorWaterLevel = crane.RadiatorWaterLevel;
					craneDTO.HydraulicOilLevel = crane.HydraulicOilLevel;
					craneDTO.V_beltsTension = crane.V_beltsTension;
					craneDTO.DrainWater = crane.DrainWater;
					craneDTO.Leaks = crane.Leaks;
					craneDTO.BatteryHolder = crane.BatteryHolder;
					craneDTO.LoadComputer = crane.LoadComputer;
					craneDTO.GaugesForCcorrectReadings = crane.GaugesForCcorrectReadings;
					craneDTO.TirePressure = crane.TirePressure;
					craneDTO.FuelTanksFull = crane.FuelTanksFull;
					craneDTO.WireRopes = crane.WireRopes;
					craneDTO.SwingBrake = crane.SwingBrake;
					craneDTO.TestLimitSwitches = crane.TestLimitSwitches;
					craneDTO.TestOutriggers = crane.TestOutriggers;
					craneDTO.AbnormalNoise = crane.AbnormalNoise;
					craneDTO.ServiceBrakes = crane.ServiceBrakes;
					craneDTO.Sheaves = crane.Sheaves;
					craneDTO.SpoolingOfWire = crane.SpoolingOfWire;
					craneDTO.Hookcondition = crane.Hookcondition;
					craneDTO.BoomSections = crane.BoomSections;
					craneDTO.EngineV_belts = crane.EngineV_belts;
					craneDTO.WiringVisually = crane.WiringVisually;
					craneDTO.LoadIndicator = crane.LoadIndicator;
					craneDTO.AudibleAlarm = crane.AudibleAlarm;
					craneDTO.LoadLimiting = crane.LoadLimiting;
					craneDTO.BoomAngle = crane.BoomAngle;
					craneDTO.LimitSwitch = crane.LimitSwitch;
					craneDTO.EmergencyShutDown = crane.EmergencyShutDown;
					craneDTO.OperatingReturn = crane.OperatingReturn;
					craneDTO.OperatingControls = crane.OperatingControls;
					craneDTO.HeadLight = crane.HeadLight;
					craneDTO.ReverseAlarm = crane.ReverseAlarm;
					craneDTO.ParkingBrake = crane.ParkingBrake;
					craneDTO.SafetyBelt = crane.SafetyBelt;
					craneDTO.DriverSeat = crane.DriverSeat;
					craneDTO.Wipers = crane.Wipers;
					craneDTO.ExistingCorrosion = crane.ExistingCorrosion;
					craneDTO.TireBolts = crane.TireBolts;
					craneDTO.SafeLoadIndicator = crane.SafeLoadIndicator;
					craneDTO.ScreenCurtains = crane.ScreenCurtains;
					craneDTO.Outrigger = crane.Outrigger;
					craneDTO.StrangeSound = crane.StrangeSound;
					craneDTO.CleanAndTidyRemarks = crane.CleanAndTidyRemarks;
					craneDTO.EngineOilLevelRemarks = crane.EngineOilLevelRemarks;
					craneDTO.TransmissionOilLevelRemarks = crane.TransmissionOilLevelRemarks;
					craneDTO.RadiatorWaterLevelRemarks = crane.RadiatorWaterLevelRemarks;
					craneDTO.HydraulicOilLevelRemarks = crane.HydraulicOilLevelRemarks;
					craneDTO.V_beltsTensionRemarks = crane.V_beltsTensionRemarks;
					craneDTO.DrainWaterRemarks = crane.DrainWaterRemarks;
					craneDTO.LeaksRemarks = crane.LeaksRemarks;
					craneDTO.BatteryHolderRemarks = crane.BatteryHolderRemarks;
					craneDTO.LoadComputerRemarks = crane.LoadComputerRemarks;
					craneDTO.GaugesForCcorrectReadingsRemarks = crane.GaugesForCcorrectReadingsRemarks;
					craneDTO.TirePressureRemarks = crane.TirePressureRemarks;
					craneDTO.FuelTanksFullRemarks = crane.FuelTanksFullRemarks;
					craneDTO.WireRopesRemarks = crane.WireRopesRemarks;
					craneDTO.SwingBrakeRemarks = crane.SwingBrakeRemarks;
					craneDTO.TestLimitSwitchesRemarks = crane.TestLimitSwitchesRemarks;
					craneDTO.TestOutriggersRemarks = crane.TestOutriggersRemarks;
					craneDTO.AbnormalNoiseRemarks = crane.AbnormalNoiseRemarks;
					craneDTO.ServiceBrakesRemarks = crane.ServiceBrakesRemarks;
					craneDTO.SheavesRemarks = crane.SheavesRemarks;
					craneDTO.SpoolingOfWireRemarks = crane.SpoolingOfWireRemarks;
					craneDTO.HookconditionRemarks = crane.HookconditionRemarks;
					craneDTO.BoomSectionsRemarks = crane.BoomSectionsRemarks;
					craneDTO.EngineV_beltsRemarks = crane.EngineV_beltsRemarks;
					craneDTO.WiringVisuallyRemarks = crane.WiringVisuallyRemarks;
					craneDTO.LoadIndicatorRemarks = crane.LoadIndicatorRemarks;
					craneDTO.AudibleAlarmRemarks = crane.AudibleAlarmRemarks;
					craneDTO.LoadLimitingRemarks = crane.LoadLimitingRemarks;
					craneDTO.BoomAngleRemarks = crane.BoomAngleRemarks;
					craneDTO.LimitSwitchRemarks = crane.LimitSwitchRemarks;
					craneDTO.EmergencyShutDownRemarks = crane.EmergencyShutDownRemarks;
					craneDTO.OperatingReturnRemarks = crane.OperatingReturnRemarks;
					craneDTO.OperatingControlsRemarks = crane.OperatingControlsRemarks;
					craneDTO.HeadLightRemarks = crane.HeadLightRemarks;
					craneDTO.ReverseAlarmRemarks = crane.ReverseAlarmRemarks;
					craneDTO.ParkingBrakeRemarks = crane.ParkingBrakeRemarks;
					craneDTO.SafetyBeltRemarks = crane.SafetyBeltRemarks;
					craneDTO.DriverSeatRemarks = crane.DriverSeatRemarks;
					craneDTO.WipersRemarks = crane.WipersRemarks;
					craneDTO.ExistingCorrosionRemarks = crane.ExistingCorrosionRemarks;
					craneDTO.TireBoltsRemarks = crane.TireBoltsRemarks;
					craneDTO.SafeLoadIndicatorRemarks = crane.SafeLoadIndicatorRemarks;
					craneDTO.ScreenCurtainsRemarks = crane.ScreenCurtainsRemarks;
					craneDTO.OutriggerRemarks = crane.OutriggerRemarks;
					craneDTO.StrangeSoundRemarks = crane.StrangeSoundRemarks;
					craneDTO.DriverName = crane.DriverName;
					craneDTO.userID = crane.userID;

					result.Message = "Success";
					result.Data = craneDTO;
					result.Statescode = 200;
					return result;

				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					Crane crane = craneRepo.getall().FirstOrDefault(a => a.Id == ID && a.userID == UserId);
					CraneDTO craneDTO = new CraneDTO();
					craneDTO.Id = crane.Id;
					craneDTO.RigId = crane.RigId;
					craneDTO.Date = crane.Date;
					craneDTO.WellName = crane.WellName;
					craneDTO.UnitNo = crane.UnitNo;
					craneDTO.QHSEEngineer = crane.QHSEEngineer;
					//craneDTO.HrsSinceOilChange = crane.HrsSinceOilChange;
					craneDTO.CleanAndTidy = crane.CleanAndTidy;
					craneDTO.EngineOilLevel = crane.EngineOilLevel;
					craneDTO.TransmissionOilLevel = crane.TransmissionOilLevel;
					craneDTO.RadiatorWaterLevel = crane.RadiatorWaterLevel;
					craneDTO.HydraulicOilLevel = crane.HydraulicOilLevel;
					craneDTO.V_beltsTension = crane.V_beltsTension;
					craneDTO.DrainWater = crane.DrainWater;
					craneDTO.Leaks = crane.Leaks;
					craneDTO.BatteryHolder = crane.BatteryHolder;
					craneDTO.LoadComputer = crane.LoadComputer;
					craneDTO.GaugesForCcorrectReadings = crane.GaugesForCcorrectReadings;
					craneDTO.TirePressure = crane.TirePressure;
					craneDTO.FuelTanksFull = crane.FuelTanksFull;
					craneDTO.WireRopes = crane.WireRopes;
					craneDTO.SwingBrake = crane.SwingBrake;
					craneDTO.TestLimitSwitches = crane.TestLimitSwitches;
					craneDTO.TestOutriggers = crane.TestOutriggers;
					craneDTO.AbnormalNoise = crane.AbnormalNoise;
					craneDTO.ServiceBrakes = crane.ServiceBrakes;
					craneDTO.Sheaves = crane.Sheaves;
					craneDTO.SpoolingOfWire = crane.SpoolingOfWire;
					craneDTO.Hookcondition = crane.Hookcondition;
					craneDTO.BoomSections = crane.BoomSections;
					craneDTO.EngineV_belts = crane.EngineV_belts;
					craneDTO.WiringVisually = crane.WiringVisually;
					craneDTO.LoadIndicator = crane.LoadIndicator;
					craneDTO.AudibleAlarm = crane.AudibleAlarm;
					craneDTO.LoadLimiting = crane.LoadLimiting;
					craneDTO.BoomAngle = crane.BoomAngle;
					craneDTO.LimitSwitch = crane.LimitSwitch;
					craneDTO.EmergencyShutDown = crane.EmergencyShutDown;
					craneDTO.OperatingReturn = crane.OperatingReturn;
					craneDTO.OperatingControls = crane.OperatingControls;
					craneDTO.HeadLight = crane.HeadLight;
					craneDTO.ReverseAlarm = crane.ReverseAlarm;
					craneDTO.ParkingBrake = crane.ParkingBrake;
					craneDTO.SafetyBelt = crane.SafetyBelt;
					craneDTO.DriverSeat = crane.DriverSeat;
					craneDTO.Wipers = crane.Wipers;
					craneDTO.ExistingCorrosion = crane.ExistingCorrosion;
					craneDTO.TireBolts = crane.TireBolts;
					craneDTO.SafeLoadIndicator = crane.SafeLoadIndicator;
					craneDTO.ScreenCurtains = crane.ScreenCurtains;
					craneDTO.Outrigger = crane.Outrigger;
					craneDTO.StrangeSound = crane.StrangeSound;
					craneDTO.CleanAndTidyRemarks = crane.CleanAndTidyRemarks;
					craneDTO.EngineOilLevelRemarks = crane.EngineOilLevelRemarks;
					craneDTO.TransmissionOilLevelRemarks = crane.TransmissionOilLevelRemarks;
					craneDTO.RadiatorWaterLevelRemarks = crane.RadiatorWaterLevelRemarks;
					craneDTO.HydraulicOilLevelRemarks = crane.HydraulicOilLevelRemarks;
					craneDTO.V_beltsTensionRemarks = crane.V_beltsTensionRemarks;
					craneDTO.DrainWaterRemarks = crane.DrainWaterRemarks;
					craneDTO.LeaksRemarks = crane.LeaksRemarks;
					craneDTO.BatteryHolderRemarks = crane.BatteryHolderRemarks;
					craneDTO.LoadComputerRemarks = crane.LoadComputerRemarks;
					craneDTO.GaugesForCcorrectReadingsRemarks = crane.GaugesForCcorrectReadingsRemarks;
					craneDTO.TirePressureRemarks = crane.TirePressureRemarks;
					craneDTO.FuelTanksFullRemarks = crane.FuelTanksFullRemarks;
					craneDTO.WireRopesRemarks = crane.WireRopesRemarks;
					craneDTO.SwingBrakeRemarks = crane.SwingBrakeRemarks;
					craneDTO.TestLimitSwitchesRemarks = crane.TestLimitSwitchesRemarks;
					craneDTO.TestOutriggersRemarks = crane.TestOutriggersRemarks;
					craneDTO.AbnormalNoiseRemarks = crane.AbnormalNoiseRemarks;
					craneDTO.ServiceBrakesRemarks = crane.ServiceBrakesRemarks;
					craneDTO.SheavesRemarks = crane.SheavesRemarks;
					craneDTO.SpoolingOfWireRemarks = crane.SpoolingOfWireRemarks;
					craneDTO.HookconditionRemarks = crane.HookconditionRemarks;
					craneDTO.BoomSectionsRemarks = crane.BoomSectionsRemarks;
					craneDTO.EngineV_beltsRemarks = crane.EngineV_beltsRemarks;
					craneDTO.WiringVisuallyRemarks = crane.WiringVisuallyRemarks;
					craneDTO.LoadIndicatorRemarks = crane.LoadIndicatorRemarks;
					craneDTO.AudibleAlarmRemarks = crane.AudibleAlarmRemarks;
					craneDTO.LoadLimitingRemarks = crane.LoadLimitingRemarks;
					craneDTO.BoomAngleRemarks = crane.BoomAngleRemarks;
					craneDTO.LimitSwitchRemarks = crane.LimitSwitchRemarks;
					craneDTO.EmergencyShutDownRemarks = crane.EmergencyShutDownRemarks;
					craneDTO.OperatingReturnRemarks = crane.OperatingReturnRemarks;
					craneDTO.OperatingControlsRemarks = crane.OperatingControlsRemarks;
					craneDTO.HeadLightRemarks = crane.HeadLightRemarks;
					craneDTO.ReverseAlarmRemarks = crane.ReverseAlarmRemarks;
					craneDTO.ParkingBrakeRemarks = crane.ParkingBrakeRemarks;
					craneDTO.SafetyBeltRemarks = crane.SafetyBeltRemarks;
					craneDTO.DriverSeatRemarks = crane.DriverSeatRemarks;
					craneDTO.WipersRemarks = crane.WipersRemarks;
					craneDTO.ExistingCorrosionRemarks = crane.ExistingCorrosionRemarks;
					craneDTO.TireBoltsRemarks = crane.TireBoltsRemarks;
					craneDTO.SafeLoadIndicatorRemarks = crane.SafeLoadIndicatorRemarks;
					craneDTO.ScreenCurtainsRemarks = crane.ScreenCurtainsRemarks;
					craneDTO.OutriggerRemarks = crane.OutriggerRemarks;
					craneDTO.StrangeSoundRemarks = crane.StrangeSoundRemarks;
					craneDTO.DriverName = crane.DriverName;
					craneDTO.userID = crane.userID;

					result.Message = "Success";
					result.Data = craneDTO;
					result.Statescode = 200;
					return result;
				}
			}
			catch (Exception Ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}

			return result;
		}

		[HttpPost]
		public ActionResult<ResultDTO> AddCrane(CraneDTO craneDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					Crane crane = new Crane();
					crane.Id = craneDTO.Id;
					crane.RigId = craneDTO.RigId;
					crane.Date = craneDTO.Date;
					crane.WellName = craneDTO.WellName;
					crane.UnitNo = craneDTO.UnitNo;
					crane.QHSEEngineer = craneDTO.QHSEEngineer;
					//crane.HrsSinceOilChange = craneDTO.HrsSinceOilChange;
					crane.CleanAndTidy = craneDTO.CleanAndTidy;
					crane.EngineOilLevel = craneDTO.EngineOilLevel;
					crane.TransmissionOilLevel = craneDTO.TransmissionOilLevel;
					crane.RadiatorWaterLevel = craneDTO.RadiatorWaterLevel;
					crane.HydraulicOilLevel = craneDTO.HydraulicOilLevel;
					crane.V_beltsTension = craneDTO.V_beltsTension;
					crane.DrainWater = craneDTO.DrainWater;
					crane.Leaks = craneDTO.Leaks;
					crane.BatteryHolder = craneDTO.BatteryHolder;
					crane.LoadComputer = craneDTO.LoadComputer;
					crane.GaugesForCcorrectReadings = craneDTO.GaugesForCcorrectReadings;
					crane.TirePressure = craneDTO.TirePressure;
					crane.FuelTanksFull = craneDTO.FuelTanksFull;
					crane.WireRopes = craneDTO.WireRopes;
					crane.SwingBrake = craneDTO.SwingBrake;
					crane.TestLimitSwitches = craneDTO.TestLimitSwitches;
					crane.TestOutriggers = craneDTO.TestOutriggers;
					crane.AbnormalNoise = craneDTO.AbnormalNoise;
					crane.ServiceBrakes = craneDTO.ServiceBrakes;
					crane.Sheaves = craneDTO.Sheaves;
					crane.SpoolingOfWire = craneDTO.SpoolingOfWire;
					crane.Hookcondition = craneDTO.Hookcondition;
					crane.BoomSections = craneDTO.BoomSections;
					crane.EngineV_belts = craneDTO.EngineV_belts;
					crane.WiringVisually = craneDTO.WiringVisually;
					crane.LoadIndicator = craneDTO.LoadIndicator;
					crane.AudibleAlarm = craneDTO.AudibleAlarm;
					crane.LoadLimiting = craneDTO.LoadLimiting;
					crane.BoomAngle = craneDTO.BoomAngle;
					crane.LimitSwitch = craneDTO.LimitSwitch;
					crane.EmergencyShutDown = craneDTO.EmergencyShutDown;
					crane.OperatingReturn = craneDTO.OperatingReturn;
					crane.OperatingControls = craneDTO.OperatingControls;
					crane.HeadLight = craneDTO.HeadLight;
					crane.ReverseAlarm = craneDTO.ReverseAlarm;
					crane.ParkingBrake = craneDTO.ParkingBrake;
					crane.SafetyBelt = craneDTO.SafetyBelt;
					crane.DriverSeat = craneDTO.DriverSeat;
					crane.Wipers = craneDTO.Wipers;
					crane.ExistingCorrosion = craneDTO.ExistingCorrosion;
					crane.TireBolts = craneDTO.TireBolts;
					crane.SafeLoadIndicator = craneDTO.SafeLoadIndicator;
					crane.ScreenCurtains = craneDTO.ScreenCurtains;
					crane.Outrigger = craneDTO.Outrigger;
					crane.StrangeSound = craneDTO.StrangeSound;
					crane.CleanAndTidyRemarks = craneDTO.CleanAndTidyRemarks;
					crane.EngineOilLevelRemarks = craneDTO.EngineOilLevelRemarks;
					crane.TransmissionOilLevelRemarks = craneDTO.TransmissionOilLevelRemarks;
					crane.RadiatorWaterLevelRemarks = craneDTO.RadiatorWaterLevelRemarks;
					crane.HydraulicOilLevelRemarks = craneDTO.HydraulicOilLevelRemarks;
					crane.V_beltsTensionRemarks = craneDTO.V_beltsTensionRemarks;
					crane.DrainWaterRemarks = craneDTO.DrainWaterRemarks;
					crane.LeaksRemarks = craneDTO.LeaksRemarks;
					crane.BatteryHolderRemarks = craneDTO.BatteryHolderRemarks;
					crane.LoadComputerRemarks = craneDTO.LoadComputerRemarks;
					crane.GaugesForCcorrectReadingsRemarks = craneDTO.GaugesForCcorrectReadingsRemarks;
					crane.TirePressureRemarks = craneDTO.TirePressureRemarks;
					crane.FuelTanksFullRemarks = craneDTO.FuelTanksFullRemarks;
					crane.WireRopesRemarks = craneDTO.WireRopesRemarks;
					crane.SwingBrakeRemarks = craneDTO.SwingBrakeRemarks;
					crane.TestLimitSwitchesRemarks = craneDTO.TestLimitSwitchesRemarks;
					crane.TestOutriggersRemarks = craneDTO.TestOutriggersRemarks;
					crane.AbnormalNoiseRemarks = craneDTO.AbnormalNoiseRemarks;
					crane.ServiceBrakesRemarks = craneDTO.ServiceBrakesRemarks;
					crane.SheavesRemarks = craneDTO.SheavesRemarks;
					crane.SpoolingOfWireRemarks = craneDTO.SpoolingOfWireRemarks;
					crane.HookconditionRemarks = craneDTO.HookconditionRemarks;
					crane.BoomSectionsRemarks = craneDTO.BoomSectionsRemarks;
					crane.EngineV_beltsRemarks = craneDTO.EngineV_beltsRemarks;
					crane.WiringVisuallyRemarks = craneDTO.WiringVisuallyRemarks;
					crane.LoadIndicatorRemarks = craneDTO.LoadIndicatorRemarks;
					crane.AudibleAlarmRemarks = craneDTO.AudibleAlarmRemarks;
					crane.LoadLimitingRemarks = craneDTO.LoadLimitingRemarks;
					crane.BoomAngleRemarks = craneDTO.BoomAngleRemarks;
					crane.LimitSwitchRemarks = craneDTO.LimitSwitchRemarks;
					crane.EmergencyShutDownRemarks = craneDTO.EmergencyShutDownRemarks;
					crane.OperatingReturnRemarks = craneDTO.OperatingReturnRemarks;
					crane.OperatingControlsRemarks = craneDTO.OperatingControlsRemarks;
					crane.HeadLightRemarks = craneDTO.HeadLightRemarks;
					crane.ReverseAlarmRemarks = craneDTO.ReverseAlarmRemarks;
					crane.ParkingBrakeRemarks = craneDTO.ParkingBrakeRemarks;
					crane.SafetyBeltRemarks = craneDTO.SafetyBeltRemarks;
					crane.DriverSeatRemarks = craneDTO.DriverSeatRemarks;
					crane.WipersRemarks = craneDTO.WipersRemarks;
					crane.ExistingCorrosionRemarks = craneDTO.ExistingCorrosionRemarks;
					crane.TireBoltsRemarks = craneDTO.TireBoltsRemarks;
					crane.SafeLoadIndicatorRemarks = craneDTO.SafeLoadIndicatorRemarks;
					crane.ScreenCurtainsRemarks = craneDTO.ScreenCurtainsRemarks;
					crane.OutriggerRemarks = craneDTO.OutriggerRemarks;
					crane.StrangeSoundRemarks = craneDTO.StrangeSoundRemarks;
					crane.DriverName = craneDTO.DriverName;
					crane.userID = craneDTO.userID;
					craneRepo.create(crane);
					
					result.Message = "Success";
					result.Data = crane;
					result.Statescode = 200;
				}
				catch (Exception ex)
				{
					result.Message = "Error in inserting";
					result.Statescode = 400;
				}
			}
			return result;
		}

		[HttpPut("{id:int}")]
		public ActionResult<ResultDTO> Put(int id, CraneDTO newCrane) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					Crane orgCrane = craneRepo.getbyid(id);
					newCrane.Id = orgCrane.Id;
					orgCrane.RigId = newCrane.RigId;
					orgCrane.Date = newCrane.Date;
					orgCrane.WellName = newCrane.WellName;
					orgCrane.UnitNo = newCrane.UnitNo;
					orgCrane.QHSEEngineer = newCrane.QHSEEngineer;
					//orgCrane.HrsSinceOilChange = newCrane.HrsSinceOilChange;
					orgCrane.CleanAndTidy = newCrane.CleanAndTidy;
					orgCrane.EngineOilLevel = newCrane.EngineOilLevel;
					orgCrane.TransmissionOilLevel = newCrane.TransmissionOilLevel;
					orgCrane.RadiatorWaterLevel = newCrane.RadiatorWaterLevel;
					orgCrane.HydraulicOilLevel = newCrane.HydraulicOilLevel;
					orgCrane.V_beltsTension = newCrane.V_beltsTension;
					orgCrane.DrainWater = newCrane.DrainWater;
					orgCrane.Leaks = newCrane.Leaks;
					orgCrane.BatteryHolder = newCrane.BatteryHolder;
					orgCrane.LoadComputer = newCrane.LoadComputer;
					orgCrane.GaugesForCcorrectReadings = newCrane.GaugesForCcorrectReadings;
					orgCrane.TirePressure = newCrane.TirePressure;
					orgCrane.FuelTanksFull = newCrane.FuelTanksFull;
					orgCrane.WireRopes = newCrane.WireRopes;
					orgCrane.SwingBrake = newCrane.SwingBrake;
					orgCrane.TestLimitSwitches = newCrane.TestLimitSwitches;
					orgCrane.TestOutriggers = newCrane.TestOutriggers;
					orgCrane.AbnormalNoise = newCrane.AbnormalNoise;
					orgCrane.ServiceBrakes = newCrane.ServiceBrakes;
					orgCrane.Sheaves = newCrane.Sheaves;
					orgCrane.SpoolingOfWire = newCrane.SpoolingOfWire;
					orgCrane.Hookcondition = newCrane.Hookcondition;
					orgCrane.BoomSections = newCrane.BoomSections;
					orgCrane.EngineV_belts = newCrane.EngineV_belts;
					orgCrane.WiringVisually = newCrane.WiringVisually;
					orgCrane.LoadIndicator = newCrane.LoadIndicator;
					orgCrane.AudibleAlarm = newCrane.AudibleAlarm;
					orgCrane.LoadLimiting = newCrane.LoadLimiting;
					orgCrane.BoomAngle = newCrane.BoomAngle;
					orgCrane.LimitSwitch = newCrane.LimitSwitch;
					orgCrane.EmergencyShutDown = newCrane.EmergencyShutDown;
					orgCrane.OperatingReturn = newCrane.OperatingReturn;
					orgCrane.OperatingControls = newCrane.OperatingControls;
					orgCrane.HeadLight = newCrane.HeadLight;
					orgCrane.ReverseAlarm = newCrane.ReverseAlarm;
					orgCrane.ParkingBrake = newCrane.ParkingBrake;
					orgCrane.SafetyBelt = newCrane.SafetyBelt;
					orgCrane.DriverSeat = newCrane.DriverSeat;
					orgCrane.Wipers = newCrane.Wipers;
					orgCrane.ExistingCorrosion = newCrane.ExistingCorrosion;
					orgCrane.TireBolts = newCrane.TireBolts;
					orgCrane.SafeLoadIndicator = newCrane.SafeLoadIndicator;
					orgCrane.ScreenCurtains = newCrane.ScreenCurtains;
					orgCrane.Outrigger = newCrane.Outrigger;
					orgCrane.StrangeSound = newCrane.StrangeSound;
					orgCrane.CleanAndTidyRemarks = newCrane.CleanAndTidyRemarks;
					orgCrane.EngineOilLevelRemarks = newCrane.EngineOilLevelRemarks;
					orgCrane.TransmissionOilLevelRemarks = newCrane.TransmissionOilLevelRemarks;
					orgCrane.RadiatorWaterLevelRemarks = newCrane.RadiatorWaterLevelRemarks;
					orgCrane.HydraulicOilLevelRemarks = newCrane.HydraulicOilLevelRemarks;
					orgCrane.V_beltsTensionRemarks = newCrane.V_beltsTensionRemarks;
					orgCrane.DrainWaterRemarks = newCrane.DrainWaterRemarks;
					orgCrane.LeaksRemarks = newCrane.LeaksRemarks;
					orgCrane.BatteryHolderRemarks = newCrane.BatteryHolderRemarks;
					orgCrane.LoadComputerRemarks = newCrane.LoadComputerRemarks;
					orgCrane.GaugesForCcorrectReadingsRemarks = newCrane.GaugesForCcorrectReadingsRemarks;
					orgCrane.TirePressureRemarks = newCrane.TirePressureRemarks;
					orgCrane.FuelTanksFullRemarks = newCrane.FuelTanksFullRemarks;
					orgCrane.WireRopesRemarks = newCrane.WireRopesRemarks;
					orgCrane.SwingBrakeRemarks = newCrane.SwingBrakeRemarks;
					orgCrane.TestLimitSwitchesRemarks = newCrane.TestLimitSwitchesRemarks;
					orgCrane.TestOutriggersRemarks = newCrane.TestOutriggersRemarks;
					orgCrane.AbnormalNoiseRemarks = newCrane.AbnormalNoiseRemarks;
					orgCrane.ServiceBrakesRemarks = newCrane.ServiceBrakesRemarks;
					orgCrane.SheavesRemarks = newCrane.SheavesRemarks;
					orgCrane.SpoolingOfWireRemarks = newCrane.SpoolingOfWireRemarks;
					orgCrane.HookconditionRemarks = newCrane.HookconditionRemarks;
					orgCrane.BoomSectionsRemarks = newCrane.BoomSectionsRemarks;
					orgCrane.EngineV_beltsRemarks = newCrane.EngineV_beltsRemarks;
					orgCrane.WiringVisuallyRemarks = newCrane.WiringVisuallyRemarks;
					orgCrane.LoadIndicatorRemarks = newCrane.LoadIndicatorRemarks;
					orgCrane.AudibleAlarmRemarks = newCrane.AudibleAlarmRemarks;
					orgCrane.LoadLimitingRemarks = newCrane.LoadLimitingRemarks;
					orgCrane.BoomAngleRemarks = newCrane.BoomAngleRemarks;
					orgCrane.LimitSwitchRemarks = newCrane.LimitSwitchRemarks;
					orgCrane.EmergencyShutDownRemarks = newCrane.EmergencyShutDownRemarks;
					orgCrane.OperatingReturnRemarks = newCrane.OperatingReturnRemarks;
					orgCrane.OperatingControlsRemarks = newCrane.OperatingControlsRemarks;
					orgCrane.HeadLightRemarks = newCrane.HeadLightRemarks;
					orgCrane.ReverseAlarmRemarks = newCrane.ReverseAlarmRemarks;
					orgCrane.ParkingBrakeRemarks = newCrane.ParkingBrakeRemarks;
					orgCrane.SafetyBeltRemarks = newCrane.SafetyBeltRemarks;
					orgCrane.DriverSeatRemarks = newCrane.DriverSeatRemarks;
					orgCrane.WipersRemarks = newCrane.WipersRemarks;
					orgCrane.ExistingCorrosionRemarks = newCrane.ExistingCorrosionRemarks;
					orgCrane.TireBoltsRemarks = newCrane.TireBoltsRemarks;
					orgCrane.SafeLoadIndicatorRemarks = newCrane.SafeLoadIndicatorRemarks;
					orgCrane.ScreenCurtainsRemarks = newCrane.ScreenCurtainsRemarks;
					orgCrane.OutriggerRemarks = newCrane.OutriggerRemarks;
					orgCrane.StrangeSoundRemarks = newCrane.StrangeSoundRemarks;
					orgCrane.DriverName = newCrane.DriverName;
					//orgCrane.userID = newCrane.userID;


					craneRepo.update(orgCrane);
					result.Data = orgCrane;
					result.Statescode = 200;
					return result;

				}
				catch (Exception ex)
				{
					result.Message = "Error in Updating";
					result.Statescode = 400;
					return result;
				}
			}
			return BadRequest(ModelState);
		}

		[HttpPut("Delete/{id:int}")]
		public ActionResult<ResultDTO> Delete(int id) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				Crane crane = craneRepo.getbyid(id);
				crane.IsDeleted = true;
				craneRepo.update(crane);
				result.Data = crane;
				result.Statescode = 200;
				result.Message = "Success";
			}
			catch (Exception ex)
			{
				result.Message = "Error in deleted";
				result.Statescode = 400;
			}

			return result;
		}
	}
}
