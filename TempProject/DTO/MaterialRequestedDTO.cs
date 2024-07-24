using System.ComponentModel;
using TempProject.Repository;

namespace TempProject.Models
{
	public class MaterialRequestedDTO
	{
		public int Id { get; set; }

		public string PR { get; set; }

		public string RequiredItem { get; set; }

		public int HandoverId { get; set; }


		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
