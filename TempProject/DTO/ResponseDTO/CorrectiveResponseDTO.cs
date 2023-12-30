using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Models;

namespace TempProject.DTO.ResponseDTO
{
    public class CorrectiveResponseDTO
	{
		public int Id { get; set; }

		public int ReportNo { get; set; }

		public int Rig { get; set; }

		public string DescriptionOfNonConformity { get; set; }

		public string Standard { get; set; }

		public string ClauseNo { get; set; }

		public string ObjectiveEvidence { get; set; }

		public List<string> CorrectiveAndObservation { get; set; } = new List<string> { };

		public string? IfOtherObservation { get; set; }

		[DefaultValue(false)]
		public bool UpdateRisk { get; set; }

		public string? IfUpdate { get; set; }

		[DefaultValue(false)]
		public bool ManagementOfChange { get; set; }

		public string? IfManagementOfChange { get; set; }

		public string NameRasiedBy { get; set; }

		public string SigRasiedBy { get; set; }

		public DateTime DateRaisedBy { get; set; }

		public List<string> CorrectiveAndRootCauses { get; set; } = new List<string> { };

		public string? IfOtherRootCause { get; set; }

		public List<CorrectiveDataTable>? CorrectiveDataTable { get; set; } = new List<CorrectiveDataTable> { };

		public string? Comment { get; set; }

		public List<string> Images { get; set; } = new List<string>();

		public string Q_ManagerSig { get; set; }

		public string userName{ get; set; }

		public string FormStatus { get; set; }

	}
}
