using KK12FG_HSZF_2024251.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK12FG_HSZF_2024251.Application
{
    public class Json
    {
        private readonly IAnimalService animalService;
        private readonly IActivityService activityService;
        private readonly IFoodService foodService;
        public Json(IAnimalService animalService, IActivityService activityService,IFoodService foodService)
        {
            this.animalService = animalService;
            this.activityService = activityService;
            this.foodService = foodService;
        }
        public void AddDataFromJson(string path = @"animal.json")
        {
            var items = JsonConvert
                .DeserializeObject<RootObject>(
                File.ReadAllText(path));



            foreach (var animal in items.Animals)
            {

                animalService.AddAnimal(animal);
                foreach (var food in animal.Foods)
                {
                    foodService.AddFood(food, food.Quantity);
                }
                foreach (var activity in animal.Activities)
                {
                    activity.AnimalId= animalService.GetAnimals().First(an => an.Name == animal.Name).AnimalId; 
                    activityService.AddActivity(activity);
                }
            }

            
        }
    }
}
