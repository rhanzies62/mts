﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Mts.Infrastructure.Data;
using System;

namespace Mts.Infrastructure.Data.Migrations
{
    [DbContext(typeof(MtsContext))]
    partial class MtsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mts.Core.Entity.ApplicationFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsPanel");

                    b.Property<bool>("IsParent");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ParentId");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("ApplicationFeature");
                });

            modelBuilder.Entity("Mts.Core.Entity.Business", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NatureOfBusiness")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.ToTable("Business");
                });

            modelBuilder.Entity("Mts.Core.Entity.BusinessClaim", b =>
                {
                    b.Property<int>("ClaimId");

                    b.Property<int>("BusinessId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("ClaimId", "BusinessId");

                    b.HasAlternateKey("BusinessId", "ClaimId");

                    b.ToTable("BusinessClaim");
                });

            modelBuilder.Entity("Mts.Core.Entity.Claim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Claim");
                });

            modelBuilder.Entity("Mts.Core.Entity.RegistrationRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Token")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("RegistrationRequest");
                });

            modelBuilder.Entity("Mts.Core.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BusinessId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Mts.Core.Entity.RoleApplicationFeature", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("ApplicationFeatureId");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("FullAccess");

                    b.Property<string>("UpdatedBy")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("RoleId", "ApplicationFeatureId");

                    b.HasAlternateKey("ApplicationFeatureId", "RoleId");

                    b.ToTable("RoleApplicationFeature");
                });

            modelBuilder.Entity("Mts.Core.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Mts.Core.Entity.UserBusiness", b =>
                {
                    b.Property<int>("BusinessId");

                    b.Property<int>("UserId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("BusinessId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBusiness");
                });

            modelBuilder.Entity("Mts.Core.Entity.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("UserId", "RoleId");

                    b.HasAlternateKey("RoleId", "UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Mts.Core.Entity.BusinessClaim", b =>
                {
                    b.HasOne("Mts.Core.Entity.Business", "Business")
                        .WithMany("BusinessClaims")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mts.Core.Entity.Claim", "Claim")
                        .WithMany()
                        .HasForeignKey("ClaimId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mts.Core.Entity.Role", b =>
                {
                    b.HasOne("Mts.Core.Entity.Business", "Business")
                        .WithMany()
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mts.Core.Entity.RoleApplicationFeature", b =>
                {
                    b.HasOne("Mts.Core.Entity.ApplicationFeature", "ApplicationFeature")
                        .WithMany()
                        .HasForeignKey("ApplicationFeatureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mts.Core.Entity.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mts.Core.Entity.UserBusiness", b =>
                {
                    b.HasOne("Mts.Core.Entity.Business", "Business")
                        .WithMany("UserBusinesses")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mts.Core.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
