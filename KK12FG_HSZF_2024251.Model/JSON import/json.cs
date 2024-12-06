using KK12FG_HSZF_2024251.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK12FG_HSZF_2024251.Model.JSON_import
{
    public static class json<T>
    {
        //List<Animal>? animals = JsonConvert.DeserializeObject<List<Animal>>(File.ReadAllText("animal.json"));
        //List<Activity>? activitis = JsonConvert.DeserializeObject<List<Activity>>(File.ReadAllText("activity.json"));
        //List<Food>? foods = JsonConvert.DeserializeObject<List<Food>>(File.ReadAllText("food.json"));
        public static IEnumerable<T> ReturnValuesFromJson(string fileName)
        {
            return JsonConvert.DeserializeObject<IEnumerable<T>>(File.ReadAllText(fileName));
        }
    }
}
