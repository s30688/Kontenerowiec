namespace Kontenerowiec.Models
{
    public class CoolingContainer : Container
    {
        public string ProductType { get; }
        public double RequiredTemperature { get; }
        public double ContainerTemperature { get; }

        public CoolingContainer(double ownWeight, double maxLoad, string productType, double requiredTemp, double containerTemp)
            : base("C")
        {
            OwnWeight = ownWeight;
            MaxLoad = maxLoad;
            ProductType = productType;
            RequiredTemperature = requiredTemp;
            ContainerTemperature = containerTemp;
        }

        public override void Load(double weight)
        {
            if (ContainerTemperature < RequiredTemperature)
                throw new Exceptions.OverfillException($"Temperature too low in {SerialNumber}");

            base.Load(weight);
        }
    }
}
