using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Models;

namespace TempProject.DTO
{
	public class HydraulicWinchDTO
	{
		public int Id { get; set; }

		public string SerialNo { get; set; }
		public string WireSize { get; set; }
		public string Capacity { get; set; }

		[Column(TypeName = "date")]
		public DateTime WireInspectionDueDate { get; set; }

		[Column(TypeName = "date")]
		public DateTime LastMPIInspectionDate { get; set; }

		[Column(TypeName = "date")]
		public DateTime NextMPIInspectionDate { get; set; }

		[Column(TypeName = "date")]
		public DateTime NextLoadTestDate { get; set; }

		public int RigCertificatesId { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
