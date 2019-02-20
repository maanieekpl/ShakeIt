using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShakeIt.Models
{
    public class Drink
    {
        private int? id;
        private List<DrinkIngridientsTable> drinkIngridients;

        public Drink(int? id, DrinkTable drinkTable, List<bool> drinkIngridients)
        {
            this.id = id;
            this.drinkTable = drinkTable;
            this.drinkIngridients = drinkIngridients;
        }

        public int DrinkId { get; set; }
        public DrinkTable drinkTable { get; set; }
        public List<DrinkIngridientsTable> drinkIngridientsTable { get; set; }

    }

    //[Table("Drinks")]
    //public class Drink
    //{
    //    public int DrinkId { get; set; }
    //    public string DrinkName { get; set; }
    //    public int DrinkType { get; set; }
    //}

    //[Table("DrinkIngridients")]
    //public class DrinkIngridients
    //{
    //    public int DrinkId { get; set; }
    //    public int IngridientId { get; set; }
    //    public string Capacity { get; set; }
    //}
}
