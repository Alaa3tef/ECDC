using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Models;

namespace TempProject.DTO
{
	public class VehicleWeeklyChecklistDTO
    {
		public int Id { get; set; }

		public int RigId { get; set; }

		[Column(TypeName = "date")]
		public DateTime Date { get; set; }

        public string Cient { get; set; }
        public string Location { get; set; }

        public string ManPickupVehiclePlateNo { get; set; }
        public string ManPickupDriverName { get; set; }

        public string RigPickupVehiclePlateNo { get; set; }
        public string RigPickupDriverName { get; set; }

        public string PrimeMoverPlateNo { get; set; }
        public string TrailerPlateNo { get; set; }
        public string HeavyTruckDriverName { get; set; }

        public string LightBusVehiclePlateNo { get; set; }
        public string LightBusDriverName { get; set; }

        public List<ManPickupDTO> ManPickups { get; set; }=new List<ManPickupDTO>();
        public List<RigPickupDTO> RigPickups { get; set; } = new List<RigPickupDTO>();
        public List<LightBusDTO> LightBus { get; set; } = new List<LightBusDTO>();
        public List<HeavyTrucksDTO> HeavyTrucks { get; set; } = new List<HeavyTrucksDTO>();

		public string userID { get; set; }
		public string HSEEngineer { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
