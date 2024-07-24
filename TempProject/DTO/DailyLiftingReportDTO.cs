using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Models;

namespace TempProject.DTO
{
    public class DailyLiftingReportDTO
    {
        public int Id { get; set; }
        public int RigId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public string MobileCraneName { get; set; }
        public string Type { get; set; }
        public int ChasisNo { get; set; }
        public string Capacity { get; set; }
        public DateTime DateofLastInspection { get; set; }
        public DateTime DateofNextInspection { get; set; }
        public string ForkName { get; set; }
        public string ForkType { get; set; }
        public int ForkChasisNo { get; set; }
        public string ForkCapacity { get; set; }
        public DateTime ForkDateofLastInspection { get; set; }
        public DateTime ForkDateofNextInspection { get; set; }
        public List<SummaryDailyListDTO>? summaryDailyListDTOs { get; set; } = new List<SummaryDailyListDTO>();
        public List<DailyRecordStacticsListDTO> dailyRecordStacticsListDTOs { get; set; } = new List<DailyRecordStacticsListDTO>();
        public List<PermitsToWorkListDTO>? PermitsToWorkListDTOs { get; set; } = new List<PermitsToWorkListDTO>();

        public int LiftingEngieerCode { get; set; }
        public string LiftingEngieerName { get; set; }

        public string userID { get; set; }

        [DefaultValue(false)]
		public bool IsDeleted { get; set; }

	}
}
