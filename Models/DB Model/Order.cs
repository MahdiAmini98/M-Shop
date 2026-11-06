using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace M_Shop.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime CreateData { get; set; }
        public bool IsFinaly { get; set; }

        //navigation property (Relation)
        [ForeignKey("UserId")]
        public Users Users { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }

    }
}
