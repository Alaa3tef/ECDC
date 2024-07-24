using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Threading.Tasks;
using TempProject.Repository;

namespace TempProject.Models
{
    public class ForkliftDTO
	{
		public int Id { get; set; }

		public int RigId { get; set; }

		[Column(TypeName = "date")]
		public DateTime Date { get; set; }

		public string WellName { get; set; }
		public string UnitNo { get; set; }
		public string QHSEEngineer { get; set; }
		//public string HrsSinceOilChange { get; set; }
		public string CleanAndTidy { get; set; }
		public string EngineOilLevel { get; set; }
		public string TransmissionOilLevel { get; set; }
		public string RadiatorWaterLevel { get; set; }
		public string HydraulicOilLevel { get; set; }
		public string V_beltsTension { get; set; }
		public string DrainWater { get; set; }
		public string Leaks { get; set; }
		public string BatteryHolder { get; set; }
		public string GaugesForCorrectReadings { get; set; }
		public string TirePressure { get; set; }
		public string TireCondition { get; set; }
		public string FuelTanksFull { get; set; }
		public string Lights { get; set; }
		public string Alarms { get; set; }
		public string HoistingSystem { get; set; }
		public string AbnormalNoise { get; set; }
		public string Brakes { get; set; }
		public string LiquidLevel { get; set; }
		public string Instruments { get; set; }
		public string EngineDriveBelts { get; set; }
		public string CarriageRollers { get; set; }
		public string SteeringSystem { get; set; }
		public string SeatBelt { get; set; }
		public string HoseofCoilCooling { get; set; }
		public string FirstAidBox { get; set; }
		public string CrankShaft { get; set; }
		public string DriverSeat { get; set; }
		public string EngineV_belts { get; set; }
		public string Wipers { get; set; }
		public string ExistingCorrosion { get; set; }
		public string DriverName { get; set; }
		public string? CleanAndTidyRemarks { get; set; }
		public string? EngineOilLevelRemarks { get; set; }
		public string? TransmissionOilLevelRemarks { get; set; }
		public string? RadiatorWaterLevelRemarks { get; set; }
		public string? HydraulicOilLevelRemarks { get; set; }
		public string? V_beltsTensionRemarks { get; set; }
		public string? DrainWaterRemarks { get; set; }
		public string? LeaksRemarks { get; set; }
		public string? BatteryHolderRemarks { get; set; }
		public string? GaugesForCorrectReadingsRemarks { get; set; }
		public string? TyrePressureRemarks { get; set; }
		public string? TyreConditionRemarks { get; set; }
		public string? FuelTanksFullRemarks { get; set; }
		public string? LightsRemarks { get; set; }
		public string? AlarmsRemarks { get; set; }
		public string? HoistingSystemRemarks { get; set; }
		public string? AbnormalNoiseRemarks { get; set; }
		public string? BrakesRemarks { get; set; }
		public string? LiquidLevelRemarks { get; set; }
		public string? InstrumentsRemarks { get; set; }
		public string? EngineDriveBeltsRemarks { get; set; }
		public string? CarriageRollersRemarks { get; set; }
		public string? SteeringSystemRemarks { get; set; }
		public string? SeatBeltRemarks { get; set; }
		public string? HoseofCoilCoolingRemarks { get; set; }
		public string? FirstAidBoxRemarks { get; set; }
		public string? CrankShaftRemarks { get; set; }
		public string? DriverSeatRemarks { get; set; }
		public string? EngineV_beltsRemarks { get; set; }
		public string? WipersRemarks { get; set; }
		public string? ExistingCorrosionRemarks { get; set; }

		public string userID { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }

	}
}
