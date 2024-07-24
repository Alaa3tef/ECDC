using System.ComponentModel;

namespace TempProject.DTO
{
	public class HSEEquipmentListDTO
	{
		public int Id { get; set; }

		public string Equipment { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
