using System;

namespace SmartFactoryManagementSystem
{
    public class AssemblyRobot : Machine
    {
        public AssemblyRobot(string serialNumber, string name, DateTime installationDate)
            : base(serialNumber, name, installationDate)
        {
        }

        
        

        

        public override string RunDiagnostics()
        {
            return "Assembly robot diagnostics completed successfully.";
        }
    }
}
