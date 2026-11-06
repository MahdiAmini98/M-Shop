using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace M_Shop.Models
{
    public class Product
    {
        [Key] 
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public int ItemId { get; set; }
        //navigation property (Relation)
        public IEnumerable<CategoryToProduct> CategoryToProducts { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
