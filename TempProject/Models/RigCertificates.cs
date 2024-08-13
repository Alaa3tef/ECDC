using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using TempProject.Repository;


namespace TempProject.Models
{
	public class RigCertificates : ISoftDeleteRepository
	{
		public int Id { get; set; }

		[ForeignKey("Rig")]
		public int RigId { get; set; }

		public virtual Rig Rig { get; set; }

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

		public List<HSEEquipmentTable>? HSEEquipmentTable { get; set; }
		public List<HoistingSystem>? HoistingSystem { get; set; }
		public List<RotarySystem>? RotarySystem { get; set; }
		public List<MudCirculationSystem>? MudCirculationSystem { get; set; }
		public List<WellControlSystem>? WellControlSystem { get; set; }
		public List<PowerSystem>? PowerSystem { get; set; }
		public List<OtherSystem>? OtherSystem { get; set; }
		public List<PresssureReliefValve>? PresssureReliefValve { get; set; }
		public List<PersonnelCerificates>? PersonnelCerificates { get; set; }
		public List<MobileCrane>? MobileCrane { get; set; }
		public List<RigCertForklift>? Forklift { get; set; }
		public List<AirHoist>? AirHoist { get; set; }
		public List<HydraulicWinch>? HydraulicWinch { get; set; }
		public List<ManRidingWinch>? ManRidingWinch { get; set; }

		[ForeignKey("user")]
		public string userID { get; set; }

		public virtual IdentityUser user { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
