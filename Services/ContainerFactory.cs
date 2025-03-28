using Kontenerowiec.Models;

namespace Kontenerowiec.Services
{
    public static class ContainerFactory
    {
        public static Container CreateLiquid(double ownWeight, double maxLoad, bool isHazardous)
            => new LiquidContainer(ownWeight, maxLoad, isHazardous);

        public static Container CreateGas(double ownWeight, double maxLoad, double pressure)
            => new GasContainer(ownWeight, maxLoad, pressure);

        public static Container CreateCooling(double ownWeight, double maxLoad, string type, double requiredTemp, double containerTemp)
            => new CoolingContainer(ownWeight, maxLoad, type, requiredTemp, containerTemp);
    }
}
