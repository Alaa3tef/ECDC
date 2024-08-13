using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using TempProject.Models;

namespace TempProject.Repository
{
    public class WeeklyInspectionRepository : IWeeklyInspectionRepository
	{
        Context c;
        public WeeklyInspectionRepository(Context c)
        {
            this.c = c;
        }

        public List<WeeklyInspection> getall()
        {
            return c.WeeklyInspections
                .Include(a => a.Rig)
                .Include(a => a.user)
                .Where(a => a.IsDeleted == false)
                .Select(a => new WeeklyInspection 
				{
                    Id = a.Id,
                    RigId=a.RigId,
                    Rig = new Rig { Number = a.Rig.Number, Id=a.Rig.Id },
                    Date = a.Date,

                    Client = a.Client,
                    WellName = a.WellName,

                    EarthingMin = a.EarthingMin,
                    EarthingMaximum = a.EarthingMaximum,

                    EarthingWeeklyFindings = a.EarthingWeeklyFindings,
                    EarthingStatus = a.EarthingStatus,

                    CircuitWeeklyFindings =  a.CircuitWeeklyFindings,
                    CircuitStatus = a.CircuitStatus,

                    ElectricalWeeklyFindings = a.ElectricalWeeklyFindings,
                    ElectricalStatus = a.ElectricalStatus,

                    Code = a.Code,
                    PositionName = a.PositionName,
                    Name = a.Name,

                    DroppedInspectionWeeklyFindings = a.DroppedInspectionWeeklyFindings,
                    DroppedInspectionStatus = a.DroppedInspectionStatus,

                    ForkWeeklyFindings = a.ForkWeeklyFindings,
                    ForkStatus=a.ForkStatus,

                    CraneWeeklyFindings = a.CraneWeeklyFindings,
                    CraneStatus = a.CraneStatus,

                    FallWeeklyFindings = a.FallWeeklyFindings,
                    FallStatus = a.FallStatus,

                    SafetyWeeklyFindings = a.SafetyWeeklyFindings,
                    SafetyStatus = a.SafetyStatus,

                    PortableLadderWeeklyFindings = a.PortableLadderWeeklyFindings,
                    PortableLadderStatus = a.PortableLadderStatus,

                    WorkingWeeklyFindings = a.WorkingWeeklyFindings,
                    WorkingStatus = a.WorkingStatus,

                    DerrickmanWeeklyFindings = a.DerrickmanWeeklyFindings,
                    DerrickmanStatus = a.DerrickmanStatus,

                    ExpeiryDate = a.ExpeiryDate,

                    FirePumpStatus = a.FirePumpStatus,
                    FirePumpWeeklyFindings = a.FirePumpWeeklyFindings,

                    WeldingStatus = a.WeldingStatus,
                    WeldingWeeklyFindings=a.WeldingWeeklyFindings,

                    WindStatus = a.WindStatus,
                    WindWeeklyFindings = a.WindWeeklyFindings,

                    SmokeStatus = a.SmokeStatus,
                    SmokeWeeklyFindings = a.SmokeWeeklyFindings,

                    FireExtinguishersWeeklyFindings = a.FireExtinguishersWeeklyFindings,
                    FireExtinguishersStatus = a.FireExtinguishersStatus,

                    PortableGasSingle = a.PortableGasSingle,
                    PortableGasMuti = a.PortableGasMuti,
                    PortableGasWeeklyFindings = a.PortableGasWeeklyFindings,
                    PortableGasStatus = a.PortableGasStatus,

                    Scba10min = a.Scba10min,
                    Scba15min = a.Scba15min,
                    Scba30min = a.Scba30min,
                    ScbaWeeklyFindings = a.ScbaWeeklyFindings,
                    ScbaStatus = a.ScbaStatus,

                    FirstAidWeeklyFindings = a.FirstAidWeeklyFindings,
                    FirstAidStatus = a.FirstAidStatus,

                    EyeWeeklyFindings = a.EyeWeeklyFindings,
                    EyeStatus = a.EyeStatus,

                 

                    user = new IdentityUser { UserName = a.user.UserName, Id = a.user.Id }
                }).ToList();
        }
    }
}
