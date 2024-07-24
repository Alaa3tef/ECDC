using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class VisitsExcelDTO
	{
		[Column(TypeName = "date")]
		public DateTime Date { get; set; }

		public string VisitName { get; set; }
	}
}
