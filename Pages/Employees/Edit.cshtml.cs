using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SkyProject.Data;
using SkyProject.Exceptions;
using SkyProject.Interfaces;

namespace SkyProject.Pages_Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public EditModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                _employeeService.Update(Employee);
            }
            catch (EmployeeNotFoundExceptionException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return RedirectToPage("../Error");
            }


            return RedirectToPage("../Index");

        }
    }
}
