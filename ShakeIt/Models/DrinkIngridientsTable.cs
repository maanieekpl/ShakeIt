using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShakeIt.Models
{
    [Table("DrinkIngridients")]
    public class DrinkIngridientsTable
    {
            public int DrinkId { get; set; }
            public int IngridientId { get; set; }
            public string Capacity { get; set; }
    }
}
