using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class ShiftDrillTypesDTO
	{
		public int Id { get; set; }

		[Column(TypeName = "date")]
		public DateTime Date { get; set; }

		public string DrillType { get; set; }

		public int HandoverId { get; set; }
		
		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
