using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonnelCerificatesController : ControllerBase
	{
		public IRepository<PersonnelCerificates> PersonnelCerificatesRepo { get; set; }

		public PersonnelCerificatesController(IRepository<PersonnelCerificates> _PersonnelCerificatesRepo)
		{
			this.PersonnelCerificatesRepo = _PersonnelCerificatesRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<PersonnelCerificates> temp = PersonnelCerificatesRepo.getall();
			List<PersonnelCerificatesDTO> newTemp = new List<PersonnelCerificatesDTO>();
			foreach (PersonnelCerificates PersonnelCerificates in temp)
			{
				PersonnelCerificatesDTO PersonnelCerificatesDTO = new PersonnelCerificatesDTO();
				PersonnelCerificatesDTO.Id = PersonnelCerificates.Id;
				PersonnelCerificatesDTO.Code = PersonnelCerificates.Code;
				PersonnelCerificatesDTO.Position = PersonnelCerificates.Position;
				PersonnelCerificatesDTO.Name = PersonnelCerificates.Name;
				PersonnelCerificatesDTO.CertificateType = PersonnelCerificates.CertificateType;
				PersonnelCerificatesDTO.CertificateDate = PersonnelCerificates.CertificateDate;
				PersonnelCerificatesDTO.ExpiryDate = PersonnelCerificates.ExpiryDate;
				PersonnelCerificatesDTO.RigCertificatesId = PersonnelCerificates.RigCertificatesId;
				PersonnelCerificatesDTO.IsDeleted = PersonnelCerificates.IsDeleted;

				newTemp.Add(PersonnelCerificatesDTO);
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

		//	List<PersonnelCerificates> temp = PersonnelCerificatesRepo.getall();
		//	List<PersonnelCerificatesExcelDTO> newTemp = new List<PersonnelCerificatesExcelDTO>();
		//	foreach (PersonnelCerificates PersonnelCerificates in temp)
		//	{
		//		PersonnelCerificatesExcelDTO PersonnelCerificatesDTO = new PersonnelCerificatesExcelDTO();
		//		PersonnelCerificatesDTO.Id = PersonnelCerificates.Id;
		//		PersonnelCerificatesDTO.Name = PersonnelCerificates.Name;

		//		newTemp.Add(PersonnelCerificatesDTO);
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
		public PageResult<PersonnelCerificatesDTO> GettAllPersonnelCerificatesByPage(int? page, int pagesize = 10)
		{
			List<PersonnelCerificates> temp = PersonnelCerificatesRepo.getall();
			List<PersonnelCerificatesDTO> newTemp = new List<PersonnelCerificatesDTO>();
			foreach (PersonnelCerificates PersonnelCerificates in temp)
			{
				PersonnelCerificatesDTO PersonnelCerificatesDTO = new PersonnelCerificatesDTO();
				PersonnelCerificatesDTO.Id = PersonnelCerificates.Id;
				PersonnelCerificatesDTO.Code = PersonnelCerificates.Code;
				PersonnelCerificatesDTO.Position = PersonnelCerificates.Position;
				PersonnelCerificatesDTO.Name = PersonnelCerificates.Name;
				PersonnelCerificatesDTO.CertificateType = PersonnelCerificates.CertificateType;
				PersonnelCerificatesDTO.CertificateDate = PersonnelCerificates.CertificateDate;
				PersonnelCerificatesDTO.ExpiryDate = PersonnelCerificates.ExpiryDate;
				PersonnelCerificatesDTO.RigCertificatesId = PersonnelCerificates.RigCertificatesId;
				PersonnelCerificatesDTO.IsDeleted = PersonnelCerificates.IsDeleted;

				newTemp.Add(PersonnelCerificatesDTO);
			}

			float countDetails = PersonnelCerificatesRepo.getall().Count();
			var result = new PageResult<PersonnelCerificatesDTO>
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
				PersonnelCerificatesDTO PersonnelCerificatesDTO = new PersonnelCerificatesDTO();
				PersonnelCerificates PersonnelCerificates = PersonnelCerificatesRepo.getbyid(ID);
				PersonnelCerificatesDTO.Id = PersonnelCerificates.Id;
				PersonnelCerificatesDTO.Code = PersonnelCerificates.Code;
				PersonnelCerificatesDTO.Position = PersonnelCerificates.Position;
				PersonnelCerificatesDTO.Name = PersonnelCerificates.Name;
				PersonnelCerificatesDTO.CertificateType = PersonnelCerificates.CertificateType;
				PersonnelCerificatesDTO.CertificateDate = PersonnelCerificates.CertificateDate;
				PersonnelCerificatesDTO.ExpiryDate = PersonnelCerificates.ExpiryDate;
				PersonnelCerificatesDTO.RigCertificatesId = PersonnelCerificates.RigCertificatesId;
				PersonnelCerificatesDTO.IsDeleted = PersonnelCerificates.IsDeleted;

				result.Message = "Success";
				result.Data = PersonnelCerificatesDTO;
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
		public ActionResult<ResultDTO> Put(int id, PersonnelCerificatesDTO newPersonnelCerificates) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					PersonnelCerificates orgPersonnelCerificates = PersonnelCerificatesRepo.getbyid(id);
					newPersonnelCerificates.Id = orgPersonnelCerificates.Id;
					orgPersonnelCerificates.Code = newPersonnelCerificates.Code;
					orgPersonnelCerificates.Position = newPersonnelCerificates.Position;
					orgPersonnelCerificates.Name = newPersonnelCerificates.Name;
					orgPersonnelCerificates.CertificateType = newPersonnelCerificates.CertificateType;
					orgPersonnelCerificates.CertificateDate = newPersonnelCerificates.CertificateDate;
					orgPersonnelCerificates.ExpiryDate = newPersonnelCerificates.ExpiryDate;
					orgPersonnelCerificates.RigCertificatesId = newPersonnelCerificates.RigCertificatesId;
					orgPersonnelCerificates.IsDeleted = newPersonnelCerificates.IsDeleted;


					PersonnelCerificatesRepo.update(orgPersonnelCerificates);
					result.Message = "Success";
					result.Data = orgPersonnelCerificates;
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
		public ActionResult<ResultDTO> AddPersonnelCerificates(PersonnelCerificatesDTO PersonnelCerificatesDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					PersonnelCerificates PersonnelCerificates = new PersonnelCerificates();
					PersonnelCerificates.Id = PersonnelCerificatesDTO.Id;
					PersonnelCerificates.Code = PersonnelCerificatesDTO.Code;
					PersonnelCerificates.Position = PersonnelCerificatesDTO.Position;
					PersonnelCerificates.Name = PersonnelCerificatesDTO.Name;
					PersonnelCerificates.CertificateType = PersonnelCerificatesDTO.CertificateType;
					PersonnelCerificates.CertificateDate = PersonnelCerificatesDTO.CertificateDate;
					PersonnelCerificates.ExpiryDate = PersonnelCerificatesDTO.ExpiryDate;
					PersonnelCerificates.RigCertificatesId = PersonnelCerificatesDTO.RigCertificatesId;
					PersonnelCerificates.IsDeleted = PersonnelCerificatesDTO.IsDeleted;

					PersonnelCerificatesRepo.create(PersonnelCerificates);
					result.Data = PersonnelCerificatesDTO;
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
				PersonnelCerificates PersonnelCerificates = PersonnelCerificatesRepo.getbyid(id);
				PersonnelCerificates.IsDeleted = true;
				PersonnelCerificatesRepo.update(PersonnelCerificates);
				result.Data = PersonnelCerificates;
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
