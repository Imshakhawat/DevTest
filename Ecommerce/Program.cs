using Autofac;
using Autofac.Extensions.DependencyInjection;
using Ecom.Application;
using Ecom.Infrastructure;
using Ecom.Persistance;
using Ecommerce;
using Ecommerce.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


//serilog configuration
builder.Host.UseSerilog( (ctx,lc)=> lc.MinimumLevel.Debug()
                                  .MinimumLevel.Override("Microsoft",LogEventLevel.Warning)
                                  .Enrich.FromLogContext()
                                  .ReadFrom.Configuration(builder.Configuration));


try
{


    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    var migrationAssembly = Assembly.GetExecutingAssembly().GetName().FullName;

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new ApplicationModule());
        containerBuilder.RegisterModule(new InfrastructureModule());
        containerBuilder.RegisterModule(new PersistanceModule(connectionString,
            migrationAssembly));
        containerBuilder.RegisterModule(new WebModule());
    });



    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();
    builder.Services.AddControllersWithViews();

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

    app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();

    Log.Information("App starting");

    app.Run();

}

catch (Exception ex)
{
    Log.Fatal("failed to start application");
}
finally
{
    Log.CloseAndFlush();
}