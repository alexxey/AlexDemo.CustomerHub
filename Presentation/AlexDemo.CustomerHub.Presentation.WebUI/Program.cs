using System.Globalization;
using System.Reflection;
using AlexDemo.CustomerHub.Presentation.WebUI.Contracts;
using AlexDemo.CustomerHub.Presentation.WebUI.Contracts.Customer;
using AlexDemo.CustomerHub.Presentation.WebUI.Data;
using AlexDemo.CustomerHub.Presentation.WebUI.Services;
using AlexDemo.CustomerHub.Presentation.WebUI.Services.Base;
using AlexDemo.CustomerHub.Presentation.WebUI.Services.Customer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

namespace AlexDemo.CustomerHub.Presentation.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // localization
            var supportedCultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("uk"),
                new CultureInfo("sv")
            };
            builder.Services.AddLocalization(options => options.ResourcesPath = "Localization");
            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.FallBackToParentCultures = true;
                options.FallBackToParentUICultures = true;
            });

            builder.Services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            ConfigureServices(builder.Services);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // localization options:
            var requestLocalizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            var routeRequestProvider = new RouteDataRequestCultureProvider();
            requestLocalizationOptions.RequestCultureProviders.Insert(0, routeRequestProvider);

            app.UseRequestLocalization(requestLocalizationOptions);

            app.MapControllerRoute(
                name: "default",
                pattern: "{culture=en}/{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("https://localhost:44309"));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ICompanyService, CompanyService>();

            // for local storage we expect to have only single instance of the local storage
            services.AddSingleton<ILocalStorageService, LocalStorageService>();
        }
    }
}
