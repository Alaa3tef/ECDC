using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VisitsController : ControllerBase
	{
		public IRepository<Visits> VisitsRepo { get; set; }

		public VisitsController(IRepository<Visits> _VisitsRepo)
		{
			this.VisitsRepo = _VisitsRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<Visits> temp = VisitsRepo.getall();
			List<VisitsDTO> newTemp = new List<VisitsDTO>();
			foreach (Visits Visits in temp)
			{
				VisitsDTO VisitsDTO = new VisitsDTO();
				VisitsDTO.Id = Visits.Id;
				VisitsDTO.Date = Visits.Date;
				VisitsDTO.VisitName = Visits.VisitName;
				VisitsDTO.IsDeleted = Visits.IsDeleted;

				newTemp.Add(VisitsDTO);
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

		//	List<Visits> temp = VisitsRepo.getall();
		//	List<VisitsExcelDTO> newTemp = new List<VisitsExcelDTO>();
		//	foreach (Visits Visits in temp)
		//	{
		//		VisitsExcelDTO VisitsDTO = new VisitsExcelDTO();
		//		VisitsDTO.Id = Visits.Id;
		//		VisitsDTO.Name = Visits.Name;

		//		newTemp.Add(VisitsDTO);
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
		//public PageResult<VisitsDTO> GettAllVisitsByPage(int? page, int pagesize = 10)
		//{
		//	List<Visits> temp = VisitsRepo.getall();
		//	List<VisitsDTO> newTemp = new List<VisitsDTO>();
		//	foreach (Visits Visits in temp)
		//	{
		//		VisitsDTO VisitsDTO = new VisitsDTO();
		//		VisitsDTO.Id = Visits.Id;
		//		VisitsDTO.Name = Visits.Name;
		//		VisitsDTO.IsDeleted = Visits.IsDeleted;

		//		newTemp.Add(VisitsDTO);
		//	}

		//	float countDetails = VisitsRepo.getall().Count();
		//	var result = new PageResult<VisitsDTO>
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
				VisitsDTO VisitsDTO = new VisitsDTO();
				Visits Visits = VisitsRepo.getbyid(ID);
				VisitsDTO.Id = Visits.Id;
				VisitsDTO.Date = Visits.Date;
				VisitsDTO.VisitName = Visits.VisitName;
				VisitsDTO.IsDeleted = Visits.IsDeleted;

				result.Message = "Success";
				result.Data = VisitsDTO;
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
		public ActionResult<ResultDTO> Put(int id, VisitsDTO newVisits) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					Visits orgVisits = VisitsRepo.getbyid(id);
					newVisits.Id = orgVisits.Id;
					orgVisits.Date = newVisits.Date;
					orgVisits.VisitName = newVisits.VisitName;
					orgVisits.IsDeleted = newVisits.IsDeleted;


					VisitsRepo.update(orgVisits);
					result.Message = "Success";
					result.Data = orgVisits;
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
		public ActionResult<ResultDTO> AddVisits(VisitsDTO VisitsDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					Visits Visits = new Visits();
					Visits.Id = VisitsDTO.Id;
					VisitsDTO.Date = Visits.Date;
					VisitsDTO.VisitName = Visits.VisitName;
					Visits.IsDeleted = VisitsDTO.IsDeleted;

					VisitsRepo.create(Visits);
					result.Data = Visits;
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
				Visits Visits = VisitsRepo.getbyid(id);
				Visits.IsDeleted = true;
				VisitsRepo.update(Visits);
				result.Data = Visits;
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
