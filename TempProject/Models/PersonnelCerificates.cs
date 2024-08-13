using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class PersonnelCerificates : ISoftDeleteRepository
	{
		public int Id { get; set; }

		public int Code { get; set; }

		public string Position { get; set; }

		public string Name { get; set; }

		public string CertificateType { get; set; }

		[Column(TypeName = "date")]
		public DateTime CertificateDate { get; set; }

		[Column(TypeName = "date")]
		public DateTime ExpiryDate { get; set; }

		[ForeignKey("RigCertificates")]
		public int RigCertificatesId { get; set; }

		public virtual RigCertificates RigCertificates { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
