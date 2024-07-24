using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class CorrectiveAndObservation : ISoftDeleteRepository
	{
		public int Id { get; set; }

		[ForeignKey("CorrectiveAction")]
		public int CorrectiveActionId { get; set; }

		public virtual CorrectiveAction CorrectiveAction { get; set; }

		[ForeignKey("CorrectiveObservation")]
		public int CorrectiveObservationId { get; set; }

		public virtual CorrectiveActionObservation CorrectiveObservation { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
