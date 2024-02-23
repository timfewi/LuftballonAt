
using AutoMapper;
using LuftballonAt.Data;
using LuftballonAt.Domain.Repository.Contracts;
using LuftballonAt.Domain.Repository.Contracts.ProductInterfaces;
using LuftballonAt.Domain.Repository.Implementations;
using LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces;
using LuftballonAt.Domain.Services.Contracts.UtilityServiceInterfaces;
using LuftballonAt.Domain.Services.Implementations.ProductService;
using LuftballonAt.Domain.Services.Implementations.ProductsService;
using LuftballonAt.Domain.Services.Implementations.UtilityServices;
using LuftballonAt.Domain.Utilities.MappingProfiles;
using LuftballonAt.Web.Areas.Identity.Data;
using LuftballonAt.Web.Middlewares;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;


// Add Blazor Server
builder.Services.AddServerSideBlazor();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Razor Pages
builder.Services.AddRazorPages();



// Add DbContext

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add Identity
builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();



// Configure Serilog
var logger = Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("C:/LuftballonAt_Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();

// Add HttpClient
builder.Services.AddHttpClient();


// Add Auto Mapper
builder.Services.AddAutoMapper(typeof(ProductMapperProfile));
builder.Services.AddScoped<IMapper, Mapper>();
// Add Repositories
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

// Add Services

//Product Services
builder.Services.AddScoped(typeof(IProductService), typeof(ProductService));
builder.Services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
builder.Services.AddScoped(typeof(IProductColorService), typeof(ProductColorService));

// Utility Serives
builder.Services.AddScoped(typeof(IColorAnalysisService), typeof(ColorAnalysisService));



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

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.MapBlazorHub();


app.Run();
