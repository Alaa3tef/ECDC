using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using TempProject.Repository;

namespace TempProject.Models
{
	public class CorrectiveImages : ISoftDeleteRepository
	{
		public int Id { get; set; }
		public string FileName { get; set; }

		[ForeignKey("CorrectiveAction")]
		public int CorrectiveActionId { get; set; }
		public virtual CorrectiveAction CorrectiveAction { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
