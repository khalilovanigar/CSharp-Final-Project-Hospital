using DoctorsNamespace;

namespace ApplicationNamespace
{
    public enum ApplicationStatus
    {
        Pending,
        Accepted,
        Rejected
    }

    public class Application
    {
        public Doctor Doctor { get; set; }
        public ApplicationStatus Status { get; set; }

        public Application(Doctor doctor)
        {
            Doctor = doctor;
            Status = ApplicationStatus.Pending;
        }
    }
}
