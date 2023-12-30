﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SupplyManagement.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231230031155_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjectVendor", b =>
                {
                    b.Property<Guid>("ProjectsGuid")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("VendorsGuid")
                        .HasColumnType("char(36)");

                    b.HasKey("ProjectsGuid", "VendorsGuid");

                    b.HasIndex("VendorsGuid");

                    b.ToTable("tb_tr_vendor_project", (string)null);
                });

            modelBuilder.Entity("SupplyManagement.Models.Company", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("guid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("address");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_approved");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("phone_number");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("photo_url");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nchar(6)")
                        .HasColumnName("registration_number");

                    b.HasKey("Guid");

                    b.ToTable("tb_m_companies");
                });

            modelBuilder.Entity("SupplyManagement.Models.Project", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("guid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("description");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("end_date");

                    b.Property<bool>("IsOpenForBidding")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_open_for_bidding");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("project_name");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("start_date");

                    b.HasKey("Guid");

                    b.ToTable("tb_m_projects");
                });

            modelBuilder.Entity("SupplyManagement.Models.User", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("guid");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("role");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("user_name");

                    b.HasKey("Guid");

                    b.ToTable("tb_m_users");
                });

            modelBuilder.Entity("SupplyManagement.Models.Vendor", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("guid");

                    b.Property<string>("BusinessField")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("businees_field");

                    b.Property<Guid>("CompanyGuid")
                        .HasColumnType("char(36)")
                        .HasColumnName("company_guid");

                    b.Property<string>("CompanyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("company_type");

                    b.Property<bool>("IsApprovedByAdmin")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_approved_by_admin");

                    b.Property<bool>("IsApprovedByManager")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_approved_by_manager");

                    b.HasKey("Guid");

                    b.HasIndex("CompanyGuid");

                    b.ToTable("tb_m_vendors");
                });

            modelBuilder.Entity("SupplyManagement.Models.VendorApproval", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("guid");

                    b.Property<DateTime>("ApprovalDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("approval_date");

                    b.Property<Guid>("ApprovedByUserGuid")
                        .HasColumnType("char(36)")
                        .HasColumnName("approved_by_user_guid");

                    b.Property<Guid>("ApprovedByUserGuid1")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("VendorGuid")
                        .HasColumnType("char(36)")
                        .HasColumnName("vendor_guid");

                    b.HasKey("Guid");

                    b.HasIndex("ApprovedByUserGuid");

                    b.HasIndex("ApprovedByUserGuid1");

                    b.HasIndex("VendorGuid");

                    b.ToTable("tb_tr_vendor_approvals");
                });

            modelBuilder.Entity("ProjectVendor", b =>
                {
                    b.HasOne("SupplyManagement.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SupplyManagement.Models.Vendor", null)
                        .WithMany()
                        .HasForeignKey("VendorsGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SupplyManagement.Models.Vendor", b =>
                {
                    b.HasOne("SupplyManagement.Models.Company", "Company")
                        .WithMany("Vendors")
                        .HasForeignKey("CompanyGuid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("SupplyManagement.Models.VendorApproval", b =>
                {
                    b.HasOne("SupplyManagement.Models.User", "User")
                        .WithMany("VendorApprovals")
                        .HasForeignKey("ApprovedByUserGuid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SupplyManagement.Models.User", "ApprovedByUser")
                        .WithMany()
                        .HasForeignKey("ApprovedByUserGuid1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SupplyManagement.Models.Vendor", "Vendor")
                        .WithMany("VendorApprovals")
                        .HasForeignKey("VendorGuid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApprovedByUser");

                    b.Navigation("User");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("SupplyManagement.Models.Company", b =>
                {
                    b.Navigation("Vendors");
                });

            modelBuilder.Entity("SupplyManagement.Models.User", b =>
                {
                    b.Navigation("VendorApprovals");
                });

            modelBuilder.Entity("SupplyManagement.Models.Vendor", b =>
                {
                    b.Navigation("VendorApprovals");
                });
#pragma warning restore 612, 618
        }
    }
}
