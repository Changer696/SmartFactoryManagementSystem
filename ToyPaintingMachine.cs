using System;

namespace SmartFactoryManagementSystem
{
    public class ToyPaintingMachine : Machine
    {
        public ToyPaintingMachine(string serialNumber, string name, DateTime installationDate)
            : base(serialNumber, name, installationDate)
        {
        }

        public override bool Produce(Product product, int quantity)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            if (quantity <= 0)
            {
                return false;
            }

            int currentQuantity = product.GetQuantity();
            product.SetQuantity(currentQuantity + quantity);
            return true;
        }

        public override string RunDiagnostics()
        {
            return "Toy painting machine diagnostics completed successfully.";
        }
    }
}
