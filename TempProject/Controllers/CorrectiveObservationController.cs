using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CorrectiveObservationController : ControllerBase
	{
		public IRepository<CorrectiveActionObservation> CorrectiveObservationRepo { get; set; }

		public CorrectiveObservationController(IRepository<CorrectiveActionObservation> _CorrectiveObservationRepo)
		{
			this.CorrectiveObservationRepo = _CorrectiveObservationRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<CorrectiveActionObservation> temp = CorrectiveObservationRepo.getall();
			List<CorrectiveObservationDTO> newTemp = new List<CorrectiveObservationDTO>();
			foreach (CorrectiveActionObservation CorrectiveObservation in temp)
			{
				CorrectiveObservationDTO CorrectiveObservationDTO = new CorrectiveObservationDTO();
				CorrectiveObservationDTO.Id = CorrectiveObservation.Id;
				CorrectiveObservationDTO.Observation = CorrectiveObservation.Observation;
				CorrectiveObservationDTO.IsDeleted = CorrectiveObservation.IsDeleted;

				newTemp.Add(CorrectiveObservationDTO);
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
		public PageResult<CorrectiveObservationDTO> GettAllCorrectiveObservationsByPage(int? page, int pagesize = 10)
		{
			List<CorrectiveActionObservation> temp = CorrectiveObservationRepo.getall();
			List<CorrectiveObservationDTO> newTemp = new List<CorrectiveObservationDTO>();
			foreach (CorrectiveActionObservation CorrectiveObservation in temp)
			{
				CorrectiveObservationDTO CorrectiveObservationDTO = new CorrectiveObservationDTO();
				CorrectiveObservationDTO.Id = CorrectiveObservation.Id;
				CorrectiveObservationDTO.Observation = CorrectiveObservation.Observation;
				CorrectiveObservationDTO.IsDeleted = CorrectiveObservation.IsDeleted;

				newTemp.Add(CorrectiveObservationDTO);
			}

			float countDetails = CorrectiveObservationRepo.getall().Count();
			var result = new PageResult<CorrectiveObservationDTO>
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
				CorrectiveObservationDTO CorrectiveObservationDTO = new CorrectiveObservationDTO();
				CorrectiveActionObservation CorrectiveObservation = CorrectiveObservationRepo.getbyid(ID);
				CorrectiveObservationDTO.Id = CorrectiveObservation.Id;
				CorrectiveObservationDTO.Observation = CorrectiveObservation.Observation;
				CorrectiveObservationDTO.IsDeleted = CorrectiveObservation.IsDeleted;

				result.Message = "Success";
				result.Data = CorrectiveObservationDTO;
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
		public ActionResult<ResultDTO> Put(int id, CorrectiveObservationDTO newCorrectiveObservation) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					CorrectiveActionObservation orgCorrectiveObservation = CorrectiveObservationRepo.getbyid(id);
					newCorrectiveObservation.Id = orgCorrectiveObservation.Id;
					orgCorrectiveObservation.Observation = newCorrectiveObservation.Observation;
					orgCorrectiveObservation.IsDeleted = newCorrectiveObservation.IsDeleted;


					CorrectiveObservationRepo.update(orgCorrectiveObservation);
					result.Message = "Success";
					result.Data = orgCorrectiveObservation;
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
		public ActionResult<ResultDTO> AddCorrectiveObservation(CorrectiveObservationDTO CorrectiveObservationDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					CorrectiveActionObservation CorrectiveObservation = new CorrectiveActionObservation();
					CorrectiveObservation.Id = CorrectiveObservationDTO.Id;
					CorrectiveObservation.Observation = CorrectiveObservationDTO.Observation;
					CorrectiveObservation.IsDeleted = CorrectiveObservationDTO.IsDeleted;

					CorrectiveObservationRepo.create(CorrectiveObservation);
					result.Data = CorrectiveObservationDTO;
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
				CorrectiveActionObservation CorrectiveObservation = CorrectiveObservationRepo.getbyid(id);
				CorrectiveObservation.IsDeleted = true;
				CorrectiveObservationRepo.update(CorrectiveObservation);
				result.Data = CorrectiveObservation;
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
