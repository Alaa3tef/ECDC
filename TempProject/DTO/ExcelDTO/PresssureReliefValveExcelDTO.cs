using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.DTO
{
	public class PresssureReliefValveExcelDTO
	{
		public string Valves { get; set; }
		public string Location { get; set; }

		[Column(TypeName = "date")]
		public DateTime CertificationDate { get; set; }

		[Column(TypeName = "date")]
		public DateTime ExpiryDate { get; set; }
	}
}
