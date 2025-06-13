using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkyProject.Data;
using SkyProject.Exceptions;
using SkyProject.Interfaces;

namespace SkyProject.Pages_Employees
{
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeService _employeeService;


        public DetailsModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public Employee Employee { get; set; } = default!;

         public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                Employee = _employeeService.getById(id.Value);
            }
            catch (EmployeeNotFoundExceptionException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return RedirectToPage("../Error");
            }
            return Page();
        }

    }
}
