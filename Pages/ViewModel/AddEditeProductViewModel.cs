using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using M_Shop.Models;
using Microsoft.AspNetCore.Http;

namespace M_Shop.Pages.ViewModel
{
    public class AddEditeProductViewModel
    {
      
        public int Id { get; set; }
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "قیمت")]
        public decimal Price { get; set; }
        [Display(Name = "تعداد")]
        public int QuantityStoke { get; set; }
        [Display(Name = "تصویر")]
        public IFormFile Picture { get; set; }
        public List<Category> Categories { get; set; }
    }
}
