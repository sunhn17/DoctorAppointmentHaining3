using DoctorAppointmentHaining.Controllers.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace DoctorAppointmentHaining.Database
{
    public class TimeAppointDb : DbContext
    {
        public DbSet<DoctorTimeSlot> Products { get; set; }

        public TimeAppointDb(DbContextOptions<TimeAppointDb> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("database_for_appointment");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }

    public static class DbExtension
    {
        public static IServiceCollection AddPlayGroundDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TimeAppointDb>(options =>
            {
                // options.UseNpgsql(configuration.GetConnectionString("Postgres"));
                options.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = database_for_appointment");
            });
            return services;
        }
    }
}
