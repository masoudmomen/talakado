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
using Talakado.Application.Catalogs.CatalogItems.GetCatalogItemPDP;
using Talakado.Application.BasketsService;
using Talakado.Application.Users;
using Talakado.AdminPanel.MappingProfiles;
using Talakado.Application.UriComposer;
using Talakado.Application.Orders;
using Talakado.Application.Payments;
using Talakado.Application.Discounts;
using Talakado.Application.Catalogs.CatalogItems.CatalogItemServices;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddSignalR();

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

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


#region Mapper
builder.Services.AddAutoMapper(typeof(CatalogMappingProfile)); //Mapper
builder.Services.AddAutoMapper(typeof(UserMappingProfile)); //Mapper
builder.Services.AddAutoMapper(typeof(UserVMMappingProfile)); //Mapper
#endregion


#region IOC

builder.Services.AddTransient<IDataBaseContext, DataBaseContext>();
builder.Services.AddTransient<IIdentityDataBaseContext, IdentityDataBaseContext>();
builder.Services.AddTransient<IOnlineVisitorService, OnlineVisitorService>();
builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
builder.Services.AddTransient<ISaveVisitorInfoService, SaveVisitorInfoService>();
builder.Services.AddTransient<IGetMenuItemService, GetMenuItemService>();
builder.Services.AddTransient<IUriComposerService, UriComposerService>();
builder.Services.AddTransient<IGetCatalogItemPLPService, GetCatalogItemPLPService>();
builder.Services.AddTransient<IGetCatalogItemPDPService, GetCatalogItemPDPService>();
builder.Services.AddTransient<IBasketService, BasketService>();
builder.Services.AddTransient<IUserAddressService, UserAddressService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IPaymentService, PaymentService>();
builder.Services.AddTransient<IDiscountService, DiscountService>();
builder.Services.AddTransient<IDiscountHistoryService, DiscountHistoryService>();
builder.Services.AddTransient<ICatalogItemService, CatalogItemService>();


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
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(

    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.MapRazorPages();
app.MapHub<OnlineVisitorHub>("/VisitorHub");

app.Run();
