using System;

public class Calculator
{
    public int Value1 { get; set; }
    public int Value2 { get; set; }
    public int Value3 { get; set; }
    public int Result { get; set; }

    public Calculator()
    {
        Result = 0;
    }

    public Calculator(int value1) : this()
    {
        Value1 = value1;
    }

    public Calculator(int value1, int value2) : this(value1)
    {
        Value2 = value2;
    }

    public Calculator(int value1, int value2, int value3) : this(value1, value2)
    {
        Value3 = value3;
    }

    public int Add()
    {
        Result = Value1 + Value2 + Value3;
        return Result;
    }

    public int Add(int value1, int value2)
    {
        Result = value1 + value2;
        return Result;
    }

    public int Add(int value1, int value2, int value3)
    {
        Result = value1 + value2 + value3;
        return Result;
    }

    public int Substract()
    {
        Result = Value1 - Value2 - Value3;
        return Result;
    }

    public int Substract(int value1, int value2)
    {
        Result = value1 - value2;
        return Result;
    }

    public int Substract(int value1, int value2, int value3)
    {
        Result = value1 - value2 - value3;
        return Result;
    }
    public int Div()
    {
        Result = (int)Value1 / Value2;
        return Result;
    }

    public int Div(int value1, int value2)
    {
        Result = (int)(value1 / value2);
        return Result;
    }

    public int Multiply()
    {
        if(Value3==0)
            Result = Value1 * Value2;
        else
            Result = Value1 * Value2 * Value3;
        return Result;
    }

    public int Multiply(int value1, int value2)
    {
        Result = value1 * value2;
        return Result;
    }

    public int Multiply(int value1, int value2, int value3)
    {
        Result = value1 * value2 * value3;
        return Result;
    }

}
