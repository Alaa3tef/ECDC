using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TempProject.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccidentCauses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccidentCauses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CertificatesTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificatesTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassificationOfAccidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificationOfAccidents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComminucationMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComminucationMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CorrectiveActionObservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectiveActionObservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CorrectiveResponsabilitys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponsibilityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectiveResponsabilitys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "craneDailyLiftings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MobileCraneName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChasisNo = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateofLastInspection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateofNextInspection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_craneDailyLiftings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Crews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrewName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrillTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriverNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenceExpireData = table.Column<DateTime>(type: "date", nullable: false),
                    LicenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "forkDailyLiftings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForkliftName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChasisNo = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateofLastInspection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateofNextInspection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forkDailyLiftings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSEEquipmentLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Equipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSEEquipmentLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadershipVisits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadershipType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadershipVisits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NonRecordableAccidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccidentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonRecordableAccidents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PPEs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PPEs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreventionCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreventionCategorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecordableAccidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccidentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordableAccidents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportedByNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpCode = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportedByNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportedByPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportedByPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Responsibility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsibility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootCauses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CauseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootCauses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RouteNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Standards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfIncidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfIncidents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfInjurys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfInjurys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfObservationCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfObservationCategorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerNumber = table.Column<int>(type: "int", nullable: false),
                    LicenceExpireData = table.Column<DateTime>(type: "date", nullable: false),
                    LicenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViolationCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViolationCategorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Bop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    ECDC = table.Column<int>(type: "int", nullable: false),
                    Client = table.Column<int>(type: "int", nullable: false),
                    Service = table.Column<int>(type: "int", nullable: false),
                    Visitors = table.Column<int>(type: "int", nullable: false),
                    Catering = table.Column<int>(type: "int", nullable: false),
                    WatchMen = table.Column<int>(type: "int", nullable: false),
                    inspection = table.Column<int>(type: "int", nullable: false),
                    Rental = table.Column<int>(type: "int", nullable: false),
                    Other = table.Column<int>(type: "int", nullable: false),
                    ManPower = table.Column<int>(type: "int", nullable: false),
                    TotalManHours = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bop_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Bop_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cranes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    WellName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QHSEEngineer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CleanAndTidy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineOilLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransmissionOilLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RadiatorWaterLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HydraulicOilLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    V_beltsTension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrainWater = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Leaks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatteryHolder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoadComputer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GaugesForCcorrectReadings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TirePressure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelTanksFull = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WireRopes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SwingBrake = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestLimitSwitches = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestOutriggers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbnormalNoise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceBrakes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sheaves = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpoolingOfWire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hookcondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoomSections = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineV_belts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WiringVisually = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoadIndicator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AudibleAlarm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoadLimiting = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoomAngle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LimitSwitch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergencyShutDown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperatingReturn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperatingControls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadLight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReverseAlarm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParkingBrake = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SafetyBelt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverSeat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wipers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExistingCorrosion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TireBolts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SafeLoadIndicator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScreenCurtains = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Outrigger = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrangeSound = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CleanAndTidyRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineOilLevelRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransmissionOilLevelRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RadiatorWaterLevelRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HydraulicOilLevelRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    V_beltsTensionRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrainWaterRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaksRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatteryHolderRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoadComputerRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GaugesForCcorrectReadingsRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TirePressureRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuelTanksFullRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WireRopesRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SwingBrakeRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestLimitSwitchesRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestOutriggersRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbnormalNoiseRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceBrakesRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SheavesRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpoolingOfWireRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HookconditionRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoomSectionsRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineV_beltsRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WiringVisuallyRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoadIndicatorRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AudibleAlarmRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoadLimitingRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoomAngleRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LimitSwitchRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyShutDownRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingReturnRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingControlsRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadLightRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReverseAlarmRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParkingBrakeRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SafetyBeltRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverSeatRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WipersRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExistingCorrosionRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TireBoltsRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SafeLoadIndicatorRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreenCurtainsRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutriggerRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrangeSoundRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cranes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cranes_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cranes_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CustomerReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "date", nullable: false),
                    DateTo = table.Column<DateTime>(type: "date", nullable: false),
                    ECDCRepresentative = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerRepresentative = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvaluationResult = table.Column<int>(type: "int", nullable: false),
                    ClientRepresentative = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerReports_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CustomerReports_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DailyLiftingReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    MobileCraneName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChasisNo = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateofLastInspection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateofNextInspection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ForkName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ForkType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ForkChasisNo = table.Column<int>(type: "int", nullable: false),
                    ForkCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ForkDateofLastInspection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ForkDateofNextInspection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LiftingEngieerCode = table.Column<int>(type: "int", nullable: false),
                    LiftingEngieerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyLiftingReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyLiftingReports_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DailyLiftingReports_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DaysSinceNoLTI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysSinceNoLTI", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaysSinceNoLTI_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Drills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrillTypeId = table.Column<int>(type: "int", nullable: false),
                    TimeInitiated = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeCompleted = table.Column<TimeSpan>(type: "time", nullable: false),
                    DrillScenario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergencyEquipmentUsed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffectivenessPoints = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeficienciesPoints = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recommendations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STPCode = table.Column<int>(type: "int", nullable: false),
                    STPPositionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STPName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QHSEEmpCode = table.Column<int>(type: "int", nullable: false),
                    QHSEPositionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QHSEEmpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drills_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Drills_DrillTypes_DrillTypeId",
                        column: x => x.DrillTypeId,
                        principalTable: "DrillTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Drills_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EmpCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    RigId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpCodes_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmpCodes_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Forklifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    WellName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QHSEEngineer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CleanAndTidy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineOilLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransmissionOilLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RadiatorWaterLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HydraulicOilLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    V_beltsTension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrainWater = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Leaks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatteryHolder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GaugesForCorrectReadings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TirePressure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TireCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelTanksFull = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lights = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alarms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoistingSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbnormalNoise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brakes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiquidLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instruments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineDriveBelts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarriageRollers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SteeringSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatBelt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoseofCoilCooling = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstAidBox = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrankShaft = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverSeat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineV_belts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wipers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExistingCorrosion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CleanAndTidyRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineOilLevelRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransmissionOilLevelRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RadiatorWaterLevelRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HydraulicOilLevelRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    V_beltsTensionRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrainWaterRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaksRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatteryHolderRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GaugesForCorrectReadingsRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TyrePressureRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TyreConditionRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuelTanksFullRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LightsRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlarmsRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoistingSystemRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbnormalNoiseRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrakesRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiquidLevelRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstrumentsRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineDriveBeltsRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarriageRollersRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SteeringSystemRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeatBeltRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoseofCoilCoolingRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstAidBoxRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrankShaftRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverSeatRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineV_beltsRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WipersRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExistingCorrosionRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forklifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forklifts_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Forklifts_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Handovers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftDateFrom = table.Column<DateTime>(type: "date", nullable: false),
                    ShiftDateTo = table.Column<DateTime>(type: "date", nullable: false),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    WellName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeavingEmpCode = table.Column<int>(type: "int", nullable: false),
                    LeavingEmpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComingEmpCode = table.Column<int>(type: "int", nullable: false),
                    ComingEmpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StopCards = table.Column<int>(type: "int", nullable: false),
                    MonthlyStopCards = table.Column<int>(type: "int", nullable: false),
                    OpenStopCards = table.Column<int>(type: "int", nullable: false),
                    Drills = table.Column<int>(type: "int", nullable: false),
                    MonthlyDrills = table.Column<int>(type: "int", nullable: false),
                    SafetyAlerts = table.Column<int>(type: "int", nullable: false),
                    MonthlySafetyAlerts = table.Column<int>(type: "int", nullable: false),
                    WeeklyInspection = table.Column<int>(type: "int", nullable: false),
                    InternalAudit = table.Column<int>(type: "int", nullable: false),
                    ExternalAudit = table.Column<int>(type: "int", nullable: false),
                    MedicalReport = table.Column<int>(type: "int", nullable: false),
                    TrainingMatrix = table.Column<int>(type: "int", nullable: false),
                    RigMove = table.Column<int>(type: "int", nullable: false),
                    IncidentReport = table.Column<int>(type: "int", nullable: false),
                    TrackingSheetClosedPoints = table.Column<int>(type: "int", nullable: false),
                    PotentialHazardReport = table.Column<int>(type: "int", nullable: false),
                    ShiftBrief = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QHSEEngineer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Handovers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Handovers_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Handovers_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistoryReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelephoneNumber = table.Column<int>(type: "int", nullable: false),
                    Socia_DoYouSmokeAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Socia_DoYouSmokeComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Socia_DoYouExerciseRegularlyAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Socia_DoYouExerciseRegularlyComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Socia_HaveYouBeenExposedAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Socia_HaveYouBeenExposedComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Socia_HaveYouEverDevelopedAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Socia_HaveYouEverDevelopedComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Socia_HaveYouSufferedAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Socia_HaveYouSufferedComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family_AreYouCurrentlyBeingTreatedAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family_AreYouCurrentlyBeingTreatedComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family_AreYouCurrentlyReceivingAnyMedicalAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family_AreYouCurrentlyReceivingAnyMedicalComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family_HighBloodPressureAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family_HighBloodPressureComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family_HeartDiseaseAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family_HeartDiseaseComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family_COPDAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family_COPDComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family_DiabetesAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family_DiabetesComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family_GITAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family_GITComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family_KidneyAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family_KidneyComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family_NeurologicalAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family_NeurologicalComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family_InfectiousAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family_InfectiousComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family_DizzinessAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family_DizzinessComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family_DiscProlapseAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family_DiscProlapseComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family_AllergyAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family_AllergyComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family_HospitalizationAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family_HospitalizationComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family_SurgeryAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family_SurgeryComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family_DepressionAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family_DepressionComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family_DoAnyOfYour1stDegreeFamilyAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family_DoAnyOfYour1stDegreeFamilyComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralExamination_Weight = table.Column<int>(type: "int", nullable: true),
                    GeneralExamination_Height = table.Column<int>(type: "int", nullable: true),
                    GeneralExamination_BloodPressure = table.Column<int>(type: "int", nullable: true),
                    GeneralExamination_HeartRate = table.Column<int>(type: "int", nullable: true),
                    DoctorComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistoryReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistoryReports_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MedicalHistoryReports_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PotentialHazard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    PR_IssueDate = table.Column<DateTime>(type: "date", nullable: false),
                    PR_No = table.Column<int>(type: "int", nullable: false),
                    PO_No = table.Column<int>(type: "int", nullable: false),
                    ResponibilityId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NeededAction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PotentialHazard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PotentialHazard_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PotentialHazard_Responsibility_ResponibilityId",
                        column: x => x.ResponibilityId,
                        principalTable: "Responsibility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PotentialHazard_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PPEReceivings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    EmployeeCode = table.Column<int>(type: "int", nullable: false),
                    EmployeePositionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QHSEEmpCode = table.Column<int>(type: "int", nullable: false),
                    QHSEPositionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QHSEEmpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThermalCoverallsSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SafetyBootsSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalCoverallsSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PPEReceivings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PPEReceivings_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PPEReceivings_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PTSMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    TrainerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumsofTrainees = table.Column<int>(type: "int", nullable: false),
                    SubjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PTSMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PTSMs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PTSMs_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RigCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    CertificationLiftingGear = table.Column<DateTime>(type: "date", nullable: false),
                    CertificationCATIII = table.Column<DateTime>(type: "date", nullable: false),
                    CertificationCATIV = table.Column<DateTime>(type: "date", nullable: false),
                    CertificationGaugeCalibraion = table.Column<DateTime>(type: "date", nullable: false),
                    CertificationWallThickness = table.Column<DateTime>(type: "date", nullable: false),
                    DueLiftingGear = table.Column<DateTime>(type: "date", nullable: false),
                    DueCATIII = table.Column<DateTime>(type: "date", nullable: false),
                    DueCATIV = table.Column<DateTime>(type: "date", nullable: false),
                    DueGaugeCalibraion = table.Column<DateTime>(type: "date", nullable: false),
                    DueWallThickness = table.Column<DateTime>(type: "date", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RigCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RigCertificates_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RigCertificates_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RigMovePerformances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OldWellName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewWellName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoveDistance = table.Column<double>(type: "float", nullable: false),
                    ReleaseTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    AcceptanceTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    AcceptanceDate = table.Column<DateTime>(type: "date", nullable: false),
                    ActualMoveTime = table.Column<double>(type: "float", nullable: false),
                    DieselConsumed = table.Column<double>(type: "float", nullable: false),
                    TargetArchived = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BudgetTargetTotalDay = table.Column<double>(type: "float", nullable: false),
                    BudgetTargetTotalMoney = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RigMovePerformances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RigMovePerformances_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RigMovePerformances_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "VehicleWeeklyChecklists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Cient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManPickupVehiclePlateNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManPickupDriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RigPickupVehiclePlateNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RigPickupDriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimeMoverPlateNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrailerPlateNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeavyTruckDriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LightBusVehiclePlateNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LightBusDriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSEEngineer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleWeeklyChecklists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleWeeklyChecklists_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VehicleWeeklyChecklists_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyCampInspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    General_AreParking = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    General_IsCampSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    General_IsAllRubbish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    General_AreWater = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    General_IsGenerator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    General_WhatIsGeneralOpinion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    General_AreParkingComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    General_IsCampSiteComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    General_IsAllRubbishComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    General_AreWaterComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    General_IsGeneratorComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    General_WhatIsGeneralOpinionComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Safety_DateOfLastCampfireDrill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Safety_DateOfLastMedicalDrill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Safety_AreStaffAwareOfFoodHazards = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Safety_FirePumpInGoodCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Safety_AreThereAnyPotentialHazards = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Safety_IsTheDiesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Safety_AreThereAnyUnsafe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Safety_IsCampEarthing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Safety_AreFireEmergency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Safety_DateOfLastCampfireDrillComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Safety_DateOfLastMedicalDrillComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Safety_AreStaffAwareOfFoodHazardsComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Safety_FirePumpInGoodConditionComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Safety_AreThereAnyPotentialHazardsComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Safety_IsTheDieselComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Safety_AreThereAnyUnsafeComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Safety_IsCampEarthingComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Safety_AreFireEmergencyComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodStorage_WhatIsTheGeneralAppearance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodStorage_IsFoodProperlyProtectedFromRisk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodStorage_IsThereEnoughDryFood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodStorage_FrozenStoredFood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodStorage_AreFrozenFoods = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodStorage_IsFoodProperlyStored = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodStorage_AreChillerAndFreezerClean = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodStorage_AreDryFoodsProperlyStored = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodStorage_WhatIsTheGeneralAppearanceComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodStorage_IsFoodProperlyProtectedFromRiskComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodStorage_IsThereEnoughDryFoodComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodStorage_FrozenStoredFoodComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodStorage_AreFrozenFoodsComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodStorage_IsFoodProperlyStoredComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodStorage_AreChillerAndFreezerCleanComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodStorage_AreDryFoodsProperlyStoredComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Galley_IsThereWnyWaterLeaks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Galley_AreAllAppliancesWorking = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Galley_WhenWasExhaustFans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Galley_AreDishesAndUtensilsClean = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Galley_WhatTheConditionOfTheChipPanAndfoodOil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Galley_IsTheGalleyAreaClean = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Galley_IsThereWnyWaterLeaksComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Galley_AreAllAppliancesWorkingComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Galley_WhenWasExhaustFansComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Galley_AreDishesAndUtensilsCleanComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Galley_WhatTheConditionOfTheChipPanAndfoodOilComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Galley_IsTheGalleyAreaCleanComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessHall_AreWashHandBasins = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessHall_RegistersForChangingFoodOil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessHall_AreAllAppliancesWorking = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessHall_AreTablesInGoodWorkingCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessHall_AreFlyKillersWorking = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessHall_IsMessHallClean = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessHall_AllElectricalCables = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessHall_AreWashHandBasinsComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessHall_RegistersForChangingFoodOilComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessHall_AreAllAppliancesWorkingComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessHall_AreTablesInGoodWorkingConditionComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessHall_AreFlyKillersWorkingComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessHall_IsMessHallCleanComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessHall_AllElectricalCablesComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accomodations_LockersOfBathroomsAreInstalledWell = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accomodations_TypesOfCleaningMaterialsUsed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accomodations_AnyLackInCleaning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accomodations_AreDoorHingesAndClosures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accomodations_LockersOfBathroomsAreInstalledWellComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accomodations_TypesOfCleaningMaterialsUsedComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accomodations_AnyLackInCleaningComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accomodations_AreDoorHingesAndClosuresComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clinic_IsTheClinicCleanAndTidy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clinic_RelevantSdsPresent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clinic_IsMedicalApparatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clinic_IsMedicalStockMaintained = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clinic_IsMedicalTreatment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clinic_IsTheClinicCleanAndTidyComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clinic_RelevantSdsPresentComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clinic_IsMedicalApparatusComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clinic_IsMedicalStockMaintainedComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clinic_IsMedicalTreatmentComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Laundry_IsLaundryAleanAndTidy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Laundry_TypesOfChemicalsUsedAreRelevant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Laundry_AreAllAppliancesSafety = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Laundry_AreAllAppliancesWorking = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Laundry_IsLaundryAleanAndTidyComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Laundry_TypesOfChemicalsUsedAreRelevantComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Laundry_AreAllAppliancesSafetyComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Laundry_AreAllAppliancesWorkingComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralBathRooms_AreAllElectricalFixtures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneralBathRooms_AreAllDoorsInGoodWorkingOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneralBathRooms_AnyLeaksInPiping = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneralBathRooms_IsTheAreaCleanAndTidy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneralBathRooms_AreAllElectricalFixturesComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralBathRooms_AnyLeaksInPipingComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralBathRooms_IsTheAreaCleanAndTidyComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterTanks_AreWaterTanksHatchesClean = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaterTanks_AnyWaterLeaks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaterTanks_WhatIsTheDateOfLastWaterSample = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaterTanks_IsAreaCleanAndTidy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaterTanks_AreWaterTanksHatchesCleanComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterTanks_AnyWaterLeaksComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterTanks_WhatIsTheDateOfLastWaterSampleComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterTanks_IsAreaCleanAndTidyComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyCampInspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyCampInspections_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WeeklyCampInspections_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyClinics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    WeeklyClinicNo = table.Column<int>(type: "int", nullable: false),
                    MedicalReportNo = table.Column<int>(type: "int", nullable: false),
                    LastFirstAidDrillNo = table.Column<DateTime>(type: "date", nullable: false),
                    HealthMeetingNo = table.Column<int>(type: "int", nullable: false),
                    Topics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HealthStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HealthStatusComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LifeSavingApparatuses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LifeSavingApparatusesComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VaccinesAvailable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaccinesAvailableComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ERP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ERPComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalStretcher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalStretcherComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterTest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaterTestComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodSugar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodSugarComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstAidBox = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstAidBoxComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullO2Cylinder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullO2CylinderComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalWaste = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalWasteComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicinesExpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicinesExpiryDateComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QHSEEngineer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyClinics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyClinics_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WeeklyClinics_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyInspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    WellName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EyeStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EyeWeeklyFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstAidStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstAidWeeklyFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScbaStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScbaWeeklyFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Scba30min = table.Column<int>(type: "int", nullable: false),
                    Scba15min = table.Column<int>(type: "int", nullable: false),
                    Scba10min = table.Column<int>(type: "int", nullable: false),
                    PortableGasStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortableGasWeeklyFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortableGasMuti = table.Column<int>(type: "int", nullable: false),
                    PortableGasSingle = table.Column<int>(type: "int", nullable: false),
                    ExpeiryDate = table.Column<DateTime>(type: "date", nullable: false),
                    FirePumpStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirePumpWeeklyFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeldingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeldingWeeklyFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WindStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WindWeeklyFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmokeStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmokeWeeklyFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FireExtinguishersStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FireExtinguishersWeeklyFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DerrickmanStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DerrickmanWeeklyFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingWeeklyFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortableLadderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortableLadderWeeklyFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SafetyStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SafetyWeeklyFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FallStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FallWeeklyFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CraneStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CraneWeeklyFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForkStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ForkWeeklyFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DroppedInspectionStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DroppedInspectionWeeklyFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElectricalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElectricalWeeklyFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CircuitStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CircuitWeeklyFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EarthingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EarthingWeeklyFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EarthingMaximum = table.Column<float>(type: "real", nullable: false),
                    EarthingMin = table.Column<float>(type: "real", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyInspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyInspections_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WeeklyInspections_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CorrectiveActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportNo = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormResponsabilityId = table.Column<int>(type: "int", nullable: false),
                    DescriptionOfNonConformity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StandardId = table.Column<int>(type: "int", nullable: false),
                    ClauseNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectiveEvidence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IfOtherObservation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateRisk = table.Column<bool>(type: "bit", nullable: false),
                    IfUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagementOfChange = table.Column<bool>(type: "bit", nullable: false),
                    IfManagementOfChange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameRasiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRaisedBy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IfOtherRootCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q_ManagerSig = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FormStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectiveActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorrectiveActions_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CorrectiveActions_CorrectiveResponsabilitys_FormResponsabilityId",
                        column: x => x.FormResponsabilityId,
                        principalTable: "CorrectiveResponsabilitys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CorrectiveActions_Standards_StandardId",
                        column: x => x.StandardId,
                        principalTable: "Standards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCompetencyEvaluation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    QHSEEmpCode = table.Column<int>(type: "int", nullable: false),
                    QHSEPositionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QHSEEmpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeCode = table.Column<int>(type: "int", nullable: false),
                    EmployeePositionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCompetencyEvaluation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeCompetencyEvaluation_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeCompetencyEvaluation_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeCompetencyEvaluation_SubjectList_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SubjectList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MedicalReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTheIllHealth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfIncidentId = table.Column<int>(type: "int", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelephoneNumber = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RigManager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QHSEEngineer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RigDoctor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorRecommendation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalReports_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MedicalReports_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MedicalReports_TypeOfIncidents_TypeOfIncidentId",
                        column: x => x.TypeOfIncidentId,
                        principalTable: "TypeOfIncidents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StopCardRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    ClassificationID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeCode = table.Column<int>(type: "int", nullable: false),
                    ReportedByPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportedByName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionRequired = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfObservationCategoryID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StopWorkAuthorityApplied = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StopCardRegisters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StopCardRegisters_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StopCardRegisters_Classifications_ClassificationID",
                        column: x => x.ClassificationID,
                        principalTable: "Classifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StopCardRegisters_TypeOfObservationCategorys_TypeOfObservationCategoryID",
                        column: x => x.TypeOfObservationCategoryID,
                        principalTable: "TypeOfObservationCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "JMPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JournyNumber = table.Column<int>(type: "int", nullable: false),
                    NightDrivingReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QHSEManagerMustApprove = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeedLimit = table.Column<double>(type: "float", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    PurposeOfJourny = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReachBeforeDark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommunicationID = table.Column<int>(type: "int", nullable: false),
                    JournyManagerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverNameId = table.Column<int>(type: "int", nullable: false),
                    InspectionVechile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    EstimatedArriveDate = table.Column<DateTime>(type: "date", nullable: false),
                    EstimatedArriveTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    RestLocationNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RouteNameID = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    EnterTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    notifyStatus = table.Column<int>(type: "int", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JMPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JMPs_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_JMPs_ComminucationMethods_CommunicationID",
                        column: x => x.CommunicationID,
                        principalTable: "ComminucationMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_JMPs_DriverNames_DriverNameId",
                        column: x => x.DriverNameId,
                        principalTable: "DriverNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_JMPs_RouteNames_RouteNameID",
                        column: x => x.RouteNameID,
                        principalTable: "RouteNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_JMPs_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Accidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    TimeOfEvent = table.Column<TimeSpan>(type: "time", nullable: false),
                    DateOfEvent = table.Column<DateTime>(type: "date", nullable: false),
                    TypeOfInjuryID = table.Column<int>(type: "int", nullable: false),
                    ViolationCategoryId = table.Column<int>(type: "int", nullable: false),
                    AccidentCausesId = table.Column<int>(type: "int", nullable: false),
                    PreventionCategoryId = table.Column<int>(type: "int", nullable: false),
                    ClassificationOfAccidentId = table.Column<int>(type: "int", nullable: false),
                    AccidentLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QHSEEmpCode = table.Column<int>(type: "int", nullable: false),
                    QHSEPositionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QHSEEmpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PusherCode = table.Column<int>(type: "int", nullable: false),
                    PusherPositionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PusherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrillerCode = table.Column<int>(type: "int", nullable: false),
                    DrillerPositionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrillerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InjuredPersonCode = table.Column<int>(type: "int", nullable: false),
                    InjuredPersonPositionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InjuredPersonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionOfTheEvent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImmediateActionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectCauses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RootCauses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recommendations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accidents_AccidentCauses_AccidentCausesId",
                        column: x => x.AccidentCausesId,
                        principalTable: "AccidentCauses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Accidents_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Accidents_ClassificationOfAccidents_ClassificationOfAccidentId",
                        column: x => x.ClassificationOfAccidentId,
                        principalTable: "ClassificationOfAccidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Accidents_PreventionCategorys_PreventionCategoryId",
                        column: x => x.PreventionCategoryId,
                        principalTable: "PreventionCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Accidents_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Accidents_TypeOfInjurys_TypeOfInjuryID",
                        column: x => x.TypeOfInjuryID,
                        principalTable: "TypeOfInjurys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Accidents_ViolationCategorys_ViolationCategoryId",
                        column: x => x.ViolationCategoryId,
                        principalTable: "ViolationCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationCriterias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerReportId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationCriterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationCriterias_CustomerReports_CustomerReportId",
                        column: x => x.CustomerReportId,
                        principalTable: "CustomerReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DailyRecordStacticsLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyRecordStacticsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailyLiftingReportId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyRecordStacticsLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyRecordStacticsLists_DailyLiftingReports_DailyLiftingReportId",
                        column: x => x.DailyLiftingReportId,
                        principalTable: "DailyLiftingReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PermitsToWorkLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermitsToWorkName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailyLiftingReportId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermitsToWorkLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermitsToWorkLists_DailyLiftingReports_DailyLiftingReportId",
                        column: x => x.DailyLiftingReportId,
                        principalTable: "DailyLiftingReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SummaryDailyLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SummaryDaily = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailyLiftingReportId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryDailyLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SummaryDailyLists_DailyLiftingReports_DailyLiftingReportId",
                        column: x => x.DailyLiftingReportId,
                        principalTable: "DailyLiftingReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LTIPrevDateAndDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaysSinceNoLTIId = table.Column<int>(type: "int", nullable: false),
                    PrevDays = table.Column<int>(type: "int", nullable: false),
                    PrevDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LTIPrevDateAndDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LTIPrevDateAndDays_DaysSinceNoLTI_DaysSinceNoLTIId",
                        column: x => x.DaysSinceNoLTIId,
                        principalTable: "DaysSinceNoLTI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "QHSEDailyReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    StopCardsRecords = table.Column<int>(type: "int", nullable: false),
                    PTSMRecords = table.Column<int>(type: "int", nullable: false),
                    DrillsRecords = table.Column<int>(type: "int", nullable: false),
                    ManPowerNumber = table.Column<int>(type: "int", nullable: false),
                    TotalManPowerHours = table.Column<int>(type: "int", nullable: false),
                    WeeklyInspection = table.Column<int>(type: "int", nullable: true),
                    MonthlyInspection = table.Column<int>(type: "int", nullable: true),
                    WallName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPTW = table.Column<int>(type: "int", nullable: false),
                    SafetyAlertCrewNumber = table.Column<int>(type: "int", nullable: false),
                    QuizCrewNumber = table.Column<int>(type: "int", nullable: false),
                    PTWCold = table.Column<int>(type: "int", nullable: false),
                    PTWHot = table.Column<int>(type: "int", nullable: false),
                    RecordableAccident = table.Column<int>(type: "int", nullable: false),
                    NonRecordableAccident = table.Column<int>(type: "int", nullable: false),
                    RigVehiclesKilometers = table.Column<int>(type: "int", nullable: false),
                    SafetyInduction = table.Column<int>(type: "int", nullable: false),
                    RigTrackingClosedPoints = table.Column<int>(type: "int", nullable: false),
                    RigTrackingOpenPoints = table.Column<int>(type: "int", nullable: false),
                    DaysSinceLastLTI = table.Column<int>(type: "int", nullable: false),
                    DaysSinceNoLTIId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QHSEDailyReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QHSEDailyReport_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_QHSEDailyReport_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_QHSEDailyReport_DaysSinceNoLTI_DaysSinceNoLTIId",
                        column: x => x.DaysSinceNoLTIId,
                        principalTable: "DaysSinceNoLTI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_QHSEDailyReport_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DrillImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrillId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrillImages_Drills_DrillId",
                        column: x => x.DrillId,
                        principalTable: "Drills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyResponseTeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamMemberCode = table.Column<int>(type: "int", nullable: true),
                    TeamMemberPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamMemberName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrillId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyResponseTeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyResponseTeamMembers_Drills_DrillId",
                        column: x => x.DrillId,
                        principalTable: "Drills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HSEEquipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnSite = table.Column<int>(type: "int", nullable: false),
                    SentForMaintenance = table.Column<int>(type: "int", nullable: false),
                    HandoverId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSEEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HSEEquipments_Handovers_HandoverId",
                        column: x => x.HandoverId,
                        principalTable: "Handovers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HSEInventorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockAtStorage = table.Column<int>(type: "int", nullable: false),
                    ReleasedFromStorage = table.Column<int>(type: "int", nullable: false),
                    NewlyRecieved = table.Column<int>(type: "int", nullable: false),
                    HandoverId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSEInventorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HSEInventorys_Handovers_HandoverId",
                        column: x => x.HandoverId,
                        principalTable: "Handovers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MaterialRequesteds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiredItem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HandoverId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialRequesteds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialRequesteds_Handovers_HandoverId",
                        column: x => x.HandoverId,
                        principalTable: "Handovers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ShiftDrillTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    DrillType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HandoverId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftDrillTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftDrillTypes_Handovers_HandoverId",
                        column: x => x.HandoverId,
                        principalTable: "Handovers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    VisitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HandoverId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_Handovers_HandoverId",
                        column: x => x.HandoverId,
                        principalTable: "Handovers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HazardImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PotentialHazardId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HazardImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HazardImages_PotentialHazard_PotentialHazardId",
                        column: x => x.PotentialHazardId,
                        principalTable: "PotentialHazard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PPEAndPPEReceivings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PPEId = table.Column<int>(type: "int", nullable: false),
                    PPEReceivingId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PPEAndPPEReceivings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PPEAndPPEReceivings_PPEReceivings_PPEReceivingId",
                        column: x => x.PPEReceivingId,
                        principalTable: "PPEReceivings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PPEAndPPEReceivings_PPEs_PPEId",
                        column: x => x.PPEId,
                        principalTable: "PPEs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "int", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PTSMId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_PTSMs_PTSMId",
                        column: x => x.PTSMId,
                        principalTable: "PTSMs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AirHoists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WireSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WireInspectionDueDate = table.Column<DateTime>(type: "date", nullable: false),
                    LastMPIInspectionDate = table.Column<DateTime>(type: "date", nullable: false),
                    NextMPIInspectionDate = table.Column<DateTime>(type: "date", nullable: false),
                    NextLoadTestDate = table.Column<DateTime>(type: "date", nullable: false),
                    RigCertificatesId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirHoists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirHoists_RigCertificates_RigCertificatesId",
                        column: x => x.RigCertificatesId,
                        principalTable: "RigCertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HoistingSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Equipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COCAvailabilty = table.Column<bool>(type: "bit", nullable: true),
                    CATIIICertificationDate = table.Column<DateTime>(type: "date", nullable: true),
                    CATIIIExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    CATIVCertificationDate = table.Column<DateTime>(type: "date", nullable: true),
                    CATIVExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    RigCertificatesId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoistingSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoistingSystems_RigCertificates_RigCertificatesId",
                        column: x => x.RigCertificatesId,
                        principalTable: "RigCertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HSEEquipmentTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "date", nullable: false),
                    RigCertificatesId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSEEquipmentTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HSEEquipmentTables_HSEEquipmentLists_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "HSEEquipmentLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HSEEquipmentTables_RigCertificates_RigCertificatesId",
                        column: x => x.RigCertificatesId,
                        principalTable: "RigCertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HydraulicWinchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WireSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WireInspectionDueDate = table.Column<DateTime>(type: "date", nullable: false),
                    LastMPIInspectionDate = table.Column<DateTime>(type: "date", nullable: false),
                    NextMPIInspectionDate = table.Column<DateTime>(type: "date", nullable: false),
                    NextLoadTestDate = table.Column<DateTime>(type: "date", nullable: false),
                    RigCertificatesId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HydraulicWinchs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HydraulicWinchs_RigCertificates_RigCertificatesId",
                        column: x => x.RigCertificatesId,
                        principalTable: "RigCertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ManRidingWinchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WireSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WireInspectionDueDate = table.Column<DateTime>(type: "date", nullable: false),
                    LastMPIInspectionDate = table.Column<DateTime>(type: "date", nullable: false),
                    NextMPIInspectionDate = table.Column<DateTime>(type: "date", nullable: false),
                    NextLoadTestDate = table.Column<DateTime>(type: "date", nullable: false),
                    RigCertificatesId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManRidingWinchs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManRidingWinchs_RigCertificates_RigCertificatesId",
                        column: x => x.RigCertificatesId,
                        principalTable: "RigCertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MudCirculationSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Equipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COCAvailabilty = table.Column<bool>(type: "bit", nullable: true),
                    CATIIICertificationDate = table.Column<DateTime>(type: "date", nullable: true),
                    CATIIIExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    CATIVCertificationDate = table.Column<DateTime>(type: "date", nullable: true),
                    CATIVExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    RigCertificatesId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MudCirculationSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MudCirculationSystems_RigCertificates_RigCertificatesId",
                        column: x => x.RigCertificatesId,
                        principalTable: "RigCertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OtherSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CATIIICertificationDate = table.Column<DateTime>(type: "date", nullable: true),
                    CATIIIExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    CATIVCertificationDate = table.Column<DateTime>(type: "date", nullable: true),
                    CATIVExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    RigCertificatesId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherSystems_RigCertificates_RigCertificatesId",
                        column: x => x.RigCertificatesId,
                        principalTable: "RigCertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PersonnelCerificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateDate = table.Column<DateTime>(type: "date", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "date", nullable: false),
                    RigCertificatesId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelCerificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonnelCerificates_RigCertificates_RigCertificatesId",
                        column: x => x.RigCertificatesId,
                        principalTable: "RigCertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PowerSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Equipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COCAvailabilty = table.Column<bool>(type: "bit", nullable: true),
                    CATIIICertificationDate = table.Column<DateTime>(type: "date", nullable: true),
                    CATIIIExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    CATIVCertificationDate = table.Column<DateTime>(type: "date", nullable: true),
                    CATIVExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    RigCertificatesId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerSystems_RigCertificates_RigCertificatesId",
                        column: x => x.RigCertificatesId,
                        principalTable: "RigCertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PresssureReliefValves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valves = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificationDate = table.Column<DateTime>(type: "date", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "date", nullable: false),
                    RigCertificatesId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresssureReliefValves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresssureReliefValves_RigCertificates_RigCertificatesId",
                        column: x => x.RigCertificatesId,
                        principalTable: "RigCertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RigCertForklifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastExaminationDate = table.Column<DateTime>(type: "date", nullable: false),
                    NextExaminationDate = table.Column<DateTime>(type: "date", nullable: false),
                    RigCertificatesId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RigCertForklifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RigCertForklifts_RigCertificates_RigCertificatesId",
                        column: x => x.RigCertificatesId,
                        principalTable: "RigCertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RigCertMobileCranes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChassisNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HookSerialNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "date", nullable: false),
                    LastExaminationDate = table.Column<DateTime>(type: "date", nullable: false),
                    NextExaminationDate = table.Column<DateTime>(type: "date", nullable: false),
                    RigCertificatesId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RigCertMobileCranes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RigCertMobileCranes_RigCertificates_RigCertificatesId",
                        column: x => x.RigCertificatesId,
                        principalTable: "RigCertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RotarySystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Equipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COCAvailabilty = table.Column<bool>(type: "bit", nullable: true),
                    CATIIICertificationDate = table.Column<DateTime>(type: "date", nullable: true),
                    CATIIIExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    CATIVCertificationDate = table.Column<DateTime>(type: "date", nullable: true),
                    CATIVExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    RigCertificatesId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotarySystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RotarySystems_RigCertificates_RigCertificatesId",
                        column: x => x.RigCertificatesId,
                        principalTable: "RigCertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WellControlSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Equipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COCAvailabilty = table.Column<bool>(type: "bit", nullable: true),
                    CATIIICertificationDate = table.Column<DateTime>(type: "date", nullable: true),
                    CATIIIExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    CATIVCertificationDate = table.Column<DateTime>(type: "date", nullable: true),
                    CATIVExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    RigCertificatesId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WellControlSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WellControlSystems_RigCertificates_RigCertificatesId",
                        column: x => x.RigCertificatesId,
                        principalTable: "RigCertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProblemFacedDuringRigMoves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProblemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeLostProblem = table.Column<double>(type: "float", nullable: false),
                    RecommendationProblemRepeated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RigMovePerformanceId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemFacedDuringRigMoves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProblemFacedDuringRigMoves_RigMovePerformances_RigMovePerformanceId",
                        column: x => x.RigMovePerformanceId,
                        principalTable: "RigMovePerformances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HeavyTrucks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleWeeklyChecklistId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeavyTrucks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeavyTrucks_VehicleWeeklyChecklists_VehicleWeeklyChecklistId",
                        column: x => x.VehicleWeeklyChecklistId,
                        principalTable: "VehicleWeeklyChecklists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LightBuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleWeeklyChecklistId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightBuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LightBuses_VehicleWeeklyChecklists_VehicleWeeklyChecklistId",
                        column: x => x.VehicleWeeklyChecklistId,
                        principalTable: "VehicleWeeklyChecklists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ManPickups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleWeeklyChecklistId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManPickups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManPickups_VehicleWeeklyChecklists_VehicleWeeklyChecklistId",
                        column: x => x.VehicleWeeklyChecklistId,
                        principalTable: "VehicleWeeklyChecklists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RigPickups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleWeeklyChecklistId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RigPickups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RigPickups_VehicleWeeklyChecklists_VehicleWeeklyChecklistId",
                        column: x => x.VehicleWeeklyChecklistId,
                        principalTable: "VehicleWeeklyChecklists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DrugInventorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "date", nullable: false),
                    WeeklyClinicId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugInventorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrugInventorys_WeeklyClinics_WeeklyClinicId",
                        column: x => x.WeeklyClinicId,
                        principalTable: "WeeklyClinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FridgeComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "date", nullable: false),
                    WeeklyClinicId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FridgeComponents_WeeklyClinics_WeeklyClinicId",
                        column: x => x.WeeklyClinicId,
                        principalTable: "WeeklyClinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CorrectiveAndObservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorrectiveActionId = table.Column<int>(type: "int", nullable: false),
                    CorrectiveObservationId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectiveAndObservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorrectiveAndObservations_CorrectiveActionObservations_CorrectiveObservationId",
                        column: x => x.CorrectiveObservationId,
                        principalTable: "CorrectiveActionObservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CorrectiveAndObservations_CorrectiveActions_CorrectiveActionId",
                        column: x => x.CorrectiveActionId,
                        principalTable: "CorrectiveActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CorrectiveAndRootCauses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorrectiveActionId = table.Column<int>(type: "int", nullable: false),
                    RootCausesId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectiveAndRootCauses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorrectiveAndRootCauses_CorrectiveActions_CorrectiveActionId",
                        column: x => x.CorrectiveActionId,
                        principalTable: "CorrectiveActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CorrectiveAndRootCauses_RootCauses_RootCausesId",
                        column: x => x.RootCausesId,
                        principalTable: "RootCauses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CorrectiveDataTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SN = table.Column<int>(type: "int", nullable: true),
                    CorrectiveActionSelected = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsible = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuggestedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AchievementDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FollowUpAudit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CorrectiveActionId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectiveDataTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorrectiveDataTables_CorrectiveActions_CorrectiveActionId",
                        column: x => x.CorrectiveActionId,
                        principalTable: "CorrectiveActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CorrectiveImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectiveActionId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectiveImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorrectiveImages_CorrectiveActions_CorrectiveActionId",
                        column: x => x.CorrectiveActionId,
                        principalTable: "CorrectiveActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "JMP_Passengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PassengerID = table.Column<int>(type: "int", nullable: false),
                    JMPID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JMP_Passengers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JMP_Passengers_JMPs_JMPID",
                        column: x => x.JMPID,
                        principalTable: "JMPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_JMP_Passengers_Passengers_PassengerID",
                        column: x => x.PassengerID,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AccidentImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccidentId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccidentImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccidentImages_Accidents_AccidentId",
                        column: x => x.AccidentId,
                        principalTable: "Accidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CrewQuizAndQHSEDaily",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrewId = table.Column<int>(type: "int", nullable: false),
                    QHSEDailyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewQuizAndQHSEDaily", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrewQuizAndQHSEDaily_Crews_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CrewQuizAndQHSEDaily_QHSEDailyReport_QHSEDailyId",
                        column: x => x.QHSEDailyId,
                        principalTable: "QHSEDailyReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CrewSaftyAlertAndQHSEDaily",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrewId = table.Column<int>(type: "int", nullable: false),
                    QHSEDailyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewSaftyAlertAndQHSEDaily", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrewSaftyAlertAndQHSEDaily_Crews_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CrewSaftyAlertAndQHSEDaily_QHSEDailyReport_QHSEDailyId",
                        column: x => x.QHSEDailyId,
                        principalTable: "QHSEDailyReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LeaderShipVisitsAndQHSEDaily",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadershipVisitId = table.Column<int>(type: "int", nullable: false),
                    QHSEDailyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderShipVisitsAndQHSEDaily", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaderShipVisitsAndQHSEDaily_LeadershipVisits_LeadershipVisitId",
                        column: x => x.LeadershipVisitId,
                        principalTable: "LeadershipVisits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LeaderShipVisitsAndQHSEDaily_QHSEDailyReport_QHSEDailyId",
                        column: x => x.QHSEDailyId,
                        principalTable: "QHSEDailyReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccidentImages_AccidentId",
                table: "AccidentImages",
                column: "AccidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_AccidentCausesId",
                table: "Accidents",
                column: "AccidentCausesId");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_ClassificationOfAccidentId",
                table: "Accidents",
                column: "ClassificationOfAccidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_PreventionCategoryId",
                table: "Accidents",
                column: "PreventionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_RigId",
                table: "Accidents",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_TypeOfInjuryID",
                table: "Accidents",
                column: "TypeOfInjuryID");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_userID",
                table: "Accidents",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_ViolationCategoryId",
                table: "Accidents",
                column: "ViolationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AirHoists_RigCertificatesId",
                table: "AirHoists",
                column: "RigCertificatesId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_PTSMId",
                table: "Attendances",
                column: "PTSMId");

            migrationBuilder.CreateIndex(
                name: "IX_Bop_RigId",
                table: "Bop",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_Bop_UserId",
                table: "Bop",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveActions_FormResponsabilityId",
                table: "CorrectiveActions",
                column: "FormResponsabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveActions_StandardId",
                table: "CorrectiveActions",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveActions_userID",
                table: "CorrectiveActions",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveAndObservations_CorrectiveActionId",
                table: "CorrectiveAndObservations",
                column: "CorrectiveActionId");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveAndObservations_CorrectiveObservationId",
                table: "CorrectiveAndObservations",
                column: "CorrectiveObservationId");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveAndRootCauses_CorrectiveActionId",
                table: "CorrectiveAndRootCauses",
                column: "CorrectiveActionId");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveAndRootCauses_RootCausesId",
                table: "CorrectiveAndRootCauses",
                column: "RootCausesId");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveDataTables_CorrectiveActionId",
                table: "CorrectiveDataTables",
                column: "CorrectiveActionId");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveImages_CorrectiveActionId",
                table: "CorrectiveImages",
                column: "CorrectiveActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cranes_RigId",
                table: "Cranes",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_Cranes_userID",
                table: "Cranes",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_CrewQuizAndQHSEDaily_CrewId",
                table: "CrewQuizAndQHSEDaily",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewQuizAndQHSEDaily_QHSEDailyId",
                table: "CrewQuizAndQHSEDaily",
                column: "QHSEDailyId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewSaftyAlertAndQHSEDaily_CrewId",
                table: "CrewSaftyAlertAndQHSEDaily",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewSaftyAlertAndQHSEDaily_QHSEDailyId",
                table: "CrewSaftyAlertAndQHSEDaily",
                column: "QHSEDailyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerReports_RigId",
                table: "CustomerReports",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerReports_userID",
                table: "CustomerReports",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_DailyLiftingReports_RigId",
                table: "DailyLiftingReports",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyLiftingReports_userID",
                table: "DailyLiftingReports",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_DailyRecordStacticsLists_DailyLiftingReportId",
                table: "DailyRecordStacticsLists",
                column: "DailyLiftingReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DaysSinceNoLTI_RigId",
                table: "DaysSinceNoLTI",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_DrillImages_DrillId",
                table: "DrillImages",
                column: "DrillId");

            migrationBuilder.CreateIndex(
                name: "IX_Drills_DrillTypeId",
                table: "Drills",
                column: "DrillTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Drills_RigId",
                table: "Drills",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_Drills_userID",
                table: "Drills",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_DrugInventorys_WeeklyClinicId",
                table: "DrugInventorys",
                column: "WeeklyClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyResponseTeamMembers_DrillId",
                table: "EmergencyResponseTeamMembers",
                column: "DrillId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpCodes_PositionId",
                table: "EmpCodes",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpCodes_RigId",
                table: "EmpCodes",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCompetencyEvaluation_RigId",
                table: "EmployeeCompetencyEvaluation",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCompetencyEvaluation_SubjectId",
                table: "EmployeeCompetencyEvaluation",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCompetencyEvaluation_userID",
                table: "EmployeeCompetencyEvaluation",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCriterias_CustomerReportId",
                table: "EvaluationCriterias",
                column: "CustomerReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Forklifts_RigId",
                table: "Forklifts",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_Forklifts_userID",
                table: "Forklifts",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeComponents_WeeklyClinicId",
                table: "FridgeComponents",
                column: "WeeklyClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Handovers_RigId",
                table: "Handovers",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_Handovers_userID",
                table: "Handovers",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_HazardImages_PotentialHazardId",
                table: "HazardImages",
                column: "PotentialHazardId");

            migrationBuilder.CreateIndex(
                name: "IX_HeavyTrucks_VehicleWeeklyChecklistId",
                table: "HeavyTrucks",
                column: "VehicleWeeklyChecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_HoistingSystems_RigCertificatesId",
                table: "HoistingSystems",
                column: "RigCertificatesId");

            migrationBuilder.CreateIndex(
                name: "IX_HSEEquipments_HandoverId",
                table: "HSEEquipments",
                column: "HandoverId");

            migrationBuilder.CreateIndex(
                name: "IX_HSEEquipmentTables_EquipmentId",
                table: "HSEEquipmentTables",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_HSEEquipmentTables_RigCertificatesId",
                table: "HSEEquipmentTables",
                column: "RigCertificatesId");

            migrationBuilder.CreateIndex(
                name: "IX_HSEInventorys_HandoverId",
                table: "HSEInventorys",
                column: "HandoverId");

            migrationBuilder.CreateIndex(
                name: "IX_HydraulicWinchs_RigCertificatesId",
                table: "HydraulicWinchs",
                column: "RigCertificatesId");

            migrationBuilder.CreateIndex(
                name: "IX_JMP_Passengers_JMPID",
                table: "JMP_Passengers",
                column: "JMPID");

            migrationBuilder.CreateIndex(
                name: "IX_JMP_Passengers_PassengerID",
                table: "JMP_Passengers",
                column: "PassengerID");

            migrationBuilder.CreateIndex(
                name: "IX_JMPs_CommunicationID",
                table: "JMPs",
                column: "CommunicationID");

            migrationBuilder.CreateIndex(
                name: "IX_JMPs_DriverNameId",
                table: "JMPs",
                column: "DriverNameId");

            migrationBuilder.CreateIndex(
                name: "IX_JMPs_RouteNameID",
                table: "JMPs",
                column: "RouteNameID");

            migrationBuilder.CreateIndex(
                name: "IX_JMPs_userID",
                table: "JMPs",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_JMPs_VehicleId",
                table: "JMPs",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderShipVisitsAndQHSEDaily_LeadershipVisitId",
                table: "LeaderShipVisitsAndQHSEDaily",
                column: "LeadershipVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderShipVisitsAndQHSEDaily_QHSEDailyId",
                table: "LeaderShipVisitsAndQHSEDaily",
                column: "QHSEDailyId");

            migrationBuilder.CreateIndex(
                name: "IX_LightBuses_VehicleWeeklyChecklistId",
                table: "LightBuses",
                column: "VehicleWeeklyChecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_LTIPrevDateAndDays_DaysSinceNoLTIId",
                table: "LTIPrevDateAndDays",
                column: "DaysSinceNoLTIId");

            migrationBuilder.CreateIndex(
                name: "IX_ManPickups_VehicleWeeklyChecklistId",
                table: "ManPickups",
                column: "VehicleWeeklyChecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_ManRidingWinchs_RigCertificatesId",
                table: "ManRidingWinchs",
                column: "RigCertificatesId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialRequesteds_HandoverId",
                table: "MaterialRequesteds",
                column: "HandoverId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistoryReports_RigId",
                table: "MedicalHistoryReports",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistoryReports_userID",
                table: "MedicalHistoryReports",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReports_RigId",
                table: "MedicalReports",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReports_TypeOfIncidentId",
                table: "MedicalReports",
                column: "TypeOfIncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReports_userID",
                table: "MedicalReports",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_MudCirculationSystems_RigCertificatesId",
                table: "MudCirculationSystems",
                column: "RigCertificatesId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherSystems_RigCertificatesId",
                table: "OtherSystems",
                column: "RigCertificatesId");

            migrationBuilder.CreateIndex(
                name: "IX_PermitsToWorkLists_DailyLiftingReportId",
                table: "PermitsToWorkLists",
                column: "DailyLiftingReportId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelCerificates_RigCertificatesId",
                table: "PersonnelCerificates",
                column: "RigCertificatesId");

            migrationBuilder.CreateIndex(
                name: "IX_PotentialHazard_ResponibilityId",
                table: "PotentialHazard",
                column: "ResponibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PotentialHazard_RigId",
                table: "PotentialHazard",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_PotentialHazard_userID",
                table: "PotentialHazard",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_PowerSystems_RigCertificatesId",
                table: "PowerSystems",
                column: "RigCertificatesId");

            migrationBuilder.CreateIndex(
                name: "IX_PPEAndPPEReceivings_PPEId",
                table: "PPEAndPPEReceivings",
                column: "PPEId");

            migrationBuilder.CreateIndex(
                name: "IX_PPEAndPPEReceivings_PPEReceivingId",
                table: "PPEAndPPEReceivings",
                column: "PPEReceivingId");

            migrationBuilder.CreateIndex(
                name: "IX_PPEReceivings_RigId",
                table: "PPEReceivings",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_PPEReceivings_userID",
                table: "PPEReceivings",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_PresssureReliefValves_RigCertificatesId",
                table: "PresssureReliefValves",
                column: "RigCertificatesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemFacedDuringRigMoves_RigMovePerformanceId",
                table: "ProblemFacedDuringRigMoves",
                column: "RigMovePerformanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PTSMs_RigId",
                table: "PTSMs",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_PTSMs_UserId",
                table: "PTSMs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QHSEDailyReport_ClientId",
                table: "QHSEDailyReport",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_QHSEDailyReport_DaysSinceNoLTIId",
                table: "QHSEDailyReport",
                column: "DaysSinceNoLTIId");

            migrationBuilder.CreateIndex(
                name: "IX_QHSEDailyReport_RigId",
                table: "QHSEDailyReport",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_QHSEDailyReport_UserId",
                table: "QHSEDailyReport",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RigCertForklifts_RigCertificatesId",
                table: "RigCertForklifts",
                column: "RigCertificatesId");

            migrationBuilder.CreateIndex(
                name: "IX_RigCertificates_RigId",
                table: "RigCertificates",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_RigCertificates_userID",
                table: "RigCertificates",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_RigCertMobileCranes_RigCertificatesId",
                table: "RigCertMobileCranes",
                column: "RigCertificatesId");

            migrationBuilder.CreateIndex(
                name: "IX_RigMovePerformances_RigId",
                table: "RigMovePerformances",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_RigMovePerformances_UserId",
                table: "RigMovePerformances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RigPickups_VehicleWeeklyChecklistId",
                table: "RigPickups",
                column: "VehicleWeeklyChecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_RotarySystems_RigCertificatesId",
                table: "RotarySystems",
                column: "RigCertificatesId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftDrillTypes_HandoverId",
                table: "ShiftDrillTypes",
                column: "HandoverId");

            migrationBuilder.CreateIndex(
                name: "IX_StopCardRegisters_ClassificationID",
                table: "StopCardRegisters",
                column: "ClassificationID");

            migrationBuilder.CreateIndex(
                name: "IX_StopCardRegisters_TypeOfObservationCategoryID",
                table: "StopCardRegisters",
                column: "TypeOfObservationCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_StopCardRegisters_userID",
                table: "StopCardRegisters",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryDailyLists_DailyLiftingReportId",
                table: "SummaryDailyLists",
                column: "DailyLiftingReportId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleWeeklyChecklists_RigId",
                table: "VehicleWeeklyChecklists",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleWeeklyChecklists_userID",
                table: "VehicleWeeklyChecklists",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_HandoverId",
                table: "Visits",
                column: "HandoverId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyCampInspections_RigId",
                table: "WeeklyCampInspections",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyCampInspections_userID",
                table: "WeeklyCampInspections",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyClinics_RigId",
                table: "WeeklyClinics",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyClinics_userID",
                table: "WeeklyClinics",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyInspections_RigId",
                table: "WeeklyInspections",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyInspections_userID",
                table: "WeeklyInspections",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_WellControlSystems_RigCertificatesId",
                table: "WellControlSystems",
                column: "RigCertificatesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccidentImages");

            migrationBuilder.DropTable(
                name: "AirHoists");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Bop");

            migrationBuilder.DropTable(
                name: "CertificatesTypes");

            migrationBuilder.DropTable(
                name: "CorrectiveAndObservations");

            migrationBuilder.DropTable(
                name: "CorrectiveAndRootCauses");

            migrationBuilder.DropTable(
                name: "CorrectiveDataTables");

            migrationBuilder.DropTable(
                name: "CorrectiveImages");

            migrationBuilder.DropTable(
                name: "craneDailyLiftings");

            migrationBuilder.DropTable(
                name: "Cranes");

            migrationBuilder.DropTable(
                name: "CrewQuizAndQHSEDaily");

            migrationBuilder.DropTable(
                name: "CrewSaftyAlertAndQHSEDaily");

            migrationBuilder.DropTable(
                name: "DailyRecordStacticsLists");

            migrationBuilder.DropTable(
                name: "DrillImages");

            migrationBuilder.DropTable(
                name: "DrugInventorys");

            migrationBuilder.DropTable(
                name: "EmergencyResponseTeamMembers");

            migrationBuilder.DropTable(
                name: "EmpCodes");

            migrationBuilder.DropTable(
                name: "EmployeeCompetencyEvaluation");

            migrationBuilder.DropTable(
                name: "EvaluationCriterias");

            migrationBuilder.DropTable(
                name: "forkDailyLiftings");

            migrationBuilder.DropTable(
                name: "Forklifts");

            migrationBuilder.DropTable(
                name: "FridgeComponents");

            migrationBuilder.DropTable(
                name: "HazardImages");

            migrationBuilder.DropTable(
                name: "HeavyTrucks");

            migrationBuilder.DropTable(
                name: "HoistingSystems");

            migrationBuilder.DropTable(
                name: "HSEEquipments");

            migrationBuilder.DropTable(
                name: "HSEEquipmentTables");

            migrationBuilder.DropTable(
                name: "HSEInventorys");

            migrationBuilder.DropTable(
                name: "HydraulicWinchs");

            migrationBuilder.DropTable(
                name: "JMP_Passengers");

            migrationBuilder.DropTable(
                name: "LeaderShipVisitsAndQHSEDaily");

            migrationBuilder.DropTable(
                name: "LightBuses");

            migrationBuilder.DropTable(
                name: "LTIPrevDateAndDays");

            migrationBuilder.DropTable(
                name: "ManPickups");

            migrationBuilder.DropTable(
                name: "ManRidingWinchs");

            migrationBuilder.DropTable(
                name: "MaterialRequesteds");

            migrationBuilder.DropTable(
                name: "MedicalHistoryReports");

            migrationBuilder.DropTable(
                name: "MedicalReports");

            migrationBuilder.DropTable(
                name: "MudCirculationSystems");

            migrationBuilder.DropTable(
                name: "NonRecordableAccidents");

            migrationBuilder.DropTable(
                name: "OtherSystems");

            migrationBuilder.DropTable(
                name: "PermitsToWorkLists");

            migrationBuilder.DropTable(
                name: "PersonnelCerificates");

            migrationBuilder.DropTable(
                name: "PowerSystems");

            migrationBuilder.DropTable(
                name: "PPEAndPPEReceivings");

            migrationBuilder.DropTable(
                name: "PresssureReliefValves");

            migrationBuilder.DropTable(
                name: "ProblemFacedDuringRigMoves");

            migrationBuilder.DropTable(
                name: "RecordableAccidents");

            migrationBuilder.DropTable(
                name: "ReportedByNames");

            migrationBuilder.DropTable(
                name: "ReportedByPositions");

            migrationBuilder.DropTable(
                name: "RigCertForklifts");

            migrationBuilder.DropTable(
                name: "RigCertMobileCranes");

            migrationBuilder.DropTable(
                name: "RigPickups");

            migrationBuilder.DropTable(
                name: "RotarySystems");

            migrationBuilder.DropTable(
                name: "ShiftDrillTypes");

            migrationBuilder.DropTable(
                name: "StopCardRegisters");

            migrationBuilder.DropTable(
                name: "SummaryDailyLists");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "WeeklyCampInspections");

            migrationBuilder.DropTable(
                name: "WeeklyInspections");

            migrationBuilder.DropTable(
                name: "WellControlSystems");

            migrationBuilder.DropTable(
                name: "Accidents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PTSMs");

            migrationBuilder.DropTable(
                name: "CorrectiveActionObservations");

            migrationBuilder.DropTable(
                name: "RootCauses");

            migrationBuilder.DropTable(
                name: "CorrectiveActions");

            migrationBuilder.DropTable(
                name: "Crews");

            migrationBuilder.DropTable(
                name: "Drills");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "SubjectList");

            migrationBuilder.DropTable(
                name: "CustomerReports");

            migrationBuilder.DropTable(
                name: "WeeklyClinics");

            migrationBuilder.DropTable(
                name: "PotentialHazard");

            migrationBuilder.DropTable(
                name: "HSEEquipmentLists");

            migrationBuilder.DropTable(
                name: "JMPs");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "LeadershipVisits");

            migrationBuilder.DropTable(
                name: "QHSEDailyReport");

            migrationBuilder.DropTable(
                name: "TypeOfIncidents");

            migrationBuilder.DropTable(
                name: "PPEReceivings");

            migrationBuilder.DropTable(
                name: "PPEs");

            migrationBuilder.DropTable(
                name: "RigMovePerformances");

            migrationBuilder.DropTable(
                name: "VehicleWeeklyChecklists");

            migrationBuilder.DropTable(
                name: "Classifications");

            migrationBuilder.DropTable(
                name: "TypeOfObservationCategorys");

            migrationBuilder.DropTable(
                name: "DailyLiftingReports");

            migrationBuilder.DropTable(
                name: "Handovers");

            migrationBuilder.DropTable(
                name: "RigCertificates");

            migrationBuilder.DropTable(
                name: "AccidentCauses");

            migrationBuilder.DropTable(
                name: "ClassificationOfAccidents");

            migrationBuilder.DropTable(
                name: "PreventionCategorys");

            migrationBuilder.DropTable(
                name: "TypeOfInjurys");

            migrationBuilder.DropTable(
                name: "ViolationCategorys");

            migrationBuilder.DropTable(
                name: "CorrectiveResponsabilitys");

            migrationBuilder.DropTable(
                name: "Standards");

            migrationBuilder.DropTable(
                name: "DrillTypes");

            migrationBuilder.DropTable(
                name: "Responsibility");

            migrationBuilder.DropTable(
                name: "ComminucationMethods");

            migrationBuilder.DropTable(
                name: "DriverNames");

            migrationBuilder.DropTable(
                name: "RouteNames");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "DaysSinceNoLTI");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Rigs");
        }
    }
}
