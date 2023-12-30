using System.ComponentModel;
using TempProject.Repository;

namespace TempProject.Models
{
	public class CorrectiveActionObservation : ISoftDeleteRepository
	{
		public int Id { get; set; }

		public string Observation { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
