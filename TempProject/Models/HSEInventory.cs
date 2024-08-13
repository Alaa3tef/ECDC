using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class HSEInventory : ISoftDeleteRepository
	{
		public int Id { get; set; }

		public string Item { get; set; }

		public int StockAtStorage { get; set; }

		public int ReleasedFromStorage { get; set; }

		public int NewlyRecieved { get; set; }

		[ForeignKey("Handover")]
		public int HandoverId { get; set; }

		public virtual Handover Handover { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
