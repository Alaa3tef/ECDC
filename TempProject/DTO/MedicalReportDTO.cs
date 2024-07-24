using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Models;

namespace TempProject.DTO
{
    public class MedicalReportDTO
    {
        public int Id { get; set; }
        public int RigId { get; set; }
        public DateTime Date { get; set; }
        public string IsTheIllHealth { get; set; }
        public int? TypeOfIncidentId { get; set; } 
        public string Company { get; set; }
        public string Job { get; set; }
        public int Code { get; set; }
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

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public string UserId { set; get; }
    }
}
