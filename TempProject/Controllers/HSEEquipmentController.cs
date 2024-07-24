using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HSEEquipmentController : ControllerBase
	{
		public IRepository<HSEEquipment> HSEEquipmentRepo { get; set; }

		public HSEEquipmentController(IRepository<HSEEquipment> _HSEEquipmentRepo)
		{
			this.HSEEquipmentRepo = _HSEEquipmentRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<HSEEquipment> temp = HSEEquipmentRepo.getall();
			List<HSEEquipmentDTO> newTemp = new List<HSEEquipmentDTO>();
			foreach (HSEEquipment HSEEquipment in temp)
			{
				HSEEquipmentDTO HSEEquipmentDTO = new HSEEquipmentDTO();
				HSEEquipmentDTO.Id = HSEEquipment.Id;
				HSEEquipmentDTO.Item = HSEEquipment.Item;
				HSEEquipmentDTO.OnSite = HSEEquipment.OnSite;
				HSEEquipmentDTO.SentForMaintenance = HSEEquipment.SentForMaintenance;
				HSEEquipmentDTO.IsDeleted = HSEEquipment.IsDeleted;

				newTemp.Add(HSEEquipmentDTO);
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

		//	List<HSEEquipment> temp = HSEEquipmentRepo.getall();
		//	List<HSEEquipmentExcelDTO> newTemp = new List<HSEEquipmentExcelDTO>();
		//	foreach (HSEEquipment HSEEquipment in temp)
		//	{
		//		HSEEquipmentExcelDTO HSEEquipmentDTO = new HSEEquipmentExcelDTO();
		//		HSEEquipmentDTO.Id = HSEEquipment.Id;
		//		HSEEquipmentDTO.Name = HSEEquipment.Name;

		//		newTemp.Add(HSEEquipmentDTO);
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
		//public PageResult<HSEEquipmentDTO> GettAllHSEEquipmentByPage(int? page, int pagesize = 10)
		//{
		//	List<HSEEquipment> temp = HSEEquipmentRepo.getall();
		//	List<HSEEquipmentDTO> newTemp = new List<HSEEquipmentDTO>();
		//	foreach (HSEEquipment HSEEquipment in temp)
		//	{
		//		HSEEquipmentDTO HSEEquipmentDTO = new HSEEquipmentDTO();
		//		HSEEquipmentDTO.Id = HSEEquipment.Id;
		//		HSEEquipmentDTO.Name = HSEEquipment.Name;
		//		HSEEquipmentDTO.IsDeleted = HSEEquipment.IsDeleted;

		//		newTemp.Add(HSEEquipmentDTO);
		//	}

		//	float countDetails = HSEEquipmentRepo.getall().Count();
		//	var result = new PageResult<HSEEquipmentDTO>
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
				HSEEquipmentDTO HSEEquipmentDTO = new HSEEquipmentDTO();
				HSEEquipment HSEEquipment = HSEEquipmentRepo.getbyid(ID);
				HSEEquipmentDTO.Id = HSEEquipment.Id;
				HSEEquipmentDTO.Item = HSEEquipment.Item;
				HSEEquipmentDTO.OnSite = HSEEquipment.OnSite;
				HSEEquipmentDTO.SentForMaintenance = HSEEquipment.SentForMaintenance;
				HSEEquipmentDTO.IsDeleted = HSEEquipment.IsDeleted;

				result.Message = "Success";
				result.Data = HSEEquipmentDTO;
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
		public ActionResult<ResultDTO> Put(int id, HSEEquipmentDTO newHSEEquipment) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					HSEEquipment orgHSEEquipment = HSEEquipmentRepo.getbyid(id);
					newHSEEquipment.Id = orgHSEEquipment.Id;
					orgHSEEquipment.Item = newHSEEquipment.Item;
					orgHSEEquipment.OnSite = newHSEEquipment.OnSite;
					orgHSEEquipment.SentForMaintenance = newHSEEquipment.SentForMaintenance;
					orgHSEEquipment.IsDeleted = newHSEEquipment.IsDeleted;


					HSEEquipmentRepo.update(orgHSEEquipment);
					result.Message = "Success";
					result.Data = orgHSEEquipment;
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
		public ActionResult<ResultDTO> AddHSEEquipment(HSEEquipmentDTO HSEEquipmentDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					HSEEquipment HSEEquipment = new HSEEquipment();
					HSEEquipment.Id = HSEEquipmentDTO.Id;
					HSEEquipment.Item = HSEEquipmentDTO.Item;
					HSEEquipment.OnSite = HSEEquipmentDTO.OnSite;
					HSEEquipment.SentForMaintenance = HSEEquipmentDTO.SentForMaintenance;
					HSEEquipment.IsDeleted = HSEEquipmentDTO.IsDeleted;

					HSEEquipmentRepo.create(HSEEquipment);
					result.Data = HSEEquipment;
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
				HSEEquipment HSEEquipment = HSEEquipmentRepo.getbyid(id);
				HSEEquipment.IsDeleted = true;
				HSEEquipmentRepo.update(HSEEquipment);
				result.Data = HSEEquipment;
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
