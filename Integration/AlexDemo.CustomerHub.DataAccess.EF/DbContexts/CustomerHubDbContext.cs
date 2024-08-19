using AlexDemo.CustomerHub.Core.Entities.Customer;
using AlexDemo.CustomerHub.Core.Entities.Portfolio;
using AlexDemo.CustomerHub.DataAccess.EF.Extensions;
using AlexDemo.CustomerHub.DataAccess.EF.Settings;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AlexDemo.CustomerHub.DataAccess.EF.DbContexts
{
    public class CustomerHubDbContext(
        DbContextOptions options,
        IOptions<DatabaseSettings> dbSettings)
        : DbContext(options)
    {
        protected readonly DatabaseSettings DbSettings = dbSettings.Value;

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyOffice> CompanyOffices { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbSettings.CustomerHubConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DbConstants.Domain.DefaultSchemaName);

            // common configurations
            modelBuilder.ConfigureRowVersion();

            DefineCustomerConfiguration(modelBuilder);

            DefineOfficeConfiguration(modelBuilder);

            DefineUserConfiguration(modelBuilder);

            DefineProjectConfiguration(modelBuilder);

            DefineProjectUserConfiguration(modelBuilder);

            ConfigureRelationships(modelBuilder);
        }

        private void DefineCustomerConfiguration(ModelBuilder modelBuilder)
        {
            // common structure and rules
            modelBuilder.Entity<Company>().ToTable(DbConstants.Domain.EntityNames.CompanyEntityName)
                .HasKey(c => c.Id);

            modelBuilder.Entity<Company>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Company>().Property(c => c.BrandName)
                .HasMaxLength(DbConstants.CommonSettings.ShortStringLength)
                .IsRequired();

            modelBuilder.Entity<Company>().Property(c => c.CeoName)
                .HasMaxLength(DbConstants.CommonSettings.MediumStringLength);

            modelBuilder.Entity<Company>().Property(c => c.Email)
                .HasMaxLength(DbConstants.CommonSettings.EmailAddressLength);

            modelBuilder.Entity<Company>().Property(c => c.WebSite)
                .HasMaxLength(DbConstants.CommonSettings.LongStringLength);

            modelBuilder.Entity<Company>().Property(c => c.Revenue)
                .HasPrecision(15, 2);

            // indexes
            modelBuilder.Entity<Company>()
                .HasIndex(c => c.BrandName)
                .IsUnique()
                .HasDatabaseName("IX_Company_BrandName");

            modelBuilder.Entity<Company>()
                .HasIndex(c => c.Status)
                .HasDatabaseName("IX_Company_Status");

            // constraints
            modelBuilder.Entity<Company>()
                .HasIndex(c => c.Email)
                .IsUnique()
                .HasDatabaseName("IX_UX_Company_Email");
        }

        private void DefineOfficeConfiguration(ModelBuilder modelBuilder)
        {
            // common structure and rules
            modelBuilder.Entity<CompanyOffice>().ToTable(DbConstants.Domain.EntityNames.CompanyOfficeEntityName)
                .HasKey(c => c.Id);

            modelBuilder.Entity<CompanyOffice>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CompanyOffice>().Property(c => c.Name)
                .HasMaxLength(DbConstants.CommonSettings.MediumStringLength)
                .IsRequired();

            modelBuilder.Entity<CompanyOffice>().Property(c => c.OfficeCode)
                .HasMaxLength(DbConstants.CommonSettings.ShortStringLength)
                .IsRequired();

            modelBuilder.Entity<CompanyOffice>().Property(c => c.ZipCode)
                .HasMaxLength(DbConstants.CommonSettings.ExtraShortLength)
                .IsRequired();

            // indexes

            // constraints
            modelBuilder.Entity<CompanyOffice>()
                .HasIndex(c => c.OfficeCode)
                .IsUnique()
                .HasDatabaseName("IX_UX_CO_Code");
        }

        private void DefineUserConfiguration(ModelBuilder modelBuilder)
        {
            // common structure and rules
            modelBuilder.Entity<User>().ToTable(DbConstants.Domain.EntityNames.UserEntityName)
                .HasKey(c => c.Id);

            modelBuilder.Entity<User>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>().Property(c => c.Login)
                .HasMaxLength(DbConstants.Domain.UserSettings.LoginLength)
                .IsRequired();

            modelBuilder.Entity<User>().Property(c => c.Title)
                .HasMaxLength(DbConstants.CommonSettings.ExtraShortLength);

            modelBuilder.Entity<User>().Property(c => c.FirstName)
                .HasMaxLength(DbConstants.CommonSettings.ShortStringLength);

            modelBuilder.Entity<User>().Property(c => c.LastName)
                .HasMaxLength(DbConstants.CommonSettings.ShortStringLength);

            modelBuilder.Entity<Company>().Property(c => c.Email)
                .HasMaxLength(DbConstants.CommonSettings.EmailAddressLength);

            modelBuilder.Entity<User>().Property(c => c.PasswordHash)
                .HasMaxLength(DbConstants.Domain.UserSettings.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<User>().Property(c => c.PasswordSalt)
                .HasMaxLength(DbConstants.Domain.UserSettings.PasswordSalt)
                .IsRequired();

            modelBuilder.Entity<User>().Property(c => c.DateOfBirth)
                .HasColumnType(DbConstants.CommonSettings.DateTimeDateOnlyFormat);

            // indexes

            // constraints
            modelBuilder.Entity<User>()
                .HasIndex(c => c.Login)
                .IsUnique()
                .HasDatabaseName("IX_UX_User_Login");
        }

        private void DefineProjectConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().ToTable(DbConstants.Domain.EntityNames.ProjectEntityName)
                .HasKey(c => c.Id);

            modelBuilder.Entity<Project>().Property(c => c.ProjectCode)
                .HasMaxLength(DbConstants.CommonSettings.ShortStringLength)
                .IsRequired();

            modelBuilder.Entity<Project>().Property(c => c.Name)
                .HasMaxLength(DbConstants.CommonSettings.LongStringLength)
                .IsRequired();

            modelBuilder.Entity<Project>().Property(c => c.Description)
                .HasMaxLength(DbConstants.CommonSettings.ExtraLongStringLength);

            modelBuilder.Entity<Project>().Property(c => c.ProjectBudget)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Project>().Property(c => c.StartDate)
                .HasColumnType(DbConstants.CommonSettings.DateTimeSecOnlyAccuracyFormat)
                .IsRequired();

            modelBuilder.Entity<Project>().Property(c => c.EndDate)
                .HasColumnType(DbConstants.CommonSettings.DateTimeSecOnlyAccuracyFormat);
        }

        private void DefineProjectUserConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectUser>().ToTable(DbConstants.Domain.EntityNames.ProjectUserEntityName);

            modelBuilder.Entity<ProjectUser>().HasKey(pu => new { pu.ProjectId, pu.UserId });

            modelBuilder.Entity<ProjectUser>().Property(c => c.StartDate)
                .HasColumnType(DbConstants.CommonSettings.DateTimeSecOnlyAccuracyFormat)
                .IsRequired();

            modelBuilder.Entity<ProjectUser>().Property(c => c.EndDate)
                .HasColumnType(DbConstants.CommonSettings.DateTimeSecOnlyAccuracyFormat);

            modelBuilder.Entity<ProjectUser>().Property(c => c.PositionDescription)
                .HasMaxLength(DbConstants.CommonSettings.ExtraLongStringLength);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Offices)
                .WithOne(o => o.Company)
                .HasForeignKey(o => o.CompanyId);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Users)
                .WithOne(o => o.Company)
                .HasForeignKey(o => o.CompanyId)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Projects)
                .WithOne(o => o.Company)
                .HasForeignKey(o => o.CompanyId);

            modelBuilder.Entity<CompanyOffice>()
                .HasMany(c => c.Users)
                .WithOne(o => o.PrimaryOffice)
                .HasForeignKey(o => o.PrimaryOfficeId);

            modelBuilder.Entity<CompanyOffice>()
                .HasMany(c => c.Projects)
                .WithOne(o => o.ResponsibleOffice)
                .HasForeignKey(o => o.ResponsibleOfficeId);

            modelBuilder.Entity<User>()
                .HasMany(c => c.Projects)
                .WithOne(o => o.ProjectOwner)
                .HasForeignKey(o => o.ProjectOwnerId);

            modelBuilder.Entity<ProjectUser>().HasOne(pu => pu.Project)
                .WithMany(p => p.ProjectUsers)
                .HasForeignKey(pu => pu.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);  

            modelBuilder.Entity<ProjectUser>().HasOne(pu => pu.User)
                .WithMany(u => u.ProjectUsers)
                .HasForeignKey(pu => pu.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        protected virtual void GenerateDictionaryData(ModelBuilder modelBuilder)
        {
            // todo : add dictionaries and other common settings here
        }
    }
}
