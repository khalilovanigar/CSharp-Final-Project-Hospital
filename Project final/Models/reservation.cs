using System;
//using DoctorsNamespace;
namespace ReservNamespace;
public class Reserv
{
    public string Time { get; set; }
    public bool IsReserved { get; set; }

    public Reserv(string time)
    {
        Time = time;
        IsReserved = false;
    }
}
