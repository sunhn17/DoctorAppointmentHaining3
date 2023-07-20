using DoctorAppointmentHaining.API.Security;
using DoctorAppointmentHaining.Application.UseCases;
using DoctorAppointmentHaining.Domain.Contracts;
using DoctorAppointmentHaining.Infrastructure.Database;
using DoctorAppointmentHaining.Infrastructure.Repositories;
using Microsoft.AspNetCore.HttpLogging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services);
});

builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.All;
});

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtOptions.SectionName));
builder.Services.AddSlotAppointmentAuthentication(builder.Configuration);
builder.Services.AddTransient<JwtCreator>();

builder.Services.AddSlotDb(builder.Configuration);
builder.Services.AddTransient<IDoctorRepository, DoctorSlotRepo>();
builder.Services.AddTransient<CreatDoctorSlot>();
builder.Services.AddTransient<IPatientRepository, PatientAppointRepo>();
builder.Services.AddTransient<CreatPatientAppoint>();

builder.Services.AddControllers();





var app = builder.Build();

app.UseHttpLogging();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
