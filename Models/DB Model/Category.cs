using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace M_Shop.Models
{
    public class Category
    {
        [Key]
      
        public int Id { get; set; }
       
        public string Name { get; set; }
      
        public string Description { get; set; }

        //navigation property (Relation)
        public IEnumerable<CategoryToProduct> CategoryToProducts { get; set; }

    }
}
