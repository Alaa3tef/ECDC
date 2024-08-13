using System.ComponentModel;
using TempProject.Repository;

namespace TempProject.Models
{
	public class TypeOfIncident : ISoftDeleteRepository
	{
		public int Id { get; set; } = 1;
		public string Name { get; set; } = null;

		[DefaultValue(false)]
		public virtual List<MedicalReport> MedicalReports { get; set; }
		public bool IsDeleted { get; set; }
	}
}
