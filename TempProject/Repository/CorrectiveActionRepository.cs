using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using TempProject.Models;

namespace TempProject.Repository
{
	public class CorrectiveActionRepository : ICorrectiveActionRepository
	{
		Context c;
		public CorrectiveActionRepository(Context c)
		{
			this.c = c;
		}

		public List<CorrectiveAction> getall()
		{
			return c.CorrectiveActions
				.Include(a => a.Standard)
				.Include(a => a.Rig)
				.Include(a => a.user)
				.Include(a => a.Images)
				.Include(a => a.CorrectiveDataTable)
				.Include(a => a.CorrectiveAndRootCauses).ThenInclude(a => a.RootCauses)
				.Include(a => a.CorrectiveAndObservation).ThenInclude(a => a.CorrectiveObservation)
				.Where(a => a.IsDeleted == false)
				.Select(a => new CorrectiveAction
				{
					Id = a.Id,
					ReportNo = a.ReportNo,
					RigId = a.RigId,
					Rig = new Rig { Number = a.Rig.Number, Id = a.Rig.Id },
					DescriptionOfNonConformity = a.DescriptionOfNonConformity,
					StandardId = a.StandardId,
					Standard = new Standard { Id = a.Standard.Id, StandardName = a.Standard.StandardName },
					ClauseNo = a.ClauseNo,
					ObjectiveEvidence = a.ObjectiveEvidence,
					CorrectiveAndObservation = a.CorrectiveAndObservation.Select(o => new CorrectiveAndObservation
					{
						CorrectiveObservation = new CorrectiveActionObservation
						{
							Id = o.CorrectiveObservation.Id,
							Observation = o.CorrectiveObservation.Observation
						}
					}).ToList(),
					IfOtherObservation = a.IfOtherObservation,
					UpdateRisk = a.UpdateRisk,
					IfUpdate = a.IfUpdate,
					ManagementOfChange = a.ManagementOfChange,
					IfManagementOfChange = a.IfManagementOfChange,
					NameRasiedBy = a.NameRasiedBy,
					SigRasiedBy = a.SigRasiedBy,
					DateRaisedBy = a.DateRaisedBy,
					CorrectiveAndRootCauses = a.CorrectiveAndRootCauses.Select(o => new CorrectiveAndRootCauses
					{
						RootCauses = new RootCauses
						{
							Id = o.RootCauses.Id,
							CauseName = o.RootCauses.CauseName
						}
					}).ToList(),
					CorrectiveDataTable = a.CorrectiveDataTable.Select(o => new CorrectiveDataTable
					{
						Id = o.Id,
						SN = o.SN,
						Action = o.Action,
						Responsible = o.Responsible,
						SuggestedDate = o.SuggestedDate,
						AchievementDate = o.AchievementDate,
						FollowUpAudit = o.FollowUpAudit,
						Status = o.Status,
						CorrectiveActionId = o.CorrectiveActionId,
						IsDeleted = o.IsDeleted
					}).ToList(),
					IfOtherRootCause = a.IfOtherRootCause,
					//CorrectiveDataTable =a.CorrectiveDataTable.Select(d=>new CorrectiveDataTable
					//{

					//})
					Comment = a.Comment,
					Images = a.Images,
					userID = a.userID,
					user = new IdentityUser { UserName = a.user.UserName, Id = a.user.Id },
					Q_ManagerSig = a.Q_ManagerSig,
					FormStatus = a.FormStatus,
					IsDeleted = a.IsDeleted
				}).ToList();
		}
	}
}
