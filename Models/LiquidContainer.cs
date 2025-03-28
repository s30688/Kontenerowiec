using Kontenerowiec.Interfaces;
using Kontenerowiec.Exceptions;

namespace Kontenerowiec.Models
{
    public class LiquidContainer : Container, IHazardNotifier
    {
        public bool IsHazardous { get; }

        public LiquidContainer(double ownWeight, double maxLoad, bool isHazardous)
            : base("L")
        {
            OwnWeight = ownWeight;
            MaxLoad = maxLoad;
            IsHazardous = isHazardous;
        }

        public override void Load(double weight)
        {
            double limit = IsHazardous ? MaxLoad * 0.5 : MaxLoad * 0.9;

            if (weight > limit)
            {
                NotifyHazard("Hazardous load limit exceeded", SerialNumber);
                throw new OverfillException($"Attempted to load {weight}kg into {SerialNumber}.");
            }

            base.Load(weight);
        }

        public void NotifyHazard(string message, string containerNumber)
        {
            Console.WriteLine($"[HAZARD] {message} in container {containerNumber}");
        }
    }
}
