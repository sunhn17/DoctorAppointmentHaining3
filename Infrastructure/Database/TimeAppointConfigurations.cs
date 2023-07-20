using DoctorAppointmentHaining.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorAppointmentHaining.Infrastructure.Database
{
    public class TimeAppointConfigurations : IEntityTypeConfiguration<DoctorTimeSlot>
    {
        public void Configure(EntityTypeBuilder<DoctorTimeSlot> builder)
        {
            builder.ToTable("TimeSlots");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnName("SlotID");

        }
    }
}
