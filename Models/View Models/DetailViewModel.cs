using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Shop.Models.View_Models
{
    public class DetailViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
