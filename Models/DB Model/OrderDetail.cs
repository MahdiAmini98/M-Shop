using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace M_Shop.Models
{
    public class OrderDetail
    {
        [Key]
        public int DetailId { get; set; }
        [Required]
        public int OrderId { get; set; }      
        [Required]
        public int ProductId { get; set; }  
        [Required]
        public decimal Price { get; set; }      
        [Required]

        public int Count { get; set; }

        //navigation property(Relation)
        [ForeignKey("ProductId")]
        public Product Product  { get; set; }
        [ForeignKey("OrderId")]
        public Order Order  { get; set; }
        

    }
}
