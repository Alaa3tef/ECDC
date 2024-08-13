using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class PresssureReliefValve : ISoftDeleteRepository
	{
		public int Id { get; set; }

		public string Valves { get; set; }
		public string Location { get; set; }

		[Column(TypeName = "date")]
		public DateTime CertificationDate { get; set; }

		[Column(TypeName = "date")]
		public DateTime ExpiryDate { get; set; }

		[ForeignKey("RigCertificates")]
		public int RigCertificatesId { get; set; }

		public virtual RigCertificates RigCertificates { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
