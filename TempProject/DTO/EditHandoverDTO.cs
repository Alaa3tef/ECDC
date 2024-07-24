using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class EditHandoverDTO
	{
		public int Id { get; set; }

		[Column(TypeName = "date")]
		public DateTime ShiftDateFrom { get; set; }

		[Column(TypeName = "date")]
		public DateTime ShiftDateTo { get; set; }

		public int RigId { get; set; }


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

		public List<ShiftDrillTypesDTO> ShiftDrillTypes { get; set; } = new List<ShiftDrillTypesDTO>();
		public List<VisitsDTO> Visits { get; set; } = new List<VisitsDTO>();
		public List<HSEInventoryDTO> HSEInventory { get; set; } = new List<HSEInventoryDTO>();
		public List<HSEEquipmentDTO> HSEEquipment { get; set; } = new List<HSEEquipmentDTO>();
		public List<MaterialRequestedDTO> MaterialRequested { get; set; } = new List<MaterialRequestedDTO>();

		public List<ShiftDrillTypesDTO>? OtherShiftDrillTypes { get; set; } = new List<ShiftDrillTypesDTO>();
		public List<VisitsDTO>? OtherVisits { get; set; } = new List<VisitsDTO>();
		public List<HSEInventoryDTO>? OtherHSEInventory { get; set; } = new List<HSEInventoryDTO>();
		public List<HSEEquipmentDTO>? OtherHSEEquipment { get; set; } = new List<HSEEquipmentDTO>();
		public List<MaterialRequestedDTO>? OtherMaterialRequested { get; set; } = new List<MaterialRequestedDTO>();

		public string ShiftBrief { get; set; }

		public string QHSEEngineer { get; set; }

		public string userID { get; set; }


		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
