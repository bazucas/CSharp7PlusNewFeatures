namespace Features7._2;

class NonTrailingNamedArguments
{
    static void doSomething(int foo, int bar)
    {

    }

    static void Main(string[] args)
    {
        doSomething(foo: 33, 44);
        doSomething(foo: 33, bar: 44);
        doSomething(33, 44);
        doSomething(33, bar: 44);
        doSomething(bar: 33, foo: 44);

        // still illegal
        //doSomething(33, foo:44)
        //doSomething(bar: 33, 44);
    }
}