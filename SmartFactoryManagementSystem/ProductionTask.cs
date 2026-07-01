using System;

namespace SmartFactoryManagementSystem
{
    public enum Priority
    {
        Low,
        Medium,
        High
    }

      

        

    public abstract class ProductionTask
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

        public int CompareTo(ProductionTask? other)
        {
            if (other is null)
            {
                return 1;
            }

            int priorityComparison = orderPriority.CompareTo(other.orderPriority);
            if (priorityComparison != 0)
            {
                return -priorityComparison;
            }

            return string.Compare(taskId, other.taskId, StringComparison.OrdinalIgnoreCase);
        }
    }
}
