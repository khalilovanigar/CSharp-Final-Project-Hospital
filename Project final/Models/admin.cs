using System;
using System.Collections.Generic;
using DoctorsNamespace;
using ApplicationNamespace;

namespace AdminNamespace
{
    public class Admin
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Password { get; set; }

        public List<Application> PendingApplications = new List<Application>();

        public Admin(string name, string surname, string password)
        {
            Name = name;
            Surname = surname;
            Password = password;
        }

        public bool Login(string username, string password)
        {
            if (username == "admin" && password == "admin123")
            {
                Console.WriteLine("Welcome admin");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
                return false;
            }
        }

        public void AddDoctorApplication(Doctor doctor)
        {
            var app = new Application(doctor);
            PendingApplications.Add(app);
            Console.WriteLine($"Doctor {doctor.Name} {doctor.Surname} applied and is pending approval.");
        }

        public void AcceptDoctor(string name, string surname)
        {
            var app = PendingApplications.Find(a => a.Doctor.Name == name && a.Doctor.Surname == surname && a.Status == ApplicationStatus.Pending);
            if (app != null)
            {
                app.Status = ApplicationStatus.Accepted;
                Console.WriteLine($"{name} {surname} accepted.");
            }
            else
            {
                Console.WriteLine("This doctor not found on pending list");
            }
        }

        public void RejectDoctor(string name, string surname)
        {
            var app = PendingApplications.Find(a => a.Doctor.Name == name && a.Doctor.Surname == surname && a.Status == ApplicationStatus.Pending);
            if (app != null)
            {
                app.Status = ApplicationStatus.Rejected;
                Console.WriteLine($"{name} {surname} rejected.");
            }
            else
            {
                Console.WriteLine("This doctor not found on pending list");
            }
        }

        public void ShowPendingApplications()
        {
            Console.WriteLine("Pending Doctor Applications:");
            foreach (var app in PendingApplications)
            {
                if (app.Status == ApplicationStatus.Pending)
                {
                    Console.WriteLine($"- {app.Doctor.Name} {app.Doctor.Surname}, Experience: {app.Doctor.Experience} years");
                }
            }
        }
    }
}
