using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkyProject.Data;
using SkyProject.Interfaces;

namespace SkyProject.Pages_Employees
{
    public class CreateModel : PageModel
    {

        private readonly IEmployeeService _employeeService;

        public CreateModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        /*
        //not the best way to use AppDbContext
        private readonly Data.AppDbContext _context;

        public CreateModel(Data.AppDbContext context)
        {
            _context = context;
        }
    */
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                _employeeService.Create(Employee);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
            catch (Exception)
            {
                return RedirectToPage("../Error");
            }


            /*
                    _employeeService.Employees.Add(Employee);
                    await _employeeService.SaveChangesAsync();
        */
            return RedirectToPage("../Index");
        }
    }
}
