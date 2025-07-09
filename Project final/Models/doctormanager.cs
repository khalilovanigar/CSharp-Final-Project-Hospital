namespace DoctorManagerNamespace;

using System;

    public class DoctorManager
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ExperienceYears { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }

        public DoctorManager(string name, string surname, int experienceYears, string department, string description)
        {
            Name = name;
            Surname = surname;
            ExperienceYears = experienceYears;
            Department = department;
            Description = description;
        }

    public void ShowCV()
    {
        System.Console.WriteLine("Doctor's CV");
        System.Console.WriteLine($"Name: {Name}");
        System.Console.WriteLine($"Surname: {Surname}");
        System.Console.WriteLine($"Experience year: {ExperienceYears} years");
        System.Console.WriteLine($"Departament: {Department}");
        System.Console.WriteLine($"About: {Description}");
        }
    }

