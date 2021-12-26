using static System.Console;

namespace Features7._1;

public class InferTupleNames
{
    // Tuple projection initializers
    public static void Main(string[] args)
    {
        // reminder: tuples
        var me = (name: "Luis", age: 37);
        WriteLine(me);

        var alsoMe = (me.age, me.name);
        WriteLine(alsoMe.Item1); // typical
        WriteLine(alsoMe.name); // new

        var result = new[] { "March", "April", "May" } // explicit name not required
            .Select(m => (
                /*Length:*/ m/*?*/.Length, // optionally nullable
                FirstChar: m[0])) // some names (e.g., ToString) disallowed
            .Where(t => t.Length == 5); // note how .Length is available here
        WriteLine(string.Join(",", result));

        // tuples produced by deconstruction
        var now = DateTime.UtcNow;
        var u = (now.Hour, now.Minute);
        var v = ((u.Hour, u.Minute) = (11, 12));
        WriteLine(v.Minute);
    }
}