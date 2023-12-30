using System.ComponentModel;

namespace TempProject.DTO
{
	public class StandardDTO
	{
		public int Id { get; set; }
		public string StandardName { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
	}
}
