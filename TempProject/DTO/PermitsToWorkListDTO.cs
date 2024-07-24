using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class PermitsToWorkListDTO
    {
		public int Id { get; set; }
        public string Item { get; set; }

        public string PermitsToWorkListName { get; set; }

        public int DailyLiftingReportId { get; set; }

        [DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
