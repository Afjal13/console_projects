using System;

class Program
{
    static void Main()
    {
        Calculator objCallByConstructor = new Calculator(12,3);
        Console.WriteLine($"\nCalculate Add Value by Constructor Result is:{objCallByConstructor.Add()}");
        Console.WriteLine($"\nCalculate Substract Value by Constructor Result is:{objCallByConstructor.Substract()}");
        Console.WriteLine($"\nCalculate Div Value by Constructor Result is:{objCallByConstructor.Div()}");
        Console.WriteLine($"\nCalculate Multiply Value by Constructor Result is:{objCallByConstructor.Multiply()}");
        
        Calculator obj = new Calculator();
        Console.WriteLine($"\nCalculate Add Value by Method Result is:{obj.Add(2,5)}");
        
        Console.ReadKey();
        
    }
}
