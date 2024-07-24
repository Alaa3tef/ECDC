using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempProject.DTO
{
	public class DrugInventoryDTO
	{
		public int Id { get; set; }

		public string Item { get; set; }

		public int Quantity { get; set; }

		[Column(TypeName = "date")]
		public DateTime ExpireDate { get; set; }

		public int WeeklyClinicId { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
