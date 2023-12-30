using System.ComponentModel;

namespace TempProject.DTO
{
	public class CorrectiveObservationDTO
	{
		public int Id { get; set; }

		public string Observation { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
