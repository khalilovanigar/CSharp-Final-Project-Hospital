using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using DoctorsNamespace;
namespace DepartmentNamespace
{
    public class Department
    {
        public string? DepartmentName { get; set; }
        public List<Doctor> Doctors{ get; set; }= new List<Doctor>();
        public Department(string departmentName, List<Doctor> doctors)
        {
            DepartmentName = departmentName;
            Doctors = doctors;
        }

        public static void SaveDepartmentsToFile(string filePath, List<Department> departments)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };
            string json = JsonSerializer.Serialize(departments, options);
            File.WriteAllText(filePath, json);
        }

        public static List<Department> LoadDepartmentsFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<Department>();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Department>>(json, options) ?? new List<Department>();
        }



    }
}
