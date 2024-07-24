using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Models;

namespace TempProject.DTO
{
	public class MobileCraneExcelDTO
	{
		public string Model { get; set; }
		public string Type { get; set; }
		public string ChassisNo { get; set; }
		public string HookSerialNo { get; set; }
		public string Capacity { get; set; }

		[Column(TypeName = "date")]
		public DateTime ManufactureDate { get; set; }

		[Column(TypeName = "date")]
		public DateTime LastExaminationDate { get; set; }

		[Column(TypeName = "date")]
		public DateTime NextExaminationDate { get; set; }
	}
}
