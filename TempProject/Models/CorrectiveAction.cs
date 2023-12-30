using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class CorrectiveAction : ISoftDeleteRepository
	{
		public int Id { get; set; }

		public int ReportNo { get; set; }

		[ForeignKey("Rig")]
		public int RigId { get; set; }

		public virtual Rig Rig { get; set; }

		public string DescriptionOfNonConformity { get; set; }

		[ForeignKey("Standard")]
		public int StandardId { get; set; }

		public virtual Standard Standard { get; set; }

		public string ClauseNo { get; set; }

		public string ObjectiveEvidence { get; set; }

		public virtual List<CorrectiveAndObservation> CorrectiveAndObservation { get; set; }

		public string? IfOtherObservation { get; set; }
		
		[DefaultValue(false)]
		public bool UpdateRisk { get; set; }

		public string? IfUpdate { get; set; }

		[DefaultValue(false)]
		public bool ManagementOfChange { get; set; }

		public string? IfManagementOfChange { get; set; }

		public string NameRasiedBy { get; set; }

		public string SigRasiedBy { get; set; }

		public DateTime DateRaisedBy { get; set; }

		public virtual List<CorrectiveAndRootCauses> CorrectiveAndRootCauses { get; set; }

		public string? IfOtherRootCause { get; set; }

		public virtual List<CorrectiveDataTable>? CorrectiveDataTable { get; set; }

		public string? Comment { get; set; }

		public virtual List<CorrectiveImages> Images { get; set; } = new List<CorrectiveImages>();

		public string Q_ManagerSig { get; set; }

		[ForeignKey("user")]
		public string userID { get; set; }

		public virtual IdentityUser user { get; set; }

		public string FormStatus { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
