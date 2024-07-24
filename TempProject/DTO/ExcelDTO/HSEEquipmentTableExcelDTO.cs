using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempProject.DTO
{
	public class HSEEquipmentTableExcelDTO
	{
		public string Equipment { get; set; }

		public string Model { get; set; }

		public string SerialNumber { get; set; }


		[Column(TypeName = "date")]
		public DateTime ExpiryDate { get; set; }
	}
}
