using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class Handover : ISoftDeleteRepository
	{
		public int Id { get; set; }

		[Column(TypeName = "date")]
		public DateTime ShiftDateFrom { get; set; }

		[Column(TypeName = "date")]
		public DateTime ShiftDateTo { get; set; }

		[ForeignKey("Rig")]
		public int RigId { get; set; }

		public virtual Rig Rig { get; set; }

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

		public List<ShiftDrillTypes> ShiftDrillTypes { get; set; }
		public List<Visits> Visits { get; set; }
		public List<HSEInventory> HSEInventory { get; set; }
		public List<HSEEquipment> HSEEquipment { get; set; }
		public List<MaterialRequested>? MaterialRequested { get; set; }

		public string ShiftBrief { get; set; }

		public string QHSEEngineer { get; set; }

		[ForeignKey("user")]
		public string userID { get; set; }

		public virtual IdentityUser user { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
