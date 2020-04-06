using DeliveryCostCalculator.Business;
using DeliveryCostCalculator.Business.Entities;
using DeliveryCostCalculator.Business.Enums;
using System;

namespace DeliveryCostCalculator
{
    class Program
    {
        private static IDeliveryCalculatorBusiness manager;

        static void Main(string[] args)
        {
            manager = new DeliveryCalculatorBusiness();

            int weight, height, width, length; 

            Console.WriteLine("Welcome to Delivery Cost Calculator App!");
            Console.WriteLine("Please input package specifications.");

            weight = ReadUserInput("Weight (KG): ");
            height = ReadUserInput("Height (CM): ");
            width = ReadUserInput("Width (CM): ");
            length = ReadUserInput("Length (CM): ");

            PackageSpecificationEntity entity = new PackageSpecificationEntity()
            {
                Weight = weight,
                Length = length,
                Width = width,
                Height = height
            };

            var result = manager.CalculateDelivery(entity);

            PrintResult(result);

            Console.ReadLine();

        }

        private static void PrintResult(DeliveryCostInformationEntity entity)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Delivery Cost Information");
            Console.WriteLine("Weight (KG): {0}", entity.PackageSpecification.Weight.ToString());
            Console.WriteLine("Height (CM): {0}", entity.PackageSpecification.Height.ToString());
            Console.WriteLine("Width (CM): {0}", entity.PackageSpecification.Width.ToString());
            Console.WriteLine("Length (CM): {0}", entity.PackageSpecification.Length.ToString());
            Console.WriteLine("Category: {0}", entity.PackageCategory);
            Console.WriteLine("Cost: {0}", entity.PackageCategory.Equals(PackageCategoryEnum.Reject) ? "N/A" : "$" + entity.DeliveryCost.ToString("0.00"));
        }

        private static int ReadUserInput(string label)
        {
            int number;
            int result = 0;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write(label);
                var input = Console.ReadLine();

                if (!Int32.TryParse(input, out number))
                {
                    Console.WriteLine(">>Please input a valid integer.");
                }
                else if(Int32.Parse(input) <= 0)
                {
                    Console.WriteLine(">>Please input an integer greater than zero.");
                }
                else
                {
                    result = Int32.Parse(input);
                    isValid = true;
                }
            }

            return result;
        }
    }
}
