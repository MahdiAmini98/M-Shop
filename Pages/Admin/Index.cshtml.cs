using M_Shop.Data;
using M_Shop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace M_Shop.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private MShop_DBContext _context;

        public IndexModel(MShop_DBContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> Products { get; set; }
        //public void OnGet()
        //{    // چک کردن آیا کاربر لاگین کرده است
        //    // چک کردن آیا کاربر لاگین کرده است
        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        // Redirect از Pages به MVC Controller
        //         RedirectToAction("Login", "Account", new { area = "" });
        //    }

        //    // گرفتن UserId از Claim ها
        //    var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        //    int userId = default; 
        //    if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out userId))
        //    {
        //         HttpContext.SignOutAsync();
        //         RedirectToAction("Login", "Account", new { area = "" });
        //    }


        //    // چک کردن اینکه کاربر ادمین است یا نه
        //    var user =  _context.Users.Find(userId);

        //    if (user == null || !user.IsAdmin)
        //    {
        //        // Redirect به صفحه AccessDenied در Pages
        //        RedirectToPage("/Shared/AccessDenied");
        //    }

        //    Products = _context.Products.Include(i=>i.Item);
        //}
        public IActionResult OnGet()
        {
            // چک کردن آیا کاربر لاگین کرده است
            if (!User.Identity.IsAuthenticated)
            {
                // Redirect از Pages به MVC Controller
                return RedirectToAction("Login", "Account", new { area = "" });
            }

            // گرفتن UserId از Claim ها
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            int userId = default;
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out userId))
            {
                HttpContext.SignOutAsync();
                return RedirectToAction("Login", "Account", new { area = "" });
            }

            // چک کردن اینکه کاربر ادمین است یا نه
            var user = _context.Users.Find(userId);

            if (user == null || !user.IsAdmin)
            {
                // Redirect به صفحه AccessDenied در Pages
                return RedirectToPage("/Shared/AccessDenied");
            }

            Products = _context.Products.Include(i => i.Item);
            return Page();
        }
    }
}
