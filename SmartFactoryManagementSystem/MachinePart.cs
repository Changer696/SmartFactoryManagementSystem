using System;
using System.Xml.Linq;

namespace SmartFactoryManagementSystem
{

    public enum MachineMaterial
    {
        Unknown,
        Glue,
        Wood,
        Paint,
        Thread
    }



    public abstract class MachinePart
    {
  
        private readonly string partId;
        private readonly string name;
        private readonly MachineMaterial material;
        private double wearLevel;
        private readonly bool isRequired;

        public MachinePart(string partId, string name, bool isRequired)
            : this(partId, name, isRequired, MachineMaterial.Unknown)
        {
        }

        public MachinePart(string partId, string name, bool isRequired, MachineMaterial material)
        {
            this.partId = partId;
            this.name = name;
            this.isRequired = isRequired;
            this.material = material;
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

        public MachineMaterial GetMaterial()
        {
            return material;
        }

    }
}

