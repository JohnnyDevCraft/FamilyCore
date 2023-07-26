using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyCore.Module.Migrations
{
    /// <inheritdoc />
    public partial class Version_1_0_0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AddressLine1 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressLine2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ZipCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AuditEFCoreWeakReference",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TypeName = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Key = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DefaultString = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditEFCoreWeakReference", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DashboardData",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Content = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SynchronizeTitle = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardData", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Subject = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EndOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AllDay = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Location = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Label = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    RecurrenceInfoXml = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RecurrencePatternID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ReminderInfoXml = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RemindInSeconds = table.Column<int>(type: "int", nullable: false),
                    AlarmTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsPostponed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Event_Event_RecurrencePatternID",
                        column: x => x.RecurrencePatternID,
                        principalTable: "Event",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FileData",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Size = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileData", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModelDifferences",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContextId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelDifferences", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModulesInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AssemblyFileName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Version = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsMain = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulesInfo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PermissionPolicyRoleBase",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAdministrative = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CanEditModel = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PermissionPolicy = table.Column<int>(type: "int", nullable: false),
                    IsAllowPermissionPriority = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyRoleBase", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PermissionPolicyUser",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ChangePasswordOnFirstLogon = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoredPassword = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainPhone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Extension = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyUser", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReportDataV2",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataTypeName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsInplaceReport = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PredefinedReportTypeName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<byte[]>(type: "longblob", nullable: true),
                    DisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParametersObjectTypeName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDataV2", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    Key = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Caption = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Color_Int = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Key);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Payees",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    BillingAddressID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ShippingAddressID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    MainPhone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Extension = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fax = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Website = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TaxId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payees_Addresses_BillingAddressID",
                        column: x => x.BillingAddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Payees_Addresses_ShippingAddressID",
                        column: x => x.ShippingAddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AuditData",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    OperationType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OldValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NewValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditedObjectID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    OldObjectID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    NewObjectID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UserObjectID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AuditData_AuditEFCoreWeakReference_AuditedObjectID",
                        column: x => x.AuditedObjectID,
                        principalTable: "AuditEFCoreWeakReference",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AuditData_AuditEFCoreWeakReference_NewObjectID",
                        column: x => x.NewObjectID,
                        principalTable: "AuditEFCoreWeakReference",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AuditData_AuditEFCoreWeakReference_OldObjectID",
                        column: x => x.OldObjectID,
                        principalTable: "AuditEFCoreWeakReference",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AuditData_AuditEFCoreWeakReference_UserObjectID",
                        column: x => x.UserObjectID,
                        principalTable: "AuditEFCoreWeakReference",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModelDifferenceAspects",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Xml = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OwnerID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelDifferenceAspects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ModelDifferenceAspects_ModelDifferences_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "ModelDifferences",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PermissionPolicyActionPermissionObject",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ActionId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyActionPermissionObject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyActionPermissionObject_PermissionPolicyRoleB~",
                        column: x => x.RoleID,
                        principalTable: "PermissionPolicyRoleBase",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PermissionPolicyNavigationPermissionObject",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ItemPath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TargetTypeFullName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NavigateState = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyNavigationPermissionObject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyNavigationPermissionObject_PermissionPolicyR~",
                        column: x => x.RoleID,
                        principalTable: "PermissionPolicyRoleBase",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PermissionPolicyTypePermissionObject",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TargetTypeFullName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ReadState = table.Column<int>(type: "int", nullable: true),
                    WriteState = table.Column<int>(type: "int", nullable: true),
                    CreateState = table.Column<int>(type: "int", nullable: true),
                    DeleteState = table.Column<int>(type: "int", nullable: true),
                    NavigateState = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyTypePermissionObject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyTypePermissionObject_PermissionPolicyRoleBas~",
                        column: x => x.RoleID,
                        principalTable: "PermissionPolicyRoleBase",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PermissionPolicyRolePermissionPolicyUser",
                columns: table => new
                {
                    RolesID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsersID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyRolePermissionPolicyUser", x => new { x.RolesID, x.UsersID });
                    table.ForeignKey(
                        name: "FK_PermissionPolicyRolePermissionPolicyUser_PermissionPolicyRol~",
                        column: x => x.RolesID,
                        principalTable: "PermissionPolicyRoleBase",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyRolePermissionPolicyUser_PermissionPolicyUse~",
                        column: x => x.UsersID,
                        principalTable: "PermissionPolicyUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EventResource",
                columns: table => new
                {
                    EventsID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ResourcesKey = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventResource", x => new { x.EventsID, x.ResourcesKey });
                    table.ForeignKey(
                        name: "FK_EventResource_Event_EventsID",
                        column: x => x.EventsID,
                        principalTable: "Event",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventResource_Resource_ResourcesKey",
                        column: x => x.ResourcesKey,
                        principalTable: "Resource",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PayeeContacts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OfficePhone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OfficeExtension = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FaxLine = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CellPhone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JobTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PayeeID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayeeContacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PayeeContacts_Payees_PayeeID",
                        column: x => x.PayeeID,
                        principalTable: "Payees",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PermissionPolicyMemberPermissionsObject",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Members = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Criteria = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReadState = table.Column<int>(type: "int", nullable: true),
                    WriteState = table.Column<int>(type: "int", nullable: true),
                    TypePermissionObjectID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyMemberPermissionsObject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyMemberPermissionsObject_PermissionPolicyType~",
                        column: x => x.TypePermissionObjectID,
                        principalTable: "PermissionPolicyTypePermissionObject",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PermissionPolicyObjectPermissionsObject",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Criteria = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReadState = table.Column<int>(type: "int", nullable: true),
                    WriteState = table.Column<int>(type: "int", nullable: true),
                    DeleteState = table.Column<int>(type: "int", nullable: true),
                    NavigateState = table.Column<int>(type: "int", nullable: true),
                    TypePermissionObjectID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyObjectPermissionsObject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyObjectPermissionsObject_PermissionPolicyType~",
                        column: x => x.TypePermissionObjectID,
                        principalTable: "PermissionPolicyTypePermissionObject",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AccountName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoutingNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeldWithID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    MainContactID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DateOpened = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateClosed = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    OpeningAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    OriginalCreditorID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CurrentCreditorID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    OriginalId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OriginDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DebtInterestRate = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    OriginalAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    BadDebtType = table.Column<int>(type: "int", nullable: false),
                    DateServed = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CaseNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProsecutingAttorneyID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DateFiled = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CourtDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateJudgement = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateSettled = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CourtFiledInID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreditLimit = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    NextStatement = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    NextPaymentDue = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    MinimumPayment = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    AccountManagerID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    AutoNotify = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Accounts_PayeeContacts_AccountManagerID",
                        column: x => x.AccountManagerID,
                        principalTable: "PayeeContacts",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Accounts_PayeeContacts_MainContactID",
                        column: x => x.MainContactID,
                        principalTable: "PayeeContacts",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Accounts_Payees_CourtFiledInID",
                        column: x => x.CourtFiledInID,
                        principalTable: "Payees",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Accounts_Payees_CurrentCreditorID",
                        column: x => x.CurrentCreditorID,
                        principalTable: "Payees",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Accounts_Payees_HeldWithID",
                        column: x => x.HeldWithID,
                        principalTable: "Payees",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Accounts_Payees_OriginalCreditorID",
                        column: x => x.OriginalCreditorID,
                        principalTable: "Payees",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Accounts_Payees_ProsecutingAttorneyID",
                        column: x => x.ProsecutingAttorneyID,
                        principalTable: "Payees",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CommLog",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AccountID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ContactID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Subject = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CommLog_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CommLog_PayeeContacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "PayeeContacts",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FromAccountID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ToAccountID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReferenceNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsReconciled = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    ReconciledDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ReconciledNotes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_FromAccountID",
                        column: x => x.FromAccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_ToAccountID",
                        column: x => x.ToAccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountManagerID",
                table: "Accounts",
                column: "AccountManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CourtFiledInID",
                table: "Accounts",
                column: "CourtFiledInID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CurrentCreditorID",
                table: "Accounts",
                column: "CurrentCreditorID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_HeldWithID",
                table: "Accounts",
                column: "HeldWithID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_MainContactID",
                table: "Accounts",
                column: "MainContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_OriginalCreditorID",
                table: "Accounts",
                column: "OriginalCreditorID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ProsecutingAttorneyID",
                table: "Accounts",
                column: "ProsecutingAttorneyID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditData_AuditedObjectID",
                table: "AuditData",
                column: "AuditedObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditData_NewObjectID",
                table: "AuditData",
                column: "NewObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditData_OldObjectID",
                table: "AuditData",
                column: "OldObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditData_UserObjectID",
                table: "AuditData",
                column: "UserObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditEFCoreWeakReference_Key_TypeName",
                table: "AuditEFCoreWeakReference",
                columns: new[] { "Key", "TypeName" });

            migrationBuilder.CreateIndex(
                name: "IX_CommLog_AccountID",
                table: "CommLog",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_CommLog_ContactID",
                table: "CommLog",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_RecurrencePatternID",
                table: "Event",
                column: "RecurrencePatternID");

            migrationBuilder.CreateIndex(
                name: "IX_EventResource_ResourcesKey",
                table: "EventResource",
                column: "ResourcesKey");

            migrationBuilder.CreateIndex(
                name: "IX_ModelDifferenceAspects_OwnerID",
                table: "ModelDifferenceAspects",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_PayeeContacts_PayeeID",
                table: "PayeeContacts",
                column: "PayeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Payees_BillingAddressID",
                table: "Payees",
                column: "BillingAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Payees_ShippingAddressID",
                table: "Payees",
                column: "ShippingAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyActionPermissionObject_RoleID",
                table: "PermissionPolicyActionPermissionObject",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyMemberPermissionsObject_TypePermissionObject~",
                table: "PermissionPolicyMemberPermissionsObject",
                column: "TypePermissionObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyNavigationPermissionObject_RoleID",
                table: "PermissionPolicyNavigationPermissionObject",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyObjectPermissionsObject_TypePermissionObject~",
                table: "PermissionPolicyObjectPermissionsObject",
                column: "TypePermissionObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyRolePermissionPolicyUser_UsersID",
                table: "PermissionPolicyRolePermissionPolicyUser",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyTypePermissionObject_RoleID",
                table: "PermissionPolicyTypePermissionObject",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FromAccountID",
                table: "Transactions",
                column: "FromAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ToAccountID",
                table: "Transactions",
                column: "ToAccountID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditData");

            migrationBuilder.DropTable(
                name: "CommLog");

            migrationBuilder.DropTable(
                name: "DashboardData");

            migrationBuilder.DropTable(
                name: "EventResource");

            migrationBuilder.DropTable(
                name: "FileData");

            migrationBuilder.DropTable(
                name: "ModelDifferenceAspects");

            migrationBuilder.DropTable(
                name: "ModulesInfo");

            migrationBuilder.DropTable(
                name: "PermissionPolicyActionPermissionObject");

            migrationBuilder.DropTable(
                name: "PermissionPolicyMemberPermissionsObject");

            migrationBuilder.DropTable(
                name: "PermissionPolicyNavigationPermissionObject");

            migrationBuilder.DropTable(
                name: "PermissionPolicyObjectPermissionsObject");

            migrationBuilder.DropTable(
                name: "PermissionPolicyRolePermissionPolicyUser");

            migrationBuilder.DropTable(
                name: "ReportDataV2");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "AuditEFCoreWeakReference");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "ModelDifferences");

            migrationBuilder.DropTable(
                name: "PermissionPolicyTypePermissionObject");

            migrationBuilder.DropTable(
                name: "PermissionPolicyUser");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "PermissionPolicyRoleBase");

            migrationBuilder.DropTable(
                name: "PayeeContacts");

            migrationBuilder.DropTable(
                name: "Payees");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
