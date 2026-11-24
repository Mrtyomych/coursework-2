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
    [Table("BRANDS")]
    public class Brand
    {
        [Key]
        [Column("id_brand")]
        public int IdBrand { get; set; }

        [Column("brand_name")]
        public string BrandName { get; set; }

        public virtual List<Car> Cars { get; set; } = new List<Car>();
    }
}
