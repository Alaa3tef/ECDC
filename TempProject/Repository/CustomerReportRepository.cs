using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using TempProject.Models;

namespace TempProject.Repository
{
    public class CustomerReportRepository : ICustomerReportRepository
    {
        Context c;
        public CustomerReportRepository(Context c)
        {
            this.c = c;
        }

        public List<CustomerReport> getall()
        {
            return c.CustomerReports
                //.Include(a => a.Rating)
                .Include(a => a.Rig)
                .Include(a => a.user)
                .Where(a => a.IsDeleted == false)
                .Select(a => new CustomerReport
				{
                    Id = a.Id,
                    Rig = new Rig { Number = a.Rig.Number, Id=a.Rig.Id },
                    DateFrom = a.DateFrom,
                    DateTo = a.DateTo,

                    Client = a.Client,
                    ClientRepresentative = a.ClientRepresentative,
                    Month = a.Month,
                    Year = a.Year,
                    EvaluationResult =  a.EvaluationResult,
					//Rating = new Rating { Name = a.Rating.Name },
                    Location = a.Location,
                    Comment = a.Comment,
                    CustomerRepresentative = a.CustomerRepresentative,
                    ECDCRepresentative = a.ECDCRepresentative,
					//RatingId = a.RatingId,

					user = new IdentityUser { UserName = a.user.UserName, Id = a.user.Id }
                }).ToList();
        }
    }
}
