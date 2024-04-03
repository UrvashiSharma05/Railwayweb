using Microsoft.EntityFrameworkCore;
using Railwayweb.Models.RailwayDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
//builder.Services.AddDbContext<StudentDBContext>(options => options.UseNpgsql(config.GetConnectionString("dbcs") ?? throw new InvalidOperationException("Connection string 'StudentDBContext'not found")));
builder.Services.AddDbContext<RailwayDbContext>(options => options.UseNpgsql(config.GetConnectionString("dbcs") ?? throw new InvalidOperationException("Connection string 'StudentDBContext'not found")));

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
    pattern: "{controller=Railway}/{action=HomePage}/{id?}");

app.Run();
