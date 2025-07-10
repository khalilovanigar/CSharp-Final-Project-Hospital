using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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
    bool exists = PendingApplications.Any(a => a.Doctor.Name == doctor.Name && a.Doctor.Surname == doctor.Surname);
    if (!exists)
    {
        PendingApplications.Add(new Application { Doctor = doctor, Status = ApplicationStatus.Pending });
        SaveApplicationsToFile();
    }
    else
    {
        Console.WriteLine("This doctor has already applied.");
    }
}

private const string FilePath = "pending_applications.json";

public void SaveApplicationsToFile()
{
    string json = JsonSerializer.Serialize(PendingApplications, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(FilePath, json);
}


public void LoadApplicationsFromFile()
{
    if (File.Exists(FilePath))
    {
        string json = File.ReadAllText(FilePath);
        if (!string.IsNullOrWhiteSpace(json)) 
        {
            var list = JsonSerializer.Deserialize<List<Application>>(json);
            if (list != null)
            {
                PendingApplications = list;
            }
        }
        else
        {
            PendingApplications = new List<Application>();
        }
    }
    else
    {
        PendingApplications = new List<Application>();
    }
}

        public void AcceptDoctor(string name, string surname)
        {
            var app = PendingApplications.Find(a => a.Doctor.Name == name && a.Doctor.Surname == surname && a.Status == ApplicationStatus.Pending);
            if (app != null)
            {
                app.Status = ApplicationStatus.Accepted;
                SaveApplicationsToFile();
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
                SaveApplicationsToFile();
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
