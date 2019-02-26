using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShakeIt.Models
{
    public class DrinkHelper
    {
        public int DHId { get; set; }
        public Drink DHDrink { get; set; }
        public List<DrinkIngridientsHelper> DHDIHelper { get; set; } = new List<DrinkIngridientsHelper>();
        public DrinkIngridientsHelper drinkIngridientsHelper { get; set; }
        //public List<DrinkIngridients> DHDrinkIngrid { get; set; }



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
