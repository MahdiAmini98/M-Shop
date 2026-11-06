using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using M_Shop.Data;
using M_Shop.Pages.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace M_Shop.Pages.Admin
{
    public class EditModel : PageModel
    {
        private MShop_DBContext _context;

        public EditModel(MShop_DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddEditeProductViewModel AddEditeProductViewModel { get; set; }

        public void OnGet(int id)
        {
            var product = _context.Products.Include(i => i.Item)
                .Where(d => d.Id == id).Select(v => new AddEditeProductViewModel()
                {
                    
                    Id = v.Id,
                    Name = v.Name,
                    Description = v.Description,
                    Price = v.Item.Price,
                    QuantityStoke = v.Item.QuantityStack

                }).FirstOrDefault();

            AddEditeProductViewModel = product;

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            
                return Page();

            var product = _context.Products.Find(AddEditeProductViewModel.Id);
            var item = _context.Items.First(d=>d.Id==product.ItemId);

            product.Name = AddEditeProductViewModel.Name;
            product.Description = AddEditeProductViewModel.Description;
            item.Price = AddEditeProductViewModel.Price;
            item.QuantityStack = AddEditeProductViewModel.QuantityStoke;


            _context.SaveChanges();

            if (AddEditeProductViewModel.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "imag",
                    product.Id + Path.GetExtension(AddEditeProductViewModel.Picture.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    AddEditeProductViewModel.Picture.CopyTo(stream);
                }
            }


            return RedirectToPage("Index");

        }
    }
}
