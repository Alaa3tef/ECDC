using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TempProject.Models;

namespace TempProject.Repository
{
    public class MedicalHistoryReportRepository :IMedicalHistoryReportRepository
    {
        Context c;

        public MedicalHistoryReportRepository(Context c)
        {
            this.c = c;

        }
        public List<MedicalHistoryReport> getall()
        {
            return c.MedicalHistoryReports
                .Include(a => a.Rig)
                .Include(a => a.user)
                .Where(a => a.IsDeleted == false)
                .Select(a => new MedicalHistoryReport
                {
                    Id = a.Id,
                    RigId=a.RigId,
                    Rig = new Rig { Number = a.Rig.Number, Id = a.Rig.Id },
                    Date = a.Date,
                    Company=a.Company,
                    DateOfBirth=a.DateOfBirth,
                    Code=a.Code,
                    Address=a.Address,
                    TelephoneNumber=a.TelephoneNumber,
                    Name=a.Name,
                    Jop=a.Jop,
                    Contact=a.Contact,

                    Socia_DoYouExerciseRegularlyAnswer=a.Socia_DoYouExerciseRegularlyAnswer,
                    Socia_DoYouExerciseRegularlyComment=a.Socia_DoYouExerciseRegularlyComment,

                    Socia_DoYouSmokeAnswer=a.Socia_DoYouSmokeAnswer,
                    Socia_DoYouSmokeComment=a.Socia_DoYouSmokeComment,

                    Socia_HaveYouBeenExposedAnswer=a.Socia_HaveYouBeenExposedAnswer,
                    Socia_HaveYouBeenExposedComment=a.Socia_HaveYouBeenExposedComment,

                    Socia_HaveYouEverDevelopedAnswer=a.Socia_HaveYouEverDevelopedAnswer,
                    Socia_HaveYouEverDevelopedComment=a.Socia_HaveYouEverDevelopedComment,

                    Socia_HaveYouSufferedAnswer=a.Socia_HaveYouSufferedAnswer,
                    Socia_HaveYouSufferedComment=a.Socia_HaveYouSufferedComment,

                    Family_AllergyAnswer=a.Family_AllergyAnswer,
                    Family_AllergyComment=a.Family_AllergyComment,

                    Family_AreYouCurrentlyBeingTreatedAnswer=a.Family_AreYouCurrentlyBeingTreatedAnswer,
                    Family_AreYouCurrentlyBeingTreatedComment=a.Family_AreYouCurrentlyBeingTreatedComment,

                    Family_AreYouCurrentlyReceivingAnyMedicalAnswer=a.Family_AreYouCurrentlyReceivingAnyMedicalAnswer,
                    Family_AreYouCurrentlyReceivingAnyMedicalComment=a.Family_AreYouCurrentlyReceivingAnyMedicalComment,

                    Family_COPDAnswer=a.Family_COPDAnswer,
                    Family_COPDComment=a.Family_COPDComment,

                    Family_DepressionAnswer=a.Family_DepressionAnswer,
                    Family_DepressionComment=a.Family_DepressionComment,

                    Family_DiabetesAnswer=a.Family_DiabetesAnswer,
                    Family_DiabetesComment=a.Family_DiabetesComment,

                    Family_DiscProlapseAnswer=a.Family_DiscProlapseAnswer,
                    Family_DiscProlapseComment=a.Family_DiscProlapseComment,

                    Family_DizzinessAnswer=a.Family_DizzinessAnswer,
                    Family_DizzinessComment=a.Family_DizzinessComment,

                    Family_DoAnyOfYour1stDegreeFamilyAnswer=a.Family_DoAnyOfYour1stDegreeFamilyAnswer,
                    Family_DoAnyOfYour1stDegreeFamilyComment=a.Family_DoAnyOfYour1stDegreeFamilyComment,

                    Family_GITAnswer=a.Family_GITAnswer,
                    Family_GITComment=a.Family_GITComment,

                    Family_HeartDiseaseAnswer=a.Family_HeartDiseaseAnswer,
                    Family_HeartDiseaseComment=a.Family_HeartDiseaseComment,

                    Family_HighBloodPressureAnswer=a.Family_HighBloodPressureAnswer,
                    Family_HighBloodPressureComment=a.Family_HighBloodPressureComment,

                    Family_HospitalizationAnswer=a.Family_HospitalizationAnswer,
                    Family_HospitalizationComment=a.Family_HospitalizationComment,

                    Family_InfectiousAnswer=a.Family_InfectiousAnswer,
                    Family_InfectiousComment=a.Family_InfectiousComment,

                    Family_KidneyAnswer=a.Family_KidneyAnswer,
                    Family_KidneyComment=a.Family_KidneyComment,

                    Family_NeurologicalAnswer=a.Family_NeurologicalAnswer,
                    Family_NeurologicalComment=a.Family_NeurologicalComment,

                    Family_SurgeryAnswer=a.Family_SurgeryAnswer,
                    Family_SurgeryComment=a.Family_SurgeryComment,

                    GeneralExamination_BloodPressure=a.GeneralExamination_BloodPressure,
                    GeneralExamination_HeartRate=a.GeneralExamination_HeartRate,
                    GeneralExamination_Height=a.GeneralExamination_Height,
                    GeneralExamination_Weight=a.GeneralExamination_Weight,

                    DoctorComments=a.DoctorComments,
                    DoctorName=a.DoctorName,

                    user = new IdentityUser { UserName = a.user.UserName, Id = a.user.Id }


                }).ToList();
        }
    }
}
