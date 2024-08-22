﻿// <auto-generated />
using System;
using AlexDemo.CustomerHub.DataAccess.EF.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlexDemo.CustomerHub.DataAccess.EF.Migrations
{
    [DbContext(typeof(CustomerHubDbContext))]
    partial class CustomerHubDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("demo")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlexDemo.CustomerHub.Core.Entities.Customer.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte>("BusinessType")
                        .HasColumnType("tinyint");

                    b.Property<string>("CeoName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte>("Currency")
                        .HasColumnType("tinyint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte>("HeadOfficeCountry")
                        .HasColumnType("tinyint");

                    b.Property<int>("NumberOfEmployees")
                        .HasColumnType("int");

                    b.Property<decimal>("Revenue")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("WebSite")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("BrandName")
                        .IsUnique()
                        .HasDatabaseName("IX_Company_BrandName");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("IX_UX_Company_Email");

                    b.HasIndex("Status")
                        .HasDatabaseName("IX_Company_Status");

                    b.ToTable("Company", "demo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandName = "Bentley",
                            BusinessType = (byte)3,
                            CeoName = "Adrian Hallmark",
                            Currency = (byte)1,
                            Email = "bentley@demo.com",
                            HeadOfficeCountry = (byte)1,
                            NumberOfEmployees = 5000,
                            Revenue = 3700000m,
                            Status = (byte)2,
                            UpdatedOn = new DateTime(2024, 8, 22, 21, 21, 47, 919, DateTimeKind.Utc).AddTicks(817),
                            WebSite = "www.bentleymotors.com"
                        },
                        new
                        {
                            Id = 2,
                            BrandName = "Aston Martin",
                            BusinessType = (byte)3,
                            CeoName = "Amedeo Felisa",
                            Currency = (byte)1,
                            Email = "aston-martin@demo.com",
                            HeadOfficeCountry = (byte)1,
                            NumberOfEmployees = 2500,
                            Revenue = 1400000000m,
                            Status = (byte)2,
                            UpdatedOn = new DateTime(2024, 8, 22, 21, 22, 47, 919, DateTimeKind.Utc).AddTicks(831),
                            WebSite = "www.astonmartin.com"
                        },
                        new
                        {
                            Id = 3,
                            BrandName = "BMW",
                            BusinessType = (byte)6,
                            CeoName = "Oliver Zipse",
                            Currency = (byte)3,
                            Email = "bnw@demo.com",
                            HeadOfficeCountry = (byte)3,
                            NumberOfEmployees = 130000,
                            Revenue = 158000000000m,
                            Status = (byte)1,
                            UpdatedOn = new DateTime(2024, 8, 22, 21, 22, 47, 919, DateTimeKind.Utc).AddTicks(835)
                        },
                        new
                        {
                            Id = 4,
                            BrandName = "Volvo",
                            BusinessType = (byte)4,
                            CeoName = "Jim Rowan",
                            Currency = (byte)3,
                            Email = "volvo@demo.com",
                            HeadOfficeCountry = (byte)2,
                            NumberOfEmployees = 40000,
                            Revenue = 36200000000m,
                            Status = (byte)2,
                            UpdatedOn = new DateTime(2024, 8, 16, 21, 22, 47, 919, DateTimeKind.Utc).AddTicks(838)
                        },
                        new
                        {
                            Id = 5,
                            BrandName = "Toyota",
                            BusinessType = (byte)6,
                            CeoName = "Akio Toyoda",
                            Currency = (byte)4,
                            Email = "toyota@demo.com",
                            HeadOfficeCountry = (byte)6,
                            NumberOfEmployees = 370000,
                            Revenue = 240000000000m,
                            Status = (byte)3,
                            UpdatedOn = new DateTime(2024, 8, 22, 21, 22, 47, 919, DateTimeKind.Utc).AddTicks(842)
                        },
                        new
                        {
                            Id = 6,
                            BrandName = "Audi",
                            BusinessType = (byte)5,
                            CeoName = "Markus Duesmann",
                            Currency = (byte)3,
                            Email = "audi@demo.com",
                            HeadOfficeCountry = (byte)3,
                            NumberOfEmployees = 90000,
                            Revenue = 61400000000m,
                            Status = (byte)2,
                            UpdatedOn = new DateTime(2024, 8, 22, 21, 22, 47, 919, DateTimeKind.Utc).AddTicks(844)
                        },
                        new
                        {
                            Id = 7,
                            BrandName = "Ford",
                            BusinessType = (byte)6,
                            CeoName = "Jim Farley",
                            Currency = (byte)2,
                            Email = "ford@demo.com",
                            HeadOfficeCountry = (byte)5,
                            NumberOfEmployees = 180000,
                            Revenue = 167000000000m,
                            Status = (byte)2,
                            UpdatedOn = new DateTime(2024, 8, 22, 21, 22, 47, 919, DateTimeKind.Utc).AddTicks(846)
                        },
                        new
                        {
                            Id = 8,
                            BrandName = "Skoda",
                            BusinessType = (byte)4,
                            CeoName = "Klaus Zellmer",
                            Currency = (byte)3,
                            Email = "skoda@demo.com",
                            HeadOfficeCountry = (byte)4,
                            NumberOfEmployees = 45000,
                            Revenue = 23000000000m,
                            Status = (byte)1,
                            UpdatedOn = new DateTime(2024, 8, 22, 21, 22, 47, 919, DateTimeKind.Utc).AddTicks(848)
                        });
                });

            modelBuilder.Entity("AlexDemo.CustomerHub.Core.Entities.Customer.CompanyOffice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<byte>("Country")
                        .HasColumnType("tinyint");

                    b.Property<bool>("IsHeadOffice")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumberOfEmployees")
                        .HasColumnType("int");

                    b.Property<string>("OfficeCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("OfficeCode")
                        .IsUnique()
                        .HasDatabaseName("IX_UX_CO_Code");

                    b.ToTable("CompanyOffice", "demo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            Country = (byte)1,
                            IsHeadOffice = true,
                            Name = "Bentley Motors Crewe",
                            NumberOfEmployees = 4000,
                            OfficeCode = "BNTL-1",
                            Status = (byte)0,
                            UpdatedOn = new DateTime(2024, 8, 22, 21, 22, 47, 919, DateTimeKind.Utc).AddTicks(1979),
                            ZipCode = "CW1 3PL"
                        },
                        new
                        {
                            Id = 2,
                            CompanyId = 2,
                            Country = (byte)1,
                            IsHeadOffice = true,
                            Name = "Aston Martin Gaydon",
                            NumberOfEmployees = 100,
                            OfficeCode = "ASTN-1",
                            Status = (byte)0,
                            UpdatedOn = new DateTime(2024, 8, 22, 21, 22, 47, 919, DateTimeKind.Utc).AddTicks(1982),
                            ZipCode = "CV35 0DB"
                        });
                });

            modelBuilder.Entity("AlexDemo.CustomerHub.Core.Entities.Customer.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<byte>("CompanyRole")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("PrimaryOfficeId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<string>("Title")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2(0)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Login")
                        .IsUnique()
                        .HasDatabaseName("IX_UX_User_Login");

                    b.HasIndex("PrimaryOfficeId");

                    b.ToTable("User", "demo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            CompanyRole = (byte)0,
                            DateOfBirth = new DateTime(1981, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "test.bentley@bentley.com",
                            FirstName = "Test",
                            LastName = "Sir",
                            Login = "test.bentley",
                            PasswordHash = "GLHedsmFUt6kqasyxn6KsGsf/mThOme6ElLZm/fw0bU=",
                            PasswordSalt = "svnVSv8cVzCQQyV2zELixw==",
                            PrimaryOfficeId = 1,
                            Status = (byte)0,
                            Title = "Mr",
                            UpdatedOn = new DateTime(2024, 8, 22, 21, 22, 47, 921, DateTimeKind.Utc).AddTicks(1917)
                        },
                        new
                        {
                            Id = 2,
                            CompanyId = 2,
                            CompanyRole = (byte)0,
                            DateOfBirth = new DateTime(1983, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "test.aston@aston.com",
                            FirstName = "Test",
                            LastName = "Madam",
                            Login = "test.aston",
                            PasswordHash = "kPS45Rsoy687P9g5rorhqwFyI4te+X9VN93JUy3xORs=",
                            PasswordSalt = "FbPm7DDOeQ6+pCmhzq7Xzg==",
                            PrimaryOfficeId = 2,
                            Status = (byte)0,
                            Title = "Mrs",
                            UpdatedOn = new DateTime(2024, 8, 22, 21, 22, 47, 922, DateTimeKind.Utc).AddTicks(9843)
                        },
                        new
                        {
                            Id = 3,
                            CompanyId = 1,
                            CompanyRole = (byte)0,
                            DateOfBirth = new DateTime(1999, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user.bentley@aston.com",
                            Login = "user.benntley",
                            PasswordHash = "xluP2jDFdbsjpbyuDoKMuUQ4yY/QdI0RyyqmHs+A7Bc=",
                            PasswordSalt = "ifFB0wyDuyULpIwXkGF6rg==",
                            PrimaryOfficeId = 1,
                            Status = (byte)0,
                            UpdatedOn = new DateTime(2024, 8, 22, 21, 22, 47, 924, DateTimeKind.Utc).AddTicks(9136)
                        });
                });

            modelBuilder.Entity("AlexDemo.CustomerHub.Core.Entities.Portfolio.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("ProjectBudget")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.Property<string>("ProjectCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProjectOwnerId")
                        .HasColumnType("int");

                    b.Property<byte>("ProjectStatus")
                        .HasColumnType("tinyint");

                    b.Property<int>("ResponsibleOfficeId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2(0)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2(0)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProjectOwnerId");

                    b.HasIndex("ResponsibleOfficeId");

                    b.ToTable("Project", "demo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            Description = "test bentley project",
                            Name = "first bentley project",
                            ProjectBudget = 0m,
                            ProjectCode = "BNTL-TEST",
                            ProjectOwnerId = 1,
                            ProjectStatus = (byte)0,
                            ResponsibleOfficeId = 1,
                            StartDate = new DateTime(2024, 8, 29, 21, 22, 47, 925, DateTimeKind.Utc).AddTicks(20),
                            Status = (byte)1,
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CompanyId = 1,
                            Description = "second test bentley project",
                            Name = "second bentley project",
                            ProjectBudget = 0m,
                            ProjectCode = "BNTL-TEST-2",
                            ProjectOwnerId = 1,
                            ProjectStatus = (byte)0,
                            ResponsibleOfficeId = 1,
                            StartDate = new DateTime(2024, 8, 23, 21, 22, 47, 925, DateTimeKind.Utc).AddTicks(27),
                            Status = (byte)1,
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("AlexDemo.CustomerHub.Core.Entities.Portfolio.ProjectUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<byte>("CurrentRole")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("PositionDescription")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2(0)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2(0)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectUser", "demo");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CurrentRole = (byte)1,
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectId = 1,
                            StartDate = new DateTime(2024, 8, 22, 21, 22, 47, 925, DateTimeKind.Utc).AddTicks(757),
                            Status = (byte)2,
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        });
                });

            modelBuilder.Entity("AlexDemo.CustomerHub.Core.Entities.Customer.CompanyOffice", b =>
                {
                    b.HasOne("AlexDemo.CustomerHub.Core.Entities.Customer.Company", "Company")
                        .WithMany("Offices")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("AlexDemo.CustomerHub.Core.Entities.Customer.User", b =>
                {
                    b.HasOne("AlexDemo.CustomerHub.Core.Entities.Customer.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AlexDemo.CustomerHub.Core.Entities.Customer.CompanyOffice", "PrimaryOffice")
                        .WithMany("Users")
                        .HasForeignKey("PrimaryOfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("PrimaryOffice");
                });

            modelBuilder.Entity("AlexDemo.CustomerHub.Core.Entities.Portfolio.Project", b =>
                {
                    b.HasOne("AlexDemo.CustomerHub.Core.Entities.Customer.Company", "Company")
                        .WithMany("Projects")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AlexDemo.CustomerHub.Core.Entities.Customer.User", "ProjectOwner")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectOwnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AlexDemo.CustomerHub.Core.Entities.Customer.CompanyOffice", "ResponsibleOffice")
                        .WithMany("Projects")
                        .HasForeignKey("ResponsibleOfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("ProjectOwner");

                    b.Navigation("ResponsibleOffice");
                });

            modelBuilder.Entity("AlexDemo.CustomerHub.Core.Entities.Portfolio.ProjectUser", b =>
                {
                    b.HasOne("AlexDemo.CustomerHub.Core.Entities.Portfolio.Project", "Project")
                        .WithMany("ProjectUsers")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AlexDemo.CustomerHub.Core.Entities.Customer.User", "User")
                        .WithMany("ProjectUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AlexDemo.CustomerHub.Core.Entities.Customer.Company", b =>
                {
                    b.Navigation("Offices");

                    b.Navigation("Projects");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("AlexDemo.CustomerHub.Core.Entities.Customer.CompanyOffice", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("AlexDemo.CustomerHub.Core.Entities.Customer.User", b =>
                {
                    b.Navigation("ProjectUsers");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("AlexDemo.CustomerHub.Core.Entities.Portfolio.Project", b =>
                {
                    b.Navigation("ProjectUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
