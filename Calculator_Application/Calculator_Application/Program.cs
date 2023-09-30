using System;

class Program
{
    static void Main()
    {
        Calculator objCallByConstructor = new Calculator(2,5,3);
        Console.WriteLine($"\nCalculate Value by Constructor Result is:{objCallByConstructor.Add()}");
        
        Calculator obj = new Calculator();
        Console.WriteLine($"\nCalculate Value by Method Result is:{obj.Add(2,5)}");
        
        Console.ReadKey();
        
    }
}
