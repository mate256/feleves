using KK12FG_HSZF_2024251.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KK12FG_HSZF_2024251.Persistence.MsSql
{
    public interface IFoodDataProvider
    {
        public IEnumerable<Food> GetFoods();
        public void AddFood(Food Food);
        public void UpdateFood(Food food);
        public void RemoveFood(Food Food);
    }
    public class FoodDataProvider : IFoodDataProvider
    {
        private readonly PetRegistrationDbContext ctx;
        public FoodDataProvider(PetRegistrationDbContext context)
        {
            ctx = context;
        }

        public void AddFood(Food Food)
        {
            ctx.Add(Food);
            ctx.SaveChanges();
        }

        public IEnumerable<Food> GetFoods()
        {
            return ctx.Foods.Include(a => a.Animals).ToHashSet();
        }

        public void RemoveFood(Food Food)
        {
            ctx.Remove(Food);
            ctx.SaveChanges();
        }

        public void UpdateFood(Food food)
        {
            var foodToUpdate = ctx.Foods.First(t => t.FoodId == food.FoodId);
            foodToUpdate.Name = food.Name;
            foodToUpdate.Quantity = food.Quantity;
            ctx.Foods.Update(foodToUpdate);
            ctx.SaveChanges();
        }
    }
}
