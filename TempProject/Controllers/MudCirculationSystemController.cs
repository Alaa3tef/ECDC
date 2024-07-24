using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MudCirculationSystemController : ControllerBase
	{
		public IRepository<MudCirculationSystem> MudCirculationSystemRepo { get; set; }

		public MudCirculationSystemController(IRepository<MudCirculationSystem> _MudCirculationSystemRepo)
		{
			this.MudCirculationSystemRepo = _MudCirculationSystemRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<MudCirculationSystem> temp = MudCirculationSystemRepo.getall();
			List<MudCirculationSystemDTO> newTemp = new List<MudCirculationSystemDTO>();
			foreach (MudCirculationSystem MudCirculationSystem in temp)
			{
				MudCirculationSystemDTO MudCirculationSystemDTO = new MudCirculationSystemDTO();
				MudCirculationSystemDTO.Id = MudCirculationSystem.Id;
				MudCirculationSystemDTO.Equipment = MudCirculationSystem.Equipment;
				MudCirculationSystemDTO.SerialNumber = MudCirculationSystem.SerialNumber;
				MudCirculationSystemDTO.COCAvailabilty = MudCirculationSystem.COCAvailabilty;
				MudCirculationSystemDTO.CATIIICertificationDate = MudCirculationSystem.CATIIICertificationDate;
				MudCirculationSystemDTO.CATIIIExpiryDate = MudCirculationSystem.CATIIIExpiryDate;
				MudCirculationSystemDTO.CATIVCertificationDate = MudCirculationSystem.CATIVCertificationDate;
				MudCirculationSystemDTO.CATIVExpiryDate = MudCirculationSystem.CATIVExpiryDate;
				MudCirculationSystemDTO.RigCertificatesId = MudCirculationSystem.RigCertificatesId;
				MudCirculationSystemDTO.IsDeleted = MudCirculationSystem.IsDeleted;

				newTemp.Add(MudCirculationSystemDTO);
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

		//	List<MudCirculationSystem> temp = MudCirculationSystemRepo.getall();
		//	List<MudCirculationSystemExcelDTO> newTemp = new List<MudCirculationSystemExcelDTO>();
		//	foreach (MudCirculationSystem MudCirculationSystem in temp)
		//	{
		//		MudCirculationSystemExcelDTO MudCirculationSystemDTO = new MudCirculationSystemExcelDTO();
		//		MudCirculationSystemDTO.Id = MudCirculationSystem.Id;
		//		MudCirculationSystemDTO.Name = MudCirculationSystem.Name;

		//		newTemp.Add(MudCirculationSystemDTO);
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
		public PageResult<MudCirculationSystemDTO> GettAllMudCirculationSystemByPage(int? page, int pagesize = 10)
		{
			List<MudCirculationSystem> temp = MudCirculationSystemRepo.getall();
			List<MudCirculationSystemDTO> newTemp = new List<MudCirculationSystemDTO>();
			foreach (MudCirculationSystem MudCirculationSystem in temp)
			{
				MudCirculationSystemDTO MudCirculationSystemDTO = new MudCirculationSystemDTO();
				MudCirculationSystemDTO.Id = MudCirculationSystem.Id;
				MudCirculationSystemDTO.Equipment = MudCirculationSystem.Equipment;
				MudCirculationSystemDTO.SerialNumber = MudCirculationSystem.SerialNumber;
				MudCirculationSystemDTO.COCAvailabilty = MudCirculationSystem.COCAvailabilty;
				MudCirculationSystemDTO.CATIIICertificationDate = MudCirculationSystem.CATIIICertificationDate;
				MudCirculationSystemDTO.CATIIIExpiryDate = MudCirculationSystem.CATIIIExpiryDate;
				MudCirculationSystemDTO.CATIVCertificationDate = MudCirculationSystem.CATIVCertificationDate;
				MudCirculationSystemDTO.CATIVExpiryDate = MudCirculationSystem.CATIVExpiryDate;
				MudCirculationSystemDTO.RigCertificatesId = MudCirculationSystem.RigCertificatesId;
				MudCirculationSystemDTO.IsDeleted = MudCirculationSystem.IsDeleted;

				newTemp.Add(MudCirculationSystemDTO);
			}

			float countDetails = MudCirculationSystemRepo.getall().Count();
			var result = new PageResult<MudCirculationSystemDTO>
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
				MudCirculationSystemDTO MudCirculationSystemDTO = new MudCirculationSystemDTO();
				MudCirculationSystem MudCirculationSystem = MudCirculationSystemRepo.getbyid(ID);
				MudCirculationSystemDTO.Id = MudCirculationSystem.Id;
				MudCirculationSystemDTO.Equipment = MudCirculationSystem.Equipment;
				MudCirculationSystemDTO.SerialNumber = MudCirculationSystem.SerialNumber;
				MudCirculationSystemDTO.COCAvailabilty = MudCirculationSystem.COCAvailabilty;
				MudCirculationSystemDTO.CATIIICertificationDate = MudCirculationSystem.CATIIICertificationDate;
				MudCirculationSystemDTO.CATIIIExpiryDate = MudCirculationSystem.CATIIIExpiryDate;
				MudCirculationSystemDTO.CATIVCertificationDate = MudCirculationSystem.CATIVCertificationDate;
				MudCirculationSystemDTO.CATIVExpiryDate = MudCirculationSystem.CATIVExpiryDate;
				MudCirculationSystemDTO.RigCertificatesId = MudCirculationSystem.RigCertificatesId;
				MudCirculationSystemDTO.IsDeleted = MudCirculationSystem.IsDeleted;

				result.Message = "Success";
				result.Data = MudCirculationSystemDTO;
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
		public ActionResult<ResultDTO> Put(int id, MudCirculationSystemDTO newMudCirculationSystem) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					MudCirculationSystem orgMudCirculationSystem = MudCirculationSystemRepo.getbyid(id);
					newMudCirculationSystem.Id = orgMudCirculationSystem.Id;
					orgMudCirculationSystem.Equipment = newMudCirculationSystem.Equipment;
					orgMudCirculationSystem.SerialNumber = newMudCirculationSystem.SerialNumber;
					orgMudCirculationSystem.COCAvailabilty = newMudCirculationSystem.COCAvailabilty;
					orgMudCirculationSystem.CATIIICertificationDate = newMudCirculationSystem.CATIIICertificationDate;
					orgMudCirculationSystem.CATIIIExpiryDate = newMudCirculationSystem.CATIIIExpiryDate;
					orgMudCirculationSystem.CATIVCertificationDate = newMudCirculationSystem.CATIVCertificationDate;
					orgMudCirculationSystem.CATIVExpiryDate = newMudCirculationSystem.CATIVExpiryDate;
					orgMudCirculationSystem.RigCertificatesId = newMudCirculationSystem.RigCertificatesId;
					orgMudCirculationSystem.IsDeleted = newMudCirculationSystem.IsDeleted;


					MudCirculationSystemRepo.update(orgMudCirculationSystem);
					result.Message = "Success";
					result.Data = orgMudCirculationSystem;
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
		public ActionResult<ResultDTO> AddMudCirculationSystem(MudCirculationSystemDTO MudCirculationSystemDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					MudCirculationSystem MudCirculationSystem = new MudCirculationSystem();
					MudCirculationSystem.Id = MudCirculationSystemDTO.Id;
					MudCirculationSystem.Equipment = MudCirculationSystemDTO.Equipment;
					MudCirculationSystem.SerialNumber = MudCirculationSystemDTO.SerialNumber;
					MudCirculationSystem.COCAvailabilty = MudCirculationSystemDTO.COCAvailabilty;
					MudCirculationSystem.CATIIICertificationDate = MudCirculationSystemDTO.CATIIICertificationDate;
					MudCirculationSystem.CATIIIExpiryDate = MudCirculationSystemDTO.CATIIIExpiryDate;
					MudCirculationSystem.CATIVCertificationDate = MudCirculationSystemDTO.CATIVCertificationDate;
					MudCirculationSystem.CATIVExpiryDate = MudCirculationSystemDTO.CATIVExpiryDate;
					MudCirculationSystem.RigCertificatesId = MudCirculationSystemDTO.RigCertificatesId;
					MudCirculationSystem.IsDeleted = MudCirculationSystemDTO.IsDeleted;

					MudCirculationSystemRepo.create(MudCirculationSystem);
					result.Data = MudCirculationSystemDTO;
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
				MudCirculationSystem MudCirculationSystem = MudCirculationSystemRepo.getbyid(id);
				MudCirculationSystem.IsDeleted = true;
				MudCirculationSystemRepo.update(MudCirculationSystem);
				result.Data = MudCirculationSystem;
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
