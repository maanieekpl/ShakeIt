using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShakeIt.Models
{
    [Table("DrinkIngridients")]
    public class DrinkIngridients
    {
        [ForeignKey("Drinks")]
        public int DrinkId { get; set; }
        [ForeignKey("Ingridients")]
        public int IngridientId { get; set; }
        public string Capacity { get; set; }
    }


}
