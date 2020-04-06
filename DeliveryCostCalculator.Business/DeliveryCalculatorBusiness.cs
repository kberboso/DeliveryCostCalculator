using DeliveryCostCalculator.Business.Entities;
using DeliveryCostCalculator.Business.Enums;

namespace DeliveryCostCalculator.Business
{
    public class DeliveryCalculatorBusiness : IDeliveryCalculatorBusiness
    {
        public DeliveryCostInformationEntity CalculateDelivery(PackageSpecificationEntity packageSpecification)
        {
            DeliveryCostInformationEntity result = new DeliveryCostInformationEntity();

            var packageVolume = PackageVolume(packageSpecification.Length, packageSpecification.Width, packageSpecification.Height);

            if(packageSpecification.Weight > 25)
            {
                result.PackageCategory = PackageCategoryEnum.Reject;
                result.DeliveryCost = 0;
            }
            else if(packageSpecification.Weight > 10)
            {
                result.PackageCategory = PackageCategoryEnum.HeavyPackage;
                result.DeliveryCost = packageSpecification.Weight * 15;
            }
            else if (packageVolume < 1500)
            {
                result.PackageCategory = PackageCategoryEnum.SmallPackage;
                result.DeliveryCost = packageVolume * .05;
            }
            else if (packageVolume < 2500)
            {
                result.PackageCategory = PackageCategoryEnum.MediumPackage;
                result.DeliveryCost = packageVolume * .04;
            }
            else
            {
                result.PackageCategory = PackageCategoryEnum.LargePackage;
                result.DeliveryCost = packageVolume * .03;
            }

            result.PackageSpecification = packageSpecification;

            return result;
        }

        public int PackageVolume(int length, int width, int height)
        {
            return length * width * height;
        }
    }
}
