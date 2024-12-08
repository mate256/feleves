using KK12FG_HSZF_2024251.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KK12FG_HSZF_2024251.Persistence.MsSql
{
    public interface IAnimalDataProvider
    {
        public IEnumerable<Animal> GetAnimals();
        public Animal AddAnimal(Animal animal);
        public void UpdateAnimal(Animal animal);
        public void RemoveAnimal(Animal animal);
    }
    
    public class AnimalDataProvider : IAnimalDataProvider
    {
        private readonly PetRegistrationDbContext ctx;
        public AnimalDataProvider(PetRegistrationDbContext context)
        {
            ctx = context;
        }

        public Animal AddAnimal(Animal animal)
        {
            ctx.Animals.Add(animal);
            ctx.SaveChanges();
            return animal;
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return ctx.Animals
                .Include(t => t.Activities)
                .Include(t => t.Foods).ToHashSet();
        }

        public void RemoveAnimal(Animal animal)
        {
            ctx.Animals.Remove(animal);
            ctx.SaveChanges();
        }

        public void UpdateAnimal(Animal animal)
        {
            var animalToUpdate = ctx.Animals.First(t => t.AnimalId == animal.AnimalId);
            animalToUpdate.Name = animal.Name;
            animalToUpdate.Gender = animal.Gender;
            animalToUpdate.Species = animal.Species;
            animalToUpdate.Age = animal.Age;
            ctx.Animals.Update(animalToUpdate);
            ctx.SaveChanges();
        }
    }
}
