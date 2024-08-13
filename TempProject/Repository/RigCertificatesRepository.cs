using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using TempProject.Models;

namespace TempProject.Repository
{
	public class RigCertificatesRepository : IRigCertificatesRepository
	{
		Context c;
		public RigCertificatesRepository(Context c)
		{
			this.c = c;
		}

		public List<RigCertificates> getall()
		{
			return c.RigCertificates
				.Include(a => a.Rig)
				.Include(a => a.user)
				//.Include(a => a.HSEEquipmentTable)
				//.Include(a => a.HoistingSystem)
				//.Include(a => a.RotarySystem)
				//.Include(a => a.MudCirculationSystem)
				//.Include(a => a.WellControlSystem)
				//.Include(a => a.PowerSystem)
				//.Include(a => a.OtherSystem)
				//.Include(a => a.PresssureReliefValve)
				//.Include(a => a.PersonnelCerificates)
				//.Include(a => a.MobileCrane1)
				//.Include(a => a.MobileCrane2)
				//.Include(a => a.Forklift1)
				//.Include(a => a.Forklift2)
				//.Include(a => a.AirHoist)
				//.Include(a => a.AirHoist2)
				//.Include(a => a.HydraulicWinch1)
				//.Include(a => a.HydraulicWinch2)
				//.Include(a => a.ManRidingWinch)
				.Where(a => a.IsDeleted == false)
				.Select(a => new RigCertificates
				{
					Id = a.Id,
					RigId = a.RigId,
					Rig = new Rig { Number = a.Rig.Number, Id = a.Rig.Id },
					Date = a.Date,
					CertificationLiftingGear = a.CertificationLiftingGear,
					CertificationCATIII = a.CertificationCATIII,
					CertificationCATIV = a.CertificationCATIV,
					CertificationGaugeCalibraion = a.CertificationGaugeCalibraion,
					CertificationWallThickness = a.CertificationWallThickness,
					DueLiftingGear = a.DueLiftingGear,
					DueCATIII = a.DueCATIII,
					DueCATIV = a.DueCATIV,
					DueGaugeCalibraion = a.DueGaugeCalibraion,
					DueWallThickness = a.DueWallThickness,
					//HSEEquipmentTable = a.HSEEquipmentTable,
					////HoistingSystem = a.HoistingSystem,
					//HoistingSystem = a.HoistingSystem.Select(o => new HoistingSystem
					//{
					//	Id = o.Id,
					//	Equipment = o.Equipment,
					//	SerialNumber = o.SerialNumber,
					//	COCAvailabilty = o.COCAvailabilty,
					//	CATIIICertificationDate = o.CATIIICertificationDate,
					//	CATIIIExpiryDate = o.CATIIIExpiryDate,
					//	CATIVCertificationDate = o.CATIVCertificationDate,
					//	CATIVExpiryDate = o.CATIVExpiryDate,
					//	RigCertificatesId = o.RigCertificatesId
					//}).ToList(),
					////RotarySystem = a.RotarySystem,
					//RotarySystem = a.RotarySystem.Select(o => new RotarySystem
					//{
					//	Id = o.Id,
					//	Equipment = o.Equipment,
					//	SerialNumber = o.SerialNumber,
					//	COCAvailabilty = o.COCAvailabilty,
					//	CATIIICertificationDate = o.CATIIICertificationDate,
					//	CATIIIExpiryDate = o.CATIIIExpiryDate,
					//	CATIVCertificationDate = o.CATIVCertificationDate,
					//	CATIVExpiryDate = o.CATIVExpiryDate,
					//	RigCertificatesId = o.RigCertificatesId
					//}).ToList(),
					////MudCirculationSystem = a.MudCirculationSystem,
					//MudCirculationSystem = a.MudCirculationSystem.Select(o => new MudCirculationSystem
					//{
					//	Id = o.Id,
					//	Equipment = o.Equipment,
					//	SerialNumber = o.SerialNumber,
					//	COCAvailabilty = o.COCAvailabilty,
					//	CATIIICertificationDate = o.CATIIICertificationDate,
					//	CATIIIExpiryDate = o.CATIIIExpiryDate,
					//	CATIVCertificationDate = o.CATIVCertificationDate,
					//	CATIVExpiryDate = o.CATIVExpiryDate,
					//	RigCertificatesId = o.RigCertificatesId
					//}).ToList(),
					////WellControlSystem = a.WellControlSystem,
					//WellControlSystem = a.WellControlSystem.Select(o => new WellControlSystem
					//{
					//	Id = o.Id,
					//	Equipment = o.Equipment,
					//	SerialNumber = o.SerialNumber,
					//	COCAvailabilty = o.COCAvailabilty,
					//	CATIIICertificationDate = o.CATIIICertificationDate,
					//	CATIIIExpiryDate = o.CATIIIExpiryDate,
					//	CATIVCertificationDate = o.CATIVCertificationDate,
					//	CATIVExpiryDate = o.CATIVExpiryDate,
					//	RigCertificatesId = o.RigCertificatesId
					//}).ToList(),
					////PowerSystem = a.PowerSystem,
					//PowerSystem = a.PowerSystem.Select(o => new PowerSystem
					//{
					//	Id = o.Id,
					//	Equipment = o.Equipment,
					//	SerialNumber = o.SerialNumber,
					//	COCAvailabilty = o.COCAvailabilty,
					//	CATIIICertificationDate = o.CATIIICertificationDate,
					//	CATIIIExpiryDate = o.CATIIIExpiryDate,
					//	CATIVCertificationDate = o.CATIVCertificationDate,
					//	CATIVExpiryDate = o.CATIVExpiryDate,
					//	RigCertificatesId = o.RigCertificatesId
					//}).ToList(),
					////OtherSystem = a.OtherSystem,
					//OtherSystem = a.OtherSystem.Select(o => new OtherSystem
					//{
					//	Id = o.Id,
					//	Item = o.Item,
					//	CATIIICertificationDate = o.CATIIICertificationDate,
					//	CATIIIExpiryDate = o.CATIIIExpiryDate,
					//	CATIVCertificationDate = o.CATIVCertificationDate,
					//	CATIVExpiryDate = o.CATIVExpiryDate,
					//	RigCertificatesId = o.RigCertificatesId
					//}).ToList(),
					////PresssureReliefValve = a.PresssureReliefValve,
					//PresssureReliefValve = a.PresssureReliefValve.Select(o => new PresssureReliefValve
					//{
					//	Id = o.Id,
					//	Valves = o.Valves,
					//	Location = o.Location,
					//	CertificationDate = o.CertificationDate,
					//	ExpiryDate = o.ExpiryDate,
					//	RigCertificatesId = o.RigCertificatesId
					//}).ToList(),
					////PersonnelCerificates = a.PersonnelCerificates,
					//PersonnelCerificates = a.PersonnelCerificates.Select(o => new PersonnelCerificates
					//{
					//	Id = o.Id,
					//	Code = o.Code,
					//	Position = o.Position,
					//	Name = o.Name,
					//	CertificateType = o.CertificateType,
					//	CertificateDate = o.CertificateDate,
					//	ExpiryDate = o.ExpiryDate,
					//	RigCertificatesId = o.RigCertificatesId
					//}).ToList(),
					//MobileCrane1 = a.MobileCrane1,
					//MobileCrane2 = a.MobileCrane2,
					//Forklift1 = a.Forklift1,
					//Forklift2 = a.Forklift2,
					//AirHoist = a.AirHoist,
					//AirHoist2 = a.AirHoist2,
					//HydraulicWinch1 = a.HydraulicWinch1,
					//HydraulicWinch2 = a.HydraulicWinch2,
					//ManRidingWinch = a.ManRidingWinch,
					userID = a.userID,
					user = new IdentityUser { UserName = a.user.UserName, Id = a.user.Id },
					IsDeleted = a.IsDeleted
				}).ToList();
		}
	}
}
