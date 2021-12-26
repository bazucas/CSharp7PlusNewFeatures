using static System.Console;

namespace Features7;

public class ThrowExpressions
{
    public string Name { get; set; }

    public ThrowExpressions(string name)
    {
        Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
    }

    int GetValue(int n)
    {
        return n > 0 ? n + 1 : throw new Exception();
    }

    static void MainTE(string[] args)
    {
        int v = -1;
        try
        {
            var te = new ThrowExpressions("");
            v = te.GetValue(-1); // does not get defaulted!
        }
        catch (Exception e)
        {
            WriteLine(e);
        }
        finally
        {
            WriteLine(v);
        }
    }
}