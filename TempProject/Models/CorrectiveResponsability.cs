using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class CorrectiveResponsability : ISoftDeleteRepository
	{
		public int Id { get; set; }

		public string ResponsibilityName { get; set; }

		public virtual List<CorrectiveAction> CorrectiveActions { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
