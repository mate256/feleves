using KK12FG_HSZF_2024251.Model;
using KK12FG_HSZF_2024251.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK12FG_HSZF_2024251.Application
{
    public interface IFoodService
    {
        IEnumerable<Food> GetFoods();
        void AddFood(Food Food,int quantity);
        void UpdateFood(string animalId, int quantity);
        void RemoveFood(Food Food);
        void AddMultipleFood(IEnumerable<Food> foods);
    }
    public class FoodService : IFoodService
    {
        private readonly IFoodDataProvider FoodDataProvider;
        public FoodService(IFoodDataProvider FoodDataProvider)
        {
            this.FoodDataProvider = FoodDataProvider;
        }

        public void AddFood(Food newFood, int quantity)
        {
            var food = FoodDataProvider.GetFoods().FirstOrDefault(t => t.Name == newFood.Name);
            if (food == null)
            {
                FoodDataProvider.AddFood(newFood);
            }
            else
            {
                food.Quantity += quantity;
            }
            
        }

        public void AddMultipleFood(IEnumerable<Food> foods)
        {
            foreach (var item in foods)
            {
                AddFood(item,item.Quantity);
            }
        }

        public IEnumerable<Food> GetFoods()
        {
            return FoodDataProvider.GetFoods();
        }

        public void RemoveFood(Food Food)
        {
            throw new NotImplementedException();
        }

        public void UpdateFood(string animalId, int quantity)
        {
            //animalId = quantity;
        }
    }
}
