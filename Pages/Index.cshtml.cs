using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
        //private readonly AppDbContext _context;
        /*
                public IndexModel(Data.AppDbContext context)
                {
                    _context = context;
                }*/

        public IList<Employee> Employees { get; set; } = default!;

        public void OnGet()
        {
            Employees = _employeeService.GetAll().ToList();
            //Employees = await _context.Employees.ToListAsync();
        }

    }
}
