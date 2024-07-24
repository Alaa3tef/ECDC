using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.DTO
{
	public class PresssureReliefValveDTO
	{
		public int Id { get; set; }

		public string Valves { get; set; }
		public string Location { get; set; }

		[Column(TypeName = "date")]
		public DateTime CertificationDate { get; set; }

		[Column(TypeName = "date")]
		public DateTime ExpiryDate { get; set; }

		public int RigCertificatesId { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
