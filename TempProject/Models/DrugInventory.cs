using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class DrugInventory : ISoftDeleteRepository
	{
		public int Id { get; set; }

		public string Item { get; set; }

		public int Quantity { get; set; }

		[Column(TypeName = "date")]
		public DateTime ExpireDate { get; set; }

		[ForeignKey("WeeklyClinic")]
		public int WeeklyClinicId { get; set; }

		public virtual WeeklyClinic WeeklyClinic { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
