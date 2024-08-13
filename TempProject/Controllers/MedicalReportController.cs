using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using TempProject.DTO;
using TempProject.DTO.ResponseDTO;
using TempProject.Helper;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalReportController : ControllerBase
    {
        public IRepository<MedicalReport> MedicalReportRepo { get; set; }

        public IMedicalReportRepossitory MedicalReportRepoistory { get; set; }

        private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager;


        public MedicalReportController(Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager,
            IRepository<MedicalReport> _MedicalReportRepo,
            IMedicalReportRepossitory _MedicalReportRepoistory)

            
        {
            this.MedicalReportRepo = _MedicalReportRepo;
            this.MedicalReportRepoistory = _MedicalReportRepoistory;
            this.userManager = _userManager;
           

        }

        [HttpGet("GetData")]
        public async Task<ResultDTO> GetAllWithData(string UserID, string UserRole)
        {
            ResultDTO result = new ResultDTO();

            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<MedicalReport> temp = MedicalReportRepoistory.getall();
                    List<MedicalReportResponseDTO> newTemp = new List<MedicalReportResponseDTO>();
                    foreach (MedicalReport MedicalReport in temp)
                    {
                        MedicalReportResponseDTO MedicalDTO = new MedicalReportResponseDTO();
                        MedicalDTO.Id = MedicalReport.Id;
                        MedicalDTO.RigId = MedicalReport.Rig.Number;
                        MedicalDTO.Date = MedicalReport.Date;
                        MedicalDTO.DateOfBirth = MedicalReport.DateOfBirth;
                        MedicalDTO.Address = MedicalReport.Address;
                        MedicalDTO.Age = MedicalReport.Age;
                        MedicalDTO.TypeOfIncidentName = MedicalReport.TypeOfIncident.Name;
                        if (MedicalReport.TypeOfIncidentId != null)
                        {
                            MedicalDTO.TypeOfIncidentId = (int)MedicalReport.TypeOfIncidentId;
                        }
                        else
                        {
                            MedicalDTO.TypeOfIncidentId = 1;
                        }
                        MedicalDTO.Company = MedicalReport.Company;
                        MedicalDTO.Job = MedicalReport.Job;
                        MedicalDTO.Code = MedicalReport.Code;
                        MedicalDTO.IsTheIllHealth = MedicalReport.IsTheIllHealth;
                        MedicalDTO.TelephoneNumber = MedicalReport.TelephoneNumber;
                        MedicalDTO.Diagnosis = MedicalReport.Diagnosis;
                        MedicalDTO.DoctorComment = MedicalReport.DoctorComment;
                        MedicalDTO.DoctorRecommendation = MedicalReport.DoctorRecommendation;

                        MedicalDTO.Name = MedicalReport.Name;

                        MedicalDTO.RigManager = MedicalReport.RigManager;
                        MedicalDTO.RigDoctor = MedicalReport.RigDoctor;
                        MedicalDTO.QHSEEngineer = MedicalReport.QHSEEngineer;

                        MedicalDTO.userName = MedicalReport.user.UserName;
                        MedicalDTO.userID = MedicalReport.user.Id;

                        newTemp.Add(MedicalDTO);

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
                    List<MedicalReport> temp = MedicalReportRepoistory.getall().Where(a => a.user.Id == UserID).ToList();
                    List<MedicalReportResponseDTO> newTemp = new List<MedicalReportResponseDTO>();
                    foreach (MedicalReport MedicalReport in temp)
                    {
                        MedicalReportResponseDTO MedicalDTO = new MedicalReportResponseDTO();
                        MedicalDTO.Id = MedicalReport.Id;
                        MedicalDTO.RigId = MedicalReport.Rig.Number;
                        MedicalDTO.Date = MedicalReport.Date;
                        MedicalDTO.DateOfBirth = MedicalReport.DateOfBirth;
                        MedicalDTO.Address = MedicalReport.Address;
                        MedicalDTO.Age = MedicalReport.Age;
                        MedicalDTO.TypeOfIncidentName = MedicalReport.TypeOfIncident.Name;
                        if (MedicalReport.TypeOfIncidentId != null)
                        {
                            MedicalDTO.TypeOfIncidentId = (int)MedicalReport.TypeOfIncidentId;
                        }
                        else
                        {
                            MedicalDTO.TypeOfIncidentId = 1;
                        }
                        MedicalDTO.Company = MedicalReport.Company;
                        MedicalDTO.Job = MedicalReport.Job;
                        MedicalDTO.Code = MedicalReport.Code;
                        MedicalDTO.IsTheIllHealth = MedicalReport.IsTheIllHealth;
                        MedicalDTO.TelephoneNumber = MedicalReport.TelephoneNumber;
                        MedicalDTO.Diagnosis = MedicalReport.Diagnosis;
                        MedicalDTO.DoctorComment = MedicalReport.DoctorComment;
                        MedicalDTO.DoctorRecommendation = MedicalReport.DoctorRecommendation;

                        MedicalDTO.Name = MedicalReport.Name;

                        MedicalDTO.RigManager = MedicalReport.RigManager;
                        MedicalDTO.RigDoctor = MedicalReport.RigDoctor;
                        MedicalDTO.QHSEEngineer = MedicalReport.QHSEEngineer;

                        MedicalDTO.userName = MedicalReport.user.UserName;
                        MedicalDTO.userID = MedicalReport.user.Id;

                        newTemp.Add(MedicalDTO);
                        if (newTemp != null)
                        {
                            result.Message = "Success";
                            result.Statescode = 200;
                            result.Data = newTemp;

                            return result;
                        }
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
        public PageResult<MedicalReportResponseDTO> GettAllMedicalReportByPage(string UserId, string UserRole, int? page, int pagesize = 10)
        {

            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<MedicalReport> temp = MedicalReportRepoistory.getall();
                    List<MedicalReportResponseDTO> newTemp = new List<MedicalReportResponseDTO>();
                    foreach (MedicalReport MedicalReport in temp)
                    {

                        MedicalReportResponseDTO MedicalDTO = new MedicalReportResponseDTO();
                        MedicalDTO.Id = MedicalReport.Id;
                        MedicalDTO.RigId = MedicalReport.Rig.Number;
                        MedicalDTO.Date = MedicalReport.Date;
                        MedicalDTO.DateOfBirth = MedicalReport.DateOfBirth;
                        MedicalDTO.Address = MedicalReport.Address;
                        MedicalDTO.Age = MedicalReport.Age;
                        MedicalDTO.TypeOfIncidentName = MedicalReport.TypeOfIncident.Name;
                        if (MedicalReport.TypeOfIncidentId != null)
                        {
                            MedicalDTO.TypeOfIncidentId = (int)MedicalReport.TypeOfIncidentId;
                        }
                        else
                        {
                            MedicalDTO.TypeOfIncidentId = 1;
                        }
                        MedicalDTO.Company = MedicalReport.Company;
                        MedicalDTO.Job = MedicalReport.Job;
                        MedicalDTO.Code = MedicalReport.Code;
                        MedicalDTO.IsTheIllHealth = MedicalReport.IsTheIllHealth;
                        MedicalDTO.TelephoneNumber = MedicalReport.TelephoneNumber;
                        MedicalDTO.Diagnosis = MedicalReport.Diagnosis;
                        MedicalDTO.DoctorComment = MedicalReport.DoctorComment;
                        MedicalDTO.DoctorRecommendation = MedicalReport.DoctorRecommendation;
                        MedicalDTO.Name = MedicalReport.Name;


                        MedicalDTO.RigManager = MedicalReport.RigManager;
                        MedicalDTO.RigDoctor = MedicalReport.RigDoctor;
                        MedicalDTO.QHSEEngineer = MedicalReport.QHSEEngineer;

                        MedicalDTO.userName = MedicalReport.user.UserName;
                        MedicalDTO.userID = MedicalReport.user.Id;


                        newTemp.Add(MedicalDTO);
                        //result.Data = prod;
                    }

                    float countDetails = MedicalReportRepoistory.getall().Count();
                    var result = new PageResult<MedicalReportResponseDTO>
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
                    List<MedicalReport> temp = MedicalReportRepoistory.getall().Where(a => a.user.Id == UserId).ToList();
                    List<MedicalReportResponseDTO> newTemp = new List<MedicalReportResponseDTO>();
                    foreach (MedicalReport MedicalReport in temp)
                    {
                        MedicalReportResponseDTO MedicalDTO = new MedicalReportResponseDTO();
                        MedicalDTO.Id = MedicalReport.Id;
                        MedicalDTO.RigId = MedicalReport.Rig.Number;
                        MedicalDTO.Date = MedicalReport.Date;
                        MedicalDTO.DateOfBirth = MedicalReport.DateOfBirth;
                        MedicalDTO.Address = MedicalReport.Address;
                        MedicalDTO.Age = MedicalReport.Age;
                        MedicalDTO.TypeOfIncidentName = MedicalReport.TypeOfIncident.Name;
                        if (MedicalReport.TypeOfIncidentId != null)
                        {
                            MedicalDTO.TypeOfIncidentId = (int)MedicalReport.TypeOfIncidentId;
                        }
                        else
                        {
                            MedicalDTO.TypeOfIncidentId = 1;
                        }
                        MedicalDTO.Company = MedicalReport.Company;
                        MedicalDTO.Job = MedicalReport.Job;
                        MedicalDTO.Code = MedicalReport.Code;
                        MedicalDTO.IsTheIllHealth = MedicalReport.IsTheIllHealth;
                        MedicalDTO.TelephoneNumber = MedicalReport.TelephoneNumber;
                        MedicalDTO.Diagnosis = MedicalReport.Diagnosis;
                        MedicalDTO.DoctorComment = MedicalReport.DoctorComment;
                        MedicalDTO.DoctorRecommendation = MedicalReport.DoctorRecommendation;
                        MedicalDTO.Name = MedicalReport.Name;


                        MedicalDTO.RigManager = MedicalReport.RigManager;
                        MedicalDTO.RigDoctor = MedicalReport.RigDoctor;
                        MedicalDTO.QHSEEngineer = MedicalReport.QHSEEngineer;
                        MedicalDTO.userName = MedicalReport.user.UserName;
                        MedicalDTO.userID = MedicalReport.user.Id;



                        newTemp.Add(MedicalDTO);
                    }

                    float countDetails = MedicalReportRepoistory.getall().Where(a => a.user.Id == UserId).Count();
                    var result = new PageResult<MedicalReportResponseDTO>
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
                return new PageResult<MedicalReportResponseDTO>();

            }
            return new PageResult<MedicalReportResponseDTO>();
        }

        [HttpGet("GetDataById/{ID:int}")]
        public ActionResult<ResultDTO> GetAllWithDataByID(int ID, string UserId, string UserRole)
        {
            ResultDTO result = new ResultDTO();


            if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                MedicalReport temp = MedicalReportRepoistory.getall().FirstOrDefault(a => a.Id == ID);
                if (temp != null)
                {
                    MedicalReportResponseDTO MedicalDTO = new MedicalReportResponseDTO();

                    MedicalDTO.Id = temp.Id;
                    MedicalDTO.RigId = temp.Rig.Number;
                    MedicalDTO.Date = temp.Date;
                    MedicalDTO.DateOfBirth = temp.DateOfBirth;
                    MedicalDTO.Address = temp.Address;
                    MedicalDTO.Age = temp.Age;
                    MedicalDTO.TypeOfIncidentName = temp.TypeOfIncident.Name;
                    if (temp.TypeOfIncidentId != null)
                    {
                        MedicalDTO.TypeOfIncidentId = (int)temp.TypeOfIncidentId;
                    }
                    else
                    {
                        MedicalDTO.TypeOfIncidentId = 1;
                    }
                    MedicalDTO.Company = temp.Company;
                    MedicalDTO.Job = temp.Job;
                    MedicalDTO.Code = temp.Code;
                    MedicalDTO.IsTheIllHealth = temp.IsTheIllHealth;
                    MedicalDTO.TelephoneNumber = temp.TelephoneNumber;
                    MedicalDTO.Diagnosis = temp.Diagnosis;
                    MedicalDTO.DoctorComment = temp.DoctorComment;
                    MedicalDTO.DoctorRecommendation = temp.DoctorRecommendation;

                    MedicalDTO.Name = temp.Name;

                    MedicalDTO.RigManager = temp.RigManager;
                    MedicalDTO.RigDoctor = temp.RigDoctor;
                    MedicalDTO.QHSEEngineer = temp.QHSEEngineer;
                    MedicalDTO.userID = temp.user.Id;

                

                    if (MedicalDTO != null)
                    {

                        result.Message = "Success";
                        result.Statescode = 200;
                        result.Data = MedicalDTO;

                        return result;
                    }
                }

            }
            else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
            {
                MedicalReport temp = MedicalReportRepoistory.getall().FirstOrDefault(a => a.Id == ID && a.user.Id == UserId);
                if (temp != null)
                {
                    MedicalReportResponseDTO MedicalDTO = new MedicalReportResponseDTO();
                    MedicalDTO.Id = temp.Id;
                    MedicalDTO.RigId = temp.Rig.Number;
                    MedicalDTO.Date = temp.Date;
                    MedicalDTO.DateOfBirth = temp.DateOfBirth;
                    MedicalDTO.Address = temp.Address;
                    MedicalDTO.Age = temp.Age;
                    MedicalDTO.TypeOfIncidentName = temp.TypeOfIncident.Name;
                    if (temp.TypeOfIncidentId != null)
                    {
                        MedicalDTO.TypeOfIncidentId = (int)temp.TypeOfIncidentId;
                    }
                    else
                    {
                        MedicalDTO.TypeOfIncidentId = 1;
                    }
                    MedicalDTO.Company = temp.Company;
                    MedicalDTO.Job = temp.Job;
                    MedicalDTO.Code = temp.Code;
                    MedicalDTO.IsTheIllHealth = temp.IsTheIllHealth;
                    MedicalDTO.TelephoneNumber = temp.TelephoneNumber;
                    MedicalDTO.Diagnosis = temp.Diagnosis;
                    MedicalDTO.DoctorComment = temp.DoctorComment;
                    MedicalDTO.DoctorRecommendation = temp.DoctorRecommendation;
                    MedicalDTO.Name = temp.Name;


                    MedicalDTO.RigManager = temp.RigManager;
                    MedicalDTO.RigDoctor = temp.RigDoctor;
                    MedicalDTO.QHSEEngineer = temp.QHSEEngineer;
                    MedicalDTO.userID = temp.user.Id;
                

                    if (MedicalDTO != null)
                    {

                        result.Message = "Success";
                        result.Statescode = 200;
                        result.Data = MedicalDTO;

                        return result;
                    }
                }

            }

            result.Statescode = 404;
            result.Message = "data not found";
            return result;
        }

        //  ------------------filter by MedicalReportType------------------------------------------

        //[HttpGet("GetDataByRigAndDateAndName {RigNumber:int}")]
        //public ActionResult<ResultDTO> GetDataByRigAndDateAndName( string Name ,string UserId, string UserRole,string date, int RigNumber ,string Jop)
        //{
        //    DateTime dateObject = DateTime.Parse(date);
        //    // Decode the URL-encoded parameters
        //    //string decodedName = WebUtility.UrlDecode(Name);
        //    //string decodedJop = WebUtility.UrlDecode(Jop);
        //    ResultDTO result = new ResultDTO();

        //    try
        //    {
        //        if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
        //        {
        //            List<MedicalReportResponseDTO> MedicalReportDTOs = new List<MedicalReportResponseDTO>();
        //            List<MedicalReport> MedicalReports = MedicalReportRepoistory.getall().Where(a =>
        //                a.Name == Name &&
        //                a.Job == Jop &&
        //                a.Rig.Number == RigNumber &&
        //                DateTime.SpecifyKind(a.Date, DateTimeKind.Utc) == dateObject.ToUniversalTime()
        //            ).ToList();
        //            foreach (MedicalReport MedicalReport in MedicalReports)
        //            {
        //                MedicalReportResponseDTO MedicalDTO = new MedicalReportResponseDTO();
        //                MedicalDTO.Id = MedicalReport.Id;
        //                MedicalDTO.RigId = MedicalReport.Rig.Number;
        //                MedicalDTO.Date = MedicalReport.Date;
        //                MedicalDTO.DateOfBirth = MedicalReport.DateOfBirth;
        //                MedicalDTO.Address = MedicalReport.Address;
        //                MedicalDTO.Age = MedicalReport.Age;
        //                MedicalDTO.TypeOfIncidentName = MedicalReport.TypeOfIncident.Name;
        //                if (MedicalReport.TypeOfIncidentId != null)
        //                {
        //                    MedicalDTO.TypeOfIncidentId = (int)MedicalReport.TypeOfIncidentId;
        //                }
        //                else
        //                {
        //                    MedicalDTO.TypeOfIncidentId = 1;
        //                }
        //                MedicalDTO.Company = MedicalReport.Company;
        //                MedicalDTO.Job = MedicalReport.Job;
        //                MedicalDTO.Code = MedicalReport.Code;
        //                MedicalDTO.IsTheIllHealth = MedicalReport.IsTheIllHealth;
        //                MedicalDTO.TelephoneNumber = MedicalReport.TelephoneNumber;
        //                MedicalDTO.Diagnosis = MedicalReport.Diagnosis;
        //                MedicalDTO.DoctorComment = MedicalReport.DoctorComment;
        //                MedicalDTO.DoctorRecommendation = MedicalReport.DoctorRecommendation;
        //                MedicalDTO.Name = MedicalReport.Name;
        //                MedicalDTO.RigManager = MedicalReport.RigManager;
        //                MedicalDTO.RigDoctor = MedicalReport.RigDoctor;
        //                MedicalDTO.QHSEEngineer = MedicalReport.QHSEEngineer;

        //                MedicalDTO.userID = MedicalReport.user.Id;
        //                MedicalDTO.userName = MedicalReport.user.UserName;

        //                MedicalReportDTOs.Add(MedicalDTO);
        //            }
        //            result.Message = "Success";
        //            result.Data = MedicalReportDTOs;
        //            result.Statescode = 200;
        //            return result;
        //        }
        //        else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
        //        {
        //            List<MedicalReportResponseDTO> MedicalReportDTOs = new List<MedicalReportResponseDTO>();
        //            List<MedicalReport> MedicalReports = MedicalReportRepoistory.getall().Where(a =>  a.Name==Name &&  a.Job == Jop && a.Rig.Number == RigNumber && a.Date == dateObject&& a.user.Id == UserId).ToList();
        //            foreach (MedicalReport MedicalReport in MedicalReports)
        //            {
        //                MedicalReportResponseDTO MedicalDTO = new MedicalReportResponseDTO();
        //                MedicalDTO.Id = MedicalReport.Id;
        //                MedicalDTO.RigId = MedicalReport.Rig.Number;
        //                MedicalDTO.Date = MedicalReport.Date;
        //                MedicalDTO.DateOfBirth = MedicalReport.DateOfBirth;
        //                MedicalDTO.Address = MedicalReport.Address;
        //                MedicalDTO.Age = MedicalReport.Age;
        //                MedicalDTO.TypeOfIncidentName = MedicalReport.TypeOfIncident.Name;
        //                if (MedicalReport.TypeOfIncidentId != null)
        //                {
        //                    MedicalDTO.TypeOfIncidentId = (int)MedicalReport.TypeOfIncidentId;
        //                }
        //                else
        //                {
        //                    MedicalDTO.TypeOfIncidentId = 1;
        //                }
        //                MedicalDTO.Company = MedicalReport.Company;
        //                MedicalDTO.Job = MedicalReport.Job;
        //                MedicalDTO.Code = MedicalReport.Code;
        //                MedicalDTO.IsTheIllHealth = MedicalReport.IsTheIllHealth;
        //                MedicalDTO.TelephoneNumber = MedicalReport.TelephoneNumber;
        //                MedicalDTO.Diagnosis = MedicalReport.Diagnosis;
        //                MedicalDTO.DoctorComment = MedicalReport.DoctorComment;
        //                MedicalDTO.DoctorRecommendation = MedicalReport.DoctorRecommendation;

        //                MedicalDTO.Name = MedicalReport.Name;

        //                MedicalDTO.RigManager = MedicalReport.RigManager;
        //                MedicalDTO.RigDoctor = MedicalReport.RigDoctor;
        //                MedicalDTO.QHSEEngineer = MedicalReport.QHSEEngineer;

        //                MedicalReportDTOs.Add(MedicalDTO);
        //            }
        //            result.Message = "Success";
        //            result.Data = MedicalReportDTOs;
        //            result.Statescode = 200;
        //            return result;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.Statescode = 404;
        //        result.Message = "data not found";
        //    }

        //    return result;

        //}

        [HttpGet("GetDataByRigAndDateAndName{RigNumber:int}")]
        public ActionResult<ResultDTO> GetDataByRigAndDateAndName(string Name, string UserId, string UserRole, DateTime date, int RigNumber ,string Jop)
        {
            ResultDTO result = new ResultDTO();

            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<MedicalReportResponseDTO> MedicalReportDTOs = new List<MedicalReportResponseDTO>();
                    List<MedicalReport> MedicalReports = MedicalReportRepoistory.getall().Where(a => a.Name == Name && a.Rig.Number == RigNumber && a.Date.Date == date.Date && a.Job == Jop).ToList();
                    foreach (MedicalReport MedicalReport in MedicalReports)
                    {
                        MedicalReportResponseDTO MedicalDTO = new MedicalReportResponseDTO();
                        MedicalDTO.Id = MedicalReport.Id;
                        MedicalDTO.RigId = MedicalReport.Rig.Number;
                        MedicalDTO.Date = MedicalReport.Date;
                        MedicalDTO.DateOfBirth = MedicalReport.DateOfBirth;
                        MedicalDTO.Address = MedicalReport.Address;
                        MedicalDTO.Age = MedicalReport.Age;
                        MedicalDTO.TypeOfIncidentName = MedicalReport.TypeOfIncident.Name;
                        if (MedicalReport.TypeOfIncidentId != null)
                        {
                            MedicalDTO.TypeOfIncidentId = (int)MedicalReport.TypeOfIncidentId;
                        }
                        else
                        {
                            MedicalDTO.TypeOfIncidentId = 1;
                        }
                        MedicalDTO.Company = MedicalReport.Company;
                        MedicalDTO.Job = MedicalReport.Job;
                        MedicalDTO.Code = MedicalReport.Code;
                        MedicalDTO.IsTheIllHealth = MedicalReport.IsTheIllHealth;
                        MedicalDTO.TelephoneNumber = MedicalReport.TelephoneNumber;
                        MedicalDTO.Diagnosis = MedicalReport.Diagnosis;
                        MedicalDTO.DoctorComment = MedicalReport.DoctorComment;
                        MedicalDTO.DoctorRecommendation = MedicalReport.DoctorRecommendation;

                        MedicalDTO.Name = MedicalReport.Name;

                        MedicalDTO.RigManager = MedicalReport.RigManager;
                        MedicalDTO.RigDoctor = MedicalReport.RigDoctor;
                        MedicalDTO.QHSEEngineer = MedicalReport.QHSEEngineer;

                        MedicalDTO.userName = MedicalReport.user.UserName;
                        MedicalDTO.userID = MedicalReport.user.Id;



                        MedicalReportDTOs.Add(MedicalDTO);
                        //result.Data = prod;
                    }
                    result.Message = "Success";
                    result.Data = MedicalReportDTOs;
                    result.Statescode = 200;
                    return result;
                }
                else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
                {
                    List<MedicalReportResponseDTO> MedicalReportDTOs = new List<MedicalReportResponseDTO>();
                    List<MedicalReport> MedicalReports = MedicalReportRepoistory.getall().Where(a => a.Name == Name && a.Rig.Number == RigNumber && a.Date.Date == date.Date && a.Job == Jop && a.user.Id == UserId).ToList();
                    foreach (MedicalReport MedicalReport in MedicalReports)
                    {
                        MedicalReportResponseDTO MedicalDTO = new MedicalReportResponseDTO();
                        MedicalDTO.Id = MedicalReport.Id;
                        MedicalDTO.RigId = MedicalReport.Rig.Number;
                        MedicalDTO.Date = MedicalReport.Date;
                        MedicalDTO.DateOfBirth = MedicalReport.DateOfBirth;
                        MedicalDTO.Address = MedicalReport.Address;
                        MedicalDTO.Age = MedicalReport.Age;
                        MedicalDTO.TypeOfIncidentName = MedicalReport.TypeOfIncident.Name;
                        if (MedicalReport.TypeOfIncidentId != null)
                        {
                            MedicalDTO.TypeOfIncidentId = (int)MedicalReport.TypeOfIncidentId;
                        }
                        else
                        {
                            MedicalDTO.TypeOfIncidentId = 1;
                        }
                        MedicalDTO.Company = MedicalReport.Company;
                        MedicalDTO.Job = MedicalReport.Job;
                        MedicalDTO.Code = MedicalReport.Code;
                        MedicalDTO.IsTheIllHealth = MedicalReport.IsTheIllHealth;
                        MedicalDTO.TelephoneNumber = MedicalReport.TelephoneNumber;
                        MedicalDTO.Diagnosis = MedicalReport.Diagnosis;
                        MedicalDTO.DoctorComment = MedicalReport.DoctorComment;
                        MedicalDTO.DoctorRecommendation = MedicalReport.DoctorRecommendation;

                        MedicalDTO.Name = MedicalReport.Name;

                        MedicalDTO.RigManager = MedicalReport.RigManager;
                        MedicalDTO.RigDoctor = MedicalReport.RigDoctor;
                        MedicalDTO.QHSEEngineer = MedicalReport.QHSEEngineer;

                        MedicalDTO.userName = MedicalReport.user.UserName;
                        MedicalDTO.userID = MedicalReport.user.Id;



                        MedicalReportDTOs.Add(MedicalDTO);
                    }
                    result.Message = "Success";
                    result.Data = MedicalReportDTOs;
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
        public ActionResult<ResultDTO> AddMedicalReport ([FromForm] MedicalReportDTO MedicalReport)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    MedicalReport MedicalDTO = new MedicalReport();
                    MedicalDTO.RigId = MedicalReport.RigId;
                    MedicalDTO.Date = MedicalReport.Date;
                    MedicalDTO.DateOfBirth = MedicalReport.DateOfBirth;
                    MedicalDTO.Address = MedicalReport.Address;
                    MedicalDTO.Age = MedicalReport.Age;

                    if (MedicalReport.TypeOfIncidentId != null)
                    {
                        MedicalDTO.TypeOfIncidentId = MedicalReport.TypeOfIncidentId;
                    }
                    else
                    {
                        MedicalDTO.TypeOfIncidentId = 1;
                    }
                    MedicalDTO.Company = MedicalReport.Company;
                    MedicalDTO.Job = MedicalReport.Job;
                    MedicalDTO.Code = MedicalReport.Code;
                    MedicalDTO.IsTheIllHealth = MedicalReport.IsTheIllHealth;
                    MedicalDTO.TelephoneNumber = MedicalReport.TelephoneNumber;
                    MedicalDTO.Diagnosis = MedicalReport.Diagnosis;
                    MedicalDTO.DoctorComment = MedicalReport.DoctorComment;
                    MedicalDTO.DoctorRecommendation = MedicalReport.DoctorRecommendation;

                    MedicalDTO.Name = MedicalReport.Name;

                    MedicalDTO.RigManager = MedicalReport.RigManager;
                    MedicalDTO.RigDoctor = MedicalReport.RigDoctor;
                    MedicalDTO.QHSEEngineer = MedicalReport.QHSEEngineer;
                    MedicalDTO.userID = MedicalReport.UserId;

                    MedicalReportRepo.create(MedicalDTO);
                    result.Message = "Success";
                    result.Data = MedicalDTO;
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


        /// *********************** Analysis For Admin ************************

        [HttpGet("GetMedicalReportAnalysisWithCompareByYear")]
        public ActionResult<ResultDTO> GetMedicalReportAnalysisWithCompareByYear([FromQuery] int Year, string UserRole)
        {

            ResultDTO result = new ResultDTO();

            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<MedicalReport> temp = MedicalReportRepoistory.getall().Where(r => (r.Date.Year == Year)).ToList();


                    List<MedicalReportResponseDTO> newTemp = new List<MedicalReportResponseDTO>();
                    foreach (MedicalReport medicalReport in temp)
                    {
                        MedicalReportResponseDTO medicalReportResponseDTO  = new MedicalReportResponseDTO();
                        medicalReportResponseDTO.Id = medicalReport.Id;
                        medicalReportResponseDTO.RigId = medicalReport.Rig.Id;
                        medicalReportResponseDTO.Date = medicalReport.Date;
                        medicalReportResponseDTO.userID = medicalReport.user.Id;

                        newTemp.Add(medicalReportResponseDTO);
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


        [HttpGet("GetMedicalReportAnalysisWithCompareByMonth")]
        public ActionResult<ResultDTO> GetMedicalReportAnalysisWithCompareByMonth(int Month, string UserRole)
        {

            ResultDTO result = new ResultDTO();

            try
            {

                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<MedicalReport> temp = MedicalReportRepoistory.getall().Where(r => (r.Date.Month == Month)).ToList();
                    List<MedicalReportResponseDTO> newTemp = new List<MedicalReportResponseDTO>();
                    foreach (MedicalReport medicalReport in temp)
                    {
                        MedicalReportResponseDTO medicalReportResponseDTO = new MedicalReportResponseDTO();
                        medicalReportResponseDTO.Id = medicalReport.Id;
                        medicalReportResponseDTO.RigId = medicalReport.Rig.Id;
                        medicalReportResponseDTO.Date = medicalReport.Date;
                        medicalReportResponseDTO.userID = medicalReport.user.Id;

                        newTemp.Add(medicalReportResponseDTO);
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



        /// *********************** End Analysis ************************

        [HttpPut("{id:int}")]
        public ActionResult<ResultDTO> Put(int id, [FromForm] MedicalReportDTO newMedicalReport) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    MedicalReport orgMedicalReport = MedicalReportRepo.getbyid(id);

                    newMedicalReport.Id = orgMedicalReport.Id;
                    orgMedicalReport.RigId = newMedicalReport.RigId;
                    orgMedicalReport.Date = newMedicalReport.Date;
                    orgMedicalReport.DateOfBirth = newMedicalReport.DateOfBirth;
                    orgMedicalReport.Address = newMedicalReport.Address;
                    orgMedicalReport.Age = newMedicalReport.Age;
                    if (newMedicalReport.TypeOfIncidentId != null)
                    {
                        orgMedicalReport.TypeOfIncidentId = newMedicalReport.TypeOfIncidentId;
                    }
                    else
                    {
                        orgMedicalReport.TypeOfIncidentId = 1;
                    }
                    orgMedicalReport.Company = newMedicalReport.Company;
                    orgMedicalReport.Job = newMedicalReport.Job;
                    orgMedicalReport.Code = newMedicalReport.Code;
                    orgMedicalReport.IsTheIllHealth = newMedicalReport.IsTheIllHealth;
                    orgMedicalReport.TelephoneNumber = newMedicalReport.TelephoneNumber;
                    orgMedicalReport.Diagnosis = newMedicalReport.Diagnosis;
                    orgMedicalReport.DoctorComment = newMedicalReport.DoctorComment;
                    orgMedicalReport.DoctorRecommendation = newMedicalReport.DoctorRecommendation;

                    orgMedicalReport.Name = newMedicalReport.Name;

                    orgMedicalReport.RigManager = newMedicalReport.RigManager;
                    orgMedicalReport.RigDoctor = newMedicalReport.RigDoctor;
                    orgMedicalReport.QHSEEngineer = newMedicalReport.QHSEEngineer;
                    //orgMedicalReport.userID = newMedicalReport.UserId;

                        MedicalReportRepo.update(orgMedicalReport);
                        result.Data = orgMedicalReport;
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
        public ActionResult<ResultDTO> Delete(int id)
        {
            ResultDTO result = new ResultDTO();
            try
            {
                MedicalReport MedicalReport = MedicalReportRepo.getbyid(id);
                MedicalReport.IsDeleted = true;
                MedicalReportRepo.update(MedicalReport);
                result.Data = MedicalReport;
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

