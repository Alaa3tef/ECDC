using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TempProject.DTO;
using TempProject.DTO.ResponseDTO;
using TempProject.Helper;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MedicalHistoryReportController : ControllerBase
	{
		public IRepository<MedicalHistoryReport> MedicalHistoryReportRepo { get; set; }

		public IMedicalHistoryReportRepository MedicalHistoryReportRepository { get; set; }

		private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager;


		public MedicalHistoryReportController(Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager,
			IRepository<MedicalHistoryReport> _MedicalHistoryReportRepo,
			IMedicalHistoryReportRepository _MedicalHistoryReportRepoistory)

		{
			this.MedicalHistoryReportRepo = _MedicalHistoryReportRepo;
			this.MedicalHistoryReportRepository = _MedicalHistoryReportRepoistory;
			this.userManager = _userManager;

		}

		[HttpGet("GetData")]
		public async Task<ResultDTO> GetAllWithData(string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<MedicalHistoryReport> temp = MedicalHistoryReportRepository.getall();
					List<MedicalHistoryReportResponseDTO> newTemp = new List<MedicalHistoryReportResponseDTO>();
					foreach (MedicalHistoryReport MedicalHistoryReport in temp)
					{
						MedicalHistoryReportResponseDTO MedicalHistoryReportResponseDTO = new MedicalHistoryReportResponseDTO();
						MedicalHistoryReportResponseDTO.Id = MedicalHistoryReport.Id;
						MedicalHistoryReportResponseDTO.RigId = MedicalHistoryReport.Rig.Number;
						MedicalHistoryReportResponseDTO.Date = MedicalHistoryReport.Date;
						MedicalHistoryReportResponseDTO.DateOfBirth = MedicalHistoryReport.DateOfBirth;
						MedicalHistoryReportResponseDTO.Company = MedicalHistoryReport.Company;
						MedicalHistoryReportResponseDTO.Code = MedicalHistoryReport.Code;
						MedicalHistoryReportResponseDTO.Contact = MedicalHistoryReport.Contact;
						MedicalHistoryReportResponseDTO.Address = MedicalHistoryReport.Address;
						MedicalHistoryReportResponseDTO.TelephoneNumber = MedicalHistoryReport.TelephoneNumber;
						MedicalHistoryReportResponseDTO.Name = MedicalHistoryReport.Name;
						MedicalHistoryReportResponseDTO.Jop = MedicalHistoryReport.Jop;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyAnswer = MedicalHistoryReport.Socia_DoYouExerciseRegularlyAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyComment = MedicalHistoryReport.Socia_DoYouExerciseRegularlyComment;

						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeAnswer = MedicalHistoryReport.Socia_DoYouSmokeAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeComment = MedicalHistoryReport.Socia_DoYouSmokeComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedAnswer = MedicalHistoryReport.Socia_HaveYouBeenExposedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedComment = MedicalHistoryReport.Socia_HaveYouBeenExposedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedAnswer = MedicalHistoryReport.Socia_HaveYouEverDevelopedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedComment = MedicalHistoryReport.Socia_HaveYouEverDevelopedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedAnswer = MedicalHistoryReport.Socia_HaveYouSufferedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedComment = MedicalHistoryReport.Socia_HaveYouSufferedComment;

						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyAnswer = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyAnswer;
						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyComment = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyComment;

						MedicalHistoryReportResponseDTO.Family_DizzinessAnswer = MedicalHistoryReport.Family_DizzinessAnswer;
						MedicalHistoryReportResponseDTO.Family_DizzinessComment = MedicalHistoryReport.Family_DizzinessComment;

						MedicalHistoryReportResponseDTO.Family_DiscProlapseAnswer = MedicalHistoryReport.Family_DiscProlapseAnswer;
						MedicalHistoryReportResponseDTO.Family_DiscProlapseComment = MedicalHistoryReport.Family_DiscProlapseComment;

						MedicalHistoryReportResponseDTO.Family_DiabetesAnswer = MedicalHistoryReport.Family_DiabetesAnswer;
						MedicalHistoryReportResponseDTO.Family_DiabetesComment = MedicalHistoryReport.Family_DiabetesComment;

						MedicalHistoryReportResponseDTO.Family_DepressionAnswer = MedicalHistoryReport.Family_DepressionAnswer;
						MedicalHistoryReportResponseDTO.Family_DepressionComment = MedicalHistoryReport.Family_DepressionComment;

						MedicalHistoryReportResponseDTO.Family_COPDAnswer = MedicalHistoryReport.Family_COPDAnswer;
						MedicalHistoryReportResponseDTO.Family_COPDComment = MedicalHistoryReport.Family_COPDComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalAnswer = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalComment = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedAnswer = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedComment = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedComment;

						MedicalHistoryReportResponseDTO.Family_AllergyAnswer = MedicalHistoryReport.Family_AllergyAnswer;
						MedicalHistoryReportResponseDTO.Family_AllergyComment = MedicalHistoryReport.Family_AllergyComment;

						MedicalHistoryReportResponseDTO.Family_GITAnswer = MedicalHistoryReport.Family_GITAnswer;
						MedicalHistoryReportResponseDTO.Family_GITComment = MedicalHistoryReport.Family_GITComment;

						MedicalHistoryReportResponseDTO.Family_HeartDiseaseAnswer = MedicalHistoryReport.Family_HeartDiseaseAnswer;
						MedicalHistoryReportResponseDTO.Family_HeartDiseaseComment = MedicalHistoryReport.Family_HeartDiseaseComment;

						MedicalHistoryReportResponseDTO.Family_HighBloodPressureAnswer = MedicalHistoryReport.Family_HighBloodPressureAnswer;
						MedicalHistoryReportResponseDTO.Family_HighBloodPressureComment = MedicalHistoryReport.Family_HighBloodPressureComment;

						MedicalHistoryReportResponseDTO.Family_HospitalizationAnswer = MedicalHistoryReport.Family_HospitalizationAnswer;
						MedicalHistoryReportResponseDTO.Family_HospitalizationComment = MedicalHistoryReport.Family_HospitalizationComment;

						MedicalHistoryReportResponseDTO.Family_InfectiousAnswer = MedicalHistoryReport.Family_InfectiousAnswer;
						MedicalHistoryReportResponseDTO.Family_InfectiousComment = MedicalHistoryReport.Family_InfectiousComment;

						MedicalHistoryReportResponseDTO.Family_KidneyAnswer = MedicalHistoryReport.Family_KidneyAnswer;
						MedicalHistoryReportResponseDTO.Family_KidneyComment = MedicalHistoryReport.Family_KidneyComment;

						MedicalHistoryReportResponseDTO.Family_NeurologicalAnswer = MedicalHistoryReport.Family_NeurologicalAnswer;
						MedicalHistoryReportResponseDTO.Family_NeurologicalComment = MedicalHistoryReport.Family_NeurologicalComment;

						MedicalHistoryReportResponseDTO.Family_SurgeryAnswer = MedicalHistoryReport.Family_SurgeryAnswer;
						MedicalHistoryReportResponseDTO.Family_SurgeryComment = MedicalHistoryReport.Family_SurgeryComment;

						MedicalHistoryReportResponseDTO.DoctorComments = MedicalHistoryReport.DoctorComments;
						MedicalHistoryReportResponseDTO.DoctorName = MedicalHistoryReport.DoctorName;

						MedicalHistoryReportResponseDTO.GeneralExamination_BloodPressure = MedicalHistoryReport.GeneralExamination_BloodPressure;
						MedicalHistoryReportResponseDTO.GeneralExamination_HeartRate = MedicalHistoryReport.GeneralExamination_HeartRate;

						MedicalHistoryReportResponseDTO.GeneralExamination_Height = MedicalHistoryReport.GeneralExamination_Height;
						MedicalHistoryReportResponseDTO.GeneralExamination_Weight = MedicalHistoryReport.GeneralExamination_Weight;

						MedicalHistoryReportResponseDTO.userName = MedicalHistoryReport.user.UserName;
						MedicalHistoryReportResponseDTO.userID = MedicalHistoryReport.user.Id;



						newTemp.Add(MedicalHistoryReportResponseDTO);
					}

					if (newTemp != null)
					{
						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{

					List<MedicalHistoryReport> temp = MedicalHistoryReportRepository.getall().Where(a => a.user.Id == UserID).ToList();
					List<MedicalHistoryReportResponseDTO> newTemp = new List<MedicalHistoryReportResponseDTO>();
					foreach (MedicalHistoryReport MedicalHistoryReport in temp)
					{
						MedicalHistoryReportResponseDTO MedicalHistoryReportResponseDTO = new MedicalHistoryReportResponseDTO();
						MedicalHistoryReportResponseDTO.Id = MedicalHistoryReport.Id;
						MedicalHistoryReportResponseDTO.RigId = MedicalHistoryReport.Rig.Number;
						MedicalHistoryReportResponseDTO.Date = MedicalHistoryReport.Date;
						MedicalHistoryReportResponseDTO.DateOfBirth = MedicalHistoryReport.DateOfBirth;
						MedicalHistoryReportResponseDTO.Company = MedicalHistoryReport.Company;
						MedicalHistoryReportResponseDTO.Code = MedicalHistoryReport.Code;
						MedicalHistoryReportResponseDTO.Contact = MedicalHistoryReport.Contact;
						MedicalHistoryReportResponseDTO.Address = MedicalHistoryReport.Address;
						MedicalHistoryReportResponseDTO.TelephoneNumber = MedicalHistoryReport.TelephoneNumber;
						MedicalHistoryReportResponseDTO.Name = MedicalHistoryReport.Name;
						MedicalHistoryReportResponseDTO.Jop = MedicalHistoryReport.Jop;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyAnswer = MedicalHistoryReport.Socia_DoYouExerciseRegularlyAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyComment = MedicalHistoryReport.Socia_DoYouExerciseRegularlyComment;

						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeAnswer = MedicalHistoryReport.Socia_DoYouSmokeAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeComment = MedicalHistoryReport.Socia_DoYouSmokeComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedAnswer = MedicalHistoryReport.Socia_HaveYouBeenExposedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedComment = MedicalHistoryReport.Socia_HaveYouBeenExposedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedAnswer = MedicalHistoryReport.Socia_HaveYouEverDevelopedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedComment = MedicalHistoryReport.Socia_HaveYouEverDevelopedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedAnswer = MedicalHistoryReport.Socia_HaveYouSufferedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedComment = MedicalHistoryReport.Socia_HaveYouSufferedComment;

						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyAnswer = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyAnswer;
						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyComment = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyComment;

						MedicalHistoryReportResponseDTO.Family_DizzinessAnswer = MedicalHistoryReport.Family_DizzinessAnswer;
						MedicalHistoryReportResponseDTO.Family_DizzinessComment = MedicalHistoryReport.Family_DizzinessComment;

						MedicalHistoryReportResponseDTO.Family_DiscProlapseAnswer = MedicalHistoryReport.Family_DiscProlapseAnswer;
						MedicalHistoryReportResponseDTO.Family_DiscProlapseComment = MedicalHistoryReport.Family_DiscProlapseComment;

						MedicalHistoryReportResponseDTO.Family_DiabetesAnswer = MedicalHistoryReport.Family_DiabetesAnswer;
						MedicalHistoryReportResponseDTO.Family_DiabetesComment = MedicalHistoryReport.Family_DiabetesComment;

						MedicalHistoryReportResponseDTO.Family_DepressionAnswer = MedicalHistoryReport.Family_DepressionAnswer;
						MedicalHistoryReportResponseDTO.Family_DepressionComment = MedicalHistoryReport.Family_DepressionComment;

						MedicalHistoryReportResponseDTO.Family_COPDAnswer = MedicalHistoryReport.Family_COPDAnswer;
						MedicalHistoryReportResponseDTO.Family_COPDComment = MedicalHistoryReport.Family_COPDComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalAnswer = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalComment = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedAnswer = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedComment = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedComment;

						MedicalHistoryReportResponseDTO.Family_AllergyAnswer = MedicalHistoryReport.Family_AllergyAnswer;
						MedicalHistoryReportResponseDTO.Family_AllergyComment = MedicalHistoryReport.Family_AllergyComment;

						MedicalHistoryReportResponseDTO.Family_GITAnswer = MedicalHistoryReport.Family_GITAnswer;
						MedicalHistoryReportResponseDTO.Family_GITComment = MedicalHistoryReport.Family_GITComment;

						MedicalHistoryReportResponseDTO.Family_HeartDiseaseAnswer = MedicalHistoryReport.Family_HeartDiseaseAnswer;
						MedicalHistoryReportResponseDTO.Family_HeartDiseaseComment = MedicalHistoryReport.Family_HeartDiseaseComment;

						MedicalHistoryReportResponseDTO.Family_HighBloodPressureAnswer = MedicalHistoryReport.Family_HighBloodPressureAnswer;
						MedicalHistoryReportResponseDTO.Family_HighBloodPressureComment = MedicalHistoryReport.Family_HighBloodPressureComment;

						MedicalHistoryReportResponseDTO.Family_HospitalizationAnswer = MedicalHistoryReport.Family_HospitalizationAnswer;
						MedicalHistoryReportResponseDTO.Family_HospitalizationComment = MedicalHistoryReport.Family_HospitalizationComment;

						MedicalHistoryReportResponseDTO.Family_InfectiousAnswer = MedicalHistoryReport.Family_InfectiousAnswer;
						MedicalHistoryReportResponseDTO.Family_InfectiousComment = MedicalHistoryReport.Family_InfectiousComment;

						MedicalHistoryReportResponseDTO.Family_KidneyAnswer = MedicalHistoryReport.Family_KidneyAnswer;
						MedicalHistoryReportResponseDTO.Family_KidneyComment = MedicalHistoryReport.Family_KidneyComment;

						MedicalHistoryReportResponseDTO.Family_NeurologicalAnswer = MedicalHistoryReport.Family_NeurologicalAnswer;
						MedicalHistoryReportResponseDTO.Family_NeurologicalComment = MedicalHistoryReport.Family_NeurologicalComment;

						MedicalHistoryReportResponseDTO.Family_SurgeryAnswer = MedicalHistoryReport.Family_SurgeryAnswer;
						MedicalHistoryReportResponseDTO.Family_SurgeryComment = MedicalHistoryReport.Family_SurgeryComment;

						MedicalHistoryReportResponseDTO.DoctorComments = MedicalHistoryReport.DoctorComments;
						MedicalHistoryReportResponseDTO.DoctorName = MedicalHistoryReport.DoctorName;

						MedicalHistoryReportResponseDTO.GeneralExamination_BloodPressure = MedicalHistoryReport.GeneralExamination_BloodPressure;
						MedicalHistoryReportResponseDTO.GeneralExamination_HeartRate = MedicalHistoryReport.GeneralExamination_HeartRate;

						MedicalHistoryReportResponseDTO.GeneralExamination_Height = MedicalHistoryReport.GeneralExamination_Height;
						MedicalHistoryReportResponseDTO.GeneralExamination_Weight = MedicalHistoryReport.GeneralExamination_Weight;

						MedicalHistoryReportResponseDTO.userName = MedicalHistoryReport.user.UserName;
						MedicalHistoryReportResponseDTO.userID = MedicalHistoryReport.user.Id;

					}
					if (newTemp != null)
					{
						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}
				}
			}
			catch (Exception ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}
			return result;
		}

		[HttpGet("GetDataForExcel")]
		public ActionResult<ResultDTO> GetDataForExcel(string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<MedicalHistoryReport> temp = MedicalHistoryReportRepository.getall();
					List<MedicalHistoryReportExcelDTO> newTemp = new List<MedicalHistoryReportExcelDTO>();
					foreach (MedicalHistoryReport MedicalHistoryReport in temp)
					{
						MedicalHistoryReportExcelDTO MedicalHistoryReportResponseDTO = new MedicalHistoryReportExcelDTO();
						MedicalHistoryReportResponseDTO.Id = MedicalHistoryReport.Id;
						MedicalHistoryReportResponseDTO.RigId = MedicalHistoryReport.Rig.Number;
						MedicalHistoryReportResponseDTO.Date = MedicalHistoryReport.Date;
						MedicalHistoryReportResponseDTO.DateOfBirth = MedicalHistoryReport.DateOfBirth;
						MedicalHistoryReportResponseDTO.Company = MedicalHistoryReport.Company;
						MedicalHistoryReportResponseDTO.Code = MedicalHistoryReport.Code;
						MedicalHistoryReportResponseDTO.Contact = MedicalHistoryReport.Contact;
						MedicalHistoryReportResponseDTO.Address = MedicalHistoryReport.Address;
						MedicalHistoryReportResponseDTO.TelephoneNumber = MedicalHistoryReport.TelephoneNumber;
						MedicalHistoryReportResponseDTO.Name = MedicalHistoryReport.Name;
						MedicalHistoryReportResponseDTO.Jop = MedicalHistoryReport.Jop;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyAnswer = MedicalHistoryReport.Socia_DoYouExerciseRegularlyAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyComment = MedicalHistoryReport.Socia_DoYouExerciseRegularlyComment;

						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeAnswer = MedicalHistoryReport.Socia_DoYouSmokeAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeComment = MedicalHistoryReport.Socia_DoYouSmokeComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedAnswer = MedicalHistoryReport.Socia_HaveYouBeenExposedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedComment = MedicalHistoryReport.Socia_HaveYouBeenExposedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedAnswer = MedicalHistoryReport.Socia_HaveYouEverDevelopedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedComment = MedicalHistoryReport.Socia_HaveYouEverDevelopedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedAnswer = MedicalHistoryReport.Socia_HaveYouSufferedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedComment = MedicalHistoryReport.Socia_HaveYouSufferedComment;

						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyAnswer = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyAnswer;
						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyComment = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyComment;

						MedicalHistoryReportResponseDTO.Family_DizzinessAnswer = MedicalHistoryReport.Family_DizzinessAnswer;
						MedicalHistoryReportResponseDTO.Family_DizzinessComment = MedicalHistoryReport.Family_DizzinessComment;

						MedicalHistoryReportResponseDTO.Family_DiscProlapseAnswer = MedicalHistoryReport.Family_DiscProlapseAnswer;
						MedicalHistoryReportResponseDTO.Family_DiscProlapseComment = MedicalHistoryReport.Family_DiscProlapseComment;

						MedicalHistoryReportResponseDTO.Family_DiabetesAnswer = MedicalHistoryReport.Family_DiabetesAnswer;
						MedicalHistoryReportResponseDTO.Family_DiabetesComment = MedicalHistoryReport.Family_DiabetesComment;

						MedicalHistoryReportResponseDTO.Family_DepressionAnswer = MedicalHistoryReport.Family_DepressionAnswer;
						MedicalHistoryReportResponseDTO.Family_DepressionComment = MedicalHistoryReport.Family_DepressionComment;

						MedicalHistoryReportResponseDTO.Family_COPDAnswer = MedicalHistoryReport.Family_COPDAnswer;
						MedicalHistoryReportResponseDTO.Family_COPDComment = MedicalHistoryReport.Family_COPDComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalAnswer = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalComment = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedAnswer = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedComment = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedComment;

						MedicalHistoryReportResponseDTO.Family_AllergyAnswer = MedicalHistoryReport.Family_AllergyAnswer;
						MedicalHistoryReportResponseDTO.Family_AllergyComment = MedicalHistoryReport.Family_AllergyComment;

						MedicalHistoryReportResponseDTO.Family_GITAnswer = MedicalHistoryReport.Family_GITAnswer;
						MedicalHistoryReportResponseDTO.Family_GITComment = MedicalHistoryReport.Family_GITComment;

						MedicalHistoryReportResponseDTO.Family_HeartDiseaseAnswer = MedicalHistoryReport.Family_HeartDiseaseAnswer;
						MedicalHistoryReportResponseDTO.Family_HeartDiseaseComment = MedicalHistoryReport.Family_HeartDiseaseComment;

						MedicalHistoryReportResponseDTO.Family_HighBloodPressureAnswer = MedicalHistoryReport.Family_HighBloodPressureAnswer;
						MedicalHistoryReportResponseDTO.Family_HighBloodPressureComment = MedicalHistoryReport.Family_HighBloodPressureComment;

						MedicalHistoryReportResponseDTO.Family_HospitalizationAnswer = MedicalHistoryReport.Family_HospitalizationAnswer;
						MedicalHistoryReportResponseDTO.Family_HospitalizationComment = MedicalHistoryReport.Family_HospitalizationComment;

						MedicalHistoryReportResponseDTO.Family_InfectiousAnswer = MedicalHistoryReport.Family_InfectiousAnswer;
						MedicalHistoryReportResponseDTO.Family_InfectiousComment = MedicalHistoryReport.Family_InfectiousComment;

						MedicalHistoryReportResponseDTO.Family_KidneyAnswer = MedicalHistoryReport.Family_KidneyAnswer;
						MedicalHistoryReportResponseDTO.Family_KidneyComment = MedicalHistoryReport.Family_KidneyComment;

						MedicalHistoryReportResponseDTO.Family_NeurologicalAnswer = MedicalHistoryReport.Family_NeurologicalAnswer;
						MedicalHistoryReportResponseDTO.Family_NeurologicalComment = MedicalHistoryReport.Family_NeurologicalComment;

						MedicalHistoryReportResponseDTO.Family_SurgeryAnswer = MedicalHistoryReport.Family_SurgeryAnswer;
						MedicalHistoryReportResponseDTO.Family_SurgeryComment = MedicalHistoryReport.Family_SurgeryComment;

						MedicalHistoryReportResponseDTO.DoctorComments = MedicalHistoryReport.DoctorComments;
						MedicalHistoryReportResponseDTO.DoctorName = MedicalHistoryReport.DoctorName;

						MedicalHistoryReportResponseDTO.GeneralExamination_BloodPressure = MedicalHistoryReport.GeneralExamination_BloodPressure;
						MedicalHistoryReportResponseDTO.GeneralExamination_HeartRate = MedicalHistoryReport.GeneralExamination_HeartRate;

						MedicalHistoryReportResponseDTO.GeneralExamination_Height = MedicalHistoryReport.GeneralExamination_Height;
						MedicalHistoryReportResponseDTO.GeneralExamination_Weight = MedicalHistoryReport.GeneralExamination_Weight;

						MedicalHistoryReportResponseDTO.userName = MedicalHistoryReport.user.UserName;
						MedicalHistoryReportResponseDTO.userID = MedicalHistoryReport.user.Id;


						newTemp.Add(MedicalHistoryReportResponseDTO);
					}

					if (newTemp != null)
					{
						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<MedicalHistoryReport> temp = MedicalHistoryReportRepository.getall().Where(a => a.user.Id == UserID).ToList();
					List<MedicalHistoryReportExcelDTO> newTemp = new List<MedicalHistoryReportExcelDTO>();
					foreach (MedicalHistoryReport MedicalHistoryReport in temp)
					{
						MedicalHistoryReportExcelDTO MedicalHistoryReportResponseDTO = new MedicalHistoryReportExcelDTO();
						MedicalHistoryReportResponseDTO.Id = MedicalHistoryReport.Id;
						MedicalHistoryReportResponseDTO.RigId = MedicalHistoryReport.Rig.Number;
						MedicalHistoryReportResponseDTO.Date = MedicalHistoryReport.Date;
						MedicalHistoryReportResponseDTO.DateOfBirth = MedicalHistoryReport.DateOfBirth;
						MedicalHistoryReportResponseDTO.Company = MedicalHistoryReport.Company;
						MedicalHistoryReportResponseDTO.Code = MedicalHistoryReport.Code;
						MedicalHistoryReportResponseDTO.Contact = MedicalHistoryReport.Contact;
						MedicalHistoryReportResponseDTO.Address = MedicalHistoryReport.Address;
						MedicalHistoryReportResponseDTO.TelephoneNumber = MedicalHistoryReport.TelephoneNumber;
						MedicalHistoryReportResponseDTO.Name = MedicalHistoryReport.Name;
						MedicalHistoryReportResponseDTO.Jop = MedicalHistoryReport.Jop;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyAnswer = MedicalHistoryReport.Socia_DoYouExerciseRegularlyAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyComment = MedicalHistoryReport.Socia_DoYouExerciseRegularlyComment;

						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeAnswer = MedicalHistoryReport.Socia_DoYouSmokeAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeComment = MedicalHistoryReport.Socia_DoYouSmokeComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedAnswer = MedicalHistoryReport.Socia_HaveYouBeenExposedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedComment = MedicalHistoryReport.Socia_HaveYouBeenExposedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedAnswer = MedicalHistoryReport.Socia_HaveYouEverDevelopedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedComment = MedicalHistoryReport.Socia_HaveYouEverDevelopedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedAnswer = MedicalHistoryReport.Socia_HaveYouSufferedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedComment = MedicalHistoryReport.Socia_HaveYouSufferedComment;

						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyAnswer = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyAnswer;
						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyComment = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyComment;

						MedicalHistoryReportResponseDTO.Family_DizzinessAnswer = MedicalHistoryReport.Family_DizzinessAnswer;
						MedicalHistoryReportResponseDTO.Family_DizzinessComment = MedicalHistoryReport.Family_DizzinessComment;

						MedicalHistoryReportResponseDTO.Family_DiscProlapseAnswer = MedicalHistoryReport.Family_DiscProlapseAnswer;
						MedicalHistoryReportResponseDTO.Family_DiscProlapseComment = MedicalHistoryReport.Family_DiscProlapseComment;

						MedicalHistoryReportResponseDTO.Family_DiabetesAnswer = MedicalHistoryReport.Family_DiabetesAnswer;
						MedicalHistoryReportResponseDTO.Family_DiabetesComment = MedicalHistoryReport.Family_DiabetesComment;

						MedicalHistoryReportResponseDTO.Family_DepressionAnswer = MedicalHistoryReport.Family_DepressionAnswer;
						MedicalHistoryReportResponseDTO.Family_DepressionComment = MedicalHistoryReport.Family_DepressionComment;

						MedicalHistoryReportResponseDTO.Family_COPDAnswer = MedicalHistoryReport.Family_COPDAnswer;
						MedicalHistoryReportResponseDTO.Family_COPDComment = MedicalHistoryReport.Family_COPDComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalAnswer = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalComment = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedAnswer = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedComment = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedComment;

						MedicalHistoryReportResponseDTO.Family_AllergyAnswer = MedicalHistoryReport.Family_AllergyAnswer;
						MedicalHistoryReportResponseDTO.Family_AllergyComment = MedicalHistoryReport.Family_AllergyComment;

						MedicalHistoryReportResponseDTO.Family_GITAnswer = MedicalHistoryReport.Family_GITAnswer;
						MedicalHistoryReportResponseDTO.Family_GITComment = MedicalHistoryReport.Family_GITComment;

						MedicalHistoryReportResponseDTO.Family_HeartDiseaseAnswer = MedicalHistoryReport.Family_HeartDiseaseAnswer;
						MedicalHistoryReportResponseDTO.Family_HeartDiseaseComment = MedicalHistoryReport.Family_HeartDiseaseComment;

						MedicalHistoryReportResponseDTO.Family_HighBloodPressureAnswer = MedicalHistoryReport.Family_HighBloodPressureAnswer;
						MedicalHistoryReportResponseDTO.Family_HighBloodPressureComment = MedicalHistoryReport.Family_HighBloodPressureComment;

						MedicalHistoryReportResponseDTO.Family_HospitalizationAnswer = MedicalHistoryReport.Family_HospitalizationAnswer;
						MedicalHistoryReportResponseDTO.Family_HospitalizationComment = MedicalHistoryReport.Family_HospitalizationComment;

						MedicalHistoryReportResponseDTO.Family_InfectiousAnswer = MedicalHistoryReport.Family_InfectiousAnswer;
						MedicalHistoryReportResponseDTO.Family_InfectiousComment = MedicalHistoryReport.Family_InfectiousComment;

						MedicalHistoryReportResponseDTO.Family_KidneyAnswer = MedicalHistoryReport.Family_KidneyAnswer;
						MedicalHistoryReportResponseDTO.Family_KidneyComment = MedicalHistoryReport.Family_KidneyComment;

						MedicalHistoryReportResponseDTO.Family_NeurologicalAnswer = MedicalHistoryReport.Family_NeurologicalAnswer;
						MedicalHistoryReportResponseDTO.Family_NeurologicalComment = MedicalHistoryReport.Family_NeurologicalComment;

						MedicalHistoryReportResponseDTO.Family_SurgeryAnswer = MedicalHistoryReport.Family_SurgeryAnswer;
						MedicalHistoryReportResponseDTO.Family_SurgeryComment = MedicalHistoryReport.Family_SurgeryComment;

						MedicalHistoryReportResponseDTO.DoctorComments = MedicalHistoryReport.DoctorComments;
						MedicalHistoryReportResponseDTO.DoctorName = MedicalHistoryReport.DoctorName;

						MedicalHistoryReportResponseDTO.GeneralExamination_BloodPressure = MedicalHistoryReport.GeneralExamination_BloodPressure;
						MedicalHistoryReportResponseDTO.GeneralExamination_HeartRate = MedicalHistoryReport.GeneralExamination_HeartRate;

						MedicalHistoryReportResponseDTO.GeneralExamination_Height = MedicalHistoryReport.GeneralExamination_Height;
						MedicalHistoryReportResponseDTO.GeneralExamination_Weight = MedicalHistoryReport.GeneralExamination_Weight;

						MedicalHistoryReportResponseDTO.userName = MedicalHistoryReport.user.UserName;
						MedicalHistoryReportResponseDTO.userID = MedicalHistoryReport.user.Id;


						newTemp.Add(MedicalHistoryReportResponseDTO);
					}

					if (newTemp != null)
					{
						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}

				}

			}
			catch (Exception ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}

			return result;
		}

		[HttpGet("ByPage/{page:int}")]
		public PageResult<MedicalHistoryReportResponseDTO> GettAllMedicalHistoryReportByPage(string UserId, string UserRole, int? page, int pagesize = 10)
		{

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<MedicalHistoryReport> temp = MedicalHistoryReportRepository.getall();
					List<MedicalHistoryReportResponseDTO> newTemp = new List<MedicalHistoryReportResponseDTO>();
					foreach (MedicalHistoryReport MedicalHistoryReport in temp)
					{
						MedicalHistoryReportResponseDTO MedicalHistoryReportResponseDTO = new MedicalHistoryReportResponseDTO();
						MedicalHistoryReportResponseDTO.Id = MedicalHistoryReport.Id;
						MedicalHistoryReportResponseDTO.RigId = MedicalHistoryReport.Rig.Number;
						MedicalHistoryReportResponseDTO.Date = MedicalHistoryReport.Date;
						MedicalHistoryReportResponseDTO.DateOfBirth = MedicalHistoryReport.DateOfBirth;
						MedicalHistoryReportResponseDTO.Company = MedicalHistoryReport.Company;
						MedicalHistoryReportResponseDTO.Code = MedicalHistoryReport.Code;
						MedicalHistoryReportResponseDTO.Contact = MedicalHistoryReport.Contact;
						MedicalHistoryReportResponseDTO.Address = MedicalHistoryReport.Address;
						MedicalHistoryReportResponseDTO.TelephoneNumber = MedicalHistoryReport.TelephoneNumber;
						MedicalHistoryReportResponseDTO.Name = MedicalHistoryReport.Name;
						MedicalHistoryReportResponseDTO.Jop = MedicalHistoryReport.Jop;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyAnswer = MedicalHistoryReport.Socia_DoYouExerciseRegularlyAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyComment = MedicalHistoryReport.Socia_DoYouExerciseRegularlyComment;

						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeAnswer = MedicalHistoryReport.Socia_DoYouSmokeAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeComment = MedicalHistoryReport.Socia_DoYouSmokeComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedAnswer = MedicalHistoryReport.Socia_HaveYouBeenExposedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedComment = MedicalHistoryReport.Socia_HaveYouBeenExposedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedAnswer = MedicalHistoryReport.Socia_HaveYouEverDevelopedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedComment = MedicalHistoryReport.Socia_HaveYouEverDevelopedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedAnswer = MedicalHistoryReport.Socia_HaveYouSufferedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedComment = MedicalHistoryReport.Socia_HaveYouSufferedComment;

						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyAnswer = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyAnswer;
						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyComment = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyComment;

						MedicalHistoryReportResponseDTO.Family_DizzinessAnswer = MedicalHistoryReport.Family_DizzinessAnswer;
						MedicalHistoryReportResponseDTO.Family_DizzinessComment = MedicalHistoryReport.Family_DizzinessComment;

						MedicalHistoryReportResponseDTO.Family_DiscProlapseAnswer = MedicalHistoryReport.Family_DiscProlapseAnswer;
						MedicalHistoryReportResponseDTO.Family_DiscProlapseComment = MedicalHistoryReport.Family_DiscProlapseComment;

						MedicalHistoryReportResponseDTO.Family_DiabetesAnswer = MedicalHistoryReport.Family_DiabetesAnswer;
						MedicalHistoryReportResponseDTO.Family_DiabetesComment = MedicalHistoryReport.Family_DiabetesComment;

						MedicalHistoryReportResponseDTO.Family_DepressionAnswer = MedicalHistoryReport.Family_DepressionAnswer;
						MedicalHistoryReportResponseDTO.Family_DepressionComment = MedicalHistoryReport.Family_DepressionComment;

						MedicalHistoryReportResponseDTO.Family_COPDAnswer = MedicalHistoryReport.Family_COPDAnswer;
						MedicalHistoryReportResponseDTO.Family_COPDComment = MedicalHistoryReport.Family_COPDComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalAnswer = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalComment = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedAnswer = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedComment = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedComment;

						MedicalHistoryReportResponseDTO.Family_AllergyAnswer = MedicalHistoryReport.Family_AllergyAnswer;
						MedicalHistoryReportResponseDTO.Family_AllergyComment = MedicalHistoryReport.Family_AllergyComment;

						MedicalHistoryReportResponseDTO.Family_GITAnswer = MedicalHistoryReport.Family_GITAnswer;
						MedicalHistoryReportResponseDTO.Family_GITComment = MedicalHistoryReport.Family_GITComment;

						MedicalHistoryReportResponseDTO.Family_HeartDiseaseAnswer = MedicalHistoryReport.Family_HeartDiseaseAnswer;
						MedicalHistoryReportResponseDTO.Family_HeartDiseaseComment = MedicalHistoryReport.Family_HeartDiseaseComment;

						MedicalHistoryReportResponseDTO.Family_HighBloodPressureAnswer = MedicalHistoryReport.Family_HighBloodPressureAnswer;
						MedicalHistoryReportResponseDTO.Family_HighBloodPressureComment = MedicalHistoryReport.Family_HighBloodPressureComment;

						MedicalHistoryReportResponseDTO.Family_HospitalizationAnswer = MedicalHistoryReport.Family_HospitalizationAnswer;
						MedicalHistoryReportResponseDTO.Family_HospitalizationComment = MedicalHistoryReport.Family_HospitalizationComment;

						MedicalHistoryReportResponseDTO.Family_InfectiousAnswer = MedicalHistoryReport.Family_InfectiousAnswer;
						MedicalHistoryReportResponseDTO.Family_InfectiousComment = MedicalHistoryReport.Family_InfectiousComment;

						MedicalHistoryReportResponseDTO.Family_KidneyAnswer = MedicalHistoryReport.Family_KidneyAnswer;
						MedicalHistoryReportResponseDTO.Family_KidneyComment = MedicalHistoryReport.Family_KidneyComment;

						MedicalHistoryReportResponseDTO.Family_NeurologicalAnswer = MedicalHistoryReport.Family_NeurologicalAnswer;
						MedicalHistoryReportResponseDTO.Family_NeurologicalComment = MedicalHistoryReport.Family_NeurologicalComment;

						MedicalHistoryReportResponseDTO.Family_SurgeryAnswer = MedicalHistoryReport.Family_SurgeryAnswer;
						MedicalHistoryReportResponseDTO.Family_SurgeryComment = MedicalHistoryReport.Family_SurgeryComment;

						MedicalHistoryReportResponseDTO.DoctorComments = MedicalHistoryReport.DoctorComments;
						MedicalHistoryReportResponseDTO.DoctorName = MedicalHistoryReport.DoctorName;

						MedicalHistoryReportResponseDTO.GeneralExamination_BloodPressure = MedicalHistoryReport.GeneralExamination_BloodPressure;
						MedicalHistoryReportResponseDTO.GeneralExamination_HeartRate = MedicalHistoryReport.GeneralExamination_HeartRate;

						MedicalHistoryReportResponseDTO.GeneralExamination_Height = MedicalHistoryReport.GeneralExamination_Height;
						MedicalHistoryReportResponseDTO.GeneralExamination_Weight = MedicalHistoryReport.GeneralExamination_Weight;

						MedicalHistoryReportResponseDTO.userName = MedicalHistoryReport.user.UserName;
						MedicalHistoryReportResponseDTO.userID = MedicalHistoryReport.user.Id;


						newTemp.Add(MedicalHistoryReportResponseDTO);

					}

					float countDetails = MedicalHistoryReportRepository.getall().Count();
					var result = new PageResult<MedicalHistoryReportResponseDTO>
					{
						Count = (int)Math.Ceiling(countDetails / pagesize),
						PageIndex = page ?? 1,
						PageSize = pagesize,
						Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
					};

					return result;

				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<MedicalHistoryReport> temp = MedicalHistoryReportRepository.getall().Where(a => a.user.Id == UserId).ToList();
					List<MedicalHistoryReportResponseDTO> newTemp = new List<MedicalHistoryReportResponseDTO>();
					foreach (MedicalHistoryReport MedicalHistoryReport in temp)
					{
						MedicalHistoryReportResponseDTO MedicalHistoryReportResponseDTO = new MedicalHistoryReportResponseDTO();
						MedicalHistoryReportResponseDTO.Id = MedicalHistoryReport.Id;
						MedicalHistoryReportResponseDTO.RigId = MedicalHistoryReport.Rig.Number;
						MedicalHistoryReportResponseDTO.Date = MedicalHistoryReport.Date;
						MedicalHistoryReportResponseDTO.DateOfBirth = MedicalHistoryReport.DateOfBirth;
						MedicalHistoryReportResponseDTO.Company = MedicalHistoryReport.Company;
						MedicalHistoryReportResponseDTO.Code = MedicalHistoryReport.Code;
						MedicalHistoryReportResponseDTO.Contact = MedicalHistoryReport.Contact;
						MedicalHistoryReportResponseDTO.Address = MedicalHistoryReport.Address;
						MedicalHistoryReportResponseDTO.TelephoneNumber = MedicalHistoryReport.TelephoneNumber;
						MedicalHistoryReportResponseDTO.Name = MedicalHistoryReport.Name;
						MedicalHistoryReportResponseDTO.Jop = MedicalHistoryReport.Jop;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyAnswer = MedicalHistoryReport.Socia_DoYouExerciseRegularlyAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyComment = MedicalHistoryReport.Socia_DoYouExerciseRegularlyComment;

						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeAnswer = MedicalHistoryReport.Socia_DoYouSmokeAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeComment = MedicalHistoryReport.Socia_DoYouSmokeComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedAnswer = MedicalHistoryReport.Socia_HaveYouBeenExposedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedComment = MedicalHistoryReport.Socia_HaveYouBeenExposedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedAnswer = MedicalHistoryReport.Socia_HaveYouEverDevelopedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedComment = MedicalHistoryReport.Socia_HaveYouEverDevelopedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedAnswer = MedicalHistoryReport.Socia_HaveYouSufferedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedComment = MedicalHistoryReport.Socia_HaveYouSufferedComment;

						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyAnswer = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyAnswer;
						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyComment = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyComment;

						MedicalHistoryReportResponseDTO.Family_DizzinessAnswer = MedicalHistoryReport.Family_DizzinessAnswer;
						MedicalHistoryReportResponseDTO.Family_DizzinessComment = MedicalHistoryReport.Family_DizzinessComment;

						MedicalHistoryReportResponseDTO.Family_DiscProlapseAnswer = MedicalHistoryReport.Family_DiscProlapseAnswer;
						MedicalHistoryReportResponseDTO.Family_DiscProlapseComment = MedicalHistoryReport.Family_DiscProlapseComment;

						MedicalHistoryReportResponseDTO.Family_DiabetesAnswer = MedicalHistoryReport.Family_DiabetesAnswer;
						MedicalHistoryReportResponseDTO.Family_DiabetesComment = MedicalHistoryReport.Family_DiabetesComment;

						MedicalHistoryReportResponseDTO.Family_DepressionAnswer = MedicalHistoryReport.Family_DepressionAnswer;
						MedicalHistoryReportResponseDTO.Family_DepressionComment = MedicalHistoryReport.Family_DepressionComment;

						MedicalHistoryReportResponseDTO.Family_COPDAnswer = MedicalHistoryReport.Family_COPDAnswer;
						MedicalHistoryReportResponseDTO.Family_COPDComment = MedicalHistoryReport.Family_COPDComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalAnswer = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalComment = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedAnswer = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedComment = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedComment;

						MedicalHistoryReportResponseDTO.Family_AllergyAnswer = MedicalHistoryReport.Family_AllergyAnswer;
						MedicalHistoryReportResponseDTO.Family_AllergyComment = MedicalHistoryReport.Family_AllergyComment;

						MedicalHistoryReportResponseDTO.Family_GITAnswer = MedicalHistoryReport.Family_GITAnswer;
						MedicalHistoryReportResponseDTO.Family_GITComment = MedicalHistoryReport.Family_GITComment;

						MedicalHistoryReportResponseDTO.Family_HeartDiseaseAnswer = MedicalHistoryReport.Family_HeartDiseaseAnswer;
						MedicalHistoryReportResponseDTO.Family_HeartDiseaseComment = MedicalHistoryReport.Family_HeartDiseaseComment;

						MedicalHistoryReportResponseDTO.Family_HighBloodPressureAnswer = MedicalHistoryReport.Family_HighBloodPressureAnswer;
						MedicalHistoryReportResponseDTO.Family_HighBloodPressureComment = MedicalHistoryReport.Family_HighBloodPressureComment;

						MedicalHistoryReportResponseDTO.Family_HospitalizationAnswer = MedicalHistoryReport.Family_HospitalizationAnswer;
						MedicalHistoryReportResponseDTO.Family_HospitalizationComment = MedicalHistoryReport.Family_HospitalizationComment;

						MedicalHistoryReportResponseDTO.Family_InfectiousAnswer = MedicalHistoryReport.Family_InfectiousAnswer;
						MedicalHistoryReportResponseDTO.Family_InfectiousComment = MedicalHistoryReport.Family_InfectiousComment;

						MedicalHistoryReportResponseDTO.Family_KidneyAnswer = MedicalHistoryReport.Family_KidneyAnswer;
						MedicalHistoryReportResponseDTO.Family_KidneyComment = MedicalHistoryReport.Family_KidneyComment;

						MedicalHistoryReportResponseDTO.Family_NeurologicalAnswer = MedicalHistoryReport.Family_NeurologicalAnswer;
						MedicalHistoryReportResponseDTO.Family_NeurologicalComment = MedicalHistoryReport.Family_NeurologicalComment;

						MedicalHistoryReportResponseDTO.Family_SurgeryAnswer = MedicalHistoryReport.Family_SurgeryAnswer;
						MedicalHistoryReportResponseDTO.Family_SurgeryComment = MedicalHistoryReport.Family_SurgeryComment;

						MedicalHistoryReportResponseDTO.DoctorComments = MedicalHistoryReport.DoctorComments;
						MedicalHistoryReportResponseDTO.DoctorName = MedicalHistoryReport.DoctorName;

						MedicalHistoryReportResponseDTO.GeneralExamination_BloodPressure = MedicalHistoryReport.GeneralExamination_BloodPressure;
						MedicalHistoryReportResponseDTO.GeneralExamination_HeartRate = MedicalHistoryReport.GeneralExamination_HeartRate;

						MedicalHistoryReportResponseDTO.GeneralExamination_Height = MedicalHistoryReport.GeneralExamination_Height;
						MedicalHistoryReportResponseDTO.GeneralExamination_Weight = MedicalHistoryReport.GeneralExamination_Weight;

						MedicalHistoryReportResponseDTO.userName = MedicalHistoryReport.user.UserName;
						MedicalHistoryReportResponseDTO.userID = MedicalHistoryReport.user.Id;


						newTemp.Add(MedicalHistoryReportResponseDTO);
					}

					float countDetails = MedicalHistoryReportRepository.getall().Where(a => a.user.Id == UserId).Count();
					var result = new PageResult<MedicalHistoryReportResponseDTO>
					{
						Count = (int)Math.Ceiling(countDetails / pagesize),
						PageIndex = page ?? 1,
						PageSize = pagesize,
						Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
					};

					return result;
				}
			}
			catch (Exception ex)
			{
				return new PageResult<MedicalHistoryReportResponseDTO>();

			}
			return new PageResult<MedicalHistoryReportResponseDTO>();
		}

		[HttpGet("GetDataById/{ID:int}")]
		public ActionResult<ResultDTO> GetAllWithDataByID(int ID, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();


			if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
			{
				MedicalHistoryReport temp = MedicalHistoryReportRepository.getall().FirstOrDefault(a => a.Id == ID);
				if (temp != null)
				{
					MedicalHistoryReportResponseDTO MedicalHistoryReportResponseDTO = new MedicalHistoryReportResponseDTO();
					MedicalHistoryReportResponseDTO.Id = temp.Id;
					MedicalHistoryReportResponseDTO.RigId = temp.RigId;
					MedicalHistoryReportResponseDTO.Date = temp.Date;
					MedicalHistoryReportResponseDTO.DateOfBirth = temp.DateOfBirth;
					MedicalHistoryReportResponseDTO.Company = temp.Company;
					MedicalHistoryReportResponseDTO.Code = temp.Code;
					MedicalHistoryReportResponseDTO.Contact = temp.Contact;
					MedicalHistoryReportResponseDTO.Address = temp.Address;
					MedicalHistoryReportResponseDTO.TelephoneNumber = temp.TelephoneNumber;
					MedicalHistoryReportResponseDTO.Name = temp.Name;
					MedicalHistoryReportResponseDTO.Jop = temp.Jop;
					MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyAnswer = temp.Socia_DoYouExerciseRegularlyAnswer;
					MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyComment = temp.Socia_DoYouExerciseRegularlyComment;

					MedicalHistoryReportResponseDTO.Socia_DoYouSmokeAnswer = temp.Socia_DoYouSmokeAnswer;
					MedicalHistoryReportResponseDTO.Socia_DoYouSmokeComment = temp.Socia_DoYouSmokeComment;

					MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedAnswer = temp.Socia_HaveYouBeenExposedAnswer;
					MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedComment = temp.Socia_HaveYouBeenExposedComment;

					MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedAnswer = temp.Socia_HaveYouEverDevelopedAnswer;
					MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedComment = temp.Socia_HaveYouEverDevelopedComment;

					MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedAnswer = temp.Socia_HaveYouSufferedAnswer;
					MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedComment = temp.Socia_HaveYouSufferedComment;

					MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyAnswer = temp.Family_DoAnyOfYour1stDegreeFamilyAnswer;
					MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyComment = temp.Family_DoAnyOfYour1stDegreeFamilyComment;

					MedicalHistoryReportResponseDTO.Family_DizzinessAnswer = temp.Family_DizzinessAnswer;
					MedicalHistoryReportResponseDTO.Family_DizzinessComment = temp.Family_DizzinessComment;

					MedicalHistoryReportResponseDTO.Family_DiscProlapseAnswer = temp.Family_DiscProlapseAnswer;
					MedicalHistoryReportResponseDTO.Family_DiscProlapseComment = temp.Family_DiscProlapseComment;

					MedicalHistoryReportResponseDTO.Family_DiabetesAnswer = temp.Family_DiabetesAnswer;
					MedicalHistoryReportResponseDTO.Family_DiabetesComment = temp.Family_DiabetesComment;

					MedicalHistoryReportResponseDTO.Family_DepressionAnswer = temp.Family_DepressionAnswer;
					MedicalHistoryReportResponseDTO.Family_DepressionComment = temp.Family_DepressionComment;

					MedicalHistoryReportResponseDTO.Family_COPDAnswer = temp.Family_COPDAnswer;
					MedicalHistoryReportResponseDTO.Family_COPDComment = temp.Family_COPDComment;

					MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalAnswer = temp.Family_AreYouCurrentlyReceivingAnyMedicalAnswer;
					MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalComment = temp.Family_AreYouCurrentlyReceivingAnyMedicalComment;

					MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedAnswer = temp.Family_AreYouCurrentlyBeingTreatedAnswer;
					MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedComment = temp.Family_AreYouCurrentlyBeingTreatedComment;

					MedicalHistoryReportResponseDTO.Family_AllergyAnswer = temp.Family_AllergyAnswer;
					MedicalHistoryReportResponseDTO.Family_AllergyComment = temp.Family_AllergyComment;

					MedicalHistoryReportResponseDTO.Family_GITAnswer = temp.Family_GITAnswer;
					MedicalHistoryReportResponseDTO.Family_GITComment = temp.Family_GITComment;

					MedicalHistoryReportResponseDTO.Family_HeartDiseaseAnswer = temp.Family_HeartDiseaseAnswer;
					MedicalHistoryReportResponseDTO.Family_HeartDiseaseComment = temp.Family_HeartDiseaseComment;

					MedicalHistoryReportResponseDTO.Family_HighBloodPressureAnswer = temp.Family_HighBloodPressureAnswer;
					MedicalHistoryReportResponseDTO.Family_HighBloodPressureComment = temp.Family_HighBloodPressureComment;

					MedicalHistoryReportResponseDTO.Family_HospitalizationAnswer = temp.Family_HospitalizationAnswer;
					MedicalHistoryReportResponseDTO.Family_HospitalizationComment = temp.Family_HospitalizationComment;

					MedicalHistoryReportResponseDTO.Family_InfectiousAnswer = temp.Family_InfectiousAnswer;
					MedicalHistoryReportResponseDTO.Family_InfectiousComment = temp.Family_InfectiousComment;

					MedicalHistoryReportResponseDTO.Family_KidneyAnswer = temp.Family_KidneyAnswer;
					MedicalHistoryReportResponseDTO.Family_KidneyComment = temp.Family_KidneyComment;

					MedicalHistoryReportResponseDTO.Family_NeurologicalAnswer = temp.Family_NeurologicalAnswer;
					MedicalHistoryReportResponseDTO.Family_NeurologicalComment = temp.Family_NeurologicalComment;

					MedicalHistoryReportResponseDTO.Family_SurgeryAnswer = temp.Family_SurgeryAnswer;
					MedicalHistoryReportResponseDTO.Family_SurgeryComment = temp.Family_SurgeryComment;

					MedicalHistoryReportResponseDTO.DoctorComments = temp.DoctorComments;
					MedicalHistoryReportResponseDTO.DoctorName = temp.DoctorName;

					MedicalHistoryReportResponseDTO.GeneralExamination_BloodPressure = temp.GeneralExamination_BloodPressure;
					MedicalHistoryReportResponseDTO.GeneralExamination_HeartRate = temp.GeneralExamination_HeartRate;

					MedicalHistoryReportResponseDTO.GeneralExamination_Height = temp.GeneralExamination_Height;
					MedicalHistoryReportResponseDTO.GeneralExamination_Weight = temp.GeneralExamination_Weight;

					MedicalHistoryReportResponseDTO.userName = temp.user.UserName;
					MedicalHistoryReportResponseDTO.userID = temp.user.Id;

					if (MedicalHistoryReportResponseDTO != null)
					{

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = MedicalHistoryReportResponseDTO;

						return result;
					}
				}

			}
			else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
			{
				MedicalHistoryReport temp = MedicalHistoryReportRepository.getall().FirstOrDefault(a => a.Id == ID && a.user.Id == UserId);
				if (temp != null)
				{
					MedicalHistoryReportResponseDTO MedicalHistoryReportResponseDTO = new MedicalHistoryReportResponseDTO();
					MedicalHistoryReportResponseDTO.Id = temp.Id;
					MedicalHistoryReportResponseDTO.RigId = temp.RigId;
					MedicalHistoryReportResponseDTO.Date = temp.Date;
					MedicalHistoryReportResponseDTO.DateOfBirth = temp.DateOfBirth;
					MedicalHistoryReportResponseDTO.Company = temp.Company;
					MedicalHistoryReportResponseDTO.Code = temp.Code;
					MedicalHistoryReportResponseDTO.Contact = temp.Contact;
					MedicalHistoryReportResponseDTO.Address = temp.Address;
					MedicalHistoryReportResponseDTO.TelephoneNumber = temp.TelephoneNumber;
					MedicalHistoryReportResponseDTO.Name = temp.Name;
					MedicalHistoryReportResponseDTO.Jop = temp.Jop;
					MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyAnswer = temp.Socia_DoYouExerciseRegularlyAnswer;
					MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyComment = temp.Socia_DoYouExerciseRegularlyComment;

					MedicalHistoryReportResponseDTO.Socia_DoYouSmokeAnswer = temp.Socia_DoYouSmokeAnswer;
					MedicalHistoryReportResponseDTO.Socia_DoYouSmokeComment = temp.Socia_DoYouSmokeComment;

					MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedAnswer = temp.Socia_HaveYouBeenExposedAnswer;
					MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedComment = temp.Socia_HaveYouBeenExposedComment;

					MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedAnswer = temp.Socia_HaveYouEverDevelopedAnswer;
					MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedComment = temp.Socia_HaveYouEverDevelopedComment;

					MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedAnswer = temp.Socia_HaveYouSufferedAnswer;
					MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedComment = temp.Socia_HaveYouSufferedComment;

					MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyAnswer = temp.Family_DoAnyOfYour1stDegreeFamilyAnswer;
					MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyComment = temp.Family_DoAnyOfYour1stDegreeFamilyComment;

					MedicalHistoryReportResponseDTO.Family_DizzinessAnswer = temp.Family_DizzinessAnswer;
					MedicalHistoryReportResponseDTO.Family_DizzinessComment = temp.Family_DizzinessComment;

					MedicalHistoryReportResponseDTO.Family_DiscProlapseAnswer = temp.Family_DiscProlapseAnswer;
					MedicalHistoryReportResponseDTO.Family_DiscProlapseComment = temp.Family_DiscProlapseComment;

					MedicalHistoryReportResponseDTO.Family_DiabetesAnswer = temp.Family_DiabetesAnswer;
					MedicalHistoryReportResponseDTO.Family_DiabetesComment = temp.Family_DiabetesComment;

					MedicalHistoryReportResponseDTO.Family_DepressionAnswer = temp.Family_DepressionAnswer;
					MedicalHistoryReportResponseDTO.Family_DepressionComment = temp.Family_DepressionComment;

					MedicalHistoryReportResponseDTO.Family_COPDAnswer = temp.Family_COPDAnswer;
					MedicalHistoryReportResponseDTO.Family_COPDComment = temp.Family_COPDComment;

					MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalAnswer = temp.Family_AreYouCurrentlyReceivingAnyMedicalAnswer;
					MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalComment = temp.Family_AreYouCurrentlyReceivingAnyMedicalComment;

					MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedAnswer = temp.Family_AreYouCurrentlyBeingTreatedAnswer;
					MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedComment = temp.Family_AreYouCurrentlyBeingTreatedComment;

					MedicalHistoryReportResponseDTO.Family_AllergyAnswer = temp.Family_AllergyAnswer;
					MedicalHistoryReportResponseDTO.Family_AllergyComment = temp.Family_AllergyComment;

					MedicalHistoryReportResponseDTO.Family_GITAnswer = temp.Family_GITAnswer;
					MedicalHistoryReportResponseDTO.Family_GITComment = temp.Family_GITComment;

					MedicalHistoryReportResponseDTO.Family_HeartDiseaseAnswer = temp.Family_HeartDiseaseAnswer;
					MedicalHistoryReportResponseDTO.Family_HeartDiseaseComment = temp.Family_HeartDiseaseComment;

					MedicalHistoryReportResponseDTO.Family_HighBloodPressureAnswer = temp.Family_HighBloodPressureAnswer;
					MedicalHistoryReportResponseDTO.Family_HighBloodPressureComment = temp.Family_HighBloodPressureComment;

					MedicalHistoryReportResponseDTO.Family_HospitalizationAnswer = temp.Family_HospitalizationAnswer;
					MedicalHistoryReportResponseDTO.Family_HospitalizationComment = temp.Family_HospitalizationComment;

					MedicalHistoryReportResponseDTO.Family_InfectiousAnswer = temp.Family_InfectiousAnswer;
					MedicalHistoryReportResponseDTO.Family_InfectiousComment = temp.Family_InfectiousComment;

					MedicalHistoryReportResponseDTO.Family_KidneyAnswer = temp.Family_KidneyAnswer;
					MedicalHistoryReportResponseDTO.Family_KidneyComment = temp.Family_KidneyComment;

					MedicalHistoryReportResponseDTO.Family_NeurologicalAnswer = temp.Family_NeurologicalAnswer;
					MedicalHistoryReportResponseDTO.Family_NeurologicalComment = temp.Family_NeurologicalComment;

					MedicalHistoryReportResponseDTO.Family_SurgeryAnswer = temp.Family_SurgeryAnswer;
					MedicalHistoryReportResponseDTO.Family_SurgeryComment = temp.Family_SurgeryComment;

					MedicalHistoryReportResponseDTO.DoctorComments = temp.DoctorComments;
					MedicalHistoryReportResponseDTO.DoctorName = temp.DoctorName;

					MedicalHistoryReportResponseDTO.GeneralExamination_BloodPressure = temp.GeneralExamination_BloodPressure;
					MedicalHistoryReportResponseDTO.GeneralExamination_HeartRate = temp.GeneralExamination_HeartRate;

					MedicalHistoryReportResponseDTO.GeneralExamination_Height = temp.GeneralExamination_Height;
					MedicalHistoryReportResponseDTO.GeneralExamination_Weight = temp.GeneralExamination_Weight;

					MedicalHistoryReportResponseDTO.userName = temp.user.UserName;
					MedicalHistoryReportResponseDTO.userID = temp.user.Id;


					if (MedicalHistoryReportResponseDTO != null)
					{

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = MedicalHistoryReportResponseDTO;

						return result;
					}
				}

			}

			result.Statescode = 404;
			result.Message = "data not found";
			return result;
		}

		[HttpGet("Print/{ID:int}")]
		public ActionResult<ResultDTO> GetAllWithDataByIDForPrint(int ID, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();


			if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
			{
				MedicalHistoryReport temp = MedicalHistoryReportRepository.getall().FirstOrDefault(a => a.Id == ID);
				if (temp != null)
				{
					MedicalHistoryReportResponseDTO MedicalHistoryReportResponseDTO = new MedicalHistoryReportResponseDTO();
					MedicalHistoryReportResponseDTO.Id = temp.Id;
					MedicalHistoryReportResponseDTO.RigId = temp.Rig.Number;
					MedicalHistoryReportResponseDTO.Date = temp.Date;
					MedicalHistoryReportResponseDTO.DateOfBirth = temp.DateOfBirth;
					MedicalHistoryReportResponseDTO.Company = temp.Company;
					MedicalHistoryReportResponseDTO.Code = temp.Code;
					MedicalHistoryReportResponseDTO.Contact = temp.Contact;
					MedicalHistoryReportResponseDTO.Address = temp.Address;
					MedicalHistoryReportResponseDTO.TelephoneNumber = temp.TelephoneNumber;
					MedicalHistoryReportResponseDTO.Name = temp.Name;
					MedicalHistoryReportResponseDTO.Jop = temp.Jop;
					MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyAnswer = temp.Socia_DoYouExerciseRegularlyAnswer;
					MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyComment = temp.Socia_DoYouExerciseRegularlyComment;

					MedicalHistoryReportResponseDTO.Socia_DoYouSmokeAnswer = temp.Socia_DoYouSmokeAnswer;
					MedicalHistoryReportResponseDTO.Socia_DoYouSmokeComment = temp.Socia_DoYouSmokeComment;

					MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedAnswer = temp.Socia_HaveYouBeenExposedAnswer;
					MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedComment = temp.Socia_HaveYouBeenExposedComment;

					MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedAnswer = temp.Socia_HaveYouEverDevelopedAnswer;
					MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedComment = temp.Socia_HaveYouEverDevelopedComment;

					MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedAnswer = temp.Socia_HaveYouSufferedAnswer;
					MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedComment = temp.Socia_HaveYouSufferedComment;

					MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyAnswer = temp.Family_DoAnyOfYour1stDegreeFamilyAnswer;
					MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyComment = temp.Family_DoAnyOfYour1stDegreeFamilyComment;

					MedicalHistoryReportResponseDTO.Family_DizzinessAnswer = temp.Family_DizzinessAnswer;
					MedicalHistoryReportResponseDTO.Family_DizzinessComment = temp.Family_DizzinessComment;

					MedicalHistoryReportResponseDTO.Family_DiscProlapseAnswer = temp.Family_DiscProlapseAnswer;
					MedicalHistoryReportResponseDTO.Family_DiscProlapseComment = temp.Family_DiscProlapseComment;

					MedicalHistoryReportResponseDTO.Family_DiabetesAnswer = temp.Family_DiabetesAnswer;
					MedicalHistoryReportResponseDTO.Family_DiabetesComment = temp.Family_DiabetesComment;

					MedicalHistoryReportResponseDTO.Family_DepressionAnswer = temp.Family_DepressionAnswer;
					MedicalHistoryReportResponseDTO.Family_DepressionComment = temp.Family_DepressionComment;

					MedicalHistoryReportResponseDTO.Family_COPDAnswer = temp.Family_COPDAnswer;
					MedicalHistoryReportResponseDTO.Family_COPDComment = temp.Family_COPDComment;

					MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalAnswer = temp.Family_AreYouCurrentlyReceivingAnyMedicalAnswer;
					MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalComment = temp.Family_AreYouCurrentlyReceivingAnyMedicalComment;

					MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedAnswer = temp.Family_AreYouCurrentlyBeingTreatedAnswer;
					MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedComment = temp.Family_AreYouCurrentlyBeingTreatedComment;

					MedicalHistoryReportResponseDTO.Family_AllergyAnswer = temp.Family_AllergyAnswer;
					MedicalHistoryReportResponseDTO.Family_AllergyComment = temp.Family_AllergyComment;

					MedicalHistoryReportResponseDTO.Family_GITAnswer = temp.Family_GITAnswer;
					MedicalHistoryReportResponseDTO.Family_GITComment = temp.Family_GITComment;

					MedicalHistoryReportResponseDTO.Family_HeartDiseaseAnswer = temp.Family_HeartDiseaseAnswer;
					MedicalHistoryReportResponseDTO.Family_HeartDiseaseComment = temp.Family_HeartDiseaseComment;

					MedicalHistoryReportResponseDTO.Family_HighBloodPressureAnswer = temp.Family_HighBloodPressureAnswer;
					MedicalHistoryReportResponseDTO.Family_HighBloodPressureComment = temp.Family_HighBloodPressureComment;

					MedicalHistoryReportResponseDTO.Family_HospitalizationAnswer = temp.Family_HospitalizationAnswer;
					MedicalHistoryReportResponseDTO.Family_HospitalizationComment = temp.Family_HospitalizationComment;

					MedicalHistoryReportResponseDTO.Family_InfectiousAnswer = temp.Family_InfectiousAnswer;
					MedicalHistoryReportResponseDTO.Family_InfectiousComment = temp.Family_InfectiousComment;

					MedicalHistoryReportResponseDTO.Family_KidneyAnswer = temp.Family_KidneyAnswer;
					MedicalHistoryReportResponseDTO.Family_KidneyComment = temp.Family_KidneyComment;

					MedicalHistoryReportResponseDTO.Family_NeurologicalAnswer = temp.Family_NeurologicalAnswer;
					MedicalHistoryReportResponseDTO.Family_NeurologicalComment = temp.Family_NeurologicalComment;

					MedicalHistoryReportResponseDTO.Family_SurgeryAnswer = temp.Family_SurgeryAnswer;
					MedicalHistoryReportResponseDTO.Family_SurgeryComment = temp.Family_SurgeryComment;

					MedicalHistoryReportResponseDTO.DoctorComments = temp.DoctorComments;
					MedicalHistoryReportResponseDTO.DoctorName = temp.DoctorName;

					MedicalHistoryReportResponseDTO.GeneralExamination_BloodPressure = temp.GeneralExamination_BloodPressure;
					MedicalHistoryReportResponseDTO.GeneralExamination_HeartRate = temp.GeneralExamination_HeartRate;

					MedicalHistoryReportResponseDTO.GeneralExamination_Height = temp.GeneralExamination_Height;
					MedicalHistoryReportResponseDTO.GeneralExamination_Weight = temp.GeneralExamination_Weight;

					MedicalHistoryReportResponseDTO.userName = temp.user.UserName;
					MedicalHistoryReportResponseDTO.userID = temp.user.Id;

					if (MedicalHistoryReportResponseDTO != null)
					{

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = MedicalHistoryReportResponseDTO;

						return result;
					}
				}

			}
			else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
			{
				MedicalHistoryReport temp = MedicalHistoryReportRepository.getall().FirstOrDefault(a => a.Id == ID && a.user.Id == UserId);
				if (temp != null)
				{
					MedicalHistoryReportResponseDTO MedicalHistoryReportResponseDTO = new MedicalHistoryReportResponseDTO();
					MedicalHistoryReportResponseDTO.Id = temp.Id;
					MedicalHistoryReportResponseDTO.RigId = temp.Rig.Number;
					MedicalHistoryReportResponseDTO.Date = temp.Date;
					MedicalHistoryReportResponseDTO.DateOfBirth = temp.DateOfBirth;
					MedicalHistoryReportResponseDTO.Company = temp.Company;
					MedicalHistoryReportResponseDTO.Code = temp.Code;
					MedicalHistoryReportResponseDTO.Contact = temp.Contact;
					MedicalHistoryReportResponseDTO.Address = temp.Address;
					MedicalHistoryReportResponseDTO.TelephoneNumber = temp.TelephoneNumber;
					MedicalHistoryReportResponseDTO.Name = temp.Name;
					MedicalHistoryReportResponseDTO.Jop = temp.Jop;
					MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyAnswer = temp.Socia_DoYouExerciseRegularlyAnswer;
					MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyComment = temp.Socia_DoYouExerciseRegularlyComment;

					MedicalHistoryReportResponseDTO.Socia_DoYouSmokeAnswer = temp.Socia_DoYouSmokeAnswer;
					MedicalHistoryReportResponseDTO.Socia_DoYouSmokeComment = temp.Socia_DoYouSmokeComment;

					MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedAnswer = temp.Socia_HaveYouBeenExposedAnswer;
					MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedComment = temp.Socia_HaveYouBeenExposedComment;

					MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedAnswer = temp.Socia_HaveYouEverDevelopedAnswer;
					MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedComment = temp.Socia_HaveYouEverDevelopedComment;

					MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedAnswer = temp.Socia_HaveYouSufferedAnswer;
					MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedComment = temp.Socia_HaveYouSufferedComment;

					MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyAnswer = temp.Family_DoAnyOfYour1stDegreeFamilyAnswer;
					MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyComment = temp.Family_DoAnyOfYour1stDegreeFamilyComment;

					MedicalHistoryReportResponseDTO.Family_DizzinessAnswer = temp.Family_DizzinessAnswer;
					MedicalHistoryReportResponseDTO.Family_DizzinessComment = temp.Family_DizzinessComment;

					MedicalHistoryReportResponseDTO.Family_DiscProlapseAnswer = temp.Family_DiscProlapseAnswer;
					MedicalHistoryReportResponseDTO.Family_DiscProlapseComment = temp.Family_DiscProlapseComment;

					MedicalHistoryReportResponseDTO.Family_DiabetesAnswer = temp.Family_DiabetesAnswer;
					MedicalHistoryReportResponseDTO.Family_DiabetesComment = temp.Family_DiabetesComment;

					MedicalHistoryReportResponseDTO.Family_DepressionAnswer = temp.Family_DepressionAnswer;
					MedicalHistoryReportResponseDTO.Family_DepressionComment = temp.Family_DepressionComment;

					MedicalHistoryReportResponseDTO.Family_COPDAnswer = temp.Family_COPDAnswer;
					MedicalHistoryReportResponseDTO.Family_COPDComment = temp.Family_COPDComment;

					MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalAnswer = temp.Family_AreYouCurrentlyReceivingAnyMedicalAnswer;
					MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalComment = temp.Family_AreYouCurrentlyReceivingAnyMedicalComment;

					MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedAnswer = temp.Family_AreYouCurrentlyBeingTreatedAnswer;
					MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedComment = temp.Family_AreYouCurrentlyBeingTreatedComment;

					MedicalHistoryReportResponseDTO.Family_AllergyAnswer = temp.Family_AllergyAnswer;
					MedicalHistoryReportResponseDTO.Family_AllergyComment = temp.Family_AllergyComment;

					MedicalHistoryReportResponseDTO.Family_GITAnswer = temp.Family_GITAnswer;
					MedicalHistoryReportResponseDTO.Family_GITComment = temp.Family_GITComment;

					MedicalHistoryReportResponseDTO.Family_HeartDiseaseAnswer = temp.Family_HeartDiseaseAnswer;
					MedicalHistoryReportResponseDTO.Family_HeartDiseaseComment = temp.Family_HeartDiseaseComment;

					MedicalHistoryReportResponseDTO.Family_HighBloodPressureAnswer = temp.Family_HighBloodPressureAnswer;
					MedicalHistoryReportResponseDTO.Family_HighBloodPressureComment = temp.Family_HighBloodPressureComment;

					MedicalHistoryReportResponseDTO.Family_HospitalizationAnswer = temp.Family_HospitalizationAnswer;
					MedicalHistoryReportResponseDTO.Family_HospitalizationComment = temp.Family_HospitalizationComment;

					MedicalHistoryReportResponseDTO.Family_InfectiousAnswer = temp.Family_InfectiousAnswer;
					MedicalHistoryReportResponseDTO.Family_InfectiousComment = temp.Family_InfectiousComment;

					MedicalHistoryReportResponseDTO.Family_KidneyAnswer = temp.Family_KidneyAnswer;
					MedicalHistoryReportResponseDTO.Family_KidneyComment = temp.Family_KidneyComment;

					MedicalHistoryReportResponseDTO.Family_NeurologicalAnswer = temp.Family_NeurologicalAnswer;
					MedicalHistoryReportResponseDTO.Family_NeurologicalComment = temp.Family_NeurologicalComment;

					MedicalHistoryReportResponseDTO.Family_SurgeryAnswer = temp.Family_SurgeryAnswer;
					MedicalHistoryReportResponseDTO.Family_SurgeryComment = temp.Family_SurgeryComment;

					MedicalHistoryReportResponseDTO.DoctorComments = temp.DoctorComments;
					MedicalHistoryReportResponseDTO.DoctorName = temp.DoctorName;

					MedicalHistoryReportResponseDTO.GeneralExamination_BloodPressure = temp.GeneralExamination_BloodPressure;
					MedicalHistoryReportResponseDTO.GeneralExamination_HeartRate = temp.GeneralExamination_HeartRate;

					MedicalHistoryReportResponseDTO.GeneralExamination_Height = temp.GeneralExamination_Height;
					MedicalHistoryReportResponseDTO.GeneralExamination_Weight = temp.GeneralExamination_Weight;

					MedicalHistoryReportResponseDTO.userName = temp.user.UserName;
					MedicalHistoryReportResponseDTO.userID = temp.user.Id;


					if (MedicalHistoryReportResponseDTO != null)
					{

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = MedicalHistoryReportResponseDTO;

						return result;
					}
				}

			}

			result.Statescode = 404;
			result.Message = "data not found";
			return result;
		}


		//  ------------------ filter by MedicalHistoryReport ------------------------------------------
		[HttpGet("GetDataByRigAndDateAndName")]
		public ActionResult<ResultDTO> GetDataByRigAndDateAndName(string Name, string UserId, string UserRole, int RigNumber, string Jop)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<MedicalHistoryReport> MedicalHistoryReports = MedicalHistoryReportRepository.getall().Where(a => a.Name == Name && a.Rig.Number == RigNumber && a.Jop == Jop).ToList();
					List<MedicalHistoryReportResponseDTO> MedicalHistoryReportResponseDTOs = new List<MedicalHistoryReportResponseDTO>();
					foreach (MedicalHistoryReport MedicalHistoryReport in MedicalHistoryReports)
					{
						MedicalHistoryReportResponseDTO MedicalHistoryReportResponseDTO = new MedicalHistoryReportResponseDTO();
						MedicalHistoryReportResponseDTO.Id = MedicalHistoryReport.Id;
						MedicalHistoryReportResponseDTO.RigId = MedicalHistoryReport.Rig.Number;
						MedicalHistoryReportResponseDTO.Date = MedicalHistoryReport.Date;
						MedicalHistoryReportResponseDTO.DateOfBirth = MedicalHistoryReport.DateOfBirth;
						MedicalHistoryReportResponseDTO.Company = MedicalHistoryReport.Company;
						MedicalHistoryReportResponseDTO.Code = MedicalHistoryReport.Code;
						MedicalHistoryReportResponseDTO.Contact = MedicalHistoryReport.Contact;
						MedicalHistoryReportResponseDTO.Address = MedicalHistoryReport.Address;
						MedicalHistoryReportResponseDTO.TelephoneNumber = MedicalHistoryReport.TelephoneNumber;
						MedicalHistoryReportResponseDTO.Name = MedicalHistoryReport.Name;
						MedicalHistoryReportResponseDTO.Jop = MedicalHistoryReport.Jop;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyAnswer = MedicalHistoryReport.Socia_DoYouExerciseRegularlyAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyComment = MedicalHistoryReport.Socia_DoYouExerciseRegularlyComment;

						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeAnswer = MedicalHistoryReport.Socia_DoYouSmokeAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeComment = MedicalHistoryReport.Socia_DoYouSmokeComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedAnswer = MedicalHistoryReport.Socia_HaveYouBeenExposedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedComment = MedicalHistoryReport.Socia_HaveYouBeenExposedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedAnswer = MedicalHistoryReport.Socia_HaveYouEverDevelopedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedComment = MedicalHistoryReport.Socia_HaveYouEverDevelopedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedAnswer = MedicalHistoryReport.Socia_HaveYouSufferedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedComment = MedicalHistoryReport.Socia_HaveYouSufferedComment;

						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyAnswer = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyAnswer;
						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyComment = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyComment;

						MedicalHistoryReportResponseDTO.Family_DizzinessAnswer = MedicalHistoryReport.Family_DizzinessAnswer;
						MedicalHistoryReportResponseDTO.Family_DizzinessComment = MedicalHistoryReport.Family_DizzinessComment;

						MedicalHistoryReportResponseDTO.Family_DiscProlapseAnswer = MedicalHistoryReport.Family_DiscProlapseAnswer;
						MedicalHistoryReportResponseDTO.Family_DiscProlapseComment = MedicalHistoryReport.Family_DiscProlapseComment;

						MedicalHistoryReportResponseDTO.Family_DiabetesAnswer = MedicalHistoryReport.Family_DiabetesAnswer;
						MedicalHistoryReportResponseDTO.Family_DiabetesComment = MedicalHistoryReport.Family_DiabetesComment;

						MedicalHistoryReportResponseDTO.Family_DepressionAnswer = MedicalHistoryReport.Family_DepressionAnswer;
						MedicalHistoryReportResponseDTO.Family_DepressionComment = MedicalHistoryReport.Family_DepressionComment;

						MedicalHistoryReportResponseDTO.Family_COPDAnswer = MedicalHistoryReport.Family_COPDAnswer;
						MedicalHistoryReportResponseDTO.Family_COPDComment = MedicalHistoryReport.Family_COPDComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalAnswer = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalComment = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedAnswer = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedComment = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedComment;

						MedicalHistoryReportResponseDTO.Family_AllergyAnswer = MedicalHistoryReport.Family_AllergyAnswer;
						MedicalHistoryReportResponseDTO.Family_AllergyComment = MedicalHistoryReport.Family_AllergyComment;

						MedicalHistoryReportResponseDTO.Family_GITAnswer = MedicalHistoryReport.Family_GITAnswer;
						MedicalHistoryReportResponseDTO.Family_GITComment = MedicalHistoryReport.Family_GITComment;

						MedicalHistoryReportResponseDTO.Family_HeartDiseaseAnswer = MedicalHistoryReport.Family_HeartDiseaseAnswer;
						MedicalHistoryReportResponseDTO.Family_HeartDiseaseComment = MedicalHistoryReport.Family_HeartDiseaseComment;

						MedicalHistoryReportResponseDTO.Family_HighBloodPressureAnswer = MedicalHistoryReport.Family_HighBloodPressureAnswer;
						MedicalHistoryReportResponseDTO.Family_HighBloodPressureComment = MedicalHistoryReport.Family_HighBloodPressureComment;

						MedicalHistoryReportResponseDTO.Family_HospitalizationAnswer = MedicalHistoryReport.Family_HospitalizationAnswer;
						MedicalHistoryReportResponseDTO.Family_HospitalizationComment = MedicalHistoryReport.Family_HospitalizationComment;

						MedicalHistoryReportResponseDTO.Family_InfectiousAnswer = MedicalHistoryReport.Family_InfectiousAnswer;
						MedicalHistoryReportResponseDTO.Family_InfectiousComment = MedicalHistoryReport.Family_InfectiousComment;

						MedicalHistoryReportResponseDTO.Family_KidneyAnswer = MedicalHistoryReport.Family_KidneyAnswer;
						MedicalHistoryReportResponseDTO.Family_KidneyComment = MedicalHistoryReport.Family_KidneyComment;

						MedicalHistoryReportResponseDTO.Family_NeurologicalAnswer = MedicalHistoryReport.Family_NeurologicalAnswer;
						MedicalHistoryReportResponseDTO.Family_NeurologicalComment = MedicalHistoryReport.Family_NeurologicalComment;

						MedicalHistoryReportResponseDTO.Family_SurgeryAnswer = MedicalHistoryReport.Family_SurgeryAnswer;
						MedicalHistoryReportResponseDTO.Family_SurgeryComment = MedicalHistoryReport.Family_SurgeryComment;

						//MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyAnswer = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyComment;
						//MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyComment = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyComment;

						MedicalHistoryReportResponseDTO.DoctorComments = MedicalHistoryReport.DoctorComments;
						MedicalHistoryReportResponseDTO.DoctorName = MedicalHistoryReport.DoctorName;

						MedicalHistoryReportResponseDTO.GeneralExamination_BloodPressure = MedicalHistoryReport.GeneralExamination_BloodPressure;
						MedicalHistoryReportResponseDTO.GeneralExamination_HeartRate = MedicalHistoryReport.GeneralExamination_HeartRate;

						MedicalHistoryReportResponseDTO.GeneralExamination_Height = MedicalHistoryReport.GeneralExamination_Height;
						MedicalHistoryReportResponseDTO.GeneralExamination_Weight = MedicalHistoryReport.GeneralExamination_Weight;

						MedicalHistoryReportResponseDTO.userName = MedicalHistoryReport.user.UserName;
						MedicalHistoryReportResponseDTO.userID = MedicalHistoryReport.user.Id;


						MedicalHistoryReportResponseDTOs.Add(MedicalHistoryReportResponseDTO);
					}




					result.Message = "Success";
					result.Data = MedicalHistoryReportResponseDTOs;
					result.Statescode = 200;
					return result;
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<MedicalHistoryReport> MedicalHistoryReports = MedicalHistoryReportRepository.getall().Where(a => a.Name == Name && a.Rig.Number == RigNumber && a.user.Id == UserId && a.Jop == Jop).ToList();
					List<MedicalHistoryReportResponseDTO> MedicalHistoryReportResponseDTOs = new List<MedicalHistoryReportResponseDTO>();
					foreach (MedicalHistoryReport MedicalHistoryReport in MedicalHistoryReports)
					{
						MedicalHistoryReportResponseDTO MedicalHistoryReportResponseDTO = new MedicalHistoryReportResponseDTO();
						MedicalHistoryReportResponseDTO.Id = MedicalHistoryReport.Id;
						MedicalHistoryReportResponseDTO.RigId = MedicalHistoryReport.Rig.Number;
						MedicalHistoryReportResponseDTO.Date = MedicalHistoryReport.Date;
						MedicalHistoryReportResponseDTO.DateOfBirth = MedicalHistoryReport.DateOfBirth;
						MedicalHistoryReportResponseDTO.Company = MedicalHistoryReport.Company;
						MedicalHistoryReportResponseDTO.Code = MedicalHistoryReport.Code;
						MedicalHistoryReportResponseDTO.Contact = MedicalHistoryReport.Contact;
						MedicalHistoryReportResponseDTO.Address = MedicalHistoryReport.Address;
						MedicalHistoryReportResponseDTO.TelephoneNumber = MedicalHistoryReport.TelephoneNumber;
						MedicalHistoryReportResponseDTO.Name = MedicalHistoryReport.Name;
						MedicalHistoryReportResponseDTO.Jop = MedicalHistoryReport.Jop;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyAnswer = MedicalHistoryReport.Socia_DoYouExerciseRegularlyAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyComment = MedicalHistoryReport.Socia_DoYouExerciseRegularlyComment;

						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeAnswer = MedicalHistoryReport.Socia_DoYouSmokeAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeComment = MedicalHistoryReport.Socia_DoYouSmokeComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedAnswer = MedicalHistoryReport.Socia_HaveYouBeenExposedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedComment = MedicalHistoryReport.Socia_HaveYouBeenExposedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedAnswer = MedicalHistoryReport.Socia_HaveYouEverDevelopedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedComment = MedicalHistoryReport.Socia_HaveYouEverDevelopedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedAnswer = MedicalHistoryReport.Socia_HaveYouSufferedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedComment = MedicalHistoryReport.Socia_HaveYouSufferedComment;

						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyAnswer = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyAnswer;
						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyComment = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyComment;

						MedicalHistoryReportResponseDTO.Family_DizzinessAnswer = MedicalHistoryReport.Family_DizzinessAnswer;
						MedicalHistoryReportResponseDTO.Family_DizzinessComment = MedicalHistoryReport.Family_DizzinessComment;

						MedicalHistoryReportResponseDTO.Family_DiscProlapseAnswer = MedicalHistoryReport.Family_DiscProlapseAnswer;
						MedicalHistoryReportResponseDTO.Family_DiscProlapseComment = MedicalHistoryReport.Family_DiscProlapseComment;

						MedicalHistoryReportResponseDTO.Family_DiabetesAnswer = MedicalHistoryReport.Family_DiabetesAnswer;
						MedicalHistoryReportResponseDTO.Family_DiabetesComment = MedicalHistoryReport.Family_DiabetesComment;

						MedicalHistoryReportResponseDTO.Family_DepressionAnswer = MedicalHistoryReport.Family_DepressionAnswer;
						MedicalHistoryReportResponseDTO.Family_DepressionComment = MedicalHistoryReport.Family_DepressionComment;

						MedicalHistoryReportResponseDTO.Family_COPDAnswer = MedicalHistoryReport.Family_COPDAnswer;
						MedicalHistoryReportResponseDTO.Family_COPDComment = MedicalHistoryReport.Family_COPDComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalAnswer = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalComment = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedAnswer = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedComment = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedComment;

						MedicalHistoryReportResponseDTO.Family_AllergyAnswer = MedicalHistoryReport.Family_AllergyAnswer;
						MedicalHistoryReportResponseDTO.Family_AllergyComment = MedicalHistoryReport.Family_AllergyComment;

						MedicalHistoryReportResponseDTO.Family_GITAnswer = MedicalHistoryReport.Family_GITAnswer;
						MedicalHistoryReportResponseDTO.Family_GITComment = MedicalHistoryReport.Family_GITComment;

						MedicalHistoryReportResponseDTO.Family_HeartDiseaseAnswer = MedicalHistoryReport.Family_HeartDiseaseAnswer;
						MedicalHistoryReportResponseDTO.Family_HeartDiseaseComment = MedicalHistoryReport.Family_HeartDiseaseComment;

						MedicalHistoryReportResponseDTO.Family_HighBloodPressureAnswer = MedicalHistoryReport.Family_HighBloodPressureAnswer;
						MedicalHistoryReportResponseDTO.Family_HighBloodPressureComment = MedicalHistoryReport.Family_HighBloodPressureComment;

						MedicalHistoryReportResponseDTO.Family_HospitalizationAnswer = MedicalHistoryReport.Family_HospitalizationAnswer;
						MedicalHistoryReportResponseDTO.Family_HospitalizationComment = MedicalHistoryReport.Family_HospitalizationComment;

						MedicalHistoryReportResponseDTO.Family_InfectiousAnswer = MedicalHistoryReport.Family_InfectiousAnswer;
						MedicalHistoryReportResponseDTO.Family_InfectiousComment = MedicalHistoryReport.Family_InfectiousComment;

						MedicalHistoryReportResponseDTO.Family_KidneyAnswer = MedicalHistoryReport.Family_KidneyAnswer;
						MedicalHistoryReportResponseDTO.Family_KidneyComment = MedicalHistoryReport.Family_KidneyComment;

						MedicalHistoryReportResponseDTO.Family_NeurologicalAnswer = MedicalHistoryReport.Family_NeurologicalAnswer;
						MedicalHistoryReportResponseDTO.Family_NeurologicalComment = MedicalHistoryReport.Family_NeurologicalComment;

						MedicalHistoryReportResponseDTO.Family_SurgeryAnswer = MedicalHistoryReport.Family_SurgeryAnswer;
						MedicalHistoryReportResponseDTO.Family_SurgeryComment = MedicalHistoryReport.Family_SurgeryComment;

						MedicalHistoryReportResponseDTO.DoctorComments = MedicalHistoryReport.DoctorComments;
						MedicalHistoryReportResponseDTO.DoctorName = MedicalHistoryReport.DoctorName;

						MedicalHistoryReportResponseDTO.GeneralExamination_BloodPressure = MedicalHistoryReport.GeneralExamination_BloodPressure;
						MedicalHistoryReportResponseDTO.GeneralExamination_HeartRate = MedicalHistoryReport.GeneralExamination_HeartRate;

						MedicalHistoryReportResponseDTO.GeneralExamination_Height = MedicalHistoryReport.GeneralExamination_Height;
						MedicalHistoryReportResponseDTO.GeneralExamination_Weight = MedicalHistoryReport.GeneralExamination_Weight;

						MedicalHistoryReportResponseDTO.userName = MedicalHistoryReport.user.UserName;
						MedicalHistoryReportResponseDTO.userID = MedicalHistoryReport.user.Id;


						MedicalHistoryReportResponseDTOs.Add(MedicalHistoryReportResponseDTO);
					}


					result.Message = "Success";
					result.Data = MedicalHistoryReportResponseDTOs;
					result.Statescode = 200;
					return result;
				}

			}
			catch (Exception ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}

			return result;

		}


		[HttpPost]
		public ActionResult<ResultDTO> AddMedicalHistoryReport([FromForm] MedicalHistoryReportDTO MedicalHistoryReport)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{

					MedicalHistoryReport MedicalHistoryReportResponseDTO = new MedicalHistoryReport();
					MedicalHistoryReportResponseDTO.Id = default;
					MedicalHistoryReportResponseDTO.RigId = MedicalHistoryReport.RigId;
					MedicalHistoryReportResponseDTO.Date = MedicalHistoryReport.Date;
					MedicalHistoryReportResponseDTO.DateOfBirth = MedicalHistoryReport.DateOfBirth;
					MedicalHistoryReportResponseDTO.Company = MedicalHistoryReport.Company;
					MedicalHistoryReportResponseDTO.Code = MedicalHistoryReport.Code;
					MedicalHistoryReportResponseDTO.Contact = MedicalHistoryReport.Contact;
					MedicalHistoryReportResponseDTO.Address = MedicalHistoryReport.Address;
					MedicalHistoryReportResponseDTO.TelephoneNumber = MedicalHistoryReport.TelephoneNumber;
					MedicalHistoryReportResponseDTO.Name = MedicalHistoryReport.Name;
					MedicalHistoryReportResponseDTO.Jop = MedicalHistoryReport.Jop;
					MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyAnswer = MedicalHistoryReport.Socia_DoYouExerciseRegularlyAnswer;
					MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyComment = MedicalHistoryReport.Socia_DoYouExerciseRegularlyComment;

					MedicalHistoryReportResponseDTO.Socia_DoYouSmokeAnswer = MedicalHistoryReport.Socia_DoYouSmokeAnswer;
					MedicalHistoryReportResponseDTO.Socia_DoYouSmokeComment = MedicalHistoryReport.Socia_DoYouSmokeComment;

					MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedAnswer = MedicalHistoryReport.Socia_HaveYouBeenExposedAnswer;
					MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedComment = MedicalHistoryReport.Socia_HaveYouBeenExposedComment;

					MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedAnswer = MedicalHistoryReport.Socia_HaveYouEverDevelopedAnswer;
					MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedComment = MedicalHistoryReport.Socia_HaveYouEverDevelopedComment;

					MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedAnswer = MedicalHistoryReport.Socia_HaveYouSufferedAnswer;
					MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedComment = MedicalHistoryReport.Socia_HaveYouSufferedComment;

					MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyAnswer = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyAnswer;
					MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyComment = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyComment;

					MedicalHistoryReportResponseDTO.Family_DizzinessAnswer = MedicalHistoryReport.Family_DizzinessAnswer;
					MedicalHistoryReportResponseDTO.Family_DizzinessComment = MedicalHistoryReport.Family_DizzinessComment;

					MedicalHistoryReportResponseDTO.Family_DiscProlapseAnswer = MedicalHistoryReport.Family_DiscProlapseAnswer;
					MedicalHistoryReportResponseDTO.Family_DiscProlapseComment = MedicalHistoryReport.Family_DiscProlapseComment;

					MedicalHistoryReportResponseDTO.Family_DiabetesAnswer = MedicalHistoryReport.Family_DiabetesAnswer;
					MedicalHistoryReportResponseDTO.Family_DiabetesComment = MedicalHistoryReport.Family_DiabetesComment;

					MedicalHistoryReportResponseDTO.Family_DepressionAnswer = MedicalHistoryReport.Family_DepressionAnswer;
					MedicalHistoryReportResponseDTO.Family_DepressionComment = MedicalHistoryReport.Family_DepressionComment;

					MedicalHistoryReportResponseDTO.Family_COPDAnswer = MedicalHistoryReport.Family_COPDAnswer;
					MedicalHistoryReportResponseDTO.Family_COPDComment = MedicalHistoryReport.Family_COPDComment;

					MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalAnswer = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalAnswer;
					MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalComment = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalComment;

					MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedAnswer = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedAnswer;
					MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedComment = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedComment;

					MedicalHistoryReportResponseDTO.Family_AllergyAnswer = MedicalHistoryReport.Family_AllergyAnswer;
					MedicalHistoryReportResponseDTO.Family_AllergyComment = MedicalHistoryReport.Family_AllergyComment;

					MedicalHistoryReportResponseDTO.Family_GITAnswer = MedicalHistoryReport.Family_GITAnswer;
					MedicalHistoryReportResponseDTO.Family_GITComment = MedicalHistoryReport.Family_GITComment;

					MedicalHistoryReportResponseDTO.Family_HeartDiseaseAnswer = MedicalHistoryReport.Family_HeartDiseaseAnswer;
					MedicalHistoryReportResponseDTO.Family_HeartDiseaseComment = MedicalHistoryReport.Family_HeartDiseaseComment;

					MedicalHistoryReportResponseDTO.Family_HighBloodPressureAnswer = MedicalHistoryReport.Family_HighBloodPressureAnswer;
					MedicalHistoryReportResponseDTO.Family_HighBloodPressureComment = MedicalHistoryReport.Family_HighBloodPressureComment;

					MedicalHistoryReportResponseDTO.Family_HospitalizationAnswer = MedicalHistoryReport.Family_HospitalizationAnswer;
					MedicalHistoryReportResponseDTO.Family_HospitalizationComment = MedicalHistoryReport.Family_HospitalizationComment;

					MedicalHistoryReportResponseDTO.Family_InfectiousAnswer = MedicalHistoryReport.Family_InfectiousAnswer;
					MedicalHistoryReportResponseDTO.Family_InfectiousComment = MedicalHistoryReport.Family_InfectiousComment;

					MedicalHistoryReportResponseDTO.Family_KidneyAnswer = MedicalHistoryReport.Family_KidneyAnswer;
					MedicalHistoryReportResponseDTO.Family_KidneyComment = MedicalHistoryReport.Family_KidneyComment;

					MedicalHistoryReportResponseDTO.Family_NeurologicalAnswer = MedicalHistoryReport.Family_NeurologicalAnswer;
					MedicalHistoryReportResponseDTO.Family_NeurologicalComment = MedicalHistoryReport.Family_NeurologicalComment;

					MedicalHistoryReportResponseDTO.Family_SurgeryAnswer = MedicalHistoryReport.Family_SurgeryAnswer;
					MedicalHistoryReportResponseDTO.Family_SurgeryComment = MedicalHistoryReport.Family_SurgeryComment;

					MedicalHistoryReportResponseDTO.DoctorComments = MedicalHistoryReport.DoctorComments;
					MedicalHistoryReportResponseDTO.DoctorName = MedicalHistoryReport.DoctorName;

					MedicalHistoryReportResponseDTO.GeneralExamination_BloodPressure = MedicalHistoryReport.GeneralExamination_BloodPressure;
					MedicalHistoryReportResponseDTO.GeneralExamination_HeartRate = MedicalHistoryReport.GeneralExamination_HeartRate;

					MedicalHistoryReportResponseDTO.GeneralExamination_Height = MedicalHistoryReport.GeneralExamination_Height;
					MedicalHistoryReportResponseDTO.GeneralExamination_Weight = MedicalHistoryReport.GeneralExamination_Weight;

					MedicalHistoryReportResponseDTO.userID = MedicalHistoryReport.userID;
					MedicalHistoryReportRepo.create(MedicalHistoryReportResponseDTO);


					result.Message = "Success";
					result.Data = MedicalHistoryReportResponseDTO;
					result.Statescode = 200;
				}
				catch (Exception ex)
				{
					result.Message = "Error in inserting";
					result.Statescode = 400;
				}
			}
			return result;
		}


		[HttpPut("{id:int}")]
		public ActionResult<ResultDTO> Put(int id, [FromForm] MedicalHistoryReportDTO newMedicalHistoryReport) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					MedicalHistoryReport orgMedicalHistoryReport = MedicalHistoryReportRepo.getbyid(id);

					newMedicalHistoryReport.Id = orgMedicalHistoryReport.Id;
					orgMedicalHistoryReport.RigId = newMedicalHistoryReport.RigId;
					orgMedicalHistoryReport.Date = newMedicalHistoryReport.Date;
					orgMedicalHistoryReport.DateOfBirth = newMedicalHistoryReport.DateOfBirth;
					orgMedicalHistoryReport.Company = newMedicalHistoryReport.Company;
					orgMedicalHistoryReport.Code = newMedicalHistoryReport.Code;
					orgMedicalHistoryReport.Contact = newMedicalHistoryReport.Contact;
					orgMedicalHistoryReport.Address = newMedicalHistoryReport.Address;
					orgMedicalHistoryReport.TelephoneNumber = newMedicalHistoryReport.TelephoneNumber;
					orgMedicalHistoryReport.Name = newMedicalHistoryReport.Name;
					orgMedicalHistoryReport.Jop = newMedicalHistoryReport.Jop;
					orgMedicalHistoryReport.Socia_DoYouExerciseRegularlyAnswer = newMedicalHistoryReport.Socia_DoYouExerciseRegularlyAnswer;
					orgMedicalHistoryReport.Socia_DoYouExerciseRegularlyComment = newMedicalHistoryReport.Socia_DoYouExerciseRegularlyComment;

					orgMedicalHistoryReport.Socia_DoYouSmokeAnswer = newMedicalHistoryReport.Socia_DoYouSmokeAnswer;
					orgMedicalHistoryReport.Socia_DoYouSmokeComment = newMedicalHistoryReport.Socia_DoYouSmokeComment;

					orgMedicalHistoryReport.Socia_HaveYouBeenExposedAnswer = newMedicalHistoryReport.Socia_HaveYouBeenExposedAnswer;
					orgMedicalHistoryReport.Socia_HaveYouBeenExposedComment = newMedicalHistoryReport.Socia_HaveYouBeenExposedComment;

					orgMedicalHistoryReport.Socia_HaveYouEverDevelopedAnswer = newMedicalHistoryReport.Socia_HaveYouEverDevelopedAnswer;
					orgMedicalHistoryReport.Socia_HaveYouEverDevelopedComment = newMedicalHistoryReport.Socia_HaveYouEverDevelopedComment;

					orgMedicalHistoryReport.Socia_HaveYouSufferedAnswer = newMedicalHistoryReport.Socia_HaveYouSufferedAnswer;
					orgMedicalHistoryReport.Socia_HaveYouSufferedComment = newMedicalHistoryReport.Socia_HaveYouSufferedComment;

					orgMedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyAnswer = newMedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyAnswer;
					orgMedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyComment = newMedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyComment;

					orgMedicalHistoryReport.Family_DizzinessAnswer = newMedicalHistoryReport.Family_DizzinessAnswer;
					orgMedicalHistoryReport.Family_DizzinessComment = newMedicalHistoryReport.Family_DizzinessComment;

					orgMedicalHistoryReport.Family_DiscProlapseAnswer = newMedicalHistoryReport.Family_DiscProlapseAnswer;
					orgMedicalHistoryReport.Family_DiscProlapseComment = newMedicalHistoryReport.Family_DiscProlapseComment;

					orgMedicalHistoryReport.Family_DiabetesAnswer = newMedicalHistoryReport.Family_DiabetesAnswer;
					orgMedicalHistoryReport.Family_DiabetesComment = newMedicalHistoryReport.Family_DiabetesComment;

					orgMedicalHistoryReport.Family_DepressionAnswer = newMedicalHistoryReport.Family_DepressionAnswer;
					orgMedicalHistoryReport.Family_DepressionComment = newMedicalHistoryReport.Family_DepressionComment;

					orgMedicalHistoryReport.Family_COPDAnswer = newMedicalHistoryReport.Family_COPDAnswer;
					orgMedicalHistoryReport.Family_COPDComment = newMedicalHistoryReport.Family_COPDComment;

					orgMedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalAnswer = newMedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalAnswer;
					orgMedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalComment = newMedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalComment;

					orgMedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedAnswer = newMedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedAnswer;
					orgMedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedComment = newMedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedComment;

					orgMedicalHistoryReport.Family_AllergyAnswer = newMedicalHistoryReport.Family_AllergyAnswer;
					orgMedicalHistoryReport.Family_AllergyComment = newMedicalHistoryReport.Family_AllergyComment;

					orgMedicalHistoryReport.Family_GITAnswer = newMedicalHistoryReport.Family_GITAnswer;
					orgMedicalHistoryReport.Family_GITComment = newMedicalHistoryReport.Family_GITComment;

					orgMedicalHistoryReport.Family_HeartDiseaseAnswer = newMedicalHistoryReport.Family_HeartDiseaseAnswer;
					orgMedicalHistoryReport.Family_HeartDiseaseComment = newMedicalHistoryReport.Family_HeartDiseaseComment;

					orgMedicalHistoryReport.Family_HighBloodPressureAnswer = newMedicalHistoryReport.Family_HighBloodPressureAnswer;
					orgMedicalHistoryReport.Family_HighBloodPressureComment = newMedicalHistoryReport.Family_HighBloodPressureComment;

					orgMedicalHistoryReport.Family_HospitalizationAnswer = newMedicalHistoryReport.Family_HospitalizationAnswer;
					orgMedicalHistoryReport.Family_HospitalizationComment = newMedicalHistoryReport.Family_HospitalizationComment;

					orgMedicalHistoryReport.Family_InfectiousAnswer = newMedicalHistoryReport.Family_InfectiousAnswer;
					orgMedicalHistoryReport.Family_InfectiousComment = newMedicalHistoryReport.Family_InfectiousComment;

					orgMedicalHistoryReport.Family_KidneyAnswer = newMedicalHistoryReport.Family_KidneyAnswer;
					orgMedicalHistoryReport.Family_KidneyComment = newMedicalHistoryReport.Family_KidneyComment;

					orgMedicalHistoryReport.Family_NeurologicalAnswer = newMedicalHistoryReport.Family_NeurologicalAnswer;
					orgMedicalHistoryReport.Family_NeurologicalComment = newMedicalHistoryReport.Family_NeurologicalComment;

					orgMedicalHistoryReport.Family_SurgeryAnswer = newMedicalHistoryReport.Family_SurgeryAnswer;
					orgMedicalHistoryReport.Family_SurgeryComment = newMedicalHistoryReport.Family_SurgeryComment;

					orgMedicalHistoryReport.DoctorComments = newMedicalHistoryReport.DoctorComments;
					orgMedicalHistoryReport.DoctorName = newMedicalHistoryReport.DoctorName;

					orgMedicalHistoryReport.GeneralExamination_BloodPressure = newMedicalHistoryReport.GeneralExamination_BloodPressure;
					orgMedicalHistoryReport.GeneralExamination_HeartRate = newMedicalHistoryReport.GeneralExamination_HeartRate;

					orgMedicalHistoryReport.GeneralExamination_Height = newMedicalHistoryReport.GeneralExamination_Height;
					orgMedicalHistoryReport.GeneralExamination_Weight = newMedicalHistoryReport.GeneralExamination_Weight;


					//orgMedicalHistoryReport.userID = newMedicalHistoryReport.userID;

					MedicalHistoryReportRepo.update(orgMedicalHistoryReport);
					result.Data = orgMedicalHistoryReport;
					result.Statescode = 200;
					return result;


				}
				catch (Exception ex)
				{
					result.Message = "Error in Updating";
					result.Statescode = 400;
					return result;
				}
			}
			return BadRequest(ModelState);
		}

		[HttpPut("Delete/{id:int}")]
		public ActionResult<ResultDTO> Delete(int id) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				MedicalHistoryReport MedicalHistoryReport = MedicalHistoryReportRepo.getbyid(id);
				MedicalHistoryReport.IsDeleted = true;
				MedicalHistoryReportRepo.update(MedicalHistoryReport);
				result.Data = MedicalHistoryReport;
				result.Statescode = 200;
				result.Message = "Success";
			}
			catch (Exception ex)
			{
				result.Message = "Error in deleted";
				result.Statescode = 400;
			}

			return result;
		}



		/// *********************** Analysis For Admin ************************

		[HttpGet("GetMedicalHistoryReportAnalysisWithCompareByYear")]
		public ActionResult<ResultDTO> GetMedicalHistoryReportAnalysisWithCompareByYear([FromQuery] int Rig, string UserRole)
		{

			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<MedicalHistoryReport> temp = MedicalHistoryReportRepository.getall().Where(r => (r.Rig.Id == Rig)).ToList();


					List<MedicalHistoryReportResponseDTO> newTemp = new List<MedicalHistoryReportResponseDTO>();
					foreach (MedicalHistoryReport MedicalHistoryReport in temp)
					{
						MedicalHistoryReportResponseDTO MedicalHistoryReportResponseDTO = new MedicalHistoryReportResponseDTO();
						MedicalHistoryReportResponseDTO.Id = MedicalHistoryReport.Id;
						MedicalHistoryReportResponseDTO.RigId = MedicalHistoryReport.Rig.Id;
						MedicalHistoryReportResponseDTO.Date = MedicalHistoryReport.Date;
						MedicalHistoryReportResponseDTO.userID = MedicalHistoryReport.user.Id;

						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyAnswer = MedicalHistoryReport.Socia_DoYouExerciseRegularlyAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyComment = MedicalHistoryReport.Socia_DoYouExerciseRegularlyComment;

						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeAnswer = MedicalHistoryReport.Socia_DoYouSmokeAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeComment = MedicalHistoryReport.Socia_DoYouSmokeComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedAnswer = MedicalHistoryReport.Socia_HaveYouBeenExposedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedComment = MedicalHistoryReport.Socia_HaveYouBeenExposedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedAnswer = MedicalHistoryReport.Socia_HaveYouEverDevelopedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedComment = MedicalHistoryReport.Socia_HaveYouEverDevelopedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedAnswer = MedicalHistoryReport.Socia_HaveYouSufferedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedComment = MedicalHistoryReport.Socia_HaveYouSufferedComment;
						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyAnswer = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyAnswer;
						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyComment = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyComment;

						MedicalHistoryReportResponseDTO.Family_DizzinessAnswer = MedicalHistoryReport.Family_DizzinessAnswer;
						MedicalHistoryReportResponseDTO.Family_DizzinessComment = MedicalHistoryReport.Family_DizzinessComment;

						MedicalHistoryReportResponseDTO.Family_DiscProlapseAnswer = MedicalHistoryReport.Family_DiscProlapseAnswer;
						MedicalHistoryReportResponseDTO.Family_DiscProlapseComment = MedicalHistoryReport.Family_DiscProlapseComment;

						MedicalHistoryReportResponseDTO.Family_DiabetesAnswer = MedicalHistoryReport.Family_DiabetesAnswer;
						MedicalHistoryReportResponseDTO.Family_DiabetesComment = MedicalHistoryReport.Family_DiabetesComment;

						MedicalHistoryReportResponseDTO.Family_DepressionAnswer = MedicalHistoryReport.Family_DepressionAnswer;
						MedicalHistoryReportResponseDTO.Family_DepressionComment = MedicalHistoryReport.Family_DepressionComment;

						MedicalHistoryReportResponseDTO.Family_COPDAnswer = MedicalHistoryReport.Family_COPDAnswer;
						MedicalHistoryReportResponseDTO.Family_COPDComment = MedicalHistoryReport.Family_COPDComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalAnswer = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalComment = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedAnswer = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedComment = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedComment;

						MedicalHistoryReportResponseDTO.Family_AllergyAnswer = MedicalHistoryReport.Family_AllergyAnswer;
						MedicalHistoryReportResponseDTO.Family_AllergyComment = MedicalHistoryReport.Family_AllergyComment;

						MedicalHistoryReportResponseDTO.Family_GITAnswer = MedicalHistoryReport.Family_GITAnswer;
						MedicalHistoryReportResponseDTO.Family_GITComment = MedicalHistoryReport.Family_GITComment;

						MedicalHistoryReportResponseDTO.Family_HeartDiseaseAnswer = MedicalHistoryReport.Family_HeartDiseaseAnswer;
						MedicalHistoryReportResponseDTO.Family_HeartDiseaseComment = MedicalHistoryReport.Family_HeartDiseaseComment;

						MedicalHistoryReportResponseDTO.Family_HighBloodPressureAnswer = MedicalHistoryReport.Family_HighBloodPressureAnswer;
						MedicalHistoryReportResponseDTO.Family_HighBloodPressureComment = MedicalHistoryReport.Family_HighBloodPressureComment;

						MedicalHistoryReportResponseDTO.Family_HospitalizationAnswer = MedicalHistoryReport.Family_HospitalizationAnswer;
						MedicalHistoryReportResponseDTO.Family_HospitalizationComment = MedicalHistoryReport.Family_HospitalizationComment;

						MedicalHistoryReportResponseDTO.Family_InfectiousAnswer = MedicalHistoryReport.Family_InfectiousAnswer;
						MedicalHistoryReportResponseDTO.Family_InfectiousComment = MedicalHistoryReport.Family_InfectiousComment;

						MedicalHistoryReportResponseDTO.Family_KidneyAnswer = MedicalHistoryReport.Family_KidneyAnswer;
						MedicalHistoryReportResponseDTO.Family_KidneyComment = MedicalHistoryReport.Family_KidneyComment;

						MedicalHistoryReportResponseDTO.Family_NeurologicalAnswer = MedicalHistoryReport.Family_NeurologicalAnswer;
						MedicalHistoryReportResponseDTO.Family_NeurologicalComment = MedicalHistoryReport.Family_NeurologicalComment;

						MedicalHistoryReportResponseDTO.Family_SurgeryAnswer = MedicalHistoryReport.Family_SurgeryAnswer;
						MedicalHistoryReportResponseDTO.Family_SurgeryComment = MedicalHistoryReport.Family_SurgeryComment;

						newTemp.Add(MedicalHistoryReportResponseDTO);
					}
					if (newTemp != null)
					{

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}
				}
			}
			catch (Exception ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}
			return result;
		}

		[HttpGet("SearchByDieases")]
		public ActionResult<ResultDTO> SearchByDieases(string Diseases, string UserRole)
		{
			string newDiseases = Diseases.Replace("%20", "");
			Console.WriteLine(newDiseases);

			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<MedicalHistoryReport> temp = MedicalHistoryReportRepository.getall()
	  .Where(e => e.Socia_DoYouSmokeAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))


				  || e.Socia_HaveYouSufferedAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))
				  || e.Socia_HaveYouEverDevelopedAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))
				  || e.Socia_HaveYouBeenExposedAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))
				  || e.Socia_DoYouExerciseRegularlyAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))

				  || e.Family_AreYouCurrentlyBeingTreatedAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))

				 || e.Family_AreYouCurrentlyReceivingAnyMedicalAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))

				  || e.Family_HighBloodPressureAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))

				  || e.Family_HeartDiseaseAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))

				  || e.Family_COPDAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))

				  || e.Family_DiabetesAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))

				  || e.Family_GITAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))


				  || e.Family_KidneyAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))

				  || e.Family_NeurologicalAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))

				  || e.Family_InfectiousAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))

				  || e.Family_HospitalizationAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))

				  || e.Family_SurgeryAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))

				  || e.Family_DepressionAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))

				  || e.Family_DoAnyOfYour1stDegreeFamilyAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))

				  || e.Family_AllergyAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))

				  || e.Family_DiscProlapseAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))

				  || e.Family_DizzinessAnswer.Equals("Yes", StringComparison.OrdinalIgnoreCase) &&
				  SearchList.Any(disease => GetDiseaseByName(e, disease).Equals(newDiseases, StringComparison.OrdinalIgnoreCase))

				  )
	  .ToList();



					List<MedicalHistoryReportResponseDTO> newTemp = new List<MedicalHistoryReportResponseDTO>();

					foreach (MedicalHistoryReport MedicalHistoryReport in temp)
					{
						MedicalHistoryReportResponseDTO MedicalHistoryReportResponseDTO = new MedicalHistoryReportResponseDTO();
						MedicalHistoryReportResponseDTO.Id = MedicalHistoryReport.Id;
						MedicalHistoryReportResponseDTO.RigId = MedicalHistoryReport.Rig.Number;
						MedicalHistoryReportResponseDTO.Date = MedicalHistoryReport.Date;
						MedicalHistoryReportResponseDTO.DateOfBirth = MedicalHistoryReport.DateOfBirth;
						MedicalHistoryReportResponseDTO.Company = MedicalHistoryReport.Company;
						MedicalHistoryReportResponseDTO.Code = MedicalHistoryReport.Code;
						MedicalHistoryReportResponseDTO.Contact = MedicalHistoryReport.Contact;
						MedicalHistoryReportResponseDTO.Address = MedicalHistoryReport.Address;
						MedicalHistoryReportResponseDTO.TelephoneNumber = MedicalHistoryReport.TelephoneNumber;
						MedicalHistoryReportResponseDTO.Name = MedicalHistoryReport.Name;
						MedicalHistoryReportResponseDTO.Jop = MedicalHistoryReport.Jop;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyAnswer = MedicalHistoryReport.Socia_DoYouExerciseRegularlyAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyComment = MedicalHistoryReport.Socia_DoYouExerciseRegularlyComment;

						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeAnswer = MedicalHistoryReport.Socia_DoYouSmokeAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeComment = MedicalHistoryReport.Socia_DoYouSmokeComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedAnswer = MedicalHistoryReport.Socia_HaveYouBeenExposedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedComment = MedicalHistoryReport.Socia_HaveYouBeenExposedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedAnswer = MedicalHistoryReport.Socia_HaveYouEverDevelopedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedComment = MedicalHistoryReport.Socia_HaveYouEverDevelopedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedAnswer = MedicalHistoryReport.Socia_HaveYouSufferedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedComment = MedicalHistoryReport.Socia_HaveYouSufferedComment;

						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyAnswer = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyAnswer;
						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyComment = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyComment;

						MedicalHistoryReportResponseDTO.Family_DizzinessAnswer = MedicalHistoryReport.Family_DizzinessAnswer;
						MedicalHistoryReportResponseDTO.Family_DizzinessComment = MedicalHistoryReport.Family_DizzinessComment;

						MedicalHistoryReportResponseDTO.Family_DiscProlapseAnswer = MedicalHistoryReport.Family_DiscProlapseAnswer;
						MedicalHistoryReportResponseDTO.Family_DiscProlapseComment = MedicalHistoryReport.Family_DiscProlapseComment;

						MedicalHistoryReportResponseDTO.Family_DiabetesAnswer = MedicalHistoryReport.Family_DiabetesAnswer;
						MedicalHistoryReportResponseDTO.Family_DiabetesComment = MedicalHistoryReport.Family_DiabetesComment;

						MedicalHistoryReportResponseDTO.Family_DepressionAnswer = MedicalHistoryReport.Family_DepressionAnswer;
						MedicalHistoryReportResponseDTO.Family_DepressionComment = MedicalHistoryReport.Family_DepressionComment;

						MedicalHistoryReportResponseDTO.Family_COPDAnswer = MedicalHistoryReport.Family_COPDAnswer;
						MedicalHistoryReportResponseDTO.Family_COPDComment = MedicalHistoryReport.Family_COPDComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalAnswer = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalComment = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedAnswer = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedComment = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedComment;

						MedicalHistoryReportResponseDTO.Family_AllergyAnswer = MedicalHistoryReport.Family_AllergyAnswer;
						MedicalHistoryReportResponseDTO.Family_AllergyComment = MedicalHistoryReport.Family_AllergyComment;

						MedicalHistoryReportResponseDTO.Family_GITAnswer = MedicalHistoryReport.Family_GITAnswer;
						MedicalHistoryReportResponseDTO.Family_GITComment = MedicalHistoryReport.Family_GITComment;

						MedicalHistoryReportResponseDTO.Family_HeartDiseaseAnswer = MedicalHistoryReport.Family_HeartDiseaseAnswer;
						MedicalHistoryReportResponseDTO.Family_HeartDiseaseComment = MedicalHistoryReport.Family_HeartDiseaseComment;

						MedicalHistoryReportResponseDTO.Family_HighBloodPressureAnswer = MedicalHistoryReport.Family_HighBloodPressureAnswer;
						MedicalHistoryReportResponseDTO.Family_HighBloodPressureComment = MedicalHistoryReport.Family_HighBloodPressureComment;

						MedicalHistoryReportResponseDTO.Family_HospitalizationAnswer = MedicalHistoryReport.Family_HospitalizationAnswer;
						MedicalHistoryReportResponseDTO.Family_HospitalizationComment = MedicalHistoryReport.Family_HospitalizationComment;

						MedicalHistoryReportResponseDTO.Family_InfectiousAnswer = MedicalHistoryReport.Family_InfectiousAnswer;
						MedicalHistoryReportResponseDTO.Family_InfectiousComment = MedicalHistoryReport.Family_InfectiousComment;

						MedicalHistoryReportResponseDTO.Family_KidneyAnswer = MedicalHistoryReport.Family_KidneyAnswer;
						MedicalHistoryReportResponseDTO.Family_KidneyComment = MedicalHistoryReport.Family_KidneyComment;

						MedicalHistoryReportResponseDTO.Family_NeurologicalAnswer = MedicalHistoryReport.Family_NeurologicalAnswer;
						MedicalHistoryReportResponseDTO.Family_NeurologicalComment = MedicalHistoryReport.Family_NeurologicalComment;

						MedicalHistoryReportResponseDTO.Family_SurgeryAnswer = MedicalHistoryReport.Family_SurgeryAnswer;
						MedicalHistoryReportResponseDTO.Family_SurgeryComment = MedicalHistoryReport.Family_SurgeryComment;

						MedicalHistoryReportResponseDTO.DoctorComments = MedicalHistoryReport.DoctorComments;
						MedicalHistoryReportResponseDTO.DoctorName = MedicalHistoryReport.DoctorName;

						MedicalHistoryReportResponseDTO.GeneralExamination_BloodPressure = MedicalHistoryReport.GeneralExamination_BloodPressure;
						MedicalHistoryReportResponseDTO.GeneralExamination_HeartRate = MedicalHistoryReport.GeneralExamination_HeartRate;

						MedicalHistoryReportResponseDTO.GeneralExamination_Height = MedicalHistoryReport.GeneralExamination_Height;
						MedicalHistoryReportResponseDTO.GeneralExamination_Weight = MedicalHistoryReport.GeneralExamination_Weight;

						MedicalHistoryReportResponseDTO.userName = MedicalHistoryReport.user.UserName;
						MedicalHistoryReportResponseDTO.userID = MedicalHistoryReport.user.Id;

						newTemp.Add(MedicalHistoryReportResponseDTO);
					}

					if (newTemp.Count > 0)
					{
						result.Statescode = 200;
						result.Data = newTemp;
					}
					else
					{
						result.Statescode = 404;
						result.Message = "Data not found";
					}
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<MedicalHistoryReport> temp = MedicalHistoryReportRepository.getall()
					 .Where(e => SearchList.Any(disease => GetDiseaseByName(e, disease).Contains(newDiseases, StringComparison.OrdinalIgnoreCase))).ToList();

					List<MedicalHistoryReportResponseDTO> newTemp = new List<MedicalHistoryReportResponseDTO>();

					foreach (MedicalHistoryReport MedicalHistoryReport in temp)
					{
						MedicalHistoryReportResponseDTO MedicalHistoryReportResponseDTO = new MedicalHistoryReportResponseDTO();
						MedicalHistoryReportResponseDTO.Id = MedicalHistoryReport.Id;
						MedicalHistoryReportResponseDTO.RigId = MedicalHistoryReport.Rig.Number;
						MedicalHistoryReportResponseDTO.Date = MedicalHistoryReport.Date;
						MedicalHistoryReportResponseDTO.DateOfBirth = MedicalHistoryReport.DateOfBirth;
						MedicalHistoryReportResponseDTO.Company = MedicalHistoryReport.Company;
						MedicalHistoryReportResponseDTO.Code = MedicalHistoryReport.Code;
						MedicalHistoryReportResponseDTO.Contact = MedicalHistoryReport.Contact;
						MedicalHistoryReportResponseDTO.Address = MedicalHistoryReport.Address;
						MedicalHistoryReportResponseDTO.TelephoneNumber = MedicalHistoryReport.TelephoneNumber;
						MedicalHistoryReportResponseDTO.Name = MedicalHistoryReport.Name;
						MedicalHistoryReportResponseDTO.Jop = MedicalHistoryReport.Jop;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyAnswer = MedicalHistoryReport.Socia_DoYouExerciseRegularlyAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouExerciseRegularlyComment = MedicalHistoryReport.Socia_DoYouExerciseRegularlyComment;

						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeAnswer = MedicalHistoryReport.Socia_DoYouSmokeAnswer;
						MedicalHistoryReportResponseDTO.Socia_DoYouSmokeComment = MedicalHistoryReport.Socia_DoYouSmokeComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedAnswer = MedicalHistoryReport.Socia_HaveYouBeenExposedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouBeenExposedComment = MedicalHistoryReport.Socia_HaveYouBeenExposedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedAnswer = MedicalHistoryReport.Socia_HaveYouEverDevelopedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouEverDevelopedComment = MedicalHistoryReport.Socia_HaveYouEverDevelopedComment;

						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedAnswer = MedicalHistoryReport.Socia_HaveYouSufferedAnswer;
						MedicalHistoryReportResponseDTO.Socia_HaveYouSufferedComment = MedicalHistoryReport.Socia_HaveYouSufferedComment;

						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyAnswer = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyAnswer;
						MedicalHistoryReportResponseDTO.Family_DoAnyOfYour1stDegreeFamilyComment = MedicalHistoryReport.Family_DoAnyOfYour1stDegreeFamilyComment;

						MedicalHistoryReportResponseDTO.Family_DizzinessAnswer = MedicalHistoryReport.Family_DizzinessAnswer;
						MedicalHistoryReportResponseDTO.Family_DizzinessComment = MedicalHistoryReport.Family_DizzinessComment;

						MedicalHistoryReportResponseDTO.Family_DiscProlapseAnswer = MedicalHistoryReport.Family_DiscProlapseAnswer;
						MedicalHistoryReportResponseDTO.Family_DiscProlapseComment = MedicalHistoryReport.Family_DiscProlapseComment;

						MedicalHistoryReportResponseDTO.Family_DiabetesAnswer = MedicalHistoryReport.Family_DiabetesAnswer;
						MedicalHistoryReportResponseDTO.Family_DiabetesComment = MedicalHistoryReport.Family_DiabetesComment;

						MedicalHistoryReportResponseDTO.Family_DepressionAnswer = MedicalHistoryReport.Family_DepressionAnswer;
						MedicalHistoryReportResponseDTO.Family_DepressionComment = MedicalHistoryReport.Family_DepressionComment;

						MedicalHistoryReportResponseDTO.Family_COPDAnswer = MedicalHistoryReport.Family_COPDAnswer;
						MedicalHistoryReportResponseDTO.Family_COPDComment = MedicalHistoryReport.Family_COPDComment;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalAnswer = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyReceivingAnyMedicalComment = MedicalHistoryReport.Family_AreYouCurrentlyReceivingAnyMedicalAnswer;

						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedAnswer = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedAnswer;
						MedicalHistoryReportResponseDTO.Family_AreYouCurrentlyBeingTreatedComment = MedicalHistoryReport.Family_AreYouCurrentlyBeingTreatedComment;

						MedicalHistoryReportResponseDTO.Family_AllergyAnswer = MedicalHistoryReport.Family_AllergyAnswer;
						MedicalHistoryReportResponseDTO.Family_AllergyComment = MedicalHistoryReport.Family_AllergyComment;

						MedicalHistoryReportResponseDTO.Family_GITAnswer = MedicalHistoryReport.Family_GITAnswer;
						MedicalHistoryReportResponseDTO.Family_GITComment = MedicalHistoryReport.Family_GITComment;

						MedicalHistoryReportResponseDTO.Family_HeartDiseaseAnswer = MedicalHistoryReport.Family_HeartDiseaseAnswer;
						MedicalHistoryReportResponseDTO.Family_HeartDiseaseComment = MedicalHistoryReport.Family_HeartDiseaseComment;

						MedicalHistoryReportResponseDTO.Family_HighBloodPressureAnswer = MedicalHistoryReport.Family_HighBloodPressureAnswer;
						MedicalHistoryReportResponseDTO.Family_HighBloodPressureComment = MedicalHistoryReport.Family_HighBloodPressureComment;

						MedicalHistoryReportResponseDTO.Family_HospitalizationAnswer = MedicalHistoryReport.Family_HospitalizationAnswer;
						MedicalHistoryReportResponseDTO.Family_HospitalizationComment = MedicalHistoryReport.Family_HospitalizationComment;

						MedicalHistoryReportResponseDTO.Family_InfectiousAnswer = MedicalHistoryReport.Family_InfectiousAnswer;
						MedicalHistoryReportResponseDTO.Family_InfectiousComment = MedicalHistoryReport.Family_InfectiousComment;

						MedicalHistoryReportResponseDTO.Family_KidneyAnswer = MedicalHistoryReport.Family_KidneyAnswer;
						MedicalHistoryReportResponseDTO.Family_KidneyComment = MedicalHistoryReport.Family_KidneyComment;

						MedicalHistoryReportResponseDTO.Family_NeurologicalAnswer = MedicalHistoryReport.Family_NeurologicalAnswer;
						MedicalHistoryReportResponseDTO.Family_NeurologicalComment = MedicalHistoryReport.Family_NeurologicalComment;

						MedicalHistoryReportResponseDTO.Family_SurgeryAnswer = MedicalHistoryReport.Family_SurgeryAnswer;
						MedicalHistoryReportResponseDTO.Family_SurgeryComment = MedicalHistoryReport.Family_SurgeryComment;

						MedicalHistoryReportResponseDTO.DoctorComments = MedicalHistoryReport.DoctorComments;
						MedicalHistoryReportResponseDTO.DoctorName = MedicalHistoryReport.DoctorName;

						MedicalHistoryReportResponseDTO.GeneralExamination_BloodPressure = MedicalHistoryReport.GeneralExamination_BloodPressure;
						MedicalHistoryReportResponseDTO.GeneralExamination_HeartRate = MedicalHistoryReport.GeneralExamination_HeartRate;

						MedicalHistoryReportResponseDTO.GeneralExamination_Height = MedicalHistoryReport.GeneralExamination_Height;
						MedicalHistoryReportResponseDTO.GeneralExamination_Weight = MedicalHistoryReport.GeneralExamination_Weight;

						MedicalHistoryReportResponseDTO.userName = MedicalHistoryReport.user.UserName;
						MedicalHistoryReportResponseDTO.userID = MedicalHistoryReport.user.Id;

						newTemp.Add(MedicalHistoryReportResponseDTO);
					}

					if (newTemp.Count > 0)
					{
						result.Statescode = 200;
						result.Data = newTemp;
					}
					else
					{
						result.Statescode = 404;
						result.Message = "Data not found";
					}
				}
			}
			catch (Exception ex)
			{
				result.Statescode = 404;
				result.Message = "Data not found";
			}

			return result;
		}

		private IEnumerable<string> SearchList = new List<string>
		{
			"Smokers",
			"industrial injury",
			"Depression or Anxiety disorder",
			"Allergy",
			"Surgery",
			"Hospitalization",
			"Disc prolapse",
			"Dizziness, vertigo, problems with balance",
			"Infectious disease",
			"Neurological disorder (e.g. Stroke or epilepsy)",
			"Kidney disease (e.g. stone)",
			"GIT disease (e.g. Liver disease)",
			"Diabetes",
			"Bronchial Asthma / COPD",
			"Heart Disease/ Chest pain",
			"High/ Low blood pressure"

		};

		private string GetDiseaseByName(MedicalHistoryReport report, string DiseaseName)
		{
			switch (DiseaseName)
			{
				case "Smokers": return "Smokers";//return report.Socia_DoYouSmokeAnswer;
				case "industrial injury": return "industrial injury";
				case "Depression &Anxiety disorder": return "Depression &Anxiety disorder";
				case "Surgery": return "Surgery";
				case "Hospitalization": return "Hospitalization";
				case "Disc prolapse": return "Disc prolapse";
				case "Dizziness, vertigo, problems with balance": return "Dizziness, vertigo, problems with balance";
				case "Infectious disease": return "Infectious disease";
				case "Neurological disorder (e.g. Stroke or epilepsy)": return "Neurological disorder (e.g. Stroke or epilepsy)";
				case "Kidney disease (e.g. stone)": return "Kidney disease (e.g. stone)";
				case "GIT disease (e.g. Liver disease)": return "GIT disease (e.g. Liver disease)";
				case "Diabetes": return "Diabetes";
				case "Bronchial Asthma / COPD": return "Bronchial Asthma / COPD";
				case "Heart Disease/ Chest pain": return "Heart Disease/ Chest pain";
				case "High/ Low blood pressure": return "High/ Low blood pressure ";//report.Family_HighBloodPressureAnswer;
				case "Allergy": return "Allergy"; //report.Family_AllergyAnswer;

				default: return string.Empty;
			}
		}

	}
}

