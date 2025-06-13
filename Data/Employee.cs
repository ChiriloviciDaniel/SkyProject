using System.ComponentModel.DataAnnotations;
using SkyProject.Enums;

namespace SkyProject.Data;

public class Employee
{
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Display(Name = "First Name")]
    public string? Firstname { get; set; }
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }
    [Display(Name = "Create Date")]
    public DateTime CreateDate { get; set; }
    public EmployeeRole Role { get; set; }
    [Display(Name = "Exit Date")]
    public DateTime? ExitDate { get; set; }

}
