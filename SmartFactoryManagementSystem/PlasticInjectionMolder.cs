using System;

namespace SmartFactoryManagementSystem
{
    public class PlasticInjectionMolder : Machine
    {
        public PlasticInjectionMolder(string serialNumber, string name, DateTime installationDate)
            : base(serialNumber, name, installationDate)
        {
        }

        
        

        public override string RunDiagnostics()
        {
            return "Plastic injection molder diagnostics completed successfully.";
        }
    }
}
