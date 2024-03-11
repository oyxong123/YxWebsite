using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using YxWebsite.Context;
using MudBlazor.Services;
using Radzen;
using YxWebsite.Services;
using YxWebsite.Interfaces;
using AutoMapper;
using YxWebsite.Dtos;
using Blazorise;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
.AddHubOptions(options =>
 {
     options.ClientTimeoutInterval = TimeSpan.FromSeconds(400);  // Increase time before blazor starts to say connection lost.
     options.KeepAliveInterval = TimeSpan.FromSeconds(200);
 });

// Add service to the container for connection to the database.
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add MudBlazor component services to web app.
builder.Services.AddMudServices();

// Add AutoMapper service to web app.
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add Radzen component services to web app.
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

// Add interface services to web app.
builder.Services.AddScoped<ILcService, LcService>();
builder.Services.AddScoped<ILcCategoryService, LcCategoryService>();
builder.Services.AddScoped<IAuditTrailsService, AuditTrailsService>();
builder.Services.AddScoped<ILoginService, LoginService>();

// Set the limit of image size to 50Mb
builder.Services.AddServerSideBlazor()
    .AddHubOptions(options =>
    {
        options.MaximumReceiveMessageSize = 1024 * 1024 * 50;
    });

// Add Blazorize service to web app.
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    });

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
