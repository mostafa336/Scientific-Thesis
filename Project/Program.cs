using Thesis.Models;
using Thesis.Repository;
using Thesis.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ScienteficThesisDbContext>();
builder.Services.AddTransient<IDegreeService,DegreeService>();
builder.Services.AddTransient<IDegreeRepository, DegreeRepository>();
builder.Services.AddTransient<ICountryRepository, CountryRepository>();
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<IApplicationService, ApplicationService>();
builder.Services.AddTransient<IApplicationRepository, ApplicationRepository>();
builder.Services.AddTransient<IUniversityService, UniversityService>();
builder.Services.AddTransient<IUniversityRepository, UniversityRepository>();


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

app.Run();
