using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using TempProject.Models;

namespace TempProject.Repository
{
    public class MedicalReportRepository : IMedicalReportRepossitory
    {
        Context c;
        public MedicalReportRepository(Context c)
        {
            this.c = c;
        }

        public List<MedicalReport> getall()
        {
            return c.MedicalReports
                .Include(a => a.TypeOfIncident)
                .Include(a => a.Rig)
                .Include(a => a.user)
                .Where(a => a.IsDeleted == false)
                .Select(a => new MedicalReport
                {
                    Id = a.Id,
                    Rig = new Rig { Number = a.Rig.Number, Id = a.Rig.Id },
                    Date = a.Date,
                    DateOfBirth = a.DateOfBirth,
                    IsTheIllHealth = a.IsTheIllHealth,
                    Address = a.Address,
                    Age = a.Age,
                    Code = a.Code,
                    TypeOfIncident = new TypeOfIncident { Name = a.TypeOfIncident.Name },
                    Company = a.Company,
                    Job = a.Job,
                    Diagnosis = a.Diagnosis,
                    DoctorComment = a.DoctorComment,
                    DoctorRecommendation = a.DoctorRecommendation,
                    RigDoctor = a.RigDoctor,
                    TelephoneNumber = a.TelephoneNumber,
                    TypeOfIncidentId = a.TypeOfIncidentId,
                    RigManager=a.RigManager,
                    QHSEEngineer=a.QHSEEngineer,
                    Name=a.Name,

                    user = new IdentityUser { UserName = a.user.UserName, Id = a.user.Id }
                }).ToList();
        }
    }
}
