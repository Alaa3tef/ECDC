using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class RigCertForklift : ISoftDeleteRepository
	{
		public int Id { get; set; }
		public string Model { get; set; }
		public string Type { get; set; }
		public string SerialNo { get; set; }
		public string Capacity { get; set; }

		[Column(TypeName = "date")]
		public DateTime LastExaminationDate { get; set; }

		[Column(TypeName = "date")]
		public DateTime NextExaminationDate { get; set; }

		[ForeignKey("RigCertificates")]
		public int RigCertificatesId { get; set; }

		public virtual RigCertificates RigCertificates { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
