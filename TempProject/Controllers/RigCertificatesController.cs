using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Helper;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RigCertificatesController : ControllerBase
	{
		public IRepository<RigCertificates> RigCertificatesRepo;

		public IRigCertificatesRepository RigCertificatesRepoistory;

		private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager;

		public IRepository<MobileCrane> MobileCraneRepo;

		public IRepository<RigCertForklift> ForkliftRepo;

		public IRepository<AirHoist> AirHoistRepo;

		public IRepository<HydraulicWinch> HydraulicWinchRepo;

		public IRepository<ManRidingWinch> ManRidingWinchRepo;

		public IRepository<HSEEquipmentTable> HSEEquipmentTableRepo;
		public IRepository<HSEEquipmentList> HSEEquipmentListRepo;
		public IRepository<HoistingSystem> HoistingSystemRepo;
		public IRepository<RotarySystem> RotarySystemRepo;
		public IRepository<MudCirculationSystem> MudCirculationSystemRepo;
		public IRepository<WellControlSystem> WellControlSystemRepo;
		public IRepository<PowerSystem> PowerSystemRepo;
		public IRepository<OtherSystem> OtherSystemRepo;
		public IRepository<PresssureReliefValve> PresssureReliefValveRepo;
		public IRepository<PersonnelCerificates> PersonnelCerificatesRepo;


		public RigCertificatesController(
			IRepository<MobileCrane> _MobileCraneRepo,
			IRepository<RigCertForklift> _ForkliftRepo,
			IRepository<AirHoist> _AirHoistRepo,
			IRepository<HydraulicWinch> _HydraulicWinchRepo,
			IRepository<ManRidingWinch> _ManRidingWinchRepo,
			IRepository<HSEEquipmentTable> _HSEEquipmentTableRepo,
			IRepository<HSEEquipmentList> _HSEEquipmentListRepo,
			IRepository<HoistingSystem> _HoistingSystemRepo,
			IRepository<RotarySystem> _RotarySystemRepo,
			IRepository<MudCirculationSystem> _MudCirculationSystemRepo,
			IRepository<RigCertificates> _RigCertificatesRepo,
			IRepository<PersonnelCerificates> _PersonnelCerificatesRepo,
			IRepository<PresssureReliefValve> _PresssureReliefValveRepo,
			IRepository<OtherSystem> _OtherSystemRepo,
			IRepository<PowerSystem> _PowerSystemRepo,
			IRepository<WellControlSystem> _WellControlSystemRepo,
			Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager,
			IRigCertificatesRepository _RigCertificatesRepoistory)
		{
			this.RigCertificatesRepo = _RigCertificatesRepo;
			this.userManager = _userManager;
			this.MobileCraneRepo = _MobileCraneRepo;
			this.ForkliftRepo = _ForkliftRepo;
			this.AirHoistRepo = _AirHoistRepo;
			this.HydraulicWinchRepo = _HydraulicWinchRepo;
			this.ManRidingWinchRepo = _ManRidingWinchRepo;
			this.HSEEquipmentTableRepo = _HSEEquipmentTableRepo;
			this.HSEEquipmentListRepo = _HSEEquipmentListRepo;
			this.HoistingSystemRepo = _HoistingSystemRepo;
			this.RotarySystemRepo = _RotarySystemRepo;
			this.MudCirculationSystemRepo = _MudCirculationSystemRepo;
			this.RigCertificatesRepo = _RigCertificatesRepo;
			this.PersonnelCerificatesRepo = _PersonnelCerificatesRepo;
			this.PresssureReliefValveRepo = _PresssureReliefValveRepo;
			this.OtherSystemRepo = _OtherSystemRepo;
			this.PowerSystemRepo = _PowerSystemRepo;
			this.WellControlSystemRepo = _WellControlSystemRepo;
			this.RigCertificatesRepoistory = _RigCertificatesRepoistory;
		}

		[HttpGet("GetData")]
		public async Task<ResultDTO> GetAllWithData(string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<RigCertificates> temp = RigCertificatesRepoistory.getall();
					List<RigCertificatesResponseDTO> newTemp = new List<RigCertificatesResponseDTO>();
					foreach (RigCertificates RigCertificates in temp)
					{
						RigCertificatesResponseDTO RigCertificatesDTO = new RigCertificatesResponseDTO();
						RigCertificatesDTO.Id = RigCertificates.Id;
						RigCertificatesDTO.RigNo = RigCertificates.Rig.Number;
						RigCertificatesDTO.Date = RigCertificates.Date;
						RigCertificatesDTO.CertificationLiftingGear = RigCertificates.CertificationLiftingGear;
						RigCertificatesDTO.CertificationCATIII = RigCertificates.CertificationCATIII;
						RigCertificatesDTO.CertificationCATIV = RigCertificates.CertificationCATIV;
						RigCertificatesDTO.CertificationGaugeCalibraion = RigCertificates.CertificationGaugeCalibraion;
						RigCertificatesDTO.CertificationWallThickness = RigCertificates.CertificationWallThickness;
						RigCertificatesDTO.DueLiftingGear = RigCertificates.DueLiftingGear;
						RigCertificatesDTO.DueCATIII = RigCertificates.DueCATIII;
						RigCertificatesDTO.DueCATIV = RigCertificates.DueCATIV;
						RigCertificatesDTO.DueGaugeCalibraion = RigCertificates.DueGaugeCalibraion;
						RigCertificatesDTO.DueWallThickness = RigCertificates.DueWallThickness;
						RigCertificatesDTO.userName = RigCertificates.user.UserName;
						RigCertificatesDTO.IsDeleted = RigCertificates.IsDeleted;

						var RigCertificatesPersonnelCerificates = PersonnelCerificatesRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesPersonnelCerificates.Any())
						{
							foreach (var item in RigCertificatesPersonnelCerificates)
							{
								PersonnelCerificatesDTO personnelCerificates = new PersonnelCerificatesDTO();
								personnelCerificates.Id = item.Id;
								personnelCerificates.Code = item.Code;
								personnelCerificates.Position = item.Position;
								personnelCerificates.Name = item.Name;
								personnelCerificates.CertificateType = item.CertificateType;
								personnelCerificates.CertificateDate = item.CertificateDate;
								personnelCerificates.ExpiryDate = item.ExpiryDate;
								personnelCerificates.RigCertificatesId = RigCertificates.Id;
								personnelCerificates.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.PersonnelCerificates.Add(personnelCerificates);
							}
						}

						var RigCertificatesHSEEquipmentTable = HSEEquipmentTableRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesHSEEquipmentTable.Any())
						{
							var EquipList = HSEEquipmentListRepo.getall();
							foreach (var item in RigCertificatesHSEEquipmentTable)
							{
								HSEEquipmentTableResponseDTO hSEEquipmentTable = new HSEEquipmentTableResponseDTO();
								hSEEquipmentTable.Id = item.Id;
								hSEEquipmentTable.Equipment = EquipList.FirstOrDefault(e=>e.Id==item.EquipmentId).Equipment;
								hSEEquipmentTable.Model = item.Model;
								hSEEquipmentTable.SerialNumber = item.SerialNumber;
								hSEEquipmentTable.ExpiryDate = item.ExpiryDate;
								hSEEquipmentTable.RigCertificatesId = RigCertificates.Id;
								hSEEquipmentTable.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.HSEEquipmentTable.Add(hSEEquipmentTable);
							}
						}
						
						var RigCertificatesPresssureReliefValve = PresssureReliefValveRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesPresssureReliefValve.Any())
						{
							foreach (var item in RigCertificatesPresssureReliefValve)
							{
								PresssureReliefValveDTO presssureReliefValve = new PresssureReliefValveDTO();
								presssureReliefValve.Id = item.Id;
								presssureReliefValve.Valves = item.Valves;
								presssureReliefValve.Location = item.Location;
								presssureReliefValve.CertificationDate = item.CertificationDate;
								presssureReliefValve.ExpiryDate = item.ExpiryDate;
								presssureReliefValve.RigCertificatesId = RigCertificates.Id;
								presssureReliefValve.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.PresssureReliefValve.Add(presssureReliefValve);
							}
						}
						
						var RigCertificatesHoistingSystem = HoistingSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesHoistingSystem)
						{
							HoistingSystemDTO hoistingSystem = new HoistingSystemDTO();
							hoistingSystem.Id = item.Id;
							hoistingSystem.Equipment = item.Equipment;
							hoistingSystem.SerialNumber = item.SerialNumber;
							hoistingSystem.COCAvailabilty = item.COCAvailabilty;
							hoistingSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							hoistingSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							hoistingSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							hoistingSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							hoistingSystem.RigCertificatesId = RigCertificates.Id;
							hoistingSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.HoistingSystem.Add(hoistingSystem);
						}

						var RigCertificatesRotarySystem = RotarySystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesRotarySystem)
						{
							RotarySystemDTO rotarySystem = new RotarySystemDTO();
							rotarySystem.Id = item.Id;
							rotarySystem.Equipment = item.Equipment;
							rotarySystem.SerialNumber = item.SerialNumber;
							rotarySystem.COCAvailabilty = item.COCAvailabilty;
							rotarySystem.CATIIICertificationDate = item.CATIIICertificationDate;
							rotarySystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							rotarySystem.CATIVCertificationDate = item.CATIVCertificationDate;
							rotarySystem.CATIVExpiryDate = item.CATIVExpiryDate;
							rotarySystem.RigCertificatesId = RigCertificates.Id;
							rotarySystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.RotarySystem.Add(rotarySystem);
						}

						var RigCertificatesMudCirculationSystem = MudCirculationSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesMudCirculationSystem)
						{
							MudCirculationSystemDTO mudCirculationSystem = new MudCirculationSystemDTO();
							mudCirculationSystem.Id = item.Id;
							mudCirculationSystem.Equipment = item.Equipment;
							mudCirculationSystem.SerialNumber = item.SerialNumber;
							mudCirculationSystem.COCAvailabilty = item.COCAvailabilty;
							mudCirculationSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							mudCirculationSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							mudCirculationSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							mudCirculationSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							mudCirculationSystem.RigCertificatesId = RigCertificates.Id;
							mudCirculationSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.MudCirculationSystem.Add(mudCirculationSystem);
						}

						var RigCertificatesWellControlSystem = WellControlSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesWellControlSystem)
						{
							WellControlSystemDTO wellControlSystem = new WellControlSystemDTO();
							wellControlSystem.Id = item.Id;
							wellControlSystem.Equipment = item.Equipment;
							wellControlSystem.SerialNumber = item.SerialNumber;
							wellControlSystem.COCAvailabilty = item.COCAvailabilty;
							wellControlSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							wellControlSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							wellControlSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							wellControlSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							wellControlSystem.RigCertificatesId = RigCertificates.Id;
							wellControlSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.WellControlSystem.Add(wellControlSystem);
						}

						var RigCertificatesPowerSystem = PowerSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesPowerSystem)
						{
							PowerSystemDTO powerSystem = new PowerSystemDTO();
							powerSystem.Id = item.Id;
							powerSystem.Equipment = item.Equipment;
							powerSystem.SerialNumber = item.SerialNumber;
							powerSystem.COCAvailabilty = item.COCAvailabilty;
							powerSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							powerSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							powerSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							powerSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							powerSystem.RigCertificatesId = RigCertificates.Id;
							powerSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.PowerSystem.Add(powerSystem);
						}

						var RigCertificatesOtherSystem = OtherSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesOtherSystem)
						{
							OtherSystemDTO otherSystem = new OtherSystemDTO();
							otherSystem.Id = item.Id;
							otherSystem.Item = item.Item;
							otherSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							otherSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							otherSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							otherSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							otherSystem.RigCertificatesId = RigCertificates.Id;
							otherSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.OtherSystem.Add(otherSystem);
						}

						var RigCertificatesMobileCrane = MobileCraneRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesMobileCrane.Any())
						{
							foreach (var item in RigCertificatesMobileCrane)
							{
								MobileCraneDTO mobileCrane = new MobileCraneDTO();
								mobileCrane.Id = item.Id;
								mobileCrane.Model = item.Model;
								mobileCrane.Type = item.Type;
								mobileCrane.ChassisNo = item.ChassisNo;
								mobileCrane.HookSerialNo = item.HookSerialNo;
								mobileCrane.Capacity = item.Capacity;
								mobileCrane.ManufactureDate = item.ManufactureDate;
								mobileCrane.LastExaminationDate = item.LastExaminationDate;
								mobileCrane.NextExaminationDate = item.NextExaminationDate;
								mobileCrane.RigCertificatesId = item.RigCertificatesId;
								mobileCrane.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.MobileCrane.Add(mobileCrane);
							}
						}

						
						var RigCertificatesForklift = ForkliftRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesForklift.Any())
						{
							foreach (var item in RigCertificatesForklift)
							{
								RigCertForkliftDTO forklift = new RigCertForkliftDTO();
								forklift.Id = item.Id;
								forklift.Model = item.Model;
								forklift.Type = item.Type;
								forklift.SerialNo = item.SerialNo;
								forklift.Capacity = item.Capacity;
								forklift.LastExaminationDate = item.LastExaminationDate;
								forklift.NextExaminationDate = item.NextExaminationDate;
								forklift.RigCertificatesId = item.RigCertificatesId;
								forklift.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.Forklift.Add(forklift);
							}
						}


						var RigCertificatesAirHoist = AirHoistRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesAirHoist.Any())
						{
							foreach (var item in RigCertificatesAirHoist)
							{
								AirHoistDTO airHoist = new AirHoistDTO();
								airHoist.Id = item.Id;
								airHoist.SerialNo = item.SerialNo;
								airHoist.WireSize = item.WireSize;
								airHoist.Capacity = item.Capacity;
								airHoist.WireInspectionDueDate = item.WireInspectionDueDate;
								airHoist.LastMPIInspectionDate = item.LastMPIInspectionDate;
								airHoist.NextMPIInspectionDate = item.NextMPIInspectionDate;
								airHoist.NextLoadTestDate = item.NextLoadTestDate;
								airHoist.RigCertificatesId = item.RigCertificatesId;
								airHoist.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.AirHoist.Add(airHoist);
							}
						}


						var RigCertificatesHydraulicWinch = HydraulicWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesHydraulicWinch.Any())
						{
							foreach (var item in RigCertificatesHydraulicWinch)
							{
								HydraulicWinchDTO hydraulicWinch = new HydraulicWinchDTO();
								hydraulicWinch.Id = item.Id;
								hydraulicWinch.SerialNo = item.SerialNo;
								hydraulicWinch.WireSize = item.WireSize;
								hydraulicWinch.Capacity = item.Capacity;
								hydraulicWinch.WireInspectionDueDate = item.WireInspectionDueDate;
								hydraulicWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
								hydraulicWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
								hydraulicWinch.NextLoadTestDate = item.NextLoadTestDate;
								hydraulicWinch.RigCertificatesId = item.RigCertificatesId;
								hydraulicWinch.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.HydraulicWinch.Add(hydraulicWinch);
							}
						}

						var RigCertificatesManRidingWinch = ManRidingWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesManRidingWinch.Any())
						{
							foreach (var item in RigCertificatesManRidingWinch)
							{
								ManRidingWinchDTO manRidingWinch = new ManRidingWinchDTO();
								manRidingWinch.Id = item.Id;
								manRidingWinch.SerialNo = item.SerialNo;
								manRidingWinch.WireSize = item.WireSize;
								manRidingWinch.Capacity = item.Capacity;
								manRidingWinch.WireInspectionDueDate = item.WireInspectionDueDate;
								manRidingWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
								manRidingWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
								manRidingWinch.NextLoadTestDate = item.NextLoadTestDate;
								manRidingWinch.RigCertificatesId = item.RigCertificatesId;
								manRidingWinch.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.ManRidingWinch.Add(manRidingWinch);
							}
						}


						newTemp.Add(RigCertificatesDTO);
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
					List<RigCertificates> temp = RigCertificatesRepoistory.getall().Where(a => a.user.Id == UserID).ToList();
					List<RigCertificatesResponseDTO> newTemp = new List<RigCertificatesResponseDTO>();
					foreach (RigCertificates RigCertificates in temp)
					{
						RigCertificatesResponseDTO RigCertificatesDTO = new RigCertificatesResponseDTO();
						RigCertificatesDTO.Id = RigCertificates.Id;
						RigCertificatesDTO.RigNo = RigCertificates.Rig.Number;
						RigCertificatesDTO.Date = RigCertificates.Date;
						RigCertificatesDTO.CertificationLiftingGear = RigCertificates.CertificationLiftingGear;
						RigCertificatesDTO.CertificationCATIII = RigCertificates.CertificationCATIII;
						RigCertificatesDTO.CertificationCATIV = RigCertificates.CertificationCATIV;
						RigCertificatesDTO.CertificationGaugeCalibraion = RigCertificates.CertificationGaugeCalibraion;
						RigCertificatesDTO.CertificationWallThickness = RigCertificates.CertificationWallThickness;
						RigCertificatesDTO.DueLiftingGear = RigCertificates.DueLiftingGear;
						RigCertificatesDTO.DueCATIII = RigCertificates.DueCATIII;
						RigCertificatesDTO.DueCATIV = RigCertificates.DueCATIV;
						RigCertificatesDTO.DueGaugeCalibraion = RigCertificates.DueGaugeCalibraion;
						RigCertificatesDTO.DueWallThickness = RigCertificates.DueWallThickness;
						RigCertificatesDTO.userName = RigCertificates.user.UserName;
						RigCertificatesDTO.IsDeleted = RigCertificates.IsDeleted;

						var RigCertificatesPersonnelCerificates = PersonnelCerificatesRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesPersonnelCerificates.Any())
						{
							foreach (var item in RigCertificatesPersonnelCerificates)
							{
								PersonnelCerificatesDTO personnelCerificates = new PersonnelCerificatesDTO();
								personnelCerificates.Id = item.Id;
								personnelCerificates.Code = item.Code;
								personnelCerificates.Position = item.Position;
								personnelCerificates.Name = item.Name;
								personnelCerificates.CertificateType = item.CertificateType;
								personnelCerificates.CertificateDate = item.CertificateDate;
								personnelCerificates.ExpiryDate = item.ExpiryDate;
								personnelCerificates.RigCertificatesId = RigCertificates.Id;
								personnelCerificates.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.PersonnelCerificates.Add(personnelCerificates);
							}
						}

						var RigCertificatesHSEEquipmentTable = HSEEquipmentTableRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesHSEEquipmentTable.Any())
						{
							var EquipList = HSEEquipmentListRepo.getall();
							foreach (var item in RigCertificatesHSEEquipmentTable)
							{
								HSEEquipmentTableResponseDTO hSEEquipmentTable = new HSEEquipmentTableResponseDTO();
								hSEEquipmentTable.Id = item.Id;
								hSEEquipmentTable.Equipment = EquipList.FirstOrDefault(e => e.Id == item.EquipmentId).Equipment;
								hSEEquipmentTable.Model = item.Model;
								hSEEquipmentTable.SerialNumber = item.SerialNumber;
								hSEEquipmentTable.ExpiryDate = item.ExpiryDate;
								hSEEquipmentTable.RigCertificatesId = RigCertificates.Id;
								hSEEquipmentTable.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.HSEEquipmentTable.Add(hSEEquipmentTable);
							}
						}

						var RigCertificatesPresssureReliefValve = PresssureReliefValveRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesPresssureReliefValve.Any())
						{
							foreach (var item in RigCertificatesPresssureReliefValve)
							{
								PresssureReliefValveDTO presssureReliefValve = new PresssureReliefValveDTO();
								presssureReliefValve.Id = item.Id;
								presssureReliefValve.Valves = item.Valves;
								presssureReliefValve.Location = item.Location;
								presssureReliefValve.CertificationDate = item.CertificationDate;
								presssureReliefValve.ExpiryDate = item.ExpiryDate;
								presssureReliefValve.RigCertificatesId = RigCertificates.Id;
								presssureReliefValve.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.PresssureReliefValve.Add(presssureReliefValve);
							}
						}

						var RigCertificatesHoistingSystem = HoistingSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesHoistingSystem)
						{
							HoistingSystemDTO hoistingSystem = new HoistingSystemDTO();
							hoistingSystem.Id = item.Id;
							hoistingSystem.Equipment = item.Equipment;
							hoistingSystem.SerialNumber = item.SerialNumber;
							hoistingSystem.COCAvailabilty = item.COCAvailabilty;
							hoistingSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							hoistingSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							hoistingSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							hoistingSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							hoistingSystem.RigCertificatesId = RigCertificates.Id;
							hoistingSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.HoistingSystem.Add(hoistingSystem);
						}

						var RigCertificatesRotarySystem = RotarySystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesRotarySystem)
						{
							RotarySystemDTO rotarySystem = new RotarySystemDTO();
							rotarySystem.Id = item.Id;
							rotarySystem.Equipment = item.Equipment;
							rotarySystem.SerialNumber = item.SerialNumber;
							rotarySystem.COCAvailabilty = item.COCAvailabilty;
							rotarySystem.CATIIICertificationDate = item.CATIIICertificationDate;
							rotarySystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							rotarySystem.CATIVCertificationDate = item.CATIVCertificationDate;
							rotarySystem.CATIVExpiryDate = item.CATIVExpiryDate;
							rotarySystem.RigCertificatesId = RigCertificates.Id;
							rotarySystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.RotarySystem.Add(rotarySystem);
						}

						var RigCertificatesMudCirculationSystem = MudCirculationSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesMudCirculationSystem)
						{
							MudCirculationSystemDTO mudCirculationSystem = new MudCirculationSystemDTO();
							mudCirculationSystem.Id = item.Id;
							mudCirculationSystem.Equipment = item.Equipment;
							mudCirculationSystem.SerialNumber = item.SerialNumber;
							mudCirculationSystem.COCAvailabilty = item.COCAvailabilty;
							mudCirculationSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							mudCirculationSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							mudCirculationSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							mudCirculationSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							mudCirculationSystem.RigCertificatesId = RigCertificates.Id;
							mudCirculationSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.MudCirculationSystem.Add(mudCirculationSystem);
						}

						var RigCertificatesWellControlSystem = WellControlSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesWellControlSystem)
						{
							WellControlSystemDTO wellControlSystem = new WellControlSystemDTO();
							wellControlSystem.Id = item.Id;
							wellControlSystem.Equipment = item.Equipment;
							wellControlSystem.SerialNumber = item.SerialNumber;
							wellControlSystem.COCAvailabilty = item.COCAvailabilty;
							wellControlSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							wellControlSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							wellControlSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							wellControlSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							wellControlSystem.RigCertificatesId = RigCertificates.Id;
							wellControlSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.WellControlSystem.Add(wellControlSystem);
						}

						var RigCertificatesPowerSystem = PowerSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesPowerSystem)
						{
							PowerSystemDTO powerSystem = new PowerSystemDTO();
							powerSystem.Id = item.Id;
							powerSystem.Equipment = item.Equipment;
							powerSystem.SerialNumber = item.SerialNumber;
							powerSystem.COCAvailabilty = item.COCAvailabilty;
							powerSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							powerSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							powerSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							powerSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							powerSystem.RigCertificatesId = RigCertificates.Id;
							powerSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.PowerSystem.Add(powerSystem);
						}

						var RigCertificatesOtherSystem = OtherSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesOtherSystem)
						{
							OtherSystemDTO otherSystem = new OtherSystemDTO();
							otherSystem.Id = item.Id;
							otherSystem.Item = item.Item;
							otherSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							otherSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							otherSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							otherSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							otherSystem.RigCertificatesId = RigCertificates.Id;
							otherSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.OtherSystem.Add(otherSystem);
						}

						var RigCertificatesMobileCrane = MobileCraneRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesMobileCrane.Any())
						{
							foreach (var item in RigCertificatesMobileCrane)
							{
								MobileCraneDTO mobileCrane = new MobileCraneDTO();
								mobileCrane.Id = item.Id;
								mobileCrane.Model = item.Model;
								mobileCrane.Type = item.Type;
								mobileCrane.ChassisNo = item.ChassisNo;
								mobileCrane.HookSerialNo = item.HookSerialNo;
								mobileCrane.Capacity = item.Capacity;
								mobileCrane.ManufactureDate = item.ManufactureDate;
								mobileCrane.LastExaminationDate = item.LastExaminationDate;
								mobileCrane.NextExaminationDate = item.NextExaminationDate;
								mobileCrane.RigCertificatesId = item.RigCertificatesId;
								mobileCrane.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.MobileCrane.Add(mobileCrane);
							}
						}


						var RigCertificatesForklift = ForkliftRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesForklift.Any())
						{
							foreach (var item in RigCertificatesForklift)
							{
								RigCertForkliftDTO forklift = new RigCertForkliftDTO();
								forklift.Id = item.Id;
								forklift.Model = item.Model;
								forklift.Type = item.Type;
								forklift.SerialNo = item.SerialNo;
								forklift.Capacity = item.Capacity;
								forklift.LastExaminationDate = item.LastExaminationDate;
								forklift.NextExaminationDate = item.NextExaminationDate;
								forklift.RigCertificatesId = item.RigCertificatesId;
								forklift.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.Forklift.Add(forklift);
							}
						}


						var RigCertificatesAirHoist = AirHoistRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesAirHoist.Any())
						{
							foreach (var item in RigCertificatesAirHoist)
							{
								AirHoistDTO airHoist = new AirHoistDTO();
								airHoist.Id = item.Id;
								airHoist.SerialNo = item.SerialNo;
								airHoist.WireSize = item.WireSize;
								airHoist.Capacity = item.Capacity;
								airHoist.WireInspectionDueDate = item.WireInspectionDueDate;
								airHoist.LastMPIInspectionDate = item.LastMPIInspectionDate;
								airHoist.NextMPIInspectionDate = item.NextMPIInspectionDate;
								airHoist.NextLoadTestDate = item.NextLoadTestDate;
								airHoist.RigCertificatesId = item.RigCertificatesId;
								airHoist.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.AirHoist.Add(airHoist);
							}
						}


						var RigCertificatesHydraulicWinch = HydraulicWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesHydraulicWinch.Any())
						{
							foreach (var item in RigCertificatesHydraulicWinch)
							{
								HydraulicWinchDTO hydraulicWinch = new HydraulicWinchDTO();
								hydraulicWinch.Id = item.Id;
								hydraulicWinch.SerialNo = item.SerialNo;
								hydraulicWinch.WireSize = item.WireSize;
								hydraulicWinch.Capacity = item.Capacity;
								hydraulicWinch.WireInspectionDueDate = item.WireInspectionDueDate;
								hydraulicWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
								hydraulicWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
								hydraulicWinch.NextLoadTestDate = item.NextLoadTestDate;
								hydraulicWinch.RigCertificatesId = item.RigCertificatesId;
								hydraulicWinch.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.HydraulicWinch.Add(hydraulicWinch);
							}
						}

						var RigCertificatesManRidingWinch = ManRidingWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesManRidingWinch.Any())
						{
							foreach (var item in RigCertificatesManRidingWinch)
							{
								ManRidingWinchDTO manRidingWinch = new ManRidingWinchDTO();
								manRidingWinch.Id = item.Id;
								manRidingWinch.SerialNo = item.SerialNo;
								manRidingWinch.WireSize = item.WireSize;
								manRidingWinch.Capacity = item.Capacity;
								manRidingWinch.WireInspectionDueDate = item.WireInspectionDueDate;
								manRidingWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
								manRidingWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
								manRidingWinch.NextLoadTestDate = item.NextLoadTestDate;
								manRidingWinch.RigCertificatesId = item.RigCertificatesId;
								manRidingWinch.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.ManRidingWinch.Add(manRidingWinch);
							}
						}


						newTemp.Add(RigCertificatesDTO);                        
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


		[HttpGet("GetDataForPrint")]
		public async Task<ResultDTO> GetAllWithDataForPrint(int RigNo, DateTime date, string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<RigCertificates> temp = RigCertificatesRepoistory.getall().Where(r => r.Rig.Number == RigNo && r.Date == date).ToList();
					List<RigCertificatesResponseDTO> newTemp = new List<RigCertificatesResponseDTO>();
					foreach (RigCertificates RigCertificates in temp)
					{
						RigCertificatesResponseDTO RigCertificatesDTO = new RigCertificatesResponseDTO();
						RigCertificatesDTO.Id = RigCertificates.Id;
						RigCertificatesDTO.RigNo = RigCertificates.Rig.Number;
						RigCertificatesDTO.Date = RigCertificates.Date;
						RigCertificatesDTO.CertificationLiftingGear = RigCertificates.CertificationLiftingGear;
						RigCertificatesDTO.CertificationCATIII = RigCertificates.CertificationCATIII;
						RigCertificatesDTO.CertificationCATIV = RigCertificates.CertificationCATIV;
						RigCertificatesDTO.CertificationGaugeCalibraion = RigCertificates.CertificationGaugeCalibraion;
						RigCertificatesDTO.CertificationWallThickness = RigCertificates.CertificationWallThickness;
						RigCertificatesDTO.DueLiftingGear = RigCertificates.DueLiftingGear;
						RigCertificatesDTO.DueCATIII = RigCertificates.DueCATIII;
						RigCertificatesDTO.DueCATIV = RigCertificates.DueCATIV;
						RigCertificatesDTO.DueGaugeCalibraion = RigCertificates.DueGaugeCalibraion;
						RigCertificatesDTO.DueWallThickness = RigCertificates.DueWallThickness;
						RigCertificatesDTO.userName = RigCertificates.user.UserName;
						RigCertificatesDTO.IsDeleted = RigCertificates.IsDeleted;

						var RigCertificatesPersonnelCerificates = PersonnelCerificatesRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesPersonnelCerificates.Any())
						{
							foreach (var item in RigCertificatesPersonnelCerificates)
							{
								PersonnelCerificatesDTO personnelCerificates = new PersonnelCerificatesDTO();
								personnelCerificates.Id = item.Id;
								personnelCerificates.Code = item.Code;
								personnelCerificates.Position = item.Position;
								personnelCerificates.Name = item.Name;
								personnelCerificates.CertificateType = item.CertificateType;
								personnelCerificates.CertificateDate = item.CertificateDate;
								personnelCerificates.ExpiryDate = item.ExpiryDate;
								personnelCerificates.RigCertificatesId = RigCertificates.Id;
								personnelCerificates.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.PersonnelCerificates.Add(personnelCerificates);
							}
						}

						var RigCertificatesHSEEquipmentTable = HSEEquipmentTableRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesHSEEquipmentTable.Any())
						{
							var EquipList = HSEEquipmentListRepo.getall();
							foreach (var item in RigCertificatesHSEEquipmentTable)
							{
								HSEEquipmentTableResponseDTO hSEEquipmentTable = new HSEEquipmentTableResponseDTO();
								hSEEquipmentTable.Id = item.Id;
								hSEEquipmentTable.Equipment = EquipList.FirstOrDefault(e => e.Id == item.EquipmentId).Equipment;
								hSEEquipmentTable.Model = item.Model;
								hSEEquipmentTable.SerialNumber = item.SerialNumber;
								hSEEquipmentTable.ExpiryDate = item.ExpiryDate;
								hSEEquipmentTable.RigCertificatesId = RigCertificates.Id;
								hSEEquipmentTable.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.HSEEquipmentTable.Add(hSEEquipmentTable);
							}
						}

						var RigCertificatesPresssureReliefValve = PresssureReliefValveRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesPresssureReliefValve.Any())
						{
							foreach (var item in RigCertificatesPresssureReliefValve)
							{
								PresssureReliefValveDTO presssureReliefValve = new PresssureReliefValveDTO();
								presssureReliefValve.Id = item.Id;
								presssureReliefValve.Valves = item.Valves;
								presssureReliefValve.Location = item.Location;
								presssureReliefValve.CertificationDate = item.CertificationDate;
								presssureReliefValve.ExpiryDate = item.ExpiryDate;
								presssureReliefValve.RigCertificatesId = RigCertificates.Id;
								presssureReliefValve.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.PresssureReliefValve.Add(presssureReliefValve);
							}
						}

						var RigCertificatesHoistingSystem = HoistingSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesHoistingSystem)
						{
							HoistingSystemDTO hoistingSystem = new HoistingSystemDTO();
							hoistingSystem.Id = item.Id;
							hoistingSystem.Equipment = item.Equipment;
							hoistingSystem.SerialNumber = item.SerialNumber;
							hoistingSystem.COCAvailabilty = item.COCAvailabilty;
							hoistingSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							hoistingSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							hoistingSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							hoistingSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							hoistingSystem.RigCertificatesId = RigCertificates.Id;
							hoistingSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.HoistingSystem.Add(hoistingSystem);
						}

						var RigCertificatesRotarySystem = RotarySystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesRotarySystem)
						{
							RotarySystemDTO rotarySystem = new RotarySystemDTO();
							rotarySystem.Id = item.Id;
							rotarySystem.Equipment = item.Equipment;
							rotarySystem.SerialNumber = item.SerialNumber;
							rotarySystem.COCAvailabilty = item.COCAvailabilty;
							rotarySystem.CATIIICertificationDate = item.CATIIICertificationDate;
							rotarySystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							rotarySystem.CATIVCertificationDate = item.CATIVCertificationDate;
							rotarySystem.CATIVExpiryDate = item.CATIVExpiryDate;
							rotarySystem.RigCertificatesId = RigCertificates.Id;
							rotarySystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.RotarySystem.Add(rotarySystem);
						}

						var RigCertificatesMudCirculationSystem = MudCirculationSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesMudCirculationSystem)
						{
							MudCirculationSystemDTO mudCirculationSystem = new MudCirculationSystemDTO();
							mudCirculationSystem.Id = item.Id;
							mudCirculationSystem.Equipment = item.Equipment;
							mudCirculationSystem.SerialNumber = item.SerialNumber;
							mudCirculationSystem.COCAvailabilty = item.COCAvailabilty;
							mudCirculationSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							mudCirculationSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							mudCirculationSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							mudCirculationSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							mudCirculationSystem.RigCertificatesId = RigCertificates.Id;
							mudCirculationSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.MudCirculationSystem.Add(mudCirculationSystem);
						}

						var RigCertificatesWellControlSystem = WellControlSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesWellControlSystem)
						{
							WellControlSystemDTO wellControlSystem = new WellControlSystemDTO();
							wellControlSystem.Id = item.Id;
							wellControlSystem.Equipment = item.Equipment;
							wellControlSystem.SerialNumber = item.SerialNumber;
							wellControlSystem.COCAvailabilty = item.COCAvailabilty;
							wellControlSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							wellControlSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							wellControlSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							wellControlSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							wellControlSystem.RigCertificatesId = RigCertificates.Id;
							wellControlSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.WellControlSystem.Add(wellControlSystem);
						}

						var RigCertificatesPowerSystem = PowerSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesPowerSystem)
						{
							PowerSystemDTO powerSystem = new PowerSystemDTO();
							powerSystem.Id = item.Id;
							powerSystem.Equipment = item.Equipment;
							powerSystem.SerialNumber = item.SerialNumber;
							powerSystem.COCAvailabilty = item.COCAvailabilty;
							powerSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							powerSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							powerSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							powerSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							powerSystem.RigCertificatesId = RigCertificates.Id;
							powerSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.PowerSystem.Add(powerSystem);
						}

						var RigCertificatesOtherSystem = OtherSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesOtherSystem)
						{
							OtherSystemDTO otherSystem = new OtherSystemDTO();
							otherSystem.Id = item.Id;
							otherSystem.Item = item.Item;
							otherSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							otherSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							otherSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							otherSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							otherSystem.RigCertificatesId = RigCertificates.Id;
							otherSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.OtherSystem.Add(otherSystem);
						}

						var RigCertificatesMobileCrane = MobileCraneRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesMobileCrane.Any())
						{
							foreach (var item in RigCertificatesMobileCrane)
							{
								MobileCraneDTO mobileCrane = new MobileCraneDTO();
								mobileCrane.Id = item.Id;
								mobileCrane.Model = item.Model;
								mobileCrane.Type = item.Type;
								mobileCrane.ChassisNo = item.ChassisNo;
								mobileCrane.HookSerialNo = item.HookSerialNo;
								mobileCrane.Capacity = item.Capacity;
								mobileCrane.ManufactureDate = item.ManufactureDate;
								mobileCrane.LastExaminationDate = item.LastExaminationDate;
								mobileCrane.NextExaminationDate = item.NextExaminationDate;
								mobileCrane.RigCertificatesId = item.RigCertificatesId;
								mobileCrane.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.MobileCrane.Add(mobileCrane);
							}
						}


						var RigCertificatesForklift = ForkliftRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesForklift.Any())
						{
							foreach (var item in RigCertificatesForklift)
							{
								RigCertForkliftDTO forklift = new RigCertForkliftDTO();
								forklift.Id = item.Id;
								forklift.Model = item.Model;
								forklift.Type = item.Type;
								forklift.SerialNo = item.SerialNo;
								forklift.Capacity = item.Capacity;
								forklift.LastExaminationDate = item.LastExaminationDate;
								forklift.NextExaminationDate = item.NextExaminationDate;
								forklift.RigCertificatesId = item.RigCertificatesId;
								forklift.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.Forklift.Add(forklift);
							}
						}


						var RigCertificatesAirHoist = AirHoistRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesAirHoist.Any())
						{
							foreach (var item in RigCertificatesAirHoist)
							{
								AirHoistDTO airHoist = new AirHoistDTO();
								airHoist.Id = item.Id;
								airHoist.SerialNo = item.SerialNo;
								airHoist.WireSize = item.WireSize;
								airHoist.Capacity = item.Capacity;
								airHoist.WireInspectionDueDate = item.WireInspectionDueDate;
								airHoist.LastMPIInspectionDate = item.LastMPIInspectionDate;
								airHoist.NextMPIInspectionDate = item.NextMPIInspectionDate;
								airHoist.NextLoadTestDate = item.NextLoadTestDate;
								airHoist.RigCertificatesId = item.RigCertificatesId;
								airHoist.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.AirHoist.Add(airHoist);
							}
						}


						var RigCertificatesHydraulicWinch = HydraulicWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesHydraulicWinch.Any())
						{
							foreach (var item in RigCertificatesHydraulicWinch)
							{
								HydraulicWinchDTO hydraulicWinch = new HydraulicWinchDTO();
								hydraulicWinch.Id = item.Id;
								hydraulicWinch.SerialNo = item.SerialNo;
								hydraulicWinch.WireSize = item.WireSize;
								hydraulicWinch.Capacity = item.Capacity;
								hydraulicWinch.WireInspectionDueDate = item.WireInspectionDueDate;
								hydraulicWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
								hydraulicWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
								hydraulicWinch.NextLoadTestDate = item.NextLoadTestDate;
								hydraulicWinch.RigCertificatesId = item.RigCertificatesId;
								hydraulicWinch.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.HydraulicWinch.Add(hydraulicWinch);
							}
						}

						var RigCertificatesManRidingWinch = ManRidingWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesManRidingWinch.Any())
						{
							foreach (var item in RigCertificatesManRidingWinch)
							{
								ManRidingWinchDTO manRidingWinch = new ManRidingWinchDTO();
								manRidingWinch.Id = item.Id;
								manRidingWinch.SerialNo = item.SerialNo;
								manRidingWinch.WireSize = item.WireSize;
								manRidingWinch.Capacity = item.Capacity;
								manRidingWinch.WireInspectionDueDate = item.WireInspectionDueDate;
								manRidingWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
								manRidingWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
								manRidingWinch.NextLoadTestDate = item.NextLoadTestDate;
								manRidingWinch.RigCertificatesId = item.RigCertificatesId;
								manRidingWinch.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.ManRidingWinch.Add(manRidingWinch);
							}
						}


						newTemp.Add(RigCertificatesDTO);
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
					List<RigCertificates> temp = RigCertificatesRepoistory.getall().Where(a => a.user.Id == UserID && a.Date == date && a.Rig.Number == RigNo).ToList();
					List<RigCertificatesResponseDTO> newTemp = new List<RigCertificatesResponseDTO>();
					foreach (RigCertificates RigCertificates in temp)
					{
						RigCertificatesResponseDTO RigCertificatesDTO = new RigCertificatesResponseDTO();
						RigCertificatesDTO.Id = RigCertificates.Id;
						RigCertificatesDTO.RigNo = RigCertificates.Rig.Number;
						RigCertificatesDTO.Date = RigCertificates.Date;
						RigCertificatesDTO.CertificationLiftingGear = RigCertificates.CertificationLiftingGear;
						RigCertificatesDTO.CertificationCATIII = RigCertificates.CertificationCATIII;
						RigCertificatesDTO.CertificationCATIV = RigCertificates.CertificationCATIV;
						RigCertificatesDTO.CertificationGaugeCalibraion = RigCertificates.CertificationGaugeCalibraion;
						RigCertificatesDTO.CertificationWallThickness = RigCertificates.CertificationWallThickness;
						RigCertificatesDTO.DueLiftingGear = RigCertificates.DueLiftingGear;
						RigCertificatesDTO.DueCATIII = RigCertificates.DueCATIII;
						RigCertificatesDTO.DueCATIV = RigCertificates.DueCATIV;
						RigCertificatesDTO.DueGaugeCalibraion = RigCertificates.DueGaugeCalibraion;
						RigCertificatesDTO.DueWallThickness = RigCertificates.DueWallThickness;
						RigCertificatesDTO.userName = RigCertificates.user.UserName;
						RigCertificatesDTO.IsDeleted = RigCertificates.IsDeleted;

						var RigCertificatesPersonnelCerificates = PersonnelCerificatesRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesPersonnelCerificates.Any())
						{
							foreach (var item in RigCertificatesPersonnelCerificates)
							{
								PersonnelCerificatesDTO personnelCerificates = new PersonnelCerificatesDTO();
								personnelCerificates.Id = item.Id;
								personnelCerificates.Code = item.Code;
								personnelCerificates.Position = item.Position;
								personnelCerificates.Name = item.Name;
								personnelCerificates.CertificateType = item.CertificateType;
								personnelCerificates.CertificateDate = item.CertificateDate;
								personnelCerificates.ExpiryDate = item.ExpiryDate;
								personnelCerificates.RigCertificatesId = RigCertificates.Id;
								personnelCerificates.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.PersonnelCerificates.Add(personnelCerificates);
							}
						}

						var RigCertificatesHSEEquipmentTable = HSEEquipmentTableRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesHSEEquipmentTable.Any())
						{
							var EquipList = HSEEquipmentListRepo.getall();

							foreach (var item in RigCertificatesHSEEquipmentTable)
							{
								HSEEquipmentTableResponseDTO hSEEquipmentTable = new HSEEquipmentTableResponseDTO();
								hSEEquipmentTable.Id = item.Id;
								hSEEquipmentTable.Equipment = EquipList.FirstOrDefault(e => e.Id == item.EquipmentId).Equipment;
								hSEEquipmentTable.Model = item.Model;
								hSEEquipmentTable.SerialNumber = item.SerialNumber;
								hSEEquipmentTable.ExpiryDate = item.ExpiryDate;
								hSEEquipmentTable.RigCertificatesId = RigCertificates.Id;
								hSEEquipmentTable.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.HSEEquipmentTable.Add(hSEEquipmentTable);
							}
						}

						var RigCertificatesPresssureReliefValve = PresssureReliefValveRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesPresssureReliefValve.Any())
						{
							foreach (var item in RigCertificatesPresssureReliefValve)
							{
								PresssureReliefValveDTO presssureReliefValve = new PresssureReliefValveDTO();
								presssureReliefValve.Id = item.Id;
								presssureReliefValve.Valves = item.Valves;
								presssureReliefValve.Location = item.Location;
								presssureReliefValve.CertificationDate = item.CertificationDate;
								presssureReliefValve.ExpiryDate = item.ExpiryDate;
								presssureReliefValve.RigCertificatesId = RigCertificates.Id;
								presssureReliefValve.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.PresssureReliefValve.Add(presssureReliefValve);
							}
						}

						var RigCertificatesHoistingSystem = HoistingSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesHoistingSystem)
						{
							HoistingSystemDTO hoistingSystem = new HoistingSystemDTO();
							hoistingSystem.Id = item.Id;
							hoistingSystem.Equipment = item.Equipment;
							hoistingSystem.SerialNumber = item.SerialNumber;
							hoistingSystem.COCAvailabilty = item.COCAvailabilty;
							hoistingSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							hoistingSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							hoistingSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							hoistingSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							hoistingSystem.RigCertificatesId = RigCertificates.Id;
							hoistingSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.HoistingSystem.Add(hoistingSystem);
						}

						var RigCertificatesRotarySystem = RotarySystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesRotarySystem)
						{
							RotarySystemDTO rotarySystem = new RotarySystemDTO();
							rotarySystem.Id = item.Id;
							rotarySystem.Equipment = item.Equipment;
							rotarySystem.SerialNumber = item.SerialNumber;
							rotarySystem.COCAvailabilty = item.COCAvailabilty;
							rotarySystem.CATIIICertificationDate = item.CATIIICertificationDate;
							rotarySystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							rotarySystem.CATIVCertificationDate = item.CATIVCertificationDate;
							rotarySystem.CATIVExpiryDate = item.CATIVExpiryDate;
							rotarySystem.RigCertificatesId = RigCertificates.Id;
							rotarySystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.RotarySystem.Add(rotarySystem);
						}

						var RigCertificatesMudCirculationSystem = MudCirculationSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesMudCirculationSystem)
						{
							MudCirculationSystemDTO mudCirculationSystem = new MudCirculationSystemDTO();
							mudCirculationSystem.Id = item.Id;
							mudCirculationSystem.Equipment = item.Equipment;
							mudCirculationSystem.SerialNumber = item.SerialNumber;
							mudCirculationSystem.COCAvailabilty = item.COCAvailabilty;
							mudCirculationSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							mudCirculationSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							mudCirculationSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							mudCirculationSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							mudCirculationSystem.RigCertificatesId = RigCertificates.Id;
							mudCirculationSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.MudCirculationSystem.Add(mudCirculationSystem);
						}

						var RigCertificatesWellControlSystem = WellControlSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesWellControlSystem)
						{
							WellControlSystemDTO wellControlSystem = new WellControlSystemDTO();
							wellControlSystem.Id = item.Id;
							wellControlSystem.Equipment = item.Equipment;
							wellControlSystem.SerialNumber = item.SerialNumber;
							wellControlSystem.COCAvailabilty = item.COCAvailabilty;
							wellControlSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							wellControlSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							wellControlSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							wellControlSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							wellControlSystem.RigCertificatesId = RigCertificates.Id;
							wellControlSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.WellControlSystem.Add(wellControlSystem);
						}

						var RigCertificatesPowerSystem = PowerSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesPowerSystem)
						{
							PowerSystemDTO powerSystem = new PowerSystemDTO();
							powerSystem.Id = item.Id;
							powerSystem.Equipment = item.Equipment;
							powerSystem.SerialNumber = item.SerialNumber;
							powerSystem.COCAvailabilty = item.COCAvailabilty;
							powerSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							powerSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							powerSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							powerSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							powerSystem.RigCertificatesId = RigCertificates.Id;
							powerSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.PowerSystem.Add(powerSystem);
						}

						var RigCertificatesOtherSystem = OtherSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesOtherSystem)
						{
							OtherSystemDTO otherSystem = new OtherSystemDTO();
							otherSystem.Id = item.Id;
							otherSystem.Item = item.Item;
							otherSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							otherSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							otherSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							otherSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							otherSystem.RigCertificatesId = RigCertificates.Id;
							otherSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.OtherSystem.Add(otherSystem);
						}

						var RigCertificatesMobileCrane = MobileCraneRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesMobileCrane.Any())
						{
							foreach (var item in RigCertificatesMobileCrane)
							{
								MobileCraneDTO mobileCrane = new MobileCraneDTO();
								mobileCrane.Id = item.Id;
								mobileCrane.Model = item.Model;
								mobileCrane.Type = item.Type;
								mobileCrane.ChassisNo = item.ChassisNo;
								mobileCrane.HookSerialNo = item.HookSerialNo;
								mobileCrane.Capacity = item.Capacity;
								mobileCrane.ManufactureDate = item.ManufactureDate;
								mobileCrane.LastExaminationDate = item.LastExaminationDate;
								mobileCrane.NextExaminationDate = item.NextExaminationDate;
								mobileCrane.RigCertificatesId = item.RigCertificatesId;
								mobileCrane.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.MobileCrane.Add(mobileCrane);
							}
						}


						var RigCertificatesForklift = ForkliftRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesForklift.Any())
						{
							foreach (var item in RigCertificatesForklift)
							{
								RigCertForkliftDTO forklift = new RigCertForkliftDTO();
								forklift.Id = item.Id;
								forklift.Model = item.Model;
								forklift.Type = item.Type;
								forklift.SerialNo = item.SerialNo;
								forklift.Capacity = item.Capacity;
								forklift.LastExaminationDate = item.LastExaminationDate;
								forklift.NextExaminationDate = item.NextExaminationDate;
								forklift.RigCertificatesId = item.RigCertificatesId;
								forklift.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.Forklift.Add(forklift);
							}
						}


						var RigCertificatesAirHoist = AirHoistRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesAirHoist.Any())
						{
							foreach (var item in RigCertificatesAirHoist)
							{
								AirHoistDTO airHoist = new AirHoistDTO();
								airHoist.Id = item.Id;
								airHoist.SerialNo = item.SerialNo;
								airHoist.WireSize = item.WireSize;
								airHoist.Capacity = item.Capacity;
								airHoist.WireInspectionDueDate = item.WireInspectionDueDate;
								airHoist.LastMPIInspectionDate = item.LastMPIInspectionDate;
								airHoist.NextMPIInspectionDate = item.NextMPIInspectionDate;
								airHoist.NextLoadTestDate = item.NextLoadTestDate;
								airHoist.RigCertificatesId = item.RigCertificatesId;
								airHoist.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.AirHoist.Add(airHoist);
							}
						}


						var RigCertificatesHydraulicWinch = HydraulicWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesHydraulicWinch.Any())
						{
							foreach (var item in RigCertificatesHydraulicWinch)
							{
								HydraulicWinchDTO hydraulicWinch = new HydraulicWinchDTO();
								hydraulicWinch.Id = item.Id;
								hydraulicWinch.SerialNo = item.SerialNo;
								hydraulicWinch.WireSize = item.WireSize;
								hydraulicWinch.Capacity = item.Capacity;
								hydraulicWinch.WireInspectionDueDate = item.WireInspectionDueDate;
								hydraulicWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
								hydraulicWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
								hydraulicWinch.NextLoadTestDate = item.NextLoadTestDate;
								hydraulicWinch.RigCertificatesId = item.RigCertificatesId;
								hydraulicWinch.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.HydraulicWinch.Add(hydraulicWinch);
							}
						}

						var RigCertificatesManRidingWinch = ManRidingWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesManRidingWinch.Any())
						{
							foreach (var item in RigCertificatesManRidingWinch)
							{
								ManRidingWinchDTO manRidingWinch = new ManRidingWinchDTO();
								manRidingWinch.Id = item.Id;
								manRidingWinch.SerialNo = item.SerialNo;
								manRidingWinch.WireSize = item.WireSize;
								manRidingWinch.Capacity = item.Capacity;
								manRidingWinch.WireInspectionDueDate = item.WireInspectionDueDate;
								manRidingWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
								manRidingWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
								manRidingWinch.NextLoadTestDate = item.NextLoadTestDate;
								manRidingWinch.RigCertificatesId = item.RigCertificatesId;
								manRidingWinch.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.ManRidingWinch.Add(manRidingWinch);
							}
						}

						newTemp.Add(RigCertificatesDTO);
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


		[HttpGet("GetDataForExcel")]
		public ActionResult<ResultDTO> GetDataForExcel(string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<RigCertificates> temp = RigCertificatesRepoistory.getall().Where(r=>r.userID==UserID).ToList();
					List<RigCertificatesExcelDTO> newTemp = new List<RigCertificatesExcelDTO>();
					foreach (RigCertificates RigCertificates in temp)
					{
						RigCertificatesExcelDTO RigCertificatesDTO = new RigCertificatesExcelDTO();
						RigCertificatesDTO.Rig_Number = RigCertificates.Rig.Number;
						RigCertificatesDTO.Date = RigCertificates.Date;
						RigCertificatesDTO.Certification_Lifting_Gear = RigCertificates.CertificationLiftingGear;
						RigCertificatesDTO.Certification_CATIII = RigCertificates.CertificationCATIII;
						RigCertificatesDTO.Certification_CATIV = RigCertificates.CertificationCATIV;
						RigCertificatesDTO.Certification_Gauge_Calibraion = RigCertificates.CertificationGaugeCalibraion;
						RigCertificatesDTO.Certification_Wall_Thickness = RigCertificates.CertificationWallThickness;
						RigCertificatesDTO.Due_Lifting_Gear = RigCertificates.DueLiftingGear;
						RigCertificatesDTO.Due_CATIII = RigCertificates.DueCATIII;
						RigCertificatesDTO.Due_CATIV = RigCertificates.DueCATIV;
						RigCertificatesDTO.Due_Gauge_Calibraion = RigCertificates.DueGaugeCalibraion;
						RigCertificatesDTO.Due_Wall_Thickness = RigCertificates.DueWallThickness;
						RigCertificatesDTO.User_Name = RigCertificates.user.UserName;

						var RigCertificatesPersonnelCerificates = PersonnelCerificatesRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesPersonnelCerificates.Any())
						{
							foreach (var item in RigCertificatesPersonnelCerificates)
							{
								PersonnelCerificatesExcelDTO personnelCerificates = new PersonnelCerificatesExcelDTO();
								personnelCerificates.Code = item.Code;
								personnelCerificates.Position = item.Position;
								personnelCerificates.Name = item.Name;
								personnelCerificates.CertificateType = item.CertificateType;
								personnelCerificates.CertificateDate = item.CertificateDate;
								personnelCerificates.ExpiryDate = item.ExpiryDate;
								RigCertificatesDTO.Personnel_Cerificates.Add(personnelCerificates);
							}
						}

						var RigCertificatesHSEEquipmentTable = HSEEquipmentTableRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesHSEEquipmentTable.Any())
						{
							var EquipList = HSEEquipmentListRepo.getall();
							foreach (var item in RigCertificatesHSEEquipmentTable)
							{
								HSEEquipmentTableExcelDTO hSEEquipmentTable = new HSEEquipmentTableExcelDTO();
								hSEEquipmentTable.Equipment = EquipList.FirstOrDefault(e => e.Id == item.EquipmentId).Equipment;
								hSEEquipmentTable.Model = item.Model;
								hSEEquipmentTable.SerialNumber = item.SerialNumber;
								hSEEquipmentTable.ExpiryDate = item.ExpiryDate;
								RigCertificatesDTO.HSE_Equipment.Add(hSEEquipmentTable);
							}
						}

						var RigCertificatesPresssureReliefValve = PresssureReliefValveRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesPresssureReliefValve.Any())
						{
							foreach (var item in RigCertificatesPresssureReliefValve)
							{
								PresssureReliefValveExcelDTO presssureReliefValve = new PresssureReliefValveExcelDTO();
								presssureReliefValve.Valves = item.Valves;
								presssureReliefValve.Location = item.Location;
								presssureReliefValve.CertificationDate = item.CertificationDate;
								presssureReliefValve.ExpiryDate = item.ExpiryDate;
								RigCertificatesDTO.Presssure_Relief_Valve.Add(presssureReliefValve);
							}
						}

						var RigCertificatesHoistingSystem = HoistingSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesHoistingSystem)
						{
							HoistingSystemExcelDTO hoistingSystem = new HoistingSystemExcelDTO();
							hoistingSystem.Equipment = item.Equipment;
							hoistingSystem.SerialNumber = item.SerialNumber;
							hoistingSystem.COCAvailabilty = item.COCAvailabilty == true ? "available" : "Not available";
							hoistingSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							hoistingSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							hoistingSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							hoistingSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							RigCertificatesDTO.Hoisting_System.Add(hoistingSystem);
						}

						var RigCertificatesRotarySystem = RotarySystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesRotarySystem)
						{
							RotarySystemExcelDTO rotarySystem = new RotarySystemExcelDTO();
							rotarySystem.Equipment = item.Equipment;
							rotarySystem.SerialNumber = item.SerialNumber;
							rotarySystem.COCAvailabilty = item.COCAvailabilty == true ? "available" : "Not available";
							rotarySystem.CATIIICertificationDate = item.CATIIICertificationDate;
							rotarySystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							rotarySystem.CATIVCertificationDate = item.CATIVCertificationDate;
							rotarySystem.CATIVExpiryDate = item.CATIVExpiryDate;
							RigCertificatesDTO.Rotary_System.Add(rotarySystem);
						}

						var RigCertificatesMudCirculationSystem = MudCirculationSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesMudCirculationSystem)
						{
							MudCirculationSystemExcelDTO mudCirculationSystem = new MudCirculationSystemExcelDTO();
							mudCirculationSystem.Equipment = item.Equipment;
							mudCirculationSystem.SerialNumber = item.SerialNumber;
							mudCirculationSystem.COCAvailabilty = item.COCAvailabilty == true ? "available" : "Not available";
							mudCirculationSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							mudCirculationSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							mudCirculationSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							mudCirculationSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							RigCertificatesDTO.Mud_Circulation_System.Add(mudCirculationSystem);
						}

						var RigCertificatesWellControlSystem = WellControlSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesWellControlSystem)
						{
							WellControlSystemExcelDTO wellControlSystem = new WellControlSystemExcelDTO();
							wellControlSystem.Equipment = item.Equipment;
							wellControlSystem.SerialNumber = item.SerialNumber;
							wellControlSystem.COCAvailabilty = item.COCAvailabilty == true ? "available" : "Not available";
							wellControlSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							wellControlSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							wellControlSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							wellControlSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							RigCertificatesDTO.Well_Control_System.Add(wellControlSystem);
						}

						var RigCertificatesPowerSystem = PowerSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesPowerSystem)
						{
							PowerSystemExcelDTO powerSystem = new PowerSystemExcelDTO();
							powerSystem.Equipment = item.Equipment;
							powerSystem.SerialNumber = item.SerialNumber;
							powerSystem.COCAvailabilty = item.COCAvailabilty == true ? "available" : "Not available";
							powerSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							powerSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							powerSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							powerSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							RigCertificatesDTO.Power_System.Add(powerSystem);
						}

						var RigCertificatesOtherSystem = OtherSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesOtherSystem)
						{
							OtherSystemExcelDTO otherSystem = new OtherSystemExcelDTO();
							otherSystem.Item = item.Item;
							otherSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							otherSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							otherSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							otherSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							RigCertificatesDTO.Other_System.Add(otherSystem);
						}

						var RigCertificatesMobileCrane = MobileCraneRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesMobileCrane.Any())
						{
							foreach (var item in RigCertificatesMobileCrane)
							{
								MobileCraneExcelDTO mobileCrane = new MobileCraneExcelDTO();
								mobileCrane.Model = item.Model;
								mobileCrane.Type = item.Type;
								mobileCrane.ChassisNo = item.ChassisNo;
								mobileCrane.HookSerialNo = item.HookSerialNo;
								mobileCrane.Capacity = item.Capacity;
								mobileCrane.ManufactureDate = item.ManufactureDate;
								mobileCrane.LastExaminationDate = item.LastExaminationDate;
								mobileCrane.NextExaminationDate = item.NextExaminationDate;
								RigCertificatesDTO.Mobile_Crane.Add(mobileCrane);
							}
						}


						var RigCertificatesForklift = ForkliftRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesForklift.Any())
						{
							foreach (var item in RigCertificatesForklift)
							{
								RigCertForkliftExcelDTO forklift = new RigCertForkliftExcelDTO();
								forklift.Model = item.Model;
								forklift.Type = item.Type;
								forklift.SerialNo = item.SerialNo;
								forklift.Capacity = item.Capacity;
								forklift.LastExaminationDate = item.LastExaminationDate;
								forklift.NextExaminationDate = item.NextExaminationDate;
								RigCertificatesDTO.Forklift.Add(forklift);
							}
						}


						var RigCertificatesAirHoist = AirHoistRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesAirHoist.Any())
						{
							foreach (var item in RigCertificatesAirHoist)
							{
								AirHoistExcelDTO airHoist = new AirHoistExcelDTO();
								airHoist.SerialNo = item.SerialNo;
								airHoist.WireSize = item.WireSize;
								airHoist.Capacity = item.Capacity;
								airHoist.WireInspectionDueDate = item.WireInspectionDueDate;
								airHoist.LastMPIInspectionDate = item.LastMPIInspectionDate;
								airHoist.NextMPIInspectionDate = item.NextMPIInspectionDate;
								airHoist.NextLoadTestDate = item.NextLoadTestDate;
								RigCertificatesDTO.Air_Hoist.Add(airHoist);
							}
						}


						var RigCertificatesHydraulicWinch = HydraulicWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesHydraulicWinch.Any())
						{
							foreach (var item in RigCertificatesHydraulicWinch)
							{
								HydraulicWinchExcelDTO hydraulicWinch = new HydraulicWinchExcelDTO();
								hydraulicWinch.SerialNo = item.SerialNo;
								hydraulicWinch.WireSize = item.WireSize;
								hydraulicWinch.Capacity = item.Capacity;
								hydraulicWinch.WireInspectionDueDate = item.WireInspectionDueDate;
								hydraulicWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
								hydraulicWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
								hydraulicWinch.NextLoadTestDate = item.NextLoadTestDate;
								RigCertificatesDTO.Hydraulic_Winch.Add(hydraulicWinch);
							}
						}

						var RigCertificatesManRidingWinch = ManRidingWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesManRidingWinch.Any())
						{
							foreach (var item in RigCertificatesManRidingWinch)
							{
								ManRidingWinchExcelDTO manRidingWinch = new ManRidingWinchExcelDTO();
								manRidingWinch.SerialNo = item.SerialNo;
								manRidingWinch.WireSize = item.WireSize;
								manRidingWinch.Capacity = item.Capacity;
								manRidingWinch.WireInspectionDueDate = item.WireInspectionDueDate;
								manRidingWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
								manRidingWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
								manRidingWinch.NextLoadTestDate = item.NextLoadTestDate;
								RigCertificatesDTO.Man_Riding_Winch.Add(manRidingWinch);
							}
						}
						newTemp.Add(RigCertificatesDTO);
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
					List<RigCertificates> temp = RigCertificatesRepoistory.getall().Where(a => a.user.Id == UserID).ToList();
					List<RigCertificatesExcelDTO> newTemp = new List<RigCertificatesExcelDTO>();
					foreach (RigCertificates RigCertificates in temp)
					{
						RigCertificatesExcelDTO RigCertificatesDTO = new RigCertificatesExcelDTO();
						RigCertificatesDTO.Rig_Number = RigCertificates.Rig.Number;
						RigCertificatesDTO.Date = RigCertificates.Date;
						RigCertificatesDTO.Certification_Lifting_Gear = RigCertificates.CertificationLiftingGear;
						RigCertificatesDTO.Certification_CATIII = RigCertificates.CertificationCATIII;
						RigCertificatesDTO.Certification_CATIV = RigCertificates.CertificationCATIV;
						RigCertificatesDTO.Certification_Gauge_Calibraion = RigCertificates.CertificationGaugeCalibraion;
						RigCertificatesDTO.Certification_Wall_Thickness = RigCertificates.CertificationWallThickness;
						RigCertificatesDTO.Due_Lifting_Gear = RigCertificates.DueLiftingGear;
						RigCertificatesDTO.Due_CATIII = RigCertificates.DueCATIII;
						RigCertificatesDTO.Due_CATIV = RigCertificates.DueCATIV;
						RigCertificatesDTO.Due_Gauge_Calibraion = RigCertificates.DueGaugeCalibraion;
						RigCertificatesDTO.Due_Wall_Thickness = RigCertificates.DueWallThickness;
						RigCertificatesDTO.User_Name = RigCertificates.user.UserName;

						var RigCertificatesPersonnelCerificates = PersonnelCerificatesRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesPersonnelCerificates.Any())
						{
							foreach (var item in RigCertificatesPersonnelCerificates)
							{
								PersonnelCerificatesExcelDTO personnelCerificates = new PersonnelCerificatesExcelDTO();
								personnelCerificates.Code = item.Code;
								personnelCerificates.Position = item.Position;
								personnelCerificates.Name = item.Name;
								personnelCerificates.CertificateType = item.CertificateType;
								personnelCerificates.CertificateDate = item.CertificateDate;
								personnelCerificates.ExpiryDate = item.ExpiryDate;
								RigCertificatesDTO.Personnel_Cerificates.Add(personnelCerificates);
							}
						}

						var RigCertificatesHSEEquipmentTable = HSEEquipmentTableRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesHSEEquipmentTable.Any())
						{
							var EquipList = HSEEquipmentListRepo.getall();
							foreach (var item in RigCertificatesHSEEquipmentTable)
							{
								HSEEquipmentTableExcelDTO hSEEquipmentTable = new HSEEquipmentTableExcelDTO();
								hSEEquipmentTable.Equipment = EquipList.FirstOrDefault(e => e.Id == item.EquipmentId).Equipment;
								hSEEquipmentTable.Model = item.Model;
								hSEEquipmentTable.SerialNumber = item.SerialNumber;
								hSEEquipmentTable.ExpiryDate = item.ExpiryDate;
								RigCertificatesDTO.HSE_Equipment.Add(hSEEquipmentTable);
							}
						}

						var RigCertificatesPresssureReliefValve = PresssureReliefValveRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesPresssureReliefValve.Any())
						{
							foreach (var item in RigCertificatesPresssureReliefValve)
							{
								PresssureReliefValveExcelDTO presssureReliefValve = new PresssureReliefValveExcelDTO();
								presssureReliefValve.Valves = item.Valves;
								presssureReliefValve.Location = item.Location;
								presssureReliefValve.CertificationDate = item.CertificationDate;
								presssureReliefValve.ExpiryDate = item.ExpiryDate;
								RigCertificatesDTO.Presssure_Relief_Valve.Add(presssureReliefValve);
							}
						}

						var RigCertificatesHoistingSystem = HoistingSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesHoistingSystem)
						{
							HoistingSystemExcelDTO hoistingSystem = new HoistingSystemExcelDTO();
							hoistingSystem.Equipment = item.Equipment;
							hoistingSystem.SerialNumber = item.SerialNumber;
							hoistingSystem.COCAvailabilty = item.COCAvailabilty == true ? "available" : "Not available";
							hoistingSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							hoistingSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							hoistingSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							hoistingSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							RigCertificatesDTO.Hoisting_System.Add(hoistingSystem);
						}

						var RigCertificatesRotarySystem = RotarySystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesRotarySystem)
						{
							RotarySystemExcelDTO rotarySystem = new RotarySystemExcelDTO();
							rotarySystem.Equipment = item.Equipment;
							rotarySystem.SerialNumber = item.SerialNumber;
							rotarySystem.COCAvailabilty = item.COCAvailabilty == true ? "available" : "Not available";
							rotarySystem.CATIIICertificationDate = item.CATIIICertificationDate;
							rotarySystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							rotarySystem.CATIVCertificationDate = item.CATIVCertificationDate;
							rotarySystem.CATIVExpiryDate = item.CATIVExpiryDate;
							RigCertificatesDTO.Rotary_System.Add(rotarySystem);
						}

						var RigCertificatesMudCirculationSystem = MudCirculationSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesMudCirculationSystem)
						{
							MudCirculationSystemExcelDTO mudCirculationSystem = new MudCirculationSystemExcelDTO();
							mudCirculationSystem.Equipment = item.Equipment;
							mudCirculationSystem.SerialNumber = item.SerialNumber;
							mudCirculationSystem.COCAvailabilty = item.COCAvailabilty == true ? "available" : "Not available";
							mudCirculationSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							mudCirculationSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							mudCirculationSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							mudCirculationSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							RigCertificatesDTO.Mud_Circulation_System.Add(mudCirculationSystem);
						}

						var RigCertificatesWellControlSystem = WellControlSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesWellControlSystem)
						{
							WellControlSystemExcelDTO wellControlSystem = new WellControlSystemExcelDTO();
							wellControlSystem.Equipment = item.Equipment;
							wellControlSystem.SerialNumber = item.SerialNumber;
							wellControlSystem.COCAvailabilty = item.COCAvailabilty == true ? "available" : "Not available";
							wellControlSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							wellControlSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							wellControlSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							wellControlSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							RigCertificatesDTO.Well_Control_System.Add(wellControlSystem);
						}

						var RigCertificatesPowerSystem = PowerSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesPowerSystem)
						{
							PowerSystemExcelDTO powerSystem = new PowerSystemExcelDTO();
							powerSystem.Equipment = item.Equipment;
							powerSystem.SerialNumber = item.SerialNumber;
							powerSystem.COCAvailabilty = item.COCAvailabilty == true ? "available" : "Not available";
							powerSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							powerSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							powerSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							powerSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							RigCertificatesDTO.Power_System.Add(powerSystem);
						}

						var RigCertificatesOtherSystem = OtherSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesOtherSystem)
						{
							OtherSystemExcelDTO otherSystem = new OtherSystemExcelDTO();
							otherSystem.Item = item.Item;
							otherSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							otherSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							otherSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							otherSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							RigCertificatesDTO.Other_System.Add(otherSystem);
						}

						var RigCertificatesMobileCrane = MobileCraneRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesMobileCrane.Any())
						{
							foreach (var item in RigCertificatesMobileCrane)
							{
								MobileCraneExcelDTO mobileCrane = new MobileCraneExcelDTO();
								mobileCrane.Model = item.Model;
								mobileCrane.Type = item.Type;
								mobileCrane.ChassisNo = item.ChassisNo;
								mobileCrane.HookSerialNo = item.HookSerialNo;
								mobileCrane.Capacity = item.Capacity;
								mobileCrane.ManufactureDate = item.ManufactureDate;
								mobileCrane.LastExaminationDate = item.LastExaminationDate;
								mobileCrane.NextExaminationDate = item.NextExaminationDate;
								RigCertificatesDTO.Mobile_Crane.Add(mobileCrane);
							}
						}

						
						var RigCertificatesForklift = ForkliftRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesForklift.Any())
						{
							foreach (var item in RigCertificatesForklift)
							{
								RigCertForkliftExcelDTO forklift = new RigCertForkliftExcelDTO();
								forklift.Model = item.Model;
								forklift.Type = item.Type;
								forklift.SerialNo = item.SerialNo;
								forklift.Capacity = item.Capacity;
								forklift.LastExaminationDate = item.LastExaminationDate;
								forklift.NextExaminationDate = item.NextExaminationDate;
								RigCertificatesDTO.Forklift.Add(forklift);
							}
						}


						var RigCertificatesAirHoist = AirHoistRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesAirHoist.Any())
						{
							foreach (var item in RigCertificatesAirHoist)
							{
								AirHoistExcelDTO airHoist = new AirHoistExcelDTO();
								airHoist.SerialNo = item.SerialNo;
								airHoist.WireSize = item.WireSize;
								airHoist.Capacity = item.Capacity;
								airHoist.WireInspectionDueDate = item.WireInspectionDueDate;
								airHoist.LastMPIInspectionDate = item.LastMPIInspectionDate;
								airHoist.NextMPIInspectionDate = item.NextMPIInspectionDate;
								airHoist.NextLoadTestDate = item.NextLoadTestDate;
								RigCertificatesDTO.Air_Hoist.Add(airHoist);
							}
						}


						var RigCertificatesHydraulicWinch = HydraulicWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesHydraulicWinch.Any())
						{
							foreach (var item in RigCertificatesHydraulicWinch)
							{
								HydraulicWinchExcelDTO hydraulicWinch = new HydraulicWinchExcelDTO();
								hydraulicWinch.SerialNo = item.SerialNo;
								hydraulicWinch.WireSize = item.WireSize;
								hydraulicWinch.Capacity = item.Capacity;
								hydraulicWinch.WireInspectionDueDate = item.WireInspectionDueDate;
								hydraulicWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
								hydraulicWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
								hydraulicWinch.NextLoadTestDate = item.NextLoadTestDate;
								RigCertificatesDTO.Hydraulic_Winch.Add(hydraulicWinch);
							}
						}

						var RigCertificatesManRidingWinch = ManRidingWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesManRidingWinch.Any())
						{
							foreach (var item in RigCertificatesManRidingWinch)
							{
								ManRidingWinchExcelDTO manRidingWinch = new ManRidingWinchExcelDTO();
								manRidingWinch.SerialNo = item.SerialNo;
								manRidingWinch.WireSize = item.WireSize;
								manRidingWinch.Capacity = item.Capacity;
								manRidingWinch.WireInspectionDueDate = item.WireInspectionDueDate;
								manRidingWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
								manRidingWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
								manRidingWinch.NextLoadTestDate = item.NextLoadTestDate;
								RigCertificatesDTO.Man_Riding_Winch.Add(manRidingWinch);
							}
						}
						newTemp.Add(RigCertificatesDTO);
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
		public PageResult<RigCertificatesResponseDTO> GettAllRigCertificatesByPage(string UserId, string UserRole, int? page, int pagesize = 10)
		{
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<RigCertificates> temp = RigCertificatesRepoistory.getall();
					List<RigCertificatesResponseDTO> newTemp = new List<RigCertificatesResponseDTO>();
					foreach (RigCertificates RigCertificates in temp)
					{
						RigCertificatesResponseDTO RigCertificatesDTO = new RigCertificatesResponseDTO();
						RigCertificatesDTO.Id = RigCertificates.Id;
						RigCertificatesDTO.RigNo = RigCertificates.Rig.Number;
						RigCertificatesDTO.Date = RigCertificates.Date;
						RigCertificatesDTO.CertificationLiftingGear = RigCertificates.CertificationLiftingGear;
						RigCertificatesDTO.CertificationCATIII = RigCertificates.CertificationCATIII;
						RigCertificatesDTO.CertificationCATIV = RigCertificates.CertificationCATIV;
						RigCertificatesDTO.CertificationGaugeCalibraion = RigCertificates.CertificationGaugeCalibraion;
						RigCertificatesDTO.CertificationWallThickness = RigCertificates.CertificationWallThickness;
						RigCertificatesDTO.DueLiftingGear = RigCertificates.DueLiftingGear;
						RigCertificatesDTO.DueCATIII = RigCertificates.DueCATIII;
						RigCertificatesDTO.DueCATIV = RigCertificates.DueCATIV;
						RigCertificatesDTO.DueGaugeCalibraion = RigCertificates.DueGaugeCalibraion;
						RigCertificatesDTO.DueWallThickness = RigCertificates.DueWallThickness;
						RigCertificatesDTO.userName = RigCertificates.user.UserName;
						RigCertificatesDTO.IsDeleted = RigCertificates.IsDeleted;

						var RigCertificatesPersonnelCerificates = PersonnelCerificatesRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesPersonnelCerificates.Any())
						{
							foreach (var item in RigCertificatesPersonnelCerificates)
							{
								PersonnelCerificatesDTO personnelCerificates = new PersonnelCerificatesDTO();
								personnelCerificates.Id = item.Id;
								personnelCerificates.Code = item.Code;
								personnelCerificates.Position = item.Position;
								personnelCerificates.Name = item.Name;
								personnelCerificates.CertificateType = item.CertificateType;
								personnelCerificates.CertificateDate = item.CertificateDate;
								personnelCerificates.ExpiryDate = item.ExpiryDate;
								personnelCerificates.RigCertificatesId = RigCertificates.Id;
								personnelCerificates.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.PersonnelCerificates.Add(personnelCerificates);
							}
						}

						var RigCertificatesHSEEquipmentTable = HSEEquipmentTableRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesHSEEquipmentTable.Any())
						{
							var EquipList = HSEEquipmentListRepo.getall();
							foreach (var item in RigCertificatesHSEEquipmentTable)
							{
								HSEEquipmentTableResponseDTO hSEEquipmentTable = new HSEEquipmentTableResponseDTO();
								hSEEquipmentTable.Id = item.Id;
								hSEEquipmentTable.Equipment = EquipList.FirstOrDefault(e => e.Id == item.EquipmentId).Equipment;
								hSEEquipmentTable.Model = item.Model;
								hSEEquipmentTable.SerialNumber = item.SerialNumber;
								hSEEquipmentTable.ExpiryDate = item.ExpiryDate;
								hSEEquipmentTable.RigCertificatesId = RigCertificates.Id;
								hSEEquipmentTable.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.HSEEquipmentTable.Add(hSEEquipmentTable);
							}
						}

						var RigCertificatesPresssureReliefValve = PresssureReliefValveRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesPresssureReliefValve.Any())
						{
							foreach (var item in RigCertificatesPresssureReliefValve)
							{
								PresssureReliefValveDTO presssureReliefValve = new PresssureReliefValveDTO();
								presssureReliefValve.Id = item.Id;
								presssureReliefValve.Valves = item.Valves;
								presssureReliefValve.Location = item.Location;
								presssureReliefValve.CertificationDate = item.CertificationDate;
								presssureReliefValve.ExpiryDate = item.ExpiryDate;
								presssureReliefValve.RigCertificatesId = RigCertificates.Id;
								presssureReliefValve.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.PresssureReliefValve.Add(presssureReliefValve);
							}
						}

						var RigCertificatesHoistingSystem = HoistingSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesHoistingSystem)
						{
							HoistingSystemDTO hoistingSystem = new HoistingSystemDTO();
							hoistingSystem.Id = item.Id;
							hoistingSystem.Equipment = item.Equipment;
							hoistingSystem.SerialNumber = item.SerialNumber;
							hoistingSystem.COCAvailabilty = item.COCAvailabilty;
							hoistingSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							hoistingSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							hoistingSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							hoistingSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							hoistingSystem.RigCertificatesId = RigCertificates.Id;
							hoistingSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.HoistingSystem.Add(hoistingSystem);
						}

						var RigCertificatesRotarySystem = RotarySystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesRotarySystem)
						{
							RotarySystemDTO rotarySystem = new RotarySystemDTO();
							rotarySystem.Id = item.Id;
							rotarySystem.Equipment = item.Equipment;
							rotarySystem.SerialNumber = item.SerialNumber;
							rotarySystem.COCAvailabilty = item.COCAvailabilty;
							rotarySystem.CATIIICertificationDate = item.CATIIICertificationDate;
							rotarySystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							rotarySystem.CATIVCertificationDate = item.CATIVCertificationDate;
							rotarySystem.CATIVExpiryDate = item.CATIVExpiryDate;
							rotarySystem.RigCertificatesId = RigCertificates.Id;
							rotarySystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.RotarySystem.Add(rotarySystem);
						}

						var RigCertificatesMudCirculationSystem = MudCirculationSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesMudCirculationSystem)
						{
							MudCirculationSystemDTO mudCirculationSystem = new MudCirculationSystemDTO();
							mudCirculationSystem.Id = item.Id;
							mudCirculationSystem.Equipment = item.Equipment;
							mudCirculationSystem.SerialNumber = item.SerialNumber;
							mudCirculationSystem.COCAvailabilty = item.COCAvailabilty;
							mudCirculationSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							mudCirculationSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							mudCirculationSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							mudCirculationSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							mudCirculationSystem.RigCertificatesId = RigCertificates.Id;
							mudCirculationSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.MudCirculationSystem.Add(mudCirculationSystem);
						}

						var RigCertificatesWellControlSystem = WellControlSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesWellControlSystem)
						{
							WellControlSystemDTO wellControlSystem = new WellControlSystemDTO();
							wellControlSystem.Id = item.Id;
							wellControlSystem.Equipment = item.Equipment;
							wellControlSystem.SerialNumber = item.SerialNumber;
							wellControlSystem.COCAvailabilty = item.COCAvailabilty;
							wellControlSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							wellControlSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							wellControlSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							wellControlSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							wellControlSystem.RigCertificatesId = RigCertificates.Id;
							wellControlSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.WellControlSystem.Add(wellControlSystem);
						}

						var RigCertificatesPowerSystem = PowerSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesPowerSystem)
						{
							PowerSystemDTO powerSystem = new PowerSystemDTO();
							powerSystem.Id = item.Id;
							powerSystem.Equipment = item.Equipment;
							powerSystem.SerialNumber = item.SerialNumber;
							powerSystem.COCAvailabilty = item.COCAvailabilty;
							powerSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							powerSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							powerSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							powerSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							powerSystem.RigCertificatesId = RigCertificates.Id;
							powerSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.PowerSystem.Add(powerSystem);
						}

						var RigCertificatesOtherSystem = OtherSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesOtherSystem)
						{
							OtherSystemDTO otherSystem = new OtherSystemDTO();
							otherSystem.Id = item.Id;
							otherSystem.Item = item.Item;
							otherSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							otherSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							otherSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							otherSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							otherSystem.RigCertificatesId = RigCertificates.Id;
							otherSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.OtherSystem.Add(otherSystem);
						}

						var RigCertificatesMobileCrane = MobileCraneRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesMobileCrane.Any())
						{
							foreach (var item in RigCertificatesMobileCrane)
							{
								MobileCraneDTO mobileCrane = new MobileCraneDTO();
								mobileCrane.Id = item.Id;
								mobileCrane.Model = item.Model;
								mobileCrane.Type = item.Type;
								mobileCrane.ChassisNo = item.ChassisNo;
								mobileCrane.HookSerialNo = item.HookSerialNo;
								mobileCrane.Capacity = item.Capacity;
								mobileCrane.ManufactureDate = item.ManufactureDate;
								mobileCrane.LastExaminationDate = item.LastExaminationDate;
								mobileCrane.NextExaminationDate = item.NextExaminationDate;
								mobileCrane.RigCertificatesId = item.RigCertificatesId;
								mobileCrane.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.MobileCrane.Add(mobileCrane);
							}
						}


						var RigCertificatesForklift = ForkliftRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesForklift.Any())
						{
							foreach (var item in RigCertificatesForklift)
							{
								RigCertForkliftDTO forklift = new RigCertForkliftDTO();
								forklift.Id = item.Id;
								forklift.Model = item.Model;
								forklift.Type = item.Type;
								forklift.SerialNo = item.SerialNo;
								forklift.Capacity = item.Capacity;
								forklift.LastExaminationDate = item.LastExaminationDate;
								forklift.NextExaminationDate = item.NextExaminationDate;
								forklift.RigCertificatesId = item.RigCertificatesId;
								forklift.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.Forklift.Add(forklift);
							}
						}


						var RigCertificatesAirHoist = AirHoistRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesAirHoist.Any())
						{
							foreach (var item in RigCertificatesAirHoist)
							{
								AirHoistDTO airHoist = new AirHoistDTO();
								airHoist.Id = item.Id;
								airHoist.SerialNo = item.SerialNo;
								airHoist.WireSize = item.WireSize;
								airHoist.Capacity = item.Capacity;
								airHoist.WireInspectionDueDate = item.WireInspectionDueDate;
								airHoist.LastMPIInspectionDate = item.LastMPIInspectionDate;
								airHoist.NextMPIInspectionDate = item.NextMPIInspectionDate;
								airHoist.NextLoadTestDate = item.NextLoadTestDate;
								airHoist.RigCertificatesId = item.RigCertificatesId;
								airHoist.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.AirHoist.Add(airHoist);
							}
						}


						var RigCertificatesHydraulicWinch = HydraulicWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesHydraulicWinch.Any())
						{
							foreach (var item in RigCertificatesHydraulicWinch)
							{
								HydraulicWinchDTO hydraulicWinch = new HydraulicWinchDTO();
								hydraulicWinch.Id = item.Id;
								hydraulicWinch.SerialNo = item.SerialNo;
								hydraulicWinch.WireSize = item.WireSize;
								hydraulicWinch.Capacity = item.Capacity;
								hydraulicWinch.WireInspectionDueDate = item.WireInspectionDueDate;
								hydraulicWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
								hydraulicWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
								hydraulicWinch.NextLoadTestDate = item.NextLoadTestDate;
								hydraulicWinch.RigCertificatesId = item.RigCertificatesId;
								hydraulicWinch.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.HydraulicWinch.Add(hydraulicWinch);
							}
						}

						var RigCertificatesManRidingWinch = ManRidingWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesManRidingWinch.Any())
						{
							foreach (var item in RigCertificatesManRidingWinch)
							{
								ManRidingWinchDTO manRidingWinch = new ManRidingWinchDTO();
								manRidingWinch.Id = item.Id;
								manRidingWinch.SerialNo = item.SerialNo;
								manRidingWinch.WireSize = item.WireSize;
								manRidingWinch.Capacity = item.Capacity;
								manRidingWinch.WireInspectionDueDate = item.WireInspectionDueDate;
								manRidingWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
								manRidingWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
								manRidingWinch.NextLoadTestDate = item.NextLoadTestDate;
								manRidingWinch.RigCertificatesId = item.RigCertificatesId;
								manRidingWinch.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.ManRidingWinch.Add(manRidingWinch);
							}
						}


						newTemp.Add(RigCertificatesDTO);
						//result.Data = prod;
					}


					float countDetails = RigCertificatesRepoistory.getall().Count();
					var result = new PageResult<RigCertificatesResponseDTO>
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
					List<RigCertificates> temp = RigCertificatesRepoistory.getall().Where(a => a.user.Id == UserId).ToList();
					List<RigCertificatesResponseDTO> newTemp = new List<RigCertificatesResponseDTO>();
					foreach (RigCertificates RigCertificates in temp)
					{
						RigCertificatesResponseDTO RigCertificatesDTO = new RigCertificatesResponseDTO();
						RigCertificatesDTO.Id = RigCertificates.Id;
						RigCertificatesDTO.RigNo = RigCertificates.Rig.Number;
						RigCertificatesDTO.Date = RigCertificates.Date;
						RigCertificatesDTO.CertificationLiftingGear = RigCertificates.CertificationLiftingGear;
						RigCertificatesDTO.CertificationCATIII = RigCertificates.CertificationCATIII;
						RigCertificatesDTO.CertificationCATIV = RigCertificates.CertificationCATIV;
						RigCertificatesDTO.CertificationGaugeCalibraion = RigCertificates.CertificationGaugeCalibraion;
						RigCertificatesDTO.CertificationWallThickness = RigCertificates.CertificationWallThickness;
						RigCertificatesDTO.DueLiftingGear = RigCertificates.DueLiftingGear;
						RigCertificatesDTO.DueCATIII = RigCertificates.DueCATIII;
						RigCertificatesDTO.DueCATIV = RigCertificates.DueCATIV;
						RigCertificatesDTO.DueGaugeCalibraion = RigCertificates.DueGaugeCalibraion;
						RigCertificatesDTO.DueWallThickness = RigCertificates.DueWallThickness;
						RigCertificatesDTO.userName = RigCertificates.user.UserName;
						RigCertificatesDTO.IsDeleted = RigCertificates.IsDeleted;

						var RigCertificatesPersonnelCerificates = PersonnelCerificatesRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesPersonnelCerificates.Any())
						{
							foreach (var item in RigCertificatesPersonnelCerificates)
							{
								PersonnelCerificatesDTO personnelCerificates = new PersonnelCerificatesDTO();
								personnelCerificates.Id = item.Id;
								personnelCerificates.Code = item.Code;
								personnelCerificates.Position = item.Position;
								personnelCerificates.Name = item.Name;
								personnelCerificates.CertificateType = item.CertificateType;
								personnelCerificates.CertificateDate = item.CertificateDate;
								personnelCerificates.ExpiryDate = item.ExpiryDate;
								personnelCerificates.RigCertificatesId = RigCertificates.Id;
								personnelCerificates.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.PersonnelCerificates.Add(personnelCerificates);
							}
						}

						var RigCertificatesHSEEquipmentTable = HSEEquipmentTableRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesHSEEquipmentTable.Any())
						{
							var EquipList = HSEEquipmentListRepo.getall();
							foreach (var item in RigCertificatesHSEEquipmentTable)
							{
								HSEEquipmentTableResponseDTO hSEEquipmentTable = new HSEEquipmentTableResponseDTO();
								hSEEquipmentTable.Id = item.Id;
								hSEEquipmentTable.Equipment = EquipList.FirstOrDefault(e => e.Id == item.EquipmentId).Equipment;
								hSEEquipmentTable.Model = item.Model;
								hSEEquipmentTable.SerialNumber = item.SerialNumber;
								hSEEquipmentTable.ExpiryDate = item.ExpiryDate;
								hSEEquipmentTable.RigCertificatesId = RigCertificates.Id;
								hSEEquipmentTable.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.HSEEquipmentTable.Add(hSEEquipmentTable);
							}
						}

						var RigCertificatesPresssureReliefValve = PresssureReliefValveRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesPresssureReliefValve.Any())
						{
							foreach (var item in RigCertificatesPresssureReliefValve)
							{
								PresssureReliefValveDTO presssureReliefValve = new PresssureReliefValveDTO();
								presssureReliefValve.Id = item.Id;
								presssureReliefValve.Valves = item.Valves;
								presssureReliefValve.Location = item.Location;
								presssureReliefValve.CertificationDate = item.CertificationDate;
								presssureReliefValve.ExpiryDate = item.ExpiryDate;
								presssureReliefValve.RigCertificatesId = RigCertificates.Id;
								presssureReliefValve.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.PresssureReliefValve.Add(presssureReliefValve);
							}
						}

						var RigCertificatesHoistingSystem = HoistingSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesHoistingSystem)
						{
							HoistingSystemDTO hoistingSystem = new HoistingSystemDTO();
							hoistingSystem.Id = item.Id;
							hoistingSystem.Equipment = item.Equipment;
							hoistingSystem.SerialNumber = item.SerialNumber;
							hoistingSystem.COCAvailabilty = item.COCAvailabilty;
							hoistingSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							hoistingSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							hoistingSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							hoistingSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							hoistingSystem.RigCertificatesId = RigCertificates.Id;
							hoistingSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.HoistingSystem.Add(hoistingSystem);
						}

						var RigCertificatesRotarySystem = RotarySystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesRotarySystem)
						{
							RotarySystemDTO rotarySystem = new RotarySystemDTO();
							rotarySystem.Id = item.Id;
							rotarySystem.Equipment = item.Equipment;
							rotarySystem.SerialNumber = item.SerialNumber;
							rotarySystem.COCAvailabilty = item.COCAvailabilty;
							rotarySystem.CATIIICertificationDate = item.CATIIICertificationDate;
							rotarySystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							rotarySystem.CATIVCertificationDate = item.CATIVCertificationDate;
							rotarySystem.CATIVExpiryDate = item.CATIVExpiryDate;
							rotarySystem.RigCertificatesId = RigCertificates.Id;
							rotarySystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.RotarySystem.Add(rotarySystem);
						}

						var RigCertificatesMudCirculationSystem = MudCirculationSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesMudCirculationSystem)
						{
							MudCirculationSystemDTO mudCirculationSystem = new MudCirculationSystemDTO();
							mudCirculationSystem.Id = item.Id;
							mudCirculationSystem.Equipment = item.Equipment;
							mudCirculationSystem.SerialNumber = item.SerialNumber;
							mudCirculationSystem.COCAvailabilty = item.COCAvailabilty;
							mudCirculationSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							mudCirculationSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							mudCirculationSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							mudCirculationSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							mudCirculationSystem.RigCertificatesId = RigCertificates.Id;
							mudCirculationSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.MudCirculationSystem.Add(mudCirculationSystem);
						}

						var RigCertificatesWellControlSystem = WellControlSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesWellControlSystem)
						{
							WellControlSystemDTO wellControlSystem = new WellControlSystemDTO();
							wellControlSystem.Id = item.Id;
							wellControlSystem.Equipment = item.Equipment;
							wellControlSystem.SerialNumber = item.SerialNumber;
							wellControlSystem.COCAvailabilty = item.COCAvailabilty;
							wellControlSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							wellControlSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							wellControlSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							wellControlSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							wellControlSystem.RigCertificatesId = RigCertificates.Id;
							wellControlSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.WellControlSystem.Add(wellControlSystem);
						}

						var RigCertificatesPowerSystem = PowerSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesPowerSystem)
						{
							PowerSystemDTO powerSystem = new PowerSystemDTO();
							powerSystem.Id = item.Id;
							powerSystem.Equipment = item.Equipment;
							powerSystem.SerialNumber = item.SerialNumber;
							powerSystem.COCAvailabilty = item.COCAvailabilty;
							powerSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							powerSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							powerSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							powerSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							powerSystem.RigCertificatesId = RigCertificates.Id;
							powerSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.PowerSystem.Add(powerSystem);
						}

						var RigCertificatesOtherSystem = OtherSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						foreach (var item in RigCertificatesOtherSystem)
						{
							OtherSystemDTO otherSystem = new OtherSystemDTO();
							otherSystem.Id = item.Id;
							otherSystem.Item = item.Item;
							otherSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							otherSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							otherSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							otherSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							otherSystem.RigCertificatesId = RigCertificates.Id;
							otherSystem.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.OtherSystem.Add(otherSystem);
						}

						var RigCertificatesMobileCrane = MobileCraneRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesMobileCrane.Any())
						{
							foreach (var item in RigCertificatesMobileCrane)
							{
								MobileCraneDTO mobileCrane = new MobileCraneDTO();
								mobileCrane.Id = item.Id;
								mobileCrane.Model = item.Model;
								mobileCrane.Type = item.Type;
								mobileCrane.ChassisNo = item.ChassisNo;
								mobileCrane.HookSerialNo = item.HookSerialNo;
								mobileCrane.Capacity = item.Capacity;
								mobileCrane.ManufactureDate = item.ManufactureDate;
								mobileCrane.LastExaminationDate = item.LastExaminationDate;
								mobileCrane.NextExaminationDate = item.NextExaminationDate;
								mobileCrane.RigCertificatesId = item.RigCertificatesId;
								mobileCrane.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.MobileCrane.Add(mobileCrane);
							}
						}


						var RigCertificatesForklift = ForkliftRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesForklift.Any())
						{
							foreach (var item in RigCertificatesForklift)
							{
								RigCertForkliftDTO forklift = new RigCertForkliftDTO();
								forklift.Id = item.Id;
								forklift.Model = item.Model;
								forklift.Type = item.Type;
								forklift.SerialNo = item.SerialNo;
								forklift.Capacity = item.Capacity;
								forklift.LastExaminationDate = item.LastExaminationDate;
								forklift.NextExaminationDate = item.NextExaminationDate;
								forklift.RigCertificatesId = item.RigCertificatesId;
								forklift.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.Forklift.Add(forklift);
							}
						}


						var RigCertificatesAirHoist = AirHoistRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesAirHoist.Any())
						{
							foreach (var item in RigCertificatesAirHoist)
							{
								AirHoistDTO airHoist = new AirHoistDTO();
								airHoist.Id = item.Id;
								airHoist.SerialNo = item.SerialNo;
								airHoist.WireSize = item.WireSize;
								airHoist.Capacity = item.Capacity;
								airHoist.WireInspectionDueDate = item.WireInspectionDueDate;
								airHoist.LastMPIInspectionDate = item.LastMPIInspectionDate;
								airHoist.NextMPIInspectionDate = item.NextMPIInspectionDate;
								airHoist.NextLoadTestDate = item.NextLoadTestDate;
								airHoist.RigCertificatesId = item.RigCertificatesId;
								airHoist.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.AirHoist.Add(airHoist);
							}
						}


						var RigCertificatesHydraulicWinch = HydraulicWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesHydraulicWinch.Any())
						{
							foreach (var item in RigCertificatesHydraulicWinch)
							{
								HydraulicWinchDTO hydraulicWinch = new HydraulicWinchDTO();
								hydraulicWinch.Id = item.Id;
								hydraulicWinch.SerialNo = item.SerialNo;
								hydraulicWinch.WireSize = item.WireSize;
								hydraulicWinch.Capacity = item.Capacity;
								hydraulicWinch.WireInspectionDueDate = item.WireInspectionDueDate;
								hydraulicWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
								hydraulicWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
								hydraulicWinch.NextLoadTestDate = item.NextLoadTestDate;
								hydraulicWinch.RigCertificatesId = item.RigCertificatesId;
								hydraulicWinch.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.HydraulicWinch.Add(hydraulicWinch);
							}
						}

						var RigCertificatesManRidingWinch = ManRidingWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
						if (RigCertificatesManRidingWinch.Any())
						{
							foreach (var item in RigCertificatesManRidingWinch)
							{
								ManRidingWinchDTO manRidingWinch = new ManRidingWinchDTO();
								manRidingWinch.Id = item.Id;
								manRidingWinch.SerialNo = item.SerialNo;
								manRidingWinch.WireSize = item.WireSize;
								manRidingWinch.Capacity = item.Capacity;
								manRidingWinch.WireInspectionDueDate = item.WireInspectionDueDate;
								manRidingWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
								manRidingWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
								manRidingWinch.NextLoadTestDate = item.NextLoadTestDate;
								manRidingWinch.RigCertificatesId = item.RigCertificatesId;
								manRidingWinch.IsDeleted = item.IsDeleted;
								RigCertificatesDTO.ManRidingWinch.Add(manRidingWinch);
							}
						}


						newTemp.Add(RigCertificatesDTO);
						//result.Data = prod;
					}

					float countDetails = RigCertificatesRepoistory.getall().Where(a => a.user.Id == UserId).Count();
					var result = new PageResult<RigCertificatesResponseDTO>
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
				return new PageResult<RigCertificatesResponseDTO>();

			}
			return new PageResult<RigCertificatesResponseDTO>();
		}


		[HttpGet("GetDataById/{ID:int}")]
		public ActionResult<ResultDTO> GetAllWithDataByID(int ID, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();
			if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
			{
				RigCertificates RigCertificates = RigCertificatesRepoistory.getall().FirstOrDefault(a => a.Id == ID);
				if (RigCertificates != null)
				{
					RigCertificatesResponseDTO RigCertificatesDTO = new RigCertificatesResponseDTO();
					RigCertificatesDTO.Id = RigCertificates.Id;
					RigCertificatesDTO.RigNo = RigCertificates.Rig.Number;
					RigCertificatesDTO.Date = RigCertificates.Date;
					RigCertificatesDTO.CertificationLiftingGear = RigCertificates.CertificationLiftingGear;
					RigCertificatesDTO.CertificationCATIII = RigCertificates.CertificationCATIII;
					RigCertificatesDTO.CertificationCATIV = RigCertificates.CertificationCATIV;
					RigCertificatesDTO.CertificationGaugeCalibraion = RigCertificates.CertificationGaugeCalibraion;
					RigCertificatesDTO.CertificationWallThickness = RigCertificates.CertificationWallThickness;
					RigCertificatesDTO.DueLiftingGear = RigCertificates.DueLiftingGear;
					RigCertificatesDTO.DueCATIII = RigCertificates.DueCATIII;
					RigCertificatesDTO.DueCATIV = RigCertificates.DueCATIV;
					RigCertificatesDTO.DueGaugeCalibraion = RigCertificates.DueGaugeCalibraion;
					RigCertificatesDTO.DueWallThickness = RigCertificates.DueWallThickness;
					RigCertificatesDTO.userName = RigCertificates.user.UserName;
					RigCertificatesDTO.IsDeleted = RigCertificates.IsDeleted;

					var RigCertificatesPersonnelCerificates = PersonnelCerificatesRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesPersonnelCerificates.Any())
					{
						foreach (var item in RigCertificatesPersonnelCerificates)
						{
							PersonnelCerificatesDTO personnelCerificates = new PersonnelCerificatesDTO();
							personnelCerificates.Id = item.Id;
							personnelCerificates.Code = item.Code;
							personnelCerificates.Position = item.Position;
							personnelCerificates.Name = item.Name;
							personnelCerificates.CertificateType = item.CertificateType;
							personnelCerificates.CertificateDate = item.CertificateDate;
							personnelCerificates.ExpiryDate = item.ExpiryDate;
							personnelCerificates.RigCertificatesId = RigCertificates.Id;
							personnelCerificates.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.PersonnelCerificates.Add(personnelCerificates);
						}
					}

					var RigCertificatesHSEEquipmentTable = HSEEquipmentTableRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesHSEEquipmentTable.Any())
					{
						var EquipList = HSEEquipmentListRepo.getall();
						foreach (var item in RigCertificatesHSEEquipmentTable)
						{
							HSEEquipmentTableResponseDTO hSEEquipmentTable = new HSEEquipmentTableResponseDTO();
							hSEEquipmentTable.Id = item.Id;
							hSEEquipmentTable.Equipment = EquipList.FirstOrDefault(e => e.Id == item.EquipmentId).Equipment;
							hSEEquipmentTable.Model = item.Model;
							hSEEquipmentTable.SerialNumber = item.SerialNumber;
							hSEEquipmentTable.ExpiryDate = item.ExpiryDate;
							hSEEquipmentTable.RigCertificatesId = RigCertificates.Id;
							hSEEquipmentTable.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.HSEEquipmentTable.Add(hSEEquipmentTable);
						}
					}

					var RigCertificatesPresssureReliefValve = PresssureReliefValveRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesPresssureReliefValve.Any())
					{
						foreach (var item in RigCertificatesPresssureReliefValve)
						{
							PresssureReliefValveDTO presssureReliefValve = new PresssureReliefValveDTO();
							presssureReliefValve.Id = item.Id;
							presssureReliefValve.Valves = item.Valves;
							presssureReliefValve.Location = item.Location;
							presssureReliefValve.CertificationDate = item.CertificationDate;
							presssureReliefValve.ExpiryDate = item.ExpiryDate;
							presssureReliefValve.RigCertificatesId = RigCertificates.Id;
							presssureReliefValve.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.PresssureReliefValve.Add(presssureReliefValve);
						}
					}

					var RigCertificatesHoistingSystem = HoistingSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesHoistingSystem)
					{
						HoistingSystemDTO hoistingSystem = new HoistingSystemDTO();
						hoistingSystem.Id = item.Id;
						hoistingSystem.Equipment = item.Equipment;
						hoistingSystem.SerialNumber = item.SerialNumber;
						hoistingSystem.COCAvailabilty = item.COCAvailabilty;
						hoistingSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						hoistingSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						hoistingSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						hoistingSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						hoistingSystem.RigCertificatesId = RigCertificates.Id;
						hoistingSystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.HoistingSystem.Add(hoistingSystem);
					}

					var RigCertificatesRotarySystem = RotarySystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesRotarySystem)
					{
						RotarySystemDTO rotarySystem = new RotarySystemDTO();
						rotarySystem.Id = item.Id;
						rotarySystem.Equipment = item.Equipment;
						rotarySystem.SerialNumber = item.SerialNumber;
						rotarySystem.COCAvailabilty = item.COCAvailabilty;
						rotarySystem.CATIIICertificationDate = item.CATIIICertificationDate;
						rotarySystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						rotarySystem.CATIVCertificationDate = item.CATIVCertificationDate;
						rotarySystem.CATIVExpiryDate = item.CATIVExpiryDate;
						rotarySystem.RigCertificatesId = RigCertificates.Id;
						rotarySystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.RotarySystem.Add(rotarySystem);
					}

					var RigCertificatesMudCirculationSystem = MudCirculationSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesMudCirculationSystem)
					{
						MudCirculationSystemDTO mudCirculationSystem = new MudCirculationSystemDTO();
						mudCirculationSystem.Id = item.Id;
						mudCirculationSystem.Equipment = item.Equipment;
						mudCirculationSystem.SerialNumber = item.SerialNumber;
						mudCirculationSystem.COCAvailabilty = item.COCAvailabilty;
						mudCirculationSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						mudCirculationSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						mudCirculationSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						mudCirculationSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						mudCirculationSystem.RigCertificatesId = RigCertificates.Id;
						mudCirculationSystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.MudCirculationSystem.Add(mudCirculationSystem);
					}

					var RigCertificatesWellControlSystem = WellControlSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesWellControlSystem)
					{
						WellControlSystemDTO wellControlSystem = new WellControlSystemDTO();
						wellControlSystem.Id = item.Id;
						wellControlSystem.Equipment = item.Equipment;
						wellControlSystem.SerialNumber = item.SerialNumber;
						wellControlSystem.COCAvailabilty = item.COCAvailabilty;
						wellControlSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						wellControlSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						wellControlSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						wellControlSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						wellControlSystem.RigCertificatesId = RigCertificates.Id;
						wellControlSystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.WellControlSystem.Add(wellControlSystem);
					}

					var RigCertificatesPowerSystem = PowerSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesPowerSystem)
					{
						PowerSystemDTO powerSystem = new PowerSystemDTO();
						powerSystem.Id = item.Id;
						powerSystem.Equipment = item.Equipment;
						powerSystem.SerialNumber = item.SerialNumber;
						powerSystem.COCAvailabilty = item.COCAvailabilty;
						powerSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						powerSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						powerSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						powerSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						powerSystem.RigCertificatesId = RigCertificates.Id;
						powerSystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.PowerSystem.Add(powerSystem);
					}

					var RigCertificatesOtherSystem = OtherSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesOtherSystem)
					{
						OtherSystemDTO otherSystem = new OtherSystemDTO();
						otherSystem.Id = item.Id;
						otherSystem.Item = item.Item;
						otherSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						otherSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						otherSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						otherSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						otherSystem.RigCertificatesId = RigCertificates.Id;
						otherSystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.OtherSystem.Add(otherSystem);
					}

					var RigCertificatesMobileCrane = MobileCraneRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesMobileCrane.Any())
					{
						foreach (var item in RigCertificatesMobileCrane)
						{
							MobileCraneDTO mobileCrane = new MobileCraneDTO();
							mobileCrane.Id = item.Id;
							mobileCrane.Model = item.Model;
							mobileCrane.Type = item.Type;
							mobileCrane.ChassisNo = item.ChassisNo;
							mobileCrane.HookSerialNo = item.HookSerialNo;
							mobileCrane.Capacity = item.Capacity;
							mobileCrane.ManufactureDate = item.ManufactureDate;
							mobileCrane.LastExaminationDate = item.LastExaminationDate;
							mobileCrane.NextExaminationDate = item.NextExaminationDate;
							mobileCrane.RigCertificatesId = item.RigCertificatesId;
							mobileCrane.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.MobileCrane.Add(mobileCrane);
						}
					}


					var RigCertificatesForklift = ForkliftRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesForklift.Any())
					{
						foreach (var item in RigCertificatesForklift)
						{
							RigCertForkliftDTO forklift = new RigCertForkliftDTO();
							forklift.Id = item.Id;
							forklift.Model = item.Model;
							forklift.Type = item.Type;
							forklift.SerialNo = item.SerialNo;
							forklift.Capacity = item.Capacity;
							forklift.LastExaminationDate = item.LastExaminationDate;
							forklift.NextExaminationDate = item.NextExaminationDate;
							forklift.RigCertificatesId = item.RigCertificatesId;
							forklift.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.Forklift.Add(forklift);
						}
					}


					var RigCertificatesAirHoist = AirHoistRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesAirHoist.Any())
					{
						foreach (var item in RigCertificatesAirHoist)
						{
							AirHoistDTO airHoist = new AirHoistDTO();
							airHoist.Id = item.Id;
							airHoist.SerialNo = item.SerialNo;
							airHoist.WireSize = item.WireSize;
							airHoist.Capacity = item.Capacity;
							airHoist.WireInspectionDueDate = item.WireInspectionDueDate;
							airHoist.LastMPIInspectionDate = item.LastMPIInspectionDate;
							airHoist.NextMPIInspectionDate = item.NextMPIInspectionDate;
							airHoist.NextLoadTestDate = item.NextLoadTestDate;
							airHoist.RigCertificatesId = item.RigCertificatesId;
							airHoist.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.AirHoist.Add(airHoist);
						}
					}


					var RigCertificatesHydraulicWinch = HydraulicWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesHydraulicWinch.Any())
					{
						foreach (var item in RigCertificatesHydraulicWinch)
						{
							HydraulicWinchDTO hydraulicWinch = new HydraulicWinchDTO();
							hydraulicWinch.Id = item.Id;
							hydraulicWinch.SerialNo = item.SerialNo;
							hydraulicWinch.WireSize = item.WireSize;
							hydraulicWinch.Capacity = item.Capacity;
							hydraulicWinch.WireInspectionDueDate = item.WireInspectionDueDate;
							hydraulicWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
							hydraulicWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
							hydraulicWinch.NextLoadTestDate = item.NextLoadTestDate;
							hydraulicWinch.RigCertificatesId = item.RigCertificatesId;
							hydraulicWinch.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.HydraulicWinch.Add(hydraulicWinch);
						}
					}

					var RigCertificatesManRidingWinch = ManRidingWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesManRidingWinch.Any())
					{
						foreach (var item in RigCertificatesManRidingWinch)
						{
							ManRidingWinchDTO manRidingWinch = new ManRidingWinchDTO();
							manRidingWinch.Id = item.Id;
							manRidingWinch.SerialNo = item.SerialNo;
							manRidingWinch.WireSize = item.WireSize;
							manRidingWinch.Capacity = item.Capacity;
							manRidingWinch.WireInspectionDueDate = item.WireInspectionDueDate;
							manRidingWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
							manRidingWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
							manRidingWinch.NextLoadTestDate = item.NextLoadTestDate;
							manRidingWinch.RigCertificatesId = item.RigCertificatesId;
							manRidingWinch.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.ManRidingWinch.Add(manRidingWinch);
						}
					}

					result.Message = "Success";
					result.Statescode = 200;
					result.Data = RigCertificatesDTO;

					return result;
				}
				
			}
			else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
			{
				RigCertificates RigCertificates = RigCertificatesRepoistory.getall().FirstOrDefault(a => a.Id == ID && a.user.Id == UserId);
				if (RigCertificates != null)
				{
					RigCertificatesResponseDTO RigCertificatesDTO = new RigCertificatesResponseDTO();
					RigCertificatesDTO.Id = RigCertificates.Id;
					RigCertificatesDTO.RigNo = RigCertificates.Rig.Number;
					RigCertificatesDTO.Date = RigCertificates.Date;
					RigCertificatesDTO.CertificationLiftingGear = RigCertificates.CertificationLiftingGear;
					RigCertificatesDTO.CertificationCATIII = RigCertificates.CertificationCATIII;
					RigCertificatesDTO.CertificationCATIV = RigCertificates.CertificationCATIV;
					RigCertificatesDTO.CertificationGaugeCalibraion = RigCertificates.CertificationGaugeCalibraion;
					RigCertificatesDTO.CertificationWallThickness = RigCertificates.CertificationWallThickness;
					RigCertificatesDTO.DueLiftingGear = RigCertificates.DueLiftingGear;
					RigCertificatesDTO.DueCATIII = RigCertificates.DueCATIII;
					RigCertificatesDTO.DueCATIV = RigCertificates.DueCATIV;
					RigCertificatesDTO.DueGaugeCalibraion = RigCertificates.DueGaugeCalibraion;
					RigCertificatesDTO.DueWallThickness = RigCertificates.DueWallThickness;
					RigCertificatesDTO.userName = RigCertificates.user.UserName;
					RigCertificatesDTO.IsDeleted = RigCertificates.IsDeleted;

					var RigCertificatesPersonnelCerificates = PersonnelCerificatesRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesPersonnelCerificates.Any())
					{
						foreach (var item in RigCertificatesPersonnelCerificates)
						{
							PersonnelCerificatesDTO personnelCerificates = new PersonnelCerificatesDTO();
							personnelCerificates.Id = item.Id;
							personnelCerificates.Code = item.Code;
							personnelCerificates.Position = item.Position;
							personnelCerificates.Name = item.Name;
							personnelCerificates.CertificateType = item.CertificateType;
							personnelCerificates.CertificateDate = item.CertificateDate;
							personnelCerificates.ExpiryDate = item.ExpiryDate;
							personnelCerificates.RigCertificatesId = RigCertificates.Id;
							personnelCerificates.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.PersonnelCerificates.Add(personnelCerificates);
						}
					}

					var RigCertificatesHSEEquipmentTable = HSEEquipmentTableRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesHSEEquipmentTable.Any())
					{
						var EquipList = HSEEquipmentListRepo.getall();
						foreach (var item in RigCertificatesHSEEquipmentTable)
						{
							HSEEquipmentTableResponseDTO hSEEquipmentTable = new HSEEquipmentTableResponseDTO();
							hSEEquipmentTable.Id = item.Id;
							hSEEquipmentTable.Equipment = EquipList.FirstOrDefault(e => e.Id == item.EquipmentId).Equipment;
							hSEEquipmentTable.Model = item.Model;
							hSEEquipmentTable.SerialNumber = item.SerialNumber;
							hSEEquipmentTable.ExpiryDate = item.ExpiryDate;
							hSEEquipmentTable.RigCertificatesId = RigCertificates.Id;
							hSEEquipmentTable.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.HSEEquipmentTable.Add(hSEEquipmentTable);
						}
					}

					var RigCertificatesPresssureReliefValve = PresssureReliefValveRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesPresssureReliefValve.Any())
					{
						foreach (var item in RigCertificatesPresssureReliefValve)
						{
							PresssureReliefValveDTO presssureReliefValve = new PresssureReliefValveDTO();
							presssureReliefValve.Id = item.Id;
							presssureReliefValve.Valves = item.Valves;
							presssureReliefValve.Location = item.Location;
							presssureReliefValve.CertificationDate = item.CertificationDate;
							presssureReliefValve.ExpiryDate = item.ExpiryDate;
							presssureReliefValve.RigCertificatesId = RigCertificates.Id;
							presssureReliefValve.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.PresssureReliefValve.Add(presssureReliefValve);
						}
					}

					var RigCertificatesHoistingSystem = HoistingSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesHoistingSystem)
					{
						HoistingSystemDTO hoistingSystem = new HoistingSystemDTO();
						hoistingSystem.Id = item.Id;
						hoistingSystem.Equipment = item.Equipment;
						hoistingSystem.SerialNumber = item.SerialNumber;
						hoistingSystem.COCAvailabilty = item.COCAvailabilty;
						hoistingSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						hoistingSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						hoistingSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						hoistingSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						hoistingSystem.RigCertificatesId = RigCertificates.Id;
						hoistingSystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.HoistingSystem.Add(hoistingSystem);
					}

					var RigCertificatesRotarySystem = RotarySystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesRotarySystem)
					{
						RotarySystemDTO rotarySystem = new RotarySystemDTO();
						rotarySystem.Id = item.Id;
						rotarySystem.Equipment = item.Equipment;
						rotarySystem.SerialNumber = item.SerialNumber;
						rotarySystem.COCAvailabilty = item.COCAvailabilty;
						rotarySystem.CATIIICertificationDate = item.CATIIICertificationDate;
						rotarySystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						rotarySystem.CATIVCertificationDate = item.CATIVCertificationDate;
						rotarySystem.CATIVExpiryDate = item.CATIVExpiryDate;
						rotarySystem.RigCertificatesId = RigCertificates.Id;
						rotarySystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.RotarySystem.Add(rotarySystem);
					}

					var RigCertificatesMudCirculationSystem = MudCirculationSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesMudCirculationSystem)
					{
						MudCirculationSystemDTO mudCirculationSystem = new MudCirculationSystemDTO();
						mudCirculationSystem.Id = item.Id;
						mudCirculationSystem.Equipment = item.Equipment;
						mudCirculationSystem.SerialNumber = item.SerialNumber;
						mudCirculationSystem.COCAvailabilty = item.COCAvailabilty;
						mudCirculationSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						mudCirculationSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						mudCirculationSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						mudCirculationSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						mudCirculationSystem.RigCertificatesId = RigCertificates.Id;
						mudCirculationSystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.MudCirculationSystem.Add(mudCirculationSystem);
					}

					var RigCertificatesWellControlSystem = WellControlSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesWellControlSystem)
					{
						WellControlSystemDTO wellControlSystem = new WellControlSystemDTO();
						wellControlSystem.Id = item.Id;
						wellControlSystem.Equipment = item.Equipment;
						wellControlSystem.SerialNumber = item.SerialNumber;
						wellControlSystem.COCAvailabilty = item.COCAvailabilty;
						wellControlSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						wellControlSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						wellControlSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						wellControlSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						wellControlSystem.RigCertificatesId = RigCertificates.Id;
						wellControlSystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.WellControlSystem.Add(wellControlSystem);
					}

					var RigCertificatesPowerSystem = PowerSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesPowerSystem)
					{
						PowerSystemDTO powerSystem = new PowerSystemDTO();
						powerSystem.Id = item.Id;
						powerSystem.Equipment = item.Equipment;
						powerSystem.SerialNumber = item.SerialNumber;
						powerSystem.COCAvailabilty = item.COCAvailabilty;
						powerSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						powerSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						powerSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						powerSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						powerSystem.RigCertificatesId = RigCertificates.Id;
						powerSystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.PowerSystem.Add(powerSystem);
					}

					var RigCertificatesOtherSystem = OtherSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesOtherSystem)
					{
						OtherSystemDTO otherSystem = new OtherSystemDTO();
						otherSystem.Id = item.Id;
						otherSystem.Item = item.Item;
						otherSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						otherSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						otherSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						otherSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						otherSystem.RigCertificatesId = RigCertificates.Id;
						otherSystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.OtherSystem.Add(otherSystem);
					}

					var RigCertificatesMobileCrane = MobileCraneRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesMobileCrane.Any())
					{
						foreach (var item in RigCertificatesMobileCrane)
						{
							MobileCraneDTO mobileCrane = new MobileCraneDTO();
							mobileCrane.Id = item.Id;
							mobileCrane.Model = item.Model;
							mobileCrane.Type = item.Type;
							mobileCrane.ChassisNo = item.ChassisNo;
							mobileCrane.HookSerialNo = item.HookSerialNo;
							mobileCrane.Capacity = item.Capacity;
							mobileCrane.ManufactureDate = item.ManufactureDate;
							mobileCrane.LastExaminationDate = item.LastExaminationDate;
							mobileCrane.NextExaminationDate = item.NextExaminationDate;
							mobileCrane.RigCertificatesId = item.RigCertificatesId;
							mobileCrane.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.MobileCrane.Add(mobileCrane);
						}
					}


					var RigCertificatesForklift = ForkliftRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesForklift.Any())
					{
						foreach (var item in RigCertificatesForklift)
						{
							RigCertForkliftDTO forklift = new RigCertForkliftDTO();
							forklift.Id = item.Id;
							forklift.Model = item.Model;
							forklift.Type = item.Type;
							forklift.SerialNo = item.SerialNo;
							forklift.Capacity = item.Capacity;
							forklift.LastExaminationDate = item.LastExaminationDate;
							forklift.NextExaminationDate = item.NextExaminationDate;
							forklift.RigCertificatesId = item.RigCertificatesId;
							forklift.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.Forklift.Add(forklift);
						}
					}


					var RigCertificatesAirHoist = AirHoistRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesAirHoist.Any())
					{
						foreach (var item in RigCertificatesAirHoist)
						{
							AirHoistDTO airHoist = new AirHoistDTO();
							airHoist.Id = item.Id;
							airHoist.SerialNo = item.SerialNo;
							airHoist.WireSize = item.WireSize;
							airHoist.Capacity = item.Capacity;
							airHoist.WireInspectionDueDate = item.WireInspectionDueDate;
							airHoist.LastMPIInspectionDate = item.LastMPIInspectionDate;
							airHoist.NextMPIInspectionDate = item.NextMPIInspectionDate;
							airHoist.NextLoadTestDate = item.NextLoadTestDate;
							airHoist.RigCertificatesId = item.RigCertificatesId;
							airHoist.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.AirHoist.Add(airHoist);
						}
					}


					var RigCertificatesHydraulicWinch = HydraulicWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesHydraulicWinch.Any())
					{
						foreach (var item in RigCertificatesHydraulicWinch)
						{
							HydraulicWinchDTO hydraulicWinch = new HydraulicWinchDTO();
							hydraulicWinch.Id = item.Id;
							hydraulicWinch.SerialNo = item.SerialNo;
							hydraulicWinch.WireSize = item.WireSize;
							hydraulicWinch.Capacity = item.Capacity;
							hydraulicWinch.WireInspectionDueDate = item.WireInspectionDueDate;
							hydraulicWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
							hydraulicWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
							hydraulicWinch.NextLoadTestDate = item.NextLoadTestDate;
							hydraulicWinch.RigCertificatesId = item.RigCertificatesId;
							hydraulicWinch.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.HydraulicWinch.Add(hydraulicWinch);
						}
					}

					var RigCertificatesManRidingWinch = ManRidingWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesManRidingWinch.Any())
					{
						foreach (var item in RigCertificatesManRidingWinch)
						{
							ManRidingWinchDTO manRidingWinch = new ManRidingWinchDTO();
							manRidingWinch.Id = item.Id;
							manRidingWinch.SerialNo = item.SerialNo;
							manRidingWinch.WireSize = item.WireSize;
							manRidingWinch.Capacity = item.Capacity;
							manRidingWinch.WireInspectionDueDate = item.WireInspectionDueDate;
							manRidingWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
							manRidingWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
							manRidingWinch.NextLoadTestDate = item.NextLoadTestDate;
							manRidingWinch.RigCertificatesId = item.RigCertificatesId;
							manRidingWinch.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.ManRidingWinch.Add(manRidingWinch);
						}
					}
					result.Message = "Success";
					result.Statescode = 200;
					result.Data = RigCertificatesDTO;

					return result;
				}
			}

			result.Statescode = 404;
			result.Message = "data not found";
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
					RigCertificates RigCertificates = RigCertificatesRepoistory.getall().FirstOrDefault(a => a.Id == ID);
					RigCertificatesDTO RigCertificatesDTO = new RigCertificatesDTO();
					RigCertificatesDTO.Id = RigCertificates.Id;
					RigCertificatesDTO.RigId = RigCertificates.RigId;
					RigCertificatesDTO.Date = RigCertificates.Date;
					RigCertificatesDTO.CertificationLiftingGear = RigCertificates.CertificationLiftingGear;
					RigCertificatesDTO.CertificationCATIII = RigCertificates.CertificationCATIII;
					RigCertificatesDTO.CertificationCATIV = RigCertificates.CertificationCATIV;
					RigCertificatesDTO.CertificationGaugeCalibraion = RigCertificates.CertificationGaugeCalibraion;
					RigCertificatesDTO.CertificationWallThickness = RigCertificates.CertificationWallThickness;
					RigCertificatesDTO.DueLiftingGear = RigCertificates.DueLiftingGear;
					RigCertificatesDTO.DueCATIII = RigCertificates.DueCATIII;
					RigCertificatesDTO.DueCATIV = RigCertificates.DueCATIV;
					RigCertificatesDTO.DueGaugeCalibraion = RigCertificates.DueGaugeCalibraion;
					RigCertificatesDTO.DueWallThickness = RigCertificates.DueWallThickness;
					RigCertificatesDTO.userID = RigCertificates.userID;
					RigCertificatesDTO.IsDeleted = RigCertificates.IsDeleted;

					var RigCertificatesPersonnelCerificates = PersonnelCerificatesRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesPersonnelCerificates.Any())
					{
						foreach (var item in RigCertificatesPersonnelCerificates)
						{
							PersonnelCerificatesDTO personnelCerificates = new PersonnelCerificatesDTO();
							personnelCerificates.Id = item.Id;
							personnelCerificates.Code = item.Code;
							personnelCerificates.Position = item.Position;
							personnelCerificates.Name = item.Name;
							personnelCerificates.CertificateType = item.CertificateType;
							personnelCerificates.CertificateDate = item.CertificateDate;
							personnelCerificates.ExpiryDate = item.ExpiryDate;
							personnelCerificates.RigCertificatesId = RigCertificates.Id;
							personnelCerificates.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.PersonnelCerificates.Add(personnelCerificates);
						}
					}

					var RigCertificatesHSEEquipmentTable = HSEEquipmentTableRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesHSEEquipmentTable.Any())
					{
						foreach (var item in RigCertificatesHSEEquipmentTable)
						{
							HSEEquipmentTableDTO hSEEquipmentTable = new HSEEquipmentTableDTO();
							hSEEquipmentTable.Id = item.Id;
							hSEEquipmentTable.EquipmentId = item.EquipmentId;
							hSEEquipmentTable.Model = item.Model;
							hSEEquipmentTable.SerialNumber = item.SerialNumber;
							hSEEquipmentTable.ExpiryDate = item.ExpiryDate;
							hSEEquipmentTable.RigCertificatesId = RigCertificates.Id;
							hSEEquipmentTable.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.HSEEquipmentTable.Add(hSEEquipmentTable);
						}
					}

					var RigCertificatesPresssureReliefValve = PresssureReliefValveRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesPresssureReliefValve.Any())
					{
						foreach (var item in RigCertificatesPresssureReliefValve)
						{
							PresssureReliefValveDTO presssureReliefValve = new PresssureReliefValveDTO();
							presssureReliefValve.Id = item.Id;
							presssureReliefValve.Valves = item.Valves;
							presssureReliefValve.Location = item.Location;
							presssureReliefValve.CertificationDate = item.CertificationDate;
							presssureReliefValve.ExpiryDate = item.ExpiryDate;
							presssureReliefValve.RigCertificatesId = RigCertificates.Id;
							presssureReliefValve.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.PresssureReliefValve.Add(presssureReliefValve);
						}
					}

					var RigCertificatesHoistingSystem = HoistingSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesHoistingSystem)
					{
						HoistingSystemDTO hoistingSystem = new HoistingSystemDTO();
						hoistingSystem.Id = item.Id;
						hoistingSystem.Equipment = item.Equipment;
						hoistingSystem.SerialNumber = item.SerialNumber;
						hoistingSystem.COCAvailabilty = item.COCAvailabilty;
						hoistingSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						hoistingSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						hoistingSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						hoistingSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						hoistingSystem.RigCertificatesId = RigCertificates.Id;
						hoistingSystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.HoistingSystem.Add(hoistingSystem);
					}

					var RigCertificatesRotarySystem = RotarySystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesRotarySystem)
					{
						RotarySystemDTO rotarySystem = new RotarySystemDTO();
						rotarySystem.Id = item.Id;
						rotarySystem.Equipment = item.Equipment;
						rotarySystem.SerialNumber = item.SerialNumber;
						rotarySystem.COCAvailabilty = item.COCAvailabilty;
						rotarySystem.CATIIICertificationDate = item.CATIIICertificationDate;
						rotarySystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						rotarySystem.CATIVCertificationDate = item.CATIVCertificationDate;
						rotarySystem.CATIVExpiryDate = item.CATIVExpiryDate;
						rotarySystem.RigCertificatesId = RigCertificates.Id;
						rotarySystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.RotarySystem.Add(rotarySystem);
					}

					var RigCertificatesMudCirculationSystem = MudCirculationSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesMudCirculationSystem)
					{
						MudCirculationSystemDTO mudCirculationSystem = new MudCirculationSystemDTO();
						mudCirculationSystem.Id = item.Id;
						mudCirculationSystem.Equipment = item.Equipment;
						mudCirculationSystem.SerialNumber = item.SerialNumber;
						mudCirculationSystem.COCAvailabilty = item.COCAvailabilty;
						mudCirculationSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						mudCirculationSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						mudCirculationSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						mudCirculationSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						mudCirculationSystem.RigCertificatesId = RigCertificates.Id;
						mudCirculationSystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.MudCirculationSystem.Add(mudCirculationSystem);
					}

					var RigCertificatesWellControlSystem = WellControlSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesWellControlSystem)
					{
						WellControlSystemDTO wellControlSystem = new WellControlSystemDTO();
						wellControlSystem.Id = item.Id;
						wellControlSystem.Equipment = item.Equipment;
						wellControlSystem.SerialNumber = item.SerialNumber;
						wellControlSystem.COCAvailabilty = item.COCAvailabilty;
						wellControlSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						wellControlSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						wellControlSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						wellControlSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						wellControlSystem.RigCertificatesId = RigCertificates.Id;
						wellControlSystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.WellControlSystem.Add(wellControlSystem);
					}

					var RigCertificatesPowerSystem = PowerSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesPowerSystem)
					{
						PowerSystemDTO powerSystem = new PowerSystemDTO();
						powerSystem.Id = item.Id;
						powerSystem.Equipment = item.Equipment;
						powerSystem.SerialNumber = item.SerialNumber;
						powerSystem.COCAvailabilty = item.COCAvailabilty;
						powerSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						powerSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						powerSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						powerSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						powerSystem.RigCertificatesId = RigCertificates.Id;
						powerSystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.PowerSystem.Add(powerSystem);
					}

					var RigCertificatesOtherSystem = OtherSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesOtherSystem)
					{
						OtherSystemDTO otherSystem = new OtherSystemDTO();
						otherSystem.Id = item.Id;
						otherSystem.Item = item.Item;
						otherSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						otherSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						otherSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						otherSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						otherSystem.RigCertificatesId = RigCertificates.Id;
						otherSystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.OtherSystem.Add(otherSystem);
					}

					var RigCertificatesMobileCrane = MobileCraneRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesMobileCrane.Any())
					{
						foreach (var item in RigCertificatesMobileCrane)
						{
							MobileCraneDTO mobileCrane = new MobileCraneDTO();
							mobileCrane.Id = item.Id;
							mobileCrane.Model = item.Model;
							mobileCrane.Type = item.Type;
							mobileCrane.ChassisNo = item.ChassisNo;
							mobileCrane.HookSerialNo = item.HookSerialNo;
							mobileCrane.Capacity = item.Capacity;
							mobileCrane.ManufactureDate = item.ManufactureDate;
							mobileCrane.LastExaminationDate = item.LastExaminationDate;
							mobileCrane.NextExaminationDate = item.NextExaminationDate;
							mobileCrane.RigCertificatesId = item.RigCertificatesId;
							mobileCrane.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.MobileCrane.Add(mobileCrane);
						}
					}


					var RigCertificatesForklift = ForkliftRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesForklift.Any())
					{
						foreach (var item in RigCertificatesForklift)
						{
							RigCertForkliftDTO forklift = new RigCertForkliftDTO();
							forklift.Id = item.Id;
							forklift.Model = item.Model;
							forklift.Type = item.Type;
							forklift.SerialNo = item.SerialNo;
							forklift.Capacity = item.Capacity;
							forklift.LastExaminationDate = item.LastExaminationDate;
							forklift.NextExaminationDate = item.NextExaminationDate;
							forklift.RigCertificatesId = item.RigCertificatesId;
							forklift.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.Forklift.Add(forklift);
						}
					}


					var RigCertificatesAirHoist = AirHoistRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesAirHoist.Any())
					{
						foreach (var item in RigCertificatesAirHoist)
						{
							AirHoistDTO airHoist = new AirHoistDTO();
							airHoist.Id = item.Id;
							airHoist.SerialNo = item.SerialNo;
							airHoist.WireSize = item.WireSize;
							airHoist.Capacity = item.Capacity;
							airHoist.WireInspectionDueDate = item.WireInspectionDueDate;
							airHoist.LastMPIInspectionDate = item.LastMPIInspectionDate;
							airHoist.NextMPIInspectionDate = item.NextMPIInspectionDate;
							airHoist.NextLoadTestDate = item.NextLoadTestDate;
							airHoist.RigCertificatesId = item.RigCertificatesId;
							airHoist.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.AirHoist.Add(airHoist);
						}
					}


					var RigCertificatesHydraulicWinch = HydraulicWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesHydraulicWinch.Any())
					{
						foreach (var item in RigCertificatesHydraulicWinch)
						{
							HydraulicWinchDTO hydraulicWinch = new HydraulicWinchDTO();
							hydraulicWinch.Id = item.Id;
							hydraulicWinch.SerialNo = item.SerialNo;
							hydraulicWinch.WireSize = item.WireSize;
							hydraulicWinch.Capacity = item.Capacity;
							hydraulicWinch.WireInspectionDueDate = item.WireInspectionDueDate;
							hydraulicWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
							hydraulicWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
							hydraulicWinch.NextLoadTestDate = item.NextLoadTestDate;
							hydraulicWinch.RigCertificatesId = item.RigCertificatesId;
							hydraulicWinch.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.HydraulicWinch.Add(hydraulicWinch);
						}
					}

					var RigCertificatesManRidingWinch = ManRidingWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesManRidingWinch.Any())
					{
						foreach (var item in RigCertificatesManRidingWinch)
						{
							ManRidingWinchDTO manRidingWinch = new ManRidingWinchDTO();
							manRidingWinch.Id = item.Id;
							manRidingWinch.SerialNo = item.SerialNo;
							manRidingWinch.WireSize = item.WireSize;
							manRidingWinch.Capacity = item.Capacity;
							manRidingWinch.WireInspectionDueDate = item.WireInspectionDueDate;
							manRidingWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
							manRidingWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
							manRidingWinch.NextLoadTestDate = item.NextLoadTestDate;
							manRidingWinch.RigCertificatesId = item.RigCertificatesId;
							manRidingWinch.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.ManRidingWinch.Add(manRidingWinch);
						}
					}

					result.Message = "Success";
					result.Data = RigCertificatesDTO;
					result.Statescode = 200;
					return result;

				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					RigCertificates RigCertificates = RigCertificatesRepo.getall().FirstOrDefault(a => a.Id == ID && a.userID == UserId);
					RigCertificatesDTO RigCertificatesDTO = new RigCertificatesDTO();
					RigCertificatesDTO.Id = RigCertificates.Id;
					RigCertificatesDTO.RigId = RigCertificates.RigId;
					RigCertificatesDTO.Date = RigCertificates.Date;
					RigCertificatesDTO.CertificationLiftingGear = RigCertificates.CertificationLiftingGear;
					RigCertificatesDTO.CertificationCATIII = RigCertificates.CertificationCATIII;
					RigCertificatesDTO.CertificationCATIV = RigCertificates.CertificationCATIV;
					RigCertificatesDTO.CertificationGaugeCalibraion = RigCertificates.CertificationGaugeCalibraion;
					RigCertificatesDTO.CertificationWallThickness = RigCertificates.CertificationWallThickness;
					RigCertificatesDTO.DueLiftingGear = RigCertificates.DueLiftingGear;
					RigCertificatesDTO.DueCATIII = RigCertificates.DueCATIII;
					RigCertificatesDTO.DueCATIV = RigCertificates.DueCATIV;
					RigCertificatesDTO.DueGaugeCalibraion = RigCertificates.DueGaugeCalibraion;
					RigCertificatesDTO.DueWallThickness = RigCertificates.DueWallThickness;
					RigCertificatesDTO.userID = RigCertificates.userID;
					RigCertificatesDTO.IsDeleted = RigCertificates.IsDeleted;

					var RigCertificatesPersonnelCerificates = PersonnelCerificatesRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesPersonnelCerificates.Any())
					{
						foreach (var item in RigCertificatesPersonnelCerificates)
						{
							PersonnelCerificatesDTO personnelCerificates = new PersonnelCerificatesDTO();
							personnelCerificates.Id = item.Id;
							personnelCerificates.Code = item.Code;
							personnelCerificates.Position = item.Position;
							personnelCerificates.Name = item.Name;
							personnelCerificates.CertificateType = item.CertificateType;
							personnelCerificates.CertificateDate = item.CertificateDate;
							personnelCerificates.ExpiryDate = item.ExpiryDate;
							personnelCerificates.RigCertificatesId = RigCertificates.Id;
							personnelCerificates.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.PersonnelCerificates.Add(personnelCerificates);
						}
					}

					var RigCertificatesHSEEquipmentTable = HSEEquipmentTableRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesHSEEquipmentTable.Any())
					{
						foreach (var item in RigCertificatesHSEEquipmentTable)
						{
							HSEEquipmentTableDTO hSEEquipmentTable = new HSEEquipmentTableDTO();
							hSEEquipmentTable.Id = item.Id;
							hSEEquipmentTable.EquipmentId = item.EquipmentId;
							hSEEquipmentTable.Model = item.Model;
							hSEEquipmentTable.SerialNumber = item.SerialNumber;
							hSEEquipmentTable.ExpiryDate = item.ExpiryDate;
							hSEEquipmentTable.RigCertificatesId = RigCertificates.Id;
							hSEEquipmentTable.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.HSEEquipmentTable.Add(hSEEquipmentTable);
						}
					}

					var RigCertificatesPresssureReliefValve = PresssureReliefValveRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesPresssureReliefValve.Any())
					{
						foreach (var item in RigCertificatesPresssureReliefValve)
						{
							PresssureReliefValveDTO presssureReliefValve = new PresssureReliefValveDTO();
							presssureReliefValve.Id = item.Id;
							presssureReliefValve.Valves = item.Valves;
							presssureReliefValve.Location = item.Location;
							presssureReliefValve.CertificationDate = item.CertificationDate;
							presssureReliefValve.ExpiryDate = item.ExpiryDate;
							presssureReliefValve.RigCertificatesId = RigCertificates.Id;
							presssureReliefValve.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.PresssureReliefValve.Add(presssureReliefValve);
						}
					}

					var RigCertificatesHoistingSystem = HoistingSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesHoistingSystem)
					{
						HoistingSystemDTO hoistingSystem = new HoistingSystemDTO();
						hoistingSystem.Id = item.Id;
						hoistingSystem.Equipment = item.Equipment;
						hoistingSystem.SerialNumber = item.SerialNumber;
						hoistingSystem.COCAvailabilty = item.COCAvailabilty;
						hoistingSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						hoistingSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						hoistingSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						hoistingSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						hoistingSystem.RigCertificatesId = RigCertificates.Id;
						hoistingSystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.HoistingSystem.Add(hoistingSystem);
					}

					var RigCertificatesRotarySystem = RotarySystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesRotarySystem)
					{
						RotarySystemDTO rotarySystem = new RotarySystemDTO();
						rotarySystem.Id = item.Id;
						rotarySystem.Equipment = item.Equipment;
						rotarySystem.SerialNumber = item.SerialNumber;
						rotarySystem.COCAvailabilty = item.COCAvailabilty;
						rotarySystem.CATIIICertificationDate = item.CATIIICertificationDate;
						rotarySystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						rotarySystem.CATIVCertificationDate = item.CATIVCertificationDate;
						rotarySystem.CATIVExpiryDate = item.CATIVExpiryDate;
						rotarySystem.RigCertificatesId = RigCertificates.Id;
						rotarySystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.RotarySystem.Add(rotarySystem);
					}

					var RigCertificatesMudCirculationSystem = MudCirculationSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesMudCirculationSystem)
					{
						MudCirculationSystemDTO mudCirculationSystem = new MudCirculationSystemDTO();
						mudCirculationSystem.Id = item.Id;
						mudCirculationSystem.Equipment = item.Equipment;
						mudCirculationSystem.SerialNumber = item.SerialNumber;
						mudCirculationSystem.COCAvailabilty = item.COCAvailabilty;
						mudCirculationSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						mudCirculationSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						mudCirculationSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						mudCirculationSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						mudCirculationSystem.RigCertificatesId = RigCertificates.Id;
						mudCirculationSystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.MudCirculationSystem.Add(mudCirculationSystem);
					}

					var RigCertificatesWellControlSystem = WellControlSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesWellControlSystem)
					{
						WellControlSystemDTO wellControlSystem = new WellControlSystemDTO();
						wellControlSystem.Id = item.Id;
						wellControlSystem.Equipment = item.Equipment;
						wellControlSystem.SerialNumber = item.SerialNumber;
						wellControlSystem.COCAvailabilty = item.COCAvailabilty;
						wellControlSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						wellControlSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						wellControlSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						wellControlSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						wellControlSystem.RigCertificatesId = RigCertificates.Id;
						wellControlSystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.WellControlSystem.Add(wellControlSystem);
					}

					var RigCertificatesPowerSystem = PowerSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesPowerSystem)
					{
						PowerSystemDTO powerSystem = new PowerSystemDTO();
						powerSystem.Id = item.Id;
						powerSystem.Equipment = item.Equipment;
						powerSystem.SerialNumber = item.SerialNumber;
						powerSystem.COCAvailabilty = item.COCAvailabilty;
						powerSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						powerSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						powerSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						powerSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						powerSystem.RigCertificatesId = RigCertificates.Id;
						powerSystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.PowerSystem.Add(powerSystem);
					}

					var RigCertificatesOtherSystem = OtherSystemRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					foreach (var item in RigCertificatesOtherSystem)
					{
						OtherSystemDTO otherSystem = new OtherSystemDTO();
						otherSystem.Id = item.Id;
						otherSystem.Item = item.Item;
						otherSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						otherSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						otherSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						otherSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						otherSystem.RigCertificatesId = RigCertificates.Id;
						otherSystem.IsDeleted = item.IsDeleted;
						RigCertificatesDTO.OtherSystem.Add(otherSystem);
					}

					var RigCertificatesMobileCrane = MobileCraneRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesMobileCrane.Any())
					{
						foreach (var item in RigCertificatesMobileCrane)
						{
							MobileCraneDTO mobileCrane = new MobileCraneDTO();
							mobileCrane.Id = item.Id;
							mobileCrane.Model = item.Model;
							mobileCrane.Type = item.Type;
							mobileCrane.ChassisNo = item.ChassisNo;
							mobileCrane.HookSerialNo = item.HookSerialNo;
							mobileCrane.Capacity = item.Capacity;
							mobileCrane.ManufactureDate = item.ManufactureDate;
							mobileCrane.LastExaminationDate = item.LastExaminationDate;
							mobileCrane.NextExaminationDate = item.NextExaminationDate;
							mobileCrane.RigCertificatesId = item.RigCertificatesId;
							mobileCrane.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.MobileCrane.Add(mobileCrane);
						}
					}


					var RigCertificatesForklift = ForkliftRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesForklift.Any())
					{
						foreach (var item in RigCertificatesForklift)
						{
							RigCertForkliftDTO forklift = new RigCertForkliftDTO();
							forklift.Id = item.Id;
							forklift.Model = item.Model;
							forklift.Type = item.Type;
							forklift.SerialNo = item.SerialNo;
							forklift.Capacity = item.Capacity;
							forklift.LastExaminationDate = item.LastExaminationDate;
							forklift.NextExaminationDate = item.NextExaminationDate;
							forklift.RigCertificatesId = item.RigCertificatesId;
							forklift.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.Forklift.Add(forklift);
						}
					}


					var RigCertificatesAirHoist = AirHoistRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesAirHoist.Any())
					{
						foreach (var item in RigCertificatesAirHoist)
						{
							AirHoistDTO airHoist = new AirHoistDTO();
							airHoist.Id = item.Id;
							airHoist.SerialNo = item.SerialNo;
							airHoist.WireSize = item.WireSize;
							airHoist.Capacity = item.Capacity;
							airHoist.WireInspectionDueDate = item.WireInspectionDueDate;
							airHoist.LastMPIInspectionDate = item.LastMPIInspectionDate;
							airHoist.NextMPIInspectionDate = item.NextMPIInspectionDate;
							airHoist.NextLoadTestDate = item.NextLoadTestDate;
							airHoist.RigCertificatesId = item.RigCertificatesId;
							airHoist.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.AirHoist.Add(airHoist);
						}
					}


					var RigCertificatesHydraulicWinch = HydraulicWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesHydraulicWinch.Any())
					{
						foreach (var item in RigCertificatesHydraulicWinch)
						{
							HydraulicWinchDTO hydraulicWinch = new HydraulicWinchDTO();
							hydraulicWinch.Id = item.Id;
							hydraulicWinch.SerialNo = item.SerialNo;
							hydraulicWinch.WireSize = item.WireSize;
							hydraulicWinch.Capacity = item.Capacity;
							hydraulicWinch.WireInspectionDueDate = item.WireInspectionDueDate;
							hydraulicWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
							hydraulicWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
							hydraulicWinch.NextLoadTestDate = item.NextLoadTestDate;
							hydraulicWinch.RigCertificatesId = item.RigCertificatesId;
							hydraulicWinch.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.HydraulicWinch.Add(hydraulicWinch);
						}
					}

					var RigCertificatesManRidingWinch = ManRidingWinchRepo.getall().Where(p => p.RigCertificatesId == RigCertificates.Id).ToList();
					if (RigCertificatesManRidingWinch.Any())
					{
						foreach (var item in RigCertificatesManRidingWinch)
						{
							ManRidingWinchDTO manRidingWinch = new ManRidingWinchDTO();
							manRidingWinch.Id = item.Id;
							manRidingWinch.SerialNo = item.SerialNo;
							manRidingWinch.WireSize = item.WireSize;
							manRidingWinch.Capacity = item.Capacity;
							manRidingWinch.WireInspectionDueDate = item.WireInspectionDueDate;
							manRidingWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
							manRidingWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
							manRidingWinch.NextLoadTestDate = item.NextLoadTestDate;
							manRidingWinch.RigCertificatesId = item.RigCertificatesId;
							manRidingWinch.IsDeleted = item.IsDeleted;
							RigCertificatesDTO.ManRidingWinch.Add(manRidingWinch);
						}
					}

					result.Message = "Success";
					result.Data = RigCertificatesDTO;
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
		public ActionResult<ResultDTO> AddRigCertificates(RigCertificatesDTO RigCertificatesDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					RigCertificates RigCertificates = new RigCertificates();
					RigCertificates.Id = default;
					RigCertificates.RigId = RigCertificatesDTO.RigId;
					RigCertificates.Date = RigCertificatesDTO.Date;
					RigCertificates.CertificationLiftingGear = RigCertificatesDTO.CertificationLiftingGear;
					RigCertificates.CertificationCATIII = RigCertificatesDTO.CertificationCATIII;
					RigCertificates.CertificationCATIV = RigCertificatesDTO.CertificationCATIV;
					RigCertificates.CertificationGaugeCalibraion = RigCertificatesDTO.CertificationGaugeCalibraion;
					RigCertificates.CertificationWallThickness = RigCertificatesDTO.CertificationWallThickness;
					RigCertificates.DueLiftingGear = RigCertificatesDTO.DueLiftingGear;
					RigCertificates.DueCATIII = RigCertificatesDTO.DueCATIII;
					RigCertificates.DueCATIV = RigCertificatesDTO.DueCATIV;
					RigCertificates.DueGaugeCalibraion = RigCertificatesDTO.DueGaugeCalibraion;
					RigCertificates.DueWallThickness = RigCertificatesDTO.DueWallThickness;
					RigCertificates.userID = RigCertificatesDTO.userID;

					RigCertificatesRepo.create(RigCertificates);

					if (RigCertificatesDTO.HSEEquipmentTable.Any())
					{
						foreach (var item in RigCertificatesDTO.HSEEquipmentTable)
						{
							HSEEquipmentTable hSEEquipmentTable = new HSEEquipmentTable();
							hSEEquipmentTable.EquipmentId = item.EquipmentId;
							hSEEquipmentTable.Model = item.Model;
							hSEEquipmentTable.SerialNumber = item.SerialNumber;
							hSEEquipmentTable.ExpiryDate = item.ExpiryDate;
							hSEEquipmentTable.RigCertificatesId = RigCertificates.Id;
							hSEEquipmentTable.IsDeleted = item.IsDeleted;
							HSEEquipmentTableRepo.create(hSEEquipmentTable);
						}
					}
					if (RigCertificatesDTO.PersonnelCerificates.Any())
					{
						foreach (var item in RigCertificatesDTO.PersonnelCerificates)
						{
							PersonnelCerificates personnelCerificates = new PersonnelCerificates();
							personnelCerificates.Code = item.Code;
							personnelCerificates.Position = item.Position;
							personnelCerificates.Name = item.Name;
							personnelCerificates.CertificateType = item.CertificateType;
							personnelCerificates.CertificateDate = item.CertificateDate;
							personnelCerificates.ExpiryDate = item.ExpiryDate;
							personnelCerificates.RigCertificatesId = RigCertificates.Id;
							personnelCerificates.IsDeleted = item.IsDeleted;
							PersonnelCerificatesRepo.create(personnelCerificates);
						}
					}
					if (RigCertificatesDTO.PresssureReliefValve.Any())
					{
						foreach (var item in RigCertificatesDTO.PresssureReliefValve)
						{
							PresssureReliefValve presssureReliefValve = new PresssureReliefValve();
							presssureReliefValve.Valves = item.Valves;
							presssureReliefValve.Location = item.Location;
							presssureReliefValve.CertificationDate = item.CertificationDate;
							presssureReliefValve.ExpiryDate = item.ExpiryDate;
							presssureReliefValve.RigCertificatesId = RigCertificates.Id;
							presssureReliefValve.IsDeleted = item.IsDeleted;
							PresssureReliefValveRepo.create(presssureReliefValve);
						}
					}
					foreach (var item in RigCertificatesDTO.HoistingSystem)
					{
						HoistingSystem hoistingSystem = new HoistingSystem();
						hoistingSystem.Equipment = item.Equipment;
						hoistingSystem.SerialNumber = item.SerialNumber;
						hoistingSystem.COCAvailabilty = item.COCAvailabilty;
						hoistingSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						hoistingSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						hoistingSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						hoistingSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						hoistingSystem.RigCertificatesId = RigCertificates.Id;
						hoistingSystem.IsDeleted = item.IsDeleted;
						HoistingSystemRepo.create(hoistingSystem);
					}
					foreach (var item in RigCertificatesDTO.RotarySystem)
					{
						RotarySystem rotarySystem = new RotarySystem();
						rotarySystem.Equipment = item.Equipment;
						rotarySystem.SerialNumber = item.SerialNumber;
						rotarySystem.COCAvailabilty = item.COCAvailabilty;
						rotarySystem.CATIIICertificationDate = item.CATIIICertificationDate;
						rotarySystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						rotarySystem.CATIVCertificationDate = item.CATIVCertificationDate;
						rotarySystem.CATIVExpiryDate = item.CATIVExpiryDate;
						rotarySystem.RigCertificatesId = RigCertificates.Id;
						rotarySystem.IsDeleted = item.IsDeleted;
						RotarySystemRepo.create(rotarySystem);
					}
					foreach (var item in RigCertificatesDTO.MudCirculationSystem)
					{
						MudCirculationSystem mudCirculationSystem = new MudCirculationSystem();
						mudCirculationSystem.Equipment = item.Equipment;
						mudCirculationSystem.SerialNumber = item.SerialNumber;
						mudCirculationSystem.COCAvailabilty = item.COCAvailabilty;
						mudCirculationSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						mudCirculationSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						mudCirculationSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						mudCirculationSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						mudCirculationSystem.RigCertificatesId = RigCertificates.Id;
						mudCirculationSystem.IsDeleted = item.IsDeleted;
						MudCirculationSystemRepo.create(mudCirculationSystem);
					}
					foreach (var item in RigCertificatesDTO.WellControlSystem)
					{
						WellControlSystem wellControlSystem = new WellControlSystem();
						wellControlSystem.Equipment = item.Equipment;
						wellControlSystem.SerialNumber = item.SerialNumber;
						wellControlSystem.COCAvailabilty = item.COCAvailabilty;
						wellControlSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						wellControlSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						wellControlSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						wellControlSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						wellControlSystem.RigCertificatesId = RigCertificates.Id;
						wellControlSystem.IsDeleted = item.IsDeleted;
						WellControlSystemRepo.create(wellControlSystem);
					}
					foreach (var item in RigCertificatesDTO.PowerSystem)
					{
						PowerSystem powerSystem = new PowerSystem();
						powerSystem.Equipment = item.Equipment;
						powerSystem.SerialNumber = item.SerialNumber;
						powerSystem.COCAvailabilty = item.COCAvailabilty;
						powerSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						powerSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						powerSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						powerSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						powerSystem.RigCertificatesId = RigCertificates.Id;
						powerSystem.IsDeleted = item.IsDeleted;
						PowerSystemRepo.create(powerSystem);
					}
					foreach (var item in RigCertificatesDTO.OtherSystem)
					{
						OtherSystem otherSystem = new OtherSystem();
						otherSystem.Item = item.Item;
						otherSystem.CATIIICertificationDate = item.CATIIICertificationDate;
						otherSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
						otherSystem.CATIVCertificationDate = item.CATIVCertificationDate;
						otherSystem.CATIVExpiryDate = item.CATIVExpiryDate;
						otherSystem.RigCertificatesId = RigCertificates.Id;
						otherSystem.IsDeleted = item.IsDeleted;
						OtherSystemRepo.create(otherSystem);
					}
					if (RigCertificatesDTO.MobileCrane.Any())
					{
						foreach(var item in RigCertificatesDTO.MobileCrane)
						{
							MobileCrane mobileCrane = new MobileCrane();
							mobileCrane.Model = item.Model;
							mobileCrane.Type = item.Type;
							mobileCrane.ChassisNo = item.ChassisNo;
							mobileCrane.HookSerialNo = item.HookSerialNo;
							mobileCrane.Capacity = item.Capacity;
							mobileCrane.ManufactureDate = item.ManufactureDate;
							mobileCrane.LastExaminationDate = item.LastExaminationDate;
							mobileCrane.NextExaminationDate = item.NextExaminationDate;
							mobileCrane.RigCertificatesId = RigCertificates.Id;
							mobileCrane.IsDeleted = item.IsDeleted;
							MobileCraneRepo.create(mobileCrane);
						}
					}
					if (RigCertificatesDTO.Forklift.Any())
					{
						foreach (var item in RigCertificatesDTO.Forklift)
						{
							RigCertForklift forklift = new RigCertForklift();
							forklift.Model = item.Model;
							forklift.Type = item.Type;
							forklift.SerialNo = item.SerialNo;
							forklift.Capacity = item.Capacity;
							forklift.LastExaminationDate = item.LastExaminationDate;
							forklift.NextExaminationDate = item.NextExaminationDate;
							forklift.RigCertificatesId = RigCertificates.Id;
							forklift.IsDeleted = item.IsDeleted;
							ForkliftRepo.create(forklift);
						}
					}
					if (RigCertificatesDTO.AirHoist.Any())
					{
						foreach (var item in RigCertificatesDTO.AirHoist)
						{
							AirHoist airHoist = new AirHoist();
							airHoist.SerialNo = item.SerialNo;
							airHoist.WireSize = item.WireSize;
							airHoist.Capacity = item.Capacity;
							airHoist.WireInspectionDueDate = item.WireInspectionDueDate;
							airHoist.LastMPIInspectionDate = item.LastMPIInspectionDate;
							airHoist.NextMPIInspectionDate = item.NextMPIInspectionDate;
							airHoist.NextLoadTestDate = item.NextLoadTestDate;
							airHoist.RigCertificatesId = RigCertificates.Id;
							airHoist.IsDeleted = item.IsDeleted;
							AirHoistRepo.create(airHoist);
						}
					}
					if (RigCertificatesDTO.HydraulicWinch.Any())
					{
						foreach (var item in RigCertificatesDTO.HydraulicWinch)
						{
							HydraulicWinch hydraulicWinch = new HydraulicWinch();
							hydraulicWinch.SerialNo = item.SerialNo;
							hydraulicWinch.WireSize = item.WireSize;
							hydraulicWinch.Capacity = item.Capacity;
							hydraulicWinch.WireInspectionDueDate = item.WireInspectionDueDate;
							hydraulicWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
							hydraulicWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
							hydraulicWinch.NextLoadTestDate = item.NextLoadTestDate;
							hydraulicWinch.RigCertificatesId = RigCertificates.Id;
							hydraulicWinch.IsDeleted = item.IsDeleted;
							HydraulicWinchRepo.create(hydraulicWinch);
						}
					}
					if (RigCertificatesDTO.ManRidingWinch.Any())
					{
						foreach (var item in RigCertificatesDTO.ManRidingWinch)
						{
							ManRidingWinch manRidingWinch = new ManRidingWinch();
							manRidingWinch.SerialNo = item.SerialNo;
							manRidingWinch.WireSize = item.WireSize;
							manRidingWinch.Capacity = item.Capacity;
							manRidingWinch.WireInspectionDueDate = item.WireInspectionDueDate;
							manRidingWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
							manRidingWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
							manRidingWinch.NextLoadTestDate = item.NextLoadTestDate;
							manRidingWinch.RigCertificatesId = RigCertificates.Id;
							manRidingWinch.IsDeleted = item.IsDeleted;
							ManRidingWinchRepo.create(manRidingWinch);
						}
					}

					result.Message = "Success";
					result.Data = RigCertificates;
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
		public ActionResult<ResultDTO> Put(int id, RigCertificatesDTO newRigCertificates) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					RigCertificates orgRigCertificates = RigCertificatesRepo.getbyid(id);
					orgRigCertificates.RigId = newRigCertificates.RigId;
					orgRigCertificates.Date = newRigCertificates.Date;
					orgRigCertificates.CertificationLiftingGear = newRigCertificates.CertificationLiftingGear;
					orgRigCertificates.CertificationCATIII = newRigCertificates.CertificationCATIII;
					orgRigCertificates.CertificationCATIV = newRigCertificates.CertificationCATIV;
					orgRigCertificates.CertificationGaugeCalibraion = newRigCertificates.CertificationGaugeCalibraion;
					orgRigCertificates.CertificationWallThickness = newRigCertificates.CertificationWallThickness;
					orgRigCertificates.DueLiftingGear = newRigCertificates.DueLiftingGear;
					orgRigCertificates.DueCATIII = newRigCertificates.DueCATIII;
					orgRigCertificates.DueCATIV = newRigCertificates.DueCATIV;
					orgRigCertificates.DueGaugeCalibraion = newRigCertificates.DueGaugeCalibraion;
					orgRigCertificates.DueWallThickness = newRigCertificates.DueWallThickness;
					//orgRigCertificates.userID = newRigCertificates.userID;
					orgRigCertificates.IsDeleted = newRigCertificates.IsDeleted;

					RigCertificatesRepo.update(orgRigCertificates);

					var oldPersonalCertificates = PersonnelCerificatesRepo.getall().Where(o => o.RigCertificatesId == id).ToList();
					if (oldPersonalCertificates.Any())
					{
						if (oldPersonalCertificates.Count == newRigCertificates.PersonnelCerificates.Count)
						{
							for (int i = 0; i < oldPersonalCertificates.Count(); i++)
							{
								var OldItem = oldPersonalCertificates[i];
								var newItem = newRigCertificates.PersonnelCerificates[i];

								OldItem.Code = newItem.Code;
								OldItem.Position = newItem.Position;
								OldItem.Name = newItem.Name;
								OldItem.CertificateType = newItem.CertificateType;
								OldItem.CertificateDate = newItem.CertificateDate;
								OldItem.ExpiryDate = newItem.ExpiryDate;
								OldItem.RigCertificatesId = id;
								PersonnelCerificatesRepo.update(OldItem);
							}
						}
						else
						{
							foreach (var item in oldPersonalCertificates)
							{
								PersonnelCerificatesRepo.delete(item);
							}
							foreach (var item in newRigCertificates.PersonnelCerificates)
							{
								PersonnelCerificates personnelCerificates = new PersonnelCerificates();
								personnelCerificates.Code = item.Code;
								personnelCerificates.Position = item.Position;
								personnelCerificates.Name = item.Name;
								personnelCerificates.CertificateType = item.CertificateType;
								personnelCerificates.CertificateDate = item.CertificateDate;
								personnelCerificates.ExpiryDate = item.ExpiryDate;
								personnelCerificates.RigCertificatesId = id;
								personnelCerificates.IsDeleted = item.IsDeleted;
								PersonnelCerificatesRepo.create(personnelCerificates);
							}
						}
					}
					else
					{
						foreach (var item in newRigCertificates.PersonnelCerificates)
						{
							PersonnelCerificates personnelCerificates = new PersonnelCerificates();
							personnelCerificates.Code = item.Code;
							personnelCerificates.Position = item.Position;
							personnelCerificates.Name = item.Name;
							personnelCerificates.CertificateType = item.CertificateType;
							personnelCerificates.CertificateDate = item.CertificateDate;
							personnelCerificates.ExpiryDate = item.ExpiryDate;
							personnelCerificates.RigCertificatesId = id;
							personnelCerificates.IsDeleted = item.IsDeleted;
							PersonnelCerificatesRepo.create(personnelCerificates);
						}
					}
					
					var oldPresssureReliefValve = PresssureReliefValveRepo.getall().Where(o => o.RigCertificatesId == id).ToList();
					if (oldPresssureReliefValve.Any())
					{
						if (oldPresssureReliefValve.Count == newRigCertificates.PresssureReliefValve.Count)
						{
							for (int i = 0; i < oldPresssureReliefValve.Count(); i++)
							{
								var OldItem = oldPresssureReliefValve[i];
								var newItem = newRigCertificates.PresssureReliefValve[i];

								OldItem.Valves = newItem.Valves;
								OldItem.Location = newItem.Location;
								OldItem.CertificationDate = newItem.CertificationDate;
								OldItem.ExpiryDate = newItem.ExpiryDate;
								OldItem.RigCertificatesId = id;
								PresssureReliefValveRepo.update(OldItem);
							}
						}
						else
						{
							foreach (var item in oldPresssureReliefValve)
							{
								PresssureReliefValveRepo.delete(item);
							}
							foreach (var item in newRigCertificates.PresssureReliefValve)
							{
								PresssureReliefValve presssureReliefValve = new PresssureReliefValve();
								presssureReliefValve.Valves = item.Valves;
								presssureReliefValve.Location = item.Location;
								presssureReliefValve.CertificationDate = item.CertificationDate;
								presssureReliefValve.ExpiryDate = item.ExpiryDate;
								presssureReliefValve.RigCertificatesId = orgRigCertificates.Id;
								presssureReliefValve.IsDeleted = item.IsDeleted;
								PresssureReliefValveRepo.create(presssureReliefValve);
							}
						}
					}
					else 
					{ 
							foreach (var item in newRigCertificates.PresssureReliefValve)
							{
								PresssureReliefValve presssureReliefValve = new PresssureReliefValve();
								presssureReliefValve.Valves = item.Valves;
								presssureReliefValve.Location = item.Location;
								presssureReliefValve.CertificationDate = item.CertificationDate;
								presssureReliefValve.ExpiryDate = item.ExpiryDate;
								presssureReliefValve.RigCertificatesId = orgRigCertificates.Id;
								presssureReliefValve.IsDeleted = item.IsDeleted;
								PresssureReliefValveRepo.create(presssureReliefValve);
							}
					}

					var oldHSEEquipmentTable = HSEEquipmentTableRepo.getall().Where(o => o.RigCertificatesId == id).ToList();
					if (oldHSEEquipmentTable.Any())
					{
						if (oldHSEEquipmentTable.Count == newRigCertificates.HSEEquipmentTable.Count)
						{
							for (int i = 0; i < oldHSEEquipmentTable.Count(); i++)
							{
								var OldItem = oldHSEEquipmentTable[i];
								var newItem = newRigCertificates.HSEEquipmentTable[i];

								OldItem.EquipmentId = newItem.EquipmentId;
								OldItem.Model = newItem.Model;
								OldItem.SerialNumber = newItem.SerialNumber;
								OldItem.ExpiryDate = newItem.ExpiryDate;
								OldItem.RigCertificatesId = id;
								HSEEquipmentTableRepo.update(OldItem);
							}
						}
						else
						{
							foreach (var item in oldHSEEquipmentTable)
							{
								HSEEquipmentTableRepo.delete(item);
							}
							foreach (var item in newRigCertificates.HSEEquipmentTable)
							{
								HSEEquipmentTable hSEEquipmentTable = new HSEEquipmentTable();
								hSEEquipmentTable.EquipmentId = item.EquipmentId;
								hSEEquipmentTable.Model = item.Model;
								hSEEquipmentTable.SerialNumber = item.SerialNumber;
								hSEEquipmentTable.ExpiryDate = item.ExpiryDate;
								hSEEquipmentTable.RigCertificatesId = orgRigCertificates.Id;
								hSEEquipmentTable.IsDeleted = item.IsDeleted;
								HSEEquipmentTableRepo.create(hSEEquipmentTable);
							}
						}
					}
					else
					{
						foreach (var item in newRigCertificates.HSEEquipmentTable)
						{
							HSEEquipmentTable hSEEquipmentTable = new HSEEquipmentTable();
							hSEEquipmentTable.EquipmentId = item.EquipmentId;
							hSEEquipmentTable.Model = item.Model;
							hSEEquipmentTable.SerialNumber = item.SerialNumber;
							hSEEquipmentTable.ExpiryDate = item.ExpiryDate;
							hSEEquipmentTable.RigCertificatesId = orgRigCertificates.Id;
							hSEEquipmentTable.IsDeleted = item.IsDeleted;
							HSEEquipmentTableRepo.create(hSEEquipmentTable);
						}
					}

					var oldHoistingSystem = HoistingSystemRepo.getall().Where(o => o.RigCertificatesId == id).ToList();
					if (oldHoistingSystem.Count == newRigCertificates.HoistingSystem.Count)
					{
						for (int i = 0; i < oldHoistingSystem.Count(); i++)
						{
							var OldItem = oldHoistingSystem[i];
							var newItem = newRigCertificates.HoistingSystem[i];

							OldItem.Equipment = newItem.Equipment;
							OldItem.SerialNumber = newItem.SerialNumber;
							OldItem.COCAvailabilty = newItem.COCAvailabilty;
							OldItem.CATIIICertificationDate = newItem.CATIIICertificationDate;
							OldItem.CATIIIExpiryDate = newItem.CATIIIExpiryDate;
							OldItem.CATIVCertificationDate = newItem.CATIVCertificationDate;
							OldItem.CATIVExpiryDate = newItem.CATIVExpiryDate;
							OldItem.RigCertificatesId = id;
							HoistingSystemRepo.update(OldItem);
						}
					}
					else
					{
						foreach (var item in oldHoistingSystem)
						{
							HoistingSystemRepo.delete(item);
						}
						foreach (var item in newRigCertificates.HoistingSystem)
						{
							HoistingSystem hoistingSystem = new HoistingSystem();
							hoistingSystem.Equipment = item.Equipment;
							hoistingSystem.SerialNumber = item.SerialNumber;
							hoistingSystem.COCAvailabilty = item.COCAvailabilty;
							hoistingSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							hoistingSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							hoistingSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							hoistingSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							hoistingSystem.RigCertificatesId = id;
							hoistingSystem.IsDeleted = item.IsDeleted;
							HoistingSystemRepo.create(hoistingSystem);
						}
					}

					var oldRotarySystem = RotarySystemRepo.getall().Where(o => o.RigCertificatesId == id).ToList();
					if (oldRotarySystem.Count == newRigCertificates.RotarySystem.Count)
					{
						for (int i = 0; i < oldRotarySystem.Count(); i++)
						{
							var OldItem = oldRotarySystem[i];
							var newItem = newRigCertificates.RotarySystem[i];

							OldItem.Equipment = newItem.Equipment;
							OldItem.SerialNumber = newItem.SerialNumber;
							OldItem.COCAvailabilty = newItem.COCAvailabilty;
							OldItem.CATIIICertificationDate = newItem.CATIIICertificationDate;
							OldItem.CATIIIExpiryDate = newItem.CATIIIExpiryDate;
							OldItem.CATIVCertificationDate = newItem.CATIVCertificationDate;
							OldItem.CATIVExpiryDate = newItem.CATIVExpiryDate;
							OldItem.RigCertificatesId = id;
							RotarySystemRepo.update(OldItem);
						}
					}
					else
					{
						foreach (var item in oldRotarySystem)
						{
							RotarySystemRepo.delete(item);
						}
						foreach (var item in newRigCertificates.RotarySystem)
						{
							RotarySystem rotarySystem = new RotarySystem();
							rotarySystem.Equipment = item.Equipment;
							rotarySystem.SerialNumber = item.SerialNumber;
							rotarySystem.COCAvailabilty = item.COCAvailabilty;
							rotarySystem.CATIIICertificationDate = item.CATIIICertificationDate;
							rotarySystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							rotarySystem.CATIVCertificationDate = item.CATIVCertificationDate;
							rotarySystem.CATIVExpiryDate = item.CATIVExpiryDate;
							rotarySystem.RigCertificatesId = id;
							rotarySystem.IsDeleted = item.IsDeleted;
							RotarySystemRepo.create(rotarySystem);
						}
					}

					var oldMudCirculationSystem = MudCirculationSystemRepo.getall().Where(o => o.RigCertificatesId == id).ToList();
					if (oldMudCirculationSystem.Count == newRigCertificates.MudCirculationSystem.Count)
					{
						for (int i = 0; i < oldMudCirculationSystem.Count(); i++)
						{
							var OldItem = oldMudCirculationSystem[i];
							var newItem = newRigCertificates.MudCirculationSystem[i];

							OldItem.Equipment = newItem.Equipment;
							OldItem.SerialNumber = newItem.SerialNumber;
							OldItem.COCAvailabilty = newItem.COCAvailabilty;
							OldItem.CATIIICertificationDate = newItem.CATIIICertificationDate;
							OldItem.CATIIIExpiryDate = newItem.CATIIIExpiryDate;
							OldItem.CATIVCertificationDate = newItem.CATIVCertificationDate;
							OldItem.CATIVExpiryDate = newItem.CATIVExpiryDate;
							OldItem.RigCertificatesId = id;
							MudCirculationSystemRepo.update(OldItem);
						}
					}
					else
					{
						foreach (var item in oldMudCirculationSystem)
						{
							MudCirculationSystemRepo.delete(item);
						}
						foreach (var item in newRigCertificates.MudCirculationSystem)
						{
							MudCirculationSystem mudCirculationSystem = new MudCirculationSystem();
							mudCirculationSystem.Equipment = item.Equipment;
							mudCirculationSystem.SerialNumber = item.SerialNumber;
							mudCirculationSystem.COCAvailabilty = item.COCAvailabilty;
							mudCirculationSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							mudCirculationSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							mudCirculationSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							mudCirculationSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							mudCirculationSystem.RigCertificatesId = id;
							mudCirculationSystem.IsDeleted = item.IsDeleted;
							MudCirculationSystemRepo.create(mudCirculationSystem);
						}
					}

					var oldWellControlSystem = WellControlSystemRepo.getall().Where(o => o.RigCertificatesId == id).ToList();
					if (oldWellControlSystem.Count == newRigCertificates.WellControlSystem.Count)
					{
						for (int i = 0; i < oldWellControlSystem.Count(); i++)
						{
							var OldItem = oldWellControlSystem[i];
							var newItem = newRigCertificates.WellControlSystem[i];

							OldItem.Equipment = newItem.Equipment;
							OldItem.SerialNumber = newItem.SerialNumber;
							OldItem.COCAvailabilty = newItem.COCAvailabilty;
							OldItem.CATIIICertificationDate = newItem.CATIIICertificationDate;
							OldItem.CATIIIExpiryDate = newItem.CATIIIExpiryDate;
							OldItem.CATIVCertificationDate = newItem.CATIVCertificationDate;
							OldItem.CATIVExpiryDate = newItem.CATIVExpiryDate;
							OldItem.RigCertificatesId = id;
							WellControlSystemRepo.update(OldItem);
						}
					}
					else
					{
						foreach (var item in oldWellControlSystem)
						{
							WellControlSystemRepo.delete(item);
						}
						foreach (var item in newRigCertificates.WellControlSystem)
						{
							WellControlSystem wellControlSystem = new WellControlSystem();
							wellControlSystem.Equipment = item.Equipment;
							wellControlSystem.SerialNumber = item.SerialNumber;
							wellControlSystem.COCAvailabilty = item.COCAvailabilty;
							wellControlSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							wellControlSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							wellControlSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							wellControlSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							wellControlSystem.RigCertificatesId = id;
							wellControlSystem.IsDeleted = item.IsDeleted;
							WellControlSystemRepo.create(wellControlSystem);
						}
					}

					var oldPowerSystem = PowerSystemRepo.getall().Where(o => o.RigCertificatesId == id).ToList();
					if (oldPowerSystem.Count == newRigCertificates.PowerSystem.Count)
					{
						for (int i = 0; i < oldPowerSystem.Count(); i++)
						{
							var OldItem = oldPowerSystem[i];
							var newItem = newRigCertificates.PowerSystem[i];

							OldItem.Equipment = newItem.Equipment;
							OldItem.SerialNumber = newItem.SerialNumber;
							OldItem.COCAvailabilty = newItem.COCAvailabilty;
							OldItem.CATIIICertificationDate = newItem.CATIIICertificationDate;
							OldItem.CATIIIExpiryDate = newItem.CATIIIExpiryDate;
							OldItem.CATIVCertificationDate = newItem.CATIVCertificationDate;
							OldItem.CATIVExpiryDate = newItem.CATIVExpiryDate;
							OldItem.RigCertificatesId = id;
							PowerSystemRepo.update(OldItem);
						}
					}
					else
					{
						foreach (var item in oldPowerSystem)
						{
							PowerSystemRepo.delete(item);
						}
						foreach (var item in newRigCertificates.PowerSystem)
						{
							PowerSystem powerSystem = new PowerSystem();
							powerSystem.Equipment = item.Equipment;
							powerSystem.SerialNumber = item.SerialNumber;
							powerSystem.COCAvailabilty = item.COCAvailabilty;
							powerSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							powerSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							powerSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							powerSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							powerSystem.RigCertificatesId = id;
							powerSystem.IsDeleted = item.IsDeleted;
							PowerSystemRepo.create(powerSystem);
						}
					}

					var oldOtherSystem = OtherSystemRepo.getall().Where(o => o.RigCertificatesId == id).ToList();
					if (oldOtherSystem.Count == newRigCertificates.OtherSystem.Count)
					{
						for (int i = 0; i < oldOtherSystem.Count(); i++)
						{
							var OldItem = oldOtherSystem[i];
							var newItem = newRigCertificates.OtherSystem[i];

							OldItem.Item = newItem.Item;
							OldItem.CATIIICertificationDate = newItem.CATIIICertificationDate;
							OldItem.CATIIIExpiryDate = newItem.CATIIIExpiryDate;
							OldItem.CATIVCertificationDate = newItem.CATIVCertificationDate;
							OldItem.CATIVExpiryDate = newItem.CATIVExpiryDate;
							OldItem.RigCertificatesId = id;
							OtherSystemRepo.update(OldItem);
						}
					}
					else
					{
						foreach (var item in oldOtherSystem)
						{
							OtherSystemRepo.delete(item);
						}
						foreach (var item in newRigCertificates.OtherSystem)
						{
							OtherSystem otherSystem = new OtherSystem();
							otherSystem.Item = item.Item;
							otherSystem.CATIIICertificationDate = item.CATIIICertificationDate;
							otherSystem.CATIIIExpiryDate = item.CATIIIExpiryDate;
							otherSystem.CATIVCertificationDate = item.CATIVCertificationDate;
							otherSystem.CATIVExpiryDate = item.CATIVExpiryDate;
							otherSystem.RigCertificatesId = id;
							otherSystem.IsDeleted = item.IsDeleted;
							OtherSystemRepo.create(otherSystem);
						}
					}

					var oldMobileCrane = MobileCraneRepo.getall().Where(o => o.RigCertificatesId == id).ToList();
					if (oldMobileCrane.Any())
					{
						if (oldMobileCrane.Count == newRigCertificates.MobileCrane.Count)
						{
							for (int i = 0; i < oldMobileCrane.Count(); i++)
							{
								var OldItem = oldMobileCrane[i];
								var newItem = newRigCertificates.MobileCrane[i];

								OldItem.Model = newItem.Model;
								OldItem.Type = newItem.Type;
								OldItem.ChassisNo = newItem.ChassisNo;
								OldItem.HookSerialNo = newItem.HookSerialNo;
								OldItem.Capacity = newItem.Capacity;
								OldItem.ManufactureDate = newItem.ManufactureDate;
								OldItem.LastExaminationDate = newItem.LastExaminationDate;
								OldItem.NextExaminationDate = newItem.NextExaminationDate;
								OldItem.RigCertificatesId = id;
								OldItem.IsDeleted = newItem.IsDeleted;
								MobileCraneRepo.update(OldItem);
							}
						}
						else
						{
							foreach (var item in oldMobileCrane)
							{
								MobileCraneRepo.delete(item);
							}
							foreach (var item in newRigCertificates.MobileCrane)
							{
								MobileCrane mobileCrane = new MobileCrane();
								mobileCrane.Model = item.Model;
								mobileCrane.Type = item.Type;
								mobileCrane.ChassisNo = item.ChassisNo;
								mobileCrane.HookSerialNo = item.HookSerialNo;
								mobileCrane.Capacity = item.Capacity;
								mobileCrane.ManufactureDate = item.ManufactureDate;
								mobileCrane.LastExaminationDate = item.LastExaminationDate;
								mobileCrane.NextExaminationDate = item.NextExaminationDate;
								mobileCrane.RigCertificatesId = id;
								mobileCrane.IsDeleted = item.IsDeleted;
								MobileCraneRepo.create(mobileCrane);
							}
						}
					}
					else
					{
						foreach (var item in newRigCertificates.MobileCrane)
						{
							MobileCrane mobileCrane = new MobileCrane();
							mobileCrane.Model = item.Model;
							mobileCrane.Type = item.Type;
							mobileCrane.ChassisNo = item.ChassisNo;
							mobileCrane.HookSerialNo = item.HookSerialNo;
							mobileCrane.Capacity = item.Capacity;
							mobileCrane.ManufactureDate = item.ManufactureDate;
							mobileCrane.LastExaminationDate = item.LastExaminationDate;
							mobileCrane.NextExaminationDate = item.NextExaminationDate;
							mobileCrane.RigCertificatesId = id;
							mobileCrane.IsDeleted = item.IsDeleted;
							MobileCraneRepo.create(mobileCrane);
						}
					}


					var oldForklift = ForkliftRepo.getall().Where(o => o.RigCertificatesId == id).ToList();
					if (oldForklift.Any())
					{
						if (oldForklift.Count == newRigCertificates.Forklift.Count)
						{
							for (int i = 0; i < oldForklift.Count(); i++)
							{
								var OldItem = oldForklift[i];
								var newItem = newRigCertificates.Forklift[i];

								OldItem.Model = newItem.Model;
								OldItem.Type = newItem.Type;
								OldItem.SerialNo = newItem.SerialNo;
								OldItem.Capacity = newItem.Capacity;
								OldItem.LastExaminationDate = newItem.LastExaminationDate;
								OldItem.NextExaminationDate = newItem.NextExaminationDate;
								OldItem.RigCertificatesId = id;
								OldItem.IsDeleted = newItem.IsDeleted;

								ForkliftRepo.update(OldItem);
							}
						}
						else
						{
							foreach (var item in oldForklift)
							{
								ForkliftRepo.delete(item);
							}
							foreach (var item in newRigCertificates.Forklift)
							{
								RigCertForklift forklift = new RigCertForklift();
								forklift.Model = item.Model;
								forklift.Type = item.Type;
								forklift.SerialNo = item.SerialNo;
								forklift.Capacity = item.Capacity;
								forklift.LastExaminationDate = item.LastExaminationDate;
								forklift.NextExaminationDate = item.NextExaminationDate;
								forklift.RigCertificatesId = id;
								forklift.IsDeleted = item.IsDeleted;
								ForkliftRepo.create(forklift);
							}
						}
					}
					else
					{
						foreach (var item in newRigCertificates.Forklift)
						{
							RigCertForklift forklift = new RigCertForklift();
							forklift.Model = item.Model;
							forklift.Type = item.Type;
							forklift.SerialNo = item.SerialNo;
							forklift.Capacity = item.Capacity;
							forklift.LastExaminationDate = item.LastExaminationDate;
							forklift.NextExaminationDate = item.NextExaminationDate;
							forklift.RigCertificatesId = id;
							forklift.IsDeleted = item.IsDeleted;
							ForkliftRepo.create(forklift);
						}
					}

					var oldAirHoist = AirHoistRepo.getall().Where(o => o.RigCertificatesId == id).ToList();
					if (oldAirHoist.Any())
					{
						if (oldAirHoist.Count == newRigCertificates.AirHoist.Count)
						{
							for (int i = 0; i < oldAirHoist.Count(); i++)
							{
								var OldItem = oldAirHoist[i];
								var newItem = newRigCertificates.AirHoist[i];

								OldItem.SerialNo = newItem.SerialNo;
								OldItem.WireSize = newItem.WireSize;
								OldItem.Capacity = newItem.Capacity;
								OldItem.WireInspectionDueDate = newItem.WireInspectionDueDate;
								OldItem.LastMPIInspectionDate = newItem.LastMPIInspectionDate;
								OldItem.NextMPIInspectionDate = newItem.NextMPIInspectionDate;
								OldItem.NextLoadTestDate = newItem.NextLoadTestDate;
								OldItem.RigCertificatesId = id;
								OldItem.IsDeleted = newItem.IsDeleted;
								AirHoistRepo.update(OldItem);
							}
						}
						else
						{
							foreach (var item in oldAirHoist)
							{
								AirHoistRepo.delete(item);
							}
							foreach (var item in newRigCertificates.AirHoist)
							{
								AirHoist airHoist = new AirHoist();
								airHoist.SerialNo = item.SerialNo;
								airHoist.WireSize = item.WireSize;
								airHoist.Capacity = item.Capacity;
								airHoist.WireInspectionDueDate = item.WireInspectionDueDate;
								airHoist.LastMPIInspectionDate = item.LastMPIInspectionDate;
								airHoist.NextMPIInspectionDate = item.NextMPIInspectionDate;
								airHoist.NextLoadTestDate = item.NextLoadTestDate;
								airHoist.RigCertificatesId = id;
								airHoist.IsDeleted = item.IsDeleted;
								AirHoistRepo.create(airHoist);
							}
						}
					}
					else
					{
						foreach (var item in newRigCertificates.AirHoist)
						{
							AirHoist airHoist = new AirHoist();
							airHoist.SerialNo = item.SerialNo;
							airHoist.WireSize = item.WireSize;
							airHoist.Capacity = item.Capacity;
							airHoist.WireInspectionDueDate = item.WireInspectionDueDate;
							airHoist.LastMPIInspectionDate = item.LastMPIInspectionDate;
							airHoist.NextMPIInspectionDate = item.NextMPIInspectionDate;
							airHoist.NextLoadTestDate = item.NextLoadTestDate;
							airHoist.RigCertificatesId = id;
							airHoist.IsDeleted = item.IsDeleted;
							AirHoistRepo.create(airHoist);
						}
					}

					var oldHydraulicWinch = HydraulicWinchRepo.getall().Where(o => o.RigCertificatesId == id).ToList();
					if (oldHydraulicWinch.Any())
					{
						if (oldHydraulicWinch.Count == newRigCertificates.HydraulicWinch.Count)
						{
							for (int i = 0; i < oldHydraulicWinch.Count(); i++)
							{
								var OldItem = oldHydraulicWinch[i];
								var newItem = newRigCertificates.HydraulicWinch[i];

								OldItem.SerialNo = newItem.SerialNo;
								OldItem.WireSize = newItem.WireSize;
								OldItem.Capacity = newItem.Capacity;
								OldItem.WireInspectionDueDate = newItem.WireInspectionDueDate;
								OldItem.LastMPIInspectionDate = newItem.LastMPIInspectionDate;
								OldItem.NextMPIInspectionDate = newItem.NextMPIInspectionDate;
								OldItem.NextLoadTestDate = newItem.NextLoadTestDate;
								OldItem.RigCertificatesId = id;
								OldItem.IsDeleted = newItem.IsDeleted;
								HydraulicWinchRepo.update(OldItem);
							}
						}
						else
						{
							foreach (var item in oldHydraulicWinch)
							{
								HydraulicWinchRepo.delete(item);
							}
							foreach (var item in newRigCertificates.HydraulicWinch)
							{
								HydraulicWinch hydraulicWinch = new HydraulicWinch();
								hydraulicWinch.SerialNo = item.SerialNo;
								hydraulicWinch.WireSize = item.WireSize;
								hydraulicWinch.Capacity = item.Capacity;
								hydraulicWinch.WireInspectionDueDate = item.WireInspectionDueDate;
								hydraulicWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
								hydraulicWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
								hydraulicWinch.NextLoadTestDate = item.NextLoadTestDate;
								hydraulicWinch.RigCertificatesId = id;
								hydraulicWinch.IsDeleted = item.IsDeleted;
								HydraulicWinchRepo.create(hydraulicWinch);
							}
						}
					}
					else
					{
						foreach (var item in newRigCertificates.HydraulicWinch)
						{
							HydraulicWinch hydraulicWinch = new HydraulicWinch();
							hydraulicWinch.SerialNo = item.SerialNo;
							hydraulicWinch.WireSize = item.WireSize;
							hydraulicWinch.Capacity = item.Capacity;
							hydraulicWinch.WireInspectionDueDate = item.WireInspectionDueDate;
							hydraulicWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
							hydraulicWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
							hydraulicWinch.NextLoadTestDate = item.NextLoadTestDate;
							hydraulicWinch.RigCertificatesId = id;
							hydraulicWinch.IsDeleted = item.IsDeleted;
							HydraulicWinchRepo.create(hydraulicWinch);
						}
					}

					var oldManRidingWinch = ManRidingWinchRepo.getall().Where(o => o.RigCertificatesId == id).ToList();
					if (oldManRidingWinch.Any())
					{
						if (oldManRidingWinch.Count == newRigCertificates.ManRidingWinch.Count)
						{
							for (int i = 0; i < oldManRidingWinch.Count(); i++)
							{
								var OldItem = oldManRidingWinch[i];
								var newItem = newRigCertificates.ManRidingWinch[i];

								OldItem.SerialNo = newItem.SerialNo;
								OldItem.WireSize = newItem.WireSize;
								OldItem.Capacity = newItem.Capacity;
								OldItem.WireInspectionDueDate = newItem.WireInspectionDueDate;
								OldItem.LastMPIInspectionDate = newItem.LastMPIInspectionDate;
								OldItem.NextMPIInspectionDate = newItem.NextMPIInspectionDate;
								OldItem.NextLoadTestDate = newItem.NextLoadTestDate;
								OldItem.RigCertificatesId = id;
								OldItem.IsDeleted = newItem.IsDeleted;
								ManRidingWinchRepo.update(OldItem);
							}
						}
						else
						{
							foreach (var item in oldManRidingWinch)
							{
								ManRidingWinchRepo.delete(item);
							}
							foreach (var item in newRigCertificates.ManRidingWinch)
							{
								ManRidingWinch manRidingWinch = new ManRidingWinch();
								manRidingWinch.SerialNo = item.SerialNo;
								manRidingWinch.WireSize = item.WireSize;
								manRidingWinch.Capacity = item.Capacity;
								manRidingWinch.WireInspectionDueDate = item.WireInspectionDueDate;
								manRidingWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
								manRidingWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
								manRidingWinch.NextLoadTestDate = item.NextLoadTestDate;
								manRidingWinch.RigCertificatesId = id;
								manRidingWinch.IsDeleted = item.IsDeleted;
								ManRidingWinchRepo.create(manRidingWinch);
							}
						}
					}
					else
					{
						foreach (var item in newRigCertificates.ManRidingWinch)
						{
							ManRidingWinch manRidingWinch = new ManRidingWinch();
							manRidingWinch.SerialNo = item.SerialNo;
							manRidingWinch.WireSize = item.WireSize;
							manRidingWinch.Capacity = item.Capacity;
							manRidingWinch.WireInspectionDueDate = item.WireInspectionDueDate;
							manRidingWinch.LastMPIInspectionDate = item.LastMPIInspectionDate;
							manRidingWinch.NextMPIInspectionDate = item.NextMPIInspectionDate;
							manRidingWinch.NextLoadTestDate = item.NextLoadTestDate;
							manRidingWinch.RigCertificatesId = id;
							manRidingWinch.IsDeleted = item.IsDeleted;
							ManRidingWinchRepo.create(manRidingWinch);
						}
					}

					result.Data = orgRigCertificates;
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
				List<MudCirculationSystem> MudCirculationSystem = MudCirculationSystemRepo.getall().Where(p => p.RigCertificatesId == id).ToList();
				if (MudCirculationSystem.Any())
				{
					foreach (var item in MudCirculationSystem)
					{
						MudCirculationSystem mudCirculationSystem = MudCirculationSystemRepo.getbyid(item.Id);

						mudCirculationSystem.IsDeleted = true;

						MudCirculationSystemRepo.update(mudCirculationSystem);
					}
				}

				List<HoistingSystem> HoistingSystem = HoistingSystemRepo.getall().Where(p => p.RigCertificatesId == id).ToList();
				if (HoistingSystem.Any())
				{
					foreach (var item in HoistingSystem)
					{
						HoistingSystem hoistingSystem = HoistingSystemRepo.getbyid(item.Id);

						hoistingSystem.IsDeleted = true;

						HoistingSystemRepo.update(hoistingSystem);
					}
				}

				List<RotarySystem> RotarySystem = RotarySystemRepo.getall().Where(p => p.RigCertificatesId == id).ToList();
				if (RotarySystem.Any())
				{
					foreach (var item in RotarySystem)
					{
						RotarySystem rotarySystem = RotarySystemRepo.getbyid(item.Id);

						rotarySystem.IsDeleted = true;

						RotarySystemRepo.update(rotarySystem);
					}
				}

				List<WellControlSystem> WellControlSystems = WellControlSystemRepo.getall().Where(p => p.RigCertificatesId == id).ToList();
				if (WellControlSystems.Any())
				{
					foreach (var item in WellControlSystems)
					{
						WellControlSystem wellControlSystem = WellControlSystemRepo.getbyid(item.Id);

						wellControlSystem.IsDeleted = true;

						WellControlSystemRepo.update(wellControlSystem);
					}
				}

				List<PowerSystem> PowerSystem = PowerSystemRepo.getall().Where(p => p.RigCertificatesId == id).ToList();
				if (PowerSystem.Any())
				{
					foreach (var item in PowerSystem)
					{
						PowerSystem powerSystem = PowerSystemRepo.getbyid(item.Id);
						powerSystem.IsDeleted = true;
						PowerSystemRepo.update(powerSystem);
					}
				}

				List<OtherSystem> OtherSystem = OtherSystemRepo.getall().Where(p => p.RigCertificatesId == id).ToList();
				if (OtherSystem.Any())
				{
					foreach (var item in OtherSystem)
					{
						OtherSystem otherSystem = OtherSystemRepo.getbyid(item.Id);

						otherSystem.IsDeleted = true;

						OtherSystemRepo.update(otherSystem);
					}
				}

				List<HSEEquipmentTable> HSEEquipmentTable = HSEEquipmentTableRepo.getall().Where(p => p.RigCertificatesId == id).ToList();
				if (HSEEquipmentTable.Any())
				{
					foreach (var item in HSEEquipmentTable)
					{
						HSEEquipmentTable hseEquipmentTable = HSEEquipmentTableRepo.getbyid(item.Id);

						hseEquipmentTable.IsDeleted = true;

						HSEEquipmentTableRepo.update(hseEquipmentTable);
					}
				}

				List<PresssureReliefValve> PresssureReliefValves = PresssureReliefValveRepo.getall().Where(p => p.RigCertificatesId == id).ToList();
				if (PresssureReliefValves.Any())
				{
					foreach (var item in PresssureReliefValves)
					{
						PresssureReliefValve presssureReliefValve = PresssureReliefValveRepo.getbyid(item.Id);

						presssureReliefValve.IsDeleted = true;

						PresssureReliefValveRepo.update(presssureReliefValve);
					}
				}

				List<PersonnelCerificates> PersonnelCerificates = PersonnelCerificatesRepo.getall().Where(p => p.RigCertificatesId == id).ToList();
				if (PersonnelCerificates.Any())
				{
					foreach (var item in PersonnelCerificates)
					{
						PersonnelCerificates personnelCerificates = PersonnelCerificatesRepo.getbyid(item.Id);

						personnelCerificates.IsDeleted = true;

						PersonnelCerificatesRepo.update(personnelCerificates);
					}
				}

				List<MobileCrane> MobileCrane = MobileCraneRepo.getall().Where(p => p.RigCertificatesId == id).ToList();
				if (MobileCrane.Any())
				{
					foreach (var item in MobileCrane)
					{
						MobileCrane mobileCrane = MobileCraneRepo.getbyid(item.Id);

						mobileCrane.IsDeleted = true;

						MobileCraneRepo.update(mobileCrane);
					}
				}

		
				List<RigCertForklift> Forklift = ForkliftRepo.getall().Where(p => p.RigCertificatesId == id).ToList();
				if (Forklift.Any())
				{
					foreach (var item in PersonnelCerificates)
					{
						RigCertForklift forklift = ForkliftRepo.getbyid(item.Id);

						forklift.IsDeleted = true;

						ForkliftRepo.update(forklift);
					}
				}

				List<AirHoist> AirHoist = AirHoistRepo.getall().Where(p => p.RigCertificatesId == id).ToList();
				if (AirHoist.Any())
				{
					foreach (var item in AirHoist)
					{
						AirHoist airHoist = AirHoistRepo.getbyid(item.Id);

						airHoist.IsDeleted = true;

						AirHoistRepo.update(airHoist);
					}
				}

				List<HydraulicWinch> HydraulicWinch = HydraulicWinchRepo.getall().Where(p => p.RigCertificatesId == id).ToList();
				if (HydraulicWinch.Any())
				{
					foreach (var item in HydraulicWinch)
					{
						HydraulicWinch hydraulicWinch = HydraulicWinchRepo.getbyid(item.Id);

						hydraulicWinch.IsDeleted = true;

						HydraulicWinchRepo.update(hydraulicWinch);
					}
				}



				List<ManRidingWinch> ManRidingWinch = ManRidingWinchRepo.getall().Where(p => p.RigCertificatesId == id).ToList();
				if (ManRidingWinch.Any())
				{
					foreach (var item in ManRidingWinch)
					{
						ManRidingWinch manRidingWinch = ManRidingWinchRepo.getbyid(item.Id);

						manRidingWinch.IsDeleted = true;

						ManRidingWinchRepo.update(manRidingWinch);
					}
				}

				RigCertificates rigCertificates = RigCertificatesRepo.getbyid(id);
				rigCertificates.IsDeleted = true;
				RigCertificatesRepo.update(rigCertificates);

				result.Data = rigCertificates;
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
