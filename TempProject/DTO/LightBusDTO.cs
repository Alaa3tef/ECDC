using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempProject.DTO
{
	public class LightBusDTO
    {
		public int Id { get; set; }

        public string Status { get; set; }
        public string Item { get; set; }

        public string? Remarks { get; set; }
        public int VehicleWeeklyChecklistId { get; set; }


        [DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
