using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Mts.Infrastructure.Data.Migrations
{
    public partial class reinitializedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLineOne = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    District = table.Column<string>(nullable: false),
                    StreetName = table.Column<string>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationFeature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsPanel = table.Column<bool>(nullable: false),
                    IsParent = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    RouteAddress = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationFeature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    NatureOfBusiness = table.Column<string>(maxLength: 500, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Claim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CredentialUpdateLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    IsPasswordUpdate = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CredentialUpdateLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IpAddress = table.Column<string>(nullable: true),
                    Success = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.UniqueConstraint("AK_UserRole_RoleId_UserId", x => new { x.RoleId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: false),
                    ContactNumber = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    ErrorCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsEmailValidated = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    ValidatedDate = table.Column<DateTime>(nullable: false),
                    ValidationToken = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessClaim",
                columns: table => new
                {
                    ClaimId = table.Column<int>(nullable: false),
                    BusinessId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessClaim", x => new { x.ClaimId, x.BusinessId });
                    table.UniqueConstraint("AK_BusinessClaim_BusinessId_ClaimId", x => new { x.BusinessId, x.ClaimId });
                    table.ForeignKey(
                        name: "FK_BusinessClaim_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessClaim_Claim_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBusiness",
                columns: table => new
                {
                    BusinessId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBusiness", x => new { x.BusinessId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserBusiness_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBusiness_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleApplicationFeature",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    ApplicationFeatureId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    FullAccess = table.Column<bool>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleApplicationFeature", x => new { x.RoleId, x.ApplicationFeatureId });
                    table.UniqueConstraint("AK_RoleApplicationFeature_ApplicationFeatureId_RoleId", x => new { x.ApplicationFeatureId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RoleApplicationFeature_ApplicationFeature_ApplicationFeatureId",
                        column: x => x.ApplicationFeatureId,
                        principalTable: "ApplicationFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleApplicationFeature_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Role_BusinessId",
                table: "Role",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_User_AddressId",
                table: "User",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBusiness_UserId",
                table: "UserBusiness",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessClaim");

            migrationBuilder.DropTable(
                name: "CredentialUpdateLog");

            migrationBuilder.DropTable(
                name: "LoginLog");

            migrationBuilder.DropTable(
                name: "RegistrationRequest");

            migrationBuilder.DropTable(
                name: "RoleApplicationFeature");

            migrationBuilder.DropTable(
                name: "UserBusiness");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Claim");

            migrationBuilder.DropTable(
                name: "ApplicationFeature");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
