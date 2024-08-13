using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class WellControlSystem : ISoftDeleteRepository
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

		[ForeignKey("RigCertificates")]
		public int RigCertificatesId { get; set; }

		public virtual RigCertificates RigCertificates { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
