using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HSEEquipmentTableController : ControllerBase
	{
		public IRepository<HSEEquipmentTable> HSEEquipmentTableRepo { get; set; }

		public HSEEquipmentTableController(IRepository<HSEEquipmentTable> _HSEEquipmentTableRepo)
		{
			this.HSEEquipmentTableRepo = _HSEEquipmentTableRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<HSEEquipmentTable> temp = HSEEquipmentTableRepo.getall();
			List<HSEEquipmentTableDTO> newTemp = new List<HSEEquipmentTableDTO>();
			foreach (HSEEquipmentTable HSEEquipmentTable in temp)
			{
				HSEEquipmentTableDTO HSEEquipmentTableDTO = new HSEEquipmentTableDTO();
				HSEEquipmentTableDTO.Id = HSEEquipmentTable.Id;
				HSEEquipmentTableDTO.EquipmentId = HSEEquipmentTable.EquipmentId;
				HSEEquipmentTableDTO.Model = HSEEquipmentTable.Model;
				HSEEquipmentTableDTO.SerialNumber = HSEEquipmentTable.SerialNumber;
				HSEEquipmentTableDTO.ExpiryDate = HSEEquipmentTable.ExpiryDate;
				HSEEquipmentTableDTO.RigCertificatesId = HSEEquipmentTable.RigCertificatesId;
				HSEEquipmentTableDTO.IsDeleted = HSEEquipmentTable.IsDeleted;

				newTemp.Add(HSEEquipmentTableDTO);
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

		//	List<HSEEquipmentTable> temp = HSEEquipmentTableRepo.getall();
		//	List<HSEEquipmentTableExcelDTO> newTemp = new List<HSEEquipmentTableExcelDTO>();
		//	foreach (HSEEquipmentTable HSEEquipmentTable in temp)
		//	{
		//		HSEEquipmentTableExcelDTO HSEEquipmentTableDTO = new HSEEquipmentTableExcelDTO();
		//		HSEEquipmentTableDTO.Id = HSEEquipmentTable.Id;
		//		HSEEquipmentTableDTO.Name = HSEEquipmentTable.Name;

		//		newTemp.Add(HSEEquipmentTableDTO);
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
		public PageResult<HSEEquipmentTableDTO> GettAllHSEEquipmentTableByPage(int? page, int pagesize = 10)
		{
			List<HSEEquipmentTable> temp = HSEEquipmentTableRepo.getall();
			List<HSEEquipmentTableDTO> newTemp = new List<HSEEquipmentTableDTO>();
			foreach (HSEEquipmentTable HSEEquipmentTable in temp)
			{
				HSEEquipmentTableDTO HSEEquipmentTableDTO = new HSEEquipmentTableDTO();
				HSEEquipmentTableDTO.Id = HSEEquipmentTable.Id;
				HSEEquipmentTableDTO.EquipmentId = HSEEquipmentTable.EquipmentId;
				HSEEquipmentTableDTO.Model = HSEEquipmentTable.Model;
				HSEEquipmentTableDTO.SerialNumber = HSEEquipmentTable.SerialNumber;
				HSEEquipmentTableDTO.ExpiryDate = HSEEquipmentTable.ExpiryDate;
				HSEEquipmentTableDTO.RigCertificatesId = HSEEquipmentTable.RigCertificatesId;
				HSEEquipmentTableDTO.IsDeleted = HSEEquipmentTable.IsDeleted;

				newTemp.Add(HSEEquipmentTableDTO);
			}

			float countDetails = HSEEquipmentTableRepo.getall().Count();
			var result = new PageResult<HSEEquipmentTableDTO>
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
				HSEEquipmentTableDTO HSEEquipmentTableDTO = new HSEEquipmentTableDTO();
				HSEEquipmentTable HSEEquipmentTable = HSEEquipmentTableRepo.getbyid(ID);
				HSEEquipmentTableDTO.Id = HSEEquipmentTable.Id;
				HSEEquipmentTableDTO.EquipmentId = HSEEquipmentTable.EquipmentId;
				HSEEquipmentTableDTO.Model = HSEEquipmentTable.Model;
				HSEEquipmentTableDTO.SerialNumber = HSEEquipmentTable.SerialNumber;
				HSEEquipmentTableDTO.ExpiryDate = HSEEquipmentTable.ExpiryDate;
				HSEEquipmentTableDTO.RigCertificatesId = HSEEquipmentTable.RigCertificatesId;
				HSEEquipmentTableDTO.IsDeleted = HSEEquipmentTable.IsDeleted;

				result.Message = "Success";
				result.Data = HSEEquipmentTableDTO;
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
		public ActionResult<ResultDTO> Put(int id, HSEEquipmentTableDTO newHSEEquipmentTable) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					HSEEquipmentTable orgHSEEquipmentTable = HSEEquipmentTableRepo.getbyid(id);
					newHSEEquipmentTable.Id = orgHSEEquipmentTable.Id;
					orgHSEEquipmentTable.EquipmentId = newHSEEquipmentTable.EquipmentId;
					orgHSEEquipmentTable.Model = newHSEEquipmentTable.Model;
					orgHSEEquipmentTable.SerialNumber = newHSEEquipmentTable.SerialNumber;
					orgHSEEquipmentTable.ExpiryDate = newHSEEquipmentTable.ExpiryDate;
					orgHSEEquipmentTable.RigCertificatesId = newHSEEquipmentTable.RigCertificatesId;
					orgHSEEquipmentTable.IsDeleted = newHSEEquipmentTable.IsDeleted;


					HSEEquipmentTableRepo.update(orgHSEEquipmentTable);
					result.Message = "Success";
					result.Data = orgHSEEquipmentTable;
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
		public ActionResult<ResultDTO> AddHSEEquipmentTable(HSEEquipmentTableDTO HSEEquipmentTableDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					HSEEquipmentTable HSEEquipmentTable = new HSEEquipmentTable();
					HSEEquipmentTable.Id = HSEEquipmentTableDTO.Id;
					HSEEquipmentTable.EquipmentId = HSEEquipmentTableDTO.EquipmentId;
					HSEEquipmentTable.Model = HSEEquipmentTableDTO.Model;
					HSEEquipmentTable.SerialNumber = HSEEquipmentTableDTO.SerialNumber;
					HSEEquipmentTable.ExpiryDate = HSEEquipmentTableDTO.ExpiryDate;
					HSEEquipmentTable.RigCertificatesId = HSEEquipmentTableDTO.RigCertificatesId;
					HSEEquipmentTable.IsDeleted = HSEEquipmentTableDTO.IsDeleted;

					HSEEquipmentTableRepo.create(HSEEquipmentTable);
					result.Data = HSEEquipmentTableDTO;
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
				HSEEquipmentTable HSEEquipmentTable = HSEEquipmentTableRepo.getbyid(id);
				HSEEquipmentTable.IsDeleted = true;
				HSEEquipmentTableRepo.update(HSEEquipmentTable);
				result.Data = HSEEquipmentTable;
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
