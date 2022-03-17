
using CsharpTraining;

var taxi = new Taxi(
    topSpeed: 55,
    initialFee: 50,
    timeIntervalTreshold: 60,
    distanceTreshold: 5,
    timeIntervalCharge: .55,
    distanceCharge: .52
);

while (true)
{
    Console.WriteLine("Distance: " + taxi.TotalDistance);
    Console.WriteLine("Time: " + taxi.TotalTime);
    Console.WriteLine("Speed: " + taxi.Speed);
    Console.WriteLine("Fee: " + taxi.RideFee);
    Console.WriteLine();

    taxi.Gas(5, 2);
    taxi.SetFee();

    Console.Write("Continue Driving: ");
    if (Console.ReadKey().Key != ConsoleKey.Y)
    {
        break;
    }
    Console.WriteLine();    
}
Console.WriteLine();
Console.WriteLine("Destination Reached!");

Bus.BusStop[] busStops = {
    new Bus.BusStop(1000, 12),
    new Bus.BusStop(2000, 15),
    new Bus.BusStop(3500, 17),
    new Bus.BusStop(5000, 22),
    new Bus.BusStop(5500, 25),
};

// var bus = new Bus(50, busStops);

// while (true)
// {
//     Console.WriteLine("Distance: " + bus.TotalDistance);
//     Console.WriteLine("Time: " + bus.TotalTime);
//     Console.WriteLine("Speed: " + bus.Speed);
//     Console.WriteLine("Fee: " + bus.RideFee);
//     Console.WriteLine();

//     bus.Gas(5, 2);
//     bus.SetFee();

//     Console.Write("Continue Driving: ");
//     if (Console.ReadKey().Key != ConsoleKey.Y)
//     {
//         break;
//     }
//     Console.WriteLine();    
// }
// Console.WriteLine();
// Console.WriteLine("Destination Reached!");