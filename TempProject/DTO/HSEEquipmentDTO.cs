using System.ComponentModel;
using TempProject.Repository;

namespace TempProject.Models
{
	public class HSEEquipmentDTO
	{
		public int Id { get; set; }

		public string Item { get; set; }

		public int OnSite { get; set; }

		public int SentForMaintenance { get; set; }

		public int HandoverId { get; set; }


		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
