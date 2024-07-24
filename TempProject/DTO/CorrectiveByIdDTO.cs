using System.ComponentModel;
using TempProject.Models;

namespace TempProject.DTO
{
	public class CorrectiveByIdDTO
	{
		public int Id { get; set; }

		public int ReportNo { get; set; }

		public string Title { get; set; }

		//public int RigId { get; set; }

		public int FormResponsabilityId { get; set; }

		public string DescriptionOfNonConformity { get; set; }

		public int StandardId { get; set; }

		public string ClauseNo { get; set; }

		public string ObjectiveEvidence { get; set; }


		public string? IfOtherObservation { get; set; }

		public bool UpdateRisk { get; set; }

		public string? IfUpdate { get; set; }

		public bool ManagementOfChange { get; set; }

		public string? IfManagementOfChange { get; set; }

		public string NameRasiedBy { get; set; }

		public string SigRasiedBy { get; set; }

		public DateTime DateRaisedBy { get; set; }


		public string? IfOtherRootCause { get; set; }


		public string? Comment { get; set; }

		public List<CorrectiveImages>? Images { get; set; } = new List<CorrectiveImages>();

		public List<CorrectiveAndObservation> CorrectiveObservation { get; set; } = new List<CorrectiveAndObservation> { };

		public List<CorrectiveAndRootCauses> RootCauses { get; set; } = new List<CorrectiveAndRootCauses> { };

		public int? sn1 { get; set; }
		public string? CorrectiveActionSelected1 { get; set; }

		public string? Action1 { get; set; }

		public string? Responsible1 { get; set; }

		public DateTime? SuggestedDate1 { get; set; }

		public DateTime? AchievementDate1 { get; set; }

		public string? FollowUpAudit1 { get; set; }

		public bool Status1 { get; set; }

		public int? sn2 { get; set; }
		public string? CorrectiveActionSelected2 { get; set; }

		public string? Action2 { get; set; }

		public string? Responsible2 { get; set; }

		public DateTime? SuggestedDate2 { get; set; }

		public DateTime? AchievementDate2 { get; set; }

		public string? FollowUpAudit2 { get; set; }

		public bool Status2 { get; set; }

		public int? sn3 { get; set; }
		public string? CorrectiveActionSelected3 { get; set; }

		public string? Action3 { get; set; }

		public string? Responsible3 { get; set; }

		public DateTime? SuggestedDate3 { get; set; }

		public DateTime? AchievementDate3 { get; set; }

		public string? FollowUpAudit3 { get; set; }

		public bool Status3 { get; set; }

		public int? sn4 { get; set; }
		public string? CorrectiveActionSelected4 { get; set; }

		public string? Action4 { get; set; }

		public string? Responsible4 { get; set; }

		public DateTime? SuggestedDate4 { get; set; }

		public DateTime? AchievementDate4 { get; set; }

		public string? FollowUpAudit4 { get; set; }

		public bool Status4 { get; set; }


		public string? Q_ManagerSig { get; set; }

		//public string? QHSEEngineer { get; set; }

		public string userID { get; set; }
		
		public string FormStatus { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
