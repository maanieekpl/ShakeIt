using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShakeIt.Models
{
    public class DrinkHelper
    {

        public DrinkHelper(int DrinkId, Drink drinkTable, List<DrinkIngridientsTable> drinkIngridients)
        {
            this.DrinkId = DrinkId;
            this.drinkTable = drinkTable;
            this.drinkIngridientsTable = drinkIngridients;
        }

        public int DrinkId;
        public Drink drinkTable;
        public List<DrinkIngridientsTable> drinkIngridientsTable = new List<DrinkIngridientsTable>();

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
