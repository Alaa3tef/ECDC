using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TempProject.DTO;
using TempProject.DTO.ResponseDTO;
using TempProject.Helper;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerReportController : ControllerBase
    {
        public IRepository<CustomerReport> CustomerReportRepo { get; set; }
        public IRepository<EvaluationCriteria> EvaluationCriteriaRepo { get; set; }
        public IRepository<Rig> RigRepo { get; set; }

        public ICustomerReportRepository CustomerReportRepoistory { get; set; }

        private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager;


        public CustomerReportController(Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager,
            IRepository<CustomerReport> _CustomerReportRepo,
            ICustomerReportRepository _CustomerReportRepoistory,
            IRepository<EvaluationCriteria> _EvaluationCriteriaRepo,
            IRepository<Rig> _RigRepo)

            
        {
            this.CustomerReportRepo = _CustomerReportRepo;
            this.CustomerReportRepoistory = _CustomerReportRepoistory;
            this.userManager = _userManager;
            this.EvaluationCriteriaRepo = _EvaluationCriteriaRepo;
			this.RigRepo = _RigRepo;

        }

 

        [HttpGet("GetData")]
        public async Task<ResultDTO> GetAllWithData(string UserID, string UserRole)
        {
            ResultDTO result = new ResultDTO();

            try
            {
                List<CustomerReport> temp = new List<CustomerReport>();

                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    temp = CustomerReportRepoistory.getall();
                }
                else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
                {
                    temp = CustomerReportRepoistory.getall().Where(a => a.user.Id == UserID).ToList();
                }

                List<CustomerReportResponseDTO> newTemp = new List<CustomerReportResponseDTO>();

                Console.WriteLine(temp.Count);

                foreach (CustomerReport customerReport in temp)
                {
                    CustomerReportResponseDTO customerReportResponseDTO = new CustomerReportResponseDTO();
                    customerReportResponseDTO.Id = customerReport.Id;
                    customerReportResponseDTO.RigId = customerReport.Rig.Number;
                    customerReportResponseDTO.DateFrom = customerReport.DateFrom;
                    customerReportResponseDTO.DateTo = customerReport.DateTo;
                    customerReportResponseDTO.Year = customerReport.Year;
                    customerReportResponseDTO.Client = customerReport.Client;
                    customerReportResponseDTO.ClientRepresentative = customerReport.ClientRepresentative;
                    customerReportResponseDTO.Comment = customerReport.Comment;
                    customerReportResponseDTO.Location = customerReport.Location;
                    customerReportResponseDTO.ECDCRepresentative = customerReport.ECDCRepresentative;
                    customerReportResponseDTO.CustomerRepresentative = customerReport.CustomerRepresentative;
                    customerReportResponseDTO.EvaluationResult = customerReport.EvaluationResult;
                    customerReportResponseDTO.Month = customerReport.Month;

                    customerReportResponseDTO.userName = customerReport.user.UserName;
                    customerReportResponseDTO.userID = customerReport.user.Id;

                    List<EvaluationCriteria> evaluationCriterias = EvaluationCriteriaRepo.getall()
                        .Where(emp => emp.CustomerReportId == customerReport.Id).ToList();

                    // Set the ratings and comments
                    for (int i = 0; i < 8; i++)
                    {
                        var criteria = evaluationCriterias.ElementAtOrDefault(i);

                        switch (i)
                        {
                            case 0:
                                customerReportResponseDTO.Rating = criteria != null ? criteria.Rating : string.Empty ;
                                customerReportResponseDTO.CommentEvaluationCriteria = criteria != null ? criteria.Comment : string.Empty;
                                break;
                            case 1:
                                customerReportResponseDTO.Rating1 = criteria != null ? criteria.Rating : string.Empty ;
                                customerReportResponseDTO.CommentEvaluationCriteria1 = criteria != null ? criteria.Comment : string.Empty;
                                break;
                            case 2:
                                customerReportResponseDTO.Rating2 = criteria != null ? criteria.Rating : string.Empty ;
                                customerReportResponseDTO.CommentEvaluationCriteria2 = criteria != null ? criteria.Comment : string.Empty;
                                break;
                            case 3:
                                customerReportResponseDTO.Rating3 = criteria != null ? criteria.Rating : string.Empty ;
                                customerReportResponseDTO.CommentEvaluationCriteria3 = criteria != null ? criteria.Comment : string.Empty;
                                break;
                            case 4:
                                customerReportResponseDTO.Rating4 = criteria != null ? criteria.Rating : string.Empty ;
                                customerReportResponseDTO.CommentEvaluationCriteria4 = criteria != null ? criteria.Comment : string.Empty;
                                break;
                            case 5:
                                customerReportResponseDTO.Rating5 = criteria != null ? criteria.Rating : string.Empty ;
                                customerReportResponseDTO.CommentEvaluationCriteria5 = criteria != null ? criteria.Comment : string.Empty;
                                break;
                            case 6:
                                customerReportResponseDTO.Rating6 = criteria != null ? criteria.Rating : string.Empty ;
                                customerReportResponseDTO.CommentEvaluationCriteria6 = criteria != null ? criteria.Comment : string.Empty;
                                break;
                            case 7:
                                customerReportResponseDTO.Rating7 = criteria != null ? criteria.Rating : string.Empty ;
                                customerReportResponseDTO.CommentEvaluationCriteria7 = criteria != null ? criteria.Comment : string.Empty;
                                break;
                        }
                    }

                    newTemp.Add(customerReportResponseDTO);
                }

                if (newTemp.Count > 0)
                {
                    result.Message = "Success";
                    result.Statescode = 200;
                    result.Data = newTemp;
                }
            }
            catch (Exception ex)
            {
                result.Statescode = 404;
                result.Message = "Data not found";
            }

            return result;
        }


        [HttpGet("GetDataForExcel")]
        public ActionResult<ResultDTO> GetDataForExcel(string UserID, string UserRole)
        {
            ResultDTO result = new ResultDTO();
            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<CustomerReport> temp = CustomerReportRepoistory.getall();
                    List<CustomerReportExcelDTO> newTemp = new List<CustomerReportExcelDTO>();
                    foreach (CustomerReport customerReport in temp)
                    {
                        CustomerReportExcelDTO customerReportExcelDTO = new CustomerReportExcelDTO();
                        customerReportExcelDTO.Id = customerReport.Id;
                        customerReportExcelDTO.RigId = customerReport.Rig.Number;
                        customerReportExcelDTO.DateFrom = customerReport.DateFrom;
                        customerReportExcelDTO.DateTo = customerReport.DateTo;
                        customerReportExcelDTO.Year = customerReport.Year;
                        //customerReportExcelDTO.RatingId = customerReport.RatingId;
                        //customerReportExcelDTO.RatingName = customerReport.Rating.Name;
                        customerReportExcelDTO.Client = customerReport.Client;
                        customerReportExcelDTO.ClientRepresentative = customerReport.ClientRepresentative;
                        customerReportExcelDTO.Comment = customerReport.Comment;
                        customerReportExcelDTO.Location = customerReport.Location;
                        customerReportExcelDTO.ECDCRepresentative = customerReport.ECDCRepresentative;
                        customerReportExcelDTO.EvaluationResult = customerReport.EvaluationResult;
                        customerReportExcelDTO.Month = customerReport.Month;
                        customerReportExcelDTO.CustomerRepresentative = customerReport.CustomerRepresentative;

                        customerReportExcelDTO.userName = customerReport.user.UserName;

                        List<EvaluationCriteria> evaluationCriterias = EvaluationCriteriaRepo.getall().Where(emp => emp.CustomerReportId == customerReport.Id).ToList();


                        // Ensure at least one rating is present
                        if (evaluationCriterias.Any())
                        {
                            // Set the first rating
                            customerReportExcelDTO.Rating = evaluationCriterias[0].Rating;
                            customerReportExcelDTO.Rating1 = evaluationCriterias[1].Rating;
                            customerReportExcelDTO.Rating2 = evaluationCriterias[2].Rating;
                            customerReportExcelDTO.Rating3 = evaluationCriterias[3].Rating;
                            customerReportExcelDTO.Rating4 = evaluationCriterias[4].Rating;
                            customerReportExcelDTO.Rating5 = evaluationCriterias[5].Rating;
                            customerReportExcelDTO.Rating6 = evaluationCriterias[6].Rating;
                            customerReportExcelDTO.Rating7 = evaluationCriterias[7].Rating;

                            // Assign comments based on their count
                            for (int i = 0; i < 8; i++)
                            {
                                // Assign comments only if available
                                if (i < evaluationCriterias.Count)
                                {
                                    switch (i)
                                    {
                                        case 0:
                                            customerReportExcelDTO.CommentEvaluationCriteria = evaluationCriterias[i].Comment;
                                            break;
                                        case 1:
                                            customerReportExcelDTO.CommentEvaluationCriteria1 = evaluationCriterias[i].Comment;
                                            break;
                                        case 2:
                                            customerReportExcelDTO.CommentEvaluationCriteria2 = evaluationCriterias[i].Comment;
                                            break;
                                        case 3:
                                            customerReportExcelDTO.CommentEvaluationCriteria3 = evaluationCriterias[i].Comment;
                                            break;
                                        case 4:
                                            customerReportExcelDTO.CommentEvaluationCriteria4 = evaluationCriterias[i].Comment;
                                            break;
                                        case 5:
                                            customerReportExcelDTO.CommentEvaluationCriteria5 = evaluationCriterias[i].Comment;
                                            break;
                                        case 6:
                                            customerReportExcelDTO.CommentEvaluationCriteria6 = evaluationCriterias[i].Comment;
                                            break;
                                        case 7:
                                            customerReportExcelDTO.CommentEvaluationCriteria7 = evaluationCriterias[i].Comment;
                                            break;

                                    }

                                }

                                else
                                {
                                    // If no comment is available, set an empty string or handle as needed
                                    switch (i)
                                    {
                                        case 0:
                                            customerReportExcelDTO.CommentEvaluationCriteria = string.Empty;
                                            break;
                                        case 1:
                                            customerReportExcelDTO.CommentEvaluationCriteria1 = string.Empty;
                                            break;
                                        case 2:
                                            customerReportExcelDTO.CommentEvaluationCriteria2 = string.Empty;
                                            break;
                                        case 3:
                                            customerReportExcelDTO.CommentEvaluationCriteria3 = string.Empty;
                                            break;
                                        case 4:
                                            customerReportExcelDTO.CommentEvaluationCriteria4 = string.Empty;
                                            break;
                                        case 5:
                                            customerReportExcelDTO.CommentEvaluationCriteria5 = string.Empty;
                                            break;
                                        case 6:
                                            customerReportExcelDTO.CommentEvaluationCriteria6 = string.Empty;
                                            break;
                                        case 7:
                                            customerReportExcelDTO.CommentEvaluationCriteria7 = string.Empty;
                                            break;
                                    }
                                }
                            }
                            newTemp.Add(customerReportExcelDTO);
                        }


                    }

                    if (newTemp != null)
                    {
                        result.Message = "Success";
                        result.Statescode = 200;
                        result.Data = newTemp;

                        return result;
                    }

                }
                else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
                {
                    List<CustomerReport> temp = CustomerReportRepoistory.getall().Where(a => a.user.Id == UserID).ToList();
                    List<CustomerReportExcelDTO> newTemp = new List<CustomerReportExcelDTO>();
                    foreach (CustomerReport customerReport in temp)
                    {
                        CustomerReportExcelDTO customerReportExcelDTO = new CustomerReportExcelDTO();
                        customerReportExcelDTO.Id = customerReport.Id;
                        customerReportExcelDTO.RigId = customerReport.Rig.Number;
                        customerReportExcelDTO.DateFrom = customerReport.DateFrom;
                        customerReportExcelDTO.DateTo = customerReport.DateTo;
                        customerReportExcelDTO.Year = customerReport.Year;
                        //customerReportExcelDTO.RatingId = customerReport.RatingId;
                        //customerReportExcelDTO.RatingName = customerReport.Rating.Name;
                        customerReportExcelDTO.Client = customerReport.Client;
                        customerReportExcelDTO.ClientRepresentative = customerReport.ClientRepresentative;
                        customerReportExcelDTO.Comment = customerReport.Comment;
                        customerReportExcelDTO.Location = customerReport.Location;
                        customerReportExcelDTO.ECDCRepresentative = customerReport.ECDCRepresentative;
                        customerReportExcelDTO.EvaluationResult = customerReport.EvaluationResult;
                        customerReportExcelDTO.Month = customerReport.Month;
                        customerReportExcelDTO.CustomerRepresentative = customerReport.CustomerRepresentative;

                        customerReportExcelDTO.userName = customerReport.user.UserName;


                        List<EvaluationCriteria> evaluationCriterias = EvaluationCriteriaRepo.getall().Where(emp => emp.CustomerReportId == customerReport.Id).ToList();

                        // Ensure at least one rating is present
                        if (evaluationCriterias.Any())
                        {
                            // Set the first rating
                            customerReportExcelDTO.Rating = evaluationCriterias[0].Rating;
                            customerReportExcelDTO.Rating1 = evaluationCriterias[1].Rating;
                            customerReportExcelDTO.Rating2 = evaluationCriterias[2].Rating;
                            customerReportExcelDTO.Rating3 = evaluationCriterias[3].Rating;
                            customerReportExcelDTO.Rating4 = evaluationCriterias[4].Rating;
                            customerReportExcelDTO.Rating5 = evaluationCriterias[5].Rating;
                            customerReportExcelDTO.Rating6 = evaluationCriterias[6].Rating;
                            customerReportExcelDTO.Rating7 = evaluationCriterias[7].Rating;

                            // Assign comments based on their count
                            for (int i = 0; i < 8; i++)
                            {
                                // Assign comments only if available
                                if (i < evaluationCriterias.Count)
                                {
                                    switch (i)
                                    {
                                        case 0:
                                            customerReportExcelDTO.CommentEvaluationCriteria = evaluationCriterias[i].Comment;
                                            break;
                                        case 1:
                                            customerReportExcelDTO.CommentEvaluationCriteria1 = evaluationCriterias[i].Comment;
                                            break;
                                        case 2:
                                            customerReportExcelDTO.CommentEvaluationCriteria2 = evaluationCriterias[i].Comment;
                                            break;
                                        case 3:
                                            customerReportExcelDTO.CommentEvaluationCriteria3 = evaluationCriterias[i].Comment;
                                            break;
                                        case 4:
                                            customerReportExcelDTO.CommentEvaluationCriteria4 = evaluationCriterias[i].Comment;
                                            break;
                                        case 5:
                                            customerReportExcelDTO.CommentEvaluationCriteria5 = evaluationCriterias[i].Comment;
                                            break;
                                        case 6:
                                            customerReportExcelDTO.CommentEvaluationCriteria6 = evaluationCriterias[i].Comment;
                                            break;
                                        case 7:
                                            customerReportExcelDTO.CommentEvaluationCriteria7 = evaluationCriterias[i].Comment;
                                            break;

                                    }

                                }

                                else
                                {
                                    // If no comment is available, set an empty string or handle as needed
                                    switch (i)
                                    {
                                        case 0:
                                            customerReportExcelDTO.CommentEvaluationCriteria = string.Empty;
                                            break;
                                        case 1:
                                            customerReportExcelDTO.CommentEvaluationCriteria1 = string.Empty;
                                            break;
                                        case 2:
                                            customerReportExcelDTO.CommentEvaluationCriteria2 = string.Empty;
                                            break;
                                        case 3:
                                            customerReportExcelDTO.CommentEvaluationCriteria3 = string.Empty;
                                            break;
                                        case 4:
                                            customerReportExcelDTO.CommentEvaluationCriteria4 = string.Empty;
                                            break;
                                        case 5:
                                            customerReportExcelDTO.CommentEvaluationCriteria5 = string.Empty;
                                            break;
                                        case 6:
                                            customerReportExcelDTO.CommentEvaluationCriteria6 = string.Empty;
                                            break;
                                        case 7:
                                            customerReportExcelDTO.CommentEvaluationCriteria7 = string.Empty;
                                            break;
                                    }
                                }
                            }
                            newTemp.Add(customerReportExcelDTO);
                        }


                    }
                    if (newTemp != null)
                    {
                        result.Message = "Success";
                        result.Statescode = 200;
                        result.Data = newTemp;

                        return result;
                    }

                }
            }


            catch (Exception ex)
            {
                result.Statescode = 404;
                result.Message = "data not found";
            }

            return result;
        }

        [HttpGet("ByPage/{page:int}")]
        public PageResult<CustomerReportResponseDTO> GettAllCustomerByPage(string UserId, string UserRole, int? page, int pagesize = 10)
        {

            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<CustomerReport> temp = CustomerReportRepoistory.getall();
                    List<CustomerReportResponseDTO> newTemp = new List<CustomerReportResponseDTO>();
                    foreach (CustomerReport customerReport in temp)
                    {
                        CustomerReportResponseDTO customerReportResponseDTO = new CustomerReportResponseDTO();
                        customerReportResponseDTO.Id = customerReport.Id;
                        customerReportResponseDTO.RigId = customerReport.Rig.Number;
                        customerReportResponseDTO.DateFrom = customerReport.DateFrom;
                        customerReportResponseDTO.DateTo = customerReport.DateTo;
                        customerReportResponseDTO.Year = customerReport.Year;
                        //customerReportResponseDTO.RatingId = customerReport.RatingId;
                        //customerReportResponseDTO.RatingName = customerReport.Rating.Name;
                        customerReportResponseDTO.Client = customerReport.Client;
                        customerReportResponseDTO.ClientRepresentative = customerReport.ClientRepresentative;
                        customerReportResponseDTO.Comment = customerReport.Comment;
                        customerReportResponseDTO.Location = customerReport.Location;
                        customerReportResponseDTO.ECDCRepresentative = customerReport.ECDCRepresentative;
                        customerReportResponseDTO.EvaluationResult = customerReport.EvaluationResult;
                        customerReportResponseDTO.Month = customerReport.Month;
                        customerReportResponseDTO.CustomerRepresentative = customerReport.CustomerRepresentative;

                        customerReportResponseDTO.userName = customerReport.user.UserName;
                        customerReportResponseDTO.userID = customerReport.user.Id;

                        List<EvaluationCriteria> evaluationCriterias = EvaluationCriteriaRepo.getall().Where(emp => emp.CustomerReportId == customerReport.Id).ToList();


                        // Ensure at least one rating is present
                        if (evaluationCriterias.Any())
                        {
                            // Set the first rating
                            customerReportResponseDTO.Rating = evaluationCriterias[0].Rating;
                            customerReportResponseDTO.Rating1 = evaluationCriterias[1].Rating;
                            customerReportResponseDTO.Rating2 = evaluationCriterias[2].Rating;
                            customerReportResponseDTO.Rating3 = evaluationCriterias[3].Rating;
                            customerReportResponseDTO.Rating4 = evaluationCriterias[4].Rating;
                            customerReportResponseDTO.Rating5 = evaluationCriterias[5].Rating;
                            customerReportResponseDTO.Rating6 = evaluationCriterias[6].Rating;
                            customerReportResponseDTO.Rating7 = evaluationCriterias[7].Rating;

                            // Assign comments based on their count
                            for (int i = 0; i < 8; i++)
                            {
                                // Assign comments only if available
                                if (i < evaluationCriterias.Count)
                                {
                                    switch (i)
                                    {
                                        case 0:
                                            customerReportResponseDTO.CommentEvaluationCriteria = evaluationCriterias[i].Comment;
                                            break;
                                        case 1:
                                            customerReportResponseDTO.CommentEvaluationCriteria1 = evaluationCriterias[i].Comment;
                                            break;
                                        case 2:
                                            customerReportResponseDTO.CommentEvaluationCriteria2 = evaluationCriterias[i].Comment;
                                            break;
                                        case 3:
                                            customerReportResponseDTO.CommentEvaluationCriteria3 = evaluationCriterias[i].Comment;
                                            break;
                                        case 4:
                                            customerReportResponseDTO.CommentEvaluationCriteria4 = evaluationCriterias[i].Comment;
                                            break;
                                        case 5:
                                            customerReportResponseDTO.CommentEvaluationCriteria5 = evaluationCriterias[i].Comment;
                                            break;
                                        case 6:
                                            customerReportResponseDTO.CommentEvaluationCriteria6 = evaluationCriterias[i].Comment;
                                            break;
                                        case 7:
                                            customerReportResponseDTO.CommentEvaluationCriteria7 = evaluationCriterias[i].Comment;
                                            break;

                                    }

                                }

                                else
                                {
                                    // If no comment is available, set an empty string or handle as needed
                                    switch (i)
                                    {
                                        case 0:
                                            customerReportResponseDTO.CommentEvaluationCriteria = string.Empty;
                                            break;
                                        case 1:
                                            customerReportResponseDTO.CommentEvaluationCriteria1 = string.Empty;
                                            break;
                                        case 2:
                                            customerReportResponseDTO.CommentEvaluationCriteria2 = string.Empty;
                                            break;
                                        case 3:
                                            customerReportResponseDTO.CommentEvaluationCriteria3 = string.Empty;
                                            break;
                                        case 4:
                                            customerReportResponseDTO.CommentEvaluationCriteria4 = string.Empty;
                                            break;
                                        case 5:
                                            customerReportResponseDTO.CommentEvaluationCriteria5 = string.Empty;
                                            break;
                                        case 6:
                                            customerReportResponseDTO.CommentEvaluationCriteria6 = string.Empty;
                                            break;
                                        case 7:
                                            customerReportResponseDTO.CommentEvaluationCriteria7 = string.Empty;
                                            break;
                                    }
                                }
                            }
                            newTemp.Add(customerReportResponseDTO);
                        }


                        //result.Data = prod;
                    }

                    float countDetails = CustomerReportRepoistory.getall().Count();
                    var result = new PageResult<CustomerReportResponseDTO>
                    {
                        Count = (int)Math.Ceiling(countDetails / pagesize),
                        PageIndex = page ?? 1,
                        PageSize = pagesize,
                        Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
                    };

                    return result;

                }
                else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
                {
                    List<CustomerReport> temp = CustomerReportRepoistory.getall().Where(a => a.user.Id == UserId).ToList();
                    List<CustomerReportResponseDTO> newTemp = new List<CustomerReportResponseDTO>();
                    foreach (CustomerReport customerReport in temp)
                    {

                        CustomerReportResponseDTO customerReportResponseDTO = new CustomerReportResponseDTO();
                        customerReportResponseDTO.Id = customerReport.Id;
                        customerReportResponseDTO.RigId = customerReport.Rig.Number;
                        customerReportResponseDTO.DateFrom = customerReport.DateFrom;
                        customerReportResponseDTO.DateTo = customerReport.DateTo;
                        customerReportResponseDTO.Year = customerReport.Year;
                        //customerReportResponseDTO.RatingId = customerReport.RatingId;
                        //customerReportResponseDTO.RatingName = customerReport.Rating.Name;
                        customerReportResponseDTO.Client = customerReport.Client;
                        customerReportResponseDTO.ClientRepresentative = customerReport.ClientRepresentative;
                        customerReportResponseDTO.Comment = customerReport.Comment;
                        customerReportResponseDTO.Location = customerReport.Location;
                        customerReportResponseDTO.ECDCRepresentative = customerReport.ECDCRepresentative;
                        customerReportResponseDTO.EvaluationResult = customerReport.EvaluationResult;
                        customerReportResponseDTO.Month = customerReport.Month;
                        customerReportResponseDTO.CustomerRepresentative = customerReport.CustomerRepresentative;

                        customerReportResponseDTO.userName = customerReport.user.UserName;
                        customerReportResponseDTO.userID = customerReport.user.Id;

                        List<EvaluationCriteria> evaluationCriterias = EvaluationCriteriaRepo.getall().Where(emp => emp.CustomerReportId == customerReport.Id).ToList();


                        // Ensure at least one rating is present
                        if (evaluationCriterias.Any())
                        {
                            // Set the first rating
                            customerReportResponseDTO.Rating = evaluationCriterias[0].Rating;
                            customerReportResponseDTO.Rating1 = evaluationCriterias[1].Rating;
                            customerReportResponseDTO.Rating2 = evaluationCriterias[2].Rating;
                            customerReportResponseDTO.Rating3 = evaluationCriterias[3].Rating;
                            customerReportResponseDTO.Rating4 = evaluationCriterias[4].Rating;
                            customerReportResponseDTO.Rating5 = evaluationCriterias[5].Rating;
                            customerReportResponseDTO.Rating6 = evaluationCriterias[6].Rating;
                            customerReportResponseDTO.Rating7 = evaluationCriterias[7].Rating;

                            // Assign comments based on their count
                            for (int i = 0; i < 8; i++)
                            {
                                // Assign comments only if available
                                if (i < evaluationCriterias.Count)
                                {
                                    switch (i)
                                    {
                                        case 0:
                                            customerReportResponseDTO.CommentEvaluationCriteria = evaluationCriterias[i].Comment;
                                            break;
                                        case 1:
                                            customerReportResponseDTO.CommentEvaluationCriteria1 = evaluationCriterias[i].Comment;
                                            break;
                                        case 2:
                                            customerReportResponseDTO.CommentEvaluationCriteria2 = evaluationCriterias[i].Comment;
                                            break;
                                        case 3:
                                            customerReportResponseDTO.CommentEvaluationCriteria3 = evaluationCriterias[i].Comment;
                                            break;
                                        case 4:
                                            customerReportResponseDTO.CommentEvaluationCriteria4 = evaluationCriterias[i].Comment;
                                            break;
                                        case 5:
                                            customerReportResponseDTO.CommentEvaluationCriteria5 = evaluationCriterias[i].Comment;
                                            break;
                                        case 6:
                                            customerReportResponseDTO.CommentEvaluationCriteria6 = evaluationCriterias[i].Comment;
                                            break;
                                        case 7:
                                            customerReportResponseDTO.CommentEvaluationCriteria7 = evaluationCriterias[i].Comment;
                                            break;

                                    }

                                }

                                else
                                {
                                    // If no comment is available, set an empty string or handle as needed
                                    switch (i)
                                    {
                                        case 0:
                                            customerReportResponseDTO.CommentEvaluationCriteria = string.Empty;
                                            break;
                                        case 1:
                                            customerReportResponseDTO.CommentEvaluationCriteria1 = string.Empty;
                                            break;
                                        case 2:
                                            customerReportResponseDTO.CommentEvaluationCriteria2 = string.Empty;
                                            break;
                                        case 3:
                                            customerReportResponseDTO.CommentEvaluationCriteria3 = string.Empty;
                                            break;
                                        case 4:
                                            customerReportResponseDTO.CommentEvaluationCriteria4 = string.Empty;
                                            break;
                                        case 5:
                                            customerReportResponseDTO.CommentEvaluationCriteria5 = string.Empty;
                                            break;
                                        case 6:
                                            customerReportResponseDTO.CommentEvaluationCriteria6 = string.Empty;
                                            break;
                                        case 7:
                                            customerReportResponseDTO.CommentEvaluationCriteria7 = string.Empty;
                                            break;
                                    }
                                }
                            }
                            newTemp.Add(customerReportResponseDTO);
                        }


                    }

                    float countDetails = CustomerReportRepoistory.getall().Where(a => a.user.Id == UserId).Count();
                    var result = new PageResult<CustomerReportResponseDTO>
                    {
                        Count = (int)Math.Ceiling(countDetails / pagesize),
                        PageIndex = page ?? 1,
                        PageSize = pagesize,
                        Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
                    };

                    return result;
                }
            }
            catch (Exception ex)
            {
                return new PageResult<CustomerReportResponseDTO>();

            }
            return new PageResult<CustomerReportResponseDTO>();
        }

        [HttpGet("GetDataById/{ID:int}")]
        public ActionResult<ResultDTO> GetAllWithDataByID(int ID, string UserId, string UserRole)
        {
            ResultDTO result = new ResultDTO();


            if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                CustomerReport temp = CustomerReportRepoistory.getall().FirstOrDefault(a => a.Id == ID);
                if (temp != null)
                {
                    CustomerReportResponseDTO customerReportResponseDTO = new CustomerReportResponseDTO();
                    List<EvaluationCriteria> evaluationCriterias = EvaluationCriteriaRepo.getall().Where(emp => emp.CustomerReportId == temp.Id).ToList();

                    customerReportResponseDTO.Id = temp.Id;
                    customerReportResponseDTO.RigId = temp.Rig.Id;
                    customerReportResponseDTO.DateFrom = temp.DateFrom;
                    customerReportResponseDTO.DateTo = temp.DateTo;
                    customerReportResponseDTO.Year = temp.Year;
                    //customerReportResponseDTO.RatingId = temp.RatingId;
                    //customerReportResponseDTO.RatingName = temp.Rating.Name;
                    customerReportResponseDTO.Client = temp.Client;
                    customerReportResponseDTO.ClientRepresentative = temp.ClientRepresentative;
                    customerReportResponseDTO.Comment = temp.Comment;
                    customerReportResponseDTO.Location = temp.Location;
                    customerReportResponseDTO.ECDCRepresentative = temp.ECDCRepresentative;
                    customerReportResponseDTO.EvaluationResult = temp.EvaluationResult;
                    customerReportResponseDTO.Month = temp.Month;
                    customerReportResponseDTO.CustomerRepresentative = temp.CustomerRepresentative;

                    customerReportResponseDTO.userID = temp.user.Id;



                    // Ensure at least one rating is present
                    if (evaluationCriterias.Any())
                    {
                        // Set the first rating
                        customerReportResponseDTO.Rating = evaluationCriterias[0].Rating;
                        customerReportResponseDTO.Rating1 = evaluationCriterias[1].Rating;
                        customerReportResponseDTO.Rating2 = evaluationCriterias[2].Rating;
                        customerReportResponseDTO.Rating3 = evaluationCriterias[3].Rating;
                        customerReportResponseDTO.Rating4 = evaluationCriterias[4].Rating;
                        customerReportResponseDTO.Rating5 = evaluationCriterias[5].Rating;
                        customerReportResponseDTO.Rating6 = evaluationCriterias[6].Rating;
                        customerReportResponseDTO.Rating7 = evaluationCriterias[7].Rating;

                        // Assign comments based on their count
                        for (int i = 0; i < 8; i++)
                        {
                            // Assign comments only if available
                            if (i < evaluationCriterias.Count)
                            {
                                switch (i)
                                {
                                    case 0:
                                        customerReportResponseDTO.CommentEvaluationCriteria = evaluationCriterias[i].Comment;
                                        break;
                                    case 1:
                                        customerReportResponseDTO.CommentEvaluationCriteria1 = evaluationCriterias[i].Comment;
                                        break;
                                    case 2:
                                        customerReportResponseDTO.CommentEvaluationCriteria2 = evaluationCriterias[i].Comment;
                                        break;
                                    case 3:
                                        customerReportResponseDTO.CommentEvaluationCriteria3 = evaluationCriterias[i].Comment;
                                        break;
                                    case 4:
                                        customerReportResponseDTO.CommentEvaluationCriteria4 = evaluationCriterias[i].Comment;
                                        break;
                                    case 5:
                                        customerReportResponseDTO.CommentEvaluationCriteria5 = evaluationCriterias[i].Comment;
                                        break;
                                    case 6:
                                        customerReportResponseDTO.CommentEvaluationCriteria6 = evaluationCriterias[i].Comment;
                                        break;
                                    case 7:
                                        customerReportResponseDTO.CommentEvaluationCriteria7 = evaluationCriterias[i].Comment;
                                        break;

                                }

                            }

                            else
                            {
                                // If no comment is available, set an empty string or handle as needed
                                switch (i)
                                {
                                    case 0:
                                        customerReportResponseDTO.CommentEvaluationCriteria = string.Empty;
                                        break;
                                    case 1:
                                        customerReportResponseDTO.CommentEvaluationCriteria1 = string.Empty;
                                        break;
                                    case 2:
                                        customerReportResponseDTO.CommentEvaluationCriteria2 = string.Empty;
                                        break;
                                    case 3:
                                        customerReportResponseDTO.CommentEvaluationCriteria3 = string.Empty;
                                        break;
                                    case 4:
                                        customerReportResponseDTO.CommentEvaluationCriteria4 = string.Empty;
                                        break;
                                    case 5:
                                        customerReportResponseDTO.CommentEvaluationCriteria5 = string.Empty;
                                        break;
                                    case 6:
                                        customerReportResponseDTO.CommentEvaluationCriteria6 = string.Empty;
                                        break;
                                    case 7:
                                        customerReportResponseDTO.CommentEvaluationCriteria7 = string.Empty;
                                        break;
                                }
                            }
                        }
                    }



                    if (customerReportResponseDTO != null)
                    {

                        result.Message = "Success";
                        result.Statescode = 200;
                        result.Data = customerReportResponseDTO;

                        return result;
                    }
                }

            }
            else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
            {
                CustomerReport temp = CustomerReportRepoistory.getall().FirstOrDefault(a => a.Id == ID && a.user.Id == UserId);
                if (temp != null)
                {
                    List<EvaluationCriteria> evaluationCriterias = EvaluationCriteriaRepo.getall().Where(emp => emp.CustomerReportId == temp.Id).ToList();
                    CustomerReportResponseDTO customerReportResponseDTO = new CustomerReportResponseDTO();
                    customerReportResponseDTO.Id = temp.Id;
                    customerReportResponseDTO.RigId = temp.Rig.Id;
                    customerReportResponseDTO.DateFrom = temp.DateFrom;
                    customerReportResponseDTO.DateTo = temp.DateTo;
                    customerReportResponseDTO.Year = temp.Year;
                    //customerReportResponseDTO.RatingId = temp.RatingId;
                    //customerReportResponseDTO.RatingName = temp.Rating.Name;
                    customerReportResponseDTO.Client = temp.Client;
                    customerReportResponseDTO.ClientRepresentative = temp.ClientRepresentative;
                    customerReportResponseDTO.Comment = temp.Comment;
                    customerReportResponseDTO.Location = temp.Location;
                    customerReportResponseDTO.ECDCRepresentative = temp.ECDCRepresentative;
                    customerReportResponseDTO.EvaluationResult = temp.EvaluationResult;
                    customerReportResponseDTO.Month = temp.Month;
                    customerReportResponseDTO.CustomerRepresentative = temp.CustomerRepresentative;

                    customerReportResponseDTO.Rating = evaluationCriterias[0].Rating;
                    customerReportResponseDTO.Rating = evaluationCriterias[1].Rating;
                    customerReportResponseDTO.Rating = evaluationCriterias[2].Rating;
                    customerReportResponseDTO.Rating = evaluationCriterias[3].Rating;
                    customerReportResponseDTO.Rating = evaluationCriterias[4].Rating;
                    customerReportResponseDTO.Rating = evaluationCriterias[5].Rating;
                    customerReportResponseDTO.Rating = evaluationCriterias[6].Rating;
                    customerReportResponseDTO.Rating = evaluationCriterias[7].Rating;

                    customerReportResponseDTO.userID = temp.user.Id;


                    // Ensure at least one rating is present
                    if (evaluationCriterias.Any())
                    {
                        // Set the first rating
                        customerReportResponseDTO.Rating = evaluationCriterias[0].Rating;
                        customerReportResponseDTO.Rating1 = evaluationCriterias[1].Rating;
                        customerReportResponseDTO.Rating2 = evaluationCriterias[2].Rating;
                        customerReportResponseDTO.Rating3 = evaluationCriterias[3].Rating;
                        customerReportResponseDTO.Rating4 = evaluationCriterias[4].Rating;
                        customerReportResponseDTO.Rating5 = evaluationCriterias[5].Rating;
                        customerReportResponseDTO.Rating6 = evaluationCriterias[6].Rating;
                        customerReportResponseDTO.Rating7 = evaluationCriterias[7].Rating;

                        // Assign comments based on their count
                        for (int i = 0; i < 8; i++)
                        {
                            // Assign comments only if available
                            if (i < evaluationCriterias.Count)
                            {
                                switch (i)
                                {
                                    case 0:
                                        customerReportResponseDTO.CommentEvaluationCriteria = evaluationCriterias[i].Comment;
                                        break;
                                    case 1:
                                        customerReportResponseDTO.CommentEvaluationCriteria1 = evaluationCriterias[i].Comment;
                                        break;
                                    case 2:
                                        customerReportResponseDTO.CommentEvaluationCriteria2 = evaluationCriterias[i].Comment;
                                        break;
                                    case 3:
                                        customerReportResponseDTO.CommentEvaluationCriteria3 = evaluationCriterias[i].Comment;
                                        break;
                                    case 4:
                                        customerReportResponseDTO.CommentEvaluationCriteria4 = evaluationCriterias[i].Comment;
                                        break;
                                    case 5:
                                        customerReportResponseDTO.CommentEvaluationCriteria5 = evaluationCriterias[i].Comment;
                                        break;
                                    case 6:
                                        customerReportResponseDTO.CommentEvaluationCriteria6 = evaluationCriterias[i].Comment;
                                        break;
                                    case 7:
                                        customerReportResponseDTO.CommentEvaluationCriteria7 = evaluationCriterias[i].Comment;
                                        break;

                                }

                            }

                            else
                            {
                                // If no comment is available, set an empty string or handle as needed
                                switch (i)
                                {
                                    case 0:
                                        customerReportResponseDTO.CommentEvaluationCriteria = string.Empty;
                                        break;
                                    case 1:
                                        customerReportResponseDTO.CommentEvaluationCriteria1 = string.Empty;
                                        break;
                                    case 2:
                                        customerReportResponseDTO.CommentEvaluationCriteria2 = string.Empty;
                                        break;
                                    case 3:
                                        customerReportResponseDTO.CommentEvaluationCriteria3 = string.Empty;
                                        break;
                                    case 4:
                                        customerReportResponseDTO.CommentEvaluationCriteria4 = string.Empty;
                                        break;
                                    case 5:
                                        customerReportResponseDTO.CommentEvaluationCriteria5 = string.Empty;
                                        break;
                                    case 6:
                                        customerReportResponseDTO.CommentEvaluationCriteria6 = string.Empty;
                                        break;
                                    case 7:
                                        customerReportResponseDTO.CommentEvaluationCriteria7 = string.Empty;
                                        break;
                                }
                            }
                        }
                    }




                    if (customerReportResponseDTO != null)
                    {

                        result.Message = "Success";
                        result.Statescode = 200;
                        result.Data = customerReportResponseDTO;

                        return result;
                    }
                }

            }

            result.Statescode = 404;
            result.Message = "data not found";
            return result;
        }

          //------------------filter by Month&Year ------------------------------------------

        [HttpGet("GetDataByMonthAndYear/{Month}")]
        public ActionResult<ResultDTO> GetDataByMonthAndYear(int Month, int Year ,string UserId, string UserRole)
        {
            ResultDTO result = new ResultDTO();

            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<CustomerReportResponseDTO> customerReportResponseDTOs = new List<CustomerReportResponseDTO>(); 
                    List<CustomerReport> customerReports = CustomerReportRepoistory.getall().Where(a => a.Month== Month&& a.Year==Year).ToList();
                    foreach (CustomerReport customerReport in customerReports)
                    {
                        CustomerReportResponseDTO customerReportResponseDTO = new CustomerReportResponseDTO();
                        customerReportResponseDTO.Id = customerReport.Id;
                        customerReportResponseDTO.RigId = customerReport.Rig.Number;
                        customerReportResponseDTO.DateFrom = customerReport.DateFrom;
                        customerReportResponseDTO.DateTo = customerReport.DateTo;
                        customerReportResponseDTO.Year = customerReport.Year;
                        //customerReportResponseDTO.RatingId = customerReport.RatingId;
                        //customerReportResponseDTO.RatingName = customerReport.Rating.Name;
                        customerReportResponseDTO.Client = customerReport.Client;
                        customerReportResponseDTO.ClientRepresentative = customerReport.ClientRepresentative;
                        customerReportResponseDTO.Comment = customerReport.Comment;
                        customerReportResponseDTO.Location = customerReport.Location;
                        customerReportResponseDTO.ECDCRepresentative = customerReport.ECDCRepresentative;
                        customerReportResponseDTO.EvaluationResult = customerReport.EvaluationResult;
                        customerReportResponseDTO.Month = customerReport.Month;
                        customerReportResponseDTO.CustomerRepresentative = customerReport.CustomerRepresentative;

                        customerReportResponseDTO.userID = customerReport.user.Id;
                        List<EvaluationCriteria> evaluationCriterias = EvaluationCriteriaRepo.getall().Where(emp => emp.CustomerReportId == customerReport.Id).ToList();



                        // Ensure at least one rating is present
                        if (evaluationCriterias.Any())
                        {
                            // Set the first rating
                            customerReportResponseDTO.Rating = evaluationCriterias[0].Rating;
                            customerReportResponseDTO.Rating1 = evaluationCriterias[1].Rating;
                            customerReportResponseDTO.Rating2 = evaluationCriterias[2].Rating;
                            customerReportResponseDTO.Rating3 = evaluationCriterias[3].Rating;
                            customerReportResponseDTO.Rating4 = evaluationCriterias[4].Rating;
                            customerReportResponseDTO.Rating5 = evaluationCriterias[5].Rating;
                            customerReportResponseDTO.Rating6 = evaluationCriterias[6].Rating;
                            customerReportResponseDTO.Rating7 = evaluationCriterias[7].Rating;

                            // Assign comments based on their count
                            for (int i = 0; i < 8; i++)
                            {
                                // Assign comments only if available
                                if (i < evaluationCriterias.Count)
                                {
                                    switch (i)
                                    {
                                        case 0:
                                            customerReportResponseDTO.CommentEvaluationCriteria = evaluationCriterias[i].Comment;
                                            break;
                                        case 1:
                                            customerReportResponseDTO.CommentEvaluationCriteria1 = evaluationCriterias[i].Comment;
                                            break;
                                        case 2:
                                            customerReportResponseDTO.CommentEvaluationCriteria2 = evaluationCriterias[i].Comment;
                                            break;
                                        case 3:
                                            customerReportResponseDTO.CommentEvaluationCriteria3 = evaluationCriterias[i].Comment;
                                            break;
                                        case 4:
                                            customerReportResponseDTO.CommentEvaluationCriteria4 = evaluationCriterias[i].Comment;
                                            break;
                                        case 5:
                                            customerReportResponseDTO.CommentEvaluationCriteria5 = evaluationCriterias[i].Comment;
                                            break;
                                        case 6:
                                            customerReportResponseDTO.CommentEvaluationCriteria6 = evaluationCriterias[i].Comment;
                                            break;
                                        case 7:
                                            customerReportResponseDTO.CommentEvaluationCriteria7 = evaluationCriterias[i].Comment;
                                            break;

                                    }

                                }

                                else
                                {
                                    // If no comment is available, set an empty string or handle as needed
                                    switch (i)
                                    {
                                        case 0:
                                            customerReportResponseDTO.CommentEvaluationCriteria = string.Empty;
                                            break;
                                        case 1:
                                            customerReportResponseDTO.CommentEvaluationCriteria1 = string.Empty;
                                            break;
                                        case 2:
                                            customerReportResponseDTO.CommentEvaluationCriteria2 = string.Empty;
                                            break;
                                        case 3:
                                            customerReportResponseDTO.CommentEvaluationCriteria3 = string.Empty;
                                            break;
                                        case 4:
                                            customerReportResponseDTO.CommentEvaluationCriteria4 = string.Empty;
                                            break;
                                        case 5:
                                            customerReportResponseDTO.CommentEvaluationCriteria5 = string.Empty;
                                            break;
                                        case 6:
                                            customerReportResponseDTO.CommentEvaluationCriteria6 = string.Empty;
                                            break;
                                        case 7:
                                            customerReportResponseDTO.CommentEvaluationCriteria7 = string.Empty;
                                            break;
                                    }
                                }
                            }
                            customerReportResponseDTOs.Add(customerReportResponseDTO);
                        }


                        //result.Data = prod;
                    }
                    result.Message = "Success";
                    result.Data = customerReportResponseDTOs;
                    result.Statescode = 200;
                    return result;
                }
                else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
                {
                    List<CustomerReportResponseDTO> customerReportResponseDTOs = new List<CustomerReportResponseDTO>();
                    List<CustomerReport> customerReports = CustomerReportRepoistory.getall().Where(a => a.Month== Month && a.Year == Year && a.user.Id == UserId).ToList();
                    foreach (CustomerReport customerReport in customerReports)
                    {
                        CustomerReportResponseDTO customerReportResponseDTO = new CustomerReportResponseDTO();
                        customerReportResponseDTO.RigId = customerReport.Rig.Number;
                        customerReportResponseDTO.DateFrom = customerReport.DateFrom;
                        customerReportResponseDTO.DateTo = customerReport.DateTo;
                        customerReportResponseDTO.Year = customerReport.Year;
                        //customerReportResponseDTO.RatingId = customerReport.RatingId;
                        //customerReportResponseDTO.RatingName = customerReport.Rating.Name;
                        customerReportResponseDTO.Client = customerReport.Client;
                        customerReportResponseDTO.ClientRepresentative = customerReport.ClientRepresentative;
                        customerReportResponseDTO.Comment = customerReport.Comment;
                        customerReportResponseDTO.Location = customerReport.Location;
                        customerReportResponseDTO.ECDCRepresentative = customerReport.ECDCRepresentative;
                        customerReportResponseDTO.EvaluationResult = customerReport.EvaluationResult;
                        customerReportResponseDTO.Month = customerReport.Month;
                        customerReportResponseDTO.CustomerRepresentative = customerReport.CustomerRepresentative;

                        customerReportResponseDTO.userID = customerReport.user.Id;

                        List<EvaluationCriteria> evaluationCriterias = EvaluationCriteriaRepo.getall().Where(emp => emp.CustomerReportId == customerReport.Id).ToList();



                        // Ensure at least one rating is present
                        if (evaluationCriterias.Any())
                        {
                            // Set the first rating
                            customerReportResponseDTO.Rating = evaluationCriterias[0].Rating;
                            customerReportResponseDTO.Rating1 = evaluationCriterias[1].Rating;
                            customerReportResponseDTO.Rating2 = evaluationCriterias[2].Rating;
                            customerReportResponseDTO.Rating3 = evaluationCriterias[3].Rating;
                            customerReportResponseDTO.Rating4 = evaluationCriterias[4].Rating;
                            customerReportResponseDTO.Rating5 = evaluationCriterias[5].Rating;
                            customerReportResponseDTO.Rating6 = evaluationCriterias[6].Rating;
                            customerReportResponseDTO.Rating7 = evaluationCriterias[7].Rating;

                            // Assign comments based on their count
                            for (int i = 0; i < 8; i++)
                            {
                                // Assign comments only if available
                                if (i < evaluationCriterias.Count)
                                {
                                    switch (i)
                                    {
                                        case 0:
                                            customerReportResponseDTO.CommentEvaluationCriteria = evaluationCriterias[i].Comment;
                                            break;
                                        case 1:
                                            customerReportResponseDTO.CommentEvaluationCriteria1 = evaluationCriterias[i].Comment;
                                            break;
                                        case 2:
                                            customerReportResponseDTO.CommentEvaluationCriteria2 = evaluationCriterias[i].Comment;
                                            break;
                                        case 3:
                                            customerReportResponseDTO.CommentEvaluationCriteria3 = evaluationCriterias[i].Comment;
                                            break;
                                        case 4:
                                            customerReportResponseDTO.CommentEvaluationCriteria4 = evaluationCriterias[i].Comment;
                                            break;
                                        case 5:
                                            customerReportResponseDTO.CommentEvaluationCriteria5 = evaluationCriterias[i].Comment;
                                            break;
                                        case 6:
                                            customerReportResponseDTO.CommentEvaluationCriteria6 = evaluationCriterias[i].Comment;
                                            break;
                                        case 7:
                                            customerReportResponseDTO.CommentEvaluationCriteria7 = evaluationCriterias[i].Comment;
                                            break;

                                    }

                                }

                                else
                                {
                                    // If no comment is available, set an empty string or handle as needed
                                    switch (i)
                                    {
                                        case 0:
                                            customerReportResponseDTO.CommentEvaluationCriteria = string.Empty;
                                            break;
                                        case 1:
                                            customerReportResponseDTO.CommentEvaluationCriteria1 = string.Empty;
                                            break;
                                        case 2:
                                            customerReportResponseDTO.CommentEvaluationCriteria2 = string.Empty;
                                            break;
                                        case 3:
                                            customerReportResponseDTO.CommentEvaluationCriteria3 = string.Empty;
                                            break;
                                        case 4:
                                            customerReportResponseDTO.CommentEvaluationCriteria4 = string.Empty;
                                            break;
                                        case 5:
                                            customerReportResponseDTO.CommentEvaluationCriteria5 = string.Empty;
                                            break;
                                        case 6:
                                            customerReportResponseDTO.CommentEvaluationCriteria6 = string.Empty;
                                            break;
                                        case 7:
                                            customerReportResponseDTO.CommentEvaluationCriteria7 = string.Empty;
                                            break;
                                    }
                                }
                            }
                            customerReportResponseDTOs.Add(customerReportResponseDTO);
                        }



                    }
                    result.Message = "Success";
                    result.Data = customerReportResponseDTOs;
                    result.Statescode = 200;
                    return result;
                }

            }
            catch (Exception ex)
            {
                result.Statescode = 404;
                result.Message = "data not found";
            }

            return result;

        }

        [HttpPost]
        public ActionResult<ResultDTO> AddCustomerReport ([FromForm] CustomerReportDTO customerReport)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    CustomerReport customerReportObj = new CustomerReport();
                    customerReportObj.Id = default;
                    customerReportObj.RigId = customerReport.RigId;

                    customerReportObj.DateFrom = customerReport.DateFrom;
                    customerReportObj.DateTo = customerReport.DateTo;
                    customerReportObj.Year = customerReport.Year;
                    //customerReportObj.RatingId = customerReport.RatingId;

                    customerReportObj.Client = customerReport.Client;
                    customerReportObj.ClientRepresentative = customerReport.ClientRepresentative;
                    customerReportObj.Comment = customerReport.Comment;
                    customerReportObj.Location = customerReport.Location;
                    customerReportObj.ECDCRepresentative = customerReport.ECDCRepresentative;
                    customerReportObj.CustomerRepresentative = customerReport.CustomerRepresentative;
                    customerReportObj.EvaluationResult = customerReport.EvaluationResult;
                    customerReportObj.Month = customerReport.Month;

                    customerReportObj.userID = customerReport.userID;

                    CustomerReportRepo.create(customerReportObj);

                    //EvaluationCriteria evaluationCriterias = new EvaluationCriteria();
                    //evaluationCriterias.CustomerReportId = customerReportObj.Id;
                    //evaluationCriterias.Rating = customerReport.Rating;
                    //EvaluationCriteriaRepo.create(evaluationCriterias);

                    //EvaluationCriteria evaluationCriterias1 = new EvaluationCriteria();
                    //evaluationCriterias.CustomerReportId = customerReportObj.Id;
                    //evaluationCriterias.Rating = customerReport.Rating1;
                    //EvaluationCriteriaRepo.create(evaluationCriterias1);

                    //EvaluationCriteria evaluationCriterias2 = new EvaluationCriteria();
                    //evaluationCriterias.CustomerReportId = customerReportObj.Id;
                    //evaluationCriterias.Rating = customerReport.Rating2;
                    //EvaluationCriteriaRepo.create(evaluationCriterias2);

                    //EvaluationCriteria evaluationCriterias3 = new EvaluationCriteria();
                    //evaluationCriterias.CustomerReportId = customerReportObj.Id;
                    //evaluationCriterias.Rating = customerReport.Rating3;
                    //EvaluationCriteriaRepo.create(evaluationCriterias3);

                    //EvaluationCriteria evaluationCriterias4 = new EvaluationCriteria();
                    //evaluationCriterias.CustomerReportId = customerReportObj.Id;
                    //evaluationCriterias.Rating = customerReport.Rating4;
                    //EvaluationCriteriaRepo.create(evaluationCriterias4);

                    //EvaluationCriteria evaluationCriterias5 = new EvaluationCriteria();
                    //evaluationCriterias.CustomerReportId = customerReportObj.Id;
                    //evaluationCriterias.Rating = customerReport.Rating5;
                    //EvaluationCriteriaRepo.create(evaluationCriterias5);

                    //EvaluationCriteria evaluationCriterias6 = new EvaluationCriteria();
                    //evaluationCriterias.CustomerReportId = customerReportObj.Id;
                    //evaluationCriterias.Rating = customerReport.Rating6;
                    //EvaluationCriteriaRepo.create(evaluationCriterias6);

                    //EvaluationCriteria evaluationCriterias7 = new EvaluationCriteria();
                    //evaluationCriterias.CustomerReportId = customerReportObj.Id;
                    //evaluationCriterias.Rating = customerReport.Rating7;
                    //EvaluationCriteriaRepo.create(evaluationCriterias7);




                    if (!string.IsNullOrEmpty(customerReport.CommentEvaluationCriteria) || !string.IsNullOrEmpty(customerReport.Rating))
                    {
                        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                        evaluationCriteria.CustomerReportId = customerReportObj.Id;

                        // Check if CommentEvaluationCriteria is not null or empty before assigning
                        if (!string.IsNullOrEmpty(customerReport.CommentEvaluationCriteria))
                        {
                            evaluationCriteria.Comment = customerReport.CommentEvaluationCriteria;
                        }

                        evaluationCriteria.Rating = customerReport.Rating;

                        EvaluationCriteriaRepo.create(evaluationCriteria);
                    }

                    if (!string.IsNullOrEmpty(customerReport.CommentEvaluationCriteria1)|| !string.IsNullOrEmpty(customerReport.Rating1))

                    {
                        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                        evaluationCriteria.CustomerReportId = customerReportObj.Id;
                        // Check if CommentEvaluationCriteria is not null or empty before assigning
                        if (!string.IsNullOrEmpty(customerReport.CommentEvaluationCriteria1))
                        {
                            evaluationCriteria.Comment = customerReport.CommentEvaluationCriteria1;
                        }
                        evaluationCriteria.Rating = customerReport.Rating1;

                        EvaluationCriteriaRepo.create(evaluationCriteria);

                    }
                    if (!string.IsNullOrEmpty(customerReport.CommentEvaluationCriteria2)|| !string.IsNullOrEmpty(customerReport.Rating2))

                    {
                        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                        evaluationCriteria.CustomerReportId = customerReportObj.Id;
                        // Check if CommentEvaluationCriteria is not null or empty before assigning
                        if (!string.IsNullOrEmpty(customerReport.CommentEvaluationCriteria2))
                        {
                            evaluationCriteria.Comment = customerReport.CommentEvaluationCriteria2;
                        }
                        evaluationCriteria.Rating = customerReport.Rating2;

                        EvaluationCriteriaRepo.create(evaluationCriteria);

                    }
                    if (!string.IsNullOrEmpty(customerReport.CommentEvaluationCriteria3)|| !string.IsNullOrEmpty(customerReport.Rating3))

                    {
                        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                        evaluationCriteria.CustomerReportId = customerReportObj.Id;
                        // Check if CommentEvaluationCriteria is not null or empty before assigning
                        if (!string.IsNullOrEmpty(customerReport.CommentEvaluationCriteria3))
                        {
                            evaluationCriteria.Comment = customerReport.CommentEvaluationCriteria3;
                        }
                        evaluationCriteria.Rating = customerReport.Rating3;

                        EvaluationCriteriaRepo.create(evaluationCriteria);

                    }
                    if (!string.IsNullOrEmpty(customerReport.CommentEvaluationCriteria4)||!string.IsNullOrEmpty(customerReport.Rating4))

                    {
                        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                        evaluationCriteria.CustomerReportId = customerReportObj.Id;
                        // Check if CommentEvaluationCriteria is not null or empty before assigning
                        if (!string.IsNullOrEmpty(customerReport.CommentEvaluationCriteria4))
                        {
                            evaluationCriteria.Comment = customerReport.CommentEvaluationCriteria4;
                        }
                        evaluationCriteria.Rating = customerReport.Rating4;

                        EvaluationCriteriaRepo.create(evaluationCriteria);
                    }
                    if (!string.IsNullOrEmpty(customerReport.CommentEvaluationCriteria5) || !string.IsNullOrEmpty(customerReport.Rating5))

                    {
                        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                        evaluationCriteria.CustomerReportId = customerReportObj.Id;
                        // Check if CommentEvaluationCriteria is not null or empty before assigning
                        if (!string.IsNullOrEmpty(customerReport.CommentEvaluationCriteria5))
                        {
                            evaluationCriteria.Comment = customerReport.CommentEvaluationCriteria5;
                        }
                        evaluationCriteria.Rating = customerReport.Rating5;

                        EvaluationCriteriaRepo.create(evaluationCriteria);

                    }
                    if (!string.IsNullOrEmpty(customerReport.CommentEvaluationCriteria6)|| !string.IsNullOrEmpty(customerReport.Rating6))

                    {
                        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                        evaluationCriteria.CustomerReportId = customerReportObj.Id;
                        // Check if CommentEvaluationCriteria is not null or empty before assigning
                        if (!string.IsNullOrEmpty(customerReport.CommentEvaluationCriteria6))
                        {
                            evaluationCriteria.Comment = customerReport.CommentEvaluationCriteria6;
                        }
                        evaluationCriteria.Rating = customerReport.Rating6;

                        EvaluationCriteriaRepo.create(evaluationCriteria);

                    }
                    if (!string.IsNullOrEmpty(customerReport.CommentEvaluationCriteria7)||!string.IsNullOrEmpty(customerReport.Rating7))

                    {
                        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                        evaluationCriteria.CustomerReportId = customerReportObj.Id;
                        // Check if CommentEvaluationCriteria is not null or empty before assigning
                        if (!string.IsNullOrEmpty(customerReport.CommentEvaluationCriteria7))
                        {
                            evaluationCriteria.Comment = customerReport.CommentEvaluationCriteria7;
                        }
                        evaluationCriteria.Rating = customerReport.Rating7;

                        EvaluationCriteriaRepo.create(evaluationCriteria);

                    }
                  
                    result.Message = "Success";
                    result.Data = customerReportObj;
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


        //********************* Analysis For User ********************************

        [HttpGet("GetCustomerAnalysisByYearForUser")]
        public ActionResult<ResultDTO> GetCustomerAnalysisByYearForUser(int Year, string UserRole, string UserId)
        {

            ResultDTO result = new ResultDTO();

            try
            {
                if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
                {
                    List<CustomerReport> temp = CustomerReportRepoistory.getall().Where(r => r.Year == Year && r.user.Id == UserId).ToList();

                    List<CustomerReportDTO> newTemp = new List<CustomerReportDTO>();
                    foreach (CustomerReport customerReport in temp)
                    {
                        CustomerReportDTO customerReportResponseDTO = new CustomerReportDTO();
                        customerReportResponseDTO.Id = customerReport.Id;
                        customerReportResponseDTO.RigId = customerReport.Rig.Id;
                        customerReportResponseDTO.EvaluationResult = customerReport.EvaluationResult;
                        customerReportResponseDTO.userID = customerReport.user.Id;
                        customerReportResponseDTO.Month = customerReport.Month;
                        customerReportResponseDTO.RigNumber = customerReport.Rig.Number;

                        newTemp.Add(customerReportResponseDTO);
                    }
                    if (newTemp != null)
                    {

                        result.Message = "Success";
                        result.Statescode = 200;
                        result.Data = newTemp;

                        return result;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Statescode = 404;
                result.Message = "data not found";
            }
            return result;
        }

        /// *********************** Analysis For Admin ************************
        [HttpGet("GetCustomerAnalysisWithCompareByYear")]
        public ActionResult<ResultDTO> GetCustomerAnalysisWithCompareByYear([FromQuery] int Year, string UserRole)
        {

            ResultDTO result = new ResultDTO();

            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<CustomerReport> temp = CustomerReportRepoistory.getall().Where(r => (r.Year == Year)).ToList();

                    List<CustomerReportDTO> newTemp = new List<CustomerReportDTO>();
                    foreach (CustomerReport customerReport in temp)
                    {
                        CustomerReportDTO customerReportResponseDTO = new CustomerReportDTO();
                        customerReportResponseDTO.Id = customerReport.Id;
                        customerReportResponseDTO.RigId = customerReport.Rig.Id;
                        customerReportResponseDTO.RigNumber = customerReport.Rig.Number;

                        customerReportResponseDTO.EvaluationResult = customerReport.EvaluationResult;
                        customerReportResponseDTO.Month = customerReport.Month;
                        customerReportResponseDTO.userID = customerReport.user.Id;

                        newTemp.Add(customerReportResponseDTO);
                    }

                  

                    if (newTemp != null)
                    {

                        result.Message = "Success";
                        result.Statescode = 200;
                        result.Data = newTemp;

                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Statescode = 404;
                result.Message = "data not found";
            }
            return result;
        }

        [HttpGet("GetCustomerAnalysisWithCompareByMonth")]
        public ActionResult<ResultDTO> GetCustomerAnalysisWithCompareByMonth([FromQuery] int Month, string UserRole)
        {

            ResultDTO result = new ResultDTO();

            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<CustomerReport> temp = CustomerReportRepoistory.getall().Where(r => (r.Month == Month)).ToList();
                   
                    List<CustomerReportDTO> newTemp = new List<CustomerReportDTO>();
                    foreach (CustomerReport customerReport in temp)
                    {
                        CustomerReportDTO customerReportResponseDTO = new CustomerReportDTO();
                        customerReportResponseDTO.Id = customerReport.Id;
                        customerReportResponseDTO.RigId = customerReport.Rig.Id;
                        customerReportResponseDTO.EvaluationResult = customerReport.EvaluationResult;
                        customerReportResponseDTO.userID = customerReport.user.Id;
                        customerReportResponseDTO.Month = customerReport.Month;
                        customerReportResponseDTO.RigNumber = customerReport.Rig.Number;

                        newTemp.Add(customerReportResponseDTO);
                    }
                    if (newTemp != null)
                    {

                        result.Message = "Success";
                        result.Statescode = 200;
                        result.Data = newTemp;

                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Statescode = 404;
                result.Message = "data not found";
            }
            return result;
        }

        [HttpGet("GetCustomerAnalysisWithCompareTwoRigsByYear")]
        public ActionResult<ResultDTO> GetCustomerAnalysisWithCompareTwoRigsByYear([FromQuery] int RigID1, int RigID2, int Year, string UserRole)
        {

            ResultDTO result = new ResultDTO();

            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<CustomerReport> temp = CustomerReportRepoistory.getall().Where(r => (r.Rig.Id == RigID1 || r.Rig.Id == RigID2) && (r.Year == Year)).ToList();

                    List<CustomerReportDTO> newTemp = new List<CustomerReportDTO>();
                    foreach (CustomerReport customerReport in temp)
                    {
                        CustomerReportDTO customerReportResponseDTO = new CustomerReportDTO();
                        customerReportResponseDTO.Id = customerReport.Id;
                        customerReportResponseDTO.RigId = customerReport.Rig.Id;
                        customerReportResponseDTO.EvaluationResult = customerReport.EvaluationResult;
                        customerReportResponseDTO.userID = customerReport.user.Id;
                        customerReportResponseDTO.Month = customerReport.Month;
                        customerReportResponseDTO.RigNumber = customerReport.Rig.Number;

                        newTemp.Add(customerReportResponseDTO);
                    }
                    if (newTemp != null)
                    {

                        result.Message = "Success";
                        result.Statescode = 200;
                        result.Data = newTemp;

                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Statescode = 404;
                result.Message = "data not found";
            }
            return result;
        }

        /// *********************** End  Analysis ************************


        [HttpPut("{id:int}")]
        public ActionResult<ResultDTO> Put(int id, [FromForm] CustomerReportDTO newCustometReport) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    CustomerReport orgCustomerReport = CustomerReportRepo.getbyid(id);
                    List<EvaluationCriteria> evaluationCriterias = EvaluationCriteriaRepo.getall().Where(p => p.CustomerReportId == id).ToList();

                    newCustometReport.Id = orgCustomerReport.Id;
                    orgCustomerReport.RigId = newCustometReport.RigId;
                    orgCustomerReport.DateFrom = newCustometReport.DateFrom;
                    orgCustomerReport.DateTo = newCustometReport.DateTo;
                    orgCustomerReport.Year = newCustometReport.Year;
                    //orgCustomerReport.RatingId = newCustometReport.RatingId;
                    orgCustomerReport.Client = newCustometReport.Client;
                    orgCustomerReport.ClientRepresentative = newCustometReport.ClientRepresentative;
                    orgCustomerReport.Comment = newCustometReport.Comment;
                    orgCustomerReport.Location = newCustometReport.Location;
                    orgCustomerReport.ECDCRepresentative = newCustometReport.ECDCRepresentative;
                    orgCustomerReport.EvaluationResult = newCustometReport.EvaluationResult;
                    orgCustomerReport.Month = newCustometReport.Month;
                    orgCustomerReport.CustomerRepresentative = newCustometReport.CustomerRepresentative;
                    orgCustomerReport.IsDeleted = newCustometReport.IsDeleted;

                    if (evaluationCriterias.Count > 0)
                    {
                        for (int i = 0; i < evaluationCriterias.Count; i++)
                        {
                            EvaluationCriteria criteria = evaluationCriterias[i];
                            criteria.IsDeleted = true;
                            EvaluationCriteriaRepo.update(criteria);
                        }
                    }

                    if (!string.IsNullOrEmpty(newCustometReport.Rating))
                    {
                        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                        evaluationCriteria.Rating = newCustometReport.Rating;

                        if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria))
                        {
                            evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria;

                        }
                        EvaluationCriteriaRepo.create(evaluationCriteria);
                    }
                    if (!string.IsNullOrEmpty(newCustometReport.Rating1))
                    {
                        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                        evaluationCriteria.Rating = newCustometReport.Rating1;

                        if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria1))
                        {
                            evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria1;

                        }
                        EvaluationCriteriaRepo.create(evaluationCriteria);
                    }
                    if (!string.IsNullOrEmpty(newCustometReport.Rating2))
                    {
                        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                        evaluationCriteria.Rating = newCustometReport.Rating2;

                        if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria2))
                        {
                            evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria2;

                        }
                        EvaluationCriteriaRepo.create(evaluationCriteria);
                    }
                    if (!string.IsNullOrEmpty(newCustometReport.Rating3))
                    {
                        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                        evaluationCriteria.Rating = newCustometReport.Rating3;

                        if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria3))
                        {
                            evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria3;

                        }
                        EvaluationCriteriaRepo.create(evaluationCriteria);
                    }
                    if (!string.IsNullOrEmpty(newCustometReport.Rating4))
                    {
                        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                        evaluationCriteria.Rating = newCustometReport.Rating4;

                        if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria4))
                        {
                            evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria4;

                        }
                        EvaluationCriteriaRepo.create(evaluationCriteria);
                    }
                    if (!string.IsNullOrEmpty(newCustometReport.Rating5))
                    {
                        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                        evaluationCriteria.Rating = newCustometReport.Rating5;

                        if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria5))
                        {
                            evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria5;

                        }
                        EvaluationCriteriaRepo.create(evaluationCriteria);
                    }
                    if (!string.IsNullOrEmpty(newCustometReport.Rating6))
                    {
                        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                        evaluationCriteria.Rating = newCustometReport.Rating6;

                        if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria6))
                        {
                            evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria6;

                        }
                        EvaluationCriteriaRepo.create(evaluationCriteria);
                    }
                    if (!string.IsNullOrEmpty(newCustometReport.Rating7))
                    {
                        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                        evaluationCriteria.Rating = newCustometReport.Rating7;

                        if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria7))
                        {
                            evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria7;

                        }
                        EvaluationCriteriaRepo.create(evaluationCriteria);
                    }



                    //if (evaluationCriterias.Count == 1)
                    //{
                    //    if (string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria) == null || string.IsNullOrEmpty(newCustometReport.Rating) == null)
                    //    {
                    //        evaluationCriterias[0].IsDeleted = true;
                    //        EvaluationCriteriaRepo.update(evaluationCriterias[0]);
                    //    }
                    //    else
                    //    {
                    //        evaluationCriterias[0].Comment = newCustometReport.CommentEvaluationCriteria;
                    //        evaluationCriterias[0].Rating = newCustometReport.Rating;

                    //        EvaluationCriteriaRepo.update(evaluationCriterias[0]);
                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria1) || string.IsNullOrEmpty(newCustometReport.Rating1))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria1;
                    //        evaluationCriteria.Rating = newCustometReport.Rating1;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria2) || string.IsNullOrEmpty(newCustometReport.Rating2))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria2;
                    //        evaluationCriteria.Rating = newCustometReport.Rating2;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria3) || string.IsNullOrEmpty(newCustometReport.Rating3))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria3;
                    //        evaluationCriteria.Rating = newCustometReport.Rating3;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria4) || string.IsNullOrEmpty(newCustometReport.Rating4))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria4;
                    //        evaluationCriteria.Rating = newCustometReport.Rating4;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria5) || string.IsNullOrEmpty(newCustometReport.Rating5))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria5;
                    //        evaluationCriteria.Rating = newCustometReport.Rating5;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria6) || string.IsNullOrEmpty(newCustometReport.Rating6))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria6;
                    //        evaluationCriteria.Rating = newCustometReport.Rating6;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria7) || string.IsNullOrEmpty(newCustometReport.Rating7))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria7;
                    //        evaluationCriteria.Rating = newCustometReport.Rating7;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }

                    //}

                    //else if (evaluationCriterias.Count == 2)
                    //{
                    //    if (string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria) == null || string.IsNullOrEmpty(newCustometReport.Rating) == null)
                    //    {
                    //        evaluationCriterias[0].IsDeleted = true;
                    //        EvaluationCriteriaRepo.update(evaluationCriterias[0]);
                    //    }
                    //    else
                    //    {
                    //        evaluationCriterias[0].Comment = newCustometReport.CommentEvaluationCriteria;
                    //        evaluationCriterias[0].Rating = newCustometReport.Rating;

                    //        EvaluationCriteriaRepo.update(evaluationCriterias[0]);
                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria1) || string.IsNullOrEmpty(newCustometReport.Rating1))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria1;
                    //        evaluationCriteria.Rating = newCustometReport.Rating1;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria2) || string.IsNullOrEmpty(newCustometReport.Rating2))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria2;
                    //        evaluationCriteria.Rating = newCustometReport.Rating2;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria3) || string.IsNullOrEmpty(newCustometReport.Rating3))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria3;
                    //        evaluationCriteria.Rating = newCustometReport.Rating3;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria4) || string.IsNullOrEmpty(newCustometReport.Rating4))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria4;
                    //        evaluationCriteria.Rating = newCustometReport.Rating4;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria5) || string.IsNullOrEmpty(newCustometReport.Rating5))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria5;
                    //        evaluationCriteria.Rating = newCustometReport.Rating5;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria6) || string.IsNullOrEmpty(newCustometReport.Rating6))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria6;
                    //        evaluationCriteria.Rating = newCustometReport.Rating6;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria7) || string.IsNullOrEmpty(newCustometReport.Rating7))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria7;
                    //        evaluationCriteria.Rating = newCustometReport.Rating7;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }

                    //}

                    //else if (evaluationCriterias.Count == 3)
                    //{
                    //    if (string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria) == null || string.IsNullOrEmpty(newCustometReport.Rating) == null)
                    //    {
                    //        evaluationCriterias[0].IsDeleted = true;
                    //        EvaluationCriteriaRepo.update(evaluationCriterias[0]);
                    //    }
                    //    else
                    //    {
                    //        evaluationCriterias[0].Comment = newCustometReport.CommentEvaluationCriteria;
                    //        evaluationCriterias[0].Rating = newCustometReport.Rating;

                    //        EvaluationCriteriaRepo.update(evaluationCriterias[0]);
                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria1) || string.IsNullOrEmpty(newCustometReport.Rating1))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria1;
                    //        evaluationCriteria.Rating = newCustometReport.Rating1;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria2) || string.IsNullOrEmpty(newCustometReport.Rating2))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria2;
                    //        evaluationCriteria.Rating = newCustometReport.Rating2;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria3) || string.IsNullOrEmpty(newCustometReport.Rating3))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria3;
                    //        evaluationCriteria.Rating = newCustometReport.Rating3;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria4) || string.IsNullOrEmpty(newCustometReport.Rating4))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria4;
                    //        evaluationCriteria.Rating = newCustometReport.Rating4;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria5) || string.IsNullOrEmpty(newCustometReport.Rating5))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria5;
                    //        evaluationCriteria.Rating = newCustometReport.Rating5;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria6) || string.IsNullOrEmpty(newCustometReport.Rating6))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria6;
                    //        evaluationCriteria.Rating = newCustometReport.Rating6;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria7) || string.IsNullOrEmpty(newCustometReport.Rating7))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria7;
                    //        evaluationCriteria.Rating = newCustometReport.Rating7;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }

                    //}

                    //else if (evaluationCriterias.Count == 4)
                    //{
                    //    if (string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria) == null || string.IsNullOrEmpty(newCustometReport.Rating) == null)
                    //    {
                    //        evaluationCriterias[0].IsDeleted = true;
                    //        EvaluationCriteriaRepo.update(evaluationCriterias[0]);
                    //    }
                    //    else
                    //    {
                    //        evaluationCriterias[0].Comment = newCustometReport.CommentEvaluationCriteria;
                    //        evaluationCriterias[0].Rating = newCustometReport.Rating;

                    //        EvaluationCriteriaRepo.update(evaluationCriterias[0]);
                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria1) || string.IsNullOrEmpty(newCustometReport.Rating1))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria1;
                    //        evaluationCriteria.Rating = newCustometReport.Rating1;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria2) || string.IsNullOrEmpty(newCustometReport.Rating2))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria2;
                    //        evaluationCriteria.Rating = newCustometReport.Rating2;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria3) || string.IsNullOrEmpty(newCustometReport.Rating3))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria3;
                    //        evaluationCriteria.Rating = newCustometReport.Rating3;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria4) || string.IsNullOrEmpty(newCustometReport.Rating4))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria4;
                    //        evaluationCriteria.Rating = newCustometReport.Rating4;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria5) || string.IsNullOrEmpty(newCustometReport.Rating5))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria5;
                    //        evaluationCriteria.Rating = newCustometReport.Rating5;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria6) || string.IsNullOrEmpty(newCustometReport.Rating6))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria6;
                    //        evaluationCriteria.Rating = newCustometReport.Rating6;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria7) || string.IsNullOrEmpty(newCustometReport.Rating7))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria7;
                    //        evaluationCriteria.Rating = newCustometReport.Rating7;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }

                    //}
                    //else if (evaluationCriterias.Count == 5)
                    //{
                    //    if (string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria) == null || string.IsNullOrEmpty(newCustometReport.Rating) == null)
                    //    {
                    //        evaluationCriterias[0].IsDeleted = true;
                    //        EvaluationCriteriaRepo.update(evaluationCriterias[0]);
                    //    }
                    //    else
                    //    {
                    //        evaluationCriterias[0].Comment = newCustometReport.CommentEvaluationCriteria;
                    //        evaluationCriterias[0].Rating = newCustometReport.Rating;

                    //        EvaluationCriteriaRepo.update(evaluationCriterias[0]);
                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria1) || string.IsNullOrEmpty(newCustometReport.Rating1))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria1;
                    //        evaluationCriteria.Rating = newCustometReport.Rating1;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria2) || string.IsNullOrEmpty(newCustometReport.Rating2))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria2;
                    //        evaluationCriteria.Rating = newCustometReport.Rating2;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria3) || string.IsNullOrEmpty(newCustometReport.Rating3))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria3;
                    //        evaluationCriteria.Rating = newCustometReport.Rating3;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria4) || string.IsNullOrEmpty(newCustometReport.Rating4))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria4;
                    //        evaluationCriteria.Rating = newCustometReport.Rating4;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria5) || string.IsNullOrEmpty(newCustometReport.Rating5))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria5;
                    //        evaluationCriteria.Rating = newCustometReport.Rating5;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria6) || string.IsNullOrEmpty(newCustometReport.Rating6))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria6;
                    //        evaluationCriteria.Rating = newCustometReport.Rating6;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria7) || string.IsNullOrEmpty(newCustometReport.Rating7))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria7;
                    //        evaluationCriteria.Rating = newCustometReport.Rating7;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }


                    //}
                    //else if (evaluationCriterias.Count == 6)
                    //{
                    //    if (string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria) == null || string.IsNullOrEmpty(newCustometReport.Rating) == null)
                    //    {
                    //        evaluationCriterias[0].IsDeleted = true;
                    //        EvaluationCriteriaRepo.update(evaluationCriterias[0]);
                    //    }
                    //    else
                    //    {
                    //        evaluationCriterias[0].Comment = newCustometReport.CommentEvaluationCriteria;
                    //        evaluationCriterias[0].Rating = newCustometReport.Rating;

                    //        EvaluationCriteriaRepo.update(evaluationCriterias[0]);
                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria1) || string.IsNullOrEmpty(newCustometReport.Rating1))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria1;
                    //        evaluationCriteria.Rating = newCustometReport.Rating1;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria2) || string.IsNullOrEmpty(newCustometReport.Rating2))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria2;
                    //        evaluationCriteria.Rating = newCustometReport.Rating2;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria3) || string.IsNullOrEmpty(newCustometReport.Rating3))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria3;
                    //        evaluationCriteria.Rating = newCustometReport.Rating3;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria4) || string.IsNullOrEmpty(newCustometReport.Rating4))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria4;
                    //        evaluationCriteria.Rating = newCustometReport.Rating4;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria5) || string.IsNullOrEmpty(newCustometReport.Rating5))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria5;
                    //        evaluationCriteria.Rating = newCustometReport.Rating5;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria6) || string.IsNullOrEmpty(newCustometReport.Rating6))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria6;
                    //        evaluationCriteria.Rating = newCustometReport.Rating6;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria7) || string.IsNullOrEmpty(newCustometReport.Rating7))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria7;
                    //        evaluationCriteria.Rating = newCustometReport.Rating7;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }

                    //}
                    //else if (evaluationCriterias.Count == 7)
                    //{
                    //    if (string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria) == null || string.IsNullOrEmpty(newCustometReport.Rating) == null)
                    //    {
                    //        evaluationCriterias[0].IsDeleted = true;
                    //        EvaluationCriteriaRepo.update(evaluationCriterias[0]);
                    //    }
                    //    else
                    //    {
                    //        evaluationCriterias[0].Comment = newCustometReport.CommentEvaluationCriteria;
                    //        evaluationCriterias[0].Rating = newCustometReport.Rating;

                    //        EvaluationCriteriaRepo.update(evaluationCriterias[0]);
                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria1) || string.IsNullOrEmpty(newCustometReport.Rating1))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria1;
                    //        evaluationCriteria.Rating = newCustometReport.Rating1;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria2) || string.IsNullOrEmpty(newCustometReport.Rating2))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria2;
                    //        evaluationCriteria.Rating = newCustometReport.Rating2;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria3) || string.IsNullOrEmpty(newCustometReport.Rating3))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria3;
                    //        evaluationCriteria.Rating = newCustometReport.Rating3;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria4) || string.IsNullOrEmpty(newCustometReport.Rating4))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria4;
                    //        evaluationCriteria.Rating = newCustometReport.Rating4;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria5) || string.IsNullOrEmpty(newCustometReport.Rating5))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria5;
                    //        evaluationCriteria.Rating = newCustometReport.Rating5;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria6) || string.IsNullOrEmpty(newCustometReport.Rating6))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria6;
                    //        evaluationCriteria.Rating = newCustometReport.Rating6;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria7) || string.IsNullOrEmpty(newCustometReport.Rating7))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria7;
                    //        evaluationCriteria.Rating = newCustometReport.Rating7;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }

                    //}
                    //else if (evaluationCriterias.Count == 8)
                    //{
                    //    if (string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria) == null || string.IsNullOrEmpty(newCustometReport.Rating) == null)
                    //    {
                    //        evaluationCriterias[0].IsDeleted = true;
                    //        EvaluationCriteriaRepo.update(evaluationCriterias[0]);
                    //    }
                    //    else
                    //    {
                    //        evaluationCriterias[0].Comment = newCustometReport.CommentEvaluationCriteria;
                    //        evaluationCriterias[0].Rating = newCustometReport.Rating;

                    //        EvaluationCriteriaRepo.update(evaluationCriterias[0]);
                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria1) || string.IsNullOrEmpty(newCustometReport.Rating1))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria1;
                    //        evaluationCriteria.Rating = newCustometReport.Rating1;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria2) || string.IsNullOrEmpty(newCustometReport.Rating2))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria2;
                    //        evaluationCriteria.Rating = newCustometReport.Rating2;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria3) || string.IsNullOrEmpty(newCustometReport.Rating3))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria3;
                    //        evaluationCriteria.Rating = newCustometReport.Rating3;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria4) || string.IsNullOrEmpty(newCustometReport.Rating4))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria4;
                    //        evaluationCriteria.Rating = newCustometReport.Rating4;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria5) || string.IsNullOrEmpty(newCustometReport.Rating5))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria5;
                    //        evaluationCriteria.Rating = newCustometReport.Rating5;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria6) || string.IsNullOrEmpty(newCustometReport.Rating6))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria6;
                    //        evaluationCriteria.Rating = newCustometReport.Rating6;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria7) || string.IsNullOrEmpty(newCustometReport.Rating7))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria7;
                    //        evaluationCriteria.Rating = newCustometReport.Rating7;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }

                    //}

                    //else if (evaluationCriterias.Count == 0)
                    //{
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria) || string.IsNullOrEmpty(newCustometReport.Rating))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria;
                    //        evaluationCriteria.Rating = newCustometReport.Rating;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }

                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria1) || string.IsNullOrEmpty(newCustometReport.Rating1))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria1;
                    //        evaluationCriteria.Rating = newCustometReport.Rating1;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria2) || string.IsNullOrEmpty(newCustometReport.Rating2))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria2;
                    //        evaluationCriteria.Rating = newCustometReport.Rating2;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria3) || string.IsNullOrEmpty(newCustometReport.Rating3))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria3;
                    //        evaluationCriteria.Rating = newCustometReport.Rating;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria4) || string.IsNullOrEmpty(newCustometReport.Rating4))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria4;
                    //        evaluationCriteria.Rating = newCustometReport.Rating4;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria5) || string.IsNullOrEmpty(newCustometReport.Rating5))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria5;
                    //        evaluationCriteria.Rating = newCustometReport.Rating5;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria6) || string.IsNullOrEmpty(newCustometReport.Rating6))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria6;
                    //        evaluationCriteria.Rating = newCustometReport.Rating6;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }
                    //    if (!string.IsNullOrEmpty(newCustometReport.CommentEvaluationCriteria7) || string.IsNullOrEmpty(newCustometReport.Rating7))

                    //    {
                    //        EvaluationCriteria evaluationCriteria = new EvaluationCriteria();
                    //        evaluationCriteria.CustomerReportId = newCustometReport.Id;
                    //        evaluationCriteria.Comment = newCustometReport.CommentEvaluationCriteria7;
                    //        evaluationCriteria.Rating = newCustometReport.Rating7;

                    //        EvaluationCriteriaRepo.create(evaluationCriteria);

                    //    }



                    //}

                    CustomerReportRepo.update(orgCustomerReport);
                        result.Data = orgCustomerReport;
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

        [HttpPut("Delete/{id:int}")]
        public ActionResult<ResultDTO> Delete(int id) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();
            try
            {
                List<EvaluationCriteria> evaluationCriterias = EvaluationCriteriaRepo.getall().Where(p => p.CustomerReportId == id).ToList();
                foreach (var item in evaluationCriterias)
                {
                    EvaluationCriteria evaluationCriteria = EvaluationCriteriaRepo.getbyid(item.Id);
                    evaluationCriteria.IsDeleted = true;

                    EvaluationCriteriaRepo.update(evaluationCriteria);

                }
                CustomerReport customerReport = CustomerReportRepo.getbyid(id);
                customerReport.IsDeleted = true;
                CustomerReportRepo.update(customerReport);
                result.Data = customerReport;
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

