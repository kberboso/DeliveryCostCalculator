using DeliveryCostCalculator.Business.Enums;

namespace DeliveryCostCalculator.Business.Entities
{
    public class DeliveryCostInformationEntity : BaseEntity
    {
        public PackageSpecificationEntity PackageSpecification { get; set; }
        public PackageCategoryEnum PackageCategory { get; set; }
        public double DeliveryCost { get; set; }
    }
}
