using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kursach
{
    [Table("FINES")]
    public class Fine
    {
        [Key]
        [Column("id_fine")]
        public int IdFine { get; set; }

        [Column("id_car")]
        public int IdCar { get; set; }

        [Column("fine_date")]
        public string FineDate { get; set; }

        [Column("amount")]
        public decimal Amount { get; set; }

        [Column("reason")]
        public string Reason { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [ForeignKey("IdCar")]
        public virtual Car Car { get; set; }
    }
}
