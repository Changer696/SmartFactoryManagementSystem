using System;

namespace SmartFactoryManagementSystem
{
    public enum ProductCategory
    {
        OutdoorToys,
        EducationalToys,
        PretendToys

    }

	public abstract  class Product
	{
        //PROPRIETATI
        private decimal productionCost;
        private decimal sellingPrice;
        private int quantity;

        public string? Name { get; set; }
		public ProductCategory Category { get; set; }
    
		 public DateTime ProductionDate { get; set; }

        public decimal ProductionCost
        {
            get { return productionCost; }
            set
            {
                if (value < 0) throw new ArgumentException("Costul de producție nu poate fi negativ."); 
                productionCost = value;
            }
        }

        public decimal SellingPrice
        {
            get { return sellingPrice; }
            set
            {
                if (value < 0) throw new ArgumentException("Prețul de vânzare nu poate fi negativ."); 
                sellingPrice = value;
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0) throw new ArgumentException("Cantitatea nu poate fi negativă."); 
                quantity = value;
            }
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public void SetQuantity(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Cantitatea nu poate fi negativă.");
            }

            quantity = value;
        }
        //Constructor

        public Product(string name, ProductCategory category, decimal productionCost, decimal sellingPrice, int quantity, DateTime productionDate)
        {
            Name = name;
            Category = category;
            ProductionCost = productionCost; 
            SellingPrice = sellingPrice;
            Quantity = quantity;
            ProductionDate = productionDate;
        }
        // METODE

        public decimal CalculateProfit()
		{
            
            return SellingPrice - ProductionCost;
 
		}
		public virtual void Describe()
		{
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Category: {Category}");
            Console.WriteLine($"Production Cost: {ProductionCost:C}");
            Console.WriteLine($"Selling Price: {SellingPrice:C}");
            Console.WriteLine($"Profit: {CalculateProfit():C}");
            Console.WriteLine($"Quantity in Stock: {Quantity}");
            Console.WriteLine($"Production Date: {ProductionDate}");
            Console.WriteLine();
		}

       /* public void AddStock(int amount)
        {
            if (amount > 0)
            {
                Quantity += amount;
            }
        }

        public  void RemoveStock(int amount)
        {
            if(amount > 0 && (Quantity - amount) >= 0)
            {
                Quantity -= amount;
            }
        }
		*/
		
	}

	internal  class UrsuletPlus : Product
	{
		//Constructor
		public UrsuletPlus(string name,
						decimal productioncost,
						decimal sellingPrice,
						int quantity,
						DateTime productionDate)
			:base(name,ProductCategory.PretendToys, productioncost, sellingPrice, quantity, productionDate) 
		{
		}
        public override void Describe()
        {
            Console.WriteLine("---Ursulet de Plus---");
            base.Describe();
        }

    }

    internal class CuburiLemn : Product
    {
        //Constructor
        public CuburiLemn(string name,
                        decimal productioncost,
                        decimal sellingPrice,
                        int quantity,
                        DateTime productionDate)
            : base(name,ProductCategory.EducationalToys, productioncost, sellingPrice, quantity, productionDate)
        {
        }
        public override void Describe()
        {
            Console.WriteLine("---Cuburi de Lemn---");
            base.Describe();
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
            : base(name,ProductCategory.PretendToys, productioncost, sellingPrice, quantity, productionDate)
        {
        }
       
        public override void Describe()
        {
            Console.WriteLine("---Papusa---");
            base.Describe();
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
            : base(name,ProductCategory.OutdoorToys, productioncost, sellingPrice, quantity, productionDate)
        {
        }
        
        public override void Describe()
        {
            Console.WriteLine("---Minge---");
            base.Describe();
        }
    }

	internal  class Frisbee : Product
    {
        //Constructor
        public Frisbee(string name,
                        decimal productioncost,
                        decimal sellingPrice,
                        int quantity,
                        DateTime productionDate)
            : base(name,ProductCategory.OutdoorToys, productioncost, sellingPrice, quantity, productionDate)
        {
        }
        
        public override void Describe()
        {
            Console.WriteLine("---Frisbee---");
            base.Describe();
        }
    }
}