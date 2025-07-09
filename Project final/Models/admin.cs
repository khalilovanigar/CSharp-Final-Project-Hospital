using System;
using System.Collections.Generic;
using DoctorsNamespace;
using ApplicationNamespace;

namespace AdminNamespace
{
    public class Admin
    {
        public string? Name { get; set; }
        public string Password { get; set; }

        public List<Application> PendingApplications = new List<Application>();

        public Admin(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public void Login(string username, string password)
        {
            if (username != "admin" || password != "admin123")
            {
                throw new UnauthorizedAccessException("Invalid username or password!");
            }

        }



        public void AddDoctorApplication(Doctor doctor)
        {
            var app = new Application(doctor);
            PendingApplications.Add(app);
        }

        public void AcceptDoctor(string name, string surname)
        {
            var app = PendingApplications.Find(a => a.Doctor.Name == name && a.Doctor.Surname == surname && a.Status == ApplicationStatus.Pending);
            if (app != null)
            {
                app.Status = ApplicationStatus.Accepted;
                System.Console.WriteLine();
                System.Console.WriteLine($"Dr.{name} {surname} accepted.");
                System.Console.WriteLine();
            }
            else
            {
                System.Console.WriteLine("This doctor not found on pending list");
            }
        }

        public void RejectDoctor(string name, string surname)
        {
            var app = PendingApplications.Find(a => a.Doctor.Name == name && a.Doctor.Surname == surname && a.Status == ApplicationStatus.Pending);
            if (app != null)
            {
                app.Status = ApplicationStatus.Rejected;
                System.Console.WriteLine();
                System.Console.WriteLine($"Dr.{name} {surname} rejected.");
                System.Console.WriteLine();
            }
            else
            {
                System.Console.WriteLine("This doctor not found on pending list");
            }
        }

        public void ShowPendingApplications()
        {
            System.Console.WriteLine("             -----Pending Doctors List-----");
            System.Console.WriteLine();
            foreach (var app in PendingApplications)
            {
                if (app.Status == ApplicationStatus.Pending)
                {
                    System.Console.WriteLine($"- Fullname:     {app.Doctor.Name} {app.Doctor.Surname}");
                    System.Console.WriteLine($"- Department:   {app.Doctor.Department}");
                    System.Console.WriteLine($"- Experience:   {app.Doctor.Experience} years");
                    System.Console.WriteLine($"- Description:  {app.Doctor.Description}");
                    System.Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                }
            }
        }
    }
}
