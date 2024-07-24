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
	public class ForkDailyLiftingController : ControllerBase
	{
		public IRepository<ForkDailyLifting> ForkDailyLiftingRepo { get; set; }
		
		public IForkDailyLiftingRepository ForkDailyLiftingRepository { get; set; }

		public ForkDailyLiftingController(IRepository<ForkDailyLifting> _ForkDailyLiftingRepo, IForkDailyLiftingRepository _ForkDailyLiftingRepository)
		{
	
			this.ForkDailyLiftingRepo = _ForkDailyLiftingRepo;
			this.ForkDailyLiftingRepository= _ForkDailyLiftingRepository;
		}
		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<ForkDailyLifting> temp = ForkDailyLiftingRepo.getall();
			List<ForkDailyLiftingDTO> newTemp = new List<ForkDailyLiftingDTO>();
			foreach (ForkDailyLifting ForkDailyLifting in temp)
			{
				ForkDailyLiftingDTO ForkDailyLiftingDTO = new ForkDailyLiftingDTO();
				ForkDailyLiftingDTO.Id = ForkDailyLifting.Id;
				ForkDailyLiftingDTO.ForkType = ForkDailyLifting.Type;
				ForkDailyLiftingDTO.ForkChasisNo = ForkDailyLifting.ChasisNo;
				ForkDailyLiftingDTO.ForkCapacity = ForkDailyLifting.Capacity;
				ForkDailyLiftingDTO.IsDeleted = ForkDailyLifting.IsDeleted;
				ForkDailyLiftingDTO.ForkDateofNextInspection = ForkDailyLifting.DateofNextInspection;
				ForkDailyLiftingDTO.ForkName = ForkDailyLifting.ForkliftName;
                ForkDailyLiftingDTO.ForkDateofLastInspection = ForkDailyLifting.DateofLastInspection;

                newTemp.Add(ForkDailyLiftingDTO);
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

		//[HttpGet("GetAllForExcel")]
		//public ActionResult<ResultDTO> GetAllForExcel()
		//{

		//	ResultDTO result = new ResultDTO();

		//	List<ForkDailyLifting> temp = ForkDailyLiftingRepository.getall();
		//	List<ForkDailyLiftingExcelDTO> newTemp = new List<ForkDailyLiftingExcelDTO>();
		//	foreach (ForkDailyLifting ForkDailyLifting in temp)
		//	{
		//		ForkDailyLiftingExcelDTO ForkDailyLiftingDTO = new ForkDailyLiftingExcelDTO();
		//		ForkDailyLiftingDTO.Id = ForkDailyLifting.Id;
  //              ForkDailyLiftingDTO.Type = ForkDailyLifting.Type;
  //              ForkDailyLiftingDTO.ChasisNo = ForkDailyLifting.ChasisNo;
  //              ForkDailyLiftingDTO.Capacity = ForkDailyLifting.Capacity;
  //              ForkDailyLiftingDTO.DateofNextInspection = ForkDailyLifting.DateofNextInspection;
  //              ForkDailyLiftingDTO.MobileForkName = ForkDailyLifting.MobileForkName;

  //              newTemp.Add(ForkDailyLiftingDTO);
		//	}
		//	if (newTemp != null)
		//	{

		//		result.Message = "Success";
		//		result.Statescode = 200;
		//		result.Data = newTemp;

		//		return result;
		//	}

		//	result.Statescode = 404;
		//	result.Message = "data not found";
		//	return result;

		//}

		[HttpGet("ByPage/{page:int}")]
		public PageResult<ForkDailyLiftingDTO> GettAllForkDailyLiftingByPage(int? page, int pagesize = 10)
		{
			List<ForkDailyLifting> temp = ForkDailyLiftingRepo.getall();
			List<ForkDailyLiftingDTO> newTemp = new List<ForkDailyLiftingDTO>();
			foreach (ForkDailyLifting ForkDailyLifting in temp)
			{
				ForkDailyLiftingDTO ForkDailyLiftingDTO = new ForkDailyLiftingDTO();
				ForkDailyLiftingDTO.Id = ForkDailyLifting.Id;
                ForkDailyLiftingDTO.ForkType = ForkDailyLifting.Type;
                ForkDailyLiftingDTO.ForkChasisNo = ForkDailyLifting.ChasisNo;
                ForkDailyLiftingDTO.ForkCapacity = ForkDailyLifting.Capacity;
                ForkDailyLiftingDTO.IsDeleted = ForkDailyLifting.IsDeleted;
                ForkDailyLiftingDTO.ForkDateofNextInspection = ForkDailyLifting.DateofNextInspection;
                ForkDailyLiftingDTO.ForkName = ForkDailyLifting.ForkliftName;
                ForkDailyLiftingDTO.ForkDateofLastInspection = ForkDailyLifting.DateofLastInspection;

                newTemp.Add(ForkDailyLiftingDTO);
			}

			float countDetails = ForkDailyLiftingRepo.getall().Count();
			var result = new PageResult<ForkDailyLiftingDTO>
			{
				Count = (int)Math.Ceiling(countDetails / pagesize),
				PageIndex = page ?? 1,
				PageSize = pagesize,
				Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
			};
			return result;
		}

		[HttpGet("Fork")]
		public ActionResult<ResultDTO> GetByForklift(string ForkName)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				ForkDailyLiftingDTO ForkDailyLiftingDTO = new ForkDailyLiftingDTO();
				//////
				ForkDailyLifting ForkNameString = ForkDailyLiftingRepo.getall().FirstOrDefault(c => c.ForkliftName == ForkName);
				ForkDailyLiftingDTO.Id = ForkNameString.Id;
                ForkDailyLiftingDTO.ForkType = ForkNameString.Type;
                ForkDailyLiftingDTO.ForkChasisNo = ForkNameString.ChasisNo;
                ForkDailyLiftingDTO.ForkCapacity = ForkNameString.Capacity;
                ForkDailyLiftingDTO.IsDeleted = ForkNameString.IsDeleted;
                ForkDailyLiftingDTO.ForkDateofNextInspection = ForkNameString.DateofNextInspection;
                ForkDailyLiftingDTO.ForkName = ForkNameString.ForkliftName;
                ForkDailyLiftingDTO.ForkDateofLastInspection = ForkNameString.DateofLastInspection;


                result.Data = ForkDailyLiftingDTO;
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
		public ActionResult<ResultDTO> Put(int id, ForkDailyLiftingDTO newForkDailyLiftingDTO) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					ForkDailyLifting orgForkDailyLifting = ForkDailyLiftingRepo.getbyid(id);
					newForkDailyLiftingDTO.Id = orgForkDailyLifting.Id;
                    orgForkDailyLifting.Type = newForkDailyLiftingDTO.ForkType;
                    orgForkDailyLifting.ChasisNo = newForkDailyLiftingDTO.ForkChasisNo;
                    orgForkDailyLifting.Capacity = newForkDailyLiftingDTO.ForkCapacity;
                    orgForkDailyLifting.IsDeleted = newForkDailyLiftingDTO.IsDeleted;
                    orgForkDailyLifting.DateofNextInspection = newForkDailyLiftingDTO.ForkDateofNextInspection;
                    orgForkDailyLifting.DateofLastInspection = newForkDailyLiftingDTO.ForkDateofLastInspection;
                    orgForkDailyLifting.ForkliftName = newForkDailyLiftingDTO.ForkName;


                    ForkDailyLiftingRepo.update(orgForkDailyLifting);
					result.Message = "Success";
					result.Data = newForkDailyLiftingDTO;
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
				ForkDailyLiftingDTO ForkDailyLiftingDTO = new ForkDailyLiftingDTO();
				ForkDailyLifting ForkDailyLifting = ForkDailyLiftingRepo.getbyid(ID);
				ForkDailyLiftingDTO.Id = ForkDailyLifting.Id;
                ForkDailyLiftingDTO.ForkType = ForkDailyLifting.Type;
                ForkDailyLiftingDTO.ForkChasisNo = ForkDailyLifting.ChasisNo;
                ForkDailyLiftingDTO.ForkCapacity = ForkDailyLifting.Capacity;
                ForkDailyLiftingDTO.IsDeleted = ForkDailyLifting.IsDeleted;
                ForkDailyLiftingDTO.ForkDateofNextInspection = ForkDailyLifting.DateofNextInspection;
                ForkDailyLiftingDTO.ForkName = ForkDailyLifting.ForkliftName;
                ForkDailyLiftingDTO.ForkDateofLastInspection = ForkDailyLifting.DateofLastInspection;


                result.Message = "Success";
				result.Data = ForkDailyLiftingDTO;
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
		public ActionResult<ResultDTO> AddForkDailyLifting(ForkDailyLiftingDTO ForkDailyLiftingDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					ForkDailyLifting ForkDailyLifting = new ForkDailyLifting();
                    ForkDailyLifting.Type = ForkDailyLiftingDTO.ForkType;
                    ForkDailyLifting.ChasisNo = ForkDailyLiftingDTO.ForkChasisNo;
                    ForkDailyLifting.Capacity = ForkDailyLiftingDTO.ForkCapacity;
                    ForkDailyLifting.IsDeleted = ForkDailyLiftingDTO.IsDeleted;
                    ForkDailyLifting.DateofNextInspection = ForkDailyLiftingDTO.ForkDateofNextInspection;
                    ForkDailyLifting.ForkliftName = ForkDailyLiftingDTO.ForkName;
                    ForkDailyLifting.DateofLastInspection = ForkDailyLiftingDTO.ForkDateofLastInspection;

                    ForkDailyLiftingRepo.create(ForkDailyLifting);
					result.Data = ForkDailyLiftingDTO;
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
				ForkDailyLifting ForkDailyLifting = ForkDailyLiftingRepo.getbyid(id);
				ForkDailyLifting.IsDeleted = true;
				ForkDailyLiftingRepo.update(ForkDailyLifting);
				result.Data = ForkDailyLifting;
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
