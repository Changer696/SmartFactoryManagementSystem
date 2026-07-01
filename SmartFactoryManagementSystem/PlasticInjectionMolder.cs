using System;

namespace SmartFactoryManagementSystem
{
    public class PlasticInjectionMolder : Machine
    {
        public PlasticInjectionMolder(string serialNumber, string name, DateTime installationDate)
            : base(serialNumber, name, installationDate)
        {
        }

        public override bool Produce(Product product, int quantity)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            if (!ConsumeMaterialsForProduction(quantity))
            {
                return false;
            }

            int currentQuantity = product.GetQuantity();
            product.SetQuantity(currentQuantity + quantity);
            return true;
        }

        public override string RunDiagnostics()
        {
            return "Plastic injection molder diagnostics completed successfully.";
        }
    }
}
