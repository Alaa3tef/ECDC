using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RotarySystemController : ControllerBase
	{
		public IRepository<RotarySystem> RotarySystemRepo { get; set; }

		public RotarySystemController(IRepository<RotarySystem> _RotarySystemRepo)
		{
			this.RotarySystemRepo = _RotarySystemRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<RotarySystem> temp = RotarySystemRepo.getall();
			List<RotarySystemDTO> newTemp = new List<RotarySystemDTO>();
			foreach (RotarySystem RotarySystem in temp)
			{
				RotarySystemDTO RotarySystemDTO = new RotarySystemDTO();
				RotarySystemDTO.Id = RotarySystem.Id;
				RotarySystemDTO.Equipment = RotarySystem.Equipment;
				RotarySystemDTO.SerialNumber = RotarySystem.SerialNumber;
				RotarySystemDTO.COCAvailabilty = RotarySystem.COCAvailabilty;
				RotarySystemDTO.CATIIICertificationDate = RotarySystem.CATIIICertificationDate;
				RotarySystemDTO.CATIIIExpiryDate = RotarySystem.CATIIIExpiryDate;
				RotarySystemDTO.CATIVCertificationDate = RotarySystem.CATIVCertificationDate;
				RotarySystemDTO.CATIVExpiryDate = RotarySystem.CATIVExpiryDate;
				RotarySystemDTO.RigCertificatesId = RotarySystem.RigCertificatesId;
				RotarySystemDTO.IsDeleted = RotarySystem.IsDeleted;

				newTemp.Add(RotarySystemDTO);
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

		//	List<RotarySystem> temp = RotarySystemRepo.getall();
		//	List<RotarySystemExcelDTO> newTemp = new List<RotarySystemExcelDTO>();
		//	foreach (RotarySystem RotarySystem in temp)
		//	{
		//		RotarySystemExcelDTO RotarySystemDTO = new RotarySystemExcelDTO();
		//		RotarySystemDTO.Id = RotarySystem.Id;
		//		RotarySystemDTO.Name = RotarySystem.Name;

		//		newTemp.Add(RotarySystemDTO);
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
		public PageResult<RotarySystemDTO> GettAllRotarySystemByPage(int? page, int pagesize = 10)
		{
			List<RotarySystem> temp = RotarySystemRepo.getall();
			List<RotarySystemDTO> newTemp = new List<RotarySystemDTO>();
			foreach (RotarySystem RotarySystem in temp)
			{
				RotarySystemDTO RotarySystemDTO = new RotarySystemDTO();
				RotarySystemDTO.Id = RotarySystem.Id;
				RotarySystemDTO.Equipment = RotarySystem.Equipment;
				RotarySystemDTO.SerialNumber = RotarySystem.SerialNumber;
				RotarySystemDTO.COCAvailabilty = RotarySystem.COCAvailabilty;
				RotarySystemDTO.CATIIICertificationDate = RotarySystem.CATIIICertificationDate;
				RotarySystemDTO.CATIIIExpiryDate = RotarySystem.CATIIIExpiryDate;
				RotarySystemDTO.CATIVCertificationDate = RotarySystem.CATIVCertificationDate;
				RotarySystemDTO.CATIVExpiryDate = RotarySystem.CATIVExpiryDate;
				RotarySystemDTO.RigCertificatesId = RotarySystem.RigCertificatesId;
				RotarySystemDTO.IsDeleted = RotarySystem.IsDeleted;

				newTemp.Add(RotarySystemDTO);
			}

			float countDetails = RotarySystemRepo.getall().Count();
			var result = new PageResult<RotarySystemDTO>
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
				RotarySystemDTO RotarySystemDTO = new RotarySystemDTO();
				RotarySystem RotarySystem = RotarySystemRepo.getbyid(ID);
				RotarySystemDTO.Id = RotarySystem.Id;
				RotarySystemDTO.Equipment = RotarySystem.Equipment;
				RotarySystemDTO.SerialNumber = RotarySystem.SerialNumber;
				RotarySystemDTO.COCAvailabilty = RotarySystem.COCAvailabilty;
				RotarySystemDTO.CATIIICertificationDate = RotarySystem.CATIIICertificationDate;
				RotarySystemDTO.CATIIIExpiryDate = RotarySystem.CATIIIExpiryDate;
				RotarySystemDTO.CATIVCertificationDate = RotarySystem.CATIVCertificationDate;
				RotarySystemDTO.CATIVExpiryDate = RotarySystem.CATIVExpiryDate;
				RotarySystemDTO.RigCertificatesId = RotarySystem.RigCertificatesId;
				RotarySystemDTO.IsDeleted = RotarySystem.IsDeleted;

				result.Message = "Success";
				result.Data = RotarySystemDTO;
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
		public ActionResult<ResultDTO> Put(int id, RotarySystemDTO newRotarySystem) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					RotarySystem orgRotarySystem = RotarySystemRepo.getbyid(id);
					newRotarySystem.Id = orgRotarySystem.Id;
					orgRotarySystem.Equipment = newRotarySystem.Equipment;
					orgRotarySystem.SerialNumber = newRotarySystem.SerialNumber;
					orgRotarySystem.COCAvailabilty = newRotarySystem.COCAvailabilty;
					orgRotarySystem.CATIIICertificationDate = newRotarySystem.CATIIICertificationDate;
					orgRotarySystem.CATIIIExpiryDate = newRotarySystem.CATIIIExpiryDate;
					orgRotarySystem.CATIVCertificationDate = newRotarySystem.CATIVCertificationDate;
					orgRotarySystem.CATIVExpiryDate = newRotarySystem.CATIVExpiryDate;
					orgRotarySystem.RigCertificatesId = newRotarySystem.RigCertificatesId;
					orgRotarySystem.IsDeleted = newRotarySystem.IsDeleted;


					RotarySystemRepo.update(orgRotarySystem);
					result.Message = "Success";
					result.Data = orgRotarySystem;
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
		public ActionResult<ResultDTO> AddRotarySystem(RotarySystemDTO RotarySystemDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					RotarySystem RotarySystem = new RotarySystem();
					RotarySystem.Id = RotarySystemDTO.Id;
					RotarySystem.Equipment = RotarySystemDTO.Equipment;
					RotarySystem.SerialNumber = RotarySystemDTO.SerialNumber;
					RotarySystem.COCAvailabilty = RotarySystemDTO.COCAvailabilty;
					RotarySystem.CATIIICertificationDate = RotarySystemDTO.CATIIICertificationDate;
					RotarySystem.CATIIIExpiryDate = RotarySystemDTO.CATIIIExpiryDate;
					RotarySystem.CATIVCertificationDate = RotarySystemDTO.CATIVCertificationDate;
					RotarySystem.CATIVExpiryDate = RotarySystemDTO.CATIVExpiryDate;
					RotarySystem.RigCertificatesId = RotarySystemDTO.RigCertificatesId;
					RotarySystem.IsDeleted = RotarySystemDTO.IsDeleted;

					RotarySystemRepo.create(RotarySystem);
					result.Data = RotarySystemDTO;
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
				RotarySystem RotarySystem = RotarySystemRepo.getbyid(id);
				RotarySystem.IsDeleted = true;
				RotarySystemRepo.update(RotarySystem);
				result.Data = RotarySystem;
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
