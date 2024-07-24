using System.ComponentModel;

namespace TempProject.DTO
{
	public class RootCausesDTO
	{
		public int Id { get; set; }
		public string CauseName { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
