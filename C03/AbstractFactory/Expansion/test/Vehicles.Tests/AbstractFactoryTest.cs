using System;
using Vehicles.Models;
using Xunit;

namespace Vehicles.Tests
{
    // Arrange
    public class AbstractFactoryTestCars : AbstractFactoryBaseTestData
    {
        public AbstractFactoryTestCars()
        {
            AddTestData<LowGradeVehicleFactory, LowGradeCar>();
            AddTestData<HighGradeVehicleFactory, HighGradeCar>();
            AddTestData<MiddleEndVehicleFactory, MiddleGradeCar>();
        }
    }

    public class AbstractFactoryTestBikes : AbstractFactoryBaseTestData
    {
        public AbstractFactoryTestBikes()
        {
            AddTestData<LowGradeVehicleFactory, LowGradeBike>();
            AddTestData<HighGradeVehicleFactory, HighGradeBike>();
            AddTestData<MiddleEndVehicleFactory, MiddleGradeBike>();
        }
    }

    // Tests
    public class AbstractFactory
    {
        [Theory]
        [ClassData(typeof(AbstractFactoryTestCars))]
        public void Should_create_a_Car_of_the_specified_type(IVehicleFactory vehicleFactory, Type expectedCarType)
        {
            // Act
            var result = vehicleFactory.CreateCar();

            // Assert
            Assert.IsType(expectedCarType, result);
        }

        [Theory]
        [ClassData(typeof(AbstractFactoryTestBikes))]
        public void Should_create_a_Bike_of_the_specified_type(IVehicleFactory vehicleFactory, Type expectedBikeType)
        {
            // Act
            var result = vehicleFactory.CreateBike();

            // Assert
            Assert.IsType(expectedBikeType, result);
        }
    }
}
