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

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WeeklyClinicController : ControllerBase
	{
		public IRepository<WeeklyClinic> WeeklyClinicRepo;
		public IWeeklyClinicRepository WeeklyClinicRepoistory;

		private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager;

		public IRepository<DrugInventory> DrugInventoryRepo;

		public IRepository<FridgeComponent> FridgeComponentRepo;


		public WeeklyClinicController(IRepository<WeeklyClinic> _WeeklyClinicRepo, 
			IRepository<FridgeComponent> _FridgeComponentRepo, 
			IRepository<DrugInventory> _DrugInventoryRepo, 
			Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager, 
			IWeeklyClinicRepository _WeeklyClinicRepoistory)
		{
			this.WeeklyClinicRepo = _WeeklyClinicRepo;
			this.FridgeComponentRepo = _FridgeComponentRepo;
			this.userManager = _userManager;
			this.DrugInventoryRepo = _DrugInventoryRepo;
			this.WeeklyClinicRepoistory = _WeeklyClinicRepoistory;
		}

		[HttpGet("GetData")]
		public async Task<ResultDTO> GetAllWithData(string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall();
					List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
					foreach (WeeklyClinic weeklyClinic in temp)
					{
						WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
						weeklyClinicDTO.Id = weeklyClinic.Id;
						weeklyClinicDTO.RigNo = weeklyClinic.Rig.Number;
						weeklyClinicDTO.Date = weeklyClinic.Date;
						weeklyClinicDTO.WeeklyClinicNo = weeklyClinic.WeeklyClinicNo;
						weeklyClinicDTO.MedicalReportNo = weeklyClinic.MedicalReportNo;
						weeklyClinicDTO.LastFirstAidDrillNo = weeklyClinic.LastFirstAidDrillNo;
						weeklyClinicDTO.HealthMeetingNo = weeklyClinic.HealthMeetingNo;
						weeklyClinicDTO.Topics = weeklyClinic.Topics;
						weeklyClinicDTO.HealthStatus = weeklyClinic.HealthStatus;
						weeklyClinicDTO.HealthStatusComment = weeklyClinic.HealthStatusComment;
						weeklyClinicDTO.LifeSavingApparatuses = weeklyClinic.LifeSavingApparatuses;
						weeklyClinicDTO.LifeSavingApparatusesComment = weeklyClinic.LifeSavingApparatusesComment;
						weeklyClinicDTO.VaccinesAvailable = weeklyClinic.VaccinesAvailable;
						weeklyClinicDTO.VaccinesAvailableComment = weeklyClinic.VaccinesAvailableComment;
						weeklyClinicDTO.ERP = weeklyClinic.ERP;
						weeklyClinicDTO.ERPComment = weeklyClinic.ERPComment;
						weeklyClinicDTO.MedicalStretcher = weeklyClinic.MedicalStretcher;
						weeklyClinicDTO.MedicalStretcherComment = weeklyClinic.MedicalStretcherComment;
						weeklyClinicDTO.WaterTest = weeklyClinic.WaterTest;
						weeklyClinicDTO.WaterTestComment = weeklyClinic.WaterTestComment;
						weeklyClinicDTO.BloodSugar = weeklyClinic.BloodSugar;
						weeklyClinicDTO.BloodSugarComment = weeklyClinic.BloodSugarComment;
						weeklyClinicDTO.FirstAidBox = weeklyClinic.FirstAidBox;
						weeklyClinicDTO.FirstAidBoxComment = weeklyClinic.FirstAidBoxComment;
						weeklyClinicDTO.FullO2Cylinder = weeklyClinic.FullO2Cylinder;
						weeklyClinicDTO.FullO2CylinderComment = weeklyClinic.FullO2CylinderComment;
						weeklyClinicDTO.MedicalWaste = weeklyClinic.MedicalWaste;
						weeklyClinicDTO.MedicalWasteComment = weeklyClinic.MedicalWasteComment;
						weeklyClinicDTO.MedicinesExpiryDate = weeklyClinic.MedicinesExpiryDate;
						weeklyClinicDTO.MedicinesExpiryDateComment = weeklyClinic.MedicinesExpiryDateComment;
						weeklyClinicDTO.OtherComments = weeklyClinic.OtherComments;
						weeklyClinicDTO.DoctorName = weeklyClinic.DoctorName;
						weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
						weeklyClinicDTO.userName = weeklyClinic.user.UserName;
						foreach(var item in weeklyClinic.FridgeComponents)
						{
							FridgeComponentDTO fridgeComponentDTO = new FridgeComponentDTO();
							fridgeComponentDTO.Id = item.Id;
							fridgeComponentDTO.Item = item.Item;
							fridgeComponentDTO.Quantity = item.Quantity;
							fridgeComponentDTO.ExpireDate = item.ExpireDate;
							fridgeComponentDTO.WeeklyClinicId = item.WeeklyClinicId;
							fridgeComponentDTO.IsDeleted = item.IsDeleted;
							weeklyClinicDTO.FridgeComponents.Add(fridgeComponentDTO);
						}
						foreach (var item in weeklyClinic.DrugInventory)
						{
							DrugInventoryDTO drugInventoryDTO = new DrugInventoryDTO();
							drugInventoryDTO.Id = item.Id;
							drugInventoryDTO.Item = item.Item;
							drugInventoryDTO.Quantity = item.Quantity;
							drugInventoryDTO.ExpireDate = item.ExpireDate;
							drugInventoryDTO.WeeklyClinicId = item.WeeklyClinicId;
							drugInventoryDTO.IsDeleted = item.IsDeleted;
							weeklyClinicDTO.DrugInventory.Add(drugInventoryDTO);
						}
						
						newTemp.Add(weeklyClinicDTO);
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
					List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall().Where(a => a.user.Id == UserID).ToList();
					List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
					foreach (WeeklyClinic weeklyClinic in temp)
					{
						WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
						weeklyClinicDTO.Id = default;
						weeklyClinicDTO.RigNo = weeklyClinic.Rig.Number;
						weeklyClinicDTO.Date = weeklyClinic.Date;
						weeklyClinicDTO.WeeklyClinicNo = weeklyClinic.WeeklyClinicNo;
						weeklyClinicDTO.MedicalReportNo = weeklyClinic.MedicalReportNo;
						weeklyClinicDTO.LastFirstAidDrillNo = weeklyClinic.LastFirstAidDrillNo;
						weeklyClinicDTO.HealthMeetingNo = weeklyClinic.HealthMeetingNo;
						weeklyClinicDTO.Topics = weeklyClinic.Topics;
						weeklyClinicDTO.HealthStatus = weeklyClinic.HealthStatus;
						weeklyClinicDTO.HealthStatusComment = weeklyClinic.HealthStatusComment;
						weeklyClinicDTO.LifeSavingApparatuses = weeklyClinic.LifeSavingApparatuses;
						weeklyClinicDTO.LifeSavingApparatusesComment = weeklyClinic.LifeSavingApparatusesComment;
						weeklyClinicDTO.VaccinesAvailable = weeklyClinic.VaccinesAvailable;
						weeklyClinicDTO.VaccinesAvailableComment = weeklyClinic.VaccinesAvailableComment;
						weeklyClinicDTO.ERP = weeklyClinic.ERP;
						weeklyClinicDTO.ERPComment = weeklyClinic.ERPComment;
						weeklyClinicDTO.MedicalStretcher = weeklyClinic.MedicalStretcher;
						weeklyClinicDTO.MedicalStretcherComment = weeklyClinic.MedicalStretcherComment;
						weeklyClinicDTO.WaterTest = weeklyClinic.WaterTest;
						weeklyClinicDTO.WaterTestComment = weeklyClinic.WaterTestComment;
						weeklyClinicDTO.BloodSugar = weeklyClinic.BloodSugar;
						weeklyClinicDTO.BloodSugarComment = weeklyClinic.BloodSugarComment;
						weeklyClinicDTO.FirstAidBox = weeklyClinic.FirstAidBox;
						weeklyClinicDTO.FirstAidBoxComment = weeklyClinic.FirstAidBoxComment;
						weeklyClinicDTO.FullO2Cylinder = weeklyClinic.FullO2Cylinder;
						weeklyClinicDTO.FullO2CylinderComment = weeklyClinic.FullO2CylinderComment;
						weeklyClinicDTO.MedicalWaste = weeklyClinic.MedicalWaste;
						weeklyClinicDTO.MedicalWasteComment = weeklyClinic.MedicalWasteComment;
						weeklyClinicDTO.MedicinesExpiryDate = weeklyClinic.MedicinesExpiryDate;
						weeklyClinicDTO.MedicinesExpiryDateComment = weeklyClinic.MedicinesExpiryDateComment;
						weeklyClinicDTO.OtherComments = weeklyClinic.OtherComments;
						weeklyClinicDTO.DoctorName = weeklyClinic.DoctorName;
						weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
						weeklyClinicDTO.userName = weeklyClinic.user.UserName;
						foreach (var item in weeklyClinic.FridgeComponents)
						{
							FridgeComponentDTO fridgeComponentDTO = new FridgeComponentDTO();
							fridgeComponentDTO.Id = item.Id;
							fridgeComponentDTO.Item = item.Item;
							fridgeComponentDTO.Quantity = item.Quantity;
							fridgeComponentDTO.ExpireDate = item.ExpireDate;
							fridgeComponentDTO.WeeklyClinicId = item.WeeklyClinicId;
							fridgeComponentDTO.IsDeleted = item.IsDeleted;
							weeklyClinicDTO.FridgeComponents.Add(fridgeComponentDTO);
						}
						foreach (var item in weeklyClinic.DrugInventory)
						{
							DrugInventoryDTO drugInventoryDTO = new DrugInventoryDTO();
							drugInventoryDTO.Id = item.Id;
							drugInventoryDTO.Item = item.Item;
							drugInventoryDTO.Quantity = item.Quantity;
							drugInventoryDTO.ExpireDate = item.ExpireDate;
							drugInventoryDTO.WeeklyClinicId = item.WeeklyClinicId;
							drugInventoryDTO.IsDeleted = item.IsDeleted;
							weeklyClinicDTO.DrugInventory.Add(drugInventoryDTO);
						}

						newTemp.Add(weeklyClinicDTO);
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
		public async Task<ResultDTO> GetAllWithDataForPrint(int RigNo,DateTime date,string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall().Where(w=>w.Date==date&&w.Rig.Number==RigNo).ToList();
					List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
					foreach (WeeklyClinic weeklyClinic in temp)
					{
						WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
						weeklyClinicDTO.Id = default;
						weeklyClinicDTO.RigNo = weeklyClinic.Rig.Number;
						weeklyClinicDTO.Date = weeklyClinic.Date;
						weeklyClinicDTO.WeeklyClinicNo = weeklyClinic.WeeklyClinicNo;
						weeklyClinicDTO.MedicalReportNo = weeklyClinic.MedicalReportNo;
						weeklyClinicDTO.LastFirstAidDrillNo = weeklyClinic.LastFirstAidDrillNo;
						weeklyClinicDTO.HealthMeetingNo = weeklyClinic.HealthMeetingNo;
						weeklyClinicDTO.Topics = weeklyClinic.Topics;
						weeklyClinicDTO.HealthStatus = weeklyClinic.HealthStatus;
						weeklyClinicDTO.HealthStatusComment = weeklyClinic.HealthStatusComment;
						weeklyClinicDTO.LifeSavingApparatuses = weeklyClinic.LifeSavingApparatuses;
						weeklyClinicDTO.LifeSavingApparatusesComment = weeklyClinic.LifeSavingApparatusesComment;
						weeklyClinicDTO.VaccinesAvailable = weeklyClinic.VaccinesAvailable;
						weeklyClinicDTO.VaccinesAvailableComment = weeklyClinic.VaccinesAvailableComment;
						weeklyClinicDTO.ERP = weeklyClinic.ERP;
						weeklyClinicDTO.ERPComment = weeklyClinic.ERPComment;
						weeklyClinicDTO.MedicalStretcher = weeklyClinic.MedicalStretcher;
						weeklyClinicDTO.MedicalStretcherComment = weeklyClinic.MedicalStretcherComment;
						weeklyClinicDTO.WaterTest = weeklyClinic.WaterTest;
						weeklyClinicDTO.WaterTestComment = weeklyClinic.WaterTestComment;
						weeklyClinicDTO.BloodSugar = weeklyClinic.BloodSugar;
						weeklyClinicDTO.BloodSugarComment = weeklyClinic.BloodSugarComment;
						weeklyClinicDTO.FirstAidBox = weeklyClinic.FirstAidBox;
						weeklyClinicDTO.FirstAidBoxComment = weeklyClinic.FirstAidBoxComment;
						weeklyClinicDTO.FullO2Cylinder = weeklyClinic.FullO2Cylinder;
						weeklyClinicDTO.FullO2CylinderComment = weeklyClinic.FullO2CylinderComment;
						weeklyClinicDTO.MedicalWaste = weeklyClinic.MedicalWaste;
						weeklyClinicDTO.MedicalWasteComment = weeklyClinic.MedicalWasteComment;
						weeklyClinicDTO.MedicinesExpiryDate = weeklyClinic.MedicinesExpiryDate;
						weeklyClinicDTO.MedicinesExpiryDateComment = weeklyClinic.MedicinesExpiryDateComment;
						weeklyClinicDTO.OtherComments = weeklyClinic.OtherComments;
						weeklyClinicDTO.DoctorName = weeklyClinic.DoctorName;
						weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
						weeklyClinicDTO.userName = weeklyClinic.user.UserName;
						foreach (var item in weeklyClinic.FridgeComponents)
						{
							FridgeComponentDTO fridgeComponentDTO = new FridgeComponentDTO();
							fridgeComponentDTO.Id = item.Id;
							fridgeComponentDTO.Item = item.Item;
							fridgeComponentDTO.Quantity = item.Quantity;
							fridgeComponentDTO.ExpireDate = item.ExpireDate;
							fridgeComponentDTO.WeeklyClinicId = item.WeeklyClinicId;
							fridgeComponentDTO.IsDeleted = item.IsDeleted;
							weeklyClinicDTO.FridgeComponents.Add(fridgeComponentDTO);
						}
						foreach (var item in weeklyClinic.DrugInventory)
						{
							DrugInventoryDTO drugInventoryDTO = new DrugInventoryDTO();
							drugInventoryDTO.Id = item.Id;
							drugInventoryDTO.Item = item.Item;
							drugInventoryDTO.Quantity = item.Quantity;
							drugInventoryDTO.ExpireDate = item.ExpireDate;
							drugInventoryDTO.WeeklyClinicId = item.WeeklyClinicId;
							drugInventoryDTO.IsDeleted = item.IsDeleted;
							weeklyClinicDTO.DrugInventory.Add(drugInventoryDTO);
						}

						newTemp.Add(weeklyClinicDTO);
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
					List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall().Where(a => a.user.Id == UserID && a.Date == date && a.Rig.Number == RigNo).ToList();
					List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
					foreach (WeeklyClinic weeklyClinic in temp)
					{
						WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
						weeklyClinicDTO.Id = default;
						weeklyClinicDTO.RigNo = weeklyClinic.Rig.Number;
						weeklyClinicDTO.Date = weeklyClinic.Date;
						weeklyClinicDTO.WeeklyClinicNo = weeklyClinic.WeeklyClinicNo;
						weeklyClinicDTO.MedicalReportNo = weeklyClinic.MedicalReportNo;
						weeklyClinicDTO.LastFirstAidDrillNo = weeklyClinic.LastFirstAidDrillNo;
						weeklyClinicDTO.HealthMeetingNo = weeklyClinic.HealthMeetingNo;
						weeklyClinicDTO.Topics = weeklyClinic.Topics;
						weeklyClinicDTO.HealthStatus = weeklyClinic.HealthStatus;
						weeklyClinicDTO.HealthStatusComment = weeklyClinic.HealthStatusComment;
						weeklyClinicDTO.LifeSavingApparatuses = weeklyClinic.LifeSavingApparatuses;
						weeklyClinicDTO.LifeSavingApparatusesComment = weeklyClinic.LifeSavingApparatusesComment;
						weeklyClinicDTO.VaccinesAvailable = weeklyClinic.VaccinesAvailable;
						weeklyClinicDTO.VaccinesAvailableComment = weeklyClinic.VaccinesAvailableComment;
						weeklyClinicDTO.ERP = weeklyClinic.ERP;
						weeklyClinicDTO.ERPComment = weeklyClinic.ERPComment;
						weeklyClinicDTO.MedicalStretcher = weeklyClinic.MedicalStretcher;
						weeklyClinicDTO.MedicalStretcherComment = weeklyClinic.MedicalStretcherComment;
						weeklyClinicDTO.WaterTest = weeklyClinic.WaterTest;
						weeklyClinicDTO.WaterTestComment = weeklyClinic.WaterTestComment;
						weeklyClinicDTO.BloodSugar = weeklyClinic.BloodSugar;
						weeklyClinicDTO.BloodSugarComment = weeklyClinic.BloodSugarComment;
						weeklyClinicDTO.FirstAidBox = weeklyClinic.FirstAidBox;
						weeklyClinicDTO.FirstAidBoxComment = weeklyClinic.FirstAidBoxComment;
						weeklyClinicDTO.FullO2Cylinder = weeklyClinic.FullO2Cylinder;
						weeklyClinicDTO.FullO2CylinderComment = weeklyClinic.FullO2CylinderComment;
						weeklyClinicDTO.MedicalWaste = weeklyClinic.MedicalWaste;
						weeklyClinicDTO.MedicalWasteComment = weeklyClinic.MedicalWasteComment;
						weeklyClinicDTO.MedicinesExpiryDate = weeklyClinic.MedicinesExpiryDate;
						weeklyClinicDTO.MedicinesExpiryDateComment = weeklyClinic.MedicinesExpiryDateComment;
						weeklyClinicDTO.OtherComments = weeklyClinic.OtherComments;
						weeklyClinicDTO.DoctorName = weeklyClinic.DoctorName;
						weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
						weeklyClinicDTO.userName = weeklyClinic.user.UserName;
						foreach (var item in weeklyClinic.FridgeComponents)
						{
							FridgeComponentDTO fridgeComponentDTO = new FridgeComponentDTO();
							fridgeComponentDTO.Id = item.Id;
							fridgeComponentDTO.Item = item.Item;
							fridgeComponentDTO.Quantity = item.Quantity;
							fridgeComponentDTO.ExpireDate = item.ExpireDate;
							fridgeComponentDTO.WeeklyClinicId = item.WeeklyClinicId;
							fridgeComponentDTO.IsDeleted = item.IsDeleted;
							weeklyClinicDTO.FridgeComponents.Add(fridgeComponentDTO);
						}
						foreach (var item in weeklyClinic.DrugInventory)
						{
							DrugInventoryDTO drugInventoryDTO = new DrugInventoryDTO();
							drugInventoryDTO.Id = item.Id;
							drugInventoryDTO.Item = item.Item;
							drugInventoryDTO.Quantity = item.Quantity;
							drugInventoryDTO.ExpireDate = item.ExpireDate;
							drugInventoryDTO.WeeklyClinicId = item.WeeklyClinicId;
							drugInventoryDTO.IsDeleted = item.IsDeleted;
							weeklyClinicDTO.DrugInventory.Add(drugInventoryDTO);
						}

						newTemp.Add(weeklyClinicDTO);
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

		[HttpGet("GetDataForAnalysis")]
		public async Task<ResultDTO> GetDataForAnalysis(int RigId, string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					WeeklyClinic weeklyClinic = WeeklyClinicRepoistory.getall().Where(w => w.RigId == RigId).OrderByDescending(e => e.Date).FirstOrDefault();		
					WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
					weeklyClinicDTO.Id = default;
					weeklyClinicDTO.RigNo = weeklyClinic.Rig.Number;
					weeklyClinicDTO.Date = weeklyClinic.Date;
					weeklyClinicDTO.WeeklyClinicNo = weeklyClinic.WeeklyClinicNo;
					weeklyClinicDTO.MedicalReportNo = weeklyClinic.MedicalReportNo;
					weeklyClinicDTO.LastFirstAidDrillNo = weeklyClinic.LastFirstAidDrillNo;
					weeklyClinicDTO.HealthMeetingNo = weeklyClinic.HealthMeetingNo;
					weeklyClinicDTO.Topics = weeklyClinic.Topics;
					weeklyClinicDTO.HealthStatus = weeklyClinic.HealthStatus;
					weeklyClinicDTO.HealthStatusComment = weeklyClinic.HealthStatusComment;
					weeklyClinicDTO.LifeSavingApparatuses = weeklyClinic.LifeSavingApparatuses;
					weeklyClinicDTO.LifeSavingApparatusesComment = weeklyClinic.LifeSavingApparatusesComment;
					weeklyClinicDTO.VaccinesAvailable = weeklyClinic.VaccinesAvailable;
					weeklyClinicDTO.VaccinesAvailableComment = weeklyClinic.VaccinesAvailableComment;
					weeklyClinicDTO.ERP = weeklyClinic.ERP;
					weeklyClinicDTO.ERPComment = weeklyClinic.ERPComment;
					weeklyClinicDTO.MedicalStretcher = weeklyClinic.MedicalStretcher;
					weeklyClinicDTO.MedicalStretcherComment = weeklyClinic.MedicalStretcherComment;
					weeklyClinicDTO.WaterTest = weeklyClinic.WaterTest;
					weeklyClinicDTO.WaterTestComment = weeklyClinic.WaterTestComment;
					weeklyClinicDTO.BloodSugar = weeklyClinic.BloodSugar;
					weeklyClinicDTO.BloodSugarComment = weeklyClinic.BloodSugarComment;
					weeklyClinicDTO.FirstAidBox = weeklyClinic.FirstAidBox;
					weeklyClinicDTO.FirstAidBoxComment = weeklyClinic.FirstAidBoxComment;
					weeklyClinicDTO.FullO2Cylinder = weeklyClinic.FullO2Cylinder;
					weeklyClinicDTO.FullO2CylinderComment = weeklyClinic.FullO2CylinderComment;
					weeklyClinicDTO.MedicalWaste = weeklyClinic.MedicalWaste;
					weeklyClinicDTO.MedicalWasteComment = weeklyClinic.MedicalWasteComment;
					weeklyClinicDTO.MedicinesExpiryDate = weeklyClinic.MedicinesExpiryDate;
					weeklyClinicDTO.MedicinesExpiryDateComment = weeklyClinic.MedicinesExpiryDateComment;
					weeklyClinicDTO.OtherComments = weeklyClinic.OtherComments;
					weeklyClinicDTO.DoctorName = weeklyClinic.DoctorName;
					weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
					weeklyClinicDTO.userName = weeklyClinic.user.UserName;
					foreach (var item in weeklyClinic.FridgeComponents)
					{
						FridgeComponentDTO fridgeComponentDTO = new FridgeComponentDTO();
						fridgeComponentDTO.Id = item.Id;
						fridgeComponentDTO.Item = item.Item;
						fridgeComponentDTO.Quantity = item.Quantity;
						fridgeComponentDTO.ExpireDate = item.ExpireDate;
						fridgeComponentDTO.WeeklyClinicId = item.WeeklyClinicId;
						fridgeComponentDTO.IsDeleted = item.IsDeleted;
						weeklyClinicDTO.FridgeComponents.Add(fridgeComponentDTO);
					}
					foreach (var item in weeklyClinic.DrugInventory)
					{
						DrugInventoryDTO drugInventoryDTO = new DrugInventoryDTO();
						drugInventoryDTO.Id = item.Id;
						drugInventoryDTO.Item = item.Item;
						drugInventoryDTO.Quantity = item.Quantity;
						drugInventoryDTO.ExpireDate = item.ExpireDate;
						drugInventoryDTO.WeeklyClinicId = item.WeeklyClinicId;
						drugInventoryDTO.IsDeleted = item.IsDeleted;
						weeklyClinicDTO.DrugInventory.Add(drugInventoryDTO);
					}

					if (weeklyClinicDTO != null)
					{
						result.Message = "Success";
						result.Statescode = 200;
						result.Data = weeklyClinicDTO;

						return result;
					}
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					WeeklyClinic weeklyClinic = WeeklyClinicRepoistory.getall().Where(a => a.user.Id == UserID && a.RigId == RigId).OrderByDescending(e => e.Date).FirstOrDefault();
					WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
					weeklyClinicDTO.Id = default;
					weeklyClinicDTO.RigNo = weeklyClinic.Rig.Number;
					weeklyClinicDTO.Date = weeklyClinic.Date;
					weeklyClinicDTO.WeeklyClinicNo = weeklyClinic.WeeklyClinicNo;
					weeklyClinicDTO.MedicalReportNo = weeklyClinic.MedicalReportNo;
					weeklyClinicDTO.LastFirstAidDrillNo = weeklyClinic.LastFirstAidDrillNo;
					weeklyClinicDTO.HealthMeetingNo = weeklyClinic.HealthMeetingNo;
					weeklyClinicDTO.Topics = weeklyClinic.Topics;
					weeklyClinicDTO.HealthStatus = weeklyClinic.HealthStatus;
					weeklyClinicDTO.HealthStatusComment = weeklyClinic.HealthStatusComment;
					weeklyClinicDTO.LifeSavingApparatuses = weeklyClinic.LifeSavingApparatuses;
					weeklyClinicDTO.LifeSavingApparatusesComment = weeklyClinic.LifeSavingApparatusesComment;
					weeklyClinicDTO.VaccinesAvailable = weeklyClinic.VaccinesAvailable;
					weeklyClinicDTO.VaccinesAvailableComment = weeklyClinic.VaccinesAvailableComment;
					weeklyClinicDTO.ERP = weeklyClinic.ERP;
					weeklyClinicDTO.ERPComment = weeklyClinic.ERPComment;
					weeklyClinicDTO.MedicalStretcher = weeklyClinic.MedicalStretcher;
					weeklyClinicDTO.MedicalStretcherComment = weeklyClinic.MedicalStretcherComment;
					weeklyClinicDTO.WaterTest = weeklyClinic.WaterTest;
					weeklyClinicDTO.WaterTestComment = weeklyClinic.WaterTestComment;
					weeklyClinicDTO.BloodSugar = weeklyClinic.BloodSugar;
					weeklyClinicDTO.BloodSugarComment = weeklyClinic.BloodSugarComment;
					weeklyClinicDTO.FirstAidBox = weeklyClinic.FirstAidBox;
					weeklyClinicDTO.FirstAidBoxComment = weeklyClinic.FirstAidBoxComment;
					weeklyClinicDTO.FullO2Cylinder = weeklyClinic.FullO2Cylinder;
					weeklyClinicDTO.FullO2CylinderComment = weeklyClinic.FullO2CylinderComment;
					weeklyClinicDTO.MedicalWaste = weeklyClinic.MedicalWaste;
					weeklyClinicDTO.MedicalWasteComment = weeklyClinic.MedicalWasteComment;
					weeklyClinicDTO.MedicinesExpiryDate = weeklyClinic.MedicinesExpiryDate;
					weeklyClinicDTO.MedicinesExpiryDateComment = weeklyClinic.MedicinesExpiryDateComment;
					weeklyClinicDTO.OtherComments = weeklyClinic.OtherComments;
					weeklyClinicDTO.DoctorName = weeklyClinic.DoctorName;
					weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
					weeklyClinicDTO.userName = weeklyClinic.user.UserName;
					foreach (var item in weeklyClinic.FridgeComponents)
					{
						FridgeComponentDTO fridgeComponentDTO = new FridgeComponentDTO();
						fridgeComponentDTO.Id = item.Id;
						fridgeComponentDTO.Item = item.Item;
						fridgeComponentDTO.Quantity = item.Quantity;
						fridgeComponentDTO.ExpireDate = item.ExpireDate;
						fridgeComponentDTO.WeeklyClinicId = item.WeeklyClinicId;
						fridgeComponentDTO.IsDeleted = item.IsDeleted;
						weeklyClinicDTO.FridgeComponents.Add(fridgeComponentDTO);
					}
					foreach (var item in weeklyClinic.DrugInventory)
					{
						DrugInventoryDTO drugInventoryDTO = new DrugInventoryDTO();
						drugInventoryDTO.Id = item.Id;
						drugInventoryDTO.Item = item.Item;
						drugInventoryDTO.Quantity = item.Quantity;
						drugInventoryDTO.ExpireDate = item.ExpireDate;
						drugInventoryDTO.WeeklyClinicId = item.WeeklyClinicId;
						drugInventoryDTO.IsDeleted = item.IsDeleted;
						weeklyClinicDTO.DrugInventory.Add(drugInventoryDTO);
					}

					if (weeklyClinicDTO != null)
					{
						result.Message = "Success";
						result.Statescode = 200;
						result.Data = weeklyClinicDTO;

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
		//			List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall();

		//			temp = temp.Where(m => (Responsability == null || m.weeklyClinicResponsability.ResponsibilityName == Responsability)
		//				&& (Title == null || m.Title == Title)
		//				&& (date == null || m.DateRaisedBy.Date == DateTime.Parse(date).Date) && (Status == null || m.FormStatus == Status)).ToList();

		//			List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
		//			foreach (WeeklyClinic weeklyClinic in temp)
		//			{
		//				WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
		//				weeklyClinicDTO.Id = weeklyClinic.Id;
		//				//weeklyClinicDTO.Rig = weeklyClinic.Rig.Number;
		//				weeklyClinicDTO.Title = weeklyClinic.Title;
		//				weeklyClinicDTO.FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName;
		//				weeklyClinicDTO.ReportNo = weeklyClinic.ReportNo;
		//				weeklyClinicDTO.DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity;
		//				weeklyClinicDTO.Standard = weeklyClinic.Standard.StandardName;
		//				weeklyClinicDTO.ClauseNo = weeklyClinic.ClauseNo;
		//				weeklyClinicDTO.ObjectiveEvidence = weeklyClinic.ObjectiveEvidence;
		//				foreach (var item in weeklyClinic.weeklyClinicAndObservation)
		//				{
		//					string observation = item.weeklyClinicObservation.Observation;
		//					weeklyClinicDTO.weeklyClinicAndObservation.Add(observation);

		//				}
		//				foreach (var item in weeklyClinic.weeklyClinicAndRootCauses)
		//				{
		//					string cause = item.RootCauses.CauseName;
		//					weeklyClinicDTO.weeklyClinicAndRootCauses.Add(cause);

		//				}
		//				weeklyClinicDTO.IfOtherObservation = weeklyClinic.IfOtherObservation;
		//				weeklyClinicDTO.UpdateRisk = weeklyClinic.UpdateRisk;
		//				weeklyClinicDTO.IfUpdate = weeklyClinic.IfUpdate;
		//				weeklyClinicDTO.ManagementOfChange = weeklyClinic.ManagementOfChange;
		//				weeklyClinicDTO.IfManagementOfChange = weeklyClinic.IfManagementOfChange;
		//				weeklyClinicDTO.NameRasiedBy = weeklyClinic.NameRasiedBy;
		//				//weeklyClinicDTO.SigRasiedBy = weeklyClinic.SigRasiedBy;
		//				weeklyClinicDTO.DateRaisedBy = weeklyClinic.DateRaisedBy;
		//				weeklyClinicDTO.IfOtherRootCause = weeklyClinic.IfOtherRootCause;
		//				foreach (var item in weeklyClinic.weeklyClinicDataTable)
		//				{
		//					weeklyClinicDataTable Data = new weeklyClinicDataTable();
		//					Data.Id = item.Id;
		//					Data.SN = item.SN;
		//					Data.WeeklyClinicSelected = item.WeeklyClinicSelected;
		//					Data.Action = item.Action;
		//					Data.Responsible = item.Responsible;
		//					Data.SuggestedDate = item.SuggestedDate;
		//					Data.AchievementDate = item.AchievementDate;
		//					Data.Status = item.Status;
		//					Data.WeeklyClinicId = item.WeeklyClinicId;
		//					Data.FollowUpAudit = item.FollowUpAudit;
		//					Data.IsDeleted = item.IsDeleted;
		//					weeklyClinicDTO.weeklyClinicDataTable.Add(Data);
		//				};
		//				weeklyClinicDTO.Comment = weeklyClinic.Comment;
		//				weeklyClinicDTO.Q_ManagerSig = weeklyClinic.Q_ManagerSig;
		//				//weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
		//				weeklyClinicDTO.userName = weeklyClinic.user.UserName;
		//				weeklyClinicDTO.FormStatus = weeklyClinic.FormStatus;
		//				List<weeklyClinicImages> weeklyClinicImages = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).ToList();
		//				foreach (var item in weeklyClinicImages)
		//				{
		//					string FileName = item.FileName;
		//					weeklyClinicDTO.Images.Add(FileName);

		//				}
		//				newTemp.Add(weeklyClinicDTO);
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
		//	//			List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall().Where(c=>c.RigId==RigId).ToList();
		//	//			List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
		//	//			foreach (WeeklyClinic weeklyClinic in temp)
		//	//			{
		//	//				WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
		//	//				weeklyClinicDTO.Id = weeklyClinic.Id;
		//	//				weeklyClinicDTO.Rig = weeklyClinic.Rig.Number;
		//	//				weeklyClinicDTO.Title = weeklyClinic.Title;
		//	//				weeklyClinicDTO.FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName;
		//	//				weeklyClinicDTO.ReportNo = weeklyClinic.ReportNo;
		//	//				weeklyClinicDTO.DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity;
		//	//				weeklyClinicDTO.Standard = weeklyClinic.Standard.StandardName;
		//	//				weeklyClinicDTO.ClauseNo = weeklyClinic.ClauseNo;
		//	//				weeklyClinicDTO.ObjectiveEvidence = weeklyClinic.ObjectiveEvidence;
		//	//				foreach (var item in weeklyClinic.weeklyClinicAndObservation)
		//	//				{
		//	//					string observation = item.weeklyClinicObservation.Observation;
		//	//					weeklyClinicDTO.weeklyClinicAndObservation.Add(observation);

		//	//				}
		//	//				foreach (var item in weeklyClinic.weeklyClinicAndRootCauses)
		//	//				{
		//	//					string cause = item.RootCauses.CauseName;
		//	//					weeklyClinicDTO.weeklyClinicAndRootCauses.Add(cause);

		//	//				}
		//	//				weeklyClinicDTO.IfOtherObservation = weeklyClinic.IfOtherObservation;
		//	//				weeklyClinicDTO.UpdateRisk = weeklyClinic.UpdateRisk;
		//	//				weeklyClinicDTO.IfUpdate = weeklyClinic.IfUpdate;
		//	//				weeklyClinicDTO.ManagementOfChange = weeklyClinic.ManagementOfChange;
		//	//				weeklyClinicDTO.IfManagementOfChange = weeklyClinic.IfManagementOfChange;
		//	//				weeklyClinicDTO.NameRasiedBy = weeklyClinic.NameRasiedBy;
		//	//				//weeklyClinicDTO.SigRasiedBy = weeklyClinic.SigRasiedBy;
		//	//				weeklyClinicDTO.DateRaisedBy = weeklyClinic.DateRaisedBy;
		//	//				weeklyClinicDTO.IfOtherRootCause = weeklyClinic.IfOtherRootCause;
		//	//				foreach (var item in weeklyClinic.weeklyClinicDataTable)
		//	//				{
		//	//					weeklyClinicDataTable Data = new weeklyClinicDataTable();
		//	//					Data.Id = item.Id;
		//	//					Data.SN = item.SN;
		//	//					Data.WeeklyClinicSelected = item.WeeklyClinicSelected;
		//	//					Data.Action = item.Action;
		//	//					Data.Responsible = item.Responsible;
		//	//					Data.SuggestedDate = item.SuggestedDate;
		//	//					Data.AchievementDate = item.AchievementDate;
		//	//					Data.Status = item.Status;
		//	//					Data.WeeklyClinicId = item.WeeklyClinicId;
		//	//					Data.FollowUpAudit = item.FollowUpAudit;
		//	//					Data.IsDeleted = item.IsDeleted;
		//	//					weeklyClinicDTO.weeklyClinicDataTable.Add(Data);
		//	//				};
		//	//				weeklyClinicDTO.Comment = weeklyClinic.Comment;
		//	//				weeklyClinicDTO.Q_ManagerSig = weeklyClinic.Q_ManagerSig;
		//	//				weeklyClinicDTO.userName = weeklyClinic.user.UserName;
		//	//				weeklyClinicDTO.FormStatus = weeklyClinic.FormStatus;
		//	//				List<weeklyClinicImages> weeklyClinicImages = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).ToList();
		//	//				foreach (var item in weeklyClinicImages)
		//	//				{
		//	//					string FileName = item.FileName;
		//	//					weeklyClinicDTO.Images.Add(FileName);

		//	//				}
		//	//				newTemp.Add(weeklyClinicDTO);
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
		//	//			List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall().Where(a => a.user.Id == UserID && a.RigId == RigId).ToList();
		//	//			List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
		//	//			foreach (WeeklyClinic weeklyClinic in temp)
		//	//			{
		//	//				WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
		//	//				weeklyClinicDTO.Id = weeklyClinic.Id;
		//	//				weeklyClinicDTO.Rig = weeklyClinic.Rig.Number;
		//	//				weeklyClinicDTO.Title = weeklyClinic.Title;
		//	//				weeklyClinicDTO.FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName;
		//	//				weeklyClinicDTO.ReportNo = weeklyClinic.ReportNo;
		//	//				weeklyClinicDTO.DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity;
		//	//				weeklyClinicDTO.Standard = weeklyClinic.Standard.StandardName;
		//	//				weeklyClinicDTO.ClauseNo = weeklyClinic.ClauseNo;
		//	//				weeklyClinicDTO.ObjectiveEvidence = weeklyClinic.ObjectiveEvidence;
		//	//				foreach (var item in weeklyClinic.weeklyClinicAndObservation)
		//	//				{
		//	//					string observation = item.weeklyClinicObservation.Observation;
		//	//					weeklyClinicDTO.weeklyClinicAndObservation.Add(observation);

		//	//				}
		//	//				foreach (var item in weeklyClinic.weeklyClinicAndRootCauses)
		//	//				{
		//	//					string cause = item.RootCauses.CauseName;
		//	//					weeklyClinicDTO.weeklyClinicAndRootCauses.Add(cause);

		//	//				}
		//	//				weeklyClinicDTO.IfOtherObservation = weeklyClinic.IfOtherObservation;
		//	//				weeklyClinicDTO.UpdateRisk = weeklyClinic.UpdateRisk;
		//	//				weeklyClinicDTO.IfUpdate = weeklyClinic.IfUpdate;
		//	//				weeklyClinicDTO.ManagementOfChange = weeklyClinic.ManagementOfChange;
		//	//				weeklyClinicDTO.IfManagementOfChange = weeklyClinic.IfManagementOfChange;
		//	//				weeklyClinicDTO.NameRasiedBy = weeklyClinic.NameRasiedBy;
		//	//				//weeklyClinicDTO.SigRasiedBy = weeklyClinic.SigRasiedBy;
		//	//				weeklyClinicDTO.DateRaisedBy = weeklyClinic.DateRaisedBy;
		//	//				weeklyClinicDTO.IfOtherRootCause = weeklyClinic.IfOtherRootCause;
		//	//				foreach (var item in weeklyClinic.weeklyClinicDataTable)
		//	//				{
		//	//					weeklyClinicDataTable Data = new weeklyClinicDataTable();
		//	//					Data.Id = item.Id;
		//	//					Data.SN = item.SN;
		//	//					Data.WeeklyClinicSelected = item.WeeklyClinicSelected;
		//	//					Data.Action = item.Action;
		//	//					Data.Responsible = item.Responsible;
		//	//					Data.SuggestedDate = item.SuggestedDate;
		//	//					Data.AchievementDate = item.AchievementDate;
		//	//					Data.Status = item.Status;
		//	//					Data.WeeklyClinicId = item.WeeklyClinicId;
		//	//					Data.FollowUpAudit = item.FollowUpAudit;
		//	//					Data.IsDeleted = item.IsDeleted;
		//	//					weeklyClinicDTO.weeklyClinicDataTable.Add(Data);
		//	//				};
		//	//				weeklyClinicDTO.Comment = weeklyClinic.Comment;
		//	//				weeklyClinicDTO.Q_ManagerSig = weeklyClinic.Q_ManagerSig;
		//	//				weeklyClinicDTO.userName = weeklyClinic.user.UserName;
		//	//				weeklyClinicDTO.FormStatus = weeklyClinic.FormStatus;
		//	//				List<weeklyClinicImages> weeklyClinicImages = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).ToList();
		//	//				foreach (var item in weeklyClinicImages)
		//	//				{
		//	//					string FileName = item.FileName;
		//	//					weeklyClinicDTO.Images.Add(FileName);

		//	//				}
		//	//				newTemp.Add(weeklyClinicDTO);
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
		//				List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall().Where(c => c.weeklyClinicResponsability.ResponsibilityName == Responability).ToList();
		//				List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
		//				foreach (WeeklyClinic weeklyClinic in temp)
		//				{
		//					WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
		//					weeklyClinicDTO.Id = weeklyClinic.Id;
		//					//weeklyClinicDTO.Rig = weeklyClinic.Rig.Number;
		//					weeklyClinicDTO.Title = weeklyClinic.Title;
		//					weeklyClinicDTO.FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName;
		//					weeklyClinicDTO.ReportNo = weeklyClinic.ReportNo;
		//					weeklyClinicDTO.DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity;
		//					weeklyClinicDTO.Standard = weeklyClinic.Standard.StandardName;
		//					weeklyClinicDTO.ClauseNo = weeklyClinic.ClauseNo;
		//					weeklyClinicDTO.ObjectiveEvidence = weeklyClinic.ObjectiveEvidence;
		//					foreach (var item in weeklyClinic.weeklyClinicAndObservation)
		//					{
		//						string observation = item.weeklyClinicObservation.Observation;
		//						weeklyClinicDTO.weeklyClinicAndObservation.Add(observation);

		//					}
		//					foreach (var item in weeklyClinic.weeklyClinicAndRootCauses)
		//					{
		//						string cause = item.RootCauses.CauseName;
		//						weeklyClinicDTO.weeklyClinicAndRootCauses.Add(cause);

		//					}
		//					weeklyClinicDTO.IfOtherObservation = weeklyClinic.IfOtherObservation;
		//					weeklyClinicDTO.UpdateRisk = weeklyClinic.UpdateRisk;
		//					weeklyClinicDTO.IfUpdate = weeklyClinic.IfUpdate;
		//					weeklyClinicDTO.ManagementOfChange = weeklyClinic.ManagementOfChange;
		//					weeklyClinicDTO.IfManagementOfChange = weeklyClinic.IfManagementOfChange;
		//					weeklyClinicDTO.NameRasiedBy = weeklyClinic.NameRasiedBy;
		//					//weeklyClinicDTO.SigRasiedBy = weeklyClinic.SigRasiedBy;
		//					weeklyClinicDTO.DateRaisedBy = weeklyClinic.DateRaisedBy;
		//					weeklyClinicDTO.IfOtherRootCause = weeklyClinic.IfOtherRootCause;
		//					foreach (var item in weeklyClinic.weeklyClinicDataTable)
		//					{
		//						weeklyClinicDataTable Data = new weeklyClinicDataTable();
		//						Data.Id = item.Id;
		//						Data.SN = item.SN;
		//						Data.WeeklyClinicSelected = item.WeeklyClinicSelected;
		//						Data.Action = item.Action;
		//						Data.Responsible = item.Responsible;
		//						Data.SuggestedDate = item.SuggestedDate;
		//						Data.AchievementDate = item.AchievementDate;
		//						Data.Status = item.Status;
		//						Data.WeeklyClinicId = item.WeeklyClinicId;
		//						Data.FollowUpAudit = item.FollowUpAudit;
		//						Data.IsDeleted = item.IsDeleted;
		//						weeklyClinicDTO.weeklyClinicDataTable.Add(Data);
		//					};
		//					weeklyClinicDTO.Comment = weeklyClinic.Comment;
		//					weeklyClinicDTO.Q_ManagerSig = weeklyClinic.Q_ManagerSig;
		//					//weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
		//					weeklyClinicDTO.userName = weeklyClinic.user.UserName;
		//					weeklyClinicDTO.FormStatus = weeklyClinic.FormStatus;
		//					List<weeklyClinicImages> weeklyClinicImages = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).ToList();
		//					foreach (var item in weeklyClinicImages)
		//					{
		//						string FileName = item.FileName;
		//						weeklyClinicDTO.Images.Add(FileName);

		//					}
		//					newTemp.Add(weeklyClinicDTO);
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
		//				List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall().Where(a => a.user.Id == UserID && a.weeklyClinicResponsability.ResponsibilityName == Responability).ToList();
		//				List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
		//				foreach (WeeklyClinic weeklyClinic in temp)
		//				{
		//					WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
		//					weeklyClinicDTO.Id = weeklyClinic.Id;
		//					//weeklyClinicDTO.Rig = weeklyClinic.Rig.Number;
		//					weeklyClinicDTO.Title = weeklyClinic.Title;
		//					weeklyClinicDTO.FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName;
		//					weeklyClinicDTO.ReportNo = weeklyClinic.ReportNo;
		//					weeklyClinicDTO.DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity;
		//					weeklyClinicDTO.Standard = weeklyClinic.Standard.StandardName;
		//					weeklyClinicDTO.ClauseNo = weeklyClinic.ClauseNo;
		//					weeklyClinicDTO.ObjectiveEvidence = weeklyClinic.ObjectiveEvidence;
		//					foreach (var item in weeklyClinic.weeklyClinicAndObservation)
		//					{
		//						string observation = item.weeklyClinicObservation.Observation;
		//						weeklyClinicDTO.weeklyClinicAndObservation.Add(observation);

		//					}
		//					foreach (var item in weeklyClinic.weeklyClinicAndRootCauses)
		//					{
		//						string cause = item.RootCauses.CauseName;
		//						weeklyClinicDTO.weeklyClinicAndRootCauses.Add(cause);

		//					}
		//					weeklyClinicDTO.IfOtherObservation = weeklyClinic.IfOtherObservation;
		//					weeklyClinicDTO.UpdateRisk = weeklyClinic.UpdateRisk;
		//					weeklyClinicDTO.IfUpdate = weeklyClinic.IfUpdate;
		//					weeklyClinicDTO.ManagementOfChange = weeklyClinic.ManagementOfChange;
		//					weeklyClinicDTO.IfManagementOfChange = weeklyClinic.IfManagementOfChange;
		//					weeklyClinicDTO.NameRasiedBy = weeklyClinic.NameRasiedBy;
		//					//weeklyClinicDTO.SigRasiedBy = weeklyClinic.SigRasiedBy;
		//					weeklyClinicDTO.DateRaisedBy = weeklyClinic.DateRaisedBy;
		//					weeklyClinicDTO.IfOtherRootCause = weeklyClinic.IfOtherRootCause;
		//					foreach (var item in weeklyClinic.weeklyClinicDataTable)
		//					{
		//						weeklyClinicDataTable Data = new weeklyClinicDataTable();
		//						Data.Id = item.Id;
		//						Data.SN = item.SN;
		//						Data.WeeklyClinicSelected = item.WeeklyClinicSelected;
		//						Data.Action = item.Action;
		//						Data.Responsible = item.Responsible;
		//						Data.SuggestedDate = item.SuggestedDate;
		//						Data.AchievementDate = item.AchievementDate;
		//						Data.Status = item.Status;
		//						Data.WeeklyClinicId = item.WeeklyClinicId;
		//						Data.FollowUpAudit = item.FollowUpAudit;
		//						Data.IsDeleted = item.IsDeleted;
		//						weeklyClinicDTO.weeklyClinicDataTable.Add(Data);
		//					};
		//					weeklyClinicDTO.Comment = weeklyClinic.Comment;
		//					weeklyClinicDTO.Q_ManagerSig = weeklyClinic.Q_ManagerSig;
		//					//weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
		//					weeklyClinicDTO.userName = weeklyClinic.user.UserName;
		//					weeklyClinicDTO.FormStatus = weeklyClinic.FormStatus;
		//					List<weeklyClinicImages> weeklyClinicImages = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).ToList();
		//					foreach (var item in weeklyClinicImages)
		//					{
		//						string FileName = item.FileName;
		//						weeklyClinicDTO.Images.Add(FileName);

		//					}
		//					newTemp.Add(weeklyClinicDTO);
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
		//				List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall().Where(c => c.Standard.StandardName == Standard).ToList();
		//				List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
		//				foreach (WeeklyClinic weeklyClinic in temp)
		//				{
		//					WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
		//					weeklyClinicDTO.Id = weeklyClinic.Id;
		//					//weeklyClinicDTO.Rig = weeklyClinic.Rig.Number;
		//					weeklyClinicDTO.Title = weeklyClinic.Title;
		//					weeklyClinicDTO.FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName;
		//					weeklyClinicDTO.ReportNo = weeklyClinic.ReportNo;
		//					weeklyClinicDTO.DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity;
		//					weeklyClinicDTO.Standard = weeklyClinic.Standard.StandardName;
		//					weeklyClinicDTO.ClauseNo = weeklyClinic.ClauseNo;
		//					weeklyClinicDTO.ObjectiveEvidence = weeklyClinic.ObjectiveEvidence;
		//					foreach (var item in weeklyClinic.weeklyClinicAndObservation)
		//					{
		//						string observation = item.weeklyClinicObservation.Observation;
		//						weeklyClinicDTO.weeklyClinicAndObservation.Add(observation);

		//					}
		//					foreach (var item in weeklyClinic.weeklyClinicAndRootCauses)
		//					{
		//						string cause = item.RootCauses.CauseName;
		//						weeklyClinicDTO.weeklyClinicAndRootCauses.Add(cause);

		//					}
		//					weeklyClinicDTO.IfOtherObservation = weeklyClinic.IfOtherObservation;
		//					weeklyClinicDTO.UpdateRisk = weeklyClinic.UpdateRisk;
		//					weeklyClinicDTO.IfUpdate = weeklyClinic.IfUpdate;
		//					weeklyClinicDTO.ManagementOfChange = weeklyClinic.ManagementOfChange;
		//					weeklyClinicDTO.IfManagementOfChange = weeklyClinic.IfManagementOfChange;
		//					weeklyClinicDTO.NameRasiedBy = weeklyClinic.NameRasiedBy;
		//					//weeklyClinicDTO.SigRasiedBy = weeklyClinic.SigRasiedBy;
		//					weeklyClinicDTO.DateRaisedBy = weeklyClinic.DateRaisedBy;
		//					weeklyClinicDTO.IfOtherRootCause = weeklyClinic.IfOtherRootCause;
		//					foreach (var item in weeklyClinic.weeklyClinicDataTable)
		//					{
		//						weeklyClinicDataTable Data = new weeklyClinicDataTable();
		//						Data.Id = item.Id;
		//						Data.SN = item.SN;
		//						Data.WeeklyClinicSelected = item.WeeklyClinicSelected;
		//						Data.Action = item.Action;
		//						Data.Responsible = item.Responsible;
		//						Data.SuggestedDate = item.SuggestedDate;
		//						Data.AchievementDate = item.AchievementDate;
		//						Data.Status = item.Status;
		//						Data.WeeklyClinicId = item.WeeklyClinicId;
		//						Data.FollowUpAudit = item.FollowUpAudit;
		//						Data.IsDeleted = item.IsDeleted;
		//						weeklyClinicDTO.weeklyClinicDataTable.Add(Data);
		//					};
		//					weeklyClinicDTO.Comment = weeklyClinic.Comment;
		//					weeklyClinicDTO.Q_ManagerSig = weeklyClinic.Q_ManagerSig;
		//					//weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
		//					weeklyClinicDTO.userName = weeklyClinic.user.UserName;
		//					weeklyClinicDTO.FormStatus = weeklyClinic.FormStatus;
		//					List<weeklyClinicImages> weeklyClinicImages = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).ToList();
		//					foreach (var item in weeklyClinicImages)
		//					{
		//						string FileName = item.FileName;
		//						weeklyClinicDTO.Images.Add(FileName);

		//					}
		//					newTemp.Add(weeklyClinicDTO);
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
		//				List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall().Where(a => a.user.Id == UserID && a.Standard.StandardName == Standard).ToList();
		//				List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
		//				foreach (WeeklyClinic weeklyClinic in temp)
		//				{
		//					WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
		//					weeklyClinicDTO.Id = weeklyClinic.Id;
		//					//weeklyClinicDTO.Rig = weeklyClinic.Rig.Number;
		//					weeklyClinicDTO.Title = weeklyClinic.Title;
		//					weeklyClinicDTO.FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName;
		//					weeklyClinicDTO.ReportNo = weeklyClinic.ReportNo;
		//					weeklyClinicDTO.DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity;
		//					weeklyClinicDTO.Standard = weeklyClinic.Standard.StandardName;
		//					weeklyClinicDTO.ClauseNo = weeklyClinic.ClauseNo;
		//					weeklyClinicDTO.ObjectiveEvidence = weeklyClinic.ObjectiveEvidence;
		//					foreach (var item in weeklyClinic.weeklyClinicAndObservation)
		//					{
		//						string observation = item.weeklyClinicObservation.Observation;
		//						weeklyClinicDTO.weeklyClinicAndObservation.Add(observation);

		//					}
		//					foreach (var item in weeklyClinic.weeklyClinicAndRootCauses)
		//					{
		//						string cause = item.RootCauses.CauseName;
		//						weeklyClinicDTO.weeklyClinicAndRootCauses.Add(cause);

		//					}
		//					weeklyClinicDTO.IfOtherObservation = weeklyClinic.IfOtherObservation;
		//					weeklyClinicDTO.UpdateRisk = weeklyClinic.UpdateRisk;
		//					weeklyClinicDTO.IfUpdate = weeklyClinic.IfUpdate;
		//					weeklyClinicDTO.ManagementOfChange = weeklyClinic.ManagementOfChange;
		//					weeklyClinicDTO.IfManagementOfChange = weeklyClinic.IfManagementOfChange;
		//					weeklyClinicDTO.NameRasiedBy = weeklyClinic.NameRasiedBy;
		//					//weeklyClinicDTO.SigRasiedBy = weeklyClinic.SigRasiedBy;
		//					weeklyClinicDTO.DateRaisedBy = weeklyClinic.DateRaisedBy;
		//					weeklyClinicDTO.IfOtherRootCause = weeklyClinic.IfOtherRootCause;
		//					foreach (var item in weeklyClinic.weeklyClinicDataTable)
		//					{
		//						weeklyClinicDataTable Data = new weeklyClinicDataTable();
		//						Data.Id = item.Id;
		//						Data.SN = item.SN;
		//						Data.WeeklyClinicSelected = item.WeeklyClinicSelected;
		//						Data.Action = item.Action;
		//						Data.Responsible = item.Responsible;
		//						Data.SuggestedDate = item.SuggestedDate;
		//						Data.AchievementDate = item.AchievementDate;
		//						Data.Status = item.Status;
		//						Data.WeeklyClinicId = item.WeeklyClinicId;
		//						Data.FollowUpAudit = item.FollowUpAudit;
		//						Data.IsDeleted = item.IsDeleted;
		//						weeklyClinicDTO.weeklyClinicDataTable.Add(Data);
		//					};
		//					weeklyClinicDTO.Comment = weeklyClinic.Comment;
		//					weeklyClinicDTO.Q_ManagerSig = weeklyClinic.Q_ManagerSig;
		//					//weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
		//					weeklyClinicDTO.userName = weeklyClinic.user.UserName;
		//					weeklyClinicDTO.FormStatus = weeklyClinic.FormStatus;
		//					List<weeklyClinicImages> weeklyClinicImages = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).ToList();
		//					foreach (var item in weeklyClinicImages)
		//					{
		//						string FileName = item.FileName;
		//						weeklyClinicDTO.Images.Add(FileName);

		//					}
		//					newTemp.Add(weeklyClinicDTO);
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
		//				List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall().Where(x => x.weeklyClinicAndObservation.Any(obs => obs.weeklyClinicObservation.Observation == Observation)).ToList();
		//				List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
		//				foreach (WeeklyClinic weeklyClinic in temp)
		//				{
		//					WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
		//					weeklyClinicDTO.Id = weeklyClinic.Id;
		//					//weeklyClinicDTO.Rig = weeklyClinic.Rig.Number;
		//					weeklyClinicDTO.Title = weeklyClinic.Title;
		//					weeklyClinicDTO.FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName;
		//					weeklyClinicDTO.ReportNo = weeklyClinic.ReportNo;
		//					weeklyClinicDTO.DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity;
		//					weeklyClinicDTO.Standard = weeklyClinic.Standard.StandardName;
		//					weeklyClinicDTO.ClauseNo = weeklyClinic.ClauseNo;
		//					weeklyClinicDTO.ObjectiveEvidence = weeklyClinic.ObjectiveEvidence;
		//					foreach (var item in weeklyClinic.weeklyClinicAndObservation)
		//					{
		//						string observation = item.weeklyClinicObservation.Observation;
		//						weeklyClinicDTO.weeklyClinicAndObservation.Add(observation);

		//					}
		//					foreach (var item in weeklyClinic.weeklyClinicAndRootCauses)
		//					{
		//						string cause = item.RootCauses.CauseName;
		//						weeklyClinicDTO.weeklyClinicAndRootCauses.Add(cause);

		//					}
		//					weeklyClinicDTO.IfOtherObservation = weeklyClinic.IfOtherObservation;
		//					weeklyClinicDTO.UpdateRisk = weeklyClinic.UpdateRisk;
		//					weeklyClinicDTO.IfUpdate = weeklyClinic.IfUpdate;
		//					weeklyClinicDTO.ManagementOfChange = weeklyClinic.ManagementOfChange;
		//					weeklyClinicDTO.IfManagementOfChange = weeklyClinic.IfManagementOfChange;
		//					weeklyClinicDTO.NameRasiedBy = weeklyClinic.NameRasiedBy;
		//					//weeklyClinicDTO.SigRasiedBy = weeklyClinic.SigRasiedBy;
		//					weeklyClinicDTO.DateRaisedBy = weeklyClinic.DateRaisedBy;
		//					weeklyClinicDTO.IfOtherRootCause = weeklyClinic.IfOtherRootCause;
		//					foreach (var item in weeklyClinic.weeklyClinicDataTable)
		//					{
		//						weeklyClinicDataTable Data = new weeklyClinicDataTable();
		//						Data.Id = item.Id;
		//						Data.SN = item.SN;
		//						Data.WeeklyClinicSelected = item.WeeklyClinicSelected;
		//						Data.Action = item.Action;
		//						Data.Responsible = item.Responsible;
		//						Data.SuggestedDate = item.SuggestedDate;
		//						Data.AchievementDate = item.AchievementDate;
		//						Data.Status = item.Status;
		//						Data.WeeklyClinicId = item.WeeklyClinicId;
		//						Data.FollowUpAudit = item.FollowUpAudit;
		//						Data.IsDeleted = item.IsDeleted;
		//						weeklyClinicDTO.weeklyClinicDataTable.Add(Data);
		//					};
		//					weeklyClinicDTO.Comment = weeklyClinic.Comment;
		//					weeklyClinicDTO.Q_ManagerSig = weeklyClinic.Q_ManagerSig;
		//					//weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
		//					weeklyClinicDTO.userName = weeklyClinic.user.UserName;
		//					weeklyClinicDTO.FormStatus = weeklyClinic.FormStatus;
		//					List<weeklyClinicImages> weeklyClinicImages = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).ToList();
		//					foreach (var item in weeklyClinicImages)
		//					{
		//						string FileName = item.FileName;
		//						weeklyClinicDTO.Images.Add(FileName);

		//					}
		//					newTemp.Add(weeklyClinicDTO);
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
		//				List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall().Where(a => a.user.Id == UserID && a.weeklyClinicAndObservation.Any(obs => obs.weeklyClinicObservation.Observation == Observation)).ToList();
		//				List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
		//				foreach (WeeklyClinic weeklyClinic in temp)
		//				{
		//					WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
		//					weeklyClinicDTO.Id = weeklyClinic.Id;
		//					//weeklyClinicDTO.Rig = weeklyClinic.Rig.Number;
		//					weeklyClinicDTO.Title = weeklyClinic.Title;
		//					weeklyClinicDTO.FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName;
		//					weeklyClinicDTO.ReportNo = weeklyClinic.ReportNo;
		//					weeklyClinicDTO.DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity;
		//					weeklyClinicDTO.Standard = weeklyClinic.Standard.StandardName;
		//					weeklyClinicDTO.ClauseNo = weeklyClinic.ClauseNo;
		//					weeklyClinicDTO.ObjectiveEvidence = weeklyClinic.ObjectiveEvidence;
		//					foreach (var item in weeklyClinic.weeklyClinicAndObservation)
		//					{
		//						string observation = item.weeklyClinicObservation.Observation;
		//						weeklyClinicDTO.weeklyClinicAndObservation.Add(observation);

		//					}
		//					foreach (var item in weeklyClinic.weeklyClinicAndRootCauses)
		//					{
		//						string cause = item.RootCauses.CauseName;
		//						weeklyClinicDTO.weeklyClinicAndRootCauses.Add(cause);

		//					}
		//					weeklyClinicDTO.IfOtherObservation = weeklyClinic.IfOtherObservation;
		//					weeklyClinicDTO.UpdateRisk = weeklyClinic.UpdateRisk;
		//					weeklyClinicDTO.IfUpdate = weeklyClinic.IfUpdate;
		//					weeklyClinicDTO.ManagementOfChange = weeklyClinic.ManagementOfChange;
		//					weeklyClinicDTO.IfManagementOfChange = weeklyClinic.IfManagementOfChange;
		//					weeklyClinicDTO.NameRasiedBy = weeklyClinic.NameRasiedBy;
		//					//weeklyClinicDTO.SigRasiedBy = weeklyClinic.SigRasiedBy;
		//					weeklyClinicDTO.DateRaisedBy = weeklyClinic.DateRaisedBy;
		//					weeklyClinicDTO.IfOtherRootCause = weeklyClinic.IfOtherRootCause;
		//					foreach (var item in weeklyClinic.weeklyClinicDataTable)
		//					{
		//						weeklyClinicDataTable Data = new weeklyClinicDataTable();
		//						Data.Id = item.Id;
		//						Data.SN = item.SN;
		//						Data.WeeklyClinicSelected = item.WeeklyClinicSelected;
		//						Data.Action = item.Action;
		//						Data.Responsible = item.Responsible;
		//						Data.SuggestedDate = item.SuggestedDate;
		//						Data.AchievementDate = item.AchievementDate;
		//						Data.Status = item.Status;
		//						Data.WeeklyClinicId = item.WeeklyClinicId;
		//						Data.FollowUpAudit = item.FollowUpAudit;
		//						Data.IsDeleted = item.IsDeleted;
		//						weeklyClinicDTO.weeklyClinicDataTable.Add(Data);
		//					};
		//					weeklyClinicDTO.Comment = weeklyClinic.Comment;
		//					weeklyClinicDTO.Q_ManagerSig = weeklyClinic.Q_ManagerSig;
		//					//weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
		//					weeklyClinicDTO.userName = weeklyClinic.user.UserName;
		//					weeklyClinicDTO.FormStatus = weeklyClinic.FormStatus;
		//					List<weeklyClinicImages> weeklyClinicImages = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).ToList();
		//					foreach (var item in weeklyClinicImages)
		//					{
		//						string FileName = item.FileName;
		//						weeklyClinicDTO.Images.Add(FileName);

		//					}
		//					newTemp.Add(weeklyClinicDTO);
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
					List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall();
					List<WeeklyClinicExcelDTO> newTemp = new List<WeeklyClinicExcelDTO>();
					foreach (WeeklyClinic weeklyClinic in temp)
					{
						WeeklyClinicExcelDTO weeklyClinicDTO = new WeeklyClinicExcelDTO();
						//weeklyClinicDTO.Rig = weeklyClinic.Rig.Number;
						weeklyClinicDTO.RigNo = weeklyClinic.Rig.Number;
						weeklyClinicDTO.Date = weeklyClinic.Date;
						weeklyClinicDTO.WeeklyClinicNo = weeklyClinic.WeeklyClinicNo;
						weeklyClinicDTO.MedicalReportNo = weeklyClinic.MedicalReportNo;
						weeklyClinicDTO.LastFirstAidDrillNo = weeklyClinic.LastFirstAidDrillNo;
						weeklyClinicDTO.HealthMeetingNo = weeklyClinic.HealthMeetingNo;
						weeklyClinicDTO.Topics = weeklyClinic.Topics;
						weeklyClinicDTO.HealthStatus = weeklyClinic.HealthStatus;
						weeklyClinicDTO.HealthStatusComment = weeklyClinic.HealthStatusComment;
						weeklyClinicDTO.LifeSavingApparatuses = weeklyClinic.LifeSavingApparatuses;
						weeklyClinicDTO.LifeSavingApparatusesComment = weeklyClinic.LifeSavingApparatusesComment;
						weeklyClinicDTO.VaccinesAvailable = weeklyClinic.VaccinesAvailable;
						weeklyClinicDTO.VaccinesAvailableComment = weeklyClinic.VaccinesAvailableComment;
						weeklyClinicDTO.ERP = weeklyClinic.ERP;
						weeklyClinicDTO.ERPComment = weeklyClinic.ERPComment;
						weeklyClinicDTO.MedicalStretcher = weeklyClinic.MedicalStretcher;
						weeklyClinicDTO.MedicalStretcherComment = weeklyClinic.MedicalStretcherComment;
						weeklyClinicDTO.WaterTest = weeklyClinic.WaterTest;
						weeklyClinicDTO.WaterTestComment = weeklyClinic.WaterTestComment;
						weeklyClinicDTO.BloodSugar = weeklyClinic.BloodSugar;
						weeklyClinicDTO.BloodSugarComment = weeklyClinic.BloodSugarComment;
						weeklyClinicDTO.FirstAidBox = weeklyClinic.FirstAidBox;
						weeklyClinicDTO.FirstAidBoxComment = weeklyClinic.FirstAidBoxComment;
						weeklyClinicDTO.FullO2Cylinder = weeklyClinic.FullO2Cylinder;
						weeklyClinicDTO.FullO2CylinderComment = weeklyClinic.FullO2CylinderComment;
						weeklyClinicDTO.MedicalWaste = weeklyClinic.MedicalWaste;
						weeklyClinicDTO.MedicalWasteComment = weeklyClinic.MedicalWasteComment;
						weeklyClinicDTO.MedicinesExpiryDate = weeklyClinic.MedicinesExpiryDate;
						weeklyClinicDTO.MedicinesExpiryDateComment = weeklyClinic.MedicinesExpiryDateComment;
						weeklyClinicDTO.OtherComments = weeklyClinic.OtherComments;
						weeklyClinicDTO.DoctorName = weeklyClinic.DoctorName;
						weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
						weeklyClinicDTO.userName = weeklyClinic.user.UserName;
						foreach (var item in weeklyClinic.FridgeComponents)
						{
							FridgeComponentExcelDTO fridgeComponentDTO = new FridgeComponentExcelDTO();
							fridgeComponentDTO.Item = item.Item;
							fridgeComponentDTO.Quantity = item.Quantity;
							fridgeComponentDTO.ExpireDate = item.ExpireDate;
							weeklyClinicDTO.FridgeComponents.Add(fridgeComponentDTO);
						}
						foreach (var item in weeklyClinic.DrugInventory)
						{
							DrugInventoryExcelDTO drugInventoryDTO = new DrugInventoryExcelDTO();
							drugInventoryDTO.Item = item.Item;
							drugInventoryDTO.Quantity = item.Quantity;
							drugInventoryDTO.ExpireDate = item.ExpireDate;
							weeklyClinicDTO.DrugInventory.Add(drugInventoryDTO);
						}

						newTemp.Add(weeklyClinicDTO);
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
					List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall().Where(a => a.user.Id == UserID).ToList();
					List<WeeklyClinicExcelDTO> newTemp = new List<WeeklyClinicExcelDTO>();
					foreach (WeeklyClinic weeklyClinic in temp)
					{
						WeeklyClinicExcelDTO weeklyClinicDTO = new WeeklyClinicExcelDTO();
						//weeklyClinicDTO.Rig = weeklyClinic.Rig.Number;
						weeklyClinicDTO.RigNo = weeklyClinic.Rig.Number;
						weeklyClinicDTO.Date = weeklyClinic.Date;
						weeklyClinicDTO.WeeklyClinicNo = weeklyClinic.WeeklyClinicNo;
						weeklyClinicDTO.MedicalReportNo = weeklyClinic.MedicalReportNo;
						weeklyClinicDTO.LastFirstAidDrillNo = weeklyClinic.LastFirstAidDrillNo;
						weeklyClinicDTO.HealthMeetingNo = weeklyClinic.HealthMeetingNo;
						weeklyClinicDTO.Topics = weeklyClinic.Topics;
						weeklyClinicDTO.HealthStatus = weeklyClinic.HealthStatus;
						weeklyClinicDTO.HealthStatusComment = weeklyClinic.HealthStatusComment;
						weeklyClinicDTO.LifeSavingApparatuses = weeklyClinic.LifeSavingApparatuses;
						weeklyClinicDTO.LifeSavingApparatusesComment = weeklyClinic.LifeSavingApparatusesComment;
						weeklyClinicDTO.VaccinesAvailable = weeklyClinic.VaccinesAvailable;
						weeklyClinicDTO.VaccinesAvailableComment = weeklyClinic.VaccinesAvailableComment;
						weeklyClinicDTO.ERP = weeklyClinic.ERP;
						weeklyClinicDTO.ERPComment = weeklyClinic.ERPComment;
						weeklyClinicDTO.MedicalStretcher = weeklyClinic.MedicalStretcher;
						weeklyClinicDTO.MedicalStretcherComment = weeklyClinic.MedicalStretcherComment;
						weeklyClinicDTO.WaterTest = weeklyClinic.WaterTest;
						weeklyClinicDTO.WaterTestComment = weeklyClinic.WaterTestComment;
						weeklyClinicDTO.BloodSugar = weeklyClinic.BloodSugar;
						weeklyClinicDTO.BloodSugarComment = weeklyClinic.BloodSugarComment;
						weeklyClinicDTO.FirstAidBox = weeklyClinic.FirstAidBox;
						weeklyClinicDTO.FirstAidBoxComment = weeklyClinic.FirstAidBoxComment;
						weeklyClinicDTO.FullO2Cylinder = weeklyClinic.FullO2Cylinder;
						weeklyClinicDTO.FullO2CylinderComment = weeklyClinic.FullO2CylinderComment;
						weeklyClinicDTO.MedicalWaste = weeklyClinic.MedicalWaste;
						weeklyClinicDTO.MedicalWasteComment = weeklyClinic.MedicalWasteComment;
						weeklyClinicDTO.MedicinesExpiryDate = weeklyClinic.MedicinesExpiryDate;
						weeklyClinicDTO.MedicinesExpiryDateComment = weeklyClinic.MedicinesExpiryDateComment;
						weeklyClinicDTO.OtherComments = weeklyClinic.OtherComments;
						weeklyClinicDTO.DoctorName = weeklyClinic.DoctorName;
						weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
						weeklyClinicDTO.userName = weeklyClinic.user.UserName;
						foreach (var item in weeklyClinic.FridgeComponents)
						{
							FridgeComponentExcelDTO fridgeComponentDTO = new FridgeComponentExcelDTO();
							fridgeComponentDTO.Item = item.Item;
							fridgeComponentDTO.Quantity = item.Quantity;
							fridgeComponentDTO.ExpireDate = item.ExpireDate;
							weeklyClinicDTO.FridgeComponents.Add(fridgeComponentDTO);
						}
						foreach (var item in weeklyClinic.DrugInventory)
						{
							DrugInventoryExcelDTO drugInventoryDTO = new DrugInventoryExcelDTO();
							drugInventoryDTO.Item = item.Item;
							drugInventoryDTO.Quantity = item.Quantity;
							drugInventoryDTO.ExpireDate = item.ExpireDate;
							weeklyClinicDTO.DrugInventory.Add(drugInventoryDTO);
						}

						newTemp.Add(weeklyClinicDTO);
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
		public PageResult<WeeklyClinicResponseDTO> GettAllweeklyClinicByPage(string UserId, string UserRole, int? page, int pagesize = 10)
		{
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall();
					List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
					foreach (WeeklyClinic weeklyClinic in temp)
					{
						WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
						weeklyClinicDTO.Id = weeklyClinic.Id;
						weeklyClinicDTO.RigNo = weeklyClinic.Rig.Number;
						weeklyClinicDTO.Date = weeklyClinic.Date;
						weeklyClinicDTO.WeeklyClinicNo = weeklyClinic.WeeklyClinicNo;
						weeklyClinicDTO.MedicalReportNo = weeklyClinic.MedicalReportNo;
						weeklyClinicDTO.LastFirstAidDrillNo = weeklyClinic.LastFirstAidDrillNo;
						weeklyClinicDTO.HealthMeetingNo = weeklyClinic.HealthMeetingNo;
						weeklyClinicDTO.Topics = weeklyClinic.Topics;
						weeklyClinicDTO.HealthStatus = weeklyClinic.HealthStatus;
						weeklyClinicDTO.HealthStatusComment = weeklyClinic.HealthStatusComment;
						weeklyClinicDTO.LifeSavingApparatuses = weeklyClinic.LifeSavingApparatuses;
						weeklyClinicDTO.LifeSavingApparatusesComment = weeklyClinic.LifeSavingApparatusesComment;
						weeklyClinicDTO.VaccinesAvailable = weeklyClinic.VaccinesAvailable;
						weeklyClinicDTO.VaccinesAvailableComment = weeklyClinic.VaccinesAvailableComment;
						weeklyClinicDTO.ERP = weeklyClinic.ERP;
						weeklyClinicDTO.ERPComment = weeklyClinic.ERPComment;
						weeklyClinicDTO.MedicalStretcher = weeklyClinic.MedicalStretcher;
						weeklyClinicDTO.MedicalStretcherComment = weeklyClinic.MedicalStretcherComment;
						weeklyClinicDTO.WaterTest = weeklyClinic.WaterTest;
						weeklyClinicDTO.WaterTestComment = weeklyClinic.WaterTestComment;
						weeklyClinicDTO.BloodSugar = weeklyClinic.BloodSugar;
						weeklyClinicDTO.BloodSugarComment = weeklyClinic.BloodSugarComment;
						weeklyClinicDTO.FirstAidBox = weeklyClinic.FirstAidBox;
						weeklyClinicDTO.FirstAidBoxComment = weeklyClinic.FirstAidBoxComment;
						weeklyClinicDTO.FullO2Cylinder = weeklyClinic.FullO2Cylinder;
						weeklyClinicDTO.FullO2CylinderComment = weeklyClinic.FullO2CylinderComment;
						weeklyClinicDTO.MedicalWaste = weeklyClinic.MedicalWaste;
						weeklyClinicDTO.MedicalWasteComment = weeklyClinic.MedicalWasteComment;
						weeklyClinicDTO.MedicinesExpiryDate = weeklyClinic.MedicinesExpiryDate;
						weeklyClinicDTO.MedicinesExpiryDateComment = weeklyClinic.MedicinesExpiryDateComment;
						weeklyClinicDTO.OtherComments = weeklyClinic.OtherComments;
						weeklyClinicDTO.DoctorName = weeklyClinic.DoctorName;
						weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
						weeklyClinicDTO.userName = weeklyClinic.user.UserName;
						foreach (var item in weeklyClinic.FridgeComponents)
						{
							FridgeComponentDTO fridgeComponentDTO = new FridgeComponentDTO();
							fridgeComponentDTO.Id = item.Id;
							fridgeComponentDTO.Item = item.Item;
							fridgeComponentDTO.Quantity = item.Quantity;
							fridgeComponentDTO.ExpireDate = item.ExpireDate;
							fridgeComponentDTO.WeeklyClinicId = item.WeeklyClinicId;
							fridgeComponentDTO.IsDeleted = item.IsDeleted;
							weeklyClinicDTO.FridgeComponents.Add(fridgeComponentDTO);
						}
						foreach (var item in weeklyClinic.DrugInventory)
						{
							DrugInventoryDTO drugInventoryDTO = new DrugInventoryDTO();
							drugInventoryDTO.Id = item.Id;
							drugInventoryDTO.Item = item.Item;
							drugInventoryDTO.Quantity = item.Quantity;
							drugInventoryDTO.ExpireDate = item.ExpireDate;
							drugInventoryDTO.WeeklyClinicId = item.WeeklyClinicId;
							drugInventoryDTO.IsDeleted = item.IsDeleted;
							weeklyClinicDTO.DrugInventory.Add(drugInventoryDTO);
						}

						newTemp.Add(weeklyClinicDTO);
						//result.Data = prod;
					}


					float countDetails = WeeklyClinicRepoistory.getall().Count();
					var result = new PageResult<WeeklyClinicResponseDTO>
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
					List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall().Where(a => a.user.Id == UserId).ToList();
					List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
					foreach (WeeklyClinic weeklyClinic in temp)
					{
						WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
						weeklyClinicDTO.Id = weeklyClinic.Id;
						weeklyClinicDTO.RigNo = weeklyClinic.Rig.Number;
						weeklyClinicDTO.Date = weeklyClinic.Date;
						weeklyClinicDTO.WeeklyClinicNo = weeklyClinic.WeeklyClinicNo;
						weeklyClinicDTO.MedicalReportNo = weeklyClinic.MedicalReportNo;
						weeklyClinicDTO.LastFirstAidDrillNo = weeklyClinic.LastFirstAidDrillNo;
						weeklyClinicDTO.HealthMeetingNo = weeklyClinic.HealthMeetingNo;
						weeklyClinicDTO.Topics = weeklyClinic.Topics;
						weeklyClinicDTO.HealthStatus = weeklyClinic.HealthStatus;
						weeklyClinicDTO.HealthStatusComment = weeklyClinic.HealthStatusComment;
						weeklyClinicDTO.LifeSavingApparatuses = weeklyClinic.LifeSavingApparatuses;
						weeklyClinicDTO.LifeSavingApparatusesComment = weeklyClinic.LifeSavingApparatusesComment;
						weeklyClinicDTO.VaccinesAvailable = weeklyClinic.VaccinesAvailable;
						weeklyClinicDTO.VaccinesAvailableComment = weeklyClinic.VaccinesAvailableComment;
						weeklyClinicDTO.ERP = weeklyClinic.ERP;
						weeklyClinicDTO.ERPComment = weeklyClinic.ERPComment;
						weeklyClinicDTO.MedicalStretcher = weeklyClinic.MedicalStretcher;
						weeklyClinicDTO.MedicalStretcherComment = weeklyClinic.MedicalStretcherComment;
						weeklyClinicDTO.WaterTest = weeklyClinic.WaterTest;
						weeklyClinicDTO.WaterTestComment = weeklyClinic.WaterTestComment;
						weeklyClinicDTO.BloodSugar = weeklyClinic.BloodSugar;
						weeklyClinicDTO.BloodSugarComment = weeklyClinic.BloodSugarComment;
						weeklyClinicDTO.FirstAidBox = weeklyClinic.FirstAidBox;
						weeklyClinicDTO.FirstAidBoxComment = weeklyClinic.FirstAidBoxComment;
						weeklyClinicDTO.FullO2Cylinder = weeklyClinic.FullO2Cylinder;
						weeklyClinicDTO.FullO2CylinderComment = weeklyClinic.FullO2CylinderComment;
						weeklyClinicDTO.MedicalWaste = weeklyClinic.MedicalWaste;
						weeklyClinicDTO.MedicalWasteComment = weeklyClinic.MedicalWasteComment;
						weeklyClinicDTO.MedicinesExpiryDate = weeklyClinic.MedicinesExpiryDate;
						weeklyClinicDTO.MedicinesExpiryDateComment = weeklyClinic.MedicinesExpiryDateComment;
						weeklyClinicDTO.OtherComments = weeklyClinic.OtherComments;
						weeklyClinicDTO.DoctorName = weeklyClinic.DoctorName;
						weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
						weeklyClinicDTO.userName = weeklyClinic.user.UserName;
						foreach (var item in weeklyClinic.FridgeComponents)
						{
							FridgeComponentDTO fridgeComponentDTO = new FridgeComponentDTO();
							fridgeComponentDTO.Id = item.Id;
							fridgeComponentDTO.Item = item.Item;
							fridgeComponentDTO.Quantity = item.Quantity;
							fridgeComponentDTO.ExpireDate = item.ExpireDate;
							fridgeComponentDTO.WeeklyClinicId = item.WeeklyClinicId;
							fridgeComponentDTO.IsDeleted = item.IsDeleted;
							weeklyClinicDTO.FridgeComponents.Add(fridgeComponentDTO);
						}
						foreach (var item in weeklyClinic.DrugInventory)
						{
							DrugInventoryDTO drugInventoryDTO = new DrugInventoryDTO();
							drugInventoryDTO.Id = item.Id;
							drugInventoryDTO.Item = item.Item;
							drugInventoryDTO.Quantity = item.Quantity;
							drugInventoryDTO.ExpireDate = item.ExpireDate;
							drugInventoryDTO.WeeklyClinicId = item.WeeklyClinicId;
							drugInventoryDTO.IsDeleted = item.IsDeleted;
							weeklyClinicDTO.DrugInventory.Add(drugInventoryDTO);
						}

						newTemp.Add(weeklyClinicDTO);
						//result.Data = prod;
					}
					float countDetails = WeeklyClinicRepoistory.getall().Where(a => a.user.Id == UserId).Count();
					var result = new PageResult<WeeklyClinicResponseDTO>
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
				return new PageResult<WeeklyClinicResponseDTO>();

			}
			return new PageResult<WeeklyClinicResponseDTO>();
		}


		[HttpGet("GetDataById/{ID:int}")]
		public ActionResult<ResultDTO> GetAllWithDataByID(int ID, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();
			if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
			{
				WeeklyClinic weeklyClinic = WeeklyClinicRepoistory.getall().FirstOrDefault(a => a.Id == ID);
				if (weeklyClinic != null)
				{
					WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
					weeklyClinicDTO.Id = default;
					weeklyClinicDTO.RigNo = weeklyClinic.Rig.Number;
					weeklyClinicDTO.Date = weeklyClinic.Date;
					weeklyClinicDTO.WeeklyClinicNo = weeklyClinic.WeeklyClinicNo;
					weeklyClinicDTO.MedicalReportNo = weeklyClinic.MedicalReportNo;
					weeklyClinicDTO.LastFirstAidDrillNo = weeklyClinic.LastFirstAidDrillNo;
					weeklyClinicDTO.HealthMeetingNo = weeklyClinic.HealthMeetingNo;
					weeklyClinicDTO.Topics = weeklyClinic.Topics;
					weeklyClinicDTO.HealthStatus = weeklyClinic.HealthStatus;
					weeklyClinicDTO.HealthStatusComment = weeklyClinic.HealthStatusComment;
					weeklyClinicDTO.LifeSavingApparatuses = weeklyClinic.LifeSavingApparatuses;
					weeklyClinicDTO.LifeSavingApparatusesComment = weeklyClinic.LifeSavingApparatusesComment;
					weeklyClinicDTO.VaccinesAvailable = weeklyClinic.VaccinesAvailable;
					weeklyClinicDTO.VaccinesAvailableComment = weeklyClinic.VaccinesAvailableComment;
					weeklyClinicDTO.ERP = weeklyClinic.ERP;
					weeklyClinicDTO.ERPComment = weeklyClinic.ERPComment;
					weeklyClinicDTO.MedicalStretcher = weeklyClinic.MedicalStretcher;
					weeklyClinicDTO.MedicalStretcherComment = weeklyClinic.MedicalStretcherComment;
					weeklyClinicDTO.WaterTest = weeklyClinic.WaterTest;
					weeklyClinicDTO.WaterTestComment = weeklyClinic.WaterTestComment;
					weeklyClinicDTO.BloodSugar = weeklyClinic.BloodSugar;
					weeklyClinicDTO.BloodSugarComment = weeklyClinic.BloodSugarComment;
					weeklyClinicDTO.FirstAidBox = weeklyClinic.FirstAidBox;
					weeklyClinicDTO.FirstAidBoxComment = weeklyClinic.FirstAidBoxComment;
					weeklyClinicDTO.FullO2Cylinder = weeklyClinic.FullO2Cylinder;
					weeklyClinicDTO.FullO2CylinderComment = weeklyClinic.FullO2CylinderComment;
					weeklyClinicDTO.MedicalWaste = weeklyClinic.MedicalWaste;
					weeklyClinicDTO.MedicalWasteComment = weeklyClinic.MedicalWasteComment;
					weeklyClinicDTO.MedicinesExpiryDate = weeklyClinic.MedicinesExpiryDate;
					weeklyClinicDTO.MedicinesExpiryDateComment = weeklyClinic.MedicinesExpiryDateComment;
					weeklyClinicDTO.OtherComments = weeklyClinic.OtherComments;
					weeklyClinicDTO.DoctorName = weeklyClinic.DoctorName;
					weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
					weeklyClinicDTO.userName = weeklyClinic.user.UserName;
					foreach (var item in weeklyClinic.FridgeComponents)
					{
						FridgeComponentDTO fridgeComponentDTO = new FridgeComponentDTO();
						fridgeComponentDTO.Id = item.Id;
						fridgeComponentDTO.Item = item.Item;
						fridgeComponentDTO.Quantity = item.Quantity;
						fridgeComponentDTO.ExpireDate = item.ExpireDate;
						fridgeComponentDTO.WeeklyClinicId = item.WeeklyClinicId;
						fridgeComponentDTO.IsDeleted = item.IsDeleted;
						weeklyClinicDTO.FridgeComponents.Add(fridgeComponentDTO);
					}
					foreach (var item in weeklyClinic.DrugInventory)
					{
						DrugInventoryDTO drugInventoryDTO = new DrugInventoryDTO();
						drugInventoryDTO.Id = item.Id;
						drugInventoryDTO.Item = item.Item;
						drugInventoryDTO.Quantity = item.Quantity;
						drugInventoryDTO.ExpireDate = item.ExpireDate;
						drugInventoryDTO.WeeklyClinicId = item.WeeklyClinicId;
						drugInventoryDTO.IsDeleted = item.IsDeleted;
						weeklyClinicDTO.DrugInventory.Add(drugInventoryDTO);
					}


					result.Message = "Success";
					result.Statescode = 200;
					result.Data = weeklyClinicDTO;

					return result;
				}
			}
			else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
			{
				WeeklyClinic weeklyClinic = WeeklyClinicRepoistory.getall().FirstOrDefault(a => a.Id == ID && a.user.Id == UserId);
				if (weeklyClinic != null)
				{
					WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
					weeklyClinicDTO.Id = default;
					weeklyClinicDTO.RigNo = weeklyClinic.Rig.Number;
					weeklyClinicDTO.Date = weeklyClinic.Date;
					weeklyClinicDTO.WeeklyClinicNo = weeklyClinic.WeeklyClinicNo;
					weeklyClinicDTO.MedicalReportNo = weeklyClinic.MedicalReportNo;
					weeklyClinicDTO.LastFirstAidDrillNo = weeklyClinic.LastFirstAidDrillNo;
					weeklyClinicDTO.HealthMeetingNo = weeklyClinic.HealthMeetingNo;
					weeklyClinicDTO.Topics = weeklyClinic.Topics;
					weeklyClinicDTO.HealthStatus = weeklyClinic.HealthStatus;
					weeklyClinicDTO.HealthStatusComment = weeklyClinic.HealthStatusComment;
					weeklyClinicDTO.LifeSavingApparatuses = weeklyClinic.LifeSavingApparatuses;
					weeklyClinicDTO.LifeSavingApparatusesComment = weeklyClinic.LifeSavingApparatusesComment;
					weeklyClinicDTO.VaccinesAvailable = weeklyClinic.VaccinesAvailable;
					weeklyClinicDTO.VaccinesAvailableComment = weeklyClinic.VaccinesAvailableComment;
					weeklyClinicDTO.ERP = weeklyClinic.ERP;
					weeklyClinicDTO.ERPComment = weeklyClinic.ERPComment;
					weeklyClinicDTO.MedicalStretcher = weeklyClinic.MedicalStretcher;
					weeklyClinicDTO.MedicalStretcherComment = weeklyClinic.MedicalStretcherComment;
					weeklyClinicDTO.WaterTest = weeklyClinic.WaterTest;
					weeklyClinicDTO.WaterTestComment = weeklyClinic.WaterTestComment;
					weeklyClinicDTO.BloodSugar = weeklyClinic.BloodSugar;
					weeklyClinicDTO.BloodSugarComment = weeklyClinic.BloodSugarComment;
					weeklyClinicDTO.FirstAidBox = weeklyClinic.FirstAidBox;
					weeklyClinicDTO.FirstAidBoxComment = weeklyClinic.FirstAidBoxComment;
					weeklyClinicDTO.FullO2Cylinder = weeklyClinic.FullO2Cylinder;
					weeklyClinicDTO.FullO2CylinderComment = weeklyClinic.FullO2CylinderComment;
					weeklyClinicDTO.MedicalWaste = weeklyClinic.MedicalWaste;
					weeklyClinicDTO.MedicalWasteComment = weeklyClinic.MedicalWasteComment;
					weeklyClinicDTO.MedicinesExpiryDate = weeklyClinic.MedicinesExpiryDate;
					weeklyClinicDTO.MedicinesExpiryDateComment = weeklyClinic.MedicinesExpiryDateComment;
					weeklyClinicDTO.OtherComments = weeklyClinic.OtherComments;
					weeklyClinicDTO.DoctorName = weeklyClinic.DoctorName;
					weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
					weeklyClinicDTO.userName = weeklyClinic.user.UserName;
					foreach (var item in weeklyClinic.FridgeComponents)
					{
						FridgeComponentDTO fridgeComponentDTO = new FridgeComponentDTO();
						fridgeComponentDTO.Id = item.Id;
						fridgeComponentDTO.Item = item.Item;
						fridgeComponentDTO.Quantity = item.Quantity;
						fridgeComponentDTO.ExpireDate = item.ExpireDate;
						fridgeComponentDTO.WeeklyClinicId = item.WeeklyClinicId;
						fridgeComponentDTO.IsDeleted = item.IsDeleted;
						weeklyClinicDTO.FridgeComponents.Add(fridgeComponentDTO);
					}
					foreach (var item in weeklyClinic.DrugInventory)
					{
						DrugInventoryDTO drugInventoryDTO = new DrugInventoryDTO();
						drugInventoryDTO.Id = item.Id;
						drugInventoryDTO.Item = item.Item;
						drugInventoryDTO.Quantity = item.Quantity;
						drugInventoryDTO.ExpireDate = item.ExpireDate;
						drugInventoryDTO.WeeklyClinicId = item.WeeklyClinicId;
						drugInventoryDTO.IsDeleted = item.IsDeleted;
						weeklyClinicDTO.DrugInventory.Add(drugInventoryDTO);
					}


					result.Message = "Success";
					result.Statescode = 200;
					result.Data = weeklyClinicDTO;

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
		//				List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall().Where(a => a.DateRaisedBy == date).ToList();
		//				List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
		//				foreach (WeeklyClinic weeklyClinic in temp)
		//				{
		//					WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
		//					weeklyClinicDTO.Id = weeklyClinic.Id;
		//					//weeklyClinicDTO.Rig = weeklyClinic.Rig.Number;
		//					weeklyClinicDTO.Title = weeklyClinic.Title;
		//					weeklyClinicDTO.FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName;
		//					weeklyClinicDTO.ReportNo = weeklyClinic.ReportNo;
		//					weeklyClinicDTO.DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity;
		//					weeklyClinicDTO.Standard = weeklyClinic.Standard.StandardName;
		//					weeklyClinicDTO.ClauseNo = weeklyClinic.ClauseNo;
		//					weeklyClinicDTO.ObjectiveEvidence = weeklyClinic.ObjectiveEvidence;
		//					foreach (var item in weeklyClinic.weeklyClinicAndObservation)
		//					{
		//						string observation = item.weeklyClinicObservation.Observation;
		//						weeklyClinicDTO.weeklyClinicAndObservation.Add(observation);

		//					}
		//					foreach (var item in weeklyClinic.weeklyClinicAndRootCauses)
		//					{
		//						string cause = item.RootCauses.CauseName;
		//						weeklyClinicDTO.weeklyClinicAndRootCauses.Add(cause);

		//					}
		//					weeklyClinicDTO.IfOtherObservation = weeklyClinic.IfOtherObservation;
		//					weeklyClinicDTO.UpdateRisk = weeklyClinic.UpdateRisk;
		//					weeklyClinicDTO.IfUpdate = weeklyClinic.IfUpdate;
		//					weeklyClinicDTO.ManagementOfChange = weeklyClinic.ManagementOfChange;
		//					weeklyClinicDTO.IfManagementOfChange = weeklyClinic.IfManagementOfChange;
		//					weeklyClinicDTO.NameRasiedBy = weeklyClinic.NameRasiedBy;
		//					//weeklyClinicDTO.SigRasiedBy = weeklyClinic.SigRasiedBy;
		//					weeklyClinicDTO.DateRaisedBy = weeklyClinic.DateRaisedBy;
		//					weeklyClinicDTO.IfOtherRootCause = weeklyClinic.IfOtherRootCause;
		//					foreach (var item in weeklyClinic.weeklyClinicDataTable)
		//					{
		//						weeklyClinicDataTable Data = new weeklyClinicDataTable();
		//						Data.Id = item.Id;
		//						Data.SN = item.SN;
		//						Data.WeeklyClinicSelected = item.WeeklyClinicSelected;
		//						Data.Action = item.Action;
		//						Data.Responsible = item.Responsible;
		//						Data.SuggestedDate = item.SuggestedDate;
		//						Data.AchievementDate = item.AchievementDate;
		//						Data.Status = item.Status;
		//						Data.WeeklyClinicId = item.WeeklyClinicId;
		//						Data.FollowUpAudit = item.FollowUpAudit;
		//						Data.IsDeleted = item.IsDeleted;
		//						weeklyClinicDTO.weeklyClinicDataTable.Add(Data);
		//					};
		//					weeklyClinicDTO.Comment = weeklyClinic.Comment;
		//					weeklyClinicDTO.Q_ManagerSig = weeklyClinic.Q_ManagerSig;
		//					//weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
		//					weeklyClinicDTO.userName = weeklyClinic.user.UserName;
		//					weeklyClinicDTO.FormStatus = weeklyClinic.FormStatus;
		//					List<weeklyClinicImages> weeklyClinicImages = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).ToList();
		//					foreach (var item in weeklyClinicImages)
		//					{
		//						string FileName = item.FileName;
		//						weeklyClinicDTO.Images.Add(FileName);

		//					}
		//					newTemp.Add(weeklyClinicDTO);
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
		//				List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall().Where(a => a.userID == UserId && a.DateRaisedBy == date).ToList();
		//				List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
		//				foreach (WeeklyClinic weeklyClinic in temp)
		//				{
		//					WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
		//					weeklyClinicDTO.Id = weeklyClinic.Id;
		//					//weeklyClinicDTO.Rig = weeklyClinic.Rig.Number;
		//					weeklyClinicDTO.Title = weeklyClinic.Title;
		//					weeklyClinicDTO.FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName;
		//					weeklyClinicDTO.ReportNo = weeklyClinic.ReportNo;
		//					weeklyClinicDTO.DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity;
		//					weeklyClinicDTO.Standard = weeklyClinic.Standard.StandardName;
		//					weeklyClinicDTO.ClauseNo = weeklyClinic.ClauseNo;
		//					weeklyClinicDTO.ObjectiveEvidence = weeklyClinic.ObjectiveEvidence;
		//					foreach (var item in weeklyClinic.weeklyClinicAndObservation)
		//					{
		//						string observation = item.weeklyClinicObservation.Observation;
		//						weeklyClinicDTO.weeklyClinicAndObservation.Add(observation);

		//					}
		//					foreach (var item in weeklyClinic.weeklyClinicAndRootCauses)
		//					{
		//						string cause = item.RootCauses.CauseName;
		//						weeklyClinicDTO.weeklyClinicAndRootCauses.Add(cause);

		//					}
		//					weeklyClinicDTO.IfOtherObservation = weeklyClinic.IfOtherObservation;
		//					weeklyClinicDTO.UpdateRisk = weeklyClinic.UpdateRisk;
		//					weeklyClinicDTO.IfUpdate = weeklyClinic.IfUpdate;
		//					weeklyClinicDTO.ManagementOfChange = weeklyClinic.ManagementOfChange;
		//					weeklyClinicDTO.IfManagementOfChange = weeklyClinic.IfManagementOfChange;
		//					weeklyClinicDTO.NameRasiedBy = weeklyClinic.NameRasiedBy;
		//					//weeklyClinicDTO.SigRasiedBy = weeklyClinic.SigRasiedBy;
		//					weeklyClinicDTO.DateRaisedBy = weeklyClinic.DateRaisedBy;
		//					weeklyClinicDTO.IfOtherRootCause = weeklyClinic.IfOtherRootCause;
		//					foreach (var item in weeklyClinic.weeklyClinicDataTable)
		//					{
		//						weeklyClinicDataTable Data = new weeklyClinicDataTable();
		//						Data.Id = item.Id;
		//						Data.SN = item.SN;
		//						Data.WeeklyClinicSelected = item.WeeklyClinicSelected;
		//						Data.Action = item.Action;
		//						Data.Responsible = item.Responsible;
		//						Data.SuggestedDate = item.SuggestedDate;
		//						Data.AchievementDate = item.AchievementDate;
		//						Data.Status = item.Status;
		//						Data.WeeklyClinicId = item.WeeklyClinicId;
		//						Data.FollowUpAudit = item.FollowUpAudit;
		//						Data.IsDeleted = item.IsDeleted;
		//						weeklyClinicDTO.weeklyClinicDataTable.Add(Data);
		//					};
		//					weeklyClinicDTO.Comment = weeklyClinic.Comment;
		//					weeklyClinicDTO.Q_ManagerSig = weeklyClinic.Q_ManagerSig;
		//					//weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
		//					weeklyClinicDTO.userName = weeklyClinic.user.UserName;
		//					weeklyClinicDTO.FormStatus = weeklyClinic.FormStatus;
		//					List<weeklyClinicImages> weeklyClinicImages = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).ToList();
		//					foreach (var item in weeklyClinicImages)
		//					{
		//						string FileName = item.FileName;
		//						weeklyClinicDTO.Images.Add(FileName);

		//					}
		//					newTemp.Add(weeklyClinicDTO);
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
		//				var WeeklyClinics = WeeklyClinicRepoistory.getall()
		//				.Where(item => item.weeklyClinicDataTable.Any(obs => obs.SuggestedDate.Value.Date < DateTime.Now.Date))
		//				.ToList();

		//				if (WeeklyClinics.Any())
		//				{
		//					var newTemp = WeeklyClinics.Select(weeklyClinic =>
		//					{
		//						var weeklyClinicDTO = new WeeklyClinicResponseDTO
		//						{
		//							Id = weeklyClinic.Id,
		//							//Rig = weeklyClinic.Rig.Number,
		//							Title = weeklyClinic.Title,
		//							FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName,
		//							ReportNo = weeklyClinic.ReportNo,
		//							DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity,
		//							Standard = weeklyClinic.Standard.StandardName,
		//							ClauseNo = weeklyClinic.ClauseNo,
		//							ObjectiveEvidence = weeklyClinic.ObjectiveEvidence,
		//							weeklyClinicAndObservation = weeklyClinic.weeklyClinicAndObservation.Select(item => item.weeklyClinicObservation.Observation).ToList(),
		//							weeklyClinicAndRootCauses = weeklyClinic.weeklyClinicAndRootCauses.Select(item => item.RootCauses.CauseName).ToList(),
		//							IfOtherObservation = weeklyClinic.IfOtherObservation,
		//							UpdateRisk = weeklyClinic.UpdateRisk,
		//							IfUpdate = weeklyClinic.IfUpdate,
		//							ManagementOfChange = weeklyClinic.ManagementOfChange,
		//							IfManagementOfChange = weeklyClinic.IfManagementOfChange,
		//							NameRasiedBy = weeklyClinic.NameRasiedBy,
		//							DateRaisedBy = weeklyClinic.DateRaisedBy,
		//							IfOtherRootCause = weeklyClinic.IfOtherRootCause,
		//							weeklyClinicDataTable = weeklyClinic.weeklyClinicDataTable.Select(item => new weeklyClinicDataTable
		//							{
		//								Id = item.Id,
		//								SN = item.SN,
		//								WeeklyClinicSelected = item.WeeklyClinicSelected,
		//								Action = item.Action,
		//								Responsible = item.Responsible,
		//								SuggestedDate = item.SuggestedDate,
		//								AchievementDate = item.AchievementDate,
		//								Status = item.Status,
		//								WeeklyClinicId = item.WeeklyClinicId,
		//								FollowUpAudit = item.FollowUpAudit,
		//								IsDeleted = item.IsDeleted
		//							}).ToList(),
		//							Comment = weeklyClinic.Comment,
		//							Q_ManagerSig = weeklyClinic.Q_ManagerSig,
		//							//QHSEEngineer = weeklyClinic.QHSEEngineer,
		//							userName = weeklyClinic.user.UserName,
		//							FormStatus = weeklyClinic.FormStatus,
		//							Images = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).Select(item => item.FileName).ToList()
		//						};

		//						return weeklyClinicDTO;
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
		//					result.Data = new List<WeeklyClinicDTO>();

		//					return result;
		//				}

		//				//List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall();
		//				//List<WeeklyClinic> WeeklyClinics = new List<WeeklyClinic>();
		//				//foreach(var item in temp)
		//				//{
		//				//	if (item.weeklyClinicDataTable.Count() > 0)
		//				//	{
		//				//		if(item.weeklyClinicDataTable.Any(obs => obs.SuggestedDate.Value.Date < DateTime.Now.Date))
		//				//		{
		//				//			WeeklyClinics.Add(item);
		//				//		}
		//				//	}
		//				//}

		//				//if (WeeklyClinics.Count() > 0)
		//				//{
		//				//	List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
		//				//	foreach (WeeklyClinic weeklyClinic in WeeklyClinics)
		//				//	{
		//				//		WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
		//				//		weeklyClinicDTO.Id = weeklyClinic.Id;
		//				//		weeklyClinicDTO.Rig = weeklyClinic.Rig.Number;
		//				//		weeklyClinicDTO.Title = weeklyClinic.Title;
		//				//		weeklyClinicDTO.FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName;
		//				//		weeklyClinicDTO.ReportNo = weeklyClinic.ReportNo;
		//				//		weeklyClinicDTO.DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity;
		//				//		weeklyClinicDTO.Standard = weeklyClinic.Standard.StandardName;
		//				//		weeklyClinicDTO.ClauseNo = weeklyClinic.ClauseNo;
		//				//		weeklyClinicDTO.ObjectiveEvidence = weeklyClinic.ObjectiveEvidence;
		//				//		foreach (var item in weeklyClinic.weeklyClinicAndObservation)
		//				//		{
		//				//			string observation = item.weeklyClinicObservation.Observation;
		//				//			weeklyClinicDTO.weeklyClinicAndObservation.Add(observation);

		//				//		}
		//				//		foreach (var item in weeklyClinic.weeklyClinicAndRootCauses)
		//				//		{
		//				//			string cause = item.RootCauses.CauseName;
		//				//			weeklyClinicDTO.weeklyClinicAndRootCauses.Add(cause);

		//				//		}
		//				//		weeklyClinicDTO.IfOtherObservation = weeklyClinic.IfOtherObservation;
		//				//		weeklyClinicDTO.UpdateRisk = weeklyClinic.UpdateRisk;
		//				//		weeklyClinicDTO.IfUpdate = weeklyClinic.IfUpdate;
		//				//		weeklyClinicDTO.ManagementOfChange = weeklyClinic.ManagementOfChange;
		//				//		weeklyClinicDTO.IfManagementOfChange = weeklyClinic.IfManagementOfChange;
		//				//		weeklyClinicDTO.NameRasiedBy = weeklyClinic.NameRasiedBy;
		//				//		//weeklyClinicDTO.SigRasiedBy = weeklyClinic.SigRasiedBy;
		//				//		weeklyClinicDTO.DateRaisedBy = weeklyClinic.DateRaisedBy;
		//				//		weeklyClinicDTO.IfOtherRootCause = weeklyClinic.IfOtherRootCause;
		//				//		foreach (var item in weeklyClinic.weeklyClinicDataTable)
		//				//		{
		//				//			weeklyClinicDataTable Data = new weeklyClinicDataTable();
		//				//			Data.Id = item.Id;
		//				//			Data.SN = item.SN;
		//				//			Data.WeeklyClinicSelected = item.WeeklyClinicSelected;
		//				//			Data.Action = item.Action;
		//				//			Data.Responsible = item.Responsible;
		//				//			Data.SuggestedDate = item.SuggestedDate;
		//				//			Data.AchievementDate = item.AchievementDate;
		//				//			Data.Status = item.Status;
		//				//			Data.WeeklyClinicId = item.WeeklyClinicId;
		//				//			Data.FollowUpAudit = item.FollowUpAudit;
		//				//			Data.IsDeleted = item.IsDeleted;
		//				//			weeklyClinicDTO.weeklyClinicDataTable.Add(Data);
		//				//		};
		//				//		weeklyClinicDTO.Comment = weeklyClinic.Comment;
		//				//		weeklyClinicDTO.Q_ManagerSig = weeklyClinic.Q_ManagerSig;
		//				//		weeklyClinicDTO.userName = weeklyClinic.user.UserName;
		//				//		weeklyClinicDTO.FormStatus = weeklyClinic.FormStatus;
		//				//		List<weeklyClinicImages> weeklyClinicImages = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).ToList();
		//				//		foreach (var item in weeklyClinicImages)
		//				//		{
		//				//			string FileName = item.FileName;
		//				//			weeklyClinicDTO.Images.Add(FileName);

		//				//		}
		//				//		newTemp.Add(weeklyClinicDTO);
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
		//				var WeeklyClinics = WeeklyClinicRepoistory.getall()
		//				.Where(item => item.userID == UserId && item.weeklyClinicDataTable.Any(obs => obs.SuggestedDate.Value.Date < DateTime.Now.Date))
		//				.ToList();

		//				if (WeeklyClinics.Any())
		//				{
		//					var newTemp = WeeklyClinics.Select(weeklyClinic =>
		//					{
		//						var weeklyClinicDTO = new WeeklyClinicResponseDTO
		//						{
		//							Id = weeklyClinic.Id,
		//							//Rig = weeklyClinic.Rig.Number,
		//							Title = weeklyClinic.Title,
		//							FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName,
		//							ReportNo = weeklyClinic.ReportNo,
		//							DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity,
		//							Standard = weeklyClinic.Standard.StandardName,
		//							ClauseNo = weeklyClinic.ClauseNo,
		//							ObjectiveEvidence = weeklyClinic.ObjectiveEvidence,
		//							weeklyClinicAndObservation = weeklyClinic.weeklyClinicAndObservation.Select(item => item.weeklyClinicObservation.Observation).ToList(),
		//							weeklyClinicAndRootCauses = weeklyClinic.weeklyClinicAndRootCauses.Select(item => item.RootCauses.CauseName).ToList(),
		//							IfOtherObservation = weeklyClinic.IfOtherObservation,
		//							UpdateRisk = weeklyClinic.UpdateRisk,
		//							IfUpdate = weeklyClinic.IfUpdate,
		//							ManagementOfChange = weeklyClinic.ManagementOfChange,
		//							IfManagementOfChange = weeklyClinic.IfManagementOfChange,
		//							NameRasiedBy = weeklyClinic.NameRasiedBy,
		//							DateRaisedBy = weeklyClinic.DateRaisedBy,
		//							IfOtherRootCause = weeklyClinic.IfOtherRootCause,
		//							weeklyClinicDataTable = weeklyClinic.weeklyClinicDataTable.Select(item => new weeklyClinicDataTable
		//							{
		//								Id = item.Id,
		//								SN = item.SN,
		//								WeeklyClinicSelected = item.WeeklyClinicSelected,
		//								Action = item.Action,
		//								Responsible = item.Responsible,
		//								SuggestedDate = item.SuggestedDate,
		//								AchievementDate = item.AchievementDate,
		//								Status = item.Status,
		//								WeeklyClinicId = item.WeeklyClinicId,
		//								FollowUpAudit = item.FollowUpAudit,
		//								IsDeleted = item.IsDeleted
		//							}).ToList(),
		//							Comment = weeklyClinic.Comment,
		//							Q_ManagerSig = weeklyClinic.Q_ManagerSig,
		//							//QHSEEngineer = weeklyClinic.QHSEEngineer,
		//							userName = weeklyClinic.user.UserName,
		//							FormStatus = weeklyClinic.FormStatus,
		//							Images = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).Select(item => item.FileName).ToList()
		//						};

		//						return weeklyClinicDTO;
		//					}).ToList();

		//					result.Message = "Success";
		//					result.Statescode = 200;
		//					result.Data = newTemp;

		//					return result;
		//					//List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall().Where(a => a.userID == UserId && a.DateRaisedBy == date).ToList();
		//					//List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
		//					//foreach (WeeklyClinic weeklyClinic in temp)
		//					//{
		//					//	WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
		//					//	weeklyClinicDTO.Id = weeklyClinic.Id;
		//					//	weeklyClinicDTO.Rig = weeklyClinic.Rig.Number;
		//					//	weeklyClinicDTO.Title = weeklyClinic.Title;
		//					//	weeklyClinicDTO.FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName;
		//					//	weeklyClinicDTO.ReportNo = weeklyClinic.ReportNo;
		//					//	weeklyClinicDTO.DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity;
		//					//	weeklyClinicDTO.Standard = weeklyClinic.Standard.StandardName;
		//					//	weeklyClinicDTO.ClauseNo = weeklyClinic.ClauseNo;
		//					//	weeklyClinicDTO.ObjectiveEvidence = weeklyClinic.ObjectiveEvidence;
		//					//	foreach (var item in weeklyClinic.weeklyClinicAndObservation)
		//					//	{
		//					//		string observation = item.weeklyClinicObservation.Observation;
		//					//		weeklyClinicDTO.weeklyClinicAndObservation.Add(observation);

		//					//	}
		//					//	foreach (var item in weeklyClinic.weeklyClinicAndRootCauses)
		//					//	{
		//					//		string cause = item.RootCauses.CauseName;
		//					//		weeklyClinicDTO.weeklyClinicAndRootCauses.Add(cause);

		//					//	}
		//					//	weeklyClinicDTO.IfOtherObservation = weeklyClinic.IfOtherObservation;
		//					//	weeklyClinicDTO.UpdateRisk = weeklyClinic.UpdateRisk;
		//					//	weeklyClinicDTO.IfUpdate = weeklyClinic.IfUpdate;
		//					//	weeklyClinicDTO.ManagementOfChange = weeklyClinic.ManagementOfChange;
		//					//	weeklyClinicDTO.IfManagementOfChange = weeklyClinic.IfManagementOfChange;
		//					//	weeklyClinicDTO.NameRasiedBy = weeklyClinic.NameRasiedBy;
		//					//	//weeklyClinicDTO.SigRasiedBy = weeklyClinic.SigRasiedBy;
		//					//	weeklyClinicDTO.DateRaisedBy = weeklyClinic.DateRaisedBy;
		//					//	weeklyClinicDTO.IfOtherRootCause = weeklyClinic.IfOtherRootCause;
		//					//	foreach (var item in weeklyClinic.weeklyClinicDataTable)
		//					//	{
		//					//		weeklyClinicDataTable Data = new weeklyClinicDataTable();
		//					//		Data.Id = item.Id;
		//					//		Data.SN = item.SN;
		//					//		Data.WeeklyClinicSelected = item.WeeklyClinicSelected;
		//					//		Data.Action = item.Action;
		//					//		Data.Responsible = item.Responsible;
		//					//		Data.SuggestedDate = item.SuggestedDate;
		//					//		Data.AchievementDate = item.AchievementDate;
		//					//		Data.Status = item.Status;
		//					//		Data.WeeklyClinicId = item.WeeklyClinicId;
		//					//		Data.FollowUpAudit = item.FollowUpAudit;
		//					//		Data.IsDeleted = item.IsDeleted;
		//					//		weeklyClinicDTO.weeklyClinicDataTable.Add(Data);
		//					//	};
		//					//	weeklyClinicDTO.Comment = weeklyClinic.Comment;
		//					//	weeklyClinicDTO.Q_ManagerSig = weeklyClinic.Q_ManagerSig;
		//					//	weeklyClinicDTO.userName = weeklyClinic.user.UserName;
		//					//	weeklyClinicDTO.FormStatus = weeklyClinic.FormStatus;
		//					//	List<weeklyClinicImages> weeklyClinicImages = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).ToList();
		//					//	foreach (var item in weeklyClinicImages)
		//					//	{
		//					//		string FileName = item.FileName;
		//					//		weeklyClinicDTO.Images.Add(FileName);

		//					//	}
		//					//	newTemp.Add(weeklyClinicDTO);
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
		//					result.Data = new List<WeeklyClinicDTO>();

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
					WeeklyClinic weeklyClinic = WeeklyClinicRepoistory.getall().FirstOrDefault(a => a.Id == ID);
					WeeklyClinicDTO weeklyClinicDTO = new WeeklyClinicDTO();
					weeklyClinicDTO.Id = default;
					weeklyClinicDTO.RigId = weeklyClinic.RigId;
					weeklyClinicDTO.Date = weeklyClinic.Date;
					weeklyClinicDTO.WeeklyClinicNo = weeklyClinic.WeeklyClinicNo;
					weeklyClinicDTO.MedicalReportNo = weeklyClinic.MedicalReportNo;
					weeklyClinicDTO.LastFirstAidDrillNo = weeklyClinic.LastFirstAidDrillNo;
					weeklyClinicDTO.HealthMeetingNo = weeklyClinic.HealthMeetingNo;
					weeklyClinicDTO.Topics = weeklyClinic.Topics;
					weeklyClinicDTO.HealthStatus = weeklyClinic.HealthStatus;
					weeklyClinicDTO.HealthStatusComment = weeklyClinic.HealthStatusComment;
					weeklyClinicDTO.LifeSavingApparatuses = weeklyClinic.LifeSavingApparatuses;
					weeklyClinicDTO.LifeSavingApparatusesComment = weeklyClinic.LifeSavingApparatusesComment;
					weeklyClinicDTO.VaccinesAvailable = weeklyClinic.VaccinesAvailable;
					weeklyClinicDTO.VaccinesAvailableComment = weeklyClinic.VaccinesAvailableComment;
					weeklyClinicDTO.ERP = weeklyClinic.ERP;
					weeklyClinicDTO.ERPComment = weeklyClinic.ERPComment;
					weeklyClinicDTO.MedicalStretcher = weeklyClinic.MedicalStretcher;
					weeklyClinicDTO.MedicalStretcherComment = weeklyClinic.MedicalStretcherComment;
					weeklyClinicDTO.WaterTest = weeklyClinic.WaterTest;
					weeklyClinicDTO.WaterTestComment = weeklyClinic.WaterTestComment;
					weeklyClinicDTO.BloodSugar = weeklyClinic.BloodSugar;
					weeklyClinicDTO.BloodSugarComment = weeklyClinic.BloodSugarComment;
					weeklyClinicDTO.FirstAidBox = weeklyClinic.FirstAidBox;
					weeklyClinicDTO.FirstAidBoxComment = weeklyClinic.FirstAidBoxComment;
					weeklyClinicDTO.FullO2Cylinder = weeklyClinic.FullO2Cylinder;
					weeklyClinicDTO.FullO2CylinderComment = weeklyClinic.FullO2CylinderComment;
					weeklyClinicDTO.MedicalWaste = weeklyClinic.MedicalWaste;
					weeklyClinicDTO.MedicalWasteComment = weeklyClinic.MedicalWasteComment;
					weeklyClinicDTO.MedicinesExpiryDate = weeklyClinic.MedicinesExpiryDate;
					weeklyClinicDTO.MedicinesExpiryDateComment = weeklyClinic.MedicinesExpiryDateComment;
					weeklyClinicDTO.OtherComments = weeklyClinic.OtherComments;
					weeklyClinicDTO.DoctorName = weeklyClinic.DoctorName;
					weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
					weeklyClinicDTO.userID = weeklyClinic.userID;
					if (weeklyClinic.FridgeComponents.Any())
					{
						foreach (var item in weeklyClinic.FridgeComponents)
						{
							FridgeComponentDTO fridgeComponentDTO = new FridgeComponentDTO();
							fridgeComponentDTO.Id = item.Id;
							fridgeComponentDTO.Item = item.Item;
							fridgeComponentDTO.Quantity = item.Quantity;
							fridgeComponentDTO.ExpireDate = item.ExpireDate;
							fridgeComponentDTO.WeeklyClinicId = weeklyClinic.Id;
							weeklyClinicDTO.FridgeComponents.Add(fridgeComponentDTO);
						}
					}
					if (weeklyClinic.DrugInventory.Any())
					{
						foreach (var item in weeklyClinic.DrugInventory)
						{
							DrugInventoryDTO drugInventoryDTO = new DrugInventoryDTO();
							drugInventoryDTO.Id = item.Id;
							drugInventoryDTO.Item = item.Item;
							drugInventoryDTO.Quantity = item.Quantity;
							drugInventoryDTO.ExpireDate = item.ExpireDate;
							drugInventoryDTO.WeeklyClinicId = weeklyClinic.Id;
							weeklyClinicDTO.DrugInventory.Add(drugInventoryDTO);
						}
					}
					result.Message = "Success";
					result.Data = weeklyClinicDTO;
					result.Statescode = 200;
					return result;

				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					WeeklyClinic weeklyClinic = WeeklyClinicRepoistory.getall().FirstOrDefault(a => a.Id == ID && a.userID == UserId);
					WeeklyClinicDTO weeklyClinicDTO = new WeeklyClinicDTO();
					weeklyClinicDTO.Id = default;
					weeklyClinicDTO.RigId = weeklyClinic.RigId;
					weeklyClinicDTO.Date = weeklyClinic.Date;
					weeklyClinicDTO.WeeklyClinicNo = weeklyClinic.WeeklyClinicNo;
					weeklyClinicDTO.MedicalReportNo = weeklyClinic.MedicalReportNo;
					weeklyClinicDTO.LastFirstAidDrillNo = weeklyClinic.LastFirstAidDrillNo;
					weeklyClinicDTO.HealthMeetingNo = weeklyClinic.HealthMeetingNo;
					weeklyClinicDTO.Topics = weeklyClinic.Topics;
					weeklyClinicDTO.HealthStatus = weeklyClinic.HealthStatus;
					weeklyClinicDTO.HealthStatusComment = weeklyClinic.HealthStatusComment;
					weeklyClinicDTO.LifeSavingApparatuses = weeklyClinic.LifeSavingApparatuses;
					weeklyClinicDTO.LifeSavingApparatusesComment = weeklyClinic.LifeSavingApparatusesComment;
					weeklyClinicDTO.VaccinesAvailable = weeklyClinic.VaccinesAvailable;
					weeklyClinicDTO.VaccinesAvailableComment = weeklyClinic.VaccinesAvailableComment;
					weeklyClinicDTO.ERP = weeklyClinic.ERP;
					weeklyClinicDTO.ERPComment = weeklyClinic.ERPComment;
					weeklyClinicDTO.MedicalStretcher = weeklyClinic.MedicalStretcher;
					weeklyClinicDTO.MedicalStretcherComment = weeklyClinic.MedicalStretcherComment;
					weeklyClinicDTO.WaterTest = weeklyClinic.WaterTest;
					weeklyClinicDTO.WaterTestComment = weeklyClinic.WaterTestComment;
					weeklyClinicDTO.BloodSugar = weeklyClinic.BloodSugar;
					weeklyClinicDTO.BloodSugarComment = weeklyClinic.BloodSugarComment;
					weeklyClinicDTO.FirstAidBox = weeklyClinic.FirstAidBox;
					weeklyClinicDTO.FirstAidBoxComment = weeklyClinic.FirstAidBoxComment;
					weeklyClinicDTO.FullO2Cylinder = weeklyClinic.FullO2Cylinder;
					weeklyClinicDTO.FullO2CylinderComment = weeklyClinic.FullO2CylinderComment;
					weeklyClinicDTO.MedicalWaste = weeklyClinic.MedicalWaste;
					weeklyClinicDTO.MedicalWasteComment = weeklyClinic.MedicalWasteComment;
					weeklyClinicDTO.MedicinesExpiryDate = weeklyClinic.MedicinesExpiryDate;
					weeklyClinicDTO.MedicinesExpiryDateComment = weeklyClinic.MedicinesExpiryDateComment;
					weeklyClinicDTO.OtherComments = weeklyClinic.OtherComments;
					weeklyClinicDTO.DoctorName = weeklyClinic.DoctorName;
					weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
					weeklyClinicDTO.userID = weeklyClinic.userID;
					if (weeklyClinic.FridgeComponents.Any()){
						foreach (var item in weeklyClinic.FridgeComponents)
						{
							FridgeComponentDTO fridgeComponentDTO = new FridgeComponentDTO();
							fridgeComponentDTO.Id = item.Id;
							fridgeComponentDTO.Item = item.Item;
							fridgeComponentDTO.Quantity = item.Quantity;
							fridgeComponentDTO.ExpireDate = item.ExpireDate;
							fridgeComponentDTO.WeeklyClinicId = weeklyClinic.Id;
							weeklyClinicDTO.FridgeComponents.Add(fridgeComponentDTO);
						}
					}
					if (weeklyClinic.DrugInventory.Any())
					{
						foreach (var item in weeklyClinic.DrugInventory)
						{
							DrugInventoryDTO drugInventoryDTO = new DrugInventoryDTO();
							drugInventoryDTO.Id = item.Id;
							drugInventoryDTO.Item = item.Item;
							drugInventoryDTO.Quantity = item.Quantity;
							drugInventoryDTO.ExpireDate = item.ExpireDate;
							drugInventoryDTO.WeeklyClinicId = weeklyClinic.Id;
							weeklyClinicDTO.DrugInventory.Add(drugInventoryDTO);
						}
					}

					result.Message = "Success";
					result.Data = weeklyClinicDTO;
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
		public ActionResult<ResultDTO> AddWeeklyClinic(WeeklyClinicDTO WeeklyClinicDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					WeeklyClinic weeklyClinic = new WeeklyClinic();
					weeklyClinic.Id = default;
					weeklyClinic.RigId = WeeklyClinicDTO.RigId;
					weeklyClinic.Date = WeeklyClinicDTO.Date;
					weeklyClinic.WeeklyClinicNo = WeeklyClinicDTO.WeeklyClinicNo;
					weeklyClinic.MedicalReportNo = WeeklyClinicDTO.MedicalReportNo;
					weeklyClinic.LastFirstAidDrillNo = WeeklyClinicDTO.LastFirstAidDrillNo;
					weeklyClinic.HealthMeetingNo = WeeklyClinicDTO.HealthMeetingNo;
					weeklyClinic.Topics = WeeklyClinicDTO.Topics;
					weeklyClinic.HealthStatus = WeeklyClinicDTO.HealthStatus;
					weeklyClinic.HealthStatusComment = WeeklyClinicDTO.HealthStatusComment;
					weeklyClinic.LifeSavingApparatuses = WeeklyClinicDTO.LifeSavingApparatuses;
					weeklyClinic.LifeSavingApparatusesComment = WeeklyClinicDTO.LifeSavingApparatusesComment;
					weeklyClinic.VaccinesAvailable = WeeklyClinicDTO.VaccinesAvailable;
					weeklyClinic.VaccinesAvailableComment = WeeklyClinicDTO.VaccinesAvailableComment;
					weeklyClinic.ERP = WeeklyClinicDTO.ERP;
					weeklyClinic.ERPComment = WeeklyClinicDTO.ERPComment;
					weeklyClinic.MedicalStretcher = WeeklyClinicDTO.MedicalStretcher;
					weeklyClinic.MedicalStretcherComment = WeeklyClinicDTO.MedicalStretcherComment;
					weeklyClinic.WaterTest = WeeklyClinicDTO.WaterTest;
					weeklyClinic.WaterTestComment = WeeklyClinicDTO.WaterTestComment;
					weeklyClinic.BloodSugar = WeeklyClinicDTO.BloodSugar;
					weeklyClinic.BloodSugarComment = WeeklyClinicDTO.BloodSugarComment;
					weeklyClinic.FirstAidBox = WeeklyClinicDTO.FirstAidBox;
					weeklyClinic.FirstAidBoxComment = WeeklyClinicDTO.FirstAidBoxComment;
					weeklyClinic.FullO2Cylinder = WeeklyClinicDTO.FullO2Cylinder;
					weeklyClinic.FullO2CylinderComment = WeeklyClinicDTO.FullO2CylinderComment;
					weeklyClinic.MedicalWaste = WeeklyClinicDTO.MedicalWaste;
					weeklyClinic.MedicalWasteComment = WeeklyClinicDTO.MedicalWasteComment;
					weeklyClinic.MedicinesExpiryDate = WeeklyClinicDTO.MedicinesExpiryDate;
					weeklyClinic.MedicinesExpiryDateComment = WeeklyClinicDTO.MedicinesExpiryDateComment;
					weeklyClinic.OtherComments = WeeklyClinicDTO.OtherComments;
					weeklyClinic.DoctorName = WeeklyClinicDTO.DoctorName;
					weeklyClinic.userID = WeeklyClinicDTO.userID;
					weeklyClinic.QHSEEngineer = WeeklyClinicDTO.QHSEEngineer;
					WeeklyClinicRepo.create(weeklyClinic);
			
					foreach (var item in WeeklyClinicDTO.FridgeComponents)
					{
						FridgeComponent FridgeComponent = new FridgeComponent();

						FridgeComponent.WeeklyClinicId = weeklyClinic.Id;
						FridgeComponent.Item = item.Item;
						FridgeComponent.Quantity = item.Quantity;
						FridgeComponent.ExpireDate = item.ExpireDate;
						FridgeComponentRepo.create(FridgeComponent);
					}
					foreach (var item in WeeklyClinicDTO.DrugInventory)
					{
						DrugInventory DrugInventory = new DrugInventory();

						DrugInventory.WeeklyClinicId = weeklyClinic.Id;
						DrugInventory.Item = item.Item;
						DrugInventory.Quantity = item.Quantity;
						DrugInventory.ExpireDate = item.ExpireDate;
						DrugInventoryRepo.create(DrugInventory);
					}

					result.Message = "Success";
					result.Data = weeklyClinic;
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
		public ActionResult<ResultDTO> Put(int id, WeeklyClinicDTO newWeeklyClinic) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					WeeklyClinic orgweeklyClinic = WeeklyClinicRepo.getbyid(id);
					orgweeklyClinic.RigId = newWeeklyClinic.RigId;
					orgweeklyClinic.Date = newWeeklyClinic.Date;
					orgweeklyClinic.WeeklyClinicNo = newWeeklyClinic.WeeklyClinicNo;
					orgweeklyClinic.MedicalReportNo = newWeeklyClinic.MedicalReportNo;
					orgweeklyClinic.LastFirstAidDrillNo = newWeeklyClinic.LastFirstAidDrillNo;
					orgweeklyClinic.HealthMeetingNo = newWeeklyClinic.HealthMeetingNo;
					orgweeklyClinic.Topics = newWeeklyClinic.Topics;
					orgweeklyClinic.HealthStatus = newWeeklyClinic.HealthStatus;
					orgweeklyClinic.HealthStatusComment = newWeeklyClinic.HealthStatusComment;
					orgweeklyClinic.LifeSavingApparatuses = newWeeklyClinic.LifeSavingApparatuses;
					orgweeklyClinic.LifeSavingApparatusesComment = newWeeklyClinic.LifeSavingApparatusesComment;
					orgweeklyClinic.VaccinesAvailable = newWeeklyClinic.VaccinesAvailable;
					orgweeklyClinic.VaccinesAvailableComment = newWeeklyClinic.VaccinesAvailableComment;
					orgweeklyClinic.ERP = newWeeklyClinic.ERP;
					orgweeklyClinic.ERPComment = newWeeklyClinic.ERPComment;
					orgweeklyClinic.MedicalStretcher = newWeeklyClinic.MedicalStretcher;
					orgweeklyClinic.MedicalStretcherComment = newWeeklyClinic.MedicalStretcherComment;
					orgweeklyClinic.WaterTest = newWeeklyClinic.WaterTest;
					orgweeklyClinic.WaterTestComment = newWeeklyClinic.WaterTestComment;
					orgweeklyClinic.BloodSugar = newWeeklyClinic.BloodSugar;
					orgweeklyClinic.BloodSugarComment = newWeeklyClinic.BloodSugarComment;
					orgweeklyClinic.FirstAidBox = newWeeklyClinic.FirstAidBox;
					orgweeklyClinic.FirstAidBoxComment = newWeeklyClinic.FirstAidBoxComment;
					orgweeklyClinic.FullO2Cylinder = newWeeklyClinic.FullO2Cylinder;
					orgweeklyClinic.FullO2CylinderComment = newWeeklyClinic.FullO2CylinderComment;
					orgweeklyClinic.MedicalWaste = newWeeklyClinic.MedicalWaste;
					orgweeklyClinic.MedicalWasteComment = newWeeklyClinic.MedicalWasteComment;
					orgweeklyClinic.MedicinesExpiryDate = newWeeklyClinic.MedicinesExpiryDate;
					orgweeklyClinic.MedicinesExpiryDateComment = newWeeklyClinic.MedicinesExpiryDateComment;
					orgweeklyClinic.OtherComments = newWeeklyClinic.OtherComments;
					orgweeklyClinic.DoctorName = newWeeklyClinic.DoctorName;
					orgweeklyClinic.QHSEEngineer = newWeeklyClinic.QHSEEngineer;
					orgweeklyClinic.userID = newWeeklyClinic.userID;
					WeeklyClinicRepo.update(orgweeklyClinic);

					var oldFridgeComponents = FridgeComponentRepo.getall().Where(o => o.WeeklyClinicId == id).ToList();
					if (oldFridgeComponents.Count == newWeeklyClinic.FridgeComponents.Count)
					{
						for (int i = 0; i < oldFridgeComponents.Count(); i++)
						{
							var OldItem = oldFridgeComponents[i];
							var newItem = newWeeklyClinic.FridgeComponents[i];

							OldItem.Item = newItem.Item;
							OldItem.Quantity = newItem.Quantity;
							OldItem.ExpireDate = newItem.ExpireDate;
							OldItem.WeeklyClinicId = id;
							FridgeComponentRepo.update(OldItem);
						}
					}
					else
					{
						foreach (var item in oldFridgeComponents)
						{
							FridgeComponentRepo.delete(item);
						}
						foreach (var item in newWeeklyClinic.FridgeComponents)
						{
							FridgeComponent FridgeComponent = new FridgeComponent();

							FridgeComponent.WeeklyClinicId = id;
							FridgeComponent.Item = item.Item;
							FridgeComponent.Quantity = item.Quantity;
							FridgeComponent.ExpireDate = item.ExpireDate;
							FridgeComponentRepo.create(FridgeComponent);
						}
					}

					var oldDrugInventory = DrugInventoryRepo.getall().Where(o => o.WeeklyClinicId == id).ToList();
					if (oldDrugInventory.Count == newWeeklyClinic.DrugInventory.Count)
					{
						for (int i = 0; i < oldDrugInventory.Count(); i++)
						{
							var OldItem = oldDrugInventory[i];
							var newItem = newWeeklyClinic.DrugInventory[i];

							OldItem.Item = newItem.Item;
							OldItem.Quantity = newItem.Quantity;
							OldItem.ExpireDate = newItem.ExpireDate;
							OldItem.WeeklyClinicId = id;
							DrugInventoryRepo.update(OldItem);
						}
					}
					else
					{
						foreach (var item in oldDrugInventory)
						{
							DrugInventoryRepo.delete(item);
						}
						foreach (var item in newWeeklyClinic.DrugInventory)
						{
							DrugInventory DrugInventory = new DrugInventory();

							DrugInventory.WeeklyClinicId = id;
							DrugInventory.Item = item.Item;
							DrugInventory.Quantity = item.Quantity;
							DrugInventory.ExpireDate = item.ExpireDate;
							DrugInventoryRepo.create(DrugInventory);
						}
					}
					
					result.Data = orgweeklyClinic;
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
				WeeklyClinic weeklyClinic = WeeklyClinicRepo.getbyid(id);
				weeklyClinic.IsDeleted = true;
				WeeklyClinicRepo.update(weeklyClinic);

				result.Data = weeklyClinic;
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
