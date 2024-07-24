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

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	//[Authorize]
	public class ForkliftController : ControllerBase
    {
        public IRepository<Forklift> forkliftRepo { get; set; }
        public IForkliftRepository forkliftRepository { get; set; }

		private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager;

        public ForkliftController(IForkliftRepository _forkliftRepository,Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager,IRepository<Forklift> _forkliftRepo)
        {
            this.forkliftRepo = _forkliftRepo;
            this.forkliftRepository = _forkliftRepository;
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
					List<Forklift> temp = forkliftRepository.getall();
					List<ForkliftResponseDTO> newTemp = new List<ForkliftResponseDTO>();
					foreach (Forklift forklift in temp)
					{
						ForkliftResponseDTO forkliftDTO = new ForkliftResponseDTO();
						forkliftDTO.Id = forklift.Id;
						forkliftDTO.RigNo = forklift.Rig.Number;
						forkliftDTO.Date = forklift.Date;
						forkliftDTO.WellName = forklift.WellName;
						forkliftDTO.UnitNo = forklift.UnitNo;
						forkliftDTO.QHSEEngineer = forklift.QHSEEngineer;
						//forkliftDTO.HrsSinceOilChange = forklift.HrsSinceOilChange;
						forkliftDTO.CleanAndTidy = forklift.CleanAndTidy;
						forkliftDTO.EngineOilLevel = forklift.EngineOilLevel;
						forkliftDTO.TransmissionOilLevel = forklift.TransmissionOilLevel;
						forkliftDTO.RadiatorWaterLevel = forklift.RadiatorWaterLevel;
						forkliftDTO.HydraulicOilLevel = forklift.HydraulicOilLevel;
						forkliftDTO.V_beltsTension = forklift.V_beltsTension;
						forkliftDTO.DrainWater = forklift.DrainWater;
						forkliftDTO.Leaks = forklift.Leaks;
						forkliftDTO.BatteryHolder = forklift.BatteryHolder;
						forkliftDTO.GaugesForCorrectReadings = forklift.GaugesForCorrectReadings;
						forkliftDTO.TirePressure = forklift.TirePressure;
						forkliftDTO.TireCondition = forklift.TireCondition;
						forkliftDTO.FuelTanksFull = forklift.FuelTanksFull;
						forkliftDTO.Lights = forklift.Lights;
						forkliftDTO.Alarms = forklift.Alarms;
						forkliftDTO.HoistingSystem = forklift.HoistingSystem;
						forkliftDTO.AbnormalNoise = forklift.AbnormalNoise;
						forkliftDTO.Brakes = forklift.Brakes;
						forkliftDTO.LiquidLevel = forklift.LiquidLevel;
						forkliftDTO.Instruments = forklift.Instruments;
						forkliftDTO.EngineDriveBelts = forklift.EngineDriveBelts;
						forkliftDTO.CarriageRollers = forklift.CarriageRollers;
						forkliftDTO.SteeringSystem = forklift.SteeringSystem;
						forkliftDTO.SeatBelt = forklift.SeatBelt;
						forkliftDTO.HoseofCoilCooling = forklift.HoseofCoilCooling;
						forkliftDTO.FirstAidBox = forklift.FirstAidBox;
						forkliftDTO.CrankShaft = forklift.CrankShaft;
						forkliftDTO.DriverSeat = forklift.DriverSeat;
						forkliftDTO.EngineV_belts = forklift.EngineV_belts;
						forkliftDTO.Wipers = forklift.Wipers;
						forkliftDTO.ExistingCorrosion = forklift.ExistingCorrosion;
						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.CleanAndTidyRemarks = forklift.CleanAndTidyRemarks;
						forkliftDTO.EngineOilLevelRemarks = forklift.EngineOilLevelRemarks;
						forkliftDTO.TransmissionOilLevelRemarks = forklift.TransmissionOilLevelRemarks;
						forkliftDTO.RadiatorWaterLevelRemarks = forklift.RadiatorWaterLevelRemarks;
						forkliftDTO.HydraulicOilLevelRemarks = forklift.HydraulicOilLevelRemarks;
						forkliftDTO.V_beltsTensionRemarks = forklift.V_beltsTensionRemarks;
						forkliftDTO.DrainWaterRemarks = forklift.DrainWaterRemarks;
						forkliftDTO.LeaksRemarks = forklift.LeaksRemarks;
						forkliftDTO.BatteryHolderRemarks = forklift.BatteryHolderRemarks;
						forkliftDTO.GaugesForCorrectReadingsRemarks = forklift.GaugesForCorrectReadingsRemarks;
						forkliftDTO.TyrePressureRemarks = forklift.TyrePressureRemarks;
						forkliftDTO.TyreConditionRemarks = forklift.TyreConditionRemarks;
						forkliftDTO.FuelTanksFullRemarks = forklift.FuelTanksFullRemarks;
						forkliftDTO.LightsRemarks = forklift.LightsRemarks;
						forkliftDTO.AlarmsRemarks = forklift.AlarmsRemarks;
						forkliftDTO.HoistingSystemRemarks = forklift.HoistingSystemRemarks;
						forkliftDTO.AbnormalNoiseRemarks = forklift.AbnormalNoiseRemarks;
						forkliftDTO.BrakesRemarks = forklift.BrakesRemarks;
						forkliftDTO.LiquidLevelRemarks = forklift.LiquidLevelRemarks;
						forkliftDTO.InstrumentsRemarks = forklift.InstrumentsRemarks;
						forkliftDTO.EngineDriveBeltsRemarks = forklift.EngineDriveBeltsRemarks;
						forkliftDTO.CarriageRollersRemarks = forklift.CarriageRollersRemarks;
						forkliftDTO.SteeringSystemRemarks = forklift.SteeringSystemRemarks;
						forkliftDTO.SeatBeltRemarks = forklift.SeatBeltRemarks;
						forkliftDTO.HoseofCoilCoolingRemarks = forklift.HoseofCoilCoolingRemarks;
						forkliftDTO.FirstAidBoxRemarks = forklift.FirstAidBoxRemarks;
						forkliftDTO.CrankShaftRemarks = forklift.CrankShaftRemarks;
						forkliftDTO.DriverSeatRemarks = forklift.DriverSeatRemarks;
						forkliftDTO.EngineV_beltsRemarks = forklift.EngineV_beltsRemarks;
						forkliftDTO.WipersRemarks = forklift.WipersRemarks;
						forkliftDTO.ExistingCorrosionRemarks = forklift.ExistingCorrosionRemarks;

						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.userName = forklift.user.UserName;

						newTemp.Add(forkliftDTO);

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
					List<Forklift> temp = forkliftRepository.getall().Where(a => a.user.Id == UserID).ToList();
					List<ForkliftResponseDTO> newTemp = new List<ForkliftResponseDTO>();
					foreach (Forklift forklift in temp)
					{
						ForkliftResponseDTO forkliftDTO = new ForkliftResponseDTO();
						forkliftDTO.Id = forklift.Id;
						forkliftDTO.RigNo = forklift.Rig.Number;
						forkliftDTO.Date = forklift.Date;
						forkliftDTO.WellName = forklift.WellName;
						forkliftDTO.UnitNo = forklift.UnitNo;
						forkliftDTO.QHSEEngineer = forklift.QHSEEngineer;
						//forkliftDTO.HrsSinceOilChange = forklift.HrsSinceOilChange;
						forkliftDTO.CleanAndTidy = forklift.CleanAndTidy;
						forkliftDTO.EngineOilLevel = forklift.EngineOilLevel;
						forkliftDTO.TransmissionOilLevel = forklift.TransmissionOilLevel;
						forkliftDTO.RadiatorWaterLevel = forklift.RadiatorWaterLevel;
						forkliftDTO.HydraulicOilLevel = forklift.HydraulicOilLevel;
						forkliftDTO.V_beltsTension = forklift.V_beltsTension;
						forkliftDTO.DrainWater = forklift.DrainWater;
						forkliftDTO.Leaks = forklift.Leaks;
						forkliftDTO.BatteryHolder = forklift.BatteryHolder;
						forkliftDTO.GaugesForCorrectReadings = forklift.GaugesForCorrectReadings;
						forkliftDTO.TirePressure = forklift.TirePressure;
						forkliftDTO.TireCondition = forklift.TireCondition;
						forkliftDTO.FuelTanksFull = forklift.FuelTanksFull;
						forkliftDTO.Lights = forklift.Lights;
						forkliftDTO.Alarms = forklift.Alarms;
						forkliftDTO.HoistingSystem = forklift.HoistingSystem;
						forkliftDTO.AbnormalNoise = forklift.AbnormalNoise;
						forkliftDTO.Brakes = forklift.Brakes;
						forkliftDTO.LiquidLevel = forklift.LiquidLevel;
						forkliftDTO.Instruments = forklift.Instruments;
						forkliftDTO.EngineDriveBelts = forklift.EngineDriveBelts;
						forkliftDTO.CarriageRollers = forklift.CarriageRollers;
						forkliftDTO.SteeringSystem = forklift.SteeringSystem;
						forkliftDTO.SeatBelt = forklift.SeatBelt;
						forkliftDTO.HoseofCoilCooling = forklift.HoseofCoilCooling;
						forkliftDTO.FirstAidBox = forklift.FirstAidBox;
						forkliftDTO.CrankShaft = forklift.CrankShaft;
						forkliftDTO.DriverSeat = forklift.DriverSeat;
						forkliftDTO.EngineV_belts = forklift.EngineV_belts;
						forkliftDTO.Wipers = forklift.Wipers;
						forkliftDTO.ExistingCorrosion = forklift.ExistingCorrosion;
						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.CleanAndTidyRemarks = forklift.CleanAndTidyRemarks;
						forkliftDTO.EngineOilLevelRemarks = forklift.EngineOilLevelRemarks;
						forkliftDTO.TransmissionOilLevelRemarks = forklift.TransmissionOilLevelRemarks;
						forkliftDTO.RadiatorWaterLevelRemarks = forklift.RadiatorWaterLevelRemarks;
						forkliftDTO.HydraulicOilLevelRemarks = forklift.HydraulicOilLevelRemarks;
						forkliftDTO.V_beltsTensionRemarks = forklift.V_beltsTensionRemarks;
						forkliftDTO.DrainWaterRemarks = forklift.DrainWaterRemarks;
						forkliftDTO.LeaksRemarks = forklift.LeaksRemarks;
						forkliftDTO.BatteryHolderRemarks = forklift.BatteryHolderRemarks;
						forkliftDTO.GaugesForCorrectReadingsRemarks = forklift.GaugesForCorrectReadingsRemarks;
						forkliftDTO.TyrePressureRemarks = forklift.TyrePressureRemarks;
						forkliftDTO.TyreConditionRemarks = forklift.TyreConditionRemarks;
						forkliftDTO.FuelTanksFullRemarks = forklift.FuelTanksFullRemarks;
						forkliftDTO.LightsRemarks = forklift.LightsRemarks;
						forkliftDTO.AlarmsRemarks = forklift.AlarmsRemarks;
						forkliftDTO.HoistingSystemRemarks = forklift.HoistingSystemRemarks;
						forkliftDTO.AbnormalNoiseRemarks = forklift.AbnormalNoiseRemarks;
						forkliftDTO.BrakesRemarks = forklift.BrakesRemarks;
						forkliftDTO.LiquidLevelRemarks = forklift.LiquidLevelRemarks;
						forkliftDTO.InstrumentsRemarks = forklift.InstrumentsRemarks;
						forkliftDTO.EngineDriveBeltsRemarks = forklift.EngineDriveBeltsRemarks;
						forkliftDTO.CarriageRollersRemarks = forklift.CarriageRollersRemarks;
						forkliftDTO.SteeringSystemRemarks = forklift.SteeringSystemRemarks;
						forkliftDTO.SeatBeltRemarks = forklift.SeatBeltRemarks;
						forkliftDTO.HoseofCoilCoolingRemarks = forklift.HoseofCoilCoolingRemarks;
						forkliftDTO.FirstAidBoxRemarks = forklift.FirstAidBoxRemarks;
						forkliftDTO.CrankShaftRemarks = forklift.CrankShaftRemarks;
						forkliftDTO.DriverSeatRemarks = forklift.DriverSeatRemarks;
						forkliftDTO.EngineV_beltsRemarks = forklift.EngineV_beltsRemarks;
						forkliftDTO.WipersRemarks = forklift.WipersRemarks;
						forkliftDTO.ExistingCorrosionRemarks = forklift.ExistingCorrosionRemarks;

						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.userName = forklift.user.UserName;

						newTemp.Add(forkliftDTO);

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
					List<Forklift> temp = forkliftRepository.getall();
					List<ForkliftExcelDTO> newTemp = new List<ForkliftExcelDTO>();
					foreach (Forklift forklift in temp)
					{
						ForkliftExcelDTO forkliftDTO = new ForkliftExcelDTO();
						forkliftDTO.Id = forklift.Id;
						forkliftDTO.RigNo = forklift.Rig.Number;
						forkliftDTO.Date = forklift.Date;
						forkliftDTO.WellName = forklift.WellName;
						forkliftDTO.UnitNo = forklift.UnitNo;
						forkliftDTO.QHSEEngineer = forklift.QHSEEngineer;
						//forkliftDTO.HrsSinceOilChange = forklift.HrsSinceOilChange;
						forkliftDTO.CleanAndTidy = forklift.CleanAndTidy;
						forkliftDTO.EngineOilLevel = forklift.EngineOilLevel;
						forkliftDTO.TransmissionOilLevel = forklift.TransmissionOilLevel;
						forkliftDTO.RadiatorWaterLevel = forklift.RadiatorWaterLevel;
						forkliftDTO.HydraulicOilLevel = forklift.HydraulicOilLevel;
						forkliftDTO.V_beltsTension = forklift.V_beltsTension;
						forkliftDTO.DrainWater = forklift.DrainWater;
						forkliftDTO.Leaks = forklift.Leaks;
						forkliftDTO.BatteryHolder = forklift.BatteryHolder;
						forkliftDTO.GaugesForCorrectReadings = forklift.GaugesForCorrectReadings;
						forkliftDTO.TirePressure = forklift.TirePressure;
						forkliftDTO.TireCondition = forklift.TireCondition;
						forkliftDTO.FuelTanksFull = forklift.FuelTanksFull;
						forkliftDTO.Lights = forklift.Lights;
						forkliftDTO.Alarms = forklift.Alarms;
						forkliftDTO.HoistingSystem = forklift.HoistingSystem;
						forkliftDTO.AbnormalNoise = forklift.AbnormalNoise;
						forkliftDTO.Brakes = forklift.Brakes;
						forkliftDTO.LiquidLevel = forklift.LiquidLevel;
						forkliftDTO.Instruments = forklift.Instruments;
						forkliftDTO.EngineDriveBelts = forklift.EngineDriveBelts;
						forkliftDTO.CarriageRollers = forklift.CarriageRollers;
						forkliftDTO.SteeringSystem = forklift.SteeringSystem;
						forkliftDTO.SeatBelt = forklift.SeatBelt;
						forkliftDTO.HoseofCoilCooling = forklift.HoseofCoilCooling;
						forkliftDTO.FirstAidBox = forklift.FirstAidBox;
						forkliftDTO.CrankShaft = forklift.CrankShaft;
						forkliftDTO.DriverSeat = forklift.DriverSeat;
						forkliftDTO.EngineV_belts = forklift.EngineV_belts;
						forkliftDTO.Wipers = forklift.Wipers;
						forkliftDTO.ExistingCorrosion = forklift.ExistingCorrosion;
						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.CleanAndTidyRemarks = forklift.CleanAndTidyRemarks;
						forkliftDTO.EngineOilLevelRemarks = forklift.EngineOilLevelRemarks;
						forkliftDTO.TransmissionOilLevelRemarks = forklift.TransmissionOilLevelRemarks;
						forkliftDTO.RadiatorWaterLevelRemarks = forklift.RadiatorWaterLevelRemarks;
						forkliftDTO.HydraulicOilLevelRemarks = forklift.HydraulicOilLevelRemarks;
						forkliftDTO.V_beltsTensionRemarks = forklift.V_beltsTensionRemarks;
						forkliftDTO.DrainWaterRemarks = forklift.DrainWaterRemarks;
						forkliftDTO.LeaksRemarks = forklift.LeaksRemarks;
						forkliftDTO.BatteryHolderRemarks = forklift.BatteryHolderRemarks;
						forkliftDTO.GaugesForCorrectReadingsRemarks = forklift.GaugesForCorrectReadingsRemarks;
						forkliftDTO.TirePressureRemarks = forklift.TyrePressureRemarks;
						forkliftDTO.TireConditionRemarks = forklift.TyreConditionRemarks;
						forkliftDTO.FuelTanksFullRemarks = forklift.FuelTanksFullRemarks;
						forkliftDTO.LightsRemarks = forklift.LightsRemarks;
						forkliftDTO.AlarmsRemarks = forklift.AlarmsRemarks;
						forkliftDTO.HoistingSystemRemarks = forklift.HoistingSystemRemarks;
						forkliftDTO.AbnormalNoiseRemarks = forklift.AbnormalNoiseRemarks;
						forkliftDTO.BrakesRemarks = forklift.BrakesRemarks;
						forkliftDTO.LiquidLevelRemarks = forklift.LiquidLevelRemarks;
						forkliftDTO.InstrumentsRemarks = forklift.InstrumentsRemarks;
						forkliftDTO.EngineDriveBeltsRemarks = forklift.EngineDriveBeltsRemarks;
						forkliftDTO.CarriageRollersRemarks = forklift.CarriageRollersRemarks;
						forkliftDTO.SteeringSystemRemarks = forklift.SteeringSystemRemarks;
						forkliftDTO.SeatBeltRemarks = forklift.SeatBeltRemarks;
						forkliftDTO.HoseofCoilCoolingRemarks = forklift.HoseofCoilCoolingRemarks;
						forkliftDTO.FirstAidBoxRemarks = forklift.FirstAidBoxRemarks;
						forkliftDTO.CrankShaftRemarks = forklift.CrankShaftRemarks;
						forkliftDTO.DriverSeatRemarks = forklift.DriverSeatRemarks;
						forkliftDTO.EngineV_beltsRemarks = forklift.EngineV_beltsRemarks;
						forkliftDTO.WipersRemarks = forklift.WipersRemarks;
						forkliftDTO.ExistingCorrosionRemarks = forklift.ExistingCorrosionRemarks;

						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.userName = forklift.user.UserName;

						newTemp.Add(forkliftDTO);

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
					List<Forklift> temp = forkliftRepository.getall().Where(a => a.user.Id == UserID).ToList();
					List<ForkliftExcelDTO> newTemp = new List<ForkliftExcelDTO>();
					foreach (Forklift forklift in temp)
					{
						ForkliftExcelDTO forkliftDTO = new ForkliftExcelDTO();
						forkliftDTO.Id = forklift.Id;
						forkliftDTO.RigNo = forklift.Rig.Number;
						forkliftDTO.Date = forklift.Date;
						forkliftDTO.WellName = forklift.WellName;
						forkliftDTO.UnitNo = forklift.UnitNo;
						forkliftDTO.QHSEEngineer = forklift.QHSEEngineer;
						//forkliftDTO.HrsSinceOilChange = forklift.HrsSinceOilChange;
						forkliftDTO.CleanAndTidy = forklift.CleanAndTidy;
						forkliftDTO.EngineOilLevel = forklift.EngineOilLevel;
						forkliftDTO.TransmissionOilLevel = forklift.TransmissionOilLevel;
						forkliftDTO.RadiatorWaterLevel = forklift.RadiatorWaterLevel;
						forkliftDTO.HydraulicOilLevel = forklift.HydraulicOilLevel;
						forkliftDTO.V_beltsTension = forklift.V_beltsTension;
						forkliftDTO.DrainWater = forklift.DrainWater;
						forkliftDTO.Leaks = forklift.Leaks;
						forkliftDTO.BatteryHolder = forklift.BatteryHolder;
						forkliftDTO.GaugesForCorrectReadings = forklift.GaugesForCorrectReadings;
						forkliftDTO.TirePressure = forklift.TirePressure;
						forkliftDTO.TireCondition = forklift.TireCondition;
						forkliftDTO.FuelTanksFull = forklift.FuelTanksFull;
						forkliftDTO.Lights = forklift.Lights;
						forkliftDTO.Alarms = forklift.Alarms;
						forkliftDTO.HoistingSystem = forklift.HoistingSystem;
						forkliftDTO.AbnormalNoise = forklift.AbnormalNoise;
						forkliftDTO.Brakes = forklift.Brakes;
						forkliftDTO.LiquidLevel = forklift.LiquidLevel;
						forkliftDTO.Instruments = forklift.Instruments;
						forkliftDTO.EngineDriveBelts = forklift.EngineDriveBelts;
						forkliftDTO.CarriageRollers = forklift.CarriageRollers;
						forkliftDTO.SteeringSystem = forklift.SteeringSystem;
						forkliftDTO.SeatBelt = forklift.SeatBelt;
						forkliftDTO.HoseofCoilCooling = forklift.HoseofCoilCooling;
						forkliftDTO.FirstAidBox = forklift.FirstAidBox;
						forkliftDTO.CrankShaft = forklift.CrankShaft;
						forkliftDTO.DriverSeat = forklift.DriverSeat;
						forkliftDTO.EngineV_belts = forklift.EngineV_belts;
						forkliftDTO.Wipers = forklift.Wipers;
						forkliftDTO.ExistingCorrosion = forklift.ExistingCorrosion;
						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.CleanAndTidyRemarks = forklift.CleanAndTidyRemarks;
						forkliftDTO.EngineOilLevelRemarks = forklift.EngineOilLevelRemarks;
						forkliftDTO.TransmissionOilLevelRemarks = forklift.TransmissionOilLevelRemarks;
						forkliftDTO.RadiatorWaterLevelRemarks = forklift.RadiatorWaterLevelRemarks;
						forkliftDTO.HydraulicOilLevelRemarks = forklift.HydraulicOilLevelRemarks;
						forkliftDTO.V_beltsTensionRemarks = forklift.V_beltsTensionRemarks;
						forkliftDTO.DrainWaterRemarks = forklift.DrainWaterRemarks;
						forkliftDTO.LeaksRemarks = forklift.LeaksRemarks;
						forkliftDTO.BatteryHolderRemarks = forklift.BatteryHolderRemarks;
						forkliftDTO.GaugesForCorrectReadingsRemarks = forklift.GaugesForCorrectReadingsRemarks;
						forkliftDTO.TirePressureRemarks = forklift.TyrePressureRemarks;
						forkliftDTO.TireConditionRemarks = forklift.TyreConditionRemarks;
						forkliftDTO.FuelTanksFullRemarks = forklift.FuelTanksFullRemarks;
						forkliftDTO.LightsRemarks = forklift.LightsRemarks;
						forkliftDTO.AlarmsRemarks = forklift.AlarmsRemarks;
						forkliftDTO.HoistingSystemRemarks = forklift.HoistingSystemRemarks;
						forkliftDTO.AbnormalNoiseRemarks = forklift.AbnormalNoiseRemarks;
						forkliftDTO.BrakesRemarks = forklift.BrakesRemarks;
						forkliftDTO.LiquidLevelRemarks = forklift.LiquidLevelRemarks;
						forkliftDTO.InstrumentsRemarks = forklift.InstrumentsRemarks;
						forkliftDTO.EngineDriveBeltsRemarks = forklift.EngineDriveBeltsRemarks;
						forkliftDTO.CarriageRollersRemarks = forklift.CarriageRollersRemarks;
						forkliftDTO.SteeringSystemRemarks = forklift.SteeringSystemRemarks;
						forkliftDTO.SeatBeltRemarks = forklift.SeatBeltRemarks;
						forkliftDTO.HoseofCoilCoolingRemarks = forklift.HoseofCoilCoolingRemarks;
						forkliftDTO.FirstAidBoxRemarks = forklift.FirstAidBoxRemarks;
						forkliftDTO.CrankShaftRemarks = forklift.CrankShaftRemarks;
						forkliftDTO.DriverSeatRemarks = forklift.DriverSeatRemarks;
						forkliftDTO.EngineV_beltsRemarks = forklift.EngineV_beltsRemarks;
						forkliftDTO.WipersRemarks = forklift.WipersRemarks;
						forkliftDTO.ExistingCorrosionRemarks = forklift.ExistingCorrosionRemarks;

						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.userName = forklift.user.UserName;

						newTemp.Add(forkliftDTO);
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
					List<Forklift> temp = forkliftRepository.getall().Where(c => c.RigId == RigId).ToList();
					List<ForkliftResponseDTO> newTemp = new List<ForkliftResponseDTO>();
					foreach (Forklift forklift in temp)
					{
						ForkliftResponseDTO forkliftDTO = new ForkliftResponseDTO();
						forkliftDTO.Id = forklift.Id;
						forkliftDTO.RigNo = forklift.Rig.Number;
						forkliftDTO.Date = forklift.Date;
						forkliftDTO.WellName = forklift.WellName;
						forkliftDTO.UnitNo = forklift.UnitNo;
						forkliftDTO.QHSEEngineer = forklift.QHSEEngineer;
						//forkliftDTO.HrsSinceOilChange = forklift.HrsSinceOilChange;
						forkliftDTO.CleanAndTidy = forklift.CleanAndTidy;
						forkliftDTO.EngineOilLevel = forklift.EngineOilLevel;
						forkliftDTO.TransmissionOilLevel = forklift.TransmissionOilLevel;
						forkliftDTO.RadiatorWaterLevel = forklift.RadiatorWaterLevel;
						forkliftDTO.HydraulicOilLevel = forklift.HydraulicOilLevel;
						forkliftDTO.V_beltsTension = forklift.V_beltsTension;
						forkliftDTO.DrainWater = forklift.DrainWater;
						forkliftDTO.Leaks = forklift.Leaks;
						forkliftDTO.BatteryHolder = forklift.BatteryHolder;
						forkliftDTO.GaugesForCorrectReadings = forklift.GaugesForCorrectReadings;
						forkliftDTO.TirePressure = forklift.TirePressure;
						forkliftDTO.TireCondition = forklift.TireCondition;
						forkliftDTO.FuelTanksFull = forklift.FuelTanksFull;
						forkliftDTO.Lights = forklift.Lights;
						forkliftDTO.Alarms = forklift.Alarms;
						forkliftDTO.HoistingSystem = forklift.HoistingSystem;
						forkliftDTO.AbnormalNoise = forklift.AbnormalNoise;
						forkliftDTO.Brakes = forklift.Brakes;
						forkliftDTO.LiquidLevel = forklift.LiquidLevel;
						forkliftDTO.Instruments = forklift.Instruments;
						forkliftDTO.EngineDriveBelts = forklift.EngineDriveBelts;
						forkliftDTO.CarriageRollers = forklift.CarriageRollers;
						forkliftDTO.SteeringSystem = forklift.SteeringSystem;
						forkliftDTO.SeatBelt = forklift.SeatBelt;
						forkliftDTO.HoseofCoilCooling = forklift.HoseofCoilCooling;
						forkliftDTO.FirstAidBox = forklift.FirstAidBox;
						forkliftDTO.CrankShaft = forklift.CrankShaft;
						forkliftDTO.DriverSeat = forklift.DriverSeat;
						forkliftDTO.EngineV_belts = forklift.EngineV_belts;
						forkliftDTO.Wipers = forklift.Wipers;
						forkliftDTO.ExistingCorrosion = forklift.ExistingCorrosion;
						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.CleanAndTidyRemarks = forklift.CleanAndTidyRemarks;
						forkliftDTO.EngineOilLevelRemarks = forklift.EngineOilLevelRemarks;
						forkliftDTO.TransmissionOilLevelRemarks = forklift.TransmissionOilLevelRemarks;
						forkliftDTO.RadiatorWaterLevelRemarks = forklift.RadiatorWaterLevelRemarks;
						forkliftDTO.HydraulicOilLevelRemarks = forklift.HydraulicOilLevelRemarks;
						forkliftDTO.V_beltsTensionRemarks = forklift.V_beltsTensionRemarks;
						forkliftDTO.DrainWaterRemarks = forklift.DrainWaterRemarks;
						forkliftDTO.LeaksRemarks = forklift.LeaksRemarks;
						forkliftDTO.BatteryHolderRemarks = forklift.BatteryHolderRemarks;
						forkliftDTO.GaugesForCorrectReadingsRemarks = forklift.GaugesForCorrectReadingsRemarks;
						forkliftDTO.TyrePressureRemarks = forklift.TyrePressureRemarks;
						forkliftDTO.TyreConditionRemarks = forklift.TyreConditionRemarks;
						forkliftDTO.FuelTanksFullRemarks = forklift.FuelTanksFullRemarks;
						forkliftDTO.LightsRemarks = forklift.LightsRemarks;
						forkliftDTO.AlarmsRemarks = forklift.AlarmsRemarks;
						forkliftDTO.HoistingSystemRemarks = forklift.HoistingSystemRemarks;
						forkliftDTO.AbnormalNoiseRemarks = forklift.AbnormalNoiseRemarks;
						forkliftDTO.BrakesRemarks = forklift.BrakesRemarks;
						forkliftDTO.LiquidLevelRemarks = forklift.LiquidLevelRemarks;
						forkliftDTO.InstrumentsRemarks = forklift.InstrumentsRemarks;
						forkliftDTO.EngineDriveBeltsRemarks = forklift.EngineDriveBeltsRemarks;
						forkliftDTO.CarriageRollersRemarks = forklift.CarriageRollersRemarks;
						forkliftDTO.SteeringSystemRemarks = forklift.SteeringSystemRemarks;
						forkliftDTO.SeatBeltRemarks = forklift.SeatBeltRemarks;
						forkliftDTO.HoseofCoilCoolingRemarks = forklift.HoseofCoilCoolingRemarks;
						forkliftDTO.FirstAidBoxRemarks = forklift.FirstAidBoxRemarks;
						forkliftDTO.CrankShaftRemarks = forklift.CrankShaftRemarks;
						forkliftDTO.DriverSeatRemarks = forklift.DriverSeatRemarks;
						forkliftDTO.EngineV_beltsRemarks = forklift.EngineV_beltsRemarks;
						forkliftDTO.WipersRemarks = forklift.WipersRemarks;
						forkliftDTO.ExistingCorrosionRemarks = forklift.ExistingCorrosionRemarks;

						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.userName = forklift.user.UserName;

						newTemp.Add(forkliftDTO);

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
					List<Forklift> temp = forkliftRepository.getall().Where(a => a.user.Id == UserID && a.RigId == RigId).ToList().ToList();
					List<ForkliftResponseDTO> newTemp = new List<ForkliftResponseDTO>();
					foreach (Forklift forklift in temp)
					{
						ForkliftResponseDTO forkliftDTO = new ForkliftResponseDTO();
						forkliftDTO.Id = forklift.Id;
						forkliftDTO.RigNo = forklift.Rig.Number;
						forkliftDTO.Date = forklift.Date;
						forkliftDTO.WellName = forklift.WellName;
						forkliftDTO.UnitNo = forklift.UnitNo;
						forkliftDTO.QHSEEngineer = forklift.QHSEEngineer;
						//forkliftDTO.HrsSinceOilChange = forklift.HrsSinceOilChange;
						forkliftDTO.CleanAndTidy = forklift.CleanAndTidy;
						forkliftDTO.EngineOilLevel = forklift.EngineOilLevel;
						forkliftDTO.TransmissionOilLevel = forklift.TransmissionOilLevel;
						forkliftDTO.RadiatorWaterLevel = forklift.RadiatorWaterLevel;
						forkliftDTO.HydraulicOilLevel = forklift.HydraulicOilLevel;
						forkliftDTO.V_beltsTension = forklift.V_beltsTension;
						forkliftDTO.DrainWater = forklift.DrainWater;
						forkliftDTO.Leaks = forklift.Leaks;
						forkliftDTO.BatteryHolder = forklift.BatteryHolder;
						forkliftDTO.GaugesForCorrectReadings = forklift.GaugesForCorrectReadings;
						forkliftDTO.TirePressure = forklift.TirePressure;
						forkliftDTO.TireCondition = forklift.TireCondition;
						forkliftDTO.FuelTanksFull = forklift.FuelTanksFull;
						forkliftDTO.Lights = forklift.Lights;
						forkliftDTO.Alarms = forklift.Alarms;
						forkliftDTO.HoistingSystem = forklift.HoistingSystem;
						forkliftDTO.AbnormalNoise = forklift.AbnormalNoise;
						forkliftDTO.Brakes = forklift.Brakes;
						forkliftDTO.LiquidLevel = forklift.LiquidLevel;
						forkliftDTO.Instruments = forklift.Instruments;
						forkliftDTO.EngineDriveBelts = forklift.EngineDriveBelts;
						forkliftDTO.CarriageRollers = forklift.CarriageRollers;
						forkliftDTO.SteeringSystem = forklift.SteeringSystem;
						forkliftDTO.SeatBelt = forklift.SeatBelt;
						forkliftDTO.HoseofCoilCooling = forklift.HoseofCoilCooling;
						forkliftDTO.FirstAidBox = forklift.FirstAidBox;
						forkliftDTO.CrankShaft = forklift.CrankShaft;
						forkliftDTO.DriverSeat = forklift.DriverSeat;
						forkliftDTO.EngineV_belts = forklift.EngineV_belts;
						forkliftDTO.Wipers = forklift.Wipers;
						forkliftDTO.ExistingCorrosion = forklift.ExistingCorrosion;
						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.CleanAndTidyRemarks = forklift.CleanAndTidyRemarks;
						forkliftDTO.EngineOilLevelRemarks = forklift.EngineOilLevelRemarks;
						forkliftDTO.TransmissionOilLevelRemarks = forklift.TransmissionOilLevelRemarks;
						forkliftDTO.RadiatorWaterLevelRemarks = forklift.RadiatorWaterLevelRemarks;
						forkliftDTO.HydraulicOilLevelRemarks = forklift.HydraulicOilLevelRemarks;
						forkliftDTO.V_beltsTensionRemarks = forklift.V_beltsTensionRemarks;
						forkliftDTO.DrainWaterRemarks = forklift.DrainWaterRemarks;
						forkliftDTO.LeaksRemarks = forklift.LeaksRemarks;
						forkliftDTO.BatteryHolderRemarks = forklift.BatteryHolderRemarks;
						forkliftDTO.GaugesForCorrectReadingsRemarks = forklift.GaugesForCorrectReadingsRemarks;
						forkliftDTO.TyrePressureRemarks = forklift.TyrePressureRemarks;
						forkliftDTO.TyreConditionRemarks = forklift.TyreConditionRemarks;
						forkliftDTO.FuelTanksFullRemarks = forklift.FuelTanksFullRemarks;
						forkliftDTO.LightsRemarks = forklift.LightsRemarks;
						forkliftDTO.AlarmsRemarks = forklift.AlarmsRemarks;
						forkliftDTO.HoistingSystemRemarks = forklift.HoistingSystemRemarks;
						forkliftDTO.AbnormalNoiseRemarks = forklift.AbnormalNoiseRemarks;
						forkliftDTO.BrakesRemarks = forklift.BrakesRemarks;
						forkliftDTO.LiquidLevelRemarks = forklift.LiquidLevelRemarks;
						forkliftDTO.InstrumentsRemarks = forklift.InstrumentsRemarks;
						forkliftDTO.EngineDriveBeltsRemarks = forklift.EngineDriveBeltsRemarks;
						forkliftDTO.CarriageRollersRemarks = forklift.CarriageRollersRemarks;
						forkliftDTO.SteeringSystemRemarks = forklift.SteeringSystemRemarks;
						forkliftDTO.SeatBeltRemarks = forklift.SeatBeltRemarks;
						forkliftDTO.HoseofCoilCoolingRemarks = forklift.HoseofCoilCoolingRemarks;
						forkliftDTO.FirstAidBoxRemarks = forklift.FirstAidBoxRemarks;
						forkliftDTO.CrankShaftRemarks = forklift.CrankShaftRemarks;
						forkliftDTO.DriverSeatRemarks = forklift.DriverSeatRemarks;
						forkliftDTO.EngineV_beltsRemarks = forklift.EngineV_beltsRemarks;
						forkliftDTO.WipersRemarks = forklift.WipersRemarks;
						forkliftDTO.ExistingCorrosionRemarks = forklift.ExistingCorrosionRemarks;

						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.userName = forklift.user.UserName;

						newTemp.Add(forkliftDTO);

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
		public PageResult<ForkliftResponseDTO> GettAllStoCardsByPage(string UserId, string UserRole, int? page, int pagesize = 10)
		{
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<Forklift> temp = forkliftRepository.getall();
					List<ForkliftResponseDTO> newTemp = new List<ForkliftResponseDTO>();
					foreach (Forklift forklift in temp)
					{
						ForkliftResponseDTO forkliftDTO = new ForkliftResponseDTO();
						forkliftDTO.Id = forklift.Id;
						forkliftDTO.RigNo = forklift.Rig.Number;
						forkliftDTO.Date = forklift.Date;
						forkliftDTO.WellName = forklift.WellName;
						forkliftDTO.UnitNo = forklift.UnitNo;
						forkliftDTO.QHSEEngineer = forklift.QHSEEngineer;
						//forkliftDTO.HrsSinceOilChange = forklift.HrsSinceOilChange;
						forkliftDTO.CleanAndTidy = forklift.CleanAndTidy;
						forkliftDTO.EngineOilLevel = forklift.EngineOilLevel;
						forkliftDTO.TransmissionOilLevel = forklift.TransmissionOilLevel;
						forkliftDTO.RadiatorWaterLevel = forklift.RadiatorWaterLevel;
						forkliftDTO.HydraulicOilLevel = forklift.HydraulicOilLevel;
						forkliftDTO.V_beltsTension = forklift.V_beltsTension;
						forkliftDTO.DrainWater = forklift.DrainWater;
						forkliftDTO.Leaks = forklift.Leaks;
						forkliftDTO.BatteryHolder = forklift.BatteryHolder;
						forkliftDTO.GaugesForCorrectReadings = forklift.GaugesForCorrectReadings;
						forkliftDTO.TirePressure = forklift.TirePressure;
						forkliftDTO.TireCondition = forklift.TireCondition;
						forkliftDTO.FuelTanksFull = forklift.FuelTanksFull;
						forkliftDTO.Lights = forklift.Lights;
						forkliftDTO.Alarms = forklift.Alarms;
						forkliftDTO.HoistingSystem = forklift.HoistingSystem;
						forkliftDTO.AbnormalNoise = forklift.AbnormalNoise;
						forkliftDTO.Brakes = forklift.Brakes;
						forkliftDTO.LiquidLevel = forklift.LiquidLevel;
						forkliftDTO.Instruments = forklift.Instruments;
						forkliftDTO.EngineDriveBelts = forklift.EngineDriveBelts;
						forkliftDTO.CarriageRollers = forklift.CarriageRollers;
						forkliftDTO.SteeringSystem = forklift.SteeringSystem;
						forkliftDTO.SeatBelt = forklift.SeatBelt;
						forkliftDTO.HoseofCoilCooling = forklift.HoseofCoilCooling;
						forkliftDTO.FirstAidBox = forklift.FirstAidBox;
						forkliftDTO.CrankShaft = forklift.CrankShaft;
						forkliftDTO.DriverSeat = forklift.DriverSeat;
						forkliftDTO.EngineV_belts = forklift.EngineV_belts;
						forkliftDTO.Wipers = forklift.Wipers;
						forkliftDTO.ExistingCorrosion = forklift.ExistingCorrosion;
						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.CleanAndTidyRemarks = forklift.CleanAndTidyRemarks;
						forkliftDTO.EngineOilLevelRemarks = forklift.EngineOilLevelRemarks;
						forkliftDTO.TransmissionOilLevelRemarks = forklift.TransmissionOilLevelRemarks;
						forkliftDTO.RadiatorWaterLevelRemarks = forklift.RadiatorWaterLevelRemarks;
						forkliftDTO.HydraulicOilLevelRemarks = forklift.HydraulicOilLevelRemarks;
						forkliftDTO.V_beltsTensionRemarks = forklift.V_beltsTensionRemarks;
						forkliftDTO.DrainWaterRemarks = forklift.DrainWaterRemarks;
						forkliftDTO.LeaksRemarks = forklift.LeaksRemarks;
						forkliftDTO.BatteryHolderRemarks = forklift.BatteryHolderRemarks;
						forkliftDTO.GaugesForCorrectReadingsRemarks = forklift.GaugesForCorrectReadingsRemarks;
						forkliftDTO.TyrePressureRemarks = forklift.TyrePressureRemarks;
						forkliftDTO.TyreConditionRemarks = forklift.TyreConditionRemarks;
						forkliftDTO.FuelTanksFullRemarks = forklift.FuelTanksFullRemarks;
						forkliftDTO.LightsRemarks = forklift.LightsRemarks;
						forkliftDTO.AlarmsRemarks = forklift.AlarmsRemarks;
						forkliftDTO.HoistingSystemRemarks = forklift.HoistingSystemRemarks;
						forkliftDTO.AbnormalNoiseRemarks = forklift.AbnormalNoiseRemarks;
						forkliftDTO.BrakesRemarks = forklift.BrakesRemarks;
						forkliftDTO.LiquidLevelRemarks = forklift.LiquidLevelRemarks;
						forkliftDTO.InstrumentsRemarks = forklift.InstrumentsRemarks;
						forkliftDTO.EngineDriveBeltsRemarks = forklift.EngineDriveBeltsRemarks;
						forkliftDTO.CarriageRollersRemarks = forklift.CarriageRollersRemarks;
						forkliftDTO.SteeringSystemRemarks = forklift.SteeringSystemRemarks;
						forkliftDTO.SeatBeltRemarks = forklift.SeatBeltRemarks;
						forkliftDTO.HoseofCoilCoolingRemarks = forklift.HoseofCoilCoolingRemarks;
						forkliftDTO.FirstAidBoxRemarks = forklift.FirstAidBoxRemarks;
						forkliftDTO.CrankShaftRemarks = forklift.CrankShaftRemarks;
						forkliftDTO.DriverSeatRemarks = forklift.DriverSeatRemarks;
						forkliftDTO.EngineV_beltsRemarks = forklift.EngineV_beltsRemarks;
						forkliftDTO.WipersRemarks = forklift.WipersRemarks;
						forkliftDTO.ExistingCorrosionRemarks = forklift.ExistingCorrosionRemarks;

						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.userName = forklift.user.UserName;

						newTemp.Add(forkliftDTO);
					}

					float countDetails = forkliftRepository.getall().Count();
					var result = new PageResult<ForkliftResponseDTO>
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
					List<Forklift> temp = forkliftRepository.getall().Where(a => a.user.Id == UserId).ToList();
					List<ForkliftResponseDTO> newTemp = new List<ForkliftResponseDTO>();
					foreach (Forklift forklift in temp)
					{
						ForkliftResponseDTO forkliftDTO = new ForkliftResponseDTO();
						forkliftDTO.Id = forklift.Id;
						forkliftDTO.RigNo = forklift.Rig.Number;
						forkliftDTO.Date = forklift.Date;
						forkliftDTO.WellName = forklift.WellName;
						forkliftDTO.UnitNo = forklift.UnitNo;
						forkliftDTO.QHSEEngineer = forklift.QHSEEngineer;
						//forkliftDTO.HrsSinceOilChange = forklift.HrsSinceOilChange;
						forkliftDTO.CleanAndTidy = forklift.CleanAndTidy;
						forkliftDTO.EngineOilLevel = forklift.EngineOilLevel;
						forkliftDTO.TransmissionOilLevel = forklift.TransmissionOilLevel;
						forkliftDTO.RadiatorWaterLevel = forklift.RadiatorWaterLevel;
						forkliftDTO.HydraulicOilLevel = forklift.HydraulicOilLevel;
						forkliftDTO.V_beltsTension = forklift.V_beltsTension;
						forkliftDTO.DrainWater = forklift.DrainWater;
						forkliftDTO.Leaks = forklift.Leaks;
						forkliftDTO.BatteryHolder = forklift.BatteryHolder;
						forkliftDTO.GaugesForCorrectReadings = forklift.GaugesForCorrectReadings;
						forkliftDTO.TirePressure = forklift.TirePressure;
						forkliftDTO.TireCondition = forklift.TireCondition;
						forkliftDTO.FuelTanksFull = forklift.FuelTanksFull;
						forkliftDTO.Lights = forklift.Lights;
						forkliftDTO.Alarms = forklift.Alarms;
						forkliftDTO.HoistingSystem = forklift.HoistingSystem;
						forkliftDTO.AbnormalNoise = forklift.AbnormalNoise;
						forkliftDTO.Brakes = forklift.Brakes;
						forkliftDTO.LiquidLevel = forklift.LiquidLevel;
						forkliftDTO.Instruments = forklift.Instruments;
						forkliftDTO.EngineDriveBelts = forklift.EngineDriveBelts;
						forkliftDTO.CarriageRollers = forklift.CarriageRollers;
						forkliftDTO.SteeringSystem = forklift.SteeringSystem;
						forkliftDTO.SeatBelt = forklift.SeatBelt;
						forkliftDTO.HoseofCoilCooling = forklift.HoseofCoilCooling;
						forkliftDTO.FirstAidBox = forklift.FirstAidBox;
						forkliftDTO.CrankShaft = forklift.CrankShaft;
						forkliftDTO.DriverSeat = forklift.DriverSeat;
						forkliftDTO.EngineV_belts = forklift.EngineV_belts;
						forkliftDTO.Wipers = forklift.Wipers;
						forkliftDTO.ExistingCorrosion = forklift.ExistingCorrosion;
						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.CleanAndTidyRemarks = forklift.CleanAndTidyRemarks;
						forkliftDTO.EngineOilLevelRemarks = forklift.EngineOilLevelRemarks;
						forkliftDTO.TransmissionOilLevelRemarks = forklift.TransmissionOilLevelRemarks;
						forkliftDTO.RadiatorWaterLevelRemarks = forklift.RadiatorWaterLevelRemarks;
						forkliftDTO.HydraulicOilLevelRemarks = forklift.HydraulicOilLevelRemarks;
						forkliftDTO.V_beltsTensionRemarks = forklift.V_beltsTensionRemarks;
						forkliftDTO.DrainWaterRemarks = forklift.DrainWaterRemarks;
						forkliftDTO.LeaksRemarks = forklift.LeaksRemarks;
						forkliftDTO.BatteryHolderRemarks = forklift.BatteryHolderRemarks;
						forkliftDTO.GaugesForCorrectReadingsRemarks = forklift.GaugesForCorrectReadingsRemarks;
						forkliftDTO.TyrePressureRemarks = forklift.TyrePressureRemarks;
						forkliftDTO.TyreConditionRemarks = forklift.TyreConditionRemarks;
						forkliftDTO.FuelTanksFullRemarks = forklift.FuelTanksFullRemarks;
						forkliftDTO.LightsRemarks = forklift.LightsRemarks;
						forkliftDTO.AlarmsRemarks = forklift.AlarmsRemarks;
						forkliftDTO.HoistingSystemRemarks = forklift.HoistingSystemRemarks;
						forkliftDTO.AbnormalNoiseRemarks = forklift.AbnormalNoiseRemarks;
						forkliftDTO.BrakesRemarks = forklift.BrakesRemarks;
						forkliftDTO.LiquidLevelRemarks = forklift.LiquidLevelRemarks;
						forkliftDTO.InstrumentsRemarks = forklift.InstrumentsRemarks;
						forkliftDTO.EngineDriveBeltsRemarks = forklift.EngineDriveBeltsRemarks;
						forkliftDTO.CarriageRollersRemarks = forklift.CarriageRollersRemarks;
						forkliftDTO.SteeringSystemRemarks = forklift.SteeringSystemRemarks;
						forkliftDTO.SeatBeltRemarks = forklift.SeatBeltRemarks;
						forkliftDTO.HoseofCoilCoolingRemarks = forklift.HoseofCoilCoolingRemarks;
						forkliftDTO.FirstAidBoxRemarks = forklift.FirstAidBoxRemarks;
						forkliftDTO.CrankShaftRemarks = forklift.CrankShaftRemarks;
						forkliftDTO.DriverSeatRemarks = forklift.DriverSeatRemarks;
						forkliftDTO.EngineV_beltsRemarks = forklift.EngineV_beltsRemarks;
						forkliftDTO.WipersRemarks = forklift.WipersRemarks;
						forkliftDTO.ExistingCorrosionRemarks = forklift.ExistingCorrosionRemarks;

						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.userName = forklift.user.UserName;
						newTemp.Add(forkliftDTO);
					}

					float countDetails = forkliftRepository.getall().Where(a => a.user.Id == UserId).Count();
					var result = new PageResult<ForkliftResponseDTO>
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
				return new PageResult<ForkliftResponseDTO>();

			}
			return new PageResult<ForkliftResponseDTO>();
		}


		[HttpGet("GetDataById/{ID:int}")]
		public ActionResult<ResultDTO> GetAllWithDataByID(int ID, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
			{
				Forklift forklift = forkliftRepository.getall().FirstOrDefault(a => a.Id == ID);
				if (forklift != null)
				{
					ForkliftResponseDTO forkliftDTO = new ForkliftResponseDTO();
					forkliftDTO.Id = forklift.Id;
					forkliftDTO.RigNo = forklift.Rig.Number;
					forkliftDTO.Date = forklift.Date;
					forkliftDTO.WellName = forklift.WellName;
					forkliftDTO.UnitNo = forklift.UnitNo;
					forkliftDTO.QHSEEngineer = forklift.QHSEEngineer;
					//forkliftDTO.HrsSinceOilChange = forklift.HrsSinceOilChange;
					forkliftDTO.CleanAndTidy = forklift.CleanAndTidy;
					forkliftDTO.EngineOilLevel = forklift.EngineOilLevel;
					forkliftDTO.TransmissionOilLevel = forklift.TransmissionOilLevel;
					forkliftDTO.RadiatorWaterLevel = forklift.RadiatorWaterLevel;
					forkliftDTO.HydraulicOilLevel = forklift.HydraulicOilLevel;
					forkliftDTO.V_beltsTension = forklift.V_beltsTension;
					forkliftDTO.DrainWater = forklift.DrainWater;
					forkliftDTO.Leaks = forklift.Leaks;
					forkliftDTO.BatteryHolder = forklift.BatteryHolder;
					forkliftDTO.GaugesForCorrectReadings = forklift.GaugesForCorrectReadings;
					forkliftDTO.TirePressure = forklift.TirePressure;
					forkliftDTO.TireCondition = forklift.TireCondition;
					forkliftDTO.FuelTanksFull = forklift.FuelTanksFull;
					forkliftDTO.Lights = forklift.Lights;
					forkliftDTO.Alarms = forklift.Alarms;
					forkliftDTO.HoistingSystem = forklift.HoistingSystem;
					forkliftDTO.AbnormalNoise = forklift.AbnormalNoise;
					forkliftDTO.Brakes = forklift.Brakes;
					forkliftDTO.LiquidLevel = forklift.LiquidLevel;
					forkliftDTO.Instruments = forklift.Instruments;
					forkliftDTO.EngineDriveBelts = forklift.EngineDriveBelts;
					forkliftDTO.CarriageRollers = forklift.CarriageRollers;
					forkliftDTO.SteeringSystem = forklift.SteeringSystem;
					forkliftDTO.SeatBelt = forklift.SeatBelt;
					forkliftDTO.HoseofCoilCooling = forklift.HoseofCoilCooling;
					forkliftDTO.FirstAidBox = forklift.FirstAidBox;
					forkliftDTO.CrankShaft = forklift.CrankShaft;
					forkliftDTO.DriverSeat = forklift.DriverSeat;
					forkliftDTO.EngineV_belts = forklift.EngineV_belts;
					forkliftDTO.Wipers = forklift.Wipers;
					forkliftDTO.ExistingCorrosion = forklift.ExistingCorrosion;
					forkliftDTO.DriverName = forklift.DriverName;
					forkliftDTO.CleanAndTidyRemarks = forklift.CleanAndTidyRemarks;
					forkliftDTO.EngineOilLevelRemarks = forklift.EngineOilLevelRemarks;
					forkliftDTO.TransmissionOilLevelRemarks = forklift.TransmissionOilLevelRemarks;
					forkliftDTO.RadiatorWaterLevelRemarks = forklift.RadiatorWaterLevelRemarks;
					forkliftDTO.HydraulicOilLevelRemarks = forklift.HydraulicOilLevelRemarks;
					forkliftDTO.V_beltsTensionRemarks = forklift.V_beltsTensionRemarks;
					forkliftDTO.DrainWaterRemarks = forklift.DrainWaterRemarks;
					forkliftDTO.LeaksRemarks = forklift.LeaksRemarks;
					forkliftDTO.BatteryHolderRemarks = forklift.BatteryHolderRemarks;
					forkliftDTO.GaugesForCorrectReadingsRemarks = forklift.GaugesForCorrectReadingsRemarks;
					forkliftDTO.TyrePressureRemarks = forklift.TyrePressureRemarks;
					forkliftDTO.TyreConditionRemarks = forklift.TyreConditionRemarks;
					forkliftDTO.FuelTanksFullRemarks = forklift.FuelTanksFullRemarks;
					forkliftDTO.LightsRemarks = forklift.LightsRemarks;
					forkliftDTO.AlarmsRemarks = forklift.AlarmsRemarks;
					forkliftDTO.HoistingSystemRemarks = forklift.HoistingSystemRemarks;
					forkliftDTO.AbnormalNoiseRemarks = forklift.AbnormalNoiseRemarks;
					forkliftDTO.BrakesRemarks = forklift.BrakesRemarks;
					forkliftDTO.LiquidLevelRemarks = forklift.LiquidLevelRemarks;
					forkliftDTO.InstrumentsRemarks = forklift.InstrumentsRemarks;
					forkliftDTO.EngineDriveBeltsRemarks = forklift.EngineDriveBeltsRemarks;
					forkliftDTO.CarriageRollersRemarks = forklift.CarriageRollersRemarks;
					forkliftDTO.SteeringSystemRemarks = forklift.SteeringSystemRemarks;
					forkliftDTO.SeatBeltRemarks = forklift.SeatBeltRemarks;
					forkliftDTO.HoseofCoilCoolingRemarks = forklift.HoseofCoilCoolingRemarks;
					forkliftDTO.FirstAidBoxRemarks = forklift.FirstAidBoxRemarks;
					forkliftDTO.CrankShaftRemarks = forklift.CrankShaftRemarks;
					forkliftDTO.DriverSeatRemarks = forklift.DriverSeatRemarks;
					forkliftDTO.EngineV_beltsRemarks = forklift.EngineV_beltsRemarks;
					forkliftDTO.WipersRemarks = forklift.WipersRemarks;
					forkliftDTO.ExistingCorrosionRemarks = forklift.ExistingCorrosionRemarks;

					forkliftDTO.DriverName = forklift.DriverName;
					forkliftDTO.userName = forklift.user.UserName;
					forkliftDTO.IsDeleted = forklift.IsDeleted;


					if (forkliftDTO != null)
					{

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = forkliftDTO;

						return result;
					}
				}

			}
			else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
			{
				Forklift forklift = forkliftRepository.getall().FirstOrDefault(a => a.Id == ID && a.user.Id == UserId);
				if (forklift != null)
				{
					ForkliftResponseDTO forkliftDTO = new ForkliftResponseDTO();
					forkliftDTO.Id = forklift.Id;
					forkliftDTO.RigNo = forklift.Rig.Number;
					forkliftDTO.Date = forklift.Date;
					forkliftDTO.WellName = forklift.WellName;
					forkliftDTO.UnitNo = forklift.UnitNo;
					forkliftDTO.QHSEEngineer = forklift.QHSEEngineer;
					//forkliftDTO.HrsSinceOilChange = forklift.HrsSinceOilChange;
					forkliftDTO.CleanAndTidy = forklift.CleanAndTidy;
					forkliftDTO.EngineOilLevel = forklift.EngineOilLevel;
					forkliftDTO.TransmissionOilLevel = forklift.TransmissionOilLevel;
					forkliftDTO.RadiatorWaterLevel = forklift.RadiatorWaterLevel;
					forkliftDTO.HydraulicOilLevel = forklift.HydraulicOilLevel;
					forkliftDTO.V_beltsTension = forklift.V_beltsTension;
					forkliftDTO.DrainWater = forklift.DrainWater;
					forkliftDTO.Leaks = forklift.Leaks;
					forkliftDTO.BatteryHolder = forklift.BatteryHolder;
					forkliftDTO.GaugesForCorrectReadings = forklift.GaugesForCorrectReadings;
					forkliftDTO.TirePressure = forklift.TirePressure;
					forkliftDTO.TireCondition = forklift.TireCondition;
					forkliftDTO.FuelTanksFull = forklift.FuelTanksFull;
					forkliftDTO.Lights = forklift.Lights;
					forkliftDTO.Alarms = forklift.Alarms;
					forkliftDTO.HoistingSystem = forklift.HoistingSystem;
					forkliftDTO.AbnormalNoise = forklift.AbnormalNoise;
					forkliftDTO.Brakes = forklift.Brakes;
					forkliftDTO.LiquidLevel = forklift.LiquidLevel;
					forkliftDTO.Instruments = forklift.Instruments;
					forkliftDTO.EngineDriveBelts = forklift.EngineDriveBelts;
					forkliftDTO.CarriageRollers = forklift.CarriageRollers;
					forkliftDTO.SteeringSystem = forklift.SteeringSystem;
					forkliftDTO.SeatBelt = forklift.SeatBelt;
					forkliftDTO.HoseofCoilCooling = forklift.HoseofCoilCooling;
					forkliftDTO.FirstAidBox = forklift.FirstAidBox;
					forkliftDTO.CrankShaft = forklift.CrankShaft;
					forkliftDTO.DriverSeat = forklift.DriverSeat;
					forkliftDTO.EngineV_belts = forklift.EngineV_belts;
					forkliftDTO.Wipers = forklift.Wipers;
					forkliftDTO.ExistingCorrosion = forklift.ExistingCorrosion;
					forkliftDTO.DriverName = forklift.DriverName;
					forkliftDTO.CleanAndTidyRemarks = forklift.CleanAndTidyRemarks;
					forkliftDTO.EngineOilLevelRemarks = forklift.EngineOilLevelRemarks;
					forkliftDTO.TransmissionOilLevelRemarks = forklift.TransmissionOilLevelRemarks;
					forkliftDTO.RadiatorWaterLevelRemarks = forklift.RadiatorWaterLevelRemarks;
					forkliftDTO.HydraulicOilLevelRemarks = forklift.HydraulicOilLevelRemarks;
					forkliftDTO.V_beltsTensionRemarks = forklift.V_beltsTensionRemarks;
					forkliftDTO.DrainWaterRemarks = forklift.DrainWaterRemarks;
					forkliftDTO.LeaksRemarks = forklift.LeaksRemarks;
					forkliftDTO.BatteryHolderRemarks = forklift.BatteryHolderRemarks;
					forkliftDTO.GaugesForCorrectReadingsRemarks = forklift.GaugesForCorrectReadingsRemarks;
					forkliftDTO.TyrePressureRemarks = forklift.TyrePressureRemarks;
					forkliftDTO.TyreConditionRemarks = forklift.TyreConditionRemarks;
					forkliftDTO.FuelTanksFullRemarks = forklift.FuelTanksFullRemarks;
					forkliftDTO.LightsRemarks = forklift.LightsRemarks;
					forkliftDTO.AlarmsRemarks = forklift.AlarmsRemarks;
					forkliftDTO.HoistingSystemRemarks = forklift.HoistingSystemRemarks;
					forkliftDTO.AbnormalNoiseRemarks = forklift.AbnormalNoiseRemarks;
					forkliftDTO.BrakesRemarks = forklift.BrakesRemarks;
					forkliftDTO.LiquidLevelRemarks = forklift.LiquidLevelRemarks;
					forkliftDTO.InstrumentsRemarks = forklift.InstrumentsRemarks;
					forkliftDTO.EngineDriveBeltsRemarks = forklift.EngineDriveBeltsRemarks;
					forkliftDTO.CarriageRollersRemarks = forklift.CarriageRollersRemarks;
					forkliftDTO.SteeringSystemRemarks = forklift.SteeringSystemRemarks;
					forkliftDTO.SeatBeltRemarks = forklift.SeatBeltRemarks;
					forkliftDTO.HoseofCoilCoolingRemarks = forklift.HoseofCoilCoolingRemarks;
					forkliftDTO.FirstAidBoxRemarks = forklift.FirstAidBoxRemarks;
					forkliftDTO.CrankShaftRemarks = forklift.CrankShaftRemarks;
					forkliftDTO.DriverSeatRemarks = forklift.DriverSeatRemarks;
					forkliftDTO.EngineV_beltsRemarks = forklift.EngineV_beltsRemarks;
					forkliftDTO.WipersRemarks = forklift.WipersRemarks;
					forkliftDTO.ExistingCorrosionRemarks = forklift.ExistingCorrosionRemarks;

					forkliftDTO.DriverName = forklift.DriverName;
					forkliftDTO.userName = forklift.user.UserName;
					forkliftDTO.IsDeleted = forklift.IsDeleted;


					if (forkliftDTO != null)
					{

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = forkliftDTO;

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
					List<ForkliftResponseDTO> forkliftDTOs = new List<ForkliftResponseDTO>();
					List<Forklift> forklifts = forkliftRepository.getall().Where(a => a.Date == date).ToList();
					foreach (Forklift forklift in forklifts)
					{
						ForkliftResponseDTO forkliftDTO = new ForkliftResponseDTO();
						forkliftDTO.Id = forklift.Id;
						forkliftDTO.RigNo = forklift.Rig.Number;
						forkliftDTO.Date = forklift.Date;
						forkliftDTO.WellName = forklift.WellName;
						forkliftDTO.UnitNo = forklift.UnitNo;
						forkliftDTO.QHSEEngineer = forklift.QHSEEngineer;
						//forkliftDTO.HrsSinceOilChange = forklift.HrsSinceOilChange;
						forkliftDTO.CleanAndTidy = forklift.CleanAndTidy;
						forkliftDTO.EngineOilLevel = forklift.EngineOilLevel;
						forkliftDTO.TransmissionOilLevel = forklift.TransmissionOilLevel;
						forkliftDTO.RadiatorWaterLevel = forklift.RadiatorWaterLevel;
						forkliftDTO.HydraulicOilLevel = forklift.HydraulicOilLevel;
						forkliftDTO.V_beltsTension = forklift.V_beltsTension;
						forkliftDTO.DrainWater = forklift.DrainWater;
						forkliftDTO.Leaks = forklift.Leaks;
						forkliftDTO.BatteryHolder = forklift.BatteryHolder;
						forkliftDTO.GaugesForCorrectReadings = forklift.GaugesForCorrectReadings;
						forkliftDTO.TirePressure = forklift.TirePressure;
						forkliftDTO.TireCondition = forklift.TireCondition;
						forkliftDTO.FuelTanksFull = forklift.FuelTanksFull;
						forkliftDTO.Lights = forklift.Lights;
						forkliftDTO.Alarms = forklift.Alarms;
						forkliftDTO.HoistingSystem = forklift.HoistingSystem;
						forkliftDTO.AbnormalNoise = forklift.AbnormalNoise;
						forkliftDTO.Brakes = forklift.Brakes;
						forkliftDTO.LiquidLevel = forklift.LiquidLevel;
						forkliftDTO.Instruments = forklift.Instruments;
						forkliftDTO.EngineDriveBelts = forklift.EngineDriveBelts;
						forkliftDTO.CarriageRollers = forklift.CarriageRollers;
						forkliftDTO.SteeringSystem = forklift.SteeringSystem;
						forkliftDTO.SeatBelt = forklift.SeatBelt;
						forkliftDTO.HoseofCoilCooling = forklift.HoseofCoilCooling;
						forkliftDTO.FirstAidBox = forklift.FirstAidBox;
						forkliftDTO.CrankShaft = forklift.CrankShaft;
						forkliftDTO.DriverSeat = forklift.DriverSeat;
						forkliftDTO.EngineV_belts = forklift.EngineV_belts;
						forkliftDTO.Wipers = forklift.Wipers;
						forkliftDTO.ExistingCorrosion = forklift.ExistingCorrosion;
						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.CleanAndTidyRemarks = forklift.CleanAndTidyRemarks;
						forkliftDTO.EngineOilLevelRemarks = forklift.EngineOilLevelRemarks;
						forkliftDTO.TransmissionOilLevelRemarks = forklift.TransmissionOilLevelRemarks;
						forkliftDTO.RadiatorWaterLevelRemarks = forklift.RadiatorWaterLevelRemarks;
						forkliftDTO.HydraulicOilLevelRemarks = forklift.HydraulicOilLevelRemarks;
						forkliftDTO.V_beltsTensionRemarks = forklift.V_beltsTensionRemarks;
						forkliftDTO.DrainWaterRemarks = forklift.DrainWaterRemarks;
						forkliftDTO.LeaksRemarks = forklift.LeaksRemarks;
						forkliftDTO.BatteryHolderRemarks = forklift.BatteryHolderRemarks;
						forkliftDTO.GaugesForCorrectReadingsRemarks = forklift.GaugesForCorrectReadingsRemarks;
						forkliftDTO.TyrePressureRemarks = forklift.TyrePressureRemarks;
						forkliftDTO.TyreConditionRemarks = forklift.TyreConditionRemarks;
						forkliftDTO.FuelTanksFullRemarks = forklift.FuelTanksFullRemarks;
						forkliftDTO.LightsRemarks = forklift.LightsRemarks;
						forkliftDTO.AlarmsRemarks = forklift.AlarmsRemarks;
						forkliftDTO.HoistingSystemRemarks = forklift.HoistingSystemRemarks;
						forkliftDTO.AbnormalNoiseRemarks = forklift.AbnormalNoiseRemarks;
						forkliftDTO.BrakesRemarks = forklift.BrakesRemarks;
						forkliftDTO.LiquidLevelRemarks = forklift.LiquidLevelRemarks;
						forkliftDTO.InstrumentsRemarks = forklift.InstrumentsRemarks;
						forkliftDTO.EngineDriveBeltsRemarks = forklift.EngineDriveBeltsRemarks;
						forkliftDTO.CarriageRollersRemarks = forklift.CarriageRollersRemarks;
						forkliftDTO.SteeringSystemRemarks = forklift.SteeringSystemRemarks;
						forkliftDTO.SeatBeltRemarks = forklift.SeatBeltRemarks;
						forkliftDTO.HoseofCoilCoolingRemarks = forklift.HoseofCoilCoolingRemarks;
						forkliftDTO.FirstAidBoxRemarks = forklift.FirstAidBoxRemarks;
						forkliftDTO.CrankShaftRemarks = forklift.CrankShaftRemarks;
						forkliftDTO.DriverSeatRemarks = forklift.DriverSeatRemarks;
						forkliftDTO.EngineV_beltsRemarks = forklift.EngineV_beltsRemarks;
						forkliftDTO.WipersRemarks = forklift.WipersRemarks;
						forkliftDTO.ExistingCorrosionRemarks = forklift.ExistingCorrosionRemarks;

						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.userName = forklift.user.UserName;
						forkliftDTOs.Add(forkliftDTO);

					}
					result.Message = "Success";
					result.Data = forkliftDTOs;
					result.Statescode = 200;
					return result;
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<ForkliftResponseDTO> forkliftDTOs = new List<ForkliftResponseDTO>();
					List<Forklift> forklifts = forkliftRepository.getall().Where(a => a.Date == date && a.user.Id == UserId).ToList();
					foreach (Forklift forklift in forklifts)
					{
						ForkliftResponseDTO forkliftDTO = new ForkliftResponseDTO();
						forkliftDTO.Id = forklift.Id;
						forkliftDTO.RigNo = forklift.Rig.Number;
						forkliftDTO.Date = forklift.Date;
						forkliftDTO.WellName = forklift.WellName;
						forkliftDTO.UnitNo = forklift.UnitNo;
						forkliftDTO.QHSEEngineer = forklift.QHSEEngineer;
						//forkliftDTO.HrsSinceOilChange = forklift.HrsSinceOilChange;
						forkliftDTO.CleanAndTidy = forklift.CleanAndTidy;
						forkliftDTO.EngineOilLevel = forklift.EngineOilLevel;
						forkliftDTO.TransmissionOilLevel = forklift.TransmissionOilLevel;
						forkliftDTO.RadiatorWaterLevel = forklift.RadiatorWaterLevel;
						forkliftDTO.HydraulicOilLevel = forklift.HydraulicOilLevel;
						forkliftDTO.V_beltsTension = forklift.V_beltsTension;
						forkliftDTO.DrainWater = forklift.DrainWater;
						forkliftDTO.Leaks = forklift.Leaks;
						forkliftDTO.BatteryHolder = forklift.BatteryHolder;
						forkliftDTO.GaugesForCorrectReadings = forklift.GaugesForCorrectReadings;
						forkliftDTO.TirePressure = forklift.TirePressure;
						forkliftDTO.TireCondition = forklift.TireCondition;
						forkliftDTO.FuelTanksFull = forklift.FuelTanksFull;
						forkliftDTO.Lights = forklift.Lights;
						forkliftDTO.Alarms = forklift.Alarms;
						forkliftDTO.HoistingSystem = forklift.HoistingSystem;
						forkliftDTO.AbnormalNoise = forklift.AbnormalNoise;
						forkliftDTO.Brakes = forklift.Brakes;
						forkliftDTO.LiquidLevel = forklift.LiquidLevel;
						forkliftDTO.Instruments = forklift.Instruments;
						forkliftDTO.EngineDriveBelts = forklift.EngineDriveBelts;
						forkliftDTO.CarriageRollers = forklift.CarriageRollers;
						forkliftDTO.SteeringSystem = forklift.SteeringSystem;
						forkliftDTO.SeatBelt = forklift.SeatBelt;
						forkliftDTO.HoseofCoilCooling = forklift.HoseofCoilCooling;
						forkliftDTO.FirstAidBox = forklift.FirstAidBox;
						forkliftDTO.CrankShaft = forklift.CrankShaft;
						forkliftDTO.DriverSeat = forklift.DriverSeat;
						forkliftDTO.EngineV_belts = forklift.EngineV_belts;
						forkliftDTO.Wipers = forklift.Wipers;
						forkliftDTO.ExistingCorrosion = forklift.ExistingCorrosion;
						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.CleanAndTidyRemarks = forklift.CleanAndTidyRemarks;
						forkliftDTO.EngineOilLevelRemarks = forklift.EngineOilLevelRemarks;
						forkliftDTO.TransmissionOilLevelRemarks = forklift.TransmissionOilLevelRemarks;
						forkliftDTO.RadiatorWaterLevelRemarks = forklift.RadiatorWaterLevelRemarks;
						forkliftDTO.HydraulicOilLevelRemarks = forklift.HydraulicOilLevelRemarks;
						forkliftDTO.V_beltsTensionRemarks = forklift.V_beltsTensionRemarks;
						forkliftDTO.DrainWaterRemarks = forklift.DrainWaterRemarks;
						forkliftDTO.LeaksRemarks = forklift.LeaksRemarks;
						forkliftDTO.BatteryHolderRemarks = forklift.BatteryHolderRemarks;
						forkliftDTO.GaugesForCorrectReadingsRemarks = forklift.GaugesForCorrectReadingsRemarks;
						forkliftDTO.TyrePressureRemarks = forklift.TyrePressureRemarks;
						forkliftDTO.TyreConditionRemarks = forklift.TyreConditionRemarks;
						forkliftDTO.FuelTanksFullRemarks = forklift.FuelTanksFullRemarks;
						forkliftDTO.LightsRemarks = forklift.LightsRemarks;
						forkliftDTO.AlarmsRemarks = forklift.AlarmsRemarks;
						forkliftDTO.HoistingSystemRemarks = forklift.HoistingSystemRemarks;
						forkliftDTO.AbnormalNoiseRemarks = forklift.AbnormalNoiseRemarks;
						forkliftDTO.BrakesRemarks = forklift.BrakesRemarks;
						forkliftDTO.LiquidLevelRemarks = forklift.LiquidLevelRemarks;
						forkliftDTO.InstrumentsRemarks = forklift.InstrumentsRemarks;
						forkliftDTO.EngineDriveBeltsRemarks = forklift.EngineDriveBeltsRemarks;
						forkliftDTO.CarriageRollersRemarks = forklift.CarriageRollersRemarks;
						forkliftDTO.SteeringSystemRemarks = forklift.SteeringSystemRemarks;
						forkliftDTO.SeatBeltRemarks = forklift.SeatBeltRemarks;
						forkliftDTO.HoseofCoilCoolingRemarks = forklift.HoseofCoilCoolingRemarks;
						forkliftDTO.FirstAidBoxRemarks = forklift.FirstAidBoxRemarks;
						forkliftDTO.CrankShaftRemarks = forklift.CrankShaftRemarks;
						forkliftDTO.DriverSeatRemarks = forklift.DriverSeatRemarks;
						forkliftDTO.EngineV_beltsRemarks = forklift.EngineV_beltsRemarks;
						forkliftDTO.WipersRemarks = forklift.WipersRemarks;
						forkliftDTO.ExistingCorrosionRemarks = forklift.ExistingCorrosionRemarks;

						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.userName = forklift.user.UserName;
						forkliftDTOs.Add(forkliftDTO);

					}
					result.Message = "Success";
					result.Data = forkliftDTOs;
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
		public ActionResult<ResultDTO> GetAllWithDataByDateAndRig(DateTime date, int rigNo, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<ForkliftResponseDTO> forkliftDTOs = new List<ForkliftResponseDTO>();
					List<Forklift> forklifts = forkliftRepository.getall().Where(a => a.Date == date && a.Rig.Number == rigNo).ToList();
					foreach (Forklift forklift in forklifts)
					{
						ForkliftResponseDTO forkliftDTO = new ForkliftResponseDTO();
						forkliftDTO.Id = forklift.Id;
						forkliftDTO.RigNo = forklift.Rig.Number;
						forkliftDTO.Date = forklift.Date;
						forkliftDTO.WellName = forklift.WellName;
						forkliftDTO.UnitNo = forklift.UnitNo;
						forkliftDTO.QHSEEngineer = forklift.QHSEEngineer;
						//forkliftDTO.HrsSinceOilChange = forklift.HrsSinceOilChange;
						forkliftDTO.CleanAndTidy = forklift.CleanAndTidy;
						forkliftDTO.EngineOilLevel = forklift.EngineOilLevel;
						forkliftDTO.TransmissionOilLevel = forklift.TransmissionOilLevel;
						forkliftDTO.RadiatorWaterLevel = forklift.RadiatorWaterLevel;
						forkliftDTO.HydraulicOilLevel = forklift.HydraulicOilLevel;
						forkliftDTO.V_beltsTension = forklift.V_beltsTension;
						forkliftDTO.DrainWater = forklift.DrainWater;
						forkliftDTO.Leaks = forklift.Leaks;
						forkliftDTO.BatteryHolder = forklift.BatteryHolder;
						forkliftDTO.GaugesForCorrectReadings = forklift.GaugesForCorrectReadings;
						forkliftDTO.TirePressure = forklift.TirePressure;
						forkliftDTO.TireCondition = forklift.TireCondition;
						forkliftDTO.FuelTanksFull = forklift.FuelTanksFull;
						forkliftDTO.Lights = forklift.Lights;
						forkliftDTO.Alarms = forklift.Alarms;
						forkliftDTO.HoistingSystem = forklift.HoistingSystem;
						forkliftDTO.AbnormalNoise = forklift.AbnormalNoise;
						forkliftDTO.Brakes = forklift.Brakes;
						forkliftDTO.LiquidLevel = forklift.LiquidLevel;
						forkliftDTO.Instruments = forklift.Instruments;
						forkliftDTO.EngineDriveBelts = forklift.EngineDriveBelts;
						forkliftDTO.CarriageRollers = forklift.CarriageRollers;
						forkliftDTO.SteeringSystem = forklift.SteeringSystem;
						forkliftDTO.SeatBelt = forklift.SeatBelt;
						forkliftDTO.HoseofCoilCooling = forklift.HoseofCoilCooling;
						forkliftDTO.FirstAidBox = forklift.FirstAidBox;
						forkliftDTO.CrankShaft = forklift.CrankShaft;
						forkliftDTO.DriverSeat = forklift.DriverSeat;
						forkliftDTO.EngineV_belts = forklift.EngineV_belts;
						forkliftDTO.Wipers = forklift.Wipers;
						forkliftDTO.ExistingCorrosion = forklift.ExistingCorrosion;
						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.CleanAndTidyRemarks = forklift.CleanAndTidyRemarks;
						forkliftDTO.EngineOilLevelRemarks = forklift.EngineOilLevelRemarks;
						forkliftDTO.TransmissionOilLevelRemarks = forklift.TransmissionOilLevelRemarks;
						forkliftDTO.RadiatorWaterLevelRemarks = forklift.RadiatorWaterLevelRemarks;
						forkliftDTO.HydraulicOilLevelRemarks = forklift.HydraulicOilLevelRemarks;
						forkliftDTO.V_beltsTensionRemarks = forklift.V_beltsTensionRemarks;
						forkliftDTO.DrainWaterRemarks = forklift.DrainWaterRemarks;
						forkliftDTO.LeaksRemarks = forklift.LeaksRemarks;
						forkliftDTO.BatteryHolderRemarks = forklift.BatteryHolderRemarks;
						forkliftDTO.GaugesForCorrectReadingsRemarks = forklift.GaugesForCorrectReadingsRemarks;
						forkliftDTO.TyrePressureRemarks = forklift.TyrePressureRemarks;
						forkliftDTO.TyreConditionRemarks = forklift.TyreConditionRemarks;
						forkliftDTO.FuelTanksFullRemarks = forklift.FuelTanksFullRemarks;
						forkliftDTO.LightsRemarks = forklift.LightsRemarks;
						forkliftDTO.AlarmsRemarks = forklift.AlarmsRemarks;
						forkliftDTO.HoistingSystemRemarks = forklift.HoistingSystemRemarks;
						forkliftDTO.AbnormalNoiseRemarks = forklift.AbnormalNoiseRemarks;
						forkliftDTO.BrakesRemarks = forklift.BrakesRemarks;
						forkliftDTO.LiquidLevelRemarks = forklift.LiquidLevelRemarks;
						forkliftDTO.InstrumentsRemarks = forklift.InstrumentsRemarks;
						forkliftDTO.EngineDriveBeltsRemarks = forklift.EngineDriveBeltsRemarks;
						forkliftDTO.CarriageRollersRemarks = forklift.CarriageRollersRemarks;
						forkliftDTO.SteeringSystemRemarks = forklift.SteeringSystemRemarks;
						forkliftDTO.SeatBeltRemarks = forklift.SeatBeltRemarks;
						forkliftDTO.HoseofCoilCoolingRemarks = forklift.HoseofCoilCoolingRemarks;
						forkliftDTO.FirstAidBoxRemarks = forklift.FirstAidBoxRemarks;
						forkliftDTO.CrankShaftRemarks = forklift.CrankShaftRemarks;
						forkliftDTO.DriverSeatRemarks = forklift.DriverSeatRemarks;
						forkliftDTO.EngineV_beltsRemarks = forklift.EngineV_beltsRemarks;
						forkliftDTO.WipersRemarks = forklift.WipersRemarks;
						forkliftDTO.ExistingCorrosionRemarks = forklift.ExistingCorrosionRemarks;

						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.userName = forklift.user.UserName;
						forkliftDTOs.Add(forkliftDTO);

					}
					result.Message = "Success";
					result.Data = forkliftDTOs;
					result.Statescode = 200;
					return result;
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<ForkliftResponseDTO> forkliftDTOs = new List<ForkliftResponseDTO>();
					List<Forklift> forklifts = forkliftRepository.getall().Where(a => a.Date == date && a.user.Id == UserId && a.Rig.Number == rigNo).ToList();
					foreach (Forklift forklift in forklifts)
					{
						ForkliftResponseDTO forkliftDTO = new ForkliftResponseDTO();
						forkliftDTO.Id = forklift.Id;
						forkliftDTO.RigNo = forklift.Rig.Number;
						forkliftDTO.Date = forklift.Date;
						forkliftDTO.WellName = forklift.WellName;
						forkliftDTO.UnitNo = forklift.UnitNo;
						forkliftDTO.QHSEEngineer = forklift.QHSEEngineer;
						//forkliftDTO.HrsSinceOilChange = forklift.HrsSinceOilChange;
						forkliftDTO.CleanAndTidy = forklift.CleanAndTidy;
						forkliftDTO.EngineOilLevel = forklift.EngineOilLevel;
						forkliftDTO.TransmissionOilLevel = forklift.TransmissionOilLevel;
						forkliftDTO.RadiatorWaterLevel = forklift.RadiatorWaterLevel;
						forkliftDTO.HydraulicOilLevel = forklift.HydraulicOilLevel;
						forkliftDTO.V_beltsTension = forklift.V_beltsTension;
						forkliftDTO.DrainWater = forklift.DrainWater;
						forkliftDTO.Leaks = forklift.Leaks;
						forkliftDTO.BatteryHolder = forklift.BatteryHolder;
						forkliftDTO.GaugesForCorrectReadings = forklift.GaugesForCorrectReadings;
						forkliftDTO.TirePressure = forklift.TirePressure;
						forkliftDTO.TireCondition = forklift.TireCondition;
						forkliftDTO.FuelTanksFull = forklift.FuelTanksFull;
						forkliftDTO.Lights = forklift.Lights;
						forkliftDTO.Alarms = forklift.Alarms;
						forkliftDTO.HoistingSystem = forklift.HoistingSystem;
						forkliftDTO.AbnormalNoise = forklift.AbnormalNoise;
						forkliftDTO.Brakes = forklift.Brakes;
						forkliftDTO.LiquidLevel = forklift.LiquidLevel;
						forkliftDTO.Instruments = forklift.Instruments;
						forkliftDTO.EngineDriveBelts = forklift.EngineDriveBelts;
						forkliftDTO.CarriageRollers = forklift.CarriageRollers;
						forkliftDTO.SteeringSystem = forklift.SteeringSystem;
						forkliftDTO.SeatBelt = forklift.SeatBelt;
						forkliftDTO.HoseofCoilCooling = forklift.HoseofCoilCooling;
						forkliftDTO.FirstAidBox = forklift.FirstAidBox;
						forkliftDTO.CrankShaft = forklift.CrankShaft;
						forkliftDTO.DriverSeat = forklift.DriverSeat;
						forkliftDTO.EngineV_belts = forklift.EngineV_belts;
						forkliftDTO.Wipers = forklift.Wipers;
						forkliftDTO.ExistingCorrosion = forklift.ExistingCorrosion;
						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.CleanAndTidyRemarks = forklift.CleanAndTidyRemarks;
						forkliftDTO.EngineOilLevelRemarks = forklift.EngineOilLevelRemarks;
						forkliftDTO.TransmissionOilLevelRemarks = forklift.TransmissionOilLevelRemarks;
						forkliftDTO.RadiatorWaterLevelRemarks = forklift.RadiatorWaterLevelRemarks;
						forkliftDTO.HydraulicOilLevelRemarks = forklift.HydraulicOilLevelRemarks;
						forkliftDTO.V_beltsTensionRemarks = forklift.V_beltsTensionRemarks;
						forkliftDTO.DrainWaterRemarks = forklift.DrainWaterRemarks;
						forkliftDTO.LeaksRemarks = forklift.LeaksRemarks;
						forkliftDTO.BatteryHolderRemarks = forklift.BatteryHolderRemarks;
						forkliftDTO.GaugesForCorrectReadingsRemarks = forklift.GaugesForCorrectReadingsRemarks;
						forkliftDTO.TyrePressureRemarks = forklift.TyrePressureRemarks;
						forkliftDTO.TyreConditionRemarks = forklift.TyreConditionRemarks;
						forkliftDTO.FuelTanksFullRemarks = forklift.FuelTanksFullRemarks;
						forkliftDTO.LightsRemarks = forklift.LightsRemarks;
						forkliftDTO.AlarmsRemarks = forklift.AlarmsRemarks;
						forkliftDTO.HoistingSystemRemarks = forklift.HoistingSystemRemarks;
						forkliftDTO.AbnormalNoiseRemarks = forklift.AbnormalNoiseRemarks;
						forkliftDTO.BrakesRemarks = forklift.BrakesRemarks;
						forkliftDTO.LiquidLevelRemarks = forklift.LiquidLevelRemarks;
						forkliftDTO.InstrumentsRemarks = forklift.InstrumentsRemarks;
						forkliftDTO.EngineDriveBeltsRemarks = forklift.EngineDriveBeltsRemarks;
						forkliftDTO.CarriageRollersRemarks = forklift.CarriageRollersRemarks;
						forkliftDTO.SteeringSystemRemarks = forklift.SteeringSystemRemarks;
						forkliftDTO.SeatBeltRemarks = forklift.SeatBeltRemarks;
						forkliftDTO.HoseofCoilCoolingRemarks = forklift.HoseofCoilCoolingRemarks;
						forkliftDTO.FirstAidBoxRemarks = forklift.FirstAidBoxRemarks;
						forkliftDTO.CrankShaftRemarks = forklift.CrankShaftRemarks;
						forkliftDTO.DriverSeatRemarks = forklift.DriverSeatRemarks;
						forkliftDTO.EngineV_beltsRemarks = forklift.EngineV_beltsRemarks;
						forkliftDTO.WipersRemarks = forklift.WipersRemarks;
						forkliftDTO.ExistingCorrosionRemarks = forklift.ExistingCorrosionRemarks;

						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.userName = forklift.user.UserName;
						forkliftDTOs.Add(forkliftDTO);

					}
					result.Message = "Success";
					result.Data = forkliftDTOs;
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
					List<ForkliftResponseDTO> forkliftDTOs = new List<ForkliftResponseDTO>();
					List<Forklift> forklifts = forkliftRepository.getall().Where(a => a.RigId == rigId).ToList();
					foreach (Forklift forklift in forklifts)
					{
						ForkliftResponseDTO forkliftDTO = new ForkliftResponseDTO();
						forkliftDTO.Id = forklift.Id;
						forkliftDTO.RigNo = forklift.Rig.Number;
						forkliftDTO.Date = forklift.Date;
						forkliftDTO.WellName = forklift.WellName;
						forkliftDTO.UnitNo = forklift.UnitNo;
						forkliftDTO.QHSEEngineer = forklift.QHSEEngineer;
						//forkliftDTO.HrsSinceOilChange = forklift.HrsSinceOilChange;
						forkliftDTO.CleanAndTidy = forklift.CleanAndTidy;
						forkliftDTO.EngineOilLevel = forklift.EngineOilLevel;
						forkliftDTO.TransmissionOilLevel = forklift.TransmissionOilLevel;
						forkliftDTO.RadiatorWaterLevel = forklift.RadiatorWaterLevel;
						forkliftDTO.HydraulicOilLevel = forklift.HydraulicOilLevel;
						forkliftDTO.V_beltsTension = forklift.V_beltsTension;
						forkliftDTO.DrainWater = forklift.DrainWater;
						forkliftDTO.Leaks = forklift.Leaks;
						forkliftDTO.BatteryHolder = forklift.BatteryHolder;
						forkliftDTO.GaugesForCorrectReadings = forklift.GaugesForCorrectReadings;
						forkliftDTO.TirePressure = forklift.TirePressure;
						forkliftDTO.TireCondition = forklift.TireCondition;
						forkliftDTO.FuelTanksFull = forklift.FuelTanksFull;
						forkliftDTO.Lights = forklift.Lights;
						forkliftDTO.Alarms = forklift.Alarms;
						forkliftDTO.HoistingSystem = forklift.HoistingSystem;
						forkliftDTO.AbnormalNoise = forklift.AbnormalNoise;
						forkliftDTO.Brakes = forklift.Brakes;
						forkliftDTO.LiquidLevel = forklift.LiquidLevel;
						forkliftDTO.Instruments = forklift.Instruments;
						forkliftDTO.EngineDriveBelts = forklift.EngineDriveBelts;
						forkliftDTO.CarriageRollers = forklift.CarriageRollers;
						forkliftDTO.SteeringSystem = forklift.SteeringSystem;
						forkliftDTO.SeatBelt = forklift.SeatBelt;
						forkliftDTO.HoseofCoilCooling = forklift.HoseofCoilCooling;
						forkliftDTO.FirstAidBox = forklift.FirstAidBox;
						forkliftDTO.CrankShaft = forklift.CrankShaft;
						forkliftDTO.DriverSeat = forklift.DriverSeat;
						forkliftDTO.EngineV_belts = forklift.EngineV_belts;
						forkliftDTO.Wipers = forklift.Wipers;
						forkliftDTO.ExistingCorrosion = forklift.ExistingCorrosion;
						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.CleanAndTidyRemarks = forklift.CleanAndTidyRemarks;
						forkliftDTO.EngineOilLevelRemarks = forklift.EngineOilLevelRemarks;
						forkliftDTO.TransmissionOilLevelRemarks = forklift.TransmissionOilLevelRemarks;
						forkliftDTO.RadiatorWaterLevelRemarks = forklift.RadiatorWaterLevelRemarks;
						forkliftDTO.HydraulicOilLevelRemarks = forklift.HydraulicOilLevelRemarks;
						forkliftDTO.V_beltsTensionRemarks = forklift.V_beltsTensionRemarks;
						forkliftDTO.DrainWaterRemarks = forklift.DrainWaterRemarks;
						forkliftDTO.LeaksRemarks = forklift.LeaksRemarks;
						forkliftDTO.BatteryHolderRemarks = forklift.BatteryHolderRemarks;
						forkliftDTO.GaugesForCorrectReadingsRemarks = forklift.GaugesForCorrectReadingsRemarks;
						forkliftDTO.TyrePressureRemarks = forklift.TyrePressureRemarks;
						forkliftDTO.TyreConditionRemarks = forklift.TyreConditionRemarks;
						forkliftDTO.FuelTanksFullRemarks = forklift.FuelTanksFullRemarks;
						forkliftDTO.LightsRemarks = forklift.LightsRemarks;
						forkliftDTO.AlarmsRemarks = forklift.AlarmsRemarks;
						forkliftDTO.HoistingSystemRemarks = forklift.HoistingSystemRemarks;
						forkliftDTO.AbnormalNoiseRemarks = forklift.AbnormalNoiseRemarks;
						forkliftDTO.BrakesRemarks = forklift.BrakesRemarks;
						forkliftDTO.LiquidLevelRemarks = forklift.LiquidLevelRemarks;
						forkliftDTO.InstrumentsRemarks = forklift.InstrumentsRemarks;
						forkliftDTO.EngineDriveBeltsRemarks = forklift.EngineDriveBeltsRemarks;
						forkliftDTO.CarriageRollersRemarks = forklift.CarriageRollersRemarks;
						forkliftDTO.SteeringSystemRemarks = forklift.SteeringSystemRemarks;
						forkliftDTO.SeatBeltRemarks = forklift.SeatBeltRemarks;
						forkliftDTO.HoseofCoilCoolingRemarks = forklift.HoseofCoilCoolingRemarks;
						forkliftDTO.FirstAidBoxRemarks = forklift.FirstAidBoxRemarks;
						forkliftDTO.CrankShaftRemarks = forklift.CrankShaftRemarks;
						forkliftDTO.DriverSeatRemarks = forklift.DriverSeatRemarks;
						forkliftDTO.EngineV_beltsRemarks = forklift.EngineV_beltsRemarks;
						forkliftDTO.WipersRemarks = forklift.WipersRemarks;
						forkliftDTO.ExistingCorrosionRemarks = forklift.ExistingCorrosionRemarks;

						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.userName = forklift.user.UserName;
						forkliftDTOs.Add(forkliftDTO);

					}
					result.Message = "Success";
					result.Data = forkliftDTOs;
					result.Statescode = 200;
					return result;
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<ForkliftResponseDTO> forkliftDTOs = new List<ForkliftResponseDTO>();
					List<Forklift> forklifts = forkliftRepository.getall().Where(a => a.RigId == rigId && a.user.Id == UserId).ToList();
					foreach (Forklift forklift in forklifts)
					{
						ForkliftResponseDTO forkliftDTO = new ForkliftResponseDTO();
						forkliftDTO.Id = forklift.Id;
						forkliftDTO.RigNo = forklift.Rig.Number;
						forkliftDTO.Date = forklift.Date;
						forkliftDTO.WellName = forklift.WellName;
						forkliftDTO.UnitNo = forklift.UnitNo;
						forkliftDTO.QHSEEngineer = forklift.QHSEEngineer;
						//forkliftDTO.HrsSinceOilChange = forklift.HrsSinceOilChange;
						forkliftDTO.CleanAndTidy = forklift.CleanAndTidy;
						forkliftDTO.EngineOilLevel = forklift.EngineOilLevel;
						forkliftDTO.TransmissionOilLevel = forklift.TransmissionOilLevel;
						forkliftDTO.RadiatorWaterLevel = forklift.RadiatorWaterLevel;
						forkliftDTO.HydraulicOilLevel = forklift.HydraulicOilLevel;
						forkliftDTO.V_beltsTension = forklift.V_beltsTension;
						forkliftDTO.DrainWater = forklift.DrainWater;
						forkliftDTO.Leaks = forklift.Leaks;
						forkliftDTO.BatteryHolder = forklift.BatteryHolder;
						forkliftDTO.GaugesForCorrectReadings = forklift.GaugesForCorrectReadings;
						forkliftDTO.TirePressure = forklift.TirePressure;
						forkliftDTO.TireCondition = forklift.TireCondition;
						forkliftDTO.FuelTanksFull = forklift.FuelTanksFull;
						forkliftDTO.Lights = forklift.Lights;
						forkliftDTO.Alarms = forklift.Alarms;
						forkliftDTO.HoistingSystem = forklift.HoistingSystem;
						forkliftDTO.AbnormalNoise = forklift.AbnormalNoise;
						forkliftDTO.Brakes = forklift.Brakes;
						forkliftDTO.LiquidLevel = forklift.LiquidLevel;
						forkliftDTO.Instruments = forklift.Instruments;
						forkliftDTO.EngineDriveBelts = forklift.EngineDriveBelts;
						forkliftDTO.CarriageRollers = forklift.CarriageRollers;
						forkliftDTO.SteeringSystem = forklift.SteeringSystem;
						forkliftDTO.SeatBelt = forklift.SeatBelt;
						forkliftDTO.HoseofCoilCooling = forklift.HoseofCoilCooling;
						forkliftDTO.FirstAidBox = forklift.FirstAidBox;
						forkliftDTO.CrankShaft = forklift.CrankShaft;
						forkliftDTO.DriverSeat = forklift.DriverSeat;
						forkliftDTO.EngineV_belts = forklift.EngineV_belts;
						forkliftDTO.Wipers = forklift.Wipers;
						forkliftDTO.ExistingCorrosion = forklift.ExistingCorrosion;
						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.CleanAndTidyRemarks = forklift.CleanAndTidyRemarks;
						forkliftDTO.EngineOilLevelRemarks = forklift.EngineOilLevelRemarks;
						forkliftDTO.TransmissionOilLevelRemarks = forklift.TransmissionOilLevelRemarks;
						forkliftDTO.RadiatorWaterLevelRemarks = forklift.RadiatorWaterLevelRemarks;
						forkliftDTO.HydraulicOilLevelRemarks = forklift.HydraulicOilLevelRemarks;
						forkliftDTO.V_beltsTensionRemarks = forklift.V_beltsTensionRemarks;
						forkliftDTO.DrainWaterRemarks = forklift.DrainWaterRemarks;
						forkliftDTO.LeaksRemarks = forklift.LeaksRemarks;
						forkliftDTO.BatteryHolderRemarks = forklift.BatteryHolderRemarks;
						forkliftDTO.GaugesForCorrectReadingsRemarks = forklift.GaugesForCorrectReadingsRemarks;
						forkliftDTO.TyrePressureRemarks = forklift.TyrePressureRemarks;
						forkliftDTO.TyreConditionRemarks = forklift.TyreConditionRemarks;
						forkliftDTO.FuelTanksFullRemarks = forklift.FuelTanksFullRemarks;
						forkliftDTO.LightsRemarks = forklift.LightsRemarks;
						forkliftDTO.AlarmsRemarks = forklift.AlarmsRemarks;
						forkliftDTO.HoistingSystemRemarks = forklift.HoistingSystemRemarks;
						forkliftDTO.AbnormalNoiseRemarks = forklift.AbnormalNoiseRemarks;
						forkliftDTO.BrakesRemarks = forklift.BrakesRemarks;
						forkliftDTO.LiquidLevelRemarks = forklift.LiquidLevelRemarks;
						forkliftDTO.InstrumentsRemarks = forklift.InstrumentsRemarks;
						forkliftDTO.EngineDriveBeltsRemarks = forklift.EngineDriveBeltsRemarks;
						forkliftDTO.CarriageRollersRemarks = forklift.CarriageRollersRemarks;
						forkliftDTO.SteeringSystemRemarks = forklift.SteeringSystemRemarks;
						forkliftDTO.SeatBeltRemarks = forklift.SeatBeltRemarks;
						forkliftDTO.HoseofCoilCoolingRemarks = forklift.HoseofCoilCoolingRemarks;
						forkliftDTO.FirstAidBoxRemarks = forklift.FirstAidBoxRemarks;
						forkliftDTO.CrankShaftRemarks = forklift.CrankShaftRemarks;
						forkliftDTO.DriverSeatRemarks = forklift.DriverSeatRemarks;
						forkliftDTO.EngineV_beltsRemarks = forklift.EngineV_beltsRemarks;
						forkliftDTO.WipersRemarks = forklift.WipersRemarks;
						forkliftDTO.ExistingCorrosionRemarks = forklift.ExistingCorrosionRemarks;

						forkliftDTO.DriverName = forklift.DriverName;
						forkliftDTO.userName = forklift.user.UserName;
						forkliftDTOs.Add(forkliftDTO);

					}
					result.Message = "Success";
					result.Data = forkliftDTOs;
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
					Forklift forklift = forkliftRepo.getall().FirstOrDefault(a => a.Id == ID);
					ForkliftDTO forkliftDTO = new ForkliftDTO();
					forkliftDTO.Id = forklift.Id;
					forkliftDTO.RigId = forklift.RigId;
					forkliftDTO.Date = forklift.Date;
					forkliftDTO.WellName = forklift.WellName;
					forkliftDTO.UnitNo = forklift.UnitNo;
					forkliftDTO.QHSEEngineer = forklift.QHSEEngineer;
					//forkliftDTO.HrsSinceOilChange = forklift.HrsSinceOilChange;
					forkliftDTO.CleanAndTidy = forklift.CleanAndTidy;
					forkliftDTO.EngineOilLevel = forklift.EngineOilLevel;
					forkliftDTO.TransmissionOilLevel = forklift.TransmissionOilLevel;
					forkliftDTO.RadiatorWaterLevel = forklift.RadiatorWaterLevel;
					forkliftDTO.HydraulicOilLevel = forklift.HydraulicOilLevel;
					forkliftDTO.V_beltsTension = forklift.V_beltsTension;
					forkliftDTO.DrainWater = forklift.DrainWater;
					forkliftDTO.Leaks = forklift.Leaks;
					forkliftDTO.BatteryHolder = forklift.BatteryHolder;
					forkliftDTO.GaugesForCorrectReadings = forklift.GaugesForCorrectReadings;
					forkliftDTO.TirePressure = forklift.TirePressure;
					forkliftDTO.TireCondition = forklift.TireCondition;
					forkliftDTO.FuelTanksFull = forklift.FuelTanksFull;
					forkliftDTO.Lights = forklift.Lights;
					forkliftDTO.Alarms = forklift.Alarms;
					forkliftDTO.HoistingSystem = forklift.HoistingSystem;
					forkliftDTO.AbnormalNoise = forklift.AbnormalNoise;
					forkliftDTO.Brakes = forklift.Brakes;
					forkliftDTO.LiquidLevel = forklift.LiquidLevel;
					forkliftDTO.Instruments = forklift.Instruments;
					forkliftDTO.EngineDriveBelts = forklift.EngineDriveBelts;
					forkliftDTO.CarriageRollers = forklift.CarriageRollers;
					forkliftDTO.SteeringSystem = forklift.SteeringSystem;
					forkliftDTO.SeatBelt = forklift.SeatBelt;
					forkliftDTO.HoseofCoilCooling = forklift.HoseofCoilCooling;
					forkliftDTO.FirstAidBox = forklift.FirstAidBox;
					forkliftDTO.CrankShaft = forklift.CrankShaft;
					forkliftDTO.DriverSeat = forklift.DriverSeat;
					forkliftDTO.EngineV_belts = forklift.EngineV_belts;
					forkliftDTO.Wipers = forklift.Wipers;
					forkliftDTO.ExistingCorrosion = forklift.ExistingCorrosion;
					forkliftDTO.DriverName = forklift.DriverName;
					forkliftDTO.CleanAndTidyRemarks = forklift.CleanAndTidyRemarks;
					forkliftDTO.EngineOilLevelRemarks = forklift.EngineOilLevelRemarks;
					forkliftDTO.TransmissionOilLevelRemarks = forklift.TransmissionOilLevelRemarks;
					forkliftDTO.RadiatorWaterLevelRemarks = forklift.RadiatorWaterLevelRemarks;
					forkliftDTO.HydraulicOilLevelRemarks = forklift.HydraulicOilLevelRemarks;
					forkliftDTO.V_beltsTensionRemarks = forklift.V_beltsTensionRemarks;
					forkliftDTO.DrainWaterRemarks = forklift.DrainWaterRemarks;
					forkliftDTO.LeaksRemarks = forklift.LeaksRemarks;
					forkliftDTO.BatteryHolderRemarks = forklift.BatteryHolderRemarks;
					forkliftDTO.GaugesForCorrectReadingsRemarks = forklift.GaugesForCorrectReadingsRemarks;
					forkliftDTO.TyrePressureRemarks = forklift.TyrePressureRemarks;
					forkliftDTO.TyreConditionRemarks = forklift.TyreConditionRemarks;
					forkliftDTO.FuelTanksFullRemarks = forklift.FuelTanksFullRemarks;
					forkliftDTO.LightsRemarks = forklift.LightsRemarks;
					forkliftDTO.AlarmsRemarks = forklift.AlarmsRemarks;
					forkliftDTO.HoistingSystemRemarks = forklift.HoistingSystemRemarks;
					forkliftDTO.AbnormalNoiseRemarks = forklift.AbnormalNoiseRemarks;
					forkliftDTO.BrakesRemarks = forklift.BrakesRemarks;
					forkliftDTO.LiquidLevelRemarks = forklift.LiquidLevelRemarks;
					forkliftDTO.InstrumentsRemarks = forklift.InstrumentsRemarks;
					forkliftDTO.EngineDriveBeltsRemarks = forklift.EngineDriveBeltsRemarks;
					forkliftDTO.CarriageRollersRemarks = forklift.CarriageRollersRemarks;
					forkliftDTO.SteeringSystemRemarks = forklift.SteeringSystemRemarks;
					forkliftDTO.SeatBeltRemarks = forklift.SeatBeltRemarks;
					forkliftDTO.HoseofCoilCoolingRemarks = forklift.HoseofCoilCoolingRemarks;
					forkliftDTO.FirstAidBoxRemarks = forklift.FirstAidBoxRemarks;
					forkliftDTO.CrankShaftRemarks = forklift.CrankShaftRemarks;
					forkliftDTO.DriverSeatRemarks = forklift.DriverSeatRemarks;
					forkliftDTO.EngineV_beltsRemarks = forklift.EngineV_beltsRemarks;
					forkliftDTO.WipersRemarks = forklift.WipersRemarks;
					forkliftDTO.ExistingCorrosionRemarks = forklift.ExistingCorrosionRemarks;

					forkliftDTO.DriverName = forklift.DriverName;
					forkliftDTO.userID = forklift.userID;

					result.Message = "Success";
					result.Data = forkliftDTO;
					result.Statescode = 200;
					return result;

				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					Forklift forklift = forkliftRepo.getall().FirstOrDefault(a => a.Id == ID && a.userID == UserId);
					ForkliftDTO forkliftDTO = new ForkliftDTO();
					forkliftDTO.Id = forklift.Id;
					forkliftDTO.RigId = forklift.RigId;
					forkliftDTO.Date = forklift.Date;
					forkliftDTO.WellName = forklift.WellName;
					forkliftDTO.UnitNo = forklift.UnitNo;
					forkliftDTO.QHSEEngineer = forklift.QHSEEngineer;
					//forkliftDTO.HrsSinceOilChange = forklift.HrsSinceOilChange;
					forkliftDTO.CleanAndTidy = forklift.CleanAndTidy;
					forkliftDTO.EngineOilLevel = forklift.EngineOilLevel;
					forkliftDTO.TransmissionOilLevel = forklift.TransmissionOilLevel;
					forkliftDTO.RadiatorWaterLevel = forklift.RadiatorWaterLevel;
					forkliftDTO.HydraulicOilLevel = forklift.HydraulicOilLevel;
					forkliftDTO.V_beltsTension = forklift.V_beltsTension;
					forkliftDTO.DrainWater = forklift.DrainWater;
					forkliftDTO.Leaks = forklift.Leaks;
					forkliftDTO.BatteryHolder = forklift.BatteryHolder;
					forkliftDTO.GaugesForCorrectReadings = forklift.GaugesForCorrectReadings;
					forkliftDTO.TirePressure = forklift.TirePressure;
					forkliftDTO.TireCondition = forklift.TireCondition;
					forkliftDTO.FuelTanksFull = forklift.FuelTanksFull;
					forkliftDTO.Lights = forklift.Lights;
					forkliftDTO.Alarms = forklift.Alarms;
					forkliftDTO.HoistingSystem = forklift.HoistingSystem;
					forkliftDTO.AbnormalNoise = forklift.AbnormalNoise;
					forkliftDTO.Brakes = forklift.Brakes;
					forkliftDTO.LiquidLevel = forklift.LiquidLevel;
					forkliftDTO.Instruments = forklift.Instruments;
					forkliftDTO.EngineDriveBelts = forklift.EngineDriveBelts;
					forkliftDTO.CarriageRollers = forklift.CarriageRollers;
					forkliftDTO.SteeringSystem = forklift.SteeringSystem;
					forkliftDTO.SeatBelt = forklift.SeatBelt;
					forkliftDTO.HoseofCoilCooling = forklift.HoseofCoilCooling;
					forkliftDTO.FirstAidBox = forklift.FirstAidBox;
					forkliftDTO.CrankShaft = forklift.CrankShaft;
					forkliftDTO.DriverSeat = forklift.DriverSeat;
					forkliftDTO.EngineV_belts = forklift.EngineV_belts;
					forkliftDTO.Wipers = forklift.Wipers;
					forkliftDTO.ExistingCorrosion = forklift.ExistingCorrosion;
					forkliftDTO.DriverName = forklift.DriverName;
					forkliftDTO.CleanAndTidyRemarks = forklift.CleanAndTidyRemarks;
					forkliftDTO.EngineOilLevelRemarks = forklift.EngineOilLevelRemarks;
					forkliftDTO.TransmissionOilLevelRemarks = forklift.TransmissionOilLevelRemarks;
					forkliftDTO.RadiatorWaterLevelRemarks = forklift.RadiatorWaterLevelRemarks;
					forkliftDTO.HydraulicOilLevelRemarks = forklift.HydraulicOilLevelRemarks;
					forkliftDTO.V_beltsTensionRemarks = forklift.V_beltsTensionRemarks;
					forkliftDTO.DrainWaterRemarks = forklift.DrainWaterRemarks;
					forkliftDTO.LeaksRemarks = forklift.LeaksRemarks;
					forkliftDTO.BatteryHolderRemarks = forklift.BatteryHolderRemarks;
					forkliftDTO.GaugesForCorrectReadingsRemarks = forklift.GaugesForCorrectReadingsRemarks;
					forkliftDTO.TyrePressureRemarks = forklift.TyrePressureRemarks;
					forkliftDTO.TyreConditionRemarks = forklift.TyreConditionRemarks;
					forkliftDTO.FuelTanksFullRemarks = forklift.FuelTanksFullRemarks;
					forkliftDTO.LightsRemarks = forklift.LightsRemarks;
					forkliftDTO.AlarmsRemarks = forklift.AlarmsRemarks;
					forkliftDTO.HoistingSystemRemarks = forklift.HoistingSystemRemarks;
					forkliftDTO.AbnormalNoiseRemarks = forklift.AbnormalNoiseRemarks;
					forkliftDTO.BrakesRemarks = forklift.BrakesRemarks;
					forkliftDTO.LiquidLevelRemarks = forklift.LiquidLevelRemarks;
					forkliftDTO.InstrumentsRemarks = forklift.InstrumentsRemarks;
					forkliftDTO.EngineDriveBeltsRemarks = forklift.EngineDriveBeltsRemarks;
					forkliftDTO.CarriageRollersRemarks = forklift.CarriageRollersRemarks;
					forkliftDTO.SteeringSystemRemarks = forklift.SteeringSystemRemarks;
					forkliftDTO.SeatBeltRemarks = forklift.SeatBeltRemarks;
					forkliftDTO.HoseofCoilCoolingRemarks = forklift.HoseofCoilCoolingRemarks;
					forkliftDTO.FirstAidBoxRemarks = forklift.FirstAidBoxRemarks;
					forkliftDTO.CrankShaftRemarks = forklift.CrankShaftRemarks;
					forkliftDTO.DriverSeatRemarks = forklift.DriverSeatRemarks;
					forkliftDTO.EngineV_beltsRemarks = forklift.EngineV_beltsRemarks;
					forkliftDTO.WipersRemarks = forklift.WipersRemarks;
					forkliftDTO.ExistingCorrosionRemarks = forklift.ExistingCorrosionRemarks;

					forkliftDTO.DriverName = forklift.DriverName;
					forkliftDTO.userID = forklift.userID;

					result.Message = "Success";
					result.Data = forkliftDTO;
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
		public ActionResult<ResultDTO> AddForklift(ForkliftDTO forkliftDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					Forklift forklift = new Forklift();
					forklift.Id = forkliftDTO.Id;
					forklift.RigId = forkliftDTO.RigId;
					forklift.Date = forkliftDTO.Date;
					forklift.WellName = forkliftDTO.WellName;
					forklift.UnitNo = forkliftDTO.UnitNo;
					forklift.QHSEEngineer = forkliftDTO.QHSEEngineer;
					//forklift.HrsSinceOilChange = forkliftDTO.HrsSinceOilChange;
					forklift.CleanAndTidy = forkliftDTO.CleanAndTidy;
					forklift.EngineOilLevel = forkliftDTO.EngineOilLevel;
					forklift.TransmissionOilLevel = forkliftDTO.TransmissionOilLevel;
					forklift.RadiatorWaterLevel = forkliftDTO.RadiatorWaterLevel;
					forklift.HydraulicOilLevel = forkliftDTO.HydraulicOilLevel;
					forklift.V_beltsTension = forkliftDTO.V_beltsTension;
					forklift.DrainWater = forkliftDTO.DrainWater;
					forklift.Leaks = forkliftDTO.Leaks;
					forklift.BatteryHolder = forkliftDTO.BatteryHolder;
					forklift.GaugesForCorrectReadings = forkliftDTO.GaugesForCorrectReadings;
					forklift.TirePressure = forkliftDTO.TirePressure;
					forklift.TireCondition = forkliftDTO.TireCondition;
					forklift.FuelTanksFull = forkliftDTO.FuelTanksFull;
					forklift.Lights = forkliftDTO.Lights;
					forklift.Alarms = forkliftDTO.Alarms;
					forklift.HoistingSystem = forkliftDTO.HoistingSystem;
					forklift.AbnormalNoise = forkliftDTO.AbnormalNoise;
					forklift.Brakes = forkliftDTO.Brakes;
					forklift.LiquidLevel = forkliftDTO.LiquidLevel;
					forklift.Instruments = forkliftDTO.Instruments;
					forklift.EngineDriveBelts = forkliftDTO.EngineDriveBelts;
					forklift.CarriageRollers = forkliftDTO.CarriageRollers;
					forklift.SteeringSystem = forkliftDTO.SteeringSystem;
					forklift.SeatBelt = forkliftDTO.SeatBelt;
					forklift.HoseofCoilCooling = forkliftDTO.HoseofCoilCooling;
					forklift.FirstAidBox = forkliftDTO.FirstAidBox;
					forklift.CrankShaft = forkliftDTO.CrankShaft;
					forklift.DriverSeat = forkliftDTO.DriverSeat;
					forklift.EngineV_belts = forkliftDTO.EngineV_belts;
					forklift.Wipers = forkliftDTO.Wipers;
					forklift.ExistingCorrosion = forkliftDTO.ExistingCorrosion;
					forklift.DriverName = forkliftDTO.DriverName;
					forklift.CleanAndTidyRemarks = forkliftDTO.CleanAndTidyRemarks;
					forklift.EngineOilLevelRemarks = forkliftDTO.EngineOilLevelRemarks;
					forklift.TransmissionOilLevelRemarks = forkliftDTO.TransmissionOilLevelRemarks;
					forklift.RadiatorWaterLevelRemarks = forkliftDTO.RadiatorWaterLevelRemarks;
					forklift.HydraulicOilLevelRemarks = forkliftDTO.HydraulicOilLevelRemarks;
					forklift.V_beltsTensionRemarks = forkliftDTO.V_beltsTensionRemarks;
					forklift.DrainWaterRemarks = forkliftDTO.DrainWaterRemarks;
					forklift.LeaksRemarks = forkliftDTO.LeaksRemarks;
					forklift.BatteryHolderRemarks = forkliftDTO.BatteryHolderRemarks;
					forklift.GaugesForCorrectReadingsRemarks = forkliftDTO.GaugesForCorrectReadingsRemarks;
					forklift.TyrePressureRemarks = forkliftDTO.TyrePressureRemarks;
					forklift.TyreConditionRemarks = forkliftDTO.TyreConditionRemarks;
					forklift.FuelTanksFullRemarks = forkliftDTO.FuelTanksFullRemarks;
					forklift.LightsRemarks = forkliftDTO.LightsRemarks;
					forklift.AlarmsRemarks = forkliftDTO.AlarmsRemarks;
					forklift.HoistingSystemRemarks = forkliftDTO.HoistingSystemRemarks;
					forklift.AbnormalNoiseRemarks = forkliftDTO.AbnormalNoiseRemarks;
					forklift.BrakesRemarks = forkliftDTO.BrakesRemarks;
					forklift.LiquidLevelRemarks = forkliftDTO.LiquidLevelRemarks;
					forklift.InstrumentsRemarks = forkliftDTO.InstrumentsRemarks;
					forklift.EngineDriveBeltsRemarks = forkliftDTO.EngineDriveBeltsRemarks;
					forklift.CarriageRollersRemarks = forkliftDTO.CarriageRollersRemarks;
					forklift.SteeringSystemRemarks = forkliftDTO.SteeringSystemRemarks;
					forklift.SeatBeltRemarks = forkliftDTO.SeatBeltRemarks;
					forklift.HoseofCoilCoolingRemarks = forkliftDTO.HoseofCoilCoolingRemarks;
					forklift.FirstAidBoxRemarks = forkliftDTO.FirstAidBoxRemarks;
					forklift.CrankShaftRemarks = forkliftDTO.CrankShaftRemarks;
					forklift.DriverSeatRemarks = forkliftDTO.DriverSeatRemarks;
					forklift.EngineV_beltsRemarks = forkliftDTO.EngineV_beltsRemarks;
					forklift.WipersRemarks = forkliftDTO.WipersRemarks;
					forklift.ExistingCorrosionRemarks = forkliftDTO.ExistingCorrosionRemarks;
					forklift.DriverName = forkliftDTO.DriverName;
					forklift.userID = forkliftDTO.userID;
					forkliftRepo.create(forklift);

					result.Message = "Success";
					result.Data = forklift;
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
		public ActionResult<ResultDTO> Put(int id, ForkliftDTO newForklift) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					Forklift orgForklift = forkliftRepo.getbyid(id);
					newForklift.Id = orgForklift.Id;
					orgForklift.RigId = newForklift.RigId;
					orgForklift.Date = newForklift.Date;
					orgForklift.WellName = newForklift.WellName;
					orgForklift.UnitNo = newForklift.UnitNo;
					orgForklift.QHSEEngineer = newForklift.QHSEEngineer;
					//orgForklift.HrsSinceOilChange = newForklift.HrsSinceOilChange;
					orgForklift.CleanAndTidy = newForklift.CleanAndTidy;
					orgForklift.EngineOilLevel = newForklift.EngineOilLevel;
					orgForklift.TransmissionOilLevel = newForklift.TransmissionOilLevel;
					orgForklift.RadiatorWaterLevel = newForklift.RadiatorWaterLevel;
					orgForklift.HydraulicOilLevel = newForklift.HydraulicOilLevel;
					orgForklift.V_beltsTension = newForklift.V_beltsTension;
					orgForklift.DrainWater = newForklift.DrainWater;
					orgForklift.Leaks = newForklift.Leaks;
					orgForklift.BatteryHolder = newForklift.BatteryHolder;
					orgForklift.GaugesForCorrectReadings = newForklift.GaugesForCorrectReadings;
					orgForklift.TirePressure = newForklift.TirePressure;
					orgForklift.TireCondition = newForklift.TireCondition;
					orgForklift.FuelTanksFull = newForklift.FuelTanksFull;
					orgForklift.Lights = newForklift.Lights;
					orgForklift.Alarms = newForklift.Alarms;
					orgForklift.HoistingSystem = newForklift.HoistingSystem;
					orgForklift.AbnormalNoise = newForklift.AbnormalNoise;
					orgForklift.Brakes = newForklift.Brakes;
					orgForklift.LiquidLevel = newForklift.LiquidLevel;
					orgForklift.Instruments = newForklift.Instruments;
					orgForklift.EngineDriveBelts = newForklift.EngineDriveBelts;
					orgForklift.CarriageRollers = newForklift.CarriageRollers;
					orgForklift.SteeringSystem = newForklift.SteeringSystem;
					orgForklift.SeatBelt = newForklift.SeatBelt;
					orgForklift.HoseofCoilCooling = newForklift.HoseofCoilCooling;
					orgForklift.FirstAidBox = newForklift.FirstAidBox;
					orgForklift.CrankShaft = newForklift.CrankShaft;
					orgForklift.DriverSeat = newForklift.DriverSeat;
					orgForklift.EngineV_belts = newForklift.EngineV_belts;
					orgForklift.Wipers = newForklift.Wipers;
					orgForklift.ExistingCorrosion = newForklift.ExistingCorrosion;
					orgForklift.DriverName = newForklift.DriverName;
					orgForklift.CleanAndTidyRemarks = newForklift.CleanAndTidyRemarks;
					orgForklift.EngineOilLevelRemarks = newForklift.EngineOilLevelRemarks;
					orgForklift.TransmissionOilLevelRemarks = newForklift.TransmissionOilLevelRemarks;
					orgForklift.RadiatorWaterLevelRemarks = newForklift.RadiatorWaterLevelRemarks;
					orgForklift.HydraulicOilLevelRemarks = newForklift.HydraulicOilLevelRemarks;
					orgForklift.V_beltsTensionRemarks = newForklift.V_beltsTensionRemarks;
					orgForklift.DrainWaterRemarks = newForklift.DrainWaterRemarks;
					orgForklift.LeaksRemarks = newForklift.LeaksRemarks;
					orgForklift.BatteryHolderRemarks = newForklift.BatteryHolderRemarks;
					orgForklift.GaugesForCorrectReadingsRemarks = newForklift.GaugesForCorrectReadingsRemarks;
					orgForklift.TyrePressureRemarks = newForklift.TyrePressureRemarks;
					orgForklift.TyreConditionRemarks = newForklift.TyreConditionRemarks;
					orgForklift.FuelTanksFullRemarks = newForklift.FuelTanksFullRemarks;
					orgForklift.LightsRemarks = newForklift.LightsRemarks;
					orgForklift.AlarmsRemarks = newForklift.AlarmsRemarks;
					orgForklift.HoistingSystemRemarks = newForklift.HoistingSystemRemarks;
					orgForklift.AbnormalNoiseRemarks = newForklift.AbnormalNoiseRemarks;
					orgForklift.BrakesRemarks = newForklift.BrakesRemarks;
					orgForklift.LiquidLevelRemarks = newForklift.LiquidLevelRemarks;
					orgForklift.InstrumentsRemarks = newForklift.InstrumentsRemarks;
					orgForklift.EngineDriveBeltsRemarks = newForklift.EngineDriveBeltsRemarks;
					orgForklift.CarriageRollersRemarks = newForklift.CarriageRollersRemarks;
					orgForklift.SteeringSystemRemarks = newForklift.SteeringSystemRemarks;
					orgForklift.SeatBeltRemarks = newForklift.SeatBeltRemarks;
					orgForklift.HoseofCoilCoolingRemarks = newForklift.HoseofCoilCoolingRemarks;
					orgForklift.FirstAidBoxRemarks = newForklift.FirstAidBoxRemarks;
					orgForklift.CrankShaftRemarks = newForklift.CrankShaftRemarks;
					orgForklift.DriverSeatRemarks = newForklift.DriverSeatRemarks;
					orgForklift.EngineV_beltsRemarks = newForklift.EngineV_beltsRemarks;
					orgForklift.WipersRemarks = newForklift.WipersRemarks;
					orgForklift.ExistingCorrosionRemarks = newForklift.ExistingCorrosionRemarks;

					orgForklift.DriverName = newForklift.DriverName;
					orgForklift.userID = newForklift.userID;


					forkliftRepo.update(orgForklift);
					result.Data = orgForklift;
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
				Forklift forklift = forkliftRepo.getbyid(id);
				forklift.IsDeleted = true;
				forkliftRepo.update(forklift);
				result.Data = forklift;
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
