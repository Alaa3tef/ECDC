using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OtherSystemController : ControllerBase
	{
		public IRepository<OtherSystem> OtherSystemRepo { get; set; }

		public OtherSystemController(IRepository<OtherSystem> _OtherSystemRepo)
		{
			this.OtherSystemRepo = _OtherSystemRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<OtherSystem> temp = OtherSystemRepo.getall();
			List<OtherSystemDTO> newTemp = new List<OtherSystemDTO>();
			foreach (OtherSystem OtherSystem in temp)
			{
				OtherSystemDTO OtherSystemDTO = new OtherSystemDTO();
				OtherSystemDTO.Id = OtherSystem.Id;
				OtherSystemDTO.Item = OtherSystem.Item;
				OtherSystemDTO.CATIIICertificationDate = OtherSystem.CATIIICertificationDate;
				OtherSystemDTO.CATIIIExpiryDate = OtherSystem.CATIIIExpiryDate;
				OtherSystemDTO.CATIVCertificationDate = OtherSystem.CATIVCertificationDate;
				OtherSystemDTO.CATIVExpiryDate = OtherSystem.CATIVExpiryDate;
				OtherSystemDTO.RigCertificatesId = OtherSystem.RigCertificatesId;
				OtherSystemDTO.IsDeleted = OtherSystem.IsDeleted;

				newTemp.Add(OtherSystemDTO);
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

		//	List<OtherSystem> temp = OtherSystemRepo.getall();
		//	List<OtherSystemExcelDTO> newTemp = new List<OtherSystemExcelDTO>();
		//	foreach (OtherSystem OtherSystem in temp)
		//	{
		//		OtherSystemExcelDTO OtherSystemDTO = new OtherSystemExcelDTO();
		//		OtherSystemDTO.Id = OtherSystem.Id;
		//		OtherSystemDTO.Name = OtherSystem.Name;

		//		newTemp.Add(OtherSystemDTO);
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
		public PageResult<OtherSystemDTO> GettAllOtherSystemByPage(int? page, int pagesize = 10)
		{
			List<OtherSystem> temp = OtherSystemRepo.getall();
			List<OtherSystemDTO> newTemp = new List<OtherSystemDTO>();
			foreach (OtherSystem OtherSystem in temp)
			{
				OtherSystemDTO OtherSystemDTO = new OtherSystemDTO();
				OtherSystemDTO.Id = OtherSystem.Id;
				OtherSystemDTO.Item = OtherSystem.Item;
				OtherSystemDTO.CATIIICertificationDate = OtherSystem.CATIIICertificationDate;
				OtherSystemDTO.CATIIIExpiryDate = OtherSystem.CATIIIExpiryDate;
				OtherSystemDTO.CATIVCertificationDate = OtherSystem.CATIVCertificationDate;
				OtherSystemDTO.CATIVExpiryDate = OtherSystem.CATIVExpiryDate;
				OtherSystemDTO.RigCertificatesId = OtherSystem.RigCertificatesId;
				OtherSystemDTO.IsDeleted = OtherSystem.IsDeleted;

				newTemp.Add(OtherSystemDTO);
			}

			float countDetails = OtherSystemRepo.getall().Count();
			var result = new PageResult<OtherSystemDTO>
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
				OtherSystemDTO OtherSystemDTO = new OtherSystemDTO();
				OtherSystem OtherSystem = OtherSystemRepo.getbyid(ID);
				OtherSystemDTO.Id = OtherSystem.Id;
				OtherSystemDTO.Item = OtherSystem.Item;
				OtherSystemDTO.CATIIICertificationDate = OtherSystem.CATIIICertificationDate;
				OtherSystemDTO.CATIIIExpiryDate = OtherSystem.CATIIIExpiryDate;
				OtherSystemDTO.CATIVCertificationDate = OtherSystem.CATIVCertificationDate;
				OtherSystemDTO.CATIVExpiryDate = OtherSystem.CATIVExpiryDate;
				OtherSystemDTO.RigCertificatesId = OtherSystem.RigCertificatesId;
				OtherSystemDTO.IsDeleted = OtherSystem.IsDeleted;

				result.Message = "Success";
				result.Data = OtherSystemDTO;
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
		public ActionResult<ResultDTO> Put(int id, OtherSystemDTO newOtherSystem) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					OtherSystem orgOtherSystem = OtherSystemRepo.getbyid(id);
					newOtherSystem.Id = orgOtherSystem.Id;
					orgOtherSystem.Item = newOtherSystem.Item;
					orgOtherSystem.CATIIICertificationDate = newOtherSystem.CATIIICertificationDate;
					orgOtherSystem.CATIIIExpiryDate = newOtherSystem.CATIIIExpiryDate;
					orgOtherSystem.CATIVCertificationDate = newOtherSystem.CATIVCertificationDate;
					orgOtherSystem.CATIVExpiryDate = newOtherSystem.CATIVExpiryDate;
					orgOtherSystem.RigCertificatesId = newOtherSystem.RigCertificatesId;
					orgOtherSystem.IsDeleted = newOtherSystem.IsDeleted;


					OtherSystemRepo.update(orgOtherSystem);
					result.Message = "Success";
					result.Data = orgOtherSystem;
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
		public ActionResult<ResultDTO> AddOtherSystem(OtherSystemDTO OtherSystemDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					OtherSystem OtherSystem = new OtherSystem();
					OtherSystem.Id = OtherSystemDTO.Id;
					OtherSystem.Item = OtherSystemDTO.Item;
					OtherSystem.CATIIICertificationDate = OtherSystemDTO.CATIIICertificationDate;
					OtherSystem.CATIIIExpiryDate = OtherSystemDTO.CATIIIExpiryDate;
					OtherSystem.CATIVCertificationDate = OtherSystemDTO.CATIVCertificationDate;
					OtherSystem.CATIVExpiryDate = OtherSystemDTO.CATIVExpiryDate;
					OtherSystem.RigCertificatesId = OtherSystemDTO.RigCertificatesId;
					OtherSystem.IsDeleted = OtherSystemDTO.IsDeleted;

					OtherSystemRepo.create(OtherSystem);
					result.Data = OtherSystemDTO;
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
				OtherSystem OtherSystem = OtherSystemRepo.getbyid(id);
				OtherSystem.IsDeleted = true;
				OtherSystemRepo.update(OtherSystem);
				result.Data = OtherSystem;
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
