using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Models;

namespace TempProject.DTO
{
    public class WeeklyInspectionDTO
    {
        public int Id { get; set; }

        public int RigId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public string WellName { get; set; }
        public string Client { get; set; }


        public string EyeStatus { get; set; }
        public string? EyeWeeklyFindings { get; set; }

        public string FirstAidStatus { get; set; }
        public string? FirstAidWeeklyFindings { get; set; }

        public string ScbaStatus { get; set; }
        public string? ScbaWeeklyFindings { get; set; }
        public int Scba30min { get; set; }
        public int Scba15min { get; set; }
        public int Scba10min { get; set; }

        public string PortableGasStatus { get; set; }
        public string? PortableGasWeeklyFindings { get; set; }
        public int PortableGasMuti { get; set; }
        public int PortableGasSingle { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExpeiryDate { get; set; }
        public string FirePumpStatus { get; set; }
        public string? FirePumpWeeklyFindings { get; set; }
        public string WeldingStatus { get; set; }
        public string? WeldingWeeklyFindings { get; set; }

        public string WindStatus { get; set; }
        public string? WindWeeklyFindings { get; set; }

        public string SmokeStatus { get; set; }
        public string? SmokeWeeklyFindings { get; set; }

        public string FireExtinguishersStatus { get; set; }
        public string? FireExtinguishersWeeklyFindings { get; set; }

        public string DerrickmanStatus { get; set; }
        public string? DerrickmanWeeklyFindings { get; set; }

        public string WorkingStatus { get; set; }
        public string? WorkingWeeklyFindings { get; set; }

        public string PortableLadderStatus { get; set; }
        public string? PortableLadderWeeklyFindings { get; set; }

        public string SafetyStatus { get; set; }
        public string? SafetyWeeklyFindings { get; set; }

        public string FallStatus { get; set; }
        public string? FallWeeklyFindings { get; set; }

        public string CraneStatus { get; set; }
        public string? CraneWeeklyFindings { get; set; }

        public string ForkStatus { get; set; }
        public string? ForkWeeklyFindings { get; set; }

        public string DroppedInspectionStatus { get; set; }
        public string? DroppedInspectionWeeklyFindings { get; set; }

        public string ElectricalStatus { get; set; }
        public string? ElectricalWeeklyFindings { get; set; }

        public string CircuitStatus { get; set; }
        public string? CircuitWeeklyFindings { get; set; }

        public string EarthingStatus { get; set; }
        public string? EarthingWeeklyFindings { get; set; }
		public float EarthingMaximum { get; set; }
		public float EarthingMin { get; set; }

		public int Code { get; set; }
        public string PositionName { get; set; }
        public string Name { get; set; }

        public string userID { get; set; }

        [DefaultValue(false)]
		public bool IsDeleted { get; set; }

	}
}
