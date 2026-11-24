using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach
{
    public class Car
    {
        [Key]
        public int id_car { get; set; }
        public string reg_number { get; set; }
        public string id_brand { get; set; }
        public string id_owner { get; set; }
        public string color { get; set; }
        public string year { get; set; }
        public string digit_part { get; set; }
        public Car()
        {

        }

    }

    
}
