using System;
using Kontenerowiec.Models;
using Kontenerowiec.Services;

class Program
{
    static void Main()
    {
        Console.WriteLine("SYSTEM ZARZĄDZANIA KONTENERAMI");
        
        Ship ship = new Ship("Evergreen", maxContainerCount: 5, maxWeight: 100, maxSpeed: 25);
        
        var liquid = ContainerFactory.CreateLiquid(ownWeight: 1500, maxLoad: 8000, isHazardous: true);
        var gas = ContainerFactory.CreateGas(ownWeight: 2000, maxLoad: 10000, pressure: 15);
        var cooling = ContainerFactory.CreateCooling(ownWeight: 1800, maxLoad: 12000, type: "Bananas", requiredTemp: 5, containerTemp: 6);
        
        try
        {
            liquid.Load(3500); // OK (50% of 8000)
            gas.Load(9500);    // OK
            cooling.Load(10000); // OK
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] {ex.Message}");
        }
        
        ship.LoadContainer(liquid);
        ship.LoadContainer(gas);
        ship.LoadContainer(cooling);
        
        Console.WriteLine("\nINFORMACJE O STATKU");
        ship.PrintInfo();
        
        gas.Unload();
        Console.WriteLine($"\nPo rozładunku gazu: {gas}");
        
        ship.RemoveContainer(liquid.SerialNumber);
        Console.WriteLine($"\nUsunięto kontener: {liquid.SerialNumber}");

        Console.WriteLine("\nKOŃCOWY STAN STATKU");
        ship.PrintInfo();
    }
}