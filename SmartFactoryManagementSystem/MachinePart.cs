using System;

namespace SmartFactoryManagementSystem
{
    public abstract class MachinePart
    {
        private readonly string partId;
        private readonly string name;
        private double wearLevel;
        private readonly bool isRequired;

        public MachinePart(string partId, string name, bool isRequired)
        {
            this.partId = partId;
            this.name = name;
            this.isRequired = isRequired;
            this.wearLevel = 0;
        }

        public void Degrade(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Wear amount cannot be negative.");
            }

            wearLevel += amount;
        }

        public void ReplacePart()
        {
            wearLevel = 0;
        }

        public bool IsFunctional()
        {
            return wearLevel < 100;
        }

        public string GetName()
        {
            return name;
        }

        public string GetPartId()
        {
            return partId;
        }

        public double GetWearLevel()
        {
            return wearLevel;
        }

        public bool IsRequired()
        {
            return isRequired;
        }
    }
}