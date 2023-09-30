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
    //  public Calculator(int Value1, int Value2)
    //  {
    //      this.Value1 = Value1;
    //      this.Value2 = Value2;
    //      Result = 0;
    //  }
    //  public Calculator(int Value1, int Value2, int Value3)
    //  {
    //this.Value1 = Value1; 
    //this.Value2 = Value2; 
    //this.Value3 = Value3;
    //      Result = 0;

    //  }

    public int Add(int Value1, int Value2)
    {
        Result = Value1 + Value2;

        return Result;
    }

}
