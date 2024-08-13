using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TempProject.DTO;
using TempProject.DTO.ResponseDTO;
using TempProject.Helper;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WeeklyInspectionController : ControllerBase
	{
		public IRepository<WeeklyInspection> WeeklyInspectionRepo { get; set; }

		public IWeeklyInspectionRepository WeeklyInspectionRepository { get; set; }

		private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager;


		public WeeklyInspectionController(Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager,
			IRepository<WeeklyInspection> _WeeklyInspectionRepo,
			IWeeklyInspectionRepository _WeeklyInspectionRepoistory)

		{
			this.WeeklyInspectionRepo = _WeeklyInspectionRepo;
			this.WeeklyInspectionRepository = _WeeklyInspectionRepoistory;
			this.userManager = _userManager;

		}

		[HttpGet("GetData")]
		public async Task<ResultDTO> GetAllWithData(string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<WeeklyInspection> temp = WeeklyInspectionRepository.getall();
					List<WeeklyInspectionResponseDTO> newTemp = new List<WeeklyInspectionResponseDTO>();
					foreach (WeeklyInspection weeklyInspection in temp)
					{
						WeeklyInspectionResponseDTO weeklyInspectionResponseDTO = new WeeklyInspectionResponseDTO();
						weeklyInspectionResponseDTO.Id = weeklyInspection.Id;
						weeklyInspectionResponseDTO.RigId = weeklyInspection.Rig.Number;
						weeklyInspectionResponseDTO.Date = weeklyInspection.Date;
						weeklyInspectionResponseDTO.WellName = weeklyInspection.WellName;
						weeklyInspectionResponseDTO.Client = weeklyInspection.Client;
						weeklyInspectionResponseDTO.EyeStatus = weeklyInspection.EyeStatus;
						weeklyInspectionResponseDTO.EyeWeeklyFindings = weeklyInspection.EyeWeeklyFindings;
						weeklyInspectionResponseDTO.FirstAidStatus = weeklyInspection.FirstAidStatus;
						weeklyInspectionResponseDTO.FirstAidWeeklyFindings = weeklyInspection.FirstAidWeeklyFindings;
						weeklyInspectionResponseDTO.ScbaStatus = weeklyInspection.ScbaStatus;
						weeklyInspectionResponseDTO.ScbaWeeklyFindings = weeklyInspection.ScbaWeeklyFindings;
						weeklyInspectionResponseDTO.Scba30min = weeklyInspection.Scba30min;
						weeklyInspectionResponseDTO.Scba15min = weeklyInspection.Scba15min;
						weeklyInspectionResponseDTO.Scba10min = weeklyInspection.Scba10min;
						weeklyInspectionResponseDTO.PortableGasStatus = weeklyInspection.PortableGasStatus;
						weeklyInspectionResponseDTO.PortableGasWeeklyFindings = weeklyInspection.PortableGasWeeklyFindings;
						weeklyInspectionResponseDTO.PortableGasMuti = weeklyInspection.PortableGasMuti;
						weeklyInspectionResponseDTO.PortableGasSingle = weeklyInspection.PortableGasSingle;
						weeklyInspectionResponseDTO.ExpeiryDate = weeklyInspection.ExpeiryDate;
						weeklyInspectionResponseDTO.FireExtinguishersWeeklyFindings = weeklyInspection.FireExtinguishersWeeklyFindings;
						weeklyInspectionResponseDTO.FireExtinguishersStatus = weeklyInspection.FireExtinguishersStatus;
						weeklyInspectionResponseDTO.SmokeWeeklyFindings = weeklyInspection.SmokeWeeklyFindings;
						weeklyInspectionResponseDTO.SmokeStatus = weeklyInspection.SmokeStatus;
						weeklyInspectionResponseDTO.WindWeeklyFindings = weeklyInspection.WindWeeklyFindings;
						weeklyInspectionResponseDTO.WindStatus = weeklyInspection.WindStatus;
						weeklyInspectionResponseDTO.FirePumpWeeklyFindings = weeklyInspection.FirePumpWeeklyFindings;
						weeklyInspectionResponseDTO.FirePumpStatus = weeklyInspection.FirePumpStatus;
						weeklyInspectionResponseDTO.DerrickmanStatus = weeklyInspection.DerrickmanStatus;
						weeklyInspectionResponseDTO.DerrickmanWeeklyFindings = weeklyInspection.DerrickmanWeeklyFindings;
						weeklyInspectionResponseDTO.WorkingStatus = weeklyInspection.WorkingStatus;
						weeklyInspectionResponseDTO.WorkingWeeklyFindings = weeklyInspection.WorkingWeeklyFindings;
						weeklyInspectionResponseDTO.PortableLadderStatus = weeklyInspection.PortableLadderStatus;
						weeklyInspectionResponseDTO.PortableLadderWeeklyFindings = weeklyInspection.PortableLadderWeeklyFindings;
						weeklyInspectionResponseDTO.SafetyStatus = weeklyInspection.SafetyStatus;
						weeklyInspectionResponseDTO.SafetyWeeklyFindings = weeklyInspection.SafetyWeeklyFindings;
						weeklyInspectionResponseDTO.FallStatus = weeklyInspection.FallStatus;
						weeklyInspectionResponseDTO.FallWeeklyFindings = weeklyInspection.FallWeeklyFindings;
						weeklyInspectionResponseDTO.CraneStatus = weeklyInspection.CraneStatus;
						weeklyInspectionResponseDTO.CraneWeeklyFindings = weeklyInspection.CraneWeeklyFindings;
						weeklyInspectionResponseDTO.ForkStatus = weeklyInspection.ForkStatus;
						weeklyInspectionResponseDTO.ForkWeeklyFindings = weeklyInspection.ForkWeeklyFindings;
						weeklyInspectionResponseDTO.DroppedInspectionStatus = weeklyInspection.DroppedInspectionStatus;
						weeklyInspectionResponseDTO.DroppedInspectionWeeklyFindings = weeklyInspection.DroppedInspectionWeeklyFindings;
						weeklyInspectionResponseDTO.ElectricalStatus = weeklyInspection.ElectricalStatus;
						weeklyInspectionResponseDTO.EarthingWeeklyFindings = weeklyInspection.EarthingWeeklyFindings;
						weeklyInspectionResponseDTO.EarthingMaximum = weeklyInspection.EarthingMaximum;
						weeklyInspectionResponseDTO.EarthingMin = weeklyInspection.EarthingMin;
						weeklyInspectionResponseDTO.Code = weeklyInspection.Code;
						weeklyInspectionResponseDTO.Name = weeklyInspection.Name;
						weeklyInspectionResponseDTO.PositionName = weeklyInspection.PositionName;
						weeklyInspectionResponseDTO.WeldingStatus = weeklyInspection.WeldingStatus;
						weeklyInspectionResponseDTO.WeldingWeeklyFindings = weeklyInspection.WeldingWeeklyFindings;
						weeklyInspectionResponseDTO.ElectricalWeeklyFindings = weeklyInspection.ElectricalWeeklyFindings;
						weeklyInspectionResponseDTO.CircuitStatus = weeklyInspection.CircuitStatus;
						weeklyInspectionResponseDTO.CircuitWeeklyFindings = weeklyInspection.CircuitWeeklyFindings;
						weeklyInspectionResponseDTO.EarthingStatus = weeklyInspection.EarthingStatus;

						weeklyInspectionResponseDTO.userName = weeklyInspection.user.UserName;
						weeklyInspectionResponseDTO.userID = weeklyInspection.user.Id;



						newTemp.Add(weeklyInspectionResponseDTO);
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

					List<WeeklyInspection> temp = WeeklyInspectionRepository.getall().Where(a => a.user.Id == UserID).ToList();
					List<WeeklyInspectionResponseDTO> newTemp = new List<WeeklyInspectionResponseDTO>();
					foreach (WeeklyInspection weeklyInspection in temp)
					{
						WeeklyInspectionResponseDTO weeklyInspectionResponseDTO = new WeeklyInspectionResponseDTO();
						weeklyInspectionResponseDTO.Id = weeklyInspection.Id;
						weeklyInspectionResponseDTO.RigId = weeklyInspection.Rig.Number;
						weeklyInspectionResponseDTO.Date = weeklyInspection.Date;
						weeklyInspectionResponseDTO.WellName = weeklyInspection.WellName;
						weeklyInspectionResponseDTO.Client = weeklyInspection.Client;
						weeklyInspectionResponseDTO.EyeStatus = weeklyInspection.EyeStatus;
						weeklyInspectionResponseDTO.EyeWeeklyFindings = weeklyInspection.EyeWeeklyFindings;
						weeklyInspectionResponseDTO.FirstAidStatus = weeklyInspection.FirstAidStatus;
						weeklyInspectionResponseDTO.FirstAidWeeklyFindings = weeklyInspection.FirstAidWeeklyFindings;
						weeklyInspectionResponseDTO.ScbaStatus = weeklyInspection.ScbaStatus;
						weeklyInspectionResponseDTO.ScbaWeeklyFindings = weeklyInspection.ScbaWeeklyFindings;
						weeklyInspectionResponseDTO.Scba30min = weeklyInspection.Scba30min;
						weeklyInspectionResponseDTO.Scba15min = weeklyInspection.Scba15min;
						weeklyInspectionResponseDTO.Scba10min = weeklyInspection.Scba10min;
						weeklyInspectionResponseDTO.PortableGasStatus = weeklyInspection.PortableGasStatus;
						weeklyInspectionResponseDTO.PortableGasWeeklyFindings = weeklyInspection.PortableGasWeeklyFindings;
						weeklyInspectionResponseDTO.PortableGasMuti = weeklyInspection.PortableGasMuti;
						weeklyInspectionResponseDTO.PortableGasSingle = weeklyInspection.PortableGasSingle;
						weeklyInspectionResponseDTO.ExpeiryDate = weeklyInspection.ExpeiryDate;
						weeklyInspectionResponseDTO.FireExtinguishersWeeklyFindings = weeklyInspection.FireExtinguishersWeeklyFindings;
						weeklyInspectionResponseDTO.FireExtinguishersStatus = weeklyInspection.FireExtinguishersStatus;
						weeklyInspectionResponseDTO.SmokeWeeklyFindings = weeklyInspection.SmokeWeeklyFindings;
						weeklyInspectionResponseDTO.SmokeStatus = weeklyInspection.SmokeStatus;
						weeklyInspectionResponseDTO.WindWeeklyFindings = weeklyInspection.WindWeeklyFindings;
						weeklyInspectionResponseDTO.WindStatus = weeklyInspection.WindStatus;
						weeklyInspectionResponseDTO.FirePumpWeeklyFindings = weeklyInspection.FirePumpWeeklyFindings;
						weeklyInspectionResponseDTO.FirePumpStatus = weeklyInspection.FirePumpStatus;
						weeklyInspectionResponseDTO.DerrickmanStatus = weeklyInspection.DerrickmanStatus;
						weeklyInspectionResponseDTO.DerrickmanWeeklyFindings = weeklyInspection.DerrickmanWeeklyFindings;
						weeklyInspectionResponseDTO.WorkingStatus = weeklyInspection.WorkingStatus;
						weeklyInspectionResponseDTO.WorkingWeeklyFindings = weeklyInspection.WorkingWeeklyFindings;
						weeklyInspectionResponseDTO.PortableLadderStatus = weeklyInspection.PortableLadderStatus;
						weeklyInspectionResponseDTO.PortableLadderWeeklyFindings = weeklyInspection.PortableLadderWeeklyFindings;
						weeklyInspectionResponseDTO.SafetyStatus = weeklyInspection.SafetyStatus;
						weeklyInspectionResponseDTO.SafetyWeeklyFindings = weeklyInspection.SafetyWeeklyFindings;
						weeklyInspectionResponseDTO.FallStatus = weeklyInspection.FallStatus;
						weeklyInspectionResponseDTO.FallWeeklyFindings = weeklyInspection.FallWeeklyFindings;
						weeklyInspectionResponseDTO.CraneStatus = weeklyInspection.CraneStatus;
						weeklyInspectionResponseDTO.CraneWeeklyFindings = weeklyInspection.CraneWeeklyFindings;
						weeklyInspectionResponseDTO.ForkStatus = weeklyInspection.ForkStatus;
						weeklyInspectionResponseDTO.ForkWeeklyFindings = weeklyInspection.ForkWeeklyFindings;
						weeklyInspectionResponseDTO.DroppedInspectionStatus = weeklyInspection.DroppedInspectionStatus;
						weeklyInspectionResponseDTO.DroppedInspectionWeeklyFindings = weeklyInspection.DroppedInspectionWeeklyFindings;
						weeklyInspectionResponseDTO.ElectricalStatus = weeklyInspection.ElectricalStatus;
						weeklyInspectionResponseDTO.EarthingWeeklyFindings = weeklyInspection.EarthingWeeklyFindings;
						weeklyInspectionResponseDTO.EarthingMaximum = weeklyInspection.EarthingMaximum;
						weeklyInspectionResponseDTO.EarthingMin = weeklyInspection.EarthingMin;
						weeklyInspectionResponseDTO.Code = weeklyInspection.Code;
						weeklyInspectionResponseDTO.Name = weeklyInspection.Name;
						weeklyInspectionResponseDTO.PositionName = weeklyInspection.PositionName;


						weeklyInspectionResponseDTO.WeldingStatus = weeklyInspection.WeldingStatus;
						weeklyInspectionResponseDTO.WeldingWeeklyFindings = weeklyInspection.WeldingWeeklyFindings;
						weeklyInspectionResponseDTO.ElectricalWeeklyFindings = weeklyInspection.ElectricalWeeklyFindings;
						weeklyInspectionResponseDTO.CircuitStatus = weeklyInspection.CircuitStatus;
						weeklyInspectionResponseDTO.CircuitWeeklyFindings = weeklyInspection.CircuitWeeklyFindings;
						weeklyInspectionResponseDTO.EarthingStatus = weeklyInspection.EarthingStatus;

						weeklyInspectionResponseDTO.userName = weeklyInspection.user.UserName;
						weeklyInspectionResponseDTO.userID = weeklyInspection.user.Id;



						newTemp.Add(weeklyInspectionResponseDTO);
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
					List<WeeklyInspection> temp = WeeklyInspectionRepository.getall();
					List<WeeklyInspectionExcelDTO> newTemp = new List<WeeklyInspectionExcelDTO>();
					foreach (WeeklyInspection weeklyInspection in temp)
					{
						WeeklyInspectionExcelDTO weeklyInspectionResponseDTO = new WeeklyInspectionExcelDTO();
						weeklyInspectionResponseDTO.Id = weeklyInspection.Id;
						weeklyInspectionResponseDTO.RigId = weeklyInspection.Rig.Number;
						weeklyInspectionResponseDTO.Date = weeklyInspection.Date;
						weeklyInspectionResponseDTO.WellName = weeklyInspection.WellName;
						weeklyInspectionResponseDTO.Client = weeklyInspection.Client;
						weeklyInspectionResponseDTO.EyeStatus = weeklyInspection.EyeStatus;
						weeklyInspectionResponseDTO.EyeWeeklyFindings = weeklyInspection.EyeWeeklyFindings;
						weeklyInspectionResponseDTO.FirstAidStatus = weeklyInspection.FirstAidStatus;
						weeklyInspectionResponseDTO.FirstAidWeeklyFindings = weeklyInspection.FirstAidWeeklyFindings;
						weeklyInspectionResponseDTO.ScbaStatus = weeklyInspection.ScbaStatus;
						weeklyInspectionResponseDTO.ScbaWeeklyFindings = weeklyInspection.ScbaWeeklyFindings;
						weeklyInspectionResponseDTO.Scba30min = weeklyInspection.Scba30min;
						weeklyInspectionResponseDTO.Scba15min = weeklyInspection.Scba15min;
						weeklyInspectionResponseDTO.Scba10min = weeklyInspection.Scba10min;
						weeklyInspectionResponseDTO.PortableGasStatus = weeklyInspection.PortableGasStatus;
						weeklyInspectionResponseDTO.PortableGasWeeklyFindings = weeklyInspection.PortableGasWeeklyFindings;
						weeklyInspectionResponseDTO.PortableGasMuti = weeklyInspection.PortableGasMuti;
						weeklyInspectionResponseDTO.PortableGasSingle = weeklyInspection.PortableGasSingle;
						weeklyInspectionResponseDTO.ExpeiryDate = weeklyInspection.ExpeiryDate;
						weeklyInspectionResponseDTO.FireExtinguishersWeeklyFindings = weeklyInspection.FireExtinguishersWeeklyFindings;
						weeklyInspectionResponseDTO.FireExtinguishersStatus = weeklyInspection.FireExtinguishersStatus;
						weeklyInspectionResponseDTO.SmokeWeeklyFindings = weeklyInspection.SmokeWeeklyFindings;
						weeklyInspectionResponseDTO.SmokeStatus = weeklyInspection.SmokeStatus;
						weeklyInspectionResponseDTO.WindWeeklyFindings = weeklyInspection.WindWeeklyFindings;
						weeklyInspectionResponseDTO.WindStatus = weeklyInspection.WindStatus;
						weeklyInspectionResponseDTO.FirePumpWeeklyFindings = weeklyInspection.FirePumpWeeklyFindings;
						weeklyInspectionResponseDTO.FirePumpStatus = weeklyInspection.FirePumpStatus;
						weeklyInspectionResponseDTO.DerrickmanStatus = weeklyInspection.DerrickmanStatus;
						weeklyInspectionResponseDTO.DerrickmanWeeklyFindings = weeklyInspection.DerrickmanWeeklyFindings;
						weeklyInspectionResponseDTO.WorkingStatus = weeklyInspection.WorkingStatus;
						weeklyInspectionResponseDTO.WorkingWeeklyFindings = weeklyInspection.WorkingWeeklyFindings;
						weeklyInspectionResponseDTO.PortableLadderStatus = weeklyInspection.PortableLadderStatus;
						weeklyInspectionResponseDTO.PortableLadderWeeklyFindings = weeklyInspection.PortableLadderWeeklyFindings;
						weeklyInspectionResponseDTO.SafetyStatus = weeklyInspection.SafetyStatus;
						weeklyInspectionResponseDTO.SafetyWeeklyFindings = weeklyInspection.SafetyWeeklyFindings;
						weeklyInspectionResponseDTO.FallStatus = weeklyInspection.FallStatus;
						weeklyInspectionResponseDTO.FallWeeklyFindings = weeklyInspection.FallWeeklyFindings;
						weeklyInspectionResponseDTO.CraneStatus = weeklyInspection.CraneStatus;
						weeklyInspectionResponseDTO.CraneWeeklyFindings = weeklyInspection.CraneWeeklyFindings;
						weeklyInspectionResponseDTO.ForkStatus = weeklyInspection.ForkStatus;
						weeklyInspectionResponseDTO.ForkWeeklyFindings = weeklyInspection.ForkWeeklyFindings;
						weeklyInspectionResponseDTO.DroppedInspectionStatus = weeklyInspection.DroppedInspectionStatus;
						weeklyInspectionResponseDTO.DroppedInspectionWeeklyFindings = weeklyInspection.DroppedInspectionWeeklyFindings;
						weeklyInspectionResponseDTO.ElectricalStatus = weeklyInspection.ElectricalStatus;
						weeklyInspectionResponseDTO.EarthingWeeklyFindings = weeklyInspection.EarthingWeeklyFindings;
						weeklyInspectionResponseDTO.EarthingMaximum = (int)weeklyInspection.EarthingMaximum;
						weeklyInspectionResponseDTO.EarthingMin = (int)weeklyInspection.EarthingMin;
						weeklyInspectionResponseDTO.Code = weeklyInspection.Code;
						weeklyInspectionResponseDTO.Name = weeklyInspection.Name;
						weeklyInspectionResponseDTO.PositionName = weeklyInspection.PositionName;

						weeklyInspectionResponseDTO.WeldingStatus = weeklyInspection.WeldingStatus;
						weeklyInspectionResponseDTO.WeldingWeeklyFindings = weeklyInspection.WeldingWeeklyFindings;
						weeklyInspectionResponseDTO.ElectricalWeeklyFindings = weeklyInspection.ElectricalWeeklyFindings;
						weeklyInspectionResponseDTO.CircuitStatus = weeklyInspection.CircuitStatus;
						weeklyInspectionResponseDTO.CircuitWeeklyFindings = weeklyInspection.CircuitWeeklyFindings;
						weeklyInspectionResponseDTO.EarthingStatus = weeklyInspection.EarthingStatus;

						weeklyInspectionResponseDTO.userName = weeklyInspection.user.UserName;
						// weeklyInspectionResponseDTO.userID = weeklyInspection.user.Id;



						newTemp.Add(weeklyInspectionResponseDTO);
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
					List<WeeklyInspection> temp = WeeklyInspectionRepository.getall().Where(a => a.user.Id == UserID).ToList();
					List<WeeklyInspectionExcelDTO> newTemp = new List<WeeklyInspectionExcelDTO>();
					foreach (WeeklyInspection weeklyInspection in temp)
					{
						WeeklyInspectionExcelDTO weeklyInspectionResponseDTO = new WeeklyInspectionExcelDTO();
						weeklyInspectionResponseDTO.Id = weeklyInspection.Id;
						weeklyInspectionResponseDTO.RigId = weeklyInspection.Rig.Number;
						weeklyInspectionResponseDTO.Date = weeklyInspection.Date;
						weeklyInspectionResponseDTO.WellName = weeklyInspection.WellName;
						weeklyInspectionResponseDTO.Client = weeklyInspection.Client;
						weeklyInspectionResponseDTO.EyeStatus = weeklyInspection.EyeStatus;
						weeklyInspectionResponseDTO.EyeWeeklyFindings = weeklyInspection.EyeWeeklyFindings;
						weeklyInspectionResponseDTO.FirstAidStatus = weeklyInspection.FirstAidStatus;
						weeklyInspectionResponseDTO.FirstAidWeeklyFindings = weeklyInspection.FirstAidWeeklyFindings;
						weeklyInspectionResponseDTO.ScbaStatus = weeklyInspection.ScbaStatus;
						weeklyInspectionResponseDTO.ScbaWeeklyFindings = weeklyInspection.ScbaWeeklyFindings;
						weeklyInspectionResponseDTO.Scba30min = weeklyInspection.Scba30min;
						weeklyInspectionResponseDTO.Scba15min = weeklyInspection.Scba15min;
						weeklyInspectionResponseDTO.Scba10min = weeklyInspection.Scba10min;
						weeklyInspectionResponseDTO.PortableGasStatus = weeklyInspection.PortableGasStatus;
						weeklyInspectionResponseDTO.PortableGasWeeklyFindings = weeklyInspection.PortableGasWeeklyFindings;
						weeklyInspectionResponseDTO.PortableGasMuti = weeklyInspection.PortableGasMuti;
						weeklyInspectionResponseDTO.PortableGasSingle = weeklyInspection.PortableGasSingle;
						weeklyInspectionResponseDTO.ExpeiryDate = weeklyInspection.ExpeiryDate;
						weeklyInspectionResponseDTO.FireExtinguishersWeeklyFindings = weeklyInspection.FireExtinguishersWeeklyFindings;
						weeklyInspectionResponseDTO.FireExtinguishersStatus = weeklyInspection.FireExtinguishersStatus;
						weeklyInspectionResponseDTO.SmokeWeeklyFindings = weeklyInspection.SmokeWeeklyFindings;
						weeklyInspectionResponseDTO.SmokeStatus = weeklyInspection.SmokeStatus;
						weeklyInspectionResponseDTO.WindWeeklyFindings = weeklyInspection.WindWeeklyFindings;
						weeklyInspectionResponseDTO.WindStatus = weeklyInspection.WindStatus;
						weeklyInspectionResponseDTO.FirePumpWeeklyFindings = weeklyInspection.FirePumpWeeklyFindings;
						weeklyInspectionResponseDTO.FirePumpStatus = weeklyInspection.FirePumpStatus;
						weeklyInspectionResponseDTO.DerrickmanStatus = weeklyInspection.DerrickmanStatus;
						weeklyInspectionResponseDTO.DerrickmanWeeklyFindings = weeklyInspection.DerrickmanWeeklyFindings;
						weeklyInspectionResponseDTO.WorkingStatus = weeklyInspection.WorkingStatus;
						weeklyInspectionResponseDTO.WorkingWeeklyFindings = weeklyInspection.WorkingWeeklyFindings;
						weeklyInspectionResponseDTO.PortableLadderStatus = weeklyInspection.PortableLadderStatus;
						weeklyInspectionResponseDTO.PortableLadderWeeklyFindings = weeklyInspection.PortableLadderWeeklyFindings;
						weeklyInspectionResponseDTO.SafetyStatus = weeklyInspection.SafetyStatus;
						weeklyInspectionResponseDTO.SafetyWeeklyFindings = weeklyInspection.SafetyWeeklyFindings;
						weeklyInspectionResponseDTO.FallStatus = weeklyInspection.FallStatus;
						weeklyInspectionResponseDTO.FallWeeklyFindings = weeklyInspection.FallWeeklyFindings;
						weeklyInspectionResponseDTO.CraneStatus = weeklyInspection.CraneStatus;
						weeklyInspectionResponseDTO.CraneWeeklyFindings = weeklyInspection.CraneWeeklyFindings;
						weeklyInspectionResponseDTO.ForkStatus = weeklyInspection.ForkStatus;
						weeklyInspectionResponseDTO.ForkWeeklyFindings = weeklyInspection.ForkWeeklyFindings;
						weeklyInspectionResponseDTO.DroppedInspectionStatus = weeklyInspection.DroppedInspectionStatus;
						weeklyInspectionResponseDTO.DroppedInspectionWeeklyFindings = weeklyInspection.DroppedInspectionWeeklyFindings;
						weeklyInspectionResponseDTO.ElectricalStatus = weeklyInspection.ElectricalStatus;
						weeklyInspectionResponseDTO.EarthingWeeklyFindings = weeklyInspection.EarthingWeeklyFindings;
						weeklyInspectionResponseDTO.EarthingMaximum = (int)weeklyInspection.EarthingMaximum;
						weeklyInspectionResponseDTO.EarthingMin = (int)weeklyInspection.EarthingMin;
						weeklyInspectionResponseDTO.Code = weeklyInspection.Code;
						weeklyInspectionResponseDTO.Name = weeklyInspection.Name;
						weeklyInspectionResponseDTO.PositionName = weeklyInspection.PositionName;

						weeklyInspectionResponseDTO.WeldingStatus = weeklyInspection.WeldingStatus;
						weeklyInspectionResponseDTO.WeldingWeeklyFindings = weeklyInspection.WeldingWeeklyFindings;
						weeklyInspectionResponseDTO.ElectricalWeeklyFindings = weeklyInspection.ElectricalWeeklyFindings;
						weeklyInspectionResponseDTO.CircuitStatus = weeklyInspection.CircuitStatus;
						weeklyInspectionResponseDTO.CircuitWeeklyFindings = weeklyInspection.CircuitWeeklyFindings;
						weeklyInspectionResponseDTO.EarthingStatus = weeklyInspection.EarthingStatus;

						weeklyInspectionResponseDTO.userName = weeklyInspection.user.UserName;
						// weeklyInspectionResponseDTO.userName = weeklyInspection.user.Id;



						newTemp.Add(weeklyInspectionResponseDTO);
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
		public PageResult<WeeklyInspectionResponseDTO> GettAllWeeklyInspectionByPage(string UserId, string UserRole, int? page, int pagesize = 10)
		{

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<WeeklyInspection> temp = WeeklyInspectionRepository.getall();
					List<WeeklyInspectionResponseDTO> newTemp = new List<WeeklyInspectionResponseDTO>();
					foreach (WeeklyInspection weeklyInspection in temp)
					{
						WeeklyInspectionResponseDTO weeklyInspectionResponseDTO = new WeeklyInspectionResponseDTO();
						weeklyInspectionResponseDTO.Id = weeklyInspection.Id;
						weeklyInspectionResponseDTO.RigId = weeklyInspection.Rig.Number;
						weeklyInspectionResponseDTO.Date = weeklyInspection.Date;
						weeklyInspectionResponseDTO.WellName = weeklyInspection.WellName;
						weeklyInspectionResponseDTO.Client = weeklyInspection.Client;
						weeklyInspectionResponseDTO.EyeStatus = weeklyInspection.EyeStatus;
						weeklyInspectionResponseDTO.EyeWeeklyFindings = weeklyInspection.EyeWeeklyFindings;
						weeklyInspectionResponseDTO.FirstAidStatus = weeklyInspection.FirstAidStatus;
						weeklyInspectionResponseDTO.FirstAidWeeklyFindings = weeklyInspection.FirstAidWeeklyFindings;
						weeklyInspectionResponseDTO.ScbaStatus = weeklyInspection.ScbaStatus;
						weeklyInspectionResponseDTO.ScbaWeeklyFindings = weeklyInspection.ScbaWeeklyFindings;
						weeklyInspectionResponseDTO.Scba30min = weeklyInspection.Scba30min;
						weeklyInspectionResponseDTO.Scba15min = weeklyInspection.Scba15min;
						weeklyInspectionResponseDTO.Scba10min = weeklyInspection.Scba10min;
						weeklyInspectionResponseDTO.PortableGasStatus = weeklyInspection.PortableGasStatus;
						weeklyInspectionResponseDTO.PortableGasWeeklyFindings = weeklyInspection.PortableGasWeeklyFindings;
						weeklyInspectionResponseDTO.PortableGasMuti = weeklyInspection.PortableGasMuti;
						weeklyInspectionResponseDTO.PortableGasSingle = weeklyInspection.PortableGasSingle;
						weeklyInspectionResponseDTO.ExpeiryDate = weeklyInspection.ExpeiryDate;
						weeklyInspectionResponseDTO.FireExtinguishersWeeklyFindings = weeklyInspection.FireExtinguishersWeeklyFindings;
						weeklyInspectionResponseDTO.FireExtinguishersStatus = weeklyInspection.FireExtinguishersStatus;
						weeklyInspectionResponseDTO.SmokeWeeklyFindings = weeklyInspection.SmokeWeeklyFindings;
						weeklyInspectionResponseDTO.SmokeStatus = weeklyInspection.SmokeStatus;
						weeklyInspectionResponseDTO.WindWeeklyFindings = weeklyInspection.WindWeeklyFindings;
						weeklyInspectionResponseDTO.WindStatus = weeklyInspection.WindStatus;
						weeklyInspectionResponseDTO.FirePumpWeeklyFindings = weeklyInspection.FirePumpWeeklyFindings;
						weeklyInspectionResponseDTO.FirePumpStatus = weeklyInspection.FirePumpStatus;
						weeklyInspectionResponseDTO.DerrickmanStatus = weeklyInspection.DerrickmanStatus;
						weeklyInspectionResponseDTO.DerrickmanWeeklyFindings = weeklyInspection.DerrickmanWeeklyFindings;
						weeklyInspectionResponseDTO.WorkingStatus = weeklyInspection.WorkingStatus;
						weeklyInspectionResponseDTO.WorkingWeeklyFindings = weeklyInspection.WorkingWeeklyFindings;
						weeklyInspectionResponseDTO.PortableLadderStatus = weeklyInspection.PortableLadderStatus;
						weeklyInspectionResponseDTO.PortableLadderWeeklyFindings = weeklyInspection.PortableLadderWeeklyFindings;
						weeklyInspectionResponseDTO.SafetyStatus = weeklyInspection.SafetyStatus;
						weeklyInspectionResponseDTO.SafetyWeeklyFindings = weeklyInspection.SafetyWeeklyFindings;
						weeklyInspectionResponseDTO.FallStatus = weeklyInspection.FallStatus;
						weeklyInspectionResponseDTO.FallWeeklyFindings = weeklyInspection.FallWeeklyFindings;
						weeklyInspectionResponseDTO.CraneStatus = weeklyInspection.CraneStatus;
						weeklyInspectionResponseDTO.CraneWeeklyFindings = weeklyInspection.CraneWeeklyFindings;
						weeklyInspectionResponseDTO.ForkStatus = weeklyInspection.ForkStatus;
						weeklyInspectionResponseDTO.ForkWeeklyFindings = weeklyInspection.ForkWeeklyFindings;
						weeklyInspectionResponseDTO.DroppedInspectionStatus = weeklyInspection.DroppedInspectionStatus;
						weeklyInspectionResponseDTO.DroppedInspectionWeeklyFindings = weeklyInspection.DroppedInspectionWeeklyFindings;
						weeklyInspectionResponseDTO.ElectricalStatus = weeklyInspection.ElectricalStatus;
						weeklyInspectionResponseDTO.EarthingWeeklyFindings = weeklyInspection.EarthingWeeklyFindings;
						weeklyInspectionResponseDTO.EarthingMaximum = weeklyInspection.EarthingMaximum;
						weeklyInspectionResponseDTO.EarthingMin = weeklyInspection.EarthingMin;
						weeklyInspectionResponseDTO.Code = weeklyInspection.Code;
						weeklyInspectionResponseDTO.Name = weeklyInspection.Name;
						weeklyInspectionResponseDTO.PositionName = weeklyInspection.PositionName;

						weeklyInspectionResponseDTO.WeldingStatus = weeklyInspection.WeldingStatus;
						weeklyInspectionResponseDTO.WeldingWeeklyFindings = weeklyInspection.WeldingWeeklyFindings;
						weeklyInspectionResponseDTO.ElectricalWeeklyFindings = weeklyInspection.ElectricalWeeklyFindings;
						weeklyInspectionResponseDTO.CircuitStatus = weeklyInspection.CircuitStatus;
						weeklyInspectionResponseDTO.CircuitWeeklyFindings = weeklyInspection.CircuitWeeklyFindings;
						weeklyInspectionResponseDTO.EarthingStatus = weeklyInspection.EarthingStatus;

						weeklyInspectionResponseDTO.userName = weeklyInspection.user.UserName;
						weeklyInspectionResponseDTO.userID = weeklyInspection.user.Id;



						newTemp.Add(weeklyInspectionResponseDTO);

					}

					float countDetails = WeeklyInspectionRepository.getall().Count();
					var result = new PageResult<WeeklyInspectionResponseDTO>
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
					List<WeeklyInspection> temp = WeeklyInspectionRepository.getall().Where(a => a.user.Id == UserId).ToList();
					List<WeeklyInspectionResponseDTO> newTemp = new List<WeeklyInspectionResponseDTO>();
					foreach (WeeklyInspection weeklyInspection in temp)
					{
						WeeklyInspectionResponseDTO weeklyInspectionResponseDTO = new WeeklyInspectionResponseDTO();
						weeklyInspectionResponseDTO.Id = weeklyInspection.Id;
						weeklyInspectionResponseDTO.RigId = weeklyInspection.Rig.Number;
						weeklyInspectionResponseDTO.Date = weeklyInspection.Date;
						weeklyInspectionResponseDTO.WellName = weeklyInspection.WellName;
						weeklyInspectionResponseDTO.Client = weeklyInspection.Client;
						weeklyInspectionResponseDTO.EyeStatus = weeklyInspection.EyeStatus;
						weeklyInspectionResponseDTO.EyeWeeklyFindings = weeklyInspection.EyeWeeklyFindings;
						weeklyInspectionResponseDTO.FirstAidStatus = weeklyInspection.FirstAidStatus;
						weeklyInspectionResponseDTO.FirstAidWeeklyFindings = weeklyInspection.FirstAidWeeklyFindings;
						weeklyInspectionResponseDTO.ScbaStatus = weeklyInspection.ScbaStatus;
						weeklyInspectionResponseDTO.ScbaWeeklyFindings = weeklyInspection.ScbaWeeklyFindings;
						weeklyInspectionResponseDTO.Scba30min = weeklyInspection.Scba30min;
						weeklyInspectionResponseDTO.Scba15min = weeklyInspection.Scba15min;
						weeklyInspectionResponseDTO.Scba10min = weeklyInspection.Scba10min;
						weeklyInspectionResponseDTO.PortableGasStatus = weeklyInspection.PortableGasStatus;
						weeklyInspectionResponseDTO.PortableGasWeeklyFindings = weeklyInspection.PortableGasWeeklyFindings;
						weeklyInspectionResponseDTO.PortableGasMuti = weeklyInspection.PortableGasMuti;
						weeklyInspectionResponseDTO.PortableGasSingle = weeklyInspection.PortableGasSingle;
						weeklyInspectionResponseDTO.ExpeiryDate = weeklyInspection.ExpeiryDate;
						weeklyInspectionResponseDTO.FireExtinguishersWeeklyFindings = weeklyInspection.FireExtinguishersWeeklyFindings;
						weeklyInspectionResponseDTO.FireExtinguishersStatus = weeklyInspection.FireExtinguishersStatus;
						weeklyInspectionResponseDTO.SmokeWeeklyFindings = weeklyInspection.SmokeWeeklyFindings;
						weeklyInspectionResponseDTO.SmokeStatus = weeklyInspection.SmokeStatus;
						weeklyInspectionResponseDTO.WindWeeklyFindings = weeklyInspection.WindWeeklyFindings;
						weeklyInspectionResponseDTO.WindStatus = weeklyInspection.WindStatus;
						weeklyInspectionResponseDTO.FirePumpWeeklyFindings = weeklyInspection.FirePumpWeeklyFindings;
						weeklyInspectionResponseDTO.FirePumpStatus = weeklyInspection.FirePumpStatus;
						weeklyInspectionResponseDTO.DerrickmanStatus = weeklyInspection.DerrickmanStatus;
						weeklyInspectionResponseDTO.DerrickmanWeeklyFindings = weeklyInspection.DerrickmanWeeklyFindings;
						weeklyInspectionResponseDTO.WorkingStatus = weeklyInspection.WorkingStatus;
						weeklyInspectionResponseDTO.WorkingWeeklyFindings = weeklyInspection.WorkingWeeklyFindings;
						weeklyInspectionResponseDTO.PortableLadderStatus = weeklyInspection.PortableLadderStatus;
						weeklyInspectionResponseDTO.PortableLadderWeeklyFindings = weeklyInspection.PortableLadderWeeklyFindings;
						weeklyInspectionResponseDTO.SafetyStatus = weeklyInspection.SafetyStatus;
						weeklyInspectionResponseDTO.SafetyWeeklyFindings = weeklyInspection.SafetyWeeklyFindings;
						weeklyInspectionResponseDTO.FallStatus = weeklyInspection.FallStatus;
						weeklyInspectionResponseDTO.FallWeeklyFindings = weeklyInspection.FallWeeklyFindings;
						weeklyInspectionResponseDTO.CraneStatus = weeklyInspection.CraneStatus;
						weeklyInspectionResponseDTO.CraneWeeklyFindings = weeklyInspection.CraneWeeklyFindings;
						weeklyInspectionResponseDTO.ForkStatus = weeklyInspection.ForkStatus;
						weeklyInspectionResponseDTO.ForkWeeklyFindings = weeklyInspection.ForkWeeklyFindings;
						weeklyInspectionResponseDTO.DroppedInspectionStatus = weeklyInspection.DroppedInspectionStatus;
						weeklyInspectionResponseDTO.DroppedInspectionWeeklyFindings = weeklyInspection.DroppedInspectionWeeklyFindings;
						weeklyInspectionResponseDTO.ElectricalStatus = weeklyInspection.ElectricalStatus;
						weeklyInspectionResponseDTO.EarthingWeeklyFindings = weeklyInspection.EarthingWeeklyFindings;
						weeklyInspectionResponseDTO.EarthingMaximum = weeklyInspection.EarthingMaximum;
						weeklyInspectionResponseDTO.EarthingMin = weeklyInspection.EarthingMin;
						weeklyInspectionResponseDTO.Code = weeklyInspection.Code;
						weeklyInspectionResponseDTO.Name = weeklyInspection.Name;
						weeklyInspectionResponseDTO.PositionName = weeklyInspection.PositionName;

						weeklyInspectionResponseDTO.WeldingStatus = weeklyInspection.WeldingStatus;
						weeklyInspectionResponseDTO.WeldingWeeklyFindings = weeklyInspection.WeldingWeeklyFindings;
						weeklyInspectionResponseDTO.ElectricalWeeklyFindings = weeklyInspection.ElectricalWeeklyFindings;
						weeklyInspectionResponseDTO.CircuitStatus = weeklyInspection.CircuitStatus;
						weeklyInspectionResponseDTO.CircuitWeeklyFindings = weeklyInspection.CircuitWeeklyFindings;
						weeklyInspectionResponseDTO.EarthingStatus = weeklyInspection.EarthingStatus;

						weeklyInspectionResponseDTO.userName = weeklyInspection.user.UserName;
						weeklyInspectionResponseDTO.userID = weeklyInspection.user.Id;



						newTemp.Add(weeklyInspectionResponseDTO);
					}

					float countDetails = WeeklyInspectionRepository.getall().Where(a => a.user.Id == UserId).Count();
					var result = new PageResult<WeeklyInspectionResponseDTO>
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
				return new PageResult<WeeklyInspectionResponseDTO>();

			}
			return new PageResult<WeeklyInspectionResponseDTO>();
		}

		[HttpGet("GetDataById/{ID:int}")]
		public ActionResult<ResultDTO> GetAllWithDataByID(int ID, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();


			if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
			{
				WeeklyInspection temp = WeeklyInspectionRepository.getall().FirstOrDefault(a => a.Id == ID);
				if (temp != null)
				{
					WeeklyInspectionResponseDTO weeklyInspectionResponseDTO = new WeeklyInspectionResponseDTO();

					weeklyInspectionResponseDTO.Id = temp.Id;
					weeklyInspectionResponseDTO.RigId = temp.RigId;
					weeklyInspectionResponseDTO.Date = temp.Date;
					weeklyInspectionResponseDTO.WellName = temp.WellName;
					weeklyInspectionResponseDTO.Client = temp.Client;
					weeklyInspectionResponseDTO.EyeStatus = temp.EyeStatus;
					weeklyInspectionResponseDTO.EyeWeeklyFindings = temp.EyeWeeklyFindings;
					weeklyInspectionResponseDTO.FirstAidStatus = temp.FirstAidStatus;
					weeklyInspectionResponseDTO.FirstAidWeeklyFindings = temp.FirstAidWeeklyFindings;
					weeklyInspectionResponseDTO.ScbaStatus = temp.ScbaStatus;
					weeklyInspectionResponseDTO.ScbaWeeklyFindings = temp.ScbaWeeklyFindings;
					weeklyInspectionResponseDTO.Scba30min = temp.Scba30min;
					weeklyInspectionResponseDTO.Scba15min = temp.Scba15min;
					weeklyInspectionResponseDTO.Scba10min = temp.Scba10min;
					weeklyInspectionResponseDTO.PortableGasStatus = temp.PortableGasStatus;
					weeklyInspectionResponseDTO.PortableGasWeeklyFindings = temp.PortableGasWeeklyFindings;
					weeklyInspectionResponseDTO.PortableGasMuti = temp.PortableGasMuti;
					weeklyInspectionResponseDTO.PortableGasSingle = temp.PortableGasSingle;
					weeklyInspectionResponseDTO.ExpeiryDate = temp.ExpeiryDate;
					weeklyInspectionResponseDTO.FireExtinguishersWeeklyFindings = temp.FireExtinguishersWeeklyFindings;
					weeklyInspectionResponseDTO.FireExtinguishersStatus = temp.FireExtinguishersStatus;
					weeklyInspectionResponseDTO.SmokeWeeklyFindings = temp.SmokeWeeklyFindings;
					weeklyInspectionResponseDTO.SmokeStatus = temp.SmokeStatus;
					weeklyInspectionResponseDTO.WindWeeklyFindings = temp.WindWeeklyFindings;
					weeklyInspectionResponseDTO.WindStatus = temp.WindStatus;
					weeklyInspectionResponseDTO.FirePumpWeeklyFindings = temp.FirePumpWeeklyFindings;
					weeklyInspectionResponseDTO.FirePumpStatus = temp.FirePumpStatus;
					weeklyInspectionResponseDTO.DerrickmanStatus = temp.DerrickmanStatus;
					weeklyInspectionResponseDTO.DerrickmanWeeklyFindings = temp.DerrickmanWeeklyFindings;
					weeklyInspectionResponseDTO.WorkingStatus = temp.WorkingStatus;
					weeklyInspectionResponseDTO.WorkingWeeklyFindings = temp.WorkingWeeklyFindings;
					weeklyInspectionResponseDTO.PortableLadderStatus = temp.PortableLadderStatus;
					weeklyInspectionResponseDTO.PortableLadderWeeklyFindings = temp.PortableLadderWeeklyFindings;
					weeklyInspectionResponseDTO.SafetyStatus = temp.SafetyStatus;
					weeklyInspectionResponseDTO.SafetyWeeklyFindings = temp.SafetyWeeklyFindings;
					weeklyInspectionResponseDTO.FallStatus = temp.FallStatus;
					weeklyInspectionResponseDTO.FallWeeklyFindings = temp.FallWeeklyFindings;
					weeklyInspectionResponseDTO.CraneStatus = temp.CraneStatus;
					weeklyInspectionResponseDTO.CraneWeeklyFindings = temp.CraneWeeklyFindings;
					weeklyInspectionResponseDTO.ForkStatus = temp.ForkStatus;
					weeklyInspectionResponseDTO.ForkWeeklyFindings = temp.ForkWeeklyFindings;
					weeklyInspectionResponseDTO.DroppedInspectionStatus = temp.DroppedInspectionStatus;
					weeklyInspectionResponseDTO.DroppedInspectionWeeklyFindings = temp.DroppedInspectionWeeklyFindings;
					weeklyInspectionResponseDTO.ElectricalStatus = temp.ElectricalStatus;
					weeklyInspectionResponseDTO.EarthingWeeklyFindings = temp.EarthingWeeklyFindings;
					weeklyInspectionResponseDTO.EarthingMaximum = temp.EarthingMaximum;
					weeklyInspectionResponseDTO.EarthingMin = temp.EarthingMin;

					weeklyInspectionResponseDTO.WeldingStatus = temp.WeldingStatus;
					weeklyInspectionResponseDTO.WeldingWeeklyFindings = temp.WeldingWeeklyFindings;
					weeklyInspectionResponseDTO.ElectricalWeeklyFindings = temp.ElectricalWeeklyFindings;
					weeklyInspectionResponseDTO.CircuitStatus = temp.CircuitStatus;
					weeklyInspectionResponseDTO.CircuitWeeklyFindings = temp.CircuitWeeklyFindings;
					weeklyInspectionResponseDTO.EarthingStatus = temp.EarthingStatus;


					weeklyInspectionResponseDTO.Code = temp.Code;
					weeklyInspectionResponseDTO.Name = temp.Name;
					weeklyInspectionResponseDTO.PositionName = temp.PositionName;

					weeklyInspectionResponseDTO.userName = temp.user.UserName;
					weeklyInspectionResponseDTO.userID = temp.user.Id;


					if (weeklyInspectionResponseDTO != null)
					{

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = weeklyInspectionResponseDTO;

						return result;
					}
				}

			}
			else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
			{
				WeeklyInspection temp = WeeklyInspectionRepository.getall().FirstOrDefault(a => a.Id == ID && a.user.Id == UserId);
				if (temp != null)
				{
					WeeklyInspectionResponseDTO weeklyInspectionResponseDTO = new WeeklyInspectionResponseDTO();

					weeklyInspectionResponseDTO.Id = temp.Id;
					weeklyInspectionResponseDTO.RigId = temp.RigId;
					weeklyInspectionResponseDTO.Date = temp.Date;
					weeklyInspectionResponseDTO.WellName = temp.WellName;
					weeklyInspectionResponseDTO.Client = temp.Client;
					weeklyInspectionResponseDTO.EyeStatus = temp.EyeStatus;
					weeklyInspectionResponseDTO.EyeWeeklyFindings = temp.EyeWeeklyFindings;
					weeklyInspectionResponseDTO.FirstAidStatus = temp.FirstAidStatus;
					weeklyInspectionResponseDTO.FirstAidWeeklyFindings = temp.FirstAidWeeklyFindings;
					weeklyInspectionResponseDTO.ScbaStatus = temp.ScbaStatus;
					weeklyInspectionResponseDTO.ScbaWeeklyFindings = temp.ScbaWeeklyFindings;
					weeklyInspectionResponseDTO.Scba30min = temp.Scba30min;
					weeklyInspectionResponseDTO.Scba15min = temp.Scba15min;
					weeklyInspectionResponseDTO.Scba10min = temp.Scba10min;
					weeklyInspectionResponseDTO.PortableGasStatus = temp.PortableGasStatus;
					weeklyInspectionResponseDTO.PortableGasWeeklyFindings = temp.PortableGasWeeklyFindings;
					weeklyInspectionResponseDTO.PortableGasMuti = temp.PortableGasMuti;
					weeklyInspectionResponseDTO.PortableGasSingle = temp.PortableGasSingle;
					weeklyInspectionResponseDTO.ExpeiryDate = temp.ExpeiryDate;
					weeklyInspectionResponseDTO.FireExtinguishersWeeklyFindings = temp.FireExtinguishersWeeklyFindings;
					weeklyInspectionResponseDTO.FireExtinguishersStatus = temp.FireExtinguishersStatus;
					weeklyInspectionResponseDTO.SmokeWeeklyFindings = temp.SmokeWeeklyFindings;
					weeklyInspectionResponseDTO.SmokeStatus = temp.SmokeStatus;
					weeklyInspectionResponseDTO.WindWeeklyFindings = temp.WindWeeklyFindings;
					weeklyInspectionResponseDTO.WindStatus = temp.WindStatus;
					weeklyInspectionResponseDTO.FirePumpWeeklyFindings = temp.FirePumpWeeklyFindings;
					weeklyInspectionResponseDTO.FirePumpStatus = temp.FirePumpStatus;
					weeklyInspectionResponseDTO.DerrickmanStatus = temp.DerrickmanStatus;
					weeklyInspectionResponseDTO.DerrickmanWeeklyFindings = temp.DerrickmanWeeklyFindings;
					weeklyInspectionResponseDTO.WorkingStatus = temp.WorkingStatus;
					weeklyInspectionResponseDTO.WorkingWeeklyFindings = temp.WorkingWeeklyFindings;
					weeklyInspectionResponseDTO.PortableLadderStatus = temp.PortableLadderStatus;
					weeklyInspectionResponseDTO.PortableLadderWeeklyFindings = temp.PortableLadderWeeklyFindings;
					weeklyInspectionResponseDTO.SafetyStatus = temp.SafetyStatus;
					weeklyInspectionResponseDTO.SafetyWeeklyFindings = temp.SafetyWeeklyFindings;
					weeklyInspectionResponseDTO.FallStatus = temp.FallStatus;
					weeklyInspectionResponseDTO.FallWeeklyFindings = temp.FallWeeklyFindings;
					weeklyInspectionResponseDTO.CraneStatus = temp.CraneStatus;
					weeklyInspectionResponseDTO.CraneWeeklyFindings = temp.CraneWeeklyFindings;
					weeklyInspectionResponseDTO.ForkStatus = temp.ForkStatus;
					weeklyInspectionResponseDTO.ForkWeeklyFindings = temp.ForkWeeklyFindings;
					weeklyInspectionResponseDTO.DroppedInspectionStatus = temp.DroppedInspectionStatus;
					weeklyInspectionResponseDTO.DroppedInspectionWeeklyFindings = temp.DroppedInspectionWeeklyFindings;
					weeklyInspectionResponseDTO.ElectricalStatus = temp.ElectricalStatus;
					weeklyInspectionResponseDTO.EarthingWeeklyFindings = temp.EarthingWeeklyFindings;
					weeklyInspectionResponseDTO.EarthingMaximum = temp.EarthingMaximum;
					weeklyInspectionResponseDTO.EarthingMin = temp.EarthingMin;
					weeklyInspectionResponseDTO.Code = temp.Code;
					weeklyInspectionResponseDTO.Name = temp.Name;
					weeklyInspectionResponseDTO.PositionName = temp.PositionName;

					weeklyInspectionResponseDTO.WeldingStatus = temp.WeldingStatus;
					weeklyInspectionResponseDTO.WeldingWeeklyFindings = temp.WeldingWeeklyFindings;
					weeklyInspectionResponseDTO.ElectricalWeeklyFindings = temp.ElectricalWeeklyFindings;
					weeklyInspectionResponseDTO.CircuitStatus = temp.CircuitStatus;
					weeklyInspectionResponseDTO.CircuitWeeklyFindings = temp.CircuitWeeklyFindings;
					weeklyInspectionResponseDTO.EarthingStatus = temp.EarthingStatus;

					weeklyInspectionResponseDTO.userName = temp.user.UserName;
					weeklyInspectionResponseDTO.userID = temp.user.Id;


					if (weeklyInspectionResponseDTO != null)
					{

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = weeklyInspectionResponseDTO;

						return result;
					}
				}

			}

			result.Statescode = 404;
			result.Message = "data not found";
			return result;
		}

		[HttpGet("Print/{ID:int}")]
		public ActionResult<ResultDTO> GetAllWithDataByIDForPrint(int ID, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();


			if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
			{
				WeeklyInspection temp = WeeklyInspectionRepository.getall().FirstOrDefault(a => a.Id == ID);
				if (temp != null)
				{
					WeeklyInspectionResponseDTO weeklyInspectionResponseDTO = new WeeklyInspectionResponseDTO();

					weeklyInspectionResponseDTO.Id = temp.Id;
					weeklyInspectionResponseDTO.RigId = temp.Rig.Number;
					weeklyInspectionResponseDTO.Date = temp.Date;
					weeklyInspectionResponseDTO.WellName = temp.WellName;
					weeklyInspectionResponseDTO.Client = temp.Client;
					weeklyInspectionResponseDTO.EyeStatus = temp.EyeStatus;
					weeklyInspectionResponseDTO.EyeWeeklyFindings = temp.EyeWeeklyFindings;
					weeklyInspectionResponseDTO.FirstAidStatus = temp.FirstAidStatus;
					weeklyInspectionResponseDTO.FirstAidWeeklyFindings = temp.FirstAidWeeklyFindings;
					weeklyInspectionResponseDTO.ScbaStatus = temp.ScbaStatus;
					weeklyInspectionResponseDTO.ScbaWeeklyFindings = temp.ScbaWeeklyFindings;
					weeklyInspectionResponseDTO.Scba30min = temp.Scba30min;
					weeklyInspectionResponseDTO.Scba15min = temp.Scba15min;
					weeklyInspectionResponseDTO.Scba10min = temp.Scba10min;
					weeklyInspectionResponseDTO.PortableGasStatus = temp.PortableGasStatus;
					weeklyInspectionResponseDTO.PortableGasWeeklyFindings = temp.PortableGasWeeklyFindings;
					weeklyInspectionResponseDTO.PortableGasMuti = temp.PortableGasMuti;
					weeklyInspectionResponseDTO.PortableGasSingle = temp.PortableGasSingle;
					weeklyInspectionResponseDTO.ExpeiryDate = temp.ExpeiryDate;
					weeklyInspectionResponseDTO.FireExtinguishersWeeklyFindings = temp.FireExtinguishersWeeklyFindings;
					weeklyInspectionResponseDTO.FireExtinguishersStatus = temp.FireExtinguishersStatus;
					weeklyInspectionResponseDTO.SmokeWeeklyFindings = temp.SmokeWeeklyFindings;
					weeklyInspectionResponseDTO.SmokeStatus = temp.SmokeStatus;
					weeklyInspectionResponseDTO.WindWeeklyFindings = temp.WindWeeklyFindings;
					weeklyInspectionResponseDTO.WindStatus = temp.WindStatus;
					weeklyInspectionResponseDTO.FirePumpWeeklyFindings = temp.FirePumpWeeklyFindings;
					weeklyInspectionResponseDTO.FirePumpStatus = temp.FirePumpStatus;
					weeklyInspectionResponseDTO.DerrickmanStatus = temp.DerrickmanStatus;
					weeklyInspectionResponseDTO.DerrickmanWeeklyFindings = temp.DerrickmanWeeklyFindings;
					weeklyInspectionResponseDTO.WorkingStatus = temp.WorkingStatus;
					weeklyInspectionResponseDTO.WorkingWeeklyFindings = temp.WorkingWeeklyFindings;
					weeklyInspectionResponseDTO.PortableLadderStatus = temp.PortableLadderStatus;
					weeklyInspectionResponseDTO.PortableLadderWeeklyFindings = temp.PortableLadderWeeklyFindings;
					weeklyInspectionResponseDTO.SafetyStatus = temp.SafetyStatus;
					weeklyInspectionResponseDTO.SafetyWeeklyFindings = temp.SafetyWeeklyFindings;
					weeklyInspectionResponseDTO.FallStatus = temp.FallStatus;
					weeklyInspectionResponseDTO.FallWeeklyFindings = temp.FallWeeklyFindings;
					weeklyInspectionResponseDTO.CraneStatus = temp.CraneStatus;
					weeklyInspectionResponseDTO.CraneWeeklyFindings = temp.CraneWeeklyFindings;
					weeklyInspectionResponseDTO.ForkStatus = temp.ForkStatus;
					weeklyInspectionResponseDTO.ForkWeeklyFindings = temp.ForkWeeklyFindings;
					weeklyInspectionResponseDTO.DroppedInspectionStatus = temp.DroppedInspectionStatus;
					weeklyInspectionResponseDTO.DroppedInspectionWeeklyFindings = temp.DroppedInspectionWeeklyFindings;
					weeklyInspectionResponseDTO.ElectricalStatus = temp.ElectricalStatus;
					weeklyInspectionResponseDTO.EarthingWeeklyFindings = temp.EarthingWeeklyFindings;
					weeklyInspectionResponseDTO.EarthingMaximum = temp.EarthingMaximum;
					weeklyInspectionResponseDTO.EarthingMin = temp.EarthingMin;

					weeklyInspectionResponseDTO.WeldingStatus = temp.WeldingStatus;
					weeklyInspectionResponseDTO.WeldingWeeklyFindings = temp.WeldingWeeklyFindings;
					weeklyInspectionResponseDTO.ElectricalWeeklyFindings = temp.ElectricalWeeklyFindings;
					weeklyInspectionResponseDTO.CircuitStatus = temp.CircuitStatus;
					weeklyInspectionResponseDTO.CircuitWeeklyFindings = temp.CircuitWeeklyFindings;
					weeklyInspectionResponseDTO.EarthingStatus = temp.EarthingStatus;


					weeklyInspectionResponseDTO.Code = temp.Code;
					weeklyInspectionResponseDTO.Name = temp.Name;
					weeklyInspectionResponseDTO.PositionName = temp.PositionName;

					weeklyInspectionResponseDTO.userName = temp.user.UserName;
					weeklyInspectionResponseDTO.userID = temp.user.Id;


					if (weeklyInspectionResponseDTO != null)
					{

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = weeklyInspectionResponseDTO;

						return result;
					}
				}

			}
			else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
			{
				WeeklyInspection temp = WeeklyInspectionRepository.getall().FirstOrDefault(a => a.Id == ID && a.user.Id == UserId);
				if (temp != null)
				{
					WeeklyInspectionResponseDTO weeklyInspectionResponseDTO = new WeeklyInspectionResponseDTO();

					weeklyInspectionResponseDTO.Id = temp.Id;
					weeklyInspectionResponseDTO.RigId = temp.Rig.Number;
					weeklyInspectionResponseDTO.Date = temp.Date;
					weeklyInspectionResponseDTO.WellName = temp.WellName;
					weeklyInspectionResponseDTO.Client = temp.Client;
					weeklyInspectionResponseDTO.EyeStatus = temp.EyeStatus;
					weeklyInspectionResponseDTO.EyeWeeklyFindings = temp.EyeWeeklyFindings;
					weeklyInspectionResponseDTO.FirstAidStatus = temp.FirstAidStatus;
					weeklyInspectionResponseDTO.FirstAidWeeklyFindings = temp.FirstAidWeeklyFindings;
					weeklyInspectionResponseDTO.ScbaStatus = temp.ScbaStatus;
					weeklyInspectionResponseDTO.ScbaWeeklyFindings = temp.ScbaWeeklyFindings;
					weeklyInspectionResponseDTO.Scba30min = temp.Scba30min;
					weeklyInspectionResponseDTO.Scba15min = temp.Scba15min;
					weeklyInspectionResponseDTO.Scba10min = temp.Scba10min;
					weeklyInspectionResponseDTO.PortableGasStatus = temp.PortableGasStatus;
					weeklyInspectionResponseDTO.PortableGasWeeklyFindings = temp.PortableGasWeeklyFindings;
					weeklyInspectionResponseDTO.PortableGasMuti = temp.PortableGasMuti;
					weeklyInspectionResponseDTO.PortableGasSingle = temp.PortableGasSingle;
					weeklyInspectionResponseDTO.ExpeiryDate = temp.ExpeiryDate;
					weeklyInspectionResponseDTO.FireExtinguishersWeeklyFindings = temp.FireExtinguishersWeeklyFindings;
					weeklyInspectionResponseDTO.FireExtinguishersStatus = temp.FireExtinguishersStatus;
					weeklyInspectionResponseDTO.SmokeWeeklyFindings = temp.SmokeWeeklyFindings;
					weeklyInspectionResponseDTO.SmokeStatus = temp.SmokeStatus;
					weeklyInspectionResponseDTO.WindWeeklyFindings = temp.WindWeeklyFindings;
					weeklyInspectionResponseDTO.WindStatus = temp.WindStatus;
					weeklyInspectionResponseDTO.FirePumpWeeklyFindings = temp.FirePumpWeeklyFindings;
					weeklyInspectionResponseDTO.FirePumpStatus = temp.FirePumpStatus;
					weeklyInspectionResponseDTO.DerrickmanStatus = temp.DerrickmanStatus;
					weeklyInspectionResponseDTO.DerrickmanWeeklyFindings = temp.DerrickmanWeeklyFindings;
					weeklyInspectionResponseDTO.WorkingStatus = temp.WorkingStatus;
					weeklyInspectionResponseDTO.WorkingWeeklyFindings = temp.WorkingWeeklyFindings;
					weeklyInspectionResponseDTO.PortableLadderStatus = temp.PortableLadderStatus;
					weeklyInspectionResponseDTO.PortableLadderWeeklyFindings = temp.PortableLadderWeeklyFindings;
					weeklyInspectionResponseDTO.SafetyStatus = temp.SafetyStatus;
					weeklyInspectionResponseDTO.SafetyWeeklyFindings = temp.SafetyWeeklyFindings;
					weeklyInspectionResponseDTO.FallStatus = temp.FallStatus;
					weeklyInspectionResponseDTO.FallWeeklyFindings = temp.FallWeeklyFindings;
					weeklyInspectionResponseDTO.CraneStatus = temp.CraneStatus;
					weeklyInspectionResponseDTO.CraneWeeklyFindings = temp.CraneWeeklyFindings;
					weeklyInspectionResponseDTO.ForkStatus = temp.ForkStatus;
					weeklyInspectionResponseDTO.ForkWeeklyFindings = temp.ForkWeeklyFindings;
					weeklyInspectionResponseDTO.DroppedInspectionStatus = temp.DroppedInspectionStatus;
					weeklyInspectionResponseDTO.DroppedInspectionWeeklyFindings = temp.DroppedInspectionWeeklyFindings;
					weeklyInspectionResponseDTO.ElectricalStatus = temp.ElectricalStatus;
					weeklyInspectionResponseDTO.EarthingWeeklyFindings = temp.EarthingWeeklyFindings;
					weeklyInspectionResponseDTO.EarthingMaximum = temp.EarthingMaximum;
					weeklyInspectionResponseDTO.EarthingMin = temp.EarthingMin;
					weeklyInspectionResponseDTO.Code = temp.Code;
					weeklyInspectionResponseDTO.Name = temp.Name;
					weeklyInspectionResponseDTO.PositionName = temp.PositionName;

					weeklyInspectionResponseDTO.WeldingStatus = temp.WeldingStatus;
					weeklyInspectionResponseDTO.WeldingWeeklyFindings = temp.WeldingWeeklyFindings;
					weeklyInspectionResponseDTO.ElectricalWeeklyFindings = temp.ElectricalWeeklyFindings;
					weeklyInspectionResponseDTO.CircuitStatus = temp.CircuitStatus;
					weeklyInspectionResponseDTO.CircuitWeeklyFindings = temp.CircuitWeeklyFindings;
					weeklyInspectionResponseDTO.EarthingStatus = temp.EarthingStatus;

					weeklyInspectionResponseDTO.userName = temp.user.UserName;
					weeklyInspectionResponseDTO.userID = temp.user.Id;


					if (weeklyInspectionResponseDTO != null)
					{

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = weeklyInspectionResponseDTO;

						return result;
					}
				}

			}

			result.Statescode = 404;
			result.Message = "data not found";
			return result;
		}


		//  ------------------ filter by weeklyInspection ------------------------------------------

		[HttpGet("GetAllWithDataByRigNumerAndDate/{UserId}")]
		public ActionResult<ResultDTO> GetAllWithDataByRigNumerAndDate(string UserId, string date, string UserRole, int RigNumber)
		{
			DateTime dateObject = DateTime.Parse(date);
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<WeeklyInspection> weeklyInspections = WeeklyInspectionRepository.getall().Where(a => a.Rig.Number == RigNumber && a.Date == dateObject).ToList();
					List<WeeklyInspectionResponseDTO> weeklyInspectionResponseDTOs = new List<WeeklyInspectionResponseDTO>();
					foreach (WeeklyInspection weeklyInspection in weeklyInspections)
					{
						WeeklyInspectionResponseDTO weeklyInspectionResponseDTO = new WeeklyInspectionResponseDTO();
						weeklyInspectionResponseDTO.Id = weeklyInspection.Id;
						weeklyInspectionResponseDTO.RigId = weeklyInspection.Rig.Number;
						weeklyInspectionResponseDTO.Date = weeklyInspection.Date;
						weeklyInspectionResponseDTO.WellName = weeklyInspection.WellName;
						weeklyInspectionResponseDTO.Client = weeklyInspection.Client;
						weeklyInspectionResponseDTO.EyeStatus = weeklyInspection.EyeStatus;
						weeklyInspectionResponseDTO.EyeWeeklyFindings = weeklyInspection.EyeWeeklyFindings;
						weeklyInspectionResponseDTO.FirstAidStatus = weeklyInspection.FirstAidStatus;
						weeklyInspectionResponseDTO.FirstAidWeeklyFindings = weeklyInspection.FirstAidWeeklyFindings;
						weeklyInspectionResponseDTO.ScbaStatus = weeklyInspection.ScbaStatus;
						weeklyInspectionResponseDTO.ScbaWeeklyFindings = weeklyInspection.ScbaWeeklyFindings;
						weeklyInspectionResponseDTO.Scba30min = weeklyInspection.Scba30min;
						weeklyInspectionResponseDTO.Scba15min = weeklyInspection.Scba15min;
						weeklyInspectionResponseDTO.Scba10min = weeklyInspection.Scba10min;
						weeklyInspectionResponseDTO.PortableGasStatus = weeklyInspection.PortableGasStatus;
						weeklyInspectionResponseDTO.PortableGasWeeklyFindings = weeklyInspection.PortableGasWeeklyFindings;
						weeklyInspectionResponseDTO.PortableGasMuti = weeklyInspection.PortableGasMuti;
						weeklyInspectionResponseDTO.PortableGasSingle = weeklyInspection.PortableGasSingle;
						weeklyInspectionResponseDTO.ExpeiryDate = weeklyInspection.ExpeiryDate;
						weeklyInspectionResponseDTO.FireExtinguishersWeeklyFindings = weeklyInspection.FireExtinguishersWeeklyFindings;
						weeklyInspectionResponseDTO.FireExtinguishersStatus = weeklyInspection.FireExtinguishersStatus;
						weeklyInspectionResponseDTO.SmokeWeeklyFindings = weeklyInspection.SmokeWeeklyFindings;
						weeklyInspectionResponseDTO.SmokeStatus = weeklyInspection.SmokeStatus;
						weeklyInspectionResponseDTO.WindWeeklyFindings = weeklyInspection.WindWeeklyFindings;
						weeklyInspectionResponseDTO.WindStatus = weeklyInspection.WindStatus;
						weeklyInspectionResponseDTO.FirePumpWeeklyFindings = weeklyInspection.FirePumpWeeklyFindings;
						weeklyInspectionResponseDTO.FirePumpStatus = weeklyInspection.FirePumpStatus;
						weeklyInspectionResponseDTO.DerrickmanStatus = weeklyInspection.DerrickmanStatus;
						weeklyInspectionResponseDTO.DerrickmanWeeklyFindings = weeklyInspection.DerrickmanWeeklyFindings;
						weeklyInspectionResponseDTO.WorkingStatus = weeklyInspection.WorkingStatus;
						weeklyInspectionResponseDTO.WorkingWeeklyFindings = weeklyInspection.WorkingWeeklyFindings;
						weeklyInspectionResponseDTO.PortableLadderStatus = weeklyInspection.PortableLadderStatus;
						weeklyInspectionResponseDTO.PortableLadderWeeklyFindings = weeklyInspection.PortableLadderWeeklyFindings;
						weeklyInspectionResponseDTO.SafetyStatus = weeklyInspection.SafetyStatus;
						weeklyInspectionResponseDTO.SafetyWeeklyFindings = weeklyInspection.SafetyWeeklyFindings;
						weeklyInspectionResponseDTO.FallStatus = weeklyInspection.FallStatus;
						weeklyInspectionResponseDTO.FallWeeklyFindings = weeklyInspection.FallWeeklyFindings;
						weeklyInspectionResponseDTO.CraneStatus = weeklyInspection.CraneStatus;
						weeklyInspectionResponseDTO.CraneWeeklyFindings = weeklyInspection.CraneWeeklyFindings;
						weeklyInspectionResponseDTO.ForkStatus = weeklyInspection.ForkStatus;
						weeklyInspectionResponseDTO.ForkWeeklyFindings = weeklyInspection.ForkWeeklyFindings;
						weeklyInspectionResponseDTO.DroppedInspectionStatus = weeklyInspection.DroppedInspectionStatus;
						weeklyInspectionResponseDTO.DroppedInspectionWeeklyFindings = weeklyInspection.DroppedInspectionWeeklyFindings;
						weeklyInspectionResponseDTO.ElectricalStatus = weeklyInspection.ElectricalStatus;
						weeklyInspectionResponseDTO.EarthingWeeklyFindings = weeklyInspection.EarthingWeeklyFindings;
						weeklyInspectionResponseDTO.EarthingMaximum = weeklyInspection.EarthingMaximum;
						weeklyInspectionResponseDTO.EarthingMin = weeklyInspection.EarthingMin;
						weeklyInspectionResponseDTO.Code = weeklyInspection.Code;
						weeklyInspectionResponseDTO.Name = weeklyInspection.Name;
						weeklyInspectionResponseDTO.PositionName = weeklyInspection.PositionName;

						weeklyInspectionResponseDTO.WeldingStatus = weeklyInspection.WeldingStatus;
						weeklyInspectionResponseDTO.WeldingWeeklyFindings = weeklyInspection.WeldingWeeklyFindings;
						weeklyInspectionResponseDTO.ElectricalWeeklyFindings = weeklyInspection.ElectricalWeeklyFindings;
						weeklyInspectionResponseDTO.CircuitStatus = weeklyInspection.CircuitStatus;
						weeklyInspectionResponseDTO.CircuitWeeklyFindings = weeklyInspection.CircuitWeeklyFindings;
						weeklyInspectionResponseDTO.EarthingStatus = weeklyInspection.EarthingStatus;

						weeklyInspectionResponseDTO.userName = weeklyInspection.user.UserName;
						weeklyInspectionResponseDTO.userID = weeklyInspection.user.Id;



						weeklyInspectionResponseDTOs.Add(weeklyInspectionResponseDTO);
					}


					result.Message = "Success";
					result.Data = weeklyInspectionResponseDTOs;
					result.Statescode = 200;
					return result;
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{

					List<WeeklyInspection> weeklyInspections = WeeklyInspectionRepository.getall().Where(a => a.Rig.Number == RigNumber && a.Date == dateObject && a.user.Id == UserId).ToList();
					List<WeeklyInspectionResponseDTO> weeklyInspectionResponseDTOs = new List<WeeklyInspectionResponseDTO>();
					foreach (WeeklyInspection weeklyInspection in weeklyInspections)
					{
						WeeklyInspectionResponseDTO weeklyInspectionResponseDTO = new WeeklyInspectionResponseDTO();
						weeklyInspectionResponseDTO.Id = weeklyInspection.Id;
						weeklyInspectionResponseDTO.RigId = weeklyInspection.Rig.Number;
						weeklyInspectionResponseDTO.Date = weeklyInspection.Date;
						weeklyInspectionResponseDTO.WellName = weeklyInspection.WellName;
						weeklyInspectionResponseDTO.Client = weeklyInspection.Client;
						weeklyInspectionResponseDTO.EyeStatus = weeklyInspection.EyeStatus;
						weeklyInspectionResponseDTO.EyeWeeklyFindings = weeklyInspection.EyeWeeklyFindings;
						weeklyInspectionResponseDTO.FirstAidStatus = weeklyInspection.FirstAidStatus;
						weeklyInspectionResponseDTO.FirstAidWeeklyFindings = weeklyInspection.FirstAidWeeklyFindings;
						weeklyInspectionResponseDTO.ScbaStatus = weeklyInspection.ScbaStatus;
						weeklyInspectionResponseDTO.ScbaWeeklyFindings = weeklyInspection.ScbaWeeklyFindings;
						weeklyInspectionResponseDTO.Scba30min = weeklyInspection.Scba30min;
						weeklyInspectionResponseDTO.Scba15min = weeklyInspection.Scba15min;
						weeklyInspectionResponseDTO.Scba10min = weeklyInspection.Scba10min;
						weeklyInspectionResponseDTO.PortableGasStatus = weeklyInspection.PortableGasStatus;
						weeklyInspectionResponseDTO.PortableGasWeeklyFindings = weeklyInspection.PortableGasWeeklyFindings;
						weeklyInspectionResponseDTO.PortableGasMuti = weeklyInspection.PortableGasMuti;
						weeklyInspectionResponseDTO.PortableGasSingle = weeklyInspection.PortableGasSingle;
						weeklyInspectionResponseDTO.ExpeiryDate = weeklyInspection.ExpeiryDate;
						weeklyInspectionResponseDTO.FireExtinguishersWeeklyFindings = weeklyInspection.FireExtinguishersWeeklyFindings;
						weeklyInspectionResponseDTO.FireExtinguishersStatus = weeklyInspection.FireExtinguishersStatus;
						weeklyInspectionResponseDTO.SmokeWeeklyFindings = weeklyInspection.SmokeWeeklyFindings;
						weeklyInspectionResponseDTO.SmokeStatus = weeklyInspection.SmokeStatus;
						weeklyInspectionResponseDTO.WindWeeklyFindings = weeklyInspection.WindWeeklyFindings;
						weeklyInspectionResponseDTO.WindStatus = weeklyInspection.WindStatus;
						weeklyInspectionResponseDTO.FirePumpWeeklyFindings = weeklyInspection.FirePumpWeeklyFindings;
						weeklyInspectionResponseDTO.FirePumpStatus = weeklyInspection.FirePumpStatus;
						weeklyInspectionResponseDTO.DerrickmanStatus = weeklyInspection.DerrickmanStatus;
						weeklyInspectionResponseDTO.DerrickmanWeeklyFindings = weeklyInspection.DerrickmanWeeklyFindings;
						weeklyInspectionResponseDTO.WorkingStatus = weeklyInspection.WorkingStatus;
						weeklyInspectionResponseDTO.WorkingWeeklyFindings = weeklyInspection.WorkingWeeklyFindings;
						weeklyInspectionResponseDTO.PortableLadderStatus = weeklyInspection.PortableLadderStatus;
						weeklyInspectionResponseDTO.PortableLadderWeeklyFindings = weeklyInspection.PortableLadderWeeklyFindings;
						weeklyInspectionResponseDTO.SafetyStatus = weeklyInspection.SafetyStatus;
						weeklyInspectionResponseDTO.SafetyWeeklyFindings = weeklyInspection.SafetyWeeklyFindings;
						weeklyInspectionResponseDTO.FallStatus = weeklyInspection.FallStatus;
						weeklyInspectionResponseDTO.FallWeeklyFindings = weeklyInspection.FallWeeklyFindings;
						weeklyInspectionResponseDTO.CraneStatus = weeklyInspection.CraneStatus;
						weeklyInspectionResponseDTO.CraneWeeklyFindings = weeklyInspection.CraneWeeklyFindings;
						weeklyInspectionResponseDTO.ForkStatus = weeklyInspection.ForkStatus;
						weeklyInspectionResponseDTO.ForkWeeklyFindings = weeklyInspection.ForkWeeklyFindings;
						weeklyInspectionResponseDTO.DroppedInspectionStatus = weeklyInspection.DroppedInspectionStatus;
						weeklyInspectionResponseDTO.DroppedInspectionWeeklyFindings = weeklyInspection.DroppedInspectionWeeklyFindings;
						weeklyInspectionResponseDTO.ElectricalStatus = weeklyInspection.ElectricalStatus;
						weeklyInspectionResponseDTO.EarthingWeeklyFindings = weeklyInspection.EarthingWeeklyFindings;
						weeklyInspectionResponseDTO.EarthingMaximum = weeklyInspection.EarthingMaximum;
						weeklyInspectionResponseDTO.EarthingMin = weeklyInspection.EarthingMin;
						weeklyInspectionResponseDTO.Code = weeklyInspection.Code;
						weeklyInspectionResponseDTO.Name = weeklyInspection.Name;
						weeklyInspectionResponseDTO.PositionName = weeklyInspection.PositionName;

						weeklyInspectionResponseDTO.WeldingStatus = weeklyInspection.WeldingStatus;
						weeklyInspectionResponseDTO.WeldingWeeklyFindings = weeklyInspection.WeldingWeeklyFindings;
						weeklyInspectionResponseDTO.ElectricalWeeklyFindings = weeklyInspection.ElectricalWeeklyFindings;
						weeklyInspectionResponseDTO.CircuitStatus = weeklyInspection.CircuitStatus;
						weeklyInspectionResponseDTO.CircuitWeeklyFindings = weeklyInspection.CircuitWeeklyFindings;
						weeklyInspectionResponseDTO.EarthingStatus = weeklyInspection.EarthingStatus;

						weeklyInspectionResponseDTO.userName = weeklyInspection.user.UserName;
						weeklyInspectionResponseDTO.userID = weeklyInspection.user.Id;



						weeklyInspectionResponseDTOs.Add(weeklyInspectionResponseDTO);
					}

					result.Message = "Success";
					result.Data = weeklyInspectionResponseDTOs;
					result.Statescode = 200;
					return result;
				}

			}
			catch (Exception ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}

			return result;

		}


		[HttpPost]
		public ActionResult<ResultDTO> AddWeeklyInspection([FromForm] WeeklyInspectionDTO weeklyInspection)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{

					WeeklyInspection weeklyInspectionObj = new WeeklyInspection();
					weeklyInspectionObj.Id = default;
					weeklyInspectionObj.RigId = weeklyInspection.RigId;
					weeklyInspectionObj.Date = weeklyInspection.Date;
					weeklyInspectionObj.WellName = weeklyInspection.WellName;
					weeklyInspectionObj.Client = weeklyInspection.Client;
					weeklyInspectionObj.EyeStatus = weeklyInspection.EyeStatus;
					weeklyInspectionObj.EyeWeeklyFindings = weeklyInspection.EyeWeeklyFindings;
					weeklyInspectionObj.FirstAidStatus = weeklyInspection.FirstAidStatus;
					weeklyInspectionObj.FirstAidWeeklyFindings = weeklyInspection.FirstAidWeeklyFindings;
					weeklyInspectionObj.ScbaStatus = weeklyInspection.ScbaStatus;
					weeklyInspectionObj.ScbaWeeklyFindings = weeklyInspection.ScbaWeeklyFindings;
					weeklyInspectionObj.Scba30min = weeklyInspection.Scba30min;
					weeklyInspectionObj.Scba15min = weeklyInspection.Scba15min;
					weeklyInspectionObj.Scba10min = weeklyInspection.Scba10min;
					weeklyInspectionObj.PortableGasStatus = weeklyInspection.PortableGasStatus;
					weeklyInspectionObj.PortableGasWeeklyFindings = weeklyInspection.PortableGasWeeklyFindings;
					weeklyInspectionObj.PortableGasMuti = weeklyInspection.PortableGasMuti;
					weeklyInspectionObj.PortableGasSingle = weeklyInspection.PortableGasSingle;
					weeklyInspectionObj.ExpeiryDate = weeklyInspection.ExpeiryDate;
					weeklyInspectionObj.FireExtinguishersWeeklyFindings = weeklyInspection.FireExtinguishersWeeklyFindings;
					weeklyInspectionObj.FireExtinguishersStatus = weeklyInspection.FireExtinguishersStatus;
					weeklyInspectionObj.SmokeWeeklyFindings = weeklyInspection.SmokeWeeklyFindings;
					weeklyInspectionObj.SmokeStatus = weeklyInspection.SmokeStatus;
					weeklyInspectionObj.WindWeeklyFindings = weeklyInspection.WindWeeklyFindings;
					weeklyInspectionObj.WindStatus = weeklyInspection.WindStatus;
					weeklyInspectionObj.FirePumpWeeklyFindings = weeklyInspection.FirePumpWeeklyFindings;
					weeklyInspectionObj.FirePumpStatus = weeklyInspection.FirePumpStatus;
					weeklyInspectionObj.DerrickmanStatus = weeklyInspection.DerrickmanStatus;
					weeklyInspectionObj.DerrickmanWeeklyFindings = weeklyInspection.DerrickmanWeeklyFindings;
					weeklyInspectionObj.WorkingStatus = weeklyInspection.WorkingStatus;
					weeklyInspectionObj.WorkingWeeklyFindings = weeklyInspection.WorkingWeeklyFindings;
					weeklyInspectionObj.PortableLadderStatus = weeklyInspection.PortableLadderStatus;
					weeklyInspectionObj.PortableLadderWeeklyFindings = weeklyInspection.PortableLadderWeeklyFindings;
					weeklyInspectionObj.SafetyStatus = weeklyInspection.SafetyStatus;
					weeklyInspectionObj.SafetyWeeklyFindings = weeklyInspection.SafetyWeeklyFindings;
					weeklyInspectionObj.FallStatus = weeklyInspection.FallStatus;
					weeklyInspectionObj.FallWeeklyFindings = weeklyInspection.FallWeeklyFindings;
					weeklyInspectionObj.CraneStatus = weeklyInspection.CraneStatus;
					weeklyInspectionObj.CraneWeeklyFindings = weeklyInspection.CraneWeeklyFindings;
					weeklyInspectionObj.ForkStatus = weeklyInspection.ForkStatus;
					weeklyInspectionObj.ForkWeeklyFindings = weeklyInspection.ForkWeeklyFindings;
					weeklyInspectionObj.DroppedInspectionStatus = weeklyInspection.DroppedInspectionStatus;
					weeklyInspectionObj.DroppedInspectionWeeklyFindings = weeklyInspection.DroppedInspectionWeeklyFindings;
					weeklyInspectionObj.ElectricalStatus = weeklyInspection.ElectricalStatus;
					weeklyInspectionObj.EarthingWeeklyFindings = weeklyInspection.EarthingWeeklyFindings;
					weeklyInspectionObj.EarthingMaximum = weeklyInspection.EarthingMaximum;
					weeklyInspectionObj.EarthingMin = weeklyInspection.EarthingMin;
					weeklyInspectionObj.Code = weeklyInspection.Code;
					weeklyInspectionObj.Name = weeklyInspection.Name;
					weeklyInspectionObj.PositionName = weeklyInspection.PositionName;
					weeklyInspectionObj.WeldingStatus = weeklyInspection.WeldingStatus;
					weeklyInspectionObj.WeldingWeeklyFindings = weeklyInspection.WeldingWeeklyFindings;
					weeklyInspectionObj.ElectricalWeeklyFindings = weeklyInspection.ElectricalWeeklyFindings;
					weeklyInspectionObj.CircuitStatus = weeklyInspection.CircuitStatus;
					weeklyInspectionObj.CircuitWeeklyFindings = weeklyInspection.CircuitWeeklyFindings;
					weeklyInspectionObj.EarthingStatus = weeklyInspection.EarthingStatus;

					weeklyInspectionObj.userID = weeklyInspection.userID;

					WeeklyInspectionRepo.create(weeklyInspectionObj);


					result.Message = "Success";
					result.Data = weeklyInspectionObj;
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
		public ActionResult<ResultDTO> Put(int id, [FromForm] WeeklyInspectionResponseDTO newweeklyInspection) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					WeeklyInspection orgweeklyInspection = WeeklyInspectionRepo.getbyid(id);

					newweeklyInspection.Id = orgweeklyInspection.Id;
					orgweeklyInspection.RigId = newweeklyInspection.RigId;
					orgweeklyInspection.Date = newweeklyInspection.Date;
					orgweeklyInspection.WellName = newweeklyInspection.WellName;
					orgweeklyInspection.Client = newweeklyInspection.Client;
					orgweeklyInspection.EyeStatus = newweeklyInspection.EyeStatus;
					orgweeklyInspection.EyeWeeklyFindings = newweeklyInspection.EyeWeeklyFindings;
					orgweeklyInspection.FirstAidStatus = newweeklyInspection.FirstAidStatus;
					orgweeklyInspection.FirstAidWeeklyFindings = newweeklyInspection.FirstAidWeeklyFindings;
					orgweeklyInspection.ScbaStatus = newweeklyInspection.ScbaStatus;
					orgweeklyInspection.ScbaWeeklyFindings = newweeklyInspection.ScbaWeeklyFindings;
					orgweeklyInspection.Scba30min = newweeklyInspection.Scba30min;
					orgweeklyInspection.Scba15min = newweeklyInspection.Scba15min;
					orgweeklyInspection.Scba10min = newweeklyInspection.Scba10min;
					orgweeklyInspection.PortableGasStatus = newweeklyInspection.PortableGasStatus;
					orgweeklyInspection.PortableGasWeeklyFindings = newweeklyInspection.PortableGasWeeklyFindings;
					orgweeklyInspection.PortableGasMuti = newweeklyInspection.PortableGasMuti;
					orgweeklyInspection.PortableGasSingle = newweeklyInspection.PortableGasSingle;
					orgweeklyInspection.ExpeiryDate = newweeklyInspection.ExpeiryDate;
					orgweeklyInspection.FireExtinguishersWeeklyFindings = newweeklyInspection.FireExtinguishersWeeklyFindings;
					orgweeklyInspection.FireExtinguishersStatus = newweeklyInspection.FireExtinguishersStatus;
					orgweeklyInspection.SmokeWeeklyFindings = newweeklyInspection.SmokeWeeklyFindings;
					orgweeklyInspection.SmokeStatus = newweeklyInspection.SmokeStatus;
					orgweeklyInspection.WindWeeklyFindings = newweeklyInspection.WindWeeklyFindings;
					orgweeklyInspection.WindStatus = newweeklyInspection.WindStatus;
					orgweeklyInspection.FirePumpWeeklyFindings = newweeklyInspection.FirePumpWeeklyFindings;
					orgweeklyInspection.FirePumpStatus = newweeklyInspection.FirePumpStatus;
					orgweeklyInspection.DerrickmanStatus = newweeklyInspection.DerrickmanStatus;
					orgweeklyInspection.DerrickmanWeeklyFindings = newweeklyInspection.DerrickmanWeeklyFindings;
					orgweeklyInspection.WorkingStatus = newweeklyInspection.WorkingStatus;
					orgweeklyInspection.WorkingWeeklyFindings = newweeklyInspection.WorkingWeeklyFindings;
					orgweeklyInspection.PortableLadderStatus = newweeklyInspection.PortableLadderStatus;
					orgweeklyInspection.PortableLadderWeeklyFindings = newweeklyInspection.PortableLadderWeeklyFindings;
					orgweeklyInspection.SafetyStatus = newweeklyInspection.SafetyStatus;
					orgweeklyInspection.SafetyWeeklyFindings = newweeklyInspection.SafetyWeeklyFindings;
					orgweeklyInspection.FallStatus = newweeklyInspection.FallStatus;
					orgweeklyInspection.FallWeeklyFindings = newweeklyInspection.FallWeeklyFindings;
					orgweeklyInspection.CraneStatus = newweeklyInspection.CraneStatus;
					orgweeklyInspection.CraneWeeklyFindings = newweeklyInspection.CraneWeeklyFindings;
					orgweeklyInspection.ForkStatus = newweeklyInspection.ForkStatus;
					orgweeklyInspection.ForkWeeklyFindings = newweeklyInspection.ForkWeeklyFindings;
					orgweeklyInspection.DroppedInspectionStatus = newweeklyInspection.DroppedInspectionStatus;
					orgweeklyInspection.DroppedInspectionWeeklyFindings = newweeklyInspection.DroppedInspectionWeeklyFindings;
					orgweeklyInspection.ElectricalStatus = newweeklyInspection.ElectricalStatus;
					orgweeklyInspection.EarthingWeeklyFindings = newweeklyInspection.EarthingWeeklyFindings;
					orgweeklyInspection.EarthingMaximum = newweeklyInspection.EarthingMaximum;
					orgweeklyInspection.EarthingMin = newweeklyInspection.EarthingMin;
					orgweeklyInspection.Code = newweeklyInspection.Code;
					orgweeklyInspection.Name = newweeklyInspection.Name;
					orgweeklyInspection.PositionName = newweeklyInspection.PositionName;

					orgweeklyInspection.WeldingStatus = newweeklyInspection.WeldingStatus;
					orgweeklyInspection.WeldingWeeklyFindings = newweeklyInspection.WeldingWeeklyFindings;
					orgweeklyInspection.ElectricalWeeklyFindings = newweeklyInspection.ElectricalWeeklyFindings;
					orgweeklyInspection.CircuitStatus = newweeklyInspection.CircuitStatus;
					orgweeklyInspection.CircuitWeeklyFindings = newweeklyInspection.CircuitWeeklyFindings;
					orgweeklyInspection.EarthingStatus = newweeklyInspection.EarthingStatus;

					//orgweeklyInspection.userID = newweeklyInspection.userID;
					//orgweeklyInspection.user.UserName= newweeklyInspection.userName;


					WeeklyInspectionRepo.update(orgweeklyInspection);
					result.Data = orgweeklyInspection;
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
				WeeklyInspection weeklyInspection = WeeklyInspectionRepo.getbyid(id);
				weeklyInspection.IsDeleted = true;
				WeeklyInspectionRepo.update(weeklyInspection);
				result.Data = weeklyInspection;
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

