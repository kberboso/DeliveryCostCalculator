using DeliveryCostCalculator.Business.Entities;

namespace DeliveryCostCalculator.Business
{
    public interface IDeliveryCalculatorBusiness
    {
        DeliveryCostInformationEntity CalculateDelivery(PackageSpecificationEntity packageSpecification);
        int PackageVolume(int length, int width, int height);

    }
}
