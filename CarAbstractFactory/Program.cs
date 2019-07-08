using System;

class Client
{
    public void Main()
    {
        Console.WriteLine("Info about Ford");
        GetInformation(new Ford());
        Console.WriteLine();

        Console.WriteLine("Info about Toyota");
        GetInformation(new Toyota());
    }

    public void GetInformation(ICar factory)
    {
        IBody body = factory.CreateBody();
        IEngine engine = factory.CreateEngine();

        Console.WriteLine($"Engine type {body.GetEngineType(engine)}");
    }
}

public interface IBody
{
    string GetEngineType(IEngine accumulator);
    string GetInformation();
}

public interface IEngine
{
    string GetInformation();
}

public class Toyota : ICar
{
    public IBody CreateBody()
    {
        return new ToyotaBody();
    }

    public IEngine CreateEngine()
    {
        return new ToyotaEngine();
    }
}

internal class ToyotaEngine : IEngine
{
    public string GetInformation()
    {
        return "2.5-Liter Dynamic Force 4-Cylinder DOHC 16-Valve D-4S Dual Injection";
    }
}

public class FordBody : IBody
{
    public string GetEngineType(IEngine engine)
    {
        return $"{engine.GetInformation()}";
    }

    public string GetInformation()
    {
        return "Ford body";
    }
}

public class ToyotaBody : IBody
{
    public string GetEngineType(IEngine engine)
    {
        return $"{engine.GetInformation()}";
    }

    public string GetInformation()
    {
        return "Unitized body with front and rear anti-vibration sub-frames";
    }
}


public class Ford : ICar
{
    public IBody CreateBody()
    {
        return new FordBody();
    }

    public IEngine CreateEngine()
    {
        return new FordEngine();
    }
}

internal class FordEngine : IEngine
{
    public string GetInformation()
    {
        return "Ford 5.0L Coyote V-8";
    }
}

public interface ICar
{
    IBody CreateBody();
    IEngine CreateEngine();
}

class Program
{
    static void Main(string[] args)
    {
        new Client().Main();
        Console.Read();
    }
}


