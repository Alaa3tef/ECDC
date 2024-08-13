using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using TempProject.Models;

namespace TempProject.Repository
{
    public class CraneDailyLiftingRepository : ICraneDailyLiftingRepository
    {
        Context c;
        public CraneDailyLiftingRepository(Context c)
        {
            this.c = c;
        }

        public List<CraneDailyLifting> getall()
        {
            return c.craneDailyLiftings
				.Where(a => a.IsDeleted == false)
                .Select(a => new CraneDailyLifting
                {
                    Id = a.Id,
					Type=a.Type,
					Capacity=a.Capacity,
					ChasisNo= a.ChasisNo,
                    DateofLastInspection=a.DateofLastInspection,
                    DateofNextInspection=a.DateofNextInspection,
                    MobileCraneName=a.MobileCraneName

                }).ToList();
        }
    }
}
