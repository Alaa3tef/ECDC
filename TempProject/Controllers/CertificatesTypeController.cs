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
    public class CertificatesTypeController : ControllerBase
    {
        public IRepository<CertificatesType> CertificatesTypeRepo { get; set; }

        public CertificatesTypeController(IRepository<CertificatesType> _CertificatesTypeRepo)
        {
            this.CertificatesTypeRepo = _CertificatesTypeRepo;
        }

        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<CertificatesType> temp = CertificatesTypeRepo.getall();
            List<CertificatesTypeDTO> newTemp = new List<CertificatesTypeDTO>();
            foreach (CertificatesType CertificatesType in temp)
            {
                CertificatesTypeDTO CertificatesTypeDTO = new CertificatesTypeDTO();
                CertificatesTypeDTO.Id = CertificatesType.Id;
                CertificatesTypeDTO.Type = CertificatesType.Type;
                CertificatesTypeDTO.IsDeleted = CertificatesType.IsDeleted;

                newTemp.Add(CertificatesTypeDTO);
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

		//	List<CertificatesType> temp = CertificatesTypeRepo.getall();
		//	List<CertificatesTypeExcelDTO> newTemp = new List<CertificatesTypeExcelDTO>();
		//	foreach (CertificatesType CertificatesType in temp)
		//	{
		//		CertificatesTypeExcelDTO CertificatesTypeDTO = new CertificatesTypeExcelDTO();
		//		CertificatesTypeDTO.Id = CertificatesType.Id;
		//		CertificatesTypeDTO.Name = CertificatesType.Name;

		//		newTemp.Add(CertificatesTypeDTO);
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
		public PageResult<CertificatesTypeDTO> GettAllCertificatesTypeByPage(int? page, int pagesize = 10)
		{
			List<CertificatesType> temp = CertificatesTypeRepo.getall();
			List<CertificatesTypeDTO> newTemp = new List<CertificatesTypeDTO>();
			foreach (CertificatesType CertificatesType in temp)
			{
				CertificatesTypeDTO CertificatesTypeDTO = new CertificatesTypeDTO();
				CertificatesTypeDTO.Id = CertificatesType.Id;
				CertificatesTypeDTO.Type = CertificatesType.Type;
				CertificatesTypeDTO.IsDeleted = CertificatesType.IsDeleted;

				newTemp.Add(CertificatesTypeDTO);
			}

			float countDetails = CertificatesTypeRepo.getall().Count();
			var result = new PageResult<CertificatesTypeDTO>
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
                CertificatesTypeDTO CertificatesTypeDTO = new CertificatesTypeDTO();
                CertificatesType CertificatesType = CertificatesTypeRepo.getbyid(ID);
                CertificatesTypeDTO.Id = CertificatesType.Id;
                CertificatesTypeDTO.Type = CertificatesType.Type;
                CertificatesTypeDTO.IsDeleted = CertificatesType.IsDeleted;

                result.Message = "Success";
                result.Data = CertificatesTypeDTO;
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
        public ActionResult<ResultDTO> Put(int id, CertificatesTypeDTO newCertificatesType) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    CertificatesType orgCertificatesType = CertificatesTypeRepo.getbyid(id);
                    newCertificatesType.Id = orgCertificatesType.Id;
                    orgCertificatesType.Type = newCertificatesType.Type;
                    orgCertificatesType.IsDeleted = newCertificatesType.IsDeleted;


                    CertificatesTypeRepo.update(orgCertificatesType);
                    result.Message = "Success";
                    result.Data = orgCertificatesType;
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
        public ActionResult<ResultDTO> AddCertificatesType(CertificatesTypeDTO CertificatesTypeDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    CertificatesType CertificatesType = new CertificatesType();
                    CertificatesType.Id = CertificatesTypeDTO.Id;
                    CertificatesType.Type = CertificatesTypeDTO.Type;
                    CertificatesType.IsDeleted = CertificatesTypeDTO.IsDeleted;

                    CertificatesTypeRepo.create(CertificatesType);
                    result.Data = CertificatesTypeDTO;
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
                CertificatesType CertificatesType = CertificatesTypeRepo.getbyid(id);
                CertificatesType.IsDeleted = true;
                CertificatesTypeRepo.update(CertificatesType);
                result.Data = CertificatesType;
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
