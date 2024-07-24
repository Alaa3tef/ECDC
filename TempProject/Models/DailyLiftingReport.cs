using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using TempProject.Repository;

namespace TempProject.Models
{
    public class DailyLiftingReport : ISoftDeleteRepository
    {
        public int Id { get; set; }

        [ForeignKey("Rig")]
        public int RigId { get; set; }
        public virtual Rig Rig { get; set; }

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

        public virtual List<DailyRecordStacticsList> DailyRecordStacticsList { get; set; }

        public virtual List<SummaryDailyList>? SummaryDailyList { get; set; }

        public virtual List<PermitsToWorkList>? PermitsToWorkList { get; set; }

      

        public int LiftingEngieerCode { get; set; }
        public string LiftingEngieerName { get; set; }


        [ForeignKey("user")]
        public string userID { get; set; }

        public virtual IdentityUser user { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }


    }
}
