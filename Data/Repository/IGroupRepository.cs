using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M_Shop.Models;
using M_Shop.Models.View_Models;
using Microsoft.EntityFrameworkCore;

namespace M_Shop.Data.Repository
{
   public interface IGroupRepository
   {

       //لیستی از جنس دسته بندی ها را بر میگرداتد
       IEnumerable<Category> GetAllCategories();


       // استفاده میشود components از این متد  در  
       IEnumerable<ShowListGroupViewModel> GetGroupForShow();


       //نشان دادن محصولات در لیست گروه ها
        IEnumerable<Product> ShowProductByListGroup(int id, string name);

       ///////Class Repository

   }

   public class GroupRepository : IGroupRepository
   {
       private MShop_DBContext _context;

       public GroupRepository(MShop_DBContext context)
       {
           _context = context;
       }
       public IEnumerable<Category> GetAllCategories()
       {
           return _context.Categories;
       }

       public IEnumerable<ShowListGroupViewModel> GetGroupForShow()
       {
            return _context.Categories.Select(c =>
                new ShowListGroupViewModel()
                {
                    GroupId = c.Id,
                    Name = c.Name,
                    ProductCount = _context.CategoryToProducts.Count(d => d.CategoryId == c.Id)
                }).ToList();
        }

       public IEnumerable<Product> ShowProductByListGroup(int id, string name)
       {

            return _context.CategoryToProducts.Where(c => c.CategoryId == id)
                .Include(p => p.Product)
                .Select(s => s.Product).ToList();

        }
    }
}
