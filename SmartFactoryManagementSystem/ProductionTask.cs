using System;

namespace SmartFactoryManagementSystem
{
    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public class Product
    {
        private readonly string name;
        private readonly double productionCost;
        private readonly double sellingPrice;
        private int quantity;

        public Product(string name, double productionCost, double sellingPrice, int quantity)
        {
            this.name = name;
            this.productionCost = productionCost;
            this.sellingPrice = sellingPrice;
            this.quantity = quantity;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public void SetQuantity(int qty)
        {
            if (qty < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(qty), "Quantity cannot be negative.");
            }

            quantity = qty;
        }

        public double GetSellingPrice()
        {
            return sellingPrice;
        }

        public double GetProductionCost()
        {
            return productionCost;
        }

        public string GetName()
        {
            return name;
        }
    }

    public class ProductionTask
    {
        private readonly string taskId;
        private readonly Product targetProduct;
        private readonly int targetQuantity;
        private bool isCompleted;
        private readonly Priority orderPriority;

        public ProductionTask(string taskId, Product targetProduct, int targetQuantity, Priority orderPriority)
        {
            if (string.IsNullOrWhiteSpace(taskId))
            {
                throw new ArgumentException("Task ID cannot be empty.", nameof(taskId));
            }

            if (targetProduct is null)
            {
                throw new ArgumentNullException(nameof(targetProduct));
            }

            if (targetQuantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(targetQuantity), "Target quantity must be greater than zero.");
            }

            this.taskId = taskId;
            this.targetProduct = targetProduct;
            this.targetQuantity = targetQuantity;
            this.orderPriority = orderPriority;
            this.isCompleted = false;
        }

        public void CompleteTask()
        {
            isCompleted = true;
        }

        public bool IsCompleted()
        {
            return isCompleted;
        }

        public Product GetTargetProduct()
        {
            return targetProduct;
        }

        public int GetTargetQuantity()
        {
            return targetQuantity;
        }

        public string GetTaskId()
        {
            return taskId;
        }

        public Priority GetPriority()
        {
            return orderPriority;
        }
    }
}
