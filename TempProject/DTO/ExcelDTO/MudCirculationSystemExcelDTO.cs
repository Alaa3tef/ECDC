using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempProject.DTO
{
	public class MudCirculationSystemExcelDTO
	{
		public string Equipment { get; set; }

		public string SerialNumber { get; set; }

		public string COCAvailabilty { get; set; }

		[Column(TypeName = "date")]
		public DateTime? CATIIICertificationDate { get; set; }
		[Column(TypeName = "date")]
		public DateTime? CATIIIExpiryDate { get; set; }
		[Column(TypeName = "date")]
		public DateTime? CATIVCertificationDate { get; set; }
		[Column(TypeName = "date")]
		public DateTime? CATIVExpiryDate { get; set; }
	}
}
