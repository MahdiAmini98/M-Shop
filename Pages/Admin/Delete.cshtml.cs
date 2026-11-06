using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using M_Shop.Data;
using M_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace M_Shop.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private MShop_DBContext _context;

        public DeleteModel(MShop_DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }
        public void OnGet(int id)
        {
            Product = _context.Products.FirstOrDefault(c=>c.Id==id);
        }


        public IActionResult OnPost()
        {

            var product = _context.Products.Find(Product.Id);
            var item = _context.Items.First(i => i.Id == product.ItemId);

            _context.Items.Remove(item);
            _context.Products.Remove(product);

            _context.SaveChanges();

            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot",
                "images",
                product.Id + ".jpg");
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            return RedirectToPage("Index");
        }
    }
}
