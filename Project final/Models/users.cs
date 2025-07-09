using System;
using DoctorsNamespace;
namespace UsersNamespace;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

public class User
{
    public string Name { get; set; }
    public string Surname { get; set; }
    private string email;

    public string Email
    {
        get { return email; }

 set
        {
            var emailRegex = new System.Text.RegularExpressions.Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                          + "@"
                          + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z");
            if (emailRegex.IsMatch(value))
            {
                email = value;
            }
            else
            {
                throw new ArgumentException("Invalid email format.");
            }
        }
    }

    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public int LastChoice { get; set; }



    public List<Appointment> Appointments { get; set; } = new List<Appointment>();

    public User(string name, string surname, string email, string phonenumber, string password)
    {
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phonenumber;
        Password = password;
        LastChoice = -1;
    }

public static void SaveToJson(string filePath, List<User> users)
{
    try
    {
        string jsonData = JsonConvert.SerializeObject(users, Formatting.Indented);
        
        Console.WriteLine("Saving user data to JSON...");
        Console.WriteLine(jsonData);

        File.WriteAllText(filePath, jsonData); 
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error saving user data: " + ex.Message);
    }
}

public static List<User> LoadFromJson(string filePath)
{
    try
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);

            Console.WriteLine("Loading user data from JSON...");
            Console.WriteLine(jsonData); 

            return JsonConvert.DeserializeObject<List<User>>(jsonData);
        }
        else
        {
 
            return new List<User>();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error loading user data: " + ex.Message);
        return new List<User>(); 
    }
}

    public void AddAppointment(Doctor doctor, string time)
    {
        Appointments.Add(new Appointment(doctor, time));
    }
}

    public class Appointment
    {
        public Doctor Doctor { get; set; }
        public string Time { get; set; }

        public Appointment(Doctor doctor, string time)
        {
            Doctor = doctor;
            Time = time;
        }
    }
