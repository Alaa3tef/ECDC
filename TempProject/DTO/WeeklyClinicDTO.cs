using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Models;

namespace TempProject.DTO
{
	public class WeeklyClinicDTO
	{
		public int Id { get; set; }

		public int RigId { get; set; }

		[Column(TypeName = "date")]
		public DateTime Date { get; set; }

		public int WeeklyClinicNo { get; set; }

		public int MedicalReportNo { get; set; }

		[Column(TypeName = "date")]
		public DateTime LastFirstAidDrillNo { get; set; }

		public int HealthMeetingNo { get; set; }

		public string Topics { get; set; }
		public string HealthStatus { get; set; }
		public string? HealthStatusComment { get; set; }
		public string LifeSavingApparatuses { get; set; }
		public string? LifeSavingApparatusesComment { get; set; }
		public string VaccinesAvailable { get; set; }
		public string? VaccinesAvailableComment { get; set; }
		public string ERP { get; set; }
		public string? ERPComment { get; set; }
		public string MedicalStretcher { get; set; }
		public string? MedicalStretcherComment { get; set; }
		public string WaterTest { get; set; }
		public string? WaterTestComment { get; set; }
		public string BloodSugar { get; set; }
		public string? BloodSugarComment { get; set; }
		public string FirstAidBox { get; set; }
		public string? FirstAidBoxComment { get; set; }
		public string FullO2Cylinder { get; set; }
		public string? FullO2CylinderComment { get; set; }
		public string MedicalWaste { get; set; }
		public string? MedicalWasteComment { get; set; }
		public string MedicinesExpiryDate { get; set; }
		public string? MedicinesExpiryDateComment { get; set; }

		public List<FridgeComponentDTO> FridgeComponents { get; set; } = new List<FridgeComponentDTO>();

		public List<DrugInventoryDTO> DrugInventory { get; set; } = new List<DrugInventoryDTO>();

		public string OtherComments { get; set; }
		public string DoctorName { get; set; }

		public string QHSEEngineer { get; set; }

		public string userID { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
