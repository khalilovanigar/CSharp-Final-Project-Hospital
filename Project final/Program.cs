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
using System.Net;



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

var doctor1 = new Doctor("Gulnar", "Huseynova", 10, "Pediatriya") { Description = "Pediatrician with 10 years of experience. Focused on children's health." };
var doctor2 = new Doctor("Muxtar", "Kerimov", 5, "Travmotologiya") { Description = "Orthopedic specialist with 5 years of experience, skilled in trauma and fracture care." };
var doctor3 = new Doctor("Lamiye", "Aliyeva", 3, "Stomologiya") { Description = "Newly graduated dentist, passionate about dental and oral health." };
var doctor4 = new Doctor("Aylin", "Selimova", 1, "Pediatriya") { Description = "New doctor, gaining experience in the field." };
var doctor5 = new Doctor("Ayxan", "Zamanov", 2, "Travmotologiya") { Description = "2 years of experience, learning new methods in practice." };
// var doctor6 = new Doctor("Leman", "Ehmedova", 7, "Pediatriya") { Description = "Pediatrician with 7 years of experience, skilled in treating children." };
// var doctor7 = new Doctor("Fidan", "Eliyeva", 4, "Stomologiya") { Description = "New dentist, eager to develop expertise in dental treatments." };
// var doctor8 = new Doctor("Samira", "Ismayilova", 8, "Ginekologiya") { Description = "Experienced gynecologist with 8 years of practice. Specializes in women's health, prenatal care, and family planning." };
// var doctor9 = new Doctor("Resad", "Mammadov", 9, "Kardiologiya") { Description = "Skilled cardiologist with 9 years of experience. Focuses on heart diseases, preventive care, and patient management." };
// var doctor10 = new Doctor("Konul", "Veliyeva", 10, "Dermatologiya") { Description = "Veteran dermatologist with 10 years of experience. Expertise in treating skin conditions, cosmetic dermatology, and anti-aging treatments." };



        admin.AddDoctorApplication(doctor1);
        admin.AddDoctorApplication(doctor2);
        admin.AddDoctorApplication(doctor3);
        admin.AddDoctorApplication(doctor4);
        admin.AddDoctorApplication(doctor5);
        // admin.AddDoctorApplication(doctor6);
        // admin.AddDoctorApplication(doctor7);
        // admin.AddDoctorApplication(doctor8);
        // admin.AddDoctorApplication(doctor9);
        // admin.AddDoctorApplication(doctor10);

while (true)
{
var mainMenuOptions = new List<string>
{
    "1. Admin Login",
    "2. User Sign Up",
    "3. User Login",
    "4. Doctor Sign Up",
    "5. Doctor Login",
    "6. Exit from system"
};

int choice = MenuHelper.SelectFromMenu(mainMenuOptions, "Main Menu") +1 ;

    if (choice == 1)
    {
        bool adminLoggedIn = false;

        while (!adminLoggedIn)
        {
            try
            {
                Console.Clear();
                System.Console.WriteLine("     --- Admin login ---");
                System.Console.WriteLine();
                System.Console.Write("Username: ");
                string username = Console.ReadLine()!;
                System.Console.Write("Password: ");
                string password = Console.ReadLine()!;

                admin.Login(username, password);

                adminLoggedIn = true;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
                System.Console.WriteLine("Press any key to try again...");
                Console.ReadKey();
            }
        }

        Console.Clear();

        bool isAdminSessionActive = true;
        while (isAdminSessionActive)
        {
            var adminOptions = new List<string>
        {
            "1. Show pending doctor applications",
            "2. Accept or reject pending doctor",
            "3. Show accepted doctors",
            "4. Show rejected doctors",
            "5. Show all reservs",
            "6. Logout"
        };
            int adminChoice = MenuHelper.SelectFromMenu(adminOptions, "Welcome to Admin page!") + 1;

            if (adminChoice == 1)
            {
                admin.ShowPendingApplications();
                System.Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
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
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                Console.Write($"   {options[i]}   ");
                                Console.ResetColor();
                            }

                            var key = Console.ReadKey(intercept: true).Key;

                            if (key == ConsoleKey.LeftArrow)
                            {
                                selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
                            }
                            else if (key == ConsoleKey.RightArrow)
                            {
                                selectedIndex = (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1;
                            }
                            else if (key == ConsoleKey.Enter)
                            {
                                if (selectedIndex == 0)
                                {
                                    admin.AcceptDoctor(doctor.Name, doctor.Surname);
                                }
                                else if (selectedIndex == 1)
                                {
                                    admin.RejectDoctor(doctor.Name, doctor.Surname);
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
                var acceptedDoctors = admin.PendingApplications
                    .Where(a => a.Status == ApplicationStatus.Accepted)
                    .ToList();

                Console.Clear();
                System.Console.WriteLine("              ----- Accepted Doctors List -----");
                System.Console.WriteLine();   System.Console.WriteLine();

                if (acceptedDoctors.Count == 0)
                {
                    System.Console.WriteLine("No accepted doctors yet.");
                }
                else
                {
                    int counter = 1;
                    foreach (var app in acceptedDoctors)
                    {
                        var doc = app.Doctor;
                        System.Console.WriteLine($"{counter++}.Fullanme: {doc.Name} {doc.Surname}");
                        System.Console.WriteLine($"  Department: {doc.Department}");
                        System.Console.WriteLine($"  Experience: {doc.Experience} years");
                        System.Console.WriteLine("-----------------------------------------------------------");
                    }
                }

                System.Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
            else if (adminChoice == 4)
            {
                var rejectedDoctors = admin.PendingApplications
                    .Where(a => a.Status == ApplicationStatus.Rejected)
                    .ToList();

                Console.Clear();
                System.Console.WriteLine("                 ----- Rejected Doctors List -----");
                System.Console.WriteLine(); System.Console.WriteLine();

                if (rejectedDoctors.Count == 0)
                {
                    System.Console.WriteLine("No rejected doctors yet.");
                }
                else
                {
                    int counter = 1;
                    foreach (var app in rejectedDoctors)
                    {
                        var doc = app.Doctor;
                        System.Console.WriteLine($"{counter++}.Fullname: {doc.Name} {doc.Surname}");
                        System.Console.WriteLine($"  Department: {doc.Department}");
                        System.Console.WriteLine($"  Experience: {doc.Experience} years");
                        System.Console.WriteLine("-----------------------------------------------------------");
                    }
                }
                System.Console.WriteLine();
                System.Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

else if (adminChoice == 5)
{
    Console.Clear();
    System.Console.WriteLine("               ----- All Reservations -----");
    System.Console.WriteLine();

    bool anyReservation = false;

    foreach (var dept in departments)
    {
        foreach (var doc in dept.Doctors)
        {
            foreach (var res in doc.Reserved)
            {
                            if (res.IsReserved && res.ReservedBy != null)
                            {
                                anyReservation = true;
                                System.Console.WriteLine($"Department:   {dept.DepartmentName}");
                                System.Console.WriteLine($"Doctor:       Dr. {doc.Name} {doc.Surname}");
                                System.Console.WriteLine($"Time:         {res.Time}");
                                System.Console.WriteLine($"Reserved by:  {res.ReservedBy.Name} {res.ReservedBy.Surname}");
                                System.Console.WriteLine("-----------------------------------------------------------");
                }
            }
        }
    }

    if (!anyReservation)
    {
        System.Console.WriteLine("No reservations found.");
    }
    System.Console.WriteLine();
    System.Console.WriteLine("Press any key to return...");
    Console.ReadKey();
}


            else if (adminChoice == 6)
            {
                System.Console.WriteLine("Logging out from admin page");
                break;
            }
        }
}



else if (choice == 2)
{
    Console.Clear();
    System.Console.WriteLine("          ----- User Sign Up -----");
    System.Console.WriteLine();

    System.Console.Write("Enter your Name: ");
    string name = Console.ReadLine()!;

    System.Console.Write("Enter your Surname: ");
    string surname = Console.ReadLine()!;

    string email = "";
    bool isValidEmail = false;

    while (!isValidEmail)
    {
        System.Console.Write("Enter your Mail: ");
        email = Console.ReadLine()!;

        try
        {
            
            User tempUser = new User(name, surname, email, " "," "); 
            isValidEmail = true;
        }
        catch (ArgumentException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine($"Error: {ex.Message}");
            Console.ResetColor();
            System.Console.WriteLine("Please try again.");
            Console.ReadKey();
        }
    }

    System.Console.Write("Enter your Phone Number: ");
    string phoneNumber = Console.ReadLine()!;

    string password = "";
    bool isValidPassword = false;

    while (!isValidPassword)
    {
        Console.Write("Create a Password (at least 8 characters): ");
        password = Console.ReadLine()!;

        if (password.Length < 8)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Password must be at least 8 characters long.");
            Console.ResetColor();
        }
        else
        {
            isValidPassword = true;
        }
    }

    try
    {
        User newUser = new User(name, surname, email, phoneNumber, password);
        string filePath = "user_data.json";

        List<User> users_new = User.LoadFromJson(filePath);

        users_new.Add(newUser);

        User.SaveToJson(filePath, users_new); 

        Console.WriteLine("Your registration was successful. Your data has been saved to user_data.json");

        Console.WriteLine("\nUser details loaded from file:");
        foreach (var user in users_new)
        {
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Surname: {user.Surname}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Phone Number: {user.PhoneNumber}");
            Console.WriteLine($"Password: {user.Password}");
            Console.WriteLine();
        }

        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();

            // Department secimi
        
        System.Console.WriteLine("Choose a department: ");
        var departmentNames = departments.Select(d => d.DepartmentName!).ToList();
        int selectedDeptIndex = MenuHelper.SelectFromMenu(departmentNames, "Choose a Department");

        Department selectedDepartment = departments[selectedDeptIndex];
        System.Console.WriteLine($"You chose {selectedDepartment.DepartmentName}");

            // Doctor secimi
        
        var doctorNames = selectedDepartment.Doctors
                .Select(doc => $"{doc.Name} {doc.Surname} ({doc.Experience} years)")
                .ToList();

        int selectedDoctorIndex = MenuHelper.SelectFromMenu(doctorNames, "Choose a Doctor");

        var selectedDoctor = selectedDepartment.Doctors[selectedDoctorIndex];
        System.Console.WriteLine($"You chose Dr. {selectedDoctor.Name} {selectedDoctor.Surname} with {selectedDoctor.Experience} years of experience.");

            // Saat secimi
    
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
                chosenHour.ReservedBy = newUser;
                newUser.AddAppointment(selectedDoctor, chosenHour.Time);
                System.Console.WriteLine($"Thanks {name} {surname}, you have successfully reserved the time {chosenHour.Time} with Dr.{selectedDoctor.Name}.");
                Console.ReadKey();
                break;
            }
        }
    }
    catch (Exception ex)
    {
        System.Console.WriteLine($"Error during registration: {ex.Message}");
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}



else if (choice == 3)
{
    Console.Clear();
    System.Console.WriteLine("        ----- User LogIn -----");
    System.Console.WriteLine();

    string filePath = "user_data.json";
    List<User> users_new = User.LoadFromJson(filePath); 

    System.Console.Write("Enter your Name: ");
    string name = Console.ReadLine()!;

    System.Console.Write("Enter your Surname: ");
    string usersurname = Console.ReadLine()!;

    System.Console.Write("Enter your Email: ");
    string loginEmail = Console.ReadLine()!;

    System.Console.Write("Enter your Password: ");
    string password = Console.ReadLine()!;

    bool found = false;
    foreach (var user in users_new)
    {
        if (user.Name == name && user.Surname == usersurname && user.Email == loginEmail)
        {
            if (user.Password == password)
            {
                System.Console.WriteLine($"Welcome {user.Name} {user.Surname}!");
                found = true;
                bool loggedIn = true;

                int lastChoice = user.LastChoice; 

                while (loggedIn)
                {
                    string[] userOptions = { "Book an appointment", "Logout" };
                    int selectedIndex = (lastChoice != -1) ? lastChoice : 0; 
                    
                    while (true)
                    {
                        Console.Clear();
                        System.Console.WriteLine($"Welcome {user.Name} {user.Surname}!");
                        System.Console.WriteLine();

                        for (int i = 0; i < userOptions.Length; i++)
                        {
                            if (i == selectedIndex)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Console.ResetColor();
                            }

                            System.Console.WriteLine(userOptions[i]);
                        }
                        Console.ResetColor();

                        var key = Console.ReadKey(true).Key;
                        if (key == ConsoleKey.UpArrow)
                        {
                            selectedIndex = (selectedIndex == 0) ? userOptions.Length - 1 : selectedIndex - 1;
                        }
                        else if (key == ConsoleKey.DownArrow)
                        {
                            selectedIndex = (selectedIndex == userOptions.Length - 1) ? 0 : selectedIndex + 1;
                        }
                        else if (key == ConsoleKey.Enter)
                        {
                            break;
                        }
                    }

                    user.LastChoice = selectedIndex; 
                    User.SaveToJson(filePath, users_new);  

                    if (selectedIndex == 0)
                    {
                            // Department secimi
                        
                        System.Console.WriteLine("Choose a department: ");
                        var departmentNames = departments.Select(d => d.DepartmentName!).ToList();
                        int selectedDeptIndex = MenuHelper.SelectFromMenu(departmentNames, "Choose a Department");

                        Department selectedDepartment = departments[selectedDeptIndex];
                        System.Console.WriteLine($"You chose {selectedDepartment.DepartmentName}");

                            // Doctor secimi
                        
                        var doctorNames = selectedDepartment.Doctors
                            .Select(doc => $"{doc.Name} {doc.Surname} ({doc.Experience} years)")
                            .ToList();

                        int selectedDoctorIndex = MenuHelper.SelectFromMenu(doctorNames, "Choose a Doctor");

                        var selectedDoctor = selectedDepartment.Doctors[selectedDoctorIndex];
                        System.Console.WriteLine($"You chose Dr. {selectedDoctor.Name} {selectedDoctor.Surname} with {selectedDoctor.Experience} years of experience.");

                            // Saat secimi
                        
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
                                chosenHour.ReservedBy = user;
                                user.AddAppointment(selectedDoctor, chosenHour.Time);
                                System.Console.WriteLine($"Thanks {name} {usersurname}, you have successfully reserved the time {chosenHour.Time} with Dr.{selectedDoctor.Name}.");
                                Console.ReadKey();
                                break;
                            }
                        }
                    }
                    else if (selectedIndex == 1)
                    {
                        System.Console.WriteLine("Logging out from user page");
                        System.Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        loggedIn = false;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Incorrect password. Please try again.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }

    if (!found)
    {
        System.Console.WriteLine("We couldn't find this user in the system.");
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}




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
        admin.AddDoctorApplication(newDoctor);

        System.Console.WriteLine();
        Console.WriteLine($"Thank you Dr. {doctorName} {doctorSurname}, your application has been submitted for review.You will be notified once admin reviews your application/n");
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }


    else if (choice == 5)
    {
        Console.Clear();
        System.Console.WriteLine("------ Doctor Login ------");

        System.Console.Write("Enter your Name: ");
        string doctorName = Console.ReadLine()!;

        System.Console.Write("Enter your Surname: ");
        string doctorSurname = Console.ReadLine()!;

        var app = admin.PendingApplications
            .FirstOrDefault(a =>
                a.Doctor.Name.Equals(doctorName, StringComparison.OrdinalIgnoreCase) &&
                a.Doctor.Surname.Equals(doctorSurname, StringComparison.OrdinalIgnoreCase));

        if (app == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("This doctor not found..");
            Console.ResetColor();
        }
        else if (app.Status == ApplicationStatus.Pending)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("Your application has not been reviewed by the admin yet..");
            Console.ResetColor();
        }
        else if (app.Status == ApplicationStatus.Rejected)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("We are sorry but your application rejected from admin");
            Console.ResetColor();
        }
        else if (app.Status == ApplicationStatus.Accepted)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine($"Welcome, Dr. {app.Doctor.Name} {app.Doctor.Surname}!");
            Console.ResetColor();

            System.Console.WriteLine("Congratulations,you are accepted to work!");
        }

        System.Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }


    else if (choice == 6)
    {
        System.Console.WriteLine("Exiting from system");
        break;
    }
}
