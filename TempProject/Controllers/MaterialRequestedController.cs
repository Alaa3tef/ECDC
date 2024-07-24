using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MaterialRequestedController : ControllerBase
	{
		public IRepository<MaterialRequested> MaterialRequestedRepo { get; set; }

		public MaterialRequestedController(IRepository<MaterialRequested> _MaterialRequestedRepo)
		{
			this.MaterialRequestedRepo = _MaterialRequestedRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<MaterialRequested> temp = MaterialRequestedRepo.getall();
			List<MaterialRequestedDTO> newTemp = new List<MaterialRequestedDTO>();
			foreach (MaterialRequested MaterialRequested in temp)
			{
				MaterialRequestedDTO MaterialRequestedDTO = new MaterialRequestedDTO();
				MaterialRequestedDTO.Id = MaterialRequested.Id;
				MaterialRequestedDTO.PR = MaterialRequested.PR;
				MaterialRequestedDTO.RequiredItem = MaterialRequested.RequiredItem;
				MaterialRequestedDTO.IsDeleted = MaterialRequested.IsDeleted;

				newTemp.Add(MaterialRequestedDTO);
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

		//	List<MaterialRequested> temp = MaterialRequestedRepo.getall();
		//	List<MaterialRequestedExcelDTO> newTemp = new List<MaterialRequestedExcelDTO>();
		//	foreach (MaterialRequested MaterialRequested in temp)
		//	{
		//		MaterialRequestedExcelDTO MaterialRequestedDTO = new MaterialRequestedExcelDTO();
		//		MaterialRequestedDTO.Id = MaterialRequested.Id;
		//		MaterialRequestedDTO.Name = MaterialRequested.Name;

		//		newTemp.Add(MaterialRequestedDTO);
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

		//[HttpGet("ByPage/{page:int}")]
		//public PageResult<MaterialRequestedDTO> GettAllMaterialRequestedByPage(int? page, int pagesize = 10)
		//{
		//	List<MaterialRequested> temp = MaterialRequestedRepo.getall();
		//	List<MaterialRequestedDTO> newTemp = new List<MaterialRequestedDTO>();
		//	foreach (MaterialRequested MaterialRequested in temp)
		//	{
		//		MaterialRequestedDTO MaterialRequestedDTO = new MaterialRequestedDTO();
		//		MaterialRequestedDTO.Id = MaterialRequested.Id;
		//		MaterialRequestedDTO.Name = MaterialRequested.Name;
		//		MaterialRequestedDTO.IsDeleted = MaterialRequested.IsDeleted;

		//		newTemp.Add(MaterialRequestedDTO);
		//	}

		//	float countDetails = MaterialRequestedRepo.getall().Count();
		//	var result = new PageResult<MaterialRequestedDTO>
		//	{
		//		Count = (int)Math.Ceiling(countDetails / pagesize),
		//		PageIndex = page ?? 1,
		//		PageSize = pagesize,
		//		Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
		//	};
		//	return result;
		//}

		[HttpGet("{ID:int}")]
		public ActionResult<ResultDTO> GetByID(int ID)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				MaterialRequestedDTO MaterialRequestedDTO = new MaterialRequestedDTO();
				MaterialRequested MaterialRequested = MaterialRequestedRepo.getbyid(ID);
				MaterialRequestedDTO.Id = MaterialRequested.Id;
				MaterialRequestedDTO.PR = MaterialRequested.PR;
				MaterialRequestedDTO.RequiredItem = MaterialRequested.RequiredItem;
				MaterialRequestedDTO.IsDeleted = MaterialRequested.IsDeleted;

				result.Message = "Success";
				result.Data = MaterialRequestedDTO;
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
		public ActionResult<ResultDTO> Put(int id, MaterialRequestedDTO newMaterialRequested) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					MaterialRequested orgMaterialRequested = MaterialRequestedRepo.getbyid(id);
					newMaterialRequested.Id = orgMaterialRequested.Id;
					orgMaterialRequested.PR = newMaterialRequested.PR;
					orgMaterialRequested.RequiredItem = newMaterialRequested.RequiredItem;
					orgMaterialRequested.IsDeleted = newMaterialRequested.IsDeleted;


					MaterialRequestedRepo.update(orgMaterialRequested);
					result.Message = "Success";
					result.Data = orgMaterialRequested;
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
		public ActionResult<ResultDTO> AddMaterialRequested(MaterialRequestedDTO MaterialRequestedDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					MaterialRequested MaterialRequested = new MaterialRequested();
					MaterialRequested.Id = MaterialRequestedDTO.Id;
					MaterialRequestedDTO.PR = MaterialRequested.PR;
					MaterialRequestedDTO.RequiredItem = MaterialRequested.RequiredItem;
					MaterialRequested.IsDeleted = MaterialRequestedDTO.IsDeleted;

					MaterialRequestedRepo.create(MaterialRequested);
					result.Data = MaterialRequested;
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
				MaterialRequested MaterialRequested = MaterialRequestedRepo.getbyid(id);
				MaterialRequested.IsDeleted = true;
				MaterialRequestedRepo.update(MaterialRequested);
				result.Data = MaterialRequested;
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
