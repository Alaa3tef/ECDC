using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using TempProject.Repository;

namespace TempProject.Models
{
	public class CorrectiveDataTable : ISoftDeleteRepository
	{
		public int Id { get; set; }

		public int? SN { get; set; }

		public string? CorrectiveActionSelected { get; set; }

		public string? Action { get; set; }

		public string? Responsible { get; set; }

		public DateTime? SuggestedDate { get; set; }

		public DateTime? AchievementDate { get; set; }

		public string? FollowUpAudit { get; set; }

		[DefaultValue(false)]
		public bool Status { get; set; }

		[ForeignKey("CorrectiveAction")]
		public int CorrectiveActionId { get; set; }
		public virtual CorrectiveAction CorrectiveAction { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
