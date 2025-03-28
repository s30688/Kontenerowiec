using Kontenerowiec.Interfaces;
using Kontenerowiec.Exceptions;

namespace Kontenerowiec.Models
{
    public class GasContainer : Container, IHazardNotifier
    {
        public double Pressure { get; }

        public GasContainer(double ownWeight, double maxLoad, double pressure)
            : base("G")
        {
            OwnWeight = ownWeight;
            MaxLoad = maxLoad;
            Pressure = pressure;
        }

        public override void Load(double weight)
        {
            if (weight > MaxLoad)
            {
                NotifyHazard("Gas container overloaded", SerialNumber);
                throw new OverfillException($"Gas load too high in {SerialNumber}");
            }

            base.Load(weight);
        }

        public override void Unload()
        {
            CurrentLoad *= 0.05; // zostaje 5%
        }

        public void NotifyHazard(string message, string containerNumber)
        {
            Console.WriteLine($"[HAZARD] {message} in container {containerNumber}");
        }
    }
}
