using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class Visits : ISoftDeleteRepository
	{
		public int Id { get; set; }

		[Column(TypeName = "date")]
		public DateTime Date { get; set; }

		public string VisitName { get; set; }

		[ForeignKey("Handover")]
		public int HandoverId { get; set; }

		public virtual Handover Handover { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
