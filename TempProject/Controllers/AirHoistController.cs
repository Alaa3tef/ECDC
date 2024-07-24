using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AirHoistController : ControllerBase
	{
		public IRepository<AirHoist> AirHoistRepo { get; set; }

		public AirHoistController(IRepository<AirHoist> _AirHoistRepo)
		{
			this.AirHoistRepo = _AirHoistRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<AirHoist> temp = AirHoistRepo.getall();
			List<AirHoistDTO> newTemp = new List<AirHoistDTO>();
			foreach (AirHoist AirHoist in temp)
			{
				AirHoistDTO AirHoistDTO = new AirHoistDTO();
				AirHoistDTO.Id = AirHoist.Id;
				AirHoistDTO.SerialNo = AirHoist.SerialNo;
				AirHoistDTO.WireSize = AirHoist.WireSize;
				AirHoistDTO.Capacity = AirHoist.Capacity;
				AirHoistDTO.WireInspectionDueDate = AirHoist.WireInspectionDueDate;
				AirHoistDTO.LastMPIInspectionDate = AirHoist.LastMPIInspectionDate;
				AirHoistDTO.NextMPIInspectionDate = AirHoist.NextMPIInspectionDate;
				AirHoistDTO.NextLoadTestDate = AirHoist.NextLoadTestDate;
				AirHoistDTO.RigCertificatesId = AirHoist.RigCertificatesId;
				AirHoistDTO.IsDeleted = AirHoist.IsDeleted;

				newTemp.Add(AirHoistDTO);
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

		//	List<AirHoist> temp = AirHoistRepo.getall();
		//	List<AirHoistExcelDTO> newTemp = new List<AirHoistExcelDTO>();
		//	foreach (AirHoist AirHoist in temp)
		//	{
		//		AirHoistExcelDTO AirHoistDTO = new AirHoistExcelDTO();
		//		AirHoistDTO.Id = AirHoist.Id;
		//		AirHoistDTO.Name = AirHoist.Name;

		//		newTemp.Add(AirHoistDTO);
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
		public PageResult<AirHoistDTO> GettAllAirHoistByPage(int? page, int pagesize = 10)
		{
			List<AirHoist> temp = AirHoistRepo.getall();
			List<AirHoistDTO> newTemp = new List<AirHoistDTO>();
			foreach (AirHoist AirHoist in temp)
			{
				AirHoistDTO AirHoistDTO = new AirHoistDTO();
				AirHoistDTO.Id = AirHoist.Id;
				AirHoistDTO.SerialNo = AirHoist.SerialNo;
				AirHoistDTO.WireSize = AirHoist.WireSize;
				AirHoistDTO.Capacity = AirHoist.Capacity;
				AirHoistDTO.WireInspectionDueDate = AirHoist.WireInspectionDueDate;
				AirHoistDTO.LastMPIInspectionDate = AirHoist.LastMPIInspectionDate;
				AirHoistDTO.NextMPIInspectionDate = AirHoist.NextMPIInspectionDate;
				AirHoistDTO.NextLoadTestDate = AirHoist.NextLoadTestDate;
				AirHoistDTO.RigCertificatesId = AirHoist.RigCertificatesId;
				AirHoistDTO.IsDeleted = AirHoist.IsDeleted;

				newTemp.Add(AirHoistDTO);
			}

			float countDetails = AirHoistRepo.getall().Count();
			var result = new PageResult<AirHoistDTO>
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
				AirHoistDTO AirHoistDTO = new AirHoistDTO();
				AirHoist AirHoist = AirHoistRepo.getbyid(ID);
				AirHoistDTO.Id = AirHoist.Id;
				AirHoistDTO.SerialNo = AirHoist.SerialNo;
				AirHoistDTO.WireSize = AirHoist.WireSize;
				AirHoistDTO.Capacity = AirHoist.Capacity;
				AirHoistDTO.WireInspectionDueDate = AirHoist.WireInspectionDueDate;
				AirHoistDTO.LastMPIInspectionDate = AirHoist.LastMPIInspectionDate;
				AirHoistDTO.NextMPIInspectionDate = AirHoist.NextMPIInspectionDate;
				AirHoistDTO.NextLoadTestDate = AirHoist.NextLoadTestDate;
				AirHoistDTO.RigCertificatesId = AirHoist.RigCertificatesId;
				AirHoistDTO.IsDeleted = AirHoist.IsDeleted;

				result.Message = "Success";
				result.Data = AirHoistDTO;
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
		public ActionResult<ResultDTO> Put(int id, AirHoistDTO newAirHoist) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					AirHoist orgAirHoist = AirHoistRepo.getbyid(id);
					newAirHoist.Id = orgAirHoist.Id;
					orgAirHoist.SerialNo = newAirHoist.SerialNo;
					orgAirHoist.WireSize = newAirHoist.WireSize;
					orgAirHoist.Capacity = newAirHoist.Capacity;
					orgAirHoist.WireInspectionDueDate = newAirHoist.WireInspectionDueDate;
					orgAirHoist.LastMPIInspectionDate = newAirHoist.LastMPIInspectionDate;
					orgAirHoist.NextMPIInspectionDate = newAirHoist.NextMPIInspectionDate;
					orgAirHoist.NextLoadTestDate = newAirHoist.NextLoadTestDate;
					orgAirHoist.RigCertificatesId = newAirHoist.RigCertificatesId;
					orgAirHoist.IsDeleted = newAirHoist.IsDeleted;


					AirHoistRepo.update(orgAirHoist);
					result.Message = "Success";
					result.Data = orgAirHoist;
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
		public ActionResult<ResultDTO> AddAirHoist(AirHoistDTO AirHoistDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					AirHoist AirHoist = new AirHoist();
					AirHoist.Id = AirHoistDTO.Id;
					AirHoist.SerialNo = AirHoistDTO.SerialNo;
					AirHoist.WireSize = AirHoistDTO.WireSize;
					AirHoist.Capacity = AirHoistDTO.Capacity;
					AirHoist.WireInspectionDueDate = AirHoistDTO.WireInspectionDueDate;
					AirHoist.LastMPIInspectionDate = AirHoistDTO.LastMPIInspectionDate;
					AirHoist.NextMPIInspectionDate = AirHoistDTO.NextMPIInspectionDate;
					AirHoist.NextLoadTestDate = AirHoistDTO.NextLoadTestDate;
					AirHoist.RigCertificatesId = AirHoistDTO.RigCertificatesId;
					AirHoist.IsDeleted = AirHoistDTO.IsDeleted;

					AirHoistRepo.create(AirHoist);
					result.Data = AirHoistDTO;
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
				AirHoist AirHoist = AirHoistRepo.getbyid(id);
				AirHoist.IsDeleted = true;
				AirHoistRepo.update(AirHoist);
				result.Data = AirHoist;
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
