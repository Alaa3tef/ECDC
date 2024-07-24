using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ManRidingWinchController : ControllerBase
	{
		public IRepository<ManRidingWinch> ManRidingWinchRepo { get; set; }

		public ManRidingWinchController(IRepository<ManRidingWinch> _ManRidingWinchRepo)
		{
			this.ManRidingWinchRepo = _ManRidingWinchRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<ManRidingWinch> temp = ManRidingWinchRepo.getall();
			List<ManRidingWinchDTO> newTemp = new List<ManRidingWinchDTO>();
			foreach (ManRidingWinch ManRidingWinch in temp)
			{
				ManRidingWinchDTO ManRidingWinchDTO = new ManRidingWinchDTO();
				ManRidingWinchDTO.Id = ManRidingWinch.Id;
				ManRidingWinchDTO.SerialNo = ManRidingWinch.SerialNo;
				ManRidingWinchDTO.WireSize = ManRidingWinch.WireSize;
				ManRidingWinchDTO.Capacity = ManRidingWinch.Capacity;
				ManRidingWinchDTO.WireInspectionDueDate = ManRidingWinch.WireInspectionDueDate;
				ManRidingWinchDTO.LastMPIInspectionDate = ManRidingWinch.LastMPIInspectionDate;
				ManRidingWinchDTO.NextMPIInspectionDate = ManRidingWinch.NextMPIInspectionDate;
				ManRidingWinchDTO.NextLoadTestDate = ManRidingWinch.NextLoadTestDate;
				ManRidingWinchDTO.RigCertificatesId = ManRidingWinch.RigCertificatesId;
				ManRidingWinchDTO.IsDeleted = ManRidingWinch.IsDeleted;

				newTemp.Add(ManRidingWinchDTO);
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

		//	List<ManRidingWinch> temp = ManRidingWinchRepo.getall();
		//	List<ManRidingWinchExcelDTO> newTemp = new List<ManRidingWinchExcelDTO>();
		//	foreach (ManRidingWinch ManRidingWinch in temp)
		//	{
		//		ManRidingWinchExcelDTO ManRidingWinchDTO = new ManRidingWinchExcelDTO();
		//		ManRidingWinchDTO.Id = ManRidingWinch.Id;
		//		ManRidingWinchDTO.Name = ManRidingWinch.Name;

		//		newTemp.Add(ManRidingWinchDTO);
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
		public PageResult<ManRidingWinchDTO> GettAllManRidingWinchByPage(int? page, int pagesize = 10)
		{
			List<ManRidingWinch> temp = ManRidingWinchRepo.getall();
			List<ManRidingWinchDTO> newTemp = new List<ManRidingWinchDTO>();
			foreach (ManRidingWinch ManRidingWinch in temp)
			{
				ManRidingWinchDTO ManRidingWinchDTO = new ManRidingWinchDTO();
				ManRidingWinchDTO.Id = ManRidingWinch.Id;
				ManRidingWinchDTO.SerialNo = ManRidingWinch.SerialNo;
				ManRidingWinchDTO.WireSize = ManRidingWinch.WireSize;
				ManRidingWinchDTO.Capacity = ManRidingWinch.Capacity;
				ManRidingWinchDTO.WireInspectionDueDate = ManRidingWinch.WireInspectionDueDate;
				ManRidingWinchDTO.LastMPIInspectionDate = ManRidingWinch.LastMPIInspectionDate;
				ManRidingWinchDTO.NextMPIInspectionDate = ManRidingWinch.NextMPIInspectionDate;
				ManRidingWinchDTO.NextLoadTestDate = ManRidingWinch.NextLoadTestDate;
				ManRidingWinchDTO.RigCertificatesId = ManRidingWinch.RigCertificatesId;
				ManRidingWinchDTO.IsDeleted = ManRidingWinch.IsDeleted;

				newTemp.Add(ManRidingWinchDTO);
			}

			float countDetails = ManRidingWinchRepo.getall().Count();
			var result = new PageResult<ManRidingWinchDTO>
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
				ManRidingWinchDTO ManRidingWinchDTO = new ManRidingWinchDTO();
				ManRidingWinch ManRidingWinch = ManRidingWinchRepo.getbyid(ID);
				ManRidingWinchDTO.Id = ManRidingWinch.Id;
				ManRidingWinchDTO.SerialNo = ManRidingWinch.SerialNo;
				ManRidingWinchDTO.WireSize = ManRidingWinch.WireSize;
				ManRidingWinchDTO.Capacity = ManRidingWinch.Capacity;
				ManRidingWinchDTO.WireInspectionDueDate = ManRidingWinch.WireInspectionDueDate;
				ManRidingWinchDTO.LastMPIInspectionDate = ManRidingWinch.LastMPIInspectionDate;
				ManRidingWinchDTO.NextMPIInspectionDate = ManRidingWinch.NextMPIInspectionDate;
				ManRidingWinchDTO.NextLoadTestDate = ManRidingWinch.NextLoadTestDate;
				ManRidingWinchDTO.RigCertificatesId = ManRidingWinch.RigCertificatesId;
				ManRidingWinchDTO.IsDeleted = ManRidingWinch.IsDeleted;

				result.Message = "Success";
				result.Data = ManRidingWinchDTO;
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
		public ActionResult<ResultDTO> Put(int id, ManRidingWinchDTO newManRidingWinch) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					ManRidingWinch orgManRidingWinch = ManRidingWinchRepo.getbyid(id);
					newManRidingWinch.Id = orgManRidingWinch.Id;
					orgManRidingWinch.SerialNo = newManRidingWinch.SerialNo;
					orgManRidingWinch.WireSize = newManRidingWinch.WireSize;
					orgManRidingWinch.Capacity = newManRidingWinch.Capacity;
					orgManRidingWinch.WireInspectionDueDate = newManRidingWinch.WireInspectionDueDate;
					orgManRidingWinch.LastMPIInspectionDate = newManRidingWinch.LastMPIInspectionDate;
					orgManRidingWinch.NextMPIInspectionDate = newManRidingWinch.NextMPIInspectionDate;
					orgManRidingWinch.NextLoadTestDate = newManRidingWinch.NextLoadTestDate;
					orgManRidingWinch.RigCertificatesId = newManRidingWinch.RigCertificatesId;
					orgManRidingWinch.IsDeleted = newManRidingWinch.IsDeleted;


					ManRidingWinchRepo.update(orgManRidingWinch);
					result.Message = "Success";
					result.Data = orgManRidingWinch;
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
		public ActionResult<ResultDTO> AddManRidingWinch(ManRidingWinchDTO ManRidingWinchDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					ManRidingWinch ManRidingWinch = new ManRidingWinch();
					ManRidingWinch.Id = ManRidingWinchDTO.Id;
					ManRidingWinch.SerialNo = ManRidingWinchDTO.SerialNo;
					ManRidingWinch.WireSize = ManRidingWinchDTO.WireSize;
					ManRidingWinch.Capacity = ManRidingWinchDTO.Capacity;
					ManRidingWinch.WireInspectionDueDate = ManRidingWinchDTO.WireInspectionDueDate;
					ManRidingWinch.LastMPIInspectionDate = ManRidingWinchDTO.LastMPIInspectionDate;
					ManRidingWinch.NextMPIInspectionDate = ManRidingWinchDTO.NextMPIInspectionDate;
					ManRidingWinch.NextLoadTestDate = ManRidingWinchDTO.NextLoadTestDate;
					ManRidingWinch.RigCertificatesId = ManRidingWinchDTO.RigCertificatesId;
					ManRidingWinch.IsDeleted = ManRidingWinchDTO.IsDeleted;

					ManRidingWinchRepo.create(ManRidingWinch);
					result.Data = ManRidingWinchDTO;
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
				ManRidingWinch ManRidingWinch = ManRidingWinchRepo.getbyid(id);
				ManRidingWinch.IsDeleted = true;
				ManRidingWinchRepo.update(ManRidingWinch);
				result.Data = ManRidingWinch;
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
