using static System.Console;

namespace Features7;

public class Demo
{
    public static void Main(string[] args)
    {
        var myPoint = new Point();
        var (x, _) = myPoint;
        WriteLine($"{x}");
    }
}

public class Point
{
    public int X, Y;

    // deconstruction
    public void Deconstruct(out int x, out int y)
    {
        x = X;
        y = Y;
    }
}

