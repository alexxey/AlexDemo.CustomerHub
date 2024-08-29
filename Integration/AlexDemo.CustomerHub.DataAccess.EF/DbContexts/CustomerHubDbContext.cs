using AlexDemo.CustomerHub.Core.Constraints;
using AlexDemo.CustomerHub.Core.Entities;
using AlexDemo.CustomerHub.Core.Entities.Customer;
using AlexDemo.CustomerHub.Core.Entities.Portfolio;
using AlexDemo.CustomerHub.DataAccess.EF.Configurations;
using AlexDemo.CustomerHub.DataAccess.EF.Extensions;

using Microsoft.EntityFrameworkCore;

namespace AlexDemo.CustomerHub.DataAccess.EF.DbContexts
{
    public class CustomerHubDbContext(
        DbContextOptions<CustomerHubDbContext> options)
        : DbContext(options)
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyOffice> CompanyOffices { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerHubDbContext).Assembly);

            modelBuilder.HasDefaultSchema(DbConstants.Domain.DefaultSchemaName);

            // common configurations
            modelBuilder.ConfigureRowVersion();

            DefineCustomerConfiguration(modelBuilder);

            DefineProfileConfiguration(modelBuilder);

            ConfigureRelationships(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            // setup common Log properties
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.UpdatedOn = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    // todo alex: add here additional logic if/when needed
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        #region Customer Configuration
        private void DefineCustomerConfiguration(ModelBuilder modelBuilder)
        {
            DefineCompanyConfiguration(modelBuilder);

            DefineOfficeConfiguration(modelBuilder);

            DefineUserConfiguration(modelBuilder);
        }

        private void DefineCompanyConfiguration(ModelBuilder modelBuilder)
        {
            // common structure and rules
            modelBuilder.Entity<Company>().ToTable(DbConstants.Domain.EntityNames.CompanyEntityName)
                .HasKey(c => c.Id);

            modelBuilder.Entity<Company>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Company>().Property(c => c.BrandName)
                .HasMaxLength(EntityConstraints.Domain.CompanySettings.BrandNameLength)
                .IsRequired();

            modelBuilder.Entity<Company>().Property(c => c.CeoName)
                .HasMaxLength(EntityConstraints.CommonSettings.MediumStringLength);

            modelBuilder.Entity<Company>().Property(c => c.Email)
                .HasMaxLength(EntityConstraints.CommonSettings.EmailAddressLength);

            modelBuilder.Entity<Company>().Property(c => c.WebSite)
                .HasMaxLength(EntityConstraints.CommonSettings.LongStringLength);

            modelBuilder.Entity<Company>().Property(c => c.AnnualRevenue)
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
                .HasMaxLength(EntityConstraints.CommonSettings.MediumStringLength)
                .IsRequired();

            modelBuilder.Entity<CompanyOffice>().Property(c => c.OfficeCode)
                .HasMaxLength(EntityConstraints.CommonSettings.ShortStringLength)
                .IsRequired();

            modelBuilder.Entity<CompanyOffice>().Property(c => c.ZipCode)
                .HasMaxLength(EntityConstraints.CommonSettings.ExtraShortStringLength)
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
                .HasMaxLength(EntityConstraints.Domain.UserSettings.LoginLength)
                .IsRequired();

            modelBuilder.Entity<User>().Property(c => c.Title)
                .HasMaxLength(EntityConstraints.CommonSettings.ExtraShortStringLength);

            modelBuilder.Entity<User>().Property(c => c.FirstName)
                .HasMaxLength(EntityConstraints.CommonSettings.ShortStringLength);

            modelBuilder.Entity<User>().Property(c => c.LastName)
                .HasMaxLength(EntityConstraints.CommonSettings.ShortStringLength);

            modelBuilder.Entity<Company>().Property(c => c.Email)
                .HasMaxLength(EntityConstraints.CommonSettings.EmailAddressLength);

            modelBuilder.Entity<User>().Property(c => c.PasswordHash)
                .HasMaxLength(EntityConstraints.Domain.UserSettings.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<User>().Property(c => c.PasswordSalt)
                .HasMaxLength(EntityConstraints.Domain.UserSettings.PasswordSalt)
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
        #endregion

        #region Profile Configuration
        private void DefineProfileConfiguration(ModelBuilder modelBuilder)
        {
            DefineProjectConfiguration(modelBuilder);

            DefineProjectUserConfiguration(modelBuilder);
        }

        private void DefineProjectConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().ToTable(DbConstants.Domain.EntityNames.ProjectEntityName)
                .HasKey(c => c.Id);

            modelBuilder.Entity<Project>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Project>().Property(c => c.ProjectCode)
                .HasMaxLength(EntityConstraints.CommonSettings.ShortStringLength)
                .IsRequired();

            modelBuilder.Entity<Project>().Property(c => c.Name)
                .HasMaxLength(EntityConstraints.CommonSettings.LongStringLength)
                .IsRequired();

            modelBuilder.Entity<Project>().Property(c => c.Description)
                .HasMaxLength(EntityConstraints.CommonSettings.ExtraLongStringLength);

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
            modelBuilder.Entity<ProjectUser>().ToTable(DbConstants.Domain.EntityNames.ProjectUserEntityName)
                .HasKey(c => c.Id);

            // in case we need composite key : modelBuilder.Entity<ProjectUser>().HasKey(pu => new { pu.ProjectId, pu.UserId });

            modelBuilder.Entity<ProjectUser>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ProjectUser>().Property(c => c.StartDate)
                .HasColumnType(DbConstants.CommonSettings.DateTimeSecOnlyAccuracyFormat)
                .IsRequired();

            modelBuilder.Entity<ProjectUser>().Property(c => c.EndDate)
                .HasColumnType(DbConstants.CommonSettings.DateTimeSecOnlyAccuracyFormat);

            modelBuilder.Entity<ProjectUser>().Property(c => c.PositionDescription)
                .HasMaxLength(EntityConstraints.CommonSettings.ExtraLongStringLength);
        }
        #endregion

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
                .HasForeignKey(o => o.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

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
                .HasForeignKey(o => o.ProjectOwnerId)
                .OnDelete(DeleteBehavior.NoAction);

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
