using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using SkyProject.Data;
using SkyProject.Interfaces;

namespace SkyProject.Pages_Employees
{
    public class IndexModel : PageModel
    {

        private readonly IEmployeeService _employeeService;

        public IndexModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IList<Employee> Employees { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public void OnGet()
        {
            if (!string.IsNullOrWhiteSpace(SearchString))
            {
                Employees = _employeeService.SearchByName(SearchString).ToList();
                return;
            }
            Employees = _employeeService.GetAll().ToList();
            //Employees = await _context.Employees.ToListAsync();
        }

    }
}
