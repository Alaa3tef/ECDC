using System.ComponentModel;
using TempProject.Repository;

namespace TempProject.Models
{
	public class HSEEquipmentExcelDTO
	{
		public string Item { get; set; }

		public int OnSite { get; set; }

		public int SentForMaintenance { get; set; }
	}
}
