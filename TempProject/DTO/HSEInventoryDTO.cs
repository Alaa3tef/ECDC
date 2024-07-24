using System.ComponentModel;
using TempProject.Repository;

namespace TempProject.Models
{
	public class HSEInventoryDTO
	{
		public int Id { get; set; }

		public string Item { get; set; }

		public int StockAtStorage { get; set; }

		public int ReleasedFromStorage { get; set; }

		public int NewlyRecieved { get; set; }

		public int HandoverId { get; set; }


		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
