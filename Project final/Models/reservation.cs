using System;
using UsersNamespace;
using DoctorManagerNamespace;
using DoctorsNamespace;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

namespace ReservNamespace;

public class Reserv
{
    public string Time { get; set; }
    public bool IsReserved { get; set; }
    [JsonIgnore] 
    public User? ReservedBy { get; set; }

    public Reserv() { }

    public Reserv(string time)
    {
        Time = time;
        IsReserved = false;
        ReservedBy = null;
    }
    

    
}

