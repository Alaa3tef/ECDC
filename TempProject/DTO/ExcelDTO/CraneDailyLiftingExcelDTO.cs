using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempProject.DTO.ResponseDTO
{
    public class CraneDailyLiftingExcelDTO
    {
		public int Id { get; set; }
        public string MobileCraneName { get; set; }
        public string Type { get; set; }
        public int ChasisNo { get; set; }
        public string Capacity { get; set; }
        public DateTime DateofLastInspection { get; set; }
        public DateTime DateofNextInspection { get; set; }


    }
}
