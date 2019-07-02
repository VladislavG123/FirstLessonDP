using System;

class Client
{
    public void Main()
    {
        Console.WriteLine("Информация по телефону Samsung");
        GetInformation(new Samsung());
        Console.WriteLine();

        Console.WriteLine("Информация по телефону Nokia");
        GetInformation(new Nokia());
    }

    public void GetInformation(IPhone factory)
    {
        IDisplay display = factory.CreateDisplay();
        IAccumulator accumulator = factory.CreateAccumulator();

        Console.WriteLine($"Заряд батарии {display.GetAccumulatorVolume(accumulator)}");
    }
}

public interface IDisplay
{
    string GetAccumulatorVolume(IAccumulator accumulator);
}

public interface IAccumulator
{
    int MaxVolume { get; set; }
    int CurrentVolume { get; set; }
}

public class Nokia : IPhone
{
    public IDisplay CreateDisplay()
    {
        return new NokiaDisplay();
    }

    public IAccumulator CreateAccumulator()
    {
        return new NokiaAccumulator { CurrentVolume = 0, MaxVolume = 3000 };
    }
}

internal class NokiaAccumulator : IAccumulator
{
    public int MaxVolume { get; set; }
    public int CurrentVolume { get; set; }
}

public class SamsungDisplay : IDisplay
{
    public string GetAccumulatorVolume(IAccumulator accumulator)
    {
        return $"{accumulator.CurrentVolume}/{accumulator.MaxVolume}";
    }
}

public class NokiaDisplay : IDisplay
{
    public string GetAccumulatorVolume(IAccumulator accumulator)
    {
        return $"{accumulator.CurrentVolume}/{accumulator.MaxVolume}";
    }
}


public class Samsung : IPhone
{
    public IDisplay CreateDisplay()
    {
        return new SamsungDisplay();
    }

    public IAccumulator CreateAccumulator()
    {
        return new SamsungAccumulator { CurrentVolume = 0, MaxVolume = 5000 };
    }
}

internal class SamsungAccumulator : IAccumulator
{
    public int MaxVolume { get; set; }
    public int CurrentVolume { get; set; }
}

public interface IPhone
{
    IDisplay CreateDisplay();
    IAccumulator CreateAccumulator();
}

class Program
{
    static void Main(string[] args)
    {
        new Client().Main();
        Console.Read();
    }
}


