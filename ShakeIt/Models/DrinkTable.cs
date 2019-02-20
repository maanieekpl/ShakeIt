using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShakeIt.Models
{
    [Table("Drinks")]
    public class DrinkTable
    {
            public int DrinkId { get; set; }
            public string DrinkName { get; set; }
            public int DrinkType { get; set; }
    }
}
