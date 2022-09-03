global using CRUDApplication.Shared;
global using Microsoft.EntityFrameworkCore;
using CRUDApplication.Server.Data;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

string connectionString = null;
//string envVar = Environment.GetEnvironmentVariable("DATABASE_URL");
string envVar = "postgres://noxxnfnoikpdbp:19335c476b9dd6aad340496df36d0ba7e6dcffb1b99991e60a5e007b96c17a71@ec2-35-170-21-76.compute-1.amazonaws.com:5432/d1ujltko3uuu3b";

var uri = new Uri(envVar);
var username = uri.UserInfo.Split(':')[0];
var password = uri.UserInfo.Split(':')[1];
connectionString =
"; Database=" + uri.AbsolutePath.Substring(1) +
"; Username=" + username +
"; Password=" + password +
"; Port=" + uri.Port +
";";

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(connectionString)
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
