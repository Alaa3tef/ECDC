using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using TempProject.DTO;
using TempProject.DTO.ResponseDTO;
using TempProject.Helper;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyLiftingReportController : ControllerBase
    {
        public IRepository<DailyLiftingReport> DailyLiftingReportRepo { get; set; }
        public IRepository<SummaryDailyList> SummaryDailyListRepo { get; set; }
        public IRepository<DailyRecordStacticsList> DailyRecordStacticsListRepo { get; set; }
        public IRepository<PermitsToWorkList> PermitsToWorkListRepo { get; set; }
        public IDailyLiftingReportRepository DailyLiftingReportRepoistory { get; set; }

        private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager;


        public DailyLiftingReportController(Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager,
            IRepository<DailyLiftingReport> _DailyLiftingReportRepo,
            IDailyLiftingReportRepository _DailyLiftingReportRepoistory,
            IRepository<DailyRecordStacticsList> _DailyRecordStacticsListRepo,
            IRepository<SummaryDailyList> _SummaryDailyListRepo,
            IRepository<PermitsToWorkList> _PermitsToWorkListRepo)

            
        {
            this.DailyLiftingReportRepo = _DailyLiftingReportRepo;
            this.DailyLiftingReportRepoistory = _DailyLiftingReportRepoistory;
            this.userManager = _userManager;
            this.SummaryDailyListRepo = _SummaryDailyListRepo;
            this.PermitsToWorkListRepo = _PermitsToWorkListRepo;
            this.DailyLiftingReportRepo= _DailyLiftingReportRepo;
          this.DailyRecordStacticsListRepo = _DailyRecordStacticsListRepo;
        }

        //[HttpGet("GetData")]
        //public async Task<ResultDTO> GetAllWithData(string UserID, string UserRole)
        //{
        //    ResultDTO result = new ResultDTO();

        //    try
        //    {
        //        if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
        //        {
        //            List<DailyLiftingReport> temp = DailyLiftingReportRepoistory.getall();
        //            List<DailyLiftingReportResponseDTO> newTemp = new List<DailyLiftingReportResponseDTO>();
        //            foreach (DailyLiftingReport DailyLiftingReport in temp)
        //            {
        //                DailyLiftingReportResponseDTO DailyLiftingReportDTO = new DailyLiftingReportResponseDTO();
        //                DailyLiftingReportDTO.Id = DailyLiftingReport.Id;
        //                DailyLiftingReportDTO.RigId = DailyLiftingReport.Rig.Number;
        //                DailyLiftingReportDTO.Date = DailyLiftingReport.Date;

        //                DailyLiftingReportDTO.LiftingEngieerCode = DailyLiftingReport.LiftingEngieerCode;
        //                DailyLiftingReportDTO.LiftingEngieerName = DailyLiftingReport.LiftingEngieerName;

        //                DailyLiftingReportDTO.userName = DailyLiftingReport.user.UserName;
        //                DailyLiftingReportDTO.userID = DailyLiftingReport.user.Id;

        //                if (DailyLiftingReport.SummaryDailyList.Any())
        //                {
        //                    foreach (var item in DailyLiftingReport.SummaryDailyList)
        //                    {
        //                        VisitsDTO visitsDTO = new VisitsDTO();
        //                        visitsDTO.Id = item.Id;
        //                        visitsDTO.Date = item.Date;
        //                        visitsDTO.VisitName = item.VisitName;
        //                        visitsDTO.DailyLiftingReportId = item.DailyLiftingReportId;
        //                        visitsDTO.IsDeleted = item.IsDeleted;
        //                        DailyLiftingReportDTO.Visits.Add(visitsDTO);
        //                    }
        //                }

        //                List<DailyRecordStacticsList> dailyRecordStacticsLists = DailyRecordStacticsListRepo.getall().Where(emp => emp.DailyLiftingReportId == DailyLiftingReport.Id).ToList();

        //                DailyLiftingReportDTO.DailyRecordStacticsLis1 = dailyRecordStacticsLists[0].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis2 = dailyRecordStacticsLists[1].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis3 = dailyRecordStacticsLists[2].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis4 = dailyRecordStacticsLists[3].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis5 = dailyRecordStacticsLists[4].DailyRecordStacticsName;

        //                List<PermitsToWorkList> permitsToWorkLists = PermitsToWorkListRepo.getall().Where(emp => emp.DailyLiftingReportId == DailyLiftingReport.Id).ToList();

        //                DailyLiftingReportDTO.PermitsToWorkList1 = permitsToWorkLists[0].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList2 = permitsToWorkLists[1].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList3 = permitsToWorkLists[2].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList4 = permitsToWorkLists[3].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList5 = permitsToWorkLists[4].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList6 = permitsToWorkLists[5].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList7 = permitsToWorkLists[6].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList8 = permitsToWorkLists[7].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList9 = permitsToWorkLists[8].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList10 = permitsToWorkLists[9].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList11 = permitsToWorkLists[10].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList12 = permitsToWorkLists[11].PermitsToWorkName;


        //                newTemp.Add(DailyLiftingReportDTO);
        //            }
        //            if (newTemp != null)
        //            {
        //                result.Message = "Success";
        //                result.Statescode = 200;
        //                result.Data = newTemp;

        //                return result;
        //            }
        //        }
        //        else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
        //        {
        //            List<DailyLiftingReport> temp = DailyLiftingReportRepoistory.getall().Where(a => a.user.Id == UserID).ToList();
        //            List<DailyLiftingReportResponseDTO> newTemp = new List<DailyLiftingReportResponseDTO>();
        //            foreach (DailyLiftingReport DailyLiftingReport in temp)
        //            {

        //                DailyLiftingReportResponseDTO DailyLiftingReportDTO = new DailyLiftingReportResponseDTO();
        //                DailyLiftingReportDTO.Id = DailyLiftingReport.Id;
        //                DailyLiftingReportDTO.RigId = DailyLiftingReport.Rig.Number;
        //                DailyLiftingReportDTO.Date = DailyLiftingReport.Date;

        //                DailyLiftingReportDTO.RigHeavyDataId = DailyLiftingReport.RigHeavyDataId;


        //                DailyLiftingReportDTO.LiftingEngieerCode = DailyLiftingReport.LiftingEngieerCode;
        //                DailyLiftingReportDTO.LiftingEngieerName = DailyLiftingReport.LiftingEngieerName;

        //                DailyLiftingReportDTO.userName = DailyLiftingReport.user.UserName;
        //                DailyLiftingReportDTO.userID = DailyLiftingReport.user.Id;

        //                List<SummaryDailyList> summaryDailyLists = SummaryDailyListRepo.getall().Where(emp => emp.DailyLiftingReportId == DailyLiftingReport.Id).ToList();

        //                DailyLiftingReportDTO.SummaryDailyList1 = summaryDailyLists[0].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList2 = summaryDailyLists[1].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList3 = summaryDailyLists[2].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList4 = summaryDailyLists[3].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList5 = summaryDailyLists[4].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList6 = summaryDailyLists[5].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList7 = summaryDailyLists[6].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList8 = summaryDailyLists[7].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList9 = summaryDailyLists[8].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList10 = summaryDailyLists[9].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList11 = summaryDailyLists[10].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList12 = summaryDailyLists[11].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList13 = summaryDailyLists[12].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList14 = summaryDailyLists[13].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList15 = summaryDailyLists[14].SummaryDaily;

        //                List<DailyRecordStacticsList> dailyRecordStacticsLists = DailyRecordStacticsListRepo.getall().Where(emp => emp.DailyLiftingReportId == DailyLiftingReport.Id).ToList();

        //                DailyLiftingReportDTO.DailyRecordStacticsLis1 = dailyRecordStacticsLists[0].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis2 = dailyRecordStacticsLists[1].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis3 = dailyRecordStacticsLists[2].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis4 = dailyRecordStacticsLists[3].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis5 = dailyRecordStacticsLists[4].DailyRecordStacticsName;

        //                List<PermitsToWorkList> permitsToWorkLists = PermitsToWorkListRepo.getall().Where(emp => emp.DailyLiftingReportId == DailyLiftingReport.Id).ToList();

        //                DailyLiftingReportDTO.PermitsToWorkList1 = permitsToWorkLists[0].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList2 = permitsToWorkLists[1].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList3 = permitsToWorkLists[2].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList4 = permitsToWorkLists[3].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList5 = permitsToWorkLists[4].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList6 = permitsToWorkLists[5].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList7 = permitsToWorkLists[6].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList8 = permitsToWorkLists[7].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList9 = permitsToWorkLists[8].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList10 = permitsToWorkLists[9].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList11 = permitsToWorkLists[10].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList12 = permitsToWorkLists[11].PermitsToWorkName;


        //                newTemp.Add(DailyLiftingReportDTO);
        //            }
        //            //result.Data = prod;

        //            if (newTemp != null)
        //            {
        //                result.Message = "Success";
        //                result.Statescode = 200;
        //                result.Data = newTemp;

        //                return result;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Statescode = 404;
        //        result.Message = "data not found";
        //    }
        //    return result;
        //}

        //[HttpGet("ByPage/{page:int}")]
        //public PageResult<DailyLiftingReportResponseDTO> GettAllDailyLiftingReportByPage(string UserId, string UserRole, int? page, int pagesize = 10)
        //{

        //    try
        //    {
        //        if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
        //        {
        //            List<DailyLiftingReport> temp = DailyLiftingReportRepoistory.getall();
        //            List<DailyLiftingReportResponseDTO> newTemp = new List<DailyLiftingReportResponseDTO>();
        //            foreach (DailyLiftingReport DailyLiftingReport in temp)
        //            {

        //                DailyLiftingReportResponseDTO DailyLiftingReportDTO = new DailyLiftingReportResponseDTO();
        //                DailyLiftingReportDTO.Id = DailyLiftingReport.Id;
        //                DailyLiftingReportDTO.RigId = DailyLiftingReport.Rig.Number;
        //                DailyLiftingReportDTO.Date = DailyLiftingReport.Date;

        //                DailyLiftingReportDTO.RigHeavyDataId = DailyLiftingReport.RigHeavyDataId;


        //                DailyLiftingReportDTO.LiftingEngieerCode = DailyLiftingReport.LiftingEngieerCode;
        //                DailyLiftingReportDTO.LiftingEngieerName = DailyLiftingReport.LiftingEngieerName;

        //                DailyLiftingReportDTO.userName = DailyLiftingReport.user.UserName;
        //                DailyLiftingReportDTO.userID = DailyLiftingReport.user.Id;

        //                List<SummaryDailyList> summaryDailyLists = SummaryDailyListRepo.getall().Where(emp => emp.DailyLiftingReportId == DailyLiftingReport.Id).ToList();

        //                DailyLiftingReportDTO.SummaryDailyList1 = summaryDailyLists[0].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList2 = summaryDailyLists[1].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList3 = summaryDailyLists[2].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList4 = summaryDailyLists[3].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList5 = summaryDailyLists[4].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList6 = summaryDailyLists[5].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList7 = summaryDailyLists[6].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList8 = summaryDailyLists[7].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList9 = summaryDailyLists[8].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList10 = summaryDailyLists[9].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList11 = summaryDailyLists[10].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList12 = summaryDailyLists[11].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList13 = summaryDailyLists[12].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList14 = summaryDailyLists[13].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList15 = summaryDailyLists[14].SummaryDaily;

        //                List<DailyRecordStacticsList> dailyRecordStacticsLists = DailyRecordStacticsListRepo.getall().Where(emp => emp.DailyLiftingReportId == DailyLiftingReport.Id).ToList();

        //                DailyLiftingReportDTO.DailyRecordStacticsLis1 = dailyRecordStacticsLists[0].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis2 = dailyRecordStacticsLists[1].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis3 = dailyRecordStacticsLists[2].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis4 = dailyRecordStacticsLists[3].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis5 = dailyRecordStacticsLists[4].DailyRecordStacticsName;

        //                List<PermitsToWorkList> permitsToWorkLists = PermitsToWorkListRepo.getall().Where(emp => emp.DailyLiftingReportId == DailyLiftingReport.Id).ToList();

        //                DailyLiftingReportDTO.PermitsToWorkList1 = permitsToWorkLists[0].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList2 = permitsToWorkLists[1].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList3 = permitsToWorkLists[2].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList4 = permitsToWorkLists[3].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList5 = permitsToWorkLists[4].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList6 = permitsToWorkLists[5].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList7 = permitsToWorkLists[6].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList8 = permitsToWorkLists[7].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList9 = permitsToWorkLists[8].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList10 = permitsToWorkLists[9].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList11 = permitsToWorkLists[10].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList12 = permitsToWorkLists[11].PermitsToWorkName;


        //                newTemp.Add(DailyLiftingReportDTO);
        //            }

        //            float countDetails = DailyLiftingReportRepoistory.getall().Count();
        //            var result = new PageResult<DailyLiftingReportResponseDTO>
        //            {
        //                Count = (int)Math.Ceiling(countDetails / pagesize),
        //                PageIndex = page ?? 1,
        //                PageSize = pagesize,
        //                Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
        //            };

        //            return result;

        //        }
        //        else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
        //        {
        //            List<DailyLiftingReport> temp = DailyLiftingReportRepoistory.getall().Where(a => a.user.Id == UserId).ToList();
        //            List<DailyLiftingReportResponseDTO> newTemp = new List<DailyLiftingReportResponseDTO>();
        //            foreach (DailyLiftingReport DailyLiftingReport in temp)
        //            {
        //                DailyLiftingReportResponseDTO DailyLiftingReportDTO = new DailyLiftingReportResponseDTO();
        //                DailyLiftingReportDTO.Id = DailyLiftingReport.Id;
        //                DailyLiftingReportDTO.RigId = DailyLiftingReport.Rig.Number;
        //                DailyLiftingReportDTO.Date = DailyLiftingReport.Date;

        //                DailyLiftingReportDTO.RigHeavyDataId = DailyLiftingReport.RigHeavyDataId;


        //                DailyLiftingReportDTO.LiftingEngieerCode = DailyLiftingReport.LiftingEngieerCode;
        //                DailyLiftingReportDTO.LiftingEngieerName = DailyLiftingReport.LiftingEngieerName;

        //                DailyLiftingReportDTO.userName = DailyLiftingReport.user.UserName;
        //                DailyLiftingReportDTO.userID = DailyLiftingReport.user.Id;

        //                List<SummaryDailyList> summaryDailyLists = SummaryDailyListRepo.getall().Where(emp => emp.DailyLiftingReportId == DailyLiftingReport.Id).ToList();

        //                DailyLiftingReportDTO.SummaryDailyList1 = summaryDailyLists[0].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList2 = summaryDailyLists[1].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList3 = summaryDailyLists[2].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList4 = summaryDailyLists[3].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList5 = summaryDailyLists[4].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList6 = summaryDailyLists[5].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList7 = summaryDailyLists[6].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList8 = summaryDailyLists[7].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList9 = summaryDailyLists[8].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList10 = summaryDailyLists[9].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList11 = summaryDailyLists[10].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList12 = summaryDailyLists[11].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList13 = summaryDailyLists[12].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList14 = summaryDailyLists[13].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList15 = summaryDailyLists[14].SummaryDaily;

        //                List<DailyRecordStacticsList> dailyRecordStacticsLists = DailyRecordStacticsListRepo.getall().Where(emp => emp.DailyLiftingReportId == DailyLiftingReport.Id).ToList();

        //                DailyLiftingReportDTO.DailyRecordStacticsLis1 = dailyRecordStacticsLists[0].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis2 = dailyRecordStacticsLists[1].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis3 = dailyRecordStacticsLists[2].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis4 = dailyRecordStacticsLists[3].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis5 = dailyRecordStacticsLists[4].DailyRecordStacticsName;

        //                List<PermitsToWorkList> permitsToWorkLists = PermitsToWorkListRepo.getall().Where(emp => emp.DailyLiftingReportId == DailyLiftingReport.Id).ToList();

        //                DailyLiftingReportDTO.PermitsToWorkList1 = permitsToWorkLists[0].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList2 = permitsToWorkLists[1].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList3 = permitsToWorkLists[2].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList4 = permitsToWorkLists[3].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList5 = permitsToWorkLists[4].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList6 = permitsToWorkLists[5].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList7 = permitsToWorkLists[6].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList8 = permitsToWorkLists[7].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList9 = permitsToWorkLists[8].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList10 = permitsToWorkLists[9].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList11 = permitsToWorkLists[10].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList12 = permitsToWorkLists[11].PermitsToWorkName;


        //                newTemp.Add(DailyLiftingReportDTO);
        //            }

        //            float countDetails = DailyLiftingReportRepoistory.getall().Where(a => a.user.Id == UserId).Count();
        //            var result = new PageResult<DailyLiftingReportResponseDTO>
        //            {
        //                Count = (int)Math.Ceiling(countDetails / pagesize),
        //                PageIndex = page ?? 1,
        //                PageSize = pagesize,
        //                Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
        //            };

        //            return result;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new PageResult<DailyLiftingReportResponseDTO>();

        //    }
        //    return new PageResult<DailyLiftingReportResponseDTO>();
        //}

        //[HttpGet("GetDataById/{ID:int}")]
        //public ActionResult<ResultDTO> GetAllWithDataByID(int ID, string UserId, string UserRole)
        //{
        //    ResultDTO result = new ResultDTO();


        //    if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
        //    {
        //        DailyLiftingReport temp = DailyLiftingReportRepoistory.getall().FirstOrDefault(a => a.Id == ID);
        //        if (temp != null)
        //        {
        //            DailyLiftingReportResponseDTO DailyLiftingReportDTO = new DailyLiftingReportResponseDTO();

        //            DailyLiftingReportDTO.Id = temp.Id;
        //            DailyLiftingReportDTO.RigId = temp.Rig.Id;
        //            DailyLiftingReportDTO.RigNumber = temp.Rig.Number;
        //            DailyLiftingReportDTO.Date = temp.Date;
        //            DailyLiftingReportDTO.RigHeavyDataId = temp.RigHeavyDataId;
        //            DailyLiftingReportDTO.LiftingEngieerCode = temp.LiftingEngieerCode;
        //            DailyLiftingReportDTO.LiftingEngieerName = temp.LiftingEngieerName;
        //            DailyLiftingReportDTO.userName = temp.user.UserName;
        //            DailyLiftingReportDTO.userID = temp.user.Id;

        //            List<SummaryDailyList> summaryDailyLists = SummaryDailyListRepo.getall().Where(emp => emp.DailyLiftingReportId == temp.Id).ToList();

        //            DailyLiftingReportDTO.SummaryDailyList1 = summaryDailyLists[0].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList2 = summaryDailyLists[1].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList3 = summaryDailyLists[2].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList4 = summaryDailyLists[3].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList5 = summaryDailyLists[4].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList6 = summaryDailyLists[5].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList7 = summaryDailyLists[6].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList8 = summaryDailyLists[7].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList9 = summaryDailyLists[8].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList10 = summaryDailyLists[9].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList11 = summaryDailyLists[10].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList12 = summaryDailyLists[11].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList13 = summaryDailyLists[12].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList14 = summaryDailyLists[13].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList15 = summaryDailyLists[14].SummaryDaily;

        //            List<DailyRecordStacticsList> dailyRecordStacticsLists = DailyRecordStacticsListRepo.getall().Where(emp => emp.DailyLiftingReportId == temp.Id).ToList();

        //            DailyLiftingReportDTO.DailyRecordStacticsLis1 = dailyRecordStacticsLists[0].DailyRecordStacticsName;
        //            DailyLiftingReportDTO.DailyRecordStacticsLis2 = dailyRecordStacticsLists[1].DailyRecordStacticsName;
        //            DailyLiftingReportDTO.DailyRecordStacticsLis3 = dailyRecordStacticsLists[2].DailyRecordStacticsName;
        //            DailyLiftingReportDTO.DailyRecordStacticsLis4 = dailyRecordStacticsLists[3].DailyRecordStacticsName;
        //            DailyLiftingReportDTO.DailyRecordStacticsLis5 = dailyRecordStacticsLists[4].DailyRecordStacticsName;

        //            List<PermitsToWorkList> permitsToWorkLists = PermitsToWorkListRepo.getall().Where(emp => emp.DailyLiftingReportId == temp.Id).ToList();

        //            DailyLiftingReportDTO.PermitsToWorkList1 = permitsToWorkLists[0].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList2 = permitsToWorkLists[1].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList3 = permitsToWorkLists[2].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList4 = permitsToWorkLists[3].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList5 = permitsToWorkLists[4].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList6 = permitsToWorkLists[5].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList7 = permitsToWorkLists[6].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList8 = permitsToWorkLists[7].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList9 = permitsToWorkLists[8].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList10 = permitsToWorkLists[9].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList11 = permitsToWorkLists[10].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList12 = permitsToWorkLists[11].PermitsToWorkName;



        //            if (DailyLiftingReportDTO != null)
        //            {

        //                result.Message = "Success";
        //                result.Statescode = 200;
        //                result.Data = DailyLiftingReportDTO;

        //                return result;
        //            }
        //        }

        //    }
        //    else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
        //    {
        //        DailyLiftingReport temp = DailyLiftingReportRepoistory.getall().FirstOrDefault(a => a.Id == ID && a.user.Id == UserId);
        //        if (temp != null)
        //        {
        //            DailyLiftingReportResponseDTO DailyLiftingReportDTO = new DailyLiftingReportResponseDTO();

        //            DailyLiftingReportDTO.Id = temp.Id;
        //            DailyLiftingReportDTO.RigId = temp.Rig.Id;
        //            DailyLiftingReportDTO.RigNumber = temp.Rig.Number;
        //            DailyLiftingReportDTO.Date = temp.Date;
        //            DailyLiftingReportDTO.RigHeavyDataId = temp.RigHeavyDataId;
        //            DailyLiftingReportDTO.LiftingEngieerCode = temp.LiftingEngieerCode;
        //            DailyLiftingReportDTO.LiftingEngieerName = temp.LiftingEngieerName;
        //            DailyLiftingReportDTO.userName = temp.user.UserName;
        //            DailyLiftingReportDTO.userID = temp.user.Id;

        //            List<SummaryDailyList> summaryDailyLists = SummaryDailyListRepo.getall().Where(emp => emp.DailyLiftingReportId == temp.Id).ToList();

        //            DailyLiftingReportDTO.SummaryDailyList1 = summaryDailyLists[0].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList2 = summaryDailyLists[1].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList3 = summaryDailyLists[2].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList4 = summaryDailyLists[3].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList5 = summaryDailyLists[4].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList6 = summaryDailyLists[5].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList7 = summaryDailyLists[6].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList8 = summaryDailyLists[7].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList9 = summaryDailyLists[8].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList10 = summaryDailyLists[9].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList11 = summaryDailyLists[10].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList12 = summaryDailyLists[11].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList13 = summaryDailyLists[12].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList14 = summaryDailyLists[13].SummaryDaily;
        //            DailyLiftingReportDTO.SummaryDailyList15 = summaryDailyLists[14].SummaryDaily;

        //            List<DailyRecordStacticsList> dailyRecordStacticsLists = DailyRecordStacticsListRepo.getall().Where(emp => emp.DailyLiftingReportId == temp.Id).ToList();

        //            DailyLiftingReportDTO.DailyRecordStacticsLis1 = dailyRecordStacticsLists[0].DailyRecordStacticsName;
        //            DailyLiftingReportDTO.DailyRecordStacticsLis2 = dailyRecordStacticsLists[1].DailyRecordStacticsName;
        //            DailyLiftingReportDTO.DailyRecordStacticsLis3 = dailyRecordStacticsLists[2].DailyRecordStacticsName;
        //            DailyLiftingReportDTO.DailyRecordStacticsLis4 = dailyRecordStacticsLists[3].DailyRecordStacticsName;
        //            DailyLiftingReportDTO.DailyRecordStacticsLis5 = dailyRecordStacticsLists[4].DailyRecordStacticsName;

        //            List<PermitsToWorkList> permitsToWorkLists = PermitsToWorkListRepo.getall().Where(emp => emp.DailyLiftingReportId == temp.Id).ToList();

        //            DailyLiftingReportDTO.PermitsToWorkList1 = permitsToWorkLists[0].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList2 = permitsToWorkLists[1].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList3 = permitsToWorkLists[2].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList4 = permitsToWorkLists[3].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList5 = permitsToWorkLists[4].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList6 = permitsToWorkLists[5].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList7 = permitsToWorkLists[6].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList8 = permitsToWorkLists[7].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList9 = permitsToWorkLists[8].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList10 = permitsToWorkLists[9].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList11 = permitsToWorkLists[10].PermitsToWorkName;
        //            DailyLiftingReportDTO.PermitsToWorkList12 = permitsToWorkLists[11].PermitsToWorkName;



        //            if (DailyLiftingReportDTO != null)
        //            {

        //                result.Message = "Success";
        //                result.Statescode = 200;
        //                result.Data = DailyLiftingReportDTO;

        //                return result;
        //            }
        //        }

        //    }

        //    result.Statescode = 404;
        //    result.Message = "data not found";
        //    return result;
        //}

        ////  ------------------filter by DrillType------------------------------------------

        //[HttpGet("GetDataByLiftingEngieerNameAndRig/{LiftingEngieerName}")]
        //public ActionResult<ResultDTO> GetAllWithDataByDrillType(string LiftingEngieerName, string UserId, string UserRole,string date, int RigNumber)
        //{
        //    DateTime dateObject = DateTime.Parse(date);
        //    ResultDTO result = new ResultDTO();

        //    try
        //    {
        //        if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
        //        {
        //            List<DailyLiftingReportResponseDTO> DailyLiftingReportDTOs = new List<DailyLiftingReportResponseDTO>();
        //            List<DailyLiftingReport> DailyLiftingReports = DailyLiftingReportRepoistory.getall().Where(a => a.LiftingEngieerName == LiftingEngieerName  && a.Rig.Number==RigNumber&&a.Date== dateObject).ToList();
        //            foreach (DailyLiftingReport DailyLiftingReport in DailyLiftingReports)
        //            {
        //                 DailyLiftingReportResponseDTO DailyLiftingReportDTO = new DailyLiftingReportResponseDTO();
        //                DailyLiftingReportDTO.Id = DailyLiftingReport.Id;
        //                DailyLiftingReportDTO.RigId = DailyLiftingReport.Rig.Number;
        //                DailyLiftingReportDTO.Date = DailyLiftingReport.Date;

        //                DailyLiftingReportDTO.RigHeavyDataId = DailyLiftingReport.RigHeavyDataId;


        //                DailyLiftingReportDTO.LiftingEngieerCode = DailyLiftingReport.LiftingEngieerCode;
        //                DailyLiftingReportDTO.LiftingEngieerName = DailyLiftingReport.LiftingEngieerName;

        //                DailyLiftingReportDTO.userName = DailyLiftingReport.user.UserName;
        //                DailyLiftingReportDTO.userID = DailyLiftingReport.user.Id;

        //                List<SummaryDailyList> summaryDailyLists = SummaryDailyListRepo.getall().Where(emp => emp.DailyLiftingReportId == DailyLiftingReport.Id).ToList();

        //                DailyLiftingReportDTO.SummaryDailyList1 = summaryDailyLists[0].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList2 = summaryDailyLists[1].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList3 = summaryDailyLists[2].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList4 = summaryDailyLists[3].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList5 = summaryDailyLists[4].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList6 = summaryDailyLists[5].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList7 = summaryDailyLists[6].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList8 = summaryDailyLists[7].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList9 = summaryDailyLists[8].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList10 = summaryDailyLists[9].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList11 = summaryDailyLists[10].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList12 = summaryDailyLists[11].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList13 = summaryDailyLists[12].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList14 = summaryDailyLists[13].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList15 = summaryDailyLists[14].SummaryDaily;

        //                List<DailyRecordStacticsList> dailyRecordStacticsLists = DailyRecordStacticsListRepo.getall().Where(emp => emp.DailyLiftingReportId == DailyLiftingReport.Id).ToList();

        //                DailyLiftingReportDTO.DailyRecordStacticsLis1 = dailyRecordStacticsLists[0].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis2 = dailyRecordStacticsLists[1].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis3 = dailyRecordStacticsLists[2].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis4 = dailyRecordStacticsLists[3].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis5 = dailyRecordStacticsLists[4].DailyRecordStacticsName;

        //                List<PermitsToWorkList> permitsToWorkLists = PermitsToWorkListRepo.getall().Where(emp => emp.DailyLiftingReportId == DailyLiftingReport.Id).ToList();

        //                DailyLiftingReportDTO.PermitsToWorkList1 = permitsToWorkLists[0].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList2 = permitsToWorkLists[1].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList3 = permitsToWorkLists[2].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList4 = permitsToWorkLists[3].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList5 = permitsToWorkLists[4].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList6 = permitsToWorkLists[5].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList7 = permitsToWorkLists[6].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList8 = permitsToWorkLists[7].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList9 = permitsToWorkLists[8].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList10 = permitsToWorkLists[9].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList11 = permitsToWorkLists[10].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList12 = permitsToWorkLists[11].PermitsToWorkName;


        //                DailyLiftingReportDTOs.Add(DailyLiftingReportDTO);
        //                //result.Data = prod;
        //            }
        //            result.Message = "Success";
        //            result.Data = DailyLiftingReportDTOs;
        //            result.Statescode = 200;
        //            return result;
        //        }
        //        else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
        //        {
        //            List<DailyLiftingReportResponseDTO> DailyLiftingReportDTOs = new List<DailyLiftingReportResponseDTO>();
        //            List<DailyLiftingReport> DailyLiftingReports = DailyLiftingReportRepoistory.getall().Where(a => a.LiftingEngieerName == LiftingEngieerName && a.Rig.Number == RigNumber && a.Date == dateObject&& a.user.Id == UserId).ToList();
        //            foreach (DailyLiftingReport DailyLiftingReport in DailyLiftingReports)
        //            {
        //                DailyLiftingReportResponseDTO DailyLiftingReportDTO = new DailyLiftingReportResponseDTO();
        //                DailyLiftingReportDTO.Id = DailyLiftingReport.Id;
        //                DailyLiftingReportDTO.RigId = DailyLiftingReport.Rig.Number;
        //                DailyLiftingReportDTO.Date = DailyLiftingReport.Date;

        //                DailyLiftingReportDTO.RigHeavyDataId = DailyLiftingReport.RigHeavyDataId;


        //                DailyLiftingReportDTO.LiftingEngieerCode = DailyLiftingReport.LiftingEngieerCode;
        //                DailyLiftingReportDTO.LiftingEngieerName = DailyLiftingReport.LiftingEngieerName;

        //                DailyLiftingReportDTO.userName = DailyLiftingReport.user.UserName;
        //                DailyLiftingReportDTO.userID = DailyLiftingReport.user.Id;

        //                List<SummaryDailyList> summaryDailyLists = SummaryDailyListRepo.getall().Where(emp => emp.DailyLiftingReportId == DailyLiftingReport.Id).ToList();

        //                DailyLiftingReportDTO.SummaryDailyList1 = summaryDailyLists[0].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList2 = summaryDailyLists[1].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList3 = summaryDailyLists[2].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList4 = summaryDailyLists[3].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList5 = summaryDailyLists[4].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList6 = summaryDailyLists[5].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList7 = summaryDailyLists[6].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList8 = summaryDailyLists[7].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList9 = summaryDailyLists[8].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList10 = summaryDailyLists[9].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList11 = summaryDailyLists[10].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList12 = summaryDailyLists[11].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList13 = summaryDailyLists[12].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList14 = summaryDailyLists[13].SummaryDaily;
        //                DailyLiftingReportDTO.SummaryDailyList15 = summaryDailyLists[14].SummaryDaily;

        //                List<DailyRecordStacticsList> dailyRecordStacticsLists = DailyRecordStacticsListRepo.getall().Where(emp => emp.DailyLiftingReportId == DailyLiftingReport.Id).ToList();

        //                DailyLiftingReportDTO.DailyRecordStacticsLis1 = dailyRecordStacticsLists[0].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis2 = dailyRecordStacticsLists[1].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis3 = dailyRecordStacticsLists[2].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis4 = dailyRecordStacticsLists[3].DailyRecordStacticsName;
        //                DailyLiftingReportDTO.DailyRecordStacticsLis5 = dailyRecordStacticsLists[4].DailyRecordStacticsName;

        //                List<PermitsToWorkList> permitsToWorkLists = PermitsToWorkListRepo.getall().Where(emp => emp.DailyLiftingReportId == DailyLiftingReport.Id).ToList();

        //                DailyLiftingReportDTO.PermitsToWorkList1 = permitsToWorkLists[0].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList2 = permitsToWorkLists[1].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList3 = permitsToWorkLists[2].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList4 = permitsToWorkLists[3].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList5 = permitsToWorkLists[4].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList6 = permitsToWorkLists[5].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList7 = permitsToWorkLists[6].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList8 = permitsToWorkLists[7].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList9 = permitsToWorkLists[8].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList10 = permitsToWorkLists[9].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList11 = permitsToWorkLists[10].PermitsToWorkName;
        //                DailyLiftingReportDTO.PermitsToWorkList12 = permitsToWorkLists[11].PermitsToWorkName;


        //                DailyLiftingReportDTOs.Add(DailyLiftingReportDTO);
        //            }
        //            result.Message = "Success";
        //            result.Data = DailyLiftingReportDTOs;
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


        [HttpGet("GetData")]
        public async Task<ResultDTO> GetAllWithData(string UserID, string UserRole)
        {
            ResultDTO result = new ResultDTO();

            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<DailyLiftingReport> temp = DailyLiftingReportRepoistory.getall();
                    List<DailyLiftingReportResponseDTO> newTemp = new List<DailyLiftingReportResponseDTO>();
                    foreach (DailyLiftingReport DailyLiftingReport in temp)
                    {
                        DailyLiftingReportResponseDTO DailyLiftingReportDTO = new DailyLiftingReportResponseDTO();
                        DailyLiftingReportDTO.Id = DailyLiftingReport.Id;
                        DailyLiftingReportDTO.RigNumber = DailyLiftingReport.Rig.Number;
                        DailyLiftingReportDTO.Date = DailyLiftingReport.Date;
                        DailyLiftingReportDTO.MobileCraneName = DailyLiftingReport.MobileCraneName;
                        DailyLiftingReportDTO.Type = DailyLiftingReport.Type;
                        DailyLiftingReportDTO.ChasisNo = DailyLiftingReport.ChasisNo;
                        DailyLiftingReportDTO.Capacity = DailyLiftingReport.Capacity;
                        DailyLiftingReportDTO.DateofLastInspection = DailyLiftingReport.DateofLastInspection;
                        DailyLiftingReportDTO.DateofNextInspection = DailyLiftingReport.DateofNextInspection;
                        DailyLiftingReportDTO.ForkName = DailyLiftingReport.ForkName;
                        DailyLiftingReportDTO.ForkType = DailyLiftingReport.ForkType;
                        DailyLiftingReportDTO.ForkChasisNo = DailyLiftingReport.ForkChasisNo;
                        DailyLiftingReportDTO.ForkCapacity = DailyLiftingReport.ForkCapacity;
                        DailyLiftingReportDTO.ForkDateofLastInspection = DailyLiftingReport.ForkDateofLastInspection;
                        DailyLiftingReportDTO.ForkDateofNextInspection = DailyLiftingReport.ForkDateofNextInspection;
                        DailyLiftingReportDTO.LiftingEngieerCode = DailyLiftingReport.LiftingEngieerCode;
                        DailyLiftingReportDTO.LiftingEngieerName = DailyLiftingReport.LiftingEngieerName;
                        DailyLiftingReportDTO.userName = DailyLiftingReport.user.UserName;
                        if (DailyLiftingReport.SummaryDailyList.Any())
                        {
                            foreach (var item in DailyLiftingReport.SummaryDailyList)
                            {
                                SummaryDailyListDTO summaryDailyListDTO = new SummaryDailyListDTO();
                                summaryDailyListDTO.Id = item.Id;
                                summaryDailyListDTO.SummaryDailyListName = item.SummaryDaily;
                                summaryDailyListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                                summaryDailyListDTO.IsDeleted = item.IsDeleted;
                                DailyLiftingReportDTO.summaryDailyListDTOs.Add(summaryDailyListDTO);
                            }
                        }


                        if (DailyLiftingReport.DailyRecordStacticsList.Any())
                        {
                            foreach (var item in DailyLiftingReport.DailyRecordStacticsList)
                            {
                                DailyRecordStacticsListDTO dailyRecordStacticsListDTO = new DailyRecordStacticsListDTO();
								dailyRecordStacticsListDTO.Id = item.Id;
								dailyRecordStacticsListDTO.Item = item.Item;
								dailyRecordStacticsListDTO.DailyRecordStacticsListName = item.DailyRecordStacticsName;
                                dailyRecordStacticsListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                                dailyRecordStacticsListDTO.IsDeleted = item.IsDeleted;
                                DailyLiftingReportDTO.dailyRecordStacticsListDTOs.Add(dailyRecordStacticsListDTO);
                            }
                        }
                      
                        if (DailyLiftingReport.PermitsToWorkList.Any())
                        {
                            foreach (var item in DailyLiftingReport.PermitsToWorkList)
                            {
                                PermitsToWorkListDTO permitsToWorkListDTO = new PermitsToWorkListDTO();
                                permitsToWorkListDTO.Id = item.Id;
                                permitsToWorkListDTO.PermitsToWorkListName = item.PermitsToWorkName;
                                permitsToWorkListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                                permitsToWorkListDTO.IsDeleted = item.IsDeleted;
                                DailyLiftingReportDTO.PermitsToWorkListDTOs.Add(permitsToWorkListDTO);
                            }
                        }
                        newTemp.Add(DailyLiftingReportDTO);
                        //result.Data = prod;
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
                    List<DailyLiftingReport> temp = DailyLiftingReportRepoistory.getall().Where(a => a.user.Id == UserID).ToList();
                    List<DailyLiftingReportResponseDTO> newTemp = new List<DailyLiftingReportResponseDTO>();
                    foreach (DailyLiftingReport DailyLiftingReport in temp)
                    {
                        DailyLiftingReportResponseDTO DailyLiftingReportDTO = new DailyLiftingReportResponseDTO();
                        DailyLiftingReportDTO.Id = DailyLiftingReport.Id;
                        DailyLiftingReportDTO.Date = DailyLiftingReport.Date;
                        DailyLiftingReportDTO.RigNumber = DailyLiftingReport.Rig.Number;
                        DailyLiftingReportDTO.MobileCraneName = DailyLiftingReport.MobileCraneName;
                        DailyLiftingReportDTO.Type = DailyLiftingReport.Type;
                        DailyLiftingReportDTO.ChasisNo = DailyLiftingReport.ChasisNo;
                        DailyLiftingReportDTO.Capacity = DailyLiftingReport.Capacity;
                        DailyLiftingReportDTO.DateofLastInspection = DailyLiftingReport.DateofLastInspection;
                        DailyLiftingReportDTO.DateofNextInspection = DailyLiftingReport.DateofNextInspection;
                        DailyLiftingReportDTO.ForkName = DailyLiftingReport.ForkName;
                        DailyLiftingReportDTO.ForkType = DailyLiftingReport.ForkType;
                        DailyLiftingReportDTO.ForkChasisNo = DailyLiftingReport.ForkChasisNo;
                        DailyLiftingReportDTO.ForkCapacity = DailyLiftingReport.ForkCapacity;
                        DailyLiftingReportDTO.ForkDateofLastInspection = DailyLiftingReport.ForkDateofLastInspection;
                        DailyLiftingReportDTO.ForkDateofNextInspection = DailyLiftingReport.ForkDateofNextInspection;
                        DailyLiftingReportDTO.LiftingEngieerCode = DailyLiftingReport.LiftingEngieerCode;
                        DailyLiftingReportDTO.LiftingEngieerName = DailyLiftingReport.LiftingEngieerName;
                        DailyLiftingReportDTO.userName = DailyLiftingReport.user.UserName;
                        if (DailyLiftingReport.SummaryDailyList.Any())
                        {
                            foreach (var item in DailyLiftingReport.SummaryDailyList)
                            {
                                SummaryDailyListDTO summaryDailyListDTO = new SummaryDailyListDTO();
                                summaryDailyListDTO.Id = item.Id;
                                summaryDailyListDTO.SummaryDailyListName = item.SummaryDaily;
                                summaryDailyListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                                summaryDailyListDTO.IsDeleted = item.IsDeleted;
                                DailyLiftingReportDTO.summaryDailyListDTOs.Add(summaryDailyListDTO);
                            }
                        }


                        if (DailyLiftingReport.DailyRecordStacticsList.Any())
                        {
                            foreach (var item in DailyLiftingReport.DailyRecordStacticsList)
                            {
                                DailyRecordStacticsListDTO dailyRecordStacticsListDTO = new DailyRecordStacticsListDTO();
								dailyRecordStacticsListDTO.Id = item.Id;
								dailyRecordStacticsListDTO.Item = item.Item;
								dailyRecordStacticsListDTO.DailyRecordStacticsListName = item.DailyRecordStacticsName;
                                dailyRecordStacticsListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                                dailyRecordStacticsListDTO.IsDeleted = item.IsDeleted;
                                DailyLiftingReportDTO.dailyRecordStacticsListDTOs.Add(dailyRecordStacticsListDTO);
                            }
                        }

                        if (DailyLiftingReport.PermitsToWorkList.Any())
                        {
                            foreach (var item in DailyLiftingReport.PermitsToWorkList)
                            {
                                PermitsToWorkListDTO permitsToWorkListDTO = new PermitsToWorkListDTO();
                                permitsToWorkListDTO.Id = item.Id;
                                permitsToWorkListDTO.PermitsToWorkListName = item.PermitsToWorkName;
                                permitsToWorkListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                                permitsToWorkListDTO.IsDeleted = item.IsDeleted;
                                DailyLiftingReportDTO.PermitsToWorkListDTOs.Add(permitsToWorkListDTO);
                            }
                        }
                        newTemp.Add(DailyLiftingReportDTO);
                        //result.Data = prod;
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
        public PageResult<DailyLiftingReportResponseDTO> GettAllDailyLiftingReportByPage(string UserId, string UserRole, int? page, int pagesize = 10)
        {
            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<DailyLiftingReport> temp = DailyLiftingReportRepoistory.getall();
                    List<DailyLiftingReportResponseDTO> newTemp = new List<DailyLiftingReportResponseDTO>();
                    foreach (DailyLiftingReport DailyLiftingReport in temp)
                    {
                        DailyLiftingReportResponseDTO DailyLiftingReportDTO = new DailyLiftingReportResponseDTO();
                        DailyLiftingReportDTO.Id = DailyLiftingReport.Id;
                        DailyLiftingReportDTO.Date = DailyLiftingReport.Date;
                        DailyLiftingReportDTO.RigNumber = DailyLiftingReport.Rig.Number;
                        DailyLiftingReportDTO.MobileCraneName = DailyLiftingReport.MobileCraneName;
                        DailyLiftingReportDTO.Type = DailyLiftingReport.Type;
                        DailyLiftingReportDTO.ChasisNo = DailyLiftingReport.ChasisNo;
                        DailyLiftingReportDTO.Capacity = DailyLiftingReport.Capacity;
                        DailyLiftingReportDTO.DateofLastInspection = DailyLiftingReport.DateofLastInspection;
                        DailyLiftingReportDTO.DateofNextInspection = DailyLiftingReport.DateofNextInspection;
                        DailyLiftingReportDTO.ForkName = DailyLiftingReport.ForkName;
                        DailyLiftingReportDTO.ForkType = DailyLiftingReport.ForkType;
                        DailyLiftingReportDTO.ForkChasisNo = DailyLiftingReport.ForkChasisNo;
                        DailyLiftingReportDTO.ForkCapacity = DailyLiftingReport.ForkCapacity;
                        DailyLiftingReportDTO.ForkDateofLastInspection = DailyLiftingReport.ForkDateofLastInspection;
                        DailyLiftingReportDTO.ForkDateofNextInspection = DailyLiftingReport.ForkDateofNextInspection;
                        DailyLiftingReportDTO.LiftingEngieerCode = DailyLiftingReport.LiftingEngieerCode;
                        DailyLiftingReportDTO.LiftingEngieerName = DailyLiftingReport.LiftingEngieerName;
                        DailyLiftingReportDTO.userName = DailyLiftingReport.user.UserName;
                        if (DailyLiftingReport.SummaryDailyList.Any())
                        {
                            foreach (var item in DailyLiftingReport.SummaryDailyList)
                            {
                                SummaryDailyListDTO summaryDailyListDTO = new SummaryDailyListDTO();
                                summaryDailyListDTO.Id = item.Id;
                                summaryDailyListDTO.SummaryDailyListName = item.SummaryDaily;
                                summaryDailyListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                                summaryDailyListDTO.IsDeleted = item.IsDeleted;
                                DailyLiftingReportDTO.summaryDailyListDTOs.Add(summaryDailyListDTO);
                            }
                        }


                        if (DailyLiftingReport.DailyRecordStacticsList.Any())
                        {
                            foreach (var item in DailyLiftingReport.DailyRecordStacticsList)
                            {
                                DailyRecordStacticsListDTO dailyRecordStacticsListDTO = new DailyRecordStacticsListDTO();
								dailyRecordStacticsListDTO.Id = item.Id;
								dailyRecordStacticsListDTO.Item = item.Item;
								dailyRecordStacticsListDTO.DailyRecordStacticsListName = item.DailyRecordStacticsName;
                                dailyRecordStacticsListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                                dailyRecordStacticsListDTO.IsDeleted = item.IsDeleted;
                                DailyLiftingReportDTO.dailyRecordStacticsListDTOs.Add(dailyRecordStacticsListDTO);
                            }
                        }

                        if (DailyLiftingReport.PermitsToWorkList.Any())
                        {
                            foreach (var item in DailyLiftingReport.PermitsToWorkList)
                            {
                                PermitsToWorkListDTO permitsToWorkListDTO = new PermitsToWorkListDTO();
                                permitsToWorkListDTO.Id = item.Id;
                                permitsToWorkListDTO.PermitsToWorkListName = item.PermitsToWorkName;
                                permitsToWorkListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                                permitsToWorkListDTO.IsDeleted = item.IsDeleted;
                                DailyLiftingReportDTO.PermitsToWorkListDTOs.Add(permitsToWorkListDTO);
                            }
                        }
                        newTemp.Add(DailyLiftingReportDTO);
                        //result.Data = prod;
                    }


                    float countDetails = DailyLiftingReportRepoistory.getall().Count();
                    var result = new PageResult<DailyLiftingReportResponseDTO>
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
                    List<DailyLiftingReport> temp = DailyLiftingReportRepoistory.getall().Where(a => a.user.Id == UserId).ToList();
                    List<DailyLiftingReportResponseDTO> newTemp = new List<DailyLiftingReportResponseDTO>();
                    foreach (DailyLiftingReport DailyLiftingReport in temp)
                    {
                        DailyLiftingReportResponseDTO DailyLiftingReportDTO = new DailyLiftingReportResponseDTO();
                        DailyLiftingReportDTO.Id = DailyLiftingReport.Id;
                        DailyLiftingReportDTO.Date = DailyLiftingReport.Date;
                        DailyLiftingReportDTO.RigNumber = DailyLiftingReport.Rig.Number;
                        DailyLiftingReportDTO.MobileCraneName = DailyLiftingReport.MobileCraneName;
                        DailyLiftingReportDTO.Type = DailyLiftingReport.Type;
                        DailyLiftingReportDTO.ChasisNo = DailyLiftingReport.ChasisNo;
                        DailyLiftingReportDTO.Capacity = DailyLiftingReport.Capacity;
                        DailyLiftingReportDTO.DateofLastInspection = DailyLiftingReport.DateofLastInspection;
                        DailyLiftingReportDTO.DateofNextInspection = DailyLiftingReport.DateofNextInspection;
                        DailyLiftingReportDTO.ForkName = DailyLiftingReport.ForkName;
                        DailyLiftingReportDTO.ForkType = DailyLiftingReport.ForkType;
                        DailyLiftingReportDTO.ForkChasisNo = DailyLiftingReport.ForkChasisNo;
                        DailyLiftingReportDTO.ForkCapacity = DailyLiftingReport.ForkCapacity;
                        DailyLiftingReportDTO.ForkDateofLastInspection = DailyLiftingReport.ForkDateofLastInspection;
                        DailyLiftingReportDTO.ForkDateofNextInspection = DailyLiftingReport.ForkDateofNextInspection;
                        DailyLiftingReportDTO.LiftingEngieerCode = DailyLiftingReport.LiftingEngieerCode;
                        DailyLiftingReportDTO.LiftingEngieerName = DailyLiftingReport.LiftingEngieerName;
                        DailyLiftingReportDTO.userName = DailyLiftingReport.user.UserName;
                        if (DailyLiftingReport.SummaryDailyList.Any())
                        {
                            foreach (var item in DailyLiftingReport.SummaryDailyList)
                            {
                                SummaryDailyListDTO summaryDailyListDTO = new SummaryDailyListDTO();
                                summaryDailyListDTO.Id = item.Id;
                                summaryDailyListDTO.SummaryDailyListName = item.SummaryDaily;
                                summaryDailyListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                                summaryDailyListDTO.IsDeleted = item.IsDeleted;
                                DailyLiftingReportDTO.summaryDailyListDTOs.Add(summaryDailyListDTO);
                            }
                        }


                        if (DailyLiftingReport.DailyRecordStacticsList.Any())
                        {
                            foreach (var item in DailyLiftingReport.DailyRecordStacticsList)
                            {
                                DailyRecordStacticsListDTO dailyRecordStacticsListDTO = new DailyRecordStacticsListDTO();
								dailyRecordStacticsListDTO.Id = item.Id;
								dailyRecordStacticsListDTO.Item = item.Item;
								dailyRecordStacticsListDTO.DailyRecordStacticsListName = item.DailyRecordStacticsName;
                                dailyRecordStacticsListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                                dailyRecordStacticsListDTO.IsDeleted = item.IsDeleted;
                                DailyLiftingReportDTO.dailyRecordStacticsListDTOs.Add(dailyRecordStacticsListDTO);
                            }
                        }

                        if (DailyLiftingReport.PermitsToWorkList.Any())
                        {
                            foreach (var item in DailyLiftingReport.PermitsToWorkList)
                            {
                                PermitsToWorkListDTO permitsToWorkListDTO = new PermitsToWorkListDTO();
                                permitsToWorkListDTO.Id = item.Id;
                                permitsToWorkListDTO.PermitsToWorkListName = item.PermitsToWorkName;
                                permitsToWorkListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                                permitsToWorkListDTO.IsDeleted = item.IsDeleted;
                                DailyLiftingReportDTO.PermitsToWorkListDTOs.Add(permitsToWorkListDTO);
                            }
                        }
                        newTemp.Add(DailyLiftingReportDTO);
                        //result.Data = prod;
                    }

                    float countDetails = DailyLiftingReportRepoistory.getall().Where(a => a.user.Id == UserId).Count();
                    var result = new PageResult<DailyLiftingReportResponseDTO>
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
                return new PageResult<DailyLiftingReportResponseDTO>();

            }
            return new PageResult<DailyLiftingReportResponseDTO>();
        }


        [HttpGet("GetDataById/{ID:int}")]
        public ActionResult<ResultDTO> GetAllWithDataByID(int ID, string UserId, string UserRole)
        {
            ResultDTO result = new ResultDTO();
            if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                DailyLiftingReport DailyLiftingReport = DailyLiftingReportRepoistory.getall().FirstOrDefault(a => a.Id == ID);
                if (DailyLiftingReport != null)
                {
                    DailyLiftingReportResponseDTO DailyLiftingReportDTO = new DailyLiftingReportResponseDTO();
                    DailyLiftingReportDTO.Id = DailyLiftingReport.Id;
                    DailyLiftingReportDTO.Date = DailyLiftingReport.Date;
                    DailyLiftingReportDTO.RigNumber = DailyLiftingReport.Rig.Number;
                    DailyLiftingReportDTO.MobileCraneName = DailyLiftingReport.MobileCraneName;
                    DailyLiftingReportDTO.Type = DailyLiftingReport.Type;
                    DailyLiftingReportDTO.ChasisNo = DailyLiftingReport.ChasisNo;
                    DailyLiftingReportDTO.Capacity = DailyLiftingReport.Capacity;
                    DailyLiftingReportDTO.DateofLastInspection = DailyLiftingReport.DateofLastInspection;
                    DailyLiftingReportDTO.DateofNextInspection = DailyLiftingReport.DateofNextInspection;
                    DailyLiftingReportDTO.ForkName = DailyLiftingReport.ForkName;
                    DailyLiftingReportDTO.ForkType = DailyLiftingReport.ForkType;
                    DailyLiftingReportDTO.ForkChasisNo = DailyLiftingReport.ForkChasisNo;
                    DailyLiftingReportDTO.ForkCapacity = DailyLiftingReport.ForkCapacity;
                    DailyLiftingReportDTO.ForkDateofLastInspection = DailyLiftingReport.ForkDateofLastInspection;
                    DailyLiftingReportDTO.ForkDateofNextInspection = DailyLiftingReport.ForkDateofNextInspection;
                    DailyLiftingReportDTO.LiftingEngieerCode = DailyLiftingReport.LiftingEngieerCode;
                    DailyLiftingReportDTO.LiftingEngieerName = DailyLiftingReport.LiftingEngieerName;
                    DailyLiftingReportDTO.userName = DailyLiftingReport.user.UserName;
                    if (DailyLiftingReport.SummaryDailyList.Any())
                    {
                        foreach (var item in DailyLiftingReport.SummaryDailyList)
                        {
                            SummaryDailyListDTO summaryDailyListDTO = new SummaryDailyListDTO();
                            summaryDailyListDTO.Id = item.Id;
                            summaryDailyListDTO.Item = item.Item;
                            summaryDailyListDTO.SummaryDailyListName = item.SummaryDaily;
                            summaryDailyListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                            summaryDailyListDTO.IsDeleted = item.IsDeleted;
                            DailyLiftingReportDTO.summaryDailyListDTOs.Add(summaryDailyListDTO);
                        }
                    }


                    if (DailyLiftingReport.DailyRecordStacticsList.Any())
                    {
                        foreach (var item in DailyLiftingReport.DailyRecordStacticsList)
                        {
                            DailyRecordStacticsListDTO dailyRecordStacticsListDTO = new DailyRecordStacticsListDTO();
                            dailyRecordStacticsListDTO.Id = item.Id;
                            dailyRecordStacticsListDTO.Item = item.Item;
                            dailyRecordStacticsListDTO.DailyRecordStacticsListName = item.DailyRecordStacticsName;
                            dailyRecordStacticsListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                            dailyRecordStacticsListDTO.IsDeleted = item.IsDeleted;
                            DailyLiftingReportDTO.dailyRecordStacticsListDTOs.Add(dailyRecordStacticsListDTO);
                        }
                    }

                    if (DailyLiftingReport.PermitsToWorkList.Any())
                    {
                        foreach (var item in DailyLiftingReport.PermitsToWorkList)
                        {
                            PermitsToWorkListDTO permitsToWorkListDTO = new PermitsToWorkListDTO();
                            permitsToWorkListDTO.Id = item.Id;
                            permitsToWorkListDTO.Item = item.Item;
                            permitsToWorkListDTO.PermitsToWorkListName = item.PermitsToWorkName;
                            permitsToWorkListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                            permitsToWorkListDTO.IsDeleted = item.IsDeleted;
                            DailyLiftingReportDTO.PermitsToWorkListDTOs.Add(permitsToWorkListDTO);
                        }
                    }

                    result.Message = "Success";
                    result.Statescode = 200;
                    result.Data = DailyLiftingReportDTO;

                    return result;
                }
            }
            else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
            {
                DailyLiftingReport DailyLiftingReport = DailyLiftingReportRepoistory.getall().FirstOrDefault(a => a.Id == ID && a.user.Id == UserId);
                if (DailyLiftingReport != null)
                {
                    DailyLiftingReportResponseDTO DailyLiftingReportDTO = new DailyLiftingReportResponseDTO();
                    DailyLiftingReportDTO.Id = DailyLiftingReport.Id;
                    DailyLiftingReportDTO.Date = DailyLiftingReport.Date;
                    DailyLiftingReportDTO.RigNumber = DailyLiftingReport.Rig.Number;
                    DailyLiftingReportDTO.MobileCraneName = DailyLiftingReport.MobileCraneName;
                    DailyLiftingReportDTO.Type = DailyLiftingReport.Type;
                    DailyLiftingReportDTO.ChasisNo = DailyLiftingReport.ChasisNo;
                    DailyLiftingReportDTO.Capacity = DailyLiftingReport.Capacity;
                    DailyLiftingReportDTO.DateofLastInspection = DailyLiftingReport.DateofLastInspection;
                    DailyLiftingReportDTO.DateofNextInspection = DailyLiftingReport.DateofNextInspection;
                    DailyLiftingReportDTO.ForkName = DailyLiftingReport.ForkName;
                    DailyLiftingReportDTO.ForkType = DailyLiftingReport.ForkType;
                    DailyLiftingReportDTO.ForkChasisNo = DailyLiftingReport.ForkChasisNo;
                    DailyLiftingReportDTO.ForkCapacity = DailyLiftingReport.ForkCapacity;
                    DailyLiftingReportDTO.ForkDateofLastInspection = DailyLiftingReport.ForkDateofLastInspection;
                    DailyLiftingReportDTO.ForkDateofNextInspection = DailyLiftingReport.ForkDateofNextInspection;
                    DailyLiftingReportDTO.LiftingEngieerCode = DailyLiftingReport.LiftingEngieerCode;
                    DailyLiftingReportDTO.LiftingEngieerName = DailyLiftingReport.LiftingEngieerName;
                    DailyLiftingReportDTO.userName = DailyLiftingReport.user.UserName;
                    if (DailyLiftingReport.SummaryDailyList.Any())
                    {
                        foreach (var item in DailyLiftingReport.SummaryDailyList)
                        {
                            SummaryDailyListDTO summaryDailyListDTO = new SummaryDailyListDTO();
                            summaryDailyListDTO.Id = item.Id;
                            summaryDailyListDTO.SummaryDailyListName = item.SummaryDaily;
                            summaryDailyListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                            summaryDailyListDTO.IsDeleted = item.IsDeleted;
                            DailyLiftingReportDTO.summaryDailyListDTOs.Add(summaryDailyListDTO);
                        }
                    }


                    if (DailyLiftingReport.DailyRecordStacticsList.Any())
                    {
                        foreach (var item in DailyLiftingReport.DailyRecordStacticsList)
                        {
                            DailyRecordStacticsListDTO dailyRecordStacticsListDTO = new DailyRecordStacticsListDTO();
							dailyRecordStacticsListDTO.Id = item.Id;
							dailyRecordStacticsListDTO.Item = item.Item;
							dailyRecordStacticsListDTO.DailyRecordStacticsListName = item.DailyRecordStacticsName;
                            dailyRecordStacticsListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                            dailyRecordStacticsListDTO.IsDeleted = item.IsDeleted;
                            DailyLiftingReportDTO.dailyRecordStacticsListDTOs.Add(dailyRecordStacticsListDTO);
                        }
                    }

                    if (DailyLiftingReport.PermitsToWorkList.Any())
                    {
                        foreach (var item in DailyLiftingReport.PermitsToWorkList)
                        {
                            PermitsToWorkListDTO permitsToWorkListDTO = new PermitsToWorkListDTO();
                            permitsToWorkListDTO.Id = item.Id;
                            permitsToWorkListDTO.PermitsToWorkListName = item.PermitsToWorkName;
                            permitsToWorkListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                            permitsToWorkListDTO.IsDeleted = item.IsDeleted;
                            DailyLiftingReportDTO.PermitsToWorkListDTOs.Add(permitsToWorkListDTO);
                        }
                    }


                    result.Message = "Success";
                    result.Statescode = 200;
                    result.Data = DailyLiftingReportDTO;

                    return result;
                }
            }

            result.Statescode = 404;
            result.Message = "data not found";
            return result;
        }



        [HttpGet("GetDataByRigAndDateAndName{RigNumber:int}")]
        public ActionResult<ResultDTO> GetDataByRigAndDateAndName(string Name, string UserId, string UserRole, DateTime date, int RigNumber)
        {

            ResultDTO result = new ResultDTO();

            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<DailyLiftingReportResponseDTO> newTemp = new List<DailyLiftingReportResponseDTO>();
                    List<DailyLiftingReport> temp = DailyLiftingReportRepoistory.getall().Where(a => a.LiftingEngieerName == Name && a.Rig.Number == RigNumber && a.Date.Date == date.Date).ToList();
                    foreach (DailyLiftingReport DailyLiftingReport in temp)
                    {
                        DailyLiftingReportResponseDTO DailyLiftingReportDTO = new DailyLiftingReportResponseDTO();
                        DailyLiftingReportDTO.Id = default;
                        DailyLiftingReportDTO.RigNumber = DailyLiftingReport.Rig.Number;
                        DailyLiftingReportDTO.Date = DailyLiftingReport.Date;
                        DailyLiftingReportDTO.ForkDateofNextInspection = DailyLiftingReport.ForkDateofNextInspection;
                        DailyLiftingReportDTO.ForkDateofLastInspection = DailyLiftingReport.ForkDateofLastInspection;
                        DailyLiftingReportDTO.ForkCapacity = DailyLiftingReport.ForkCapacity;
                        DailyLiftingReportDTO.ForkChasisNo = DailyLiftingReport.ForkChasisNo;
                        DailyLiftingReportDTO.ForkType = DailyLiftingReport.ForkType;
                        DailyLiftingReportDTO.ForkName = DailyLiftingReport.ForkName;
                        DailyLiftingReportDTO.DateofNextInspection = DailyLiftingReport.DateofNextInspection;
                        DailyLiftingReportDTO.DateofLastInspection = DailyLiftingReport.DateofLastInspection;
                        DailyLiftingReportDTO.Capacity = DailyLiftingReport.Capacity;
                        DailyLiftingReportDTO.ChasisNo = DailyLiftingReport.ChasisNo;
                        DailyLiftingReportDTO.Type = DailyLiftingReport.Type;
                        DailyLiftingReportDTO.MobileCraneName = DailyLiftingReport.MobileCraneName;
                        DailyLiftingReportDTO.userName = DailyLiftingReport.user.UserName;
                        DailyLiftingReportDTO.LiftingEngieerCode = DailyLiftingReport.LiftingEngieerCode;
                        DailyLiftingReportDTO.LiftingEngieerName = DailyLiftingReport.LiftingEngieerName;
                        foreach (var item in DailyLiftingReport.SummaryDailyList)
                        {
                            SummaryDailyListDTO summaryDailyListDTO = new SummaryDailyListDTO();
                            summaryDailyListDTO.Id = item.Id;
							summaryDailyListDTO.SummaryDailyListName = item.SummaryDaily;
							summaryDailyListDTO.Item = item.Item;

							summaryDailyListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                            summaryDailyListDTO.IsDeleted = item.IsDeleted;
                            DailyLiftingReportDTO.summaryDailyListDTOs.Add(summaryDailyListDTO);
                        }
                        foreach (var item in DailyLiftingReport.DailyRecordStacticsList)
                        {
                            DailyRecordStacticsListDTO dailyRecordStacticsListDTO = new DailyRecordStacticsListDTO();
							dailyRecordStacticsListDTO.Id = item.Id;
							dailyRecordStacticsListDTO.DailyRecordStacticsListName = item.DailyRecordStacticsName;
							dailyRecordStacticsListDTO.Item = item.Item;

							dailyRecordStacticsListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                            dailyRecordStacticsListDTO.IsDeleted = item.IsDeleted;
                            DailyLiftingReportDTO.dailyRecordStacticsListDTOs.Add(dailyRecordStacticsListDTO);
                        }

                        foreach (var item in DailyLiftingReport.PermitsToWorkList)
                        {
                            PermitsToWorkListDTO permitsToWorkListDTO = new PermitsToWorkListDTO();
                            permitsToWorkListDTO.Id = item.Id;
							permitsToWorkListDTO.PermitsToWorkListName = item.PermitsToWorkName;
							permitsToWorkListDTO.Item = item.Item;

							permitsToWorkListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                            permitsToWorkListDTO.IsDeleted = item.IsDeleted;
                            DailyLiftingReportDTO.PermitsToWorkListDTOs.Add(permitsToWorkListDTO);
                        }

                        newTemp.Add(DailyLiftingReportDTO);
                        //result.Data = prod;
                    }



                    result.Message = "Success";
                    result.Data = newTemp;
                    result.Statescode = 200;
                    return result;
                }
                else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
                {
                    List<DailyLiftingReportResponseDTO> newTemp = new List<DailyLiftingReportResponseDTO>();
                    List<DailyLiftingReport> temp = DailyLiftingReportRepoistory.getall().Where(a => a.LiftingEngieerName == Name && a.Rig.Number == RigNumber && a.Date.Date == date.Date && a.user.Id == UserId).ToList();
                    foreach (DailyLiftingReport DailyLiftingReport in temp)
                    {
                        DailyLiftingReportResponseDTO DailyLiftingReportDTO = new DailyLiftingReportResponseDTO();
                        DailyLiftingReportDTO.Id = default;
                        DailyLiftingReportDTO.RigNumber = DailyLiftingReport.Rig.Number;
                        DailyLiftingReportDTO.Date = DailyLiftingReport.Date;
                        DailyLiftingReportDTO.ForkDateofNextInspection = DailyLiftingReport.ForkDateofNextInspection;
                        DailyLiftingReportDTO.ForkDateofLastInspection = DailyLiftingReport.ForkDateofLastInspection;
                        DailyLiftingReportDTO.ForkCapacity = DailyLiftingReport.ForkCapacity;
                        DailyLiftingReportDTO.ForkChasisNo = DailyLiftingReport.ForkChasisNo;
                        DailyLiftingReportDTO.ForkType = DailyLiftingReport.ForkType;
                        DailyLiftingReportDTO.ForkName = DailyLiftingReport.ForkName;
                        DailyLiftingReportDTO.DateofNextInspection = DailyLiftingReport.DateofNextInspection;
                        DailyLiftingReportDTO.DateofLastInspection = DailyLiftingReport.DateofLastInspection;
                        DailyLiftingReportDTO.Capacity = DailyLiftingReport.Capacity;
                        DailyLiftingReportDTO.ChasisNo = DailyLiftingReport.ChasisNo;
                        DailyLiftingReportDTO.Type = DailyLiftingReport.Type;
                        DailyLiftingReportDTO.MobileCraneName = DailyLiftingReport.MobileCraneName;
                        DailyLiftingReportDTO.userName = DailyLiftingReport.user.UserName;
                        DailyLiftingReportDTO.LiftingEngieerCode = DailyLiftingReport.LiftingEngieerCode;
                        DailyLiftingReportDTO.LiftingEngieerName = DailyLiftingReport.LiftingEngieerName;
						foreach (var item in DailyLiftingReport.SummaryDailyList)
						{
							SummaryDailyListDTO summaryDailyListDTO = new SummaryDailyListDTO();
							summaryDailyListDTO.Id = item.Id;
							summaryDailyListDTO.SummaryDailyListName = item.SummaryDaily;
							summaryDailyListDTO.Item = item.Item;

							summaryDailyListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
							summaryDailyListDTO.IsDeleted = item.IsDeleted;
							DailyLiftingReportDTO.summaryDailyListDTOs.Add(summaryDailyListDTO);
						}
						foreach (var item in DailyLiftingReport.DailyRecordStacticsList)
						{
							DailyRecordStacticsListDTO dailyRecordStacticsListDTO = new DailyRecordStacticsListDTO();
							dailyRecordStacticsListDTO.Id = item.Id;
							dailyRecordStacticsListDTO.DailyRecordStacticsListName = item.DailyRecordStacticsName;
							dailyRecordStacticsListDTO.Item = item.Item;

							dailyRecordStacticsListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
							dailyRecordStacticsListDTO.IsDeleted = item.IsDeleted;
							DailyLiftingReportDTO.dailyRecordStacticsListDTOs.Add(dailyRecordStacticsListDTO);
						}

						foreach (var item in DailyLiftingReport.PermitsToWorkList)
						{
							PermitsToWorkListDTO permitsToWorkListDTO = new PermitsToWorkListDTO();
							permitsToWorkListDTO.Id = item.Id;
							permitsToWorkListDTO.PermitsToWorkListName = item.PermitsToWorkName;
							permitsToWorkListDTO.Item = item.Item;

							permitsToWorkListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
							permitsToWorkListDTO.IsDeleted = item.IsDeleted;
							DailyLiftingReportDTO.PermitsToWorkListDTOs.Add(permitsToWorkListDTO);
						}


						newTemp.Add(DailyLiftingReportDTO);
                        //result.Data = prod;
                    }
                    result.Message = "Success";
                    result.Data = newTemp;
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


        [HttpGet("{ID:int}")]
        public ActionResult<ResultDTO> GetByID(int ID, string UserId, string UserRole)
        {
            ResultDTO result = new ResultDTO();

            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    DailyLiftingReport DailyLiftingReport = DailyLiftingReportRepoistory.getall().FirstOrDefault(a => a.Id == ID);
                    DailyLiftingReportDTO DailyLiftingReportDTO = new DailyLiftingReportDTO();
                    DailyLiftingReportDTO.Id = DailyLiftingReport.Id;
                    DailyLiftingReportDTO.Date = DailyLiftingReport.Date;
                    DailyLiftingReportDTO.RigId = DailyLiftingReport.RigId;
                    DailyLiftingReportDTO.MobileCraneName = DailyLiftingReport.MobileCraneName;
                    DailyLiftingReportDTO.Type = DailyLiftingReport.Type;
                    DailyLiftingReportDTO.ChasisNo = DailyLiftingReport.ChasisNo;
                    DailyLiftingReportDTO.Capacity = DailyLiftingReport.Capacity;
                    DailyLiftingReportDTO.DateofLastInspection = DailyLiftingReport.DateofLastInspection;
                    DailyLiftingReportDTO.DateofNextInspection = DailyLiftingReport.DateofNextInspection;
                    DailyLiftingReportDTO.ForkName = DailyLiftingReport.ForkName;
                    DailyLiftingReportDTO.ForkType = DailyLiftingReport.ForkType;
                    DailyLiftingReportDTO.ForkChasisNo = DailyLiftingReport.ForkChasisNo;
                    DailyLiftingReportDTO.ForkCapacity = DailyLiftingReport.ForkCapacity;
                    DailyLiftingReportDTO.ForkDateofLastInspection = DailyLiftingReport.ForkDateofLastInspection;
                    DailyLiftingReportDTO.ForkDateofNextInspection = DailyLiftingReport.ForkDateofNextInspection;
                    DailyLiftingReportDTO.LiftingEngieerCode = DailyLiftingReport.LiftingEngieerCode;
                    DailyLiftingReportDTO.LiftingEngieerName = DailyLiftingReport.LiftingEngieerName;
                    DailyLiftingReportDTO.userID = DailyLiftingReport.userID;

                    if (DailyLiftingReport.SummaryDailyList.Any())
                    {
                        foreach (var item in DailyLiftingReport.SummaryDailyList)
                        {
                            SummaryDailyListDTO summaryDailyListDTO = new SummaryDailyListDTO();
                            summaryDailyListDTO.Id = item.Id;
                            summaryDailyListDTO.Item=item.Item;
                            summaryDailyListDTO.SummaryDailyListName = item.SummaryDaily;
                            summaryDailyListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                            summaryDailyListDTO.IsDeleted = item.IsDeleted;
                            DailyLiftingReportDTO.summaryDailyListDTOs.Add(summaryDailyListDTO);
                        }
                    }


                    if (DailyLiftingReport.DailyRecordStacticsList.Any())
                    {
                        foreach (var item in DailyLiftingReport.DailyRecordStacticsList)
                        {
                            DailyRecordStacticsListDTO dailyRecordStacticsListDTO = new DailyRecordStacticsListDTO();
                            dailyRecordStacticsListDTO.Id = item.Id;
                            dailyRecordStacticsListDTO.Item = item.Item;
                            dailyRecordStacticsListDTO.DailyRecordStacticsListName = item.DailyRecordStacticsName;
                            dailyRecordStacticsListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                            dailyRecordStacticsListDTO.IsDeleted = item.IsDeleted;
                            DailyLiftingReportDTO.dailyRecordStacticsListDTOs.Add(dailyRecordStacticsListDTO);
                        }
                    }

                    if (DailyLiftingReport.PermitsToWorkList.Any())
                    {
                        foreach (var item in DailyLiftingReport.PermitsToWorkList)
                        {
                            PermitsToWorkListDTO permitsToWorkListDTO = new PermitsToWorkListDTO();
                            permitsToWorkListDTO.Id = item.Id;
                            permitsToWorkListDTO.Item = item.Item;
                            permitsToWorkListDTO.PermitsToWorkListName = item.PermitsToWorkName;
                            permitsToWorkListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                            permitsToWorkListDTO.IsDeleted = item.IsDeleted;
                            DailyLiftingReportDTO.PermitsToWorkListDTOs.Add(permitsToWorkListDTO);
                        }
                    }
                   
                    result.Message = "Success";
                    result.Data = DailyLiftingReportDTO;
                    result.Statescode = 200;
                    return result;

                }
                else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
                {
                    DailyLiftingReport DailyLiftingReport = DailyLiftingReportRepo.getall().FirstOrDefault(a => a.Id == ID && a.userID == UserId);
                    DailyLiftingReportDTO DailyLiftingReportDTO = new DailyLiftingReportDTO();
                    DailyLiftingReportDTO.Id = DailyLiftingReport.Id;
                    DailyLiftingReportDTO.Date = DailyLiftingReport.Date;
                    DailyLiftingReportDTO.RigId = DailyLiftingReport.RigId;         
                    DailyLiftingReportDTO.MobileCraneName = DailyLiftingReport.MobileCraneName;
                    DailyLiftingReportDTO.Type = DailyLiftingReport.Type;
                    DailyLiftingReportDTO.ChasisNo = DailyLiftingReport.ChasisNo;
                    DailyLiftingReportDTO.Capacity = DailyLiftingReport.Capacity;
                    DailyLiftingReportDTO.DateofLastInspection = DailyLiftingReport.DateofLastInspection;
                    DailyLiftingReportDTO.DateofNextInspection = DailyLiftingReport.DateofNextInspection;
                    DailyLiftingReportDTO.ForkName = DailyLiftingReport.ForkName;
                    DailyLiftingReportDTO.ForkType = DailyLiftingReport.ForkType;
                    DailyLiftingReportDTO.ForkChasisNo = DailyLiftingReport.ForkChasisNo;
                    DailyLiftingReportDTO.ForkCapacity = DailyLiftingReport.ForkCapacity;
                    DailyLiftingReportDTO.ForkDateofLastInspection = DailyLiftingReport.ForkDateofLastInspection;
                    DailyLiftingReportDTO.ForkDateofNextInspection = DailyLiftingReport.ForkDateofNextInspection;
                    DailyLiftingReportDTO.LiftingEngieerCode = DailyLiftingReport.LiftingEngieerCode;
                    DailyLiftingReportDTO.LiftingEngieerName = DailyLiftingReport.LiftingEngieerName;
                    DailyLiftingReportDTO.userID = DailyLiftingReport.userID;

                    if (DailyLiftingReport.SummaryDailyList.Any())
                    {
                        foreach (var item in DailyLiftingReport.SummaryDailyList)
                        {
                            SummaryDailyListDTO summaryDailyListDTO = new SummaryDailyListDTO();
                            summaryDailyListDTO.Id = item.Id;
                            summaryDailyListDTO.SummaryDailyListName = item.SummaryDaily;
                            summaryDailyListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                            summaryDailyListDTO.IsDeleted = item.IsDeleted;
                            DailyLiftingReportDTO.summaryDailyListDTOs.Add(summaryDailyListDTO);
                        }
                    }


                    if (DailyLiftingReport.DailyRecordStacticsList.Any())
                    {
                        foreach (var item in DailyLiftingReport.DailyRecordStacticsList)
                        {
                            DailyRecordStacticsListDTO dailyRecordStacticsListDTO = new DailyRecordStacticsListDTO();
							dailyRecordStacticsListDTO.Id = item.Id;
                            dailyRecordStacticsListDTO.Item = item.Item;
							dailyRecordStacticsListDTO.DailyRecordStacticsListName = item.DailyRecordStacticsName;
                            dailyRecordStacticsListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                            dailyRecordStacticsListDTO.IsDeleted = item.IsDeleted;
                            DailyLiftingReportDTO.dailyRecordStacticsListDTOs.Add(dailyRecordStacticsListDTO);
                        }
                    }

                    if (DailyLiftingReport.PermitsToWorkList.Any())
                    {
                        foreach (var item in DailyLiftingReport.PermitsToWorkList)
                        {
                            PermitsToWorkListDTO permitsToWorkListDTO = new PermitsToWorkListDTO();
                            permitsToWorkListDTO.Id = item.Id;
                            permitsToWorkListDTO.PermitsToWorkListName = item.PermitsToWorkName;
                            permitsToWorkListDTO.DailyLiftingReportId = item.DailyLiftingReportId;
                            permitsToWorkListDTO.IsDeleted = item.IsDeleted;
                            DailyLiftingReportDTO.PermitsToWorkListDTOs.Add(permitsToWorkListDTO);
                        }
                    }
                   
                    result.Message = "Success";
                    result.Data = DailyLiftingReportDTO;
                    result.Statescode = 200;
                    return result;
                }
            }
            catch (Exception Ex)
            {
                result.Statescode = 404;
                result.Message = "data not found";
            }

            return result;
        }



        [HttpPost]
        public ActionResult<ResultDTO> AddDailyLiftingReport(DailyLiftingReportDTO DailyLiftingReportDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    DailyLiftingReport DailyLiftingReportObj = new DailyLiftingReport();
                    DailyLiftingReportObj.Id = default;
                    DailyLiftingReportObj.RigId = DailyLiftingReportDTO.RigId;
                    DailyLiftingReportObj.Date = DailyLiftingReportDTO.Date;
                    DailyLiftingReportObj.LiftingEngieerCode = DailyLiftingReportDTO.LiftingEngieerCode;
                    DailyLiftingReportObj.LiftingEngieerName = DailyLiftingReportDTO.LiftingEngieerName;
                    DailyLiftingReportObj.userID = DailyLiftingReportDTO.userID;
                    DailyLiftingReportObj.Type = DailyLiftingReportDTO.Type;
                    DailyLiftingReportObj.Capacity = DailyLiftingReportDTO.Capacity;
                    DailyLiftingReportObj.ChasisNo = DailyLiftingReportDTO.ChasisNo;
                    DailyLiftingReportObj.DateofLastInspection = DailyLiftingReportDTO.DateofLastInspection;
                    DailyLiftingReportObj.DateofNextInspection = DailyLiftingReportDTO.DateofNextInspection;
                    DailyLiftingReportObj.MobileCraneName = DailyLiftingReportDTO.MobileCraneName;
                    DailyLiftingReportObj.ForkType = DailyLiftingReportDTO.ForkType;
                    DailyLiftingReportObj.ForkCapacity = DailyLiftingReportDTO.ForkCapacity;
                    DailyLiftingReportObj.ForkChasisNo = DailyLiftingReportDTO.ForkChasisNo;
                    DailyLiftingReportObj.ForkDateofLastInspection = DailyLiftingReportDTO.ForkDateofLastInspection;
                    DailyLiftingReportObj.ForkDateofNextInspection = DailyLiftingReportDTO.ForkDateofNextInspection;
                    DailyLiftingReportObj.ForkName = DailyLiftingReportDTO.ForkName;

                    DailyLiftingReportRepo.create(DailyLiftingReportObj);


                    foreach (var item in DailyLiftingReportDTO.summaryDailyListDTOs)
                    {
                        SummaryDailyList summaryDailyList = new SummaryDailyList();
                        //lightBus.Id = item.Id;
                        summaryDailyList.SummaryDaily = item.SummaryDailyListName;
                        summaryDailyList.Item = item.Item;
                        summaryDailyList.DailyLiftingReportId = DailyLiftingReportObj.Id;
                        summaryDailyList.IsDeleted = item.IsDeleted;
                        SummaryDailyListRepo.create(summaryDailyList);
                    }
                    foreach (var item in DailyLiftingReportDTO.PermitsToWorkListDTOs)
                    {
                        PermitsToWorkList permitsToWorkList = new PermitsToWorkList();
                        // manPickup.Id = item.Id;
                        permitsToWorkList.PermitsToWorkName = item.PermitsToWorkListName;
                        permitsToWorkList.Item = item.Item;
                        permitsToWorkList.DailyLiftingReportId = DailyLiftingReportObj.Id;
                        permitsToWorkList.IsDeleted = item.IsDeleted;
                        PermitsToWorkListRepo.create(permitsToWorkList);
                    }
                    foreach (var item in DailyLiftingReportDTO.dailyRecordStacticsListDTOs)
                    {
                        DailyRecordStacticsList dailyRecordStacticsList = new DailyRecordStacticsList();
                        //heavyTrucks.Id = item.Id;
                        dailyRecordStacticsList.DailyRecordStacticsName = item.DailyRecordStacticsListName;
                        dailyRecordStacticsList.Item = item.Item;
                        dailyRecordStacticsList.DailyLiftingReportId = DailyLiftingReportObj.Id;
                        dailyRecordStacticsList.IsDeleted = item.IsDeleted;
                        DailyRecordStacticsListRepo.create(dailyRecordStacticsList);
                    }

                    result.Message = "Success";
                    result.Data = DailyLiftingReportDTO;
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

        [HttpPut("{id:int}")]
        public ActionResult<ResultDTO> Put(int id, DailyLiftingReportDTO newDailyLiftingReport) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {

                    DailyLiftingReport orgDailyLiftingReport = DailyLiftingReportRepo.getbyid(id);
                    orgDailyLiftingReport.RigId = newDailyLiftingReport.RigId;
                    orgDailyLiftingReport.Date = newDailyLiftingReport.Date;
                    orgDailyLiftingReport.ForkDateofNextInspection = newDailyLiftingReport.ForkDateofNextInspection;
                    orgDailyLiftingReport.ForkDateofLastInspection = newDailyLiftingReport.ForkDateofLastInspection;
                    orgDailyLiftingReport.ForkCapacity = newDailyLiftingReport.ForkCapacity;
                    orgDailyLiftingReport.ForkChasisNo = newDailyLiftingReport.ForkChasisNo;
                    orgDailyLiftingReport.ForkType = newDailyLiftingReport.ForkType;
                    orgDailyLiftingReport.ForkName = newDailyLiftingReport.ForkName;
                    orgDailyLiftingReport.DateofNextInspection = newDailyLiftingReport.DateofNextInspection;
                    orgDailyLiftingReport.DateofLastInspection = newDailyLiftingReport.DateofLastInspection;
                    orgDailyLiftingReport.Type = newDailyLiftingReport.Type;
                    orgDailyLiftingReport.Capacity = newDailyLiftingReport.Capacity;
                    orgDailyLiftingReport.ChasisNo = newDailyLiftingReport.ChasisNo;
                    orgDailyLiftingReport.MobileCraneName = newDailyLiftingReport.MobileCraneName;
                    //orgDailyLiftingReport.userID = newDailyLiftingReport.userID;
                    DailyLiftingReportRepo.update(orgDailyLiftingReport);

                    
					var oldSummaryDailyList = SummaryDailyListRepo.getall().Where(o => o.DailyLiftingReportId == id).ToList();
					if (oldSummaryDailyList.Any())
					{
						if (oldSummaryDailyList.Count == newDailyLiftingReport.summaryDailyListDTOs.Count)
						{
							for (int i = 0; i < oldSummaryDailyList.Count(); i++)
							{
								var OldItem = oldSummaryDailyList[i];
								var newItem = newDailyLiftingReport.summaryDailyListDTOs[i];

								OldItem.SummaryDaily = newItem.SummaryDailyListName;
								OldItem.DailyLiftingReportId = id;
								SummaryDailyListRepo.update(OldItem);
							}
						}
						else
						{
							foreach (var item in oldSummaryDailyList)
							{
								SummaryDailyListRepo.delete(item);
							}
							foreach (var item in newDailyLiftingReport.summaryDailyListDTOs)
							{
								SummaryDailyList summaryDailyList = new SummaryDailyList();
								//lightBus.Id = item.Id;
								summaryDailyList.SummaryDaily = item.SummaryDailyListName;
								summaryDailyList.Item = item.Item;
								summaryDailyList.DailyLiftingReportId = id;
								summaryDailyList.IsDeleted = item.IsDeleted;
								SummaryDailyListRepo.create(summaryDailyList);
							}
						}
					}
					else
					{
						foreach (var item in newDailyLiftingReport.summaryDailyListDTOs)
						{
							SummaryDailyList summaryDailyList = new SummaryDailyList();
							//lightBus.Id = item.Id;
							summaryDailyList.SummaryDaily = item.SummaryDailyListName;
							summaryDailyList.Item = item.Item;
							summaryDailyList.DailyLiftingReportId = id;
							summaryDailyList.IsDeleted = item.IsDeleted;
							SummaryDailyListRepo.create(summaryDailyList);
						}
					}

					var oldDailyRecordStacticsList = DailyRecordStacticsListRepo.getall().Where(o => o.DailyLiftingReportId == id).ToList();
                    for (int i = 0; i < oldDailyRecordStacticsList.Count(); i++)
                    {
                        var OldItem = oldDailyRecordStacticsList[i];
                        var newItem = newDailyLiftingReport.dailyRecordStacticsListDTOs[i];

						OldItem.DailyRecordStacticsName = newItem.DailyRecordStacticsListName;
						OldItem.Item = newItem.Item;
						OldItem.DailyLiftingReportId = id;
                        DailyRecordStacticsListRepo.update(OldItem);
                    }
                    
					var oldPermitsToWorkList = PermitsToWorkListRepo.getall().Where(o => o.DailyLiftingReportId == id).ToList();
					if (oldPermitsToWorkList.Any())
					{
						if (oldPermitsToWorkList.Count == newDailyLiftingReport.PermitsToWorkListDTOs.Count)
						{
							for (int i = 0; i < oldPermitsToWorkList.Count(); i++)
							{
								var OldItem = oldPermitsToWorkList[i];
								var newItem = newDailyLiftingReport.PermitsToWorkListDTOs[i];

								OldItem.PermitsToWorkName = newItem.PermitsToWorkListName;
								OldItem.DailyLiftingReportId = id;
								PermitsToWorkListRepo.update(OldItem);
							}
						}
						else
						{
							foreach (var item in oldPermitsToWorkList)
							{
								PermitsToWorkListRepo.delete(item);
							}
							foreach (var item in newDailyLiftingReport.PermitsToWorkListDTOs)
							{
								PermitsToWorkList permitsToWorkList = new PermitsToWorkList();
								// manPickup.Id = item.Id;
								permitsToWorkList.PermitsToWorkName = item.PermitsToWorkListName;
								permitsToWorkList.Item = item.Item;
								permitsToWorkList.DailyLiftingReportId = id;
								permitsToWorkList.IsDeleted = item.IsDeleted;
								PermitsToWorkListRepo.create(permitsToWorkList);
							}
						}
					}
					else
					{
						foreach (var item in newDailyLiftingReport.PermitsToWorkListDTOs)
						{
							PermitsToWorkList permitsToWorkList = new PermitsToWorkList();
							// manPickup.Id = item.Id;
							permitsToWorkList.PermitsToWorkName = item.PermitsToWorkListName;
							permitsToWorkList.Item = item.Item;
							permitsToWorkList.DailyLiftingReportId = id;
							permitsToWorkList.IsDeleted = item.IsDeleted;
							PermitsToWorkListRepo.create(permitsToWorkList);
						}
					}
					result.Data = orgDailyLiftingReport;
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
                DailyLiftingReport DailyLiftingReport = DailyLiftingReportRepo.getbyid(id);
                DailyLiftingReport.IsDeleted = true;
                DailyLiftingReportRepo.update(DailyLiftingReport);

                result.Data = DailyLiftingReport;
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

