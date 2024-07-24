using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Models;

namespace TempProject.DTO
{
	public class EditRigCertificatesDTO
	{
		public int Id { get; set; }
		public int RigId { get; set; }

		[Column(TypeName = "date")]
		public DateTime Date { get; set; }

		[Column(TypeName = "date")]
		public DateTime CertificationLiftingGear { get; set; }

		[Column(TypeName = "date")]
		public DateTime CertificationCATIII { get; set; }

		[Column(TypeName = "date")]
		public DateTime CertificationCATIV { get; set; }

		[Column(TypeName = "date")]
		public DateTime CertificationGaugeCalibraion { get; set; }

		[Column(TypeName = "date")]
		public DateTime CertificationWallThickness { get; set; }

		[Column(TypeName = "date")]
		public DateTime DueLiftingGear { get; set; }

		[Column(TypeName = "date")]
		public DateTime DueCATIII { get; set; }

		[Column(TypeName = "date")]
		public DateTime DueCATIV { get; set; }

		[Column(TypeName = "date")]
		public DateTime DueGaugeCalibraion { get; set; }

		[Column(TypeName = "date")]
		public DateTime DueWallThickness { get; set; }

		public List<HSEEquipmentTableDTO> HSEEquipmentTable { get; set; } = new List<HSEEquipmentTableDTO>();
		public List<HoistingSystemDTO> HoistingSystem { get; set; } = new List<HoistingSystemDTO>();
		public List<RotarySystemDTO> RotarySystem { get; set; } = new List<RotarySystemDTO>();
		public List<MudCirculationSystemDTO> MudCirculationSystem { get; set; } = new List<MudCirculationSystemDTO>();
		public List<WellControlSystemDTO> WellControlSystem { get; set; } = new List<WellControlSystemDTO>();
		public List<PowerSystemDTO> PowerSystem { get; set; } = new List<PowerSystemDTO>();
		public List<OtherSystemDTO> OtherSystem { get; set; } = new List<OtherSystemDTO>();
		public List<PresssureReliefValveDTO> PresssureReliefValve { get; set; } = new List<PresssureReliefValveDTO>();
		public List<PersonnelCerificatesDTO> PersonnelCerificates { get; set; } = new List<PersonnelCerificatesDTO>();

		public List<HSEEquipmentTableDTO> OtherHSEEquipmentTable { get; set; } = new List<HSEEquipmentTableDTO>();
		public List<HoistingSystemDTO> OtherHoistingSystem { get; set; } = new List<HoistingSystemDTO>();
		public List<RotarySystemDTO> OtherRotarySystem { get; set; } = new List<RotarySystemDTO>();
		public List<MudCirculationSystemDTO> OtherMudCirculationSystem { get; set; } = new List<MudCirculationSystemDTO>();
		public List<WellControlSystemDTO> OtherWellControlSystem { get; set; } = new List<WellControlSystemDTO>();
		public List<PowerSystemDTO> OtherPowerSystem { get; set; } = new List<PowerSystemDTO>();
		public List<OtherSystemDTO> OtherOtherSystem { get; set; } = new List<OtherSystemDTO>();
		public List<PresssureReliefValveDTO> OtherPresssureReliefValve { get; set; } = new List<PresssureReliefValveDTO>();
		public List<PersonnelCerificatesDTO> OtherPersonnelCerificates { get; set; } = new List<PersonnelCerificatesDTO>();

		public MobileCraneDTO MobileCrane { get; set; } = new MobileCraneDTO();
		public RigCertForkliftDTO Forklift { get; set; } = new RigCertForkliftDTO();
		public AirHoistDTO AirHoist { get; set; } = new AirHoistDTO();
		public HydraulicWinchDTO HydraulicWinch { get; set; } = new HydraulicWinchDTO();
		public ManRidingWinchDTO ManRidingWinch { get; set; } = new ManRidingWinchDTO();
		public string userID { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
