using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using TempProject.Repository;

namespace TempProject.Models
{
    public class CustomerReport : ISoftDeleteRepository
    {
        public int Id { get; set; }

        [ForeignKey("Rig")]
        public int RigId { get; set; }
        public virtual Rig Rig { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateTo { get; set; }

        public string ECDCRepresentative { get; set; }


        public string CustomerRepresentative { get; set; }
        public string Comment { get; set; }
        public string Location { get; set; }
        public string Client { get; set; }

        public int EvaluationResult { get; set; }
        public string ClientRepresentative { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }
        public virtual List<EvaluationCriteria>? EvaluationCriteria { get; set; }

        [ForeignKey("user")]
        public string userID { get; set; }

        public virtual IdentityUser user { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }


    }
}
