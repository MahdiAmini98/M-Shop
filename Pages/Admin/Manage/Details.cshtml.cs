using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M_Shop.Data;
using M_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using M_Shop.Models;

namespace WebApplication2.Pages.Manage_Users
{
    public class DetailsModel : PageModel
    {
        private readonly MShop_DBContext _context;

        public DetailsModel(MShop_DBContext context)
        {
            _context = context;
        }

        public Users Users { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Users = await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);

            if (Users == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
