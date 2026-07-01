using System;

namespace SmartFactoryManagementSystem
{
    public class AssemblyRobot : Machine
    {
        public AssemblyRobot(string serialNumber, string name, DateTime installationDate)
            : base(serialNumber, name, installationDate)
        {
        }

<<<<<<< HEAD
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
=======
        
        
>>>>>>> d9f28c1756a410b8bf0ed1bd24194e0f13403068

            int currentQuantity = product.GetQuantity();
            product.SetQuantity(currentQuantity + quantity);
            return true;
        }

        public override string RunDiagnostics()
        {
            return "Assembly robot diagnostics completed successfully.";
        }
    }
}
