using ECommerce.Application.Concrete;
using ECommerce.DataAccess.Abstract;
using ECommerce.Application.Abstract;
using ECommerce.DataAccess.Concrete.EFEntityFramework;
using ECommerce.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using ECommerce.DataAccess.Abstact;
using ECommerce.DataAccess.Concerete.EFEntityFramework;
using ECommerce.WebUI.Services;
using ECommerce.WebUI.Entities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSession();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<ICartSessionService, CartSessionService>();
builder.Services.AddScoped<ICategoryDal, EFCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IProductDal, EFProductDal>();
builder.Services.AddScoped<IProductService, ProductService>();

#region Database registration

var conn = builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddDbContext<NortWindDbContext>(opt =>
//{
//    opt.UseSqlServer(conn);
//});

builder.Services.AddDbContext<CustomIdentityDbContext>(opt =>
{
    opt.UseSqlServer(conn);
});


#endregion
builder.Services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
    .AddEntityFrameworkStores<CustomIdentityDbContext>()
    .AddDefaultTokenProviders();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Register}/{id?}");

app.Run();
