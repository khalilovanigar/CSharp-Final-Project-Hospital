using System;
using System.Reflection.Metadata;
namespace UsersNamespace;

public class User
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    private string email;

    public string Email
    {
        get { return email; }

        set
        {
            if (value.EndsWith("@gmail.com"))
            {
                email = value;
            }
            else
            {
                throw new ArgumentException("Email is not true,it must end with @gmail.com");
            }
        }
    }
    
    public string? PhoneNumber { get; set; }

    public User(string name, string surname, string email, string phonenumber)
    {
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phonenumber;
    }
    
}
