using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Composition;
using System.Security.Cryptography;
using TempProject.Repository;

namespace TempProject.Models
{
	public class VehicleWeeklyChecklist : ISoftDeleteRepository
	{
		public int Id { get; set; }

		[ForeignKey("Rig")]
		public int RigId { get; set; }

		public virtual Rig Rig { get; set; }

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

        public List<ManPickup> ManPickups { get; set; }
		public List<RigPickup> RigPickups { get; set; }
		public List<LightBus> LightBus { get; set; }	
		public List<HeavyTruck> HeavyTrucks { get; set; }

		public string HSEEngineer { get; set; }


		[ForeignKey("user")]
		public string userID { get; set; }

		public virtual IdentityUser user { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
	}
}
