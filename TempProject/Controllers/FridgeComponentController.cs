using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FridgeComponentController : ControllerBase
	{
		public IRepository<FridgeComponent> FridgeComponentRepo { get; set; }

		public FridgeComponentController(IRepository<FridgeComponent> _FridgeComponentRepo)
		{
			this.FridgeComponentRepo = _FridgeComponentRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<FridgeComponent> temp = FridgeComponentRepo.getall();
			List<FridgeComponentDTO> newTemp = new List<FridgeComponentDTO>();
			foreach (FridgeComponent FridgeComponent in temp)
			{
				FridgeComponentDTO FridgeComponentDTO = new FridgeComponentDTO();
				FridgeComponentDTO.Id = FridgeComponent.Id;
				FridgeComponentDTO.Item = FridgeComponent.Item;
				FridgeComponentDTO.Quantity = FridgeComponent.Quantity;
				FridgeComponentDTO.ExpireDate = FridgeComponent.ExpireDate;
				FridgeComponentDTO.IsDeleted = FridgeComponent.IsDeleted;

				newTemp.Add(FridgeComponentDTO);
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

		//	List<FridgeComponent> temp = FridgeComponentRepo.getall();
		//	List<FridgeComponentExcelDTO> newTemp = new List<FridgeComponentExcelDTO>();
		//	foreach (FridgeComponent FridgeComponent in temp)
		//	{
		//		FridgeComponentExcelDTO FridgeComponentDTO = new FridgeComponentExcelDTO();
		//		FridgeComponentDTO.Id = FridgeComponent.Id;
		//		FridgeComponentDTO.Name = FridgeComponent.Name;

		//		newTemp.Add(FridgeComponentDTO);
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
		//public PageResult<FridgeComponentDTO> GettAllFridgeComponentByPage(int? page, int pagesize = 10)
		//{
		//	List<FridgeComponent> temp = FridgeComponentRepo.getall();
		//	List<FridgeComponentDTO> newTemp = new List<FridgeComponentDTO>();
		//	foreach (FridgeComponent FridgeComponent in temp)
		//	{
		//		FridgeComponentDTO FridgeComponentDTO = new FridgeComponentDTO();
		//		FridgeComponentDTO.Id = FridgeComponent.Id;
		//		FridgeComponentDTO.Name = FridgeComponent.Name;
		//		FridgeComponentDTO.IsDeleted = FridgeComponent.IsDeleted;

		//		newTemp.Add(FridgeComponentDTO);
		//	}

		//	float countDetails = FridgeComponentRepo.getall().Count();
		//	var result = new PageResult<FridgeComponentDTO>
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
				FridgeComponentDTO FridgeComponentDTO = new FridgeComponentDTO();
				FridgeComponent FridgeComponent = FridgeComponentRepo.getbyid(ID);
				FridgeComponentDTO.Id = FridgeComponent.Id;
				FridgeComponentDTO.Item = FridgeComponent.Item;
				FridgeComponentDTO.Quantity = FridgeComponent.Quantity;
				FridgeComponentDTO.ExpireDate = FridgeComponent.ExpireDate;
				FridgeComponentDTO.IsDeleted = FridgeComponent.IsDeleted;

				result.Message = "Success";
				result.Data = FridgeComponentDTO;
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
		public ActionResult<ResultDTO> Put(int id, FridgeComponentDTO newFridgeComponent) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					FridgeComponent orgFridgeComponent = FridgeComponentRepo.getbyid(id);
					newFridgeComponent.Id = orgFridgeComponent.Id;
					orgFridgeComponent.Item = newFridgeComponent.Item;
					orgFridgeComponent.Quantity = newFridgeComponent.Quantity;
					orgFridgeComponent.ExpireDate = newFridgeComponent.ExpireDate;
					orgFridgeComponent.IsDeleted = newFridgeComponent.IsDeleted;


					FridgeComponentRepo.update(orgFridgeComponent);
					result.Message = "Success";
					result.Data = orgFridgeComponent;
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
		public ActionResult<ResultDTO> AddFridgeComponent(FridgeComponentDTO FridgeComponentDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					FridgeComponent FridgeComponent = new FridgeComponent();
					FridgeComponent.Id = FridgeComponentDTO.Id;
					FridgeComponent.Item = FridgeComponentDTO.Item;
					FridgeComponent.Quantity = FridgeComponentDTO.Quantity;
					FridgeComponent.ExpireDate = FridgeComponentDTO.ExpireDate;
					FridgeComponent.IsDeleted = FridgeComponentDTO.IsDeleted;

					FridgeComponentRepo.create(FridgeComponent);
					result.Data = FridgeComponentDTO;
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
				FridgeComponent FridgeComponent = FridgeComponentRepo.getbyid(id);
				FridgeComponent.IsDeleted = true;
				FridgeComponentRepo.update(FridgeComponent);
				result.Data = FridgeComponent;
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
