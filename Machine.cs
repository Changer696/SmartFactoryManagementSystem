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
        }

        public abstract bool Produce(Product product, int quantity);

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
        }

        public void Repair()
        {
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
    }
}