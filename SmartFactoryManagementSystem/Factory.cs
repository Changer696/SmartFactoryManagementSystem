using SmartFactoryManagementSystem;
using System;

public class Factory
{
    public string? Name;
    // Composition: Factory contains products using an array.
    private Product[] _inventory;
    private int _uniqueProductCount; //Remebers how many diff types of products ive added

    public Factory(string name,int maxInventoryCapacity)
    {
        Name = name;
        _inventory = new Product[maxInventoryCapacity];
        _uniqueProductCount = 0;
    }

    // Method used after manufacturing is complete
    public void AddToInventory(Product newProduct)
    {
        if (_uniqueProductCount < _inventory.Length) //Checks if Inventory has space
        {
            _inventory[_uniqueProductCount] = newProduct;
            _uniqueProductCount++;
            Console.WriteLine($"{newProduct.Name} added to the factory inventory.");
        }
        else
        {
            Console.WriteLine("Inventory capacity reached!");
        }
    }

    // Method used by the SalesAgent class
    public bool ProcessSale(string productName, int amountToSell)
    {
        for (int i = 0; i < _uniqueProductCount; i++)
        {
            if (_inventory[i].Name == productName)
            {
                //  Rule 14: Cannot sell products not available in inventory.
                if (_inventory[i].Quantity >= amountToSell)
                {
                    //  Rule 15: Inventory quantity must decrease after successful sale.
                    _inventory[i].Quantity -= amountToSell;
                    Console.WriteLine($"Sold {amountToSell}x {productName}. Remaining stock: {_inventory[i].Quantity}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Sale failed: Only {_inventory[i].Quantity}x {productName} available.");
                    return false;
                }
            }
        }
        Console.WriteLine($"Sale failed: {productName} does not exist in inventory.");
        return false;
    }
    //Method used by Tehnician class


    public void Repair()
    {

    }
}