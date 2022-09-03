global using CRUDApplication.Shared;
global using Microsoft.EntityFrameworkCore;
using CRUDApplication.Server.Data;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<DataContext>(options =>
{
    var pgUserId = Environment.GetEnvironmentVariable("POSTGRES_USER_ID");
    var pgPassword = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
    var pgHost = Environment.GetEnvironmentVariable("POSTGRES_HOST");
    var pgPort = Environment.GetEnvironmentVariable("POSTGRES_PORT");
    var pgDatabase = Environment.GetEnvironmentVariable("POSTGRES_DB");

    /*var pgUserId = "noxxnfnoikpdbp";
    var pgPassword = "19335c476b9dd6aad340496df36d0ba7e6dcffb1b99991e60a5e007b96c17a71";
    var pgHost = "ec2-35-170-21-76.compute-1.amazonaws.com";
    var pgPort = "5432";
    var pgDatabase = "d1ujltko3uuu3b";*/

    var connStr = $"Server={pgHost};Port={pgPort};User Id={pgUserId};Password={pgPassword};Database={pgDatabase}";

    options.UseNpgsql(connStr);
});

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
