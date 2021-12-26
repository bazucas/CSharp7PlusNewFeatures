namespace Features7._2;

public class Base
{
    private int a;
    protected internal int b; // derived classes or classes in same assembly
    private protected int c;  // containing class or derived classes in same assembly only 
}

class Derived : Base
{
    public Derived()
    {
        c = 333; // fine

        b = 3; // no
    }
}

class Foo
{
    static void Main(string[] args)
    {
        Base pp = new Base();
        var d = new Derived();
        d.b = 3;
        // d.c is a no-go
    }
}