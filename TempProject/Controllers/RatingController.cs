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
    public class RatingController : ControllerBase
    {
  //      public IRepository<Rating> RatingRepo { get; set; }

  //      public RatingController(IRepository<Rating> _RatingRepo)
  //      {
  //          this.RatingRepo = _RatingRepo;
  //      }
  //      [HttpGet]
  //      public ActionResult<ResultDTO> GetAll()
  //      {

  //          ResultDTO result = new ResultDTO();

  //          List<Rating> temp = RatingRepo.getall();
  //          List<RatingDTO > newTemp = new List<RatingDTO>();
  //          foreach (Rating rating in temp)
  //          {
		//		RatingDTO ratingDTO = new RatingDTO();
  //              ratingDTO.Id = rating.Id;
  //              ratingDTO.Name = rating.Name;
  //              ratingDTO.IsDeleted = rating.IsDeleted;

		//		newTemp.Add(ratingDTO);
  //          }
  //          if (newTemp != null)
  //          {

  //              result.Message = "Success";
  //              result.Statescode = 200;
  //              result.Data = newTemp;

  //              return result;
  //          }

  //          result.Statescode = 404;
  //          result.Message = "data not found";
  //          return result;

  //      }

		//[HttpGet("ByPage/{page:int}")]
		//public PageResult<RatingDTO> GettRatingByPage( int? page, int pagesize = 10)
		//{
		//	try
		//	{
				
		//			List<Rating> temp = RatingRepo.getall();//.Where(s => s.Status == "Open").ToList();
		//			List<RatingDTO> newTemp = new List<RatingDTO>();
		//			foreach (Rating rating in temp)
		//			{
		//				RatingDTO ratingDTO  = new RatingDTO();
  //                      ratingDTO.Id = rating.Id;
  //                      ratingDTO.Name = rating.Name;
  //                      ratingDTO.IsDeleted = rating.IsDeleted;

		//				newTemp.Add(ratingDTO);
		//				//result.Data = prod;
		//			}

		//			float countDetails = RatingRepo.getall().Count();
		//			var result = new PageResult<RatingDTO>
		//			{
		//				Count = (int)Math.Ceiling(countDetails / pagesize),
		//				PageIndex = page ?? 1,
		//				PageSize = pagesize,
		//				Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
		//			};
		//			return result;
		//		}
				
			
		//	catch (Exception Ex)
		//	{
		//		return new PageResult<RatingDTO>();
		//	}
		//}


		//[HttpGet("{ID:int}")]
  //      public ActionResult<ResultDTO> GetByID(int ID)
  //      {
  //          ResultDTO result = new ResultDTO();
  //          try
  //          {
  //              RatingDTO ratingDTO = new RatingDTO();
		//		Rating rating = RatingRepo.getbyid(ID);
  //              ratingDTO.Id = rating.Id;
  //              ratingDTO.Name = rating.Name;
  //              ratingDTO.IsDeleted = rating.IsDeleted;

		//		result.Message = "Success";
  //              result.Data = ratingDTO;
  //              result.Statescode = 200;
  //              return result;
  //          }
  //          catch (Exception ex)
  //          {
  //              result.Message = "Error Not Find";
  //              result.Statescode = 404;
  //              return result;
  //          }
  //      }
		//[HttpPut("Edit/{id:int}")]
  //      public ActionResult<ResultDTO> Put(int id, [FromForm] RatingDTO ratingDTO) //[FromBody] string value)
  //      {
  //          ResultDTO result = new ResultDTO();

  //          if (ModelState.IsValid)
  //          {
  //              try
  //              {
  //                  Rating rating = RatingRepo.getbyid(id);

  //                  //drillType.Id = DrillTypeDTO.Id;
  //                  rating.Name = ratingDTO.Name;
  //                  rating.IsDeleted = ratingDTO.IsDeleted;

  //                  RatingRepo.update(rating);
  //                  result.Data = ratingDTO;
  //                  result.Statescode = 200;
  //                  result.Message = "Success";

  //              }
  //              catch (Exception ex)
  //              {
  //                  result.Message = "Error in inserting";
  //                  result.Statescode = 400;
  //              }
  //          }
  //          return result;
  //      }

  //      [HttpPost]
  //      public ActionResult<ResultDTO> AddRating(RatingDTO ratingDTO)
  //      {
  //          ResultDTO result = new ResultDTO();

  //          if (ModelState.IsValid)
  //          {
  //              try
  //              {
		//			Rating rating = new Rating();
		//			//DrillType.Id = DrillTypeDTO.id;
		//			rating.Name = ratingDTO.Name;
		//			rating.IsDeleted = ratingDTO.IsDeleted;

		//			RatingRepo.create(rating);
  //                  result.Message = "Success";
  //                  result.Data = ratingDTO;
  //                  result.Statescode = 200;

  //              }
  //              catch (Exception ex)
  //              {
  //                  result.Message = "Error in inserting";
  //                  result.Statescode = 400;

  //              }
  //          }
  //          return result;
  //      }

  //      [HttpPut("Delete/{id:int}")]
  //      public ActionResult<ResultDTO> Delete(int id) //[FromBody] string value)
  //      {
  //          ResultDTO result = new ResultDTO();
  //          try
  //          {
		//		Rating rating = RatingRepo.getbyid(id);
		//		rating.IsDeleted = true;
		//		RatingRepo.update(rating);
  //              result.Data = rating;
  //              result.Statescode = 200;
  //              result.Message = "Success";
  //          }
  //          catch (Exception ex)
  //          {
  //              result.Message = "Error in deleted";
  //              result.Statescode = 400;
  //          }

  //          return result;
  //      }
    }
}
