using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace M_Shop.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        public decimal Price { get; set; }
        //مقدار موجودی محصول
        public int QuantityStack { get; set; }

        //navigation property (Relation)
        public Product Product { get; set; }

    }
}
