using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RigCertForkliftController : ControllerBase
	{
		public IRepository<RigCertForklift> Forklift1Repo { get; set; }

		public RigCertForkliftController(IRepository<RigCertForklift> _Forklift1Repo)
		{
			this.Forklift1Repo = _Forklift1Repo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<RigCertForklift> temp = Forklift1Repo.getall();
			List<RigCertForkliftDTO> newTemp = new List<RigCertForkliftDTO>();
			foreach (RigCertForklift Forklift1 in temp)
			{
				RigCertForkliftDTO Forklift1DTO = new RigCertForkliftDTO();
				Forklift1DTO.Id = Forklift1.Id;
				Forklift1DTO.Model = Forklift1.Model;
				Forklift1DTO.Type = Forklift1.Type;
				Forklift1DTO.SerialNo = Forklift1.SerialNo	;
				Forklift1DTO.Capacity = Forklift1.Capacity;
				Forklift1DTO.LastExaminationDate = Forklift1.LastExaminationDate;
				Forklift1DTO.NextExaminationDate = Forklift1.NextExaminationDate;
				Forklift1DTO.RigCertificatesId = Forklift1.RigCertificatesId;
				Forklift1DTO.IsDeleted = Forklift1.IsDeleted;

				newTemp.Add(Forklift1DTO);
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

		//	List<Forklift1> temp = Forklift1Repo.getall();
		//	List<Forklift1ExcelDTO> newTemp = new List<Forklift1ExcelDTO>();
		//	foreach (Forklift1 Forklift1 in temp)
		//	{
		//		Forklift1ExcelDTO Forklift1DTO = new Forklift1ExcelDTO();
		//		Forklift1DTO.Id = Forklift1.Id;
		//		Forklift1DTO.Name = Forklift1.Name;

		//		newTemp.Add(Forklift1DTO);
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
		public PageResult<RigCertForkliftDTO> GettAllForklift1ByPage(int? page, int pagesize = 10)
		{
			List<RigCertForklift> temp = Forklift1Repo.getall();
			List<RigCertForkliftDTO> newTemp = new List<RigCertForkliftDTO>();
			foreach (RigCertForklift Forklift1 in temp)
			{
				RigCertForkliftDTO Forklift1DTO = new RigCertForkliftDTO();
				Forklift1DTO.Id = Forklift1.Id;
				Forklift1DTO.Model = Forklift1.Model;
				Forklift1DTO.Type = Forklift1.Type;
				Forklift1DTO.SerialNo = Forklift1.SerialNo;
				Forklift1DTO.Capacity = Forklift1.Capacity;
				Forklift1DTO.LastExaminationDate = Forklift1.LastExaminationDate;
				Forklift1DTO.NextExaminationDate = Forklift1.NextExaminationDate;
				Forklift1DTO.RigCertificatesId = Forklift1.RigCertificatesId;
				Forklift1DTO.IsDeleted = Forklift1.IsDeleted;

				newTemp.Add(Forklift1DTO);
			}

			float countDetails = Forklift1Repo.getall().Count();
			var result = new PageResult<RigCertForkliftDTO>
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
				RigCertForkliftDTO Forklift1DTO = new RigCertForkliftDTO();
				RigCertForklift Forklift1 = Forklift1Repo.getbyid(ID);
				Forklift1DTO.Id = Forklift1.Id;
				Forklift1DTO.Model = Forklift1.Model;
				Forklift1DTO.Type = Forklift1.Type;
				Forklift1DTO.SerialNo = Forklift1.SerialNo;
				Forklift1DTO.Capacity = Forklift1.Capacity;
				Forklift1DTO.LastExaminationDate = Forklift1.LastExaminationDate;
				Forklift1DTO.NextExaminationDate = Forklift1.NextExaminationDate;
				Forklift1DTO.RigCertificatesId = Forklift1.RigCertificatesId;
				Forklift1DTO.IsDeleted = Forklift1.IsDeleted;

				result.Message = "Success";
				result.Data = Forklift1DTO;
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
		public ActionResult<ResultDTO> Put(int id, RigCertForkliftDTO newForklift1) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					RigCertForklift orgForklift1 = Forklift1Repo.getbyid(id);
					newForklift1.Id = orgForklift1.Id;
					orgForklift1.Model = newForklift1.Model;
					orgForklift1.Type = newForklift1.Type;
					orgForklift1.SerialNo = newForklift1.SerialNo;
					orgForklift1.Capacity = newForklift1.Capacity;
					orgForklift1.LastExaminationDate = newForklift1.LastExaminationDate;
					orgForklift1.NextExaminationDate = newForklift1.NextExaminationDate;
					orgForklift1.RigCertificatesId = newForklift1.RigCertificatesId;
					orgForklift1.IsDeleted = newForklift1.IsDeleted;


					Forklift1Repo.update(orgForklift1);
					result.Message = "Success";
					result.Data = orgForklift1;
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
		public ActionResult<ResultDTO> AddForklift1(RigCertForkliftDTO Forklift1DTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					RigCertForklift Forklift1 = new RigCertForklift();
					Forklift1.Id = Forklift1DTO.Id;
					Forklift1.Model = Forklift1DTO.Model;
					Forklift1.Type = Forklift1DTO.Type;
					Forklift1.SerialNo = Forklift1DTO.SerialNo	;
					Forklift1.Capacity = Forklift1DTO.Capacity;
					Forklift1.LastExaminationDate = Forklift1DTO.LastExaminationDate;
					Forklift1.NextExaminationDate = Forklift1DTO.NextExaminationDate;
					Forklift1.RigCertificatesId = Forklift1DTO.RigCertificatesId;
					Forklift1.IsDeleted = Forklift1DTO.IsDeleted;

					Forklift1Repo.create(Forklift1);
					result.Data = Forklift1DTO;
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
				RigCertForklift Forklift1 = Forklift1Repo.getbyid(id);
				Forklift1.IsDeleted = true;
				Forklift1Repo.update(Forklift1);
				result.Data = Forklift1;
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
