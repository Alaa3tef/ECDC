using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class ShiftDrillTypesExcelDTO
	{
		[Column(TypeName = "date")]
		public DateTime Date { get; set; }

		public string DrillType { get; set; }
	}
}
