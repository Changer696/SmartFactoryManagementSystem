using System;
using System.Collections.Generic;

namespace SmartFactoryManagementSystem
{
    public enum MachineStatus
    {
        Running,
        Stopped,
        Maintenance
    }

    public enum MachineCondition
    {
        Excellent,
        Good,
        Critical
    }

    public abstract class Machine
    {
        private readonly string serialNumber;
        private readonly string name;
        private MachineStatus status;
        private MachineCondition condition;
        private readonly List<MachinePart> parts;
        private readonly DateTime installationDate;

        protected Machine(string serialNumber, string name, DateTime installationDate)
        {
            if (string.IsNullOrWhiteSpace(serialNumber))
            {
                throw new ArgumentException("Serial number cannot be empty.", nameof(serialNumber));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Machine name cannot be empty.", nameof(name));
            }

            this.serialNumber = serialNumber;
            this.name = name;
            this.installationDate = installationDate;
            this.status = MachineStatus.Stopped;
            this.condition = MachineCondition.Good;
            this.parts = new List<MachinePart>();

            AddPart(new MachinePart("MAT-001", "Glue", true, MachineMaterial.Glue));
            AddPart(new MachinePart("MAT-002", "Wood", true, MachineMaterial.Wood));
            AddPart(new MachinePart("MAT-003", "Paint", true, MachineMaterial.Paint));
            AddPart(new MachinePart("MAT-004", "Thread", true, MachineMaterial.Thread));
        }

       

        public abstract string RunDiagnostics();

        public void Start()
        {
            status = MachineStatus.Running;
        }

        public void Stop()
        {
            status = MachineStatus.Stopped;
        }

        public void AddPart(MachinePart part)
        {
            if (part is null)
            {
                throw new ArgumentNullException(nameof(part));
            }

            parts.Add(part);
            UpdateConditionFromParts();
        }

        public void DegradeParts(double amount)
        {
            foreach (var part in parts)
            {
                part.Degrade(amount);
            }

            UpdateConditionFromParts();
        }

        protected bool ConsumeMaterialsForProduction(int quantity)
        {
            if (quantity <= 0)
            {
                return false;
            }

            double wearAmount = quantity;
            foreach (var part in parts)
            {
                part.Degrade(wearAmount);
            }

            UpdateConditionFromParts();
            return true;
        }

        public void Repair()
        {
            foreach (var part in parts)
            {
                part.ReplacePart();
            }

            status = MachineStatus.Maintenance;
            condition = MachineCondition.Good;
        }

        public void Inspect()
        {
            if (condition == MachineCondition.Critical)
            {
                status = MachineStatus.Maintenance;
            }
        }

        public TimeSpan GetAge()
        {
            return DateTime.Now - installationDate;
        }

        public MachineStatus GetStatus()
        {
            return status;
        }

        public void SetStatus(MachineStatus status)
        {
            this.status = status;
        }

        public MachineCondition GetCondition()
        {
            return condition;
        }

        public void SetCondition(MachineCondition condition)
        {
            this.condition = condition;
        }

        public IReadOnlyList<MachinePart> GetParts()
        {
            return parts;
        }

        public string GetSerialNumber()
        {
            return serialNumber;
        }

        public string GetName()
        {
            return name;
        }

        private void UpdateConditionFromParts()
        {
            if (parts.Count == 0)
            {
                return;
            }

            bool hasCriticalPart = false;
            foreach (var part in parts)
            {
                if (!part.IsFunctional())
                {
                    hasCriticalPart = true;
                    break;
                }
            }

            if (hasCriticalPart)
            {
                condition = MachineCondition.Critical;
                status = MachineStatus.Maintenance;
            }
            else if (parts.Exists(p => p.GetWearLevel() >= 50))
            {
                condition = MachineCondition.Good;
            }
            else
            {
                condition = MachineCondition.Excellent;
            }
        }
    }
}