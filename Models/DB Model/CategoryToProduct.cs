using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace M_Shop.Models
{
    public class CategoryToProduct
    {
      
       
        public int CategoryId { get; set; }
        public int ProductId { get; set; }


        //navigation property (Relation)
        public Category Category { get; set; }
        public Product Product { get; set; }

    }
}
