using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class ManPickup : ISoftDeleteRepository
	{
		public int Id { get; set; }


		public string Status { get; set; }
        public string Item { get; set; }

        public string? Remarks { get; set; }

		[ForeignKey("VehicleWeeklyChecklist")]
		public int VehicleWeeklyChecklistId { get; set; }

		public virtual VehicleWeeklyChecklist VehicleWeeklyChecklist { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
