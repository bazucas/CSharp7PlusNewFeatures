using static System.Console;

namespace Features7;

public class AnotherPoint
{
    public int X, Y;

    public void Deconstruct(out string s)
    {
        s = $"{X}-{Y}";
    }

    public void Deconstruct(out int x, out int y)
    {
        x = X;
        y = Y;
    }
}

public class Tuples
{
    static Tuple<double, double> SumAndProduct(double a, double b)
    {
        return Tuple.Create(a + b, a * b);
    }

    static (double sum, double product) NewSumAndProduct(double a, double b)
    {
        return (a + b, a * b);
    }

    static void MainT(string[] args)
    {
        // New
        var sp = SumAndProduct(2, 5);
        // sp.Item1 ugly
        WriteLine($"sum = {sp.Item1}, product = {sp.Item2}");

        var sp2 = NewSumAndProduct(2, 5);
        WriteLine($"new sum = {sp2.sum}, product = {sp2.product}");
        WriteLine($"Item1 = {sp2.Item1}");
        WriteLine(sp2.GetType());

        // converting to valuetuple loses all info
        var vt = sp2;
        // back to Item1, Item2, etc...
        var item1 = vt.Item1; // :(

        // can use var below
        //(double sum, var product) = NewSumAndProduct(3, 5);
        var (sum, product) = NewSumAndProduct(3, 5);

        // note! var works but double doesn't
        // double (s, p) = NewSumAndProduct(3, 4);

        WriteLine($"sum = {sum}, product = {product}");
        WriteLine(sum.GetType());

        // also assignment
        double s, p;
        (s, p) = NewSumAndProduct(1, 10);

        // tuple declarations with names
        //var me = new {name = "Luis", age = 37}; // AnonymousType
        var me = (name: "Luis", age: 37);
        WriteLine(me);
        WriteLine(me.GetType());

        // names are not part of the type:
        WriteLine("Fields: " + string.Join(",", me.GetType().GetFields().Select(pr => pr.Name)));
        WriteLine("Properties: " + string.Join(",", me.GetType().GetProperties().Select(pr => pr.Name)));

        WriteLine($"My name is {me.name} and I am {me.age} years old");
        // proceed to show return: TupleElementNames in dotPeek (internally, Item1 etc. are used everywhere)

        // unfortunately, tuple names only propagate out of a function if they're in the signature
        var snp = new Func<double, double, (double sum, double product)>((a, b) => (sum: a + b, product: a * b));
        var result = snp(1, 2);
        // there's no result.sum unless you add it to signature
        WriteLine($"sum = {result.sum}");

        // deconstruction
        AnotherPoint pt = new AnotherPoint { X = 2, Y = 3 };
        var (x, y) = pt; // interesting error here
        WriteLine($"Got a point x = {x}, y = {y}");

        // can also discard values
        (int z, _) = pt;
    }
}