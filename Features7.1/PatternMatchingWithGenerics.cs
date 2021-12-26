using static System.Console;

namespace Features7._1;

public class Animal
{

}

public class Pig : Animal
{

}

public class PatternMatchingWithGenerics
{
    public static void Cook<T>(T animal)
        where T : Animal
    {
        // note the red squiggly!
        // cast is redundant here
        if ((object)animal is Pig pig)
        {
            // cook and eat it
            Write("We cooked and ate the pork...");
        }

        switch (/*(object)*/animal)
        {
            case Pig pork:
                WriteLine(" and it tastes delicious!");
                break;
        }
    }

    /// <summary>
    /// Need to fall back to C# 7 for this.
    /// </summary>
    static void Main(string[] args)
    {
        var pig = new Pig();
        Cook(pig);
    }
}