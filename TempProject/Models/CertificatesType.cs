using System.ComponentModel;
using TempProject.Repository;

namespace TempProject.Models
{
	public class CertificatesType:ISoftDeleteRepository
	{
		public int Id { get; set; }

		public string Type { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
