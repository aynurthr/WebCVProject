using WebCV.Application;
using Microsoft.EntityFrameworkCore;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Bigon.Presentation;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebCV.Application.Services.Identity;
using WebCV.Infrastructure.Abstracts;
using WebCV.Application.Services.File;

namespace WebCV.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DbContext>(cfg =>
            {
                cfg.UseSqlServer(builder.Configuration.GetConnectionString("cString"));
            });

            builder.Services.AddControllersWithViews();

            builder.Services.AddRouting(cfg => cfg.LowercaseUrls = true);

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<IApplicationReference>());

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(cfg => cfg.RegisterModule<WebCVDIModule>()));

            builder.Services.AddScoped<IIdentityService, FakeIdentityService>();
            builder.Services.AddSingleton<IFileService, FileService>();
            builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
