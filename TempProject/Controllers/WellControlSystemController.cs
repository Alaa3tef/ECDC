using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WellControlSystemController : ControllerBase
	{
		public IRepository<WellControlSystem> WellControlSystemRepo { get; set; }

		public WellControlSystemController(IRepository<WellControlSystem> _WellControlSystemRepo)
		{
			this.WellControlSystemRepo = _WellControlSystemRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<WellControlSystem> temp = WellControlSystemRepo.getall();
			List<WellControlSystemDTO> newTemp = new List<WellControlSystemDTO>();
			foreach (WellControlSystem WellControlSystem in temp)
			{
				WellControlSystemDTO WellControlSystemDTO = new WellControlSystemDTO();
				WellControlSystemDTO.Id = WellControlSystem.Id;
				WellControlSystemDTO.Equipment = WellControlSystem.Equipment;
				WellControlSystemDTO.SerialNumber = WellControlSystem.SerialNumber;
				WellControlSystemDTO.COCAvailabilty = WellControlSystem.COCAvailabilty;
				WellControlSystemDTO.CATIIICertificationDate = WellControlSystem.CATIIICertificationDate;
				WellControlSystemDTO.CATIIIExpiryDate = WellControlSystem.CATIIIExpiryDate;
				WellControlSystemDTO.CATIVCertificationDate = WellControlSystem.CATIVCertificationDate;
				WellControlSystemDTO.CATIVExpiryDate = WellControlSystem.CATIVExpiryDate;
				WellControlSystemDTO.RigCertificatesId = WellControlSystem.RigCertificatesId;
				WellControlSystemDTO.IsDeleted = WellControlSystem.IsDeleted;

				newTemp.Add(WellControlSystemDTO);
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

		//	List<WellControlSystem> temp = WellControlSystemRepo.getall();
		//	List<WellControlSystemExcelDTO> newTemp = new List<WellControlSystemExcelDTO>();
		//	foreach (WellControlSystem WellControlSystem in temp)
		//	{
		//		WellControlSystemExcelDTO WellControlSystemDTO = new WellControlSystemExcelDTO();
		//		WellControlSystemDTO.Id = WellControlSystem.Id;
		//		WellControlSystemDTO.Name = WellControlSystem.Name;

		//		newTemp.Add(WellControlSystemDTO);
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
		public PageResult<WellControlSystemDTO> GettAllWellControlSystemByPage(int? page, int pagesize = 10)
		{
			List<WellControlSystem> temp = WellControlSystemRepo.getall();
			List<WellControlSystemDTO> newTemp = new List<WellControlSystemDTO>();
			foreach (WellControlSystem WellControlSystem in temp)
			{
				WellControlSystemDTO WellControlSystemDTO = new WellControlSystemDTO();
				WellControlSystemDTO.Id = WellControlSystem.Id;
				WellControlSystemDTO.Equipment = WellControlSystem.Equipment;
				WellControlSystemDTO.SerialNumber = WellControlSystem.SerialNumber;
				WellControlSystemDTO.COCAvailabilty = WellControlSystem.COCAvailabilty;
				WellControlSystemDTO.CATIIICertificationDate = WellControlSystem.CATIIICertificationDate;
				WellControlSystemDTO.CATIIIExpiryDate = WellControlSystem.CATIIIExpiryDate;
				WellControlSystemDTO.CATIVCertificationDate = WellControlSystem.CATIVCertificationDate;
				WellControlSystemDTO.CATIVExpiryDate = WellControlSystem.CATIVExpiryDate;
				WellControlSystemDTO.RigCertificatesId = WellControlSystem.RigCertificatesId;
				WellControlSystemDTO.IsDeleted = WellControlSystem.IsDeleted;

				newTemp.Add(WellControlSystemDTO);
			}

			float countDetails = WellControlSystemRepo.getall().Count();
			var result = new PageResult<WellControlSystemDTO>
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
				WellControlSystemDTO WellControlSystemDTO = new WellControlSystemDTO();
				WellControlSystem WellControlSystem = WellControlSystemRepo.getbyid(ID);
				WellControlSystemDTO.Id = WellControlSystem.Id;
				WellControlSystemDTO.Equipment = WellControlSystem.Equipment;
				WellControlSystemDTO.SerialNumber = WellControlSystem.SerialNumber;
				WellControlSystemDTO.COCAvailabilty = WellControlSystem.COCAvailabilty;
				WellControlSystemDTO.CATIIICertificationDate = WellControlSystem.CATIIICertificationDate;
				WellControlSystemDTO.CATIIIExpiryDate = WellControlSystem.CATIIIExpiryDate;
				WellControlSystemDTO.CATIVCertificationDate = WellControlSystem.CATIVCertificationDate;
				WellControlSystemDTO.CATIVExpiryDate = WellControlSystem.CATIVExpiryDate;
				WellControlSystemDTO.RigCertificatesId = WellControlSystem.RigCertificatesId;
				WellControlSystemDTO.IsDeleted = WellControlSystem.IsDeleted;

				result.Message = "Success";
				result.Data = WellControlSystemDTO;
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
		public ActionResult<ResultDTO> Put(int id, WellControlSystemDTO newWellControlSystem) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					WellControlSystem orgWellControlSystem = WellControlSystemRepo.getbyid(id);
					newWellControlSystem.Id = orgWellControlSystem.Id;
					orgWellControlSystem.Equipment = newWellControlSystem.Equipment;
					orgWellControlSystem.SerialNumber = newWellControlSystem.SerialNumber;
					orgWellControlSystem.COCAvailabilty = newWellControlSystem.COCAvailabilty;
					orgWellControlSystem.CATIIICertificationDate = newWellControlSystem.CATIIICertificationDate;
					orgWellControlSystem.CATIIIExpiryDate = newWellControlSystem.CATIIIExpiryDate;
					orgWellControlSystem.CATIVCertificationDate = newWellControlSystem.CATIVCertificationDate;
					orgWellControlSystem.CATIVExpiryDate = newWellControlSystem.CATIVExpiryDate;
					orgWellControlSystem.RigCertificatesId = newWellControlSystem.RigCertificatesId;
					orgWellControlSystem.IsDeleted = newWellControlSystem.IsDeleted;


					WellControlSystemRepo.update(orgWellControlSystem);
					result.Message = "Success";
					result.Data = orgWellControlSystem;
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
		public ActionResult<ResultDTO> AddWellControlSystem(WellControlSystemDTO WellControlSystemDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					WellControlSystem WellControlSystem = new WellControlSystem();
					WellControlSystem.Id = WellControlSystemDTO.Id;
					WellControlSystem.Equipment = WellControlSystemDTO.Equipment;
					WellControlSystem.SerialNumber = WellControlSystemDTO.SerialNumber;
					WellControlSystem.COCAvailabilty = WellControlSystemDTO.COCAvailabilty;
					WellControlSystem.CATIIICertificationDate = WellControlSystemDTO.CATIIICertificationDate;
					WellControlSystem.CATIIIExpiryDate = WellControlSystemDTO.CATIIIExpiryDate;
					WellControlSystem.CATIVCertificationDate = WellControlSystemDTO.CATIVCertificationDate;
					WellControlSystem.CATIVExpiryDate = WellControlSystemDTO.CATIVExpiryDate;
					WellControlSystem.RigCertificatesId = WellControlSystemDTO.RigCertificatesId;
					WellControlSystem.IsDeleted = WellControlSystemDTO.IsDeleted;

					WellControlSystemRepo.create(WellControlSystem);
					result.Data = WellControlSystemDTO;
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
				WellControlSystem WellControlSystem = WellControlSystemRepo.getbyid(id);
				WellControlSystem.IsDeleted = true;
				WellControlSystemRepo.update(WellControlSystem);
				result.Data = WellControlSystem;
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
