using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempProject.DTO
{
	public class HSEEquipmentTableDTO
	{
		public int Id { get; set; }

		public int EquipmentId { get; set; }

		public string Model { get; set; }

		public string SerialNumber { get; set; }


		[Column(TypeName = "date")]
		public DateTime ExpiryDate { get; set; }

		public int RigCertificatesId { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
