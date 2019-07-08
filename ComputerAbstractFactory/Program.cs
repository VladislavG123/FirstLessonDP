using System;

class Client
{
    public void Main()
    {
        Console.WriteLine("Info about Dell");
        GetInformation(new Dell());
        Console.WriteLine();

        Console.WriteLine("Info about Sony");
        GetInformation(new Sony());
    }

    public void GetInformation(IComputer factory)
    {
        IMainboard mainboard = factory.CreateMainboard();
        IProcessor processor = factory.CraeteProcessror();

        Console.WriteLine($"Processor type {mainboard.GetProcessorType(processor)}");
    }
}

public interface IMainboard
{
    string GetProcessorType(IProcessor accumulator);
    string GetInformation();
}

public interface IProcessor
{
    string GetInformation();
}

public class Sony : IComputer
{
    public IMainboard CreateMainboard()
    {
        return new SonyMainboard();
    }

    public IProcessor CraeteProcessror()
    {
        return new SonyProcessor();
    }
}

internal class SonyProcessor : IProcessor
{
    public string GetInformation()
    {
        return "Intel core i3";
    }
}

public class DellMainboard : IMainboard
{
    public string GetProcessorType(IProcessor processor)
    {
        return $"{processor.GetInformation()}";
    }

    public string GetInformation()
    {
        return "Dell mainboard";
    }
}

public class SonyMainboard : IMainboard
{
    public string GetProcessorType(IProcessor processor)
    {
        return $"{processor.GetInformation()}";
    }

    public string GetInformation()
    {
        return "Sony mainboard";
    }
}


public class Dell : IComputer
{
    public IMainboard CreateMainboard()
    {
        return new DellMainboard();
    }

    public IProcessor CraeteProcessror()
    {
        return new DellProcessor();
    }
}

internal class DellProcessor : IProcessor
{
    public string GetInformation()
    {
        return "Intel core i7";
    }
}

public interface IComputer
{
    IMainboard CreateMainboard();
    IProcessor CraeteProcessror();
}

class Program
{
    static void Main(string[] args)
    {
        new Client().Main();
        Console.Read();
    }
}


