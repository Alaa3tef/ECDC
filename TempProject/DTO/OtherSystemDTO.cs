using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempProject.DTO
{
	public class OtherSystemDTO
	{
		public int Id { get; set; }

		public string Item { get; set; }

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
