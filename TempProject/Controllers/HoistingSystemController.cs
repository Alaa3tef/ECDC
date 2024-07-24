using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HoistingSystemController : ControllerBase
	{
		public IRepository<HoistingSystem> HoistingSystemRepo { get; set; }

		public HoistingSystemController(IRepository<HoistingSystem> _HoistingSystemRepo)
		{
			this.HoistingSystemRepo = _HoistingSystemRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<HoistingSystem> temp = HoistingSystemRepo.getall();
			List<HoistingSystemDTO> newTemp = new List<HoistingSystemDTO>();
			foreach (HoistingSystem HoistingSystem in temp)
			{
				HoistingSystemDTO HoistingSystemDTO = new HoistingSystemDTO();
				HoistingSystemDTO.Id = HoistingSystem.Id;
				HoistingSystemDTO.Equipment = HoistingSystem.Equipment;
				HoistingSystemDTO.SerialNumber = HoistingSystem.SerialNumber;
				HoistingSystemDTO.COCAvailabilty = HoistingSystem.COCAvailabilty;
				HoistingSystemDTO.CATIIICertificationDate = HoistingSystem.CATIIICertificationDate;
				HoistingSystemDTO.CATIIIExpiryDate = HoistingSystem.CATIIIExpiryDate;
				HoistingSystemDTO.CATIVCertificationDate = HoistingSystem.CATIVCertificationDate;
				HoistingSystemDTO.CATIVExpiryDate = HoistingSystem.CATIVExpiryDate;
				HoistingSystemDTO.RigCertificatesId = HoistingSystem.RigCertificatesId;
				HoistingSystemDTO.IsDeleted = HoistingSystem.IsDeleted;

				newTemp.Add(HoistingSystemDTO);
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

		//	List<HoistingSystem> temp = HoistingSystemRepo.getall();
		//	List<HoistingSystemExcelDTO> newTemp = new List<HoistingSystemExcelDTO>();
		//	foreach (HoistingSystem HoistingSystem in temp)
		//	{
		//		HoistingSystemExcelDTO HoistingSystemDTO = new HoistingSystemExcelDTO();
		//		HoistingSystemDTO.Id = HoistingSystem.Id;
		//		HoistingSystemDTO.Name = HoistingSystem.Name;

		//		newTemp.Add(HoistingSystemDTO);
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
		public PageResult<HoistingSystemDTO> GettAllHoistingSystemByPage(int? page, int pagesize = 10)
		{
			List<HoistingSystem> temp = HoistingSystemRepo.getall();
			List<HoistingSystemDTO> newTemp = new List<HoistingSystemDTO>();
			foreach (HoistingSystem HoistingSystem in temp)
			{
				HoistingSystemDTO HoistingSystemDTO = new HoistingSystemDTO();
				HoistingSystemDTO.Id = HoistingSystem.Id;
				HoistingSystemDTO.Equipment = HoistingSystem.Equipment;
				HoistingSystemDTO.SerialNumber = HoistingSystem.SerialNumber;
				HoistingSystemDTO.COCAvailabilty = HoistingSystem.COCAvailabilty;
				HoistingSystemDTO.CATIIICertificationDate = HoistingSystem.CATIIICertificationDate;
				HoistingSystemDTO.CATIIIExpiryDate = HoistingSystem.CATIIIExpiryDate;
				HoistingSystemDTO.CATIVCertificationDate = HoistingSystem.CATIVCertificationDate;
				HoistingSystemDTO.CATIVExpiryDate = HoistingSystem.CATIVExpiryDate;
				HoistingSystemDTO.RigCertificatesId = HoistingSystem.RigCertificatesId;
				HoistingSystemDTO.IsDeleted = HoistingSystem.IsDeleted;

				newTemp.Add(HoistingSystemDTO);
			}

			float countDetails = HoistingSystemRepo.getall().Count();
			var result = new PageResult<HoistingSystemDTO>
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
				HoistingSystemDTO HoistingSystemDTO = new HoistingSystemDTO();
				HoistingSystem HoistingSystem = HoistingSystemRepo.getbyid(ID);
				HoistingSystemDTO.Id = HoistingSystem.Id;
				HoistingSystemDTO.Equipment = HoistingSystem.Equipment;
				HoistingSystemDTO.SerialNumber = HoistingSystem.SerialNumber;
				HoistingSystemDTO.COCAvailabilty = HoistingSystem.COCAvailabilty;
				HoistingSystemDTO.CATIIICertificationDate = HoistingSystem.CATIIICertificationDate;
				HoistingSystemDTO.CATIIIExpiryDate = HoistingSystem.CATIIIExpiryDate;
				HoistingSystemDTO.CATIVCertificationDate = HoistingSystem.CATIVCertificationDate;
				HoistingSystemDTO.CATIVExpiryDate = HoistingSystem.CATIVExpiryDate;
				HoistingSystemDTO.RigCertificatesId = HoistingSystem.RigCertificatesId;
				HoistingSystemDTO.IsDeleted = HoistingSystem.IsDeleted;

				result.Message = "Success";
				result.Data = HoistingSystemDTO;
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
		public ActionResult<ResultDTO> Put(int id, HoistingSystemDTO newHoistingSystem) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					HoistingSystem orgHoistingSystem = HoistingSystemRepo.getbyid(id);
					newHoistingSystem.Id = orgHoistingSystem.Id;
					orgHoistingSystem.Equipment = newHoistingSystem.Equipment;
					orgHoistingSystem.SerialNumber = newHoistingSystem.SerialNumber;
					orgHoistingSystem.COCAvailabilty = newHoistingSystem.COCAvailabilty;
					orgHoistingSystem.CATIIICertificationDate = newHoistingSystem.CATIIICertificationDate;
					orgHoistingSystem.CATIIIExpiryDate = newHoistingSystem.CATIIIExpiryDate;
					orgHoistingSystem.CATIVCertificationDate = newHoistingSystem.CATIVCertificationDate;
					orgHoistingSystem.CATIVExpiryDate = newHoistingSystem.CATIVExpiryDate;
					orgHoistingSystem.RigCertificatesId = newHoistingSystem.RigCertificatesId;
					orgHoistingSystem.IsDeleted = newHoistingSystem.IsDeleted;


					HoistingSystemRepo.update(orgHoistingSystem);
					result.Message = "Success";
					result.Data = orgHoistingSystem;
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
		public ActionResult<ResultDTO> AddHoistingSystem(HoistingSystemDTO HoistingSystemDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					HoistingSystem HoistingSystem = new HoistingSystem();
					HoistingSystem.Id = HoistingSystemDTO.Id;
					HoistingSystem.Equipment = HoistingSystemDTO.Equipment;
					HoistingSystem.SerialNumber = HoistingSystemDTO.SerialNumber;
					HoistingSystem.COCAvailabilty = HoistingSystemDTO.COCAvailabilty;
					HoistingSystem.CATIIICertificationDate = HoistingSystemDTO.CATIIICertificationDate;
					HoistingSystem.CATIIIExpiryDate = HoistingSystemDTO.CATIIIExpiryDate;
					HoistingSystem.CATIVCertificationDate = HoistingSystemDTO.CATIVCertificationDate;
					HoistingSystem.CATIVExpiryDate = HoistingSystemDTO.CATIVExpiryDate;
					HoistingSystem.RigCertificatesId = HoistingSystemDTO.RigCertificatesId;
					HoistingSystem.IsDeleted = HoistingSystemDTO.IsDeleted;

					HoistingSystemRepo.create(HoistingSystem);
					result.Data = HoistingSystemDTO;
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
				HoistingSystem HoistingSystem = HoistingSystemRepo.getbyid(id);
				HoistingSystem.IsDeleted = true;
				HoistingSystemRepo.update(HoistingSystem);
				result.Data = HoistingSystem;
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
