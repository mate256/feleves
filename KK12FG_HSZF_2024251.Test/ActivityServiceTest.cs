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
    using KK12FG_HSZF_2024251.Persistence.MsSql;
    using KK12FG_HSZF_2024251.Model;

    [TestFixture]
    public class ActivityServiceTests
    {
        private Mock<IActivityDataProvider> mockActivityDataProvider;
        private ActivityService activityService;

        [SetUp]
        public void SetUp()
        {
            mockActivityDataProvider = new Mock<IActivityDataProvider>();
            activityService = new ActivityService(mockActivityDataProvider.Object);
        }

        [Test]
        public void AddActivity_ShouldAddActivity_WhenActivityDoesNotExist()
        {
            // Arrange
            var newActivity = new Activity { Type = "New Activity" };
            mockActivityDataProvider.Setup(x => x.GetActivity()).Returns(new List<Activity>().AsEnumerable());

            // Act
            activityService.AddActivity(newActivity);

            // Assert
            mockActivityDataProvider.Verify(x => x.AddActivity(newActivity), Times.Once);
        }

        [Test]
        public void AddMultipleActivity_ShouldAddAllActivities()
        {
            // Arrange
            var activities = new List<Activity>
        {
            new Activity { Type = "Activity A" },
            new Activity { Type = "Activity B" }
        };
            mockActivityDataProvider.Setup(x => x.GetActivity()).Returns(new List<Activity>().AsEnumerable());

            // Act
            activityService.AddMultipleActivity(activities);

            // Assert
            mockActivityDataProvider.Verify(x => x.AddActivity(It.IsAny<Activity>()), Times.Exactly(activities.Count));
        }

        [Test]
        public void GetActivity_ShouldReturnAllActivities()
        {
            // Arrange
            var activities = new List<Activity>
        {
            new Activity { Type = "Activity A" },
            new Activity { Type = "Activity B" }
        };
            mockActivityDataProvider.Setup(x => x.GetActivity()).Returns(activities.AsEnumerable());

            // Act
            var result = activityService.GetActivity();

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Activity A", result.First().Type);
            Assert.AreEqual("Activity B", result.Last().Type);
        }
    }

}
