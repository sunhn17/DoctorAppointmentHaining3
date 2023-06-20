using DoctorAppointmentHaining.Database;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddPlayGroundDb(builder.Configuration);
var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();
app.Run();
