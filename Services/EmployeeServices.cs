namespace SkyProject.Services;

using SkyProject.Data;
using SkyProject.Exceptions;
using SkyProject.Interfaces;

public class EmployeeService : IEmployeeService
{

    private readonly AppDbContext _context;

    public EmployeeService(AppDbContext context)
    {
        _context = context;
    }

    public void Create(Employee employee)
    {
        if (employee.CreateDate < DateTime.Today)
        {
            throw new ArgumentException("CreateDate cannot be in the past");
        }

        if (employee.ExitDate.HasValue)
        {
            throw new ArgumentException("ExitDate cannot be set on creation");
        }

        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var employee = _context.Employees.Find(id) ?? throw new EmployeeNotFoundExceptionException("Employee not found");

        _context.Employees.Remove(employee);
        _context.SaveChanges();
    }

    public Employee getById(int id)
    {
        var employee = _context.Employees.Find(id) ?? throw new EmployeeNotFoundExceptionException("Employee not found");
        return employee;
    }

    public IEnumerable<Employee> GetAll()
    {
        return _context.Employees;
    }

    public void Update(Employee employee)
    {
        var EmployeeToUpdate = _context.Employees.Find(employee.Id) ?? throw new EmployeeNotFoundExceptionException("Employee not found");

        EmployeeToUpdate.Firstname = employee.Firstname;
        EmployeeToUpdate.LastName = employee.LastName;
        EmployeeToUpdate.Role = employee.Role;
        EmployeeToUpdate.CreateDate = employee.CreateDate;
        EmployeeToUpdate.ExitDate = employee.ExitDate;

        _context.Employees.Update(EmployeeToUpdate);
        _context.SaveChanges();
    }
}