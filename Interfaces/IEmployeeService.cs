using SkyProject.Data;


namespace SkyProject.Interfaces;

public interface IEmployeeService
{
    void Create(Employee employee);
    void Delete(int id);
    IEnumerable<Employee> GetAll();
    IEnumerable<Employee> SearchByName(string name);
    Employee getById(int id);
    void Update(Employee employee);
}
