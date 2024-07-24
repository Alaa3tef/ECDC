using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempProject.DTO
{
	public class WellControlSystemDTO
	{
		public int Id { get; set; }

		public string Equipment { get; set; }

		public string SerialNumber { get; set; }

		//[DefaultValue(false)]
		public bool? COCAvailabilty { get; set; }

		[Column(TypeName = "date")]
		public DateTime? CATIIICertificationDate { get; set; }
		[Column(TypeName = "date")]
		public DateTime? CATIIIExpiryDate { get; set; }
		[Column(TypeName = "date")]
		public DateTime? CATIVCertificationDate { get; set; }
		[Column(TypeName = "date")]
		public DateTime? CATIVExpiryDate { get; set; }

		public int RigCertificatesId { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
