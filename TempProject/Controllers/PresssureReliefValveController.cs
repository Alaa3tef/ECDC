using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PresssureReliefValveController : ControllerBase
	{
		public IRepository<PresssureReliefValve> PresssureReliefValveRepo { get; set; }

		public PresssureReliefValveController(IRepository<PresssureReliefValve> _PresssureReliefValveRepo)
		{
			this.PresssureReliefValveRepo = _PresssureReliefValveRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<PresssureReliefValve> temp = PresssureReliefValveRepo.getall();
			List<PresssureReliefValveDTO> newTemp = new List<PresssureReliefValveDTO>();
			foreach (PresssureReliefValve PresssureReliefValve in temp)
			{
				PresssureReliefValveDTO PresssureReliefValveDTO = new PresssureReliefValveDTO();
				PresssureReliefValveDTO.Id = PresssureReliefValve.Id;
				PresssureReliefValveDTO.Valves = PresssureReliefValve.Valves;
				PresssureReliefValveDTO.Location = PresssureReliefValve.Location;
				PresssureReliefValveDTO.CertificationDate = PresssureReliefValve.CertificationDate;
				PresssureReliefValveDTO.ExpiryDate = PresssureReliefValve.ExpiryDate;
				PresssureReliefValveDTO.RigCertificatesId = PresssureReliefValve.RigCertificatesId;
				PresssureReliefValveDTO.IsDeleted = PresssureReliefValve.IsDeleted;

				newTemp.Add(PresssureReliefValveDTO);
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

		//	List<PresssureReliefValve> temp = PresssureReliefValveRepo.getall();
		//	List<PresssureReliefValveExcelDTO> newTemp = new List<PresssureReliefValveExcelDTO>();
		//	foreach (PresssureReliefValve PresssureReliefValve in temp)
		//	{
		//		PresssureReliefValveExcelDTO PresssureReliefValveDTO = new PresssureReliefValveExcelDTO();
		//		PresssureReliefValveDTO.Id = PresssureReliefValve.Id;
		//		PresssureReliefValveDTO.Name = PresssureReliefValve.Name;

		//		newTemp.Add(PresssureReliefValveDTO);
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
		public PageResult<PresssureReliefValveDTO> GettAllPresssureReliefValveByPage(int? page, int pagesize = 10)
		{
			List<PresssureReliefValve> temp = PresssureReliefValveRepo.getall();
			List<PresssureReliefValveDTO> newTemp = new List<PresssureReliefValveDTO>();
			foreach (PresssureReliefValve PresssureReliefValve in temp)
			{
				PresssureReliefValveDTO PresssureReliefValveDTO = new PresssureReliefValveDTO();
				PresssureReliefValveDTO.Id = PresssureReliefValve.Id;
				PresssureReliefValveDTO.Valves = PresssureReliefValve.Valves;
				PresssureReliefValveDTO.Location = PresssureReliefValve.Location;
				PresssureReliefValveDTO.CertificationDate = PresssureReliefValve.CertificationDate;
				PresssureReliefValveDTO.ExpiryDate = PresssureReliefValve.ExpiryDate;
				PresssureReliefValveDTO.RigCertificatesId = PresssureReliefValve.RigCertificatesId;
				PresssureReliefValveDTO.IsDeleted = PresssureReliefValve.IsDeleted;

				newTemp.Add(PresssureReliefValveDTO);
			}

			float countDetails = PresssureReliefValveRepo.getall().Count();
			var result = new PageResult<PresssureReliefValveDTO>
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
				PresssureReliefValveDTO PresssureReliefValveDTO = new PresssureReliefValveDTO();
				PresssureReliefValve PresssureReliefValve = PresssureReliefValveRepo.getbyid(ID);
				PresssureReliefValveDTO.Id = PresssureReliefValve.Id;
				PresssureReliefValveDTO.Valves = PresssureReliefValve.Valves;
				PresssureReliefValveDTO.Location = PresssureReliefValve.Location;
				PresssureReliefValveDTO.CertificationDate = PresssureReliefValve.CertificationDate;
				PresssureReliefValveDTO.ExpiryDate = PresssureReliefValve.ExpiryDate;
				PresssureReliefValveDTO.RigCertificatesId = PresssureReliefValve.RigCertificatesId;
				PresssureReliefValveDTO.IsDeleted = PresssureReliefValve.IsDeleted;

				result.Message = "Success";
				result.Data = PresssureReliefValveDTO;
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
		public ActionResult<ResultDTO> Put(int id, PresssureReliefValveDTO newPresssureReliefValve) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					PresssureReliefValve orgPresssureReliefValve = PresssureReliefValveRepo.getbyid(id);
					newPresssureReliefValve.Id = orgPresssureReliefValve.Id;
					orgPresssureReliefValve.Valves = newPresssureReliefValve.Valves;
					orgPresssureReliefValve.Location = newPresssureReliefValve.Location;
					orgPresssureReliefValve.CertificationDate = newPresssureReliefValve.CertificationDate;
					orgPresssureReliefValve.ExpiryDate = newPresssureReliefValve.ExpiryDate;
					orgPresssureReliefValve.RigCertificatesId = newPresssureReliefValve.RigCertificatesId;
					orgPresssureReliefValve.IsDeleted = newPresssureReliefValve.IsDeleted;


					PresssureReliefValveRepo.update(orgPresssureReliefValve);
					result.Message = "Success";
					result.Data = orgPresssureReliefValve;
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
		public ActionResult<ResultDTO> AddPresssureReliefValve(PresssureReliefValveDTO PresssureReliefValveDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					PresssureReliefValve PresssureReliefValve = new PresssureReliefValve();
					PresssureReliefValve.Id = PresssureReliefValveDTO.Id;
					PresssureReliefValve.Valves = PresssureReliefValveDTO.Valves;
					PresssureReliefValve.Location = PresssureReliefValveDTO.Location;
					PresssureReliefValve.CertificationDate = PresssureReliefValveDTO.CertificationDate;
					PresssureReliefValve.ExpiryDate = PresssureReliefValveDTO.ExpiryDate;
					PresssureReliefValve.RigCertificatesId = PresssureReliefValveDTO.RigCertificatesId;
					PresssureReliefValve.IsDeleted = PresssureReliefValveDTO.IsDeleted;

					PresssureReliefValveRepo.create(PresssureReliefValve);
					result.Data = PresssureReliefValveDTO;
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
				PresssureReliefValve PresssureReliefValve = PresssureReliefValveRepo.getbyid(id);
				PresssureReliefValve.IsDeleted = true;
				PresssureReliefValveRepo.update(PresssureReliefValve);
				result.Data = PresssureReliefValve;
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
