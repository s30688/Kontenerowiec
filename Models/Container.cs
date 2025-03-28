namespace Kontenerowiec.Models
{
    public abstract class Container
    {
        private static int counter = 1;

        public string SerialNumber { get; }
        public double OwnWeight { get; set; }
        public double MaxLoad { get; set; }
        public double CurrentLoad { get; protected set; }

        protected Container(string typeCode)
        {
            SerialNumber = $"KON-{typeCode}-{counter++}";
        }

        public virtual void Load(double weight)
        {
            if (CurrentLoad + weight > MaxLoad)
                throw new Exceptions.OverfillException($"Container {SerialNumber} overloaded!");

            CurrentLoad += weight;
        }

        public virtual void Unload()
        {
            CurrentLoad = 0;
        }

        public override string ToString() => $"{SerialNumber} - Load: {CurrentLoad}/{MaxLoad}";
    }
}
