using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace TempProject.Models
{
    public class Context : IdentityDbContext
    {
        public DbSet<Accident> Accidents { get; set; }
        public DbSet<AccidentImages> AccidentImages { get; set; }
        public DbSet<RouteName> RouteNames { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<JMP> JMPs { get; set; }
        public DbSet<Driver> DriverNames { get; set; }
		public DbSet<EmpCode> EmpCodes  { get; set; }
		public DbSet<PotentialHazard> PotentialHazard { get; set; }
		public DbSet<HazardImages> HazardImages { get; set; }
		public DbSet<Responsibility> Responsibility { get; set; }

        public DbSet<PPEReceiving> PPEReceivings { get; set; }
    
        public DbSet<PPE> PPEs { get; set; }
       
        public DbSet<PPEAndPPEReceiving> PPEAndPPEReceivings { get; set; }
        public DbSet<ComminucationMethod> ComminucationMethods { get; set; }
        public DbSet<Crew> Crews { get; set; }
		public DbSet<DaysSinceNoLTI> DaysSinceNoLTI { get; set; }
		public DbSet<QHSEDailyReport> QHSEDailyReport { get; set; }
		public DbSet<Client> Client { get; set; }
		public DbSet<LTIPrevDateAndDays> LTIPrevDateAndDays { get; set; }

		public DbSet<LeaderShipVisitsAndQHSEDaily> LeaderShipVisitsAndQHSEDaily { get; set; }
		public DbSet<CrewQuizAndQHSEDaily> CrewQuizAndQHSEDaily { get; set; }
		public DbSet<CrewSaftyAlertAndQHSEDaily> CrewSaftyAlertAndQHSEDaily { get; set; }

		public DbSet<LeadershipVisit> LeadershipVisits { get; set; }
        public DbSet<RecordableAccident> RecordableAccidents { get; set; }
        public DbSet<NonRecordableAccident> NonRecordableAccidents { get; set; }
        //public DbSet<Drill> Drills { get; set; }
		public DbSet<StopCardRegister> StopCardRegisters { get; set; }
		public DbSet<Rig> Rigs { get; set; }
		public DbSet<Classification> Classifications { get; set; }
		public DbSet<ClassificationOfAccident> ClassificationOfAccidents { get; set; }
		public DbSet<PreventionCategory> PreventionCategorys { get; set; }
		public DbSet<AccidentCauses> AccidentCauses { get; set; }
		public DbSet<TypeOfInjury> TypeOfInjurys { get; set; }
		public DbSet<ViolationCategory> ViolationCategorys { get; set; }
		public DbSet<Positions> Positions { get; set; }

		public DbSet<EmployeeCompetencyEvaluation> EmployeeCompetencyEvaluation { get; set; }
		public DbSet<SubjectList> SubjectList { get; set; }
		//public DbSet<QHSEPosition> QHSEPositions { get; set; }
		//public DbSet<QHSEPositionName> QHSEPositionNames { get; set; }
		public DbSet<TypeOfObservationCategory> TypeOfObservationCategorys { get; set; }
		public DbSet<ReportedByPosition> ReportedByPositions { get; set; }
		public DbSet<ReportedByName> ReportedByNames { get; set; }
		public DbSet<RigMovePerformance> RigMovePerformances { get; set; }

		public DbSet<ProblemFacedDuringRigMove> ProblemFacedDuringRigMoves { get; set; }
		public DbSet<PTSM> PTSMs { get; set; }
		public DbSet<Attendance> Attendances { get; set; }

		public DbSet<Passenger> Passengers { get; set; }
        public DbSet<JMP_Passenger> JMP_Passengers { get; set; }

        public DbSet<BOP> Bop { get; set; }

        //------------Drill Report------------------------------------
        public DbSet<DrillImages> DrillImages { get; set; }
        public DbSet<DrillType> DrillTypes { get; set; }
        public DbSet<Drill> Drills { get; set; }
        public DbSet<EmergencyResponseTeamMembers> EmergencyResponseTeamMembers { get; set; }
        
		//------------Customer Report------------------------------------
        //public DbSet<Rating> Ratings { get; set; }
        public DbSet<CustomerReport> CustomerReports { get; set; }
        public DbSet<EvaluationCriteria> EvaluationCriterias { get; set; }

		//----------------Corrective Action Report------------------------

		public DbSet<CorrectiveAction> CorrectiveActions { get; set; }
		public DbSet<CorrectiveActionObservation> CorrectiveActionObservations { get; set; }
		public DbSet<CorrectiveAndObservation> CorrectiveAndObservations { get; set; }
		public DbSet<CorrectiveAndRootCauses> CorrectiveAndRootCauses { get; set; }
		public DbSet<CorrectiveDataTable> CorrectiveDataTables { get; set; }
		public DbSet<CorrectiveImages> CorrectiveImages { get; set; }
		public DbSet<Standard> Standards { get; set; }
		public DbSet<RootCauses> RootCauses { get; set; }
		public DbSet<CorrectiveResponsability> CorrectiveResponsabilitys { get; set; }

		//*************** Crane & Forklift *************************
		public DbSet<Forklift> Forklifts { get; set; }
		public DbSet<Crane> Cranes { get; set; }

		//*************** Weekly Clinic Report *************************
		public DbSet<WeeklyClinic> WeeklyClinics { get; set; }
		public DbSet<FridgeComponent> FridgeComponents { get; set; }
		public DbSet<DrugInventory> DrugInventorys { get; set; }

		//*************** Handover Report *************************
		public DbSet<Handover> Handovers { get; set; }
		public DbSet<ShiftDrillTypes> ShiftDrillTypes { get; set; }
		public DbSet<Visits> Visits { get; set; }
		public DbSet<HSEInventory> HSEInventorys { get; set; }
		public DbSet<HSEEquipment> HSEEquipments { get; set; }
		public DbSet<MaterialRequested> MaterialRequesteds { get; set; }

		//*************** Rig Certificate Report *************************
		public DbSet<RigCertificates> RigCertificates { get; set; }
		public DbSet<HoistingSystem> HoistingSystems { get; set; }
		public DbSet<RotarySystem> RotarySystems { get; set; }
		public DbSet<MudCirculationSystem> MudCirculationSystems { get; set; }
		public DbSet<WellControlSystem> WellControlSystems { get; set; }
		public DbSet<PowerSystem> PowerSystems { get; set; }
		public DbSet<OtherSystem> OtherSystems { get; set; }
		public DbSet<PresssureReliefValve> PresssureReliefValves { get; set; }
		public DbSet<HSEEquipmentList> HSEEquipmentLists { get; set; }
		public DbSet<HSEEquipmentTable> HSEEquipmentTables { get; set; }
		public DbSet<MobileCrane> RigCertMobileCranes { get; set; }
		public DbSet<RigCertForklift> RigCertForklifts { get; set; }
		public DbSet<AirHoist> AirHoists { get; set; }
		public DbSet<HydraulicWinch> HydraulicWinchs { get; set; }
		public DbSet<ManRidingWinch> ManRidingWinchs { get; set; }
		public DbSet<PersonnelCerificates> PersonnelCerificates { get; set; }
		public DbSet<CertificatesType> CertificatesTypes { get; set; }

		//------------ Weekly Inspection Report------------------------------------
		public DbSet<WeeklyInspection> WeeklyInspections { get; set; }
        public DbSet<WeeklyCampInspection> WeeklyCampInspections { get; set; }

        //------------ Medical Report------------------------------------
        public DbSet<MedicalReport> MedicalReports { get; set; }
        public DbSet<TypeOfIncident> TypeOfIncidents { get; set; }

        //------------ Medical Hisory Report------------------------------------
        public DbSet<MedicalHistoryReport> MedicalHistoryReports { get; set; }

//------------ Daily Lifting Report------------------------------------
        public DbSet<DailyLiftingReport> DailyLiftingReports { get; set; }
       
        public DbSet<SummaryDailyList> SummaryDailyLists { get; set; }
        public DbSet<PermitsToWorkList> PermitsToWorkLists { get; set; }
        public DbSet<DailyRecordStacticsList> DailyRecordStacticsLists { get; set; }
        public DbSet<ForkDailyLifting> forkDailyLiftings { get; set; }
        public DbSet<CraneDailyLifting> craneDailyLiftings { get; set; }

//------------ VehicleWeeklyChecklist------------------------------------
        public DbSet<VehicleWeeklyChecklist> VehicleWeeklyChecklists { get; set; }
        public DbSet<RigPickup> RigPickups { get; set; }
        public DbSet<LightBus> LightBuses { get; set; }
        public DbSet<HeavyTruck> HeavyTrucks { get; set; }
        public DbSet<ManPickup> ManPickups { get; set; }
        public Context(DbContextOptions c) : base(c)
        {
            
        }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			//modelBuilder.Entity<Crew>()
			//	.HasMany(c => c.QHSEDailyReport1)
			//	//WithOne(q => q.SafetyAlertCrew)
			//	.HasForeignKey(q => q.SafetyAlertCrewId);

			//modelBuilder.Entity<Crew>()
			//	.HasMany(c => c.QHSEDailyReport2)
			//	//.WithOne(q => q.QuizCrew)
			//	.HasForeignKey(q => q.QuizCrewId);

			//modelBuilder.Entity<IdentityUserLogin<string>>()
		 //  .HasKey(l => new { l.LoginProvider, l.ProviderKey });
		}


		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	//modelBuilder.Entity<RouteName>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<Vehicle>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<Driver>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<ComminucationMethod>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<Crew>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<LeadershipVisit>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<RecordableAccident>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<NonRecordableAccident>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<Drill>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<Rig>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<Classification>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<ClassificationOfAccident>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<PreventionCategory>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<AccidentCauses>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<TypeOfInjury>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<ViolationCategory>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<ToolPusherPosition>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<ToolPusherPositionName>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<QHSEPosition>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<QHSEPositionName>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<TypeOfObservationCategory>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<ReportedByPosition>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<ReportedByName>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<Passenger>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<JMP_Passenger>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//}




	}
}
