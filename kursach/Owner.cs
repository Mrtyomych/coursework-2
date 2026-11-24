using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kursach
{
    [Table("OWNERS")]
    public class Owner
    {
        [Key]
        [Column("id_owner")]
        public int IdOwner { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("address")] 
        public string Address { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("passport")]
        public string Passport { get; set; }

        public virtual List<Car> Cars { get; set; } = new List<Car>();
    }
}