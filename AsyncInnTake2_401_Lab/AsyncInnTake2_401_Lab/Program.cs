using Microsoft.EntityFrameworkCore;
using AsyncInnTake2_401_Lab;
using AsyncInnTake2_401_Lab.Data;
using AsyncInnTake2_401_Lab.Models.Interfaces;
using AsyncInnTake2_401_Lab.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IHotel, HotelService>();
builder.Services.AddTransient<IAmenity, AmenityService>();
builder.Services.AddTransient<IRoom, RoomService>();

//ADDED HERE
builder.Services.AddDbContext<AsyncInnDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("AzureConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
