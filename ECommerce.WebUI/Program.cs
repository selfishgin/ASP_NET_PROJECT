using ECommerce.Application.Concrete;
using ECommerce.DataAccess.Abstract;
using ECommerce.Application.Abstract;
using ECommerce.DataAccess.Concrete.EFEntityFramework;
using ECommerce.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSession();

builder.Services.AddScoped<ICategoryDal, EFCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

#region Database registration

var conn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<NortWindDbContext>(opt =>
{
    opt.UseSqlServer(conn);
});
#endregion


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
