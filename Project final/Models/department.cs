using System;
using DoctorsNamespace;
namespace DepartmentNamespace;

public class Department
{
    public string? DepartmentName { get; set; }
    public List<Doctor> Doctors;
    public Department(string departmentName, List<Doctor> doctors)
    {
        DepartmentName = departmentName;
        Doctors = doctors;
    }
}
