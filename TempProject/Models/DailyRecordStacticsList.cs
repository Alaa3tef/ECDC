using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
    public class DailyRecordStacticsList : ISoftDeleteRepository
    {

        public int Id { get; set; }
        public string DailyRecordStacticsName { get; set; }

        public string Item { get; set; }

        [ForeignKey("DailyLiftingReport")]
        public int DailyLiftingReportId { get; set; }
        public virtual DailyLiftingReport DailyLiftingReport { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
