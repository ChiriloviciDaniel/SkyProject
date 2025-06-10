using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SkyProject.Data;

namespace SkyProject.Pages_Employees
{
    public class IndexModel : PageModel
    {
        private readonly SkyProject.Data.AppDbContext _context;

        public IndexModel(SkyProject.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Employee = await _context.Employees.ToListAsync();
        }
    }
}
