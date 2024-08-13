using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using TempProject.Models;

namespace TempProject.Repository
{
    public class DailyLiftingReportRepository : IDailyLiftingReportRepository
    {
        Context c;
        public DailyLiftingReportRepository(Context c)
        {
            this.c = c;
        }

        public List<DailyLiftingReport> getall()
        {
            return c.DailyLiftingReports
                //.Include(a => a.CraneDailyReports)
                .Include(a => a.Rig)
                .Include(a => a.user)
                .Include(a=> a.SummaryDailyList)
                .Include(a => a.DailyRecordStacticsList)
                .Include(a => a.PermitsToWorkList)

                .Where(a => a.IsDeleted == false)
                .Select(a => new DailyLiftingReport
                {
                    Id = a.Id,
                    Rig = new Rig { Number = a.Rig.Number, Id=a.Rig.Id },
					RigId = a.RigId,
                    Date = a.Date,
                    PermitsToWorkList = a.PermitsToWorkList,
                    SummaryDailyList = a.SummaryDailyList,
                    DailyRecordStacticsList= a.DailyRecordStacticsList,
                    LiftingEngieerCode = a.LiftingEngieerCode,
                    LiftingEngieerName = a.LiftingEngieerName,
                    Type = a.Type,
                    Capacity = a.Capacity,
                    ChasisNo = a.ChasisNo,
                    DateofLastInspection = a.DateofLastInspection,
                    DateofNextInspection = a.DateofNextInspection,
                    MobileCraneName = a.MobileCraneName,
                    ForkType = a.ForkType,
                    ForkCapacity = a.ForkCapacity,
                    ForkChasisNo = a.ForkChasisNo,
                    ForkDateofLastInspection = a.ForkDateofLastInspection,
                    ForkDateofNextInspection = a.ForkDateofNextInspection,
                    ForkName = a.ForkName,
                    user = new IdentityUser { UserName = a.user.UserName, Id = a.user.Id }
                }).ToList();
        }
    }
}
