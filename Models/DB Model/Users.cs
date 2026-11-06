using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace M_Shop.Models
{
    public class Users
    {
        [Key]
        public int  UserId { get; set; }
        [Required]
        [MaxLength(300)]
        public string  Email { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage = "کمتر از50 کارکتر باشد")]
        public string  Password { get; set; }

        [Required]
        public DateTime  RegisterDateTime { get; set; }
        public bool  IsAdmin { get; set; }


        //navigation property (Relation)

        public IEnumerable<Order> Orders { get; set; }

    }
}
