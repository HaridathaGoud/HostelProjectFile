using HostelProject.Modules.FeeDetails.FeeContext;
using HostelProject.Modules.FeeDetails.FeeService;
using HostelProject.Modules.Hostels.Context;
using HostelProject.Modules.Hostels.Services;
using HostelProject.Modules.Maintenance.MaintananceContext;
using HostelProject.Modules.Maintenance.MaintenanceServices;
using Microsoft.EntityFrameworkCore;
using ProjectApi.Modules.Context;
using ProjectApi.Modules.Services;
using Veda_Project_Sample.Context;
using Veda_Project_Sample.Services;
using vedaproject.Services;
using vedaproject.vedaproject.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<FeeContexts>(opts =>
opts.UseSqlServer("Data Source = 20.195.8.203; database=hmsdev; User ID = WertyXcsghtekn; MultipleActiveResultSets = true; Password = Qeet24564^&537Jbdu"));
builder.Services.AddScoped<FeeDIservice, FeeService>();

builder.Services.AddDbContext<AvailibilityContext>(opts =>
opts.UseSqlServer("Data Source = 20.195.8.203; database=hmsdev; User ID = WertyXcsghtekn; MultipleActiveResultSets = true; Password = Qeet24564^&537Jbdu"));
builder.Services.AddScoped<IAvailableService,AvailableService>();

builder.Services.AddDbContext<StaffContext>(opts =>
opts.UseSqlServer("Data Source = 20.195.8.203; database=hmsdev; User ID = WertyXcsghtekn; MultipleActiveResultSets = true; Password = Qeet24564^&537Jbdu"));
builder.Services.AddScoped<IStaffServices, StaffServices>();



builder.Services.AddDbContext<MaintanContext>(opts =>
opts.UseSqlServer("Data Source = 20.195.8.203; database=hmsdev; User ID = WertyXcsghtekn; MultipleActiveResultSets = true; Password = Qeet24564^&537Jbdu"));
builder.Services.AddScoped<MaintanIservices, MaintanServices>();

builder.Services.AddDbContext<HostelsContex>(opts =>
opts.UseSqlServer("Data Source = 20.195.8.203; database=hmsdev; User ID = WertyXcsghtekn; MultipleActiveResultSets = true; Password = Qeet24564^&537Jbdu"));
builder.Services.AddScoped<IHostelServices, HostelServices>();

builder.Services.AddDbContext<CitizenContext>(opts =>
opts.UseSqlServer("Data Source = 20.195.8.203; database=hmsdev; User ID = WertyXcsghtekn; MultipleActiveResultSets = true; Password = Qeet24564^&537Jbdu"));
builder.Services.AddScoped<ICitizenService, CitizenService>();

builder.Services.AddDbContext<FeeContexts>(opts =>
opts.UseSqlServer("Data Source = 20.195.8.203; database=hmsdev; User ID = WertyXcsghtekn; MultipleActiveResultSets = true; Password = Qeet24564^&537Jbdu"));
builder.Services.AddScoped<FeeDIservice, FeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
