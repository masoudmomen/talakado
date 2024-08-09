using Microsoft.EntityFrameworkCore;
using Talakado.Persistence.Contexts;
using Talakado.Infrastructure.IdentityConfigs;
using Talakado.Application.Visitors.GetDailyReports;
using Talakado.Application.Contexts;
using Talakado.Persistence.Contexts.MongoContext;
using Talakado.Application.Visitors.OnlineVisitors;
using Talakado.Infrastructure.MappingProfile;
using Talakado.Application.Catalogs.CatalogTypes;
using Talakado.AdminPanel.MappingProfiles;
using Talakado.Application.Catalogs.CatalogItems.AddNewCatalogItem;
using Talakado.Application.Catalogs.CatalogItems.CatalogItemServices;
using FluentValidation;
using Talakado.Infrastructure.ExternalApi.ImageServer;
using Talakado.Application.Discounts.AddNewDiscountService;
using Talakado.Application.Discounts;
using Talakado.Application.UriComposer;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container.(IOC)
builder.Services.AddRazorPages().AddNewtonsoftJson(optiion =>
optiion.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddControllers();

builder.Services.AddScoped<IGetDailyReportService, GetDailyReportService>();
builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
builder.Services.AddTransient<IOnlineVisitorService, OnlineVisitorService>();

builder.Services.AddAutoMapper(typeof(CatalogMappingProfile)); //Mapper
builder.Services.AddAutoMapper(typeof(CatalogVMMappingProfile));

builder.Services.AddTransient<ICatalogTypeService, CatalogTypeService>();
builder.Services.AddTransient<IAddNewCatalogItemService, AddNewCatalogItemService>();
builder.Services.AddTransient<ICatalogItemService, CatalogItemService>();
builder.Services.AddTransient<IValidator<AddNewCatalogItemDto>, AddNewCatalogItemDtoValidator>(); // FluentValidator
builder.Services.AddTransient<IImageUploadService, ImageUploadService>();
builder.Services.AddTransient<IAddNewDiscountService, AddNewDiscountService>();
builder.Services.AddTransient<IDiscountService, DiscountService>();
builder.Services.AddTransient<IDiscountHistoryService, DiscountHistoryService>();
builder.Services.AddTransient<IUriComposerService, UriComposerService>();


#endregion

#region Connection String
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
var connection = builder.Configuration["ConnectionString:sqlServer"];
builder.Services.AddDbContext<DataBaseContext>(option =>
{
    option.UseSqlServer(connection);
    option.EnableSensitiveDataLogging();
});
builder.Services.AddIdentityService(builder.Configuration);
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.Run();
