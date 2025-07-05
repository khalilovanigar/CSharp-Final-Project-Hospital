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
            Console.WriteLine("Doctor CV:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Surname: {Surname}");
            Console.WriteLine($"Experience year: {ExperienceYears} il");
            Console.WriteLine($"Departament: {Department}");
            Console.WriteLine($"About: {Description}");
        }
    }

