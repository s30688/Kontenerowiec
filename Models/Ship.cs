namespace Kontenerowiec.Models
{
    public class Ship
    {
        public string Name { get; }
        public int MaxContainerCount { get; }
        public double MaxWeight { get; } // tons
        public double MaxSpeed { get; }
        private readonly List<Container> containers = new();

        public Ship(string name, int maxContainerCount, double maxWeight, double maxSpeed)
        {
            Name = name;
            MaxContainerCount = maxContainerCount;
            MaxWeight = maxWeight;
            MaxSpeed = maxSpeed;
        }

        public bool LoadContainer(Container container)
        {
            if (containers.Count >= MaxContainerCount) return false;

            double totalWeight = containers.Sum(c => c.OwnWeight + c.CurrentLoad);
            double incomingWeight = container.OwnWeight + container.CurrentLoad;

            if (totalWeight + incomingWeight > MaxWeight * 1000) return false;

            containers.Add(container);
            return true;
        }

        public bool RemoveContainer(string serialNumber)
        {
            var container = containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            return container != null && containers.Remove(container);
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Ship: {Name}, Containers: {containers.Count}/{MaxContainerCount}, MaxWeight: {MaxWeight}t");
            foreach (var c in containers)
                Console.WriteLine($" - {c}");
        }

        public List<Container> GetContainers() => containers;
    }
}
