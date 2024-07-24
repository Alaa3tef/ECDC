using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftDrillTypesController : ControllerBase
	{
		public IRepository<ShiftDrillTypes> ShiftDrillTypesRepo { get; set; }

		public ShiftDrillTypesController(IRepository<ShiftDrillTypes> _ShiftDrillTypesRepo)
		{
			this.ShiftDrillTypesRepo = _ShiftDrillTypesRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<ShiftDrillTypes> temp = ShiftDrillTypesRepo.getall();
			List<ShiftDrillTypesDTO> newTemp = new List<ShiftDrillTypesDTO>();
			foreach (ShiftDrillTypes ShiftDrillTypes in temp)
			{
				ShiftDrillTypesDTO ShiftDrillTypesDTO = new ShiftDrillTypesDTO();
				ShiftDrillTypesDTO.Id = ShiftDrillTypes.Id;
				ShiftDrillTypesDTO.Date = ShiftDrillTypes.Date;
				ShiftDrillTypesDTO.DrillType = ShiftDrillTypes.DrillType;
				ShiftDrillTypesDTO.IsDeleted = ShiftDrillTypes.IsDeleted;

				newTemp.Add(ShiftDrillTypesDTO);
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

		//	List<ShiftDrillTypes> temp = ShiftDrillTypesRepo.getall();
		//	List<ShiftDrillTypesExcelDTO> newTemp = new List<ShiftDrillTypesExcelDTO>();
		//	foreach (ShiftDrillTypes ShiftDrillTypes in temp)
		//	{
		//		ShiftDrillTypesExcelDTO ShiftDrillTypesDTO = new ShiftDrillTypesExcelDTO();
		//		ShiftDrillTypesDTO.Id = ShiftDrillTypes.Id;
		//		ShiftDrillTypesDTO.Name = ShiftDrillTypes.Name;

		//		newTemp.Add(ShiftDrillTypesDTO);
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
		//public PageResult<ShiftDrillTypesDTO> GettAllShiftDrillTypesByPage(int? page, int pagesize = 10)
		//{
		//	List<ShiftDrillTypes> temp = ShiftDrillTypesRepo.getall();
		//	List<ShiftDrillTypesDTO> newTemp = new List<ShiftDrillTypesDTO>();
		//	foreach (ShiftDrillTypes ShiftDrillTypes in temp)
		//	{
		//		ShiftDrillTypesDTO ShiftDrillTypesDTO = new ShiftDrillTypesDTO();
		//		ShiftDrillTypesDTO.Id = ShiftDrillTypes.Id;
		//		ShiftDrillTypesDTO.Name = ShiftDrillTypes.Name;
		//		ShiftDrillTypesDTO.IsDeleted = ShiftDrillTypes.IsDeleted;

		//		newTemp.Add(ShiftDrillTypesDTO);
		//	}

		//	float countDetails = ShiftDrillTypesRepo.getall().Count();
		//	var result = new PageResult<ShiftDrillTypesDTO>
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
				ShiftDrillTypesDTO ShiftDrillTypesDTO = new ShiftDrillTypesDTO();
				ShiftDrillTypes ShiftDrillTypes = ShiftDrillTypesRepo.getbyid(ID);
				ShiftDrillTypesDTO.Id = ShiftDrillTypes.Id;
				ShiftDrillTypesDTO.Date = ShiftDrillTypes.Date;
				ShiftDrillTypesDTO.DrillType = ShiftDrillTypes.DrillType;
				ShiftDrillTypesDTO.IsDeleted = ShiftDrillTypes.IsDeleted;

				result.Message = "Success";
				result.Data = ShiftDrillTypesDTO;
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
		public ActionResult<ResultDTO> Put(int id, ShiftDrillTypesDTO newShiftDrillTypes) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					ShiftDrillTypes orgShiftDrillTypes = ShiftDrillTypesRepo.getbyid(id);
					newShiftDrillTypes.Id = orgShiftDrillTypes.Id;
					orgShiftDrillTypes.Date = newShiftDrillTypes.Date;
					orgShiftDrillTypes.DrillType = newShiftDrillTypes.DrillType;
					orgShiftDrillTypes.IsDeleted = newShiftDrillTypes.IsDeleted;


					ShiftDrillTypesRepo.update(orgShiftDrillTypes);
					result.Message = "Success";
					result.Data = orgShiftDrillTypes;
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
		public ActionResult<ResultDTO> AddShiftDrillTypes(ShiftDrillTypesDTO ShiftDrillTypesDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					ShiftDrillTypes ShiftDrillTypes = new ShiftDrillTypes();
					ShiftDrillTypes.Id = ShiftDrillTypesDTO.Id;
					ShiftDrillTypesDTO.Date = ShiftDrillTypes.Date;
					ShiftDrillTypesDTO.DrillType = ShiftDrillTypes.DrillType;
					ShiftDrillTypes.IsDeleted = ShiftDrillTypesDTO.IsDeleted;

					ShiftDrillTypesRepo.create(ShiftDrillTypes);
					result.Data = ShiftDrillTypes;
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
				ShiftDrillTypes ShiftDrillTypes = ShiftDrillTypesRepo.getbyid(id);
				ShiftDrillTypes.IsDeleted = true;
				ShiftDrillTypesRepo.update(ShiftDrillTypes);
				result.Data = ShiftDrillTypes;
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
