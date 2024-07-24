using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Models;

namespace TempProject.DTO
{
	public class RigCertForkliftExcelDTO
	{
		public string Model { get; set; }
		public string Type { get; set; }
		public string SerialNo { get; set; }
		public string Capacity { get; set; }

		[Column(TypeName = "date")]
		public DateTime LastExaminationDate { get; set; }

		[Column(TypeName = "date")]
		public DateTime NextExaminationDate { get; set; }
	}
}
