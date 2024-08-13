using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Security.Policy;
using TempProject.Models;

namespace TempProject.Repository
{
	public class VehicleWeeklyChecklistRepository : IVehicleWeeklyChecklistRepository
    {
		Context c;
		public VehicleWeeklyChecklistRepository(Context c)
		{
			this.c = c;
		}

		public List<VehicleWeeklyChecklist> getall()
		{
			return c.VehicleWeeklyChecklists
				.Include(a => a.Rig)
				.Include(a => a.LightBus)
				.Include(a => a.ManPickups)
				.Include(a => a.RigPickups)
				.Include(a => a.HeavyTrucks)
				.Where(a => a.IsDeleted == false)
				.Select(a => new VehicleWeeklyChecklist
				{
					Id = a.Id,
					RigId = a.RigId,
					Rig = new Rig { Number = a.Rig.Number, Id = a.Rig.Id },		
					Date=a.Date,
                    Cient = a.Cient,
                    Location = a.Location,
                    ManPickupVehiclePlateNo = a.ManPickupVehiclePlateNo,
                    ManPickupDriverName = a.ManPickupDriverName,
                    RigPickupVehiclePlateNo = a.RigPickupVehiclePlateNo,
                    RigPickupDriverName = a.RigPickupDriverName,
                    PrimeMoverPlateNo = a.PrimeMoverPlateNo,
                    TrailerPlateNo = a.TrailerPlateNo,
                    HeavyTruckDriverName = a.HeavyTruckDriverName,
                    LightBusDriverName = a.LightBusDriverName,
                    LightBusVehiclePlateNo = a.LightBusVehiclePlateNo,
                    HeavyTrucks = a.HeavyTrucks,
                    ManPickups = a.ManPickups,
					RigPickups = a.RigPickups,
					LightBus=a.LightBus,
					userID = a.userID,
					HSEEngineer = a.HSEEngineer,
					user = new IdentityUser { UserName = a.user.UserName, Id = a.user.Id },
					IsDeleted = a.IsDeleted
				}).ToList();
		}
	}
}
