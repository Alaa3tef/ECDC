using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PowerSystemController : ControllerBase
	{
		public IRepository<PowerSystem> PowerSystemRepo { get; set; }

		public PowerSystemController(IRepository<PowerSystem> _PowerSystemRepo)
		{
			this.PowerSystemRepo = _PowerSystemRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<PowerSystem> temp = PowerSystemRepo.getall();
			List<PowerSystemDTO> newTemp = new List<PowerSystemDTO>();
			foreach (PowerSystem PowerSystem in temp)
			{
				PowerSystemDTO PowerSystemDTO = new PowerSystemDTO();
				PowerSystemDTO.Id = PowerSystem.Id;
				PowerSystemDTO.Equipment = PowerSystem.Equipment;
				PowerSystemDTO.SerialNumber = PowerSystem.SerialNumber;
				PowerSystemDTO.COCAvailabilty = PowerSystem.COCAvailabilty;
				PowerSystemDTO.CATIIICertificationDate = PowerSystem.CATIIICertificationDate;
				PowerSystemDTO.CATIIIExpiryDate = PowerSystem.CATIIIExpiryDate;
				PowerSystemDTO.CATIVCertificationDate = PowerSystem.CATIVCertificationDate;
				PowerSystemDTO.CATIVExpiryDate = PowerSystem.CATIVExpiryDate;
				PowerSystemDTO.RigCertificatesId = PowerSystem.RigCertificatesId;
				PowerSystemDTO.IsDeleted = PowerSystem.IsDeleted;

				newTemp.Add(PowerSystemDTO);
			}
			if (newTemp != null)
			{

				result.Statescode = 200;
				result.Data = newTemp;
				result.Message = "Success";

				return result;
			}

			result.Statescode = 404;
			result.Message = "data not found";
			return result;

		}

		//[HttpGet("GetAllForExcel")]
		//public ActionResult<ResultDTO> GetAllForExcel()
		//{

		//	ResultDTO result = new ResultDTO();

		//	List<PowerSystem> temp = PowerSystemRepo.getall();
		//	List<PowerSystemExcelDTO> newTemp = new List<PowerSystemExcelDTO>();
		//	foreach (PowerSystem PowerSystem in temp)
		//	{
		//		PowerSystemExcelDTO PowerSystemDTO = new PowerSystemExcelDTO();
		//		PowerSystemDTO.Id = PowerSystem.Id;
		//		PowerSystemDTO.Name = PowerSystem.Name;

		//		newTemp.Add(PowerSystemDTO);
		//	}
		//	if (newTemp != null)
		//	{

		//		result.Statescode = 200;
		//		result.Data = newTemp;
		//		result.Message = "Success";

		//		return result;
		//	}

		//	result.Statescode = 404;
		//	result.Message = "data not found";
		//	return result;

		//}

		[HttpGet("ByPage/{page:int}")]
		public PageResult<PowerSystemDTO> GettAllPowerSystemByPage(int? page, int pagesize = 10)
		{
			List<PowerSystem> temp = PowerSystemRepo.getall();
			List<PowerSystemDTO> newTemp = new List<PowerSystemDTO>();
			foreach (PowerSystem PowerSystem in temp)
			{
				PowerSystemDTO PowerSystemDTO = new PowerSystemDTO();
				PowerSystemDTO.Id = PowerSystem.Id;
				PowerSystemDTO.Equipment = PowerSystem.Equipment;
				PowerSystemDTO.SerialNumber = PowerSystem.SerialNumber;
				PowerSystemDTO.COCAvailabilty = PowerSystem.COCAvailabilty;
				PowerSystemDTO.CATIIICertificationDate = PowerSystem.CATIIICertificationDate;
				PowerSystemDTO.CATIIIExpiryDate = PowerSystem.CATIIIExpiryDate;
				PowerSystemDTO.CATIVCertificationDate = PowerSystem.CATIVCertificationDate;
				PowerSystemDTO.CATIVExpiryDate = PowerSystem.CATIVExpiryDate;
				PowerSystemDTO.RigCertificatesId = PowerSystem.RigCertificatesId;
				PowerSystemDTO.IsDeleted = PowerSystem.IsDeleted;

				newTemp.Add(PowerSystemDTO);
			}

			float countDetails = PowerSystemRepo.getall().Count();
			var result = new PageResult<PowerSystemDTO>
			{
				Count = (int)Math.Ceiling(countDetails / pagesize),
				PageIndex = page ?? 1,
				PageSize = pagesize,
				Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
			};
			return result;
		}

		[HttpGet("{ID:int}")]
		public ActionResult<ResultDTO> GetByID(int ID)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				PowerSystemDTO PowerSystemDTO = new PowerSystemDTO();
				PowerSystem PowerSystem = PowerSystemRepo.getbyid(ID);
				PowerSystemDTO.Id = PowerSystem.Id;
				PowerSystemDTO.Equipment = PowerSystem.Equipment;
				PowerSystemDTO.SerialNumber = PowerSystem.SerialNumber;
				PowerSystemDTO.COCAvailabilty = PowerSystem.COCAvailabilty;
				PowerSystemDTO.CATIIICertificationDate = PowerSystem.CATIIICertificationDate;
				PowerSystemDTO.CATIIIExpiryDate = PowerSystem.CATIIIExpiryDate;
				PowerSystemDTO.CATIVCertificationDate = PowerSystem.CATIVCertificationDate;
				PowerSystemDTO.CATIVExpiryDate = PowerSystem.CATIVExpiryDate;
				PowerSystemDTO.RigCertificatesId = PowerSystem.RigCertificatesId;
				PowerSystemDTO.IsDeleted = PowerSystem.IsDeleted;

				result.Message = "Success";
				result.Data = PowerSystemDTO;
				result.Statescode = 200;
				return result;
			}
			catch (Exception ex)
			{
				result.Message = "Error Not Find";
				result.Statescode = 404;
				return result;
			}
		}

		[HttpPut("{id:int}")]
		public ActionResult<ResultDTO> Put(int id, PowerSystemDTO newPowerSystem) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					PowerSystem orgPowerSystem = PowerSystemRepo.getbyid(id);
					newPowerSystem.Id = orgPowerSystem.Id;
					orgPowerSystem.Equipment = newPowerSystem.Equipment;
					orgPowerSystem.SerialNumber = newPowerSystem.SerialNumber;
					orgPowerSystem.COCAvailabilty = newPowerSystem.COCAvailabilty;
					orgPowerSystem.CATIIICertificationDate = newPowerSystem.CATIIICertificationDate;
					orgPowerSystem.CATIIIExpiryDate = newPowerSystem.CATIIIExpiryDate;
					orgPowerSystem.CATIVCertificationDate = newPowerSystem.CATIVCertificationDate;
					orgPowerSystem.CATIVExpiryDate = newPowerSystem.CATIVExpiryDate;
					orgPowerSystem.RigCertificatesId = newPowerSystem.RigCertificatesId;
					orgPowerSystem.IsDeleted = newPowerSystem.IsDeleted;


					PowerSystemRepo.update(orgPowerSystem);
					result.Message = "Success";
					result.Data = orgPowerSystem;
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

		[HttpPost]
		public ActionResult<ResultDTO> AddPowerSystem(PowerSystemDTO PowerSystemDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					PowerSystem PowerSystem = new PowerSystem();
					PowerSystem.Id = PowerSystemDTO.Id;
					PowerSystem.Equipment = PowerSystemDTO.Equipment;
					PowerSystem.SerialNumber = PowerSystemDTO.SerialNumber;
					PowerSystem.COCAvailabilty = PowerSystemDTO.COCAvailabilty;
					PowerSystem.CATIIICertificationDate = PowerSystemDTO.CATIIICertificationDate;
					PowerSystem.CATIIIExpiryDate = PowerSystemDTO.CATIIIExpiryDate;
					PowerSystem.CATIVCertificationDate = PowerSystemDTO.CATIVCertificationDate;
					PowerSystem.CATIVExpiryDate = PowerSystemDTO.CATIVExpiryDate;
					PowerSystem.RigCertificatesId = PowerSystemDTO.RigCertificatesId;
					PowerSystem.IsDeleted = PowerSystemDTO.IsDeleted;

					PowerSystemRepo.create(PowerSystem);
					result.Data = PowerSystemDTO;
					result.Statescode = 200;
					result.Message = "Success";

				}
				catch (Exception ex)
				{
					result.Message = "Error in inserting";
					result.Statescode = 400;
				}
			}
			return result;



		}

		[HttpPut("Delete/{id:int}")]
		public ActionResult<ResultDTO> Delete(int id) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				PowerSystem PowerSystem = PowerSystemRepo.getbyid(id);
				PowerSystem.IsDeleted = true;
				PowerSystemRepo.update(PowerSystem);
				result.Data = PowerSystem;
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
