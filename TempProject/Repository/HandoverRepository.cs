using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using TempProject.Models;

namespace TempProject.Repository
{
	public class HandoverRepository : IHandoverRepository
	{
		Context c;
		public HandoverRepository(Context c)
		{
			this.c = c;
		}

		public List<Handover> getall()
		{
			return c.Handovers
				.Include(a => a.Rig)
				.Include(a => a.user)
				.Include(a => a.ShiftDrillTypes)
				.Include(a => a.Visits)
				.Include(a => a.HSEInventory)
				.Include(a => a.HSEEquipment)
				.Include(a => a.MaterialRequested)
				.Where(a => a.IsDeleted == false)
				.Select(a => new Handover
				{
					Id = a.Id,
					RigId = a.RigId,
					Rig = new Rig { Number = a.Rig.Number, Id = a.Rig.Id },
					ShiftDateFrom = a.ShiftDateFrom,
					ShiftDateTo = a.ShiftDateTo,
					WellName = a.WellName,
					Client = a.Client,
					LeavingEmpCode = a.LeavingEmpCode,
					LeavingEmpName = a.LeavingEmpName,
					ComingEmpCode = a.ComingEmpCode,
					ComingEmpName = a.ComingEmpName,
					StopCards = a.StopCards,
					MonthlyStopCards = a.MonthlyStopCards,
					OpenStopCards = a.OpenStopCards,
					Drills = a.Drills,
					MonthlyDrills = a.MonthlyDrills,
					SafetyAlerts = a.SafetyAlerts,
					MonthlySafetyAlerts = a.MonthlySafetyAlerts,
					WeeklyInspection = a.WeeklyInspection,
					InternalAudit = a.InternalAudit,
					ExternalAudit = a.ExternalAudit,
					MedicalReport = a.MedicalReport,
					TrainingMatrix = a.TrainingMatrix,
					RigMove = a.RigMove,
					IncidentReport = a.IncidentReport,
					TrackingSheetClosedPoints = a.TrackingSheetClosedPoints,
					PotentialHazardReport = a.PotentialHazardReport,
					ShiftBrief = a.ShiftBrief,
					QHSEEngineer = a.QHSEEngineer,
					ShiftDrillTypes = a.ShiftDrillTypes,
					Visits = a.Visits,
					HSEInventory = a.HSEInventory,
					HSEEquipment = a.HSEEquipment,
					MaterialRequested = a.MaterialRequested,
					userID = a.userID,
					user = new IdentityUser { UserName = a.user.UserName, Id = a.user.Id },
					IsDeleted = a.IsDeleted
				}).ToList();
		}
	}
}
