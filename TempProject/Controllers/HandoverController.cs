using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;
using TempProject.DTO.ResponseDTO;
using NuGet.Configuration;
using TempProject.Helper;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HandoverController : ControllerBase
	{
		public IRepository<Handover> HandoverRepo;

		public IHandoverRepository HandoverRepoistory;

		private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager;

		public IRepository<ShiftDrillTypes> ShiftDrillTypesRepo;

		public IRepository<Visits> VisitsRepo;

		public IRepository<HSEInventory> HSEInventoryRepo;

		public IRepository<HSEEquipment> HSEEquipmentRepo;

		public IRepository<MaterialRequested> MaterialRequestedRepo;


		public HandoverController(IRepository<Handover> _HandoverRepo,
			IRepository<ShiftDrillTypes> _ShiftDrillTypesRepo,
			IRepository<Visits> _VisitsRepo,
			IRepository<HSEInventory> _HSEInventoryRepo,
			IRepository<HSEEquipment> _HSEEquipmentRepo,
			IRepository<MaterialRequested> _MaterialRequestedRepo,
			Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager,
			IHandoverRepository _HandoverRepoistory)
		{
			this.HandoverRepo = _HandoverRepo;
			this.ShiftDrillTypesRepo = _ShiftDrillTypesRepo;
			this.userManager = _userManager;
			this.VisitsRepo = _VisitsRepo;
			this.HSEInventoryRepo = _HSEInventoryRepo;
			this.HSEEquipmentRepo = _HSEEquipmentRepo;
			this.MaterialRequestedRepo = _MaterialRequestedRepo;
			this.HandoverRepoistory = _HandoverRepoistory;
		}

		[HttpGet("GetData")]
		public async Task<ResultDTO> GetAllWithData(string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<Handover> temp = HandoverRepoistory.getall();
					List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
					foreach (Handover Handover in temp)
					{
						HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
						HandoverDTO.Id = Handover.Id;
						HandoverDTO.RigNo = Handover.Rig.Number;
						HandoverDTO.ShiftDateFrom = Handover.ShiftDateFrom;
						HandoverDTO.ShiftDateTo = Handover.ShiftDateTo;
						HandoverDTO.WellName = Handover.WellName;
						HandoverDTO.Client = Handover.Client;
						HandoverDTO.LeavingEmpCode = Handover.LeavingEmpCode;
						HandoverDTO.LeavingEmpName = Handover.LeavingEmpName;
						HandoverDTO.ComingEmpCode = Handover.ComingEmpCode;
						HandoverDTO.ComingEmpName = Handover.ComingEmpName;
						HandoverDTO.StopCards = Handover.StopCards;
						HandoverDTO.MonthlyStopCards = Handover.MonthlyStopCards;
						HandoverDTO.OpenStopCards = Handover.OpenStopCards;
						HandoverDTO.Drills = Handover.Drills;
						HandoverDTO.MonthlyDrills = Handover.MonthlyDrills;
						HandoverDTO.SafetyAlerts = Handover.SafetyAlerts;
						HandoverDTO.MonthlySafetyAlerts = Handover.MonthlySafetyAlerts;
						HandoverDTO.WeeklyInspection = Handover.WeeklyInspection;
						HandoverDTO.InternalAudit = Handover.InternalAudit;
						HandoverDTO.ExternalAudit = Handover.ExternalAudit;
						HandoverDTO.MedicalReport = Handover.MedicalReport;
						HandoverDTO.TrainingMatrix = Handover.TrainingMatrix;
						HandoverDTO.RigMove = Handover.RigMove;
						HandoverDTO.IncidentReport = Handover.IncidentReport;
						HandoverDTO.TrackingSheetClosedPoints = Handover.TrackingSheetClosedPoints;
						HandoverDTO.ShiftBrief = Handover.ShiftBrief;
						HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
						HandoverDTO.userName = Handover.user.UserName;
						HandoverDTO.PotentialHazardReport = Handover.PotentialHazardReport;
						if (Handover.ShiftDrillTypes.Any())
						{
							foreach (var item in Handover.ShiftDrillTypes)
							{
								ShiftDrillTypesDTO shiftDrillTypesDTO = new ShiftDrillTypesDTO();
								shiftDrillTypesDTO.Id = item.Id;
								shiftDrillTypesDTO.Date = item.Date;
								shiftDrillTypesDTO.DrillType = item.DrillType;
								shiftDrillTypesDTO.HandoverId = item.HandoverId;
								shiftDrillTypesDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.ShiftDrillTypes.Add(shiftDrillTypesDTO);
							}
						}
						if (Handover.Visits.Any())
						{
							foreach (var item in Handover.Visits)
							{
								VisitsDTO visitsDTO = new VisitsDTO();
								visitsDTO.Id = item.Id;
								visitsDTO.Date = item.Date;
								visitsDTO.VisitName = item.VisitName;
								visitsDTO.HandoverId = item.HandoverId;
								visitsDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.Visits.Add(visitsDTO);
							}
						}
						foreach (var item in Handover.HSEInventory)
						{
							HSEInventoryDTO hseInventoryDTO = new HSEInventoryDTO();
							hseInventoryDTO.Id = item.Id;
							hseInventoryDTO.Item = item.Item;
							hseInventoryDTO.StockAtStorage = item.StockAtStorage;
							hseInventoryDTO.ReleasedFromStorage = item.ReleasedFromStorage;
							hseInventoryDTO.NewlyRecieved = item.NewlyRecieved;
							hseInventoryDTO.HandoverId = item.HandoverId;
							hseInventoryDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.HSEInventory.Add(hseInventoryDTO);
						}
						foreach (var item in Handover.HSEEquipment)
						{
							HSEEquipmentDTO hseEquipmentDTO = new HSEEquipmentDTO();
							hseEquipmentDTO.Id = item.Id;
							hseEquipmentDTO.Item = item.Item;
							hseEquipmentDTO.OnSite = item.OnSite;
							hseEquipmentDTO.SentForMaintenance = item.SentForMaintenance;
							hseEquipmentDTO.HandoverId = item.HandoverId;
							hseEquipmentDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.HSEEquipment.Add(hseEquipmentDTO);
						}
						if (Handover.MaterialRequested.Any())
						{
							foreach (var item in Handover.MaterialRequested)
							{
								MaterialRequestedDTO materialRequestedDTO = new MaterialRequestedDTO();
								materialRequestedDTO.Id = item.Id;
								materialRequestedDTO.PR = item.PR;
								materialRequestedDTO.RequiredItem = item.RequiredItem;
								materialRequestedDTO.HandoverId = item.HandoverId;
								materialRequestedDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.MaterialRequested.Add(materialRequestedDTO);
							}
						}
						newTemp.Add(HandoverDTO);
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
					List<Handover> temp = HandoverRepoistory.getall().Where(a => a.user.Id == UserID).ToList();
					List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
					foreach (Handover Handover in temp)
					{
						HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
						HandoverDTO.Id = Handover.Id;
						HandoverDTO.RigNo = Handover.Rig.Number;
						HandoverDTO.ShiftDateFrom = Handover.ShiftDateFrom;
						HandoverDTO.ShiftDateTo = Handover.ShiftDateTo;
						HandoverDTO.WellName = Handover.WellName;
						HandoverDTO.Client = Handover.Client;
						HandoverDTO.LeavingEmpCode = Handover.LeavingEmpCode;
						HandoverDTO.LeavingEmpName = Handover.LeavingEmpName;
						HandoverDTO.ComingEmpCode = Handover.ComingEmpCode;
						HandoverDTO.ComingEmpName = Handover.ComingEmpName;
						HandoverDTO.StopCards = Handover.StopCards;
						HandoverDTO.MonthlyStopCards = Handover.MonthlyStopCards;
						HandoverDTO.OpenStopCards = Handover.OpenStopCards;
						HandoverDTO.Drills = Handover.Drills;
						HandoverDTO.MonthlyDrills = Handover.MonthlyDrills;
						HandoverDTO.SafetyAlerts = Handover.SafetyAlerts;
						HandoverDTO.MonthlySafetyAlerts = Handover.MonthlySafetyAlerts;
						HandoverDTO.WeeklyInspection = Handover.WeeklyInspection;
						HandoverDTO.InternalAudit = Handover.InternalAudit;
						HandoverDTO.ExternalAudit = Handover.ExternalAudit;
						HandoverDTO.MedicalReport = Handover.MedicalReport;
						HandoverDTO.TrainingMatrix = Handover.TrainingMatrix;
						HandoverDTO.RigMove = Handover.RigMove;
						HandoverDTO.IncidentReport = Handover.IncidentReport;
						HandoverDTO.TrackingSheetClosedPoints = Handover.TrackingSheetClosedPoints;
						HandoverDTO.ShiftBrief = Handover.ShiftBrief;
						HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
						HandoverDTO.userName = Handover.user.UserName;
						HandoverDTO.PotentialHazardReport = Handover.PotentialHazardReport;
						if (Handover.ShiftDrillTypes.Any())
						{
							foreach (var item in Handover.ShiftDrillTypes)
							{
								ShiftDrillTypesDTO shiftDrillTypesDTO = new ShiftDrillTypesDTO();
								shiftDrillTypesDTO.Id = item.Id;
								shiftDrillTypesDTO.Date = item.Date;
								shiftDrillTypesDTO.DrillType = item.DrillType;
								shiftDrillTypesDTO.HandoverId = item.HandoverId;
								shiftDrillTypesDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.ShiftDrillTypes.Add(shiftDrillTypesDTO);
							}
						}
						if (Handover.Visits.Any())
						{
							foreach (var item in Handover.Visits)
							{
								VisitsDTO visitsDTO = new VisitsDTO();
								visitsDTO.Id = item.Id;
								visitsDTO.Date = item.Date;
								visitsDTO.VisitName = item.VisitName;
								visitsDTO.HandoverId = item.HandoverId;
								visitsDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.Visits.Add(visitsDTO);
							}
						}
						foreach (var item in Handover.HSEInventory)
						{
							HSEInventoryDTO hseInventoryDTO = new HSEInventoryDTO();
							hseInventoryDTO.Id = item.Id;
							hseInventoryDTO.Item = item.Item;
							hseInventoryDTO.StockAtStorage = item.StockAtStorage;
							hseInventoryDTO.ReleasedFromStorage = item.ReleasedFromStorage;
							hseInventoryDTO.NewlyRecieved = item.NewlyRecieved;
							hseInventoryDTO.HandoverId = item.HandoverId;
							hseInventoryDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.HSEInventory.Add(hseInventoryDTO);
						}
						foreach (var item in Handover.HSEEquipment)
						{
							HSEEquipmentDTO hseEquipmentDTO = new HSEEquipmentDTO();
							hseEquipmentDTO.Id = item.Id;
							hseEquipmentDTO.Item = item.Item;
							hseEquipmentDTO.OnSite = item.OnSite;
							hseEquipmentDTO.SentForMaintenance = item.SentForMaintenance;
							hseEquipmentDTO.HandoverId = item.HandoverId;
							hseEquipmentDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.HSEEquipment.Add(hseEquipmentDTO);
						}
						if (Handover.MaterialRequested.Any())
						{
							foreach (var item in Handover.MaterialRequested)
							{
								MaterialRequestedDTO materialRequestedDTO = new MaterialRequestedDTO();
								materialRequestedDTO.Id = item.Id;
								materialRequestedDTO.PR = item.PR;
								materialRequestedDTO.RequiredItem = item.RequiredItem;
								materialRequestedDTO.HandoverId = item.HandoverId;
								materialRequestedDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.MaterialRequested.Add(materialRequestedDTO);
							}
						}
						newTemp.Add(HandoverDTO);
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


		//[HttpGet("GetDataForPrint")]
		//public async Task<ResultDTO> GetAllWithDataForPrint(int RigNo, DateTime date, string UserID, string UserRole)
		//{
		//	ResultDTO result = new ResultDTO();

		//	try
		//	{
		//		if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
		//		{
		//			List<Handover> temp = HandoverRepoistory.getall().Where(w => w.Date == date && w.Rig.Number == RigNo).ToList();
		//			List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
		//			foreach (Handover Handover in temp)
		//			{
		//				HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
		//				HandoverDTO.Id = default;
		//				HandoverDTO.RigNo = Handover.Rig.Number;
		//				HandoverDTO.Date = Handover.Date;
		//				HandoverDTO.HandoverNo = Handover.HandoverNo;
		//				HandoverDTO.MedicalReportNo = Handover.MedicalReportNo;
		//				HandoverDTO.LastFirstAidDrillNo = Handover.LastFirstAidDrillNo;
		//				HandoverDTO.HealthMeetingNo = Handover.HealthMeetingNo;
		//				HandoverDTO.Topics = Handover.Topics;
		//				HandoverDTO.HealthStatus = Handover.HealthStatus;
		//				HandoverDTO.HealthStatusComment = Handover.HealthStatusComment;
		//				HandoverDTO.LifeSavingApparatuses = Handover.LifeSavingApparatuses;
		//				HandoverDTO.LifeSavingApparatusesComment = Handover.LifeSavingApparatusesComment;
		//				HandoverDTO.VaccinesAvailable = Handover.VaccinesAvailable;
		//				HandoverDTO.VaccinesAvailableComment = Handover.VaccinesAvailableComment;
		//				HandoverDTO.ERP = Handover.ERP;
		//				HandoverDTO.ERPComment = Handover.ERPComment;
		//				HandoverDTO.MedicalStretcher = Handover.MedicalStretcher;
		//				HandoverDTO.MedicalStretcherComment = Handover.MedicalStretcherComment;
		//				HandoverDTO.WaterTest = Handover.WaterTest;
		//				HandoverDTO.WaterTestComment = Handover.WaterTestComment;
		//				HandoverDTO.BloodSugar = Handover.BloodSugar;
		//				HandoverDTO.BloodSugarComment = Handover.BloodSugarComment;
		//				HandoverDTO.FirstAidBox = Handover.FirstAidBox;
		//				HandoverDTO.FirstAidBoxComment = Handover.FirstAidBoxComment;
		//				HandoverDTO.FullO2Cylinder = Handover.FullO2Cylinder;
		//				HandoverDTO.FullO2CylinderComment = Handover.FullO2CylinderComment;
		//				HandoverDTO.MedicalWaste = Handover.MedicalWaste;
		//				HandoverDTO.MedicalWasteComment = Handover.MedicalWasteComment;
		//				HandoverDTO.MedicinesExpiryDate = Handover.MedicinesExpiryDate;
		//				HandoverDTO.MedicinesExpiryDateComment = Handover.MedicinesExpiryDateComment;
		//				HandoverDTO.OtherComments = Handover.OtherComments;
		//				HandoverDTO.DoctorName = Handover.DoctorName;
		//				HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
		//				HandoverDTO.userName = Handover.user.UserName;
		//				foreach (var item in Handover.FridgeComponents)
		//				{
		//					FridgeComponentDTO fridgeComponentDTO = new FridgeComponentDTO();
		//					fridgeComponentDTO.Id = item.Id;
		//					fridgeComponentDTO.Item = item.Item;
		//					fridgeComponentDTO.Quantity = item.Quantity;
		//					fridgeComponentDTO.ExpireDate = item.ExpireDate;
		//					fridgeComponentDTO.HandoverId = item.HandoverId;
		//					fridgeComponentDTO.IsDeleted = item.IsDeleted;
		//					HandoverDTO.FridgeComponents.Add(fridgeComponentDTO);
		//				}
		//				foreach (var item in Handover.DrugInventory)
		//				{
		//					DrugInventoryDTO drugInventoryDTO = new DrugInventoryDTO();
		//					drugInventoryDTO.Id = item.Id;
		//					drugInventoryDTO.Item = item.Item;
		//					drugInventoryDTO.Quantity = item.Quantity;
		//					drugInventoryDTO.ExpireDate = item.ExpireDate;
		//					drugInventoryDTO.HandoverId = item.HandoverId;
		//					drugInventoryDTO.IsDeleted = item.IsDeleted;
		//					HandoverDTO.DrugInventory.Add(drugInventoryDTO);
		//				}

		//				newTemp.Add(HandoverDTO);
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
		//			List<Handover> temp = HandoverRepoistory.getall().Where(a => a.user.Id == UserID && a.Date == date && a.Rig.Number == RigNo).ToList();
		//			List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
		//			foreach (Handover Handover in temp)
		//			{
		//				HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
		//				HandoverDTO.Id = default;
		//				HandoverDTO.RigNo = Handover.Rig.Number;
		//				HandoverDTO.Date = Handover.Date;
		//				HandoverDTO.HandoverNo = Handover.HandoverNo;
		//				HandoverDTO.MedicalReportNo = Handover.MedicalReportNo;
		//				HandoverDTO.LastFirstAidDrillNo = Handover.LastFirstAidDrillNo;
		//				HandoverDTO.HealthMeetingNo = Handover.HealthMeetingNo;
		//				HandoverDTO.Topics = Handover.Topics;
		//				HandoverDTO.HealthStatus = Handover.HealthStatus;
		//				HandoverDTO.HealthStatusComment = Handover.HealthStatusComment;
		//				HandoverDTO.LifeSavingApparatuses = Handover.LifeSavingApparatuses;
		//				HandoverDTO.LifeSavingApparatusesComment = Handover.LifeSavingApparatusesComment;
		//				HandoverDTO.VaccinesAvailable = Handover.VaccinesAvailable;
		//				HandoverDTO.VaccinesAvailableComment = Handover.VaccinesAvailableComment;
		//				HandoverDTO.ERP = Handover.ERP;
		//				HandoverDTO.ERPComment = Handover.ERPComment;
		//				HandoverDTO.MedicalStretcher = Handover.MedicalStretcher;
		//				HandoverDTO.MedicalStretcherComment = Handover.MedicalStretcherComment;
		//				HandoverDTO.WaterTest = Handover.WaterTest;
		//				HandoverDTO.WaterTestComment = Handover.WaterTestComment;
		//				HandoverDTO.BloodSugar = Handover.BloodSugar;
		//				HandoverDTO.BloodSugarComment = Handover.BloodSugarComment;
		//				HandoverDTO.FirstAidBox = Handover.FirstAidBox;
		//				HandoverDTO.FirstAidBoxComment = Handover.FirstAidBoxComment;
		//				HandoverDTO.FullO2Cylinder = Handover.FullO2Cylinder;
		//				HandoverDTO.FullO2CylinderComment = Handover.FullO2CylinderComment;
		//				HandoverDTO.MedicalWaste = Handover.MedicalWaste;
		//				HandoverDTO.MedicalWasteComment = Handover.MedicalWasteComment;
		//				HandoverDTO.MedicinesExpiryDate = Handover.MedicinesExpiryDate;
		//				HandoverDTO.MedicinesExpiryDateComment = Handover.MedicinesExpiryDateComment;
		//				HandoverDTO.OtherComments = Handover.OtherComments;
		//				HandoverDTO.DoctorName = Handover.DoctorName;
		//				HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
		//				HandoverDTO.userName = Handover.user.UserName;
		//				foreach (var item in Handover.FridgeComponents)
		//				{
		//					FridgeComponentDTO fridgeComponentDTO = new FridgeComponentDTO();
		//					fridgeComponentDTO.Id = item.Id;
		//					fridgeComponentDTO.Item = item.Item;
		//					fridgeComponentDTO.Quantity = item.Quantity;
		//					fridgeComponentDTO.ExpireDate = item.ExpireDate;
		//					fridgeComponentDTO.HandoverId = item.HandoverId;
		//					fridgeComponentDTO.IsDeleted = item.IsDeleted;
		//					HandoverDTO.FridgeComponents.Add(fridgeComponentDTO);
		//				}
		//				foreach (var item in Handover.DrugInventory)
		//				{
		//					DrugInventoryDTO drugInventoryDTO = new DrugInventoryDTO();
		//					drugInventoryDTO.Id = item.Id;
		//					drugInventoryDTO.Item = item.Item;
		//					drugInventoryDTO.Quantity = item.Quantity;
		//					drugInventoryDTO.ExpireDate = item.ExpireDate;
		//					drugInventoryDTO.HandoverId = item.HandoverId;
		//					drugInventoryDTO.IsDeleted = item.IsDeleted;
		//					HandoverDTO.DrugInventory.Add(drugInventoryDTO);
		//				}

		//				newTemp.Add(HandoverDTO);
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

		[HttpGet("GetDataForAnalysis")]
		public async Task<ResultDTO> GetDataForAnalysis(int RigId, string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<Handover> temp = HandoverRepoistory.getall().Where(w => w.RigId == RigId).ToList();
					List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
					foreach (Handover Handover in temp)
					{
						HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
						HandoverDTO.Id = Handover.Id;
						HandoverDTO.RigNo = Handover.Rig.Number;
						HandoverDTO.ShiftDateFrom = Handover.ShiftDateFrom;
						HandoverDTO.ShiftDateTo = Handover.ShiftDateTo;
						HandoverDTO.WellName = Handover.WellName;
						HandoverDTO.Client = Handover.Client;
						HandoverDTO.LeavingEmpCode = Handover.LeavingEmpCode;
						HandoverDTO.LeavingEmpName = Handover.LeavingEmpName;
						HandoverDTO.ComingEmpCode = Handover.ComingEmpCode;
						HandoverDTO.ComingEmpName = Handover.ComingEmpName;
						HandoverDTO.StopCards = Handover.StopCards;
						HandoverDTO.MonthlyStopCards = Handover.MonthlyStopCards;
						HandoverDTO.OpenStopCards = Handover.OpenStopCards;
						HandoverDTO.Drills = Handover.Drills;
						HandoverDTO.MonthlyDrills = Handover.MonthlyDrills;
						HandoverDTO.SafetyAlerts = Handover.SafetyAlerts;
						HandoverDTO.MonthlySafetyAlerts = Handover.MonthlySafetyAlerts;
						HandoverDTO.WeeklyInspection = Handover.WeeklyInspection;
						HandoverDTO.InternalAudit = Handover.InternalAudit;
						HandoverDTO.ExternalAudit = Handover.ExternalAudit;
						HandoverDTO.MedicalReport = Handover.MedicalReport;
						HandoverDTO.TrainingMatrix = Handover.TrainingMatrix;
						HandoverDTO.RigMove = Handover.RigMove;
						HandoverDTO.IncidentReport = Handover.IncidentReport;
						HandoverDTO.TrackingSheetClosedPoints = Handover.TrackingSheetClosedPoints;
						HandoverDTO.ShiftBrief = Handover.ShiftBrief;
						HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
						HandoverDTO.userName = Handover.user.UserName;
						HandoverDTO.PotentialHazardReport = Handover.PotentialHazardReport;
						if (Handover.ShiftDrillTypes.Any())
						{
							foreach (var item in Handover.ShiftDrillTypes)
							{
								ShiftDrillTypesDTO shiftDrillTypesDTO = new ShiftDrillTypesDTO();
								shiftDrillTypesDTO.Id = item.Id;
								shiftDrillTypesDTO.Date = item.Date;
								shiftDrillTypesDTO.DrillType = item.DrillType;
								shiftDrillTypesDTO.HandoverId = item.HandoverId;
								shiftDrillTypesDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.ShiftDrillTypes.Add(shiftDrillTypesDTO);
							}
						}
						if (Handover.Visits.Any())
						{
							foreach (var item in Handover.Visits)
							{
								VisitsDTO visitsDTO = new VisitsDTO();
								visitsDTO.Id = item.Id;
								visitsDTO.Date = item.Date;
								visitsDTO.VisitName = item.VisitName;
								visitsDTO.HandoverId = item.HandoverId;
								visitsDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.Visits.Add(visitsDTO);
							}
						}
						foreach (var item in Handover.HSEInventory)
						{
							HSEInventoryDTO hseInventoryDTO = new HSEInventoryDTO();
							hseInventoryDTO.Id = item.Id;
							hseInventoryDTO.Item = item.Item;
							hseInventoryDTO.StockAtStorage = item.StockAtStorage;
							hseInventoryDTO.ReleasedFromStorage = item.ReleasedFromStorage;
							hseInventoryDTO.NewlyRecieved = item.NewlyRecieved;
							hseInventoryDTO.HandoverId = item.HandoverId;
							hseInventoryDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.HSEInventory.Add(hseInventoryDTO);
						}
						foreach (var item in Handover.HSEEquipment)
						{
							HSEEquipmentDTO hseEquipmentDTO = new HSEEquipmentDTO();
							hseEquipmentDTO.Id = item.Id;
							hseEquipmentDTO.Item = item.Item;
							hseEquipmentDTO.OnSite = item.OnSite;
							hseEquipmentDTO.SentForMaintenance = item.SentForMaintenance;
							hseEquipmentDTO.HandoverId = item.HandoverId;
							hseEquipmentDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.HSEEquipment.Add(hseEquipmentDTO);
						}
						if (Handover.MaterialRequested.Any())
						{
							foreach (var item in Handover.MaterialRequested)
							{
								MaterialRequestedDTO materialRequestedDTO = new MaterialRequestedDTO();
								materialRequestedDTO.Id = item.Id;
								materialRequestedDTO.PR = item.PR;
								materialRequestedDTO.RequiredItem = item.RequiredItem;
								materialRequestedDTO.HandoverId = item.HandoverId;
								materialRequestedDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.MaterialRequested.Add(materialRequestedDTO);
							}
						}
						newTemp.Add(HandoverDTO);
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
					List<Handover> temp = HandoverRepoistory.getall().Where(a => a.user.Id == UserID && a.RigId == RigId).ToList();
					List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
					foreach (Handover Handover in temp)
					{
						HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
						HandoverDTO.Id = Handover.Id;
						HandoverDTO.RigNo = Handover.Rig.Number;
						HandoverDTO.ShiftDateFrom = Handover.ShiftDateFrom;
						HandoverDTO.ShiftDateTo = Handover.ShiftDateTo;
						HandoverDTO.WellName = Handover.WellName;
						HandoverDTO.Client = Handover.Client;
						HandoverDTO.LeavingEmpCode = Handover.LeavingEmpCode;
						HandoverDTO.LeavingEmpName = Handover.LeavingEmpName;
						HandoverDTO.ComingEmpCode = Handover.ComingEmpCode;
						HandoverDTO.ComingEmpName = Handover.ComingEmpName;
						HandoverDTO.StopCards = Handover.StopCards;
						HandoverDTO.MonthlyStopCards = Handover.MonthlyStopCards;
						HandoverDTO.OpenStopCards = Handover.OpenStopCards;
						HandoverDTO.Drills = Handover.Drills;
						HandoverDTO.MonthlyDrills = Handover.MonthlyDrills;
						HandoverDTO.SafetyAlerts = Handover.SafetyAlerts;
						HandoverDTO.MonthlySafetyAlerts = Handover.MonthlySafetyAlerts;
						HandoverDTO.WeeklyInspection = Handover.WeeklyInspection;
						HandoverDTO.InternalAudit = Handover.InternalAudit;
						HandoverDTO.ExternalAudit = Handover.ExternalAudit;
						HandoverDTO.MedicalReport = Handover.MedicalReport;
						HandoverDTO.TrainingMatrix = Handover.TrainingMatrix;
						HandoverDTO.RigMove = Handover.RigMove;
						HandoverDTO.IncidentReport = Handover.IncidentReport;
						HandoverDTO.TrackingSheetClosedPoints = Handover.TrackingSheetClosedPoints;
						HandoverDTO.ShiftBrief = Handover.ShiftBrief;
						HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
						HandoverDTO.userName = Handover.user.UserName;
						HandoverDTO.PotentialHazardReport = Handover.PotentialHazardReport;
						if (Handover.ShiftDrillTypes.Any())
						{
							foreach (var item in Handover.ShiftDrillTypes)
							{
								ShiftDrillTypesDTO shiftDrillTypesDTO = new ShiftDrillTypesDTO();
								shiftDrillTypesDTO.Id = item.Id;
								shiftDrillTypesDTO.Date = item.Date;
								shiftDrillTypesDTO.DrillType = item.DrillType;
								shiftDrillTypesDTO.HandoverId = item.HandoverId;
								shiftDrillTypesDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.ShiftDrillTypes.Add(shiftDrillTypesDTO);
							}
						}
						if (Handover.Visits.Any())
						{
							foreach (var item in Handover.Visits)
							{
								VisitsDTO visitsDTO = new VisitsDTO();
								visitsDTO.Id = item.Id;
								visitsDTO.Date = item.Date;
								visitsDTO.VisitName = item.VisitName;
								visitsDTO.HandoverId = item.HandoverId;
								visitsDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.Visits.Add(visitsDTO);
							}
						}
						foreach (var item in Handover.HSEInventory)
						{
							HSEInventoryDTO hseInventoryDTO = new HSEInventoryDTO();
							hseInventoryDTO.Id = item.Id;
							hseInventoryDTO.Item = item.Item;
							hseInventoryDTO.StockAtStorage = item.StockAtStorage;
							hseInventoryDTO.ReleasedFromStorage = item.ReleasedFromStorage;
							hseInventoryDTO.NewlyRecieved = item.NewlyRecieved;
							hseInventoryDTO.HandoverId = item.HandoverId;
							hseInventoryDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.HSEInventory.Add(hseInventoryDTO);
						}
						foreach (var item in Handover.HSEEquipment)
						{
							HSEEquipmentDTO hseEquipmentDTO = new HSEEquipmentDTO();
							hseEquipmentDTO.Id = item.Id;
							hseEquipmentDTO.Item = item.Item;
							hseEquipmentDTO.OnSite = item.OnSite;
							hseEquipmentDTO.SentForMaintenance = item.SentForMaintenance;
							hseEquipmentDTO.HandoverId = item.HandoverId;
							hseEquipmentDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.HSEEquipment.Add(hseEquipmentDTO);
						}
						if (Handover.MaterialRequested.Any())
						{
							foreach (var item in Handover.MaterialRequested)
							{
								MaterialRequestedDTO materialRequestedDTO = new MaterialRequestedDTO();
								materialRequestedDTO.Id = item.Id;
								materialRequestedDTO.PR = item.PR;
								materialRequestedDTO.RequiredItem = item.RequiredItem;
								materialRequestedDTO.HandoverId = item.HandoverId;
								materialRequestedDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.MaterialRequested.Add(materialRequestedDTO);
							}
						}
						newTemp.Add(HandoverDTO);
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

		[HttpGet("GetDataForPrint")]
		public async Task<ResultDTO> GetDataForPrint(int RigNo,string engineer, string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<Handover> temp = HandoverRepoistory.getall().Where(w => w.Rig.Number == RigNo&&w.LeavingEmpName==engineer).ToList();
					List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
					foreach (Handover Handover in temp)
					{
						HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
						HandoverDTO.Id = Handover.Id;
						HandoverDTO.RigNo = Handover.Rig.Number;
						HandoverDTO.ShiftDateFrom = Handover.ShiftDateFrom;
						HandoverDTO.ShiftDateTo = Handover.ShiftDateTo;
						HandoverDTO.WellName = Handover.WellName;
						HandoverDTO.Client = Handover.Client;
						HandoverDTO.LeavingEmpCode = Handover.LeavingEmpCode;
						HandoverDTO.LeavingEmpName = Handover.LeavingEmpName;
						HandoverDTO.ComingEmpCode = Handover.ComingEmpCode;
						HandoverDTO.ComingEmpName = Handover.ComingEmpName;
						HandoverDTO.StopCards = Handover.StopCards;
						HandoverDTO.MonthlyStopCards = Handover.MonthlyStopCards;
						HandoverDTO.OpenStopCards = Handover.OpenStopCards;
						HandoverDTO.Drills = Handover.Drills;
						HandoverDTO.MonthlyDrills = Handover.MonthlyDrills;
						HandoverDTO.SafetyAlerts = Handover.SafetyAlerts;
						HandoverDTO.MonthlySafetyAlerts = Handover.MonthlySafetyAlerts;
						HandoverDTO.WeeklyInspection = Handover.WeeklyInspection;
						HandoverDTO.InternalAudit = Handover.InternalAudit;
						HandoverDTO.ExternalAudit = Handover.ExternalAudit;
						HandoverDTO.MedicalReport = Handover.MedicalReport;
						HandoverDTO.TrainingMatrix = Handover.TrainingMatrix;
						HandoverDTO.RigMove = Handover.RigMove;
						HandoverDTO.IncidentReport = Handover.IncidentReport;
						HandoverDTO.TrackingSheetClosedPoints = Handover.TrackingSheetClosedPoints;
						HandoverDTO.ShiftBrief = Handover.ShiftBrief;
						HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
						HandoverDTO.userName = Handover.user.UserName;
						HandoverDTO.PotentialHazardReport = Handover.PotentialHazardReport;
						if (Handover.ShiftDrillTypes.Any())
						{
							foreach (var item in Handover.ShiftDrillTypes)
							{
								ShiftDrillTypesDTO shiftDrillTypesDTO = new ShiftDrillTypesDTO();
								shiftDrillTypesDTO.Id = item.Id;
								shiftDrillTypesDTO.Date = item.Date;
								shiftDrillTypesDTO.DrillType = item.DrillType;
								shiftDrillTypesDTO.HandoverId = item.HandoverId;
								shiftDrillTypesDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.ShiftDrillTypes.Add(shiftDrillTypesDTO);
							}
						}
						if (Handover.Visits.Any())
						{
							foreach (var item in Handover.Visits)
							{
								VisitsDTO visitsDTO = new VisitsDTO();
								visitsDTO.Id = item.Id;
								visitsDTO.Date = item.Date;
								visitsDTO.VisitName = item.VisitName;
								visitsDTO.HandoverId = item.HandoverId;
								visitsDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.Visits.Add(visitsDTO);
							}
						}
						foreach (var item in Handover.HSEInventory)
						{
							HSEInventoryDTO hseInventoryDTO = new HSEInventoryDTO();
							hseInventoryDTO.Id = item.Id;
							hseInventoryDTO.Item = item.Item;
							hseInventoryDTO.StockAtStorage = item.StockAtStorage;
							hseInventoryDTO.ReleasedFromStorage = item.ReleasedFromStorage;
							hseInventoryDTO.NewlyRecieved = item.NewlyRecieved;
							hseInventoryDTO.HandoverId = item.HandoverId;
							hseInventoryDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.HSEInventory.Add(hseInventoryDTO);
						}
						foreach (var item in Handover.HSEEquipment)
						{
							HSEEquipmentDTO hseEquipmentDTO = new HSEEquipmentDTO();
							hseEquipmentDTO.Id = item.Id;
							hseEquipmentDTO.Item = item.Item;
							hseEquipmentDTO.OnSite = item.OnSite;
							hseEquipmentDTO.SentForMaintenance = item.SentForMaintenance;
							hseEquipmentDTO.HandoverId = item.HandoverId;
							hseEquipmentDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.HSEEquipment.Add(hseEquipmentDTO);
						}
						if (Handover.MaterialRequested.Any())
						{
							foreach (var item in Handover.MaterialRequested)
							{
								MaterialRequestedDTO materialRequestedDTO = new MaterialRequestedDTO();
								materialRequestedDTO.Id = item.Id;
								materialRequestedDTO.PR = item.PR;
								materialRequestedDTO.RequiredItem = item.RequiredItem;
								materialRequestedDTO.HandoverId = item.HandoverId;
								materialRequestedDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.MaterialRequested.Add(materialRequestedDTO);
							}
						}
						newTemp.Add(HandoverDTO);
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
					List<Handover> temp = HandoverRepoistory.getall().Where(a => a.user.Id == UserID && a.Rig.Number == RigNo && a.LeavingEmpName == engineer).ToList();
					List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
					foreach (Handover Handover in temp)
					{
						HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
						HandoverDTO.Id = Handover.Id;
						HandoverDTO.RigNo = Handover.Rig.Number;
						HandoverDTO.ShiftDateFrom = Handover.ShiftDateFrom;
						HandoverDTO.ShiftDateTo = Handover.ShiftDateTo;
						HandoverDTO.WellName = Handover.WellName;
						HandoverDTO.Client = Handover.Client;
						HandoverDTO.LeavingEmpCode = Handover.LeavingEmpCode;
						HandoverDTO.LeavingEmpName = Handover.LeavingEmpName;
						HandoverDTO.ComingEmpCode = Handover.ComingEmpCode;
						HandoverDTO.ComingEmpName = Handover.ComingEmpName;
						HandoverDTO.StopCards = Handover.StopCards;
						HandoverDTO.MonthlyStopCards = Handover.MonthlyStopCards;
						HandoverDTO.OpenStopCards = Handover.OpenStopCards;
						HandoverDTO.Drills = Handover.Drills;
						HandoverDTO.MonthlyDrills = Handover.MonthlyDrills;
						HandoverDTO.SafetyAlerts = Handover.SafetyAlerts;
						HandoverDTO.MonthlySafetyAlerts = Handover.MonthlySafetyAlerts;
						HandoverDTO.WeeklyInspection = Handover.WeeklyInspection;
						HandoverDTO.InternalAudit = Handover.InternalAudit;
						HandoverDTO.ExternalAudit = Handover.ExternalAudit;
						HandoverDTO.MedicalReport = Handover.MedicalReport;
						HandoverDTO.TrainingMatrix = Handover.TrainingMatrix;
						HandoverDTO.RigMove = Handover.RigMove;
						HandoverDTO.IncidentReport = Handover.IncidentReport;
						HandoverDTO.TrackingSheetClosedPoints = Handover.TrackingSheetClosedPoints;
						HandoverDTO.ShiftBrief = Handover.ShiftBrief;
						HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
						HandoverDTO.userName = Handover.user.UserName;
						HandoverDTO.PotentialHazardReport = Handover.PotentialHazardReport;
						if (Handover.ShiftDrillTypes.Any())
						{
							foreach (var item in Handover.ShiftDrillTypes)
							{
								ShiftDrillTypesDTO shiftDrillTypesDTO = new ShiftDrillTypesDTO();
								shiftDrillTypesDTO.Id = item.Id;
								shiftDrillTypesDTO.Date = item.Date;
								shiftDrillTypesDTO.DrillType = item.DrillType;
								shiftDrillTypesDTO.HandoverId = item.HandoverId;
								shiftDrillTypesDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.ShiftDrillTypes.Add(shiftDrillTypesDTO);
							}
						}
						if (Handover.Visits.Any())
						{
							foreach (var item in Handover.Visits)
							{
								VisitsDTO visitsDTO = new VisitsDTO();
								visitsDTO.Id = item.Id;
								visitsDTO.Date = item.Date;
								visitsDTO.VisitName = item.VisitName;
								visitsDTO.HandoverId = item.HandoverId;
								visitsDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.Visits.Add(visitsDTO);
							}
						}
						foreach (var item in Handover.HSEInventory)
						{
							HSEInventoryDTO hseInventoryDTO = new HSEInventoryDTO();
							hseInventoryDTO.Id = item.Id;
							hseInventoryDTO.Item = item.Item;
							hseInventoryDTO.StockAtStorage = item.StockAtStorage;
							hseInventoryDTO.ReleasedFromStorage = item.ReleasedFromStorage;
							hseInventoryDTO.NewlyRecieved = item.NewlyRecieved;
							hseInventoryDTO.HandoverId = item.HandoverId;
							hseInventoryDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.HSEInventory.Add(hseInventoryDTO);
						}
						foreach (var item in Handover.HSEEquipment)
						{
							HSEEquipmentDTO hseEquipmentDTO = new HSEEquipmentDTO();
							hseEquipmentDTO.Id = item.Id;
							hseEquipmentDTO.Item = item.Item;
							hseEquipmentDTO.OnSite = item.OnSite;
							hseEquipmentDTO.SentForMaintenance = item.SentForMaintenance;
							hseEquipmentDTO.HandoverId = item.HandoverId;
							hseEquipmentDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.HSEEquipment.Add(hseEquipmentDTO);
						}
						if (Handover.MaterialRequested.Any())
						{
							foreach (var item in Handover.MaterialRequested)
							{
								MaterialRequestedDTO materialRequestedDTO = new MaterialRequestedDTO();
								materialRequestedDTO.Id = item.Id;
								materialRequestedDTO.PR = item.PR;
								materialRequestedDTO.RequiredItem = item.RequiredItem;
								materialRequestedDTO.HandoverId = item.HandoverId;
								materialRequestedDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.MaterialRequested.Add(materialRequestedDTO);
							}
						}
						newTemp.Add(HandoverDTO);
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


		[HttpGet("GetDataForChart")]
		public async Task<ResultDTO> GetDataForChart(int RigNo,string LeavingEngineer, string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<Handover> temp = HandoverRepoistory.getall().Where(w => w.Rig.Number == RigNo && w.LeavingEmpName == LeavingEngineer).ToList();
					List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
					foreach (Handover Handover in temp)
					{
						HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
						HandoverDTO.Id = Handover.Id;
						HandoverDTO.RigNo = Handover.Rig.Number;
						HandoverDTO.ShiftDateFrom = Handover.ShiftDateFrom;
						HandoverDTO.ShiftDateTo = Handover.ShiftDateTo;
						HandoverDTO.WellName = Handover.WellName;
						HandoverDTO.Client = Handover.Client;
						HandoverDTO.LeavingEmpCode = Handover.LeavingEmpCode;
						HandoverDTO.LeavingEmpName = Handover.LeavingEmpName;
						HandoverDTO.ComingEmpCode = Handover.ComingEmpCode;
						HandoverDTO.ComingEmpName = Handover.ComingEmpName;
						HandoverDTO.StopCards = Handover.StopCards;
						HandoverDTO.MonthlyStopCards = Handover.MonthlyStopCards;
						HandoverDTO.OpenStopCards = Handover.OpenStopCards;
						HandoverDTO.Drills = Handover.Drills;
						HandoverDTO.MonthlyDrills = Handover.MonthlyDrills;
						HandoverDTO.SafetyAlerts = Handover.SafetyAlerts;
						HandoverDTO.MonthlySafetyAlerts = Handover.MonthlySafetyAlerts;
						HandoverDTO.WeeklyInspection = Handover.WeeklyInspection;
						HandoverDTO.InternalAudit = Handover.InternalAudit;
						HandoverDTO.ExternalAudit = Handover.ExternalAudit;
						HandoverDTO.MedicalReport = Handover.MedicalReport;
						HandoverDTO.TrainingMatrix = Handover.TrainingMatrix;
						HandoverDTO.RigMove = Handover.RigMove;
						HandoverDTO.IncidentReport = Handover.IncidentReport;
						HandoverDTO.TrackingSheetClosedPoints = Handover.TrackingSheetClosedPoints;
						HandoverDTO.ShiftBrief = Handover.ShiftBrief;
						HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
						HandoverDTO.userName = Handover.user.UserName;
						HandoverDTO.PotentialHazardReport = Handover.PotentialHazardReport;
						if (Handover.ShiftDrillTypes.Any())
						{
							foreach (var item in Handover.ShiftDrillTypes)
							{
								ShiftDrillTypesDTO shiftDrillTypesDTO = new ShiftDrillTypesDTO();
								shiftDrillTypesDTO.Id = item.Id;
								shiftDrillTypesDTO.Date = item.Date;
								shiftDrillTypesDTO.DrillType = item.DrillType;
								shiftDrillTypesDTO.HandoverId = item.HandoverId;
								shiftDrillTypesDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.ShiftDrillTypes.Add(shiftDrillTypesDTO);
							}
						}
						if (Handover.Visits.Any())
						{
							foreach (var item in Handover.Visits)
							{
								VisitsDTO visitsDTO = new VisitsDTO();
								visitsDTO.Id = item.Id;
								visitsDTO.Date = item.Date;
								visitsDTO.VisitName = item.VisitName;
								visitsDTO.HandoverId = item.HandoverId;
								visitsDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.Visits.Add(visitsDTO);
							}
						}
						foreach (var item in Handover.HSEInventory)
						{
							HSEInventoryDTO hseInventoryDTO = new HSEInventoryDTO();
							hseInventoryDTO.Id = item.Id;
							hseInventoryDTO.Item = item.Item;
							hseInventoryDTO.StockAtStorage = item.StockAtStorage;
							hseInventoryDTO.ReleasedFromStorage = item.ReleasedFromStorage;
							hseInventoryDTO.NewlyRecieved = item.NewlyRecieved;
							hseInventoryDTO.HandoverId = item.HandoverId;
							hseInventoryDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.HSEInventory.Add(hseInventoryDTO);
						}
						foreach (var item in Handover.HSEEquipment)
						{
							HSEEquipmentDTO hseEquipmentDTO = new HSEEquipmentDTO();
							hseEquipmentDTO.Id = item.Id;
							hseEquipmentDTO.Item = item.Item;
							hseEquipmentDTO.OnSite = item.OnSite;
							hseEquipmentDTO.SentForMaintenance = item.SentForMaintenance;
							hseEquipmentDTO.HandoverId = item.HandoverId;
							hseEquipmentDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.HSEEquipment.Add(hseEquipmentDTO);
						}
						if (Handover.MaterialRequested.Any())
						{
							foreach (var item in Handover.MaterialRequested)
							{
								MaterialRequestedDTO materialRequestedDTO = new MaterialRequestedDTO();
								materialRequestedDTO.Id = item.Id;
								materialRequestedDTO.PR = item.PR;
								materialRequestedDTO.RequiredItem = item.RequiredItem;
								materialRequestedDTO.HandoverId = item.HandoverId;
								materialRequestedDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.MaterialRequested.Add(materialRequestedDTO);
							}
						}
						newTemp.Add(HandoverDTO);
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
					List<Handover> temp = HandoverRepoistory.getall().Where(a => a.user.Id == UserID && a.Rig.Number == RigNo && a.LeavingEmpName == LeavingEngineer).ToList();
					List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
					foreach (Handover Handover in temp)
					{
						HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
						HandoverDTO.Id = Handover.Id;
						HandoverDTO.RigNo = Handover.Rig.Number;
						HandoverDTO.ShiftDateFrom = Handover.ShiftDateFrom;
						HandoverDTO.ShiftDateTo = Handover.ShiftDateTo;
						HandoverDTO.WellName = Handover.WellName;
						HandoverDTO.Client = Handover.Client;
						HandoverDTO.LeavingEmpCode = Handover.LeavingEmpCode;
						HandoverDTO.LeavingEmpName = Handover.LeavingEmpName;
						HandoverDTO.ComingEmpCode = Handover.ComingEmpCode;
						HandoverDTO.ComingEmpName = Handover.ComingEmpName;
						HandoverDTO.StopCards = Handover.StopCards;
						HandoverDTO.MonthlyStopCards = Handover.MonthlyStopCards;
						HandoverDTO.OpenStopCards = Handover.OpenStopCards;
						HandoverDTO.Drills = Handover.Drills;
						HandoverDTO.MonthlyDrills = Handover.MonthlyDrills;
						HandoverDTO.SafetyAlerts = Handover.SafetyAlerts;
						HandoverDTO.MonthlySafetyAlerts = Handover.MonthlySafetyAlerts;
						HandoverDTO.WeeklyInspection = Handover.WeeklyInspection;
						HandoverDTO.InternalAudit = Handover.InternalAudit;
						HandoverDTO.ExternalAudit = Handover.ExternalAudit;
						HandoverDTO.MedicalReport = Handover.MedicalReport;
						HandoverDTO.TrainingMatrix = Handover.TrainingMatrix;
						HandoverDTO.RigMove = Handover.RigMove;
						HandoverDTO.IncidentReport = Handover.IncidentReport;
						HandoverDTO.TrackingSheetClosedPoints = Handover.TrackingSheetClosedPoints;
						HandoverDTO.ShiftBrief = Handover.ShiftBrief;
						HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
						HandoverDTO.userName = Handover.user.UserName;
						HandoverDTO.PotentialHazardReport = Handover.PotentialHazardReport;
						if (Handover.ShiftDrillTypes.Any())
						{
							foreach (var item in Handover.ShiftDrillTypes)
							{
								ShiftDrillTypesDTO shiftDrillTypesDTO = new ShiftDrillTypesDTO();
								shiftDrillTypesDTO.Id = item.Id;
								shiftDrillTypesDTO.Date = item.Date;
								shiftDrillTypesDTO.DrillType = item.DrillType;
								shiftDrillTypesDTO.HandoverId = item.HandoverId;
								shiftDrillTypesDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.ShiftDrillTypes.Add(shiftDrillTypesDTO);
							}
						}
						if (Handover.Visits.Any())
						{
							foreach (var item in Handover.Visits)
							{
								VisitsDTO visitsDTO = new VisitsDTO();
								visitsDTO.Id = item.Id;
								visitsDTO.Date = item.Date;
								visitsDTO.VisitName = item.VisitName;
								visitsDTO.HandoverId = item.HandoverId;
								visitsDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.Visits.Add(visitsDTO);
							}
						}
						foreach (var item in Handover.HSEInventory)
						{
							HSEInventoryDTO hseInventoryDTO = new HSEInventoryDTO();
							hseInventoryDTO.Id = item.Id;
							hseInventoryDTO.Item = item.Item;
							hseInventoryDTO.StockAtStorage = item.StockAtStorage;
							hseInventoryDTO.ReleasedFromStorage = item.ReleasedFromStorage;
							hseInventoryDTO.NewlyRecieved = item.NewlyRecieved;
							hseInventoryDTO.HandoverId = item.HandoverId;
							hseInventoryDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.HSEInventory.Add(hseInventoryDTO);
						}
						foreach (var item in Handover.HSEEquipment)
						{
							HSEEquipmentDTO hseEquipmentDTO = new HSEEquipmentDTO();
							hseEquipmentDTO.Id = item.Id;
							hseEquipmentDTO.Item = item.Item;
							hseEquipmentDTO.OnSite = item.OnSite;
							hseEquipmentDTO.SentForMaintenance = item.SentForMaintenance;
							hseEquipmentDTO.HandoverId = item.HandoverId;
							hseEquipmentDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.HSEEquipment.Add(hseEquipmentDTO);
						}
						if (Handover.MaterialRequested.Any())
						{
							foreach (var item in Handover.MaterialRequested)
							{
								MaterialRequestedDTO materialRequestedDTO = new MaterialRequestedDTO();
								materialRequestedDTO.Id = item.Id;
								materialRequestedDTO.PR = item.PR;
								materialRequestedDTO.RequiredItem = item.RequiredItem;
								materialRequestedDTO.HandoverId = item.HandoverId;
								materialRequestedDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.MaterialRequested.Add(materialRequestedDTO);
							}
						}
						newTemp.Add(HandoverDTO);
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

		//	[HttpGet("GetDataByFilter")]
		//	public async Task<ResultDTO> GetAllWithDataByFilter(string? Responsability, string? Title, string? date, string? Status)
		//	{
		//		ResultDTO result = new ResultDTO();

		//		try
		//		{
		//			List<Handover> temp = HandoverRepoistory.getall();

		//			temp = temp.Where(m => (Responsability == null || m.HandoverResponsability.ResponsibilityName == Responsability)
		//				&& (Title == null || m.Title == Title)
		//				&& (date == null || m.DateRaisedBy.Date == DateTime.Parse(date).Date) && (Status == null || m.FormStatus == Status)).ToList();

		//			List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
		//			foreach (Handover Handover in temp)
		//			{
		//				HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
		//				HandoverDTO.Id = Handover.Id;
		//				//HandoverDTO.Rig = Handover.Rig.Number;
		//				HandoverDTO.Title = Handover.Title;
		//				HandoverDTO.FormResponsability = Handover.HandoverResponsability.ResponsibilityName;
		//				HandoverDTO.ReportNo = Handover.ReportNo;
		//				HandoverDTO.DescriptionOfNonConformity = Handover.DescriptionOfNonConformity;
		//				HandoverDTO.Standard = Handover.Standard.StandardName;
		//				HandoverDTO.ClauseNo = Handover.ClauseNo;
		//				HandoverDTO.ObjectiveEvidence = Handover.ObjectiveEvidence;
		//				foreach (var item in Handover.HandoverAndObservation)
		//				{
		//					string observation = item.HandoverObservation.Observation;
		//					HandoverDTO.HandoverAndObservation.Add(observation);

		//				}
		//				foreach (var item in Handover.HandoverAndRootCauses)
		//				{
		//					string cause = item.RootCauses.CauseName;
		//					HandoverDTO.HandoverAndRootCauses.Add(cause);

		//				}
		//				HandoverDTO.IfOtherObservation = Handover.IfOtherObservation;
		//				HandoverDTO.UpdateRisk = Handover.UpdateRisk;
		//				HandoverDTO.IfUpdate = Handover.IfUpdate;
		//				HandoverDTO.ManagementOfChange = Handover.ManagementOfChange;
		//				HandoverDTO.IfManagementOfChange = Handover.IfManagementOfChange;
		//				HandoverDTO.NameRasiedBy = Handover.NameRasiedBy;
		//				//HandoverDTO.SigRasiedBy = Handover.SigRasiedBy;
		//				HandoverDTO.DateRaisedBy = Handover.DateRaisedBy;
		//				HandoverDTO.IfOtherRootCause = Handover.IfOtherRootCause;
		//				foreach (var item in Handover.HandoverDataTable)
		//				{
		//					HandoverDataTable Data = new HandoverDataTable();
		//					Data.Id = item.Id;
		//					Data.SN = item.SN;
		//					Data.HandoverSelected = item.HandoverSelected;
		//					Data.Action = item.Action;
		//					Data.Responsible = item.Responsible;
		//					Data.SuggestedDate = item.SuggestedDate;
		//					Data.AchievementDate = item.AchievementDate;
		//					Data.Status = item.Status;
		//					Data.HandoverId = item.HandoverId;
		//					Data.FollowUpAudit = item.FollowUpAudit;
		//					Data.IsDeleted = item.IsDeleted;
		//					HandoverDTO.HandoverDataTable.Add(Data);
		//				};
		//				HandoverDTO.Comment = Handover.Comment;
		//				HandoverDTO.Q_ManagerSig = Handover.Q_ManagerSig;
		//				//HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
		//				HandoverDTO.userName = Handover.user.UserName;
		//				HandoverDTO.FormStatus = Handover.FormStatus;
		//				List<HandoverImages> HandoverImages = HandoverImagesRepo.getall().Where(p => p.HandoverId == Handover.Id).ToList();
		//				foreach (var item in HandoverImages)
		//				{
		//					string FileName = item.FileName;
		//					HandoverDTO.Images.Add(FileName);

		//				}
		//				newTemp.Add(HandoverDTO);
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
		//		catch (Exception ex)
		//		{
		//			result.Statescode = 404;
		//			result.Message = "data not found";
		//		}
		//		return result;
		//	}

		//	//[HttpGet("GetDataForAnalysis")]
		//	//public async Task<ResultDTO> GetDataForAnalysis(int RigId, string UserID, string UserRole)
		//	//{
		//	//	ResultDTO result = new ResultDTO();

		//	//	try
		//	//	{
		//	//		if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
		//	//		{
		//	//			List<Handover> temp = HandoverRepoistory.getall().Where(c=>c.RigId==RigId).ToList();
		//	//			List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
		//	//			foreach (Handover Handover in temp)
		//	//			{
		//	//				HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
		//	//				HandoverDTO.Id = Handover.Id;
		//	//				HandoverDTO.Rig = Handover.Rig.Number;
		//	//				HandoverDTO.Title = Handover.Title;
		//	//				HandoverDTO.FormResponsability = Handover.HandoverResponsability.ResponsibilityName;
		//	//				HandoverDTO.ReportNo = Handover.ReportNo;
		//	//				HandoverDTO.DescriptionOfNonConformity = Handover.DescriptionOfNonConformity;
		//	//				HandoverDTO.Standard = Handover.Standard.StandardName;
		//	//				HandoverDTO.ClauseNo = Handover.ClauseNo;
		//	//				HandoverDTO.ObjectiveEvidence = Handover.ObjectiveEvidence;
		//	//				foreach (var item in Handover.HandoverAndObservation)
		//	//				{
		//	//					string observation = item.HandoverObservation.Observation;
		//	//					HandoverDTO.HandoverAndObservation.Add(observation);

		//	//				}
		//	//				foreach (var item in Handover.HandoverAndRootCauses)
		//	//				{
		//	//					string cause = item.RootCauses.CauseName;
		//	//					HandoverDTO.HandoverAndRootCauses.Add(cause);

		//	//				}
		//	//				HandoverDTO.IfOtherObservation = Handover.IfOtherObservation;
		//	//				HandoverDTO.UpdateRisk = Handover.UpdateRisk;
		//	//				HandoverDTO.IfUpdate = Handover.IfUpdate;
		//	//				HandoverDTO.ManagementOfChange = Handover.ManagementOfChange;
		//	//				HandoverDTO.IfManagementOfChange = Handover.IfManagementOfChange;
		//	//				HandoverDTO.NameRasiedBy = Handover.NameRasiedBy;
		//	//				//HandoverDTO.SigRasiedBy = Handover.SigRasiedBy;
		//	//				HandoverDTO.DateRaisedBy = Handover.DateRaisedBy;
		//	//				HandoverDTO.IfOtherRootCause = Handover.IfOtherRootCause;
		//	//				foreach (var item in Handover.HandoverDataTable)
		//	//				{
		//	//					HandoverDataTable Data = new HandoverDataTable();
		//	//					Data.Id = item.Id;
		//	//					Data.SN = item.SN;
		//	//					Data.HandoverSelected = item.HandoverSelected;
		//	//					Data.Action = item.Action;
		//	//					Data.Responsible = item.Responsible;
		//	//					Data.SuggestedDate = item.SuggestedDate;
		//	//					Data.AchievementDate = item.AchievementDate;
		//	//					Data.Status = item.Status;
		//	//					Data.HandoverId = item.HandoverId;
		//	//					Data.FollowUpAudit = item.FollowUpAudit;
		//	//					Data.IsDeleted = item.IsDeleted;
		//	//					HandoverDTO.HandoverDataTable.Add(Data);
		//	//				};
		//	//				HandoverDTO.Comment = Handover.Comment;
		//	//				HandoverDTO.Q_ManagerSig = Handover.Q_ManagerSig;
		//	//				HandoverDTO.userName = Handover.user.UserName;
		//	//				HandoverDTO.FormStatus = Handover.FormStatus;
		//	//				List<HandoverImages> HandoverImages = HandoverImagesRepo.getall().Where(p => p.HandoverId == Handover.Id).ToList();
		//	//				foreach (var item in HandoverImages)
		//	//				{
		//	//					string FileName = item.FileName;
		//	//					HandoverDTO.Images.Add(FileName);

		//	//				}
		//	//				newTemp.Add(HandoverDTO);
		//	//				//result.Data = prod;
		//	//			}
		//	//			if (newTemp != null)
		//	//			{
		//	//				result.Message = "Success";
		//	//				result.Statescode = 200;
		//	//				result.Data = newTemp;

		//	//				return result;
		//	//			}
		//	//		}
		//	//		else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
		//	//		{
		//	//			List<Handover> temp = HandoverRepoistory.getall().Where(a => a.user.Id == UserID && a.RigId == RigId).ToList();
		//	//			List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
		//	//			foreach (Handover Handover in temp)
		//	//			{
		//	//				HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
		//	//				HandoverDTO.Id = Handover.Id;
		//	//				HandoverDTO.Rig = Handover.Rig.Number;
		//	//				HandoverDTO.Title = Handover.Title;
		//	//				HandoverDTO.FormResponsability = Handover.HandoverResponsability.ResponsibilityName;
		//	//				HandoverDTO.ReportNo = Handover.ReportNo;
		//	//				HandoverDTO.DescriptionOfNonConformity = Handover.DescriptionOfNonConformity;
		//	//				HandoverDTO.Standard = Handover.Standard.StandardName;
		//	//				HandoverDTO.ClauseNo = Handover.ClauseNo;
		//	//				HandoverDTO.ObjectiveEvidence = Handover.ObjectiveEvidence;
		//	//				foreach (var item in Handover.HandoverAndObservation)
		//	//				{
		//	//					string observation = item.HandoverObservation.Observation;
		//	//					HandoverDTO.HandoverAndObservation.Add(observation);

		//	//				}
		//	//				foreach (var item in Handover.HandoverAndRootCauses)
		//	//				{
		//	//					string cause = item.RootCauses.CauseName;
		//	//					HandoverDTO.HandoverAndRootCauses.Add(cause);

		//	//				}
		//	//				HandoverDTO.IfOtherObservation = Handover.IfOtherObservation;
		//	//				HandoverDTO.UpdateRisk = Handover.UpdateRisk;
		//	//				HandoverDTO.IfUpdate = Handover.IfUpdate;
		//	//				HandoverDTO.ManagementOfChange = Handover.ManagementOfChange;
		//	//				HandoverDTO.IfManagementOfChange = Handover.IfManagementOfChange;
		//	//				HandoverDTO.NameRasiedBy = Handover.NameRasiedBy;
		//	//				//HandoverDTO.SigRasiedBy = Handover.SigRasiedBy;
		//	//				HandoverDTO.DateRaisedBy = Handover.DateRaisedBy;
		//	//				HandoverDTO.IfOtherRootCause = Handover.IfOtherRootCause;
		//	//				foreach (var item in Handover.HandoverDataTable)
		//	//				{
		//	//					HandoverDataTable Data = new HandoverDataTable();
		//	//					Data.Id = item.Id;
		//	//					Data.SN = item.SN;
		//	//					Data.HandoverSelected = item.HandoverSelected;
		//	//					Data.Action = item.Action;
		//	//					Data.Responsible = item.Responsible;
		//	//					Data.SuggestedDate = item.SuggestedDate;
		//	//					Data.AchievementDate = item.AchievementDate;
		//	//					Data.Status = item.Status;
		//	//					Data.HandoverId = item.HandoverId;
		//	//					Data.FollowUpAudit = item.FollowUpAudit;
		//	//					Data.IsDeleted = item.IsDeleted;
		//	//					HandoverDTO.HandoverDataTable.Add(Data);
		//	//				};
		//	//				HandoverDTO.Comment = Handover.Comment;
		//	//				HandoverDTO.Q_ManagerSig = Handover.Q_ManagerSig;
		//	//				HandoverDTO.userName = Handover.user.UserName;
		//	//				HandoverDTO.FormStatus = Handover.FormStatus;
		//	//				List<HandoverImages> HandoverImages = HandoverImagesRepo.getall().Where(p => p.HandoverId == Handover.Id).ToList();
		//	//				foreach (var item in HandoverImages)
		//	//				{
		//	//					string FileName = item.FileName;
		//	//					HandoverDTO.Images.Add(FileName);

		//	//				}
		//	//				newTemp.Add(HandoverDTO);
		//	//				//result.Data = prod;
		//	//			}
		//	//			if (newTemp != null)
		//	//			{
		//	//				result.Message = "Success";
		//	//				result.Statescode = 200;
		//	//				result.Data = newTemp;

		//	//				return result;
		//	//			}
		//	//		}
		//	//	}
		//	//	catch (Exception ex)
		//	//	{
		//	//		result.Statescode = 404;
		//	//		result.Message = "data not found";
		//	//	}
		//	//	return result;
		//	//}

		//	[HttpGet("GetDataByResponsability")]
		//	public async Task<ResultDTO> GetDataByResponsability(string Responability, string UserID, string UserRole)
		//	{
		//		ResultDTO result = new ResultDTO();

		//		try
		//		{
		//			if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
		//			{
		//				List<Handover> temp = HandoverRepoistory.getall().Where(c => c.HandoverResponsability.ResponsibilityName == Responability).ToList();
		//				List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
		//				foreach (Handover Handover in temp)
		//				{
		//					HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
		//					HandoverDTO.Id = Handover.Id;
		//					//HandoverDTO.Rig = Handover.Rig.Number;
		//					HandoverDTO.Title = Handover.Title;
		//					HandoverDTO.FormResponsability = Handover.HandoverResponsability.ResponsibilityName;
		//					HandoverDTO.ReportNo = Handover.ReportNo;
		//					HandoverDTO.DescriptionOfNonConformity = Handover.DescriptionOfNonConformity;
		//					HandoverDTO.Standard = Handover.Standard.StandardName;
		//					HandoverDTO.ClauseNo = Handover.ClauseNo;
		//					HandoverDTO.ObjectiveEvidence = Handover.ObjectiveEvidence;
		//					foreach (var item in Handover.HandoverAndObservation)
		//					{
		//						string observation = item.HandoverObservation.Observation;
		//						HandoverDTO.HandoverAndObservation.Add(observation);

		//					}
		//					foreach (var item in Handover.HandoverAndRootCauses)
		//					{
		//						string cause = item.RootCauses.CauseName;
		//						HandoverDTO.HandoverAndRootCauses.Add(cause);

		//					}
		//					HandoverDTO.IfOtherObservation = Handover.IfOtherObservation;
		//					HandoverDTO.UpdateRisk = Handover.UpdateRisk;
		//					HandoverDTO.IfUpdate = Handover.IfUpdate;
		//					HandoverDTO.ManagementOfChange = Handover.ManagementOfChange;
		//					HandoverDTO.IfManagementOfChange = Handover.IfManagementOfChange;
		//					HandoverDTO.NameRasiedBy = Handover.NameRasiedBy;
		//					//HandoverDTO.SigRasiedBy = Handover.SigRasiedBy;
		//					HandoverDTO.DateRaisedBy = Handover.DateRaisedBy;
		//					HandoverDTO.IfOtherRootCause = Handover.IfOtherRootCause;
		//					foreach (var item in Handover.HandoverDataTable)
		//					{
		//						HandoverDataTable Data = new HandoverDataTable();
		//						Data.Id = item.Id;
		//						Data.SN = item.SN;
		//						Data.HandoverSelected = item.HandoverSelected;
		//						Data.Action = item.Action;
		//						Data.Responsible = item.Responsible;
		//						Data.SuggestedDate = item.SuggestedDate;
		//						Data.AchievementDate = item.AchievementDate;
		//						Data.Status = item.Status;
		//						Data.HandoverId = item.HandoverId;
		//						Data.FollowUpAudit = item.FollowUpAudit;
		//						Data.IsDeleted = item.IsDeleted;
		//						HandoverDTO.HandoverDataTable.Add(Data);
		//					};
		//					HandoverDTO.Comment = Handover.Comment;
		//					HandoverDTO.Q_ManagerSig = Handover.Q_ManagerSig;
		//					//HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
		//					HandoverDTO.userName = Handover.user.UserName;
		//					HandoverDTO.FormStatus = Handover.FormStatus;
		//					List<HandoverImages> HandoverImages = HandoverImagesRepo.getall().Where(p => p.HandoverId == Handover.Id).ToList();
		//					foreach (var item in HandoverImages)
		//					{
		//						string FileName = item.FileName;
		//						HandoverDTO.Images.Add(FileName);

		//					}
		//					newTemp.Add(HandoverDTO);
		//					//result.Data = prod;
		//				}
		//				if (newTemp != null)
		//				{
		//					result.Message = "Success";
		//					result.Statescode = 200;
		//					result.Data = newTemp;

		//					return result;
		//				}
		//			}
		//			else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
		//			{
		//				List<Handover> temp = HandoverRepoistory.getall().Where(a => a.user.Id == UserID && a.HandoverResponsability.ResponsibilityName == Responability).ToList();
		//				List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
		//				foreach (Handover Handover in temp)
		//				{
		//					HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
		//					HandoverDTO.Id = Handover.Id;
		//					//HandoverDTO.Rig = Handover.Rig.Number;
		//					HandoverDTO.Title = Handover.Title;
		//					HandoverDTO.FormResponsability = Handover.HandoverResponsability.ResponsibilityName;
		//					HandoverDTO.ReportNo = Handover.ReportNo;
		//					HandoverDTO.DescriptionOfNonConformity = Handover.DescriptionOfNonConformity;
		//					HandoverDTO.Standard = Handover.Standard.StandardName;
		//					HandoverDTO.ClauseNo = Handover.ClauseNo;
		//					HandoverDTO.ObjectiveEvidence = Handover.ObjectiveEvidence;
		//					foreach (var item in Handover.HandoverAndObservation)
		//					{
		//						string observation = item.HandoverObservation.Observation;
		//						HandoverDTO.HandoverAndObservation.Add(observation);

		//					}
		//					foreach (var item in Handover.HandoverAndRootCauses)
		//					{
		//						string cause = item.RootCauses.CauseName;
		//						HandoverDTO.HandoverAndRootCauses.Add(cause);

		//					}
		//					HandoverDTO.IfOtherObservation = Handover.IfOtherObservation;
		//					HandoverDTO.UpdateRisk = Handover.UpdateRisk;
		//					HandoverDTO.IfUpdate = Handover.IfUpdate;
		//					HandoverDTO.ManagementOfChange = Handover.ManagementOfChange;
		//					HandoverDTO.IfManagementOfChange = Handover.IfManagementOfChange;
		//					HandoverDTO.NameRasiedBy = Handover.NameRasiedBy;
		//					//HandoverDTO.SigRasiedBy = Handover.SigRasiedBy;
		//					HandoverDTO.DateRaisedBy = Handover.DateRaisedBy;
		//					HandoverDTO.IfOtherRootCause = Handover.IfOtherRootCause;
		//					foreach (var item in Handover.HandoverDataTable)
		//					{
		//						HandoverDataTable Data = new HandoverDataTable();
		//						Data.Id = item.Id;
		//						Data.SN = item.SN;
		//						Data.HandoverSelected = item.HandoverSelected;
		//						Data.Action = item.Action;
		//						Data.Responsible = item.Responsible;
		//						Data.SuggestedDate = item.SuggestedDate;
		//						Data.AchievementDate = item.AchievementDate;
		//						Data.Status = item.Status;
		//						Data.HandoverId = item.HandoverId;
		//						Data.FollowUpAudit = item.FollowUpAudit;
		//						Data.IsDeleted = item.IsDeleted;
		//						HandoverDTO.HandoverDataTable.Add(Data);
		//					};
		//					HandoverDTO.Comment = Handover.Comment;
		//					HandoverDTO.Q_ManagerSig = Handover.Q_ManagerSig;
		//					//HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
		//					HandoverDTO.userName = Handover.user.UserName;
		//					HandoverDTO.FormStatus = Handover.FormStatus;
		//					List<HandoverImages> HandoverImages = HandoverImagesRepo.getall().Where(p => p.HandoverId == Handover.Id).ToList();
		//					foreach (var item in HandoverImages)
		//					{
		//						string FileName = item.FileName;
		//						HandoverDTO.Images.Add(FileName);

		//					}
		//					newTemp.Add(HandoverDTO);
		//					//result.Data = prod;
		//				}
		//				if (newTemp != null)
		//				{
		//					result.Message = "Success";
		//					result.Statescode = 200;
		//					result.Data = newTemp;

		//					return result;
		//				}
		//			}
		//		}
		//		catch (Exception ex)
		//		{
		//			result.Statescode = 404;
		//			result.Message = "data not found";
		//		}
		//		return result;
		//	}

		//	[HttpGet("GetDataByStandard")]
		//	public async Task<ResultDTO> GetDataByStandard(string Standard, string UserID, string UserRole)
		//	{
		//		ResultDTO result = new ResultDTO();

		//		try
		//		{
		//			if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
		//			{
		//				List<Handover> temp = HandoverRepoistory.getall().Where(c => c.Standard.StandardName == Standard).ToList();
		//				List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
		//				foreach (Handover Handover in temp)
		//				{
		//					HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
		//					HandoverDTO.Id = Handover.Id;
		//					//HandoverDTO.Rig = Handover.Rig.Number;
		//					HandoverDTO.Title = Handover.Title;
		//					HandoverDTO.FormResponsability = Handover.HandoverResponsability.ResponsibilityName;
		//					HandoverDTO.ReportNo = Handover.ReportNo;
		//					HandoverDTO.DescriptionOfNonConformity = Handover.DescriptionOfNonConformity;
		//					HandoverDTO.Standard = Handover.Standard.StandardName;
		//					HandoverDTO.ClauseNo = Handover.ClauseNo;
		//					HandoverDTO.ObjectiveEvidence = Handover.ObjectiveEvidence;
		//					foreach (var item in Handover.HandoverAndObservation)
		//					{
		//						string observation = item.HandoverObservation.Observation;
		//						HandoverDTO.HandoverAndObservation.Add(observation);

		//					}
		//					foreach (var item in Handover.HandoverAndRootCauses)
		//					{
		//						string cause = item.RootCauses.CauseName;
		//						HandoverDTO.HandoverAndRootCauses.Add(cause);

		//					}
		//					HandoverDTO.IfOtherObservation = Handover.IfOtherObservation;
		//					HandoverDTO.UpdateRisk = Handover.UpdateRisk;
		//					HandoverDTO.IfUpdate = Handover.IfUpdate;
		//					HandoverDTO.ManagementOfChange = Handover.ManagementOfChange;
		//					HandoverDTO.IfManagementOfChange = Handover.IfManagementOfChange;
		//					HandoverDTO.NameRasiedBy = Handover.NameRasiedBy;
		//					//HandoverDTO.SigRasiedBy = Handover.SigRasiedBy;
		//					HandoverDTO.DateRaisedBy = Handover.DateRaisedBy;
		//					HandoverDTO.IfOtherRootCause = Handover.IfOtherRootCause;
		//					foreach (var item in Handover.HandoverDataTable)
		//					{
		//						HandoverDataTable Data = new HandoverDataTable();
		//						Data.Id = item.Id;
		//						Data.SN = item.SN;
		//						Data.HandoverSelected = item.HandoverSelected;
		//						Data.Action = item.Action;
		//						Data.Responsible = item.Responsible;
		//						Data.SuggestedDate = item.SuggestedDate;
		//						Data.AchievementDate = item.AchievementDate;
		//						Data.Status = item.Status;
		//						Data.HandoverId = item.HandoverId;
		//						Data.FollowUpAudit = item.FollowUpAudit;
		//						Data.IsDeleted = item.IsDeleted;
		//						HandoverDTO.HandoverDataTable.Add(Data);
		//					};
		//					HandoverDTO.Comment = Handover.Comment;
		//					HandoverDTO.Q_ManagerSig = Handover.Q_ManagerSig;
		//					//HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
		//					HandoverDTO.userName = Handover.user.UserName;
		//					HandoverDTO.FormStatus = Handover.FormStatus;
		//					List<HandoverImages> HandoverImages = HandoverImagesRepo.getall().Where(p => p.HandoverId == Handover.Id).ToList();
		//					foreach (var item in HandoverImages)
		//					{
		//						string FileName = item.FileName;
		//						HandoverDTO.Images.Add(FileName);

		//					}
		//					newTemp.Add(HandoverDTO);
		//					//result.Data = prod;
		//				}
		//				if (newTemp != null)
		//				{
		//					result.Message = "Success";
		//					result.Statescode = 200;
		//					result.Data = newTemp;

		//					return result;
		//				}
		//			}
		//			else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
		//			{
		//				List<Handover> temp = HandoverRepoistory.getall().Where(a => a.user.Id == UserID && a.Standard.StandardName == Standard).ToList();
		//				List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
		//				foreach (Handover Handover in temp)
		//				{
		//					HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
		//					HandoverDTO.Id = Handover.Id;
		//					//HandoverDTO.Rig = Handover.Rig.Number;
		//					HandoverDTO.Title = Handover.Title;
		//					HandoverDTO.FormResponsability = Handover.HandoverResponsability.ResponsibilityName;
		//					HandoverDTO.ReportNo = Handover.ReportNo;
		//					HandoverDTO.DescriptionOfNonConformity = Handover.DescriptionOfNonConformity;
		//					HandoverDTO.Standard = Handover.Standard.StandardName;
		//					HandoverDTO.ClauseNo = Handover.ClauseNo;
		//					HandoverDTO.ObjectiveEvidence = Handover.ObjectiveEvidence;
		//					foreach (var item in Handover.HandoverAndObservation)
		//					{
		//						string observation = item.HandoverObservation.Observation;
		//						HandoverDTO.HandoverAndObservation.Add(observation);

		//					}
		//					foreach (var item in Handover.HandoverAndRootCauses)
		//					{
		//						string cause = item.RootCauses.CauseName;
		//						HandoverDTO.HandoverAndRootCauses.Add(cause);

		//					}
		//					HandoverDTO.IfOtherObservation = Handover.IfOtherObservation;
		//					HandoverDTO.UpdateRisk = Handover.UpdateRisk;
		//					HandoverDTO.IfUpdate = Handover.IfUpdate;
		//					HandoverDTO.ManagementOfChange = Handover.ManagementOfChange;
		//					HandoverDTO.IfManagementOfChange = Handover.IfManagementOfChange;
		//					HandoverDTO.NameRasiedBy = Handover.NameRasiedBy;
		//					//HandoverDTO.SigRasiedBy = Handover.SigRasiedBy;
		//					HandoverDTO.DateRaisedBy = Handover.DateRaisedBy;
		//					HandoverDTO.IfOtherRootCause = Handover.IfOtherRootCause;
		//					foreach (var item in Handover.HandoverDataTable)
		//					{
		//						HandoverDataTable Data = new HandoverDataTable();
		//						Data.Id = item.Id;
		//						Data.SN = item.SN;
		//						Data.HandoverSelected = item.HandoverSelected;
		//						Data.Action = item.Action;
		//						Data.Responsible = item.Responsible;
		//						Data.SuggestedDate = item.SuggestedDate;
		//						Data.AchievementDate = item.AchievementDate;
		//						Data.Status = item.Status;
		//						Data.HandoverId = item.HandoverId;
		//						Data.FollowUpAudit = item.FollowUpAudit;
		//						Data.IsDeleted = item.IsDeleted;
		//						HandoverDTO.HandoverDataTable.Add(Data);
		//					};
		//					HandoverDTO.Comment = Handover.Comment;
		//					HandoverDTO.Q_ManagerSig = Handover.Q_ManagerSig;
		//					//HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
		//					HandoverDTO.userName = Handover.user.UserName;
		//					HandoverDTO.FormStatus = Handover.FormStatus;
		//					List<HandoverImages> HandoverImages = HandoverImagesRepo.getall().Where(p => p.HandoverId == Handover.Id).ToList();
		//					foreach (var item in HandoverImages)
		//					{
		//						string FileName = item.FileName;
		//						HandoverDTO.Images.Add(FileName);

		//					}
		//					newTemp.Add(HandoverDTO);
		//					//result.Data = prod;
		//				}
		//				if (newTemp != null)
		//				{
		//					result.Message = "Success";
		//					result.Statescode = 200;
		//					result.Data = newTemp;

		//					return result;
		//				}
		//			}
		//		}
		//		catch (Exception ex)
		//		{
		//			result.Statescode = 404;
		//			result.Message = "data not found";
		//		}
		//		return result;
		//	}

		//	[HttpGet("GetDataByObservation")]
		//	public async Task<ResultDTO> GetDataByObservation(string Observation, string UserID, string UserRole)
		//	{
		//		ResultDTO result = new ResultDTO();

		//		try
		//		{
		//			if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
		//			{
		//				List<Handover> temp = HandoverRepoistory.getall().Where(x => x.HandoverAndObservation.Any(obs => obs.HandoverObservation.Observation == Observation)).ToList();
		//				List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
		//				foreach (Handover Handover in temp)
		//				{
		//					HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
		//					HandoverDTO.Id = Handover.Id;
		//					//HandoverDTO.Rig = Handover.Rig.Number;
		//					HandoverDTO.Title = Handover.Title;
		//					HandoverDTO.FormResponsability = Handover.HandoverResponsability.ResponsibilityName;
		//					HandoverDTO.ReportNo = Handover.ReportNo;
		//					HandoverDTO.DescriptionOfNonConformity = Handover.DescriptionOfNonConformity;
		//					HandoverDTO.Standard = Handover.Standard.StandardName;
		//					HandoverDTO.ClauseNo = Handover.ClauseNo;
		//					HandoverDTO.ObjectiveEvidence = Handover.ObjectiveEvidence;
		//					foreach (var item in Handover.HandoverAndObservation)
		//					{
		//						string observation = item.HandoverObservation.Observation;
		//						HandoverDTO.HandoverAndObservation.Add(observation);

		//					}
		//					foreach (var item in Handover.HandoverAndRootCauses)
		//					{
		//						string cause = item.RootCauses.CauseName;
		//						HandoverDTO.HandoverAndRootCauses.Add(cause);

		//					}
		//					HandoverDTO.IfOtherObservation = Handover.IfOtherObservation;
		//					HandoverDTO.UpdateRisk = Handover.UpdateRisk;
		//					HandoverDTO.IfUpdate = Handover.IfUpdate;
		//					HandoverDTO.ManagementOfChange = Handover.ManagementOfChange;
		//					HandoverDTO.IfManagementOfChange = Handover.IfManagementOfChange;
		//					HandoverDTO.NameRasiedBy = Handover.NameRasiedBy;
		//					//HandoverDTO.SigRasiedBy = Handover.SigRasiedBy;
		//					HandoverDTO.DateRaisedBy = Handover.DateRaisedBy;
		//					HandoverDTO.IfOtherRootCause = Handover.IfOtherRootCause;
		//					foreach (var item in Handover.HandoverDataTable)
		//					{
		//						HandoverDataTable Data = new HandoverDataTable();
		//						Data.Id = item.Id;
		//						Data.SN = item.SN;
		//						Data.HandoverSelected = item.HandoverSelected;
		//						Data.Action = item.Action;
		//						Data.Responsible = item.Responsible;
		//						Data.SuggestedDate = item.SuggestedDate;
		//						Data.AchievementDate = item.AchievementDate;
		//						Data.Status = item.Status;
		//						Data.HandoverId = item.HandoverId;
		//						Data.FollowUpAudit = item.FollowUpAudit;
		//						Data.IsDeleted = item.IsDeleted;
		//						HandoverDTO.HandoverDataTable.Add(Data);
		//					};
		//					HandoverDTO.Comment = Handover.Comment;
		//					HandoverDTO.Q_ManagerSig = Handover.Q_ManagerSig;
		//					//HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
		//					HandoverDTO.userName = Handover.user.UserName;
		//					HandoverDTO.FormStatus = Handover.FormStatus;
		//					List<HandoverImages> HandoverImages = HandoverImagesRepo.getall().Where(p => p.HandoverId == Handover.Id).ToList();
		//					foreach (var item in HandoverImages)
		//					{
		//						string FileName = item.FileName;
		//						HandoverDTO.Images.Add(FileName);

		//					}
		//					newTemp.Add(HandoverDTO);
		//					//result.Data = prod;
		//				}
		//				if (newTemp != null)
		//				{
		//					result.Message = "Success";
		//					result.Statescode = 200;
		//					result.Data = newTemp;

		//					return result;
		//				}
		//			}
		//			else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
		//			{
		//				List<Handover> temp = HandoverRepoistory.getall().Where(a => a.user.Id == UserID && a.HandoverAndObservation.Any(obs => obs.HandoverObservation.Observation == Observation)).ToList();
		//				List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
		//				foreach (Handover Handover in temp)
		//				{
		//					HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
		//					HandoverDTO.Id = Handover.Id;
		//					//HandoverDTO.Rig = Handover.Rig.Number;
		//					HandoverDTO.Title = Handover.Title;
		//					HandoverDTO.FormResponsability = Handover.HandoverResponsability.ResponsibilityName;
		//					HandoverDTO.ReportNo = Handover.ReportNo;
		//					HandoverDTO.DescriptionOfNonConformity = Handover.DescriptionOfNonConformity;
		//					HandoverDTO.Standard = Handover.Standard.StandardName;
		//					HandoverDTO.ClauseNo = Handover.ClauseNo;
		//					HandoverDTO.ObjectiveEvidence = Handover.ObjectiveEvidence;
		//					foreach (var item in Handover.HandoverAndObservation)
		//					{
		//						string observation = item.HandoverObservation.Observation;
		//						HandoverDTO.HandoverAndObservation.Add(observation);

		//					}
		//					foreach (var item in Handover.HandoverAndRootCauses)
		//					{
		//						string cause = item.RootCauses.CauseName;
		//						HandoverDTO.HandoverAndRootCauses.Add(cause);

		//					}
		//					HandoverDTO.IfOtherObservation = Handover.IfOtherObservation;
		//					HandoverDTO.UpdateRisk = Handover.UpdateRisk;
		//					HandoverDTO.IfUpdate = Handover.IfUpdate;
		//					HandoverDTO.ManagementOfChange = Handover.ManagementOfChange;
		//					HandoverDTO.IfManagementOfChange = Handover.IfManagementOfChange;
		//					HandoverDTO.NameRasiedBy = Handover.NameRasiedBy;
		//					//HandoverDTO.SigRasiedBy = Handover.SigRasiedBy;
		//					HandoverDTO.DateRaisedBy = Handover.DateRaisedBy;
		//					HandoverDTO.IfOtherRootCause = Handover.IfOtherRootCause;
		//					foreach (var item in Handover.HandoverDataTable)
		//					{
		//						HandoverDataTable Data = new HandoverDataTable();
		//						Data.Id = item.Id;
		//						Data.SN = item.SN;
		//						Data.HandoverSelected = item.HandoverSelected;
		//						Data.Action = item.Action;
		//						Data.Responsible = item.Responsible;
		//						Data.SuggestedDate = item.SuggestedDate;
		//						Data.AchievementDate = item.AchievementDate;
		//						Data.Status = item.Status;
		//						Data.HandoverId = item.HandoverId;
		//						Data.FollowUpAudit = item.FollowUpAudit;
		//						Data.IsDeleted = item.IsDeleted;
		//						HandoverDTO.HandoverDataTable.Add(Data);
		//					};
		//					HandoverDTO.Comment = Handover.Comment;
		//					HandoverDTO.Q_ManagerSig = Handover.Q_ManagerSig;
		//					//HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
		//					HandoverDTO.userName = Handover.user.UserName;
		//					HandoverDTO.FormStatus = Handover.FormStatus;
		//					List<HandoverImages> HandoverImages = HandoverImagesRepo.getall().Where(p => p.HandoverId == Handover.Id).ToList();
		//					foreach (var item in HandoverImages)
		//					{
		//						string FileName = item.FileName;
		//						HandoverDTO.Images.Add(FileName);

		//					}
		//					newTemp.Add(HandoverDTO);
		//					//result.Data = prod;
		//				}
		//				if (newTemp != null)
		//				{
		//					result.Message = "Success";
		//					result.Statescode = 200;
		//					result.Data = newTemp;

		//					return result;
		//				}
		//			}
		//		}
		//		catch (Exception ex)
		//		{
		//			result.Statescode = 404;
		//			result.Message = "data not found";
		//		}
		//		return result;
		//	}


		[HttpGet("GetDataForExcel")]
		public ActionResult<ResultDTO> GetDataForExcel(string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<Handover> temp = HandoverRepoistory.getall();
					List<HandoverExcelDTO> newTemp = new List<HandoverExcelDTO>();
					foreach (Handover Handover in temp)
					{
						HandoverExcelDTO HandoverDTO = new HandoverExcelDTO();
						HandoverDTO.RigNo = Handover.Rig.Number;
						HandoverDTO.ShiftDateFrom = Handover.ShiftDateFrom;
						HandoverDTO.ShiftDateTo = Handover.ShiftDateTo;
						HandoverDTO.WellName = Handover.WellName;
						HandoverDTO.Client = Handover.Client;
						HandoverDTO.LeavingEmpCode = Handover.LeavingEmpCode;
						HandoverDTO.LeavingEmpName = Handover.LeavingEmpName;
						HandoverDTO.ComingEmpCode = Handover.ComingEmpCode;
						HandoverDTO.ComingEmpName = Handover.ComingEmpName;
						HandoverDTO.StopCards = Handover.StopCards;
						HandoverDTO.MonthlyStopCards = Handover.MonthlyStopCards;
						HandoverDTO.OpenStopCards = Handover.OpenStopCards;
						HandoverDTO.Drills = Handover.Drills;
						HandoverDTO.MonthlyDrills = Handover.MonthlyDrills;
						HandoverDTO.SafetyAlerts = Handover.SafetyAlerts;
						HandoverDTO.MonthlySafetyAlerts = Handover.MonthlySafetyAlerts;
						HandoverDTO.WeeklyInspection = Handover.WeeklyInspection;
						HandoverDTO.InternalAudit = Handover.InternalAudit;
						HandoverDTO.ExternalAudit = Handover.ExternalAudit;
						HandoverDTO.MedicalReport = Handover.MedicalReport;
						HandoverDTO.TrainingMatrix = Handover.TrainingMatrix;
						HandoverDTO.RigMove = Handover.RigMove;
						HandoverDTO.IncidentReport = Handover.IncidentReport;
						HandoverDTO.TrackingSheetClosedPoints = Handover.TrackingSheetClosedPoints;
						HandoverDTO.ShiftBrief = Handover.ShiftBrief;
						HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
						HandoverDTO.userName = Handover.user.UserName;
						HandoverDTO.PotentialHazardReport = Handover.PotentialHazardReport;
						if (Handover.ShiftDrillTypes.Any())
						{
							foreach (var item in Handover.ShiftDrillTypes)
							{
								ShiftDrillTypesExcelDTO shiftDrillTypesDTO = new ShiftDrillTypesExcelDTO();
								shiftDrillTypesDTO.Date = item.Date;
								shiftDrillTypesDTO.DrillType = item.DrillType;
								HandoverDTO.ShiftDrillTypes.Add(shiftDrillTypesDTO);
							}
						}
						if (Handover.Visits.Any())
						{
							foreach (var item in Handover.Visits)
							{
								VisitsExcelDTO visitsDTO = new VisitsExcelDTO();
								visitsDTO.Date = item.Date;
								visitsDTO.VisitName = item.VisitName;
								HandoverDTO.Visits.Add(visitsDTO);
							}
						}
						foreach (var item in Handover.HSEInventory)
						{
							HSEInventoryExcelDTO hseInventoryDTO = new HSEInventoryExcelDTO();
							hseInventoryDTO.Item = item.Item;
							hseInventoryDTO.StockAtStorage = item.StockAtStorage;
							hseInventoryDTO.ReleasedFromStorage = item.ReleasedFromStorage;
							hseInventoryDTO.NewlyRecieved = item.NewlyRecieved;
							HandoverDTO.HSEInventory.Add(hseInventoryDTO);
						}
						foreach (var item in Handover.HSEEquipment)
						{
							HSEEquipmentExcelDTO hseEquipmentDTO = new HSEEquipmentExcelDTO();
							hseEquipmentDTO.Item = item.Item;
							hseEquipmentDTO.OnSite = item.OnSite;
							hseEquipmentDTO.SentForMaintenance = item.SentForMaintenance;
							HandoverDTO.HSEEquipment.Add(hseEquipmentDTO);
						}
						if (Handover.MaterialRequested.Any())
						{
							foreach (var item in Handover.MaterialRequested)
							{
								MaterialRequestedExcelDTO materialRequestedDTO = new MaterialRequestedExcelDTO();
								materialRequestedDTO.PR = item.PR;
								materialRequestedDTO.RequiredItem = item.RequiredItem;
								HandoverDTO.MaterialRequested.Add(materialRequestedDTO);
							}
						}
						newTemp.Add(HandoverDTO);
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
					List<Handover> temp = HandoverRepoistory.getall().Where(a => a.user.Id == UserID).ToList();
					List<HandoverExcelDTO> newTemp = new List<HandoverExcelDTO>();
					foreach (Handover Handover in temp)
					{
						HandoverExcelDTO HandoverDTO = new HandoverExcelDTO();
						HandoverDTO.RigNo = Handover.Rig.Number;
						HandoverDTO.ShiftDateFrom = Handover.ShiftDateFrom;
						HandoverDTO.ShiftDateTo = Handover.ShiftDateTo;
						HandoverDTO.WellName = Handover.WellName;
						HandoverDTO.Client = Handover.Client;
						HandoverDTO.LeavingEmpCode = Handover.LeavingEmpCode;
						HandoverDTO.LeavingEmpName = Handover.LeavingEmpName;
						HandoverDTO.ComingEmpCode = Handover.ComingEmpCode;
						HandoverDTO.ComingEmpName = Handover.ComingEmpName;
						HandoverDTO.StopCards = Handover.StopCards;
						HandoverDTO.MonthlyStopCards = Handover.MonthlyStopCards;
						HandoverDTO.OpenStopCards = Handover.OpenStopCards;
						HandoverDTO.Drills = Handover.Drills;
						HandoverDTO.MonthlyDrills = Handover.MonthlyDrills;
						HandoverDTO.SafetyAlerts = Handover.SafetyAlerts;
						HandoverDTO.MonthlySafetyAlerts = Handover.MonthlySafetyAlerts;
						HandoverDTO.WeeklyInspection = Handover.WeeklyInspection;
						HandoverDTO.InternalAudit = Handover.InternalAudit;
						HandoverDTO.ExternalAudit = Handover.ExternalAudit;
						HandoverDTO.MedicalReport = Handover.MedicalReport;
						HandoverDTO.TrainingMatrix = Handover.TrainingMatrix;
						HandoverDTO.RigMove = Handover.RigMove;
						HandoverDTO.IncidentReport = Handover.IncidentReport;
						HandoverDTO.TrackingSheetClosedPoints = Handover.TrackingSheetClosedPoints;
						HandoverDTO.ShiftBrief = Handover.ShiftBrief;
						HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
						HandoverDTO.userName = Handover.user.UserName;
						HandoverDTO.PotentialHazardReport = Handover.PotentialHazardReport;
						if (Handover.ShiftDrillTypes.Any())
						{
							foreach (var item in Handover.ShiftDrillTypes)
							{
								ShiftDrillTypesExcelDTO shiftDrillTypesDTO = new ShiftDrillTypesExcelDTO();
								shiftDrillTypesDTO.Date = item.Date;
								shiftDrillTypesDTO.DrillType = item.DrillType;
								HandoverDTO.ShiftDrillTypes.Add(shiftDrillTypesDTO);
							}
						}
						if (Handover.Visits.Any())
						{
							foreach (var item in Handover.Visits)
							{
								VisitsExcelDTO visitsDTO = new VisitsExcelDTO();
								visitsDTO.Date = item.Date;
								visitsDTO.VisitName = item.VisitName;
								HandoverDTO.Visits.Add(visitsDTO);
							}
						}
						foreach (var item in Handover.HSEInventory)
						{
							HSEInventoryExcelDTO hseInventoryDTO = new HSEInventoryExcelDTO();
							hseInventoryDTO.Item = item.Item;
							hseInventoryDTO.StockAtStorage = item.StockAtStorage;
							hseInventoryDTO.ReleasedFromStorage = item.ReleasedFromStorage;
							hseInventoryDTO.NewlyRecieved = item.NewlyRecieved;
							HandoverDTO.HSEInventory.Add(hseInventoryDTO);
						}
						foreach (var item in Handover.HSEEquipment)
						{
							HSEEquipmentExcelDTO hseEquipmentDTO = new HSEEquipmentExcelDTO();
							hseEquipmentDTO.Item = item.Item;
							hseEquipmentDTO.OnSite = item.OnSite;
							hseEquipmentDTO.SentForMaintenance = item.SentForMaintenance;
							HandoverDTO.HSEEquipment.Add(hseEquipmentDTO);
						}
						if (Handover.MaterialRequested.Any())
						{
							foreach (var item in Handover.MaterialRequested)
							{
								MaterialRequestedExcelDTO materialRequestedDTO = new MaterialRequestedExcelDTO();
								materialRequestedDTO.PR = item.PR;
								materialRequestedDTO.RequiredItem = item.RequiredItem;
								HandoverDTO.MaterialRequested.Add(materialRequestedDTO);
							}
						}
						newTemp.Add(HandoverDTO);
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

		[HttpGet("ByPage/{page:int}")]
		public PageResult<HandoverResponseDTO> GettAllHandoverByPage(string UserId, string UserRole, int? page, int pagesize = 10)
		{
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<Handover> temp = HandoverRepoistory.getall();
					List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
					foreach (Handover Handover in temp)
					{
						HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
						HandoverDTO.Id = Handover.Id;
						HandoverDTO.RigNo = Handover.Rig.Number;
						HandoverDTO.ShiftDateFrom = Handover.ShiftDateFrom;
						HandoverDTO.ShiftDateTo = Handover.ShiftDateTo;
						HandoverDTO.WellName = Handover.WellName;
						HandoverDTO.Client = Handover.Client;
						HandoverDTO.LeavingEmpCode = Handover.LeavingEmpCode;
						HandoverDTO.LeavingEmpName = Handover.LeavingEmpName;
						HandoverDTO.ComingEmpCode = Handover.ComingEmpCode;
						HandoverDTO.ComingEmpName = Handover.ComingEmpName;
						HandoverDTO.StopCards = Handover.StopCards;
						HandoverDTO.MonthlyStopCards = Handover.MonthlyStopCards;
						HandoverDTO.OpenStopCards = Handover.OpenStopCards;
						HandoverDTO.Drills = Handover.Drills;
						HandoverDTO.MonthlyDrills = Handover.MonthlyDrills;
						HandoverDTO.SafetyAlerts = Handover.SafetyAlerts;
						HandoverDTO.MonthlySafetyAlerts = Handover.MonthlySafetyAlerts;
						HandoverDTO.WeeklyInspection = Handover.WeeklyInspection;
						HandoverDTO.InternalAudit = Handover.InternalAudit;
						HandoverDTO.ExternalAudit = Handover.ExternalAudit;
						HandoverDTO.MedicalReport = Handover.MedicalReport;
						HandoverDTO.TrainingMatrix = Handover.TrainingMatrix;
						HandoverDTO.RigMove = Handover.RigMove;
						HandoverDTO.IncidentReport = Handover.IncidentReport;
						HandoverDTO.TrackingSheetClosedPoints = Handover.TrackingSheetClosedPoints;
						HandoverDTO.ShiftBrief = Handover.ShiftBrief;
						HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
						HandoverDTO.userName = Handover.user.UserName;
						HandoverDTO.PotentialHazardReport = Handover.PotentialHazardReport;
						if (Handover.ShiftDrillTypes.Any())
						{
							foreach (var item in Handover.ShiftDrillTypes)
							{
								ShiftDrillTypesDTO shiftDrillTypesDTO = new ShiftDrillTypesDTO();
								shiftDrillTypesDTO.Id = item.Id;
								shiftDrillTypesDTO.Date = item.Date;
								shiftDrillTypesDTO.DrillType = item.DrillType;
								shiftDrillTypesDTO.HandoverId = item.HandoverId;
								shiftDrillTypesDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.ShiftDrillTypes.Add(shiftDrillTypesDTO);
							}
						}
						if (Handover.Visits.Any())
						{
							foreach (var item in Handover.Visits)
							{
								VisitsDTO visitsDTO = new VisitsDTO();
								visitsDTO.Id = item.Id;
								visitsDTO.Date = item.Date;
								visitsDTO.VisitName = item.VisitName;
								visitsDTO.HandoverId = item.HandoverId;
								visitsDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.Visits.Add(visitsDTO);
							}
						}
						foreach (var item in Handover.HSEInventory)
						{
							HSEInventoryDTO hseInventoryDTO = new HSEInventoryDTO();
							hseInventoryDTO.Id = item.Id;
							hseInventoryDTO.Item = item.Item;
							hseInventoryDTO.StockAtStorage = item.StockAtStorage;
							hseInventoryDTO.ReleasedFromStorage = item.ReleasedFromStorage;
							hseInventoryDTO.NewlyRecieved = item.NewlyRecieved;
							hseInventoryDTO.HandoverId = item.HandoverId;
							hseInventoryDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.HSEInventory.Add(hseInventoryDTO);
						}
						foreach (var item in Handover.HSEEquipment)
						{
							HSEEquipmentDTO hseEquipmentDTO = new HSEEquipmentDTO();
							hseEquipmentDTO.Id = item.Id;
							hseEquipmentDTO.Item = item.Item;
							hseEquipmentDTO.OnSite = item.OnSite;
							hseEquipmentDTO.SentForMaintenance = item.SentForMaintenance;
							hseEquipmentDTO.HandoverId = item.HandoverId;
							hseEquipmentDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.HSEEquipment.Add(hseEquipmentDTO);
						}
						if (Handover.MaterialRequested.Any())
						{
							foreach (var item in Handover.MaterialRequested)
							{
								MaterialRequestedDTO materialRequestedDTO = new MaterialRequestedDTO();
								materialRequestedDTO.Id = item.Id;
								materialRequestedDTO.PR = item.PR;
								materialRequestedDTO.RequiredItem = item.RequiredItem;
								materialRequestedDTO.HandoverId = item.HandoverId;
								materialRequestedDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.MaterialRequested.Add(materialRequestedDTO);
							}
						}
						newTemp.Add(HandoverDTO);
						//result.Data = prod;
					}


					float countDetails = HandoverRepoistory.getall().Count();
					var result = new PageResult<HandoverResponseDTO>
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
					List<Handover> temp = HandoverRepoistory.getall().Where(a => a.user.Id == UserId).ToList();
					List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
					foreach (Handover Handover in temp)
					{
						HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
						HandoverDTO.Id = Handover.Id;
						HandoverDTO.RigNo = Handover.Rig.Number;
						HandoverDTO.ShiftDateFrom = Handover.ShiftDateFrom;
						HandoverDTO.ShiftDateTo = Handover.ShiftDateTo;
						HandoverDTO.WellName = Handover.WellName;
						HandoverDTO.Client = Handover.Client;
						HandoverDTO.LeavingEmpCode = Handover.LeavingEmpCode;
						HandoverDTO.LeavingEmpName = Handover.LeavingEmpName;
						HandoverDTO.ComingEmpCode = Handover.ComingEmpCode;
						HandoverDTO.ComingEmpName = Handover.ComingEmpName;
						HandoverDTO.StopCards = Handover.StopCards;
						HandoverDTO.MonthlyStopCards = Handover.MonthlyStopCards;
						HandoverDTO.OpenStopCards = Handover.OpenStopCards;
						HandoverDTO.Drills = Handover.Drills;
						HandoverDTO.MonthlyDrills = Handover.MonthlyDrills;
						HandoverDTO.SafetyAlerts = Handover.SafetyAlerts;
						HandoverDTO.MonthlySafetyAlerts = Handover.MonthlySafetyAlerts;
						HandoverDTO.WeeklyInspection = Handover.WeeklyInspection;
						HandoverDTO.InternalAudit = Handover.InternalAudit;
						HandoverDTO.ExternalAudit = Handover.ExternalAudit;
						HandoverDTO.MedicalReport = Handover.MedicalReport;
						HandoverDTO.TrainingMatrix = Handover.TrainingMatrix;
						HandoverDTO.RigMove = Handover.RigMove;
						HandoverDTO.IncidentReport = Handover.IncidentReport;
						HandoverDTO.TrackingSheetClosedPoints = Handover.TrackingSheetClosedPoints;
						HandoverDTO.ShiftBrief = Handover.ShiftBrief;
						HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
						HandoverDTO.userName = Handover.user.UserName;
						HandoverDTO.PotentialHazardReport = Handover.PotentialHazardReport;
						if (Handover.ShiftDrillTypes.Any())
						{
							foreach (var item in Handover.ShiftDrillTypes)
							{
								ShiftDrillTypesDTO shiftDrillTypesDTO = new ShiftDrillTypesDTO();
								shiftDrillTypesDTO.Id = item.Id;
								shiftDrillTypesDTO.Date = item.Date;
								shiftDrillTypesDTO.DrillType = item.DrillType;
								shiftDrillTypesDTO.HandoverId = item.HandoverId;
								shiftDrillTypesDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.ShiftDrillTypes.Add(shiftDrillTypesDTO);
							}
						}
						if (Handover.Visits.Any())
						{
							foreach (var item in Handover.Visits)
							{
								VisitsDTO visitsDTO = new VisitsDTO();
								visitsDTO.Id = item.Id;
								visitsDTO.Date = item.Date;
								visitsDTO.VisitName = item.VisitName;
								visitsDTO.HandoverId = item.HandoverId;
								visitsDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.Visits.Add(visitsDTO);
							}
						}
						foreach (var item in Handover.HSEInventory)
						{
							HSEInventoryDTO hseInventoryDTO = new HSEInventoryDTO();
							hseInventoryDTO.Id = item.Id;
							hseInventoryDTO.Item = item.Item;
							hseInventoryDTO.StockAtStorage = item.StockAtStorage;
							hseInventoryDTO.ReleasedFromStorage = item.ReleasedFromStorage;
							hseInventoryDTO.NewlyRecieved = item.NewlyRecieved;
							hseInventoryDTO.HandoverId = item.HandoverId;
							hseInventoryDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.HSEInventory.Add(hseInventoryDTO);
						}
						foreach (var item in Handover.HSEEquipment)
						{
							HSEEquipmentDTO hseEquipmentDTO = new HSEEquipmentDTO();
							hseEquipmentDTO.Id = item.Id;
							hseEquipmentDTO.Item = item.Item;
							hseEquipmentDTO.OnSite = item.OnSite;
							hseEquipmentDTO.SentForMaintenance = item.SentForMaintenance;
							hseEquipmentDTO.HandoverId = item.HandoverId;
							hseEquipmentDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.HSEEquipment.Add(hseEquipmentDTO);
						}
						if (Handover.MaterialRequested.Any())
						{
							foreach (var item in Handover.MaterialRequested)
							{
								MaterialRequestedDTO materialRequestedDTO = new MaterialRequestedDTO();
								materialRequestedDTO.Id = item.Id;
								materialRequestedDTO.PR = item.PR;
								materialRequestedDTO.RequiredItem = item.RequiredItem;
								materialRequestedDTO.HandoverId = item.HandoverId;
								materialRequestedDTO.IsDeleted = item.IsDeleted;
								HandoverDTO.MaterialRequested.Add(materialRequestedDTO);
							}
						}
						newTemp.Add(HandoverDTO);
						//result.Data = prod;
					}

					float countDetails = HandoverRepoistory.getall().Where(a => a.user.Id == UserId).Count();
					var result = new PageResult<HandoverResponseDTO>
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
				return new PageResult<HandoverResponseDTO>();

			}
			return new PageResult<HandoverResponseDTO>();
		}


		[HttpGet("GetDataById/{ID:int}")]
		public ActionResult<ResultDTO> GetAllWithDataByID(int ID, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();
			if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
			{
				Handover Handover = HandoverRepoistory.getall().FirstOrDefault(a => a.Id == ID);
				if (Handover != null)
				{
					HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
					HandoverDTO.Id = Handover.Id;
					HandoverDTO.RigNo = Handover.Rig.Number;
					HandoverDTO.ShiftDateFrom = Handover.ShiftDateFrom;
					HandoverDTO.ShiftDateTo = Handover.ShiftDateTo;
					HandoverDTO.WellName = Handover.WellName;
					HandoverDTO.Client = Handover.Client;
					HandoverDTO.LeavingEmpCode = Handover.LeavingEmpCode;
					HandoverDTO.LeavingEmpName = Handover.LeavingEmpName;
					HandoverDTO.ComingEmpCode = Handover.ComingEmpCode;
					HandoverDTO.ComingEmpName = Handover.ComingEmpName;
					HandoverDTO.StopCards = Handover.StopCards;
					HandoverDTO.MonthlyStopCards = Handover.MonthlyStopCards;
					HandoverDTO.OpenStopCards = Handover.OpenStopCards;
					HandoverDTO.Drills = Handover.Drills;
					HandoverDTO.MonthlyDrills = Handover.MonthlyDrills;
					HandoverDTO.SafetyAlerts = Handover.SafetyAlerts;
					HandoverDTO.MonthlySafetyAlerts = Handover.MonthlySafetyAlerts;
					HandoverDTO.WeeklyInspection = Handover.WeeklyInspection;
					HandoverDTO.InternalAudit = Handover.InternalAudit;
					HandoverDTO.ExternalAudit = Handover.ExternalAudit;
					HandoverDTO.MedicalReport = Handover.MedicalReport;
					HandoverDTO.TrainingMatrix = Handover.TrainingMatrix;
					HandoverDTO.RigMove = Handover.RigMove;
					HandoverDTO.IncidentReport = Handover.IncidentReport;
					HandoverDTO.TrackingSheetClosedPoints = Handover.TrackingSheetClosedPoints;
					HandoverDTO.ShiftBrief = Handover.ShiftBrief;
					HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
					HandoverDTO.userName = Handover.user.UserName;
					HandoverDTO.PotentialHazardReport = Handover.PotentialHazardReport;
					if (Handover.ShiftDrillTypes.Any())
					{
						foreach (var item in Handover.ShiftDrillTypes)
						{
							ShiftDrillTypesDTO shiftDrillTypesDTO = new ShiftDrillTypesDTO();
							shiftDrillTypesDTO.Id = item.Id;
							shiftDrillTypesDTO.Date = item.Date;
							shiftDrillTypesDTO.DrillType = item.DrillType;
							shiftDrillTypesDTO.HandoverId = item.HandoverId;
							shiftDrillTypesDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.ShiftDrillTypes.Add(shiftDrillTypesDTO);
						}
					}
					if (Handover.Visits.Any())
					{
						foreach (var item in Handover.Visits)
						{
							VisitsDTO visitsDTO = new VisitsDTO();
							visitsDTO.Id = item.Id;
							visitsDTO.Date = item.Date;
							visitsDTO.VisitName = item.VisitName;
							visitsDTO.HandoverId = item.HandoverId;
							visitsDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.Visits.Add(visitsDTO);
						}
					}
					foreach (var item in Handover.HSEInventory)
					{
						HSEInventoryDTO hseInventoryDTO = new HSEInventoryDTO();
						hseInventoryDTO.Id = item.Id;
						hseInventoryDTO.Item = item.Item;
						hseInventoryDTO.StockAtStorage = item.StockAtStorage;
						hseInventoryDTO.ReleasedFromStorage = item.ReleasedFromStorage;
						hseInventoryDTO.NewlyRecieved = item.NewlyRecieved;
						hseInventoryDTO.HandoverId = item.HandoverId;
						hseInventoryDTO.IsDeleted = item.IsDeleted;
						HandoverDTO.HSEInventory.Add(hseInventoryDTO);
					}
					foreach (var item in Handover.HSEEquipment)
					{
						HSEEquipmentDTO hseEquipmentDTO = new HSEEquipmentDTO();
						hseEquipmentDTO.Id = item.Id;
						hseEquipmentDTO.Item = item.Item;
						hseEquipmentDTO.OnSite = item.OnSite;
						hseEquipmentDTO.SentForMaintenance = item.SentForMaintenance;
						hseEquipmentDTO.HandoverId = item.HandoverId;
						hseEquipmentDTO.IsDeleted = item.IsDeleted;
						HandoverDTO.HSEEquipment.Add(hseEquipmentDTO);
					}
					if (Handover.MaterialRequested.Any())
					{
						foreach (var item in Handover.MaterialRequested)
						{
							MaterialRequestedDTO materialRequestedDTO = new MaterialRequestedDTO();
							materialRequestedDTO.Id = item.Id;
							materialRequestedDTO.PR = item.PR;
							materialRequestedDTO.RequiredItem = item.RequiredItem;
							materialRequestedDTO.HandoverId = item.HandoverId;
							materialRequestedDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.MaterialRequested.Add(materialRequestedDTO);
						}
					}
					
					result.Message = "Success";
					result.Statescode = 200;
					result.Data = HandoverDTO;

					return result;
				}
			}
			else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
			{
				Handover Handover = HandoverRepoistory.getall().FirstOrDefault(a => a.Id == ID && a.user.Id == UserId);
				if (Handover != null)
				{
					HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
					HandoverDTO.Id = Handover.Id;
					HandoverDTO.RigNo = Handover.Rig.Number;
					HandoverDTO.ShiftDateFrom = Handover.ShiftDateFrom;
					HandoverDTO.ShiftDateTo = Handover.ShiftDateTo;
					HandoverDTO.WellName = Handover.WellName;
					HandoverDTO.Client = Handover.Client;
					HandoverDTO.LeavingEmpCode = Handover.LeavingEmpCode;
					HandoverDTO.LeavingEmpName = Handover.LeavingEmpName;
					HandoverDTO.ComingEmpCode = Handover.ComingEmpCode;
					HandoverDTO.ComingEmpName = Handover.ComingEmpName;
					HandoverDTO.StopCards = Handover.StopCards;
					HandoverDTO.MonthlyStopCards = Handover.MonthlyStopCards;
					HandoverDTO.OpenStopCards = Handover.OpenStopCards;
					HandoverDTO.Drills = Handover.Drills;
					HandoverDTO.MonthlyDrills = Handover.MonthlyDrills;
					HandoverDTO.SafetyAlerts = Handover.SafetyAlerts;
					HandoverDTO.MonthlySafetyAlerts = Handover.MonthlySafetyAlerts;
					HandoverDTO.WeeklyInspection = Handover.WeeklyInspection;
					HandoverDTO.InternalAudit = Handover.InternalAudit;
					HandoverDTO.ExternalAudit = Handover.ExternalAudit;
					HandoverDTO.MedicalReport = Handover.MedicalReport;
					HandoverDTO.TrainingMatrix = Handover.TrainingMatrix;
					HandoverDTO.RigMove = Handover.RigMove;
					HandoverDTO.IncidentReport = Handover.IncidentReport;
					HandoverDTO.TrackingSheetClosedPoints = Handover.TrackingSheetClosedPoints;
					HandoverDTO.ShiftBrief = Handover.ShiftBrief;
					HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
					HandoverDTO.userName = Handover.user.UserName;
					HandoverDTO.PotentialHazardReport = Handover.PotentialHazardReport;
					if (Handover.ShiftDrillTypes.Any())
					{
						foreach (var item in Handover.ShiftDrillTypes)
						{
							ShiftDrillTypesDTO shiftDrillTypesDTO = new ShiftDrillTypesDTO();
							shiftDrillTypesDTO.Id = item.Id;
							shiftDrillTypesDTO.Date = item.Date;
							shiftDrillTypesDTO.DrillType = item.DrillType;
							shiftDrillTypesDTO.HandoverId = item.HandoverId;
							shiftDrillTypesDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.ShiftDrillTypes.Add(shiftDrillTypesDTO);
						}
					}
					if (Handover.Visits.Any())
					{
						foreach (var item in Handover.Visits)
						{
							VisitsDTO visitsDTO = new VisitsDTO();
							visitsDTO.Id = item.Id;
							visitsDTO.Date = item.Date;
							visitsDTO.VisitName = item.VisitName;
							visitsDTO.HandoverId = item.HandoverId;
							visitsDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.Visits.Add(visitsDTO);
						}
					}
					foreach (var item in Handover.HSEInventory)
					{
						HSEInventoryDTO hseInventoryDTO = new HSEInventoryDTO();
						hseInventoryDTO.Id = item.Id;
						hseInventoryDTO.Item = item.Item;
						hseInventoryDTO.StockAtStorage = item.StockAtStorage;
						hseInventoryDTO.ReleasedFromStorage = item.ReleasedFromStorage;
						hseInventoryDTO.NewlyRecieved = item.NewlyRecieved;
						hseInventoryDTO.HandoverId = item.HandoverId;
						hseInventoryDTO.IsDeleted = item.IsDeleted;
						HandoverDTO.HSEInventory.Add(hseInventoryDTO);
					}
					foreach (var item in Handover.HSEEquipment)
					{
						HSEEquipmentDTO hseEquipmentDTO = new HSEEquipmentDTO();
						hseEquipmentDTO.Id = item.Id;
						hseEquipmentDTO.Item = item.Item;
						hseEquipmentDTO.OnSite = item.OnSite;
						hseEquipmentDTO.SentForMaintenance = item.SentForMaintenance;
						hseEquipmentDTO.HandoverId = item.HandoverId;
						hseEquipmentDTO.IsDeleted = item.IsDeleted;
						HandoverDTO.HSEEquipment.Add(hseEquipmentDTO);
					}
					if (Handover.MaterialRequested.Any())
					{
						foreach (var item in Handover.MaterialRequested)
						{
							MaterialRequestedDTO materialRequestedDTO = new MaterialRequestedDTO();
							materialRequestedDTO.Id = item.Id;
							materialRequestedDTO.PR = item.PR;
							materialRequestedDTO.RequiredItem = item.RequiredItem;
							materialRequestedDTO.HandoverId = item.HandoverId;
							materialRequestedDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.MaterialRequested.Add(materialRequestedDTO);
						}
					}


					result.Message = "Success";
					result.Statescode = 200;
					result.Data = HandoverDTO;

					return result;
				}
			}

			result.Statescode = 404;
			result.Message = "data not found";
			return result;
		}


		//	[HttpGet("GetDataByDate/{date:DateTime}")]
		//	public ActionResult<ResultDTO> GetAllWithDataByDate(DateTime date, string UserId, string UserRole)
		//	{
		//		ResultDTO result = new ResultDTO();

		//		try
		//		{
		//			if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
		//			{
		//				List<Handover> temp = HandoverRepoistory.getall().Where(a => a.DateRaisedBy == date).ToList();
		//				List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
		//				foreach (Handover Handover in temp)
		//				{
		//					HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
		//					HandoverDTO.Id = Handover.Id;
		//					//HandoverDTO.Rig = Handover.Rig.Number;
		//					HandoverDTO.Title = Handover.Title;
		//					HandoverDTO.FormResponsability = Handover.HandoverResponsability.ResponsibilityName;
		//					HandoverDTO.ReportNo = Handover.ReportNo;
		//					HandoverDTO.DescriptionOfNonConformity = Handover.DescriptionOfNonConformity;
		//					HandoverDTO.Standard = Handover.Standard.StandardName;
		//					HandoverDTO.ClauseNo = Handover.ClauseNo;
		//					HandoverDTO.ObjectiveEvidence = Handover.ObjectiveEvidence;
		//					foreach (var item in Handover.HandoverAndObservation)
		//					{
		//						string observation = item.HandoverObservation.Observation;
		//						HandoverDTO.HandoverAndObservation.Add(observation);

		//					}
		//					foreach (var item in Handover.HandoverAndRootCauses)
		//					{
		//						string cause = item.RootCauses.CauseName;
		//						HandoverDTO.HandoverAndRootCauses.Add(cause);

		//					}
		//					HandoverDTO.IfOtherObservation = Handover.IfOtherObservation;
		//					HandoverDTO.UpdateRisk = Handover.UpdateRisk;
		//					HandoverDTO.IfUpdate = Handover.IfUpdate;
		//					HandoverDTO.ManagementOfChange = Handover.ManagementOfChange;
		//					HandoverDTO.IfManagementOfChange = Handover.IfManagementOfChange;
		//					HandoverDTO.NameRasiedBy = Handover.NameRasiedBy;
		//					//HandoverDTO.SigRasiedBy = Handover.SigRasiedBy;
		//					HandoverDTO.DateRaisedBy = Handover.DateRaisedBy;
		//					HandoverDTO.IfOtherRootCause = Handover.IfOtherRootCause;
		//					foreach (var item in Handover.HandoverDataTable)
		//					{
		//						HandoverDataTable Data = new HandoverDataTable();
		//						Data.Id = item.Id;
		//						Data.SN = item.SN;
		//						Data.HandoverSelected = item.HandoverSelected;
		//						Data.Action = item.Action;
		//						Data.Responsible = item.Responsible;
		//						Data.SuggestedDate = item.SuggestedDate;
		//						Data.AchievementDate = item.AchievementDate;
		//						Data.Status = item.Status;
		//						Data.HandoverId = item.HandoverId;
		//						Data.FollowUpAudit = item.FollowUpAudit;
		//						Data.IsDeleted = item.IsDeleted;
		//						HandoverDTO.HandoverDataTable.Add(Data);
		//					};
		//					HandoverDTO.Comment = Handover.Comment;
		//					HandoverDTO.Q_ManagerSig = Handover.Q_ManagerSig;
		//					//HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
		//					HandoverDTO.userName = Handover.user.UserName;
		//					HandoverDTO.FormStatus = Handover.FormStatus;
		//					List<HandoverImages> HandoverImages = HandoverImagesRepo.getall().Where(p => p.HandoverId == Handover.Id).ToList();
		//					foreach (var item in HandoverImages)
		//					{
		//						string FileName = item.FileName;
		//						HandoverDTO.Images.Add(FileName);

		//					}
		//					newTemp.Add(HandoverDTO);
		//					//result.Data = prod;
		//				}
		//				if (newTemp != null)
		//				{
		//					result.Message = "Success";
		//					result.Statescode = 200;
		//					result.Data = newTemp;

		//					return result;
		//				}
		//			}
		//			else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
		//			{
		//				List<Handover> temp = HandoverRepoistory.getall().Where(a => a.userID == UserId && a.DateRaisedBy == date).ToList();
		//				List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
		//				foreach (Handover Handover in temp)
		//				{
		//					HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
		//					HandoverDTO.Id = Handover.Id;
		//					//HandoverDTO.Rig = Handover.Rig.Number;
		//					HandoverDTO.Title = Handover.Title;
		//					HandoverDTO.FormResponsability = Handover.HandoverResponsability.ResponsibilityName;
		//					HandoverDTO.ReportNo = Handover.ReportNo;
		//					HandoverDTO.DescriptionOfNonConformity = Handover.DescriptionOfNonConformity;
		//					HandoverDTO.Standard = Handover.Standard.StandardName;
		//					HandoverDTO.ClauseNo = Handover.ClauseNo;
		//					HandoverDTO.ObjectiveEvidence = Handover.ObjectiveEvidence;
		//					foreach (var item in Handover.HandoverAndObservation)
		//					{
		//						string observation = item.HandoverObservation.Observation;
		//						HandoverDTO.HandoverAndObservation.Add(observation);

		//					}
		//					foreach (var item in Handover.HandoverAndRootCauses)
		//					{
		//						string cause = item.RootCauses.CauseName;
		//						HandoverDTO.HandoverAndRootCauses.Add(cause);

		//					}
		//					HandoverDTO.IfOtherObservation = Handover.IfOtherObservation;
		//					HandoverDTO.UpdateRisk = Handover.UpdateRisk;
		//					HandoverDTO.IfUpdate = Handover.IfUpdate;
		//					HandoverDTO.ManagementOfChange = Handover.ManagementOfChange;
		//					HandoverDTO.IfManagementOfChange = Handover.IfManagementOfChange;
		//					HandoverDTO.NameRasiedBy = Handover.NameRasiedBy;
		//					//HandoverDTO.SigRasiedBy = Handover.SigRasiedBy;
		//					HandoverDTO.DateRaisedBy = Handover.DateRaisedBy;
		//					HandoverDTO.IfOtherRootCause = Handover.IfOtherRootCause;
		//					foreach (var item in Handover.HandoverDataTable)
		//					{
		//						HandoverDataTable Data = new HandoverDataTable();
		//						Data.Id = item.Id;
		//						Data.SN = item.SN;
		//						Data.HandoverSelected = item.HandoverSelected;
		//						Data.Action = item.Action;
		//						Data.Responsible = item.Responsible;
		//						Data.SuggestedDate = item.SuggestedDate;
		//						Data.AchievementDate = item.AchievementDate;
		//						Data.Status = item.Status;
		//						Data.HandoverId = item.HandoverId;
		//						Data.FollowUpAudit = item.FollowUpAudit;
		//						Data.IsDeleted = item.IsDeleted;
		//						HandoverDTO.HandoverDataTable.Add(Data);
		//					};
		//					HandoverDTO.Comment = Handover.Comment;
		//					HandoverDTO.Q_ManagerSig = Handover.Q_ManagerSig;
		//					//HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
		//					HandoverDTO.userName = Handover.user.UserName;
		//					HandoverDTO.FormStatus = Handover.FormStatus;
		//					List<HandoverImages> HandoverImages = HandoverImagesRepo.getall().Where(p => p.HandoverId == Handover.Id).ToList();
		//					foreach (var item in HandoverImages)
		//					{
		//						string FileName = item.FileName;
		//						HandoverDTO.Images.Add(FileName);

		//					}
		//					newTemp.Add(HandoverDTO);
		//					//result.Data = prod;
		//				}
		//				if (newTemp != null)
		//				{
		//					result.Message = "Success";
		//					result.Statescode = 200;
		//					result.Data = newTemp;

		//					return result;
		//				}
		//			}
		//		}
		//		catch (Exception ex)
		//		{
		//			result.Statescode = 404;
		//			result.Message = "data not found";
		//		}

		//		return result;

		//	}

		//	[HttpGet("GetDataByDateForAnalysis")]
		//	public ActionResult<ResultDTO> GetAllWithDataByDateForAnalysis(string UserId, string UserRole)
		//	{
		//		ResultDTO result = new ResultDTO();

		//		try
		//		{
		//			if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
		//			{
		//				var Handovers = HandoverRepoistory.getall()
		//				.Where(item => item.HandoverDataTable.Any(obs => obs.SuggestedDate.Value.Date < DateTime.Now.Date))
		//				.ToList();

		//				if (Handovers.Any())
		//				{
		//					var newTemp = Handovers.Select(Handover =>
		//					{
		//						var HandoverDTO = new HandoverResponseDTO
		//						{
		//							Id = Handover.Id,
		//							//Rig = Handover.Rig.Number,
		//							Title = Handover.Title,
		//							FormResponsability = Handover.HandoverResponsability.ResponsibilityName,
		//							ReportNo = Handover.ReportNo,
		//							DescriptionOfNonConformity = Handover.DescriptionOfNonConformity,
		//							Standard = Handover.Standard.StandardName,
		//							ClauseNo = Handover.ClauseNo,
		//							ObjectiveEvidence = Handover.ObjectiveEvidence,
		//							HandoverAndObservation = Handover.HandoverAndObservation.Select(item => item.HandoverObservation.Observation).ToList(),
		//							HandoverAndRootCauses = Handover.HandoverAndRootCauses.Select(item => item.RootCauses.CauseName).ToList(),
		//							IfOtherObservation = Handover.IfOtherObservation,
		//							UpdateRisk = Handover.UpdateRisk,
		//							IfUpdate = Handover.IfUpdate,
		//							ManagementOfChange = Handover.ManagementOfChange,
		//							IfManagementOfChange = Handover.IfManagementOfChange,
		//							NameRasiedBy = Handover.NameRasiedBy,
		//							DateRaisedBy = Handover.DateRaisedBy,
		//							IfOtherRootCause = Handover.IfOtherRootCause,
		//							HandoverDataTable = Handover.HandoverDataTable.Select(item => new HandoverDataTable
		//							{
		//								Id = item.Id,
		//								SN = item.SN,
		//								HandoverSelected = item.HandoverSelected,
		//								Action = item.Action,
		//								Responsible = item.Responsible,
		//								SuggestedDate = item.SuggestedDate,
		//								AchievementDate = item.AchievementDate,
		//								Status = item.Status,
		//								HandoverId = item.HandoverId,
		//								FollowUpAudit = item.FollowUpAudit,
		//								IsDeleted = item.IsDeleted
		//							}).ToList(),
		//							Comment = Handover.Comment,
		//							Q_ManagerSig = Handover.Q_ManagerSig,
		//							//QHSEEngineer = Handover.QHSEEngineer,
		//							userName = Handover.user.UserName,
		//							FormStatus = Handover.FormStatus,
		//							Images = HandoverImagesRepo.getall().Where(p => p.HandoverId == Handover.Id).Select(item => item.FileName).ToList()
		//						};

		//						return HandoverDTO;
		//					}).ToList();

		//					result.Message = "Success";
		//					result.Statescode = 200;
		//					result.Data = newTemp;

		//					return result;
		//				}
		//				else
		//				{
		//					result.Message = "No Data";
		//					result.Statescode = 201;
		//					result.Data = new List<HandoverDTO>();

		//					return result;
		//				}

		//				//List<Handover> temp = HandoverRepoistory.getall();
		//				//List<Handover> Handovers = new List<Handover>();
		//				//foreach(var item in temp)
		//				//{
		//				//	if (item.HandoverDataTable.Count() > 0)
		//				//	{
		//				//		if(item.HandoverDataTable.Any(obs => obs.SuggestedDate.Value.Date < DateTime.Now.Date))
		//				//		{
		//				//			Handovers.Add(item);
		//				//		}
		//				//	}
		//				//}

		//				//if (Handovers.Count() > 0)
		//				//{
		//				//	List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
		//				//	foreach (Handover Handover in Handovers)
		//				//	{
		//				//		HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
		//				//		HandoverDTO.Id = Handover.Id;
		//				//		HandoverDTO.Rig = Handover.Rig.Number;
		//				//		HandoverDTO.Title = Handover.Title;
		//				//		HandoverDTO.FormResponsability = Handover.HandoverResponsability.ResponsibilityName;
		//				//		HandoverDTO.ReportNo = Handover.ReportNo;
		//				//		HandoverDTO.DescriptionOfNonConformity = Handover.DescriptionOfNonConformity;
		//				//		HandoverDTO.Standard = Handover.Standard.StandardName;
		//				//		HandoverDTO.ClauseNo = Handover.ClauseNo;
		//				//		HandoverDTO.ObjectiveEvidence = Handover.ObjectiveEvidence;
		//				//		foreach (var item in Handover.HandoverAndObservation)
		//				//		{
		//				//			string observation = item.HandoverObservation.Observation;
		//				//			HandoverDTO.HandoverAndObservation.Add(observation);

		//				//		}
		//				//		foreach (var item in Handover.HandoverAndRootCauses)
		//				//		{
		//				//			string cause = item.RootCauses.CauseName;
		//				//			HandoverDTO.HandoverAndRootCauses.Add(cause);

		//				//		}
		//				//		HandoverDTO.IfOtherObservation = Handover.IfOtherObservation;
		//				//		HandoverDTO.UpdateRisk = Handover.UpdateRisk;
		//				//		HandoverDTO.IfUpdate = Handover.IfUpdate;
		//				//		HandoverDTO.ManagementOfChange = Handover.ManagementOfChange;
		//				//		HandoverDTO.IfManagementOfChange = Handover.IfManagementOfChange;
		//				//		HandoverDTO.NameRasiedBy = Handover.NameRasiedBy;
		//				//		//HandoverDTO.SigRasiedBy = Handover.SigRasiedBy;
		//				//		HandoverDTO.DateRaisedBy = Handover.DateRaisedBy;
		//				//		HandoverDTO.IfOtherRootCause = Handover.IfOtherRootCause;
		//				//		foreach (var item in Handover.HandoverDataTable)
		//				//		{
		//				//			HandoverDataTable Data = new HandoverDataTable();
		//				//			Data.Id = item.Id;
		//				//			Data.SN = item.SN;
		//				//			Data.HandoverSelected = item.HandoverSelected;
		//				//			Data.Action = item.Action;
		//				//			Data.Responsible = item.Responsible;
		//				//			Data.SuggestedDate = item.SuggestedDate;
		//				//			Data.AchievementDate = item.AchievementDate;
		//				//			Data.Status = item.Status;
		//				//			Data.HandoverId = item.HandoverId;
		//				//			Data.FollowUpAudit = item.FollowUpAudit;
		//				//			Data.IsDeleted = item.IsDeleted;
		//				//			HandoverDTO.HandoverDataTable.Add(Data);
		//				//		};
		//				//		HandoverDTO.Comment = Handover.Comment;
		//				//		HandoverDTO.Q_ManagerSig = Handover.Q_ManagerSig;
		//				//		HandoverDTO.userName = Handover.user.UserName;
		//				//		HandoverDTO.FormStatus = Handover.FormStatus;
		//				//		List<HandoverImages> HandoverImages = HandoverImagesRepo.getall().Where(p => p.HandoverId == Handover.Id).ToList();
		//				//		foreach (var item in HandoverImages)
		//				//		{
		//				//			string FileName = item.FileName;
		//				//			HandoverDTO.Images.Add(FileName);

		//				//		}
		//				//		newTemp.Add(HandoverDTO);
		//				//		//result.Data = prod;
		//				//	}
		//				//	if (newTemp != null)
		//				//	{
		//				//		result.Message = "Success";
		//				//		result.Statescode = 200;
		//				//		result.Data = newTemp;

		//				//		return result;
		//				//	}
		//			}

		//			else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
		//			{
		//				var Handovers = HandoverRepoistory.getall()
		//				.Where(item => item.userID == UserId && item.HandoverDataTable.Any(obs => obs.SuggestedDate.Value.Date < DateTime.Now.Date))
		//				.ToList();

		//				if (Handovers.Any())
		//				{
		//					var newTemp = Handovers.Select(Handover =>
		//					{
		//						var HandoverDTO = new HandoverResponseDTO
		//						{
		//							Id = Handover.Id,
		//							//Rig = Handover.Rig.Number,
		//							Title = Handover.Title,
		//							FormResponsability = Handover.HandoverResponsability.ResponsibilityName,
		//							ReportNo = Handover.ReportNo,
		//							DescriptionOfNonConformity = Handover.DescriptionOfNonConformity,
		//							Standard = Handover.Standard.StandardName,
		//							ClauseNo = Handover.ClauseNo,
		//							ObjectiveEvidence = Handover.ObjectiveEvidence,
		//							HandoverAndObservation = Handover.HandoverAndObservation.Select(item => item.HandoverObservation.Observation).ToList(),
		//							HandoverAndRootCauses = Handover.HandoverAndRootCauses.Select(item => item.RootCauses.CauseName).ToList(),
		//							IfOtherObservation = Handover.IfOtherObservation,
		//							UpdateRisk = Handover.UpdateRisk,
		//							IfUpdate = Handover.IfUpdate,
		//							ManagementOfChange = Handover.ManagementOfChange,
		//							IfManagementOfChange = Handover.IfManagementOfChange,
		//							NameRasiedBy = Handover.NameRasiedBy,
		//							DateRaisedBy = Handover.DateRaisedBy,
		//							IfOtherRootCause = Handover.IfOtherRootCause,
		//							HandoverDataTable = Handover.HandoverDataTable.Select(item => new HandoverDataTable
		//							{
		//								Id = item.Id,
		//								SN = item.SN,
		//								HandoverSelected = item.HandoverSelected,
		//								Action = item.Action,
		//								Responsible = item.Responsible,
		//								SuggestedDate = item.SuggestedDate,
		//								AchievementDate = item.AchievementDate,
		//								Status = item.Status,
		//								HandoverId = item.HandoverId,
		//								FollowUpAudit = item.FollowUpAudit,
		//								IsDeleted = item.IsDeleted
		//							}).ToList(),
		//							Comment = Handover.Comment,
		//							Q_ManagerSig = Handover.Q_ManagerSig,
		//							//QHSEEngineer = Handover.QHSEEngineer,
		//							userName = Handover.user.UserName,
		//							FormStatus = Handover.FormStatus,
		//							Images = HandoverImagesRepo.getall().Where(p => p.HandoverId == Handover.Id).Select(item => item.FileName).ToList()
		//						};

		//						return HandoverDTO;
		//					}).ToList();

		//					result.Message = "Success";
		//					result.Statescode = 200;
		//					result.Data = newTemp;

		//					return result;
		//					//List<Handover> temp = HandoverRepoistory.getall().Where(a => a.userID == UserId && a.DateRaisedBy == date).ToList();
		//					//List<HandoverResponseDTO> newTemp = new List<HandoverResponseDTO>();
		//					//foreach (Handover Handover in temp)
		//					//{
		//					//	HandoverResponseDTO HandoverDTO = new HandoverResponseDTO();
		//					//	HandoverDTO.Id = Handover.Id;
		//					//	HandoverDTO.Rig = Handover.Rig.Number;
		//					//	HandoverDTO.Title = Handover.Title;
		//					//	HandoverDTO.FormResponsability = Handover.HandoverResponsability.ResponsibilityName;
		//					//	HandoverDTO.ReportNo = Handover.ReportNo;
		//					//	HandoverDTO.DescriptionOfNonConformity = Handover.DescriptionOfNonConformity;
		//					//	HandoverDTO.Standard = Handover.Standard.StandardName;
		//					//	HandoverDTO.ClauseNo = Handover.ClauseNo;
		//					//	HandoverDTO.ObjectiveEvidence = Handover.ObjectiveEvidence;
		//					//	foreach (var item in Handover.HandoverAndObservation)
		//					//	{
		//					//		string observation = item.HandoverObservation.Observation;
		//					//		HandoverDTO.HandoverAndObservation.Add(observation);

		//					//	}
		//					//	foreach (var item in Handover.HandoverAndRootCauses)
		//					//	{
		//					//		string cause = item.RootCauses.CauseName;
		//					//		HandoverDTO.HandoverAndRootCauses.Add(cause);

		//					//	}
		//					//	HandoverDTO.IfOtherObservation = Handover.IfOtherObservation;
		//					//	HandoverDTO.UpdateRisk = Handover.UpdateRisk;
		//					//	HandoverDTO.IfUpdate = Handover.IfUpdate;
		//					//	HandoverDTO.ManagementOfChange = Handover.ManagementOfChange;
		//					//	HandoverDTO.IfManagementOfChange = Handover.IfManagementOfChange;
		//					//	HandoverDTO.NameRasiedBy = Handover.NameRasiedBy;
		//					//	//HandoverDTO.SigRasiedBy = Handover.SigRasiedBy;
		//					//	HandoverDTO.DateRaisedBy = Handover.DateRaisedBy;
		//					//	HandoverDTO.IfOtherRootCause = Handover.IfOtherRootCause;
		//					//	foreach (var item in Handover.HandoverDataTable)
		//					//	{
		//					//		HandoverDataTable Data = new HandoverDataTable();
		//					//		Data.Id = item.Id;
		//					//		Data.SN = item.SN;
		//					//		Data.HandoverSelected = item.HandoverSelected;
		//					//		Data.Action = item.Action;
		//					//		Data.Responsible = item.Responsible;
		//					//		Data.SuggestedDate = item.SuggestedDate;
		//					//		Data.AchievementDate = item.AchievementDate;
		//					//		Data.Status = item.Status;
		//					//		Data.HandoverId = item.HandoverId;
		//					//		Data.FollowUpAudit = item.FollowUpAudit;
		//					//		Data.IsDeleted = item.IsDeleted;
		//					//		HandoverDTO.HandoverDataTable.Add(Data);
		//					//	};
		//					//	HandoverDTO.Comment = Handover.Comment;
		//					//	HandoverDTO.Q_ManagerSig = Handover.Q_ManagerSig;
		//					//	HandoverDTO.userName = Handover.user.UserName;
		//					//	HandoverDTO.FormStatus = Handover.FormStatus;
		//					//	List<HandoverImages> HandoverImages = HandoverImagesRepo.getall().Where(p => p.HandoverId == Handover.Id).ToList();
		//					//	foreach (var item in HandoverImages)
		//					//	{
		//					//		string FileName = item.FileName;
		//					//		HandoverDTO.Images.Add(FileName);

		//					//	}
		//					//	newTemp.Add(HandoverDTO);
		//					//	//result.Data = prod;
		//					//}
		//					//if (newTemp != null)
		//					//{
		//					//	result.Message = "Success";
		//					//	result.Statescode = 200;
		//					//	result.Data = newTemp;

		//					//	return result;
		//					//}
		//				}
		//				else
		//				{
		//					result.Message = "No Data";
		//					result.Statescode = 201;
		//					result.Data = new List<HandoverDTO>();

		//					return result;
		//				}
		//			}
		//		}
		//		catch (Exception ex)
		//		{
		//			result.Statescode = 404;
		//			result.Message = "data not found";
		//		}

		//		return result;

		//	}


		[HttpGet("{ID:int}")]
		public ActionResult<ResultDTO> GetByID(int ID, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					Handover Handover = HandoverRepoistory.getall().FirstOrDefault(a => a.Id == ID);
					HandoverDTO HandoverDTO = new HandoverDTO();
					HandoverDTO.Id = Handover.Id;
					HandoverDTO.RigId = Handover.RigId;
					HandoverDTO.ShiftDateFrom = Handover.ShiftDateFrom;
					HandoverDTO.ShiftDateTo = Handover.ShiftDateTo;
					HandoverDTO.WellName = Handover.WellName;
					HandoverDTO.Client = Handover.Client;
					HandoverDTO.LeavingEmpCode = Handover.LeavingEmpCode;
					HandoverDTO.LeavingEmpName = Handover.LeavingEmpName;
					HandoverDTO.ComingEmpCode = Handover.ComingEmpCode;
					HandoverDTO.ComingEmpName = Handover.ComingEmpName;
					HandoverDTO.StopCards = Handover.StopCards;
					HandoverDTO.MonthlyStopCards = Handover.MonthlyStopCards;
					HandoverDTO.OpenStopCards = Handover.OpenStopCards;
					HandoverDTO.Drills = Handover.Drills;
					HandoverDTO.MonthlyDrills = Handover.MonthlyDrills;
					HandoverDTO.SafetyAlerts = Handover.SafetyAlerts;
					HandoverDTO.MonthlySafetyAlerts = Handover.MonthlySafetyAlerts;
					HandoverDTO.WeeklyInspection = Handover.WeeklyInspection;
					HandoverDTO.InternalAudit = Handover.InternalAudit;
					HandoverDTO.ExternalAudit = Handover.ExternalAudit;
					HandoverDTO.MedicalReport = Handover.MedicalReport;
					HandoverDTO.TrainingMatrix = Handover.TrainingMatrix;
					HandoverDTO.RigMove = Handover.RigMove;
					HandoverDTO.IncidentReport = Handover.IncidentReport;
					HandoverDTO.TrackingSheetClosedPoints = Handover.TrackingSheetClosedPoints;
					HandoverDTO.ShiftBrief = Handover.ShiftBrief;
					HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
					HandoverDTO.userID = Handover.userID;
					HandoverDTO.PotentialHazardReport = Handover.PotentialHazardReport;
					if (Handover.ShiftDrillTypes.Any())
					{
						foreach (var item in Handover.ShiftDrillTypes)
						{
							ShiftDrillTypesDTO shiftDrillTypesDTO = new ShiftDrillTypesDTO();
							shiftDrillTypesDTO.Id = item.Id;
							shiftDrillTypesDTO.Date = item.Date;
							shiftDrillTypesDTO.DrillType = item.DrillType;
							shiftDrillTypesDTO.HandoverId = item.HandoverId;
							shiftDrillTypesDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.ShiftDrillTypes.Add(shiftDrillTypesDTO);
						}
					}
					if (Handover.Visits.Any())
					{
						foreach (var item in Handover.Visits)
						{
							VisitsDTO visitsDTO = new VisitsDTO();
							visitsDTO.Id = item.Id;
							visitsDTO.Date = item.Date;
							visitsDTO.VisitName = item.VisitName;
							visitsDTO.HandoverId = item.HandoverId;
							visitsDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.Visits.Add(visitsDTO);
						}
					}
					foreach (var item in Handover.HSEInventory)
					{
						HSEInventoryDTO hseInventoryDTO = new HSEInventoryDTO();
						hseInventoryDTO.Id = item.Id;
						hseInventoryDTO.Item = item.Item;
						hseInventoryDTO.StockAtStorage = item.StockAtStorage;
						hseInventoryDTO.ReleasedFromStorage = item.ReleasedFromStorage;
						hseInventoryDTO.NewlyRecieved = item.NewlyRecieved;
						hseInventoryDTO.HandoverId = item.HandoverId;
						hseInventoryDTO.IsDeleted = item.IsDeleted;
						HandoverDTO.HSEInventory.Add(hseInventoryDTO);
					}
					foreach (var item in Handover.HSEEquipment)
					{
						HSEEquipmentDTO hseEquipmentDTO = new HSEEquipmentDTO();
						hseEquipmentDTO.Id = item.Id;
						hseEquipmentDTO.Item = item.Item;
						hseEquipmentDTO.OnSite = item.OnSite;
						hseEquipmentDTO.SentForMaintenance = item.SentForMaintenance;
						hseEquipmentDTO.HandoverId = item.HandoverId;
						hseEquipmentDTO.IsDeleted = item.IsDeleted;
						HandoverDTO.HSEEquipment.Add(hseEquipmentDTO);
					}
					if (Handover.MaterialRequested.Any())
					{
						foreach (var item in Handover.MaterialRequested)
						{
							MaterialRequestedDTO materialRequestedDTO = new MaterialRequestedDTO();
							materialRequestedDTO.Id = item.Id;
							materialRequestedDTO.PR = item.PR;
							materialRequestedDTO.RequiredItem = item.RequiredItem;
							materialRequestedDTO.HandoverId = item.HandoverId;
							materialRequestedDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.MaterialRequested.Add(materialRequestedDTO);
						}
					}

					result.Message = "Success";
					result.Data = HandoverDTO;
					result.Statescode = 200;
					return result;

				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					Handover Handover = HandoverRepoistory.getall().FirstOrDefault(a => a.Id == ID && a.userID == UserId);
					HandoverDTO HandoverDTO = new HandoverDTO();
					HandoverDTO.Id = Handover.Id;
					HandoverDTO.RigId = Handover.RigId;
					HandoverDTO.ShiftDateFrom = Handover.ShiftDateFrom;
					HandoverDTO.ShiftDateTo = Handover.ShiftDateTo;
					HandoverDTO.WellName = Handover.WellName;
					HandoverDTO.Client = Handover.Client;
					HandoverDTO.LeavingEmpCode = Handover.LeavingEmpCode;
					HandoverDTO.LeavingEmpName = Handover.LeavingEmpName;
					HandoverDTO.ComingEmpCode = Handover.ComingEmpCode;
					HandoverDTO.ComingEmpName = Handover.ComingEmpName;
					HandoverDTO.StopCards = Handover.StopCards;
					HandoverDTO.MonthlyStopCards = Handover.MonthlyStopCards;
					HandoverDTO.OpenStopCards = Handover.OpenStopCards;
					HandoverDTO.Drills = Handover.Drills;
					HandoverDTO.MonthlyDrills = Handover.MonthlyDrills;
					HandoverDTO.SafetyAlerts = Handover.SafetyAlerts;
					HandoverDTO.MonthlySafetyAlerts = Handover.MonthlySafetyAlerts;
					HandoverDTO.WeeklyInspection = Handover.WeeklyInspection;
					HandoverDTO.InternalAudit = Handover.InternalAudit;
					HandoverDTO.ExternalAudit = Handover.ExternalAudit;
					HandoverDTO.MedicalReport = Handover.MedicalReport;
					HandoverDTO.TrainingMatrix = Handover.TrainingMatrix;
					HandoverDTO.RigMove = Handover.RigMove;
					HandoverDTO.IncidentReport = Handover.IncidentReport;
					HandoverDTO.TrackingSheetClosedPoints = Handover.TrackingSheetClosedPoints;
					HandoverDTO.ShiftBrief = Handover.ShiftBrief;
					HandoverDTO.QHSEEngineer = Handover.QHSEEngineer;
					HandoverDTO.userID = Handover.userID;
					HandoverDTO.PotentialHazardReport = Handover.PotentialHazardReport;
					if (Handover.ShiftDrillTypes.Any())
					{
						foreach (var item in Handover.ShiftDrillTypes)
						{
							ShiftDrillTypesDTO shiftDrillTypesDTO = new ShiftDrillTypesDTO();
							shiftDrillTypesDTO.Id = item.Id;
							shiftDrillTypesDTO.Date = item.Date;
							shiftDrillTypesDTO.DrillType = item.DrillType;
							shiftDrillTypesDTO.HandoverId = item.HandoverId;
							shiftDrillTypesDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.ShiftDrillTypes.Add(shiftDrillTypesDTO);
						}
					}
					if (Handover.Visits.Any())
					{
						foreach (var item in Handover.Visits)
						{
							VisitsDTO visitsDTO = new VisitsDTO();
							visitsDTO.Id = item.Id;
							visitsDTO.Date = item.Date;
							visitsDTO.VisitName = item.VisitName;
							visitsDTO.HandoverId = item.HandoverId;
							visitsDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.Visits.Add(visitsDTO);
						}
					}
					foreach (var item in Handover.HSEInventory)
					{
						HSEInventoryDTO hseInventoryDTO = new HSEInventoryDTO();
						hseInventoryDTO.Id = item.Id;
						hseInventoryDTO.Item = item.Item;
						hseInventoryDTO.StockAtStorage = item.StockAtStorage;
						hseInventoryDTO.ReleasedFromStorage = item.ReleasedFromStorage;
						hseInventoryDTO.NewlyRecieved = item.NewlyRecieved;
						hseInventoryDTO.HandoverId = item.HandoverId;
						hseInventoryDTO.IsDeleted = item.IsDeleted;
						HandoverDTO.HSEInventory.Add(hseInventoryDTO);
					}
					foreach (var item in Handover.HSEEquipment)
					{
						HSEEquipmentDTO hseEquipmentDTO = new HSEEquipmentDTO();
						hseEquipmentDTO.Id = item.Id;
						hseEquipmentDTO.Item = item.Item;
						hseEquipmentDTO.OnSite = item.OnSite;
						hseEquipmentDTO.SentForMaintenance = item.SentForMaintenance;
						hseEquipmentDTO.HandoverId = item.HandoverId;
						hseEquipmentDTO.IsDeleted = item.IsDeleted;
						HandoverDTO.HSEEquipment.Add(hseEquipmentDTO);
					}
					if (Handover.MaterialRequested.Any())
					{
						foreach (var item in Handover.MaterialRequested)
						{
							MaterialRequestedDTO materialRequestedDTO = new MaterialRequestedDTO();
							materialRequestedDTO.Id = item.Id;
							materialRequestedDTO.PR = item.PR;
							materialRequestedDTO.RequiredItem = item.RequiredItem;
							materialRequestedDTO.HandoverId = item.HandoverId;
							materialRequestedDTO.IsDeleted = item.IsDeleted;
							HandoverDTO.MaterialRequested.Add(materialRequestedDTO);
						}
					}

					result.Message = "Success";
					result.Data = HandoverDTO;
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
		public ActionResult<ResultDTO> AddHandover(HandoverDTO HandoverDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					Handover Handover = new Handover();
					Handover.Id = default;
					Handover.RigId = HandoverDTO.RigId;
					Handover.ShiftDateFrom = HandoverDTO.ShiftDateFrom;
					Handover.ShiftDateTo = HandoverDTO.ShiftDateTo;
					Handover.WellName = HandoverDTO.WellName;
					Handover.Client = HandoverDTO.Client;
					Handover.LeavingEmpCode = HandoverDTO.LeavingEmpCode;
					Handover.LeavingEmpName = HandoverDTO.LeavingEmpName;
					Handover.ComingEmpCode = HandoverDTO.ComingEmpCode;
					Handover.ComingEmpName = HandoverDTO.ComingEmpName;
					Handover.StopCards = HandoverDTO.StopCards;
					Handover.MonthlyStopCards = HandoverDTO.MonthlyStopCards;
					Handover.OpenStopCards = HandoverDTO.OpenStopCards;
					Handover.Drills = HandoverDTO.Drills;
					Handover.MonthlyDrills = HandoverDTO.MonthlyDrills;
					Handover.SafetyAlerts = HandoverDTO.SafetyAlerts;
					Handover.MonthlySafetyAlerts = HandoverDTO.MonthlySafetyAlerts;
					Handover.WeeklyInspection = HandoverDTO.WeeklyInspection;
					Handover.InternalAudit = HandoverDTO.InternalAudit;
					Handover.ExternalAudit = HandoverDTO.ExternalAudit;
					Handover.MedicalReport = HandoverDTO.MedicalReport;
					Handover.TrainingMatrix = HandoverDTO.TrainingMatrix;
					Handover.RigMove = HandoverDTO.RigMove;
					Handover.IncidentReport = HandoverDTO.IncidentReport;
					Handover.TrackingSheetClosedPoints = HandoverDTO.TrackingSheetClosedPoints;
					Handover.ShiftBrief = HandoverDTO.ShiftBrief;
					Handover.QHSEEngineer = HandoverDTO.QHSEEngineer;
					Handover.userID = HandoverDTO.userID;
					Handover.PotentialHazardReport = HandoverDTO.PotentialHazardReport;
					
					HandoverRepo.create(Handover);

					if (HandoverDTO.ShiftDrillTypes.Any())
					{
						foreach (var item in HandoverDTO.ShiftDrillTypes)
						{
							ShiftDrillTypes shiftDrillTypes = new ShiftDrillTypes();
							shiftDrillTypes.Date = item.Date;
							shiftDrillTypes.DrillType = item.DrillType;
							shiftDrillTypes.HandoverId = Handover.Id;
							shiftDrillTypes.IsDeleted = item.IsDeleted;
							ShiftDrillTypesRepo.create(shiftDrillTypes);
						}
					}
					if (HandoverDTO.Visits.Any())
					{
						foreach (var item in HandoverDTO.Visits)
						{
							Visits visits = new Visits();
							visits.Date = item.Date;
							visits.VisitName = item.VisitName;
							visits.HandoverId = Handover.Id;
							visits.IsDeleted = item.IsDeleted;
							VisitsRepo.create(visits);
						}
					}
					foreach (var item in HandoverDTO.HSEInventory)
					{
						HSEInventory hseInventory = new HSEInventory();
						hseInventory.Item = item.Item;
						hseInventory.StockAtStorage = item.StockAtStorage;
						hseInventory.ReleasedFromStorage = item.ReleasedFromStorage;
						hseInventory.NewlyRecieved = item.NewlyRecieved;
						hseInventory.HandoverId = Handover.Id;
						hseInventory.IsDeleted = item.IsDeleted;
						HSEInventoryRepo.create(hseInventory);
					}
					foreach (var item in HandoverDTO.HSEEquipment)
					{
						HSEEquipment hseEquipment = new HSEEquipment();
						hseEquipment.Item = item.Item;
						hseEquipment.OnSite = item.OnSite;
						hseEquipment.SentForMaintenance = item.SentForMaintenance;
						hseEquipment.HandoverId = Handover.Id;
						hseEquipment.IsDeleted = item.IsDeleted;
						HSEEquipmentRepo.create(hseEquipment);
					}
					if (HandoverDTO.MaterialRequested.Any())
					{
						foreach (var item in HandoverDTO.MaterialRequested)
						{
							MaterialRequested materialRequested = new MaterialRequested();
							materialRequested.PR = item.PR;
							materialRequested.RequiredItem = item.RequiredItem;
							materialRequested.HandoverId = Handover.Id;
							materialRequested.IsDeleted = item.IsDeleted;
							MaterialRequestedRepo.create(materialRequested);
						}
					}

					result.Message = "Success";
					result.Data = Handover;
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
		public ActionResult<ResultDTO> Put(int id, HandoverDTO newHandover) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					Handover orgHandover = HandoverRepo.getbyid(id);
					orgHandover.RigId = newHandover.RigId;
					orgHandover.ShiftDateFrom = newHandover.ShiftDateFrom;
					orgHandover.ShiftDateTo = newHandover.ShiftDateTo;
					orgHandover.WellName = newHandover.WellName;
					orgHandover.Client = newHandover.Client;
					orgHandover.LeavingEmpCode = newHandover.LeavingEmpCode;
					orgHandover.LeavingEmpName = newHandover.LeavingEmpName;
					orgHandover.ComingEmpCode = newHandover.ComingEmpCode;
					orgHandover.ComingEmpName = newHandover.ComingEmpName;
					orgHandover.StopCards = newHandover.StopCards;
					orgHandover.MonthlyStopCards = newHandover.MonthlyStopCards;
					orgHandover.OpenStopCards = newHandover.OpenStopCards;
					orgHandover.Drills = newHandover.Drills;
					orgHandover.MonthlyDrills = newHandover.MonthlyDrills;
					orgHandover.SafetyAlerts = newHandover.SafetyAlerts;
					orgHandover.MonthlySafetyAlerts = newHandover.MonthlySafetyAlerts;
					orgHandover.WeeklyInspection = newHandover.WeeklyInspection;
					orgHandover.InternalAudit = newHandover.InternalAudit;
					orgHandover.ExternalAudit = newHandover.ExternalAudit;
					orgHandover.MedicalReport = newHandover.MedicalReport;
					orgHandover.TrainingMatrix = newHandover.TrainingMatrix;
					orgHandover.RigMove = newHandover.RigMove;
					orgHandover.IncidentReport = newHandover.IncidentReport;
					orgHandover.TrackingSheetClosedPoints = newHandover.TrackingSheetClosedPoints;
					orgHandover.ShiftBrief = newHandover.ShiftBrief;
					orgHandover.QHSEEngineer = newHandover.QHSEEngineer;
					//orgHandover.userID = newHandover.userID;
					orgHandover.PotentialHazardReport = newHandover.PotentialHazardReport;

					HandoverRepo.update(orgHandover);

					var oldShiftDrillTypes = ShiftDrillTypesRepo.getall().Where(o => o.HandoverId == id).ToList();
					if (oldShiftDrillTypes.Any())
					{
						if (oldShiftDrillTypes.Count == newHandover.ShiftDrillTypes.Count)
						{
							for (int i = 0; i < oldShiftDrillTypes.Count(); i++)
							{
								var OldItem = oldShiftDrillTypes[i];
								var newItem = newHandover.ShiftDrillTypes[i];

								OldItem.Date = newItem.Date;
								OldItem.DrillType = newItem.DrillType;
								OldItem.HandoverId = id;
								ShiftDrillTypesRepo.update(OldItem);
							}
						}
						else
						{
							foreach (var item in oldShiftDrillTypes)
							{
								ShiftDrillTypesRepo.delete(item);
							}
							foreach (var item in newHandover.ShiftDrillTypes)
							{
								ShiftDrillTypes shiftDrillTypes = new ShiftDrillTypes();
								shiftDrillTypes.Date = item.Date;
								shiftDrillTypes.DrillType = item.DrillType;
								shiftDrillTypes.HandoverId = id;
								shiftDrillTypes.IsDeleted = item.IsDeleted;
								ShiftDrillTypesRepo.create(shiftDrillTypes);
							}
						}
					}
					else
					{
						foreach (var item in newHandover.ShiftDrillTypes)
						{
							ShiftDrillTypes shiftDrillTypes = new ShiftDrillTypes();
							shiftDrillTypes.Date = item.Date;
							shiftDrillTypes.DrillType = item.DrillType;
							shiftDrillTypes.HandoverId = id;
							shiftDrillTypes.IsDeleted = item.IsDeleted;
							ShiftDrillTypesRepo.create(shiftDrillTypes);
						}
					}

					var oldVisits = VisitsRepo.getall().Where(o => o.HandoverId == id).ToList();
					if (oldVisits.Any())
					{
						if (oldVisits.Count == newHandover.Visits.Count)
						{
							for (int i = 0; i < oldVisits.Count(); i++)
							{
								var OldItem = oldVisits[i];
								var newItem = newHandover.Visits[i];

								OldItem.Date = newItem.Date;
								OldItem.VisitName = newItem.VisitName;
								OldItem.HandoverId = id;
								VisitsRepo.update(OldItem);
							}
						}
						else
						{
							foreach (var item in oldVisits)
							{
								VisitsRepo.delete(item);
							}
							foreach (var item in newHandover.Visits)
							{
								Visits visits = new Visits();
								visits.Date = item.Date;
								visits.VisitName = item.VisitName;
								visits.HandoverId = id;
								visits.IsDeleted = item.IsDeleted;
								VisitsRepo.create(visits);
							}
						}
					}
					else
					{
						foreach (var item in newHandover.Visits)
						{
							Visits visits = new Visits();
							visits.Date = item.Date;
							visits.VisitName = item.VisitName;
							visits.HandoverId = id;
							visits.IsDeleted = item.IsDeleted;
							VisitsRepo.create(visits);
						}
					}

					var oldHSEInventory = HSEInventoryRepo.getall().Where(o => o.HandoverId == id).ToList();
					if (oldHSEInventory.Count == newHandover.HSEInventory.Count)
					{
						for (int i = 0; i < oldHSEInventory.Count(); i++)
						{
							var OldItem = oldHSEInventory[i];
							var newItem = newHandover.HSEInventory[i];

							OldItem.Item = newItem.Item;
							OldItem.StockAtStorage = newItem.StockAtStorage;
							OldItem.ReleasedFromStorage = newItem.ReleasedFromStorage;
							OldItem.NewlyRecieved = newItem.NewlyRecieved;
							OldItem.HandoverId = id;
							HSEInventoryRepo.update(OldItem);
						}
					}
					else
					{
						foreach (var item in oldHSEInventory)
						{
							HSEInventoryRepo.delete(item);
						}
						foreach (var item in newHandover.HSEInventory)
						{
							HSEInventory hseInventory = new HSEInventory();
							hseInventory.Item = item.Item;
							hseInventory.StockAtStorage = item.StockAtStorage;
							hseInventory.ReleasedFromStorage = item.ReleasedFromStorage;
							hseInventory.NewlyRecieved = item.NewlyRecieved;
							hseInventory.HandoverId = id;
							hseInventory.IsDeleted = item.IsDeleted;
							HSEInventoryRepo.create(hseInventory);
						}
					}

					var oldHSEEquipment = HSEEquipmentRepo.getall().Where(o => o.HandoverId == id).ToList();
					if(oldHSEEquipment.Count ==newHandover.HSEEquipment.Count)
					{
						for (int i = 0; i < oldHSEEquipment.Count(); i++)
						{
							var OldItem = oldHSEEquipment[i];
							var newItem = newHandover.HSEEquipment[i];

							OldItem.Item = newItem.Item;
							OldItem.OnSite = newItem.OnSite;
							OldItem.SentForMaintenance = newItem.SentForMaintenance;
							OldItem.HandoverId = id;
							HSEEquipmentRepo.update(OldItem);
						}
					}
					else
					{
						foreach (var item in oldHSEEquipment)
						{
							HSEEquipmentRepo.delete(item);
						}
						foreach (var item in newHandover.HSEEquipment)
						{
							HSEEquipment hseEquipment = new HSEEquipment();
							hseEquipment.Item = item.Item;
							hseEquipment.OnSite = item.OnSite;
							hseEquipment.SentForMaintenance = item.SentForMaintenance;
							hseEquipment.HandoverId = id;
							hseEquipment.IsDeleted = item.IsDeleted;
							HSEEquipmentRepo.create(hseEquipment);
						}
					}

					var oldMaterialRequested = MaterialRequestedRepo.getall().Where(o => o.HandoverId == id).ToList();
					if (oldMaterialRequested.Any())
					{
						if (oldMaterialRequested.Count == newHandover.MaterialRequested.Count)
						{
							for (int i = 0; i < oldMaterialRequested.Count(); i++)
							{
								var OldItem = oldMaterialRequested[i];
								var newItem = newHandover.MaterialRequested[i];

								OldItem.PR = newItem.PR;
								OldItem.RequiredItem = newItem.RequiredItem;
								OldItem.HandoverId = id;
								MaterialRequestedRepo.update(OldItem);
							}
						}
						else
						{
							foreach (var item in oldMaterialRequested)
							{
								MaterialRequestedRepo.delete(item);
							}
							foreach (var item in newHandover.MaterialRequested)
							{
								MaterialRequested materialRequested = new MaterialRequested();
								materialRequested.PR = item.PR;
								materialRequested.RequiredItem = item.RequiredItem;
								materialRequested.HandoverId = id;
								materialRequested.IsDeleted = item.IsDeleted;
								MaterialRequestedRepo.create(materialRequested);

							}
						}
						
					}
					else
					{
						foreach (var item in newHandover.MaterialRequested)
						{
							MaterialRequested materialRequested = new MaterialRequested();
							materialRequested.PR = item.PR;
							materialRequested.RequiredItem = item.RequiredItem;
							materialRequested.HandoverId = id;
							materialRequested.IsDeleted = item.IsDeleted;
							MaterialRequestedRepo.create(materialRequested);

						}
					}

					result.Data = orgHandover;
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
				List<ShiftDrillTypes> shiftDrillTypes = ShiftDrillTypesRepo.getall().Where(p => p.HandoverId == id).ToList();
				if (shiftDrillTypes.Any())
				{
					foreach (var item in shiftDrillTypes)
					{
						ShiftDrillTypes ShiftDrillType = ShiftDrillTypesRepo.getbyid(item.Id);

						ShiftDrillType.IsDeleted = true;

						ShiftDrillTypesRepo.update(ShiftDrillType);
					}
				}

				List<Visits> Visits = VisitsRepo.getall().Where(p => p.HandoverId == id).ToList();
				if (Visits.Any())
				{
					foreach (var item in Visits)
					{
						Visits Visit = VisitsRepo.getbyid(item.Id);

						Visit.IsDeleted = true;

						VisitsRepo.update(Visit);
					}
				}

				List<HSEInventory> HSEInventory = HSEInventoryRepo.getall().Where(p => p.HandoverId == id).ToList();
				if (HSEInventory.Any())
				{
					foreach (var item in HSEInventory)
					{
						HSEInventory hSEInventory = HSEInventoryRepo.getbyid(item.Id);

						hSEInventory.IsDeleted = true;

						HSEInventoryRepo.update(hSEInventory);
					}
				}

				List<HSEEquipment> HSEEquipments = HSEEquipmentRepo.getall().Where(p => p.HandoverId == id).ToList();
				if (HSEEquipments.Any())
				{
					foreach (var item in HSEEquipments)
					{
						HSEEquipment HSEEquipment = HSEEquipmentRepo.getbyid(item.Id);

						HSEEquipment.IsDeleted = true;

						HSEEquipmentRepo.update(HSEEquipment);
					}
				}

				List<MaterialRequested> MaterialRequesteds = MaterialRequestedRepo.getall().Where(p => p.HandoverId == id).ToList();
				if (MaterialRequesteds.Any())
				{
					foreach (var item in MaterialRequesteds)
					{
						MaterialRequested MaterialRequested = MaterialRequestedRepo.getbyid(item.Id);

						MaterialRequested.IsDeleted = true;

						MaterialRequestedRepo.update(MaterialRequested);
					}
				}

				Handover handover = HandoverRepo.getbyid(id);
				handover.IsDeleted = true;
				HandoverRepo.update(handover);

				result.Data = handover;
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
