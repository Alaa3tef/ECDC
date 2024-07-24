using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempProject.DTO
{
	public class DrugInventoryExcelDTO
	{
		public string Item { get; set; }

		public int Quantity { get; set; }

		[Column(TypeName = "date")]
		public DateTime ExpireDate { get; set; }
	}
}
