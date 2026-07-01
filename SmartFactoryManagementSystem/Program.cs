namespace SmartFactoryManagementSystem
    
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Factory toyFactory = new Factory("KABOOM",100);

            // 2. Creăm un produs (folosind clasa ta CuburiLemn) și îl adăugăm în fabrică
            CuburiLemn cuburi = new CuburiLemn("Cuburi Magice", 15.5m, 35.0m, 5, DateTime.Now);
            toyFactory.AddToInventory(cuburi);

            // 3. Creăm agentul de vânzări
            SalesAgent agent = new SalesAgent("A01", "Stefi", DateTime.Now, "Sales Agent", 8);
            */
            //EXEMPLU





            bool exit = false;
            while (!exit)

            {

                Console.WriteLine("====SMART FACTORY MANAGEMENT SYSTEM====");

                Console.WriteLine();

                Console.WriteLine("1.Employee Management");

                Console.WriteLine("2.Product Maganement");

                Console.WriteLine("3.Machine Management");

                Console.WriteLine("4.Production Overflow");

                Console.WriteLine("5.Reports");

                Console.WriteLine("6.Factory information");

                Console.WriteLine();

                Console.WriteLine("0.Exit");

            }
        }
    }
}
