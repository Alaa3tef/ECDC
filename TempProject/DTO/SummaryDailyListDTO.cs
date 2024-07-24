using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class SummaryDailyListDTO
    {
		public int Id { get; set; }
        public string Item { get; set; }

        public string SummaryDailyListName { get; set; }

        public int DailyLiftingReportId { get; set; }

        [DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
