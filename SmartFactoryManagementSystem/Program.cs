using System;
using System.Collections.Generic;

namespace SmartFactoryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int op;
            bool exit = false;
            var machines = new List<Machine>();
            var products = new List<Product>();

            while (!exit)
            {
                Console.WriteLine("====SMART FACTORY MANAGEMENT SYSTEM====");
                Console.WriteLine();
                Console.WriteLine("1.Employee Management");
                Console.WriteLine("2.Product Management");
                Console.WriteLine("3.Machine Management");
                Console.WriteLine("4.Production Overflow");
                Console.WriteLine("5.Reports");
                Console.WriteLine("6.Factory information");
                Console.WriteLine();
                Console.WriteLine("0.Exit");

                op = ReadChoice(0, 6);

                switch (op)
                {
                    case 1:
                        Console.WriteLine("Employee Management is not implemented yet.");
                        break;
                    case 2:
                        ShowProductManagementMenu(products);
                        break;
                    case 3:
                        ShowMachineManagementMenu(machines);
                        break;
                    case 4:
                        Console.WriteLine("Production Overflow is not implemented yet.");
                        break;
                    case 5:
                        Console.WriteLine("Reports are not implemented yet.");
                        break;
                    case 6:
                        Console.WriteLine("Factory information is not implemented yet.");
                        break;
                    case 0:
                        exit = true;
                        Console.WriteLine("Goodbye!");
                        break;
                }

                Console.WriteLine();
            }

            static int ReadChoice(int min, int max)
            {
                Console.WriteLine("Enter your choice: ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max)
                {
                    Console.WriteLine($"Invalid input. Please enter a valid number between {min} and {max}.");
                }

                return choice;
            }

            static int ReadInt(string prompt, int min = 0)
            {
                while (true)
                {
                    Console.Write(prompt);
                    if (int.TryParse(Console.ReadLine(), out int value) && value >= min)
                    {
                        return value;
                    }

                    Console.WriteLine("Invalid number. Please try again.");
                }
            }

            static decimal ReadDecimal(string prompt)
            {
                while (true)
                {
                    Console.Write(prompt);
                    if (decimal.TryParse(Console.ReadLine(), out decimal value) && value >= 0)
                    {
                        return value;
                    }

                    Console.WriteLine("Invalid amount. Please try again.");
                }
            }

            static DateTime ReadDate(string prompt)
            {
                while (true)
                {
                    Console.Write(prompt);
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime value))
                    {
                        return value;
                    }

                    Console.WriteLine("Invalid date. Please try again.");
                }
            }

            static void ShowProductManagementMenu(List<Product> products)
            {
                while (true)
                {
                    Console.WriteLine("=== PRODUCT MANAGEMENT ===");
                    Console.WriteLine("1. Produce product");
                    Console.WriteLine("2. Search inventory");
                    Console.WriteLine("3. Calculate values");
                    Console.WriteLine("0. Back");

                    int choice = ReadChoice(0, 3);

                    switch (choice)
                    {
                        case 1:
                            ProduceProduct(products);
                            break;
                        case 2:
                            SearchInventory(products);
                            break;
                        case 3:
                            CalculateValues(products);
                            break;
                        case 0:
                            return;
                    }

                    Console.WriteLine();
                }
            }

            static void ProduceProduct(List<Product> products)
            {
                Console.WriteLine("Select product type:");
                Console.WriteLine("1. Ursulet Plus");
                Console.WriteLine("2. Cuburi Lemn");
                Console.WriteLine("3. Papusa");
                Console.WriteLine("4. Minge");
                Console.WriteLine("5. Frisbee");
                int typeChoice = ReadChoice(1, 5);

                Console.Write("Enter product name: ");
                string name = Console.ReadLine() ?? string.Empty;
                decimal productionCost = ReadDecimal("Enter production cost: ");
                decimal sellingPrice = ReadDecimal("Enter selling price: ");
                int quantity = ReadInt("Enter produced quantity: ", 1);
                DateTime productionDate = ReadDate("Enter production date (dd/mm/yyyy): ");

                Product product = typeChoice switch
                {
                    1 => new UrsuletPlus(name, productionCost, sellingPrice, quantity, productionDate),
                    2 => new CuburiLemn(name, productionCost, sellingPrice, quantity, productionDate),
                    3 => new Papusa(name, productionCost, sellingPrice, quantity, productionDate),
                    4 => new Minge(name, productionCost, sellingPrice, quantity, productionDate),
                    _ => new Frisbee(name, productionCost, sellingPrice, quantity, productionDate)
                };

                products.Add(product);
                Console.WriteLine($"Produced {quantity} units of {product.Name}.");
            }

            static void SearchInventory(List<Product> products)
            {
                Console.Write("Enter product name to search: ");
                string searchTerm = Console.ReadLine() ?? string.Empty;

                bool found = false;
                foreach (var product in products)
                {
                    if (product.Name != null && product.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    {
                        product.Describe();
                        found = true;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("No matching products found.");
                }
            }

            static void CalculateValues(List<Product> products)
            {
                if (products.Count == 0)
                {
                    Console.WriteLine("No products in inventory.");
                    return;
                }

                decimal totalStockValue = 0;
                decimal totalProfit = 0;

                foreach (var product in products)
                {
                    totalStockValue += product.Quantity * product.SellingPrice;
                    totalProfit += product.Quantity * (product.SellingPrice - product.ProductionCost);
                }

                Console.WriteLine($"Total stock value: {totalStockValue:C}");
                Console.WriteLine($"Total expected profit: {totalProfit:C}");
            }

            static void ShowMachineManagementMenu(List<Machine> machines)
            {
                while (true)
                {
                    Console.WriteLine("=== MACHINE MANAGEMENT ===");
                    Console.WriteLine("1. Add machine");
                    Console.WriteLine("2. Start machine");
                    Console.WriteLine("3. Stop machine");
                    Console.WriteLine("4. Inspect machine");
                    Console.WriteLine("5. Repair machine");
                    Console.WriteLine("6. Run diagnostics");
                    Console.WriteLine("0. Back");

                    int choice = ReadChoice(0, 6);

                    switch (choice)
                    {
                        case 1:
                            AddMachine(machines);
                            break;
                        case 2:
                            StartMachine(machines);
                            break;
                        case 3:
                            StopMachine(machines);
                            break;
                        case 4:
                            InspectMachine(machines);
                            break;
                        case 5:
                            RepairMachine(machines);
                            break;
                        case 6:
                            RunDiagnosticsOnMachine(machines);
                            break;
                        case 0:
                            return;
                    }

                    Console.WriteLine();
                }
            }

            static void AddMachine(List<Machine> machines)
            {
                Console.WriteLine("Select machine type:");
                Console.WriteLine("1. Assembly Robot");
                Console.WriteLine("2. Plastic Injection Molder");
                int typeChoice = ReadChoice(1, 2);

                Console.Write("Enter serial number: ");
                string serialNumber = Console.ReadLine() ?? string.Empty;
                Console.Write("Enter machine name: ");
                string name = Console.ReadLine() ?? string.Empty;

                try
                {
                    Machine machine = typeChoice switch
                    {
                        1 => new AssemblyRobot(serialNumber, name, DateTime.Now),
                        _ => new PlasticInjectionMolder(serialNumber, name, DateTime.Now)
                    };

                    machines.Add(machine);
                    Console.WriteLine($"Added machine: {machine.GetName()} ({machine.GetSerialNumber()})");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Could not add machine: {ex.Message}");
                }
            }

            static Machine? SelectMachine(List<Machine> machines)
            {
                if (machines.Count == 0)
                {
                    Console.WriteLine("No machines available.");
                    return null;
                }

                Console.WriteLine("Available machines:");
                for (int i = 0; i < machines.Count; i++)
                {
                    var machine = machines[i];
                    Console.WriteLine($"{i + 1}. {machine.GetName()} [{machine.GetSerialNumber()}] - Status: {machine.GetStatus()}");
                }

                int index = ReadChoice(1, machines.Count);
                return machines[index - 1];
            }

            static void StartMachine(List<Machine> machines)
            {
                var machine = SelectMachine(machines);
                if (machine is null) return;
                machine.Start();
                Console.WriteLine($"{machine.GetName()} started.");
            }

            static void StopMachine(List<Machine> machines)
            {
                var machine = SelectMachine(machines);
                if (machine is null) return;
                machine.Stop();
                Console.WriteLine($"{machine.GetName()} stopped.");
            }

            static void InspectMachine(List<Machine> machines)
            {
                var machine = SelectMachine(machines);
                if (machine is null) return;
                machine.Inspect();

                var materials = new List<string>();
                foreach (var part in machine.GetParts())
                {
                    materials.Add(part.GetMaterial().ToString());
                }

                Console.WriteLine($"{machine.GetName()} inspected. Status: {machine.GetStatus()}, Condition: {machine.GetCondition()}");
                Console.WriteLine($"Materials used: {string.Join(", ", materials)}");
            }

            static void RepairMachine(List<Machine> machines)
            {
                var machine = SelectMachine(machines);
                if (machine is null) return;
                machine.Repair();
                Console.WriteLine($"{machine.GetName()} repaired.");
            }

            static void RunDiagnosticsOnMachine(List<Machine> machines)
            {
                var machine = SelectMachine(machines);
                if (machine is null) return;
                Console.WriteLine(machine.RunDiagnostics());
            }
        }
    }
}
