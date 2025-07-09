using System;
using UsersNamespace;
namespace ReservNamespace;
using DoctorManagerNamespace;
using DoctorsNamespace;

public class Reserv
{
    public string Time { get; set; }
    public bool IsReserved { get; set; }
    public User? ReservedBy { get; set; }

    public Reserv(string time)
    {
        Time = time;
        IsReserved = false;
    }
}





/*


    else if (choice == 4)
    {
        Console.Clear();
        System.Console.WriteLine("                   ------- Doctor Sign Up --------");
        System.Console.WriteLine();

        System.Console.Write("Enter your Name: ");
        string doctorName = Console.ReadLine()!;

        System.Console.Write("Enter your Surname: ");
        string doctorSurname = Console.ReadLine()!;

        System.Console.Write("Enter your Experience (years): ");
        bool isParsed = int.TryParse(Console.ReadLine(), out int experience);
        if (!isParsed)
        {
            System.Console.WriteLine("Invalid input. Please enter a number for experience.");
            Console.ReadKey();
            return;
        }


        System.Console.WriteLine("Select Department:");
        System.Console.WriteLine("1. Pediatriya");
        System.Console.WriteLine("2. Travmatologiya");
        System.Console.WriteLine("3. Stamotologiya");

        int deptChoice;
        while (!int.TryParse(Console.ReadLine(), out deptChoice) || deptChoice < 1 || deptChoice > 3)
        {
            System.Console.WriteLine("Invalid input. Enter a number");
        }

        string department = "";

        if (deptChoice == 1)
        {
            department = "Pediatriya";
        }
        else if (deptChoice == 2)
        {
            department = "Travmatologiya";
        }
        else if (deptChoice == 3)
        {
            department = "Stamotologiya";
        }
        else
        {
            System.Console.WriteLine("This choice does not exist");
        }

        Console.Write("Enter a short description about yourself: ");
        string description = Console.ReadLine()!;

        Doctor newDoctor = new Doctor(doctorName, doctorSurname, experience, department, description);

        string filePath = "doctors_data.json";

        List<Doctor> doctors = Doctor.LoadDoctorsFromJson(filePath);

        doctors.Add(newDoctor);
        //Admin admin = new Admin();
        admin.AddDoctorApplication(newDoctor);

        Doctor.SaveDoctorsToJson(filePath, doctors);

        System.Console.WriteLine();
        System.Console.WriteLine($"Thank you Dr. {doctorName} {doctorSurname}, your application has been submitted for review.You will be notified once admin reviews your application/n");
        System.Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }
*/
