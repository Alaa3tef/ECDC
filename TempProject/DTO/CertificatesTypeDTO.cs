using System.ComponentModel;

namespace TempProject.DTO
{
	public class CertificatesTypeDTO
	{
		public int Id { get; set; }

		public string Type { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
