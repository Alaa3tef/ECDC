using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class HSEEquipment : ISoftDeleteRepository
	{
		public int Id { get; set; }

		public string Item { get; set; }

		public int OnSite { get; set; }

		public int SentForMaintenance { get; set; }

		[ForeignKey("Handover")]
		public int HandoverId { get; set; }

		public virtual Handover Handover { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
