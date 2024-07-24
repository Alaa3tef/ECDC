using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Models;

namespace TempProject.DTO.ResponseDTO
{
    public class MedicalReportResponseDTO
    {
        public int Id { get; set; }
        public int RigId { get; set; }
        public DateTime Date { get; set; }
        public string IsTheIllHealth { get; set; }
        public int TypeOfIncidentId { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public int TelephoneNumber { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string RigManager { get; set; }
        public string QHSEEngineer { get; set; }
        public string RigDoctor { get; set; }
        public string DoctorRecommendation { get; set; }
        public string DoctorComment { get; set; }
        public string Diagnosis { get; set; }
        public string TypeOfIncidentName { get; set; }


        [DefaultValue(false)]
		public bool IsDeleted { get; set; }
		public string userID { get; set; }
		public string userName { get; set; }


	}
}
