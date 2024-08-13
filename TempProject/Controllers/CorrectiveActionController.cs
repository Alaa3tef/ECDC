using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Text;
using TempProject.DTO;
using TempProject.DTO.ResponseDTO;
using TempProject.Helper;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	//[Authorize]
	public class CorrectiveActionController : ControllerBase
    {
        public IRepository<CorrectiveAction> CorrectiveActionRepo { get; set; }
        public ICorrectiveActionRepository CorrectiveActionRepoistory { get; set; }

		private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager;
        public IRepository<CorrectiveImages> CorrectiveImagesRepo { get; set; }

		public IRepository<CorrectiveAndObservation> CorrectiveAndObservationRepo { get; set; }

		public IRepository<CorrectiveAndRootCauses> CorrectiveAndRootCausesRepo { get; set; }

		public IRepository<CorrectiveDataTable> CorrectiveDataTableRepo { get; set; }

		public CorrectiveActionController(IRepository<CorrectiveDataTable> _CorrectiveDataTableRepo, IRepository<CorrectiveAndRootCauses> _CorrectiveAndRootCausesRepo,IRepository<CorrectiveAndObservation> _CorrectiveAndObservationRepo,Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager, IRepository<CorrectiveAction> _CorrectiveActionRepo, IRepository<CorrectiveImages> _CorrectiveImagesRepo, ICorrectiveActionRepository _CorrectiveActionRepoistory)
        {
            this.CorrectiveActionRepo = _CorrectiveActionRepo;
            this.CorrectiveActionRepoistory = _CorrectiveActionRepoistory;
            this.userManager = _userManager;
			this.CorrectiveImagesRepo = _CorrectiveImagesRepo;
			this.CorrectiveAndObservationRepo = _CorrectiveAndObservationRepo;
			this.CorrectiveAndRootCausesRepo = _CorrectiveAndRootCausesRepo;
			this.CorrectiveDataTableRepo = _CorrectiveDataTableRepo;
		}

		[HttpGet("GetData")]
		public async Task<ResultDTO> GetAllWithData(string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<CorrectiveAction> temp = CorrectiveActionRepoistory.getall();
					List<CorrectiveResponseDTO> newTemp = new List<CorrectiveResponseDTO>();
					foreach (CorrectiveAction corrective in temp)
					{
						CorrectiveResponseDTO correctiveDTO = new CorrectiveResponseDTO();
						correctiveDTO.Id = corrective.Id;
						//correctiveDTO.Rig = corrective.Rig.Number;
						correctiveDTO.Title = corrective.Title;
						correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
						correctiveDTO.ReportNo = corrective.ReportNo;
						correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
						correctiveDTO.Standard = corrective.Standard.StandardName;
						correctiveDTO.ClauseNo = corrective.ClauseNo;
						correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
						foreach (var item in corrective.CorrectiveAndObservation)
						{
							string observation = item.CorrectiveObservation.Observation;
							correctiveDTO.CorrectiveAndObservation.Add(observation);

						}
						foreach (var item in corrective.CorrectiveAndRootCauses)
						{
							string cause = item.RootCauses.CauseName;
							correctiveDTO.CorrectiveAndRootCauses.Add(cause);

						}
						correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
						correctiveDTO.UpdateRisk = corrective.UpdateRisk;
						correctiveDTO.IfUpdate = corrective.IfUpdate;
						correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
						correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
						correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
						//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
						correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
						correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
						foreach (var item in corrective.CorrectiveDataTable)
						{
							CorrectiveDataTable Data = new CorrectiveDataTable();
							Data.Id = item.Id;
							Data.SN = item.SN;
							Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
							Data.Action = item.Action;
							Data.Responsible = item.Responsible;
							Data.SuggestedDate = item.SuggestedDate;
							Data.AchievementDate = item.AchievementDate;
							Data.Status = item.Status;
							Data.CorrectiveActionId = item.CorrectiveActionId;
							Data.FollowUpAudit = item.FollowUpAudit;
							Data.IsDeleted = item.IsDeleted;
							correctiveDTO.CorrectiveDataTable.Add(Data);
						};
						correctiveDTO.Comment = corrective.Comment;
						correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
						//correctiveDTO.QHSEEngineer = corrective.QHSEEngineer;
						correctiveDTO.userName = corrective.user.UserName;
						correctiveDTO.FormStatus = corrective.FormStatus;
						List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
						foreach (var item in correctiveImages)
						{
							string FileName = item.FileName;
							correctiveDTO.Images.Add(FileName);

						}
						newTemp.Add(correctiveDTO);
						//result.Data = prod;
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
					List<CorrectiveAction> temp = CorrectiveActionRepoistory.getall().Where(a => a.user.Id == UserID).ToList();
					List<CorrectiveResponseDTO> newTemp = new List<CorrectiveResponseDTO>();
					foreach (CorrectiveAction corrective in temp)
					{
						CorrectiveResponseDTO correctiveDTO = new CorrectiveResponseDTO();
						correctiveDTO.Id = corrective.Id;
						//correctiveDTO.Rig = corrective.Rig.Number;
						correctiveDTO.Title = corrective.Title;
						correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
						correctiveDTO.ReportNo = corrective.ReportNo;
						correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
						correctiveDTO.Standard = corrective.Standard.StandardName;
						correctiveDTO.ClauseNo = corrective.ClauseNo;
						correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
						foreach (var item in corrective.CorrectiveAndObservation)
						{
							string observation = item.CorrectiveObservation.Observation;
							correctiveDTO.CorrectiveAndObservation.Add(observation);

						}
						foreach (var item in corrective.CorrectiveAndRootCauses)
						{
							string cause = item.RootCauses.CauseName;
							correctiveDTO.CorrectiveAndRootCauses.Add(cause);

						}
						correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
						correctiveDTO.UpdateRisk = corrective.UpdateRisk;
						correctiveDTO.IfUpdate = corrective.IfUpdate;
						correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
						correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
						correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
						//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
						correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
						correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
						foreach (var item in corrective.CorrectiveDataTable)
						{
							CorrectiveDataTable Data = new CorrectiveDataTable();
							Data.Id = item.Id;
							Data.SN = item.SN;
							Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
							Data.Action = item.Action;
							Data.Responsible = item.Responsible;
							Data.SuggestedDate = item.SuggestedDate;
							Data.AchievementDate = item.AchievementDate;
							Data.Status = item.Status;
							Data.CorrectiveActionId = item.CorrectiveActionId;
							Data.FollowUpAudit = item.FollowUpAudit;
							Data.IsDeleted = item.IsDeleted;
							correctiveDTO.CorrectiveDataTable.Add(Data);
						};
						correctiveDTO.Comment = corrective.Comment;
						correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
						//correctiveDTO.QHSEEngineer = corrective.QHSEEngineer;
						correctiveDTO.userName = corrective.user.UserName;
						correctiveDTO.FormStatus = corrective.FormStatus;
						List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
						foreach (var item in correctiveImages)
						{
							string FileName = item.FileName;
							correctiveDTO.Images.Add(FileName);

						}
						newTemp.Add(correctiveDTO);
						//result.Data = prod;
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

		[HttpGet("GetDataByFilter")]
		public async Task<ResultDTO> GetAllWithDataByFilter(string? Responsability,string? Title,string? date,string? Status)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				List<CorrectiveAction> temp = CorrectiveActionRepoistory.getall();

				temp = temp.Where(m => (Responsability == null || m.CorrectiveResponsability.ResponsibilityName == Responsability)
					&& (Title == null || m.Title == Title)
					&& (date == null || m.DateRaisedBy.Date == DateTime.Parse(date).Date) && (Status == null || m.FormStatus == Status)).ToList();

				List<CorrectiveResponseDTO> newTemp = new List<CorrectiveResponseDTO>();
				foreach (CorrectiveAction corrective in temp)
				{
					CorrectiveResponseDTO correctiveDTO = new CorrectiveResponseDTO();
					correctiveDTO.Id = corrective.Id;
					//correctiveDTO.Rig = corrective.Rig.Number;
					correctiveDTO.Title = corrective.Title;
					correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
					correctiveDTO.ReportNo = corrective.ReportNo;
					correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
					correctiveDTO.Standard = corrective.Standard.StandardName;
					correctiveDTO.ClauseNo = corrective.ClauseNo;
					correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
					foreach (var item in corrective.CorrectiveAndObservation)
					{
						string observation = item.CorrectiveObservation.Observation;
						correctiveDTO.CorrectiveAndObservation.Add(observation);

					}
					foreach (var item in corrective.CorrectiveAndRootCauses)
					{
						string cause = item.RootCauses.CauseName;
						correctiveDTO.CorrectiveAndRootCauses.Add(cause);

					}
					correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
					correctiveDTO.UpdateRisk = corrective.UpdateRisk;
					correctiveDTO.IfUpdate = corrective.IfUpdate;
					correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
					correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
					correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
					//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
					correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
					correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
					foreach (var item in corrective.CorrectiveDataTable)
					{
						CorrectiveDataTable Data = new CorrectiveDataTable();
						Data.Id = item.Id;
						Data.SN = item.SN;
						Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
						Data.Action = item.Action;
						Data.Responsible = item.Responsible;
						Data.SuggestedDate = item.SuggestedDate;
						Data.AchievementDate = item.AchievementDate;
						Data.Status = item.Status;
						Data.CorrectiveActionId = item.CorrectiveActionId;
						Data.FollowUpAudit = item.FollowUpAudit;
						Data.IsDeleted = item.IsDeleted;
						correctiveDTO.CorrectiveDataTable.Add(Data);
					};
					correctiveDTO.Comment = corrective.Comment;
					correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
					//correctiveDTO.QHSEEngineer = corrective.QHSEEngineer;
					correctiveDTO.userName = corrective.user.UserName;
					correctiveDTO.FormStatus = corrective.FormStatus;
					List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
					foreach (var item in correctiveImages)
					{
						string FileName = item.FileName;
						correctiveDTO.Images.Add(FileName);

					}
					newTemp.Add(correctiveDTO);
					//result.Data = prod;
				}
				if (newTemp != null)
				{
					result.Message = "Success";
					result.Statescode = 200;
					result.Data = newTemp;

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

		//[HttpGet("GetDataForAnalysis")]
		//public async Task<ResultDTO> GetDataForAnalysis(int RigId, string UserID, string UserRole)
		//{
		//	ResultDTO result = new ResultDTO();

		//	try
		//	{
		//		if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
		//		{
		//			List<CorrectiveAction> temp = CorrectiveActionRepoistory.getall().Where(c=>c.RigId==RigId).ToList();
		//			List<CorrectiveResponseDTO> newTemp = new List<CorrectiveResponseDTO>();
		//			foreach (CorrectiveAction corrective in temp)
		//			{
		//				CorrectiveResponseDTO correctiveDTO = new CorrectiveResponseDTO();
		//				correctiveDTO.Id = corrective.Id;
		//				correctiveDTO.Rig = corrective.Rig.Number;
		//				correctiveDTO.Title = corrective.Title;
		//				correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
		//				correctiveDTO.ReportNo = corrective.ReportNo;
		//				correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
		//				correctiveDTO.Standard = corrective.Standard.StandardName;
		//				correctiveDTO.ClauseNo = corrective.ClauseNo;
		//				correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
		//				foreach (var item in corrective.CorrectiveAndObservation)
		//				{
		//					string observation = item.CorrectiveObservation.Observation;
		//					correctiveDTO.CorrectiveAndObservation.Add(observation);

		//				}
		//				foreach (var item in corrective.CorrectiveAndRootCauses)
		//				{
		//					string cause = item.RootCauses.CauseName;
		//					correctiveDTO.CorrectiveAndRootCauses.Add(cause);

		//				}
		//				correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
		//				correctiveDTO.UpdateRisk = corrective.UpdateRisk;
		//				correctiveDTO.IfUpdate = corrective.IfUpdate;
		//				correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
		//				correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
		//				correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
		//				//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
		//				correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
		//				correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
		//				foreach (var item in corrective.CorrectiveDataTable)
		//				{
		//					CorrectiveDataTable Data = new CorrectiveDataTable();
		//					Data.Id = item.Id;
		//					Data.SN = item.SN;
		//					Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
		//					Data.Action = item.Action;
		//					Data.Responsible = item.Responsible;
		//					Data.SuggestedDate = item.SuggestedDate;
		//					Data.AchievementDate = item.AchievementDate;
		//					Data.Status = item.Status;
		//					Data.CorrectiveActionId = item.CorrectiveActionId;
		//					Data.FollowUpAudit = item.FollowUpAudit;
		//					Data.IsDeleted = item.IsDeleted;
		//					correctiveDTO.CorrectiveDataTable.Add(Data);
		//				};
		//				correctiveDTO.Comment = corrective.Comment;
		//				correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
		//				correctiveDTO.userName = corrective.user.UserName;
		//				correctiveDTO.FormStatus = corrective.FormStatus;
		//				List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
		//				foreach (var item in correctiveImages)
		//				{
		//					string FileName = item.FileName;
		//					correctiveDTO.Images.Add(FileName);

		//				}
		//				newTemp.Add(correctiveDTO);
		//				//result.Data = prod;
		//			}
		//			if (newTemp != null)
		//			{
		//				result.Message = "Success";
		//				result.Statescode = 200;
		//				result.Data = newTemp;

		//				return result;
		//			}
		//		}
		//		else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
		//		{
		//			List<CorrectiveAction> temp = CorrectiveActionRepoistory.getall().Where(a => a.user.Id == UserID && a.RigId == RigId).ToList();
		//			List<CorrectiveResponseDTO> newTemp = new List<CorrectiveResponseDTO>();
		//			foreach (CorrectiveAction corrective in temp)
		//			{
		//				CorrectiveResponseDTO correctiveDTO = new CorrectiveResponseDTO();
		//				correctiveDTO.Id = corrective.Id;
		//				correctiveDTO.Rig = corrective.Rig.Number;
		//				correctiveDTO.Title = corrective.Title;
		//				correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
		//				correctiveDTO.ReportNo = corrective.ReportNo;
		//				correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
		//				correctiveDTO.Standard = corrective.Standard.StandardName;
		//				correctiveDTO.ClauseNo = corrective.ClauseNo;
		//				correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
		//				foreach (var item in corrective.CorrectiveAndObservation)
		//				{
		//					string observation = item.CorrectiveObservation.Observation;
		//					correctiveDTO.CorrectiveAndObservation.Add(observation);

		//				}
		//				foreach (var item in corrective.CorrectiveAndRootCauses)
		//				{
		//					string cause = item.RootCauses.CauseName;
		//					correctiveDTO.CorrectiveAndRootCauses.Add(cause);

		//				}
		//				correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
		//				correctiveDTO.UpdateRisk = corrective.UpdateRisk;
		//				correctiveDTO.IfUpdate = corrective.IfUpdate;
		//				correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
		//				correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
		//				correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
		//				//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
		//				correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
		//				correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
		//				foreach (var item in corrective.CorrectiveDataTable)
		//				{
		//					CorrectiveDataTable Data = new CorrectiveDataTable();
		//					Data.Id = item.Id;
		//					Data.SN = item.SN;
		//					Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
		//					Data.Action = item.Action;
		//					Data.Responsible = item.Responsible;
		//					Data.SuggestedDate = item.SuggestedDate;
		//					Data.AchievementDate = item.AchievementDate;
		//					Data.Status = item.Status;
		//					Data.CorrectiveActionId = item.CorrectiveActionId;
		//					Data.FollowUpAudit = item.FollowUpAudit;
		//					Data.IsDeleted = item.IsDeleted;
		//					correctiveDTO.CorrectiveDataTable.Add(Data);
		//				};
		//				correctiveDTO.Comment = corrective.Comment;
		//				correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
		//				correctiveDTO.userName = corrective.user.UserName;
		//				correctiveDTO.FormStatus = corrective.FormStatus;
		//				List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
		//				foreach (var item in correctiveImages)
		//				{
		//					string FileName = item.FileName;
		//					correctiveDTO.Images.Add(FileName);

		//				}
		//				newTemp.Add(correctiveDTO);
		//				//result.Data = prod;
		//			}
		//			if (newTemp != null)
		//			{
		//				result.Message = "Success";
		//				result.Statescode = 200;
		//				result.Data = newTemp;

		//				return result;
		//			}
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		result.Statescode = 404;
		//		result.Message = "data not found";
		//	}
		//	return result;
		//}

		[HttpGet("GetDataByResponsability")]
		public async Task<ResultDTO> GetDataByResponsability(string Responability, string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<CorrectiveAction> temp = CorrectiveActionRepoistory.getall().Where(c => c.CorrectiveResponsability.ResponsibilityName == Responability).ToList();
					List<CorrectiveResponseDTO> newTemp = new List<CorrectiveResponseDTO>();
					foreach (CorrectiveAction corrective in temp)
					{
						CorrectiveResponseDTO correctiveDTO = new CorrectiveResponseDTO();
						correctiveDTO.Id = corrective.Id;
						//correctiveDTO.Rig = corrective.Rig.Number;
						correctiveDTO.Title = corrective.Title;
						correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
						correctiveDTO.ReportNo = corrective.ReportNo;
						correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
						correctiveDTO.Standard = corrective.Standard.StandardName;
						correctiveDTO.ClauseNo = corrective.ClauseNo;
						correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
						foreach (var item in corrective.CorrectiveAndObservation)
						{
							string observation = item.CorrectiveObservation.Observation;
							correctiveDTO.CorrectiveAndObservation.Add(observation);

						}
						foreach (var item in corrective.CorrectiveAndRootCauses)
						{
							string cause = item.RootCauses.CauseName;
							correctiveDTO.CorrectiveAndRootCauses.Add(cause);

						}
						correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
						correctiveDTO.UpdateRisk = corrective.UpdateRisk;
						correctiveDTO.IfUpdate = corrective.IfUpdate;
						correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
						correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
						correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
						//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
						correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
						correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
						foreach (var item in corrective.CorrectiveDataTable)
						{
							CorrectiveDataTable Data = new CorrectiveDataTable();
							Data.Id = item.Id;
							Data.SN = item.SN;
							Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
							Data.Action = item.Action;
							Data.Responsible = item.Responsible;
							Data.SuggestedDate = item.SuggestedDate;
							Data.AchievementDate = item.AchievementDate;
							Data.Status = item.Status;
							Data.CorrectiveActionId = item.CorrectiveActionId;
							Data.FollowUpAudit = item.FollowUpAudit;
							Data.IsDeleted = item.IsDeleted;
							correctiveDTO.CorrectiveDataTable.Add(Data);
						};
						correctiveDTO.Comment = corrective.Comment;
						correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
						//correctiveDTO.QHSEEngineer = corrective.QHSEEngineer;
						correctiveDTO.userName = corrective.user.UserName;
						correctiveDTO.FormStatus = corrective.FormStatus;
						List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
						foreach (var item in correctiveImages)
						{
							string FileName = item.FileName;
							correctiveDTO.Images.Add(FileName);

						}
						newTemp.Add(correctiveDTO);
						//result.Data = prod;
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
					List<CorrectiveAction> temp = CorrectiveActionRepoistory.getall().Where(a => a.user.Id == UserID && a.CorrectiveResponsability.ResponsibilityName == Responability).ToList();
					List<CorrectiveResponseDTO> newTemp = new List<CorrectiveResponseDTO>();
					foreach (CorrectiveAction corrective in temp)
					{
						CorrectiveResponseDTO correctiveDTO = new CorrectiveResponseDTO();
						correctiveDTO.Id = corrective.Id;
						//correctiveDTO.Rig = corrective.Rig.Number;
						correctiveDTO.Title = corrective.Title;
						correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
						correctiveDTO.ReportNo = corrective.ReportNo;
						correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
						correctiveDTO.Standard = corrective.Standard.StandardName;
						correctiveDTO.ClauseNo = corrective.ClauseNo;
						correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
						foreach (var item in corrective.CorrectiveAndObservation)
						{
							string observation = item.CorrectiveObservation.Observation;
							correctiveDTO.CorrectiveAndObservation.Add(observation);

						}
						foreach (var item in corrective.CorrectiveAndRootCauses)
						{
							string cause = item.RootCauses.CauseName;
							correctiveDTO.CorrectiveAndRootCauses.Add(cause);

						}
						correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
						correctiveDTO.UpdateRisk = corrective.UpdateRisk;
						correctiveDTO.IfUpdate = corrective.IfUpdate;
						correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
						correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
						correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
						//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
						correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
						correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
						foreach (var item in corrective.CorrectiveDataTable)
						{
							CorrectiveDataTable Data = new CorrectiveDataTable();
							Data.Id = item.Id;
							Data.SN = item.SN;
							Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
							Data.Action = item.Action;
							Data.Responsible = item.Responsible;
							Data.SuggestedDate = item.SuggestedDate;
							Data.AchievementDate = item.AchievementDate;
							Data.Status = item.Status;
							Data.CorrectiveActionId = item.CorrectiveActionId;
							Data.FollowUpAudit = item.FollowUpAudit;
							Data.IsDeleted = item.IsDeleted;
							correctiveDTO.CorrectiveDataTable.Add(Data);
						};
						correctiveDTO.Comment = corrective.Comment;
						correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
						//correctiveDTO.QHSEEngineer = corrective.QHSEEngineer;
						correctiveDTO.userName = corrective.user.UserName;
						correctiveDTO.FormStatus = corrective.FormStatus;
						List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
						foreach (var item in correctiveImages)
						{
							string FileName = item.FileName;
							correctiveDTO.Images.Add(FileName);

						}
						newTemp.Add(correctiveDTO);
						//result.Data = prod;
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

		[HttpGet("GetDataByStandard")]
		public async Task<ResultDTO> GetDataByStandard(string Standard, string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<CorrectiveAction> temp = CorrectiveActionRepoistory.getall().Where(c => c.Standard.StandardName == Standard).ToList();
					List<CorrectiveResponseDTO> newTemp = new List<CorrectiveResponseDTO>();
					foreach (CorrectiveAction corrective in temp)
					{
						CorrectiveResponseDTO correctiveDTO = new CorrectiveResponseDTO();
						correctiveDTO.Id = corrective.Id;
						//correctiveDTO.Rig = corrective.Rig.Number;
						correctiveDTO.Title = corrective.Title;
						correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
						correctiveDTO.ReportNo = corrective.ReportNo;
						correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
						correctiveDTO.Standard = corrective.Standard.StandardName;
						correctiveDTO.ClauseNo = corrective.ClauseNo;
						correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
						foreach (var item in corrective.CorrectiveAndObservation)
						{
							string observation = item.CorrectiveObservation.Observation;
							correctiveDTO.CorrectiveAndObservation.Add(observation);

						}
						foreach (var item in corrective.CorrectiveAndRootCauses)
						{
							string cause = item.RootCauses.CauseName;
							correctiveDTO.CorrectiveAndRootCauses.Add(cause);

						}
						correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
						correctiveDTO.UpdateRisk = corrective.UpdateRisk;
						correctiveDTO.IfUpdate = corrective.IfUpdate;
						correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
						correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
						correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
						//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
						correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
						correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
						foreach (var item in corrective.CorrectiveDataTable)
						{
							CorrectiveDataTable Data = new CorrectiveDataTable();
							Data.Id = item.Id;
							Data.SN = item.SN;
							Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
							Data.Action = item.Action;
							Data.Responsible = item.Responsible;
							Data.SuggestedDate = item.SuggestedDate;
							Data.AchievementDate = item.AchievementDate;
							Data.Status = item.Status;
							Data.CorrectiveActionId = item.CorrectiveActionId;
							Data.FollowUpAudit = item.FollowUpAudit;
							Data.IsDeleted = item.IsDeleted;
							correctiveDTO.CorrectiveDataTable.Add(Data);
						};
						correctiveDTO.Comment = corrective.Comment;
						correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
						//correctiveDTO.QHSEEngineer = corrective.QHSEEngineer;
						correctiveDTO.userName = corrective.user.UserName;
						correctiveDTO.FormStatus = corrective.FormStatus;
						List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
						foreach (var item in correctiveImages)
						{
							string FileName = item.FileName;
							correctiveDTO.Images.Add(FileName);

						}
						newTemp.Add(correctiveDTO);
						//result.Data = prod;
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
					List<CorrectiveAction> temp = CorrectiveActionRepoistory.getall().Where(a => a.user.Id == UserID && a.Standard.StandardName == Standard).ToList();
					List<CorrectiveResponseDTO> newTemp = new List<CorrectiveResponseDTO>();
					foreach (CorrectiveAction corrective in temp)
					{
						CorrectiveResponseDTO correctiveDTO = new CorrectiveResponseDTO();
						correctiveDTO.Id = corrective.Id;
						//correctiveDTO.Rig = corrective.Rig.Number;
						correctiveDTO.Title = corrective.Title;
						correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
						correctiveDTO.ReportNo = corrective.ReportNo;
						correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
						correctiveDTO.Standard = corrective.Standard.StandardName;
						correctiveDTO.ClauseNo = corrective.ClauseNo;
						correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
						foreach (var item in corrective.CorrectiveAndObservation)
						{
							string observation = item.CorrectiveObservation.Observation;
							correctiveDTO.CorrectiveAndObservation.Add(observation);

						}
						foreach (var item in corrective.CorrectiveAndRootCauses)
						{
							string cause = item.RootCauses.CauseName;
							correctiveDTO.CorrectiveAndRootCauses.Add(cause);

						}
						correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
						correctiveDTO.UpdateRisk = corrective.UpdateRisk;
						correctiveDTO.IfUpdate = corrective.IfUpdate;
						correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
						correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
						correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
						//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
						correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
						correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
						foreach (var item in corrective.CorrectiveDataTable)
						{
							CorrectiveDataTable Data = new CorrectiveDataTable();
							Data.Id = item.Id;
							Data.SN = item.SN;
							Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
							Data.Action = item.Action;
							Data.Responsible = item.Responsible;
							Data.SuggestedDate = item.SuggestedDate;
							Data.AchievementDate = item.AchievementDate;
							Data.Status = item.Status;
							Data.CorrectiveActionId = item.CorrectiveActionId;
							Data.FollowUpAudit = item.FollowUpAudit;
							Data.IsDeleted = item.IsDeleted;
							correctiveDTO.CorrectiveDataTable.Add(Data);
						};
						correctiveDTO.Comment = corrective.Comment;
						correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
						//correctiveDTO.QHSEEngineer = corrective.QHSEEngineer;
						correctiveDTO.userName = corrective.user.UserName;
						correctiveDTO.FormStatus = corrective.FormStatus;
						List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
						foreach (var item in correctiveImages)
						{
							string FileName = item.FileName;
							correctiveDTO.Images.Add(FileName);

						}
						newTemp.Add(correctiveDTO);
						//result.Data = prod;
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

		[HttpGet("GetDataByObservation")]
		public async Task<ResultDTO> GetDataByObservation(string Observation, string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<CorrectiveAction> temp = CorrectiveActionRepoistory.getall().Where(x => x.CorrectiveAndObservation.Any(obs => obs.CorrectiveObservation.Observation == Observation)).ToList();
					List<CorrectiveResponseDTO> newTemp = new List<CorrectiveResponseDTO>();
					foreach (CorrectiveAction corrective in temp)
					{
						CorrectiveResponseDTO correctiveDTO = new CorrectiveResponseDTO();
						correctiveDTO.Id = corrective.Id;
						//correctiveDTO.Rig = corrective.Rig.Number;
						correctiveDTO.Title = corrective.Title;
						correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
						correctiveDTO.ReportNo = corrective.ReportNo;
						correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
						correctiveDTO.Standard = corrective.Standard.StandardName;
						correctiveDTO.ClauseNo = corrective.ClauseNo;
						correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
						foreach (var item in corrective.CorrectiveAndObservation)
						{
							string observation = item.CorrectiveObservation.Observation;
							correctiveDTO.CorrectiveAndObservation.Add(observation);

						}
						foreach (var item in corrective.CorrectiveAndRootCauses)
						{
							string cause = item.RootCauses.CauseName;
							correctiveDTO.CorrectiveAndRootCauses.Add(cause);

						}
						correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
						correctiveDTO.UpdateRisk = corrective.UpdateRisk;
						correctiveDTO.IfUpdate = corrective.IfUpdate;
						correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
						correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
						correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
						//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
						correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
						correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
						foreach (var item in corrective.CorrectiveDataTable)
						{
							CorrectiveDataTable Data = new CorrectiveDataTable();
							Data.Id = item.Id;
							Data.SN = item.SN;
							Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
							Data.Action = item.Action;
							Data.Responsible = item.Responsible;
							Data.SuggestedDate = item.SuggestedDate;
							Data.AchievementDate = item.AchievementDate;
							Data.Status = item.Status;
							Data.CorrectiveActionId = item.CorrectiveActionId;
							Data.FollowUpAudit = item.FollowUpAudit;
							Data.IsDeleted = item.IsDeleted;
							correctiveDTO.CorrectiveDataTable.Add(Data);
						};
						correctiveDTO.Comment = corrective.Comment;
						correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
						//correctiveDTO.QHSEEngineer = corrective.QHSEEngineer;
						correctiveDTO.userName = corrective.user.UserName;
						correctiveDTO.FormStatus = corrective.FormStatus;
						List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
						foreach (var item in correctiveImages)
						{
							string FileName = item.FileName;
							correctiveDTO.Images.Add(FileName);

						}
						newTemp.Add(correctiveDTO);
						//result.Data = prod;
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
					List<CorrectiveAction> temp = CorrectiveActionRepoistory.getall().Where(a => a.user.Id == UserID && a.CorrectiveAndObservation.Any(obs => obs.CorrectiveObservation.Observation == Observation)).ToList();
					List<CorrectiveResponseDTO> newTemp = new List<CorrectiveResponseDTO>();
					foreach (CorrectiveAction corrective in temp)
					{
						CorrectiveResponseDTO correctiveDTO = new CorrectiveResponseDTO();
						correctiveDTO.Id = corrective.Id;
						//correctiveDTO.Rig = corrective.Rig.Number;
						correctiveDTO.Title = corrective.Title;
						correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
						correctiveDTO.ReportNo = corrective.ReportNo;
						correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
						correctiveDTO.Standard = corrective.Standard.StandardName;
						correctiveDTO.ClauseNo = corrective.ClauseNo;
						correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
						foreach (var item in corrective.CorrectiveAndObservation)
						{
							string observation = item.CorrectiveObservation.Observation;
							correctiveDTO.CorrectiveAndObservation.Add(observation);

						}
						foreach (var item in corrective.CorrectiveAndRootCauses)
						{
							string cause = item.RootCauses.CauseName;
							correctiveDTO.CorrectiveAndRootCauses.Add(cause);

						}
						correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
						correctiveDTO.UpdateRisk = corrective.UpdateRisk;
						correctiveDTO.IfUpdate = corrective.IfUpdate;
						correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
						correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
						correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
						//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
						correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
						correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
						foreach (var item in corrective.CorrectiveDataTable)
						{
							CorrectiveDataTable Data = new CorrectiveDataTable();
							Data.Id = item.Id;
							Data.SN = item.SN;
							Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
							Data.Action = item.Action;
							Data.Responsible = item.Responsible;
							Data.SuggestedDate = item.SuggestedDate;
							Data.AchievementDate = item.AchievementDate;
							Data.Status = item.Status;
							Data.CorrectiveActionId = item.CorrectiveActionId;
							Data.FollowUpAudit = item.FollowUpAudit;
							Data.IsDeleted = item.IsDeleted;
							correctiveDTO.CorrectiveDataTable.Add(Data);
						};
						correctiveDTO.Comment = corrective.Comment;
						correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
						//correctiveDTO.QHSEEngineer = corrective.QHSEEngineer;
						correctiveDTO.userName = corrective.user.UserName;
						correctiveDTO.FormStatus = corrective.FormStatus;
						List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
						foreach (var item in correctiveImages)
						{
							string FileName = item.FileName;
							correctiveDTO.Images.Add(FileName);

						}
						newTemp.Add(correctiveDTO);
						//result.Data = prod;
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
					List<CorrectiveAction> temp = CorrectiveActionRepoistory.getall();
					List<CorrectiveExcelDTO> newTemp = new List<CorrectiveExcelDTO>();
					foreach (CorrectiveAction corrective in temp)
					{
						CorrectiveExcelDTO correctiveDTO = new CorrectiveExcelDTO();
						//correctiveDTO.Rig = corrective.Rig.Number;
						correctiveDTO.Title = corrective.Title;
						correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
						correctiveDTO.ReportNo = corrective.ReportNo;
						correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
						correctiveDTO.Standard = corrective.Standard.StandardName;
						correctiveDTO.ClauseNo = corrective.ClauseNo;
						correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
						foreach (var item in corrective.CorrectiveAndObservation)
						{
							string observation = item.CorrectiveObservation.Observation;
							correctiveDTO.Observation.Add(observation);

						}
						foreach (var item in corrective.CorrectiveAndRootCauses)
						{
							string cause = item.RootCauses.CauseName;
							correctiveDTO.RootCauses.Add(cause);

						}
						correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
						correctiveDTO.UpdateRisk = corrective.UpdateRisk;
						correctiveDTO.IfUpdate = corrective.IfUpdate;
						correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
						correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
						correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
						//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
						correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
						correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
						foreach (var item in corrective.CorrectiveDataTable)
						{
							CorrectiveDataTable Data = new CorrectiveDataTable();
							Data.Id = item.Id;
							Data.SN = item.SN;
							Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
							Data.Action = item.Action;
							Data.Responsible = item.Responsible;
							Data.SuggestedDate = item.SuggestedDate;
							Data.AchievementDate = item.AchievementDate;
							Data.Status = item.Status;
							Data.CorrectiveActionId = item.CorrectiveActionId;
							Data.FollowUpAudit = item.FollowUpAudit;
							Data.IsDeleted = item.IsDeleted;
							correctiveDTO.CorrectiveAction.Add(Data);
						};
						correctiveDTO.Comment = corrective.Comment;
						correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
						//correctiveDTO.QHSEEngineer = corrective.QHSEEngineer;
						correctiveDTO.userName = corrective.user.UserName;
						correctiveDTO.FormStatus = corrective.FormStatus;

						newTemp.Add(correctiveDTO);
						//result.Data = prod;
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
					List<CorrectiveAction> temp = CorrectiveActionRepoistory.getall().Where(a => a.user.Id == UserID).ToList();
					List<CorrectiveExcelDTO> newTemp = new List<CorrectiveExcelDTO>();
					foreach (CorrectiveAction corrective in temp)
					{
						CorrectiveExcelDTO correctiveDTO = new CorrectiveExcelDTO();
						//correctiveDTO.Rig = corrective.Rig.Number;
						correctiveDTO.Title = corrective.Title;
						correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
						correctiveDTO.ReportNo = corrective.ReportNo;
						correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
						correctiveDTO.Standard = corrective.Standard.StandardName;
						correctiveDTO.ClauseNo = corrective.ClauseNo;
						correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
						foreach (var item in corrective.CorrectiveAndObservation)
						{
							string observation = item.CorrectiveObservation.Observation;
							correctiveDTO.Observation.Add(observation);

						}
						foreach (var item in corrective.CorrectiveAndRootCauses)
						{
							string cause = item.RootCauses.CauseName;
							correctiveDTO.RootCauses.Add(cause);

						}
						correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
						correctiveDTO.UpdateRisk = corrective.UpdateRisk;
						correctiveDTO.IfUpdate = corrective.IfUpdate;
						correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
						correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
						correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
						//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
						correctiveDTO.DateRaisedBy = corrective.DateRaisedBy.Date;
						correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
						foreach (var item in corrective.CorrectiveDataTable)
						{
							CorrectiveDataTable Data = new CorrectiveDataTable();
							Data.Id = item.Id;
							Data.SN = item.SN;
							Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
							Data.Action = item.Action;
							Data.Responsible = item.Responsible;
							Data.SuggestedDate = item.SuggestedDate;
							Data.AchievementDate = item.AchievementDate;
							Data.Status = item.Status;
							Data.CorrectiveActionId = item.CorrectiveActionId;
							Data.FollowUpAudit = item.FollowUpAudit;
							Data.IsDeleted = item.IsDeleted;
							correctiveDTO.CorrectiveAction.Add(Data);
						};
						correctiveDTO.Comment = corrective.Comment;
						correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
						//correctiveDTO.QHSEEngineer = corrective.QHSEEngineer;
						correctiveDTO.userName = corrective.user.UserName;
						correctiveDTO.FormStatus = corrective.FormStatus;

						newTemp.Add(correctiveDTO);
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
		public PageResult<CorrectiveResponseDTO> GettAllCorrectiveByPage(string UserId, string UserRole, int? page, int pagesize = 10)
		{
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<CorrectiveAction> temp = CorrectiveActionRepoistory.getall();
					List<CorrectiveResponseDTO> newTemp = new List<CorrectiveResponseDTO>();
					foreach (CorrectiveAction corrective in temp)
					{
						CorrectiveResponseDTO correctiveDTO = new CorrectiveResponseDTO();
						correctiveDTO.Id = corrective.Id;
						//correctiveDTO.Rig = corrective.Rig.Number;
						correctiveDTO.Title = corrective.Title;
						correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
						correctiveDTO.ReportNo = corrective.ReportNo;
						correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
						correctiveDTO.Standard = corrective.Standard.StandardName;
						correctiveDTO.ClauseNo = corrective.ClauseNo;
						correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
						foreach (var item in corrective.CorrectiveAndObservation)
						{
							string observation = item.CorrectiveObservation.Observation;
							correctiveDTO.CorrectiveAndObservation.Add(observation);

						}
						foreach (var item in corrective.CorrectiveAndRootCauses)
						{
							string cause = item.RootCauses.CauseName;
							correctiveDTO.CorrectiveAndRootCauses.Add(cause);

						}
						correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
						correctiveDTO.UpdateRisk = corrective.UpdateRisk;
						correctiveDTO.IfUpdate = corrective.IfUpdate;
						correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
						correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
						correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
						//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
						correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
						correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
						foreach (var item in corrective.CorrectiveDataTable)
						{
							CorrectiveDataTable Data = new CorrectiveDataTable();
							Data.Id = item.Id;
							Data.SN = item.SN;
							Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
							Data.Action = item.Action;
							Data.Responsible = item.Responsible;
							Data.SuggestedDate = item.SuggestedDate;
							Data.AchievementDate = item.AchievementDate;
							Data.Status = item.Status;
							Data.CorrectiveActionId = item.CorrectiveActionId;
							Data.FollowUpAudit = item.FollowUpAudit;
							Data.IsDeleted = item.IsDeleted;
							correctiveDTO.CorrectiveDataTable.Add(Data);
						};
						correctiveDTO.Comment = corrective.Comment;
						correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
						//correctiveDTO.QHSEEngineer = corrective.QHSEEngineer;
						correctiveDTO.userName = corrective.user.UserName;
						correctiveDTO.FormStatus = corrective.FormStatus;
						List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
						foreach (var item in correctiveImages)
						{
							string FileName = item.FileName;
							correctiveDTO.Images.Add(FileName);

						}
						newTemp.Add(correctiveDTO);
						//result.Data = prod;
					}


					float countDetails = CorrectiveActionRepoistory.getall().Count();
					var result = new PageResult<CorrectiveResponseDTO>
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
					List<CorrectiveAction> temp = CorrectiveActionRepoistory.getall().Where(a => a.user.Id == UserId).ToList();
					List<CorrectiveResponseDTO> newTemp = new List<CorrectiveResponseDTO>();
					foreach (CorrectiveAction corrective in temp)
					{
						CorrectiveResponseDTO correctiveDTO = new CorrectiveResponseDTO();
						correctiveDTO.Id = corrective.Id;
						//correctiveDTO.Rig = corrective.Rig.Number;
						correctiveDTO.Title = corrective.Title;
						correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
						correctiveDTO.ReportNo = corrective.ReportNo;
						correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
						correctiveDTO.Standard = corrective.Standard.StandardName;
						correctiveDTO.ClauseNo = corrective.ClauseNo;
						correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
						foreach (var item in corrective.CorrectiveAndObservation)
						{
							string observation = item.CorrectiveObservation.Observation;
							correctiveDTO.CorrectiveAndObservation.Add(observation);

						}
						foreach (var item in corrective.CorrectiveAndRootCauses)
						{
							string cause = item.RootCauses.CauseName;
							correctiveDTO.CorrectiveAndRootCauses.Add(cause);

						}
						correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
						correctiveDTO.UpdateRisk = corrective.UpdateRisk;
						correctiveDTO.IfUpdate = corrective.IfUpdate;
						correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
						correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
						correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
						//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
						correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
						correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
						foreach (var item in corrective.CorrectiveDataTable)
						{
							CorrectiveDataTable Data = new CorrectiveDataTable();
							Data.Id = item.Id;
							Data.SN = item.SN;
							Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
							Data.Action = item.Action;
							Data.Responsible = item.Responsible;
							Data.SuggestedDate = item.SuggestedDate;
							Data.AchievementDate = item.AchievementDate;
							Data.Status = item.Status;
							Data.CorrectiveActionId = item.CorrectiveActionId;
							Data.FollowUpAudit = item.FollowUpAudit;
							Data.IsDeleted = item.IsDeleted;
							correctiveDTO.CorrectiveDataTable.Add(Data);
						};
						correctiveDTO.Comment = corrective.Comment;
						correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
						//correctiveDTO.QHSEEngineer = corrective.QHSEEngineer;
						correctiveDTO.userName = corrective.user.UserName;
						correctiveDTO.FormStatus = corrective.FormStatus;
						List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
						foreach (var item in correctiveImages)
						{
							string FileName = item.FileName;
							correctiveDTO.Images.Add(FileName);

						}
						newTemp.Add(correctiveDTO);
					}
					float countDetails = CorrectiveActionRepoistory.getall().Where(a => a.user.Id == UserId).Count();
					var result = new PageResult<CorrectiveResponseDTO>
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
				return new PageResult<CorrectiveResponseDTO>();

			}
			return new PageResult<CorrectiveResponseDTO>();
		}


		[HttpGet("GetDataById/{ID:int}")]
		public ActionResult<ResultDTO> GetAllWithDataByID(int ID, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();


			if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
			{
				CorrectiveAction corrective = CorrectiveActionRepoistory.getall().FirstOrDefault(a => a.Id == ID);
				if (corrective != null)
				{
					CorrectiveResponseDTO correctiveDTO = new CorrectiveResponseDTO();
					correctiveDTO.Id = corrective.Id;
					//correctiveDTO.Rig = corrective.Rig.Number;
					correctiveDTO.Title = corrective.Title;
					correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
					correctiveDTO.ReportNo = corrective.ReportNo;
					correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
					correctiveDTO.Standard = corrective.Standard.StandardName;
					correctiveDTO.ClauseNo = corrective.ClauseNo;
					correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
					foreach (var item in corrective.CorrectiveAndObservation)
					{
						string observation = item.CorrectiveObservation.Observation;
						correctiveDTO.CorrectiveAndObservation.Add(observation);

					}
					foreach (var item in corrective.CorrectiveAndRootCauses)
					{
						string cause = item.RootCauses.CauseName;
						correctiveDTO.CorrectiveAndRootCauses.Add(cause);

					}
					correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
					correctiveDTO.UpdateRisk = corrective.UpdateRisk;
					correctiveDTO.IfUpdate = corrective.IfUpdate;
					correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
					correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
					correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
					//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
					correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
					correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
					foreach (var item in corrective.CorrectiveDataTable)
					{
						CorrectiveDataTable Data = new CorrectiveDataTable();
						Data.Id = item.Id;
						Data.SN = item.SN;
						Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
						Data.Action = item.Action;
						Data.Responsible = item.Responsible;
						Data.SuggestedDate = item.SuggestedDate;
						Data.AchievementDate = item.AchievementDate;
						Data.Status = item.Status;
						Data.CorrectiveActionId = item.CorrectiveActionId;
						Data.FollowUpAudit = item.FollowUpAudit;
						Data.IsDeleted = item.IsDeleted;
						correctiveDTO.CorrectiveDataTable.Add(Data);
					};
					correctiveDTO.Comment = corrective.Comment;
					correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
					//correctiveDTO.QHSEEngineer = corrective.QHSEEngineer;
					correctiveDTO.userName = corrective.user.UserName;
					correctiveDTO.FormStatus = corrective.FormStatus;
					List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
					foreach (var item in correctiveImages)
					{
						string FileName = item.FileName;
						correctiveDTO.Images.Add(FileName);

					}

					result.Message = "Success";
					result.Statescode = 200;
					result.Data = correctiveDTO;

					return result;
				}
			}
			else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
			{
				CorrectiveAction corrective = CorrectiveActionRepoistory.getall().FirstOrDefault(a => a.Id == ID && a.user.Id == UserId);
				if (corrective != null)
				{
					CorrectiveResponseDTO correctiveDTO = new CorrectiveResponseDTO();
					correctiveDTO.Id = corrective.Id;
					//correctiveDTO.Rig = corrective.Rig.Number;
					correctiveDTO.Title = corrective.Title;
					correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
					correctiveDTO.ReportNo = corrective.ReportNo;
					correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
					correctiveDTO.Standard = corrective.Standard.StandardName;
					correctiveDTO.ClauseNo = corrective.ClauseNo;
					correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
					foreach (var item in corrective.CorrectiveAndObservation)
					{
						string observation = item.CorrectiveObservation.Observation;
						correctiveDTO.CorrectiveAndObservation.Add(observation);

					}
					foreach (var item in corrective.CorrectiveAndRootCauses)
					{
						string cause = item.RootCauses.CauseName;
						correctiveDTO.CorrectiveAndRootCauses.Add(cause);

					}
					correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
					correctiveDTO.UpdateRisk = corrective.UpdateRisk;
					correctiveDTO.IfUpdate = corrective.IfUpdate;
					correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
					correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
					correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
					//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
					correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
					correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
					foreach (var item in corrective.CorrectiveDataTable)
					{
						CorrectiveDataTable Data = new CorrectiveDataTable();
						Data.Id = item.Id;
						Data.SN = item.SN;
						Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
						Data.Action = item.Action;
						Data.Responsible = item.Responsible;
						Data.SuggestedDate = item.SuggestedDate;
						Data.AchievementDate = item.AchievementDate;
						Data.Status = item.Status;
						Data.CorrectiveActionId = item.CorrectiveActionId;
						Data.FollowUpAudit = item.FollowUpAudit;
						Data.IsDeleted = item.IsDeleted;
						correctiveDTO.CorrectiveDataTable.Add(Data);
					};
					correctiveDTO.Comment = corrective.Comment;
					correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
					//correctiveDTO.QHSEEngineer = corrective.QHSEEngineer;
					correctiveDTO.userName = corrective.user.UserName;
					correctiveDTO.FormStatus = corrective.FormStatus;
					List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
					foreach (var item in correctiveImages)
					{
						string FileName = item.FileName;
						correctiveDTO.Images.Add(FileName);

					}

					result.Message = "Success";
					result.Statescode = 200;
					result.Data = correctiveDTO;

					return result;
				}
			}

			result.Statescode = 404;
			result.Message = "data not found";
			return result;
		}


		[HttpGet("GetDataByDate/{date:DateTime}")]
		public ActionResult<ResultDTO> GetAllWithDataByDate(DateTime date, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<CorrectiveAction> temp = CorrectiveActionRepoistory.getall().Where(a => a.DateRaisedBy == date).ToList();
					List<CorrectiveResponseDTO> newTemp = new List<CorrectiveResponseDTO>();
					foreach (CorrectiveAction corrective in temp)
					{
						CorrectiveResponseDTO correctiveDTO = new CorrectiveResponseDTO();
						correctiveDTO.Id = corrective.Id;
						//correctiveDTO.Rig = corrective.Rig.Number;
						correctiveDTO.Title = corrective.Title;
						correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
						correctiveDTO.ReportNo = corrective.ReportNo;
						correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
						correctiveDTO.Standard = corrective.Standard.StandardName;
						correctiveDTO.ClauseNo = corrective.ClauseNo;
						correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
						foreach (var item in corrective.CorrectiveAndObservation)
						{
							string observation = item.CorrectiveObservation.Observation;
							correctiveDTO.CorrectiveAndObservation.Add(observation);

						}
						foreach (var item in corrective.CorrectiveAndRootCauses)
						{
							string cause = item.RootCauses.CauseName;
							correctiveDTO.CorrectiveAndRootCauses.Add(cause);

						}
						correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
						correctiveDTO.UpdateRisk = corrective.UpdateRisk;
						correctiveDTO.IfUpdate = corrective.IfUpdate;
						correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
						correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
						correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
						//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
						correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
						correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
						foreach (var item in corrective.CorrectiveDataTable)
						{
							CorrectiveDataTable Data = new CorrectiveDataTable();
							Data.Id = item.Id;
							Data.SN = item.SN;
							Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
							Data.Action = item.Action;
							Data.Responsible = item.Responsible;
							Data.SuggestedDate = item.SuggestedDate;
							Data.AchievementDate = item.AchievementDate;
							Data.Status = item.Status;
							Data.CorrectiveActionId = item.CorrectiveActionId;
							Data.FollowUpAudit = item.FollowUpAudit;
							Data.IsDeleted = item.IsDeleted;
							correctiveDTO.CorrectiveDataTable.Add(Data);
						};
						correctiveDTO.Comment = corrective.Comment;
						correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
						//correctiveDTO.QHSEEngineer = corrective.QHSEEngineer;
						correctiveDTO.userName = corrective.user.UserName;
						correctiveDTO.FormStatus = corrective.FormStatus;
						List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
						foreach (var item in correctiveImages)
						{
							string FileName = item.FileName;
							correctiveDTO.Images.Add(FileName);

						}
						newTemp.Add(correctiveDTO);
						//result.Data = prod;
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
					List<CorrectiveAction> temp = CorrectiveActionRepoistory.getall().Where(a => a.userID == UserId && a.DateRaisedBy == date).ToList();
					List<CorrectiveResponseDTO> newTemp = new List<CorrectiveResponseDTO>();
					foreach (CorrectiveAction corrective in temp)
					{
						CorrectiveResponseDTO correctiveDTO = new CorrectiveResponseDTO();
						correctiveDTO.Id = corrective.Id;
						//correctiveDTO.Rig = corrective.Rig.Number;
						correctiveDTO.Title = corrective.Title;
						correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
						correctiveDTO.ReportNo = corrective.ReportNo;
						correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
						correctiveDTO.Standard = corrective.Standard.StandardName;
						correctiveDTO.ClauseNo = corrective.ClauseNo;
						correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
						foreach (var item in corrective.CorrectiveAndObservation)
						{
							string observation = item.CorrectiveObservation.Observation;
							correctiveDTO.CorrectiveAndObservation.Add(observation);

						}
						foreach (var item in corrective.CorrectiveAndRootCauses)
						{
							string cause = item.RootCauses.CauseName;
							correctiveDTO.CorrectiveAndRootCauses.Add(cause);

						}
						correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
						correctiveDTO.UpdateRisk = corrective.UpdateRisk;
						correctiveDTO.IfUpdate = corrective.IfUpdate;
						correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
						correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
						correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
						//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
						correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
						correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
						foreach (var item in corrective.CorrectiveDataTable)
						{
							CorrectiveDataTable Data = new CorrectiveDataTable();
							Data.Id = item.Id;
							Data.SN = item.SN;
							Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
							Data.Action = item.Action;
							Data.Responsible = item.Responsible;
							Data.SuggestedDate = item.SuggestedDate;
							Data.AchievementDate = item.AchievementDate;
							Data.Status = item.Status;
							Data.CorrectiveActionId = item.CorrectiveActionId;
							Data.FollowUpAudit = item.FollowUpAudit;
							Data.IsDeleted = item.IsDeleted;
							correctiveDTO.CorrectiveDataTable.Add(Data);
						};
						correctiveDTO.Comment = corrective.Comment;
						correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
						//correctiveDTO.QHSEEngineer = corrective.QHSEEngineer;
						correctiveDTO.userName = corrective.user.UserName;
						correctiveDTO.FormStatus = corrective.FormStatus;
						List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
						foreach (var item in correctiveImages)
						{
							string FileName = item.FileName;
							correctiveDTO.Images.Add(FileName);

						}
						newTemp.Add(correctiveDTO);
						//result.Data = prod;
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

		[HttpGet("GetDataByDateForAnalysis")]
		public ActionResult<ResultDTO> GetAllWithDataByDateForAnalysis(string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					var correctiveActions = CorrectiveActionRepoistory.getall()
					.Where(item => item.CorrectiveDataTable.Any(obs => obs.SuggestedDate.Value.Date < DateTime.Now.Date))
					.ToList();

					if (correctiveActions.Any())
					{
						var newTemp = correctiveActions.Select(corrective =>
						{
							var correctiveDTO = new CorrectiveResponseDTO
							{
								Id = corrective.Id,
								//Rig = corrective.Rig.Number,
								Title = corrective.Title,
								FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName,
								ReportNo = corrective.ReportNo,
								DescriptionOfNonConformity = corrective.DescriptionOfNonConformity,
								Standard = corrective.Standard.StandardName,
								ClauseNo = corrective.ClauseNo,
								ObjectiveEvidence = corrective.ObjectiveEvidence,
								CorrectiveAndObservation = corrective.CorrectiveAndObservation.Select(item => item.CorrectiveObservation.Observation).ToList(),
								CorrectiveAndRootCauses = corrective.CorrectiveAndRootCauses.Select(item => item.RootCauses.CauseName).ToList(),
								IfOtherObservation = corrective.IfOtherObservation,
								UpdateRisk = corrective.UpdateRisk,
								IfUpdate = corrective.IfUpdate,
								ManagementOfChange = corrective.ManagementOfChange,
								IfManagementOfChange = corrective.IfManagementOfChange,
								NameRasiedBy = corrective.NameRasiedBy,
								DateRaisedBy = corrective.DateRaisedBy,
								IfOtherRootCause = corrective.IfOtherRootCause,
								CorrectiveDataTable = corrective.CorrectiveDataTable.Select(item => new CorrectiveDataTable
								{
									Id = item.Id,
									SN = item.SN,
									CorrectiveActionSelected = item.CorrectiveActionSelected,
									Action = item.Action,
									Responsible = item.Responsible,
									SuggestedDate = item.SuggestedDate,
									AchievementDate = item.AchievementDate,
									Status = item.Status,
									CorrectiveActionId = item.CorrectiveActionId,
									FollowUpAudit = item.FollowUpAudit,
									IsDeleted = item.IsDeleted
								}).ToList(),
								Comment = corrective.Comment,
								Q_ManagerSig = corrective.Q_ManagerSig,
								//QHSEEngineer = corrective.QHSEEngineer,
								userName = corrective.user.UserName,
								FormStatus = corrective.FormStatus,
								Images = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).Select(item => item.FileName).ToList()
							};

							return correctiveDTO;
						}).ToList();

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}
					else
					{
						result.Message = "No Data";
						result.Statescode = 201;
						result.Data = new List<CorrectiveActionDTO>();

						return result;
					}

					//List<CorrectiveAction> temp = CorrectiveActionRepoistory.getall();
					//List<CorrectiveAction> correctiveActions = new List<CorrectiveAction>();
					//foreach(var item in temp)
					//{
					//	if (item.CorrectiveDataTable.Count() > 0)
					//	{
					//		if(item.CorrectiveDataTable.Any(obs => obs.SuggestedDate.Value.Date < DateTime.Now.Date))
					//		{
					//			correctiveActions.Add(item);
					//		}
					//	}
					//}

					//if (correctiveActions.Count() > 0)
					//{
					//	List<CorrectiveResponseDTO> newTemp = new List<CorrectiveResponseDTO>();
					//	foreach (CorrectiveAction corrective in correctiveActions)
					//	{
					//		CorrectiveResponseDTO correctiveDTO = new CorrectiveResponseDTO();
					//		correctiveDTO.Id = corrective.Id;
					//		correctiveDTO.Rig = corrective.Rig.Number;
					//		correctiveDTO.Title = corrective.Title;
					//		correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
					//		correctiveDTO.ReportNo = corrective.ReportNo;
					//		correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
					//		correctiveDTO.Standard = corrective.Standard.StandardName;
					//		correctiveDTO.ClauseNo = corrective.ClauseNo;
					//		correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
					//		foreach (var item in corrective.CorrectiveAndObservation)
					//		{
					//			string observation = item.CorrectiveObservation.Observation;
					//			correctiveDTO.CorrectiveAndObservation.Add(observation);

					//		}
					//		foreach (var item in corrective.CorrectiveAndRootCauses)
					//		{
					//			string cause = item.RootCauses.CauseName;
					//			correctiveDTO.CorrectiveAndRootCauses.Add(cause);

					//		}
					//		correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
					//		correctiveDTO.UpdateRisk = corrective.UpdateRisk;
					//		correctiveDTO.IfUpdate = corrective.IfUpdate;
					//		correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
					//		correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
					//		correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
					//		//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
					//		correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
					//		correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
					//		foreach (var item in corrective.CorrectiveDataTable)
					//		{
					//			CorrectiveDataTable Data = new CorrectiveDataTable();
					//			Data.Id = item.Id;
					//			Data.SN = item.SN;
					//			Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
					//			Data.Action = item.Action;
					//			Data.Responsible = item.Responsible;
					//			Data.SuggestedDate = item.SuggestedDate;
					//			Data.AchievementDate = item.AchievementDate;
					//			Data.Status = item.Status;
					//			Data.CorrectiveActionId = item.CorrectiveActionId;
					//			Data.FollowUpAudit = item.FollowUpAudit;
					//			Data.IsDeleted = item.IsDeleted;
					//			correctiveDTO.CorrectiveDataTable.Add(Data);
					//		};
					//		correctiveDTO.Comment = corrective.Comment;
					//		correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
					//		correctiveDTO.userName = corrective.user.UserName;
					//		correctiveDTO.FormStatus = corrective.FormStatus;
					//		List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
					//		foreach (var item in correctiveImages)
					//		{
					//			string FileName = item.FileName;
					//			correctiveDTO.Images.Add(FileName);

					//		}
					//		newTemp.Add(correctiveDTO);
					//		//result.Data = prod;
					//	}
					//	if (newTemp != null)
					//	{
					//		result.Message = "Success";
					//		result.Statescode = 200;
					//		result.Data = newTemp;

					//		return result;
					//	}
				}

				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					var correctiveActions = CorrectiveActionRepoistory.getall()
					.Where(item => item.userID == UserId && item.CorrectiveDataTable.Any(obs => obs.SuggestedDate.Value.Date < DateTime.Now.Date))
					.ToList();

					if (correctiveActions.Any())
					{
						var newTemp = correctiveActions.Select(corrective =>
						{
							var correctiveDTO = new CorrectiveResponseDTO
							{
								Id = corrective.Id,
								//Rig = corrective.Rig.Number,
								Title = corrective.Title,
								FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName,
								ReportNo = corrective.ReportNo,
								DescriptionOfNonConformity = corrective.DescriptionOfNonConformity,
								Standard = corrective.Standard.StandardName,
								ClauseNo = corrective.ClauseNo,
								ObjectiveEvidence = corrective.ObjectiveEvidence,
								CorrectiveAndObservation = corrective.CorrectiveAndObservation.Select(item => item.CorrectiveObservation.Observation).ToList(),
								CorrectiveAndRootCauses = corrective.CorrectiveAndRootCauses.Select(item => item.RootCauses.CauseName).ToList(),
								IfOtherObservation = corrective.IfOtherObservation,
								UpdateRisk = corrective.UpdateRisk,
								IfUpdate = corrective.IfUpdate,
								ManagementOfChange = corrective.ManagementOfChange,
								IfManagementOfChange = corrective.IfManagementOfChange,
								NameRasiedBy = corrective.NameRasiedBy,
								DateRaisedBy = corrective.DateRaisedBy,
								IfOtherRootCause = corrective.IfOtherRootCause,
								CorrectiveDataTable = corrective.CorrectiveDataTable.Select(item => new CorrectiveDataTable
								{
									Id = item.Id,
									SN = item.SN,
									CorrectiveActionSelected = item.CorrectiveActionSelected,
									Action = item.Action,
									Responsible = item.Responsible,
									SuggestedDate = item.SuggestedDate,
									AchievementDate = item.AchievementDate,
									Status = item.Status,
									CorrectiveActionId = item.CorrectiveActionId,
									FollowUpAudit = item.FollowUpAudit,
									IsDeleted = item.IsDeleted
								}).ToList(),
								Comment = corrective.Comment,
								Q_ManagerSig = corrective.Q_ManagerSig,
								//QHSEEngineer = corrective.QHSEEngineer,
								userName = corrective.user.UserName,
								FormStatus = corrective.FormStatus,
								Images = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).Select(item => item.FileName).ToList()
							};

							return correctiveDTO;
						}).ToList();

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
						//List<CorrectiveAction> temp = CorrectiveActionRepoistory.getall().Where(a => a.userID == UserId && a.DateRaisedBy == date).ToList();
						//List<CorrectiveResponseDTO> newTemp = new List<CorrectiveResponseDTO>();
						//foreach (CorrectiveAction corrective in temp)
						//{
						//	CorrectiveResponseDTO correctiveDTO = new CorrectiveResponseDTO();
						//	correctiveDTO.Id = corrective.Id;
						//	correctiveDTO.Rig = corrective.Rig.Number;
						//	correctiveDTO.Title = corrective.Title;
						//	correctiveDTO.FormResponsability = corrective.CorrectiveResponsability.ResponsibilityName;
						//	correctiveDTO.ReportNo = corrective.ReportNo;
						//	correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
						//	correctiveDTO.Standard = corrective.Standard.StandardName;
						//	correctiveDTO.ClauseNo = corrective.ClauseNo;
						//	correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
						//	foreach (var item in corrective.CorrectiveAndObservation)
						//	{
						//		string observation = item.CorrectiveObservation.Observation;
						//		correctiveDTO.CorrectiveAndObservation.Add(observation);

						//	}
						//	foreach (var item in corrective.CorrectiveAndRootCauses)
						//	{
						//		string cause = item.RootCauses.CauseName;
						//		correctiveDTO.CorrectiveAndRootCauses.Add(cause);

						//	}
						//	correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
						//	correctiveDTO.UpdateRisk = corrective.UpdateRisk;
						//	correctiveDTO.IfUpdate = corrective.IfUpdate;
						//	correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
						//	correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
						//	correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
						//	//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
						//	correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
						//	correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
						//	foreach (var item in corrective.CorrectiveDataTable)
						//	{
						//		CorrectiveDataTable Data = new CorrectiveDataTable();
						//		Data.Id = item.Id;
						//		Data.SN = item.SN;
						//		Data.CorrectiveActionSelected = item.CorrectiveActionSelected;
						//		Data.Action = item.Action;
						//		Data.Responsible = item.Responsible;
						//		Data.SuggestedDate = item.SuggestedDate;
						//		Data.AchievementDate = item.AchievementDate;
						//		Data.Status = item.Status;
						//		Data.CorrectiveActionId = item.CorrectiveActionId;
						//		Data.FollowUpAudit = item.FollowUpAudit;
						//		Data.IsDeleted = item.IsDeleted;
						//		correctiveDTO.CorrectiveDataTable.Add(Data);
						//	};
						//	correctiveDTO.Comment = corrective.Comment;
						//	correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
						//	correctiveDTO.userName = corrective.user.UserName;
						//	correctiveDTO.FormStatus = corrective.FormStatus;
						//	List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
						//	foreach (var item in correctiveImages)
						//	{
						//		string FileName = item.FileName;
						//		correctiveDTO.Images.Add(FileName);

						//	}
						//	newTemp.Add(correctiveDTO);
						//	//result.Data = prod;
						//}
						//if (newTemp != null)
						//{
						//	result.Message = "Success";
						//	result.Statescode = 200;
						//	result.Data = newTemp;

						//	return result;
						//}
					}
					else
					{
						result.Message = "No Data";
						result.Statescode = 201;
						result.Data = new List<CorrectiveActionDTO>();

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


		[HttpGet("{ID:int}")]
		public ActionResult<ResultDTO> GetByID(int ID, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					CorrectiveAction corrective = CorrectiveActionRepo.getall().FirstOrDefault(a => a.Id == ID);
					CorrectiveByIdDTO correctiveDTO = new CorrectiveByIdDTO();
					correctiveDTO.Id = corrective.Id;
					//correctiveDTO.RigId = corrective.RigId;
					correctiveDTO.Title = corrective.Title;
					correctiveDTO.FormResponsabilityId = corrective.FormResponsabilityId;
					correctiveDTO.ReportNo = corrective.ReportNo;
					correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
					correctiveDTO.StandardId = corrective.StandardId;
					correctiveDTO.ClauseNo = corrective.ClauseNo;
					correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
					var CorrectiveAndObservationList = CorrectiveAndObservationRepo.getall().Where(o => o.CorrectiveActionId == corrective.Id).ToList();
					foreach (var item in CorrectiveAndObservationList)
					{
						CorrectiveAndObservation observation = new CorrectiveAndObservation();
						observation.Id = item.Id;
						observation.CorrectiveObservationId = item.CorrectiveObservationId;
						observation.CorrectiveActionId = item.CorrectiveActionId;
						observation.IsDeleted = item.IsDeleted;
						correctiveDTO.CorrectiveObservation.Add(observation);
					}
					var CorrectiveAndRootCausesList = CorrectiveAndRootCausesRepo.getall().Where(r => r.CorrectiveActionId == corrective.Id).ToList();
					foreach (var item in CorrectiveAndRootCausesList)
					{
						CorrectiveAndRootCauses causes = new CorrectiveAndRootCauses();
						causes.Id = item.Id;
						causes.RootCausesId = item.RootCausesId;
						causes.CorrectiveActionId = item.CorrectiveActionId;
						causes.IsDeleted = item.IsDeleted;
						correctiveDTO.RootCauses.Add(causes);
					}
					var CorrectiveDataTableList = CorrectiveDataTableRepo.getall().Where(d => d.CorrectiveActionId == corrective.Id).ToList();
					if (CorrectiveDataTableList.Count() == 4)
					{
						correctiveDTO.sn1 = CorrectiveDataTableList[0]?.SN;
						correctiveDTO.CorrectiveActionSelected1 = CorrectiveDataTableList[0].CorrectiveActionSelected;
						correctiveDTO.Action1 = CorrectiveDataTableList[0]?.Action;
						correctiveDTO.Responsible1 = CorrectiveDataTableList[0]?.Responsible;
						correctiveDTO.SuggestedDate1 = CorrectiveDataTableList[0]?.SuggestedDate;
						correctiveDTO.AchievementDate1 = CorrectiveDataTableList[0]?.AchievementDate;
						correctiveDTO.FollowUpAudit1 = CorrectiveDataTableList[0]?.FollowUpAudit;
						correctiveDTO.Status1 = CorrectiveDataTableList[0].Status != null ? CorrectiveDataTableList[0].Status : false; ;
						correctiveDTO.sn2 = CorrectiveDataTableList[1]?.SN;
						correctiveDTO.CorrectiveActionSelected2 = CorrectiveDataTableList[1].CorrectiveActionSelected;
						correctiveDTO.Action2 = CorrectiveDataTableList[1]?.Action;
						correctiveDTO.Responsible2 = CorrectiveDataTableList[1]?.Responsible;
						correctiveDTO.SuggestedDate2 = CorrectiveDataTableList[1]?.SuggestedDate;
						correctiveDTO.AchievementDate2 = CorrectiveDataTableList[1]?.AchievementDate;
						correctiveDTO.FollowUpAudit2 = CorrectiveDataTableList[1]?.FollowUpAudit;
						correctiveDTO.Status2 = CorrectiveDataTableList[1].Status != null ? CorrectiveDataTableList[1].Status : false; ;
						correctiveDTO.sn3 = CorrectiveDataTableList[2]?.SN;
						correctiveDTO.CorrectiveActionSelected3 = CorrectiveDataTableList[2].CorrectiveActionSelected;
						correctiveDTO.Action3 = CorrectiveDataTableList[2]?.Action;
						correctiveDTO.Responsible3 = CorrectiveDataTableList[2]?.Responsible;
						correctiveDTO.SuggestedDate3 = CorrectiveDataTableList[2]?.SuggestedDate;
						correctiveDTO.AchievementDate3 = CorrectiveDataTableList[2]?.AchievementDate;
						correctiveDTO.FollowUpAudit3 = CorrectiveDataTableList[2]?.FollowUpAudit;
						correctiveDTO.Status3 = CorrectiveDataTableList[2].Status != null ? CorrectiveDataTableList[2].Status : false;
						correctiveDTO.sn4 = CorrectiveDataTableList[3]?.SN != null ? CorrectiveDataTableList[3]?.SN : 0;
						correctiveDTO.CorrectiveActionSelected4 = CorrectiveDataTableList[3].CorrectiveActionSelected;
						correctiveDTO.Action4 = CorrectiveDataTableList[3]?.Action;
						correctiveDTO.Responsible4 = CorrectiveDataTableList[3]?.Responsible;
						correctiveDTO.SuggestedDate4 = CorrectiveDataTableList[3]?.SuggestedDate ;
						correctiveDTO.AchievementDate4 = CorrectiveDataTableList[3]?.AchievementDate;
						correctiveDTO.FollowUpAudit4 = CorrectiveDataTableList[3]?.FollowUpAudit;
						correctiveDTO.Status4 = CorrectiveDataTableList[3].Status != null ? CorrectiveDataTableList[3].Status : false;
					}
					else if (CorrectiveDataTableList.Count() == 3)
					{
						correctiveDTO.sn1 = CorrectiveDataTableList[0]?.SN;
						correctiveDTO.CorrectiveActionSelected1 = CorrectiveDataTableList[0].CorrectiveActionSelected;
						correctiveDTO.Action1 = CorrectiveDataTableList[0]?.Action;
						correctiveDTO.Responsible1 = CorrectiveDataTableList[0]?.Responsible;
						correctiveDTO.SuggestedDate1 = CorrectiveDataTableList[0]?.SuggestedDate;
						correctiveDTO.AchievementDate1 = CorrectiveDataTableList[0]?.AchievementDate;
						correctiveDTO.FollowUpAudit1 = CorrectiveDataTableList[0]?.FollowUpAudit;
						correctiveDTO.Status1 = CorrectiveDataTableList[0].Status != null ? CorrectiveDataTableList[0].Status : false; ;
						correctiveDTO.sn2 = CorrectiveDataTableList[1]?.SN;
						correctiveDTO.CorrectiveActionSelected2 = CorrectiveDataTableList[1].CorrectiveActionSelected;
						correctiveDTO.Action2 = CorrectiveDataTableList[1]?.Action;
						correctiveDTO.Responsible2 = CorrectiveDataTableList[1]?.Responsible;
						correctiveDTO.SuggestedDate2 = CorrectiveDataTableList[1]?.SuggestedDate;
						correctiveDTO.AchievementDate2 = CorrectiveDataTableList[1]?.AchievementDate;
						correctiveDTO.FollowUpAudit2 = CorrectiveDataTableList[1]?.FollowUpAudit;
						correctiveDTO.Status2 = CorrectiveDataTableList[1].Status != null ? CorrectiveDataTableList[1].Status : false; ;
						correctiveDTO.sn3 = CorrectiveDataTableList[2]?.SN;
						correctiveDTO.CorrectiveActionSelected3 = CorrectiveDataTableList[2].CorrectiveActionSelected;
						correctiveDTO.Action3 = CorrectiveDataTableList[2]?.Action;
						correctiveDTO.Responsible3 = CorrectiveDataTableList[2]?.Responsible;
						correctiveDTO.SuggestedDate3 = CorrectiveDataTableList[2]?.SuggestedDate;
						correctiveDTO.AchievementDate3 = CorrectiveDataTableList[2]?.AchievementDate;
						correctiveDTO.FollowUpAudit3 = CorrectiveDataTableList[2]?.FollowUpAudit;
						correctiveDTO.Status3 = CorrectiveDataTableList[2].Status != null ? CorrectiveDataTableList[2].Status : false;
					}
					else if (CorrectiveDataTableList.Count() == 2)
					{
						correctiveDTO.sn1 = CorrectiveDataTableList[0]?.SN;
						correctiveDTO.CorrectiveActionSelected1 = CorrectiveDataTableList[0].CorrectiveActionSelected;
						correctiveDTO.Action1 = CorrectiveDataTableList[0]?.Action;
						correctiveDTO.Responsible1 = CorrectiveDataTableList[0]?.Responsible;
						correctiveDTO.SuggestedDate1 = CorrectiveDataTableList[0]?.SuggestedDate;
						correctiveDTO.AchievementDate1 = CorrectiveDataTableList[0]?.AchievementDate;
						correctiveDTO.FollowUpAudit1 = CorrectiveDataTableList[0]?.FollowUpAudit;
						correctiveDTO.Status1 = CorrectiveDataTableList[0].Status != null ? CorrectiveDataTableList[0].Status : false; ;
						correctiveDTO.sn2 = CorrectiveDataTableList[1]?.SN;
						correctiveDTO.CorrectiveActionSelected2 = CorrectiveDataTableList[1].CorrectiveActionSelected;
						correctiveDTO.Action2 = CorrectiveDataTableList[1]?.Action;
						correctiveDTO.Responsible2 = CorrectiveDataTableList[1]?.Responsible;
						correctiveDTO.SuggestedDate2 = CorrectiveDataTableList[1]?.SuggestedDate;
						correctiveDTO.AchievementDate2 = CorrectiveDataTableList[1]?.AchievementDate;
						correctiveDTO.FollowUpAudit2 = CorrectiveDataTableList[1]?.FollowUpAudit;
						correctiveDTO.Status2 = CorrectiveDataTableList[1].Status != null ? CorrectiveDataTableList[1].Status : false; ;
					}
					else if (CorrectiveDataTableList.Count() == 1)
					{
						correctiveDTO.sn1 = CorrectiveDataTableList[0]?.SN;
						correctiveDTO.CorrectiveActionSelected1 = CorrectiveDataTableList[0].CorrectiveActionSelected;
						correctiveDTO.Action1 = CorrectiveDataTableList[0]?.Action;
						correctiveDTO.Responsible1 = CorrectiveDataTableList[0]?.Responsible;
						correctiveDTO.SuggestedDate1 = CorrectiveDataTableList[0]?.SuggestedDate;
						correctiveDTO.AchievementDate1 = CorrectiveDataTableList[0]?.AchievementDate;
						correctiveDTO.FollowUpAudit1 = CorrectiveDataTableList[0]?.FollowUpAudit;
						correctiveDTO.Status1 = CorrectiveDataTableList[0].Status != null ? CorrectiveDataTableList[0].Status : false; ;
					}

					correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
					correctiveDTO.UpdateRisk = corrective.UpdateRisk;
					correctiveDTO.IfUpdate = corrective.IfUpdate;
					correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
					correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
					correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
					//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
					correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
					correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
					correctiveDTO.Comment = corrective.Comment;
					correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
					//correctiveDTO.QHSEEngineer = corrective.QHSEEngineer;
					correctiveDTO.userID = corrective.userID;
					correctiveDTO.FormStatus = corrective.FormStatus;
					List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
					var ImageList = CorrectiveImagesRepo.getall().Where(i => i.CorrectiveActionId == corrective.Id).ToList();
					foreach (var item in ImageList)
					{
						CorrectiveImages image = new CorrectiveImages();
						image.Id = item.Id;
						image.FileName = item.FileName;
						image.CorrectiveActionId = item.CorrectiveActionId;
						image.IsDeleted = item.IsDeleted;
						correctiveDTO.Images.Add(image);
					}

					result.Message = "Success";
					result.Data = correctiveDTO;
					result.Statescode = 200;
					return result;

				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					CorrectiveAction corrective = CorrectiveActionRepo.getall().FirstOrDefault(a => a.Id == ID && a.userID == UserId);
					CorrectiveByIdDTO correctiveDTO = new CorrectiveByIdDTO();
					correctiveDTO.Id = corrective.Id;
					//correctiveDTO.RigId = corrective.RigId;
					correctiveDTO.Title = corrective.Title;
					correctiveDTO.FormResponsabilityId = corrective.FormResponsabilityId;
					correctiveDTO.ReportNo = corrective.ReportNo;
					correctiveDTO.DescriptionOfNonConformity = corrective.DescriptionOfNonConformity;
					correctiveDTO.StandardId = corrective.StandardId;
					correctiveDTO.ClauseNo = corrective.ClauseNo;
					correctiveDTO.ObjectiveEvidence = corrective.ObjectiveEvidence;
					var CorrectiveAndObservationList = CorrectiveAndObservationRepo.getall().Where(o => o.CorrectiveActionId == corrective.Id).ToList();
					foreach (var item in CorrectiveAndObservationList)
					{
						CorrectiveAndObservation observation = new CorrectiveAndObservation();
						observation.Id = item.Id;
						observation.CorrectiveObservationId = item.CorrectiveObservationId;
						observation.CorrectiveActionId = item.CorrectiveActionId;
						observation.IsDeleted = item.IsDeleted;
						correctiveDTO.CorrectiveObservation.Add(observation);
					}
					var CorrectiveAndRootCausesList = CorrectiveAndRootCausesRepo.getall().Where(r => r.CorrectiveActionId == corrective.Id).ToList();
					foreach (var item in CorrectiveAndRootCausesList)
					{
						CorrectiveAndRootCauses causes = new CorrectiveAndRootCauses();
						causes.Id = item.Id;
						causes.RootCausesId = item.RootCausesId;
						causes.CorrectiveActionId = item.CorrectiveActionId;
						causes.IsDeleted = item.IsDeleted;
						correctiveDTO.RootCauses.Add(causes);
					}
					var CorrectiveDataTableList = CorrectiveDataTableRepo.getall().Where(d => d.CorrectiveActionId == corrective.Id).ToList();
					if (CorrectiveDataTableList.Count() == 4)
					{
						correctiveDTO.sn1 = CorrectiveDataTableList[0]?.SN;
						correctiveDTO.CorrectiveActionSelected1 = CorrectiveDataTableList[0].CorrectiveActionSelected;
						correctiveDTO.Action1 = CorrectiveDataTableList[0]?.Action;
						correctiveDTO.Responsible1 = CorrectiveDataTableList[0]?.Responsible;
						correctiveDTO.SuggestedDate1 = CorrectiveDataTableList[0]?.SuggestedDate;
						correctiveDTO.AchievementDate1 = CorrectiveDataTableList[0]?.AchievementDate;
						correctiveDTO.FollowUpAudit1 = CorrectiveDataTableList[0]?.FollowUpAudit;
						correctiveDTO.Status1 = CorrectiveDataTableList[0].Status != null ? CorrectiveDataTableList[0].Status : false; ;
						correctiveDTO.sn2 = CorrectiveDataTableList[1]?.SN;
						correctiveDTO.CorrectiveActionSelected2 = CorrectiveDataTableList[1].CorrectiveActionSelected;
						correctiveDTO.Action2 = CorrectiveDataTableList[1]?.Action;
						correctiveDTO.Responsible2 = CorrectiveDataTableList[1]?.Responsible;
						correctiveDTO.SuggestedDate2 = CorrectiveDataTableList[1]?.SuggestedDate;
						correctiveDTO.AchievementDate2 = CorrectiveDataTableList[1]?.AchievementDate;
						correctiveDTO.FollowUpAudit2 = CorrectiveDataTableList[1]?.FollowUpAudit;
						correctiveDTO.Status2 = CorrectiveDataTableList[1].Status != null ? CorrectiveDataTableList[1].Status : false; ;
						correctiveDTO.sn3 = CorrectiveDataTableList[2]?.SN;
						correctiveDTO.CorrectiveActionSelected3 = CorrectiveDataTableList[2].CorrectiveActionSelected;
						correctiveDTO.Action3 = CorrectiveDataTableList[2]?.Action;
						correctiveDTO.Responsible3 = CorrectiveDataTableList[2]?.Responsible;
						correctiveDTO.SuggestedDate3 = CorrectiveDataTableList[2]?.SuggestedDate;
						correctiveDTO.AchievementDate3 = CorrectiveDataTableList[2]?.AchievementDate;
						correctiveDTO.FollowUpAudit3 = CorrectiveDataTableList[2]?.FollowUpAudit;
						correctiveDTO.Status3 = CorrectiveDataTableList[2].Status != null ? CorrectiveDataTableList[2].Status : false;
						correctiveDTO.sn4 = CorrectiveDataTableList[3]?.SN != null ? CorrectiveDataTableList[3]?.SN : 0;
						correctiveDTO.CorrectiveActionSelected4 = CorrectiveDataTableList[3].CorrectiveActionSelected;
						correctiveDTO.Action4 = CorrectiveDataTableList[3]?.Action;
						correctiveDTO.Responsible4 = CorrectiveDataTableList[3]?.Responsible;
						correctiveDTO.SuggestedDate4 = CorrectiveDataTableList[3]?.SuggestedDate;
						correctiveDTO.AchievementDate4 = CorrectiveDataTableList[3]?.AchievementDate;
						correctiveDTO.FollowUpAudit4 = CorrectiveDataTableList[3]?.FollowUpAudit;
						correctiveDTO.Status4 = CorrectiveDataTableList[3].Status != null ? CorrectiveDataTableList[3].Status : false;
					}
					else if (CorrectiveDataTableList.Count() == 3)
					{
						correctiveDTO.sn1 = CorrectiveDataTableList[0]?.SN;
						correctiveDTO.CorrectiveActionSelected1 = CorrectiveDataTableList[0].CorrectiveActionSelected;
						correctiveDTO.Action1 = CorrectiveDataTableList[0]?.Action;
						correctiveDTO.Responsible1 = CorrectiveDataTableList[0]?.Responsible;
						correctiveDTO.SuggestedDate1 = CorrectiveDataTableList[0]?.SuggestedDate;
						correctiveDTO.AchievementDate1 = CorrectiveDataTableList[0]?.AchievementDate;
						correctiveDTO.FollowUpAudit1 = CorrectiveDataTableList[0]?.FollowUpAudit;
						correctiveDTO.Status1 = CorrectiveDataTableList[0].Status != null ? CorrectiveDataTableList[0].Status : false; ;
						correctiveDTO.sn2 = CorrectiveDataTableList[1]?.SN;
						correctiveDTO.CorrectiveActionSelected2 = CorrectiveDataTableList[1].CorrectiveActionSelected;
						correctiveDTO.Action2 = CorrectiveDataTableList[1]?.Action;
						correctiveDTO.Responsible2 = CorrectiveDataTableList[1]?.Responsible;
						correctiveDTO.SuggestedDate2 = CorrectiveDataTableList[1]?.SuggestedDate;
						correctiveDTO.AchievementDate2 = CorrectiveDataTableList[1]?.AchievementDate;
						correctiveDTO.FollowUpAudit2 = CorrectiveDataTableList[1]?.FollowUpAudit;
						correctiveDTO.Status2 = CorrectiveDataTableList[1].Status != null ? CorrectiveDataTableList[1].Status : false; ;
						correctiveDTO.sn3 = CorrectiveDataTableList[2]?.SN;
						correctiveDTO.CorrectiveActionSelected3 = CorrectiveDataTableList[2].CorrectiveActionSelected;
						correctiveDTO.Action3 = CorrectiveDataTableList[2]?.Action;
						correctiveDTO.Responsible3 = CorrectiveDataTableList[2]?.Responsible;
						correctiveDTO.SuggestedDate3 = CorrectiveDataTableList[2]?.SuggestedDate;
						correctiveDTO.AchievementDate3 = CorrectiveDataTableList[2]?.AchievementDate;
						correctiveDTO.FollowUpAudit3 = CorrectiveDataTableList[2]?.FollowUpAudit;
						correctiveDTO.Status3 = CorrectiveDataTableList[2].Status != null ? CorrectiveDataTableList[2].Status : false;
					}
					else if (CorrectiveDataTableList.Count() == 2)
					{
						correctiveDTO.sn1 = CorrectiveDataTableList[0]?.SN;
						correctiveDTO.CorrectiveActionSelected1 = CorrectiveDataTableList[0].CorrectiveActionSelected;
						correctiveDTO.Action1 = CorrectiveDataTableList[0]?.Action;
						correctiveDTO.Responsible1 = CorrectiveDataTableList[0]?.Responsible;
						correctiveDTO.SuggestedDate1 = CorrectiveDataTableList[0]?.SuggestedDate;
						correctiveDTO.AchievementDate1 = CorrectiveDataTableList[0]?.AchievementDate;
						correctiveDTO.FollowUpAudit1 = CorrectiveDataTableList[0]?.FollowUpAudit;
						correctiveDTO.Status1 = CorrectiveDataTableList[0].Status != null ? CorrectiveDataTableList[0].Status : false; ;
						correctiveDTO.sn2 = CorrectiveDataTableList[1]?.SN;
						correctiveDTO.CorrectiveActionSelected2 = CorrectiveDataTableList[1].CorrectiveActionSelected;
						correctiveDTO.Action2 = CorrectiveDataTableList[1]?.Action;
						correctiveDTO.Responsible2 = CorrectiveDataTableList[1]?.Responsible;
						correctiveDTO.SuggestedDate2 = CorrectiveDataTableList[1]?.SuggestedDate;
						correctiveDTO.AchievementDate2 = CorrectiveDataTableList[1]?.AchievementDate;
						correctiveDTO.FollowUpAudit2 = CorrectiveDataTableList[1]?.FollowUpAudit;
						correctiveDTO.Status2 = CorrectiveDataTableList[1].Status != null ? CorrectiveDataTableList[1].Status : false; ;
					}
					else if (CorrectiveDataTableList.Count() == 1)
					{
						correctiveDTO.sn1 = CorrectiveDataTableList[0]?.SN;
						correctiveDTO.CorrectiveActionSelected1 = CorrectiveDataTableList[0].CorrectiveActionSelected;
						correctiveDTO.Action1 = CorrectiveDataTableList[0]?.Action;
						correctiveDTO.Responsible1 = CorrectiveDataTableList[0]?.Responsible;
						correctiveDTO.SuggestedDate1 = CorrectiveDataTableList[0]?.SuggestedDate;
						correctiveDTO.AchievementDate1 = CorrectiveDataTableList[0]?.AchievementDate;
						correctiveDTO.FollowUpAudit1 = CorrectiveDataTableList[0]?.FollowUpAudit;
						correctiveDTO.Status1 = CorrectiveDataTableList[0].Status != null ? CorrectiveDataTableList[0].Status : false; ;
					}

					correctiveDTO.IfOtherObservation = corrective.IfOtherObservation;
					correctiveDTO.UpdateRisk = corrective.UpdateRisk;
					correctiveDTO.IfUpdate = corrective.IfUpdate;
					correctiveDTO.ManagementOfChange = corrective.ManagementOfChange;
					correctiveDTO.IfManagementOfChange = corrective.IfManagementOfChange;
					correctiveDTO.NameRasiedBy = corrective.NameRasiedBy;
					//correctiveDTO.SigRasiedBy = corrective.SigRasiedBy;
					correctiveDTO.DateRaisedBy = corrective.DateRaisedBy;
					correctiveDTO.IfOtherRootCause = corrective.IfOtherRootCause;
					correctiveDTO.Comment = corrective.Comment;
					correctiveDTO.Q_ManagerSig = corrective.Q_ManagerSig;
					//correctiveDTO.QHSEEngineer = corrective.QHSEEngineer;
					correctiveDTO.userID = corrective.userID;
					correctiveDTO.FormStatus = corrective.FormStatus;
					List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == corrective.Id).ToList();
					var ImageList = CorrectiveImagesRepo.getall().Where(i => i.CorrectiveActionId == corrective.Id).ToList();
					foreach (var item in ImageList)
					{
						CorrectiveImages image = new CorrectiveImages();
						image.Id = item.Id;
						image.FileName = item.FileName;
						image.CorrectiveActionId = item.CorrectiveActionId;
						image.IsDeleted = item.IsDeleted;
						correctiveDTO.Images.Add(image);
					}
					
					result.Message = "Success";
					result.Data = correctiveDTO;
					result.Statescode = 200;
					return result;
				}


			}
			catch (Exception Ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}

			return result;
		}

		[HttpPost]
		public ActionResult<ResultDTO> AddCorrective([FromForm] CorrectiveActionDTO correctiveActionDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					CorrectiveAction corrective = new CorrectiveAction();
					corrective.Id = default;
					corrective.ReportNo = correctiveActionDTO.ReportNo;
					//corrective.RigId = correctiveActionDTO.RigId;
					corrective.FormResponsabilityId = correctiveActionDTO.FormResponsabilityId;
					corrective.Title = correctiveActionDTO.Title;
					corrective.DescriptionOfNonConformity = correctiveActionDTO.DescriptionOfNonConformity;
					corrective.StandardId = correctiveActionDTO.StandardId;
					corrective.ClauseNo = correctiveActionDTO.ClauseNo;
					corrective.ObjectiveEvidence = correctiveActionDTO.ObjectiveEvidence;
					corrective.IfOtherObservation  = correctiveActionDTO.IfOtherObservation;
					corrective.UpdateRisk = correctiveActionDTO.UpdateRisk;
					corrective.IfUpdate = correctiveActionDTO.IfUpdate;
					corrective.ManagementOfChange = correctiveActionDTO.ManagementOfChange;
					corrective.IfManagementOfChange = correctiveActionDTO.IfManagementOfChange;
					corrective.NameRasiedBy = correctiveActionDTO.NameRasiedBy;
					//corrective.SigRasiedBy = correctiveActionDTO.SigRasiedBy;
					corrective.DateRaisedBy = correctiveActionDTO.DateRaisedBy;
					corrective.IfOtherRootCause = correctiveActionDTO.IfOtherRootCause;
					corrective.Comment = correctiveActionDTO.Comment;
					corrective.Q_ManagerSig = correctiveActionDTO.Q_ManagerSig;
					//corrective.QHSEEngineer = correctiveActionDTO.QHSEEngineer;
					corrective.userID = correctiveActionDTO.userID;
					corrective.FormStatus = correctiveActionDTO.FormStatus;

					CorrectiveActionRepo.create(corrective);

					foreach (var item in correctiveActionDTO.CorrectiveObservation)
					{
						CorrectiveAndObservation correctiveAndObservation = new CorrectiveAndObservation();

						correctiveAndObservation.CorrectiveActionId = corrective.Id;
						correctiveAndObservation.CorrectiveObservationId = item;
						CorrectiveAndObservationRepo.create(correctiveAndObservation);
					}
					foreach (var item in correctiveActionDTO.RootCauses)
					{
						CorrectiveAndRootCauses correctiveAndRootCauses = new CorrectiveAndRootCauses();

						correctiveAndRootCauses.CorrectiveActionId = corrective.Id;
						correctiveAndRootCauses.RootCausesId = item;
						CorrectiveAndRootCausesRepo.create(correctiveAndRootCauses);
					}

					if (!string.IsNullOrEmpty(correctiveActionDTO.Action1) && !string.IsNullOrEmpty(correctiveActionDTO.CorrectiveActionSelected1) && (correctiveActionDTO.SN1.HasValue && correctiveActionDTO.SN1 != 0) && !string.IsNullOrEmpty(correctiveActionDTO.Responsible1) && correctiveActionDTO.SuggestedDate1.HasValue && correctiveActionDTO.SuggestedDate1.Value != DateTime.Parse("1970-01-01") && (correctiveActionDTO.SuggestedDate1.HasValue && correctiveActionDTO.SuggestedDate1.Value != DateTime.Parse("1970-01-01")))
					{
						CorrectiveDataTable correctiveDataTable = new CorrectiveDataTable();
						correctiveDataTable.SN = correctiveActionDTO.SN1;
						correctiveDataTable.CorrectiveActionSelected = correctiveActionDTO.CorrectiveActionSelected1;
						correctiveDataTable.Action = correctiveActionDTO.Action1;
						correctiveDataTable.Responsible = correctiveActionDTO.Responsible1;
						correctiveDataTable.SuggestedDate = correctiveActionDTO.SuggestedDate1;
						correctiveDataTable.AchievementDate = correctiveActionDTO.AchievementDate1;
						correctiveDataTable.FollowUpAudit = correctiveActionDTO.FollowUpAudit1;
						correctiveDataTable.Status = correctiveActionDTO.Status1;
						correctiveDataTable.CorrectiveActionId = corrective.Id;
						CorrectiveDataTableRepo.create(correctiveDataTable);
					}

					if (!string.IsNullOrEmpty(correctiveActionDTO.Action2) && !string.IsNullOrEmpty(correctiveActionDTO.CorrectiveActionSelected2) && (correctiveActionDTO.SN2.HasValue && correctiveActionDTO.SN2 != 0) && !string.IsNullOrEmpty(correctiveActionDTO.Responsible2) && correctiveActionDTO.SuggestedDate2.HasValue && correctiveActionDTO.SuggestedDate2.Value != DateTime.Parse("1970-01-01") && (correctiveActionDTO.SuggestedDate2.HasValue && correctiveActionDTO.SuggestedDate2.Value != DateTime.Parse("1970-01-01")))
					{
						CorrectiveDataTable correctiveDataTable = new CorrectiveDataTable();
						correctiveDataTable.SN = correctiveActionDTO.SN2;
						correctiveDataTable.CorrectiveActionSelected = correctiveActionDTO.CorrectiveActionSelected2;
						correctiveDataTable.Action = correctiveActionDTO.Action2;
						correctiveDataTable.Responsible = correctiveActionDTO.Responsible2;
						correctiveDataTable.SuggestedDate = correctiveActionDTO.SuggestedDate2;
						correctiveDataTable.AchievementDate = correctiveActionDTO.AchievementDate2;
						correctiveDataTable.FollowUpAudit = correctiveActionDTO.FollowUpAudit2;
						correctiveDataTable.Status = correctiveActionDTO.Status2;
						correctiveDataTable.CorrectiveActionId = corrective.Id;
						CorrectiveDataTableRepo.create(correctiveDataTable);
					}

					if (!string.IsNullOrEmpty(correctiveActionDTO.Action3) && !string.IsNullOrEmpty(correctiveActionDTO.CorrectiveActionSelected3) && (correctiveActionDTO.SN3.HasValue && correctiveActionDTO.SN3 != 0) && !string.IsNullOrEmpty(correctiveActionDTO.Responsible3) && (correctiveActionDTO.SuggestedDate3.HasValue && correctiveActionDTO.SuggestedDate3.Value != DateTime.Parse("1970-01-01")) && (correctiveActionDTO.SuggestedDate3.HasValue && correctiveActionDTO.SuggestedDate3.Value != DateTime.Parse("1970-01-01")))
					{
						CorrectiveDataTable correctiveDataTable = new CorrectiveDataTable();
						correctiveDataTable.SN = correctiveActionDTO.SN3;
						correctiveDataTable.CorrectiveActionSelected = correctiveActionDTO.CorrectiveActionSelected3;
						correctiveDataTable.Action = correctiveActionDTO.Action3;
						correctiveDataTable.Responsible = correctiveActionDTO.Responsible3;
						correctiveDataTable.SuggestedDate = correctiveActionDTO.SuggestedDate3;
						correctiveDataTable.AchievementDate = correctiveActionDTO.AchievementDate3;
						correctiveDataTable.FollowUpAudit = correctiveActionDTO.FollowUpAudit3;
						correctiveDataTable.Status = correctiveActionDTO.Status3;
						correctiveDataTable.CorrectiveActionId = corrective.Id;
						CorrectiveDataTableRepo.create(correctiveDataTable);
					}

					if (!string.IsNullOrEmpty(correctiveActionDTO.Action4) && !string.IsNullOrEmpty(correctiveActionDTO.CorrectiveActionSelected4) && (correctiveActionDTO.SN4.HasValue && correctiveActionDTO.SN4 != 0) && !string.IsNullOrEmpty(correctiveActionDTO.Responsible4) && (correctiveActionDTO.SuggestedDate4.HasValue && correctiveActionDTO.SuggestedDate4.Value != DateTime.Parse("1970-01-01")) && (correctiveActionDTO.SuggestedDate4.HasValue && correctiveActionDTO.SuggestedDate4.Value != DateTime.Parse("1970-01-01")))
					{
						CorrectiveDataTable correctiveDataTable = new CorrectiveDataTable();
						correctiveDataTable.SN = correctiveActionDTO.SN4;
						correctiveDataTable.CorrectiveActionSelected = correctiveActionDTO.CorrectiveActionSelected4;
						correctiveDataTable.Action = correctiveActionDTO.Action4;
						correctiveDataTable.Responsible = correctiveActionDTO.Responsible4;
						correctiveDataTable.SuggestedDate = correctiveActionDTO.SuggestedDate4;
						correctiveDataTable.AchievementDate = correctiveActionDTO.AchievementDate4;
						correctiveDataTable.FollowUpAudit = correctiveActionDTO.FollowUpAudit4;
						correctiveDataTable.Status = correctiveActionDTO.Status4;
						correctiveDataTable.CorrectiveActionId = corrective.Id;
						CorrectiveDataTableRepo.create(correctiveDataTable);
					}

					if (correctiveActionDTO.Images!=null)
					{
						foreach (var item in correctiveActionDTO?.Images)
						{
							CorrectiveImages correctiveImages = new CorrectiveImages();
							correctiveImages.FileName = ImagesHelper.uploadImg(item, "CorrectiveIMG");
							correctiveImages.CorrectiveActionId = corrective.Id;
							CorrectiveImagesRepo.create(correctiveImages);
						}
					}
					result.Message = "Success";
					result.Data = corrective;
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
		public ActionResult<ResultDTO> Put(int id, [FromForm] CorrectiveActionDTO newCorrective) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					CorrectiveAction orgCorrective = CorrectiveActionRepo.getbyid(id);
					orgCorrective.ReportNo = newCorrective.ReportNo;
					//orgCorrective.RigId = newCorrective.RigId;
					orgCorrective.Title = newCorrective.Title;
					orgCorrective.FormResponsabilityId = newCorrective.FormResponsabilityId;
					orgCorrective.DescriptionOfNonConformity = newCorrective.DescriptionOfNonConformity;
					orgCorrective.StandardId = newCorrective.StandardId;
					orgCorrective.ClauseNo = newCorrective.ClauseNo;
					orgCorrective.ObjectiveEvidence = newCorrective.ObjectiveEvidence;
					orgCorrective.IfOtherObservation  = newCorrective.IfOtherObservation!="null"?newCorrective.IfOtherObservation:null;
					orgCorrective.UpdateRisk = newCorrective.UpdateRisk;
					orgCorrective.IfUpdate = newCorrective.IfUpdate!="null"? newCorrective.IfUpdate:null;
					orgCorrective.ManagementOfChange = newCorrective.ManagementOfChange;
					orgCorrective.IfManagementOfChange = newCorrective.IfManagementOfChange!= "null" ? newCorrective.IfManagementOfChange : null;
					orgCorrective.NameRasiedBy = newCorrective.NameRasiedBy;
					//orgCorrective.SigRasiedBy = newCorrective.SigRasiedBy;
					orgCorrective.DateRaisedBy = newCorrective.DateRaisedBy;
					orgCorrective.IfOtherRootCause = newCorrective.IfOtherRootCause!="null"?newCorrective.IfOtherRootCause:null;
					orgCorrective.Comment = newCorrective.Comment!="null"?newCorrective.Comment:null;
					orgCorrective.Q_ManagerSig = newCorrective.Q_ManagerSig!="null"? newCorrective.Q_ManagerSig:null;
					//orgCorrective.QHSEEngineer = newCorrective.QHSEEngineer!="null"? newCorrective.QHSEEngineer:null;
					//orgCorrective.userID = newCorrective.userID;
					orgCorrective.FormStatus = newCorrective.FormStatus;

					CorrectiveActionRepo.update(orgCorrective);

					var oldCorrectiveObservation = CorrectiveAndObservationRepo.getall().Where(o => o.CorrectiveActionId == id).ToList();
					if (newCorrective.CorrectiveObservation.Count()== oldCorrectiveObservation.Count())
					{
						for (int i = 0; i < oldCorrectiveObservation.Count(); i++)
						{
							var OldItem = oldCorrectiveObservation[i];
							var newItem = newCorrective.CorrectiveObservation[i];

							OldItem.CorrectiveObservationId = newItem;
							CorrectiveAndObservationRepo.update(OldItem);
						}
					}
					else
					{
						foreach(var item in oldCorrectiveObservation)
						{
							CorrectiveAndObservationRepo.delete(item);
						}
						foreach (var item in newCorrective.CorrectiveObservation)
						{
							CorrectiveAndObservation correctiveAndObservation = new CorrectiveAndObservation();

							correctiveAndObservation.CorrectiveActionId = orgCorrective.Id;
							correctiveAndObservation.CorrectiveObservationId = item;
							CorrectiveAndObservationRepo.create(correctiveAndObservation);
						}
					}

					var OldRootCauses = CorrectiveAndRootCausesRepo.getall().Where(r => r.CorrectiveActionId == id).ToList();
					if (newCorrective.RootCauses.Count() == OldRootCauses.Count())
					{
						for (int i = 0; i < OldRootCauses.Count(); i++)
						{
							var OldItem = OldRootCauses[i];
							var newItem = newCorrective.RootCauses[i];

							OldItem.RootCausesId = newItem;
							CorrectiveAndRootCausesRepo.update(OldItem);
						}
					}
					else
					{
						foreach (var item in OldRootCauses)
						{
							CorrectiveAndRootCausesRepo.delete(item);
						}
						foreach (var item in newCorrective.RootCauses)
						{
							CorrectiveAndRootCauses correctiveAndRootCauses = new CorrectiveAndRootCauses();

							correctiveAndRootCauses.CorrectiveActionId = orgCorrective.Id;
							correctiveAndRootCauses.RootCausesId = item;
							CorrectiveAndRootCausesRepo.create(correctiveAndRootCauses);
						}
					}

					var oldDatatables = CorrectiveDataTableRepo.getall().Where(d => d.CorrectiveActionId == id).ToList();
					foreach (var item in oldDatatables)
					{
						CorrectiveDataTableRepo.delete(item);
					}

					if (!string.IsNullOrEmpty(newCorrective.Action1)&& !string.IsNullOrEmpty(newCorrective.CorrectiveActionSelected1) && (newCorrective.SN1.HasValue && newCorrective.SN1 != 0) && !string.IsNullOrEmpty(newCorrective.Responsible1) && !string.IsNullOrEmpty(newCorrective.FollowUpAudit1) && (newCorrective.SuggestedDate1.HasValue && newCorrective.SuggestedDate1.Value != DateTime.Parse("1970-01-01")) && (newCorrective.SuggestedDate1.HasValue && newCorrective.SuggestedDate1.Value != DateTime.Parse("1970-01-01")))
					{
						CorrectiveDataTable correctiveDataTable = new CorrectiveDataTable();
						correctiveDataTable.SN = newCorrective.SN1;
						correctiveDataTable.CorrectiveActionSelected = newCorrective.CorrectiveActionSelected1;
						correctiveDataTable.Action = newCorrective.Action1;
						correctiveDataTable.Responsible = newCorrective.Responsible1;
						correctiveDataTable.SuggestedDate = newCorrective.SuggestedDate1;
						correctiveDataTable.AchievementDate = newCorrective.AchievementDate1;
						correctiveDataTable.FollowUpAudit = newCorrective.FollowUpAudit1!="null"? newCorrective.FollowUpAudit1:null;
						correctiveDataTable.Status = newCorrective.Status1;
						correctiveDataTable.CorrectiveActionId = orgCorrective.Id;
						CorrectiveDataTableRepo.create(correctiveDataTable);
					}

					if (!string.IsNullOrEmpty(newCorrective.Action2) && !string.IsNullOrEmpty(newCorrective.CorrectiveActionSelected2) && (newCorrective.SN2.HasValue && newCorrective.SN2 != 0) && !string.IsNullOrEmpty(newCorrective.Responsible2) && !string.IsNullOrEmpty(newCorrective.FollowUpAudit2) && (newCorrective.SuggestedDate2.HasValue && newCorrective.SuggestedDate2.Value != DateTime.Parse("1970-01-01")) && (newCorrective.SuggestedDate2.HasValue && newCorrective.SuggestedDate2.Value != DateTime.Parse("1970-01-01")))
					{
						CorrectiveDataTable correctiveDataTable = new CorrectiveDataTable();
						correctiveDataTable.SN = newCorrective.SN2;
						correctiveDataTable.CorrectiveActionSelected = newCorrective.CorrectiveActionSelected2;
						correctiveDataTable.Action = newCorrective.Action2;
						correctiveDataTable.Responsible = newCorrective.Responsible2;
						correctiveDataTable.SuggestedDate = newCorrective.SuggestedDate2;
						correctiveDataTable.AchievementDate = newCorrective.AchievementDate2;
						correctiveDataTable.FollowUpAudit = newCorrective.FollowUpAudit2 != "null" ? newCorrective.FollowUpAudit2 : null;
						correctiveDataTable.Status = newCorrective.Status2;
						correctiveDataTable.CorrectiveActionId = orgCorrective.Id;
						CorrectiveDataTableRepo.create(correctiveDataTable);
					}

					if (!string.IsNullOrEmpty(newCorrective.Action3) && !string.IsNullOrEmpty(newCorrective.CorrectiveActionSelected3) && (newCorrective.SN3.HasValue && newCorrective.SN3 != 0) && !string.IsNullOrEmpty(newCorrective.Responsible3) && !string.IsNullOrEmpty(newCorrective.FollowUpAudit3) && (newCorrective.SuggestedDate3.HasValue && newCorrective.SuggestedDate3.Value != DateTime.Parse("1970-01-01")) && (newCorrective.SuggestedDate3.HasValue && newCorrective.SuggestedDate3.Value != DateTime.Parse("1970-01-01")))
					{
						CorrectiveDataTable correctiveDataTable = new CorrectiveDataTable();
						correctiveDataTable.SN = newCorrective.SN3;
						correctiveDataTable.CorrectiveActionSelected = newCorrective.CorrectiveActionSelected3;
						correctiveDataTable.Action = newCorrective.Action3;
						correctiveDataTable.Responsible = newCorrective.Responsible3;
						correctiveDataTable.SuggestedDate = newCorrective.SuggestedDate3;
						correctiveDataTable.AchievementDate = newCorrective.AchievementDate3;
						correctiveDataTable.FollowUpAudit = newCorrective.FollowUpAudit3!="null"? newCorrective.FollowUpAudit3:null;
						correctiveDataTable.Status = newCorrective.Status3;
						correctiveDataTable.CorrectiveActionId = orgCorrective.Id;
						CorrectiveDataTableRepo.create(correctiveDataTable);
					}

					if (!string.IsNullOrEmpty(newCorrective.Action4) && !string.IsNullOrEmpty(newCorrective.CorrectiveActionSelected4) && (newCorrective.SN4.HasValue && newCorrective.SN4 != 0) && !string.IsNullOrEmpty(newCorrective.Responsible4) && !string.IsNullOrEmpty(newCorrective.FollowUpAudit4) && (newCorrective.SuggestedDate4.HasValue && newCorrective.SuggestedDate4.Value != DateTime.Parse("1970-01-01")) && (newCorrective.SuggestedDate4.HasValue && newCorrective.SuggestedDate4.Value != DateTime.Parse("1970-01-01")))
					{
						CorrectiveDataTable correctiveDataTable = new CorrectiveDataTable();
						correctiveDataTable.SN = newCorrective.SN4;
						correctiveDataTable.CorrectiveActionSelected = newCorrective.CorrectiveActionSelected4;
						correctiveDataTable.Action = newCorrective.Action4;
						correctiveDataTable.Responsible = newCorrective.Responsible4;
						correctiveDataTable.SuggestedDate = newCorrective.SuggestedDate4;
						correctiveDataTable.AchievementDate = newCorrective.AchievementDate4;
						correctiveDataTable.FollowUpAudit = newCorrective.FollowUpAudit4!="null"? newCorrective.FollowUpAudit4:null;
						correctiveDataTable.Status = newCorrective.Status4;
						correctiveDataTable.CorrectiveActionId = orgCorrective.Id;
						CorrectiveDataTableRepo.create(correctiveDataTable);
					}

					var oldImages = CorrectiveImagesRepo.getall().Where(i => i.CorrectiveActionId == id).ToList();
					if (newCorrective.Images != null)
					{
						if (newCorrective.Images.Count() == oldImages.Count())
						{
							for (int i = 0; i < oldImages.Count(); i++)
							{
								var OldItem = oldImages[i];
								var newItem = newCorrective.Images[i];

								OldItem.FileName = ImagesHelper.uploadImg(newItem, "CorrectiveIMG");
								CorrectiveImagesRepo.update(OldItem);
							}
						}
						else
						{
							foreach (var item in oldImages)
							{
								CorrectiveImagesRepo.delete(item);
							}
							foreach (var item in newCorrective?.Images)
							{
								CorrectiveImages correctiveImages = new CorrectiveImages();
								correctiveImages.FileName = ImagesHelper.uploadImg(item, "CorrectiveIMG");
								correctiveImages.CorrectiveActionId = orgCorrective.Id;
								CorrectiveImagesRepo.create(correctiveImages);
							}
						}
					}
					

					//CorrectiveActionRepo.update(orgCorrective);
					result.Data = orgCorrective;
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
				List<CorrectiveImages> correctiveImages = CorrectiveImagesRepo.getall().Where(p => p.CorrectiveActionId == id).ToList();
				foreach (var item in correctiveImages)
				{
					CorrectiveImages correctiveImage = CorrectiveImagesRepo.getbyid(item.Id);
					DeleteImagesHelper.DeleteImage(correctiveImage.FileName, "CorrectiveIMG");

					correctiveImage.IsDeleted = true;

					CorrectiveImagesRepo.update(correctiveImage);
				}

				List<CorrectiveDataTable> dataTables=CorrectiveDataTableRepo.getall().Where(p=>p.CorrectiveActionId==id).ToList();
				foreach (var item in dataTables)
				{
					CorrectiveDataTable correctiveDataTable = CorrectiveDataTableRepo.getbyid(item.Id);

					correctiveDataTable.IsDeleted = true;

					CorrectiveDataTableRepo.update(correctiveDataTable);
				}

				List<CorrectiveAndObservation> correctiveAndObservations = CorrectiveAndObservationRepo.getall().Where(p => p.CorrectiveActionId == id).ToList();
				foreach (var item in correctiveAndObservations)
				{
					CorrectiveAndObservation correctiveAndObservation = CorrectiveAndObservationRepo.getbyid(item.Id);

					correctiveAndObservation.IsDeleted = true;

					CorrectiveAndObservationRepo.update(correctiveAndObservation);
				}

				List<CorrectiveAndRootCauses> correctiveAndRootCauses = CorrectiveAndRootCausesRepo.getall().Where(p => p.CorrectiveActionId == id).ToList();
				foreach (var item in correctiveAndRootCauses)
				{
					CorrectiveAndRootCauses correctiveAndRootCause = CorrectiveAndRootCausesRepo.getbyid(item.Id);

					correctiveAndRootCause.IsDeleted = true;

					CorrectiveAndRootCausesRepo.update(correctiveAndRootCause);
				}

				CorrectiveAction corrective = CorrectiveActionRepo.getbyid(id);
				corrective.IsDeleted = true;
				CorrectiveActionRepo.update(corrective);

				result.Data = corrective;
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
	}
}
