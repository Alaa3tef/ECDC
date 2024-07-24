using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;
using TempProject.DTO;
using TempProject.DTO.ResponseDTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class HSEEquipmentListController : ControllerBase
    {
        public IRepository<HSEEquipmentList> HSEEquipmentListRepo { get; set; }

        public HSEEquipmentListController(IRepository<HSEEquipmentList> _HSEEquipmentListRepo)
        {
            this.HSEEquipmentListRepo = _HSEEquipmentListRepo;
        }

        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<HSEEquipmentList> temp = HSEEquipmentListRepo.getall();
            List<HSEEquipmentListDTO> newTemp = new List<HSEEquipmentListDTO>();
            foreach (HSEEquipmentList HSEEquipmentList in temp)
            {
                HSEEquipmentListDTO HSEEquipmentListDTO = new HSEEquipmentListDTO();
                HSEEquipmentListDTO.Id = HSEEquipmentList.Id;
                HSEEquipmentListDTO.Equipment = HSEEquipmentList.Equipment;
                HSEEquipmentListDTO.IsDeleted = HSEEquipmentList.IsDeleted;

                newTemp.Add(HSEEquipmentListDTO);
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

		//	List<HSEEquipmentList> temp = HSEEquipmentListRepo.getall();
		//	List<HSEEquipmentListExcelDTO> newTemp = new List<HSEEquipmentListExcelDTO>();
		//	foreach (HSEEquipmentList HSEEquipmentList in temp)
		//	{
		//		HSEEquipmentListExcelDTO HSEEquipmentListDTO = new HSEEquipmentListExcelDTO();
		//		HSEEquipmentListDTO.Id = HSEEquipmentList.Id;
		//		HSEEquipmentListDTO.Name = HSEEquipmentList.Name;

		//		newTemp.Add(HSEEquipmentListDTO);
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
		public PageResult<HSEEquipmentListDTO> GettAllHSEEquipmentListByPage(int? page, int pagesize = 10)
		{
			List<HSEEquipmentList> temp = HSEEquipmentListRepo.getall();
			List<HSEEquipmentListDTO> newTemp = new List<HSEEquipmentListDTO>();
			foreach (HSEEquipmentList HSEEquipmentList in temp)
			{
				HSEEquipmentListDTO HSEEquipmentListDTO = new HSEEquipmentListDTO();
				HSEEquipmentListDTO.Id = HSEEquipmentList.Id;
				HSEEquipmentListDTO.Equipment = HSEEquipmentList.Equipment;
				HSEEquipmentListDTO.IsDeleted = HSEEquipmentList.IsDeleted;

				newTemp.Add(HSEEquipmentListDTO);
			}

			float countDetails = HSEEquipmentListRepo.getall().Count();
			var result = new PageResult<HSEEquipmentListDTO>
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
                HSEEquipmentListDTO HSEEquipmentListDTO = new HSEEquipmentListDTO();
                HSEEquipmentList HSEEquipmentList = HSEEquipmentListRepo.getbyid(ID);
                HSEEquipmentListDTO.Id = HSEEquipmentList.Id;
                HSEEquipmentListDTO.Equipment = HSEEquipmentList.Equipment;
                HSEEquipmentListDTO.IsDeleted = HSEEquipmentList.IsDeleted;

                result.Message = "Success";
                result.Data = HSEEquipmentListDTO;
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
        public ActionResult<ResultDTO> Put(int id, HSEEquipmentListDTO newHSEEquipmentList) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    HSEEquipmentList orgHSEEquipmentList = HSEEquipmentListRepo.getbyid(id);
                    newHSEEquipmentList.Id = orgHSEEquipmentList.Id;
                    orgHSEEquipmentList.Equipment = newHSEEquipmentList.Equipment;
                    orgHSEEquipmentList.IsDeleted = newHSEEquipmentList.IsDeleted;


                    HSEEquipmentListRepo.update(orgHSEEquipmentList);
                    result.Message = "Success";
                    result.Data = orgHSEEquipmentList;
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
        public ActionResult<ResultDTO> AddHSEEquipmentList(HSEEquipmentListDTO HSEEquipmentListDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    HSEEquipmentList HSEEquipmentList = new HSEEquipmentList();
                    HSEEquipmentList.Id = HSEEquipmentListDTO.Id;
                    HSEEquipmentList.Equipment = HSEEquipmentListDTO.Equipment;
                    HSEEquipmentList.IsDeleted = HSEEquipmentListDTO.IsDeleted;

                    HSEEquipmentListRepo.create(HSEEquipmentList);
                    result.Data = HSEEquipmentListDTO;
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
                HSEEquipmentList HSEEquipmentList = HSEEquipmentListRepo.getbyid(id);
                HSEEquipmentList.IsDeleted = true;
                HSEEquipmentListRepo.update(HSEEquipmentList);
                result.Data = HSEEquipmentList;
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
