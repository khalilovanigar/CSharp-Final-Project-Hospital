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

public class ReservationRecord
{
    public string DoctorName { get; set; }
    public string DoctorSurname { get; set; }
    public string Department { get; set; }
    public string Time { get; set; }
    public string ReservedByEmail { get; set; }

    public ReservationRecord(string doctorName, string doctorSurname, string department, string time, string reservedByEmail)
    {
        DoctorName = doctorName;
        DoctorSurname = doctorSurname;
        Department = department;
        Time = time;
        ReservedByEmail = reservedByEmail;
    }
}
