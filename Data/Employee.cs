using SkyProject.Enums;

namespace SkyProject.Data;

public class Employee
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string LastName { get; set; }
    public DateTime CreateDate { get; set; }
    public EmployeeRole Role { get; set; }
    public DateTime? ExitDate { get; set; }

}
