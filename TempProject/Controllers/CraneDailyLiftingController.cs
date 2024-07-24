using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.DTO.ResponseDTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CraneDailyLiftingController : ControllerBase
	{
		public IRepository<CraneDailyLifting> CraneDailyLiftingRepo { get; set; }
		
		public ICraneDailyLiftingRepository CraneDailyLiftingRepository { get; set; }

		public CraneDailyLiftingController(IRepository<CraneDailyLifting> _CraneDailyLiftingRepo, ICraneDailyLiftingRepository _CraneDailyLiftingRepository)
		{
	
			this.CraneDailyLiftingRepo = _CraneDailyLiftingRepo;
			this.CraneDailyLiftingRepository= _CraneDailyLiftingRepository;
		}
		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<CraneDailyLifting> temp = CraneDailyLiftingRepo.getall();
			List<CraneDailyLiftingDTO> newTemp = new List<CraneDailyLiftingDTO>();
			foreach (CraneDailyLifting CraneDailyLifting in temp)
			{
				CraneDailyLiftingDTO CraneDailyLiftingDTO = new CraneDailyLiftingDTO();
				CraneDailyLiftingDTO.Id = CraneDailyLifting.Id;
				CraneDailyLiftingDTO.Type = CraneDailyLifting.Type;
				CraneDailyLiftingDTO.ChasisNo = CraneDailyLifting.ChasisNo;
				CraneDailyLiftingDTO.Capacity = CraneDailyLifting.Capacity;
				CraneDailyLiftingDTO.IsDeleted = CraneDailyLifting.IsDeleted;
				CraneDailyLiftingDTO.DateofNextInspection = CraneDailyLifting.DateofNextInspection;
                CraneDailyLiftingDTO.DateofLastInspection = CraneDailyLifting.DateofLastInspection;

                CraneDailyLiftingDTO.MobileCraneName = CraneDailyLifting.MobileCraneName;
				newTemp.Add(CraneDailyLiftingDTO);
			}
			if (newTemp != null)
			{

				result.Message = "Success";
				result.Statescode = 200;
				result.Data = newTemp;

				return result;
			}

			result.Statescode = 404;
			result.Message = "data not found";
			return result;

		}

		[HttpGet("GetAllForExcel")]
		public ActionResult<ResultDTO> GetAllForExcel()
		{

			ResultDTO result = new ResultDTO();

			List<CraneDailyLifting> temp = CraneDailyLiftingRepository.getall();
			List<CraneDailyLiftingExcelDTO> newTemp = new List<CraneDailyLiftingExcelDTO>();
			foreach (CraneDailyLifting CraneDailyLifting in temp)
			{
				CraneDailyLiftingExcelDTO CraneDailyLiftingDTO = new CraneDailyLiftingExcelDTO();
				CraneDailyLiftingDTO.Id = CraneDailyLifting.Id;
                CraneDailyLiftingDTO.Type = CraneDailyLifting.Type;
                CraneDailyLiftingDTO.ChasisNo = CraneDailyLifting.ChasisNo;
                CraneDailyLiftingDTO.Capacity = CraneDailyLifting.Capacity;
                CraneDailyLiftingDTO.DateofNextInspection = CraneDailyLifting.DateofNextInspection;
                CraneDailyLiftingDTO.MobileCraneName = CraneDailyLifting.MobileCraneName;

                newTemp.Add(CraneDailyLiftingDTO);
			}
			if (newTemp != null)
			{

				result.Message = "Success";
				result.Statescode = 200;
				result.Data = newTemp;

				return result;
			}

			result.Statescode = 404;
			result.Message = "data not found";
			return result;

		}

		[HttpGet("ByPage/{page:int}")]
		public PageResult<CraneDailyLiftingDTO> GettAllCraneDailyLiftingByPage(int? page, int pagesize = 10)
		{
			List<CraneDailyLifting> temp = CraneDailyLiftingRepo.getall();
			List<CraneDailyLiftingDTO> newTemp = new List<CraneDailyLiftingDTO>();
			foreach (CraneDailyLifting CraneDailyLifting in temp)
			{
				CraneDailyLiftingDTO CraneDailyLiftingDTO = new CraneDailyLiftingDTO();
				CraneDailyLiftingDTO.Id = CraneDailyLifting.Id;
                CraneDailyLiftingDTO.Type = CraneDailyLifting.Type;
                CraneDailyLiftingDTO.ChasisNo = CraneDailyLifting.ChasisNo;
                CraneDailyLiftingDTO.Capacity = CraneDailyLifting.Capacity;
                CraneDailyLiftingDTO.IsDeleted = CraneDailyLifting.IsDeleted;
                CraneDailyLiftingDTO.DateofNextInspection = CraneDailyLifting.DateofNextInspection;
                CraneDailyLiftingDTO.MobileCraneName = CraneDailyLifting.MobileCraneName;
                newTemp.Add(CraneDailyLiftingDTO);
			}

			float countDetails = CraneDailyLiftingRepo.getall().Count();
			var result = new PageResult<CraneDailyLiftingDTO>
			{
				Count = (int)Math.Ceiling(countDetails / pagesize),
				PageIndex = page ?? 1,
				PageSize = pagesize,
				Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
			};
			return result;
		}

		[HttpGet("MobileCrane")]
		public ActionResult<ResultDTO> GetByMobileCrane(string MobileCraneName)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				CraneDailyLiftingDTO CraneDailyLiftingDTO = new CraneDailyLiftingDTO();
				//////
				CraneDailyLifting MobileCraneNameString = CraneDailyLiftingRepo.getall().FirstOrDefault(c => c.MobileCraneName == MobileCraneName);
				CraneDailyLiftingDTO.Id = MobileCraneNameString.Id;
                CraneDailyLiftingDTO.Type = MobileCraneNameString.Type;
                CraneDailyLiftingDTO.ChasisNo = MobileCraneNameString.ChasisNo;
                CraneDailyLiftingDTO.Capacity = MobileCraneNameString.Capacity;
                CraneDailyLiftingDTO.IsDeleted = MobileCraneNameString.IsDeleted;
                CraneDailyLiftingDTO.DateofNextInspection = MobileCraneNameString.DateofNextInspection;
                CraneDailyLiftingDTO.DateofLastInspection = MobileCraneNameString.DateofLastInspection;
                CraneDailyLiftingDTO.MobileCraneName = MobileCraneNameString.MobileCraneName;

                result.Data = CraneDailyLiftingDTO;
				result.Message = "Success";
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
		public ActionResult<ResultDTO> Put(int id, CraneDailyLiftingDTO newCraneDailyLiftingDTO) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					CraneDailyLifting orgCraneDailyLifting = CraneDailyLiftingRepo.getbyid(id);
					newCraneDailyLiftingDTO.Id = orgCraneDailyLifting.Id;
                    orgCraneDailyLifting.Type = newCraneDailyLiftingDTO.Type;
                    orgCraneDailyLifting.ChasisNo = newCraneDailyLiftingDTO.ChasisNo;
                    orgCraneDailyLifting.Capacity = newCraneDailyLiftingDTO.Capacity;
                    orgCraneDailyLifting.IsDeleted = newCraneDailyLiftingDTO.IsDeleted;
                    orgCraneDailyLifting.DateofNextInspection = newCraneDailyLiftingDTO.DateofNextInspection;
                    orgCraneDailyLifting.MobileCraneName = newCraneDailyLiftingDTO.MobileCraneName;


                    CraneDailyLiftingRepo.update(orgCraneDailyLifting);
					result.Message = "Success";
					result.Data = newCraneDailyLiftingDTO;
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

		[HttpGet("{ID:int}")]
		public ActionResult<ResultDTO> GetByID(int ID)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				CraneDailyLiftingDTO CraneDailyLiftingDTO = new CraneDailyLiftingDTO();
				CraneDailyLifting CraneDailyLifting = CraneDailyLiftingRepo.getbyid(ID);
				CraneDailyLiftingDTO.Id = CraneDailyLifting.Id;
                CraneDailyLiftingDTO.Type = CraneDailyLifting.Type;
                CraneDailyLiftingDTO.ChasisNo = CraneDailyLifting.ChasisNo;
                CraneDailyLiftingDTO.Capacity = CraneDailyLifting.Capacity;
                CraneDailyLiftingDTO.IsDeleted = CraneDailyLifting.IsDeleted;
                CraneDailyLiftingDTO.DateofNextInspection = CraneDailyLifting.DateofNextInspection;
                CraneDailyLiftingDTO.MobileCraneName = CraneDailyLifting.MobileCraneName;

                result.Message = "Success";
				result.Data = CraneDailyLiftingDTO;
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

		[HttpPost]
		public ActionResult<ResultDTO> AddCraneDailyLifting(CraneDailyLiftingDTO CraneDailyLiftingDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					CraneDailyLifting CraneDailyLifting = new CraneDailyLifting();
                    CraneDailyLifting.Type = CraneDailyLiftingDTO.Type;
                    CraneDailyLifting.ChasisNo = CraneDailyLiftingDTO.ChasisNo;
                    CraneDailyLifting.Capacity = CraneDailyLiftingDTO.Capacity;
                    CraneDailyLifting.IsDeleted = CraneDailyLiftingDTO.IsDeleted;
                    CraneDailyLifting.DateofNextInspection = CraneDailyLiftingDTO.DateofNextInspection;
                    CraneDailyLifting.MobileCraneName = CraneDailyLiftingDTO.MobileCraneName;
                    CraneDailyLifting.DateofLastInspection = CraneDailyLiftingDTO.DateofLastInspection;

                    CraneDailyLiftingRepo.create(CraneDailyLifting);
					result.Data = CraneDailyLiftingDTO;
					result.Statescode = 200;

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
				CraneDailyLifting CraneDailyLifting = CraneDailyLiftingRepo.getbyid(id);
				CraneDailyLifting.IsDeleted = true;
				CraneDailyLiftingRepo.update(CraneDailyLifting);
				result.Data = CraneDailyLifting;
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
