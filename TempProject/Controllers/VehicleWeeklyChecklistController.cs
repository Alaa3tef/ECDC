using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;
using TempProject.DTO.ResponseDTO;
using NuGet.Configuration;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VehicleWeeklyChecklistController : ControllerBase
	{
		public IRepository<VehicleWeeklyChecklist> VehicleWeeklyChecklistRepo;
		public IVehicleWeeklyChecklistRepository VehicleWeeklyChecklistRepoistory;

		private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager;

		public IRepository<LightBus> LightBusRepo;

		public IRepository<ManPickup> ManPickupRepo;

        public IRepository<RigPickup> RigPukupRepo;

        public IRepository<HeavyTruck> HeavyTruckRepo;
        public VehicleWeeklyChecklistController(IRepository<VehicleWeeklyChecklist> _VehicleWeeklyChecklistRepo, 
			IRepository<LightBus> _LightBusRepo, 
			IRepository<ManPickup> _ManPickupRepo,
            IRepository<RigPickup> _RigPuckupRepo,
            IRepository<HeavyTruck> _HeavyTruckRepo,
            Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager, 
			IVehicleWeeklyChecklistRepository _VehicleWeeklyChecklistRepoistory)
		{
			this.LightBusRepo = _LightBusRepo;
			this.ManPickupRepo = _ManPickupRepo;
			this.userManager = _userManager;
			this.RigPukupRepo = _RigPuckupRepo;
			this.HeavyTruckRepo = _HeavyTruckRepo;
			this.VehicleWeeklyChecklistRepoistory = _VehicleWeeklyChecklistRepoistory;
			this.VehicleWeeklyChecklistRepo = _VehicleWeeklyChecklistRepo;

        }

		[HttpGet("GetData")]
		public async Task<ResultDTO> GetAllWithData(string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<VehicleWeeklyChecklist> temp = VehicleWeeklyChecklistRepoistory.getall();
					List<VehicleWeeklyChecklistResponseDTO> newTemp = new List<VehicleWeeklyChecklistResponseDTO>();
					foreach (VehicleWeeklyChecklist vehicleWeeklyChecklist in temp)
					{
						VehicleWeeklyChecklistResponseDTO vehicleWeeklyChecklistResponse = new VehicleWeeklyChecklistResponseDTO();
                        vehicleWeeklyChecklistResponse.Id = vehicleWeeklyChecklist.Id;
                        vehicleWeeklyChecklistResponse.RigNo = vehicleWeeklyChecklist.Rig.Number;
                        vehicleWeeklyChecklistResponse.RigNumber = vehicleWeeklyChecklist.Rig.Number;

                        vehicleWeeklyChecklistResponse.Date = vehicleWeeklyChecklist.Date;
                        vehicleWeeklyChecklistResponse.LightBusDriverName = vehicleWeeklyChecklist.LightBusDriverName;
                        vehicleWeeklyChecklistResponse.LightBusVehiclePlateNo = vehicleWeeklyChecklist.LightBusVehiclePlateNo;
                        vehicleWeeklyChecklistResponse.HeavyTruckDriverName = vehicleWeeklyChecklist.HeavyTruckDriverName;
                        vehicleWeeklyChecklistResponse.TrailerPlateNo = vehicleWeeklyChecklist.TrailerPlateNo;
                        vehicleWeeklyChecklistResponse.PrimeMoverPlateNo = vehicleWeeklyChecklist.PrimeMoverPlateNo;
                        vehicleWeeklyChecklistResponse.RigPickupDriverName = vehicleWeeklyChecklist.RigPickupDriverName;
                        vehicleWeeklyChecklistResponse.RigPickupVehiclePlateNo = vehicleWeeklyChecklist.RigPickupVehiclePlateNo;
                        vehicleWeeklyChecklistResponse.ManPickupDriverName = vehicleWeeklyChecklist.ManPickupDriverName;
                        vehicleWeeklyChecklistResponse.ManPickupVehiclePlateNo = vehicleWeeklyChecklist.ManPickupVehiclePlateNo;
                        vehicleWeeklyChecklistResponse.Location = vehicleWeeklyChecklist.Location;
                        vehicleWeeklyChecklistResponse.Cient = vehicleWeeklyChecklist.Cient;
						vehicleWeeklyChecklistResponse.HSEEngineer = vehicleWeeklyChecklist.HSEEngineer;

						vehicleWeeklyChecklistResponse.userName = vehicleWeeklyChecklist.user.UserName;
						foreach(var item in vehicleWeeklyChecklist.LightBus)
						{
							LightBusDTO lightBusDTO = new LightBusDTO();
                            lightBusDTO.Id = item.Id;
                            lightBusDTO.Status = item.Status;
                            lightBusDTO.Remarks = item.Remarks;
                            lightBusDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            lightBusDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.LightBus.Add(lightBusDTO);
						}
                        foreach (var item in vehicleWeeklyChecklist.ManPickups)
                        {
                            ManPickupDTO manPickupDTO = new ManPickupDTO();
                            manPickupDTO.Id = item.Id;
                            manPickupDTO.Status = item.Status;
                            manPickupDTO.Remarks = item.Remarks;
                            manPickupDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            manPickupDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.ManPickups.Add(manPickupDTO);
                        }
                        foreach (var item in vehicleWeeklyChecklist.HeavyTrucks)
                        {
                            HeavyTrucksDTO heavyTrucksDTO = new HeavyTrucksDTO();
                            heavyTrucksDTO.Id = item.Id;
                            heavyTrucksDTO.Status = item.Status;
                            heavyTrucksDTO.Remarks = item.Remarks;
                            heavyTrucksDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            heavyTrucksDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.HeavyTrucks.Add(heavyTrucksDTO);
                        }
                        foreach (var item in vehicleWeeklyChecklist.RigPickups)
                        {
                            RigPickupDTO rigPickupDTO = new RigPickupDTO();
                            rigPickupDTO.Id = item.Id;
                            rigPickupDTO.Status = item.Status;
                            rigPickupDTO.Remarks = item.Remarks;
                            rigPickupDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            rigPickupDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.RigPickups.Add(rigPickupDTO);
                        }

                        newTemp.Add(vehicleWeeklyChecklistResponse);
						//result.Data = prod;
					}
					
					if (newTemp != null)
					{
						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<VehicleWeeklyChecklist> temp = VehicleWeeklyChecklistRepoistory.getall().Where(a => a.user.Id == UserID).ToList();
                    List<VehicleWeeklyChecklistResponseDTO> newTemp = new List<VehicleWeeklyChecklistResponseDTO>();
                    foreach (VehicleWeeklyChecklist vehicleWeeklyChecklist in temp)
                    {
                        VehicleWeeklyChecklistResponseDTO vehicleWeeklyChecklistResponse = new VehicleWeeklyChecklistResponseDTO();
                        vehicleWeeklyChecklistResponse.Id = vehicleWeeklyChecklist.Id;
                        vehicleWeeklyChecklistResponse.RigNo = vehicleWeeklyChecklist.Rig.Number;
                        vehicleWeeklyChecklistResponse.Date = vehicleWeeklyChecklist.Date;
                        vehicleWeeklyChecklistResponse.LightBusDriverName = vehicleWeeklyChecklist.LightBusDriverName;
                        vehicleWeeklyChecklistResponse.LightBusVehiclePlateNo = vehicleWeeklyChecklist.LightBusVehiclePlateNo;
                        vehicleWeeklyChecklistResponse.HeavyTruckDriverName = vehicleWeeklyChecklist.HeavyTruckDriverName;
                        vehicleWeeklyChecklistResponse.TrailerPlateNo = vehicleWeeklyChecklist.TrailerPlateNo;
                        vehicleWeeklyChecklistResponse.PrimeMoverPlateNo = vehicleWeeklyChecklist.PrimeMoverPlateNo;
                        vehicleWeeklyChecklistResponse.RigPickupDriverName = vehicleWeeklyChecklist.RigPickupDriverName;
                        vehicleWeeklyChecklistResponse.RigPickupVehiclePlateNo = vehicleWeeklyChecklist.RigPickupVehiclePlateNo;
                        vehicleWeeklyChecklistResponse.ManPickupDriverName = vehicleWeeklyChecklist.ManPickupDriverName;
                        vehicleWeeklyChecklistResponse.ManPickupVehiclePlateNo = vehicleWeeklyChecklist.ManPickupVehiclePlateNo;
                        vehicleWeeklyChecklistResponse.Location = vehicleWeeklyChecklist.Location;
                        vehicleWeeklyChecklistResponse.Cient = vehicleWeeklyChecklist.Cient;
						vehicleWeeklyChecklistResponse.HSEEngineer = vehicleWeeklyChecklist.HSEEngineer;

						vehicleWeeklyChecklistResponse.userName = vehicleWeeklyChecklist.user.UserName;
                        foreach (var item in vehicleWeeklyChecklist.LightBus)
                        {
                            LightBusDTO lightBusDTO = new LightBusDTO();
                            lightBusDTO.Id = item.Id;
                            lightBusDTO.Status = item.Status;
                            lightBusDTO.Remarks = item.Remarks;
                            lightBusDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            lightBusDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.LightBus.Add(lightBusDTO);
                        }
                        foreach (var item in vehicleWeeklyChecklist.ManPickups)
                        {
                            ManPickupDTO manPickupDTO = new ManPickupDTO();
                            manPickupDTO.Id = item.Id;
                            manPickupDTO.Status = item.Status;
                            manPickupDTO.Remarks = item.Remarks;
                            manPickupDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            manPickupDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.ManPickups.Add(manPickupDTO);
                        }
                        foreach (var item in vehicleWeeklyChecklist.HeavyTrucks)
                        {
                            HeavyTrucksDTO heavyTrucksDTO = new HeavyTrucksDTO();
                            heavyTrucksDTO.Id = item.Id;
                            heavyTrucksDTO.Status = item.Status;
                            heavyTrucksDTO.Remarks = item.Remarks;
                            heavyTrucksDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            heavyTrucksDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.HeavyTrucks.Add(heavyTrucksDTO);
                        }
                        foreach (var item in vehicleWeeklyChecklist.RigPickups)
                        {
                            RigPickupDTO rigPickupDTO = new RigPickupDTO();
                            rigPickupDTO.Id = item.Id;
                            rigPickupDTO.Status = item.Status;
                            rigPickupDTO.Remarks = item.Remarks;
                            rigPickupDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            rigPickupDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.RigPickups.Add(rigPickupDTO);
                        }

                        newTemp.Add(vehicleWeeklyChecklistResponse);
                        //result.Data = prod;
                    }

                    if (newTemp != null)
					{
						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}
				}
			}
			catch (Exception ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}
			return result;
		}


		[HttpGet("GetDataForPrint")]
		public async Task<ResultDTO> GetAllWithDataForPrint(int RigNo, DateTime date, string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<VehicleWeeklyChecklist> temp = VehicleWeeklyChecklistRepoistory.getall().Where(w => w.Date == date && w.Rig.Number == RigNo).ToList();
                    List<VehicleWeeklyChecklistResponseDTO> newTemp = new List<VehicleWeeklyChecklistResponseDTO>();
                    foreach (VehicleWeeklyChecklist vehicleWeeklyChecklist in temp)
                    {
                        VehicleWeeklyChecklistResponseDTO vehicleWeeklyChecklistResponse = new VehicleWeeklyChecklistResponseDTO();
                        vehicleWeeklyChecklistResponse.Id = vehicleWeeklyChecklist.Id;
                        vehicleWeeklyChecklistResponse.RigNo = vehicleWeeklyChecklist.Rig.Number;
                        vehicleWeeklyChecklistResponse.Date = vehicleWeeklyChecklist.Date;
                        vehicleWeeklyChecklistResponse.LightBusDriverName = vehicleWeeklyChecklist.LightBusDriverName;
                        vehicleWeeklyChecklistResponse.LightBusVehiclePlateNo = vehicleWeeklyChecklist.LightBusVehiclePlateNo;
                        vehicleWeeklyChecklistResponse.HeavyTruckDriverName = vehicleWeeklyChecklist.HeavyTruckDriverName;
                        vehicleWeeklyChecklistResponse.TrailerPlateNo = vehicleWeeklyChecklist.TrailerPlateNo;
                        vehicleWeeklyChecklistResponse.PrimeMoverPlateNo = vehicleWeeklyChecklist.PrimeMoverPlateNo;
                        vehicleWeeklyChecklistResponse.RigPickupDriverName = vehicleWeeklyChecklist.RigPickupDriverName;
                        vehicleWeeklyChecklistResponse.RigPickupVehiclePlateNo = vehicleWeeklyChecklist.RigPickupVehiclePlateNo;
                        vehicleWeeklyChecklistResponse.ManPickupDriverName = vehicleWeeklyChecklist.ManPickupDriverName;
                        vehicleWeeklyChecklistResponse.ManPickupVehiclePlateNo = vehicleWeeklyChecklist.ManPickupVehiclePlateNo;
                        vehicleWeeklyChecklistResponse.Location = vehicleWeeklyChecklist.Location;
                        vehicleWeeklyChecklistResponse.Cient = vehicleWeeklyChecklist.Cient;
						vehicleWeeklyChecklistResponse.HSEEngineer = vehicleWeeklyChecklist.HSEEngineer;

						vehicleWeeklyChecklistResponse.userName = vehicleWeeklyChecklist.user.UserName;
                        foreach (var item in vehicleWeeklyChecklist.LightBus)
                        {
                            LightBusDTO lightBusDTO = new LightBusDTO();
                            lightBusDTO.Id = item.Id;
                            lightBusDTO.Status = item.Status;
							lightBusDTO.Item=item.Item;
                            lightBusDTO.Remarks = item.Remarks;
                            lightBusDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            lightBusDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.LightBus.Add(lightBusDTO);
                        }
                        foreach (var item in vehicleWeeklyChecklist.ManPickups)
                        {
                            ManPickupDTO manPickupDTO = new ManPickupDTO();
                            manPickupDTO.Id = item.Id;
                            manPickupDTO.Status = item.Status;
							manPickupDTO.Item = item.Item;
                            manPickupDTO.Remarks = item.Remarks;
                            manPickupDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            manPickupDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.ManPickups.Add(manPickupDTO);
                        }
                        foreach (var item in vehicleWeeklyChecklist.HeavyTrucks)
                        {
                            HeavyTrucksDTO heavyTrucksDTO = new HeavyTrucksDTO();
                            heavyTrucksDTO.Id = item.Id;
                            heavyTrucksDTO.Status = item.Status;
                            heavyTrucksDTO.Remarks = item.Remarks;
							heavyTrucksDTO.Item= item.Item;
                            heavyTrucksDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            heavyTrucksDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.HeavyTrucks.Add(heavyTrucksDTO);
                        }
                        foreach (var item in vehicleWeeklyChecklist.RigPickups)
                        {
                            RigPickupDTO rigPickupDTO = new RigPickupDTO();
                            rigPickupDTO.Id = item.Id;
                            rigPickupDTO.Status = item.Status;
                            rigPickupDTO.Remarks = item.Remarks;
							rigPickupDTO.Item = item.Item;
                            rigPickupDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            rigPickupDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.RigPickups.Add(rigPickupDTO);
                        }


                        newTemp.Add(vehicleWeeklyChecklistResponse);
						//result.Data = prod;
					}
					if (newTemp != null)
					{
						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<VehicleWeeklyChecklist> temp = VehicleWeeklyChecklistRepoistory.getall().Where(a => a.user.Id == UserID && a.Date == date && a.Rig.Number == RigNo).ToList();
                    List<VehicleWeeklyChecklistResponseDTO> newTemp = new List<VehicleWeeklyChecklistResponseDTO>();
                    foreach (VehicleWeeklyChecklist vehicleWeeklyChecklist in temp)
                    {
                        VehicleWeeklyChecklistResponseDTO vehicleWeeklyChecklistResponse = new VehicleWeeklyChecklistResponseDTO();
                        vehicleWeeklyChecklistResponse.Id = vehicleWeeklyChecklist.Id;
                        vehicleWeeklyChecklistResponse.RigNo = vehicleWeeklyChecklist.Rig.Number;
                        vehicleWeeklyChecklistResponse.Date = vehicleWeeklyChecklist.Date;
                        vehicleWeeklyChecklistResponse.LightBusDriverName = vehicleWeeklyChecklist.LightBusDriverName;
                        vehicleWeeklyChecklistResponse.LightBusVehiclePlateNo = vehicleWeeklyChecklist.LightBusVehiclePlateNo;
                        vehicleWeeklyChecklistResponse.HeavyTruckDriverName = vehicleWeeklyChecklist.HeavyTruckDriverName;
                        vehicleWeeklyChecklistResponse.TrailerPlateNo = vehicleWeeklyChecklist.TrailerPlateNo;
                        vehicleWeeklyChecklistResponse.PrimeMoverPlateNo = vehicleWeeklyChecklist.PrimeMoverPlateNo;
                        vehicleWeeklyChecklistResponse.RigPickupDriverName = vehicleWeeklyChecklist.RigPickupDriverName;
                        vehicleWeeklyChecklistResponse.RigPickupVehiclePlateNo = vehicleWeeklyChecklist.RigPickupVehiclePlateNo;
                        vehicleWeeklyChecklistResponse.ManPickupDriverName = vehicleWeeklyChecklist.ManPickupDriverName;
                        vehicleWeeklyChecklistResponse.ManPickupVehiclePlateNo = vehicleWeeklyChecklist.ManPickupVehiclePlateNo;
                        vehicleWeeklyChecklistResponse.Location = vehicleWeeklyChecklist.Location;
                        vehicleWeeklyChecklistResponse.Cient = vehicleWeeklyChecklist.Cient;
						vehicleWeeklyChecklistResponse.HSEEngineer = vehicleWeeklyChecklist.HSEEngineer;

						vehicleWeeklyChecklistResponse.userName = vehicleWeeklyChecklist.user.UserName;
                        foreach (var item in vehicleWeeklyChecklist.LightBus)
                        {
                            LightBusDTO lightBusDTO = new LightBusDTO();
                            lightBusDTO.Id = item.Id;
                            lightBusDTO.Status = item.Status;
                            lightBusDTO.Remarks = item.Remarks;
                            lightBusDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            lightBusDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.LightBus.Add(lightBusDTO);
                        }
                        foreach (var item in vehicleWeeklyChecklist.ManPickups)
                        {
                            ManPickupDTO manPickupDTO = new ManPickupDTO();
                            manPickupDTO.Id = item.Id;
                            manPickupDTO.Status = item.Status;
                            manPickupDTO.Remarks = item.Remarks;
                            manPickupDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            manPickupDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.ManPickups.Add(manPickupDTO);
                        }
                        foreach (var item in vehicleWeeklyChecklist.HeavyTrucks)
                        {
                            HeavyTrucksDTO heavyTrucksDTO = new HeavyTrucksDTO();
                            heavyTrucksDTO.Id = item.Id;
                            heavyTrucksDTO.Status = item.Status;
                            heavyTrucksDTO.Remarks = item.Remarks;
                            heavyTrucksDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            heavyTrucksDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.HeavyTrucks.Add(heavyTrucksDTO);
                        }
                        foreach (var item in vehicleWeeklyChecklist.RigPickups)
                        {
                            RigPickupDTO rigPickupDTO = new RigPickupDTO();
                            rigPickupDTO.Id = item.Id;
                            rigPickupDTO.Status = item.Status;
                            rigPickupDTO.Remarks = item.Remarks;
                            rigPickupDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            rigPickupDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.RigPickups.Add(rigPickupDTO);
                        }

                        newTemp.Add(vehicleWeeklyChecklistResponse);
						//result.Data = prod;
					}
					if (newTemp != null)
					{
						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}
				}
			}
			catch (Exception ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}
			return result;
		}


		[HttpGet("ByPage/{page:int}")]
		public PageResult<VehicleWeeklyChecklistResponseDTO> GettAllVehicleWeeklyChecklistByPage(string UserId, string UserRole, int? page, int pagesize = 10)
		{
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<VehicleWeeklyChecklist> temp = VehicleWeeklyChecklistRepoistory.getall();
					List<VehicleWeeklyChecklistResponseDTO> newTemp = new List<VehicleWeeklyChecklistResponseDTO>();
					foreach (VehicleWeeklyChecklist vehicleWeeklyChecklist in temp)
					{
                       VehicleWeeklyChecklistResponseDTO vehicleWeeklyChecklistResponse = new VehicleWeeklyChecklistResponseDTO();
                        vehicleWeeklyChecklistResponse.Id = vehicleWeeklyChecklist.Id;
                        vehicleWeeklyChecklistResponse.RigNo = vehicleWeeklyChecklist.Rig.Number;
                        vehicleWeeklyChecklistResponse.Date = vehicleWeeklyChecklist.Date;
                        vehicleWeeklyChecklistResponse.LightBusDriverName = vehicleWeeklyChecklist.LightBusDriverName;
                        vehicleWeeklyChecklistResponse.LightBusVehiclePlateNo = vehicleWeeklyChecklist.LightBusVehiclePlateNo;
                        vehicleWeeklyChecklistResponse.HeavyTruckDriverName = vehicleWeeklyChecklist.HeavyTruckDriverName;
                        vehicleWeeklyChecklistResponse.TrailerPlateNo = vehicleWeeklyChecklist.TrailerPlateNo;
                        vehicleWeeklyChecklistResponse.PrimeMoverPlateNo = vehicleWeeklyChecklist.PrimeMoverPlateNo;
                        vehicleWeeklyChecklistResponse.RigPickupDriverName = vehicleWeeklyChecklist.RigPickupDriverName;
                        vehicleWeeklyChecklistResponse.RigPickupVehiclePlateNo = vehicleWeeklyChecklist.RigPickupVehiclePlateNo;
                        vehicleWeeklyChecklistResponse.ManPickupDriverName = vehicleWeeklyChecklist.ManPickupDriverName;
                        vehicleWeeklyChecklistResponse.ManPickupVehiclePlateNo = vehicleWeeklyChecklist.ManPickupVehiclePlateNo;
                        vehicleWeeklyChecklistResponse.Location = vehicleWeeklyChecklist.Location;
                        vehicleWeeklyChecklistResponse.Cient = vehicleWeeklyChecklist.Cient;
						vehicleWeeklyChecklistResponse.HSEEngineer = vehicleWeeklyChecklist.HSEEngineer;

						vehicleWeeklyChecklistResponse.userName = vehicleWeeklyChecklist.user.UserName;
                        foreach (var item in vehicleWeeklyChecklist.LightBus)
                        {
                            LightBusDTO lightBusDTO = new LightBusDTO();
                            lightBusDTO.Id = item.Id;
                            lightBusDTO.Status = item.Status;
                            lightBusDTO.Remarks = item.Remarks;
                            lightBusDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            lightBusDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.LightBus.Add(lightBusDTO);
                        }
                        foreach (var item in vehicleWeeklyChecklist.ManPickups)
                        {
                            ManPickupDTO manPickupDTO = new ManPickupDTO();
                            manPickupDTO.Id = item.Id;
                            manPickupDTO.Status = item.Status;
                            manPickupDTO.Remarks = item.Remarks;
                            manPickupDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            manPickupDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.ManPickups.Add(manPickupDTO);
                        }
                        foreach (var item in vehicleWeeklyChecklist.HeavyTrucks)
                        {
                            HeavyTrucksDTO heavyTrucksDTO = new HeavyTrucksDTO();
                            heavyTrucksDTO.Id = item.Id;
                            heavyTrucksDTO.Status = item.Status;
                            heavyTrucksDTO.Remarks = item.Remarks;
                            heavyTrucksDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            heavyTrucksDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.HeavyTrucks.Add(heavyTrucksDTO);
                        }
                        foreach (var item in vehicleWeeklyChecklist.RigPickups)
                        {
                            RigPickupDTO rigPickupDTO = new RigPickupDTO();
                            rigPickupDTO.Id = item.Id;
                            rigPickupDTO.Status = item.Status;
                            rigPickupDTO.Remarks = item.Remarks;
                            rigPickupDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            rigPickupDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.RigPickups.Add(rigPickupDTO);
                        }

                        newTemp.Add(vehicleWeeklyChecklistResponse);
					}


					float countDetails = VehicleWeeklyChecklistRepoistory.getall().Count();
					var result = new PageResult<VehicleWeeklyChecklistResponseDTO>
					{
						Count = (int)Math.Ceiling(countDetails / pagesize),
						PageIndex = page ?? 1,
						PageSize = pagesize,
						Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
					};

					return result;

				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<VehicleWeeklyChecklist> temp = VehicleWeeklyChecklistRepoistory.getall().Where(a => a.user.Id == UserId).ToList();
					List<VehicleWeeklyChecklistResponseDTO> newTemp = new List<VehicleWeeklyChecklistResponseDTO>();
					foreach (VehicleWeeklyChecklist vehicleWeeklyChecklist in temp)
					{
                        VehicleWeeklyChecklistResponseDTO vehicleWeeklyChecklistResponse = new VehicleWeeklyChecklistResponseDTO();
                        vehicleWeeklyChecklistResponse.Id = vehicleWeeklyChecklist.Id;
                        vehicleWeeklyChecklistResponse.RigNo = vehicleWeeklyChecklist.Rig.Number;
                        vehicleWeeklyChecklistResponse.Date = vehicleWeeklyChecklist.Date;
                        vehicleWeeklyChecklistResponse.LightBusDriverName = vehicleWeeklyChecklist.LightBusDriverName;
                        vehicleWeeklyChecklistResponse.LightBusVehiclePlateNo = vehicleWeeklyChecklist.LightBusVehiclePlateNo;
                        vehicleWeeklyChecklistResponse.HeavyTruckDriverName = vehicleWeeklyChecklist.HeavyTruckDriverName;
                        vehicleWeeklyChecklistResponse.TrailerPlateNo = vehicleWeeklyChecklist.TrailerPlateNo;
                        vehicleWeeklyChecklistResponse.PrimeMoverPlateNo = vehicleWeeklyChecklist.PrimeMoverPlateNo;
                        vehicleWeeklyChecklistResponse.RigPickupDriverName = vehicleWeeklyChecklist.RigPickupDriverName;
                        vehicleWeeklyChecklistResponse.RigPickupVehiclePlateNo = vehicleWeeklyChecklist.RigPickupVehiclePlateNo;
                        vehicleWeeklyChecklistResponse.ManPickupDriverName = vehicleWeeklyChecklist.ManPickupDriverName;
                        vehicleWeeklyChecklistResponse.ManPickupVehiclePlateNo = vehicleWeeklyChecklist.ManPickupVehiclePlateNo;
                        vehicleWeeklyChecklistResponse.Location = vehicleWeeklyChecklist.Location;
                        vehicleWeeklyChecklistResponse.Cient = vehicleWeeklyChecklist.Cient;
						vehicleWeeklyChecklistResponse.HSEEngineer = vehicleWeeklyChecklist.HSEEngineer;

						vehicleWeeklyChecklistResponse.userName = vehicleWeeklyChecklist.user.UserName;
                        foreach (var item in vehicleWeeklyChecklist.LightBus)
                        {
                            LightBusDTO lightBusDTO = new LightBusDTO();
                            lightBusDTO.Id = item.Id;
                            lightBusDTO.Status = item.Status;
                            lightBusDTO.Remarks = item.Remarks;
                            lightBusDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            lightBusDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.LightBus.Add(lightBusDTO);
                        }
                        foreach (var item in vehicleWeeklyChecklist.ManPickups)
                        {
                            ManPickupDTO manPickupDTO = new ManPickupDTO();
                            manPickupDTO.Id = item.Id;
                            manPickupDTO.Status = item.Status;
                            manPickupDTO.Remarks = item.Remarks;
                            manPickupDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            manPickupDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.ManPickups.Add(manPickupDTO);
                        }
                        foreach (var item in vehicleWeeklyChecklist.HeavyTrucks)
                        {
                            HeavyTrucksDTO heavyTrucksDTO = new HeavyTrucksDTO();
                            heavyTrucksDTO.Id = item.Id;
                            heavyTrucksDTO.Status = item.Status;
                            heavyTrucksDTO.Remarks = item.Remarks;
                            heavyTrucksDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            heavyTrucksDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.HeavyTrucks.Add(heavyTrucksDTO);
                        }
                        foreach (var item in vehicleWeeklyChecklist.RigPickups)
                        {
                            RigPickupDTO rigPickupDTO = new RigPickupDTO();
                            rigPickupDTO.Id = item.Id;
                            rigPickupDTO.Status = item.Status;
                            rigPickupDTO.Remarks = item.Remarks;
                            rigPickupDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                            rigPickupDTO.IsDeleted = item.IsDeleted;
                            vehicleWeeklyChecklistResponse.RigPickups.Add(rigPickupDTO);
                        }

                        newTemp.Add(vehicleWeeklyChecklistResponse);
                       
					}
					float countDetails = VehicleWeeklyChecklistRepoistory.getall().Where(a => a.user.Id == UserId).Count();
					var result = new PageResult<VehicleWeeklyChecklistResponseDTO>
					{
						Count = (int)Math.Ceiling(countDetails / pagesize),
						PageIndex = page ?? 1,
						PageSize = pagesize,
						Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
					};
					return result;
				}
			}
			catch (Exception ex)
			{
				return new PageResult<VehicleWeeklyChecklistResponseDTO>();

			}
			return new PageResult<VehicleWeeklyChecklistResponseDTO>();
		}


		[HttpGet("GetDataById/{ID:int}")]
		public ActionResult<ResultDTO> GetAllWithDataByID(int ID, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();
			if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
			{
                VehicleWeeklyChecklist vehicleWeeklyChecklist = VehicleWeeklyChecklistRepoistory.getall().FirstOrDefault(a => a.Id == ID);
				if (vehicleWeeklyChecklist != null)
				{
                    VehicleWeeklyChecklistResponseDTO vehicleWeeklyChecklistResponse = new VehicleWeeklyChecklistResponseDTO();
                    vehicleWeeklyChecklistResponse.Id = default;
                    vehicleWeeklyChecklistResponse.RigNo = vehicleWeeklyChecklist.RigId;
                    vehicleWeeklyChecklistResponse.Date = vehicleWeeklyChecklist.Date;
                    vehicleWeeklyChecklistResponse.LightBusDriverName = vehicleWeeklyChecklist.LightBusDriverName;
                    vehicleWeeklyChecklistResponse.LightBusVehiclePlateNo = vehicleWeeklyChecklist.LightBusVehiclePlateNo;
                    vehicleWeeklyChecklistResponse.HeavyTruckDriverName = vehicleWeeklyChecklist.HeavyTruckDriverName;
                    vehicleWeeklyChecklistResponse.TrailerPlateNo = vehicleWeeklyChecklist.TrailerPlateNo;
                    vehicleWeeklyChecklistResponse.PrimeMoverPlateNo = vehicleWeeklyChecklist.PrimeMoverPlateNo;
                    vehicleWeeklyChecklistResponse.RigPickupDriverName = vehicleWeeklyChecklist.RigPickupDriverName;
                    vehicleWeeklyChecklistResponse.RigPickupVehiclePlateNo = vehicleWeeklyChecklist.RigPickupVehiclePlateNo;
                    vehicleWeeklyChecklistResponse.ManPickupDriverName = vehicleWeeklyChecklist.ManPickupDriverName;
                    vehicleWeeklyChecklistResponse.ManPickupVehiclePlateNo = vehicleWeeklyChecklist.ManPickupVehiclePlateNo;
                    vehicleWeeklyChecklistResponse.Location = vehicleWeeklyChecklist.Location;
                    vehicleWeeklyChecklistResponse.Cient = vehicleWeeklyChecklist.Cient;
					vehicleWeeklyChecklistResponse.HSEEngineer = vehicleWeeklyChecklist.HSEEngineer;

					vehicleWeeklyChecklistResponse.userName = vehicleWeeklyChecklist.user.UserName;
                    foreach (var item in vehicleWeeklyChecklist.LightBus)
                    {
                        LightBusDTO lightBusDTO = new LightBusDTO();
                        lightBusDTO.Id = item.Id;
                        lightBusDTO.Status = item.Status;
                        lightBusDTO.Remarks = item.Remarks;
						lightBusDTO.Item=item.Item;
                        lightBusDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                        lightBusDTO.IsDeleted = item.IsDeleted;
                        vehicleWeeklyChecklistResponse.LightBus.Add(lightBusDTO);
                    }
                    foreach (var item in vehicleWeeklyChecklist.ManPickups)
                    {
                        ManPickupDTO manPickupDTO = new ManPickupDTO();
                        manPickupDTO.Id = item.Id;
                        manPickupDTO.Status = item.Status;
						manPickupDTO.Item = item.Item;
                        manPickupDTO.Remarks = item.Remarks;
                        manPickupDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                        manPickupDTO.IsDeleted = item.IsDeleted;
                        vehicleWeeklyChecklistResponse.ManPickups.Add(manPickupDTO);
                    }
                    foreach (var item in vehicleWeeklyChecklist.HeavyTrucks)
                    {
                        HeavyTrucksDTO heavyTrucksDTO = new HeavyTrucksDTO();
                        heavyTrucksDTO.Id = item.Id;
                        heavyTrucksDTO.Status = item.Status;
						heavyTrucksDTO.Item = item.Item;
                        heavyTrucksDTO.Remarks = item.Remarks;
                        heavyTrucksDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                        heavyTrucksDTO.IsDeleted = item.IsDeleted;
                        vehicleWeeklyChecklistResponse.HeavyTrucks.Add(heavyTrucksDTO);
                    }
                    foreach (var item in vehicleWeeklyChecklist.RigPickups)
                    {
                        RigPickupDTO rigPickupDTO = new RigPickupDTO();
                        rigPickupDTO.Id = item.Id;
                        rigPickupDTO.Status = item.Status;
						rigPickupDTO.Item = item.Item;
                        rigPickupDTO.Remarks = item.Remarks;
                        rigPickupDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                        rigPickupDTO.IsDeleted = item.IsDeleted;
                        vehicleWeeklyChecklistResponse.RigPickups.Add(rigPickupDTO);
                    }


                    result.Message = "Success";
					result.Statescode = 200;
					result.Data = vehicleWeeklyChecklistResponse;

					return result;
				}
			}
			else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
			{
                VehicleWeeklyChecklist vehicleWeeklyChecklist = VehicleWeeklyChecklistRepoistory.getall().FirstOrDefault(a => a.Id == ID && a.user.Id == UserId);
				if (vehicleWeeklyChecklist != null)
				{
                    VehicleWeeklyChecklistResponseDTO vehicleWeeklyChecklistResponse = new VehicleWeeklyChecklistResponseDTO();
                    vehicleWeeklyChecklistResponse.Id = default;
                    vehicleWeeklyChecklistResponse.RigNo = vehicleWeeklyChecklist.Rig.Number;
                    vehicleWeeklyChecklistResponse.Date = vehicleWeeklyChecklist.Date;
                    vehicleWeeklyChecklistResponse.LightBusDriverName = vehicleWeeklyChecklist.LightBusDriverName;
                    vehicleWeeklyChecklistResponse.LightBusVehiclePlateNo = vehicleWeeklyChecklist.LightBusVehiclePlateNo;
                    vehicleWeeklyChecklistResponse.HeavyTruckDriverName = vehicleWeeklyChecklist.HeavyTruckDriverName;
                    vehicleWeeklyChecklistResponse.TrailerPlateNo = vehicleWeeklyChecklist.TrailerPlateNo;
                    vehicleWeeklyChecklistResponse.PrimeMoverPlateNo = vehicleWeeklyChecklist.PrimeMoverPlateNo;
                    vehicleWeeklyChecklistResponse.RigPickupDriverName = vehicleWeeklyChecklist.RigPickupDriverName;
                    vehicleWeeklyChecklistResponse.RigPickupVehiclePlateNo = vehicleWeeklyChecklist.RigPickupVehiclePlateNo;
                    vehicleWeeklyChecklistResponse.ManPickupDriverName = vehicleWeeklyChecklist.ManPickupDriverName;
                    vehicleWeeklyChecklistResponse.ManPickupVehiclePlateNo = vehicleWeeklyChecklist.ManPickupVehiclePlateNo;
                    vehicleWeeklyChecklistResponse.Location = vehicleWeeklyChecklist.Location;
                    vehicleWeeklyChecklistResponse.Cient = vehicleWeeklyChecklist.Cient;
					vehicleWeeklyChecklistResponse.HSEEngineer = vehicleWeeklyChecklist.HSEEngineer;

					vehicleWeeklyChecklistResponse.userName = vehicleWeeklyChecklist.user.UserName;
                    foreach (var item in vehicleWeeklyChecklist.LightBus)
                    {
                        LightBusDTO lightBusDTO = new LightBusDTO();
                        lightBusDTO.Id = item.Id;
                        lightBusDTO.Status = item.Status;
                        lightBusDTO.Remarks = item.Remarks;
						lightBusDTO.Item = item.Item;
						lightBusDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                        lightBusDTO.IsDeleted = item.IsDeleted;
                        vehicleWeeklyChecklistResponse.LightBus.Add(lightBusDTO);
                    }
                    foreach (var item in vehicleWeeklyChecklist.ManPickups)
                    {
                        ManPickupDTO manPickupDTO = new ManPickupDTO();
                        manPickupDTO.Id = item.Id;
                        manPickupDTO.Status = item.Status;
						manPickupDTO.Remarks = item.Remarks;
						manPickupDTO.Item = item.Item;
						manPickupDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                        manPickupDTO.IsDeleted = item.IsDeleted;
                        vehicleWeeklyChecklistResponse.ManPickups.Add(manPickupDTO);
                    }
                    foreach (var item in vehicleWeeklyChecklist.HeavyTrucks)
                    {
                        HeavyTrucksDTO heavyTrucksDTO = new HeavyTrucksDTO();
                        heavyTrucksDTO.Id = item.Id;
                        heavyTrucksDTO.Status = item.Status;
                        heavyTrucksDTO.Remarks = item.Remarks;
                        heavyTrucksDTO.Item = item.Item;
						heavyTrucksDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                        heavyTrucksDTO.IsDeleted = item.IsDeleted;
                        vehicleWeeklyChecklistResponse.HeavyTrucks.Add(heavyTrucksDTO);
                    }
                    foreach (var item in vehicleWeeklyChecklist.RigPickups)
                    {
                        RigPickupDTO rigPickupDTO = new RigPickupDTO();
                        rigPickupDTO.Id = item.Id;
                        rigPickupDTO.Status = item.Status;
                        rigPickupDTO.Remarks = item.Remarks;
                        rigPickupDTO.Item = item.Item;
						rigPickupDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                        rigPickupDTO.IsDeleted = item.IsDeleted;
                        vehicleWeeklyChecklistResponse.RigPickups.Add(rigPickupDTO);
                    }


                    result.Message = "Success";
					result.Statescode = 200;
					result.Data = vehicleWeeklyChecklistResponse;

					return result;
				}
			}

			result.Statescode = 404;
			result.Message = "data not found";
			return result;
		}


		//	[HttpGet("GetDataByDate/{date:DateTime}")]
		//	public ActionResult<ResultDTO> GetAllWithDataByDate(DateTime date, string UserId, string UserRole)
		//	{
		//		ResultDTO result = new ResultDTO();

		//		try
		//		{
		//			if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
		//			{
		//				List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall().Where(a => a.DateRaisedBy == date).ToList();
		//				List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
		//				foreach (WeeklyClinic weeklyClinic in temp)
		//				{
		//					WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
		//					weeklyClinicDTO.Id = weeklyClinic.Id;
		//					//weeklyClinicDTO.Rig = weeklyClinic.Rig.Number;
		//					weeklyClinicDTO.Title = weeklyClinic.Title;
		//					weeklyClinicDTO.FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName;
		//					weeklyClinicDTO.ReportNo = weeklyClinic.ReportNo;
		//					weeklyClinicDTO.DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity;
		//					weeklyClinicDTO.Standard = weeklyClinic.Standard.StandardName;
		//					weeklyClinicDTO.ClauseNo = weeklyClinic.ClauseNo;
		//					weeklyClinicDTO.ObjectiveEvidence = weeklyClinic.ObjectiveEvidence;
		//					foreach (var item in weeklyClinic.weeklyClinicAndObservation)
		//					{
		//						string observation = item.weeklyClinicObservation.Observation;
		//						weeklyClinicDTO.weeklyClinicAndObservation.Add(observation);

		//					}
		//					foreach (var item in weeklyClinic.weeklyClinicAndRootCauses)
		//					{
		//						string cause = item.RootCauses.CauseName;
		//						weeklyClinicDTO.weeklyClinicAndRootCauses.Add(cause);

		//					}
		//					weeklyClinicDTO.IfOtherObservation = weeklyClinic.IfOtherObservation;
		//					weeklyClinicDTO.UpdateRisk = weeklyClinic.UpdateRisk;
		//					weeklyClinicDTO.IfUpdate = weeklyClinic.IfUpdate;
		//					weeklyClinicDTO.ManagementOfChange = weeklyClinic.ManagementOfChange;
		//					weeklyClinicDTO.IfManagementOfChange = weeklyClinic.IfManagementOfChange;
		//					weeklyClinicDTO.NameRasiedBy = weeklyClinic.NameRasiedBy;
		//					//weeklyClinicDTO.SigRasiedBy = weeklyClinic.SigRasiedBy;
		//					weeklyClinicDTO.DateRaisedBy = weeklyClinic.DateRaisedBy;
		//					weeklyClinicDTO.IfOtherRootCause = weeklyClinic.IfOtherRootCause;
		//					foreach (var item in weeklyClinic.weeklyClinicDataTable)
		//					{
		//						weeklyClinicDataTable Data = new weeklyClinicDataTable();
		//						Data.Id = item.Id;
		//						Data.SN = item.SN;
		//						Data.WeeklyClinicSelected = item.WeeklyClinicSelected;
		//						Data.Action = item.Action;
		//						Data.Responsible = item.Responsible;
		//						Data.SuggestedDate = item.SuggestedDate;
		//						Data.AchievementDate = item.AchievementDate;
		//						Data.Status = item.Status;
		//						Data.WeeklyClinicId = item.WeeklyClinicId;
		//						Data.FollowUpAudit = item.FollowUpAudit;
		//						Data.IsDeleted = item.IsDeleted;
		//						weeklyClinicDTO.weeklyClinicDataTable.Add(Data);
		//					};
		//					weeklyClinicDTO.Comment = weeklyClinic.Comment;
		//					weeklyClinicDTO.Q_ManagerSig = weeklyClinic.Q_ManagerSig;
		//					//weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
		//					weeklyClinicDTO.userName = weeklyClinic.user.UserName;
		//					weeklyClinicDTO.FormStatus = weeklyClinic.FormStatus;
		//					List<weeklyClinicImages> weeklyClinicImages = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).ToList();
		//					foreach (var item in weeklyClinicImages)
		//					{
		//						string FileName = item.FileName;
		//						weeklyClinicDTO.Images.Add(FileName);

		//					}
		//					newTemp.Add(weeklyClinicDTO);
		//					//result.Data = prod;
		//				}
		//				if (newTemp != null)
		//				{
		//					result.Message = "Success";
		//					result.Statescode = 200;
		//					result.Data = newTemp;

		//					return result;
		//				}
		//			}
		//			else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
		//			{
		//				List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall().Where(a => a.userID == UserId && a.DateRaisedBy == date).ToList();
		//				List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
		//				foreach (WeeklyClinic weeklyClinic in temp)
		//				{
		//					WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
		//					weeklyClinicDTO.Id = weeklyClinic.Id;
		//					//weeklyClinicDTO.Rig = weeklyClinic.Rig.Number;
		//					weeklyClinicDTO.Title = weeklyClinic.Title;
		//					weeklyClinicDTO.FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName;
		//					weeklyClinicDTO.ReportNo = weeklyClinic.ReportNo;
		//					weeklyClinicDTO.DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity;
		//					weeklyClinicDTO.Standard = weeklyClinic.Standard.StandardName;
		//					weeklyClinicDTO.ClauseNo = weeklyClinic.ClauseNo;
		//					weeklyClinicDTO.ObjectiveEvidence = weeklyClinic.ObjectiveEvidence;
		//					foreach (var item in weeklyClinic.weeklyClinicAndObservation)
		//					{
		//						string observation = item.weeklyClinicObservation.Observation;
		//						weeklyClinicDTO.weeklyClinicAndObservation.Add(observation);

		//					}
		//					foreach (var item in weeklyClinic.weeklyClinicAndRootCauses)
		//					{
		//						string cause = item.RootCauses.CauseName;
		//						weeklyClinicDTO.weeklyClinicAndRootCauses.Add(cause);

		//					}
		//					weeklyClinicDTO.IfOtherObservation = weeklyClinic.IfOtherObservation;
		//					weeklyClinicDTO.UpdateRisk = weeklyClinic.UpdateRisk;
		//					weeklyClinicDTO.IfUpdate = weeklyClinic.IfUpdate;
		//					weeklyClinicDTO.ManagementOfChange = weeklyClinic.ManagementOfChange;
		//					weeklyClinicDTO.IfManagementOfChange = weeklyClinic.IfManagementOfChange;
		//					weeklyClinicDTO.NameRasiedBy = weeklyClinic.NameRasiedBy;
		//					//weeklyClinicDTO.SigRasiedBy = weeklyClinic.SigRasiedBy;
		//					weeklyClinicDTO.DateRaisedBy = weeklyClinic.DateRaisedBy;
		//					weeklyClinicDTO.IfOtherRootCause = weeklyClinic.IfOtherRootCause;
		//					foreach (var item in weeklyClinic.weeklyClinicDataTable)
		//					{
		//						weeklyClinicDataTable Data = new weeklyClinicDataTable();
		//						Data.Id = item.Id;
		//						Data.SN = item.SN;
		//						Data.WeeklyClinicSelected = item.WeeklyClinicSelected;
		//						Data.Action = item.Action;
		//						Data.Responsible = item.Responsible;
		//						Data.SuggestedDate = item.SuggestedDate;
		//						Data.AchievementDate = item.AchievementDate;
		//						Data.Status = item.Status;
		//						Data.WeeklyClinicId = item.WeeklyClinicId;
		//						Data.FollowUpAudit = item.FollowUpAudit;
		//						Data.IsDeleted = item.IsDeleted;
		//						weeklyClinicDTO.weeklyClinicDataTable.Add(Data);
		//					};
		//					weeklyClinicDTO.Comment = weeklyClinic.Comment;
		//					weeklyClinicDTO.Q_ManagerSig = weeklyClinic.Q_ManagerSig;
		//					//weeklyClinicDTO.QHSEEngineer = weeklyClinic.QHSEEngineer;
		//					weeklyClinicDTO.userName = weeklyClinic.user.UserName;
		//					weeklyClinicDTO.FormStatus = weeklyClinic.FormStatus;
		//					List<weeklyClinicImages> weeklyClinicImages = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).ToList();
		//					foreach (var item in weeklyClinicImages)
		//					{
		//						string FileName = item.FileName;
		//						weeklyClinicDTO.Images.Add(FileName);

		//					}
		//					newTemp.Add(weeklyClinicDTO);
		//					//result.Data = prod;
		//				}
		//				if (newTemp != null)
		//				{
		//					result.Message = "Success";
		//					result.Statescode = 200;
		//					result.Data = newTemp;

		//					return result;
		//				}
		//			}
		//		}
		//		catch (Exception ex)
		//		{
		//			result.Statescode = 404;
		//			result.Message = "data not found";
		//		}

		//		return result;

		//	}

		//	[HttpGet("GetDataByDateForAnalysis")]
		//	public ActionResult<ResultDTO> GetAllWithDataByDateForAnalysis(string UserId, string UserRole)
		//	{
		//		ResultDTO result = new ResultDTO();

		//		try
		//		{
		//			if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
		//			{
		//				var WeeklyClinics = WeeklyClinicRepoistory.getall()
		//				.Where(item => item.weeklyClinicDataTable.Any(obs => obs.SuggestedDate.Value.Date < DateTime.Now.Date))
		//				.ToList();

		//				if (WeeklyClinics.Any())
		//				{
		//					var newTemp = WeeklyClinics.Select(weeklyClinic =>
		//					{
		//						var weeklyClinicDTO = new WeeklyClinicResponseDTO
		//						{
		//							Id = weeklyClinic.Id,
		//							//Rig = weeklyClinic.Rig.Number,
		//							Title = weeklyClinic.Title,
		//							FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName,
		//							ReportNo = weeklyClinic.ReportNo,
		//							DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity,
		//							Standard = weeklyClinic.Standard.StandardName,
		//							ClauseNo = weeklyClinic.ClauseNo,
		//							ObjectiveEvidence = weeklyClinic.ObjectiveEvidence,
		//							weeklyClinicAndObservation = weeklyClinic.weeklyClinicAndObservation.Select(item => item.weeklyClinicObservation.Observation).ToList(),
		//							weeklyClinicAndRootCauses = weeklyClinic.weeklyClinicAndRootCauses.Select(item => item.RootCauses.CauseName).ToList(),
		//							IfOtherObservation = weeklyClinic.IfOtherObservation,
		//							UpdateRisk = weeklyClinic.UpdateRisk,
		//							IfUpdate = weeklyClinic.IfUpdate,
		//							ManagementOfChange = weeklyClinic.ManagementOfChange,
		//							IfManagementOfChange = weeklyClinic.IfManagementOfChange,
		//							NameRasiedBy = weeklyClinic.NameRasiedBy,
		//							DateRaisedBy = weeklyClinic.DateRaisedBy,
		//							IfOtherRootCause = weeklyClinic.IfOtherRootCause,
		//							weeklyClinicDataTable = weeklyClinic.weeklyClinicDataTable.Select(item => new weeklyClinicDataTable
		//							{
		//								Id = item.Id,
		//								SN = item.SN,
		//								WeeklyClinicSelected = item.WeeklyClinicSelected,
		//								Action = item.Action,
		//								Responsible = item.Responsible,
		//								SuggestedDate = item.SuggestedDate,
		//								AchievementDate = item.AchievementDate,
		//								Status = item.Status,
		//								WeeklyClinicId = item.WeeklyClinicId,
		//								FollowUpAudit = item.FollowUpAudit,
		//								IsDeleted = item.IsDeleted
		//							}).ToList(),
		//							Comment = weeklyClinic.Comment,
		//							Q_ManagerSig = weeklyClinic.Q_ManagerSig,
		//							//QHSEEngineer = weeklyClinic.QHSEEngineer,
		//							userName = weeklyClinic.user.UserName,
		//							FormStatus = weeklyClinic.FormStatus,
		//							Images = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).Select(item => item.FileName).ToList()
		//						};

		//						return weeklyClinicDTO;
		//					}).ToList();

		//					result.Message = "Success";
		//					result.Statescode = 200;
		//					result.Data = newTemp;

		//					return result;
		//				}
		//				else
		//				{
		//					result.Message = "No Data";
		//					result.Statescode = 201;
		//					result.Data = new List<WeeklyClinicDTO>();

		//					return result;
		//				}

		//				//List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall();
		//				//List<WeeklyClinic> WeeklyClinics = new List<WeeklyClinic>();
		//				//foreach(var item in temp)
		//				//{
		//				//	if (item.weeklyClinicDataTable.Count() > 0)
		//				//	{
		//				//		if(item.weeklyClinicDataTable.Any(obs => obs.SuggestedDate.Value.Date < DateTime.Now.Date))
		//				//		{
		//				//			WeeklyClinics.Add(item);
		//				//		}
		//				//	}
		//				//}

		//				//if (WeeklyClinics.Count() > 0)
		//				//{
		//				//	List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
		//				//	foreach (WeeklyClinic weeklyClinic in WeeklyClinics)
		//				//	{
		//				//		WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
		//				//		weeklyClinicDTO.Id = weeklyClinic.Id;
		//				//		weeklyClinicDTO.Rig = weeklyClinic.Rig.Number;
		//				//		weeklyClinicDTO.Title = weeklyClinic.Title;
		//				//		weeklyClinicDTO.FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName;
		//				//		weeklyClinicDTO.ReportNo = weeklyClinic.ReportNo;
		//				//		weeklyClinicDTO.DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity;
		//				//		weeklyClinicDTO.Standard = weeklyClinic.Standard.StandardName;
		//				//		weeklyClinicDTO.ClauseNo = weeklyClinic.ClauseNo;
		//				//		weeklyClinicDTO.ObjectiveEvidence = weeklyClinic.ObjectiveEvidence;
		//				//		foreach (var item in weeklyClinic.weeklyClinicAndObservation)
		//				//		{
		//				//			string observation = item.weeklyClinicObservation.Observation;
		//				//			weeklyClinicDTO.weeklyClinicAndObservation.Add(observation);

		//				//		}
		//				//		foreach (var item in weeklyClinic.weeklyClinicAndRootCauses)
		//				//		{
		//				//			string cause = item.RootCauses.CauseName;
		//				//			weeklyClinicDTO.weeklyClinicAndRootCauses.Add(cause);

		//				//		}
		//				//		weeklyClinicDTO.IfOtherObservation = weeklyClinic.IfOtherObservation;
		//				//		weeklyClinicDTO.UpdateRisk = weeklyClinic.UpdateRisk;
		//				//		weeklyClinicDTO.IfUpdate = weeklyClinic.IfUpdate;
		//				//		weeklyClinicDTO.ManagementOfChange = weeklyClinic.ManagementOfChange;
		//				//		weeklyClinicDTO.IfManagementOfChange = weeklyClinic.IfManagementOfChange;
		//				//		weeklyClinicDTO.NameRasiedBy = weeklyClinic.NameRasiedBy;
		//				//		//weeklyClinicDTO.SigRasiedBy = weeklyClinic.SigRasiedBy;
		//				//		weeklyClinicDTO.DateRaisedBy = weeklyClinic.DateRaisedBy;
		//				//		weeklyClinicDTO.IfOtherRootCause = weeklyClinic.IfOtherRootCause;
		//				//		foreach (var item in weeklyClinic.weeklyClinicDataTable)
		//				//		{
		//				//			weeklyClinicDataTable Data = new weeklyClinicDataTable();
		//				//			Data.Id = item.Id;
		//				//			Data.SN = item.SN;
		//				//			Data.WeeklyClinicSelected = item.WeeklyClinicSelected;
		//				//			Data.Action = item.Action;
		//				//			Data.Responsible = item.Responsible;
		//				//			Data.SuggestedDate = item.SuggestedDate;
		//				//			Data.AchievementDate = item.AchievementDate;
		//				//			Data.Status = item.Status;
		//				//			Data.WeeklyClinicId = item.WeeklyClinicId;
		//				//			Data.FollowUpAudit = item.FollowUpAudit;
		//				//			Data.IsDeleted = item.IsDeleted;
		//				//			weeklyClinicDTO.weeklyClinicDataTable.Add(Data);
		//				//		};
		//				//		weeklyClinicDTO.Comment = weeklyClinic.Comment;
		//				//		weeklyClinicDTO.Q_ManagerSig = weeklyClinic.Q_ManagerSig;
		//				//		weeklyClinicDTO.userName = weeklyClinic.user.UserName;
		//				//		weeklyClinicDTO.FormStatus = weeklyClinic.FormStatus;
		//				//		List<weeklyClinicImages> weeklyClinicImages = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).ToList();
		//				//		foreach (var item in weeklyClinicImages)
		//				//		{
		//				//			string FileName = item.FileName;
		//				//			weeklyClinicDTO.Images.Add(FileName);

		//				//		}
		//				//		newTemp.Add(weeklyClinicDTO);
		//				//		//result.Data = prod;
		//				//	}
		//				//	if (newTemp != null)
		//				//	{
		//				//		result.Message = "Success";
		//				//		result.Statescode = 200;
		//				//		result.Data = newTemp;

		//				//		return result;
		//				//	}
		//			}

		//			else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
		//			{
		//				var WeeklyClinics = WeeklyClinicRepoistory.getall()
		//				.Where(item => item.userID == UserId && item.weeklyClinicDataTable.Any(obs => obs.SuggestedDate.Value.Date < DateTime.Now.Date))
		//				.ToList();

		//				if (WeeklyClinics.Any())
		//				{
		//					var newTemp = WeeklyClinics.Select(weeklyClinic =>
		//					{
		//						var weeklyClinicDTO = new WeeklyClinicResponseDTO
		//						{
		//							Id = weeklyClinic.Id,
		//							//Rig = weeklyClinic.Rig.Number,
		//							Title = weeklyClinic.Title,
		//							FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName,
		//							ReportNo = weeklyClinic.ReportNo,
		//							DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity,
		//							Standard = weeklyClinic.Standard.StandardName,
		//							ClauseNo = weeklyClinic.ClauseNo,
		//							ObjectiveEvidence = weeklyClinic.ObjectiveEvidence,
		//							weeklyClinicAndObservation = weeklyClinic.weeklyClinicAndObservation.Select(item => item.weeklyClinicObservation.Observation).ToList(),
		//							weeklyClinicAndRootCauses = weeklyClinic.weeklyClinicAndRootCauses.Select(item => item.RootCauses.CauseName).ToList(),
		//							IfOtherObservation = weeklyClinic.IfOtherObservation,
		//							UpdateRisk = weeklyClinic.UpdateRisk,
		//							IfUpdate = weeklyClinic.IfUpdate,
		//							ManagementOfChange = weeklyClinic.ManagementOfChange,
		//							IfManagementOfChange = weeklyClinic.IfManagementOfChange,
		//							NameRasiedBy = weeklyClinic.NameRasiedBy,
		//							DateRaisedBy = weeklyClinic.DateRaisedBy,
		//							IfOtherRootCause = weeklyClinic.IfOtherRootCause,
		//							weeklyClinicDataTable = weeklyClinic.weeklyClinicDataTable.Select(item => new weeklyClinicDataTable
		//							{
		//								Id = item.Id,
		//								SN = item.SN,
		//								WeeklyClinicSelected = item.WeeklyClinicSelected,
		//								Action = item.Action,
		//								Responsible = item.Responsible,
		//								SuggestedDate = item.SuggestedDate,
		//								AchievementDate = item.AchievementDate,
		//								Status = item.Status,
		//								WeeklyClinicId = item.WeeklyClinicId,
		//								FollowUpAudit = item.FollowUpAudit,
		//								IsDeleted = item.IsDeleted
		//							}).ToList(),
		//							Comment = weeklyClinic.Comment,
		//							Q_ManagerSig = weeklyClinic.Q_ManagerSig,
		//							//QHSEEngineer = weeklyClinic.QHSEEngineer,
		//							userName = weeklyClinic.user.UserName,
		//							FormStatus = weeklyClinic.FormStatus,
		//							Images = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).Select(item => item.FileName).ToList()
		//						};

		//						return weeklyClinicDTO;
		//					}).ToList();

		//					result.Message = "Success";
		//					result.Statescode = 200;
		//					result.Data = newTemp;

		//					return result;
		//					//List<WeeklyClinic> temp = WeeklyClinicRepoistory.getall().Where(a => a.userID == UserId && a.DateRaisedBy == date).ToList();
		//					//List<WeeklyClinicResponseDTO> newTemp = new List<WeeklyClinicResponseDTO>();
		//					//foreach (WeeklyClinic weeklyClinic in temp)
		//					//{
		//					//	WeeklyClinicResponseDTO weeklyClinicDTO = new WeeklyClinicResponseDTO();
		//					//	weeklyClinicDTO.Id = weeklyClinic.Id;
		//					//	weeklyClinicDTO.Rig = weeklyClinic.Rig.Number;
		//					//	weeklyClinicDTO.Title = weeklyClinic.Title;
		//					//	weeklyClinicDTO.FormResponsability = weeklyClinic.weeklyClinicResponsability.ResponsibilityName;
		//					//	weeklyClinicDTO.ReportNo = weeklyClinic.ReportNo;
		//					//	weeklyClinicDTO.DescriptionOfNonConformity = weeklyClinic.DescriptionOfNonConformity;
		//					//	weeklyClinicDTO.Standard = weeklyClinic.Standard.StandardName;
		//					//	weeklyClinicDTO.ClauseNo = weeklyClinic.ClauseNo;
		//					//	weeklyClinicDTO.ObjectiveEvidence = weeklyClinic.ObjectiveEvidence;
		//					//	foreach (var item in weeklyClinic.weeklyClinicAndObservation)
		//					//	{
		//					//		string observation = item.weeklyClinicObservation.Observation;
		//					//		weeklyClinicDTO.weeklyClinicAndObservation.Add(observation);

		//					//	}
		//					//	foreach (var item in weeklyClinic.weeklyClinicAndRootCauses)
		//					//	{
		//					//		string cause = item.RootCauses.CauseName;
		//					//		weeklyClinicDTO.weeklyClinicAndRootCauses.Add(cause);

		//					//	}
		//					//	weeklyClinicDTO.IfOtherObservation = weeklyClinic.IfOtherObservation;
		//					//	weeklyClinicDTO.UpdateRisk = weeklyClinic.UpdateRisk;
		//					//	weeklyClinicDTO.IfUpdate = weeklyClinic.IfUpdate;
		//					//	weeklyClinicDTO.ManagementOfChange = weeklyClinic.ManagementOfChange;
		//					//	weeklyClinicDTO.IfManagementOfChange = weeklyClinic.IfManagementOfChange;
		//					//	weeklyClinicDTO.NameRasiedBy = weeklyClinic.NameRasiedBy;
		//					//	//weeklyClinicDTO.SigRasiedBy = weeklyClinic.SigRasiedBy;
		//					//	weeklyClinicDTO.DateRaisedBy = weeklyClinic.DateRaisedBy;
		//					//	weeklyClinicDTO.IfOtherRootCause = weeklyClinic.IfOtherRootCause;
		//					//	foreach (var item in weeklyClinic.weeklyClinicDataTable)
		//					//	{
		//					//		weeklyClinicDataTable Data = new weeklyClinicDataTable();
		//					//		Data.Id = item.Id;
		//					//		Data.SN = item.SN;
		//					//		Data.WeeklyClinicSelected = item.WeeklyClinicSelected;
		//					//		Data.Action = item.Action;
		//					//		Data.Responsible = item.Responsible;
		//					//		Data.SuggestedDate = item.SuggestedDate;
		//					//		Data.AchievementDate = item.AchievementDate;
		//					//		Data.Status = item.Status;
		//					//		Data.WeeklyClinicId = item.WeeklyClinicId;
		//					//		Data.FollowUpAudit = item.FollowUpAudit;
		//					//		Data.IsDeleted = item.IsDeleted;
		//					//		weeklyClinicDTO.weeklyClinicDataTable.Add(Data);
		//					//	};
		//					//	weeklyClinicDTO.Comment = weeklyClinic.Comment;
		//					//	weeklyClinicDTO.Q_ManagerSig = weeklyClinic.Q_ManagerSig;
		//					//	weeklyClinicDTO.userName = weeklyClinic.user.UserName;
		//					//	weeklyClinicDTO.FormStatus = weeklyClinic.FormStatus;
		//					//	List<weeklyClinicImages> weeklyClinicImages = weeklyClinicImagesRepo.getall().Where(p => p.WeeklyClinicId == weeklyClinic.Id).ToList();
		//					//	foreach (var item in weeklyClinicImages)
		//					//	{
		//					//		string FileName = item.FileName;
		//					//		weeklyClinicDTO.Images.Add(FileName);

		//					//	}
		//					//	newTemp.Add(weeklyClinicDTO);
		//					//	//result.Data = prod;
		//					//}
		//					//if (newTemp != null)
		//					//{
		//					//	result.Message = "Success";
		//					//	result.Statescode = 200;
		//					//	result.Data = newTemp;

		//					//	return result;
		//					//}
		//				}
		//				else
		//				{
		//					result.Message = "No Data";
		//					result.Statescode = 201;
		//					result.Data = new List<WeeklyClinicDTO>();

		//					return result;
		//				}
		//			}
		//		}
		//		catch (Exception ex)
		//		{
		//			result.Statescode = 404;
		//			result.Message = "data not found";
		//		}

		//		return result;

		//	}


		[HttpGet("{ID:int}")]
		public ActionResult<ResultDTO> GetByID(int ID, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
                    VehicleWeeklyChecklist vehicleWeeklyChecklistResponse = VehicleWeeklyChecklistRepoistory.getall().FirstOrDefault(a => a.Id == ID);
					VehicleWeeklyChecklistDTO vehicleWeeklyChecklist = new VehicleWeeklyChecklistDTO();
                    vehicleWeeklyChecklistResponse.Id = vehicleWeeklyChecklist.Id;
                    vehicleWeeklyChecklistResponse.RigId = vehicleWeeklyChecklist.RigId;
                    vehicleWeeklyChecklistResponse.Date = vehicleWeeklyChecklist.Date;
                    vehicleWeeklyChecklistResponse.LightBusDriverName = vehicleWeeklyChecklist.LightBusDriverName;
                    vehicleWeeklyChecklistResponse.LightBusVehiclePlateNo = vehicleWeeklyChecklist.LightBusVehiclePlateNo;
                    vehicleWeeklyChecklistResponse.HeavyTruckDriverName = vehicleWeeklyChecklist.HeavyTruckDriverName;
                    vehicleWeeklyChecklistResponse.TrailerPlateNo = vehicleWeeklyChecklist.TrailerPlateNo;
                    vehicleWeeklyChecklistResponse.PrimeMoverPlateNo = vehicleWeeklyChecklist.PrimeMoverPlateNo;
                    vehicleWeeklyChecklistResponse.RigPickupDriverName = vehicleWeeklyChecklist.RigPickupDriverName;
                    vehicleWeeklyChecklistResponse.RigPickupVehiclePlateNo = vehicleWeeklyChecklist.RigPickupVehiclePlateNo;
                    vehicleWeeklyChecklistResponse.ManPickupDriverName = vehicleWeeklyChecklist.ManPickupDriverName;
                    vehicleWeeklyChecklistResponse.ManPickupVehiclePlateNo = vehicleWeeklyChecklist.ManPickupVehiclePlateNo;
                    vehicleWeeklyChecklistResponse.Location = vehicleWeeklyChecklist.Location;
					vehicleWeeklyChecklistResponse.Cient = vehicleWeeklyChecklist.Cient;
					vehicleWeeklyChecklistResponse.HSEEngineer = vehicleWeeklyChecklist.HSEEngineer;

					vehicleWeeklyChecklistResponse.userID = vehicleWeeklyChecklist.userID;
                    foreach (var item in vehicleWeeklyChecklist.LightBus)
                    {
                        LightBusDTO lightBusDTO = new LightBusDTO();
                        lightBusDTO.Id = item.Id;
                        lightBusDTO.Status = item.Status;
                        lightBusDTO.Remarks = item.Remarks;
                        lightBusDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                        lightBusDTO.IsDeleted = item.IsDeleted;
                        vehicleWeeklyChecklist.LightBus.Add(lightBusDTO);
                    }
                    foreach (var item in vehicleWeeklyChecklist.ManPickups)
                    {
                        ManPickupDTO manPickupDTO = new ManPickupDTO();
                        manPickupDTO.Id = item.Id;
                        manPickupDTO.Status = item.Status;
                        manPickupDTO.Remarks = item.Remarks;
                        manPickupDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                        manPickupDTO.IsDeleted = item.IsDeleted;
                        vehicleWeeklyChecklist.ManPickups.Add(manPickupDTO);
                    }
                    foreach (var item in vehicleWeeklyChecklist.HeavyTrucks)
                    {
                        HeavyTrucksDTO heavyTrucksDTO = new HeavyTrucksDTO();
                        heavyTrucksDTO.Id = item.Id;
                        heavyTrucksDTO.Status = item.Status;
                        heavyTrucksDTO.Remarks = item.Remarks;
                        heavyTrucksDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                        heavyTrucksDTO.IsDeleted = item.IsDeleted;
                        vehicleWeeklyChecklist.HeavyTrucks.Add(heavyTrucksDTO);
                    }
                    foreach (var item in vehicleWeeklyChecklist.RigPickups)
                    {
                        RigPickupDTO rigPickupDTO = new RigPickupDTO();
                        rigPickupDTO.Id = item.Id;
                        rigPickupDTO.Status = item.Status;
                        rigPickupDTO.Remarks = item.Remarks;
                        rigPickupDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                        rigPickupDTO.IsDeleted = item.IsDeleted;
                        vehicleWeeklyChecklist.RigPickups.Add(rigPickupDTO);
                    }

                    result.Message = "Success";
					result.Data = vehicleWeeklyChecklist;
					result.Statescode = 200;
					return result;

				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
                    VehicleWeeklyChecklist vehicleWeeklyChecklistResponse = VehicleWeeklyChecklistRepo.getall().FirstOrDefault(a => a.Id == ID && a.userID == UserId);
                    VehicleWeeklyChecklistDTO vehicleWeeklyChecklist = new VehicleWeeklyChecklistDTO();
                    vehicleWeeklyChecklistResponse.Id = default;
                    vehicleWeeklyChecklistResponse.RigId = vehicleWeeklyChecklist.RigId;
                    vehicleWeeklyChecklistResponse.Date = vehicleWeeklyChecklist.Date;
                    vehicleWeeklyChecklistResponse.LightBusDriverName = vehicleWeeklyChecklist.LightBusDriverName;
                    vehicleWeeklyChecklistResponse.LightBusVehiclePlateNo = vehicleWeeklyChecklist.LightBusVehiclePlateNo;
                    vehicleWeeklyChecklistResponse.HeavyTruckDriverName = vehicleWeeklyChecklist.HeavyTruckDriverName;
                    vehicleWeeklyChecklistResponse.TrailerPlateNo = vehicleWeeklyChecklist.TrailerPlateNo;
                    vehicleWeeklyChecklistResponse.PrimeMoverPlateNo = vehicleWeeklyChecklist.PrimeMoverPlateNo;
                    vehicleWeeklyChecklistResponse.RigPickupDriverName = vehicleWeeklyChecklist.RigPickupDriverName;
                    vehicleWeeklyChecklistResponse.RigPickupVehiclePlateNo = vehicleWeeklyChecklist.RigPickupVehiclePlateNo;
                    vehicleWeeklyChecklistResponse.ManPickupDriverName = vehicleWeeklyChecklist.ManPickupDriverName;
                    vehicleWeeklyChecklistResponse.ManPickupVehiclePlateNo = vehicleWeeklyChecklist.ManPickupVehiclePlateNo;
                    vehicleWeeklyChecklistResponse.Location = vehicleWeeklyChecklist.Location;
                    vehicleWeeklyChecklistResponse.Cient = vehicleWeeklyChecklist.Cient;
					vehicleWeeklyChecklistResponse.HSEEngineer = vehicleWeeklyChecklist.HSEEngineer;

					vehicleWeeklyChecklistResponse.userID = vehicleWeeklyChecklist.userID;
                    foreach (var item in vehicleWeeklyChecklist.LightBus)
                    {
                        LightBusDTO lightBusDTO = new LightBusDTO();
                        lightBusDTO.Id = item.Id;
                        lightBusDTO.Status = item.Status;
                        lightBusDTO.Remarks = item.Remarks;
                        lightBusDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                        lightBusDTO.IsDeleted = item.IsDeleted;
                        vehicleWeeklyChecklist.LightBus.Add(lightBusDTO);
                    }
                    foreach (var item in vehicleWeeklyChecklist.ManPickups)
                    {
                        ManPickupDTO manPickupDTO = new ManPickupDTO();
                        manPickupDTO.Id = item.Id;
                        manPickupDTO.Status = item.Status;
                        manPickupDTO.Remarks = item.Remarks;
                        manPickupDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                        manPickupDTO.IsDeleted = item.IsDeleted;
                        vehicleWeeklyChecklist.ManPickups.Add(manPickupDTO);
                    }
                    foreach (var item in vehicleWeeklyChecklist.HeavyTrucks)
                    {
                        HeavyTrucksDTO heavyTrucksDTO = new HeavyTrucksDTO();
                        heavyTrucksDTO.Id = item.Id;
                        heavyTrucksDTO.Status = item.Status;
                        heavyTrucksDTO.Remarks = item.Remarks;
                        heavyTrucksDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                        heavyTrucksDTO.IsDeleted = item.IsDeleted;
                        vehicleWeeklyChecklist.HeavyTrucks.Add(heavyTrucksDTO);
                    }
                    foreach (var item in vehicleWeeklyChecklist.RigPickups)
                    {
                        RigPickupDTO rigPickupDTO = new RigPickupDTO();
                        rigPickupDTO.Id = item.Id;
                        rigPickupDTO.Status = item.Status;
                        rigPickupDTO.Remarks = item.Remarks;
                        rigPickupDTO.VehicleWeeklyChecklistId = item.VehicleWeeklyChecklistId;
                        rigPickupDTO.IsDeleted = item.IsDeleted;
                        vehicleWeeklyChecklist.RigPickups.Add(rigPickupDTO);
                    }

                    result.Message = "Success";
					result.Data = vehicleWeeklyChecklist;
					result.Statescode = 200;
					return result;
				}
			}
			catch (Exception Ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}

			return result;
		}

		[HttpPost]
		public ActionResult<ResultDTO> AddVehicleWeeklyChecklist(VehicleWeeklyChecklistDTO VehicleWeeklyChecklistDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
                    VehicleWeeklyChecklist VehicleWeeklyChecklist = new VehicleWeeklyChecklist();
                    VehicleWeeklyChecklist.Id = default;
                    VehicleWeeklyChecklist.RigId = VehicleWeeklyChecklistDTO.RigId;
					VehicleWeeklyChecklist.Date = VehicleWeeklyChecklistDTO.Date;
                    VehicleWeeklyChecklist.LightBusDriverName = VehicleWeeklyChecklistDTO.LightBusDriverName;
                    VehicleWeeklyChecklist.LightBusVehiclePlateNo = VehicleWeeklyChecklistDTO.LightBusVehiclePlateNo;
                    VehicleWeeklyChecklist.HeavyTruckDriverName = VehicleWeeklyChecklistDTO.HeavyTruckDriverName;
                    VehicleWeeklyChecklist.TrailerPlateNo = VehicleWeeklyChecklistDTO.TrailerPlateNo;
                    VehicleWeeklyChecklist.PrimeMoverPlateNo = VehicleWeeklyChecklistDTO.PrimeMoverPlateNo;
                    VehicleWeeklyChecklist.RigPickupDriverName = VehicleWeeklyChecklistDTO.RigPickupDriverName;
                    VehicleWeeklyChecklist.RigPickupVehiclePlateNo = VehicleWeeklyChecklistDTO.RigPickupVehiclePlateNo;
                    VehicleWeeklyChecklist.ManPickupDriverName = VehicleWeeklyChecklistDTO.ManPickupDriverName;
                    VehicleWeeklyChecklist.ManPickupVehiclePlateNo = VehicleWeeklyChecklistDTO.ManPickupVehiclePlateNo;
                    VehicleWeeklyChecklist.Location = VehicleWeeklyChecklistDTO.Location;
                    VehicleWeeklyChecklist.Cient = VehicleWeeklyChecklistDTO.Cient;
					VehicleWeeklyChecklist.HSEEngineer = VehicleWeeklyChecklistDTO.HSEEngineer;
					VehicleWeeklyChecklist.userID = VehicleWeeklyChecklistDTO.userID;
					VehicleWeeklyChecklistRepo.create(VehicleWeeklyChecklist);

                    foreach (var item in VehicleWeeklyChecklistDTO.LightBus)
                    {
                        LightBus lightBus = new LightBus();
                        lightBus.Item = item.Item;
                        lightBus.Status = item.Status;
                        lightBus.Remarks = item.Remarks;
                        lightBus.VehicleWeeklyChecklistId = VehicleWeeklyChecklist.Id;
                        lightBus.IsDeleted = item.IsDeleted;
                        LightBusRepo.create(lightBus);
                    }
                    foreach (var item in VehicleWeeklyChecklistDTO.ManPickups)
                    {
                        ManPickup manPickup = new ManPickup();
                        manPickup.Item = item.Item;
                        manPickup.Status = item.Status;
                        manPickup.Remarks = item.Remarks;
                        manPickup.VehicleWeeklyChecklistId = VehicleWeeklyChecklist.Id;
                        manPickup.IsDeleted = item.IsDeleted;
                        ManPickupRepo.create(manPickup);
                    }
                    foreach (var item in VehicleWeeklyChecklistDTO.HeavyTrucks)
                    {
                        HeavyTruck heavyTrucks = new HeavyTruck();
                        heavyTrucks.Item = item.Item;
                        heavyTrucks.Status = item.Status;
                        heavyTrucks.Remarks = item.Remarks;
                        heavyTrucks.VehicleWeeklyChecklistId = VehicleWeeklyChecklist.Id;
                        heavyTrucks.IsDeleted = item.IsDeleted;
                        HeavyTruckRepo.create(heavyTrucks);
                    }
                    foreach (var item in VehicleWeeklyChecklistDTO.RigPickups)
                    {
                        RigPickup rigPickup = new RigPickup();
                        rigPickup.Item = item.Item;
                        rigPickup.Status = item.Status;
                        rigPickup.Remarks = item.Remarks;
                        rigPickup.VehicleWeeklyChecklistId = VehicleWeeklyChecklist.Id;
                        rigPickup.IsDeleted = item.IsDeleted;
                        RigPukupRepo.create(rigPickup);
                    }
			
					
					result.Message = "Success";
					result.Data = VehicleWeeklyChecklist;
					result.Statescode = 200;
				}
				catch (Exception ex)
				{
					result.Message = "Error in inserting";
					result.Statescode = 400;
				}
			}
			return result;
		}



		[HttpPut("{id:int}")]
		public ActionResult<ResultDTO> Put(int id, VehicleWeeklyChecklistDTO newVehicleWeeklyChecklist) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
                    VehicleWeeklyChecklist orgVehicleWeeklyChecklist = VehicleWeeklyChecklistRepo.getbyid(id);
                    orgVehicleWeeklyChecklist.RigId = newVehicleWeeklyChecklist.RigId;
                    orgVehicleWeeklyChecklist.Date = newVehicleWeeklyChecklist.Date;
                    orgVehicleWeeklyChecklist.LightBusDriverName = newVehicleWeeklyChecklist.LightBusDriverName;
                    orgVehicleWeeklyChecklist.LightBusVehiclePlateNo = newVehicleWeeklyChecklist.LightBusVehiclePlateNo;
                    orgVehicleWeeklyChecklist.HeavyTruckDriverName = newVehicleWeeklyChecklist.HeavyTruckDriverName;
                    orgVehicleWeeklyChecklist.TrailerPlateNo = newVehicleWeeklyChecklist.TrailerPlateNo;
                    orgVehicleWeeklyChecklist.PrimeMoverPlateNo = newVehicleWeeklyChecklist.PrimeMoverPlateNo;
                    orgVehicleWeeklyChecklist.RigPickupDriverName = newVehicleWeeklyChecklist.RigPickupDriverName;
                    orgVehicleWeeklyChecklist.RigPickupVehiclePlateNo = newVehicleWeeklyChecklist.RigPickupVehiclePlateNo;
                    orgVehicleWeeklyChecklist.ManPickupDriverName = newVehicleWeeklyChecklist.ManPickupDriverName;
                    orgVehicleWeeklyChecklist.ManPickupVehiclePlateNo = newVehicleWeeklyChecklist.ManPickupVehiclePlateNo;
                    orgVehicleWeeklyChecklist.Location = newVehicleWeeklyChecklist.Location;
                    orgVehicleWeeklyChecklist.Cient = newVehicleWeeklyChecklist.Cient;
					orgVehicleWeeklyChecklist.HSEEngineer = newVehicleWeeklyChecklist.HSEEngineer;
					//orgVehicleWeeklyChecklist.userID = newVehicleWeeklyChecklist.userID;
                    VehicleWeeklyChecklistRepo.update(orgVehicleWeeklyChecklist);

                    var oldlightBus = LightBusRepo.getall().Where(o => o.VehicleWeeklyChecklistId == id).ToList();
                    for (int i = 0; i < oldlightBus.Count(); i++)
                    {
                        var OldItem = oldlightBus[i];
                        var newItem = newVehicleWeeklyChecklist.LightBus[i];
                        //OldItem.Id = newItem.Id;
                        OldItem.Status = newItem.Status;
                        OldItem.Remarks = newItem.Remarks;
						OldItem.Item = newItem.Item;
                        OldItem.VehicleWeeklyChecklistId = id;
                        OldItem.IsDeleted = newItem.IsDeleted;
                        LightBusRepo.update(OldItem);
                    }
                   
                    var oldManPickup = ManPickupRepo.getall().Where(o => o.VehicleWeeklyChecklistId == id).ToList();
                    for (int i = 0; i < oldManPickup.Count(); i++)
                    {
                        var OldItem = oldManPickup[i];
                        var newItem = newVehicleWeeklyChecklist.ManPickups[i];
                       // OldItem.Id = newItem.Id;
                        OldItem.Status = newItem.Status;
                        OldItem.Item = newItem.Item;
                        OldItem.Remarks = newItem.Remarks;
                        OldItem.VehicleWeeklyChecklistId = id;
                        OldItem.IsDeleted = newItem.IsDeleted;
                        ManPickupRepo.update(OldItem);
                    }
                    var oldHeavyTruck = HeavyTruckRepo.getall().Where(o => o.VehicleWeeklyChecklistId == id).ToList();
                    for (int i = 0; i < oldHeavyTruck.Count(); i++)
                    {
                        var OldItem = oldHeavyTruck[i];
                        var newItem = newVehicleWeeklyChecklist.HeavyTrucks[i];
                        //OldItem.Id = newItem.Id;
                        OldItem.Status = newItem.Status;
                        OldItem.Item = newItem.Item;
                        OldItem.Remarks = newItem.Remarks;
                        OldItem.VehicleWeeklyChecklistId = id;
                        OldItem.IsDeleted = newItem.IsDeleted;
                        HeavyTruckRepo.update(OldItem);
                    }
                    var oldRigPickup = RigPukupRepo.getall().Where(o => o.VehicleWeeklyChecklistId == id).ToList();
                    for (int i = 0; i < oldRigPickup.Count(); i++)
                    {
                        var OldItem = oldRigPickup[i];
                        var newItem = newVehicleWeeklyChecklist.RigPickups[i];
                        //OldItem.Id = newItem.Id;
                        OldItem.Status = newItem.Status;
                        OldItem.Item = newItem.Item;
                        OldItem.Remarks = newItem.Remarks;
                        OldItem.VehicleWeeklyChecklistId = id;
                        OldItem.IsDeleted = newItem.IsDeleted;
                        RigPukupRepo.update(OldItem);
                    }

                   
					result.Data = orgVehicleWeeklyChecklist;
					result.Statescode = 200;
					return result;
				}
				catch (Exception ex)
				{
					result.Message = "Error in Updating";
					result.Statescode = 400;
					return result;
				}
			}
			return BadRequest(ModelState);
		}

		[HttpPut("Delete/{id:int}")]
		public ActionResult<ResultDTO> Delete(int id) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();
			try
			{
                VehicleWeeklyChecklist VehicleWeeklyChecklist = VehicleWeeklyChecklistRepo.getbyid(id);
                VehicleWeeklyChecklist.IsDeleted = true;
                VehicleWeeklyChecklistRepo.update(VehicleWeeklyChecklist);

				result.Data = VehicleWeeklyChecklist;
				result.Statescode = 200;
				result.Message = "Success";
			}
			catch (Exception ex)
			{
				result.Message = "Error in deleted";
				result.Statescode = 400;
			}

			return result;
		}
	}
}
