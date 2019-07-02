using System;

// TODO: раскомментировать программный код и воссоздать его работоспособность
//       не допускается изменение клиентского кода

class Client
{
    public void Main()
    {
        Console.WriteLine("Client: Testing client code with the first factory type...");
        ClientMethod(new ConcreteFactory1());
        Console.WriteLine();

        Console.WriteLine("Client: Testing the same client code with the second factory type...");
        ClientMethod(new ConcreteFactory2());
    }

    public void ClientMethod(IAbstractFactory factory)
    {
        IAbstractProductA productA = factory.CreateProductA();
        IAbstractProductB productB = factory.CreateProductB();

        Console.WriteLine(productB.UsefulFunctionB());
        Console.WriteLine(productB.AnotherUsefulFunctionB(productA));
    }
}

public interface IAbstractProductA
{
}
public interface IAbstractProductB
{
    string AnotherUsefulFunctionB(IAbstractProductA productA);
    string UsefulFunctionB();

}

public class ConcreteFactory2 : IAbstractFactory
{
    public IAbstractProductA CreateProductA()
    {
        return new ConcreteProductA2();
    }

    public IAbstractProductB CreateProductB()
    {
        return new ConcreteProductB2();
    }
}

internal class ConcreteProductB2 : IAbstractProductB
{
    public string AnotherUsefulFunctionB(IAbstractProductA productA)
    {
        return "The result of the B2 collaborating with the " + productA;
    }

    public string UsefulFunctionB()
    {
        return "The result of the product B2.";
    }
}

public class ConcreteProductA1 : IAbstractProductA
{

}

public class ConcreteProductA2 : IAbstractProductA
{

}


public class ConcreteFactory1 : IAbstractFactory
{
    public IAbstractProductA CreateProductA()
    {
        return new ConcreteProductA1();
    }

    public IAbstractProductB CreateProductB()
    {
        return new ConcreteProductB1();
    }
}

internal class ConcreteProductB1 : IAbstractProductB
{
    public string AnotherUsefulFunctionB(IAbstractProductA productA)
    {
        return "The result of the B2 collaborating with the " + productA;
    }

    public string UsefulFunctionB()
    {
        return "The result of the product B1.";
    }
}

public interface IAbstractFactory
{
    IAbstractProductA CreateProductA();
    IAbstractProductB CreateProductB();
}

class Program
{
    static void Main(string[] args)
    {
        new Client().Main();
        Console.Read();
    }
}


// Пример вывода программы (закомментирован для удобства)
/*
Client: Testing client code with the first factory type...
The result of the product B1.
The result of the B1 collaborating with the (The result of the product A1.)

Client: Testing the same client code with the second factory type...
The result of the product B2.
The result of the B2 collaborating with the (The result of the product A2.)
*/
