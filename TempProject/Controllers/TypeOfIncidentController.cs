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
    public class TypeOfIncidentController : ControllerBase
    {
        public IRepository<TypeOfIncident> TypeOfIncidentRepo { get; set; }

        public TypeOfIncidentController(IRepository<TypeOfIncident> _TypeOfIncidentRepo)
        {
            this.TypeOfIncidentRepo = _TypeOfIncidentRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<TypeOfIncident> temp = TypeOfIncidentRepo.getall();
            List<TypeOfIncidentDTO> newTemp = new List<TypeOfIncidentDTO>();
            foreach (TypeOfIncident TypeOfIncident in temp)
            {
				TypeOfIncidentDTO TypeOfIncidentDTO = new TypeOfIncidentDTO();
                TypeOfIncidentDTO.Id = TypeOfIncident.Id;
                TypeOfIncidentDTO.Name = TypeOfIncident.Name;
                TypeOfIncidentDTO.IsDeleted = TypeOfIncident.IsDeleted;

				newTemp.Add(TypeOfIncidentDTO);
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
		public PageResult<TypeOfIncidentDTO> GettTypeOfIncidentByPage( int? page, int pagesize = 10)
		{
			try
			{
				
					List<TypeOfIncident> temp = TypeOfIncidentRepo.getall();//.Where(s => s.Status == "Open").ToList();
					List<TypeOfIncidentDTO> newTemp = new List<TypeOfIncidentDTO>();
					foreach (TypeOfIncident TypeOfIncident in temp)
					{
						TypeOfIncidentDTO TypeOfIncidentDTO = new TypeOfIncidentDTO();
                        TypeOfIncidentDTO.Id = TypeOfIncident.Id;
                        TypeOfIncidentDTO.Name = TypeOfIncident.Name;
                        TypeOfIncidentDTO.IsDeleted = TypeOfIncident.IsDeleted;

						newTemp.Add(TypeOfIncidentDTO);
						//result.Data = prod;
					}

					float countDetails = TypeOfIncidentRepo.getall().Count();
					var result = new PageResult<TypeOfIncidentDTO>
					{
						Count = (int)Math.Ceiling(countDetails / pagesize),
						PageIndex = page ?? 1,
						PageSize = pagesize,
						Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
					};
					return result;
				}
				
			
			catch (Exception Ex)
			{
				return new PageResult<TypeOfIncidentDTO>();
			}
		}


		[HttpGet("{ID:int}")]
        public ActionResult<ResultDTO> GetByID(int ID)
        {
            ResultDTO result = new ResultDTO();
            try
            {
                TypeOfIncidentDTO TypeOfIncidentDTO = new TypeOfIncidentDTO();
				TypeOfIncident TypeOfIncident = TypeOfIncidentRepo.getbyid(ID);
                TypeOfIncidentDTO.Id = TypeOfIncident.Id;
                TypeOfIncidentDTO.Name = TypeOfIncident.Name;
                TypeOfIncidentDTO.IsDeleted = TypeOfIncident.IsDeleted;

				result.Message = "Success";
                result.Data = TypeOfIncidentDTO;
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
		[HttpPut("Edit/{id:int}")]
        public ActionResult<ResultDTO> Put(int id, [FromForm] TypeOfIncidentDTO TypeOfIncidentDTO) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    TypeOfIncident TypeOfIncident = TypeOfIncidentRepo.getbyid(id);

                    //TypeOfIncident.Id = TypeOfIncidentDTO.Id;
                    TypeOfIncident.Name = TypeOfIncidentDTO.Name;
                    TypeOfIncident.IsDeleted = TypeOfIncidentDTO.IsDeleted;

                    TypeOfIncidentRepo.update(TypeOfIncident);
                    result.Data = TypeOfIncidentDTO;
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

        [HttpPost]
        public ActionResult<ResultDTO> AddDrill(TypeOfIncidentDTO TypeOfIncidentDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
					TypeOfIncident TypeOfIncident = new TypeOfIncident();
					//TypeOfIncident.Id = TypeOfIncidentDTO.id;
					TypeOfIncident.Name = TypeOfIncidentDTO.Name;
					TypeOfIncident.IsDeleted = TypeOfIncidentDTO.IsDeleted;

					TypeOfIncidentRepo.create(TypeOfIncident);
                    result.Message = "Success";
                    result.Data = TypeOfIncidentDTO;
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
				TypeOfIncident TypeOfIncident = TypeOfIncidentRepo.getbyid(id);
				TypeOfIncident.IsDeleted = true;
				TypeOfIncidentRepo.update(TypeOfIncident);
                result.Data = TypeOfIncident;
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
