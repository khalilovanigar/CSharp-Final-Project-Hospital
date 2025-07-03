using System;
using DepartmentNamespace;
using UsersNamespace;
using DoctorsNamespace;
using ReservNamespace;
using AdminNamespace;
using ApplicationNamespace;
using System.ComponentModel.DataAnnotations;
using Project_final.Models;


var pediatricsDoctors = new List<Doctor>
{
    new Doctor("Sevda","Ehmedova",6),
    new Doctor("Selim","Eliyev",4),
    new Doctor("Leyla","Memmedli",7)
};

var traumatologyDoctors = new List<Doctor>
{
    new Doctor("Yasin","Hakverdiyev",9),
    new Doctor("Revan","Aliyev",3),
    new Doctor("Nuray","Memmedova",5)
};

var stomotologyDoctors = new List<Doctor>
{
    new Doctor ("Ramin","Hesenli",3),
    new Doctor ("Anar","Suleymanov",7),
    new Doctor ("Medine","Qurbanli",8)
};

var departments = new List<Department>
{
    new Department("Pediatriya",pediatricsDoctors),
    new Department("Travmotologiya",traumatologyDoctors),
    new Department("Stomologiya",stomotologyDoctors)
};

//var hours = new List<string> { "09:00-11:00", "12:00-14:00", "15:00-17:00" };

while (true)
{
    System.Console.WriteLine("Enter choice: ");
    System.Console.WriteLine("1. Admin Login");
    System.Console.WriteLine("2. User Sign Up");
    System.Console.WriteLine("3. User Login");
    System.Console.WriteLine("4. Doctor Sign Up");
    System.Console.WriteLine("5. Doctor Login");
    System.Console.WriteLine("6. Exit from system");

    System.Console.WriteLine();
    bool isParsed = int.TryParse(Console.ReadLine(), out int choice);
    if (!isParsed)
    {
        Console.WriteLine("Invalid input,enter number");
        continue;
    }

    if (choice == 1)
    {
        System.Console.WriteLine("Admin login");
    }


    else if (choice == 2)
    {
        System.Console.WriteLine("Enter your Name: ");
        string name = Console.ReadLine()!;

        System.Console.WriteLine("Enter your Surname: ");
        string surname = Console.ReadLine()!;

        System.Console.WriteLine("Enter your Mail: ");
        string email = Console.ReadLine()!;

        System.Console.WriteLine("Enter your Phone Number: ");
        string phonenumber = Console.ReadLine()!;

        System.Console.WriteLine();

    }

    else if (choice == 3)
    {
        System.Console.WriteLine("user login");
    }

    else if (choice == 4)
    {
        System.Console.WriteLine("doctor sign up");
    }

    else if (choice == 5)
    {
        System.Console.WriteLine("doctor login");
    }

    else if (choice == 6)
    {
        System.Console.WriteLine("exiting from system");
        break;
    }

    else
    {
        System.Console.WriteLine("Wrong input");
    }
}