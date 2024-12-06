using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK12FG_HSZF_2024251.Test
{
    using NUnit.Framework;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using KK12FG_HSZF_2024251.Application;
    using KK12FG_HSZF_2024251.Model;
    using KK12FG_HSZF_2024251.Persistence.MsSql;

    [TestFixture]
    public class FoodServiceTests
    {
        private Mock<IFoodDataProvider> mockFoodDataProvider;
        private FoodService foodService;

        [SetUp]
        public void SetUp()
        {
            mockFoodDataProvider = new Mock<IFoodDataProvider>();
            foodService = new FoodService(mockFoodDataProvider.Object);
        }

        [Test]
        public void AddFood_ShouldAddFood_WhenFoodDoesNotExist()
        {
            // Arrange
            var newFood = new Food { Name = "New Food", Quantity = 5 };
            mockFoodDataProvider.Setup(x => x.GetFoods()).Returns(new List<Food>().AsEnumerable());

            // Act
            foodService.AddFood(newFood, newFood.Quantity);

            // Assert
            mockFoodDataProvider.Verify(x => x.AddFood(newFood), Times.Once);
        }

        [Test]
        public void AddMultipleFood_ShouldAddAllFoods()
        {
            // Arrange
            var foods = new List<Food>
        {
            new Food { Name = "Food A", Quantity = 10 },
            new Food { Name = "Food B", Quantity = 20 }
        };
            mockFoodDataProvider.Setup(x => x.GetFoods()).Returns(new List<Food>().AsEnumerable());

            // Act
            foodService.AddMultipleFood(foods);

            // Assert
            mockFoodDataProvider.Verify(x => x.AddFood(It.IsAny<Food>()), Times.Exactly(foods.Count));
        }

        [Test]
        public void GetFoods_ShouldReturnAllFoods()
        {
            // Arrange
            var foods = new List<Food>
        {
            new Food { Name = "Food A", Quantity = 10 },
            new Food { Name = "Food B", Quantity = 20 }
        };
            mockFoodDataProvider.Setup(x => x.GetFoods()).Returns(foods.AsEnumerable());

            // Act
            var result = foodService.GetFoods();

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Food A", result.First().Name);
            Assert.AreEqual("Food B", result.Last().Name);
        }
    }

}
