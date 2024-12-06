namespace KK12FG_HSZF_2024251.Test;

using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Linq;
using KK12FG_HSZF_2024251.Application;
using KK12FG_HSZF_2024251.Persistence.MsSql;
using KK12FG_HSZF_2024251.Model;

[TestFixture]
public class AnimalServiceTests
{
    private Mock<IAnimalDataProvider> mockAnimalDataProvider;
    private AnimalService animalService;

    [SetUp]
    public void SetUp()
    {
        mockAnimalDataProvider = new Mock<IAnimalDataProvider>();
        animalService = new AnimalService(mockAnimalDataProvider.Object);
    }

    [Test]
    public void AddAnimal_ShouldAddAnimal_WhenAnimalDoesNotExist()
    {
        // Arrange
        var newAnimal = new Animal { Name = "New Animal" };
        mockAnimalDataProvider.Setup(x => x.GetAnimals()).Returns(new List<Animal>().AsEnumerable());

        // Act
        animalService.AddAnimal(newAnimal);

        // Assert
        mockAnimalDataProvider.Verify(x => x.AddAnimal(newAnimal), Times.Once);
    }

    [Test]
    public void AddMultipleAnimal_ShouldAddAllAnimals()
    {
        // Arrange
        var animals = new List<Animal>
        {
            new Animal { Name = "Animal A" },
            new Animal { Name = "Animal B" }
        };
        mockAnimalDataProvider.Setup(x => x.GetAnimals()).Returns(new List<Animal>().AsEnumerable());

        // Act
        animalService.AddMultipleAnimal(animals);

        // Assert
        mockAnimalDataProvider.Verify(x => x.AddAnimal(It.IsAny<Animal>()), Times.Exactly(animals.Count));
    }

    [Test]
    public void GetAnimals_ShouldReturnAllAnimals()
    {
        // Arrange
        var animals = new List<Animal>
        {
            new Animal { Name = "Animal A" },
            new Animal { Name = "Animal B" }
        };
        mockAnimalDataProvider.Setup(x => x.GetAnimals()).Returns(animals.AsEnumerable());

        // Act
        var result = animalService.GetAnimals();

        // Assert
        Assert.AreEqual(2, result.Count());
        Assert.AreEqual("Animal A", result.First().Name);
        Assert.AreEqual("Animal B", result.Last().Name);
    }

    [Test]
    public void RemoveAnimal_ShouldRemoveAnimal()
    {
        // Arrange
        var animal = new Animal { Name = "Animal A" };

        // Act
        animalService.RemoveAnimal(animal);

        // Assert
        mockAnimalDataProvider.Verify(x => x.RemoveAnimal(animal), Times.Once);
    }

    [Test]
    public void UpdateAnimal_ShouldUpdateAnimalDetails()
    {
        // Arrange
        var animal = new Animal { Name = "Updated Animal" };

        // Act
        animalService.UpdateAnimal(animal);

        // Assert
        mockAnimalDataProvider.Verify(x => x.UpdateAnimal(animal), Times.Once);
    }
}
