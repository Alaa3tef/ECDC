using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class CraneDailyLifting : ISoftDeleteRepository
	{
		public int Id { get; set; }
		public string MobileCraneName { get; set; }
        public string Type { get; set; }
        public int ChasisNo { get; set; }
        public string Capacity { get; set; }
        public DateTime DateofLastInspection  { get; set; }
        public DateTime DateofNextInspection  { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
	}
}
