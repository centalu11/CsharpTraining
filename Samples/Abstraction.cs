using System.Linq;

namespace CsharpTraining;

abstract class CommercialCar
{

    public double Speed { get; private set; }
    public double TopSpeed { get; protected set; }
    public double TotalDistance { get; protected set; }
    
    public double TotalTime { get; protected set; }
    public double RideFee { get; protected set; }

    public CommercialCar()
    {
        this.Speed = 0;
        this.TotalDistance = 0;
        this.TotalTime = 0;
    }

    public void Gas(double acceleration, double time)
    {
        if (this.Speed >= this.TopSpeed)
        {
            acceleration = 0;
        }

        double distance = (this.Speed * time) + (acceleration * (time * time) * 0.5);
        this.Speed += acceleration * time;

        this.TotalTime += time;
        this.TotalDistance += distance;
    }
    
    public abstract void SetFee();
}

class Bus : CommercialCar
{
    public record BusStop (double Destination, double Fee);
    public BusStop[] BusStops { get; set; }

    public Bus(double topSpeed, BusStop[] busStops)
    {
        this.TopSpeed = topSpeed;
        this.RideFee = 0;
        this.BusStops = busStops;
    }

    public override void SetFee()
    {
        try
        {
            this.RideFee = (from  busStop in this.BusStops
                where this.TotalDistance < busStop.Destination
                select busStop.Fee).First();
        } catch (InvalidOperationException)
        {
            Console.WriteLine("This is the last destination");
            Environment.Exit(0);
        }
    }
}

class Taxi : CommercialCar
{
    public double InitialFee { get; init; }
    public double TimeIntervalTreshold { get; init; }
    public double DistanceTreshold { get; init; }
    public double TimeIntervalCharge { get; init; }
    public double DistanceCharge { get; init; }

    public Taxi(double topSpeed, double initialFee, double timeIntervalTreshold, double distanceTreshold, double timeIntervalCharge, double distanceCharge)
    {
        this.TopSpeed = topSpeed;
        this.InitialFee = initialFee;
        this.TimeIntervalTreshold = timeIntervalTreshold;
        this.DistanceTreshold = distanceTreshold;
        this.TimeIntervalCharge = timeIntervalCharge;
        this.DistanceCharge = distanceCharge;
        this.RideFee = this.InitialFee;
    }

    public override void SetFee()
    {
        int timeMultiplier = (int) (this.TotalTime / this.TimeIntervalTreshold);
        int distanceMultipler = (int) (this.TotalDistance / this.DistanceTreshold);

        double timeFee = this.TimeIntervalCharge * timeMultiplier;
        double distanceFee = this.DistanceCharge * distanceMultipler;

        this.RideFee = this.InitialFee + timeFee + distanceFee;
    }
}
