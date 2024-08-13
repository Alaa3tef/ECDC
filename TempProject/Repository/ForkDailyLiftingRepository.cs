using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using TempProject.Models;

namespace TempProject.Repository
{
    public class ForkDailyLiftingRepository : IForkDailyLiftingRepository
    {
        Context c;
        public ForkDailyLiftingRepository(Context c)
        {
            this.c = c;
        }

        public List<ForkDailyLifting> getall()
        {
            return c.forkDailyLiftings
				.Where(a => a.IsDeleted == false)
                .Select(a => new ForkDailyLifting
                {
                    Id = a.Id,
					Type=a.Type,
					Capacity=a.Capacity,
					ChasisNo= a.ChasisNo,
                    DateofLastInspection=a.DateofLastInspection,
                    DateofNextInspection=a.DateofNextInspection,
                    ForkliftName=a.ForkliftName

                }).ToList();
        }
    }
}
