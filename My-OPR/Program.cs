using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using My_OPR.Data;
using My_OPR.Repositories.Data;
using My_OPR.Repositories.Data.Zoom;
using System.Text;
using My_OPR.Controllers;
using My_OPR.Lib;
using Microsoft.Extensions.FileProviders;
using My_OPR.Models.Master;
using My_OPR.Repositories.Data.DokumenIso;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
IConfiguration configuration = builder.Configuration;
MyConstants.rootPath = Directory.GetCurrentDirectory();
builder.Services.AddDirectoryBrowser();
builder.Services.AddControllers().AddNewtonsoftJson(
    x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Addscoped
var services = builder.Services;
services.AddScoped<CategoryRepository>();
services.AddScoped<ContentRepository>();
services.AddScoped<EventRepository>();
services.AddScoped<GroupRepository>();
services.AddScoped<ListAppRepository>();
services.AddScoped<PositionRepository>();
services.AddScoped<SliderRepository>();
services.AddScoped<AccountRepository>();
services.AddScoped<EmployeeRepository>();
services.AddScoped<LocationRepository>();
services.AddScoped<ServiceRepository>();

//ZoomBy
services.AddScoped<ZoomStatusRepository>();
services.AddScoped<ZoomSchedulerRepository>();
services.AddScoped<ZoomRepository>();

#endregion
#region 
// services.AddScoped<RegisteredFormRepository>();
services.AddScoped<RegisterFormIsoRepository>();
services.AddScoped<ISOCoreRepository>();
services.AddScoped<HistoryIsoRepository>();
services.AddScoped<ISOSupportRepository>();
services.AddScoped<DocumentISORepository>();
#endregion

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidIssuer = configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
     {
         builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
     });
});


builder.Services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("MyOPR")));

// builder.Services.AddIdentityCore<Account>().AddEntityFrameworkStores<ApplicationDBContext>();


var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseCors();
var fileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "public"));
// app.UseDirectoryBrowser(new DirectoryBrowserOptions
// {
//     FileProvider = fileProvider,
//     RequestPath = "/public"
// });
//app.UseHttpsRedirection();
// Console.WriteLine("Path ====" + Path.Combine(builder.Environment.ContentRootPath, "public"));
app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "public")),
    RequestPath = "/public",
    EnableDirectoryBrowsing = false
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
