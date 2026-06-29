using System;

namespace SmartFactoryManagementSystem
{

	public abstract  class Product
	{
		//PROPRIETATI
		public string? Name { get; set; }
		decimal ProductionCost { get; set; }
		decimal SellingPrice { get; set; }
		int Quantity { get; set; }

		DateTime ProductionDate { get; set; }
		
		//Constructor

		public Product(string name, decimal productionCost, decimal sellingPrice, int quantity, DateTime productionDate)
		{
			Name = name;
			ProductionCost = productionCost;
			SellingPrice = sellingPrice;
			Quantity = quantity;
			ProductionDate = productionDate;
		}
		// METODE

		public decimal CalculateProfit(decimal ProductionCost, decimal SellingPrice)
		{
            decimal profit = 0;
            profit = SellingPrice - ProductionCost;

            return profit;
		}
		public virtual void Describe()
		{
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Production Cost: {ProductionCost}");
            Console.WriteLine($"Selling Price: {SellingPrice}");
            Console.WriteLine($"Quantity in Stock: {Quantity}");
            Console.WriteLine($"Production Date: {ProductionDate}");
            Console.WriteLine();
		}

        public abstract void AddStock();


        public abstract void RemoveStock();
		
		
	}

	internal  class UrsuletPlus : Product
	{
		//Constructor
		public UrsuletPlus(string name,
						decimal productioncost,
						decimal sellingPrice,
						int quantity,
						DateTime productionDate)
			:base(name, productioncost, sellingPrice, quantity, productionDate) 
		{
		}
        public override void Describe()
        {
            Console.WriteLine("---Laptop---");
            base.Describe();
        }

        public override void AddStock()
        { 

        }



        public override void RemoveStock()
        {

        }
    }

    internal class TrenLemn : Product
    {
        //Constructor
        public TrenLemn(string name,
                        decimal productioncost,
                        decimal sellingPrice,
                        int quantity,
                        DateTime productionDate)
            : base(name, productioncost, sellingPrice, quantity, productionDate)
        {
        }
        public override void Describe()
        {
            Console.WriteLine("---Telefon---");
            base.Describe();
        }
        public override void AddStock()
        {

        }



        public override void RemoveStock()
        {

        }
    }

    internal class  Papusa : Product
    {
        //Constructor
        public Papusa(string name,
                        decimal productioncost,
                        decimal sellingPrice,
                        int quantity,
                        DateTime productionDate)
            : base(name, productioncost, sellingPrice, quantity, productionDate)
        {
        }
        public override void AddStock()
        {

        }



        public override void RemoveStock()
        {

        }
    }
    internal class Minge : Product
    {
        //Constructor
        public Minge(string name,
                        decimal productioncost,
                        decimal sellingPrice,
                        int quantity,
                        DateTime productionDate)
            : base(name, productioncost, sellingPrice, quantity, productionDate)
        {
        }
        public override void AddStock()
        {

        }



        public override void RemoveStock()
        {

        }
        public override void Describe()
        {
            Console.WriteLine("---Casti---");
            base.Describe();
        }
    }

	internal  class Puzzle : Product
    {
        //Constructor
        public Puzzle(string name,
                        decimal productioncost,
                        decimal sellingPrice,
                        int quantity,
                        DateTime productionDate)
            : base(name, productioncost, sellingPrice, quantity, productionDate)
        {
        }
        public override void AddStock()
        {

        }



        public override void RemoveStock()
        {

        }
        public override void Describe()
        {
            Console.WriteLine("---Imprimanta---");
            base.Describe();
        }
    }
}