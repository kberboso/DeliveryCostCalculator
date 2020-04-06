using DeliveryCostCalculator.Business;
using DeliveryCostCalculator.Business.Entities;
using DeliveryCostCalculator.Business.Enums;
using NUnit.Framework;

namespace DeliveryCostCalculator.Test
{
    [TestFixture]
    public class DeliveryCalculatorBusinessTest
    {
        private IDeliveryCalculatorBusiness manager;

        [SetUp]
        public void Setup()
        {
            manager = new DeliveryCalculatorBusiness();
        }

        [TestCase(10, 10, 10, 20)]
        public void CalculateDelivery_ValidIntegers_MediumPackage(int weight, int height, int width, int length)
        {
            PackageSpecificationEntity entity = new PackageSpecificationEntity(){ 
                Weight = weight,
                Length = length,
                Width = width,
                Height = height
            };

            var result = manager.CalculateDelivery(entity);

            Assert.AreEqual(result.PackageCategory, PackageCategoryEnum.MediumPackage);
        }

        [TestCase(22, 5, 5, 5)]
        public void CalculateDelivery_ValidIntegers_HeavyPackage(int weight, int height, int width, int length)
        {
            PackageSpecificationEntity entity = new PackageSpecificationEntity()
            {
                Weight = weight,
                Length = length,
                Width = width,
                Height = height
            };

            var result = manager.CalculateDelivery(entity);

            Assert.AreEqual(result.PackageCategory, PackageCategoryEnum.HeavyPackage);
        }

        [TestCase(2, 3, 10, 12)]
        public void CalculateDelivery_ValidIntegers_SmallPackage(int weight, int height, int width, int length)
        {
            PackageSpecificationEntity entity = new PackageSpecificationEntity()
            {
                Weight = weight,
                Length = length,
                Width = width,
                Height = height
            };

            var result = manager.CalculateDelivery(entity);

            Assert.AreEqual(result.PackageCategory, PackageCategoryEnum.SmallPackage);
        }

        [TestCase(110, 20, 55, 120)]
        public void CalculateDelivery_ValidIntegers_RejectPackage(int weight, int height, int width, int length)
        {
            PackageSpecificationEntity entity = new PackageSpecificationEntity()
            {
                Weight = weight,
                Length = length,
                Width = width,
                Height = height
            };

            var result = manager.CalculateDelivery(entity);

            Assert.AreEqual(result.PackageCategory, PackageCategoryEnum.Reject);
        }
    }
}
