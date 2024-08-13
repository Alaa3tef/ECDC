using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Security.Cryptography;
using System.Security.Policy;
using TempProject.Repository;

namespace TempProject.Models
{
    public class MedicalReport : ISoftDeleteRepository
    {
        public int Id { get; set; }

        [ForeignKey("Rig")]
        public int RigId { get; set; }
        public virtual Rig Rig { get; set; }
        public DateTime Date { get; set; }
        public string IsTheIllHealth { get; set; }

        [ForeignKey("TypeOfIncident")]
        public int? TypeOfIncidentId ;
        public virtual TypeOfIncident TypeOfIncident { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }

        public int TelephoneNumber { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string RigManager { get; set; }
        public string QHSEEngineer { get; set; }
        public string RigDoctor { get; set; }
        public string DoctorRecommendation { get; set; }
       
        public string DoctorComment { get; set; }
        public string Diagnosis { get; set; }
       
        [ForeignKey("user")]
        public string userID { get; set; }

        public virtual IdentityUser user { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }


    }
}
