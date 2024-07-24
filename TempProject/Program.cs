
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Text;
using TempProject.Hubs;
using TempProject.Models;
using TempProject.Repository;
using static System.Net.Mime.MediaTypeNames;

namespace TempProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
			
			builder.Services.AddSignalR();

			// Add services to the container.
			builder.Services.AddCors(option => option.AddPolicy("my", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IRepository<Accident>, Repository<Accident>>();
            builder.Services.AddScoped<IRepository<EmployeeCompetencyEvaluation>, Repository<EmployeeCompetencyEvaluation>>();

            
            builder.Services.AddScoped<IRepository<NonRecordableAccident>, Repository<NonRecordableAccident>>();
            builder.Services.AddScoped<IRepository<RecordableAccident>, Repository<RecordableAccident>>();
            //builder.Services.AddScoped<IRepository<Drill>, Repository<Drill>>();
			builder.Services.AddScoped<IRepository<StopCardRegister>, Repository<StopCardRegister>>();
			builder.Services.AddScoped<IRepository<Rig>, Repository<Rig>>();
			builder.Services.AddScoped<IRepository<Classification>, Repository<Classification>>();
			builder.Services.AddScoped<IRepository<ClassificationOfAccident>, Repository<ClassificationOfAccident>>();
			builder.Services.AddScoped<IRepository<PreventionCategory>, Repository<PreventionCategory>>();
			builder.Services.AddScoped<IRepository<AccidentCauses>, Repository<AccidentCauses>>();
			builder.Services.AddScoped<IRepository<TypeOfInjury>, Repository<TypeOfInjury>>();
			builder.Services.AddScoped<IRepository<ViolationCategory>, Repository<ViolationCategory>>();
			//builder.Services.AddScoped<IRepository<ToolPusherPosition>, Repository<ToolPusherPosition>>();
			//builder.Services.AddScoped<IRepository<ToolPusherPositionName>, Repository<ToolPusherPositionName>>();
			//builder.Services.AddScoped<IRepository<QHSEPosition>, Repository<QHSEPosition>>();
			//builder.Services.AddScoped<IRepository<QHSEPositionName>, Repository<QHSEPositionName>>();

			//******************** QHSE Daily Report *******************
			builder.Services.AddScoped<IRepository<DaysSinceNoLTI>, Repository<DaysSinceNoLTI>>();
			builder.Services.AddScoped<IRepository<Crew>, Repository<Crew>>();
			builder.Services.AddScoped<IRepository<LeadershipVisit>, Repository<LeadershipVisit>>();
			builder.Services.AddScoped<IRepository<QHSEDailyReport>, Repository<QHSEDailyReport>>();
			builder.Services.AddScoped<IRepository<Client>, Repository<Client>>();
			builder.Services.AddScoped<IRepository<LTIPrevDateAndDays>, Repository<LTIPrevDateAndDays>>();
			builder.Services.AddScoped<IDaysSinceNoLTIRepossitory, DaysSinceNoLTIRepository>();


			builder.Services.AddScoped<IRepository<EmpCode>, Repository<EmpCode>>();
			builder.Services.AddScoped<IEmpCodeRepository, EmpCodeRepository>();

			builder.Services.AddScoped<IRepository<SubjectList>, Repository<SubjectList>>();
			builder.Services.AddScoped<IRepository<Responsibility>, Repository<Responsibility>>();
			builder.Services.AddScoped<IRepository<PotentialHazard>, Repository<PotentialHazard>>();
			builder.Services.AddScoped<IRepository<HazardImages>, Repository<HazardImages>>();
            builder.Services.AddScoped<IRepository<AccidentImages>, Repository<AccidentImages>>();
            builder.Services.AddScoped<IRepository<ReportedByPosition>, Repository<ReportedByPosition>>();
			builder.Services.AddScoped<IRepository<ReportedByName>, Repository<ReportedByName>>();
            builder.Services.AddScoped<IRepository<TypeOfObservationCategory>, Repository<TypeOfObservationCategory>>();
            builder.Services.AddScoped<IRepository<JMP>, Repository<JMP>>();
            builder.Services.AddScoped<IRepository<RouteName>, Repository<RouteName>>();
			builder.Services.AddScoped<IRepository<Positions>, Repository<Positions>>();
			builder.Services.AddScoped<IRepository<Driver>, Repository<Driver>>();
            builder.Services.AddScoped<IRepository<ComminucationMethod>, Repository<ComminucationMethod>>();
            builder.Services.AddScoped<IRepository<Vehicle>, Repository<Vehicle>>();
            builder.Services.AddScoped<IRepository<Passenger>, Repository<Passenger>>();
			builder.Services.AddScoped<IRepository<JMP_Passenger>, Repository<JMP_Passenger>>();
			builder.Services.AddScoped<IRepository<PTSM>, Repository<PTSM>>();
			builder.Services.AddScoped<IRepository<Attendance>, Repository<Attendance>>();
			builder.Services.AddScoped<IAccidentRepository, AccidentRepository>();
			builder.Services.AddScoped<IStopCardRepository, StopCardRepository>();
			builder.Services.AddScoped<IPTSMRepository, PTSMRepository>();
			builder.Services.AddScoped<IJMPRepository, JMPRepository>();
			builder.Services.AddScoped<IRepository<RigMovePerformance>, Repository<RigMovePerformance>>();
            builder.Services.AddScoped<IRepository<ProblemFacedDuringRigMove>, Repository<ProblemFacedDuringRigMove>>();
            builder.Services.AddScoped<IRigMovePerformanceRepository, RigMovePerformanceRepository>();
            builder.Services.AddScoped<IEmployeeCompetencyEvaluationRepository, EmployeeCompetencyEvaluationRepository>();
			builder.Services.AddScoped<IPotentialHazardRepository,PotentialHazardRepository>();
			builder.Services.AddScoped<IBOPRepossitory,BOPRepository>();
            builder.Services.AddScoped<IRepository<BOP> , Repository<BOP>>();
			builder.Services.AddScoped<IQHSEDailyReportRepository, QHSEDailyReportRepository>();

			builder.Services.AddScoped<IRepository<PPE>, Repository<PPE>>();
            builder.Services.AddScoped<IRepository<PPEReceiving>, Repository<PPEReceiving>>();
            builder.Services.AddScoped<IPPEReceivingRepository, PPEReceivingRepository>();
            builder.Services.AddScoped<IRepository<PPEAndPPEReceiving>, Repository<PPEAndPPEReceiving>>();
			builder.Services.AddScoped<IRepository<CrewQuizAndQHSEDaily>, Repository<CrewQuizAndQHSEDaily>>();
			builder.Services.AddScoped<IRepository<CrewSaftyAlertAndQHSEDaily>, Repository<CrewSaftyAlertAndQHSEDaily>>();
			builder.Services.AddScoped<IRepository<LeaderShipVisitsAndQHSEDaily>, Repository<LeaderShipVisitsAndQHSEDaily>>();

			//////---------Drill Report----------------------

			builder.Services.AddScoped<IRepository<DrillType>, Repository<DrillType>>();
            builder.Services.AddScoped<IRepository<Drill>, Repository<Drill>>();
            builder.Services.AddScoped<IRepository<DrillImages>, Repository<DrillImages>>();
            builder.Services.AddScoped<IDrillRepository, DrillRepository>();
            builder.Services.AddScoped<IRepository<EmergencyResponseTeamMembers>, Repository<EmergencyResponseTeamMembers>>();

            //--------- Customer Report----------------------

            //builder.Services.AddScoped<IRepository<Rating>, Repository<Rating>>();
            builder.Services.AddScoped<IRepository<CustomerReport>, Repository<CustomerReport>>();
            builder.Services.AddScoped<ICustomerReportRepository, CustomerReportRepository>();
            builder.Services.AddScoped<IRepository<EvaluationCriteria>, Repository<EvaluationCriteria>>();

			//************ Corrective Action Report *************
			builder.Services.AddScoped<IRepository<Standard>, Repository<Standard>>();
			builder.Services.AddScoped<IRepository<RootCauses>, Repository<RootCauses>>();
			builder.Services.AddScoped<IRepository<CorrectiveActionObservation>, Repository<CorrectiveActionObservation>>();
			builder.Services.AddScoped<IRepository<CorrectiveAction>, Repository<CorrectiveAction>>();
			builder.Services.AddScoped<IRepository<CorrectiveImages>, Repository<CorrectiveImages>>();
			builder.Services.AddScoped<IRepository<CorrectiveDataTable>, Repository<CorrectiveDataTable>>();
			builder.Services.AddScoped<IRepository<CorrectiveAndRootCauses>, Repository<CorrectiveAndRootCauses>>();
			builder.Services.AddScoped<IRepository<CorrectiveAndObservation>, Repository<CorrectiveAndObservation>>();
			builder.Services.AddScoped<ICorrectiveActionRepository, CorrectiveActionRepository>();
			builder.Services.AddScoped<IRepository<CorrectiveResponsability>, Repository<CorrectiveResponsability>>();

			//************** Forklift & Crane ******************
			builder.Services.AddScoped<IRepository<Forklift>, Repository<Forklift>>();
			builder.Services.AddScoped<IRepository<Crane>, Repository<Crane>>();
			builder.Services.AddScoped<ICraneRepository, CraneRepository>();
			builder.Services.AddScoped<IForkliftRepository, ForkliftRepository>();

			//************** Weekly Clinic Report ******************
			builder.Services.AddScoped<IWeeklyClinicRepository, WeeklyClinicRepository>();
			builder.Services.AddScoped<IRepository<WeeklyClinic>, Repository<WeeklyClinic>>();
			builder.Services.AddScoped<IRepository<FridgeComponent>, Repository<FridgeComponent>>();
			builder.Services.AddScoped<IRepository<DrugInventory>, Repository<DrugInventory>>();

			//************** Handover Report ******************
			builder.Services.AddScoped<IHandoverRepository, HandoverRepository>();
			builder.Services.AddScoped<IRepository<Handover>, Repository<Handover>>();
			builder.Services.AddScoped<IRepository<ShiftDrillTypes>, Repository<ShiftDrillTypes>>();
			builder.Services.AddScoped<IRepository<Visits>, Repository<Visits>>();
			builder.Services.AddScoped<IRepository<HSEInventory>, Repository<HSEInventory>>();
			builder.Services.AddScoped<IRepository<HSEEquipment>, Repository<HSEEquipment>>();
			builder.Services.AddScoped<IRepository<MaterialRequested>, Repository<MaterialRequested>>();
			
            //************** Rig Certificattes Report ******************
			builder.Services.AddScoped<IRigCertificatesRepository, RigCertificatesRepository>();
			builder.Services.AddScoped<IRepository<RigCertificates>, Repository<RigCertificates>>();
			builder.Services.AddScoped<IRepository<MobileCrane>, Repository<MobileCrane>>();
			builder.Services.AddScoped<IRepository<RigCertForklift>, Repository<RigCertForklift>>();
			builder.Services.AddScoped<IRepository<AirHoist>, Repository<AirHoist>>();
			builder.Services.AddScoped<IRepository<ManRidingWinch>, Repository<ManRidingWinch>>();
			builder.Services.AddScoped<IRepository<HydraulicWinch>, Repository<HydraulicWinch>>();
			builder.Services.AddScoped<IRepository<HSEEquipmentTable>, Repository<HSEEquipmentTable>>();
			builder.Services.AddScoped<IRepository<HoistingSystem>, Repository<HoistingSystem>>();
			builder.Services.AddScoped<IRepository<RotarySystem>, Repository<RotarySystem>>();
			builder.Services.AddScoped<IRepository<MudCirculationSystem>, Repository<MudCirculationSystem>>();
			builder.Services.AddScoped<IRepository<WellControlSystem>, Repository<WellControlSystem>>();
			builder.Services.AddScoped<IRepository<PowerSystem>, Repository<PowerSystem>>();
			builder.Services.AddScoped<IRepository<OtherSystem>, Repository<OtherSystem>>();
			builder.Services.AddScoped<IRepository<PresssureReliefValve>, Repository<PresssureReliefValve>>();
			builder.Services.AddScoped<IRepository<PersonnelCerificates>, Repository<PersonnelCerificates>>();
			builder.Services.AddScoped<IRepository<HSEEquipmentList>, Repository<HSEEquipmentList>>();
			builder.Services.AddScoped<IRepository<CertificatesType>, Repository<CertificatesType>>();

			//--------- Weekly & Camp Inspection Report ----------------------
			builder.Services.AddScoped<IRepository<WeeklyInspection>, Repository<WeeklyInspection>>();
            builder.Services.AddScoped<IWeeklyInspectionRepository, WeeklyInspectionRepository>();

            builder.Services.AddScoped<IRepository<WeeklyCampInspection>, Repository<WeeklyCampInspection>>();
            builder.Services.AddScoped<IWeeklyCampInspectionRepository, WeeklyCampInspectionRepository>();

            //--------- Medical Report ----------------------
            builder.Services.AddScoped<IRepository<MedicalReport>, Repository<MedicalReport>>();
            builder.Services.AddScoped<IRepository<TypeOfIncident>, Repository<TypeOfIncident>>();
            builder.Services.AddScoped<IMedicalReportRepossitory, MedicalReportRepository>();


			//--------- Medical History Report ----------------------


			builder.Services.AddScoped<IRepository<MedicalHistoryReport>, Repository<MedicalHistoryReport>>();
			builder.Services.AddScoped<IMedicalHistoryReportRepository, MedicalHistoryReportRepository>();



  //////---------Daily Lifting Report----------------------

            builder.Services.AddScoped<IRepository<DailyLiftingReport>, Repository<DailyLiftingReport>>();
            builder.Services.AddScoped<IRepository<SummaryDailyList>, Repository<SummaryDailyList>>();
            builder.Services.AddScoped<IDailyLiftingReportRepository, DailyLiftingReportRepository>();
            builder.Services.AddScoped<IRepository<DailyRecordStacticsList>, Repository<DailyRecordStacticsList>>();
            builder.Services.AddScoped<IRepository<PermitsToWorkList>, Repository<PermitsToWorkList>>();
            
            builder.Services.AddScoped<IRepository<CraneDailyLifting>, Repository<CraneDailyLifting>>();
            builder.Services.AddScoped<ICraneDailyLiftingRepository, CraneDailyLiftingRepository>();
            builder.Services.AddScoped<IRepository<ForkDailyLifting>, Repository<ForkDailyLifting>>();
            builder.Services.AddScoped<IForkDailyLiftingRepository, ForkDailyLiftingRepository>();


  //////---------Vehicle Weekly Checklist Report----------------------

            builder.Services.AddScoped<IRepository<VehicleWeeklyChecklist>, Repository<VehicleWeeklyChecklist>>();
            builder.Services.AddScoped<IRepository<LightBus>, Repository<LightBus>>();
            builder.Services.AddScoped<IVehicleWeeklyChecklistRepository, VehicleWeeklyChecklistRepository>();
            builder.Services.AddScoped<IRepository<ManPickup>, Repository<ManPickup>>();
            builder.Services.AddScoped<IRepository<RigPickup>, Repository<RigPickup>>();
            builder.Services.AddScoped<IRepository<HeavyTruck>, Repository<HeavyTruck>>();




            builder.Services.AddDbContext<Context>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("cs"))
            );

            builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<Context>();
            builder.Services.AddAuthentication(options =>
            {
                //jwt
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;//not valid account
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    //parmeter
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:ValidIss"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAud"],
                    IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecrytKey"]))//asdZXCZX!#!@342352
                };
            }); //how to check if toke valid or not;
            builder.Services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation    
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASP.NET 5 Web API",
                    Description = " ITI Projrcy"
                });
                // To Enable authorization using Swagger (JWT)    
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
new string[] { }

                    }
                });
            });

            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            });
            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
            builder.Services.AddTransient<IEmailSender, EmailSender>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();

            }

            app.UseStaticFiles();
            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("my");


            app.UseDeveloperExceptionPage();

            app.MapHub<NotificationHub>("/NotificationHub");
            app.MapHub<ArrivalNotificationHub>("/ArrivalNotificationHub");

            app.MapHub<TestHub>("/TestHub");

            app.MapControllers();

            app.Run();
        }
    }
}