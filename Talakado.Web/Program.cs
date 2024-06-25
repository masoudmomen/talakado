using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Talakado.Persistence.Contexts;
using Talakado.Infrastructure.IdentityConfigs;
using Talakado.Web.Hubs;
using Talakado.Application.Visitors.OnlineVisitors;
using Talakado.Application.Contexts;
using Talakado.Persistence.Contexts.MongoContext;
using Talakado.Application.Visitors.SaveVisitorInfo;
using Talakado.Web.Utilities.Filters;
using Talakado.Web.Utilities.Middleware;
using Talakado.Application.Catalogs.GetMenuItems;
using AutoMapper;
using Talakado.Infrastructure.MappingProfile;
using Talakado.Application.Catalogs.CatalogItems.AddNewCatalogItem;
using Talakado.Application.Catalogs.CatalogItems.GetCatalogItemPLP;
using Talakado.Application.Catalogs.CatalogItems.UriComposer;
using Talakado.Application.Catalogs.CatalogItems.GetCatalogItemPDP;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddSignalR();

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Connection String
var connection = builder.Configuration["ConnectionString:sqlServer"];
builder.Services.AddDbContext<DataBaseContext>(option=>option.UseSqlServer(connection));
builder.Services.AddIdentityService(builder.Configuration);
#endregion

builder.Services.AddAuthorization();
builder.Services.ConfigureApplicationCookie(option =>
{
    option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    option.LoginPath = "/account/login";
    option.AccessDeniedPath = "/Account/AccessDenied";
    option.SlidingExpiration = true;
});

#region IOC
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddAutoMapper(typeof(CatalogMappingProfile)); //Mapper
builder.Services.AddTransient<IOnlineVisitorService, OnlineVisitorService>();
builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
builder.Services.AddTransient<ISaveVisitorInfoService, SaveVisitorInfoService>();
builder.Services.AddTransient<IGetMenuItemService, GetMenuItemService>();
builder.Services.AddTransient<IUriComposerService, UriComposerService>();
builder.Services.AddTransient<IGetCatalogItemPLPService, GetCatalogItemPLPService>();
builder.Services.AddTransient<IGetCatalogItemPDPService, GetCatalogItemPDPService>();

builder.Services.AddScoped<SaveVisitorFilter>();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSetVisitorId();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.MapRazorPages();
app.MapHub<OnlineVisitorHub>("/VisitorHub");

app.Run();
