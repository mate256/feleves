using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK12FG_HSZF_2024251.Classes
{

    public class activity
    {
        public DateTime Date { get; set; } //Dátum
        public string Type { get; set; } //Típus
        public string Description { get; set; } //Megjegyzés

        //public Dictionary<string, int> FoodStock { get; set; } = new Dictionary<string, int>(); //ÁllatEledel(típus, mennyiség)
        //public List<Activity> Activities { get; set; } = new List<Activity>(); //Tevékenységek

        //public void Feed(string food, int amount)
        //{
        //    if (FoodStock.ContainsKey(food) && FoodStock[food] >= amount)
        //    {
        //        FoodStock[food] -= amount;
        //        Activities.Add(new Activity { Type = "Feeding", Date = DateTime.Now, Description = $"{amount} units of {food} fed" });
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Insufficient {food} stock.");
        //    }
        //}
    }

}
