using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HSEInventoryController : ControllerBase
	{
		public IRepository<HSEInventory> HSEInventoryRepo { get; set; }

		public HSEInventoryController(IRepository<HSEInventory> _HSEInventoryRepo)
		{
			this.HSEInventoryRepo = _HSEInventoryRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<HSEInventory> temp = HSEInventoryRepo.getall();
			List<HSEInventoryDTO> newTemp = new List<HSEInventoryDTO>();
			foreach (HSEInventory HSEInventory in temp)
			{
				HSEInventoryDTO HSEInventoryDTO = new HSEInventoryDTO();
				HSEInventoryDTO.Id = HSEInventory.Id;
				HSEInventoryDTO.Item = HSEInventory.Item;
				HSEInventoryDTO.StockAtStorage = HSEInventory.StockAtStorage;
				HSEInventoryDTO.ReleasedFromStorage = HSEInventory.ReleasedFromStorage;
				HSEInventoryDTO.NewlyRecieved = HSEInventory.NewlyRecieved;
				HSEInventoryDTO.IsDeleted = HSEInventory.IsDeleted;

				newTemp.Add(HSEInventoryDTO);
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

		//	List<HSEInventory> temp = HSEInventoryRepo.getall();
		//	List<HSEInventoryExcelDTO> newTemp = new List<HSEInventoryExcelDTO>();
		//	foreach (HSEInventory HSEInventory in temp)
		//	{
		//		HSEInventoryExcelDTO HSEInventoryDTO = new HSEInventoryExcelDTO();
		//		HSEInventoryDTO.Id = HSEInventory.Id;
		//		HSEInventoryDTO.Name = HSEInventory.Name;

		//		newTemp.Add(HSEInventoryDTO);
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
		//public PageResult<HSEInventoryDTO> GettAllHSEInventoryByPage(int? page, int pagesize = 10)
		//{
		//	List<HSEInventory> temp = HSEInventoryRepo.getall();
		//	List<HSEInventoryDTO> newTemp = new List<HSEInventoryDTO>();
		//	foreach (HSEInventory HSEInventory in temp)
		//	{
		//		HSEInventoryDTO HSEInventoryDTO = new HSEInventoryDTO();
		//		HSEInventoryDTO.Id = HSEInventory.Id;
		//		HSEInventoryDTO.Name = HSEInventory.Name;
		//		HSEInventoryDTO.IsDeleted = HSEInventory.IsDeleted;

		//		newTemp.Add(HSEInventoryDTO);
		//	}

		//	float countDetails = HSEInventoryRepo.getall().Count();
		//	var result = new PageResult<HSEInventoryDTO>
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
				HSEInventoryDTO HSEInventoryDTO = new HSEInventoryDTO();
				HSEInventory HSEInventory = HSEInventoryRepo.getbyid(ID);
				HSEInventoryDTO.Id = HSEInventory.Id;
				HSEInventoryDTO.Item = HSEInventory.Item;
				HSEInventoryDTO.StockAtStorage = HSEInventory.StockAtStorage;
				HSEInventoryDTO.ReleasedFromStorage = HSEInventory.ReleasedFromStorage;
				HSEInventoryDTO.NewlyRecieved = HSEInventory.NewlyRecieved;
				HSEInventoryDTO.IsDeleted = HSEInventory.IsDeleted;

				result.Message = "Success";
				result.Data = HSEInventoryDTO;
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
		public ActionResult<ResultDTO> Put(int id, HSEInventoryDTO newHSEInventory) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					HSEInventory orgHSEInventory = HSEInventoryRepo.getbyid(id);
					newHSEInventory.Id = orgHSEInventory.Id;
					orgHSEInventory.Item = newHSEInventory.Item;
					orgHSEInventory.StockAtStorage = newHSEInventory.StockAtStorage;
					orgHSEInventory.ReleasedFromStorage = newHSEInventory.ReleasedFromStorage;
					orgHSEInventory.NewlyRecieved = newHSEInventory.NewlyRecieved;
					orgHSEInventory.IsDeleted = newHSEInventory.IsDeleted;


					HSEInventoryRepo.update(orgHSEInventory);
					result.Message = "Success";
					result.Data = orgHSEInventory;
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
		public ActionResult<ResultDTO> AddHSEInventory(HSEInventoryDTO HSEInventoryDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					HSEInventory HSEInventory = new HSEInventory();
					HSEInventory.Id = HSEInventoryDTO.Id;
					HSEInventory.Item = HSEInventoryDTO.Item;
					HSEInventoryDTO.StockAtStorage = HSEInventory.StockAtStorage;
					HSEInventoryDTO.ReleasedFromStorage = HSEInventory.ReleasedFromStorage;
					HSEInventoryDTO.NewlyRecieved = HSEInventory.NewlyRecieved;
					HSEInventory.IsDeleted = HSEInventoryDTO.IsDeleted;

					HSEInventoryRepo.create(HSEInventory);
					result.Data = HSEInventory;
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
				HSEInventory HSEInventory = HSEInventoryRepo.getbyid(id);
				HSEInventory.IsDeleted = true;
				HSEInventoryRepo.update(HSEInventory);
				result.Data = HSEInventory;
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
