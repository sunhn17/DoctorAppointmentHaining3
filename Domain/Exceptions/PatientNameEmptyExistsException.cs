namespace DoctorAppointmentHaining.Domain.Exceptions
{
    [Serializable]
    public class PatientNameEmptyExistsException : Exception
    {
        public PatientNameEmptyExistsException() : base("Patient name should not be null") { }
    }
}
