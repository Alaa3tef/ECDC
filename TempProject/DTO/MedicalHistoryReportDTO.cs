using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using TempProject.Models;

namespace TempProject.DTO
{
    public class MedicalHistoryReportDTO
    {
        public int Id { get; set; }

        public int RigId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public string Company { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Jop { get; set; }
        public string Address { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        public string Contact { get; set; }
        public int TelephoneNumber { get; set; }
        public string Socia_DoYouSmokeAnswer { get; set; }
        public string? Socia_DoYouSmokeComment { get; set; }

        public string Socia_DoYouExerciseRegularlyAnswer { get; set; }
        public string? Socia_DoYouExerciseRegularlyComment { get; set; }

        public string Socia_HaveYouBeenExposedAnswer { get; set; }
        public string? Socia_HaveYouBeenExposedComment { get; set; }

        public string Socia_HaveYouEverDevelopedAnswer { get; set; }
        public string? Socia_HaveYouEverDevelopedComment { get; set; }

        public string Socia_HaveYouSufferedAnswer { get; set; }
        public string? Socia_HaveYouSufferedComment { get; set; }

        public string Family_AreYouCurrentlyBeingTreatedAnswer { get; set; }
        public string? Family_AreYouCurrentlyBeingTreatedComment { get; set; }

        public string Family_AreYouCurrentlyReceivingAnyMedicalAnswer { get; set; }
        public string? Family_AreYouCurrentlyReceivingAnyMedicalComment { get; set; }

        public string Family_HighBloodPressureAnswer { get; set; }
        public string? Family_HighBloodPressureComment { get; set; }

        public string Family_HeartDiseaseAnswer { get; set; }
        public string? Family_HeartDiseaseComment { get; set; }

        public string Family_COPDAnswer { get; set; }
        public string? Family_COPDComment { get; set; }

        public string Family_DiabetesAnswer { get; set; }
        public string? Family_DiabetesComment { get; set; }

        public string Family_GITAnswer { get; set; }
        public string? Family_GITComment { get; set; }

        public string Family_KidneyAnswer { get; set; }
        public string? Family_KidneyComment { get; set; }

        public string Family_NeurologicalAnswer { get; set; }
        public string? Family_NeurologicalComment { get; set; }

        public string Family_InfectiousAnswer { get; set; }
        public string? Family_InfectiousComment { get; set; }

        public string Family_DizzinessAnswer { get; set; }
        public string? Family_DizzinessComment { get; set; }

        public string Family_DiscProlapseAnswer { get; set; }
        public string? Family_DiscProlapseComment { get; set; }

        public string Family_AllergyAnswer { get; set; }
        public string? Family_AllergyComment { get; set; }

        public string Family_HospitalizationAnswer { get; set; }
        public string? Family_HospitalizationComment { get; set; }

        public string Family_SurgeryAnswer { get; set; }
        public string? Family_SurgeryComment { get; set; }

        public string Family_DepressionAnswer { get; set; }
        public string? Family_DepressionComment { get; set; }

        public string Family_DoAnyOfYour1stDegreeFamilyAnswer { get; set; }
        public string? Family_DoAnyOfYour1stDegreeFamilyComment { get; set; }

        public int? GeneralExamination_Weight { get; set; }
        public int? GeneralExamination_Height { get; set; }
        public int? GeneralExamination_BloodPressure { get; set; }
        public int? GeneralExamination_HeartRate { get; set; }

        public string? DoctorComments { get; set; }
        public string DoctorName { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public string userID { get; set; }
    }
}
