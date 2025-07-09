using System;
using System.Collections.Generic;
using ReservNamespace;
using System.IO;
using Newtonsoft.Json;

namespace DoctorsNamespace;

public class Doctor
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Experience { get; set; }
    public string Description { get; set; }
    public List<Reserv> Reserved { get; set; }
    public string Department { get; set; }


    public Doctor(string name, string surname, int experience, string department = "", string description = "")
    {
        Name = name;
        Surname = surname;
        Experience = experience;
        Description = description;
        Department = department;
        Reserved = new List<Reserv>
    {
        new Reserv("09:00-11:00"),
        new Reserv("12:00-14:00"),
        new Reserv("15:00-17:00")
    };
    } 
        
               public static void SaveDoctorsToJson(string filePath, List<Doctor> doctors)
        {
            try
            {
                string json = JsonConvert.SerializeObject(doctors, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        } 

public static List<Doctor> LoadDoctorsFromJson(string filePath)
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            var doctors = JsonConvert.DeserializeObject<List<Doctor>>(json);
            if (doctors != null && doctors.Count > 0)
            {
                return doctors;
            }
        }
        return new List<Doctor>();
    }
    
    }
