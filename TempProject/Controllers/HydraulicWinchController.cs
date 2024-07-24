using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HydraulicWinchController : ControllerBase
	{
		public IRepository<HydraulicWinch> HydraulicWinch1Repo { get; set; }

		public HydraulicWinchController(IRepository<HydraulicWinch> _HydraulicWinch1Repo)
		{
			this.HydraulicWinch1Repo = _HydraulicWinch1Repo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<HydraulicWinch> temp = HydraulicWinch1Repo.getall();
			List<HydraulicWinchDTO> newTemp = new List<HydraulicWinchDTO>();
			foreach (HydraulicWinch HydraulicWinch1 in temp)
			{
				HydraulicWinchDTO HydraulicWinch1DTO = new HydraulicWinchDTO();
				HydraulicWinch1DTO.Id = HydraulicWinch1.Id;
				HydraulicWinch1DTO.SerialNo = HydraulicWinch1.SerialNo;
				HydraulicWinch1DTO.WireSize = HydraulicWinch1.WireSize;
				HydraulicWinch1DTO.Capacity = HydraulicWinch1.Capacity;
				HydraulicWinch1DTO.WireInspectionDueDate = HydraulicWinch1.WireInspectionDueDate;
				HydraulicWinch1DTO.LastMPIInspectionDate = HydraulicWinch1.LastMPIInspectionDate;
				HydraulicWinch1DTO.NextMPIInspectionDate = HydraulicWinch1.NextMPIInspectionDate;
				HydraulicWinch1DTO.NextLoadTestDate = HydraulicWinch1.NextLoadTestDate;
				HydraulicWinch1DTO.RigCertificatesId = HydraulicWinch1.RigCertificatesId;
				HydraulicWinch1DTO.IsDeleted = HydraulicWinch1.IsDeleted;

				newTemp.Add(HydraulicWinch1DTO);
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

		//	List<HydraulicWinch1> temp = HydraulicWinch1Repo.getall();
		//	List<HydraulicWinch1ExcelDTO> newTemp = new List<HydraulicWinch1ExcelDTO>();
		//	foreach (HydraulicWinch1 HydraulicWinch1 in temp)
		//	{
		//		HydraulicWinch1ExcelDTO HydraulicWinch1DTO = new HydraulicWinch1ExcelDTO();
		//		HydraulicWinch1DTO.Id = HydraulicWinch1.Id;
		//		HydraulicWinch1DTO.Name = HydraulicWinch1.Name;

		//		newTemp.Add(HydraulicWinch1DTO);
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
		public PageResult<HydraulicWinchDTO> GettAllHydraulicWinch1ByPage(int? page, int pagesize = 10)
		{
			List<HydraulicWinch> temp = HydraulicWinch1Repo.getall();
			List<HydraulicWinchDTO> newTemp = new List<HydraulicWinchDTO>();
			foreach (HydraulicWinch HydraulicWinch1 in temp)
			{
				HydraulicWinchDTO HydraulicWinch1DTO = new HydraulicWinchDTO();
				HydraulicWinch1DTO.Id = HydraulicWinch1.Id;
				HydraulicWinch1DTO.SerialNo = HydraulicWinch1.SerialNo;
				HydraulicWinch1DTO.WireSize = HydraulicWinch1.WireSize;
				HydraulicWinch1DTO.Capacity = HydraulicWinch1.Capacity;
				HydraulicWinch1DTO.WireInspectionDueDate = HydraulicWinch1.WireInspectionDueDate;
				HydraulicWinch1DTO.LastMPIInspectionDate = HydraulicWinch1.LastMPIInspectionDate;
				HydraulicWinch1DTO.NextMPIInspectionDate = HydraulicWinch1.NextMPIInspectionDate;
				HydraulicWinch1DTO.NextLoadTestDate = HydraulicWinch1.NextLoadTestDate;
				HydraulicWinch1DTO.RigCertificatesId = HydraulicWinch1.RigCertificatesId;
				HydraulicWinch1DTO.IsDeleted = HydraulicWinch1.IsDeleted;

				newTemp.Add(HydraulicWinch1DTO);
			}

			float countDetails = HydraulicWinch1Repo.getall().Count();
			var result = new PageResult<HydraulicWinchDTO>
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
				HydraulicWinchDTO HydraulicWinch1DTO = new HydraulicWinchDTO();
				HydraulicWinch HydraulicWinch1 = HydraulicWinch1Repo.getbyid(ID);
				HydraulicWinch1DTO.Id = HydraulicWinch1.Id;
				HydraulicWinch1DTO.SerialNo = HydraulicWinch1.SerialNo;
				HydraulicWinch1DTO.WireSize = HydraulicWinch1.WireSize;
				HydraulicWinch1DTO.Capacity = HydraulicWinch1.Capacity;
				HydraulicWinch1DTO.WireInspectionDueDate = HydraulicWinch1.WireInspectionDueDate;
				HydraulicWinch1DTO.LastMPIInspectionDate = HydraulicWinch1.LastMPIInspectionDate;
				HydraulicWinch1DTO.NextMPIInspectionDate = HydraulicWinch1.NextMPIInspectionDate;
				HydraulicWinch1DTO.NextLoadTestDate = HydraulicWinch1.NextLoadTestDate;
				HydraulicWinch1DTO.RigCertificatesId = HydraulicWinch1.RigCertificatesId;
				HydraulicWinch1DTO.IsDeleted = HydraulicWinch1.IsDeleted;

				result.Message = "Success";
				result.Data = HydraulicWinch1DTO;
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
		public ActionResult<ResultDTO> Put(int id, HydraulicWinchDTO newHydraulicWinch1) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					HydraulicWinch orgHydraulicWinch1 = HydraulicWinch1Repo.getbyid(id);
					newHydraulicWinch1.Id = orgHydraulicWinch1.Id;
					orgHydraulicWinch1.SerialNo = newHydraulicWinch1.SerialNo;
					orgHydraulicWinch1.WireSize = newHydraulicWinch1.WireSize;
					orgHydraulicWinch1.Capacity = newHydraulicWinch1.Capacity;
					orgHydraulicWinch1.WireInspectionDueDate = newHydraulicWinch1.WireInspectionDueDate;
					orgHydraulicWinch1.LastMPIInspectionDate = newHydraulicWinch1.LastMPIInspectionDate;
					orgHydraulicWinch1.NextMPIInspectionDate = newHydraulicWinch1.NextMPIInspectionDate;
					orgHydraulicWinch1.NextLoadTestDate = newHydraulicWinch1.NextLoadTestDate;
					orgHydraulicWinch1.RigCertificatesId = newHydraulicWinch1.RigCertificatesId;
					orgHydraulicWinch1.IsDeleted = newHydraulicWinch1.IsDeleted;


					HydraulicWinch1Repo.update(orgHydraulicWinch1);
					result.Message = "Success";
					result.Data = orgHydraulicWinch1;
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
		public ActionResult<ResultDTO> AddHydraulicWinch1(HydraulicWinchDTO HydraulicWinch1DTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					HydraulicWinch HydraulicWinch1 = new HydraulicWinch();
					HydraulicWinch1.Id = HydraulicWinch1DTO.Id;
					HydraulicWinch1.SerialNo = HydraulicWinch1DTO.SerialNo;
					HydraulicWinch1.WireSize = HydraulicWinch1DTO.WireSize;
					HydraulicWinch1.Capacity = HydraulicWinch1DTO.Capacity;
					HydraulicWinch1.WireInspectionDueDate = HydraulicWinch1DTO.WireInspectionDueDate;
					HydraulicWinch1.LastMPIInspectionDate = HydraulicWinch1DTO.LastMPIInspectionDate;
					HydraulicWinch1.NextMPIInspectionDate = HydraulicWinch1DTO.NextMPIInspectionDate;
					HydraulicWinch1.NextLoadTestDate = HydraulicWinch1DTO.NextLoadTestDate;
					HydraulicWinch1.RigCertificatesId = HydraulicWinch1DTO.RigCertificatesId;
					HydraulicWinch1.IsDeleted = HydraulicWinch1DTO.IsDeleted;

					HydraulicWinch1Repo.create(HydraulicWinch1);
					result.Data = HydraulicWinch1DTO;
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
				HydraulicWinch HydraulicWinch1 = HydraulicWinch1Repo.getbyid(id);
				HydraulicWinch1.IsDeleted = true;
				HydraulicWinch1Repo.update(HydraulicWinch1);
				result.Data = HydraulicWinch1;
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
