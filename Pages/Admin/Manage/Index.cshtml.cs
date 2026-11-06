using System;
using System.Collections.Generic;
using System.Linq;
using M_Shop.Data;
using M_Shop.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Pages.Manage_Users
{
    public class IndexModel : PageModel
    {
        private readonly MShop_DBContext _context;

        public IndexModel(MShop_DBContext context)
        {
            _context = context;
        }

        public IList<Users> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
