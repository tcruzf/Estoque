using ControllRR.Application.Interfaces;
using ControllRR.Application.Services;
using ControllRR.Domain.Interfaces;
using ControllRR.Infrastructure.Data.Context;
using ControllRR.Infrastructure.Repositories;
using ControllRR.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ControllRR.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.HttpOverrides;
using System.Security.Claims;
using ControllRR.Application.Profiles;
using System.Text.Json;
var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                              ForwardedHeaders.XForwardedProto |
                              ForwardedHeaders.XForwardedHost;

    // Limpar redes/proxies conhecidos para aceitar de qualquer origem
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 449;
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
/*   
// Adicionar o DbContext com MySQL
builder.Services.AddEntityFrameworkMySQL()
   .AddDbContext<ControllRRContext>(options =>
   {
       options.UseMySQL(builder.Configuration.GetConnectionString("ControlContext"));
   });
*/
builder.Services.AddControllersWithViews()
   .AddJsonOptions(options => 
       options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);
    

builder.Services.AddDbContext<ControllRRContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("ControlContext");
    var serverVersion = ServerVersion.AutoDetect(connectionString);
    options.UseMySql(connectionString, serverVersion);
}, ServiceLifetime.Scoped);

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.ClaimsIdentity.RoleClaimType = ClaimTypes.Role;
    options.Stores.MaxLengthForKeys = 128;
})
.AddEntityFrameworkStores<ControllRRContext>()
.AddDefaultTokenProviders()
.AddDefaultUI();

// Configurar cookies de autenticação
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
});


// Configurar AutoMapper
builder.Services.AddAutoMapper(
    typeof(MaintenanceMappingProfile),
    typeof(DeviceMappingProfile),
    typeof(SectorMappingProfile),
    typeof(DocumentMappingProfile),
    typeof(ApplicationUserMappingProfile),
    typeof(StockMappingProfile),
    typeof(StockManagementMappingProfile),
    typeof(MaintenanceProductProfile),
    typeof(SupplierMappingProfile),
    typeof(PurchaseOrderMappingProfile),
    typeof(CustomerMappingProfile),
    typeof(ContactInfoMapping),
    typeof(BusinessCompanyMapping),
     typeof(SysProfilesMapping)
    
    //typeof()
);
 


//builder.Services.AddAutoMapper(typeof(UserMappingProfile));
builder.Services.AddScoped<SignInManager<ApplicationUser>>();
builder.Services.AddScoped<ISystemRoutines, SystemRoutines>();
builder.Services.AddScoped<ISystemRoutinesRepository, SystemRoutinesRepository>();
builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMaintenanceService, MaintenanceService>();
builder.Services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<IFileStorageService, FileStorageService>();
builder.Services.AddScoped<ISectorService, SectorService>();
builder.Services.AddScoped<ISectorRepository, SectorRepository>();
builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();
builder.Services.AddScoped<IStockManagementService, StockManagementService>();
builder.Services.AddScoped<IStockManagementRepository, StockManagementRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IMaintenanceNumberControlRepository, MaintenanceNumberControlRepository>();
builder.Services.AddScoped<IPurchaseItemRepository, PurchaseItemRepository>();
builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
builder.Services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
builder.Services.AddScoped<IPurchaseItemService, PurchaseItemService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CusomerService>();
builder.Services.AddScoped<IBusinessCompanyRepository, BusinessCompanyRepository>();
builder.Services.AddScoped<IBusinessCompanyService, BusinessCompanyService>();
builder.Services.AddScoped<ISysProfilesRepository, SysProfilesRepository>();
builder.Services.AddScoped<ISysProfilesService, SysProfilesService>();
// Adicionar suporte ao MVC e Razor Pages
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseForwardedHeaders();// alteração
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        //await SeedingService.Initialize(services);
        await AdminSeed.InitializeAsync(services);
        //await SeedUser.InitializeAsync(services);
        System.Console.WriteLine("Try bloco");
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Erro ao executar seeds");
    }

}

var configuration = new MapperConfiguration(cfg =>
    cfg.AddProfile<StockMappingProfile>());
configuration.AssertConfigurationIsValid(); // Vai lançar exceção se houver erros

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});
app.Run();