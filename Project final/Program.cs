using Project_final.Models;
using System;
using DepartmentNamespace;
using UsersNamespace;
using DoctorsNamespace;
using ReservNamespace;
using AdminNamespace;
using ApplicationNamespace;
using DoctorManagerNamespace;
using MenuHelperNamespace;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



var pediatricsDoctors = new List<Doctor>
{
    new Doctor("Sevda","Ehmedova",6),
    new Doctor("Selim","Eliyev",4),
    new Doctor("Aysel","Abbasova",7),
    new Doctor("Leyla","Memmedli",2)
};

var traumatologyDoctors = new List<Doctor>
{
    new Doctor("Yasin","Hakverdiyev",9),
    new Doctor("Revan","Aliyev",3),
    new Doctor("Nuray","Memmedova",5),
    new Doctor("Nergiz","Osmanli",4)
};

var stomotologyDoctors = new List<Doctor>
{
    new Doctor ("Ramin","Hesenli",3),
    new Doctor ("Anar","Suleymanov",7),
    new Doctor ("Medine","Qurbanli",8),
    new Doctor ("Aysu","Memmedova",5)
};

var departments = new List<Department>
{
    new Department("Pediatriya",pediatricsDoctors),
    new Department("Travmotologiya",traumatologyDoctors),
    new Department("Stomologiya",stomotologyDoctors)
};

List<User> users = new List<User>();
var admin = new Admin("admin", "admin123");

var doctor1 = new Doctor("Gulnar", "Huseynova", 10) { Description = "Pediatrician with 10 years of experience. Focused on children's health." };
var doctor2 = new Doctor("Muxtar", "Kerimov", 5) { Description = "Orthopedic specialist with 5 years of experience, skilled in trauma and fracture care." };
var doctor3 = new Doctor("Lamiye", "Aliyeva", 3) { Description = "Newly graduated dentist, passionate about dental and oral health." };
var doctor4 = new Doctor("Aylin", "Selimova", 1) { Description = "New doctor, gaining experience in the field." };
var doctor5 = new Doctor("Ayxan", "Zamanov", 2) { Description = "2 years of experience, learning new methods in practice." };
var doctor6 = new Doctor("Leman", "Ehmedova", 7) { Description = "Pediatrician with 7 years of experience, skilled in treating children." };
var doctor7 = new Doctor("Fidan", "Eliyeva", 4) { Description = "New dentist, eager to develop expertise in dental treatments." };
var doctor8 = new Doctor("Samira", "Ismayilova", 8) { Description = "Experienced gynecologist with 8 years of practice. Specializes in women's health, prenatal care, and family planning." };
var doctor9 = new Doctor("Resad", "Mammadov", 9) { Description = "Skilled cardiologist with 9 years of experience. Focuses on heart diseases, preventive care, and patient management." };
var doctor10 = new Doctor("Konul", "Veliyeva", 10) { Description = "Veteran dermatologist with 10 years of experience. Expertise in treating skin conditions, cosmetic dermatology, and anti-aging treatments." };




        admin.AddDoctorApplication(doctor1);
        admin.AddDoctorApplication(doctor2);
        admin.AddDoctorApplication(doctor3);
        admin.AddDoctorApplication(doctor4);
        admin.AddDoctorApplication(doctor5);
        admin.AddDoctorApplication(doctor6);
        admin.AddDoctorApplication(doctor7);
        admin.AddDoctorApplication(doctor8);
        admin.AddDoctorApplication(doctor9);
        admin.AddDoctorApplication(doctor10);

while (true)
{
    System.Console.WriteLine("Enter choice: ");
    System.Console.WriteLine("1. Admin Login");
    System.Console.WriteLine("2. User Sign Up");
    System.Console.WriteLine("3. User Login");
    System.Console.WriteLine("4. Doctor Sign Up");
    System.Console.WriteLine("5. Doctor Login");
    System.Console.WriteLine("6. Exit from system");
    System.Console.Write("Your choice: ");
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
        Console.Write("Username: ");
        string username = Console.ReadLine()!;
        Console.Write("Password: ");
        string password = Console.ReadLine()!;

        if (admin.Login(username, password))
        {
            Console.Clear();
            System.Console.WriteLine("Welcome, Admin!");
            bool adminLoggedIn = true;
            while (adminLoggedIn)
            {
                System.Console.WriteLine("1. Show pending doctor applications");
                System.Console.WriteLine("2. Accept or reject doctor");
                System.Console.WriteLine("3. Logout");

                bool adminChoiceParsed = int.TryParse(Console.ReadLine(), out int adminChoice);
                if (!adminChoiceParsed)
                {
                    System.Console.WriteLine("Wrong input,Enter number");
                    continue;
                }

                if (adminChoice == 1)
                {
                    admin.ShowPendingApplications();
                }

                else if (adminChoice == 2)
                {
                    var pendingDoctors = admin.PendingApplications
                                                .Where(a => a.Status == ApplicationStatus.Pending)
                                                .ToList();

                    if (pendingDoctors.Count > 0)
                    {
                        foreach (var app in pendingDoctors)
                        {
                            var doctor = app.Doctor;
                            Console.Clear();

                            var doctorManager = new DoctorManager(doctor.Name, doctor.Surname, doctor.Experience, "Department", doctor.Description);
                            doctorManager.ShowCV();

                            System.Console.WriteLine("\nSelect action (Use Arrow keys to select, Enter to confirm):");
                            string[] options = { "Accept", "Reject" };
                            int selectedIndex = 0;

                            while (true)
                            {
                                // Seçim ekranını yenilə
                                Console.Clear();
                                doctorManager.ShowCV();
                                System.Console.WriteLine();
                                System.Console.WriteLine("Accept or reject doctor: ");
                                System.Console.WriteLine();

                                for (int i = 0; i < options.Length; i++)
                                {
                                    if (i == selectedIndex)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Green;
                                        Console.ForegroundColor = ConsoleColor.Black;
                                    }
                                    else
                                    {
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    System.Console.WriteLine(options[i]);
                                    Console.ResetColor();
                                }

                                var key = Console.ReadKey(intercept: true).Key;

                                if (key == ConsoleKey.UpArrow)
                                {
                                    selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
                                }
                                else if (key == ConsoleKey.DownArrow)
                                {
                                    selectedIndex = (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1;
                                }
                                else if (key == ConsoleKey.Enter)
                                {
                                    if (selectedIndex == 0)
                                    {
                                        admin.AcceptDoctor(doctor.Name, doctor.Surname);
                                        Console.WriteLine($"Doctor {doctor.Name} {doctor.Surname} accepted.");
                                    }
                                    else if (selectedIndex == 1)
                                    {
                                        admin.RejectDoctor(doctor.Name, doctor.Surname);
                                        Console.WriteLine($"Doctor {doctor.Name} {doctor.Surname} rejected.");
                                    }
                                    break;
                                }
                            }

                            System.Console.WriteLine("Press any key to continue to the next doctor...");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No pending doctor applications.");
                        System.Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }

                else if (adminChoice == 3)
                {
                    System.Console.WriteLine("Logging out from admin page");
                    adminLoggedIn = false;
                }
                else
                {
                    System.Console.WriteLine("Wrong input");
                }
            }
        }
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

        try
        {
            User newUser = new User(name, surname, email, phonenumber);
            users.Add(newUser);

            System.Console.WriteLine("User successfully added to registration!");

            // department choice

            System.Console.WriteLine("Choose a department: ");
            var departmentNames = departments.Select(d => d.DepartmentName!).ToList();
            int selectedDeptIndex = MenuHelper.SelectFromMenu(departmentNames, "Choose a Department");

            Department selectedDepartment = departments[selectedDeptIndex];
            System.Console.WriteLine($"You chose {selectedDepartment.DepartmentName}");

            // doctor choice

            var doctorNames = selectedDepartment.Doctors
                    .Select(doc => $"{doc.Name} {doc.Surname} ({doc.Experience} years)")
                    .ToList();

            int selectedDoctorIndex = MenuHelper.SelectFromMenu(doctorNames, "Choose a Doctor");

            var selectedDoctor = selectedDepartment.Doctors[selectedDoctorIndex];
            System.Console.WriteLine($"You chose Dr. {selectedDoctor.Name} {selectedDoctor.Surname} with {selectedDoctor.Experience} years of experience.");

            // saat secimi

            var timeOptions = selectedDoctor.Reserved
                .Select(r => $"{r.Time} {(r.IsReserved ? "(Reserved)" : "(Available)")}")
                .ToList();

            while (true)
            {
                int selectedTimeIndex = MenuHelper.SelectFromMenu(timeOptions, "Choose a time slot");

                var chosenHour = selectedDoctor.Reserved[selectedTimeIndex];

                if (chosenHour.IsReserved)
                {
                    System.Console.WriteLine("Sorry, this time slot is already reserved. Please choose another time.");
                    System.Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                }
                else
                {
                    chosenHour.IsReserved = true;
                    System.Console.WriteLine($"Thanks {name} {surname}, you have successfully reserved the time {chosenHour.Time} with Dr. {selectedDoctor.Name}.");
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error during registration: {ex.Message}");
        }

    }

    else if (choice == 3)
    {
        System.Console.WriteLine("Enter your Name:");
        string name = Console.ReadLine()!;

        System.Console.WriteLine("Enter your Surname:");
        string usersurname = Console.ReadLine()!;

        System.Console.WriteLine("Enter your Email:");
        string loginEmail = Console.ReadLine()!;

        bool found = false;
        foreach (var user in users)
        {
            if (user.Name == name && user.Surname == usersurname && user.Email == loginEmail)
            {
                System.Console.WriteLine($"Welcome {user.Name} {user.Surname}!");
                found = true;
                bool loggedIn = true;
                while (loggedIn)
                {
                    System.Console.WriteLine("1. Book an appointment");
                    System.Console.WriteLine("2. Logout");
                    System.Console.Write("Enter choice: ");
                    string userChoice = Console.ReadLine()!;
                    if (userChoice == "1")
                    {
                        // department secimi

                        System.Console.WriteLine("Choose a department: ");
                        var departmentNames = departments.Select(d => d.DepartmentName!).ToList();
                        int selectedDeptIndex = MenuHelper.SelectFromMenu(departmentNames, "Choose a Department");

                        Department selectedDepartment = departments[selectedDeptIndex];
                        System.Console.WriteLine($"You chose {selectedDepartment.DepartmentName}");

                        // doctor secimi

                        var doctorNames = selectedDepartment.Doctors
                                .Select(doc => $"{doc.Name} {doc.Surname} ({doc.Experience} years)")
                                .ToList();

                        int selectedDoctorIndex = MenuHelper.SelectFromMenu(doctorNames, "Choose a Doctor");

                        var selectedDoctor = selectedDepartment.Doctors[selectedDoctorIndex];
                        System.Console.WriteLine($"You chose Dr. {selectedDoctor.Name} {selectedDoctor.Surname} with {selectedDoctor.Experience} years of experience.");

                        // saat secimi

                        var timeOptions = selectedDoctor.Reserved
                            .Select(r => $"{r.Time} {(r.IsReserved ? "(Reserved)" : "(Available)")}")
                            .ToList();

                        while (true)
                        {
                            int selectedTimeIndex = MenuHelper.SelectFromMenu(timeOptions, "Choose a time slot");

                            var chosenHour = selectedDoctor.Reserved[selectedTimeIndex];

                            if (chosenHour.IsReserved)
                            {
                                System.Console.WriteLine("Sorry, this time slot is already reserved. Please choose another time.");
                                System.Console.WriteLine("Press any key to try again...");
                                Console.ReadKey();
                            }
                            else
                            {
                                chosenHour.IsReserved = true;
                                System.Console.WriteLine($"Thanks {name} {usersurname}, you have successfully reserved the time {chosenHour.Time} with Dr. {selectedDoctor.Name}.");
                                break;
                            }
                        }
                    }
                    else if (userChoice == "2")
                    {
                        System.Console.WriteLine("Logging out from user page");
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("Wrong input!");
                    }
                }
            }
        }

        if (!found)
        {
            System.Console.WriteLine("Wrong input. Enter true information");
        }
    }

    else if (choice == 4)
    {

        System.Console.WriteLine("Enter your Name:");
        string doctorName = Console.ReadLine()!;

        System.Console.WriteLine("Enter your Surname:");
        string doctorSurname = Console.ReadLine()!;

        System.Console.WriteLine("Enter your Experience year:");

        bool isParsed2 = int.TryParse(Console.ReadLine(), out int experience);
        if (!isParsed2)
        {
            System.Console.WriteLine("Invalid input,enter number");
            continue;
        }

        Doctor newDoctor = new Doctor(doctorName, doctorSurname, experience);
        admin.AddDoctorApplication(newDoctor);

    }

    else if (choice == 5)
    {
        System.Console.WriteLine("Doctor Login");

        System.Console.WriteLine("Enter your Name: ");
        string doctorName = Console.ReadLine()!;

        System.Console.WriteLine("Enter your Surname: ");
        string doctorSurname = Console.ReadLine()!;

        bool found = false;

        foreach (var application in admin.PendingApplications)
        {
            if (application.Status == ApplicationStatus.Accepted &&
                application.Doctor.Name == doctorName &&
                application.Doctor.Surname == doctorSurname)
            {
                Console.WriteLine($"Welcome Dr. {application.Doctor.Name} {application.Doctor.Surname}!");
                found = true;
                break;
            }
        }

        if (!found)
        {
            System.Console.WriteLine("Doctor not found or not accepted yet.");
        }
    }

    else if (choice == 6)
    {
        System.Console.WriteLine("Exiting from system");
        break;
    }

    else
    {
        System.Console.WriteLine("Wrong input");
    }
}

