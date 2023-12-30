using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplyManagement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_companies",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "char(36)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    registration_number = table.Column<string>(type: "nchar(6)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    photo_url = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    is_approved = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_companies", x => x.guid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_projects",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "char(36)", nullable: false),
                    project_name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    is_open_for_bidding = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_projects", x => x.guid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_users",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "char(36)", nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    password = table.Column<string>(type: "longtext", nullable: false),
                    role = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_users", x => x.guid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_vendors",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "char(36)", nullable: false),
                    company_guid = table.Column<Guid>(type: "char(36)", nullable: false),
                    businees_field = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    company_type = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    is_approved_by_admin = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_approved_by_manager = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_vendors", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_m_vendors_tb_m_companies_company_guid",
                        column: x => x.company_guid,
                        principalTable: "tb_m_companies",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_tr_vendor_approvals",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "char(36)", nullable: false),
                    vendor_guid = table.Column<Guid>(type: "char(36)", nullable: false),
                    approved_by_user_guid = table.Column<Guid>(type: "char(36)", nullable: false),
                    approval_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ApprovedByUserGuid1 = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_vendor_approvals", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_tr_vendor_approvals_tb_m_users_approved_by_user_guid",
                        column: x => x.approved_by_user_guid,
                        principalTable: "tb_m_users",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_tr_vendor_approvals_tb_m_users_ApprovedByUserGuid1",
                        column: x => x.ApprovedByUserGuid1,
                        principalTable: "tb_m_users",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_tr_vendor_approvals_tb_m_vendors_vendor_guid",
                        column: x => x.vendor_guid,
                        principalTable: "tb_m_vendors",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_tr_vendor_project",
                columns: table => new
                {
                    ProjectsGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    VendorsGuid = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_vendor_project", x => new { x.ProjectsGuid, x.VendorsGuid });
                    table.ForeignKey(
                        name: "FK_tb_tr_vendor_project_tb_m_projects_ProjectsGuid",
                        column: x => x.ProjectsGuid,
                        principalTable: "tb_m_projects",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_tr_vendor_project_tb_m_vendors_VendorsGuid",
                        column: x => x.VendorsGuid,
                        principalTable: "tb_m_vendors",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_vendors_company_guid",
                table: "tb_m_vendors",
                column: "company_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_vendor_approvals_approved_by_user_guid",
                table: "tb_tr_vendor_approvals",
                column: "approved_by_user_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_vendor_approvals_ApprovedByUserGuid1",
                table: "tb_tr_vendor_approvals",
                column: "ApprovedByUserGuid1");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_vendor_approvals_vendor_guid",
                table: "tb_tr_vendor_approvals",
                column: "vendor_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_vendor_project_VendorsGuid",
                table: "tb_tr_vendor_project",
                column: "VendorsGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_tr_vendor_approvals");

            migrationBuilder.DropTable(
                name: "tb_tr_vendor_project");

            migrationBuilder.DropTable(
                name: "tb_m_users");

            migrationBuilder.DropTable(
                name: "tb_m_projects");

            migrationBuilder.DropTable(
                name: "tb_m_vendors");

            migrationBuilder.DropTable(
                name: "tb_m_companies");
        }
    }
}
