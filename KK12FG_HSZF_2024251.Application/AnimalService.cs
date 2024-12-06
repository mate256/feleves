using KK12FG_HSZF_2024251.Model;
using KK12FG_HSZF_2024251.Persistence.MsSql;

namespace KK12FG_HSZF_2024251.Application
{
    public interface IAnimalService
    {
        IEnumerable<Animal> GetAnimals();
        void AddAnimal(Animal animal);
        void UpdateAnimal(Animal animal);
        void RemoveAnimal(Animal animal);
        void AddMultipleAnimal(IEnumerable<Animal> animals);
    }
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalDataProvider animalDataProvider;
        public AnimalService(IAnimalDataProvider animalDataProvider)
        {
            this.animalDataProvider = animalDataProvider;
        }

        public void AddAnimal(Animal newAnimal)
        {
            var animal = animalDataProvider.GetAnimals().FirstOrDefault(t => t.Name == newAnimal.Name);
            if (animal == null)
            {
                animalDataProvider.AddAnimal(newAnimal);
            }
        }

        public void AddMultipleAnimal(IEnumerable<Animal> animals)
        {
            foreach (var item in animals)
            {
                AddAnimal(item);
            }
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return animalDataProvider.GetAnimals();
        }

        public void RemoveAnimal(Animal animal)
        {
            animalDataProvider.RemoveAnimal(animal);
        }

        public void UpdateAnimal(Animal animal)
        {
            animalDataProvider.UpdateAnimal(animal);
        }
    }
}
