using SkyProject.Data;


namespace SkyProject.Interfaces;

public interface IEmployeeService
{
    void Create(Employee employee);
    void Delete(int id);
    IEnumerable<Employee> GetAll();
    Employee getById(int id);
    void Update(Employee employee);
}
