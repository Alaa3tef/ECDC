using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class HandoverExcelDTO
	{
		[Column(TypeName = "date")]
		public DateTime ShiftDateFrom { get; set; }

		[Column(TypeName = "date")]
		public DateTime ShiftDateTo { get; set; }

		public int RigNo { get; set; }


		public string WellName { get; set; }

		public string Client { get; set; }

		public int LeavingEmpCode { get; set; }
		public string LeavingEmpName { get; set; }
		public int ComingEmpCode { get; set; }
		public string ComingEmpName { get; set; }

		public int StopCards { get; set; }

		public int MonthlyStopCards { get; set; }

		public int OpenStopCards { get; set; }

		public int Drills { get; set; }

		public int MonthlyDrills { get; set; }

		public int SafetyAlerts { get; set; }

		public int MonthlySafetyAlerts { get; set; }

		public int WeeklyInspection { get; set; }

		public int InternalAudit { get; set; }

		public int ExternalAudit { get; set; }

		public int MedicalReport { get; set; }

		public int TrainingMatrix { get; set; }

		public int RigMove { get; set; }

		public int IncidentReport { get; set; }

		public int TrackingSheetClosedPoints { get; set; }

		public int PotentialHazardReport { get; set; }

		public List<ShiftDrillTypesExcelDTO> ShiftDrillTypes { get; set; } = new List<ShiftDrillTypesExcelDTO>();
		public List<VisitsExcelDTO> Visits { get; set; } = new List<VisitsExcelDTO>();
		public List<HSEInventoryExcelDTO> HSEInventory { get; set; } = new List<HSEInventoryExcelDTO>();
		public List<HSEEquipmentExcelDTO> HSEEquipment { get; set; } = new List<HSEEquipmentExcelDTO>();
		public List<MaterialRequestedExcelDTO> MaterialRequested { get; set; } = new List<MaterialRequestedExcelDTO>();

		public string ShiftBrief { get; set; }

		public string QHSEEngineer { get; set; }

		public string userName { get; set; }
	}
}
