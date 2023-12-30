using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StandardController : ControllerBase
	{
		public IRepository<Standard> StandardRepo { get; set; }

		public StandardController(IRepository<Standard> _StandardRepo)
		{
			this.StandardRepo = _StandardRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<Standard> temp = StandardRepo.getall();
			List<StandardDTO> newTemp = new List<StandardDTO>();
			foreach (Standard standard in temp)
			{
				StandardDTO standardDTO = new StandardDTO();
				standardDTO.Id = standard.Id;
				standardDTO.StandardName = standard.StandardName;
				standardDTO.IsDeleted = standard.IsDeleted;

				newTemp.Add(standardDTO);
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
		public PageResult<StandardDTO> GettAllStandardsByPage(int? page, int pagesize = 10)
		{
			List<Standard> temp = StandardRepo.getall();
			List<StandardDTO> newTemp = new List<StandardDTO>();
			foreach (Standard standard in temp)
			{
				StandardDTO standardDTO = new StandardDTO();
				standardDTO.Id = standard.Id;
				standardDTO.StandardName = standard.StandardName;
				standardDTO.IsDeleted = standard.IsDeleted;

				newTemp.Add(standardDTO);
			}

			float countDetails = StandardRepo.getall().Count();
			var result = new PageResult<StandardDTO>
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
				StandardDTO standardDTO = new StandardDTO();
				Standard standard = StandardRepo.getbyid(ID);
				standardDTO.Id = standard.Id;
				standardDTO.StandardName = standard.StandardName;
				standardDTO.IsDeleted = standard.IsDeleted;

				result.Message = "Success";
				result.Data = standardDTO;
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
		public ActionResult<ResultDTO> Put(int id, StandardDTO newStandard) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					Standard orgStandard = StandardRepo.getbyid(id);
					newStandard.Id = orgStandard.Id;
					orgStandard.StandardName = newStandard.StandardName;
					orgStandard.IsDeleted = newStandard.IsDeleted;


					StandardRepo.update(orgStandard);
					result.Message = "Success";
					result.Data = orgStandard;
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
		public ActionResult<ResultDTO> AddStandard(StandardDTO standardDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					Standard standard = new Standard();
					standard.Id = standardDTO.Id;
					standard.StandardName = standardDTO.StandardName;
					standard.IsDeleted = standardDTO.IsDeleted;

					StandardRepo.create(standard);
					result.Data = standardDTO;
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
				Standard standard = StandardRepo.getbyid(id);
				standard.IsDeleted = true;
				StandardRepo.update(standard);
				result.Data = standard;
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
