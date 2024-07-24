using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DrugInventoryController : ControllerBase
	{
		public IRepository<DrugInventory> DrugInventoryRepo { get; set; }

		public DrugInventoryController(IRepository<DrugInventory> _DrugInventoryRepo)
		{
			this.DrugInventoryRepo = _DrugInventoryRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<DrugInventory> temp = DrugInventoryRepo.getall();
			List<DrugInventoryDTO> newTemp = new List<DrugInventoryDTO>();
			foreach (DrugInventory DrugInventory in temp)
			{
				DrugInventoryDTO DrugInventoryDTO = new DrugInventoryDTO();
				DrugInventoryDTO.Id = DrugInventory.Id;
				DrugInventoryDTO.Item = DrugInventory.Item;
				DrugInventoryDTO.Quantity = DrugInventory.Quantity;
				DrugInventoryDTO.ExpireDate = DrugInventory.ExpireDate;
				DrugInventoryDTO.IsDeleted = DrugInventory.IsDeleted;

				newTemp.Add(DrugInventoryDTO);
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

		//	List<DrugInventory> temp = DrugInventoryRepo.getall();
		//	List<DrugInventoryExcelDTO> newTemp = new List<DrugInventoryExcelDTO>();
		//	foreach (DrugInventory DrugInventory in temp)
		//	{
		//		DrugInventoryExcelDTO DrugInventoryDTO = new DrugInventoryExcelDTO();
		//		DrugInventoryDTO.Id = DrugInventory.Id;
		//		DrugInventoryDTO.Name = DrugInventory.Name;

		//		newTemp.Add(DrugInventoryDTO);
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
		//public PageResult<DrugInventoryDTO> GettAllDrugInventoryByPage(int? page, int pagesize = 10)
		//{
		//	List<DrugInventory> temp = DrugInventoryRepo.getall();
		//	List<DrugInventoryDTO> newTemp = new List<DrugInventoryDTO>();
		//	foreach (DrugInventory DrugInventory in temp)
		//	{
		//		DrugInventoryDTO DrugInventoryDTO = new DrugInventoryDTO();
		//		DrugInventoryDTO.Id = DrugInventory.Id;
		//		DrugInventoryDTO.Name = DrugInventory.Name;
		//		DrugInventoryDTO.IsDeleted = DrugInventory.IsDeleted;

		//		newTemp.Add(DrugInventoryDTO);
		//	}

		//	float countDetails = DrugInventoryRepo.getall().Count();
		//	var result = new PageResult<DrugInventoryDTO>
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
				DrugInventoryDTO DrugInventoryDTO = new DrugInventoryDTO();
				DrugInventory DrugInventory = DrugInventoryRepo.getbyid(ID);
				DrugInventoryDTO.Id = DrugInventory.Id;
				DrugInventoryDTO.Item = DrugInventory.Item;
				DrugInventoryDTO.Quantity = DrugInventory.Quantity;
				DrugInventoryDTO.ExpireDate = DrugInventory.ExpireDate;
				DrugInventoryDTO.IsDeleted = DrugInventory.IsDeleted;

				result.Message = "Success";
				result.Data = DrugInventoryDTO;
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
		public ActionResult<ResultDTO> Put(int id, DrugInventoryDTO newDrugInventory) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					DrugInventory orgDrugInventory = DrugInventoryRepo.getbyid(id);
					newDrugInventory.Id = orgDrugInventory.Id;
					orgDrugInventory.Item = newDrugInventory.Item;
					orgDrugInventory.Quantity = newDrugInventory.Quantity;
					orgDrugInventory.ExpireDate = newDrugInventory.ExpireDate;
					orgDrugInventory.IsDeleted = newDrugInventory.IsDeleted;


					DrugInventoryRepo.update(orgDrugInventory);
					result.Message = "Success";
					result.Data = orgDrugInventory;
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
		public ActionResult<ResultDTO> AddDrugInventory(DrugInventoryDTO DrugInventoryDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					DrugInventory DrugInventory = new DrugInventory();
					DrugInventory.Id = DrugInventoryDTO.Id;
					DrugInventory.Item = DrugInventoryDTO.Item;
					DrugInventory.Quantity = DrugInventoryDTO.Quantity;
					DrugInventory.ExpireDate = DrugInventoryDTO.ExpireDate;
					DrugInventory.IsDeleted = DrugInventoryDTO.IsDeleted;

					DrugInventoryRepo.create(DrugInventory);
					result.Data = DrugInventoryDTO;
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
				DrugInventory DrugInventory = DrugInventoryRepo.getbyid(id);
				DrugInventory.IsDeleted = true;
				DrugInventoryRepo.update(DrugInventory);
				result.Data = DrugInventory;
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
