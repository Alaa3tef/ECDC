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
    public class CorrectiveResponsabilityController : ControllerBase
    {
        public IRepository<CorrectiveResponsability> CorrectiveResponsabilityRepo { get; set; }

        public CorrectiveResponsabilityController(IRepository<CorrectiveResponsability> _CorrectiveResponsabilityRepo)
        {
            this.CorrectiveResponsabilityRepo = _CorrectiveResponsabilityRepo;
        }

        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<CorrectiveResponsability> temp = CorrectiveResponsabilityRepo.getall();
            List<CorrectiveResponsabilityDTO> newTemp = new List<CorrectiveResponsabilityDTO>();
            foreach (CorrectiveResponsability CorrectiveResponsability in temp)
            {
                CorrectiveResponsabilityDTO CorrectiveResponsabilityDTO = new CorrectiveResponsabilityDTO();
                CorrectiveResponsabilityDTO.Id = CorrectiveResponsability.Id;
                CorrectiveResponsabilityDTO.ResponsibilityName = CorrectiveResponsability.ResponsibilityName;
                CorrectiveResponsabilityDTO.IsDeleted = CorrectiveResponsability.IsDeleted;

                newTemp.Add(CorrectiveResponsabilityDTO);
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
        
		[HttpGet("ByPage/{page:int}")]
		public PageResult<CorrectiveResponsabilityDTO> GettAllCorrectiveResponsabilityByPage(int? page, int pagesize = 10)
		{
			List<CorrectiveResponsability> temp = CorrectiveResponsabilityRepo.getall();
			List<CorrectiveResponsabilityDTO> newTemp = new List<CorrectiveResponsabilityDTO>();
			foreach (CorrectiveResponsability CorrectiveResponsability in temp)
			{
				CorrectiveResponsabilityDTO CorrectiveResponsabilityDTO = new CorrectiveResponsabilityDTO();
				CorrectiveResponsabilityDTO.Id = CorrectiveResponsability.Id;
				CorrectiveResponsabilityDTO.ResponsibilityName = CorrectiveResponsability.ResponsibilityName;
				CorrectiveResponsabilityDTO.IsDeleted = CorrectiveResponsability.IsDeleted;

				newTemp.Add(CorrectiveResponsabilityDTO);
			}

			float countDetails = CorrectiveResponsabilityRepo.getall().Count();
			var result = new PageResult<CorrectiveResponsabilityDTO>
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
                CorrectiveResponsabilityDTO CorrectiveResponsabilityDTO = new CorrectiveResponsabilityDTO();
                CorrectiveResponsability CorrectiveResponsability = CorrectiveResponsabilityRepo.getbyid(ID);
                CorrectiveResponsabilityDTO.Id = CorrectiveResponsability.Id;
                CorrectiveResponsabilityDTO.ResponsibilityName = CorrectiveResponsability.ResponsibilityName;
                CorrectiveResponsabilityDTO.IsDeleted = CorrectiveResponsability.IsDeleted;

                result.Message = "Success";
                result.Data = CorrectiveResponsabilityDTO;
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
        public ActionResult<ResultDTO> Put(int id, CorrectiveResponsabilityDTO newCorrectiveResponsability) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    CorrectiveResponsability orgCorrectiveResponsability = CorrectiveResponsabilityRepo.getbyid(id);
                    newCorrectiveResponsability.Id = orgCorrectiveResponsability.Id;
                    orgCorrectiveResponsability.ResponsibilityName = newCorrectiveResponsability.ResponsibilityName;
                    orgCorrectiveResponsability.IsDeleted = newCorrectiveResponsability.IsDeleted;


                    CorrectiveResponsabilityRepo.update(orgCorrectiveResponsability);
                    result.Message = "Success";
                    result.Data = orgCorrectiveResponsability;
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
        public ActionResult<ResultDTO> AddCorrectiveResponsability(CorrectiveResponsabilityDTO CorrectiveResponsabilityDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    CorrectiveResponsability CorrectiveResponsability = new CorrectiveResponsability();
                    CorrectiveResponsability.Id = CorrectiveResponsabilityDTO.Id;
                    CorrectiveResponsability.ResponsibilityName = CorrectiveResponsabilityDTO.ResponsibilityName;
                    CorrectiveResponsability.IsDeleted = CorrectiveResponsabilityDTO.IsDeleted;

                    CorrectiveResponsabilityRepo.create(CorrectiveResponsability);
                    result.Data = CorrectiveResponsabilityDTO;
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
                CorrectiveResponsability CorrectiveResponsability = CorrectiveResponsabilityRepo.getbyid(id);
                CorrectiveResponsability.IsDeleted = true;
                CorrectiveResponsabilityRepo.update(CorrectiveResponsability);
                result.Data = CorrectiveResponsability;
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
