using System.ComponentModel;
using TempProject.Repository;

namespace TempProject.Models
{
	public class Standard : ISoftDeleteRepository
	{
		public int Id { get; set; }

		public string StandardName { get; set; }

		public virtual List<CorrectiveAction> CorrectiveActions { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
