using System;
using System.Collections.Generic;
using ReservNamespace;

namespace DoctorsNamespace

{
    public class Doctor
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Experience { get; set; }
        public List<Reserv> Reserved { get; set; }


        public Doctor(string name, string surname, int experience)
        {
            Name = name;
            Surname = surname;
            Experience = experience;
            Reserved = new List<Reserv>
    {
        new Reserv("09:00-11:00"),
        new Reserv("12:00-14:00"),
        new Reserv("15:00-17:00")
    };
        }
    }
}