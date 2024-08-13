using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Security.Policy;
using TempProject.Models;

namespace TempProject.Repository
{
	public class WeeklyClinicRepository : IWeeklyClinicRepository
	{
		Context c;
		public WeeklyClinicRepository(Context c)
		{
			this.c = c;
		}

		public List<WeeklyClinic> getall()
		{
			return c.WeeklyClinics
				.Include(a => a.Rig)
				.Include(a => a.FridgeComponents)
				//.Include(a => a.user)
				.Include(a => a.DrugInventory)
				.Where(a => a.IsDeleted == false)
				.Select(a => new WeeklyClinic
				{
					Id = a.Id,
					RigId = a.RigId,
					Rig = new Rig { Number = a.Rig.Number, Id = a.Rig.Id },		
					Date=a.Date,
					WeeklyClinicNo=a.WeeklyClinicNo,
					MedicalReportNo = a.MedicalReportNo,
					LastFirstAidDrillNo = a.LastFirstAidDrillNo,
					HealthMeetingNo = a.HealthMeetingNo,
					Topics = a.Topics,
					HealthStatus = a.HealthStatus,
					HealthStatusComment = a.HealthStatusComment,
					LifeSavingApparatuses = a.LifeSavingApparatuses,
					LifeSavingApparatusesComment = a.LifeSavingApparatusesComment,
					VaccinesAvailable = a.VaccinesAvailable,
					VaccinesAvailableComment = a.VaccinesAvailableComment,
					ERP = a.ERP,
					ERPComment = a.ERPComment,
					MedicalStretcher = a.MedicalStretcher,
					MedicalStretcherComment = a.MedicalStretcherComment,
					WaterTest = a.WaterTest,
					WaterTestComment = a.WaterTestComment,
					BloodSugar = a.BloodSugar,
					BloodSugarComment = a.BloodSugarComment,
					FirstAidBox = a.FirstAidBox,
					FirstAidBoxComment = a.FirstAidBoxComment,
					FullO2Cylinder = a.FullO2Cylinder,
					FullO2CylinderComment = a.FullO2CylinderComment,
					MedicalWaste = a.MedicalWaste,
					MedicalWasteComment = a.MedicalWasteComment,
					MedicinesExpiryDate = a.MedicinesExpiryDate,
					MedicinesExpiryDateComment = a.MedicinesExpiryDateComment,
					OtherComments = a.OtherComments,
					DoctorName = a.DoctorName,
					QHSEEngineer = a.QHSEEngineer,
					FridgeComponents = a.FridgeComponents,
					DrugInventory=a.DrugInventory,		
					userID = a.userID,
					user = new IdentityUser { UserName = a.user.UserName, Id = a.user.Id },
					IsDeleted = a.IsDeleted
				}).ToList();
		}
	}
}
