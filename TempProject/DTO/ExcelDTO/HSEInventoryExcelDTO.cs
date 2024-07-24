using System.ComponentModel;
using TempProject.Repository;

namespace TempProject.Models
{
	public class HSEInventoryExcelDTO
	{
		public string Item { get; set; }

		public int StockAtStorage { get; set; }

		public int ReleasedFromStorage { get; set; }

		public int NewlyRecieved { get; set; }
	}
}
