using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class CorrectiveAndRootCauses : ISoftDeleteRepository
	{
		public int Id { get; set; }

		[ForeignKey("CorrectiveAction")]
		public int CorrectiveActionId { get; set; }

		public virtual CorrectiveAction CorrectiveAction { get; set; }

		[ForeignKey("RootCauses")]
		public int RootCausesId { get; set; }

		public virtual RootCauses RootCauses { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
