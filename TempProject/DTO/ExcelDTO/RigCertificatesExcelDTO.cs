using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Models;

namespace TempProject.DTO
{
	public class RigCertificatesExcelDTO
	{
		public int Rig_Number { get; set; }

		[Column(TypeName = "date")]
		public DateTime Date { get; set; }

		[Column(TypeName = "date")]
		public DateTime Certification_Lifting_Gear { get; set; }

		[Column(TypeName = "date")]
		public DateTime Certification_CATIII { get; set; }

		[Column(TypeName = "date")]
		public DateTime Certification_CATIV { get; set; }

		[Column(TypeName = "date")]
		public DateTime Certification_Gauge_Calibraion { get; set; }

		[Column(TypeName = "date")]
		public DateTime Certification_Wall_Thickness { get; set; }

		[Column(TypeName = "date")]
		public DateTime Due_Lifting_Gear { get; set; }

		[Column(TypeName = "date")]
		public DateTime Due_CATIII { get; set; }

		[Column(TypeName = "date")]
		public DateTime Due_CATIV { get; set; }

		[Column(TypeName = "date")]
		public DateTime Due_Gauge_Calibraion { get; set; }

		[Column(TypeName = "date")]
		public DateTime Due_Wall_Thickness { get; set; }

		public List<HSEEquipmentTableExcelDTO> HSE_Equipment { get; set; } = new List<HSEEquipmentTableExcelDTO>();
		public List<HoistingSystemExcelDTO> Hoisting_System { get; set; } = new List<HoistingSystemExcelDTO>();
		public List<RotarySystemExcelDTO> Rotary_System { get; set; } = new List<RotarySystemExcelDTO>();
		public List<MudCirculationSystemExcelDTO> Mud_Circulation_System { get; set; } = new List<MudCirculationSystemExcelDTO>();
		public List<WellControlSystemExcelDTO> Well_Control_System { get; set; } = new List<WellControlSystemExcelDTO>();
		public List<PowerSystemExcelDTO> Power_System { get; set; } = new List<PowerSystemExcelDTO>();
		public List<OtherSystemExcelDTO> Other_System { get; set; } = new List<OtherSystemExcelDTO>();
		public List<PresssureReliefValveExcelDTO> Presssure_Relief_Valve { get; set; } = new List<PresssureReliefValveExcelDTO>();
		public List<PersonnelCerificatesExcelDTO> Personnel_Cerificates { get; set; } = new List<PersonnelCerificatesExcelDTO>();
		public List<MobileCraneExcelDTO> Mobile_Crane { get; set; } = new List<MobileCraneExcelDTO>();
		public List<RigCertForkliftExcelDTO> Forklift { get; set; } = new List<RigCertForkliftExcelDTO>();
		public List<AirHoistExcelDTO> Air_Hoist { get; set; } = new List<AirHoistExcelDTO>();
		public List<HydraulicWinchExcelDTO> Hydraulic_Winch { get; set; } = new List<HydraulicWinchExcelDTO>();
		public List<ManRidingWinchExcelDTO> Man_Riding_Winch { get; set; } = new List<ManRidingWinchExcelDTO>();
		public string User_Name { get; set; }
	}
}
