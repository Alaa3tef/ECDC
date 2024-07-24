using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using TempProject.Repository;

namespace TempProject.Models
{
    public class Crane : ISoftDeleteRepository
    {
        public int Id {  get; set; }
        
		[ForeignKey("Rig")]
        public int RigId { get; set; }
        
		public virtual Rig Rig { get; set; }
        

        [Column(TypeName = "date")]
        public DateTime Date { get; set;}

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
		public string LoadComputer { get; set; }
		public string GaugesForCcorrectReadings { get; set; }
		public string TirePressure { get; set; }
		public string FuelTanksFull { get; set; }
		public string WireRopes { get; set; }
		public string SwingBrake { get; set; }
		public string TestLimitSwitches { get; set; }
		public string TestOutriggers { get; set; }
		public string AbnormalNoise { get; set; }
		public string ServiceBrakes { get; set; }
		public string Sheaves { get; set; }
		public string SpoolingOfWire { get; set; }
		public string Hookcondition { get; set; }
		public string BoomSections { get; set; }
		public string EngineV_belts { get; set; }
		public string WiringVisually { get; set; }
		public string LoadIndicator { get; set; }
		public string AudibleAlarm { get; set; }
		public string LoadLimiting { get; set; }
		public string BoomAngle { get; set; }
		public string LimitSwitch { get; set; }
		public string EmergencyShutDown { get; set; }
		public string OperatingReturn { get; set; }
		public string OperatingControls { get; set; }
		public string HeadLight { get; set; }
		public string ReverseAlarm { get; set; }
		public string ParkingBrake { get; set; }
		public string SafetyBelt { get; set; }
		public string DriverSeat { get; set; }
		public string Wipers { get; set; }
		public string ExistingCorrosion { get; set; }
		public string TireBolts { get; set; }
		public string SafeLoadIndicator { get; set; }
		public string ScreenCurtains { get; set; }
		public string Outrigger { get; set; }
		public string StrangeSound { get; set; }

		public string? CleanAndTidyRemarks { get; set; }
		public string? EngineOilLevelRemarks { get; set; }
		public string? TransmissionOilLevelRemarks { get; set; }
		public string? RadiatorWaterLevelRemarks { get; set; }
		public string? HydraulicOilLevelRemarks { get; set; }
		public string? V_beltsTensionRemarks { get; set; }
		public string? DrainWaterRemarks { get; set; }
		public string? LeaksRemarks { get; set; }
		public string? BatteryHolderRemarks { get; set; }
		public string? LoadComputerRemarks { get; set; }
		public string? GaugesForCcorrectReadingsRemarks { get; set; }
		public string? TirePressureRemarks { get; set; }
		public string? FuelTanksFullRemarks { get; set; }
		public string? WireRopesRemarks { get; set; }
		public string? SwingBrakeRemarks { get; set; }
		public string? TestLimitSwitchesRemarks { get; set; }
		public string? TestOutriggersRemarks { get; set; }
		public string? AbnormalNoiseRemarks { get; set; }
		public string? ServiceBrakesRemarks { get; set; }
		public string? SheavesRemarks { get; set; }
		public string? SpoolingOfWireRemarks { get; set; }
		public string? HookconditionRemarks { get; set; }
		public string? BoomSectionsRemarks { get; set; }
		public string? EngineV_beltsRemarks { get; set; }
		public string? WiringVisuallyRemarks { get; set; }
		public string? LoadIndicatorRemarks { get; set; }
		public string? AudibleAlarmRemarks { get; set; }
		public string? LoadLimitingRemarks { get; set; }
		public string? BoomAngleRemarks { get; set; }
		public string? LimitSwitchRemarks { get; set; }
		public string? EmergencyShutDownRemarks { get; set; }
		public string? OperatingReturnRemarks { get; set; }
		public string? OperatingControlsRemarks { get; set; }
		public string? HeadLightRemarks { get; set; }
		public string? ReverseAlarmRemarks { get; set; }
		public string? ParkingBrakeRemarks { get; set; }
		public string? SafetyBeltRemarks { get; set; }
		public string? DriverSeatRemarks { get; set; }
		public string? WipersRemarks { get; set; }
		public string? ExistingCorrosionRemarks { get; set; }
		public string? TireBoltsRemarks { get; set; }
		public string? SafeLoadIndicatorRemarks { get; set; }
		public string? ScreenCurtainsRemarks { get; set; }
		public string? OutriggerRemarks { get; set; }
		public string? StrangeSoundRemarks { get; set; }
		public string DriverName { get; set; }


		[ForeignKey("user")]
		public string userID { get; set; }
		
		public virtual IdentityUser user { get; set; }
        
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
