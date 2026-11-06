using M_Shop.Data;
using M_Shop.Models;
using M_Shop.Pages.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace M_Shop.Pages.Admin
{
  
    public class AddModel : PageModel
    {

        private MShop_DBContext _context;

        public AddModel(MShop_DBContext context)
        {
            _context = context;
        }
        [BindProperty]
        public AddEditeProductViewModel AddEditeProductViewModel { get; set; }

        
        public void OnGet()
        {
        }

       
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();


            var item = new Item()
            {
                Price = AddEditeProductViewModel.Price,
                QuantityStack = AddEditeProductViewModel.QuantityStoke
            };
            _context.Add(item);
            _context.SaveChanges();

            var product = new Product()
            {
                Name = AddEditeProductViewModel.Name,
                Item = item,
                Description = AddEditeProductViewModel.Description,

            };
            _context.Add(product);
            _context.SaveChanges();
            product.ItemId = product.Id;
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
