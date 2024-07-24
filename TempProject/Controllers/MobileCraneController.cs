using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MobileCraneController : ControllerBase
	{
		public IRepository<MobileCrane> MobileCrane1Repo { get; set; }

		public MobileCraneController(IRepository<MobileCrane> _MobileCrane1Repo)
		{
			this.MobileCrane1Repo = _MobileCrane1Repo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<MobileCrane> temp = MobileCrane1Repo.getall();
			List<MobileCraneDTO> newTemp = new List<MobileCraneDTO>();
			foreach (MobileCrane MobileCrane1 in temp)
			{
				MobileCraneDTO MobileCrane1DTO = new MobileCraneDTO();
				MobileCrane1DTO.Id = MobileCrane1.Id;
				MobileCrane1DTO.Model = MobileCrane1.Model;
				MobileCrane1DTO.Type = MobileCrane1.Type;
				MobileCrane1DTO.ChassisNo = MobileCrane1.ChassisNo;
				MobileCrane1DTO.HookSerialNo = MobileCrane1.HookSerialNo;
				MobileCrane1DTO.Capacity = MobileCrane1.Capacity;
				MobileCrane1DTO.ManufactureDate = MobileCrane1.ManufactureDate;
				MobileCrane1DTO.LastExaminationDate = MobileCrane1.LastExaminationDate;
				MobileCrane1DTO.NextExaminationDate = MobileCrane1.NextExaminationDate;
				MobileCrane1DTO.RigCertificatesId = MobileCrane1.RigCertificatesId;
				MobileCrane1DTO.IsDeleted = MobileCrane1.IsDeleted;

				newTemp.Add(MobileCrane1DTO);
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

		//	List<MobileCrane1> temp = MobileCrane1Repo.getall();
		//	List<MobileCrane1ExcelDTO> newTemp = new List<MobileCrane1ExcelDTO>();
		//	foreach (MobileCrane1 MobileCrane1 in temp)
		//	{
		//		MobileCrane1ExcelDTO MobileCrane1DTO = new MobileCrane1ExcelDTO();
		//		MobileCrane1DTO.Id = MobileCrane1.Id;
		//		MobileCrane1DTO.Name = MobileCrane1.Name;

		//		newTemp.Add(MobileCrane1DTO);
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
		public PageResult<MobileCraneDTO> GettAllMobileCrane1ByPage(int? page, int pagesize = 10)
		{
			List<MobileCrane> temp = MobileCrane1Repo.getall();
			List<MobileCraneDTO> newTemp = new List<MobileCraneDTO>();
			foreach (MobileCrane MobileCrane1 in temp)
			{
				MobileCraneDTO MobileCrane1DTO = new MobileCraneDTO();
				MobileCrane1DTO.Id = MobileCrane1.Id;
				MobileCrane1DTO.Model = MobileCrane1.Model;
				MobileCrane1DTO.Type = MobileCrane1.Type;
				MobileCrane1DTO.ChassisNo = MobileCrane1.ChassisNo;
				MobileCrane1DTO.HookSerialNo = MobileCrane1.HookSerialNo;
				MobileCrane1DTO.Capacity = MobileCrane1.Capacity;
				MobileCrane1DTO.ManufactureDate = MobileCrane1.ManufactureDate;
				MobileCrane1DTO.LastExaminationDate = MobileCrane1.LastExaminationDate;
				MobileCrane1DTO.NextExaminationDate = MobileCrane1.NextExaminationDate;
				MobileCrane1DTO.RigCertificatesId = MobileCrane1.RigCertificatesId;
				MobileCrane1DTO.IsDeleted = MobileCrane1.IsDeleted;

				newTemp.Add(MobileCrane1DTO);
			}

			float countDetails = MobileCrane1Repo.getall().Count();
			var result = new PageResult<MobileCraneDTO>
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
				MobileCraneDTO MobileCrane1DTO = new MobileCraneDTO();
				MobileCrane MobileCrane1 = MobileCrane1Repo.getbyid(ID);
				MobileCrane1DTO.Id = MobileCrane1.Id;
				MobileCrane1DTO.Model = MobileCrane1.Model;
				MobileCrane1DTO.Type = MobileCrane1.Type;
				MobileCrane1DTO.ChassisNo = MobileCrane1.ChassisNo;
				MobileCrane1DTO.HookSerialNo = MobileCrane1.HookSerialNo;
				MobileCrane1DTO.Capacity = MobileCrane1.Capacity;
				MobileCrane1DTO.ManufactureDate = MobileCrane1.ManufactureDate;
				MobileCrane1DTO.LastExaminationDate = MobileCrane1.LastExaminationDate;
				MobileCrane1DTO.NextExaminationDate = MobileCrane1.NextExaminationDate;
				MobileCrane1DTO.RigCertificatesId = MobileCrane1.RigCertificatesId;
				MobileCrane1DTO.IsDeleted = MobileCrane1.IsDeleted;

				result.Message = "Success";
				result.Data = MobileCrane1DTO;
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
		public ActionResult<ResultDTO> Put(int id, MobileCraneDTO newMobileCrane1) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					MobileCrane orgMobileCrane1 = MobileCrane1Repo.getbyid(id);
					newMobileCrane1.Id = orgMobileCrane1.Id;
					orgMobileCrane1.Model = newMobileCrane1.Model;
					orgMobileCrane1.Type = newMobileCrane1.Type;
					orgMobileCrane1.ChassisNo = newMobileCrane1.ChassisNo;
					orgMobileCrane1.HookSerialNo = newMobileCrane1.HookSerialNo;
					orgMobileCrane1.Capacity = newMobileCrane1.Capacity;
					orgMobileCrane1.ManufactureDate = newMobileCrane1.ManufactureDate;
					orgMobileCrane1.LastExaminationDate = newMobileCrane1.LastExaminationDate;
					orgMobileCrane1.NextExaminationDate = newMobileCrane1.NextExaminationDate;
					orgMobileCrane1.RigCertificatesId = newMobileCrane1.RigCertificatesId;
					orgMobileCrane1.IsDeleted = newMobileCrane1.IsDeleted;


					MobileCrane1Repo.update(orgMobileCrane1);
					result.Message = "Success";
					result.Data = orgMobileCrane1;
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
		public ActionResult<ResultDTO> AddMobileCrane1(MobileCraneDTO MobileCrane1DTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					MobileCrane MobileCrane1 = new MobileCrane();
					MobileCrane1.Id = MobileCrane1DTO.Id;
					MobileCrane1.Model = MobileCrane1DTO.Model;
					MobileCrane1.Type = MobileCrane1DTO.Type;
					MobileCrane1.ChassisNo = MobileCrane1DTO.ChassisNo;
					MobileCrane1.HookSerialNo = MobileCrane1DTO.HookSerialNo;
					MobileCrane1.Capacity = MobileCrane1DTO.Capacity;
					MobileCrane1.ManufactureDate = MobileCrane1DTO.ManufactureDate;
					MobileCrane1.LastExaminationDate = MobileCrane1DTO.LastExaminationDate;
					MobileCrane1.NextExaminationDate = MobileCrane1DTO.NextExaminationDate;
					MobileCrane1.RigCertificatesId = MobileCrane1DTO.RigCertificatesId;
					MobileCrane1.IsDeleted = MobileCrane1DTO.IsDeleted;

					MobileCrane1Repo.create(MobileCrane1);
					result.Data = MobileCrane1DTO;
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
				MobileCrane MobileCrane1 = MobileCrane1Repo.getbyid(id);
				MobileCrane1.IsDeleted = true;
				MobileCrane1Repo.update(MobileCrane1);
				result.Data = MobileCrane1;
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
