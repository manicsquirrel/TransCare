using AutoMapper;
using System.Reflection;
using TransCare.Data;
using TransCare.Data.Extensions;
using TransCare.Services.Extensions;
using TransCare.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerServices();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapFallbackToFile("index.html");
app.Run();