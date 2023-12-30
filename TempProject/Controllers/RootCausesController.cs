using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RootCausesController : ControllerBase
	{
		public IRepository<RootCauses> RootCausesRepo { get; set; }

		public RootCausesController(IRepository<RootCauses> _RootCausesRepo)
		{
			this.RootCausesRepo = _RootCausesRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<RootCauses> temp = RootCausesRepo.getall();
			List<RootCausesDTO> newTemp = new List<RootCausesDTO>();
			foreach (RootCauses RootCauses in temp)
			{
				RootCausesDTO RootCausesDTO = new RootCausesDTO();
				RootCausesDTO.Id = RootCauses.Id;
				RootCausesDTO.CauseName = RootCauses.CauseName;
				RootCausesDTO.IsDeleted = RootCauses.IsDeleted;

				newTemp.Add(RootCausesDTO);
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

		//	List<AccidentCauses> temp = AccidentCausesRepo.getall();
		//	List<AccidentCausesExcelDTO> newTemp = new List<AccidentCausesExcelDTO>();
		//	foreach (AccidentCauses accidentCauses in temp)
		//	{
		//		AccidentCausesExcelDTO accidentCausesDTO = new AccidentCausesExcelDTO();
		//		accidentCausesDTO.Id = accidentCauses.Id;
		//		accidentCausesDTO.Name = accidentCauses.Name;

		//		newTemp.Add(accidentCausesDTO);
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
		public PageResult<RootCausesDTO> GettAllRootCausessByPage(int? page, int pagesize = 10)
		{
			List<RootCauses> temp = RootCausesRepo.getall();
			List<RootCausesDTO> newTemp = new List<RootCausesDTO>();
			foreach (RootCauses RootCauses in temp)
			{
				RootCausesDTO RootCausesDTO = new RootCausesDTO();
				RootCausesDTO.Id = RootCauses.Id;
				RootCausesDTO.CauseName = RootCauses.CauseName;
				RootCausesDTO.IsDeleted = RootCauses.IsDeleted;

				newTemp.Add(RootCausesDTO);
			}

			float countDetails = RootCausesRepo.getall().Count();
			var result = new PageResult<RootCausesDTO>
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
				RootCausesDTO RootCausesDTO = new RootCausesDTO();
				RootCauses RootCauses = RootCausesRepo.getbyid(ID);
				RootCausesDTO.Id = RootCauses.Id;
				RootCausesDTO.CauseName = RootCauses.CauseName;
				RootCausesDTO.IsDeleted = RootCauses.IsDeleted;

				result.Message = "Success";
				result.Data = RootCausesDTO;
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
		public ActionResult<ResultDTO> Put(int id, RootCausesDTO newRootCauses) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					RootCauses orgRootCauses = RootCausesRepo.getbyid(id);
					newRootCauses.Id = orgRootCauses.Id;
					orgRootCauses.CauseName = newRootCauses.CauseName;
					orgRootCauses.IsDeleted = newRootCauses.IsDeleted;


					RootCausesRepo.update(orgRootCauses);
					result.Message = "Success";
					result.Data = orgRootCauses;
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
		public ActionResult<ResultDTO> AddRootCauses(RootCausesDTO RootCausesDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					RootCauses RootCauses = new RootCauses();
					RootCauses.Id = RootCausesDTO.Id;
					RootCauses.CauseName = RootCausesDTO.CauseName;
					RootCauses.IsDeleted = RootCausesDTO.IsDeleted;

					RootCausesRepo.create(RootCauses);
					result.Data = RootCausesDTO;
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
				RootCauses RootCauses = RootCausesRepo.getbyid(id);
				RootCauses.IsDeleted = true;
				RootCausesRepo.update(RootCauses);
				result.Data = RootCauses;
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
