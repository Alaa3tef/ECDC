using System.ComponentModel;

namespace TempProject.DTO
{
	public class CorrectiveResponsabilityDTO
	{
		public int Id { get; set; }

		public string ResponsibilityName { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }

	}
}
