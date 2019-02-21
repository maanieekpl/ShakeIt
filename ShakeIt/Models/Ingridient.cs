using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShakeIt.Models
{
    [Table("Ingridients")]
    public class Ingridient
    {
        [Key]
        public int IngridId { get; set; }
        public int IngridType { get; set; }
        public string IngridName { get; set; }
    }
}
