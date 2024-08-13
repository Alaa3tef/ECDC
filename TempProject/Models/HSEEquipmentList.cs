using System.ComponentModel;
using TempProject.Repository;

namespace TempProject.Models
{
	public class HSEEquipmentList : ISoftDeleteRepository
	{
		public int Id { get; set; }

		public string Equipment { get; set; }

		public virtual List<HSEEquipmentTable> HSEEquipmentTable { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
