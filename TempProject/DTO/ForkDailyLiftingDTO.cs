using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Models;

namespace TempProject.DTO
{
	public class ForkDailyLiftingDTO
    {
		public int Id { get; set; }
        public string ForkName { get; set; }
        public string ForkType { get; set; }
        public int ForkChasisNo { get; set; }
        public string ForkCapacity { get; set; }
        public DateTime ForkDateofLastInspection { get; set; }
        public DateTime ForkDateofNextInspection { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
