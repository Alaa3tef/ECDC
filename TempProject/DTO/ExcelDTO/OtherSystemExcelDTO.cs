using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempProject.DTO
{
	public class OtherSystemExcelDTO
	{
		public string Item { get; set; }

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
