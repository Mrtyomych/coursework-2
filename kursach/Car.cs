using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kursach
{
    [Table("CARS")]
    public class Car
    {
        [Key]
        [Column("id_car")]
        public int IdCar { get; set; }

        [Column("reg_number")]
        public string RegNumber { get; set; }

        [Column("id_brand")]
        public int IdBrand { get; set; } 

        [Column("id_owner")]
        public int IdOwner { get; set; }

        [Column("color")]
        public string Color { get; set; }

        [Column("year")]
        public int Year { get; set; } 

        [Column("digit_part")]
        public string DigitPart { get; set; }

        [ForeignKey("IdBrand")]
        public virtual Brand Brand { get; set; }

        [ForeignKey("IdOwner")]
        public virtual Owner Owner { get; set; }

        public virtual List<Fine> Fines { get; set; } = new List<Fine>();
    }
}
